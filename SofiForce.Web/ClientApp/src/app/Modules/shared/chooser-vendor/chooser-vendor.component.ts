import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';


import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { ItemListModel } from 'src/app/core/Models/ListModels/ItemListModel';

import { VendorService } from 'src/app/core/services/Vendor.Service';
import { VendorListModel } from 'src/app/core/Models/ListModels/VendorListModel';
import { VendorSearchModel } from 'src/app/core/Models/SearchModels/VendorSearchModel';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-chooser-vendor',
  templateUrl: './chooser-vendor.component.html',
  styleUrls: ['./chooser-vendor.component.scss']
})
export class ChooserVendorComponent implements OnInit {


  model: ResponseModel<VendorListModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: []
  };

  selected={} as ItemListModel;

  searchModel: VendorSearchModel = {
    vendorGroupId: 0,
    Take: 20,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: {
      Order:"asc",
      Property:"vendorCode"
    },
    TermBy:""

  }

  advanced=false;
  loading = false;
  first=0;
  constructor(
    
    private _VendorService: VendorService,
    private ref: DynamicDialogRef, 
    private messageService: MessageService,
    private config: DynamicDialogConfig,
    private _commonCrudService : CommonCrudService,
    private _translationLoaderService: TranslationLoaderService,) { 
    this._translationLoaderService.loadTranslations(english, arabic);

    
  }

  async ngOnInit() {
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

    await this._commonCrudService.post("Vendor/filter", this.searchModel,VendorListModel).then(res => {
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
      await this._commonCrudService.post("Vendor/filter", this.searchModel,VendorListModel).then(res => {
        this.model = res;
        this.loading = false;
      })
    }

  }

  async advancedFilter() {
    this.loading = true;
    this.first=0;
    this.searchModel.Skip=0;
    await this._commonCrudService.post("Vendor/filter", this.searchModel,VendorListModel).then(res => {
      this.model = res;
      this.loading = false;
    })

   
  }
  async advancedClear() {
    this.first=0;
    this.loading = true;
    await this._commonCrudService.post("Vendor/filter", this.searchModel,VendorListModel).then(res => {
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
