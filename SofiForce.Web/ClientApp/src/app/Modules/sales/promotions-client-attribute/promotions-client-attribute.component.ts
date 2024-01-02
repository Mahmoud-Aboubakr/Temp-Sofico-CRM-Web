import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { TranslateService } from '@ngx-translate/core';

import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';

import { BooleanService } from 'src/app/core/services/Boolean.Service';
import { ManagePromotionTypeComponent } from '../components/manage-promotion-type/manage-promotion-type.component';


import { PromtionCriteriaClientAttrModel } from 'src/app/core/Models/EntityModels/PromtionCriteriaClientAttrModel';
import { PromtionCriteriaClientAttrSearchModel } from 'src/app/core/Models/SearchModels/PromtionCriteriaClientAttrSearchModel';
import { ManagePromotionClientAttrComponent } from '../components/manage-promotion-client-attr/manage-promotion-client-attr.component';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-promotions-client-attribute',
  templateUrl: './promotions-client-attribute.component.html',
  styleUrls: ['./promotions-client-attribute.component.scss']
})
export class PromotionsClientAttributeComponent implements OnInit {


  gridModel: ResponseModel<PromtionCriteriaClientAttrModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }

  searchModel: PromtionCriteriaClientAttrSearchModel = {
    isActive: 0,
    isCustom: 0,
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    TermBy:""

  }

  advanced = false;
  isLoading = false;
  actions = false;

  first = 0;
  items: MenuItem[];
  menuItems: MenuItem[];
  selected: PromtionCriteriaClientAttrModel;

  status: LookupModel[];
  terminationReaons: LookupModel[];
  agentTypes: LookupModel[];

  CREATE_NEW_HEADER = '';
  EDIT_HEADER = '';
  REP_STC = '';
  USER_ACCRESS = '';
  CHOOSE = '';


  isCustoms: LookupModel[] = [];


  constructor(
    private _AppMessageService: AppMessageService,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _BooleanService: BooleanService,
    private _commonCrudService : CommonCrudService,

  ) {
    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Ad New Promotion').subscribe((res) => { this.CREATE_NEW_HEADER = res });
    this._translateService.get('Manage').subscribe((res) => { this.EDIT_HEADER = res });
    this._translateService.get('Promotion Statistics').subscribe((res) => { this.REP_STC = res });
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });

    
  }

  ngOnInit(): void {



    this.menuItems = [
      {
        label: 'View',
        icon: 'pi pi-fw pi-eye',
        command: (e) => this.manage('v')
      },
      {
        label: 'Edit',
        icon: 'pi pi-fw pi-pencil',
        command: (e) => this.manage('e')
      },
      {
        label: 'Delete',
        icon: 'pi pi-fw pi-times',
        command: (e) => this.manage('d')
      },

    ];



    this._BooleanService.GetAll(localStorage.getItem('lan')).then(res => {
      this.status = res;
      this.isCustoms=res;
    })



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

    await this._commonCrudService.post("PromtionCriteriaClientAttr/filter", this.searchModel, PromtionCriteriaClientAttrModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._commonCrudService.post("PromtionCriteriaClientAttr/filter", this.searchModel, PromtionCriteriaClientAttrModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }

  async reloadFilter() {
    this.isLoading = true;
    await this._commonCrudService.post("PromtionCriteriaClientAttr/filter", this.searchModel, PromtionCriteriaClientAttrModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.searchModel.Skip = 0;
    await this._commonCrudService.post("PromtionCriteriaClientAttr/filter", this.searchModel, PromtionCriteriaClientAttrModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel = {

      isActive: 0,
      Take: 30,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: undefined,
    TermBy:""


    } as PromtionCriteriaClientAttrSearchModel;
  }

  async onSelectionChange(event) {
    this.refreshMenu();
  }
  refreshMenu() {
   
  }
  async manage(mode) {

    if (mode == 'n') {

      var ref = this.dialogService.open(ManagePromotionClientAttrComponent, {
        header: this.EDIT_HEADER,
        data: { clientAttributeId: 0 },
        width: '600px',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe(() => {
        this.selected = null;
        this.reloadFilter();
        this.refreshMenu();
      });
    }

    if (mode == 'v') {
      if (this.selected != null && this.selected.clientAttributeId > 0) {
        var ref = this.dialogService.open(ManagePromotionClientAttrComponent, {
          header: this.EDIT_HEADER,
          data: { clientAttributeId: this.selected.clientAttributeId, editMode: 'v' },
          width: '500px',
          contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
          baseZIndex: 10000
        });
        ref.onClose.subscribe(() => {
          this.selected = null;
          this.reloadFilter();
          this.refreshMenu();
        });
      }

    }

    if (mode == 'e') {
      if (this.selected != null && this.selected.clientAttributeId > 0) {
        var ref = this.dialogService.open(ManagePromotionClientAttrComponent, {
          header: this.EDIT_HEADER,
          data: { clientAttributeId: this.selected.clientAttributeId },
          width: '500px',
          contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
          baseZIndex: 10000
        });
        ref.onClose.subscribe(() => {
          this.selected = null;
          this.reloadFilter();
          this.refreshMenu();
        });
      }
    }

    if (mode == 'd') {

      if (this.selected != null && this.selected.clientAttributeId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;
            let model = {} as PromtionCriteriaClientAttrModel;
            model.clientAttributeId = this.selected.clientAttributeId;
              this._commonCrudService.post("PromtionCriteriaClientAttr/Delete", model, PromtionCriteriaClientAttrModel).then(res => {
              this.advancedFilter();
              this.refreshMenu();
              this.isLoading = false;

              if (res.succeeded == true) {
                this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });
              }
              else {
                this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
              }

            })
          },
          reject: () => {
            //reject action
          }
        });
      }
    }

  }
}
