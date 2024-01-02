import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';


import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { ItemListModel } from 'src/app/core/Models/ListModels/ItemListModel';
import { ItemSearchModel } from 'src/app/core/Models/SearchModels/ItemSearchModel';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { TranslateService } from '@ngx-translate/core';
import { ChooserVendorComponent } from '../chooser-vendor/chooser-vendor.component';
import { VendorListModel } from 'src/app/core/Models/ListModels/VendorListModel';
import { BooleanService } from 'src/app/core/services/Boolean.Service';
import { ManagePromotionComponent } from '../../sales/components/manage-promotion/manage-promotion.component';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';
import { PromotionModel } from '../../../core/Models/EntityModels/PromotionModel';


@Component({
  selector: 'app-chooser-product-all',
  templateUrl: './chooser-product-all.component.html',
  styleUrls: ['./chooser-product-all.component.scss']
})
export class ChooserProductAllComponent implements OnInit {

  model: ResponseModel<ItemListModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: []
  };

  selected = {} as ItemListModel;

  autoList: LookupModel[] = [];

  promotionOnly: LookupModel[] = [];
  newStocked: LookupModel[] = [];
  newAdded: LookupModel[] = [];

  searchBy: LookupModel[] = [
    {id:1,code:'itemCode',name:'Item Code'},
    {id:2,code:'itemNameAr',name:'Name Arabic'},
    {id:3,code:'itemNameEn',name:'Name English'},
    {id:4,code:'quantity',name:'Quantity'},
    {id:5,code:'clientPrice',name:'Client Price'},
    {id:6,code:'publicPrice',name:'Publice Price'},
    {id:7,code:'discount',name:'Discount'}
  ];

  searchModel: ItemSearchModel = {
    storeId:0,
    itemId:0,
    vendorId: 0,
    vendorCode: '',
    itemCode: '',
    itemName: '',
    isNewAdded: 0,
    isNewStocked: 0,
    hasPromotion: 0,
    Take: 20,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: {
      Property: "itemId",
      Order: "desc"
    },
    isActive: 0,
    publicPrice: 0,
    clientPrice: 0,
    TermBy:"",
    storeCode:'',
    

  }

  advanced = false;
  loading = false;
  first = 0;
  isAutoLoading = false;
  STORE_DETAILS='';

  CHOOSE='';
  PROMOTION_DETAILS='';
  constructor(
    private dialogService: DialogService,
    private ref: DynamicDialogRef,
    private _translateService: TranslateService,
    private messageService: MessageService,
    private config: DynamicDialogConfig,
    private _BooleanService: BooleanService,
    private _commonCrudService : CommonCrudService,
    private _translationLoaderService: TranslationLoaderService,) {
    this._translationLoaderService.loadTranslations(english, arabic);


    if (this.config.data) {

      if(+this.config.data.storeId>0){
        this.searchModel.storeId= +this.config.data.storeId
      }

    }

    this._translateService.get('Warehouses Details').subscribe((res) => { this.STORE_DETAILS = res });
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });
    this._translateService.get('Promotion Details').subscribe((res) => { this.PROMOTION_DETAILS = res });


    var found=localStorage.getItem("chooser-product-all.component.termBy")
    if(found){
      console.log(found);
      this.searchModel.TermBy=found;
    }

    
  }

  async ngOnInit() {

    this._BooleanService.GetAll(localStorage.getItem('lan')).then(res=>{
      this.newStocked=res;
      this.newAdded=res;
      this.promotionOnly=res;

    })
  }

  async filter(event) {
    console.log(event);
    this.loading = true;
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

    this.searchModel.itemId=0;
    await this._commonCrudService.post("Item/filterAll", this.searchModel, ItemListModel).then(res => {
      this.model = res;
      this.loading = false;
      if(res.data.length>0){
        this.selected=res.data[0];
      }

    })


  }


  async smartFilter(event) {

    
    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.loading = true;
      this.searchModel.itemId=0;
      await this._commonCrudService.post("Item/filterAll", this.searchModel, ItemListModel).then(res => {
        this.model = res;
        this.loading = false;

        if(res.data.length>0){
          this.selected=res.data[0];
        }
      })
    }
    
    

  }
  async autoFilter() {

    if (this.searchModel.Term.length >=2) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.loading = true;
      await this._commonCrudService.post("Item/filterAll", this.searchModel, ItemListModel).then(res => {
        this.model = res;
        this.loading = false;

        if(res.data.length>0){
          this.selected=res.data[0];
        }
      })
    }
    
    

  }
  OnTermChange(arg){
    localStorage.setItem("chooser-product-all.component.termBy",arg.value);
  }


  async advancedFilter() {
    this.loading = true;
    this.first = 0;
    this.searchModel.Skip = 0;
    this.searchModel.itemId=0;
    await this._commonCrudService.post("Item/filterAll", this.searchModel, ItemListModel).then(res => {
      this.model = res;
      this.loading = false;
    })


  }
  async advancedClear() {
    this.first = 0;
    this.loading = true;
    this.searchModel.itemId=0;
    await this._commonCrudService.post("Item/filterAll", this.searchModel, ItemListModel).then(res => {
      this.model = res;
      this.loading = false;
    })


  }
  async onRowDblClick(e, data) {
    if (data) {
      this.ref.close(data);
    }
  }

  async filterAutoComplete(event) {
    console.log(event.query);
    if (event.query) {
      this.isAutoLoading = true;
      await this._commonCrudService.get("Item/AutoComplete?query="+event.query, LookupModel).then(res => {
        this.autoList = res.data;
        this.isAutoLoading = false;
      })
    }
    else {
      this.autoList = [];
    }
  }
  async onSelect(event){

    console.log(event);
    
    this.loading = true;

    let searchModel: ItemSearchModel = {
      itemId:event.id,
      storeId:0,
      vendorId: 0,
      vendorCode: '',
      itemCode: '',
      itemName: '',
      isNewAdded: 0,
      isNewStocked: 0,
      hasPromotion: 0,
      Take: 20,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: {
        Property: "itemId",
        Order: "desc"
      },
      isActive: 0,
      publicPrice: 0,
      clientPrice: 0,
    TermBy:""

    } as ItemSearchModel

    if(+this.config.data.storeId>0){
      searchModel.storeId= +this.config.data.storeId
    }

    await this._commonCrudService.get("Item/AutoComplete?query="+event.query, LookupModel).then(res => {
      this.model = res;
      this.loading = false;
    })
  }



  choose_Vendor() {
    var ref = this.dialogService.open(ChooserVendorComponent, {
      header: this.CHOOSE,
      width: '600px',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((ven: VendorListModel) => {
      if (ven) {
        this.searchModel.vendorCode = ven.vendorCode;
        this.searchModel.vendorId = ven.vendorId;

      }
    });
  }
  clear_Vendor() {
    this.searchModel.vendorCode = '';
    this.searchModel.vendorId = 0;
  }

  showPromotion(itemCode) {
    if (itemCode ) {

      this._commonCrudService.get(`ItemPromotion/getByItem?ItemCode=${itemCode}`,PromotionModel).then(res => {
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
}
