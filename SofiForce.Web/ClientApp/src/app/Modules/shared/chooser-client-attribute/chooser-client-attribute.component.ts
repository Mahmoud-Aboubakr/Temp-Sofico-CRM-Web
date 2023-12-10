import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { TranslateService } from '@ngx-translate/core';
import { RouteTypeService } from 'src/app/core/services/RouteType.Service';
import { ClientGroupSearchModel } from 'src/app/core/Models/SearchModels/ClientGroupSearchModel';
import { ClientGroupService } from 'src/app/core/services/ClientGroup.Service';
import { ClientGroupListModel } from 'src/app/core/Models/ListModels/ClientGroupListModel';
import { PromtionCriteriaClientAttrService } from 'src/app/core/services/promotion/PromtionCriteriaClientAttr.Service';
import { PromotionClientAttributeSearchModel } from 'src/app/core/Models/SearchModels/PromotionClientAttributeSearchModel';
import { PromtionCriteriaClientAttrModel } from 'src/app/core/Models/EntityModels/PromtionCriteriaClientAttrModel';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-chooser-client-attribute',
  templateUrl: './chooser-client-attribute.component.html',
  styleUrls: ['./chooser-client-attribute.component.scss']
})
export class ChooserClientAttributeComponent implements OnInit {



  model: ResponseModel<PromtionCriteriaClientAttrModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: []
  };

  selected={} as PromtionCriteriaClientAttrModel;

  searchModel: PromotionClientAttributeSearchModel = {
    Take: 0,
    Skip: 0,
    Term: '',
    TermBy: '',
    FilterBy: [],
    SortBy: undefined
  }

  advanced=false;
  loading = false;
  first=0;
  routeTypes:LookupModel[]=[];
  CHOOSE='';
  constructor(
    private ref: DynamicDialogRef, 
    private _translateService: TranslateService,
    private messageService: MessageService,
    private config: DynamicDialogConfig,
    private dialogService: DialogService,
    private _PromtionCriteriaClientAttrService: PromtionCriteriaClientAttrService,
    private _commonCrudService : CommonCrudService,
    private _translationLoaderService: TranslationLoaderService,) { 
    this._translationLoaderService.loadTranslations(english, arabic);

    if (this.config.data) {
        this.searchModel= this.config.data.searchModel;
    }
  }

  async ngOnInit() {
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });

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

    await this._commonCrudService.post("PromtionCriteriaClientAttr/filter", this.searchModel, PromtionCriteriaClientAttrModel).then(res => {
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
      await this._commonCrudService.post("PromtionCriteriaClientAttr/filter", this.searchModel, PromtionCriteriaClientAttrModel).then(res => {
        this.model = res;
        this.loading = false;
      })
    }

  }

  async advancedFilter() {
    this.loading = true;
    this.first=0;
    this.searchModel.Skip=0;
    this.searchModel.Take=25;

    await this._commonCrudService.post("PromtionCriteriaClientAttr/filter", this.searchModel, PromtionCriteriaClientAttrModel).then(res => {
      this.model = res;
      this.loading = false;
    })

   
  }
  async advancedClear() {
    this.first=0;
    this.loading = true;
    await this._commonCrudService.post("PromtionCriteriaClientAttr/filter", this.searchModel, PromtionCriteriaClientAttrModel).then(res => {
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
