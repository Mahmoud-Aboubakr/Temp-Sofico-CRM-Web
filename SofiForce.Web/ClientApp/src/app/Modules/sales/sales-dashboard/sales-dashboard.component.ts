import { Component, OnInit } from '@angular/core';
import { FormatterService } from 'src/app/core/services/Formatter.service';

import * as htmlToImage from 'html-to-image';
import * as download from 'downloadjs';

import { toPng, toJpeg, toBlob, toPixelData, toSvg } from 'html-to-image';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { TranslateService } from '@ngx-translate/core';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { DateTypeModel } from 'src/app/core/Models/DtoModels/DateTypeModel';

import { BranchService } from 'src/app/core/services/Branch.Service';
import { UtilService } from 'src/app/core/services/util.service';
import { DashboardSalesService } from 'src/app/core/services/DashboardSales.Service';
import { ClientGroupListModel } from "src/app/core/Models/ListModels/ClientGroupListModel";
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { ChooserBranchComponent } from '../../shared/chooser-branch/chooser-branch.component';
import { DialogService } from 'primeng/dynamicdialog';
import { DashboardSalesModel } from 'src/app/core/Models/StatisticalModels/DashboardModel';
import { UserModel } from 'src/app/core/Models/DtoModels/UserModel';
import { UserService } from 'src/app/core/services/User.Service';
import { MenuService } from 'src/app/core/services/Menu.Service';
import { DashboardSearchModel } from 'src/app/core/Models/SearchModels/DashboardSearchModel';
import { BranchSearchModel } from 'src/app/core/Models/SearchModels/BranchSearchModel';
import { ClientGroupService } from 'src/app/core/services/ClientGroup.Service';
import { ClientGroupSearchModel } from 'src/app/core/Models/SearchModels/ClientGroupSearchModel';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';
@Component({
  selector: 'app-sales-dashboard',
  templateUrl: './sales-dashboard.component.html',
  styleUrls: ['./sales-dashboard.component.scss']
})
export class SalesDashboardComponent implements OnInit {

  current: UserModel;

  branchs: BranchListModel[];

  channels: any[];

  timePeriods = [
    { id: 1, name: "Today" },
    { id: 2, name: "Yesterday To Day" },
    { id: 3, name: "Week To Day" },
    { id: 4, name: "Month To Day" },
    { id: 5, name: "Quarter To Day" },
    { id: 6, name: "Year To Day" },
    { id: 7, name: "Custom" },
  ];

  

  allSearchModel: DashboardSearchModel = {
    branchs: [],
    channels: [],
    fromDate: new Date(),
    toDate: new Date(),
    timePeriod: 1,
    clientId: 0,
    itemId: 0,
    lineChartMode: "D",
    orderKBIMode: "V",
    representativeId: 0,
    supervisorId: 0,
    vendorId: 0,
    clientCode:'',
    itemCode:'',
    representativeCode:'',
    supervisorCode:'',
    vendorCode:''  
  } as DashboardSearchModel;

  model: DashboardSalesModel = {
    timelines: [],
    perfromanceModel: {
      label: '',
      percentage: 0,
      sales: 0,
      target: 0
    },
    kbiModel: {
      allBranchs: 0,
      allClients: 0,
      allDistributors: 0,
      allItems: 0,
      allRepresentative: 0,
      allVendors: 0,
      branchPercentage: 0,
      branchs: 0,
      clientPercentage: 0,
      clients: 0,
      distributorPercentage: 0,
      distributors: 0,
      itemPercentage: 0,
      items: 0,
      representativePercentage: 0,
      representatives: 0,
      vendorPercentage: 0,
      vendors: 0
    }
  } as DashboardSalesModel;


  isLoading = false;
  isLoadingChart = false;
  isLoadingKBI = false;


  TimeLineData: any;
  timeLineOptions: any;

  hourData: any;
  hourOptions: any;

  channelData: any;
  channelOptions: any;


  dateMode: DateTypeModel[] = [];




  lblTarget = '';
  lblCurrent = '';

  lblOrders = '';


  CHOOSE = ''

  chartModes: LookupModel[] = [];
  orderKBIModes: LookupModel[] = [];

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
    private _DashboardService: DashboardSalesService,
    private _branchService: BranchService,
    private _ClientGroupService: ClientGroupService,

    private _utilService: UtilService,
    private dialogService: DialogService,

    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private _MenuService: MenuService,
    private _commonCrudService : CommonCrudService,
  ) {

    this.current = _user.Current();
    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Target').subscribe((res) => { this.lblTarget = res });
    this._translateService.get('Sales').subscribe((res) => { this.lblCurrent = res });
    this._translateService.get('Orders').subscribe((res) => { this.lblOrders = res });

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

          ],
          hoverBackgroundColor: [

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

    this.chartModes.push({ id: 0, code: 'M', name: 'Monthly View' });
    this.chartModes.push({ id: 1, code: 'D', name: 'Daily View' });

    
    this.orderKBIModes.push({ id: 0, code: 'V', name: 'Value View' });
    this.orderKBIModes.push({ id: 1, code: 'O', name: 'Count View' });

  }

  ngOnInit(): void {


    let branchModel = {
      Skip: 0,
      Take: 1000,

    } as BranchSearchModel;

    this._commonCrudService.post("Branch/Filter", branchModel, BranchListModel).then((res) => {
      // this._branchService.Filter(branchModel).then((res) => {
      this.branchs = res.data;

    })

    let clientGroupModel = {
      Skip: 0,
      Take: 1000,

    } as ClientGroupSearchModel;

      this._commonCrudService.post("ClientGroup/Filter", clientGroupModel, ClientGroupListModel).then((res) => {
        // this._ClientGroupService.Filter(clientGroupModel).then((res) => {
      this.channels = res.data;

    })


    this.getAll();
  }


  async getAll() {
    this.isLoading = true;
    this.isLoadingChart = true;
    this.isLoadingKBI = true;

    this.TimeLineData.labels = [];
    this.TimeLineData.datasets[0].data = [];
    this.TimeLineData.datasets[1].data = [];

    this.hourData.labels=[];
    this.hourData.datasets[0].data=[];


    this.channelData.labels = [];
    this.channelData.datasets[0].data = [];

    this.channelData.datasets[0].backgroundColor = [];
    this.channelData.datasets[0].hoverBackgroundColor = [];

    console.log(this.allSearchModel);

    this._commonCrudService.post("DashboardSales/all", this.allSearchModel, DashboardSalesModel).then(res => {
      // this._DashboardService.GetDashboard(this.allSearchModel).then(res => {
      console.log(res);

      if (res.succeeded == true) {
        this.model = res.data;

        res.data.timelines.forEach(element => {
          this.TimeLineData.labels.push(element.lineLabel);
          this.TimeLineData.datasets[0].data.push(element.lineTarget);
          this.TimeLineData.datasets[1].data.push(element.lineValue);
        });

        res.data.hours.forEach(element => {
          this.hourData.labels.push(element.label);
          this.hourData.datasets[0].data.push(element.value);

        });

        res.data.channels.forEach(element => {
          this.channelData.labels.push(element.label);
          this.channelData.datasets[0].data.push(element.sales);
          this.channelData.datasets[0].backgroundColor.push(element.color);
          this.channelData.datasets[0].hoverBackgroundColor.push(element.color);
        });
      }
      this.isLoading = false;
      this.isLoadingChart = false;
      this.isLoadingKBI = false;

    })

  }
  async clearAll() {

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

  onLineModeChange(arg){
    this.isLoadingChart = true;
    this.allSearchModel.lineChartMode=arg.value;

    this.TimeLineData.labels = [];
    this.TimeLineData.datasets[0].data = [];
    this.TimeLineData.datasets[1].data = [];
    
    this._commonCrudService.post("DashboardSales/ChartLine", this.allSearchModel, DashboardSalesModel).then(res => {
      // this._DashboardService.GetChartLine(this.allSearchModel).then(res => {
      console.log(res);

      if (res.succeeded == true) {
        this.model.timelines = res.data.timelines;
        res.data.timelines.forEach(element => {
          this.TimeLineData.labels.push(element.lineLabel);
          this.TimeLineData.datasets[0].data.push(element.lineTarget);
          this.TimeLineData.datasets[1].data.push(element.lineValue);
        });

      }
      this.isLoadingChart = false;
    })

  }
  onKBIChange(arg){
    this.isLoadingKBI = true;

    this.allSearchModel.orderKBIMode=arg.value;

    this._DashboardService.GetKBI(this.allSearchModel).then(res => {
      console.log(res);

      if (res.succeeded == true) {
        this.model.kbiModel = res.data.kbiModel;
       
      }
      this.isLoadingKBI = false;
    })

  }

}
