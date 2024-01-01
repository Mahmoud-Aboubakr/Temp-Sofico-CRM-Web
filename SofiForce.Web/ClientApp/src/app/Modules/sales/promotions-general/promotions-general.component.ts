import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { TranslateService } from '@ngx-translate/core';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { RepresentitiveStatisticsComponent } from '../components/representitive-statistics/representitive-statistics.component';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { BooleanService } from 'src/app/core/services/Boolean.Service';
import { ManagePromotionComponent } from '../components/manage-promotion/manage-promotion.component';
import { PromotionModel } from 'src/app/core/Models/EntityModels/PromotionModel';
import { PromotionSearchModel } from 'src/app/core/Models/SearchModels/PromotionSearchModel';
import { UtilService } from 'src/app/core/services/util.service';
import { ManagePromotionUploadComponent } from '../components/manage-promotion-upload/manage-promotion-upload.component';
import { PromotionOrdersListComponent } from '../components/promotion-orders-list/promotion-orders-list.component';
import { PromotionItemListComponent } from '../components/promotion-item-list/promotion-item-list.component';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';
@Component({
  selector: 'app-promotions-general',
  templateUrl: './promotions-general.component.html',
  styleUrls: ['./promotions-general.component.scss']
})
export class PromotionsGeneralComponent implements OnInit {


  promotionTypes: LookupModel[] = [];
  promotionGroups: LookupModel[] = [];
  promotionColors: LookupModel[] = [];
  repeatTypes: LookupModel[] = [];
  IsActives: LookupModel[] = [];

  gridModel: ResponseModel<PromotionModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }

  searchModel: PromotionSearchModel = {
    companyId: 0,
    PromotionCategoryId: 1,
    validFrom: undefined,
    validTo: undefined,
    isActive: 0,
    isApproved: 0,
    promotionTypeId: 0,
    priority: 0,
    repeats: 0,
    promotionGroupId: 0,
    repeatTypeId:0,
    displayOrder: 0,
    enableNotification: 0,
    notificationDate: undefined,
    notificationDone: 0,
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    TermBy:"",
    vendorCode:"",

  }

  advanced = false;
  showExtend = false;
  isLoading = false;
  isLoadingExtend = false;

  actions = false;

  first = 0;
  items: MenuItem[];
  menuItems: MenuItem[];
  selected: PromotionModel = {
    validTo: this._UtilService.EndDay(new Date()),
    validFrom: this._UtilService.EndDay(new Date()),
  } as PromotionModel;
  extendModel: PromotionModel = {
    validTo: this._UtilService.EndDay(new Date()),

  } as PromotionModel;



  CREATE_NEW_HEADER = '';
  EDIT_HEADER = '';
  REP_STC = '';
  PROMOTION_INVOICE='';
  PROMOTION_ITEMS='';
  USER_ACCRESS = '';
  CHOOSE = '';


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
  ) {
    this._translationLoaderService.loadTranslations(english, arabic);

    this._translateService.get('Add New Promotion').subscribe((res) => { this.CREATE_NEW_HEADER = res });
    this._translateService.get('Edit/View Promotion').subscribe((res) => { this.EDIT_HEADER = res });
    this._translateService.get('Promotion Statistics').subscribe((res) => { this.REP_STC = res });
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });
    this._translateService.get('Promotion Invoices').subscribe((res) => { this.PROMOTION_INVOICE = res });
    this._translateService.get('Promotion Items').subscribe((res) => { this.PROMOTION_ITEMS = res });

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
      {
        separator: true,
      },
      {
        label: 'Activate',
        icon: 'pi pi-fw pi-check',
        command: (e) => this.manage('a')
      },
      {
        label: 'De-Activate',
        icon: 'pi pi-fw pi-replay',
        command: (e) => this.manage('da')
      },
      {
        label: 'Copy',
        icon: 'pi pi-fw pi-copy',
        command: (e) => this.manage('c')
      },
      {
        label: 'Extend',
        icon: 'fa fa-calendar',
        command: (e) => this.manage('x')
      },
      {
        separator: true,
      },
      {
        label: 'Promotion Invoices',
        icon: 'fa fa-th-list',
        command: (e) => this.manage('piv')
      },
      {
        label: 'Promotion Items',
        icon: 'fa fa-cube',
        command: (e) => this.manage('pim')
      },
      
    ];


    this._BooleanService.GetAll(localStorage.getItem('lan')).then(res => {
      this.IsActives = res;
    })

      this._commonCrudService.get("PromotionGroup/GetAll", LookupModel).then(res => {
      if (res.succeeded = true) {
        this.promotionGroups = res.data;
      }
      this.promotionGroups.unshift({ id: 0, code: '--', name: '--' });
    })

      this._commonCrudService.get("PromotionType/GetAll", LookupModel).then(res => {
      if (res.succeeded = true) {
        this.promotionTypes = res.data;
      }
      this.promotionTypes.unshift({ id: 0, code: '--', name: '--' });
    })

      this._commonCrudService.get("PromotionRepeatType/GetAll", LookupModel).then(res => {
      if (res.succeeded = true) {
        this.repeatTypes = res.data;
      }
      this.repeatTypes.unshift({ id: 0, code: '--', name: '--' });
    })



    this.promotionColors.push({ id: 1, code: 'FF0000', name: 'FF0000' });
    this.promotionColors.push({ id: 2, code: '00FF00', name: '00FF00' });
    this.promotionColors.push({ id: 3, code: '0000FF', name: '0000FF' });
    this.promotionColors.push({ id: 4, code: 'FFFF00', name: 'FFFF00' });
    this.promotionColors.push({ id: 5, code: 'FFD700', name: 'FFD700' });

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

      await this._commonCrudService.post("Promotion/filter", this.searchModel, PromotionModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })

  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._commonCrudService.post("Promotion/filter", this.searchModel, PromotionModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }
  }

  async reloadFilter() {
    this.isLoading = true;
    await this._commonCrudService.post("Promotion/filter", this.searchModel, PromotionModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.searchModel.Skip = 0;
    await this._commonCrudService.post("Promotion/filter", this.searchModel, PromotionModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel = {

      companyId: 0,
      PromotionCategoryId: 2,
      validFrom: undefined,
      validTo: undefined,
      isActive: 0,
      repeatTypeId:0,
      isApproved: 0,
      promotionTypeId: 0,
      priority: 0,
      repeats: 0,
      promotionGroupId: 0,
      displayOrder: 0,
      enableNotification: 0,
      notificationDate: undefined,
      notificationDone: 0,
      Take: 0,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: undefined,
    TermBy:"",
    vendorCode:"",


    };
  }

  async onSelectionChange(event) {
    this.refreshMenu();
  }
  refreshMenu() {
  }
  async manage(mode) {

    if (mode == 'n') {

      var ref = this.dialogService.open(ManagePromotionUploadComponent, {
        header: this.EDIT_HEADER,
        data: { promotionId: 0 },
        width: '400px',
        contentStyle: { "max-height": "600px", "height": "600px", "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe(() => {
        this.selected = null;
        this.reloadFilter();
        this.refreshMenu();
      });
    }

    if (mode == 'v') {

      var ref = this.dialogService.open(ManagePromotionComponent, {
        header: this.EDIT_HEADER,
        data: { promotionId: this.selected.promotionId, editMode: 'v' },
        width: '900px',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe(() => {
        this.selected = null;
        this.reloadFilter();
        this.refreshMenu();
      });
    }

    if (mode == 'piv') {
      var ref = this.dialogService.open(PromotionOrdersListComponent, {
        header: this.PROMOTION_INVOICE,
        data: { promotionId: this.selected.promotionId, take:20,isPopup:true },
        width: '1400px',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });
    }
    

    if (mode == 'pim') {
      var ref = this.dialogService.open(PromotionItemListComponent, {
        header: this.PROMOTION_ITEMS,
        data: { promotionId: this.selected.promotionId, take:20,isPopup:true },
        width: '1400px',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });
    }

    if (mode == 'e') {
      if (this.selected != null && this.selected.promotionId > 0) {
        var ref = this.dialogService.open(ManagePromotionComponent, {
          header: this.EDIT_HEADER,
          data: { promotionId: this.selected.promotionId },
          width: '900px',
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
    if (mode == 'c') {
      if (this.selected != null && this.selected.promotionId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;
            let model = {} as PromotionModel;
            model.promotionId = this.selected.promotionId;
              this._commonCrudService.post("Promotion/copy", model, PromotionModel).then(res => {
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

    if (mode == 'a') {

      if (this.selected != null && this.selected.promotionId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;
            let model = {} as PromotionModel;
            model.promotionId = this.selected.promotionId;
              this._commonCrudService.post("Promotion/activate", model, PromotionModel).then(res => {
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
    if (mode == 'da') {

      if (this.selected != null && this.selected.promotionId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;
            let model = {} as PromotionModel;
            model.promotionId = this.selected.promotionId;
              this._commonCrudService.post("Promotion/deActivate", model, PromotionModel).then(res => {
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
    if (mode == 'd') {

      if (this.selected != null && this.selected.promotionId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {
            
            this.isLoading = true;
            let model = {} as PromotionModel;
            model.promotionId = this.selected.promotionId;
              this._commonCrudService.post("Promotion/Delete", model, PromotionModel).then(res => {
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
    if (mode == 'x') {

      if (this.selected != null && this.selected.promotionId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {
            this.extendModel.validFrom = this._UtilService.LocalDate(this.selected.validFrom);
            this.extendModel.validTo = this._UtilService.LocalDate(this.selected.validTo);
            this.showExtend = true;

          },
          reject: () => {
            //reject action
          }
        });
      }
    }

    if (mode == 's') {
      if (this.selected != null && this.selected.promotionId > 0) {


        var ref = this.dialogService.open(RepresentitiveStatisticsComponent, {
          header: this.REP_STC,
          data: { promotionId: this.selected.promotionId },
          width: '70%',
          contentStyle: { "max-height": "600px", "height": "600px", "overflow": "auto" },
          baseZIndex: 10000
        });

        ref.onClose.subscribe(() => {
          this.selected = null;
          this.reloadFilter();
          this.refreshMenu();
        });

      }
    }

    if(mode=='t'){
      this.isLoading = true;
      (await this._commonCrudService.getFile("Promotion/template1")).subscribe((data: any) => {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "supplementaryTemplate";
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);


        this.isLoading = false;
      })
    }
  }
  extend() {
    if (this.extendModel.validTo < this.selected.validTo) {
      this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });
      return;
    }


    this.extendModel.promotionId = this.selected.promotionId;

    this.isLoadingExtend = true;
      this._commonCrudService.post("Promotion/extend", this.extendModel, PromotionModel).then(res => {
      this.showExtend = false;
      this.advancedFilter();
      this.refreshMenu();
      this.isLoadingExtend = false;

      if (res.succeeded == true) {
        this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });
      }
      else {
        this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
      }
    })
  }

}
