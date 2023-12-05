import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { RepresentativeJourneyListModel } from 'src/app/core/Models/ListModels/RepresentativeJourneyListModel';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { RepresentativeJourneySearchModel } from 'src/app/core/Models/SearchModels/RepresentativeJourneySearchModel';
import { RepresentativeJourneyService } from 'src/app/core/services/RepresentativeJourney.Service';
import { ManageJourneyPlanComponent } from '../components/manage-journey-plan/manage-journey-plan.component';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { TranslateService } from '@ngx-translate/core';
import { JourneyPlanStatisticsComponent } from '../components/journey-plan-statistics/journey-plan-statistics.component';
import { JourneyClearModel } from 'src/app/core/Models/DtoModels/JourneyClearModel';
import { ChooserClientComponent } from '../../shared/chooser-client/chooser-client.component';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { RepresentativeModel } from 'src/app/core/Models/EntityModels/representativeModel';
import { ClientModel } from 'src/app/core/Models/EntityModels/clientModel';
import { ChooserRepresentativeComponent } from '../../shared/chooser-representative/chooser-representative.component';
import { SupervisorListModel } from 'src/app/core/Models/ListModels/SupervisorListModel';
import { ChooserSupervisorComponent } from '../../shared/chooser-supervisor/chooser-supervisor.component';
import { BranchModel } from 'src/app/core/Models/EntityModels/branchModel';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { SupervisorModel } from 'src/app/core/Models/EntityModels/supervisorModel';
import { ChooserBranchComponent } from '../../shared/chooser-branch/chooser-branch.component';

import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { RepresentativeJourneyModel } from 'src/app/core/Models/EntityModels/RepresentativeJourneyModel';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { MenuService } from 'src/app/core/services/Menu.Service';
import { ChooserRouteComponent } from '../../shared/chooser-route/chooser-route.component';
import { RouteSetupListModel } from 'src/app/core/Models/ListModels/RouteSetupListModel';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { RouteTypeService } from 'src/app/core/services/RouteType.Service';

@Component({
  selector: 'app-journey-plan',
  templateUrl: './journey-plan.component.html',
  styleUrls: ['./journey-plan.component.scss']
})
export class JourneyPlanComponent implements OnInit {

  gridModel: ResponseModel<RepresentativeJourneyListModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }

  searchModel: RepresentativeJourneySearchModel = {
    representativeId: 0,
    represtitiveUserId: 0,
    supervisorId: 0,
    routeId: 0,
    branchId: 0,
    kindId: 0,
    routeTypeId:0, 
    representativeCode: '',
    represtitiveUserCode: '',
    supervisorCode: '',
    routeCode: '',
    branchCode: '',
    kindCode: '',
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    TermBy:""

  }

  advanced = false;
  isLoading = false;
  first = 0;
  items: MenuItem[];
  menuItems: MenuItem[];
  cMenuItems: MenuItem[];

  selected: RepresentativeJourneyListModel;

  clearModel: JourneyClearModel = {
    clearDate: new Date()
  };


  MANAGE_GERNEY_HEADER = '';
  GERNEY_STC_HEADER = '';


  CHOOSE_BRANCH = '';
  CHOOSE_SUPERVISOR = '';
  CHOOSE_REPRESENTITIVE = '';
  CHOOSE_CLIENT = '';
  CHOOSE_ROUTE = '';

  routeTypes:LookupModel[]=[];

  constructor(
    private _AppMessageService: AppMessageService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _RepresentativeJourneyService: RepresentativeJourneyService,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private _RouteTypeService: RouteTypeService,

    private _MenuService:MenuService,
  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Create Journey Plan').subscribe((res) => { this.MANAGE_GERNEY_HEADER = res });
    this._translateService.get('Journey Statistics').subscribe((res) => { this.GERNEY_STC_HEADER = res });

    this._translateService.get('Choose Branch').subscribe((res) => { this.CHOOSE_BRANCH = res });
    this._translateService.get('Choose Supervisor').subscribe((res) => { this.CHOOSE_SUPERVISOR = res });
    this._translateService.get('Choose Sales Man').subscribe((res) => { this.CHOOSE_REPRESENTITIVE = res });
    this._translateService.get('Choose Client').subscribe((res) => { this.CHOOSE_CLIENT = res });

    this._translateService.get('Choose Route').subscribe((res) => { this.CHOOSE_ROUTE = res });



    this.searchModel.branchId = 0;
    this.searchModel.branchCode = '';

    this.searchModel.supervisorId = 0;
    this.searchModel.supervisorCode = '';

    this.searchModel.representativeId = 0;
    this.searchModel.representativeCode = '';



  }

  ngOnInit(): void {


    this.menuItems = [
      {
        label: 'Upload Journey',
        icon: 'pi pi-fw pi-upload',
        command: (event) => this.Manage('upload'),
      },
      {
        label: 'Clear All',
        icon: 'pi pi-fw pi-times',
        command: (event) => this.Manage('clear'),
      },
      {
        label: 'Template',
        icon: 'pi pi-fw pi-cloud-download',
        command: (event) => this.Manage('template'),
      },
      {
        label: 'Export',
        icon: 'pi pi-fw pi-cloud-download',
        command: (event) => this.Manage('download'),
      },
    ];


    this.cMenuItems = [
      {
        label: 'Delete',
        icon: 'pi pi-fw pi-times',
        command: (event) => this.Manage('delete'),
      },
    ];


    this._RouteTypeService.GetAll().then(res=>{
      this.routeTypes=res.data;
      this.routeTypes.unshift({id:0,code:'0',name:'--'});
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

    await this._RepresentativeJourneyService.Filter(this.searchModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._RepresentativeJourneyService.Filter(this.searchModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {


    this.selected=null;
    
    this.isLoading = true;
    await this._RepresentativeJourneyService.Filter(this.searchModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.searchModel.Skip = 0;
    await this._RepresentativeJourneyService.Filter(this.searchModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel = {
      representativeId: 0,
      represtitiveUserId: 0,
      supervisorId: 0,
      routeTypeId:0,
      routeId: 0,
      branchId: 0,
      kindId: 0,
      representativeCode: '',
      represtitiveUserCode: '',
      supervisorCode: '',
      routeCode: '',
      branchCode: '',
      kindCode: '',
      Take: 30,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: undefined,
    TermBy:""

    }



    this.searchModel.branchId = 0;
    this.searchModel.branchCode = '';

    this.searchModel.supervisorId = 0;
    this.searchModel.supervisorCode = '';

    this.searchModel.representativeId = 0;
    this.searchModel.representativeCode = '';

  }


  async Manage(operation) {

    if (operation == 'upload') {
      var ref = this.dialogService.open(ManageJourneyPlanComponent, {
        header: this.MANAGE_GERNEY_HEADER,
        width: '400px',
        contentStyle: { "max-height": "600px", "height": "600px", "overflow": "auto" },
        baseZIndex: 10000
      });


      ref.onClose.subscribe(() => {
        this.reloadFilter();

      });
    }


    if (operation == 'clear') {
      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {

          this.isLoading = true;
          this._RepresentativeJourneyService.Clear(this.clearModel).then(res => {
            this.advancedFilter();
            this.isLoading = false;
          })

        },
        reject: () => {
          //reject action
        }
      });
    }
    if (operation == 'template') {
      this.isLoading = true;
      (await this._RepresentativeJourneyService.Template()).subscribe((data: any) => {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "JourneyTemplate_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);


        this.isLoading = false;
      })
    }
    if (operation == 'download') {
      this.isLoading = true;
      (await this._RepresentativeJourneyService.Download(this.searchModel)).subscribe((data: any) => {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "CuurentJourney_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);


        this.isLoading = false;
      })
    }
    if (operation == 'stc') {
      this.isLoading = true;
      (await this._RepresentativeJourneyService.Missing()).subscribe((data: any) => {
  
        console.log(data);
  
        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "MissingRepresentatives_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);
  
  
        this.isLoading = false;
      })
    }

    


    this.refreshMenu();

  }

  async onSelectionChange(event) {
    this.refreshMenu();
  }
  refreshMenu() {

  }
  choose_Branch() {
    var ref = this.dialogService.open(ChooserBranchComponent, {
      header: this.CHOOSE_BRANCH,
      width: '600px',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((branch: BranchListModel) => {
      if (branch) {
        this.searchModel.branchCode = branch.branchCode;
        this.searchModel.branchId = branch.branchId;

      }
    });
  }
  clear_Branch() {
    this.searchModel.branchCode = '';
    this.searchModel.branchId = 0;
  }


  choose_Route() {
    var ref = this.dialogService.open(ChooserRouteComponent, {
      header: this.CHOOSE_BRANCH,
      width: '1000px',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((route: RouteSetupListModel) => {
      if (route) {
        this.searchModel.routeCode = route.routeCode;
        this.searchModel.routeId = route.routeId;

      }
    });
  }
  clear_Route() {
    this.searchModel.routeCode = '';
    this.searchModel.routeId = 0;
  }

  choose_Supervisor() {
    var ref = this.dialogService.open(ChooserSupervisorComponent, {
      header: this.CHOOSE_SUPERVISOR,
      width: '1200px',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((supervisor: SupervisorListModel) => {
      if (supervisor) {


        this.searchModel.supervisorCode = supervisor.supervisorCode;
        this.searchModel.supervisorId = supervisor.supervisorId;

        this.searchModel.representativeCode = '';
        this.searchModel.representativeId = 0;

      }
    });
  }

  clear_Supervisor() {
    this.searchModel.supervisorCode = '';
    this.searchModel.supervisorId = 0;
  }

  choose_Representative() {
    var ref = this.dialogService.open(ChooserRepresentativeComponent, {
      header: this.CHOOSE_SUPERVISOR,
      width: '1200px',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((represeentitive: RepresentativeListModel) => {
      if (represeentitive) {


        this.searchModel.representativeCode = represeentitive.representativeCode;
        this.searchModel.representativeId = represeentitive.representativeId;

      }
    });
  }

  clear_Representative() {
    this.searchModel.representativeCode = '';
    this.searchModel.representativeId = 0;
  }

}
