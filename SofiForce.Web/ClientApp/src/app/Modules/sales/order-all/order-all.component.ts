import { Component, Input, OnInit } from '@angular/core';
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
import { CommonCrudService } from '../../../core/services/CommonCrud.service';


@Component({
  selector: 'app-order-all',
  templateUrl: './order-all.component.html',
  styleUrls: ['./order-all.component.scss']
})
export class OrderAllComponent implements OnInit {


  orderModel: SalesOrderModel = {
    customDiscountTotal: 0,
    itemDiscountTotal: 0,
    taxTotal: 0,
    netTotal: 0,
    cashDiscountTotal: 0,
    itemTotal: 0,
    salesDate: this._UtilService.LocalDate(new Date()),
  } as SalesOrderModel;

  model: ResponseModel<SalesOrderListModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: []
  };


  isLoading = false;
  first = 0;
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

  searchModel: SalesOrderSearchModel = {
    salesCode: '',
    clientCode: '',
    branchId: 0,
    branchCode: undefined,
    representativeId: 0,
    representativeCode: undefined,
    storeId: 0,
    storeCode: undefined,
    priorityTypeId: 0,
    salesDate: undefined,
    salesOrderStatusId: 0,
    salesOrderTypeId: 1,
    salesOrderSourceId: [1,2],
    invoiceDate: undefined,
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    filterMode: 0,
    clientId: 0,
    isInvoiced: 0,
    TermBy:"",
    cashDiscountOnly:false,

  }
  menu: MenuItem[];
  selected: SalesOrderListModel;

  Payments: LookupModel[] = [];
  Priorites: LookupModel[] = [];
  Status: LookupModel[] = [];
  Types: LookupModel[] = [];
  Sources: LookupModel[] = [];

  searchBy: LookupModel[] = [
    {id:1,code:'representativeCode',name:'SalesMan'},
    {id:2,code:'clientCode',name:'Client Code'},
    {id:3,code:'branchCode',name:'Branch Code'},
    {id:4,code:'storeCode',name:'Store Code'},
    {id:5,code:'invoiceCode',name:'Invoice Code'},
    {id:6,code:'salesCode',name:'Order Code'},
  ];

  constructor(
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
    private _commonCrudService : CommonCrudService,


    private _MenuService: MenuService,
  ) {

    this._translationLoaderService.loadTranslations(english, arabic);

    this._translateService.get('Choose Branch').subscribe((res) => { this.CHOOSE_BRANCH = res });
    this._translateService.get('Choose Supervisor').subscribe((res) => { this.CHOOSE_SUPERVISOR = res });
    this._translateService.get('Choose Sales Man').subscribe((res) => { this.CHOOSE_REPRESENTITIVE = res });
    this._translateService.get('Choose Client').subscribe((res) => { this.CHOOSE_CLIENT = res });
    this._translateService.get('Order Log').subscribe((res) => { this.HEADER_LOG = res });
    this._translateService.get('Client Statisticals').subscribe((res) => { this.HEADER_STC = res });


    var found=localStorage.getItem("order-all.component.termBy")
    if(found){
      console.log(found);
      this.searchModel.TermBy=found;
    }
  }


  OnTermChange(arg){
    localStorage.setItem("order-all.component.termBy",arg.value);
  }

  ngOnInit(): void {



    this._translateService.get('Manage Order').subscribe((res) => { this.HEADER_MANAGE = res });
    this._translateService.get('Order Errors Details').subscribe((res) => { this.HEADER_ERRORS = res });
    this._translateService.get('Order Workflow Details').subscribe((res) => { this.HEADER_WORKFLOW = res });





    this.menu = [

      {
        label: 'Manage Order',
        icon: 'pi pi-fw pi-pencil',
        command: (e) => this.manage('edit')
      },
      {
        label: 'Delete',
        icon: 'pi pi-fw pi-times',
        command: (e) => this.manage('delete')
      },
      {
        label: 'Re-open',
        icon: 'fa fa-repeat',
        command: (e) => this.manage('reopen')
      },
      {
        label: 'Copy',
        icon: 'fa fa-clone',
        command: (e) => this.manage('copy')
      },
      {
        separator: true,
      },
      {
        label: 'Client Statisticals',
        icon: 'fa fa-bar-chart',
        command: (e) => this.manage('stc')
      },
    ];




    this._commonCrudService.get("PaymentTerm/GetAll", LookupModel).then(res => {
      this.Payments = res.data;
      this.Payments.unshift({ id: 0, code: '0', name: '--' });
    })

    this._commonCrudService.get("SalesOrderStatus/GetAll", LookupModel).then(res => {
      this.Status = res.data;
      this.Status.unshift({ id: 0, code: '0', name: '--' });

    })

    this._commonCrudService.get("Priority/GetAll", LookupModel).then(res => {
      this.Priorites = res.data;
      this.Priorites.unshift({ id: 0, code: '0', name: '--' });

    })

    this._commonCrudService.get("SalesOrderType/GetAll", LookupModel).then(res => {
      this.Types = res.data;
      this.Types.unshift({ id: 0, code: '0', name: '--' });
    })
    this._commonCrudService.get("SalesOrderSource/GetAll", LookupModel).then(res => {
      this.Sources = res.data;
    })

    

  }


  async filter(event) {


    this.isLoading = true;
    this.searchModel.Skip = event.first;
    this.searchModel.Take = event.rows;


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

    await this._commonCrudService.post("SalesOrder/filter", this.searchModel, SalesOrderListModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._commonCrudService.post("SalesOrder/filter", this.searchModel, SalesOrderListModel).then(res => {
        this.model = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {

    this.isLoading = true;
    await this._commonCrudService.post("SalesOrder/filter", this.searchModel, SalesOrderListModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    await this._commonCrudService.post("SalesOrder/filter", this.searchModel, SalesOrderListModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })
  }
  async clearFilter() {
    this.first = 0;
    this.isLoading = true;
    this.searchModel = {
      salesCode: '',
      clientCode: '',
      branchId: 0,
      branchCode: undefined,
      representativeId: 0,
      representativeCode: undefined,
      storeId: 0,
      storeCode: undefined,
      priorityTypeId: 0,
      salesDate: undefined,
      salesOrderStatusId: 0,
      salesOrderTypeId: 1,
      salesOrderSourceId: [0],
      invoiceDate: undefined,
      Take: 30,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: undefined,
      filterMode: 0,
      clientId: 0,
      isInvoiced: 0,
    TermBy:"",
    cashDiscountOnly:false

    }
    await this._commonCrudService.post("SalesOrder/filter", this.searchModel, SalesOrderListModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })

  }

  async manage(mode) {


    if (mode == "new") {
      var ref = this.dialogService.open(ManageSalesOrderComponent, {
        header: this.HEADER_MANAGE,
        width: '95%',
        height: '95vh',
      });

      ref.onClose.subscribe(() => {

        this.reloadFilter();

      });
    }

    if (mode == "edit") {
      if (this.selected && this.selected.salesId > 0) {
        var ref = this.dialogService.open(ManageSalesOrderComponent, {
          header: this.HEADER_MANAGE,
          data: {
            salesId: this.selected.salesId,
            mode: mode,
          },
          width: '95%',
          height: '95vh',
        });

        ref.onClose.subscribe(() => {

          this.reloadFilter();

        });
      }
    }





    if (mode == 'delete') {

      if (this.selected != null && this.selected.salesId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {


            this.isLoading = true;
            let model = {} as SalesOrderModel;
            model.salesId = this.selected.salesId;
            this._commonCrudService.post("SalesOrder/delete", model, SalesOrderModel).then(res => {
              this.advancedFilter();
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

    if (mode == 'copy') {

      if (this.selected != null && this.selected.salesId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {


            this.isLoading = true;
            let model = {} as SalesOrderModel;
            model.salesId = this.selected.salesId;
            this._commonCrudService.post("SalesOrder/copy", model, SalesOrderModel).then(res => {
              this.advancedFilter();
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

    if (mode == "reopen") {
      if (this.selected != null && this.selected.salesId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {


            this.isLoading = true;
            let model = {} as SalesOrderModel;
            model.salesId = this.selected.salesId;
            this._commonCrudService.post("SalesOrder/Open", model, SalesOrderModel).then(res => {
              this.advancedFilter();
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


    if (mode == "stc") {
      if (this.selected != null && this.selected.clientId > 0) {
        var ref = this.dialogService.open(ClientStatisticalComponent, {
          header: this.HEADER_STC,
          data: {
            clientId: this.selected.clientId
          },
          width: '95%',
          contentStyle: { "max-height": "100%", "height": "100%", "overflow": "auto" },
          baseZIndex: 10000
        });
      }
    }
  }

  async onSelectionChange(event) {
    this.selected = event;

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

  clear_Client() {
    this.searchModel.clientCode = '';
    this.searchModel.clientId = 0;
  }


  choose_Store() {
    var ref = this.dialogService.open(ChooserStoreComponent, {
      header: this.CHOOSE_CLIENT,
      width: '1100px',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((store: StoreListModel) => {
      if (store) {


        this.searchModel.storeCode = store.storeCode;
        this.searchModel.storeId = store.storeId;

      }
    });
  }

  clear_Store() {
    this.searchModel.storeCode = '';
    this.searchModel.storeId = 0;
  }

  FixedNumer(num: number) {
    if (!num) return 0;

    return Number(num.toFixed(3));
  }

  async saveOption() {

    console.log(this.orderModel.promotionOptions);
    this.orderModel.promotionOptions.forEach(element => {
      if (element.selected == true) {
        element.batchs.forEach(element => {
          this.orderModel.salesOrderDetails.push(element)
        });
      }
    });


    // Save Order
    await this._commonCrudService.post("SalesOrder/saveItems", this.orderModel, SalesOrderModel).then(res => {
      if (res.succeeded == true) {
        this.orderModel = res.data;
      }
      else {
        this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
        return;
      }
    });

    // Approve Order
    if (this.orderModel.hasError == false) {
      await this._commonCrudService.post("SalesOrder/approve", this.orderModel, SalesOrderModel).then(res => {
        if (res.succeeded == true) {
          this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });
        }
        else {
          if (this.orderModel.errors.length > 0) {
            //show errors

          }
          else {
            this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
          }
        }
      })
    }
    else {
      this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
    }

    this.advancedFilter();
    this.showOption = false;
  }
  selectOption(event, model) {
    console.log(event.target.value);

    const result = this.orderModel.promotionOptions.filter((obj) => {
      return obj.promotionId === model.promotionId;
    });

    result.forEach(element => {
      if (element.rowId == event.target.value) {
        element.selected = true;
      }
      else {
        element.selected = false;
      }
    });
  }
}
