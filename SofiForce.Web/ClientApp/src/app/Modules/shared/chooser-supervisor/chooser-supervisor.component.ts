import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';


import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { RepresentativeSearchModel } from 'src/app/core/Models/SearchModels/RepresentativeSearchModel';
import { RepresentativeService } from 'src/app/core/services/Representative.Service';
import { SupervisorListModel } from 'src/app/core/Models/ListModels/SupervisorListModel';
import { SupervisorSearchModel } from 'src/app/core/Models/SearchModels/SupervisorSearchModel';
import { SupervisorService } from 'src/app/core/services/Supervisor.Service';
import { TranslateService } from '@ngx-translate/core';
import { BooleanService } from 'src/app/core/services/Boolean.Service';
import { BranchService } from 'src/app/core/services/Branch.Service';
import { TerminationReasonService } from 'src/app/core/services/TerminationReason.Service';
import { SupervisorTypeService } from 'src/app/core/services/SupervisorType.Service';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { ChooserBranchComponent } from '../chooser-branch/chooser-branch.component';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { BranchModel } from '../../../core/Models/EntityModels/branchModel';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-chooser-supervisor',
  templateUrl: './chooser-supervisor.component.html',
  styleUrls: ['./chooser-supervisor.component.scss']
})
export class ChooserSupervisorComponent implements OnInit {

  model: ResponseModel<SupervisorListModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: []
  };

  selected={} as SupervisorListModel;

  searchModel: SupervisorSearchModel = {
    branchId: 0,
    branchCode: '',
    supervisorName: '',
    terminationDate: undefined,
    joinDate: undefined,
    phone: '',
    supervisorTypeId: 0,
    supervisorTypeIds: '',
    isActive: 1,
    isTerminated: 2,
    terminationReasonId: 0,
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    businessUnitId: 0,
    companyCode: '',
    TermBy:""

  }

  advanced=false;
  loading = false;
  first=0;
  CHOOSE = '';

  status: LookupModel[];
  terminationReaons: LookupModel[];
  agentTypes: LookupModel[];
  
  constructor(
    private _SupervisorService: SupervisorService,
    private ref: DynamicDialogRef, 
    private messageService: MessageService,
    private config: DynamicDialogConfig,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _BooleanService: BooleanService,
    private _BranchService: BranchService,
    private _TerminationReasonService: TerminationReasonService,
    private _commonCrudService : CommonCrudService,
    private _SupervisorTypeService: SupervisorTypeService,
    private _translationLoaderService: TranslationLoaderService,) { 
    this._translationLoaderService.loadTranslations(english, arabic);

    if (this.config.data) {
      if(+this.config.data.branchId>0){
        this.searchModel.branchId= +this.config.data.branchId
      }
    }
  }

  async ngOnInit() {

    this.loading = true;

    if(this.searchModel.branchId>0){
      await this._commonCrudService.get("Branch/GetByid?Id="+this.searchModel.branchId, BranchModel).then(res=>{
        this.searchModel.branchCode=res.data.branchCode
      })
    }

    this._commonCrudService.get("SupervisorType/GetAll", LookupModel).then(res=>{
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

    await this._commonCrudService.post("Supervisor/Filter",this.searchModel,SupervisorListModel).then(res => {
      this.model = res;
      this.loading = false;
    })
  }

  async filter(event) {
    this.loading = true;
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

    this._commonCrudService.post("Supervisor/Filter",this.searchModel,SupervisorListModel).then(res => {
      this.model = res;
      this.loading = false;
    })
  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first=0;
      this.searchModel.Skip=0;
      this.loading = true;
      await this._commonCrudService.post("Supervisor/Filter",this.searchModel,SupervisorListModel).then(res => {
        this.model = res;
        this.loading = false;
      })
    }

  }

  async advancedFilter() {
    this.loading = true;
    this.first=0;
    this.searchModel.Skip=0;
    await this._commonCrudService.post("Supervisor/Filter",this.searchModel,SupervisorListModel).then(res => {
      this.model = res;
      this.loading = false;
    })

   
  }
  async advancedClear() {
    this.first=0;
    this.loading = true;
    this.searchModel.branchId=0;
    
    await this._commonCrudService.post("Supervisor/Filter",this.searchModel,SupervisorListModel).then(res => {
      this.model = res;
      this.loading = false;
    })

   
  }

  async clearFilter() {
    this.searchModel = {

      branchId: 0,
      branchCode: '',
      supervisorName: '',
      terminationDate: undefined,
      joinDate: undefined,
      phone: '',
      supervisorTypeId: 0,
      supervisorTypeIds: '',
      isActive: 0,
      isTerminated: 0,
      terminationReasonId: 0,
      Take: 30,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: undefined,
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

  async onRowDblClick(e,data){
    if(data){
      this.ref.close(data);
    }
  }
}
