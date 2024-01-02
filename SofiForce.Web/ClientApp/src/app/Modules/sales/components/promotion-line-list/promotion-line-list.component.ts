import { Component, Input, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig } from 'primeng/dynamicdialog';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { TranslateService } from '@ngx-translate/core';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { BooleanService } from 'src/app/core/services/Boolean.Service';
import { UtilService } from 'src/app/core/services/util.service';
import { SalesOrderPromotionAllListModel } from 'src/app/core/Models/EntityModels/SalesOrderPromotionAllListModel';
import { SalesOrderPromotionAllSearchModel } from 'src/app/core/Models/SearchModels/SalesOrderPromotionAllSearchModel';
import { ManageSalesOrderComponent } from '../manage-sales-order/manage-sales-order.component';
import { ItemPromotionAllListModel } from 'src/app/core/Models/ListModels/ItemPromotionAllListModel';
import { ItemPromotionAllSearchModel } from 'src/app/core/Models/SearchModels/ItemPromotionAllSearchModel';
import { ManagePromotionComponent } from '../manage-promotion/manage-promotion.component';
import { SalesOrderPromotionSearchModel } from 'src/app/core/Models/SearchModels/SalesOrderPromotionSearchModel';
import { SalesOrderLinePromotionListModel } from 'src/app/core/Models/ListModels/SalesOrderLinePromotionListModel';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { ChooserBranchComponent } from 'src/app/Modules/shared/chooser-branch/chooser-branch.component';
import { ChooserClientComponent } from 'src/app/Modules/shared/chooser-client/chooser-client.component';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { ChooserVendorComponent } from 'src/app/Modules/shared/chooser-vendor/chooser-vendor.component';
import { VendorListModel } from 'src/app/core/Models/ListModels/VendorListModel';
import { ChooserProductComponent } from 'src/app/Modules/shared/chooser-product/chooser-product.component';
import { ItemListModel } from 'src/app/core/Models/ListModels/ItemListModel';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';
@Component({
  selector: 'app-promotion-line-list',
  templateUrl: './promotion-line-list.component.html',
  styleUrls: ['./promotion-line-list.component.scss']
})
export class PromotionLineListComponent implements OnInit {


  @Input() take = 30;
  @Input() itemId = 0;
  @Input() promotionId = 0;
  @Input() salesId = 0;
  @Input() isPopup = false;


  gridModel: ResponseModel<SalesOrderLinePromotionListModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }

  searchModel: SalesOrderPromotionSearchModel = {
    outcomeType: 1,
    itemId: 0,
    batchNo: '',
    vendorId: 0,
    branchId: 0,
    clientId: 0,
    from: this._UtilService.FirstOFMonth(new Date()),
    to: new Date(),
    promotionCode: '',
    invoiceCode: '',
    promotionId: 0,
    salesId: 0,
    Take: 25,
    Skip: 0,
    Term: '',
    TermBy: '',
    FilterBy: [],
    SortBy: undefined,
    itemCode: '',
    vendorCode: '',
    branchCode: '',
    clientCode: ''
  }

  advanced = true;
  showExtend = false;
  isLoading = false;
  isLoadingExtend = false;
  showFilter = true;

  actions = false;

  first = 0;
  items: MenuItem[];
  menuItems: MenuItem[];

  selected: SalesOrderLinePromotionListModel


  CREATE_NEW_HEADER = '';
  EDIT_HEADER = '';
  REP_STC = '';
  USER_ACCRESS = '';
  CHOOSE = '';
  Types = [
    { id: 1, name: "Free", },
    { id: 2, name: "Discount", }
  ];
  constructor(
    private _AppMessageService: AppMessageService,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _BooleanService: BooleanService,
    private _UtilService: UtilService,
    private config: DynamicDialogConfig,
    private _commonCrudService : CommonCrudService,

  ) {
    this._translationLoaderService.loadTranslations(english, arabic);

    this._translateService.get('Add New Promotion').subscribe((res) => { this.CREATE_NEW_HEADER = res });
    this._translateService.get('Edit/View Promotion').subscribe((res) => { this.EDIT_HEADER = res });
    this._translateService.get('Promotion Statistics').subscribe((res) => { this.REP_STC = res });
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });


    if (this.config.data) {
      console.log("Dialog  Data");

      console.log(this.config.data);

      if (this.config.data.take) {
        this.searchModel.Take = +this.config.data.take;
      }


      if (this.config.data.promotionId) {
        this.searchModel.promotionId = +this.config.data.promotionId;
      }

      if (this.config.data.itemId) {
        this.searchModel.itemId = +this.config.data.itemId;
      }
      if (this.config.data.salesId) {
        this.searchModel.salesId = +this.config.data.salesId;
      }

      if (this.config.data.isPopup) {
        this.isPopup = this.config.data.isPopup;
      }


      if (this.config.data.showFilter) {
        this.showFilter = this.config.data.showFilter;
      }

    }
  }

  ngOnInit(): void {

    if (this.itemId > 0)
      this.searchModel.itemId = this.itemId;

    if (this.promotionId > 0)
      this.searchModel.promotionId = this.promotionId;

    if (this.salesId > 0) {
      this.searchModel.salesId = this.salesId;
      this.advanced = false;
    }
    
    if (this.take > 0)
      this.searchModel.Take = this.take;

    console.log(this.searchModel);

    this.menuItems = [
      {
        label: 'View Invoice',
        icon: 'fa fa-list-alt',
        command: (e) => this.manage('i')
      },
      {
        label: 'View Promotion',
        icon: 'fa fa-tags',
        command: (e) => this.manage('p')
      },
    ];


  }

  OnTermChange(arg) {
    localStorage.setItem("promotion-orders-list.component.termBy", arg.value);
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

    await this._commonCrudService.post("SalesOrderLinePromotion/filter", this.searchModel,SalesOrderLinePromotionListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._commonCrudService.post("SalesOrderLinePromotion/filter", this.searchModel,SalesOrderLinePromotionListModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {
    this.isLoading = true;
    await this._commonCrudService.post("SalesOrderLinePromotion/filter", this.searchModel,SalesOrderLinePromotionListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.searchModel.Skip = 0;
    await this._commonCrudService.post("SalesOrderLinePromotion/filter", this.searchModel,SalesOrderLinePromotionListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel = {

      outcomeType: 1,
      itemId: 0,
      batchNo: '',
      vendorId: 0,
      branchId: 0,
      clientId: 0,
      from: this._UtilService.FirstOFMonth(new Date()),
      to: new Date(),
      promotionCode: '',
      invoiceCode: '',
      promotionId: 0,
      salesId: 0,
      Take: 25,
      Skip: 0,
      Term: '',
      TermBy: '',
      FilterBy: [],
      SortBy: undefined,
      itemCode: '',
      vendorCode: '',
      branchCode: '',
      clientCode: ''

    };

    this.advancedFilter();
  }

  async onSelectionChange(event) {
    this.refreshMenu();
  }
  refreshMenu() {
  }
  async manage(mode) {

    if (mode == 'p') {
      if (this.selected && this.selected.promotionId > 0) {
        var ref = this.dialogService.open(ManagePromotionComponent, {
          header: this.EDIT_HEADER,
          data: { promotionId: this.selected.promotionId },
          width: '900px',
          contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
          baseZIndex: 10000
        });


      }
    }
    if (mode == 'i') {

      if (this.selected && this.selected.salesId > 0) {
        var ref = this.dialogService.open(ManageSalesOrderComponent, {
          header: this.EDIT_HEADER,
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

    if (mode == 'download') {
      this.isLoading = true;
      (await this._commonCrudService.postFile("SalesOrderLinePromotion/download",this.searchModel)).subscribe((data: any) => {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "ItemPromotion_" + new Date().toISOString().split('.')[0].replace(/[^\d]/gi, '');
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);


        this.isLoading = false;
      })
    }


  }

  choose_Branch() {
    var ref = this.dialogService.open(ChooserBranchComponent, {
      header: this.CHOOSE,
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
    this.searchModel.branchCode = "";
    this.searchModel.branchId = 0;
  }
  choose_Client() {
    var ref = this.dialogService.open(ChooserClientComponent, {
      header: this.CHOOSE,
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
    this.searchModel.clientCode = "";
    this.searchModel.clientId = 0;
  }
  choose_Vendor() {
    var ref = this.dialogService.open(ChooserVendorComponent, {
      header: this.CHOOSE,
      width: '800px',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((client: VendorListModel) => {
      if (client) {


        this.searchModel.vendorCode = client.vendorCode;
        this.searchModel.vendorId = client.vendorId;

      }
    });
  }

  clear_Vendor() {
    this.searchModel.vendorCode = "";
    this.searchModel.vendorId = 0;
  }
  choose_Item() {
    var ref = this.dialogService.open(ChooserProductComponent, {
      header: this.CHOOSE,
      width: '1200px',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((client: ItemListModel) => {
      if (client) {


        this.searchModel.itemCode = client.itemCode;
        this.searchModel.itemId = client.itemId;

      }
    });
  }

  clear_Item() {
    this.searchModel.itemCode = "";
    this.searchModel.itemId = 0;
  }
}
