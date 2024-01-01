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
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { SalesOrderModel } from 'src/app/core/Models/EntityModels/salesOrderModel';
import { ManageSalesOrderComponent } from '../components/manage-sales-order/manage-sales-order.component';
import { ManageSalesOrderWorkflowComponent } from '../components/manage-sales-order-workflow/manage-sales-order-workflow.component';
import { ChooserRepresentativeComponent } from '../../shared/chooser-representative/chooser-representative.component';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { ChooserBranchComponent } from '../../shared/chooser-branch/chooser-branch.component';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { ChooserClientComponent } from '../../shared/chooser-client/chooser-client.component';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { ChooserStoreComponent } from '../../shared/chooser-store/chooser-store.component';
import { StoreListModel } from 'src/app/core/Models/ListModels/StoreListModel';
import { ViewSalesOrderLogComponent } from '../components/view-sales-order-log/view-sales-order-log.component';
import { UtilService } from 'src/app/core/services/util.service';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';


@Component({
  selector: 'app-sales-order-rejected',
  templateUrl: './sales-order-rejected.component.html',
  styleUrls: ['./sales-order-rejected.component.scss']
})
export class SalesOrderRejectedComponent implements OnInit {


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
    salesOrderTypeId: 0,
    salesOrderSourceId: [0],
    invoiceDate: undefined,
    isInvoiced:2,
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    filterMode: 0,
    clientId: 0,
    TermBy:"",
    cashDiscountOnly:false,

  }
  menu: MenuItem[];

  selected: SalesOrderListModel;

  Payments: LookupModel[] = [];
  Priorites: LookupModel[] = [];
  Status: LookupModel[] = [];
  Types: LookupModel[] = [];

  constructor(
    private _translationLoaderService: TranslationLoaderService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _AppMessageService: AppMessageService,
    private _UtilService: UtilService,
    private _commonCrudService : CommonCrudService
  ) {

    this._translationLoaderService.loadTranslations(english, arabic);

    this._translateService.get('Choose Branch').subscribe((res) => { this.CHOOSE_BRANCH = res });
    this._translateService.get('Choose Supervisor').subscribe((res) => { this.CHOOSE_SUPERVISOR = res });
    this._translateService.get('Choose Sales Man').subscribe((res) => { this.CHOOSE_REPRESENTITIVE = res });
    this._translateService.get('Choose Client').subscribe((res) => { this.CHOOSE_CLIENT = res });
    this._translateService.get('Order Log').subscribe((res) => { this.HEADER_LOG = res });
 
  }



  ngOnInit(): void {



    this._translateService.get('Manage Order').subscribe((res) => { this.HEADER_MANAGE = res });
    this._translateService.get('Order Errors Details').subscribe((res) => { this.HEADER_ERRORS = res });
    this._translateService.get('Order Workflow Details').subscribe((res) => { this.HEADER_WORKFLOW = res });


    this.menu = [
      {
        label: 'Manage Order',
        icon: 'pi pi-fw pi-pencil',
        command: (e) => this.manage('e')
      },
      {
        label: 'Delete',
        icon: 'pi pi-fw pi-times',
        command: (e) => this.manage('d')
      },
      {
        label: 'Duplicate',
        icon: 'pi pi-fw pi-clone',
        command: (e) => this.manage('c')
      },
      {
        label: 'Re-open',
        icon: 'fa fa-repeat',
        command: (e) => this.manage('reopen')
      },
      {
        label: 'Confim',
        icon: 'fa fa-check-circle',
        command: (e) => this.manage('confirm')
      },
      {
        label: 'Trasfer',
        icon: 'fa fa-exchange',
        command: (e) => this.manage('transfer')
      },
    ];

    this.refreshMenu(null);



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

    this.selected = null;

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
      this.selected = null;
      this.refreshMenu(null);
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
      salesOrderTypeId: 0,
      salesOrderSourceId: [0],
      invoiceDate: undefined,
      isInvoiced:2,
      Take: 30,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: undefined,
      filterMode: 0,
      clientId: 0,
    TermBy:"",
    cashDiscountOnly:false,

    }
    await this._commonCrudService.post("SalesOrder/filter", this.searchModel, SalesOrderListModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })

  }

  async manage(mode) {

   
    if (mode == "e") {
      if (this.selected && this.selected.salesId > 0) {
        var ref = this.dialogService.open(ManageSalesOrderComponent, {
          header: this.HEADER_MANAGE,
          data: {
            salesId: this.selected.salesId,
            mode: mode,
          },
          modal: true,
          width: '95%',
          height: '95vh',
        });

        ref.onClose.subscribe(() => {

          this.reloadFilter();

        });
      }
    }
   
   

    if (mode == "flow") {
      if (this.selected && this.selected.salesId > 0) {
        var ref = this.dialogService.open(ManageSalesOrderWorkflowComponent, {
          header: this.HEADER_WORKFLOW,
          data: {
            salesId: this.selected.salesId
          },
          width: '700px',
          contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
          baseZIndex: 10000
        });

        ref.onClose.subscribe(() => {

          this.reloadFilter();

        });
      }
    }


    if (mode == 'd') {

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

    if (mode == "log") {
      if (this.selected != null && this.selected.salesId > 0) {
        var ref = this.dialogService.open(ViewSalesOrderLogComponent, {
          header: this.HEADER_LOG,
          data: {
            salesId: this.selected.salesId
          },
          width: '800px',
          contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
          baseZIndex: 10000
        });
      }
    }

    if (mode == "transfer") {
      if (this.selected != null && this.selected.salesId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {


            this.isLoading = true;
            let model = {} as SalesOrderModel;
            model.salesId = this.selected.salesId;
            this._commonCrudService.post("SalesOrder/transfer", model, SalesOrderModel).then(res => {
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


  }

  async onSelectionChange(event) {
    this.selected = event;
    this.refreshMenu(this.selected);
  }
  refreshMenu(event) {

    console.log(event);


    this.isLoading = true;

    this.menu[0].disabled = true;
    this.menu[1].disabled = true;
    this.menu[2].disabled = true;
    this.menu[3].disabled = true;
    this.menu[4].disabled = true;
    this.menu[5].disabled = true;
    this.menu[6].disabled = true;
    this.menu[7].disabled = true;
    this.menu[8].disabled = true;
    this.menu[9].disabled = true;

    if (event && +event.salesId > 0) {


      //View
      this.menu[0].disabled = false;

      //Edit
      if (event.salesOrderStatusId == 1)
        this.menu[1].disabled = false;
      //Delete
      if (event.salesOrderStatusId == 1)
        this.menu[2].disabled = false;
      //Duplicate
      this.menu[3].disabled = false;
      //Errors
      this.menu[4].disabled = false;

      //WorkFlow
      if (event.salesOrderStatusId > 1)
        this.menu[5].disabled = false;
      //Log
      this.menu[6].disabled = false;
      //Re-open
      if (event.salesOrderStatusId == 2)
        this.menu[7].disabled = false;
      //Confim
      if (event.salesOrderStatusId == 1)
        this.menu[8].disabled = false;
      //Trasfer
      if (event.salesOrderStatusId == 2)
        this.menu[9].disabled = false;

    }

    this.isLoading = false;

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
}
