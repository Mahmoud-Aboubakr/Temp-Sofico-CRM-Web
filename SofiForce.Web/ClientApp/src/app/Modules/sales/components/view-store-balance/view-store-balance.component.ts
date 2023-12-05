import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { MessageService, PrimeNGConfig } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { ItemStoreTotalService } from 'src/app/core/services/ItemStoreTotal.Service';
import { ItemStoreTotalSearchModel } from 'src/app/core/Models/SearchModels/ItemStoreTotalSearchModel';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { ItemStoreTotalListModel } from 'src/app/core/Models/ListModels/ItemStoreTotalListModel';
import { ChooserBatchComponent } from 'src/app/Modules/shared/chooser-batch/chooser-batch.component';

@Component({
  selector: 'app-view-store-balance',
  templateUrl: './view-store-balance.component.html',
  styleUrls: ['./view-store-balance.component.scss']
})
export class ViewStoreBalanceComponent implements OnInit {

  gridModel: ResponseModel<ItemStoreTotalListModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }

  searchModel: ItemStoreTotalSearchModel = {
    vendorId: 0,
    vendorCode: '',
    itemId: 0,
    itemCode: '',
    branchId: 0,
    branchCode: '',
    storeId: 0,
    storeCode: '',
    Take: 20,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    TermBy:""

  }


  isLoading = false;


  storeId=0;
  BATCHS='';
  constructor(
    private _ItemStoreTotalService: ItemStoreTotalService,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private _AppMessageService: AppMessageService,
    private messageService: MessageService,
    private config: DynamicDialogConfig,
  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Batchs Details').subscribe((res) => { this.BATCHS = res });


    if (this.config.data.itemId) {
      this.searchModel.itemId = this.config.data.itemId
    }
    if (this.config.data.storeId) {
      this.storeId = this.config.data.storeId
    }
  }

  ngOnInit(): void {

  
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

    await this._ItemStoreTotalService.Filter(this.searchModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._ItemStoreTotalService.Filter(this.searchModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {

    this.isLoading = true;

    await this._ItemStoreTotalService.Filter(this.searchModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    this.searchModel.Skip = 0;
    await this._ItemStoreTotalService.Filter(this.searchModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel = {
      vendorId: 0,
      vendorCode: '',
      itemId: 0,
      itemCode: '',
      branchId: 0,
      branchCode: '',
      storeId: 0,
      storeCode: '',
      Take: 0,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: undefined,
    TermBy:""

    }
  }

  showBatchs(branchId,itemId,storeId){
 if (itemId > 0 && storeId > 0 && branchId>0) {

      var ref = this.dialogService.open(ChooserBatchComponent, {
        data: {
          itemId: itemId,
          branchId: branchId,
          storeId: storeId
        },
        header: this.BATCHS,
        width: '800px',
        modal: true,
        height: "90%"
      });
    }

  }
}
