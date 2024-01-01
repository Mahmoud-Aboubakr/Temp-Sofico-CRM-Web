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
import { ClientSearchModel } from 'src/app/core/Models/SearchModels/ClientSearchModel';
import { ClientModel } from 'src/app/core/Models/EntityModels/clientModel';
import { ManageClientComponent } from '../components/manage-client/manage-client.component';
import { ClientStatisticalComponent } from '../components/client-statistical/client-statistical.component';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';
@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.scss']
})
export class ClientsComponent implements OnInit {

  gridModel: ResponseModel<ClientListModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }


  Governerates: LookupModel[] = [];
  Cities: LookupModel[] = [];

  MainChannels: LookupModel[] = [];
  SubChannels: LookupModel[] = [];
  Classfications: LookupModel[] = [];
  PaymentTerms: LookupModel[] = [];

  ClientTypes: LookupModel[] = [];
  LocationLevels: LookupModel[] = [];
  DocumentTypes: LookupModel[] = [];
  IsActives: LookupModel[] = [];
  IsChains: LookupModel[] = [];
  Istaxables: LookupModel[] = [];

  IsNews: LookupModel[] = [];
  InRoutes: LookupModel[] = [];
  NeedValidations: LookupModel[] = [];
  businessUnits: LookupModel[] = [];



  searchModel: ClientSearchModel = {
    clientId: 0,
    clientCode: '',
    clientName: '',
    clientTypeId: 0,
    branchId: 0,
    branchCode: '',
    branchSubId: 0,
    regionId: 0,
    governerateId: 0,
    cityId: 0,
    areaId: 0,
    clientGroupId: 0,
    clientGroupSubId: 0,
    building: '',
    floor: '',
    property: '',
    phone: '',
    mobile: '',
    whatsApp: '',
    isActive: 0,
    Take: 30,
    Skip: 0,
    Term: '',
    commercialCode: '',
    FilterBy: [],
    SortBy: undefined,
    taxCode: '',
    isChain: 0,
    isTaxable: 0,
    paymentTermId: 0,
    clientClassificationId: 0,
    locationLevelId: 0,
    businessUnitId: 0,
    inRoute: 0,
    isNew: 0,
    needValidation: 0,
    TermBy:""
  }

  advanced = false;
  isLoading = false;
  actions = false;

  first = 0;
  items: MenuItem[];
  menuItems: MenuItem[];
  cmItems: MenuItem[];
  selected: ClientListModel;


  CREATE_NEW_HEADER = '';
  EDIT_HEADER = '';
  MANAGE_REPRESENTITVE_HEADER = '';
  CLIENT_STC = '';
  USER_ACCRESS = '';

  CHOOSE = '';

  
  agentTypes: LookupModel[];

  searchBy: LookupModel[] = [{id:1,code:'clientCode',name:'Client Code'},{id:2,code:'clientNameAr',name:'Name Arabic'},{id:3,code:'clientNameEn',name:'Name English'}];


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
    this._translateService.get('Manage Representitive').subscribe((res) => { this.MANAGE_REPRESENTITVE_HEADER = res });
    this._translateService.get('Client Statistics').subscribe((res) => { this.CLIENT_STC = res });
    this._translateService.get('User Access').subscribe((res) => { this.USER_ACCRESS = res });
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });


    var found=localStorage.getItem("clients.component.termBy")
    if(found){
      console.log(found);
      this.searchModel.TermBy=found;
    }


  }

  OnTermChange(arg){
    localStorage.setItem("clients.component.termBy",arg.value);
  }
  async autoFilter() {

    if (this.searchModel.Term.length >=2) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._commonCrudService.post("Client/Filter",this.searchModel, ClientListModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;

        if(res.data.length>0){
          this.selected=res.data[0];
        }
      })
    }
    
    

  }

  ngOnInit(): void {



    this.menuItems = [
      {
        label: 'Export',
        icon: 'pi pi-fw pi-file-excel',
        command: (e) => this.manage('x')
      },
    ];

    this.cmItems = [
      {
        label: 'Manage',
        icon: 'pi pi-fw pi-pencil',
        command: (e) => this.manage('e')
      },
      {
        label: 'Activate',
        icon: 'pi pi-fw pi-check',
        command: (e) => this.manage('active')
      },
      {
        label: 'De-Activate',
        icon: 'pi pi-fw pi-times',
        command: (e) => this.manage('inactive')
      },
      {
        label: 'Statistics',
        icon: 'pi pi-fw pi-chart-line',
        command: (e) => this.manage('s')
      },
    ];

    this._commonCrudService.get("SupervisorType/GetAll", LookupModel).then(res => {
      this.agentTypes = res.data;
      this.agentTypes.unshift({ id: 0, code: '0', name: '--' });

    })

    this._BooleanService.GetAll(localStorage.getItem('lan')).then(res => {
      this.IsActives = res;
    })
    this._BooleanService.GetAll(localStorage.getItem('lan')).then(res => {
      this.Istaxables = res;
    })
    this._BooleanService.GetAll(localStorage.getItem('lan')).then(res => {
      this.IsChains = res;
    })

    this._BooleanService.GetAll(localStorage.getItem('lan')).then(res => {
      this.IsNews = res;
    })
    this._BooleanService.GetAll(localStorage.getItem('lan')).then(res => {
      this.NeedValidations = res;
    })
    this._BooleanService.GetAll(localStorage.getItem('lan')).then(res => {
      this.InRoutes = res;
    })

    this._commonCrudService.get("BusinessUnit/getAll", LookupModel).then(res => {
      this.businessUnits = res.data;
      this.businessUnits.unshift({ id: 0, code: '0', name: '--' });

    })



    this._commonCrudService.get("Governerate/GetAll", LookupModel).then(res => {
      this.Governerates = res.data;

      if (this.Governerates.length > 0) {
        this._commonCrudService.get("City/GetByGovernerate?Id="+this.Governerates[0].id,LookupModel).then(res => {
          this.Cities = res.data;
          this.Cities.unshift({ id: 0, code: '0', name: '--' });
        })
      }

      this.Governerates.unshift({ id: 0, code: '0', name: '--' });
    });

    this._commonCrudService.get("ClientType/GetAll", LookupModel).then(res => {
      this.ClientTypes = res.data;
      this.ClientTypes.unshift({ id: 0, code: '0', name: '--' });
    })

    this._commonCrudService.get("LocationLevel/GetAll", LookupModel).then(res => {
      this.LocationLevels = res.data;
      this.LocationLevels.unshift({ id: 0, code: '0', name: '--' });
    })


    this._commonCrudService.get("ClientGroup/GetAll", LookupModel).then(res => {
      this.MainChannels = res.data;
      this.MainChannels.unshift({ id: 0, code: '0', name: '--' });
    })

    this._commonCrudService.get("ClientClassification/GetAll", LookupModel).then(res => {
      this.Classfications = res.data;
      this.Classfications.unshift({ id: 0, code: '0', name: '--' });
    })

    this._commonCrudService.get("PaymentTerm/GetAll", LookupModel).then(res => {
      this.PaymentTerms = res.data;
      this.PaymentTerms.unshift({ id: 0, code: '0', name: '--' });
    })

  }


  async onGovernerateChange(e) {

    this.Cities = [];
    this.isLoading = true;

    this._commonCrudService.get("City/GetByGovernerate?Id="+e.value, LookupModel).then(res => {
      this.Cities = res.data;
      this.isLoading = false;
      this.Cities.unshift({ id: 0, code: '0', name: '--' });
    })
  }
  async onChannelChange(e) {
    this.SubChannels = [];
    this.isLoading = true;

    this._commonCrudService.get("ClientGroupSub/GetByClientGroup?Id="+e.value, LookupModel).then(res => {
      this.SubChannels = res.data;
      this.isLoading = false;
      this.SubChannels.unshift({ id: 0, code: '0', name: '--' });

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

    await this._commonCrudService.post("Client/Filter",this.searchModel, ClientListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._commonCrudService.post("Client/Filter",this.searchModel, ClientListModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {

    this.selected = null;

    this.isLoading = true;
    await this._commonCrudService.post("Client/Filter",this.searchModel, ClientListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.searchModel.Skip = 0;
    await this._commonCrudService.post("Client/Filter",this.searchModel, ClientListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel = {
      clientId: 0,
    clientCode: '',
    clientName: '',
    clientTypeId: 0,
    branchId: 0,
    branchCode: '',
    branchSubId: 0,
    regionId: 0,
    governerateId: 0,
    cityId: 0,
    areaId: 0,
    clientGroupId: 0,
    clientGroupSubId: 0,
    building: '',
    floor: '',
    property: '',
    phone: '',
    mobile: '',
    whatsApp: '',
    isActive: 0,
    Take: 30,
    Skip: 0,
    Term: '',
    commercialCode: '',
    FilterBy: [],
    SortBy: undefined,
    taxCode: '',
    isChain: 0,
    isTaxable: 0,
    paymentTermId: 0,
    clientClassificationId: 0,
    locationLevelId: 0,
    businessUnitId: 0,
    inRoute: 0,
    isNew: 0,
    needValidation: 0,
    TermBy:""
    }
  }

  async onSelectionChange(event) {
    this.refreshMenu();
  }
  refreshMenu() {

    
  }
  async manage(mode) {

    if (mode == 'e') {
      if (this.selected != null && this.selected.clientId > 0) {
        var ref = this.dialogService.open(ManageClientComponent, {
          header: this.EDIT_HEADER,
          data: { clientId: this.selected.clientId },
          width: '1200px',
          height: '720px',
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

      if (this.selected != null && this.selected.clientId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {


            this.isLoading = true;
            let model = {} as ClientModel;
            model.clientId = this.selected.clientId;
            this._commonCrudService.post("Client/Delete",this.searchModel, ClientModel).then(res => {
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
    if (mode == 'active') {

      if (this.selected != null && this.selected.clientId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {


            this.isLoading = true;
            let model = {} as ClientModel;
            model.clientId = this.selected.clientId;
            model.isActive=true;
            this._commonCrudService.post("Client/Status",model, ClientModel)
            .then(res => {
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
    if (mode == 'inactive') {

      if (this.selected != null && this.selected.clientId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {


            this.isLoading = true;
            let model = {} as ClientModel;
            model.clientId = this.selected.clientId;
            model.isActive=false;
            this._commonCrudService.post("Client/Status",model, ClientModel)
            .then(res => {
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
      await (this._commonCrudService.postFile("Client/Export", this.searchModel)).subscribe((data: any) => {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "Clients_" + new Date().toISOString().split('.')[0].replace(/[^\d]/gi, '');
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);


        this.isLoading = false;
      })
    }

    if (mode == 's') {
      if (this.selected != null && this.selected.clientId > 0) {


        var ref = this.dialogService.open(ClientStatisticalComponent, {
          header: this.CLIENT_STC,
          data: { clientId: this.selected.clientId },
          width: '90%',
          height: '90%',
          contentStyle: { "overflow": "auto" },
          baseZIndex: 10000
        });
        
      }
    }
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
  clear_Branch() {
    this.searchModel.branchCode = '';
    this.searchModel.branchId = 0;
  }

}
