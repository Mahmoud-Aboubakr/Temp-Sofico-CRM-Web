import { Component, OnInit } from '@angular/core';
import { FormatterService } from 'src/app/core/services/Formatter.service';

import * as htmlToImage from 'html-to-image';
import * as download from 'downloadjs';

import { toPng, toJpeg, toBlob, toPixelData, toSvg } from 'html-to-image';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { TranslateService } from '@ngx-translate/core';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';

import { BranchService } from 'src/app/core/services/Branch.Service';
import { UtilService } from 'src/app/core/services/util.service';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { UserModel } from 'src/app/core/Models/DtoModels/UserModel';
import { UserService } from 'src/app/core/services/User.Service';
import { DashboardSalesClientSearchModel } from 'src/app/core/Models/SearchModels/DashboardSalesClientSearchModel';
import { ClientStatisticalModel } from 'src/app/core/Models/StatisticalModels/ClientStatisticalModel';
import { DashboardSalesClientService } from 'src/app/core/services/DashboardSalesClient.Service';
import { ManageSalesOrderComponent } from 'src/app/Modules/sales/components/manage-sales-order/manage-sales-order.component';
import { ManageClientSurveyComponent } from '../manage-client-survey/manage-client-survey.component';
import { ManageClientServiceRequestComponent } from '../manage-client-service-request/manage-client-service-request.component';
import { ManageActivityComponent } from '../manage-activity/manage-activity.component';
import { ManageClientComplainComponent } from '../manage-client-complain/manage-client-complain.component';
import { ClientQuotaSearchModel } from 'src/app/core/Models/SearchModels/ClientQuotaSearchModel';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { ClientQuotaListModel } from 'src/app/core/Models/ListModels/ClientQuotaListModel';
import { ClientQuotaService } from 'src/app/core/services/ClientQuota.Service';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { ClientQuotaHistoryListModel } from 'src/app/core/Models/ListModels/ClientQuotaHistoryListModel';

@Component({
  selector: 'app-client-statistical',
  templateUrl: './client-statistical.component.html',
  styleUrls: ['./client-statistical.component.scss']
})
export class ClientStatisticalComponent implements OnInit {

  current: UserModel;

  searchModel: DashboardSalesClientSearchModel = {
    clientId: 0,
    clientCode: ''
  } as DashboardSalesClientSearchModel;


  searchQuotaModel: ClientQuotaSearchModel = {
    itemId: 0,
    itemCode: '',
    clientId: 0,
    clientCode: '',
    Take: 20,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    TermBy:""
  }


  model: ClientStatisticalModel = {
    timelines: [],
    perfromanceModel: {
      label: '',
      percentage: 0,
      sales: 0,
      target: 0
    },
    clientModel: {
      branchCode: '',
      branchId: 0,
      branchName: '',
      cityName: '',
      clientAccountCode: '',
      clientAccountId: 0,
      clientCode: '',
      clientGroupName: '',
      clientId: 0,
      clientName: '',
      clientTypeName: '',
      creditBalance: 0,
      creditLimit: 0,
      governerateName: '',
      isActive: false,
      isTaxable: false,
      mobile: '',
      paymentTermId: 0,
      paymentTermName: '',
      phone: '',
      regionName: '',
      whatsApp: '',
      businessUnitCode: '',
      businessUnitId: 0,
      businessUnitName: "",
      cashGroupId: 0,
      cityCode: "",
      cityId: 0,
      clientClassificationId: 0,
      clientGroupCode: '',
      clientGroupId: 0,
      clientGroupSubCode: '',
      clientGroupSubId: 0,
      clientGroupSubName: '',
      clientTypeId: 0,
      commercialCode: '',
      governerateCode: '',
      governerateId: 0,
      inRoute: false,
      isCashDiscount: false,
      isChain: false,
      isNew: false,
      latitude: 0,
      locationLevelId: 0,
      longitude: 0,
      needValidation: false,
      regionId: 0,
      taxCode: ''
    } as ClientListModel

  } as ClientStatisticalModel;


  gridQuotaModel: ResponseModel<ClientQuotaHistoryListModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }

  isLoading = false;
  isLoadingQuota = false;

  TimeLineData: any;
  timeLineOptions: any;

  hourData: any;
  hourOptions: any;

  channelData: any;
  channelOptions: any;




  lblTarget = '';
  lblCurrent = '';

  lblOrders = '';


  CHOOSE = ''
  HEADER_MANAGE = ''

  timeLinePopup = false;
  performancePopup = false;
  ordrKBIPopup = false;
  channelPopup = false;
  salesHourPopup = false;

  venorPopup = false;
  hotPopup = false;
  itemPopup = false;

  constructor(

    private _user: UserService,
    private _FormatterService: FormatterService,
    private _DashboardSalesClientService: DashboardSalesClientService,
    private _branchService: BranchService,
    private _utilService: UtilService,
    private dialogService: DialogService,
    private config: DynamicDialogConfig,
    private ref: DynamicDialogRef,
    private _ClientQuotaService: ClientQuotaService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
  ) {

    this.current = _user.Current();
    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Target').subscribe((res) => { this.lblTarget = res });
    this._translateService.get('Sales').subscribe((res) => { this.lblCurrent = res });
    this._translateService.get('Orders').subscribe((res) => { this.lblOrders = res });

    this._translateService.get('Manage').subscribe((res) => { this.HEADER_MANAGE = res });
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });


    this.TimeLineData = {
      labels: [],
      datasets: [{
        type: 'line',
        label: this.lblTarget,
        borderColor: '#FFA500',
        borderWidth: 2,
        fill: false,
        data: [

        ]
      }, {
        type: 'bar',
        label: this.lblCurrent,
        backgroundColor: '#009688',
        data: [

        ],
        borderColor: 'white',
        borderWidth: 2
      }]
    };


    this.hourData = {
      labels: [],
      datasets: [{
        type: 'line',
        label: this.lblOrders,
        borderColor: '#FFA500',
        borderWidth: 2,
        fill: false,
        data: [

        ]
      }]
    };

    this.timeLineOptions = {
      plugins: {
        legend: {
          labels: {
            color: '#495057'
          }
        }
      },
      scales: {
        x: {
          ticks: {
            color: '#495057'
          },
          grid: {
            color: '#ebedef'
          }
        },
        y: {
          ticks: {
            color: '#495057',
            stepSize: 0.5

          },
          grid: {
            color: '#ebedef'
          },
          display: false


        }
      }
    };

    this.hourOptions = {
      plugins: {
        legend: {
          labels: {
            color: '#495057'
          }
        }
      },
      scales: {
        x: {
          ticks: {
            color: '#495057'
          },
          grid: {
            color: '#ebedef'
          }
        },
        y: {
          ticks: {
            color: '#495057',
            stepSize: 0.5

          },
          grid: {
            color: '#ebedef'
          },
          display: false


        }
      }
    };

    this.channelData = {
      labels: [],
      datasets: [
        {
          data: [],
          backgroundColor: [
            "#FF6384",
            "#36A2EB",
            "#FFCE56"
          ],
          hoverBackgroundColor: [
            "#FF6384",
            "#36A2EB",
            "#FFCE56"
          ]
        }
      ]
    };

    this.channelOptions = {
      plugins: {
        legend: {
          labels: {
            color: '#495057'
          },
          position: 'right'
        }
      }
    };



    if (this.config.data) {
      if (+this.config.data.clientId > 0) {
        this.searchModel.clientId = +this.config.data.clientId;
        this.searchQuotaModel.clientId = +this.config.data.clientId;
      }
    }


  }

  ngOnInit(): void {
    if (this.searchModel.clientId > 0) {
      this.getDahboard();
    }
    else {
      this.ref.close();
    }
  }

  async getDahboard() {
    this.isLoading = true;
    this.TimeLineData.labels = [];
    this.TimeLineData.datasets[0].data = [];
    this.TimeLineData.datasets[1].data = [];

    this._DashboardSalesClientService.GetALL(this.searchModel).then(res => {

      console.log(res);
      this.model = res.data;

      if (res.succeeded == true) {
        res.data.timelines.forEach(element => {
          this.TimeLineData.labels.push(element.lineLabel);
          this.TimeLineData.datasets[0].data.push(element.lineTarget);
          this.TimeLineData.datasets[1].data.push(element.lineValue);

        });
      }

      this.isLoading = false;
    })

  }

  manage(operation, id) {

    if (operation == 'order') {

      if (this.searchModel.clientId > 0 && id > 0) {

        var ref = this.dialogService.open(ManageSalesOrderComponent, {
          header: this.HEADER_MANAGE,
          data: {
            salesId: id,
            mode: 'e',
          },
          width: '95%',
          height: '95vh',
        });

      }

    }

    if (operation == 'servey') {
      if (this.searchModel.clientId > 0 && id > 0) {
        var ref = this.dialogService.open(ManageClientSurveyComponent, {
          header: this.HEADER_MANAGE,
          data: { clientServeyId: id },
          width: '1200px',
          height: '750px',
          contentStyle: { "overflow": "auto" },
          baseZIndex: 10000
        });
      }

    }
    if (operation == 'request') {

      if (this.searchModel.clientId > 0 && id > 0) {

        var ref = this.dialogService.open(ManageClientServiceRequestComponent, {
          header: this.HEADER_MANAGE,
          data: { requestId: id },
          width: '1000px',
          height: '750px',
          contentStyle: { "overflow": "auto" },
          baseZIndex: 10000
        });
      }

    }
    if (operation == "call") {

      if (this.searchModel.clientId > 0 && id > 0) {
        var ref = this.dialogService.open(ManageActivityComponent, {
          header: this.HEADER_MANAGE,
          data: { activityId: id },
          width: '400px',
          height: '720px',
          contentStyle: { "overflow": "auto" },
          baseZIndex: 10000
        });
      }

    }
    if (operation == "visit") {


      var ref = this.dialogService.open(ManageActivityComponent, {
        header: this.HEADER_MANAGE,
        data: { activityId: id },
        width: '1100px',
        height: '720px',
        contentStyle: { "overflow": "auto" },
        baseZIndex: 10000
      });

    }

    if (operation == "complain") {

      if (this.searchModel.clientId > 0 && id > 0) {
        var ref = this.dialogService.open(ManageClientComplainComponent, {
          header: this.HEADER_MANAGE,
          data: { complainId: id },
          width: '1000px',
          height: '750px',
          contentStyle: { "overflow": "auto" },
          baseZIndex: 10000
        });
      }

    }

    if (operation == "edit") {

    }


  }

  getFormated(number) {
    return this._FormatterService.kFormatter(number);
  }

  getCommaFormated(number) {
    return this._FormatterService.CommaFormatter(number);
  }


  export(element) {
    htmlToImage.toPng(document.getElementById(element))
      .then(function (dataUrl) {
        download(dataUrl, new Date().toISOString().split('.')[0].replace(/[^\d]/gi, '') + '.png');
      }).then(() => {

      });
  }


  async filter(event) {


    this.isLoadingQuota = true;
    this.searchQuotaModel.Skip = event.first;
    this.searchQuotaModel.Take = event.rows;


    this.searchQuotaModel.SortBy = { Order: "", Property: "" }
    if (event.sortField) {
      this.searchQuotaModel.SortBy.Property = event.sortField;
      if (event.sortOrder == 1) {
        this.searchQuotaModel.SortBy.Order = "asc";
      }
      else {
        this.searchQuotaModel.SortBy.Order = "desc";

      }
    }

    await this._ClientQuotaService.getHistory(this.searchQuotaModel.clientId,this.searchQuotaModel.itemId).then(res => {
      this.gridQuotaModel = res;
      this.isLoadingQuota = false;
    })


  }

}
