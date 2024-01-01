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
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-promotion-item-list',
  templateUrl: './promotion-item-list.component.html',
  styleUrls: ['./promotion-item-list.component.scss']
})
export class PromotionItemListComponent implements OnInit {


  @Input() take = 20;
  @Input() itemId = 0;
  @Input() promotionId = 0;
  @Input() isPopup = false;


  gridModel: ResponseModel<ItemPromotionAllListModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }

  searchModel: ItemPromotionAllSearchModel = {
    itemId: 0,
    promotionId: 0,
    isActive: 0,
    promotionCode: '',
    itemCode: '',
    Take: 0,
    Skip: 0,
    Term: '',
    TermBy: '',
    FilterBy: [],
    SortBy: undefined
  }

  advanced = false;
  showExtend = false;
  isLoading = false;
  isLoadingExtend = false;
  showFilter=true;

  actions = false;

  first = 0;
  items: MenuItem[];
  menuItems: MenuItem[];

  selected: ItemPromotionAllListModel


  CREATE_NEW_HEADER = '';
  EDIT_HEADER = '';
  REP_STC = '';
  USER_ACCRESS = '';
  CHOOSE = '';

  searchBy: LookupModel[] = [
    {id:1,code:'clientCode',name:'Client'},
    {id:2,code:'promotionCode',name:'Promotion'},
    {id:3,code:'invoiceCode',name:'Invoice'},

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

    private _commonCrudService : CommonCrudService,
    private config: DynamicDialogConfig,

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
    if (this.take > 0)
      this.searchModel.Take = this.take;

    console.log(this.searchModel);

    this.menuItems = [
      {
        label: 'View Promotion',
        icon: 'pi pi-fw pi-eye',
        command: (e) => this.manage('v')
      },
    ];


  }

  OnTermChange(arg){
    localStorage.setItem("promotion-orders-list.component.termBy",arg.value);
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

    await this._commonCrudService.post("Item/ItemPromotion", this.searchModel,ItemPromotionAllListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._commonCrudService.post("Item/ItemPromotion", this.searchModel,ItemPromotionAllListModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {
    this.isLoading = true;
    await this._commonCrudService.post("Item/ItemPromotion", this.searchModel,ItemPromotionAllListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.searchModel.Skip = 0;
    await this._commonCrudService.post("Item/ItemPromotion", this.searchModel,ItemPromotionAllListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel = {

      itemId: 0,
      promotionId: 0,
      isActive: 0,
      promotionCode: '',
      itemCode: '',
      Take: 0,
      Skip: 0,
      Term: '',
      TermBy: '',
      FilterBy: [],
      SortBy: undefined

    };
  }

  async onSelectionChange(event) {
    this.refreshMenu();
  }
  refreshMenu() {
  }
  async manage(mode) {

    if (mode == 'v') {
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

    if (mode == 'download') {
      this.isLoading = true;
      (await this._commonCrudService.postFile("Item/itemPromotionDownload",this.searchModel)).subscribe((data: any) => {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "ItemPromotion_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);


        this.isLoading = false;
      })
    }
    

  }

}
