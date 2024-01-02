import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { TranslateService } from '@ngx-translate/core';
import { SupervisorListModel } from 'src/app/core/Models/ListModels/SupervisorListModel';
import { SupervisorSearchModel } from 'src/app/core/Models/SearchModels/SupervisorSearchModel';
import { ManageSupervisorComponent } from '../components/manage-supervisor/manage-supervisor.component';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { SupervisorModel } from 'src/app/core/Models/EntityModels/supervisorModel';
import { ManageSupervisorRepresentitiveComponent } from '../components/manage-supervisor-representitive/manage-supervisor-representitive.component';
import { SupervisorStatisticsComponent } from '../components/supervisor-statistics/supervisor-statistics.component';
import { BooleanService } from 'src/app/core/services/Boolean.Service';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { ChooserBranchComponent } from '../../shared/chooser-branch/chooser-branch.component';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { SalesControlSearchModel } from 'src/app/core/Models/SearchModels/SalesControlSearchModel';
import { SalesControlRepresentativeComponent } from '../sales-control-representative/sales-control-representative.component';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';
@Component({
  selector: 'app-supervisors',
  templateUrl: './supervisors.component.html',
  styleUrls: ['./supervisors.component.scss']
})
export class SupervisorsComponent implements OnInit {

  gridModel: ResponseModel<SupervisorListModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }

  searchModel: SupervisorSearchModel = {
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

  }

  advanced = false;
  isLoading = false;
  actions = false;

  first = 0;
  items: MenuItem[];
  menuItems: MenuItem[];
  contextItems: MenuItem[];
  selected: SupervisorListModel;


  CREATE_NEW_HEADER = '';
  EDIT_HEADER = '';
  MANAGE_REPRESENTITVE_HEADER = '';
  SUPERVISOR_STC = '';
  USER_ACCRESS = '';

  CHOOSE = '';
  PERFORMANCE='';

  status: LookupModel[];
  terminationReaons: LookupModel[];
  agentTypes: LookupModel[];

  
  constructor(
    private _AppMessageService: AppMessageService,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _BooleanService: BooleanService,
    private _commonCrudSerice : CommonCrudService,
  ) {
    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Ad New Information').subscribe((res) => { this.CREATE_NEW_HEADER = res });
    this._translateService.get('Edit Information').subscribe((res) => { this.EDIT_HEADER = res });
    this._translateService.get('Manage Representitive').subscribe((res) => { this.MANAGE_REPRESENTITVE_HEADER = res });
    this._translateService.get('Supervisor Statistics').subscribe((res) => { this.SUPERVISOR_STC = res });
    this._translateService.get('User Access').subscribe((res) => { this.USER_ACCRESS = res });
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });
    this._translateService.get('Performance').subscribe((res) => { this.PERFORMANCE = res });

  }

  ngOnInit(): void {

    

    this.menuItems = [
      {
        label: 'Create',
        icon: 'pi pi-fw pi-plus',
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

    this._commonCrudSerice.get("SupervisorType/GetAll", LookupModel).then(res=>{
      this.agentTypes=res.data;
      this.agentTypes.unshift({id:0,code:'0',name:'--'});

    })
    this._commonCrudSerice.get("TerminationReason/GetAll", LookupModel).then(res=>{
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

    await this._commonCrudSerice.post("Supervisor/Filter", this.searchModel, SupervisorListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._commonCrudSerice.post("Supervisor/Filter", this.searchModel, SupervisorListModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {

    this.selected=null;
    
    this.isLoading = true;
    await this._commonCrudSerice.post("Supervisor/Filter", this.searchModel, SupervisorListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.searchModel.Skip = 0;
    await this._commonCrudSerice.post("Supervisor/Filter", this.searchModel, SupervisorListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
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

    }
  }

  async onSelectionChange(event) {
    this.refreshMenu();
  }
  refreshMenu(){
    
  }
  async manage(mode) {

    if (mode == 'n') {

      var ref = this.dialogService.open(ManageSupervisorComponent, {
        header: this.CREATE_NEW_HEADER,
        data: { supervisorId: 0 },
        width: '1000px',
        contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe(() => {
        this.selected = null;
        this.reloadFilter();
        this.refreshMenu();
      });
    }

    if (mode == 'e') {
      if (this.selected != null && this.selected.supervisorId > 0) {
        var ref = this.dialogService.open(ManageSupervisorComponent, {
          header: this.EDIT_HEADER,
          data: { supervisorId: this.selected.supervisorId },
          width: '1000px',
          contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
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

      if (this.selected != null && this.selected.supervisorId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {


            this.isLoading = true;
            let model = {} as SupervisorModel;
            model.supervisorId = this.selected.supervisorId;
            this._commonCrudSerice.post("Supervisor/Delete", model, SupervisorModel).then(res => {
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

    if (mode == 'r') {
      if (this.selected != null && this.selected.supervisorId > 0) {


        var ref = this.dialogService.open(ManageSupervisorRepresentitiveComponent, {
          header: this.EDIT_HEADER,
          data: { supervisorId: this.selected.supervisorId },
          width: '70%',
          contentStyle: { "max-height": "600px", "height": "600px", "overflow": "auto" },
          baseZIndex: 10000
        });

        ref.onClose.subscribe(() => {
          this.selected = null;
          this.reloadFilter();
          this.refreshMenu();
        });


      }
    }

    if (mode == 'x') {
      this.isLoading=true;
      await (this._commonCrudSerice.postFile("Supervisor/Export",this.searchModel)).subscribe((data:any)=> {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "Supervisors_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);

       
        this.isLoading=false;
      })
    }
    if (mode == 's') {
      if (this.selected != null && this.selected.supervisorId > 0) {


        var ref = this.dialogService.open(SupervisorStatisticsComponent, {
          header: this.SUPERVISOR_STC,
          data: { supervisorId: this.selected.supervisorId },
          width: '70%',
          contentStyle: { "max-height": "600px", "height": "600px", "overflow": "auto" },
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

      if (this.selected != null && this.selected.supervisorId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {


            this.isLoading = true;
            let model = {} as SupervisorModel;
            model.supervisorId = this.selected.supervisorId;
            model.isActive=true;
            this._commonCrudSerice.post("Supervisor/Status", model, SupervisorModel).then(res => {
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

      if (this.selected != null && this.selected.supervisorId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {


            this.isLoading = true;
            let model = {} as SupervisorModel;
            model.supervisorId = this.selected.supervisorId;
            model.isActive=false;
            this._commonCrudSerice.post("Supervisor/Status", model, SupervisorModel).then(res => {
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
    if (mode == 'stc') {

      if (this.selected != null && this.selected.supervisorId > 0) {
        let mySearch: SalesControlSearchModel = {
          Take: 100,
          Skip: 0,
          Term: '',
          FilterBy: null,
          SortBy: null,
          branchId: this.selected.branchId,
          supervisorId: this.selected.supervisorId,
          representativeId: 0,
          fromDate: new Date(),
          toDate: new Date(),
          branchCode: this.searchModel.branchCode,
          supervisorCode: this.selected.supervisorCode,
          representativeCode: '',
          clientId: 0,
          clientCode: '',
    TermBy:""

        };
        var ref = this.dialogService.open(SalesControlRepresentativeComponent, {
          data: {
            searchModel: mySearch,
            pop: true,
          },
          header: this.PERFORMANCE,
          width: '90%',
          modal: true,
          height: "90%"
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

}
