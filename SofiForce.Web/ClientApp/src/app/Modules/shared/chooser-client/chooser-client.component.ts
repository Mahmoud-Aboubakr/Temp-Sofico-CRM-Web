import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';


import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { ClientSearchModel } from 'src/app/core/Models/SearchModels/ClientSearchModel';
import { ClientService } from 'src/app/core/services/Client.Service';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { PaymentTermService } from 'src/app/core/services/PaymentTerm.Service';
import { ClientClassificationService } from 'src/app/core/services/ClientClassification.Service';
import { ClientGroupSubService } from 'src/app/core/services/ClientGroupSub.Service';
import { ClientGroupService } from 'src/app/core/services/ClientGroup.Service';
import { LocationLevelService } from 'src/app/core/services/LocationLevel.Service';
import { ClientTypeService } from 'src/app/core/services/ClientType.Service';
import { CityService } from 'src/app/core/services/City.Service';
import { GovernerateService } from 'src/app/core/services/Governerate.Service';
import { BooleanService } from 'src/app/core/services/Boolean.Service';
import { SupervisorTypeService } from 'src/app/core/services/SupervisorType.Service';
import { TranslateService } from '@ngx-translate/core';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { ChooserBranchComponent } from '../chooser-branch/chooser-branch.component';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { BranchService } from 'src/app/core/services/Branch.Service';

@Component({
  selector: 'app-chooser-client',
  templateUrl: './chooser-client.component.html',
  styleUrls: ['./chooser-client.component.scss']
})
export class ChooserClientComponent implements OnInit {


  model: ResponseModel<ClientListModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: []
  };

  selected={} as ClientListModel;

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
    Take: 20,
    Skip: 0,
    Term: '',
    commercialCode: '',
    FilterBy: [],
    SortBy: {
      Property: "clientId",
      Order: "desc"
    },
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
  
  advanced=false;
  loading = false;
  first=0;
  CHOOSE='';

  searchBy: LookupModel[] = [{id:1,code:'clientCode',name:'Client Code'},{id:2,code:'clientNameAr',name:'Name Arabic'},{id:3,code:'clientNameEn',name:'Name English'}];

  constructor(

    private config: DynamicDialogConfig,

    private _AppMessageService: AppMessageService,
    private _ClientService: ClientService,
    private _BranchService: BranchService,

    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private confirmationService: ConfirmationService,

    private ref: DynamicDialogRef, 

    private messageService: MessageService,

    
    private _BooleanService: BooleanService,


    private _GovernerateService: GovernerateService,
    private _CityService: CityService,



    private _ClientTypeService: ClientTypeService,
    private _LocationLevelService: LocationLevelService,

    private _ClientGroupService: ClientGroupService,
    private _ClientGroupSubService: ClientGroupSubService,
    private _ClientClassificationService: ClientClassificationService,
    private _PaymentTermService: PaymentTermService,

    
    ) { 
    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });

    if (this.config.data) {
      if(+this.config.data.branchId>0){
        this.searchModel.branchId= +this.config.data.branchId
      }
    }

    if (this.config.data && this.config.data.searchModel) {
        this.searchModel= this.config.data.searchModel
    }

    var found=localStorage.getItem("chooser-client.component.termBy")
    if(found){
      console.log(found);
      this.searchModel.TermBy=found;
    }

  }
  OnTermChange(arg){
    localStorage.setItem("chooser-client.component.termBy",arg.value);
  }

  async ngOnInit() {



    this._BooleanService.GetAll(localStorage.getItem('lan')).then(res => {
      this.IsActives = res;
    })
    this._BooleanService.GetAll(localStorage.getItem('lan')).then(res => {
      this.Istaxables = res;
    })
    this._BooleanService.GetAll(localStorage.getItem('lan')).then(res => {
      this.IsChains = res;
    })

    this._GovernerateService.GetAll().then(res => {
      this.Governerates = res.data;

      if (this.Governerates.length > 0) {
        this._CityService.GetByGovernerate(this.Governerates[0].id).then(res => {
          this.Cities = res.data;
          this.Cities.unshift({ id: 0, code: '0', name: '--' });
        })
      }

      this.Governerates.unshift({ id: 0, code: '0', name: '--' });
    });

    this._ClientTypeService.GetAll().then(res => {
      this.ClientTypes = res.data;
      this.ClientTypes.unshift({ id: 0, code: '0', name: '--' });
    })

    this._LocationLevelService.GetAll().then(res => {
      this.LocationLevels = res.data;
      this.LocationLevels.unshift({ id: 0, code: '0', name: '--' });
    })


    this._ClientGroupService.GetAll().then(res => {
      this.MainChannels = res.data;
      this.MainChannels.unshift({ id: 0, code: '0', name: '--' });
    })

    this._ClientClassificationService.GetAll().then(res => {
      this.Classfications = res.data;
      this.Classfications.unshift({ id: 0, code: '0', name: '--' });
    })

    this._PaymentTermService.GetAll().then(res => {
      this.PaymentTerms = res.data;
      this.PaymentTerms.unshift({ id: 0, code: '0', name: '--' });
    })

    this.loading = true;
    await this._ClientService.Filter(this.searchModel).then(res => {
      this.model = res;
      this.loading = false;
    })

    if(this.searchModel.branchId>0){
      this._BranchService.GetByid(this.searchModel.branchId).then(res=>{
        this.searchModel.branchCode=res.data.branchCode;
      })
    }
  }

  async filter(event) {
    console.log(event);
    this.loading = true;
    this.searchModel.Skip = event.first;
  
    if (event.filters.clientCode)
      this.searchModel.clientCode = event.filters.clientCode.value;
    if (event.filters.clientName)
      this.searchModel.clientName = event.filters.clientName.value;
    if (event.filters.phone)
      this.searchModel.phone = event.filters.phone.value;
    if (event.filters.mobile)
      this.searchModel.mobile = event.filters.mobile.value;
    if (event.filters.whatsApp)
      this.searchModel.whatsApp = event.filters.whatsApp.value;
    if (event.filters.isActive)
      this.searchModel.isActive = event.filters.isActive.value;

    if (event.sortField) {
      this.searchModel.SortBy.Property = event.sortField;
      if (event.sortOrder == 1) {
        this.searchModel.SortBy.Order = "asc";
      }
      else {
        this.searchModel.SortBy.Order = "desc";

      }
    }

    await this._ClientService.Filter(this.searchModel).then(res => {
      this.model = res;
      this.loading = false;
     
      if(res.data.length>0){
        this.selected=res.data[0];
      }

    })

   
  }

  async autoFilter() {

    if (this.searchModel.Term.length >=2) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.loading = true;
      await this._ClientService.Filter(this.searchModel).then(res => {
        this.model = res;
        this.loading = false;

        if(res.data.length>0){
          this.selected=res.data[0];
        }
      })
    }
    
    

  }

  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first=0;
      this.searchModel.Skip=0;
      this.loading = true;
      await this._ClientService.Filter(this.searchModel).then(res => {
        this.model = res;
        this.loading = false;
        if(res.data.length>0){
          this.selected=res.data[0];
        }

      })
    }

  }

  async advancedFilter() {
    this.loading = true;
    this.first=0;
    this.searchModel.Skip=0;
    await this._ClientService.Filter(this.searchModel).then(res => {
      this.model = res;
      this.loading = false;

      if(res.data.length>0){
        this.selected=res.data[0];
      }
    })

   
  }
  async advancedClear() {
    this.first=0;
    this.loading = true;
    await this._ClientService.Filter(this.searchModel).then(res => {
      this.model = res;
      this.loading = false;

      if(res.data.length>0){
        this.selected=res.data[0];
      }
    })

   
  }
  async onRowDblClick(e,data){
    if(data){
      this.ref.close(data);
    }
  }

  async onGovernerateChange(e) {

    this.Cities = [];
    this.loading = true;

    this._CityService.GetByGovernerate(e.value).then(res => {
      this.Cities = res.data;
      this.loading = false;
      this.Cities.unshift({ id: 0, code: '0', name: '--' });
    })
  }

  async onChannelChange(e) {
    this.SubChannels = [];
    this.loading = true;

    this._ClientGroupSubService.GetByClientGroup(e.value).then(res => {
      this.SubChannels = res.data;
      this.loading = false;
      this.SubChannels.unshift({ id: 0, code: '0', name: '--' });

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
  clear_Branch() {
    this.searchModel.branchCode = '';
    this.searchModel.branchId = 0;
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
      Take: 20,
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


  getAvailableBalance(limit,balance){

    if(!limit) limit=0;
    if(!balance) balance=0;

    let available= limit-balance;
    if(available<0) available=0;

    return available;

  }
  

}

