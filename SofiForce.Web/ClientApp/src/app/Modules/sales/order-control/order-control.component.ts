import { Component, OnInit } from '@angular/core';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { DialogService } from 'primeng/dynamicdialog';
import { TranslateService } from '@ngx-translate/core';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { SalesOrderSearchModel } from 'src/app/core/Models/SearchModels/SalesOrderSearchModel';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { SalesOrderListModel } from 'src/app/core/Models/ListModels/SalesOrderListModel';
import { SalesOrderService } from 'src/app/core/services/SalesOrder.Service';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { SalesOrderModel } from 'src/app/core/Models/EntityModels/salesOrderModel';
import { ManageSalesOrderComponent } from '../components/manage-sales-order/manage-sales-order.component';
import { ChooserRepresentativeComponent } from '../../shared/chooser-representative/chooser-representative.component';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { ChooserBranchComponent } from '../../shared/chooser-branch/chooser-branch.component';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { ChooserClientComponent } from '../../shared/chooser-client/chooser-client.component';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { ChooserStoreComponent } from '../../shared/chooser-store/chooser-store.component';
import { StoreListModel } from 'src/app/core/Models/ListModels/StoreListModel';
import { SalesOrderSourceService } from 'src/app/core/services/SalesOrderSource.Service';
import { SalesOrderStatusService } from 'src/app/core/services/SalesOrderStatus.Service';
import { PaymentTermService } from 'src/app/core/services/PaymentTerm.Service';
import { PriorityService } from 'src/app/core/services/Priority.Service';
import { SalesOrderTypeService } from 'src/app/core/services/SalesOrderType.Service';
import { UtilService } from 'src/app/core/services/util.service';
import { MenuService } from 'src/app/core/services/Menu.Service';
import { ClientStatisticalComponent } from '../../crm/components/client-statistical/client-statistical.component';
import { SalesOrderControlSearchModel } from 'src/app/core/Models/SearchModels/SalesOrderControlSearchModel';
import { SalesOrderControlService } from 'src/app/core/services/SalesOrderControl.Service';
import { ListNumberDto } from 'src/app/core/Models/DtoModels/ListNumberDto';
import { BooleanService } from 'src/app/core/services/Boolean.Service';
import { Router } from '@angular/router';
import { CommonCrudService } from 'src/app/core/services/CommonCrud.service';
@Component({
  selector: 'app-order-control',
  templateUrl: './order-control.component.html',
  styleUrls: ['./order-control.component.scss']
})
export class OrderControlComponent implements OnInit {

  modelConfirm:  ResponseModel<SalesOrderListModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: []
  };
  modelTransfer:  ResponseModel<SalesOrderListModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: []
  };
  modelCompleted:  ResponseModel<SalesOrderListModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: []
  };



  isLoadingConfirm = false;
  isLoadingTransfer = false;
  isLoadingCompleted = false;

  showFilterConfirmed = false;
  showFilterTransfered = false;
  showFilterCompleted = false;

  advanced = false;
  showOption = false;

  orderTypes: LookupModel[] = [];


  HEADER_ERRORS = '';
  HEADER_MANAGE = '';
  HEADER_WORKFLOW = '';
  HEADER_LOG = '';
  HEADER_STC = '';

  CHOOSE_BRANCH = '';
  CHOOSE_SUPERVISOR = '';
  CHOOSE_REPRESENTITIVE = '';
  CHOOSE_CLIENT = '';



  searchConfirmModel: SalesOrderControlSearchModel = {
    clientId: 0,
    salesCode: '',
    clientCode: '',
    branchId: 0,
    representativeId: 0,
    storeId: 0,
    priorityTypeId: 0,
    salesDateFrom: null,
    salesDateTo: null,
    salesOrderTypeId: 0,
    salesOrderStatusId: 2,
    rejectedOnly: 0,
    Take: 10,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    branchCode: '',
    representativeCode: '',
    storeCode: '',
    TermBy:""

  }

  searchTransferModel: SalesOrderControlSearchModel = {
    clientId: 0,
    salesCode: '',
    clientCode: '',
    branchId: 0,
    representativeId: 0,
    storeId: 0,
    priorityTypeId: 0,
    salesDateFrom: null,
    salesDateTo: null,
    salesOrderTypeId: 0,
    salesOrderStatusId: 3,
    rejectedOnly: 0,
    Take: 10,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    branchCode: '',
    representativeCode: '',
    storeCode: '',
    TermBy:""

  }

  searchCompletedModel: SalesOrderControlSearchModel = {
    clientId: 0,
    salesCode: '',
    clientCode: '',
    branchId: 0,
    representativeId: 0,
    storeId: 0,
    priorityTypeId: 0,
    salesDateFrom: this._UtilService.FirstOFMonth(new Date()),
    salesDateTo: this._UtilService.LastOFMonth(new Date()),
    salesOrderTypeId: 0,
    salesOrderStatusId: 4,
  
    rejectedOnly: 0,
    Take: 10,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    branchCode: '',
    representativeCode: '',
    storeCode: '',
    TermBy:""

  }

  selectedConfirm: SalesOrderListModel[]=[];
  selectedTransfer: SalesOrderListModel[]=[];
  selectedCompleted: SalesOrderListModel[]=[];

  firstConfirm = 0;
  firstTransfer = 0;
  firstCompleted = 0;


  Payments: LookupModel[] = [];
  Priorites: LookupModel[] = [];
  Status: LookupModel[] = [];
  Types: LookupModel[] = [];
  Errors: LookupModel[] = [];

  constructor(
    private _SalesOrderControlService: SalesOrderControlService,
    private _CommonCrudService:CommonCrudService,
    private _SalesOrderService: SalesOrderService,

    private _translationLoaderService: TranslationLoaderService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _AppMessageService: AppMessageService,
    private _PaymentTermService: PaymentTermService,
    private _SalesOrderSourceService: SalesOrderSourceService,
    private _SalesOrderStatusService: SalesOrderStatusService,
    private _SalesOrderTypeService: SalesOrderTypeService,
    private _UtilService: UtilService,
    private _PriorityService: PriorityService,
    private _MenuService: MenuService,
    private _BooleanService: BooleanService,
    private _router: Router
  ) {

    this._translationLoaderService.loadTranslations(english, arabic);

    this._translateService.get('Choose Branch').subscribe((res) => { this.CHOOSE_BRANCH = res });
    this._translateService.get('Choose Supervisor').subscribe((res) => { this.CHOOSE_SUPERVISOR = res });
    this._translateService.get('Choose Sales Man').subscribe((res) => { this.CHOOSE_REPRESENTITIVE = res });
    this._translateService.get('Choose Client').subscribe((res) => { this.CHOOSE_CLIENT = res });
    this._translateService.get('Order Log').subscribe((res) => { this.HEADER_LOG = res });
    this._translateService.get('Client Statisticals').subscribe((res) => { this.HEADER_STC = res });

  }



  ngOnInit(): void {



    this._translateService.get('Manage Order').subscribe((res) => { this.HEADER_MANAGE = res });
    this._translateService.get('Order Errors Details').subscribe((res) => { this.HEADER_ERRORS = res });
    this._translateService.get('Order Workflow Details').subscribe((res) => { this.HEADER_WORKFLOW = res });




    this._PaymentTermService.GetAll().then(res => {
      this.Payments = res.data;
      this.Payments.unshift({ id: 0, code: '0', name: '--' });
    })

    this._SalesOrderStatusService.GetAll().then(res => {
      this.Status = res.data;
      this.Status.unshift({ id: 0, code: '0', name: '--' });

    })

    this._PriorityService.GetAll().then(res => {
      this.Priorites = res.data;
      this.Priorites.unshift({ id: 0, code: '0', name: '--' });

    })

    this._SalesOrderTypeService.GetAll().then(res => {
      this.Types = res.data;
      this.Types.unshift({ id: 0, code: '0', name: '--' });
    })

    this._BooleanService.GetAll(localStorage['lan']).then(res => {
      this.Errors = res;
    })


    setInterval(() => {
      this._CommonCrudService.post("SalesOrderControl/filter",this.searchConfirmModel,SalesOrderListModel).then(res => {
        this.modelConfirm = res;
      })

      this._CommonCrudService.post("SalesOrderControl/filter",this.searchTransferModel,SalesOrderListModel).then(res => {
        this.modelTransfer = res;
      })

    }, 60 * 1000)

  }


  async filterConfirm(event) {


      this.isLoadingConfirm = true;
      this.searchConfirmModel.Skip = event.first;
      this.searchConfirmModel.Take = event.rows;
  
  
      this.searchConfirmModel.SortBy = { Order: "", Property: "" }
      if (event.sortField) {
        this.searchConfirmModel.SortBy.Property = event.sortField;
        if (event.sortOrder == 1) {
          this.searchConfirmModel.SortBy.Order = "asc";
        }
        else {
          this.searchConfirmModel.SortBy.Order = "desc";
  
        }
      }
      
      await this._CommonCrudService.post("SalesOrderControl/filter",this.searchConfirmModel,SalesOrderListModel).then(res => {
        this.modelConfirm = res;
        this.isLoadingConfirm = false;
        this.selectedConfirm=[];
      })
    
  }

  async filterTransfer(event) {
    this.isLoadingTransfer = true;
    this.searchTransferModel.Skip = event.first;
    this.searchTransferModel.Take = event.rows;


    this.searchTransferModel.SortBy = { Order: "", Property: "" }
    if (event.sortField) {
      this.searchTransferModel.SortBy.Property = event.sortField;
      if (event.sortOrder == 1) {
        this.searchTransferModel.SortBy.Order = "asc";
      }
      else {
        this.searchTransferModel.SortBy.Order = "desc";

      }
    }
    
    await this._CommonCrudService.post("SalesOrderControl/filter",this.searchTransferModel,SalesOrderListModel).then(res => {
      this.modelTransfer = res;
      this.isLoadingTransfer = false;
      this.selectedTransfer=[];
    })
  }

  async filterCompleted(event) {

    this.isLoadingCompleted = true;
    this.searchCompletedModel.Skip = event.first;
    this.searchCompletedModel.Take = event.rows;


    this.searchCompletedModel.SortBy = { Order: "", Property: "" }
    if (event.sortField) {
      this.searchCompletedModel.SortBy.Property = event.sortField;
      if (event.sortOrder == 1) {
        this.searchCompletedModel.SortBy.Order = "asc";
      }
      else {
        this.searchCompletedModel.SortBy.Order = "desc";

      }
    }
    await this._CommonCrudService.post("SalesOrderControl/filter",this.searchCompletedModel,SalesOrderListModel).then(res => {
      this.modelCompleted = res;
      this.isLoadingCompleted = false;
      this.selectedCompleted=[];
    })

  }

  async selectAllConfirm(){

    if(this.selectedConfirm.length!=this.modelConfirm.data.length){
    this.selectedConfirm=[];
      
      this.modelConfirm.data.forEach(element => {
        this.selectedConfirm.push(element);
      });
    }
    else
    {
      this.selectedConfirm=[];
    }

  }

  async selectAllTransfer(){

    if(this.selectedTransfer.length!=this.modelConfirm.data.length){
    this.selectedTransfer=[];
      
      this.modelTransfer.data.forEach(element => {
        this.selectedTransfer.push(element);
      });
    }
    else
    {
      this.selectedTransfer=[];
    }

  }

  async clearFilterConfirm() {
    this.reloadFilterConfirm();
  }
  async clearFilterTransfer() {

    this.reloadFilterTransfer();
  }
  async clearFilterComplete() {

    this.reloadFilterComplete();
  }
  async reloadFilterConfirm() {
    this.isLoadingConfirm = true;
    this._CommonCrudService.post("SalesOrderControl/filter",this.searchConfirmModel,SalesOrderListModel).then(res => {
      this.modelConfirm = res;
      this.isLoadingConfirm = false;
      this.selectedConfirm=[];

    })
  }

  async reloadFilterTransfer() {

    this.isLoadingTransfer = true;
    this._CommonCrudService.post("SalesOrderControl/filter",this.searchTransferModel,SalesOrderListModel).then(res => {
      this.modelTransfer = res;
      this.isLoadingTransfer = false;
      this.selectedTransfer=[];
    })
  }
  async reloadFilterComplete() {

    this.isLoadingCompleted = true;
    this._CommonCrudService.post("SalesOrderControl/filter",this.searchCompletedModel,SalesOrderListModel).then(res => {
      this.modelCompleted = res;
      this.isLoadingCompleted = false;
      this.selectedCompleted=[];
    })
  }
  

  reloadFilterAll(){
    this.reloadFilterConfirm();
    this.reloadFilterTransfer();
    this.reloadFilterComplete();

  }


  async onSelectionConfirmChange(event) {
    this.selectedConfirm = event;
  }
  async onSelectionTransferChange(event) {
    this.selectedTransfer = event;
  }
  async onSelectionCompletedChange(event) {
    this.selectedCompleted = event;
  }



  choose_Branch(mode) {
    
      var ref = this.dialogService.open(ChooserBranchComponent, {
        header: this.CHOOSE_BRANCH,
        width: '600px',
        modal: true,
        height: "90%"
      });
  
      ref.onClose.subscribe((branch: BranchListModel) => {
        if (branch) {
          if(mode=='confirm'){
            this.searchConfirmModel.branchCode = branch.branchCode;
            this.searchConfirmModel.branchId = branch.branchId;
            this.reloadFilterConfirm();
          }
          if(mode=='transfer'){
            this.searchTransferModel.branchCode = branch.branchCode;
            this.searchTransferModel.branchId = branch.branchId;
            this.reloadFilterTransfer();
          }
          if(mode='complete'){
            this.searchCompletedModel.branchCode = branch.branchCode;
            this.searchCompletedModel.branchId = branch.branchId;
            this.reloadFilterComplete();
          }

        }
      });
    

  }
  clear_Branch(mode) {
    if(mode=="confirm"){
      this.searchConfirmModel.branchCode = '';
      this.searchConfirmModel.branchId = 0;
      this.reloadFilterConfirm();
    }

    if(mode=='transfer'){
      this.searchTransferModel.branchCode = '';
      this.searchTransferModel.branchId = 0;
      this.reloadFilterConfirm();
    }

    if(mode='complete'){
      this.searchCompletedModel.branchCode = '';
      this.searchCompletedModel.branchId = 0;
      this.reloadFilterComplete();
    }

  }



  choose_Representative(mode) {
    
      var ref = this.dialogService.open(ChooserRepresentativeComponent, {
        header: this.CHOOSE_SUPERVISOR,
        width: '90%',
        modal: true,
        height: "90%"
      });
  
      ref.onClose.subscribe((represeentitive: RepresentativeListModel) => {
        if (represeentitive) {

          if(mode=="confirm"){
            this.searchConfirmModel.representativeCode = represeentitive.representativeCode;
            this.searchConfirmModel.representativeId = represeentitive.representativeId;
            this.reloadFilterConfirm();
    
          }

          if(mode=='transfer'){
            this.searchTransferModel.representativeCode = represeentitive.representativeCode;
            this.searchTransferModel.representativeId = represeentitive.representativeId;
            this.reloadFilterTransfer();
          }

          if(mode='complete'){
            this.searchCompletedModel.representativeCode = represeentitive.representativeCode;
            this.searchCompletedModel.representativeId = represeentitive.representativeId;
            this.reloadFilterComplete();
          }
          
  
        }
      });
    

  }

  clear_Representative(mode) {
    if(mode=="confirm"){
      this.searchConfirmModel.representativeCode = '';
      this.searchConfirmModel.representativeId = 0;
      this.reloadFilterConfirm();
    }
    if(mode=='transfer'){
      this.searchTransferModel.representativeCode = '';
      this.searchTransferModel.representativeId = 0;
      this.reloadFilterTransfer();
    }
    if(mode='complete'){
      this.searchCompletedModel.representativeCode = '';
      this.searchCompletedModel.representativeId = 0;
      this.reloadFilterComplete();
    }

  }

  choose_Client(mode) {
    
    var ref = this.dialogService.open(ChooserClientComponent, {
      header: this.CHOOSE_CLIENT,
      width: '90%',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((client: ClientListModel) => {
      if (client) {

        if(mode=="confirm"){
          this.searchConfirmModel.clientCode = client.clientCode;
          this.searchConfirmModel.clientId = client.clientId;
          this.reloadFilterConfirm();
        }
        if(mode=='transfer'){
          this.searchCompletedModel.clientCode = client.clientCode;
          this.searchCompletedModel.clientId = client.clientId;
          this.reloadFilterTransfer();
        }

        if(mode='complete'){
          this.searchCompletedModel.clientCode = client.clientCode;
          this.searchCompletedModel.clientId = client.clientId;
          this.reloadFilterComplete();
        }

      }
    });
  }

  clear_Client(mode) {
    if(mode=="confirm"){
    this.searchConfirmModel.clientCode = '';
    this.searchConfirmModel.clientId = 0;
    this.reloadFilterConfirm();
    }
    if(mode=='transfer'){
      this.searchTransferModel.clientCode = '';
      this.searchTransferModel.clientId = 0;
      this.reloadFilterTransfer();
    }
    if(mode='complete'){
      this.searchCompletedModel.clientCode = '';
      this.searchCompletedModel.clientId = 0;
      this.reloadFilterComplete();
    }
  }


  choose_Store(mode) {
    var ref = this.dialogService.open(ChooserStoreComponent, {
      header: this.CHOOSE_CLIENT,
      width: '1100px',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((store: StoreListModel) => {
      if (store) {

        if(mode=="confirm"){
          this.searchConfirmModel.storeCode = store.storeCode;
          this.searchConfirmModel.storeId = store.storeId;
          this.reloadFilterConfirm();
        }
        if(mode=='transfer'){
          this.searchTransferModel.storeCode = store.storeCode;
          this.searchTransferModel.storeId = store.storeId;
          this.reloadFilterTransfer();
        }

        if(mode='complete'){
          this.searchCompletedModel.storeCode = store.storeCode;
          this.searchCompletedModel.storeId = store.storeId;
          this.reloadFilterComplete();
        }


      }
    });
  }

  clear_Store(mode) {
    if(mode=="confirm"){
      this.searchConfirmModel.storeCode = '';
      this.searchConfirmModel.storeId = 0;
      this.reloadFilterConfirm();
    }
    if(mode=='transfer'){
      this.searchTransferModel.storeCode = '';
      this.searchTransferModel.storeId = 0;
      this.reloadFilterTransfer();
    }
    if(mode='complete'){
      this.searchCompletedModel.storeCode = '';
      this.searchCompletedModel.storeId = 0;
      this.reloadFilterComplete();
    }

  }

  FixedNumer(num: number) {
    if (!num) return 0;

    return Number(num.toFixed(3));
  }

  manageOrder(salesId){

    if(salesId>0){
      var ref = this.dialogService.open(ManageSalesOrderComponent, {
        header: this.HEADER_MANAGE,
        data: {
          salesId: salesId,
        },
        modal: true,
        width: '95%',
        height: '95vh',
      });
    }
  }
  showClientStc(clientId){
    if(clientId>0){
      var ref = this.dialogService.open(ClientStatisticalComponent, {
        header: this.HEADER_STC,
        data: {
          clientId: clientId
        },
        width: '95%',
        contentStyle: { "max-height": "100%", "height": "100%", "overflow": "auto" },
        baseZIndex: 10000
      });
    }
  }
  addToTransfer(){
    if(this.selectedConfirm.length>0){

      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {
  
          let model:ListNumberDto={
            ids:[],
          } as ListNumberDto;
    
          this.selectedConfirm.forEach(element => {
            model.ids.push(element.salesId);
          });
    
          this.isLoadingConfirm=true;
          this._SalesOrderControlService.MarkTransfer(model).then(res=>{
            this.selectedConfirm=[];
            
            this.firstConfirm=0;
            this.firstTransfer=0;
            
            this.reloadFilterConfirm();
            this.reloadFilterTransfer();

    
          })
    
        },
        reject: () => {
          //reject action
        }
      });
    }
  }

  openOrder(mode){



      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {
  
         
          let model:ListNumberDto={
            ids:[],
          } as ListNumberDto;
    

          if(mode=="confirmed"){
            this.selectedConfirm.forEach(element => {
              model.ids.push(element.salesId);
            });
          }
          else if(mode=="transfer")
          {
            this.selectedTransfer.forEach(element => {
              if(element.hasError==true){
                model.ids.push(element.salesId);
              }
            });
          }


    
          this.isLoadingConfirm=true;
          this.isLoadingTransfer=true;
          this._SalesOrderService.OpenAll(model).then(res=>{
            this.selectedConfirm=[];
            
            this.firstConfirm=0;
            this.firstTransfer=0;
            
            this.reloadFilterConfirm();
            this.reloadFilterTransfer();

    
          })
    
        },
        reject: () => {
          //reject action
        }
      });
    
  }

}
