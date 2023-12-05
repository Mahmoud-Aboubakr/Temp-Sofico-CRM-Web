import { ChangeDetectorRef, Component, Input, OnInit, ViewChild } from '@angular/core';
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
import { SalesOrderService } from 'src/app/core/services/SalesOrder.Service';
import { PriorityService } from 'src/app/core/services/Priority.Service';
import { PaymentTermService } from 'src/app/core/services/PaymentTerm.Service';
import { ChooserClientComponent } from 'src/app/Modules/shared/chooser-client/chooser-client.component';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { BranchService } from 'src/app/core/services/Branch.Service';
import { StoreService } from 'src/app/core/services/Store.Service';
import { ItemStoreService } from 'src/app/core/services/ItemStore.Service';
import { ChooserProductComponent } from 'src/app/Modules/shared/chooser-product/chooser-product.component';
import { SalesOrderDetailModel } from 'src/app/core/Models/EntityModels/salesOrderDetailModel';
import { ChooserBatchComponent } from 'src/app/Modules/shared/chooser-batch/chooser-batch.component';
import { ItemListModel } from 'src/app/core/Models/ListModels/ItemListModel';
import { ItemModel } from 'src/app/core/Models/EntityModels/itemModel';
import { ItemStoreModel } from 'src/app/core/Models/EntityModels/itemStoreModel';
import { ChooserBranchComponent } from 'src/app/Modules/shared/chooser-branch/chooser-branch.component';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
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
import { ClientSearchModel } from 'src/app/core/Models/SearchModels/ClientSearchModel';
import { ClientStatisticalComponent } from 'src/app/Modules/crm/components/client-statistical/client-statistical.component';
import { CustomDiscountTypeService } from 'src/app/core/services/CustomDiscountType.Service';
import { ViewPromotionComponent } from '../view-promotion/view-promotion.component';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { ViewStoreBalanceComponent } from '../view-store-balance/view-store-balance.component';
import { ViewClientQuotaComponent } from '../view-client-quota/view-client-quota.component';
import { UtilService } from 'src/app/core/services/util.service';
import { ItemStoreListModel } from 'src/app/core/Models/ListModels/ItemStoreListModel';
import { ErrorDialogComponent } from 'src/app/Modules/shared/dialogs/error-dialog/error-dialog.component';
import { ItemPromotionService } from 'src/app/core/services/ItemPromotion.Service';
import { ManagePromotionComponent } from '../manage-promotion/manage-promotion.component';
import { AlertService } from 'src/app/core/services/Alert.Service';
import { CityService } from 'src/app/core/services/City.Service';
import { GovernerateService } from 'src/app/core/services/Governerate.Service';
import { SalesOrderAddressModel } from 'src/app/core/Models/EntityModels/SalesOrderAddressModel';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { SalesOrderErrorListModel } from 'src/app/core/Models/ListModels/SalesOrderErrorListModel';
import { SalesOrderErrorService } from 'src/app/core/services/SalesOrderError.Service';
import { SalesOrderErrorSearchModel } from 'src/app/core/Models/SearchModels/SalesOrderErrorSearchModel';
import { SalesOrderLogListModel } from 'src/app/core/Models/ListModels/SalesOrderLogListModel';
import { SalesOrderLogService } from 'src/app/core/services/SalesOrderLog.Service';
import { SalesOrderDispatchModel } from 'src/app/core/Models/EntityModels/SalesOrderDispatchModel';
import { ClientModel } from 'src/app/core/Models/EntityModels/clientModel';
import { ClientGroupService } from 'src/app/core/services/ClientGroup.Service';
import { ClientGroupSubService } from 'src/app/core/services/ClientGroupSub.Service';
import { SalesOrderMessagesListModel } from 'src/app/core/Models/ListModels/SalesOrderMessagesListModel';
import { SalesOrderMessageService } from 'src/app/core/services/SalesOrderMessage.Service';
import { UserModel } from 'src/app/core/Models/DtoModels/UserModel';
import { SalesOrderMessagesModel } from 'src/app/core/Models/EntityModels/SalesOrderMessagesModel';
import { ChooserPromotionComponent } from 'src/app/Modules/shared/chooser-promotion/chooser-promotion.component';


declare var google: any;

@Component({
  selector: 'app-manage-sales-order',
  templateUrl: './manage-sales-order.component.html',
  styleUrls: ['./manage-sales-order.component.scss']
})
export class ManageSalesOrderComponent implements OnInit {

  isLoading = false;
  showError = false;
  showOption = false;
  isLoadingGrid = false;
  isPromotionCalculated = false;
  DUPLICATE_PRODUCT = '';
  CHOOSE = '';
  NO_BATCH_FOUND = '';
  BAD_BUYER = '';
  PROMOTION_DETAILS = '';
  STORE_DETAILS = '';
  CLIENT_QUOTA_DETAILS = '';
  CLIENT_STC = '';

  Payments: LookupModel[] = [];
  Priorites: LookupModel[] = [];
  OrderStatus: LookupModel[] = [];
  DispatchStatus: LookupModel[] = [];

  Sources: LookupModel[] = [];
  Governerates: LookupModel[] = [];
  Cities: LookupModel[] = [];
  discountType: LookupModel[] = [];
  feedBacks: LookupModel[] = [];
  ClientGroups: LookupModel[] = [];
  ClientGroupSubs: LookupModel[] = [];

  xx = '';
  currentUser: UserModel;

  model: SalesOrderModel = {
    customDiscountTotal: 0,
    itemDiscountTotal: 0,
    taxTotal: 0,
    netTotal: 0,
    cashDiscountTotal: 0,
    itemTotal: 0,
    salesDate: this._UtilService.LocalDate(new Date()),
    salesCode: '',
    invoiceCode: '',
    clientId: 0,
    agentId: 0,
    storeId: 0,
    representativeId: 0,
    paymentTermId: 0,
  } as SalesOrderModel;

  clientModel: ClientModel = {
    isActive: false,
    isCashDiscount: false,
    isTaxable: false,
    paymentTermId: 0,
    businessUnitId: 0,
    clientGroupId: 0,
    clientGroupSubId: 0,

  } as ClientModel;

  addressModel: SalesOrderAddressModel = {
    address: '',
    building: '',
    cityId: 0,
    floor: '',
    governerateId: 0,
    landmark: '',
    latitude: 0,
    longitude: 0,
    mobile: '',
    phone: '',
    property: '',
    regionId: 0,
    salesAddressId: 0,
    salesId: 0,
    whatsApp: '',
    updateClient: false,
  } as SalesOrderAddressModel;

  modelError: SalesOrderErrorListModel[] = [];
  modelLog: SalesOrderLogListModel[] = [];
  modelMessages: SalesOrderMessagesListModel[] = [];
  modelMessage: SalesOrderMessagesListModel = {

  } as SalesOrderMessagesListModel;

  modelDispatch: SalesOrderDispatchModel = {
    dispatchId: 0,
    salesId: 0,
    dispatchCode: '',
    dispatchDate: undefined,
    dispatchTime: undefined,
    shiftDate: undefined,
    distributorId: 0,
    carId: 0,
    driverId: 0,
    distributorCode: '',
    carCode: '',
    driverCode: '',
    inZone: false,
    distance: 0,
    latitude: 0,
    longitude: 0,
    feedbackId: 0,
    notes: ''
  } as SalesOrderDispatchModel;
  selected: SalesOrderDetailModel;
  selectedError: SalesOrderErrorListModel;
  selectedLog: SalesOrderLogListModel;

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

  menu: MenuItem[];
  items: MenuItem[];
  selectedIndex = 1;

  options: any;
  overlays: any[];
  maker = { lat: 30.065774, lng: 31.338034 };

  constructor(
    private ref: DynamicDialogRef,
    private _auth: UserService,
    private primengConfig: PrimeNGConfig,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private _SalesOrderSourceService: SalesOrderSourceService,
    private _SalesOrderStatusService: SalesOrderStatusService,
    private _BranchService: BranchService,
    private _StoreService: StoreService,
    private _PriorityService: PriorityService,
    private _ItemStoreService: ItemStoreService,
    private _RepresentativeService: RepresentativeService,
    private confirmationService: ConfirmationService,
    private _SalesOrderService: SalesOrderService,
    private _PaymentTermService: PaymentTermService,
    private _ClientService: ClientService,
    private _CustomDiscountTypeService: CustomDiscountTypeService,
    private _AppMessageService: AppMessageService,
    private config: DynamicDialogConfig,
    private _UtilService: UtilService,
    private _ItemPromotionService: ItemPromotionService,
    private _AlertService: AlertService,
    private cdr: ChangeDetectorRef,
    private _GovernerateService: GovernerateService,
    private _CityService: CityService,
    private _SalesOrderErrorService: SalesOrderErrorService,
    private _SalesOrderLogService: SalesOrderLogService,
    private _ClientGroupService: ClientGroupService,
    private _ClientGroupSubService: ClientGroupSubService,
    private _SalesOrderMessageService: SalesOrderMessageService,
    private _UserService: UserService,
    private messageService: MessageService,

  ) {
    this.currentUser = _UserService.Current();

    this._translationLoaderService.loadTranslations(english, arabic);
    this.clear();

    this.model.salesId = 0;


    this.modelMessage = {
      avatar: this.currentUser.avatar,
      jobTitle: this.currentUser.jobTitle,
      message: '',
      messageDate: new Date(),
      realName: this.currentUser.realName,
      salesId: 0,
      salesMessageId: 0,
      userId: this.currentUser.userId,
      userName: this.currentUser.username,
    };


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



    this.menu = [
      {
        label: 'Clear', icon: 'pi pi-times', command: () => {
          this.clear();
        }
      },
      { separator: true },
      {
        label: 'Promotion', icon: 'pi pi-cog', command: () => {
          this.Promotion();
        }
      }
    ];

    this.items = [
      {
        label: 'Order Info',
        icon: 'fa fa-info-circle',
        command: (e) => this.manage(1)
      },
      {
        label: 'Order Items',
        icon: 'fa fa-users',
        disabled: this.model.salesId == 0 ? true : false,
        command: (e) => this.manage(2)
      },
      {
        label: 'Promotions Summery',
        icon: 'fa fa-tags',
        disabled: this.model.salesId == 0 ? true : false,
        command: (e) => this.manage(7)
      },
      {
        label: 'Delivery Address',
        icon: 'fa fa-money',
        disabled: this.model.salesId == 0 ? true : false,
        command: (e) => this.manage(3)
      },
      {
        label: 'Order Dispatching',
        icon: 'fa fa-money',
        disabled: this.model.salesId == 0 ? true : false,
        command: (e) => this.manage(6)

      },
      {
        label: 'Order Errors',
        icon: 'fa fa-unlock-alt',
        disabled: this.model.salesId == 0 ? true : false,
        badge: "2",
        command: (e) => this.manage(4)
      },
      {
        label: 'Order Log',
        icon: 'fa fa-history',
        disabled: this.model.salesId == 0 ? true : false,
        command: (e) => this.manage(5)
      },
    ];


    this.options = {
      center: this.maker,
      zoom: 5,
      mapId: '2df52e872b9212a',
      mapTypeControl: false,
      streetViewControl: false,
      keyboardShortcuts: false,
    };

    this.overlays = [
    ];

  }
  manage(index) {
    this.selectedIndex = index;
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

    this.addLine();

  }
  duplicate() {
    this.model.salesId = 0;
    this.model.salesOrderStatusId = 1;

    this.model.clientId = 0;
    this.model.clientCode = '';
    this.model.clientName = '';

  }

  ngOnInit(): void {

    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });
    this._translateService.get('This Product with batch/expire exist in this order').subscribe((res) => { this.DUPLICATE_PRODUCT = res });
    this._translateService.get('No Batch found on this product').subscribe((res) => { this.NO_BATCH_FOUND = res });
    this._translateService.get('Promotion Details').subscribe((res) => { this.PROMOTION_DETAILS = res });
    this._translateService.get('Warehouses Details').subscribe((res) => { this.STORE_DETAILS = res });
    this._translateService.get('Client Quota Details').subscribe((res) => { this.CLIENT_QUOTA_DETAILS = res });
    this._translateService.get('Client Statisticals ').subscribe((res) => { this.CLIENT_STC = res });


    this.init();
  }
  async init() {

    this.model.salesOrderStatusId = 1;
    this.model.salesOrderSourceId = 1;
    this.model.salesTime = this._UtilService.LocalDate(new Date());

    this.isLoading = true;

    this._GovernerateService.GetAll().then(res => {
      this.Governerates = res.data;

      if (this.Governerates.length > 0) {
        this._CityService.GetByGovernerate(this.Governerates[0].id).then(res => {
          this.Cities = res.data;
          this.Cities.unshift({ id: 0, code: '0', name: '--' });
        })
      }

      this.Governerates.unshift({ id: 0, code: '0', name: '--' });
    });

    this._PaymentTermService.GetAll().then(res => {
      this.Payments = res.data;
    })

    this._SalesOrderSourceService.GetAll().then(res => {
      this.Sources = res.data;
    })

    this._ClientGroupService.GetAll().then(res => {
      this.ClientGroups = res.data;
      this.ClientGroups.unshift({ id: 0, code: '0', name: '--' });
    })
    this._ClientGroupSubService.GetAll().then(res => {
      this.ClientGroupSubs = res.data;
      this.ClientGroupSubs.unshift({ id: 0, code: '0', name: '--' });

    })


    this._SalesOrderStatusService.GetAll().then(res => {
      this.OrderStatus = res.data.filter(a => a.id < 5);
      this.DispatchStatus = res.data.filter(a => a.id >= 5);
    })

    this._PriorityService.GetAll().then(res => {
      this.Priorites = res.data;
    })

    this._CustomDiscountTypeService.GetAll().then(res => {
      this.discountType = res.data;
    })


    let current = this._auth.Current();

    console.log(current);

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
        await this._RepresentativeService.getById(current.representativeId).then(res => {
          if (res.succeeded == true) {
            this.model.representativeId = res.data.representativeId;
            this.model.representativeCode = res.data.representativeCode;
            this.model.representativeName = res.data.representativeNameEn;
          }

        })
      }

      if (current.storeId > 0) {
        await this._StoreService.getById(current.storeId).then(res => {
          if (res.succeeded == true) {
            this.model.storeId = res.data.storeId;
            this.model.storeCode = res.data.storeCode;
            this.model.storeName = res.data.storeNameEn;

            this.model.branchId=res.data.branchId;

            
          }

        })
      }

    }




    if (this.model.salesId > 0) {
      await this._SalesOrderService.getById(this.model.salesId).then(res => {
        if (res.succeeded == true) {

          this.selectedIndex = 2;
          this.model = res.data;
          this.model.salesTime = new Date(res.data.salesTime)
         
          this.addLine();

          
          if (this.model.storeId > 0) {
            this._StoreService.getById(this.model.storeId).then(res => {
              this.model.storeCode = res.data.storeCode;
              this.model.storeName = res.data.storeNameEn;
            })
          }
          if (this.model.clientId > 0) {
            this._ClientService.getById(this.model.clientId).then(res => {
              this.model.clientCode = res.data.clientCode;
              this.model.clientName = res.data.clientNameEn;

              this.clientModel.paymentTermId = res.data.paymentTermId;
              this.clientModel.clientGroupId = res.data.clientGroupId;
              this.clientModel.clientGroupSubId = res.data.clientGroupSubId;
              this.clientModel.creditBalance = res.data.creditBalance;
              this.clientModel.creditLimit = res.data.creditLimit;
              this.clientModel.isActive = res.data.isActive;
              this.clientModel.isTaxable = res.data.isTaxable;
              this.clientModel.isCashDiscount = res.data.isCashDiscount;


            })
          }
          if (this.model.representativeId > 0) {
            this._RepresentativeService.getById(this.model.representativeId).then(res => {
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


          this._SalesOrderService.getAddress(this.model.salesId).then(res => {
            if (res.succeeded == true) {
              this.addressModel = res.data;

              if (!this.addressModel) {
                this.addressModel = {
                  address: '',
                  building: '',
                  cityId: 0,
                  floor: '',
                  governerateId: 0,
                  landmark: '',
                  latitude: 0,
                  longitude: 0,
                  mobile: '',
                  phone: '',
                  property: '',
                  regionId: 0,
                  salesAddressId: 0,
                  salesId: 0,
                  updateClient: false,
                  whatsApp: ''
                } as SalesOrderAddressModel;
              }

              if (this.addressModel.latitude > 0 && this.addressModel.longitude > 0) {
                this.overlays = [];
                this.overlays.push(new google.maps.Marker({ position: { lat: this.addressModel.latitude, lng: this.addressModel.longitude }, icon: "assets/images/marker_icon_online.png", title: "Delivery Location" }),);
                this.options.center.lat = this.addressModel.latitude;
                this.options.center.lng = this.addressModel.longitude;
              }
            }
          })
          this._SalesOrderMessageService.GetMessages(this.model.salesId).then(res => {
            this.modelMessages = res.data;
            if (this.modelMessages.length == 0) {
              this.modelMessages.push({
                avatar: this.currentUser.avatar,
                jobTitle: this.currentUser.jobTitle,
                message: 'you can add comment or note for yourself or for others',
                messageDate: new Date(),
                realName: this.currentUser.realName,
                salesId: this.model.salesId,
                salesMessageId: -1,
                userId: this.currentUser.userId,
                userName: this.currentUser.username
              });
            }
          })

          this._SalesOrderErrorService.GetBySalesId(this.model.salesId).then(res => {
            this.modelError = res.data;
          })

          this._SalesOrderLogService.GetById(this.model.salesId).then(res => {
            this.modelLog = res.data;
          })

          if (this.model.salesOrderDetails.length == 0) {
            this.addLine();
          }
        }
        else {
          this.ref.close();
        }
      })
    }
    else {
      this.modelMessages.push({
        avatar: this.currentUser.avatar,
        jobTitle: this.currentUser.jobTitle,
        message: 'you can add comment or note for yourself or for others',
        messageDate: new Date(),
        realName: this.currentUser.realName,
        salesId: this.model.salesId,
        salesMessageId: -1,
        userId: this.currentUser.userId,
        userName: this.currentUser.username
      });

    }


    if (this.model.clientId > 0) {
      this._ClientService.getById(this.model.clientId).then(res => {
        this.model.clientId = res.data.clientId;
        this.model.clientCode = res.data.clientCode;
        this.model.clientName = res.data.clientNameEn;

      })
    }

    this.isLoading = false;
  }


  async saveHeader() {
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


    if (valid == false) {

      this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });
      return;
    }




    this.confirmationService.confirm({
      message: this._AppMessageService.MESSAGE_CONFIRM,
      accept: async () => {

        this.isLoading = true;
        this.model.errors = [];
        this.model.warnings = [];

        await this._SalesOrderService.SaveHeader(this.model).then((res) => {
          if (res.succeeded == true) {

            if (res.data != null && res.data.salesId > 0) {
              this.items[1].disabled = false;
              this.items[2].disabled = false;
              this.items[3].disabled = false;
              this.items[4].disabled = false;
              this.items[5].disabled = false;
              this.selectedIndex = 2;

              this.model.salesId = res.data.salesId;

              this.messageService.add({ severity: 'succuss', detail: this._AppMessageService.MESSAGE_OK });

              this.modelMessages.forEach(element => {
                element.salesId = this.model.salesId;
              });

              this._SalesOrderMessageService.Save(this.modelMessages).then(res => {
                this.modelMessages = res.data;
              })

              if (this.model.salesOrderDetails.length == 0) {
                this.addLine();
              }
            }
            else {
              this.messageService.add({ severity: 'error', detail: res.message });
            }

          }
          else {
            this.messageService.add({ severity: 'error', detail: res.message });
          }
        });

        this.isLoading = false;

        //this.cdr.detectChanges();
      },
      reject: () => {
        //reject action
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



    await this._SalesOrderService.Promotion(this.model).then((res) => {
      if (res.succeeded == true) {
        this.model = res.data;
        if (res.data.promotionOptions.length > 0) {
          this.showOption = true;
        }
        this.isPromotionCalculated = true;
      }
      else {
        //this.messageService.add({ severity: 'error', detail: res.message });
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
          await this._SalesOrderService.Approve(orderModel).then(res => {
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
  async onBranchChange(event) {

  }


  chooseProduct(line: SalesOrderDetailModel) {

    console.log(line);

    if (line.isBouns == true) {
      return
    }
    if (this.model.clientId && this.model.storeId > 0 && this.model.branchId) {

      this.isPromotionCalculated=false;
      var ref = this.dialogService.open(ChooserProductComponent, {

        data: {
          storeId: this.model.storeId,
          canChange:false,
        },

        header: this.CHOOSE,
        width: '95%',
        modal: true,
        height: "95%"
      });

      ref.onClose.subscribe((product: ItemListModel) => {
        if (product && product.isActive == true && product.quantity > 0) {

          let IsDone = this.addToOrder(line, product)

          if (IsDone == true) {
            this.calcTotals();
            this.addLine();
          }
        }
        else {
          //this.messageService.add({ severity: 'error', detail: this.NO_BATCH_FOUND });
        }

      });

    }
    else {
      //this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });

    }

  }

  addToOrder(line: SalesOrderDetailModel, product: ItemListModel): boolean {

    let isDone = false;



    line.itemId = product.itemId;
    line.itemCode = product.itemCode;
    line.itemName = product.itemName;
    line.clientPrice = product.clientPrice;
    line.publicPrice = product.publicPrice;
    line.itemStoreId = 0;
    line.hasPromotion = product.hasPromotion;
    line.detailId = product.itemId;
    line.isBouns = false;

    line.discount = 0.00,
      line.taxValue = 0.00;

    line.lineValue = Number((line.quantity * line.clientPrice).toFixed(3));

    if (product.isTaxable == true) {
      line.taxValue = Number((line.clientPrice * 0.14).toFixed(2));
    }

    this.itemStoreSearchModel.branchId = this.model.branchId;
    this.itemStoreSearchModel.itemId = line.itemId;
    this.itemStoreSearchModel.storeId = this.model.storeId;

    this.isLoadingGrid = true;

    this._ItemStoreService.Filter(this.itemStoreSearchModel).then(res => {
      console.log(res);

      if (res && res.data && res.data.length > 0) {

        var exist = this.model.salesOrderDetails
          .find(a => a.itemStoreId == res.data[0].itemStoreId && a.isBouns == false)

        if (exist == null) {

          line.itemStoreId = res.data[0].itemStoreId;
          line.batch = res.data[0].batchNo;
          line.expiration = res.data[0].expireDate;
          line.unitId = res.data[0].unitId;

          if (res.data[0].available < line.quantity) {
            line.quantity = 0;
          }

        }
        else {
          // remove line dublicate 
          //this.messageService.add({ severity: 'error', detail: this.DUPLICATE_PRODUCT });
        }
      }
      else {
        // handle no batch found
        line = {} as SalesOrderDetailModel;
        //this.messageService.add({ severity: 'error', detail: this.NO_BATCH_FOUND });
      }

      this.isLoadingGrid = false;

    });

    isDone = true;

    return isDone;

  }
  chooseBatch(line: SalesOrderDetailModel) {
    if (line.isBouns == true) {
      return;
    }
    if (line.itemId > 0 && this.model.storeId > 0 && this.model.branchId) {

      this.isPromotionCalculated=false;
      var ref = this.dialogService.open(ChooserBatchComponent, {
        data: {
          itemId: line.itemId,
          storeId: this.model.storeId,
          isActive: 1,
          available: 1
        },
        header: this.CHOOSE,
        width: '800px',
        modal: true,
        height: "90%"
      });

      ref.onClose.subscribe((product: ItemStoreListModel) => {
        if (product != null && product.available > 0 && product.isActive == true && product.itemStoreId > 0) {
          var exist = this.model.salesOrderDetails.find(a => a.itemStoreId == product.itemStoreId);
          if (exist == null) {
            line.itemStoreId = product.itemStoreId;
            line.batch = product.batchNo;
            line.expiration = product.expireDate;
          }

    this.isPromotionCalculated=false;

        }
      });
    }
  }
  choose_representitive() {

    if (this.model.branchId == undefined || this.model.branchId == null || this.model.branchId == 0) {
      return;
    }

    this.representitiveSearchModel.branchId = this.model.branchId;


    var ref = this.dialogService.open(ChooserRepresentativeComponent, {
      header: this.CHOOSE,
      data: { searchModel: this.representitiveSearchModel },
      width: '95%',
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

  choose_Client() {


    if (this.model.branchId == undefined || this.model.branchId == null || this.model.branchId == 0) {
      return;
    }


    let searchModel: ClientSearchModel = {


      clientId: 0,
      clientCode: '',
      clientName: '',
      clientTypeId: 0,
      branchId: 0,
      branchCode: '',
      branchSubId: 0,
      regionId: 0,
      governerateId: 0,
      cityId: 0,
      areaId: 0,
      clientGroupId: 0,
      clientGroupSubId: 0,
      building: '',
      floor: '',
      property: '',
      phone: '',
      mobile: '',
      whatsApp: '',
      isActive: 0,
      Take: 30,
      Skip: 0,
      Term: '',
      commercialCode: '',
      FilterBy: [],
      SortBy: { Property: "clientId", Order: "asc" },
      taxCode: '',
      isChain: 0,
      isTaxable: 0,
      paymentTermId: 0,
      clientClassificationId: 0,
      locationLevelId: 0,
      businessUnitId: 0,
      inRoute: 0,
      isNew: 0,
      needValidation: 0,
      TermBy: ""

    }

    var ref = this.dialogService.open(ChooserClientComponent, {
      data: { searchModel: searchModel },
      header: this.CHOOSE,
      width: '95%',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((client: ClientListModel) => {
      if (client) {

        if (client.isActive == true) {
          this.model.clientCode = client.clientCode;
          this.model.clientName = client.clientName;

          this.model.branchId=client.branchId;


          this.model.clientId = client.clientId;
          this.model.paymentTermId = client.paymentTermId;

          this.clientModel.paymentTermId = client.paymentTermId;
          this.clientModel.clientGroupId = client.clientGroupId;
          this.clientModel.clientGroupSubId = client.clientGroupSubId;
          this.clientModel.creditBalance = client.creditBalance;
          this.clientModel.creditLimit = client.creditLimit;
          this.clientModel.isActive = client.isActive;
          this.clientModel.isTaxable = client.isTaxable;
          this.clientModel.isCashDiscount = client.isCashDiscount;

          this.addLine();
        }
        else {

          this.messageService.add({ severity: 'error', detail: this.BAD_BUYER });
        }


      }
    });

  }


  addLine() {
    if (this.model.clientId > 0 && this.model.storeId > 0 && this.model.branchId) {
      var line: SalesOrderDetailListModel = {} as SalesOrderDetailListModel;

      line.itemId = 0;
      line.itemCode = 'Select New';
      line.itemName = '';
      line.clientPrice = 0;
      line.publicPrice = 0;
      line.quantity = 1;
      line.unitId = 0;
      line.isBouns = false;
      line.itemStoreId = null;
      line.lineValue = 0;
      line.batch = '';
      var exist = this.model.salesOrderDetails.find(a => a.itemId == 0);
      if (!exist) {
        this.model.salesOrderDetails.push(line);
      }

    }
    else {
      //this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID});
    }
  }
  deleteLine() {
    this.model.salesOrderDetails.forEach((element, index) => {
      
      this.isPromotionCalculated=false;

      if (element.itemId == this.selected.itemId && element.itemStoreId == this.selected.itemStoreId) {
        this.model.salesOrderDetails.splice(index, 1);
        this.calcTotals();
      }

    });
  }

  calcTotals() {

    if (this.model.salesOrderDetails.length > 0) {

      this.model.itemTotal = Number((this.model.salesOrderDetails.filter(item => item.itemId > 0).reduce((sum, current) => sum + (current.quantity * current.clientPrice), 0)).toFixed(3))
      this.model.taxTotal = Number((this.model.salesOrderDetails.filter(item => item.taxValue > 0).reduce((sum, current) => sum + current.taxValue * current.quantity, 0)).toFixed(3));
      this.model.itemDiscountTotal = Number((this.model.salesOrderDetails.filter(item => item.itemId > 0).reduce((sum, current) => sum + (current.quantity * current.discount), 0)).toFixed(3))

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

  }

  onQuantityChange(arg, line: SalesOrderDetailModel) {
    if (arg.value) {
      line.lineValue = Number((arg.value * line.clientPrice).toFixed(3));
    }
    this.isPromotionCalculated=false;
    this.calcTotals();
  }

  onKeyDown(arg, line: SalesOrderDetailModel) {
    if (arg.keyCode == 13){
    this.isPromotionCalculated=false;
      this.calcTotals();
    }
    
  }
  getLineValue(line: SalesOrderDetailModel){
    return Number((line.clientPrice-line.discount+line.taxValue)*line.quantity).toFixed(3);
  }

  showClientStc() {
    if (this.model != null && this.model.clientId > 0) {


      var ref = this.dialogService.open(ClientStatisticalComponent, {
        header: this.CLIENT_STC,
        data: { clientId: this.model.clientId },
        width: '90%',
        height: '90%',
        contentStyle: { "overflow": "auto" },
        baseZIndex: 10000
      });

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

  showPromotion(itemCode) {
    if (itemCode && this.model.clientId > 0) {


      this.isLoading = true;
      this._ItemPromotionService.GetByItem(itemCode).then(res => {
        if (res != null && res.data) {
          if (res.data.promotionId > 0) {
            var ref = this.dialogService.open(ManagePromotionComponent, {
              header: this.PROMOTION_DETAILS,
              data: { promotionId: res.data.promotionId, promotionCategoryId: res.data.promotionCategoryId, editMode: 'v',minimal:true },
              width: '900px',
              contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
              baseZIndex: 10000
            });
          }
        }

        this.isLoading = false;

      })
    }
  }
  showWarehouse(itemId) {
    if (itemId > 0 && this.model.clientId > 0) {

      var ref = this.dialogService.open(ViewStoreBalanceComponent, {
        header: this.STORE_DETAILS,
        data: { itemId: itemId, storeId: this.model.storeId },
        width: '1200px',
        height: '700px',
        contentStyle: { "overflow": "auto" },
        baseZIndex: 10000
      });


    }
  }



  showQuota(itemId) {
    if (itemId > 0 && this.model.clientId > 0) {

      var ref = this.dialogService.open(ViewClientQuotaComponent, {
        header: this.CLIENT_QUOTA_DETAILS,
        data: { itemId: itemId, clientId: this.model.clientId },
        width: '900px',
        height: '700px',
        contentStyle: { "overflow": "auto" },
        baseZIndex: 10000
      });


    }
  }

  showErrors() {
    this.showError = true;
  }

  FixedNumer(num: number) {
    if (!num) return 0;

    return Number(num.toFixed(3));
  }
  async saveOption() {

    this.model.promotionOptions.forEach(element => {
      if (element.selected == true) {
        element.batchs.forEach(element => {
          element.clientPrice = 0;
          this.model.salesOrderDetails.push(element)
          this.model.salesOrderDetails = this.model.salesOrderDetails.sort((n1, n2) => {
            if (n1.itemId < n2.itemId) {
              return 1;
            }

            if (n1.itemId > n2.itemId) {
              return -1;
            }

            return 0;
          });
        });
      }
    });

    this.isLoading = true;
    this.model.errors = [];
    this.model.warnings = [];

    await this._SalesOrderService.SaveDetails(this.model).then((res) => {
      this.model = res.data;
      this.isPromotionCalculated = true;
      this.showOption = false;
    });

    this.isLoading = false;

  }
  selectOption(event, model) {
    console.log(event.target.value);

    const result = this.model.promotionOptions.filter((obj) => {
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
  async onGovernerateChange(e) {

    this.Cities = [];
    this.isLoading = true;

    this._CityService.GetByGovernerate(e.value).then(res => {
      this.Cities = res.data;
      this.isLoading = false;
      this.Cities.unshift({ id: 0, code: '0', name: '--' });
    })
  }
  async drawMarker(event) {
    console.log(this.addressModel.latitude + ' ' + this.addressModel.longitude);
    this.isLoading = true;
    if (this.addressModel.latitude > 0 && this.addressModel.longitude > 0) {
      this.overlays = [];
      this.overlays.push(new google.maps.Marker({ position: { lat: this.addressModel.latitude, lng: this.addressModel.longitude }, icon: "assets/images/marker_icon_online.png", title: "Delivery Location" }),);
      this.options.center.lat = this.addressModel.latitude;
      this.options.center.lng = this.addressModel.longitude;

    }
    else {
      this.overlays = [];
      this.options.center.lat = undefined;
      this.options.center.lng = undefined;
    }
    this.isLoading = false;

    this.cdr.detectChanges();
  }
  async SaveAddress() {
    let valid = true;

    if (this.model.clientId == 0) {
      valid = false;

    }


    if (this.model.salesId == 0) {
      valid = false;

    }
    if (this.addressModel.governerateId == 0) {
      valid = false;
    }
    if (this.addressModel.cityId == 0) {
      valid = false;
    }


    if (valid == false) {
      this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });
      return;
    }
    this.confirmationService.confirm({
      message: this._AppMessageService.MESSAGE_CONFIRM,
      accept: async () => {

        this.isLoading = true;
        this.addressModel.salesId = this.model.salesId;
        await this._SalesOrderService.saveAddress(this.addressModel).then((res) => {
          //console.log(res);
          this.addressModel = res.data;

          if (res.succeeded == true) {

            if (res.data != null && res.data.salesId > 0) {
              this.messageService.add({ severity: 'succuss', detail: this._AppMessageService.MESSAGE_OK });
            }
            else {
              this.messageService.add({ severity: 'error', detail: res.message });
            }

          }
          else {
            this.messageService.add({ severity: 'error', detail: res.message });
          }
        });

        this.isLoading = false;

        //this.cdr.detectChanges();
      },
      reject: () => {
        //reject action
      }
    });
  }
  handleMapClick(event) {
    this.addressModel.latitude = event.latLng.lat();
    this.addressModel.longitude = event.latLng.lng();

    this.overlays = [];
    this.overlays.push(new google.maps.Marker({ position: { lat: this.addressModel.latitude, lng: this.addressModel.longitude }, icon: "assets/images/marker_icon_online.png", title: "Delivery Location" }),);
    this.options.center.lat = this.addressModel.latitude;
    this.options.center.lng = this.addressModel.longitude;

    this.cdr.detectChanges();
  }

  manageError(operation) {
    if (operation == 'reload') {
      if (this.model.salesId > 0) {
        this.isLoading = true;
        this._SalesOrderErrorService.GetBySalesId(this.model.salesId).then(res => {
          this.modelError = res.data;
          this.isLoading = false;
        })
      }
    }
  }
  manageLog(operation) {
    if (operation == 'reload') {
      if (this.model.salesId > 0) {
        this.isLoading = true;
        this._SalesOrderLogService.GetById(this.model.salesId).then(res => {
          this.modelLog = res.data;
          this.isLoading = false;
        })
      }
    }
  }

  isEnabled(type) {

    let result = true;
    if (type == 'client') {
      var count = this.model.salesOrderDetails.filter(a => a.itemId > 0).length;
      console.log("Count" + count);

      if (count > 0) {
        result = false;
      }
    }
    return result;
  }

  saveMessage(key) {
    if (key.code == 'Enter' || key.code == 'NumpadEnter') {
      if (this.modelMessage && this.modelMessage.message && this.modelMessage.message.length > 0) {
        this.modelMessage.salesId = this.model.salesId;
        this.modelMessages.push(this.modelMessage);

        this.modelMessage = {
          avatar: this.currentUser.avatar,
          jobTitle: this.currentUser.jobTitle,
          message: '',
          messageDate: new Date(),
          realName: this.currentUser.realName,
          salesId: 0,
          salesMessageId: 0,
          userId: this.currentUser.userId,
          userName: this.currentUser.username,
        };

      }
    }
  }
  PromotionAll(){
    var ref = this.dialogService.open(ChooserPromotionComponent, {
      header: this.CHOOSE,
      data: {
        branchId: this.currentUser.branchId,
        storeId: this.currentUser.storeId
      },
      width: '90%',
      contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
    });
    ref.onClose.subscribe((product: ItemListModel) => {
      if (product) {
        
      }
    });

  }
}
