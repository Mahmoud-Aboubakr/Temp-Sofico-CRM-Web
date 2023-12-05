import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig } from 'primeng/dynamicdialog';
import { OperationRequestListModel } from 'src/app/core/Models/ListModels/OperationRequestListModel';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { OperationRequestDetailListModel } from 'src/app/core/Models/ListModels/OperationRequestDetailListModel';
import { OperationRequestDetailSearchModel } from 'src/app/core/Models/SearchModels/OperationRequestDetailSearchModel';
import { OperationRequestDetailService } from 'src/app/core/services/OperationRequestDetail.Service';
import { ManageOperationRequestDetailComponent } from '../manage-operation-request-detail/manage-operation-request-detail.component';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { GovernerateService } from 'src/app/core/services/Governerate.Service';
import { CityService } from 'src/app/core/services/City.Service';
import { OperationStatusService } from 'src/app/core/services/OperationStatus.Service';
import { ClientTypeService } from 'src/app/core/services/ClientType.Service';
import { LocationLevelService } from 'src/app/core/services/LocationLevel.Service';
import { OperationRejectReasonService } from 'src/app/core/services/OperationRejectReason.Service';
import { OperationRequestDetailModel } from 'src/app/core/Models/EntityModels/OperationRequestDetailModel';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { ChooserClientComponent } from 'src/app/Modules/shared/chooser-client/chooser-client.component';

@Component({
  selector: 'app-manage-scan-list',
  templateUrl: './manage-scan-list.component.html',
  styleUrls: ['./manage-scan-list.component.scss']
})
export class ManageScanListComponent implements OnInit {

  @Input()
  operationId: number;

  gridModel: ResponseModel<OperationRequestDetailListModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }

  searchModel: OperationRequestDetailSearchModel = {
    clientId: 0,
    operationId: 0,
    clientTypeId: 0,
    regionId: 0,
    governerateId: 0,
    cityId: 0,
    locationLevelId: 0,
    operationStatusId: 0,
    operationDate: undefined,
    Take: 20,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    operationRejectReasonId: 0,
    TermBy:""
  }

  advanced = false;
  isLoading = false;
  first = 0;
  menuItems: MenuItem[];
  selected: OperationRequestDetailListModel;


  MANAGE_HEADER = '';
  CLIENTS_HEADER = '';
  CHOOSE_CLIENT='';

  Governerates: LookupModel[] = [];
  Cities: LookupModel[] = [];
  ClientTypes: LookupModel[] = [];
  LocationLevels: LookupModel[] = [];
  OperationStatuses: LookupModel[] = [];

  RejectReasons: LookupModel[] = [];

  showCoded=false;
  showApprove=false;
  showReject=false;


  operationRejectReasonId:number=0;
  accuracy:number=0;
  clientCode='';

  constructor(
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private _AppMessageService: AppMessageService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _OperationRequestDetailService: OperationRequestDetailService,
    private activatedRoute: ActivatedRoute,
    private config: DynamicDialogConfig,
    private _GovernerateService: GovernerateService,
    private _CityService: CityService,
    private _OperationStatusService: OperationStatusService,
    private _ClientTypeService: ClientTypeService,
    private _LocationLevelService: LocationLevelService,
    private _OperationRejectReasonService: OperationRejectReasonService,
  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Add / Edit Scan Request').subscribe((res) => { this.MANAGE_HEADER = res });
    this._translateService.get('Clients List').subscribe((res) => { this.CLIENTS_HEADER = res });
    this._translateService.get('Choose Client').subscribe((res) => { this.CHOOSE_CLIENT = res });



    this.menuItems = [
      {
        label: 'Manage Client',
        icon: 'pi pi-fw pi-plus',
        command: (e) => this.manage('manage')
      },
      {
        label: 'Delete',
        icon: 'pi pi-fw pi-times',
        command: (e) => this.manage('delete')
      },
      {
        separator:true,
      },
      {
        label: 'Mark As',
        icon: 'pi pi-fw pi-check',
        items:[
          {
            label: 'Approved',
            icon: 'pi pi-fw pi-check',
            command: (e) => this.showApprove=true
          },
          {
            label: 'Rejected',
            icon: 'pi pi-fw pi-times',
            command: (e) => this.showReject=true
          },
          {
            label: 'Coded',
            icon: 'pi pi-fw pi-user',
            command: (e) => this.showCoded=true
          },
        ],

      },
    ];



  }

  async manage(operation){
    if(operation=='approve'){

      if (this.selected != null && this.selected.detailId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;
            let model = {} as OperationRequestDetailModel;
            model.detailId = this.selected.detailId;
            this._OperationRequestDetailService.approve(model).then(res => {
              this.advancedFilter();
              this.isLoading = false;
              
              if (res.succeeded == true) {
                this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });
                this.showApprove=false;
              }
              else {
                this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
              }
            })
          },
          reject: () => {
            //reject action
          }
        });
      }
    }
    if(operation=='reject'){
      if (this.selected != null && this.selected.detailId > 0 &&this.operationRejectReasonId>0 &&this.accuracy>0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;
            let model = {} as OperationRequestDetailModel;
            model.detailId = this.selected.detailId;
            model.operationRejectReasonId=this.operationRejectReasonId;
            model.accuracy=this.accuracy;

            this._OperationRequestDetailService.reject(model).then(res => {
              this.advancedFilter();
              this.isLoading = false;
              
              if (res.succeeded == true) {
                this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });
                this.showReject=false;
              }
              else {
                this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
              }
            })
          },
          reject: () => {
            //reject action
          }
        });
      }
    }
    if(operation=='code'){
      if (this.selected != null && this.selected.detailId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;
            let model = {} as OperationRequestDetailModel;
            model.detailId = this.selected.detailId;
            model.clientId = this.selected.clientId;

            this._OperationRequestDetailService.coded(model).then(res => {
              this.advancedFilter();
              this.isLoading = false;
              
              if (res.succeeded == true) {
                this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });
                this.showCoded=false;
              }
              else {
                this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
              }

            })
          },
          reject: () => {
            //reject action
          }
        });
      }
    }
  }

  ngOnInit(): void {


    this._GovernerateService.GetAll().then(res => {
      this.Governerates = res.data;
      this.Governerates.unshift({ id: 0, code: '0', name: '--' });
    });

    this._OperationStatusService.GetAll().then(res => {
      this.OperationStatuses = res.data;
      this.OperationStatuses.unshift({ id: 0, code: '0', name: '--' });
    })
    this._ClientTypeService.GetAll().then(res => {
      this.ClientTypes = res.data;
      this.ClientTypes.unshift({ id: 0, code: '0', name: '--' });

    })

    this._LocationLevelService.GetAll().then(res => {
      this.LocationLevels = res.data;
      this.LocationLevels.unshift({ id: 0, code: '0', name: '--' });

    })

    this._OperationRejectReasonService.GetAll().then(res => {
      this.RejectReasons = res.data;
      this.RejectReasons.unshift({ id: 0, code: '0', name: '--' });

    })

    // pass from parameter
    if (this.operationId > 0) {
      this.searchModel.operationId = +this.config.data.operationId
    }
    // pass from primng
    if (this.config.data) {
      if (+this.config.data.operationId > 0) {
        this.searchModel.operationId = +this.config.data.operationId
      }
    }

  }

  async onGovernerateChange(e) {

    this.Cities = [];
    this.isLoading = true;

    this._CityService.GetByGovernerate(e.value).then(res => {
      this.Cities = res.data;
      this.isLoading = false;
      this.Cities.unshift({ id: 0, code: '0', name: '--' });
    })
  }


  Chooser_Client() {
    var ref = this.dialogService.open(ChooserClientComponent, {
      header: this.CHOOSE_CLIENT,
      width: '90%',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((sel: ClientListModel) => {
      if (sel != null) {
        this.clientCode = sel.clientCode;
        this.selected.clientId = sel.clientId;
      }
    });
  }

  async filter(event) {
    console.log(event);
    this.isLoading = true;
    this.searchModel.Skip = event.first;
    this.searchModel.Take = event.rows;
    console.log(this.searchModel);

    this.searchModel.SortBy = { Order: "", Property: "" }
    if (event.sortField) {
      this.searchModel.SortBy.Property = event.sortField;
      if (event.sortOrder == 1) {
        this.searchModel.SortBy.Order = "asc";
      }
      else {
        this.searchModel.SortBy.Order = "desc";

      }
    }

    await this._OperationRequestDetailService.Filter(this.searchModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      this.selected = null;

      await this._OperationRequestDetailService.Filter(this.searchModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {

    this.isLoading = true;
    this.selected = null;

    await this._OperationRequestDetailService.Filter(this.searchModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.selected = null;

    this.searchModel.Skip = 0;
    await this._OperationRequestDetailService.Filter(this.searchModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel = {
      clientId: 0,
      operationId: 0,
      clientTypeId: 0,
      regionId: 0,
      governerateId: 0,
      cityId: 0,
      locationLevelId: 0,
      operationStatusId: 0,
      operationDate: undefined,
      Take: 20,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: undefined,
      operationRejectReasonId: 0,
      TermBy:""
    }

  }


  async onRowDblClick(e, data) {
    if (data) {
      if (data && data.detailId > 0) {
        var ref = this.dialogService.open(ManageOperationRequestDetailComponent, {
          data: { detailId: data.detailId },
          header: this.CLIENTS_HEADER,
          width: '90%',
          height: '90%',
          contentStyle: { "overflow": "auto" },
          baseZIndex: 10000
        });

        ref.onClose.subscribe(() => {
          this.selected = null;
          this.reloadFilter();
        });
      }
    }
  }



  async export() {
    this.isLoading = true;
    await (this._OperationRequestDetailService.Export(this.searchModel)).subscribe((data: any) => {

      console.log(data);

      const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      const a = document.createElement('a');
      a.setAttribute('style', 'display:none;');
      document.body.appendChild(a);
      a.download = "Scan_" + new Date().toISOString().split('.')[0].replace(/[^\d]/gi, '');
      a.href = URL.createObjectURL(downloadedFile);
      a.target = '_blank';
      a.click();
      document.body.removeChild(a);


      this.isLoading = false;
    })
  }


  async deleteDetail() {
    if (this.selected != null && this.selected.detailId > 0) {
      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {
          this.isLoading = true;
          let model = {} as OperationRequestDetailModel;
          model.detailId = this.selected.detailId;
          this._OperationRequestDetailService.Delete(model).then(res => {
            this.advancedFilter();
            this.isLoading = false;
            if (res.succeeded == true) {
              this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });
            }
            else {
              this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
            }
          })
        },
        reject: () => {
          //reject action
        }
      });
    }
  }
  async onSelectionChange(event) {
    this.selected = event;

  }

}
