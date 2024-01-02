import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';


import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { ItemStoreListModel } from 'src/app/core/Models/ListModels/ItemStoreListModel';
import { ItemStoreSearchModel } from 'src/app/core/Models/SearchModels/ItemStoreSearchModel';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-chooser-batch',
  templateUrl: './chooser-batch.component.html',
  styleUrls: ['./chooser-batch.component.scss']
})
export class ChooserBatchComponent implements OnInit {

  model: ResponseModel<ItemStoreListModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: []
  };

  selected={} as ItemStoreListModel;

  searchModel: ItemStoreSearchModel = {
    vendorId: 0,
    itemId: 0,
    branchId: 0,
    storeId: 0,
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: {
      Order:"asc",
      Property:"expireDate",
    },
    expireDate: undefined,
    isActive: 0,
    available: 0,
    TermBy:""

  }

  advanced=false;
  loading = false;
  first=0;
  constructor(
    private _commonCrudService : CommonCrudService,
    private ref: DynamicDialogRef, 
    private messageService: MessageService,
    private config: DynamicDialogConfig,
    private _translationLoaderService: TranslationLoaderService,) { 
    this._translationLoaderService.loadTranslations(english, arabic);

    if (this.config.data) {
      if(+this.config.data.vendorId>0){
        this.searchModel.vendorId= +this.config.data.vendorId
      }

      if(+this.config.data.itemId>0){
        this.searchModel.itemId= +this.config.data.itemId
      }

      if(+this.config.data.storeId>0){
        this.searchModel.storeId= +this.config.data.storeId
      }

      if(+this.config.data.isActive>0){
        this.searchModel.isActive= +this.config.data.isActive
      }
      
      if(+this.config.data.available>0){
        this.searchModel.available= +this.config.data.available
      }

    }
  }

  async ngOnInit() {

  }

  async filter(event) {
    console.log(event);
    this.loading = true;
    this.searchModel.Skip = event.first;
    this.searchModel.Take = event.rows;


    if (event.sortField && event.sortField!=undefined) {
      this.searchModel.SortBy.Property = event.sortField;
      if (event.sortOrder == 1) {
        this.searchModel.SortBy.Order = "asc";
      }
      else {
        this.searchModel.SortBy.Order = "desc";

      }
    }

    await this._commonCrudService.post("ItemStore/filter",this.searchModel,ItemStoreListModel).then(res => {
      this.model = res;
      this.loading = false;
      if(this.model.succeeded==false){
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Internal Server Error , call system administrator' });
      }
    })

   
  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first=0;
      this.searchModel.Skip=0;
      this.loading = true;
      await this._commonCrudService.post("ItemStore/filter",this.searchModel,ItemStoreListModel).then(res => {
        this.model = res;
        this.loading = false;
      })
    }

  }

  async advancedFilter() {
    this.loading = true;
    this.first=0;
    this.searchModel.Skip=0;
    await this._commonCrudService.post("ItemStore/filter",this.searchModel,ItemStoreListModel).then(res => {
      this.model = res;
      this.loading = false;
    })

   
  }
  async advancedClear() {
    this.first=0;
    this.loading = true;
    await this._commonCrudService.post("ItemStore/filter",this.searchModel,ItemStoreListModel).then(res => {
      this.model = res;
      this.loading = false;
    })

   
  }
  async onRowDblClick(e,data){
    if(data){
      this.ref.close(data);
    }
  }

}
