import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';


import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { RepresentativeSearchModel } from 'src/app/core/Models/SearchModels/RepresentativeSearchModel';
import { BooleanService } from 'src/app/core/services/Boolean.Service';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { ChooserSupervisorComponent } from '../chooser-supervisor/chooser-supervisor.component';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { ChooserBranchComponent } from '../chooser-branch/chooser-branch.component';
import { SupervisorListModel } from 'src/app/core/Models/ListModels/SupervisorListModel';
import { TranslateService } from '@ngx-translate/core';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';
import { BranchModel } from '../../../core/Models/EntityModels/branchModel';
import { SupervisorModel } from '../../../core/Models/EntityModels/supervisorModel';

@Component({
  selector: 'app-chooser-representative',
  templateUrl: './chooser-representative.component.html',
  styleUrls: ['./chooser-representative.component.scss']
})
export class ChooserRepresentativeComponent implements OnInit {

  isLoading=false;
  model: ResponseModel<RepresentativeListModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: []
  };

  selected={} as RepresentativeListModel;

  searchModel: RepresentativeSearchModel = {
    supervisorId: 0,
    supervisorCode: '',
    branchId: 0,
    branchCode: '',
    representativeName: '',
    terminationDate: undefined,
    joinDate: undefined,
    phone: '',
    kindId: 0,
    kindIds:'',
    isActive: 0,
    isTerminated: 0,
    terminationReasonId: 0,
    Take: 20,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    searchMode:0,
    businessUnitId:0,
    companyCode:'',
    TermBy:""


  }

  advanced=false;
  first=0;


  status: LookupModel[];
  terminationReaons: LookupModel[];
  agentTypes: LookupModel[];
  
  CHOOSE = '';


  constructor(
    private ref: DynamicDialogRef, 
    private config: DynamicDialogConfig,
    private messageService: MessageService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private _BooleanService: BooleanService,
    private _commonCrudService : CommonCrudService,

    ) { 
    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });

    if (this.config.data) {
      if(+this.config.data.branchId>0){
        this.searchModel.branchId= +this.config.data.branchId
      }
    }

    if (this.config.data) {
      if(+this.config.data.supervisorId>0){
        this.searchModel.supervisorId= +this.config.data.supervisorId
      }
    }

    if (this.config.data) {
      if(this.config.data.kindId){
        this.searchModel.kindId= this.config.data.kindId
      }
    }

    if (this.config.data) {
      if(this.config.data.kindIds){
        this.searchModel.kindIds= this.config.data.kindIds
      }
    }

    if (this.config.data) {
      if(this.config.data.searchModel){
        this.searchModel= this.config.data.searchModel
      }
    }

  }

  async ngOnInit() {

    this.isLoading = true;

    if(this.searchModel.branchId>0){
      await this._commonCrudService.get("Branch/GetByid?Id="+this.searchModel.branchId, BranchModel).then(res=>{
        this.searchModel.branchCode=res.data.branchCode
      })
    }

    if(this.searchModel.supervisorId>0){
      await this._commonCrudService.get("Supervisor/getById?Id="+this.searchModel.supervisorId, SupervisorModel).then(res=>{
        this.searchModel.supervisorCode=res.data.supervisorCode
      })
    }

    this._commonCrudService.get("RepresentativeKind/GetAll", LookupModel).then(res=>{
      this.agentTypes=res.data;
      this.agentTypes.unshift({id:0,code:'0',name:'--'});

    })
    this._commonCrudService.get("TerminationReason/GetAll", LookupModel).then(res=>{
      this.terminationReaons=res.data;
      this.terminationReaons.unshift({id:0,code:'0',name:'--'});
    })

    this._BooleanService.GetAll(localStorage.getItem('lan')).then(res=>{
      this.status=res;
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

    await this._commonCrudService.post("Representative/Filter", this.searchModel, RepresentativeListModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._commonCrudService.post("Representative/Filter", this.searchModel, RepresentativeListModel).then(res => {
        this.model = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {

    this.selected=null;
    
    this.isLoading = true;
    await this._commonCrudService.post("Representative/Filter", this.searchModel, RepresentativeListModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.searchModel.Skip = 0;
    await this._commonCrudService.post("Representative/Filter", this.searchModel, RepresentativeListModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel = {

      supervisorId: 0,
      supervisorCode: '',
      branchId: 0,
      branchCode: '',
      representativeName: '',
      terminationDate: undefined,
      joinDate: undefined,
      phone: '',
      kindId: 0,
      kindIds:'',
      isActive: 0,
      isTerminated: 0,
      terminationReasonId: 0,
      Take: 30,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: undefined,
      searchMode:0,
      businessUnitId:0,
      companyCode:'',
    TermBy:""


    };
  }

  choose_Branch(){
    var ref = this.dialogService.open(ChooserBranchComponent, {
      header: this.CHOOSE,
      width: '600px',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((res:BranchListModel) => {
      if(res){
        this.searchModel.branchCode=res.branchCode;
        this.searchModel.branchId=res.branchId;
      }
    });
  }
  clear_Branch(){
    this.searchModel.branchCode='';
    this.searchModel.branchId=0;
  }
  choose_Suppervisor(){
    var ref = this.dialogService.open(ChooserSupervisorComponent, {
      header: this.CHOOSE,
      width: '1200px',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((res:SupervisorListModel) => {
      if(res){
        this.searchModel.supervisorCode=res.supervisorCode;
        this.searchModel.supervisorId=res.supervisorId;
      }
    });
  }
  clear_Suppervisor(){
    this.searchModel.supervisorCode='';
    this.searchModel.supervisorId=0;
  }

  async onRowDblClick(e,data){
    if(data){
      this.ref.close(data);
    }
  }
}
