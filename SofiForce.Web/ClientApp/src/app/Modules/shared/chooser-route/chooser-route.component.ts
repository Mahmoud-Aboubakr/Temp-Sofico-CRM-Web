import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';


import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { RouteSetupListModel } from 'src/app/core/Models/ListModels/RouteSetupListModel';
import { RouteSetupSearchModel } from 'src/app/core/Models/SearchModels/RouteSetupSearchModel';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { ChooserBranchComponent } from '../chooser-branch/chooser-branch.component';
import { TranslateService } from '@ngx-translate/core';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';


@Component({
  selector: 'app-chooser-route',
  templateUrl: './chooser-route.component.html',
  styleUrls: ['./chooser-route.component.scss']
})
export class ChooserRouteComponent implements OnInit {


  model: ResponseModel<RouteSetupListModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: []
  };

  selected={} as RouteSetupListModel;

  searchModel: RouteSetupSearchModel = {
    branchId: 0,
    routeTypeId: 0,
    branchCode: '',
    routeTypeCode: '',
    isActive: 0,
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
  routeTypes:LookupModel[]=[];
  CHOOSE='';
  constructor(
    private ref: DynamicDialogRef, 
    private _translateService: TranslateService,
    private messageService: MessageService,
    private config: DynamicDialogConfig,
    private dialogService: DialogService,
    private _commonCrudService : CommonCrudService,
    private _translationLoaderService: TranslationLoaderService,) { 
    this._translationLoaderService.loadTranslations(english, arabic);

    if (this.config.data) {
        this.searchModel= this.config.data.searchModel;
    }
  }

  async ngOnInit() {
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });
    this._commonCrudService.get("RouteType/GetAll",LookupModel).then(res => {
      this.routeTypes = res.data;
      this.routeTypes.unshift({id:0,name:'--',code:'0'});
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

    await this._commonCrudService.post("RouteSetup/Filter", this.searchModel, RouteSetupListModel).then(res => {
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
      await this._commonCrudService.post("RouteSetup/Filter", this.searchModel, RouteSetupListModel).then(res => {
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

    await this._commonCrudService.post("RouteSetup/Filter", this.searchModel, RouteSetupListModel).then(res => {
      this.model = res;
      this.loading = false;
    })

   
  }
  async advancedClear() {
    this.first=0;
    this.loading = true;
    await this._commonCrudService.post("RouteSetup/Filter", this.searchModel, RouteSetupListModel).then(res => {
      this.model = res;
      this.loading = false;
    })

   
  }
  async onRowDblClick(e,data){
    if(data){
      this.ref.close(data);
    }
  }

  Chooser_Branch() {
    var ref = this.dialogService.open(ChooserBranchComponent, {
      header: this.CHOOSE,
      width: '600px',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((re) => {
      this.searchModel.branchCode = re.branchCode;
      this.searchModel.branchId = re.branchId;
    });
  }
  Clear_Branch(){
    this.searchModel.branchCode = '';
    this.searchModel.branchId = 0;
  }


}
