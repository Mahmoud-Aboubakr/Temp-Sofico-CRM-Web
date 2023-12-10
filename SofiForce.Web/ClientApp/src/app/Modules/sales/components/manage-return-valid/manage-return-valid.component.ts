import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MenuItem, MessageService, PrimeNGConfig } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { SalesOrderModel } from 'src/app/core/Models/EntityModels/salesOrderModel';
import { RepresentativeService } from 'src/app/core/services/Representative.Service';
import { SalesOrderStatusService } from 'src/app/core/services/SalesOrderStatus.Service';
import { SalesOrderSourceService } from 'src/app/core/services/SalesOrderSource.Service';
import { PriorityService } from 'src/app/core/services/Priority.Service';
import { PaymentTermService } from 'src/app/core/services/PaymentTerm.Service';
import { BranchService } from 'src/app/core/services/Branch.Service';
import { StoreService } from 'src/app/core/services/Store.Service';
import { ItemStoreService } from 'src/app/core/services/ItemStore.Service';
import { SalesOrderDetailModel } from 'src/app/core/Models/EntityModels/salesOrderDetailModel';
import { BranchSearchModel } from 'src/app/core/Models/SearchModels/BranchSearchModel';
import { RepresentativeSearchModel } from 'src/app/core/Models/SearchModels/RepresentativeSearchModel';
import { StoreSearchModel } from 'src/app/core/Models/SearchModels/StoreSearchModel';
import { ChooserStoreComponent } from 'src/app/Modules/shared/chooser-store/chooser-store.component';
import { ChooserRepresentativeComponent } from 'src/app/Modules/shared/chooser-representative/chooser-representative.component';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { StoreListModel } from 'src/app/core/Models/ListModels/StoreListModel';
import { ItemStoreSearchModel } from 'src/app/core/Models/SearchModels/ItemStoreSearchModel';
import { UserService } from 'src/app/core/services/User.Service';
import { ClientService } from 'src/app/core/services/Client.Service';
import { SalesOrderDetailListModel } from 'src/app/core/Models/ListModels/SalesOrderDetailListModel';
import { CustomDiscountTypeService } from 'src/app/core/services/CustomDiscountType.Service';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { UtilService } from 'src/app/core/services/util.service';
import { ItemPromotionService } from 'src/app/core/services/ItemPromotion.Service';
import { ManagePromotionComponent } from '../manage-promotion/manage-promotion.component';
import { AlertService } from 'src/app/core/services/Alert.Service';
import { ReturnOrderService } from 'src/app/core/services/ReturnOrder.Service';
import { ChooserInvoiceComponent } from 'src/app/Modules/shared/chooser-invoice/chooser-invoice.component';
import { SalesOrderListModel } from 'src/app/core/Models/ListModels/SalesOrderListModel';
import { BooleanService } from 'src/app/core/services/Boolean.Service';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';
import { StoreModel } from '../../../../core/Models/EntityModels/storeModel';
import { ClientModel } from '../../../../core/Models/EntityModels/clientModel';
import { RepresentativeModel } from '../../../../core/Models/EntityModels/representativeModel';
import { BranchModel } from '../../../../core/Models/EntityModels/branchModel';


@Component({
  selector: 'app-manage-return-valid',
  templateUrl: './manage-return-valid.component.html',
  styleUrls: ['./manage-return-valid.component.scss']
})
export class ManageReturnValidComponent implements OnInit {

  isPromotionCalculated = false;
  isLoading = false;
  showError = false;
  showOption = false;
  isLoadingGrid = false;



  Payments: LookupModel[] = [];
  Priorites: LookupModel[] = [];
  Status: LookupModel[] = [];
  Sources: LookupModel[] = [];

  discountType: LookupModel[] = [];

  returnTypes: LookupModel[] = [];
  returnReasons: LookupModel[] = [];

  xx = '';
  returnTypeId=1;
  model: SalesOrderModel = {
    customDiscountTotal: 0,
    itemDiscountTotal: 0,
    taxTotal: 0,
    netTotal: 0,
    cashDiscountTotal: 0,
    itemTotal: 0,
    salesDate: this._UtilService.LocalDate(new Date()),
  } as SalesOrderModel;

  selected: SalesOrderDetailModel;

  branchSearchModel: BranchSearchModel = {
    Take: 20,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    TermBy: ""
  }
  storeSearchModel: StoreSearchModel = {
    Take: 20,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    branchId: 0,
    branchCode: '',
    storeTypeId: 0,
    isActive: 1,
    isOrder: 1,
    storeMode: 1,
    TermBy: ""
  }


  itemStoreSearchModel: ItemStoreSearchModel = {
    vendorId: 0,
    itemId: 0,
    branchId: 0,
    storeId: 0,
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    expireDate: new Date(),
    isActive: 1,
    available: 1,
    TermBy: ""

  }


  representitiveSearchModel: RepresentativeSearchModel = {
    supervisorId: 0,
    supervisorCode: '',
    branchId: 0,
    branchCode: '',
    representativeName: '',
    terminationDate: undefined,
    joinDate: undefined,
    phone: '',
    kindId: 0,
    kindIds: '1,2',
    isActive: 1,
    isTerminated: 2,
    terminationReasonId: 0,
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    searchMode: 1,
    businessUnitId: 0,
    companyCode: '',
    TermBy: ""

  }

  SaveMode = 'n';
  showDiscount = false;
  CHOOSE = '';
  menu: MenuItem[];

  invoiceCode
  constructor(
    private ref: DynamicDialogRef,
    private _auth: UserService,
    private primengConfig: PrimeNGConfig,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private _SalesOrderSourceService: SalesOrderSourceService,
    private _SalesOrderStatusService: SalesOrderStatusService,
    private _ReturnOrderService: ReturnOrderService,
    private _BranchService: BranchService,
    private _StoreService: StoreService,
    private _PriorityService: PriorityService,
    private _ItemStoreService: ItemStoreService,
    private _RepresentativeService: RepresentativeService,
    private confirmationService: ConfirmationService,
    private _PaymentTermService: PaymentTermService,
    private _ClientService: ClientService,
    private _CustomDiscountTypeService: CustomDiscountTypeService,
    private _AppMessageService: AppMessageService,
    private config: DynamicDialogConfig,
    private _UtilService: UtilService,
    private _ItemPromotionService: ItemPromotionService,
    private _BooleanService: BooleanService,
    private messageService: MessageService,
    private _commonCrudService : CommonCrudService,
    ) {
    this._translationLoaderService.loadTranslations(english, arabic);
    this.clear();
    this.model.salesId = 0;


    console.log(this.config.data);


    if (this.config.data) {

      if (+this.config.data.salesId > 0) {
        this.model.salesId = +this.config.data.salesId
      }

      if (+this.config.data.clientId > 0) {
        this.model.clientId = +this.config.data.clientId
      }

      if (this.config.data.mode) {
        this.SaveMode = this.config.data.mode
      }
      if (this.config.data.showDiscount) {
        this.showDiscount = this.config.data.showDiscount
      }
    }


    this.returnTypes.push({id:1,code:'1',name:'All Order'});
    this.returnTypes.push({id:2,code:'2',name:'Items'});



  }
  clear() {

    this.model.netTotal = 0;
    this.model.deliveryTotal = 0;
    this.model.itemDiscountTotal = 0;
    this.model.customDiscountTotal = 0;
    this.model.customDiscountValue = 0;
    this.model.cashDiscountTotal = 0;
    this.model.taxTotal = 0;
    this.model.itemTotal = 0;
    this.model.salesOrderDetails = [];
    this.model.errors = [];
    this.model.warnings = [];

  }
  ReturnAll() {

    if (this.model.salesOrderDetails && this.model.salesOrderDetails.length > 0) {
      this.model.salesOrderDetails.forEach(element => {
        element.returnQuantity = element.quantity - element.totalReturn;
        element.lineValue = Number((element.returnQuantity * element.clientPrice).toFixed(3));

      });

      this.calcTotals();
    }
  }

  ngOnInit(): void {

    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });



    this.init();
  }
  async init() {

    this.model.salesOrderStatusId = 1;
    this.model.salesOrderSourceId = 1;
    this.model.salesTime = this._UtilService.LocalDate(new Date());

    this.isLoading = true;
    this._commonCrudService.get("PaymentTerm/GetAll", LookupModel).then(res => {
      this.Payments = res.data;
    })

    this._commonCrudService.get("SalesOrderSource/GetAll", LookupModel).then(res => {
      this.Sources = res.data;
    })

    this._commonCrudService.get("SalesOrderStatus/GetAll", LookupModel).then(res => {
      this.Status = res.data.filter(a => a.id < 5);
    })

    this._commonCrudService.get("Priority/GetAll", LookupModel).then(res => {
      this.Priorites = res.data;
    })

    this._commonCrudService.get("CustomDiscountType/GetAll", LookupModel).then(res => {
      this.discountType = res.data;
    })


    let current = this._auth.Current();

    if (current != null && current != undefined) {
      if (current.branchId > 0) {
        await this._BranchService.GetByid(current.branchId).then(res => {
          if (res.succeeded == true) {
            this.model.branchId = res.data.branchId;
            this.model.branchCode = res.data.branchCode;
            this.model.branchName = res.data.branchNameEn;

            this.storeSearchModel.branchId = res.data.branchId;
            this.representitiveSearchModel.branchId = res.data.branchId;
          }

        })
      }

      if (current.representativeId > 0) {
        this._commonCrudService.get("Representative/getById?Id="+current.representativeId, RepresentativeModel).then(res => {
          if (res.succeeded == true) {
            this.model.representativeId = res.data.representativeId;
            this.model.representativeCode = res.data.representativeCode;
            this.model.representativeName = res.data.representativeNameEn;
          }

        })
      }

      if (current.storeId > 0) {
        this._commonCrudService.get("Store/getById?Id="+current.storeId, StoreModel).then(res => {
          if (res.succeeded == true) {
            this.model.storeId = res.data.storeId;
            this.model.storeCode = res.data.storeCode;
            this.model.storeName = res.data.storeNameEn;

          }

        })
      }

    }




    if (this.model.salesId > 0) {
      await this._commonCrudService.get("ReturnOrder/getById?Id="+this.model.salesId, SalesOrderModel).then(res => {
        if (res.succeeded == true) {

          this.model = res.data;
          this.model.salesTime = new Date(res.data.salesTime)

          if (this.model.branchId > 0) {
            this._commonCrudService.get("Branch/GetByid?Id="+this.model.branchId, BranchModel).then(res => {
              this.model.branchCode = res.data.branchCode;
              this.model.branchName = res.data.branchNameEn;

            })
          }
          if (this.model.storeId > 0) {
            this._commonCrudService.get("Store/getById?Id="+this.model.storeId, StoreModel).then(res => {
              this.model.storeCode = res.data.storeCode;
              this.model.storeName = res.data.storeNameEn;

            })
          }
          if (this.model.clientId > 0) {
            this._commonCrudService.get("Client/getById?Id="+this.model.clientId, ClientModel).then(res => {
              this.model.clientCode = res.data.clientCode;
              this.model.clientName = res.data.clientNameEn;

            })
          }
          if (this.model.representativeId > 0) {
            this._commonCrudService.get("Representative/getById?Id="+this.model.representativeId, RepresentativeModel).then(res => {
              this.model.representativeCode = res.data.representativeCode;
              this.model.representativeName = res.data.representativeNameEn;

            })
          }

          if (this.SaveMode == 'c') {

            this.model.salesId = 0;
            this.model.clientId = 0;
            this.model.clientCode = '';
            this.model.clientName = '';

          }
        }
        else {
          this.ref.close();
        }
      })
    }


    if (this.model.clientId > 0) {
      this._commonCrudService.get("Client/getById?Id="+this.model.clientId, ClientModel).then(res => {
        this.model.clientId = res.data.clientId;
        this.model.clientCode = res.data.clientCode;
        this.model.clientName = res.data.clientNameEn;

      })
    }

    this.isLoading = false;
  }
  choose_representitive() {

    if (this.model.branchId == undefined || this.model.branchId == null || this.model.branchId == 0) {
      return;
    }

    this.representitiveSearchModel.branchId = this.model.branchId;


    var ref = this.dialogService.open(ChooserRepresentativeComponent, {
      header: this.CHOOSE,
      data: { searchModel: this.representitiveSearchModel },
      width: '1200px',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((rep: RepresentativeListModel) => {
      if (rep) {
        this.model.representativeCode = rep.representativeCode;
        this.model.representativeName = rep.representativeName;

        this.model.representativeId = rep.representativeId;
      }
    });
  }
  choose_Store() {

    if (this.model.branchId == undefined || this.model.branchId == null || this.model.branchId == 0) {
      return;
    }

    let searchModel = {} as StoreSearchModel;

    searchModel.Skip = 0;
    searchModel.Take = 30;
    searchModel.branchId = this.model.branchId;
    searchModel.isActive = 1;
    searchModel.isOrder = 1;
    searchModel.storeMode = 1;

    var ref = this.dialogService.open(ChooserStoreComponent, {
      header: this.CHOOSE,
      data: { searchModel: searchModel },
      width: '1000px',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((store: StoreListModel) => {
      if (store) {

        this.model.storeCode = store.storeCode;
        this.model.storeName = store.storeName;

        this.model.storeId = store.storeId;
        this.model.branchId = store.branchId;

        this.model.representativeId = 0;
        this.model.representativeCode = '';
        this.model.representativeName = '';

      }
    });
  }

  calcTotals() {

    if (this.model.salesOrderDetails.length > 0) {

      this.model.itemTotal = Number((this.model.salesOrderDetails.filter(item => item.itemId > 0).reduce((sum, current) => sum + (current.returnQuantity * current.clientPrice), 0)).toFixed(3))
      this.model.taxTotal = Number((this.model.salesOrderDetails.filter(item => item.taxValue > 0).reduce((sum, current) => sum + current.taxValue * current.returnQuantity, 0)).toFixed(3));
      this.model.itemDiscountTotal = Number((this.model.salesOrderDetails.filter(item => item.itemId > 0).reduce((sum, current) => sum + (current.returnQuantity * current.discount), 0)).toFixed(3))

      if (this.model.customDiscountTotal > 0)
        this.model.customDiscountTotal = Number((this.model.customDiscountTotal).toFixed(3))
      else
        this.model.customDiscountTotal = 0;

      if (this.model.itemDiscountTotal > 0)
        this.model.itemDiscountTotal = Number((this.model.itemDiscountTotal).toFixed(3))
      else
        this.model.itemDiscountTotal = 0;

      if (this.model.cashDiscountTotal > 0)
        this.model.cashDiscountTotal = Number((this.model.cashDiscountTotal).toFixed(3))
      else
        this.model.cashDiscountTotal = 0;

      this.model.netTotal = Number((this.model.itemTotal + this.model.taxTotal - this.model.itemDiscountTotal - this.model.customDiscountTotal).toFixed(3))
    }
    else {
      this.model.taxTotal = 0;
      this.model.itemTotal = 0;
      this.model.itemDiscountTotal = 0;
      this.model.cashDiscountTotal = 0;
      this.model.customDiscountTotal = 0;
      this.model.netTotal = 0;
      this.model.customDiscountValue = 0;
    }

    this.isPromotionCalculated = false;

  }

  onQuantityChange(arg, line: SalesOrderDetailListModel) {
    if (arg.value) {
      if (arg.value <= (line.quantity - line.totalReturn)) {
        line.lineValue = Number((arg.value * line.clientPrice).toFixed(3));
      }
      else {
        line.lineValue = Number(((line.quantity - line.totalReturn) * line.clientPrice).toFixed(3));
      }
    }
    this.calcTotals();
  }



  onKeyDown(arg, line: SalesOrderDetailModel) {
    if (arg.keyCode == 13){
    this.isPromotionCalculated=false;
      this.calcTotals();
    }
    
  }

  updateDiscount() {

    if (this.model.customDiscountTypeId == 1) {
      if (this.model.customDiscountValue <= this.model.itemTotal) {
        this.model.customDiscountTotal = this.model.customDiscountValue;
      }
      else {
        this.model.customDiscountValue = 0;
        this.model.customDiscountTotal = 0;
      }
    }
    else if (this.model.customDiscountTypeId == 2) {
      if (this.model.customDiscountValue <= 100) {
        this.model.customDiscountTotal = (this.model.itemTotal * this.model.customDiscountValue / 100);
      }
      else {
        this.model.customDiscountValue = 0;
        this.model.customDiscountTotal = 0;
      }
    }

    this.calcTotals();
  }



  showErrors() {
    this.showError = true;
  }

  FixedNumer(num: number) {
    if (!num) return 0;

    return Number(num.toFixed(3));
  }



  async choose_Invoice() {
    var ref = this.dialogService.open(ChooserInvoiceComponent, {
      header: this.CHOOSE,
      width: '90%',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((order: SalesOrderListModel) => {
      if (order) {
        this.invoiceCode = order.invoiceCode;

        this.isLoading=true;
        this.isPromotionCalculated = true;
        this._commonCrudService.get("ReturnOrder/getByCode?InvoiceCode="+order.invoiceCode,SalesOrderModel).then(res=>{

          if(res.succeeded==true){
            this.model.clientId=res.data.clientId;
            this.model.branchId=res.data.branchId;
            this.model.cashDiscountTotal=res.data.cashDiscountTotal;
            this.model.salesOrderDetails=res.data.salesOrderDetails;
          }
          this.isLoading=false;

        })

      }
    });
  }
  async Promotion() {


    let valid = true;

    if (this.model.clientId == 0) {
      valid = false;

    }
    if (this.model.storeId == 0) {
      valid = false;

    }
    if (this.model.branchId == 0) {
      valid = false;

    }
    if (this.model.representativeId == 0) {
      valid = false;

    }

    if (this.model.salesOrderSourceId == 0) {
      valid = false;

    }
    if (this.model.salesOrderStatusId == 0) {
      valid = false;

    }
    if (this.model.paymentTermId == 0) {
      valid = false;

    }
    if (this.model.salesOrderTypeId == 0) {
      valid = false;

    }


    let invalidbatch = this.model.salesOrderDetails.find(a => a.itemStoreId == 0);
    if (invalidbatch) {
      valid = false;
    }

    if (valid == false) {
      //this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });
      return;
    }

    this.isLoading = true;
    this.model.errors = [];
    this.model.warnings = [];
    this.model.promotionOptions = [];



    await this._commonCrudService.post("ReturnOrder/promotion",this.model,SalesOrderModel).then((res) => {
      if (res.succeeded == true) {
        this.model = res.data;
        if (res.data.promotionOptions.length > 0) {
          this.showOption = true;
        }
        this.isPromotionCalculated = true;
      }
      else {
        this.messageService.add({ severity: 'error', detail: res.message });
      }
    });

    this.isLoading = false;
  }

  async confirm() {
    if (this.model != null && this.model.salesId > 0) {
      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {

          this.isLoading = true;
          let orderModel = {} as SalesOrderModel;
          orderModel.salesId = this.model.salesId;
          // Approve Order
          await this._commonCrudService.post("ReturnOrder/approve",orderModel,SalesOrderModel).then(res => {
            if (res.succeeded == true) {
              this.ref.close();
              this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });
            }
            else {
              this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
            }
          })
          this.isLoading = false;
        },
        reject: () => {
          //reject action
        }
      });
    }
  }
}
