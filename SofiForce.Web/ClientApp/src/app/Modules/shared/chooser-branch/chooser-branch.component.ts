import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';


import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { BranchSearchModel } from 'src/app/core/Models/SearchModels/BranchSearchModel';
import { BranchService } from 'src/app/core/services/Branch.Service';

@Component({
  selector: 'app-chooser-branch',
  templateUrl: './chooser-branch.component.html',
  styleUrls: ['./chooser-branch.component.scss']
})
export class ChooserBranchComponent implements OnInit {


  model: ResponseModel<BranchListModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: []
  };

  selected={} as BranchListModel;

  searchModel: BranchSearchModel = {
    Take: 20,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    TermBy:""

  }

  advanced=false;
  loading = false;
  first=0;
  constructor(
    private _BranchService: BranchService,
    private ref: DynamicDialogRef, 
    private messageService: MessageService,
    private config: DynamicDialogConfig,
    private _translationLoaderService: TranslationLoaderService,) { 
    this._translationLoaderService.loadTranslations(english, arabic);


  }

  async ngOnInit() {

    this.loading = true;
    await this._BranchService.Filter(this.searchModel).then(res => {
      this.model = res;
      this.loading = false;
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

    await this._BranchService.Filter(this.searchModel).then(res => {
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
      await this._BranchService.Filter(this.searchModel).then(res => {
        this.model = res;
        this.loading = false;
      })
    }

  }

  async advancedFilter() {
    this.loading = true;
    this.first=0;
    this.searchModel.Skip=0;
    await this._BranchService.Filter(this.searchModel).then(res => {
      this.model = res;
      this.loading = false;
    })

   
  }
  async advancedClear() {
    this.first=0;
    this.loading = true;
    await this._BranchService.Filter(this.searchModel).then(res => {
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
