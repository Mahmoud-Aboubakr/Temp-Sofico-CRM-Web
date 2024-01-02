import { Component, OnInit } from '@angular/core';
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
import { ManageOperationRequestDetailComponent } from '../manage-operation-request-detail/manage-operation-request-detail.component';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { OperationRequestDetailModel } from 'src/app/core/Models/EntityModels/OperationRequestDetailModel';
import { OperationRequestDetailAddModel } from 'src/app/core/Models/DtoModels/OperationRequestDetailAddModel';
import { ChooserClientComponent } from 'src/app/Modules/shared/chooser-client/chooser-client.component';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { async } from 'rxjs/internal/scheduler/async';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-manage-validation-list',
  templateUrl: './manage-validation-list.component.html',
  styleUrls: ['./manage-validation-list.component.scss']
})
export class ManageValidationListComponent implements OnInit {


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
  advancedAdd = false;

  isLoading = false;
  first = 0;
  menuItems: MenuItem[];
  selected: OperationRequestDetailListModel;


  MANAGE_HEADER = '';
  CLIENTS_HEADER = '';

  Governerates: LookupModel[] = [];
  Cities: LookupModel[] = [];
  ClientTypes: LookupModel[] = [];
  LocationLevels: LookupModel[] = [];
  OperationStatuses: LookupModel[] = [];

  RejectReasons: LookupModel[] = [];
  
   addModel={} as OperationRequestDetailAddModel;
  constructor(
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private _AppMessageService: AppMessageService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private activatedRoute: ActivatedRoute,
    private config: DynamicDialogConfig,
    private _commonCrudService : CommonCrudService,
    ) { 

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Add / Edit Scan Request').subscribe((res) => { this.MANAGE_HEADER = res });
    this._translateService.get('Clients List').subscribe((res) => { this.CLIENTS_HEADER = res });


    if (this.config.data) {
      if (+this.config.data.operationId > 0) {
        this.searchModel.operationId = +this.config.data.operationId
      }
    }


  }

  ngOnInit(): void {


    this._commonCrudService.get("Governerate/GetAll", LookupModel).then(res => {
      this.Governerates = res.data;
      this.Governerates.unshift({id:0,code:'0',name:'--'});
    });

    this._commonCrudService.get("OperationStatus/GetAll", LookupModel).then(res => {
      this.OperationStatuses = res.data;
      this.OperationStatuses.unshift({id:0,code:'0',name:'--'});
    })
    this._commonCrudService.get("ClientType/GetAll", LookupModel).then(res => {
      this.ClientTypes = res.data;
      this.ClientTypes.unshift({id:0,code:'0',name:'--'});

    })

    this._commonCrudService.get("LocationLevel/GetAll", LookupModel).then(res => {
      this.LocationLevels = res.data;
      this.LocationLevels.unshift({id:0,code:'0',name:'--'});

    })

    this._commonCrudService.get("OperationRejectReason/GetAll", LookupModel).then(res => {
      this.RejectReasons = res.data;
      this.RejectReasons.unshift({id:0,code:'0',name:'--'});

    })

    this.refreshMenu();

  }

  async onGovernerateChange(e) {

    this.Cities = [];
    this.isLoading = true;

    this._commonCrudService.get("City/GetByGovernerate?Id="+e.value, LookupModel).then(res => {
      this.Cities = res.data;
      this.isLoading = false;
      this.Cities.unshift({id:0,code:'0',name:'--'});
    })
  }

  onSelectionChange() {
    this.refreshMenu();
  }

  async deleteDetail(){
    if (this.selected != null && this.selected.detailId > 0) {
      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {
          this.isLoading=true;
          let model={} as OperationRequestDetailModel;
          model.detailId=this.selected.detailId;
          this._commonCrudService.post("OperationRequestDetail/Delete", model, OperationRequestDetailModel).then(res => {
            this.advancedFilter();
            this.refreshMenu();
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

  async export(){
    this.isLoading=true;
    await (this._commonCrudService.postFile("OperationRequestDetail/Export", this.searchModel)).subscribe((data:any)=> {

      console.log(data);

      const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      const a = document.createElement('a');
      a.setAttribute('style', 'display:none;');
      document.body.appendChild(a);
      a.download = "Validation_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
      a.href = URL.createObjectURL(downloadedFile);
      a.target = '_blank';
      a.click();
      document.body.removeChild(a);

     
      this.isLoading=false;
    })
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

    await this._commonCrudService.post("OperationRequestDetail/Filter", this.searchModel, OperationRequestDetailListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      this.selected=null;

      await this._commonCrudService.post("OperationRequestDetail/Filter", this.searchModel, OperationRequestDetailListModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {

    this.isLoading = true;
    this.selected=null;
      
    await this._commonCrudService.post("OperationRequestDetail/Filter", this.searchModel, OperationRequestDetailListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.selected=null;
      
    this.searchModel.Skip = 0;
    await this._commonCrudService.post("OperationRequestDetail/Filter", this.searchModel, OperationRequestDetailListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel={
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
      operationRejectReasonId:0,
      TermBy:""
    }
    
  }

  refreshMenu() {

    this.menuItems[1].visible = false;
    this.menuItems[2].visible = false;
    this.menuItems[3].visible = false;
    this.menuItems[4].visible = false;

    if (this.selected != null && this.selected.operationId > 0) {

      this.menuItems[1].visible = true;
      this.menuItems[2].visible = true;
      this.menuItems[3].visible = true;
      this.menuItems[4].visible = true;

    }
  }

  async onRowDblClick(e,data){
    if(data){
      if(data &&data.detailId>0){
        var ref = this.dialogService.open(ManageOperationRequestDetailComponent, {
          data:{detailId:data.detailId},
          header: this.CLIENTS_HEADER,
          width: '90%',
          height:'90%',
          contentStyle: { "overflow": "auto" },
          baseZIndex: 10000
        });
  
        ref.onClose.subscribe(() => {
          this.selected = null;
          this.reloadFilter();
          this.refreshMenu();
        });
      }
    }
  }


  Chooser_Client(){
    var ref = this.dialogService.open(ChooserClientComponent, {
      header: this.CLIENTS_HEADER,
      width: '90%',
      height:'90%',
      contentStyle: { "overflow": "auto" },
      baseZIndex: 10000
    });

    ref.onClose.subscribe(async (sel:ClientListModel) => {
      if(sel && sel.clientCode){

        this.addModel.operationId=this.searchModel.operationId;
        this.addModel.clientId=sel.clientId;
        this.addModel.clientCode=sel.clientCode;

        this.advancedAdd=false;
        await this._commonCrudService.post("OperationRequestDetail/Add",this.addModel,OperationRequestDetailAddModel).then(res => {
          this.advancedFilter();
          this.refreshMenu();
          this.addModel={} as OperationRequestDetailAddModel;
          this.isLoading = false;
          if (res.succeeded == true) {
            this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });
          }
          else {
            this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
          }
        })

      }
    });
  }

}
