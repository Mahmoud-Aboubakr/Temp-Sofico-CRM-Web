import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';


import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { ItemListModel } from 'src/app/core/Models/ListModels/ItemListModel';
import { ItemSearchModel } from 'src/app/core/Models/SearchModels/ItemSearchModel';
import { ItemPromotionService } from 'src/app/core/services/ItemPromotion.Service';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { TranslateService } from '@ngx-translate/core';
import { ChooserVendorComponent } from '../chooser-vendor/chooser-vendor.component';
import { VendorListModel } from 'src/app/core/Models/ListModels/VendorListModel';
import { ManagePromotionComponent } from '../../sales/components/manage-promotion/manage-promotion.component';
import { ViewStoreBalanceComponent } from '../../sales/components/view-store-balance/view-store-balance.component';
import { ChooserStoreComponent } from '../chooser-store/chooser-store.component';
import { StoreListModel } from 'src/app/core/Models/ListModels/StoreListModel';
import { ItemService } from 'src/app/core/services/Item.Service';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';
import { PromotionModel } from '../../../core/Models/EntityModels/PromotionModel';


@Component({
  selector: 'app-chooser-promotion',
  templateUrl: './chooser-promotion.component.html',
  styleUrls: ['./chooser-promotion.component.scss']
})
export class ChooserPromotionComponent implements OnInit {

  model: ResponseModel<ItemListModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: []
  };

  selected = {} as ItemListModel;

  searchModel: ItemSearchModel = {
    storeId:0,
    itemId:0,
    vendorId: 0,
    vendorCode: '',
    itemCode: '',
    itemName: '',
    isNewAdded: 0,
    isNewStocked: 0,
    hasPromotion: 1,
    isActive: 0,
    publicPrice: 0,
    clientPrice: 0,
    Take: 20,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: {
      Property: "itemId",
      Order: "desc"
    },
    TermBy:"",
    storeCode:"",

  }

  advanced = false;
  loading = false;
  first = 0;

  CHOOSE = '';
  PROMOTION_DETAILS: '';

  promotionTypes: LookupModel[] = [];
  isValid: LookupModel[] = [];

  searchBy: LookupModel[] = [{id:1,code:'itemCode',name:'Item Code'},{id:2,code:'itemNameAr',name:'Name Arabic'},{id:3,code:'itemNameEn',name:'Name English'}];


  constructor(
    private _ItemService: ItemService,
    private ref: DynamicDialogRef,
    private messageService: MessageService,
    private config: DynamicDialogConfig,
    private _ItemPromotionService: ItemPromotionService,
    private dialogService: DialogService,
    private _commonCrudService : CommonCrudService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,) {
    this._translationLoaderService.loadTranslations(english, arabic);



    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });
    this._translateService.get('Promotion Details').subscribe((res) => { this.PROMOTION_DETAILS = res });


    if (this.config.data) {

      if(+this.config.data.storeId>0){
        this.searchModel.storeId= +this.config.data.storeId
      }

    }

    var found=localStorage.getItem("chooser-promotion.component.termBy")
    if(found){
      console.log(found);
      this.searchModel.TermBy=found;
    }


    
  }

  async ngOnInit() {
  }

  async filter(event) {
   console.log(event);
    this.searchModel.Skip = event.first;
    this.searchModel.Take = event.rows;


    if (event.sortField) {
      this.searchModel.SortBy.Property = event.sortField;
      if (event.sortOrder == 1) {
        this.searchModel.SortBy.Order = "asc";
      }
      else {
        this.searchModel.SortBy.Order = "desc";

      }
    }


    this.loading = true;

    this.searchModel.itemId=0;
    await this._commonCrudService.post("Item/filter", this.searchModel, ItemListModel).then(res => {
      this.model = res;
      this.loading = false;
      if (this.model.succeeded == false) {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Internal Server Error , call system administrator' });
      }
    })


  }

  async autoFilter() {

    if (this.searchModel.Term.length >=2) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.loading = true;
      await this._commonCrudService.post("Item/filter", this.searchModel, ItemListModel).then(res => {
        this.model = res;
        this.loading = false;

        if(res.data.length>0){
          this.selected=res.data[0];
        }
      })
    }
    
    

  }

  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.loading = true;
      await this._commonCrudService.post("Item/filter", this.searchModel, ItemListModel).then(res => {
        this.model = res;
        this.loading = false;
      })
    }

  }

  async advancedFilter() {
    this.loading = true;
    this.first = 0;
    this.searchModel.Skip = 0;
    await this._commonCrudService.post("Item/filter", this.searchModel, ItemListModel).then(res => {
      this.model = res;
      this.loading = false;
    })


  }
  async advancedClear() {
    this.first = 0;
    this.loading = true;
    await this._commonCrudService.post("Item/filter", this.searchModel, ItemListModel).then(res => {
      this.model = res;
      this.loading = false;
    })


  }
  async onRowDblClick(e, data) {
    if (data) {

      this.ref.close(data);

    }
  }

  async choose_Vendor() {

    var ref = this.dialogService.open(ChooserVendorComponent, {
      header: this.CHOOSE,
      width: '90%',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((branch: VendorListModel) => {
      if (branch) {

        this.searchModel.vendorCode = branch.vendorCode;
        this.searchModel.vendorId = branch.vendorId;
        this.advancedFilter();

      }
    });

  }


  OnTermChange(arg){
    localStorage.setItem("chooser-promotion.component.termBy",arg.value);
  }


  async clear_Vendor() {

    this.searchModel.vendorId = 0;
    this.searchModel.vendorCode = '';
    this.advancedFilter();

  }

  async choose_Store() {

    var ref = this.dialogService.open(ChooserStoreComponent, {
      header: this.CHOOSE,
      width: '90%',
      modal: true,
      height: "720px"
    });

    ref.onClose.subscribe((st: StoreListModel) => {
      if (st) {

        this.searchModel.vendorCode = st.storeCode;
        this.searchModel.vendorId = st.storeId;
        this.advancedFilter();

      }
    });

  }



  async clear_Store() {

    this.searchModel.storeId = 0;
    this.searchModel.storeCode = '';
    this.advancedFilter();

  }

  showPromo(itemCode) {
    this.loading = true;
    this._commonCrudService.get(`ItemPromotion/getByItem?ItemCode=${itemCode}`, PromotionModel).then(res => {
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

      this.loading = false;

    })
  }
  showPromotion(itemCode) {
    if (itemCode ) {

      this._commonCrudService.get(`ItemPromotion/getByItem?ItemCode=${itemCode}`, PromotionModel).then(res => {
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

      })
    }
  }
  showWarehouse(itemId) {
    if (itemId > 0) {

      var ref = this.dialogService.open(ViewStoreBalanceComponent, {
        header: this.CHOOSE,
        data: { itemId: itemId, storeId: this.searchModel.storeId },
        width: '1200px',
        height: '700px',
        contentStyle: { "overflow": "auto" },
        baseZIndex: 10000
      });


    }
  }

}
