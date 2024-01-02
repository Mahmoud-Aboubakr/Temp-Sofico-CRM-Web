import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { TranslateService } from '@ngx-translate/core';
import { SupervisorListModel } from 'src/app/core/Models/ListModels/SupervisorListModel';

import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { RepresentativeSearchModel } from 'src/app/core/Models/SearchModels/RepresentativeSearchModel';
import { ManageRepreseentitiveComponent } from '../components/manage-represeentitive/manage-represeentitive.component';
import { RepresentativeModel } from 'src/app/core/Models/EntityModels/representativeModel';

import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { BooleanService } from 'src/app/core/services/Boolean.Service';
import { ChooserBranchComponent } from '../../shared/chooser-branch/chooser-branch.component';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { ChooserSupervisorComponent } from '../../shared/chooser-supervisor/chooser-supervisor.component';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-representitives',
  templateUrl: './representitives.component.html',
  styleUrls: ['./representitives.component.scss']
})
export class RepresentitivesComponent implements OnInit {

  gridModel: ResponseModel<RepresentativeListModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }

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
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    searchMode:0,
    businessUnitId:0,
    companyCode:'',
    TermBy:""

  }

  advanced = false;
  isLoading = false;
  actions = false;

  first = 0;
  items: MenuItem[];
  menuItems: MenuItem[];
  contextItems: MenuItem[];
  selected: RepresentativeListModel;

  status: LookupModel[];
  terminationReaons: LookupModel[];
  agentTypes: LookupModel[];

  CREATE_NEW_HEADER = '';
  EDIT_HEADER = '';
  REP_STC = '';
  USER_ACCRESS = '';
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
    this._translateService.get('Representative Statistics').subscribe((res) => { this.REP_STC = res });
    this._translateService.get('User Access').subscribe((res) => { this.USER_ACCRESS = res });
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });


    
  }

  ngOnInit(): void {

    

    this.menuItems = [
      {
        label: 'Create',
        icon: 'pi pi-fw pi-plus',
        disabled:true,
        command: (e) => this.manage('n')
      },
      {
        separator: true
      },
      {
        label: 'Export',
        icon: 'pi pi-fw pi-file-excel',
        command: (e) => this.manage('x')
      },
    ];

    this.contextItems = [
      
      {
        label: 'Manage',
        icon: 'pi pi-fw pi-pencil',
        command: (e) => this.manage('e')
      },
      {
        label: 'Delete',
        disabled:true,
        icon: 'pi pi-fw pi-times',
        command: (e) => this.manage('d')
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
        separator: true,
      },
      {
        label: 'Statistics',
        icon: 'pi pi-fw pi-chart-line',
        command: (e) => this.manage('stc')

      },
    ];

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
      this.gridModel = res;
      this.isLoading = false;
    })

  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._commonCrudService.post("Representative/Filter", this.searchModel, RepresentativeListModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {
    this.isLoading = true;
    await this._commonCrudService.post("Representative/Filter", this.searchModel, RepresentativeListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.searchModel.Skip = 0;
    await this._commonCrudService.post("Representative/Filter", this.searchModel, RepresentativeListModel).then(res => {
      this.gridModel = res;
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

  async onSelectionChange(event) {
    this.refreshMenu();
  }
  refreshMenu(){

  }
  async manage(mode) {

    if (mode == 'e') {
      if (this.selected != null && this.selected.representativeId > 0) {
        var ref = this.dialogService.open(ManageRepreseentitiveComponent, {
          header: this.EDIT_HEADER,
          data: { representativeId: this.selected.representativeId },
          width: '1200px',
          contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
          baseZIndex: 10000
        });
        ref.onClose.subscribe(() => {
          this.selected = null;
          this.reloadFilter();
          this.refreshMenu();
        });
      }
    }

    if (mode == 'active') {

      if (this.selected != null && this.selected.representativeId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {


            this.isLoading = true;
            let model = {} as RepresentativeModel;
            model.representativeId = this.selected.representativeId;
            model.isActive=true;
              this._commonCrudService.post("Representative/Status", model, RepresentativeModel).then(res => {
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

      if (this.selected != null && this.selected.representativeId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {


            this.isLoading = true;
            let model = {} as RepresentativeModel;
            model.representativeId = this.selected.representativeId;
            model.isActive=false;
            this._commonCrudService.post("Representative/Status", model, RepresentativeModel).then(res => {
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
}
