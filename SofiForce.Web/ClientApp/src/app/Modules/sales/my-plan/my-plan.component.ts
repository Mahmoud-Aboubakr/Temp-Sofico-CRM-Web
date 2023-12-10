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

import { saveAsPng, saveAsJpeg } from 'save-html-as-image';
import { ChooserClientComponent } from '../../shared/chooser-client/chooser-client.component';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { ManageSalesOrderComponent } from '../components/manage-sales-order/manage-sales-order.component';
import { SalesOrderModel } from 'src/app/core/Models/EntityModels/salesOrderModel';
import { SalesControlSearchModel } from 'src/app/core/Models/SearchModels/SalesControlSearchModel';
import { SalesControlService } from 'src/app/core/services/SalesControl.Service';
import { UserService } from 'src/app/core/services/User.Service';
import { UserModel } from 'src/app/core/Models/DtoModels/UserModel';
import { ManageActivityComponent } from '../../crm/components/manage-activity/manage-activity.component';
import { ClientActivityModel } from 'src/app/core/Models/EntityModels/ClientActivityModel';
import { ClientStatisticalComponent } from '../../crm/components/client-statistical/client-statistical.component';
import { MenuService } from 'src/app/core/services/Menu.Service';
import { PerformanceClientDetailModel, PerformanceClientModel } from 'src/app/core/Models/StatisticalModels/SalesClientControlModel';
import { ChooserRepresentativeComponent } from '../../shared/chooser-representative/chooser-representative.component';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { UtilService } from 'src/app/core/services/util.service';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';
@Component({
  selector: 'app-my-plan',
  templateUrl: './my-plan.component.html',
  styleUrls: ['./my-plan.component.scss']
})
export class MyPlanComponent implements OnInit {

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
    fromDate: this._UtilService.FirstOFMonth(new Date()),
    toDate: new Date(),
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
  MANAGE_CALL='';
  CLIENT_STC='';
  NEW_ORDER=''
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
    private _user:UserService,
    private _MenuService:MenuService,
    private _UtilService:UtilService,
    private _commonCrudService : CommonCrudService,
    ) {
    this.current = _user.Current();
    this._translationLoaderService.loadTranslations(english, arabic);
    

    this.searchModel.clientId = 0;


    this.searchModel.representativeId=this.current.representativeId;
    this.searchModel.branchId=this.current.branchId;


  }
  hideSTC() {
    this.showSTC = !this.showSTC;
  }
  ngOnInit(): void {

    this._translateService.get('Choose Client').subscribe((res) => { this.CHOOSE_CLIENT = res });
    this._translateService.get('New Order').subscribe((res) => { this.NEW_ORDER = res });
    this._translateService.get('New Call').subscribe((res) => { this.NEW_ORDER = res });
    this._translateService.get('Client Statisticals').subscribe((res) => { this.CLIENT_STC = res });

    this.menuItems = [
      {
        label: 'New Order',
        icon: 'pi pi-fw pi-plus',
        command: (e) => this.manage('new')
      },
      {
        label: 'New Call',
        icon: 'pi pi-fw pi-phone',
        command: (e) => this.manage('call')
      },
      {
        label: 'Client Statistics',
        icon: 'pi pi-fw pi-chart-bar',
        command: (e) => this.manage('stc')
      },
    ];


    this.refreshMenu();

    this.reload();

  }
  refreshMenu(){
    this.menuItems[0].visible=false;
    this.menuItems[1].visible=false;
    this.menuItems[2].visible=false;
    if(this.selected!=null && this.selected.clientId>0){
      this.menuItems[0].visible=true;
      this.menuItems[1].visible=true;
      this.menuItems[2].visible=true;
    }

  }

  async reload() {
    if(this.searchModel.representativeId==undefined || this.searchModel.representativeId==0){
      return;
    }

    this.isLoading = true;
    this._commonCrudService.post("SalesControl/client", this.searchModel, PerformanceClientModel).then(res => {
      this.model = res;
      this.isLoading = false;
      this.selected=null;
      this.refreshMenu();

    })
  }

  async clearFilter(){
    await this.reload();
  }
  async advancedFilter(){
    await this.reload();
  }

  async onSelectionChange(event) {
    this.refreshMenu();
  }

  async manage(operation){

    console.log(this.selected)
    
    if(operation=='new'){
      if(this.selected && this.selected.clientId>0){
        var ref = this.dialogService.open(ManageSalesOrderComponent, {
          data:{clientId:this.selected.clientId},
          header: this.NEW_ORDER,
          modal: true,
          width: '95%',
          height: '95vh',
        });
    
        ref.onClose.subscribe((model: SalesOrderModel) => {
          this.reload();
        });
      }

    }
    
    if(operation=='call'){
      var ref = this.dialogService.open(ManageActivityComponent, {
        data:{clientId:this.selected.clientId},
        header: this.MANAGE_CALL,
        width: '400px',
        contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
        baseZIndex: 10000
      });

      ref.onClose.subscribe((model: ClientActivityModel) => {
        if (model) {
          this.reload()
        }
      });
    }
    
    if(operation=='stc'){
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

    if(operation=='share'){
      const node = document.getElementById('allpage');
      saveAsPng(node);
    }
    if(operation=='export'){
      this.isLoading=true;
      await (this._commonCrudService.postFile("SalesControl/clientExport", this.searchModel)).subscribe((data:any)=> {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "MyPlan_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);

       
        this.isLoading=false;
      })
    }
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
      await (this._commonCrudService.postFile("SalesControl/clientExport", this.searchModel)).subscribe((data:any)=> {

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

  choose_Rep() {
    var ref = this.dialogService.open(ChooserRepresentativeComponent, {
      header: this.CHOOSE_CLIENT,
      width: '90%',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((res: RepresentativeListModel) => {
      if (res) {



        this.searchModel.representativeCode = res.representativeCode;
        this.searchModel.representativeId = res.representativeId;

      }
    });
  }


}
