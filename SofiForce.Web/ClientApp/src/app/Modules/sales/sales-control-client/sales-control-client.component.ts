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
import { SalesControlService } from 'src/app/core/services/SalesControl.Service';


import { saveAsPng, saveAsJpeg } from 'save-html-as-image';
import { ChooserSupervisorComponent } from '../../shared/chooser-supervisor/chooser-supervisor.component';
import { SupervisorListModel } from 'src/app/core/Models/ListModels/SupervisorListModel';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { ChooserBranchComponent } from '../../shared/chooser-branch/chooser-branch.component';
import { ChooserRepresentativeComponent } from '../../shared/chooser-representative/chooser-representative.component';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';

import { ChooserClientComponent } from '../../shared/chooser-client/chooser-client.component';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { MenuService } from 'src/app/core/services/Menu.Service';
import { UserService } from 'src/app/core/services/User.Service';
import { UserModel } from 'src/app/core/Models/DtoModels/UserModel';
import { PerformanceClientDetailModel, PerformanceClientModel } from 'src/app/core/Models/StatisticalModels/SalesClientControlModel';

@Component({
  selector: 'app-sales-control-client',
  templateUrl: './sales-control-client.component.html',
  styleUrls: ['./sales-control-client.component.scss']
})
export class SalesControlClientComponent implements OnInit {

  model: ResponseModel<PerformanceClientModel> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: {
      callAll:0,
      callNegative:0,
      callPercentage:0,
      callPostitive:0,
      clientCoverage:0,
      myOrders:0,
      mySales:0,
      perormanceLabel:'',
      perormancePercentage:0,
      salesPercentage:0,
      targetCall:0,
      targetValue:0,
      targetVisit:0,
      visitAll:0,
      visitNegative:0,
      visitPercentage:0,
      visitPostitive:0,
      detailModels:[]
    } as PerformanceClientModel
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
  selected: PerformanceClientDetailModel;

  isLoading = false;
  menuItems: MenuItem[];

  advanced=false;

  CHOOSE_BRANCH='';
  CHOOSE_SUPERVISOR='';
  CHOOSE_REPRESENTITIVE='';
  CHOOSE_CLIENT='';

  current: UserModel;
  pop = false;
  showSTC = true;
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
    private _MenuService:MenuService,
    private _user: UserService,
  ) {
    this.current = _user.Current();
    this._translationLoaderService.loadTranslations(english, arabic);


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
    this._translateService.get('Choose Client').subscribe((res) => { this.CHOOSE_CLIENT = res });



    this.reload();


  }

  async reload() {

    if(this.searchModel.representativeId==0){

      this.messageService.add({ severity: 'error', detail:  this._AppMessageService.MESSAGE_INVALID });
      return;
    }

    this.isLoading = true;
    this._SalesControlService.getClient(this.searchModel).then(res => {
      this.model = res;
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
      await (this._SalesControlService.clientExport(this.searchModel)).subscribe((data:any)=> {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "ClientSales_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
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

  clear_Supervisor(){
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

  clear_Representative(){
    this.searchModel.representativeCode = '';
    this.searchModel.representativeId = 0;
  }

  choose_Client() {
    var ref = this.dialogService.open(ChooserClientComponent, {
      header: this.CHOOSE_CLIENT,
      width: '90%',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((client: ClientListModel) => {
      if (client) {


        this.searchModel.clientCode = client.clientCode;
        this.searchModel.clientId = client.clientId;

      }
    });
  }

  clear_Client(){
    this.searchModel.clientCode = '';
    this.searchModel.clientId = 0;
  }


}
