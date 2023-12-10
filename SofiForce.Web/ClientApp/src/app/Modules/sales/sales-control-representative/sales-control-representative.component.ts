import { Component, OnInit } from '@angular/core';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { DialogService, DynamicDialogConfig } from 'primeng/dynamicdialog';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { FormatterService } from 'src/app/core/services/Formatter.service';
import { SalesControlSearchModel } from 'src/app/core/Models/SearchModels/SalesControlSearchModel';
import { BranchModel } from 'src/app/core/Models/EntityModels/branchModel';
import { SupervisorModel } from 'src/app/core/Models/EntityModels/supervisorModel';
import { RepresentativeModel } from 'src/app/core/Models/EntityModels/representativeModel';
import { SalesControlService } from 'src/app/core/services/SalesControl.Service';


import { saveAsPng, saveAsJpeg } from 'save-html-as-image';
import { SalesRepresentativeControlModel } from 'src/app/core/Models/StatisticalModels/SalesRepresentativeControlModel';
import { ChooserSupervisorComponent } from '../../shared/chooser-supervisor/chooser-supervisor.component';
import { SupervisorListModel } from 'src/app/core/Models/ListModels/SupervisorListModel';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { ChooserBranchComponent } from '../../shared/chooser-branch/chooser-branch.component';
import { ChooserRepresentativeComponent } from '../../shared/chooser-representative/chooser-representative.component';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { SalesControlClientComponent } from '../sales-control-client/sales-control-client.component';
import { ClientModel } from 'src/app/core/Models/EntityModels/clientModel';
import { NotificationModel } from 'src/app/core/Models/EntityModels/NotificationModel';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { NotificationTypeService } from 'src/app/core/services/NotificationType.Service';
import { PriorityService } from 'src/app/core/services/Priority.Service';
import { UtilService } from 'src/app/core/services/util.service';
import { NotificationService } from 'src/app/core/services/Notification.Service';
import { MenuService } from 'src/app/core/services/Menu.Service';
import { UserService } from 'src/app/core/services/User.Service';
import { UserModel } from 'src/app/core/Models/DtoModels/UserModel';
import { PerformanceSalesmanModel } from 'src/app/core/Models/StatisticalModels/PerformanceSalesmanModel';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';
@Component({
  selector: 'app-sales-control-representative',
  templateUrl: './sales-control-representative.component.html',
  styleUrls: ['./sales-control-representative.component.scss']
})
export class SalesControlRepresentativeComponent implements OnInit {
  model: PerformanceSalesmanModel[] = []

  notificationModel: NotificationModel = {
    notificationId: 0,
    notificationDate: undefined,
    scheduleTime: undefined,
    notificationDateTime: undefined,
    priorityId: 0,
    message: '',
    notificationTypeId: 0,
    userGroupId: 0,
    UserId: 0
  };
  
  searchModel: SalesControlSearchModel = {
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    branchId: 0,
    supervisorId: 0,
    representativeId: 0,
    fromDate: undefined,
    toDate: undefined,
    branchCode: undefined,
    supervisorCode: undefined,
    representativeCode: undefined,
    clientId: 0,
    clientCode: undefined,
    TermBy:""

  };
  selected: SalesRepresentativeControlModel;

  isLoading = false;
  menuItems: MenuItem[];

  advanced=false;

  CHOOSE_BRANCH='';
  CHOOSE_SUPERVISOR='';
  CHOOSE_REPRESENTITIVE='';

  SHOW_CLIENT='';
  errorMessage='';
  current: UserModel;
  pop = false;
  showSTC = true;


  notificationTypes: LookupModel[] = [];
  priorities: LookupModel[] = [];

  constructor(
    private _FormatterService: FormatterService,
    private _SalesControlService: SalesControlService,
    private _translationLoaderService: TranslationLoaderService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _AppMessageService: AppMessageService,
    private config: DynamicDialogConfig,

    private _NotificationService: NotificationService,
    private _NotificationTypeService: NotificationTypeService,
    private _PriorityService: PriorityService,
    private _UtilService: UtilService,

    private _MenuService:MenuService,
    private _user: UserService,
    private _commonCrudService : CommonCrudService,
  ) {
    this.current = _user.Current();
    this._translationLoaderService.loadTranslations(english, arabic);


    this.notificationModel.notificationDate = _UtilService.LocalDate(new Date());
    this.notificationModel.scheduleTime = _UtilService.LocalDate(new Date());
    this.notificationModel.notificationDateTime = _UtilService.LocalDate(new Date());

    this.searchModel.branchId = 0;
    this.searchModel.branchCode = '';

    this.searchModel.supervisorId = 0;
    this.searchModel.supervisorCode = '';

    this.searchModel.representativeId = 0;
    this.searchModel.representativeCode = '';

    this.searchModel.clientId = 0;
    this.searchModel.clientCode = '';
    

    this.searchModel.fromDate = new Date();
    this.searchModel.toDate = new Date();

    console.log(this.searchModel);

    if (this.config.data) {
      if(this.config.data.searchModel){
        this.searchModel= this.config.data.searchModel;
      }
      if(this.config.data.pop){
        this.pop= true;
        this.showSTC=false;

      }
    }


  }
  hideSTC() {
    this.showSTC = !this.showSTC;
  }
  ngOnInit(): void {


    this._translateService.get('Choose Branch').subscribe((res) => { this.CHOOSE_BRANCH = res });
    this._translateService.get('Choose Supervisor').subscribe((res) => { this.CHOOSE_SUPERVISOR = res });
    this._translateService.get('Choose Sales Man').subscribe((res) => { this.CHOOSE_REPRESENTITIVE = res });
    this._translateService.get('Clients Details').subscribe((res) => { this.SHOW_CLIENT = res });

    this._translateService.get('Select branch to view the performance').subscribe((res) => { this.errorMessage = res });


    this.reload();



    this._commonCrudService.get("NotificationType/GetAll", LookupModel).then(res=>{
      // this._NotificationTypeService.GetAll().then(res=>{
      this.notificationTypes=res.data;
    })

    this._commonCrudService.get("Priority/GetAll", LookupModel).then(res=>{
      // this._PriorityService.GetAll().then(res=>{
      this.priorities=res.data;
    })


  }
  async saveNotification(){

  }

  async reload() {
    
    this.isLoading = true;

    this._commonCrudService.post("SalesControl/representative", this.searchModel, PerformanceSalesmanModel).then(res => {
      // this._SalesControlService.getRepresentative(this.searchModel).then(res => {
      this.model = res.data;
      this.isLoading = false;
    })
  }

  async clearFilter(){

    this.searchModel.branchId=0;
    this.searchModel.branchCode='';
    this.searchModel.supervisorId=0;
    this.searchModel.supervisorCode='';

    this.searchModel.representativeId=0;
    this.searchModel.representativeCode='';

    this.searchModel.clientId=0;
    this.searchModel.clientCode='';

    await this.reload();

  }
  async advancedFilter(){
    await this.reload();
  }

  async onSelectionChange(event) {
    //this.refreshMenu();
  }


  export(element) {
    const node = document.getElementById(element);

    //download the node as png. Image (2019-12-01).png
    saveAsPng(node);
  }

  getFormated(number) {
    if (number == undefined || number == null)
      return 0;
    return this._FormatterService.kFormatter(number);
  }

  getCommaFormated(number) {
    if (number == undefined || number == null)
      return 0;
    return this._FormatterService.CommaFormatter(number);
  }

  async exportExcel(){
    this.isLoading=true;
      await (this._commonCrudService.postFile("SalesControl/representativeExport", this.searchModel)).subscribe((data:any)=> {
        // await (this._SalesControlService.representativeExport(this.searchModel)).subscribe((data:any)=> {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "RepresentativeSales_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);

       
        this.isLoading=false;
      })
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

        this.searchModel.supervisorCode = '';
        this.searchModel.supervisorId = 0;

        this.searchModel.representativeCode = '';
        this.searchModel.representativeId = 0;

      }
    });
  }
  clear_Branch() {

    this.searchModel.branchCode = '';
    this.searchModel.branchId = 0;
  }

  choose_Supervisor() {
    var ref = this.dialogService.open(ChooserSupervisorComponent, {
      header: this.CHOOSE_SUPERVISOR,
      width: '90%',
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

  clear_Supervisor(){
    this.searchModel.supervisorCode = '';
    this.searchModel.supervisorId = 0;
  }
  
  choose_Representative() {
    var ref = this.dialogService.open(ChooserRepresentativeComponent, {
      data:{branchId:this.searchModel.branchId,supervisorId:this.searchModel.supervisorId},
      header: this.CHOOSE_SUPERVISOR,
      width: '90%',
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

  clear_Representative(){
    this.searchModel.representativeCode = '';
    this.searchModel.representativeId = 0;
  }


  showClient(representativeId) {

    let mySearch: SalesControlSearchModel = {
      Take: this.searchModel.Take,
      Skip: this.searchModel.Skip,
      Term: this.searchModel.Term,
      FilterBy: this.searchModel.FilterBy,
      SortBy: this.searchModel.SortBy,
      branchId: this.searchModel.branchId,
      supervisorId: this.searchModel.supervisorId,
      representativeId: representativeId,
      fromDate: this.searchModel.fromDate,
      toDate: this.searchModel.toDate,
      branchCode: this.searchModel.branchCode,
      supervisorCode: this.searchModel.supervisorCode,
      representativeCode: this.searchModel.representativeCode,
      clientId: this.searchModel.clientId,
      clientCode: this.searchModel.clientCode,
    TermBy:""

    };
    var ref = this.dialogService.open(SalesControlClientComponent, {
      data: {
        searchModel: mySearch,
        pop: true,
      },
      header: this.SHOW_CLIENT,
      width: '95%',
      modal: true,
      contentStyle: { "max-height": "100vh", "height": "100vh", "overflow": "auto" },
      baseZIndex: 10000
    });


  }

}
