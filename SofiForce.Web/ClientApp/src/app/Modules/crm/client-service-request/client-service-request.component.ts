import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { TranslateService } from '@ngx-translate/core';

import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { BooleanService } from 'src/app/core/services/Boolean.Service';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { ChooserBranchComponent } from '../../shared/chooser-branch/chooser-branch.component';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';

import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';

import { ClientComplainSearchModel } from 'src/app/core/Models/SearchModels/ClientComplainSearchModel';
import { ClientComplainListModel } from 'src/app/core/Models/ListModels/ClientComplainListModel';
import { ManageClientComplainComponent } from '../components/manage-client-complain/manage-client-complain.component';
import { ClientComplainModel } from 'src/app/core/Models/EntityModels/ClientComplainModel';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { ChooserRepresentativeComponent } from '../../shared/chooser-representative/chooser-representative.component';
import { ChooserClientComponent } from '../../shared/chooser-client/chooser-client.component';
import { ClientServiceRequestListModel } from 'src/app/core/Models/ListModels/ClientServiceRequestListModel';
import { ClientRequestSearchModel } from 'src/app/core/Models/SearchModels/ClientRequestSearchModel';
import { ManageClientServiceRequestComponent } from '../components/manage-client-service-request/manage-client-service-request.component';
import { ClientServiceRequestModel } from 'src/app/core/Models/EntityModels/ClientServiceRequestModel';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';
@Component({
  selector: 'app-client-service-request',
  templateUrl: './client-service-request.component.html',
  styleUrls: ['./client-service-request.component.scss']
})
export class ClientServiceRequestComponent implements OnInit {

  gridModel: ResponseModel<ClientServiceRequestListModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }


  RequestTypes: LookupModel[] = [];
  RequestTypeDetails: LookupModel[] = [];
  Priorities: LookupModel[] = [];
  RequestStatus: LookupModel[] = [];
  Departments: LookupModel[] = [];
  IsClosed: LookupModel[] = [];



  searchModel: ClientRequestSearchModel = {
    requestCode: '',
    branchId: 0,
    branchCode: '',
    representativeId: 0,
    representativeCode: '',
    clientId: 0,
    clientCode: '',
    requestDate: undefined,
    requestTypeId: 0,
    requestTypeDetailId: 0,
    phone: '',
    priorityId: 0,
    requestStatusId: 0,
    isClosed: 0,
    departmentId: 0,
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    TermBy:"",
  }

  advanced = false;
  isLoading = false;
  actions = false;

  first = 0;
  items: MenuItem[];
  menuItems: MenuItem[];
  selected: ClientServiceRequestListModel;


  CREATE_NEW_HEADER = '';
  EDIT_HEADER = '';
  CHOOSE = '';

  constructor(
    private _AppMessageService: AppMessageService,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _BooleanService: BooleanService,
    private _commonCrudService : CommonCrudService,
  ) {
    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Ad New Information').subscribe((res) => { this.CREATE_NEW_HEADER = res });
    this._translateService.get('Edit Information').subscribe((res) => { this.EDIT_HEADER = res });
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });

   
  }

  ngOnInit(): void {



    this.menuItems = [
      {
        label: 'Create',
        icon: 'pi pi-fw pi-plus',
        command: (e) => this.manage('n')
      },
      {
        label: 'Edit',
        icon: 'pi pi-fw pi-pencil',
        visible: false,
        command: (e) => this.manage('e')
      },
      {
        label: 'Delete',
        icon: 'pi pi-fw pi-times',
        visible: false,
        command: (e) => this.manage('d')
      },
      {
        label: 'Export',
        icon: 'pi pi-fw pi-file-excel',
        command: (e) => this.manage('x')
      },
    ];



    this._commonCrudService.get("RequestType/GetAll", LookupModel).then(res => {
      this.RequestTypes = res.data;
      if (this.RequestTypes.length > 0) {
        this._commonCrudService.get("RequestTypeDetail/GetByTypeId?Id="+this.RequestTypes[0].id,LookupModel).then(res => {
          this.RequestTypeDetails = res.data;
          this.RequestTypeDetails.unshift({ id: 0, code: '0', name: '--' });

        })
      }
      this.RequestTypes.unshift({ id: 0, code: '0', name: '--' });

    })

    this._commonCrudService.get("RequestStatus/GetAll", LookupModel).then(res => {
      this.RequestStatus = res.data
      this.RequestStatus.unshift({ id: 0, code: '0', name: '--' });

    })

    this._BooleanService.GetAll(localStorage.getItem("lan")).then(res => {
      this.IsClosed = res
    })

    this._commonCrudService.get("Department/GetAll", LookupModel).then(res => {
      this.Departments = res.data
      this.Departments.unshift({ id: 0, code: '0', name: '--' });
    })


    this._commonCrudService.get("Priority/GetAll", LookupModel).then(res => {
      this.Priorities = res.data
      this.Priorities.unshift({ id: 0, code: '0', name: '--' });
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

    await this._commonCrudService.post("ClientRequest/Filter", this.searchModel, ClientServiceRequestListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._commonCrudService.post("ClientRequest/Filter", this.searchModel, ClientServiceRequestListModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {

    this.selected = null;

    this.isLoading = true;
    await this._commonCrudService.post("ClientRequest/Filter", this.searchModel, ClientServiceRequestListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.searchModel.Skip = 0;
    await this._commonCrudService.post("ClientRequest/Filter", this.searchModel, ClientServiceRequestListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel = {
      requestCode: '',
      branchId: 0,
      representativeId: 0,
      clientId: 0,
      requestDate: undefined,
      requestTypeId: 0,
      requestTypeDetailId: 0,
      phone: '',
      priorityId: 0,
      requestStatusId: 0,
      isClosed: 0,
      departmentId: 0,
      Take: 30,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: undefined,
      branchCode: '',
      representativeCode: '',
      clientCode: '',
      TermBy:""
    }
  }

  async onSelectionChange(event) {
    this.refreshMenu();
  }
  refreshMenu() {

    this.menuItems[1].visible = false;
    this.menuItems[2].visible = false;

    if (this.selected != null && this.selected.requestId > 0) {
      this.menuItems[1].visible = true;
      this.menuItems[2].visible = true;
    }
  }
  async manage(mode) {

    if (mode == 'n') {

      var ref = this.dialogService.open(ManageClientServiceRequestComponent, {
        header: this.CREATE_NEW_HEADER,
        width: '1000px',
        height: '750px',
        contentStyle: { "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe(() => {
        this.selected = null;
        this.reloadFilter();
        this.refreshMenu();
      });
    }

    if (mode == 'e') {
      if (this.selected != null && this.selected.requestId > 0) {
        var ref = this.dialogService.open(ManageClientServiceRequestComponent, {
          header: this.EDIT_HEADER,
          data: { requestId: this.selected.requestId },
          width: '1000px',
          height: '750px',
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

    if (mode == 'd') {

      if (this.selected != null && this.selected.requestId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {


            this.isLoading = true;
            let model = {} as ClientServiceRequestModel;
            model.requestId = this.selected.requestId;
            this._commonCrudService.post("ClientRequest/Delete", this.searchModel, ClientServiceRequestModel).then(res => {
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

    if (mode == 'x') {
      this.isLoading = true;
      await (this._commonCrudService.postFile("ClientRequest/Export", this.searchModel)).subscribe((data: any) => {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "Requests_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);


        this.isLoading = false;
      })
    }


  }

  async onTypeChange(arg) {
    this.isLoading = true;
    this._commonCrudService.get("RequestTypeDetail/GetByTypeId?Id="+arg.value, LookupModel).then(res => {
      this.RequestTypeDetails = res.data;
      this.RequestTypeDetails.unshift({ id: 0, code: '0', name: '--' });

      this.isLoading = false;
    })
  }


  choose_Branch() {
    var ref = this.dialogService.open(ChooserBranchComponent, {
      header: this.CHOOSE,
      width: '600px',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((res: BranchListModel) => {
      if (res) {
        this.searchModel.branchCode = res.branchCode;
        this.searchModel.branchId = res.branchId;
      }
    });
  }



  choose_Client() {
    var ref = this.dialogService.open(ChooserClientComponent, {
      header: this.CHOOSE,
      width: '90%',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((res: ClientListModel) => {
      if (res) {
        this.searchModel.clientCode = res.clientCode;
        this.searchModel.clientId = res.clientId;
      }
    });
  }
  choose_Representative() {
    var ref = this.dialogService.open(ChooserRepresentativeComponent, {
      header: this.CHOOSE,
      width: '1200px',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((res: RepresentativeListModel) => {
      if (res) {
        this.searchModel.representativeCode = res.representativeCode;
        this.searchModel.representativeId = res.representativeId;
      }
    });
  }

  clear_Client() {
    this.searchModel.clientCode = '';
    this.searchModel.clientId = 0;
  }

  clear_Representative() {
    this.searchModel.representativeCode = '';
    this.searchModel.representativeId = 0;
  }
  clear_Branch() {
    this.searchModel.branchCode = '';
    this.searchModel.branchId = 0;
  }
}
