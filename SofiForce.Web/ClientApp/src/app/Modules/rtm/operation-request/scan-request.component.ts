import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { OperationRequestListModel } from 'src/app/core/Models/ListModels/OperationRequestListModel';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { OperationRequestSearchModel } from 'src/app/core/Models/SearchModels/OperationRequestSearchModel';
import { ActivatedRoute } from '@angular/router';
import { ManageScanRequestComponent } from '../components/manage-operation-request/manage-scan-request.component';
import { OperationRequestModel } from 'src/app/core/Models/EntityModels/OperationRequestModel';
import { ManageScanListComponent } from '../components/manage-scan-list/manage-scan-list.component';
import { ChooserRepresentativeComponent } from '../../shared/chooser-representative/chooser-representative.component';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { BooleanService } from 'src/app/core/services/Boolean.Service';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-scan-request',
  templateUrl: './scan-request.component.html',
  styleUrls: ['./scan-request.component.scss']
})
export class ScanRequestComponent implements OnInit {

  gridModel: ResponseModel<OperationRequestListModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }

  searchModel: OperationRequestSearchModel = {
    operationCode: '',
    operationTypeId: 1,
    representativeId: 0,
    representativeCode: '',
    governerateId: 0,
    operationDate: undefined,
    startDate: undefined,
    isClosed: 0,
    Take: 0,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    TermBy:""
  }

  advanced = false;
  isLoading = false;
  first = 0;
  menuItems: MenuItem[];
  selected: OperationRequestListModel;

  governerates:LookupModel[]=[];
  statuses:LookupModel[]=[];


  MANAGE_HEADER = '';
  CLIENTS_HEADER = '';
  CHOOSE_REPRESENTITIVE='';
  constructor(

    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private _AppMessageService: AppMessageService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private activatedRoute: ActivatedRoute,
    private _BooleanService: BooleanService,
    private _commonCrudService : CommonCrudService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Add / Edit Scan Request').subscribe((res) => { this.MANAGE_HEADER = res });
    this._translateService.get('Clients List').subscribe((res) => { this.CLIENTS_HEADER = res });
    this._translateService.get('Choose Represetitive').subscribe((res) => { this.CHOOSE_REPRESENTITIVE = res });

    this.searchModel.operationTypeId = 1;

  }

  ngOnInit(): void {

    this.menuItems = [
      {
        label: 'Create',
        icon: 'pi pi-fw pi-plus',
        command: (e) => this.manage('create')
      },
      {
        label: 'Edit',
        icon: 'pi pi-fw pi-pencil',
        command: (e) => this.manage('edit')
      },
      {
        label: 'Delete',
        icon: 'pi pi-fw pi-times',
        command: (e) => this.manage('delete')
      },
      {
        label: 'Close',
        icon: 'pi pi-fw pi-lock',
        command: (e) => this.manage('close')
      },
      {
        label: 'Clients',
        icon: 'pi pi-fw pi-users',
        command: (e) => this.manage('clients')
      },
      {
        label: 'Export',
        icon: 'pi pi-fw pi-cloud-download',
        command: (e) => this.manage('export')
      },
    ];


    this._commonCrudService.get("Governerate/GetAll", LookupModel).then(res=>{
      this.governerates=res.data;
      this.governerates.unshift({id:0,code:'0',name:'--'})
    });

    this._BooleanService.GetAll(localStorage.getItem('lan')).then(res=>{
      this.statuses=res;
      this.governerates.unshift({id:0,code:'0',name:'--'})
    });
    

    this.refreshMenu();

  }

  async manage(operation) {
    if (operation == 'create') {
      var ref = this.dialogService.open(ManageScanRequestComponent, {
        header: this.MANAGE_HEADER,
        width: '95%',
        height: '95vh',
        contentStyle: { "overflow": "auto" },
        baseZIndex: 10000
      });

      ref.onClose.subscribe(() => {
        this.selected = null;
        this.reloadFilter();
        this.refreshMenu();
      });
    }

    if (operation == 'edit') {
      if(this.selected &&this.selected.operationId>0){
        var ref = this.dialogService.open(ManageScanRequestComponent, {
          data:{operationId:this.selected.operationId},
          header: this.MANAGE_HEADER,
          width: '95%',
          height: '95vh',
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

    if (operation == 'delete') {
      if (this.selected != null && this.selected.operationId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {


            this.isLoading = true;
            let model = {} as OperationRequestModel;
            model.operationId = this.selected.operationId;
            this._commonCrudService.post("OperationRequest/Delete", model, OperationRequestModel).then(res => {
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


    if (operation == 'close') {
      if (this.selected != null && this.selected.operationId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {
            this.isLoading=true;
            await this._commonCrudService.get("OperationRequest/getById?Id="+this.selected.operationId, OperationRequestModel).then((res)=>{
              if(res.succeeded && res.data){
                res.data.isClosed=true;
                this._commonCrudService.post("OperationRequest/Save", res.data, OperationRequestModel).then(res => {
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
              }

            })
           
          },
          reject: () => {
            //reject action
          }
        });
      }
    }

    if (operation == 'clients') {
      if(this.selected &&this.selected.operationId>0){
        var ref = this.dialogService.open(ManageScanListComponent, {
          data:{operationId:this.selected.operationId},
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

    if (operation == 'export') {

      this.isLoading = true;
      await (this._commonCrudService.postFile("OperationRequest/Export", this.searchModel)).subscribe((data: any) => {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "Scan_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);


        this.isLoading = false;
      })
    }

  }

  onSelectionChange() {
    this.refreshMenu();
  }

  async onRowDblClick(e,data){
    if(data){
      if(data &&data.operationId>0){
        var ref = this.dialogService.open(ManageScanListComponent, {
          data:{operationId:data.operationId},
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

    await this._commonCrudService.post("OperationRequest/Filter", this.searchModel, OperationRequestListModel).then(res => {
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

      await this._commonCrudService.post("OperationRequest/Filter", this.searchModel, OperationRequestListModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {

    this.isLoading = true;
    this.selected=null;
      
    await this._commonCrudService.post("OperationRequest/Filter", this.searchModel, OperationRequestListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.selected=null;
      
    this.searchModel.Skip = 0;
    await this._commonCrudService.post("OperationRequest/Filter", this.searchModel, OperationRequestListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel={
      operationCode: '',
      operationTypeId: 1,
      representativeId: 0,
      representativeCode: '',
      governerateId: 0,
      operationDate: undefined,
      startDate: undefined,
      isClosed: 0,
      Take: 0,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: undefined,
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

  Chooser_Represtitive() {
    var ref = this.dialogService.open(ChooserRepresentativeComponent, {
      data: { kindId: '5' },
      header: this.CHOOSE_REPRESENTITIVE,
      width: '90%',
      contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((sel: RepresentativeListModel) => {
      if (sel != null) {
        this.searchModel.representativeId = sel.representativeId;
        this.searchModel.representativeCode = sel.representativeCode;
      }
    });
  }
  clear_Represtitive(){
    this.searchModel.representativeId = 0;
    this.searchModel.representativeCode = '';
  }
}
