import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';


import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { StoreListModel } from 'src/app/core/Models/ListModels/StoreListModel';
import { StoreSearchModel } from 'src/app/core/Models/SearchModels/StoreSearchModel';
import { StoreService } from 'src/app/core/services/Store.Service';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { ChooserBranchComponent } from '../chooser-branch/chooser-branch.component';
import { TranslateService } from '@ngx-translate/core';


@Component({
  selector: 'app-chooser-store',
  templateUrl: './chooser-store.component.html',
  styleUrls: ['./chooser-store.component.scss']
})
export class ChooserStoreComponent implements OnInit {


  model: ResponseModel<StoreListModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: []
  };

  selected={} as StoreListModel;

  searchModel: StoreSearchModel = {
    branchId: 0,
    branchCode: '',
    storeTypeId: 0,
    Take: 20,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    isActive: 0,
    isOrder: 0,
    storeMode: 0,
    TermBy:""
  }

  advanced=false;
  loading = false;
  first=0;

  CHOOSE='';

  constructor(
    private dialogService: DialogService,
    private _StoreService: StoreService,
    private ref: DynamicDialogRef, 
    private messageService: MessageService,
    private config: DynamicDialogConfig,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,) { 
    this._translationLoaderService.loadTranslations(english, arabic);


    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });

    if (this.config.data) {
        this.searchModel= this.config.data.searchModel;
    }
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

    await this._StoreService.Filter(this.searchModel).then(res => {
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
      await this._StoreService.Filter(this.searchModel).then(res => {
        this.model = res;
        this.loading = false;
      })
    }

  }

  async advancedFilter() {
    this.loading = true;
    this.first=0;
    this.searchModel.Skip=0;
    await this._StoreService.Filter(this.searchModel).then(res => {
      this.model = res;
      this.loading = false;
    })

   
  }
  async advancedClear() {
    this.first=0;
    this.loading = true;
    await this._StoreService.Filter(this.searchModel).then(res => {
      this.model = res;
      this.loading = false;
    })

   
  }
  async onRowDblClick(e,data){
    if(data){
      this.ref.close(data);
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
    this.searchModel.branchCode = '';
    this.searchModel.branchId = 0;
  }

}
