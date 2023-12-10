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
import { TerminationReasonService } from 'src/app/core/services/TerminationReason.Service';
import { BooleanService } from 'src/app/core/services/Boolean.Service';
import { RepresentativeKindService } from 'src/app/core/services/RepresentativeKind.Service';
import { ManagePromotionTypeComponent } from '../components/manage-promotion-type/manage-promotion-type.component';
import { PromotionTypeModel } from 'src/app/core/Models/EntityModels/PromotionTypeModel';
import { PromotionTypeSearchModel } from 'src/app/core/Models/SearchModels/PromotionTypeSearchModel';
import { PromotionTypeService } from 'src/app/core/services/promotion/PromotionType.Service';
import { PromotionInputService } from 'src/app/core/services/promotion/PromotionInput.Service';
import { PromotionOutputService } from 'src/app/core/services/promotion/PromotionOutput.Service';
import { MenuService } from 'src/app/core/services/Menu.Service';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-promotions-condition',
  templateUrl: './promotions-condition.component.html',
  styleUrls: ['./promotions-condition.component.scss']
})
export class PromotionsConditionComponent implements OnInit {


  gridModel: ResponseModel<PromotionTypeModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }

  searchModel: PromotionTypeSearchModel = {
    promotionInputId: 0,
    promotionOutputId: 0,
    isActive: 0,
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
  selected: PromotionTypeModel;

  status: LookupModel[];
  terminationReaons: LookupModel[];
  agentTypes: LookupModel[];

  CREATE_NEW_HEADER = '';
  EDIT_HEADER = '';
  REP_STC = '';
  USER_ACCRESS = '';
  CHOOSE = '';


  inputs: LookupModel[] = [];
  outputs: LookupModel[] = [];
  
  constructor(
    private _AppMessageService: AppMessageService,
    private _PromotionTypeService: PromotionTypeService,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _TerminationReasonService: TerminationReasonService,
    private _RepresentativeKindService: RepresentativeKindService,
    private _BooleanService: BooleanService,
    private _PromotionInputService: PromotionInputService,
    private _PromotionOutputService: PromotionOutputService,
    // private _MenuService:MenuService,
    private _commonCrudService : CommonCrudService,
  ) {
    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Ad New Promotion').subscribe((res) => { this.CREATE_NEW_HEADER = res });
    this._translateService.get('Edit/View Promotion').subscribe((res) => { this.EDIT_HEADER = res });
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

    // this._RepresentativeKindService.GetAll().then(res=>{
       this._commonCrudService.get("RepresentativeKind/GetAll", LookupModel).then(res=>{
      this.agentTypes=res.data;
      this.agentTypes.unshift({id:0,code:'0',name:'--'});

    })

    // this._TerminationReasonService.GetAll().then(res=>{
      this._commonCrudService.get("TerminationReason/GetAll", LookupModel).then(res=>{
      this.terminationReaons=res.data;
      this.terminationReaons.unshift({id:0,code:'0',name:'--'});
    })

    this._BooleanService.GetAll(localStorage.getItem('lan')).then(res=>{
      this.status=res;
    })

    // this._PromotionInputService.GetAll().then(res => {
      this._commonCrudService.get("PromotionInput/GetAll", LookupModel).then(res => {
      if (res.succeeded = true) {
        this.inputs = res.data;
      }
      this.inputs.unshift({ id: 0, code: '--', name: '--' });
    })

    // this._PromotionOutputService.GetAll().then(res => {
      this._commonCrudService.get("PromotionOutput/GetAll", LookupModel).then(res => {
      if (res.succeeded = true) {
        this.outputs = res.data;
      }
      this.outputs.unshift({ id: 0, code: '--', name: '--' });
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

    // await this._PromotionTypeService.Filter(this.searchModel).then(res => {
      await this._commonCrudService.post("PromotionType/filter", this.searchModel, PromotionTypeModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })

  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
    //   await this._PromotionTypeService.Filter(this.searchModel).then(res => {
      await this._commonCrudService.post("PromotionType/filter", this.searchModel, PromotionTypeModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }

  async reloadFilter() {
    this.isLoading = true;
  //   await this._PromotionTypeService.Filter(this.searchModel).then(res => {
    await this._commonCrudService.post("PromotionType/filter", this.searchModel, PromotionTypeModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.searchModel.Skip = 0;
  //   await this._PromotionTypeService.Filter(this.searchModel).then(res => {
    await this._commonCrudService.post("PromotionType/filter", this.searchModel, PromotionTypeModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel = {

      promotionInputId: 0,
      promotionOutputId: 0,
      isActive: 0,
      Take: 30,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: undefined,
    TermBy:""


    } as PromotionTypeSearchModel;
  }

  async onSelectionChange(event) {
    this.refreshMenu();
  }
  refreshMenu(){
    this.menuItems[1].disabled=false;
    this.menuItems[2].disabled=false;

    if(this.selected && this.selected.canEdit!=true)
    {
      this.menuItems[1].disabled=true;
    }
    if(this.selected && this.selected.canDelete!=true)
    {
      this.menuItems[2].disabled=true;
    }
  }
  async manage(mode) {

    if (mode == 'n') {

      var ref = this.dialogService.open(ManagePromotionTypeComponent, {
        header: this.EDIT_HEADER,
        data: { promotionTypeId: 0 },
        width: '400px',
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
      if (this.selected != null && this.selected.promotionTypeId > 0) {
        var ref = this.dialogService.open(ManagePromotionTypeComponent, {
          header: this.EDIT_HEADER,
          data: { promotionTypeId: this.selected.promotionTypeId,editMode:'v' },
          width: '400px',
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
      if (this.selected != null && this.selected.promotionTypeId > 0) {
        var ref = this.dialogService.open(ManagePromotionTypeComponent, {
          header: this.EDIT_HEADER,
          data: { promotionTypeId: this.selected.promotionTypeId },
          width: '400px',
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

      if (this.selected != null && this.selected.promotionTypeId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;
            let model = {} as PromotionTypeModel;
            model.promotionTypeId = this.selected.promotionTypeId;
            // this._PromotionTypeService.Delete(model).then(res => {
              this._commonCrudService.post("PromotionType/Delete", model, PromotionTypeModel).then(res => {
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
