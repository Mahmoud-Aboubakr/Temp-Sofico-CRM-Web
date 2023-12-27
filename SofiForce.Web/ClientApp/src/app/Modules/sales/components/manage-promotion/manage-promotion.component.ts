import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { BranchService } from 'src/app/core/services/Branch.Service';
import { PromotionService } from 'src/app/core/services/promotion/Promotion.Service';
import { PromotionCriteriaService } from 'src/app/core/services/promotion/PromotionCriteria.Service';
import { PromotionCriteriaAttrService } from 'src/app/core/services/promotion/PromotionCriteriaAttr.Service';
import { PromotionCriteriaAttrCustomService } from 'src/app/core/services/promotion/PromotionCriteriaAttrCustom.Service';
import { PromotionGroupService } from 'src/app/core/services/promotion/PromotionGroup.Service';
import { PromotionInputService } from 'src/app/core/services/promotion/PromotionInput.Service';
import { PromotionMixGroupService } from 'src/app/core/services/promotion/PromotionMixGroup.Service';
import { PromotionOrderHistoryService } from 'src/app/core/services/promotion/PromotionOrderHistory.Service';
import { PromotionOutcomeService } from 'src/app/core/services/promotion/PromotionOutcome.Service';
import { PromotionOutputService } from 'src/app/core/services/promotion/PromotionOutput.Service';
import { PromotionTypeService } from 'src/app/core/services/promotion/PromotionType.Service';
import { PromtionCriteriaClientService } from 'src/app/core/services/promotion/PromtionCriteriaClient.Service';
import { PromtionCriteriaClientAttrService } from 'src/app/core/services/promotion/PromtionCriteriaClientAttr.Service';
import { PromtionCriteriaClientAttrCustomService } from 'src/app/core/services/promotion/PromtionCriteriaClientAttrCustom.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';


import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { PromotionModel } from 'src/app/core/Models/EntityModels/PromotionModel';
import { UtilService } from 'src/app/core/services/util.service';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { PromotionCriteriaModel } from 'src/app/core/Models/EntityModels/PromotionCriteriaModel';
import { PromotionOutcomeModel } from 'src/app/core/Models/EntityModels/PromotionOutcomeModel';
import { PromtionCriteriaClientModel } from 'src/app/core/Models/EntityModels/PromtionCriteriaClientModel';
import { PromotionMixGroupModel } from 'src/app/core/Models/EntityModels/PromotionMixGroupModel';
import { ManagePromotionCriteriaAttrComponent } from '../manage-promotion-criteria-attr/manage-promotion-criteria-attr.component';
import { ManagePromotionClientAttrComponent } from '../manage-promotion-client-attr/manage-promotion-client-attr.component';
import { ManagePromotionTypeComponent } from '../manage-promotion-type/manage-promotion-type.component';
import { PromtionCriteriaSalesManModel } from 'src/app/core/Models/EntityModels/PromtionCriteriaSalesManModel';
import { PromtionCriteriaSalesManService } from 'src/app/core/services/promotion/PromtionCriteriaSalesMan.Service';
import { PromtionCriteriaSalesManAttrService } from 'src/app/core/services/promotion/PromtionCriteriaSalesManAttr.Service';
import { ManagePromotionSalesManAttrComponent } from '../manage-promotion-salesman-attr/manage-promotion-salesman-attr.component';
import { PromotionCriteriaAttrModel } from 'src/app/core/Models/EntityModels/PromotionCriteriaAttrModel';
import { ChooserProductComponent } from 'src/app/Modules/shared/chooser-product/chooser-product.component';
import { ItemListModel } from 'src/app/core/Models/ListModels/ItemListModel';
import { ChooserVendorComponent } from 'src/app/Modules/shared/chooser-vendor/chooser-vendor.component';
import { VendorListModel } from 'src/app/core/Models/ListModels/VendorListModel';
import { ChooserItemGroupComponent } from 'src/app/Modules/shared/chooser-item-group/chooser-item-group.component';
import { ItemGroupModel } from 'src/app/core/Models/EntityModels/itemGroupModel';
import { ItemGroupListModel } from 'src/app/core/Models/ListModels/ItemGroupListModel';
import { PromtionCriteriaClientAttrModel } from 'src/app/core/Models/EntityModels/PromtionCriteriaClientAttrModel';
import { ChooserClientComponent } from 'src/app/Modules/shared/chooser-client/chooser-client.component';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { ChooserBranchComponent } from 'src/app/Modules/shared/chooser-branch/chooser-branch.component';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { ChooserClientTypeComponent } from 'src/app/Modules/shared/chooser-client-type/chooser-client-type.component';
import { ClientTypeListModel } from 'src/app/core/Models/ListModels/ClientTypeListModel';
import { ChooserPaymentTermComponent } from 'src/app/Modules/shared/chooser-payment-term/chooser-payment-term.component';
import { PaymentTermListModel } from 'src/app/core/Models/ListModels/PaymentTermListModel';
import { ChooserGovernerateComponent } from 'src/app/Modules/shared/chooser-governerate/chooser-governerate.component';
import { GovernerateListModel } from 'src/app/core/Models/ListModels/GovernerateListModel';
import { ChooserCityComponent } from 'src/app/Modules/shared/chooser-city/chooser-city.component';
import { CityListModel } from 'src/app/core/Models/ListModels/CityListModel';
import { ChooserLocationLevelComponent } from 'src/app/Modules/shared/chooser-location-level/chooser-location-level.component';
import { LocationLevelListModel } from 'src/app/core/Models/ListModels/LocationLevelListModel';
import { PromtionCriteriaSalesManAttrModel } from 'src/app/core/Models/EntityModels/PromtionCriteriaSalesManAttrModel';
import { ChooserRepresentativeComponent } from 'src/app/Modules/shared/chooser-representative/chooser-representative.component';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { PromotionRepeatTypeService } from 'src/app/core/services/promotion/PromotionRepeatType.Service';
import { PromotionItemBundleModel } from 'src/app/core/Models/EntityModels/PromotionItemBundleModel';
import { PromotionItemBundleService } from 'src/app/core/services/promotion/PromotionItemBundle.Service';
import { PromotionItemBundleListModel } from 'src/app/core/Models/ListModels/PromotionItemBundleListModel';
import { UserModel } from 'src/app/core/Models/DtoModels/UserModel';
import { UserService } from 'src/app/core/services/User.Service';
import { ChooserProductAllComponent } from 'src/app/Modules/shared/chooser-product-all/chooser-product-all.component';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';
import { PromotionTypeModel } from '../../../../core/Models/EntityModels/PromotionTypeModel';

@Component({
  selector: 'app-manage-promotion',
  templateUrl: './manage-promotion.component.html',
  styleUrls: ['./manage-promotion.component.scss']
})
export class ManagePromotionComponent implements OnInit {

  EDIT_ATTR_HEADER = '';
  EDIT_TYPE_HEADER = '';
  CHOOSE = '';

  activeIndex=0;

  current:UserModel;

  PromotionModel: PromotionModel = {
    promotionId: 0,
    isActive: false,
    isApproved: false,
    promotionCategoryId: 0,
    companyId: 1,
    enableNotification: false,
    priority: 0,
    displayOrder: 1,
    notificationDate: this._UtilService.LocalDate(new Date()),
    notificationDone: false,
    promotionCode: '',
    promotionDesc: '',
    color: '',
    promotionGroupId: 1,
    promotionTypeId: 0,
    repeats: 0,
    validFrom: this._UtilService.LocalDate(new Date()),
    validTo: this._UtilService.LocalDate(new Date()),
    icon: '',
    repeatTypeId:1,

  } as PromotionModel;

  PromotionCriteriaModel: PromotionCriteriaModel = {
    attributeCode: '',
    attributeId: 0,
    criteriaId: 0,
    excluded: false,
    groupCode: '',
    groupId: 0,
    isActive: true,
    promotionId: 0,
    valueFrom: '',


  } as PromotionCriteriaModel;



  PromotionOutcomeModel: PromotionOutcomeModel = {
    promotionId: 0,
    displayOrder: 0,
    isActive: true,
    count: 0,
    slice: 0,
    outcomeId: 0,
    itemCode: '',
    value: 0,


  } as PromotionOutcomeModel;

  PromtionCriteriaClientModel: PromtionCriteriaClientModel = {
    clientCriteriaId: 0,
    clientAttributeId: 0,
    promotionId: 0,
    isActive: true,
    excluded: false,
    valueFrom: '',

    clientAttributeCode: ''

  } as PromtionCriteriaClientModel;

  PromtionCriteriaSalesManModel: PromtionCriteriaSalesManModel = {
    salesManCriteriaId: 0,
    salesManAttributeId: 0,
    promotionId: 0,
    isActive: true,
    excluded: false,
    valueFrom: '',

    salesManAttributeCode: ''

  } as PromtionCriteriaSalesManModel;


  PromotionMixGroupModel: PromotionMixGroupModel = {
    groupNo: 1,
    groupId: 0,
    promotionId: 0,
    slice: 0,
    isActive: true,

  } as PromotionMixGroupModel;

  PromotionItemBundleModel: PromotionItemBundleModel = {
    bundleId: 0,
    cBy: 0,
    cDate: new Date(),
    eBy: 0,
    eDate: new Date(),
    isMandatory: false,
    itemId: 0,
    itemCode:'',
    promotionId: 0,
    quantity: 1,

  } as PromotionItemBundleModel;

  PromotionCriteriaList: PromotionCriteriaModel[] = [];
  PromotionOucomeList: PromotionOutcomeModel[] = [];
  PromtionCriteriaClientList: PromtionCriteriaClientModel[] = [];
  PromtionCriteriaSalesManList: PromtionCriteriaSalesManModel[] = [];

  PromotionMixGroupList: PromotionMixGroupModel[] = [];
  PromotionItemBundleList: PromotionItemBundleListModel[] = [];


  promotionTypes: LookupModel[] = [];
  promotionGroups: LookupModel[] = [];
  promotionColors: LookupModel[] = [];
  attributes: LookupModel[] = [];
  attributesClient: LookupModel[] = [];
  attributesSalesMan: LookupModel[] = [];
  repeatTypes: LookupModel[] = [];


  isLoading = false;

  isMixAndMatch = false;
  showItemCriteria = false;
  showClientCriteria = false;
  showSalesManCriteria = false;
  showGroup = false;

  showOutcome = false;
  showBundle = false;

  inputId = 0;
  outputId = 0;
  IsCustomAttr = true;
  IsCustomClientAttr = true;
  IsCustomSalesManAttr = true;


  isPromotionLoading = false;

  isCritriaItemLoading = false;
  isOutcomeLoading = false;
  isBundleLoading = false;

  isCritriaClientLoading = false;
  isCritriaSalesManLoading = false;
  isGroupLoading = false;

  editMode = '';
  minimal = false;

  constructor(

    private _AppMessageService: AppMessageService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _BranchService: BranchService,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private ref: DynamicDialogRef,
    private dialogService: DialogService,
    private config: DynamicDialogConfig,
    private _UtilService: UtilService,

    private _PromotionService: PromotionService,
    private _PromotionCriteriaService: PromotionCriteriaService,
    private _PromotionCriteriaAttrService: PromotionCriteriaAttrService,
    private _PromotionCriteriaAttrCustomService: PromotionCriteriaAttrCustomService,
    private _PromotionGroupService: PromotionGroupService,
    private _PromotionInputService: PromotionInputService,
    private _PromotionMixGroupService: PromotionMixGroupService,
    private _PromotionOrderHistoryService: PromotionOrderHistoryService,
    private _PromotionOutcomeService: PromotionOutcomeService,
    private _PromotionOutputService: PromotionOutputService,
    private _PromotionTypeService: PromotionTypeService,
    private _PromtionCriteriaSalesManService: PromtionCriteriaSalesManService,
    private _PromtionCriteriaClientService: PromtionCriteriaClientService,
    private _PromtionCriteriaClientAttrService: PromtionCriteriaClientAttrService,
    private _PromtionCriteriaClientAttrCustomService: PromtionCriteriaClientAttrCustomService,
    private _PromtionCriteriaSalesManAttrService: PromtionCriteriaSalesManAttrService,
    private _PromotionItemBundleService:PromotionItemBundleService,
    private _PromotionRepeatTypeService: PromotionRepeatTypeService,
    private _UserService: UserService,
    private _commonCrudService : CommonCrudService,


  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Add/Edit Attribute').subscribe((res) => { this.EDIT_ATTR_HEADER = res });
    this._translateService.get('Add/Edit Condition Type').subscribe((res) => { this.EDIT_TYPE_HEADER = res });
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });


    if (this.config.data) {
      if (+this.config.data.promotionId > 0) {
        this.PromotionModel.promotionId = +this.config.data.promotionId;
      }

      if (this.config.data.editMode) {
        this.editMode = this.config.data.editMode;
      }

      if (this.config.data.minimal) {
        this.minimal = this.config.data.minimal;
        this.activeIndex=1;
      }




      if (this.config.data.promotionCategoryId) {

        this.PromotionModel.promotionCategoryId = this.config.data.promotionCategoryId;


        if (this.PromotionModel.promotionCategoryId == 3) {
          this.PromotionModel.promotionTypeId = 1;
          this.isMixAndMatch = false;
          this.inputId = 2;
          this.outputId = 1;
        }

      }

    }
  }

  ngOnInit(): void {

    this.current=this._UserService.Current();
    
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

    this._commonCrudService.get("PromotionCriteriaAttr/GetAll", LookupModel).then(res => {
      if (res.succeeded = true) {
        this.attributes = res.data;
      }
      this.attributes.unshift({ id: 0, code: '--', name: '--' });
    })


    this._commonCrudService.get("PromtionCriteriaClientAttr/GetAll", LookupModel).then(res => {
      if (res.succeeded = true) {
        this.attributesClient = res.data;
      }
      this.attributesClient.unshift({ id: 0, code: '--', name: '--' });
    })

    this._commonCrudService.get("PromtionCriteriaSalesManAttr/GetAll", LookupModel).then(res => {
      if (res.succeeded = true) {
        this.attributesSalesMan = res.data;
      }
      this.attributesSalesMan.unshift({ id: 0, code: '--', name: '--' });
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


    if (this.PromotionModel.promotionId > 0) {

      this.buildPromotion();

    }

  }
  async buildPromotion() {
    this.isLoading = true;
    await this._commonCrudService.get("Promotion/getById?Id="+this.PromotionModel.promotionId, PromotionModel).then(res => {
      if (res.succeeded == true) {
        this.PromotionModel = res.data;
        this.PromotionModel.validFrom
        this.PromotionModel.validFrom = this._UtilService.EndDay(this.PromotionModel.validFrom);
        this.PromotionModel.validTo = this._UtilService.EndDay(this.PromotionModel.validTo);

        if (res.data.isApproved == true) {
          this.editMode = "v";
        }

        if (this.PromotionModel.promotionTypeId > 0) {

          this._commonCrudService.get("PromotionType/GetById?Id="+this.PromotionModel.promotionId, PromotionModel).then(res => {
            if (res.succeeded == true) {
              if (res.data) {

                console.log(res.data);

                this.inputId = res.data.promotionInputId;
                this.outputId = res.data.promotionOutputId;

                if (this.inputId == 3 || this.inputId == 4) {
                  this.isMixAndMatch = true;
                }



              }
            }
          })

        }

      }
    })
    this.isLoading = false;


    this.isCritriaItemLoading = true;
    await this._commonCrudService.get("PromotionCriteria/getByPromotion?Id="+this.PromotionModel.promotionId, PromotionCriteriaModel).then(res => {
      if (res.succeeded == true) {
        this.PromotionCriteriaList = res.data;
      }
      this.isCritriaItemLoading = false;

    })

    this.isOutcomeLoading = true;
    await this._commonCrudService.get("PromotionOutcome/getByPromotion?Id="+this.PromotionModel.promotionId, PromotionOutcomeModel).then(res => {
      if (res.succeeded == true) {
        this.PromotionOucomeList = res.data;

        if (this.outputId == 3) {
          if (this.PromotionOucomeList.length > 0) {
            this.PromotionOutcomeModel.itemCode = this.PromotionOucomeList[0].itemCode;
          }
        }

        this.isOutcomeLoading = false;


      }
    })

    this.isCritriaClientLoading = true;

    await this._commonCrudService.get("PromtionCriteriaClient/getByPromotion?Id="+this.PromotionModel.promotionId, PromtionCriteriaClientModel).then(res => {
      if (res.succeeded == true) {
        this.PromtionCriteriaClientList = res.data;
      }
      this.isCritriaClientLoading = false;

    })


    this.isCritriaSalesManLoading = true;

    await this._commonCrudService.get("PromtionCriteriaSalesMan/getByPromotion?Id="+this.PromotionModel.promotionId, PromtionCriteriaSalesManModel).then(res => {
      if (res.succeeded == true) {
        this.PromtionCriteriaSalesManList = res.data;
      }
      this.isCritriaSalesManLoading = false;

    })


    this.isGroupLoading = true;

    await this._commonCrudService.get("PromotionMixGroup/getByPromotion?Id="+this.PromotionModel.promotionId,PromotionMixGroupModel).then(res => {
      if (res.succeeded == true) {
        this.PromotionMixGroupList = res.data;
      }
      this.isGroupLoading = false;

    })


    this.isBundleLoading = true;

    await this._commonCrudService.get("PromotionItemBundle/getByPromotion?Id="+this.PromotionModel.promotionId, PromotionItemBundleListModel).then(res => {
      if (res.succeeded == true) {
        this.PromotionItemBundleList = res.data;
      }
      this.isBundleLoading = false;

    })
  }

  async SavePromotion() {

    let isValid = true;
    if (this.PromotionModel.promotionCode.trim().length == 0) {
      isValid = false;
    }
    
    if (this.PromotionModel.promotionCategoryId == 2) {
      if (this.PromotionModel.promotionTypeId == 0) {
        isValid = false;
      }
      if (this.PromotionModel.promotionGroupId == 0) {
        isValid = false;
      }
    }


    if (this.PromotionModel.repeatTypeId == 0) {
      isValid = false;
    }
    if (!this.PromotionModel.validFrom) {
      isValid = false;
    }
    if (!this.PromotionModel.validTo) {
      isValid = false;
    }

    if (this.PromotionModel.validTo < this.PromotionModel.validFrom) {
      isValid = false;
    }

    if (isValid == true) {
      this.isPromotionLoading = true;
      this._commonCrudService.post("Promotion/Save", this.PromotionModel, PromotionModel).then(res => {
        if (res.succeeded == true) {
          this.PromotionModel = res.data;
          //done
          this.messageService.add({ severity: 'success', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_OK });
        }
        else {
          //error
          this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_ERROR });
          this.PromotionModel.promotionId = 0;
        }
        this.isPromotionLoading = false;

      })
    }
    else {
      this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_INVALID });
    }
  }
  addCritriaLine() {
    this.resetItemCriteria();
    this.showItemCriteria = true;
    this.IsCustomAttr = true;
  }

  addBundleLine() {
    this.resetItemBundleCriteria();
    this.showBundle = true;
  }

  addCritriaClientLine() {
    this.resetClientCriteria();
    this.showClientCriteria = true;
  }
  addCritriaSalesManLine() {
    this.resetSalesManCriteria();
    this.showSalesManCriteria = true;
  }

  addOutcomeLine() {
    this.resetOutcomeCriteria();
    this.showOutcome = true;
  }
  addGroupLine() {
    this.resetGroupCriteria();
    this.showGroup = true;
  }

  editCritriaLine() {
    this.showItemCriteria = true;

    this._commonCrudService.get("PromotionCriteriaAttr/GetById?Id=" + this.PromotionCriteriaModel.attributeId, PromotionCriteriaAttrModel).then(res => {
      if (res.succeeded == true) {
        if (res.data) {
          this.IsCustomAttr = res.data.isCustom;
        }
      }
    })

  }
  editBundleLine() {
    this.showBundle = true;
  }

  editCritriaClientLine() {

    this.showClientCriteria = true;
    this._commonCrudService.get("PromtionCriteriaClientAttr/GetById?Id=" + this.PromtionCriteriaClientModel.clientAttributeId, PromotionCriteriaAttrModel).then(res => {
      if (res.succeeded == true) {
        if (res.data) {
          this.IsCustomClientAttr = res.data.isCustom;
        }
      }
    })
  }
  editCritriaSalesManLine() {
    this.showSalesManCriteria = true;
    this._commonCrudService.get("PromtionCriteriaSalesManAttr/GetById?Id=" + this.PromtionCriteriaSalesManModel.salesManAttributeId, PromtionCriteriaSalesManAttrModel).then(res => {
      if (res.succeeded == true) {
        if (res.data) {
          this.IsCustomSalesManAttr = res.data.isCustom;
        }
      }
    })
  }
  editOutcomeLine() {
    this.showOutcome = true;
  }
  editGroupLine() {
    this.showGroup = true;
  }

  deleteOutcomeLine() {
    if (this.PromotionOutcomeModel != null && this.PromotionOutcomeModel.outcomeId > 0) {
      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {
          this.isOutcomeLoading = true;
          let model = {} as PromotionOutcomeModel;
          model.outcomeId = this.PromotionOutcomeModel.outcomeId;
          this.isOutcomeLoading = true;
          await this._PromotionOutcomeService.Delete(model).then(async res => {
            if (res.succeeded == true) {
              this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });

              //rebind grid
              this.PromotionOucomeList = [];
              await this._commonCrudService.get("PromotionOutcome/getByPromotion?Id="+this.PromotionOutcomeModel.promotionId,PromotionOutcomeModel).then(res => {
                if (res.succeeded == true) {
                  this.PromotionOucomeList = res.data;
                }
              })

              this.resetOutcomeCriteria();

            }
            else {
              this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
            }
          })
          this.isOutcomeLoading = false;

        },
        reject: () => {
          //reject action
        }
      });
    }
  }

  deleteBundleLine() {
    if (this.PromotionItemBundleModel != null && this.PromotionItemBundleModel.bundleId > 0) {
      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {
          this.isBundleLoading = true;
          let model = {} as PromotionItemBundleModel;
          model.bundleId = this.PromotionItemBundleModel.bundleId;
          await this._PromotionItemBundleService.Delete(model).then(async res => {
            if (res.succeeded == true) {
              this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });

              //rebind grid
              this.PromotionItemBundleList = [];
              await this._commonCrudService.get("PromotionItemBundle/getByPromotion?Id="+this.PromotionItemBundleModel.promotionId, PromotionItemBundleListModel).then(res => {
                if (res.succeeded == true) {
                  this.PromotionItemBundleList = res.data;
                }
              })

              this.resetItemBundleCriteria();

            }
            else {
              this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
            }
          })
          this.isBundleLoading = false;

        },
        reject: () => {
          //reject action
        }
      });
    }
  }

  deleteCritriaLine() {
    if (this.PromotionCriteriaModel != null && this.PromotionCriteriaModel.criteriaId > 0) {
      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {
          this.isCritriaItemLoading = true;
          let model = {} as PromotionCriteriaModel;
          model.criteriaId = this.PromotionCriteriaModel.criteriaId;
          this.isCritriaItemLoading = true;
          await this._commonCrudService.post("PromotionCriteria/Delete", model,PromotionCriteriaModel).then(async res => {
            if (res.succeeded == true) {
              this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });


              //rebind grid
              this.PromotionCriteriaList = [];
              await this._commonCrudService.get("PromotionCriteria/getByPromotion?Id="+this.PromotionCriteriaModel.promotionId, PromotionCriteriaModel).then(res => {
                if (res.succeeded == true) {
                  this.PromotionCriteriaList = res.data;
                }
              })

              this.resetItemCriteria();


            }
            else {
              this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
            }
          })
          this.isCritriaItemLoading = false;

        },
        reject: () => {
          //reject action
        }
      });
    }
  }
  deleteCritriaClientLine() {

    if (this.PromtionCriteriaClientModel != null && this.PromtionCriteriaClientModel.clientCriteriaId > 0) {
      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {
          let model = {} as PromtionCriteriaClientModel;
          model.clientCriteriaId = this.PromtionCriteriaClientModel.clientCriteriaId;
          this.isCritriaClientLoading = true;
          await this._commonCrudService.post("PromtionCriteriaClient/Delete", model, PromtionCriteriaClientModel).then(async res => {
            if (res.succeeded == true) {
              this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });

              //rebind grid
              this.PromtionCriteriaClientList = [];
              await this._commonCrudService.get("PromtionCriteriaClient/getByPromotion?Id="+this.PromtionCriteriaClientModel.promotionId, PromtionCriteriaClientModel).then(res => {
                if (res.succeeded == true) {
                  this.PromtionCriteriaClientList = res.data;
                }
              })

              this.resetClientCriteria();

            }
            else {
              this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
            }
          })
          this.isCritriaClientLoading = false;

        },
        reject: () => {
          //reject action
        }
      });
    }

  }

  deleteCritriaSalesManLine() {

    if (this.PromtionCriteriaSalesManModel != null && this.PromtionCriteriaSalesManModel.salesManCriteriaId > 0) {
      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {
          let model = {} as PromtionCriteriaSalesManModel;
          model.salesManCriteriaId = this.PromtionCriteriaSalesManModel.salesManCriteriaId;
          this.isCritriaSalesManLoading = true;
          await this._commonCrudService.post("PromtionCriteriaSalesMan/Delete", model, PromtionCriteriaSalesManModel).then(async res => {
            if (res.succeeded == true) {
              this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });

              //rebind grid
              this.PromtionCriteriaSalesManList = [];
              await this._commonCrudService.get("PromtionCriteriaSalesMan/getByPromotion?Id="+this.PromtionCriteriaSalesManModel.promotionId, PromtionCriteriaSalesManModel).then(res => {
                if (res.succeeded == true) {
                  this.PromtionCriteriaSalesManList = res.data;
                }
              })

              this.resetSalesManCriteria();

            }
            else {
              this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
            }
          })
          this.isCritriaSalesManLoading = false;

        },
        reject: () => {
          //reject action
        }
      });
    }

  }
  deleteGroupLine() {

    if (this.PromotionMixGroupModel != null && this.PromotionMixGroupModel.groupId > 0) {
      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {
          let model = {} as PromotionMixGroupModel;
          model.groupId = this.PromotionMixGroupModel.groupId;
          this.isGroupLoading = true;
          await this._commonCrudService.post("PromotionMixGroup/Delete", model, PromotionMixGroupModel).then(async res => {
            if (res.succeeded == true) {
              this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });

              //rebind grid
              this.PromotionMixGroupList = [];
              await this._commonCrudService.get("PromotionMixGroup/getByPromotion?Id="+this.PromotionMixGroupModel.promotionId, PromotionMixGroupModel).then(res => {
                if (res.succeeded == true) {
                  this.PromotionMixGroupList = res.data;
                }
              })

              //rebind Criteria grid
              this.PromotionCriteriaList = [];
              await this._commonCrudService.get("PromotionCriteria/getByPromotion?Id="+this.PromotionMixGroupModel.promotionId, PromotionCriteriaModel).then(res => {
                if (res.succeeded == true) {
                  this.PromotionCriteriaList = res.data;
                }
              })

              this.resetGroupCriteria();
              this.resetItemCriteria();
            }
            else {
              this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
            }
          })

          this.isGroupLoading = false;

        },
        reject: () => {
          //reject action
        }
      });
    }

  }

  resetItemCriteria() {
    //reset
    this.IsCustomAttr = true;


    this.PromotionCriteriaModel.valueFrom='';
    this.PromotionCriteriaModel.attributeId=0;
    this.PromotionCriteriaModel.attributeCode='';
    this.PromotionCriteriaModel.criteriaId=0;
    this.PromotionCriteriaModel.promotionId=0;

  }
  resetClientCriteria() {
    //reset
    this.IsCustomClientAttr = true;
  

    this.PromtionCriteriaClientModel.clientCriteriaId=0;
    this.PromtionCriteriaClientModel.clientAttributeId=0;
    this.PromtionCriteriaClientModel.promotionId=0;
    this.PromtionCriteriaClientModel.valueFrom='';

  }

  resetSalesManCriteria() {
    //reset
    this.IsCustomSalesManAttr = true;


    this.PromtionCriteriaSalesManModel.salesManCriteriaId=0;
    this.PromtionCriteriaSalesManModel.salesManAttributeId=0;
    this.PromtionCriteriaSalesManModel.promotionId=0;
    this.PromtionCriteriaSalesManModel.valueFrom='';

  }
  resetOutcomeCriteria() {
    //reset
    this.PromotionOutcomeModel.promotionId = 0;
    this.PromotionOutcomeModel.displayOrder = 0;
    this.PromotionOutcomeModel.isActive = true;
    this.PromotionOutcomeModel.count = 0;
    this.PromotionOutcomeModel.slice = 0;
    this.PromotionOutcomeModel.outcomeId = 0;
    this.PromotionOutcomeModel.value = 0;

  }

  resetGroupCriteria() {
    //reset
    this.PromotionMixGroupModel = {
      groupId: 0,
      promotionId: 0,
      slice: 0,
      isActive: true,
      groupNo: this.PromotionMixGroupList.length + 1
    } as PromotionMixGroupModel;
  }

  resetItemBundleCriteria(){
    this.PromotionItemBundleModel = {
      bundleId: 0,
      cBy: 0,
      cDate: new Date(),
      eBy: 0,
      eDate: new Date(),
      isMandatory: false,
      itemCode: '',
      promotionId: 0,
      quantity: 1,

    } as PromotionItemBundleModel;
  }
  async saveItemCriteria() {

    let valid = true;

    this.PromotionCriteriaModel.promotionId = this.PromotionModel.promotionId;

    if (this.PromotionCriteriaModel.attributeId == 0) {
      valid = false;
    }
    if (this.PromotionCriteriaModel.promotionId == 0) {
      valid = false;
    }

    if (this.IsCustomAttr == false) {
      if (this.PromotionCriteriaModel.valueFrom.trim().length == 0) {
        valid = false;
      }

    }



    if (valid == false) {
      this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_INVALID });
      return;
    }

    this.isCritriaItemLoading = true;
    await this._commonCrudService.post("PromotionCriteria/Save", this.PromotionCriteriaModel, PromotionCriteriaModel).then(async res => {
      if (res.succeeded == true) {


        //rebind grid
        this.PromotionCriteriaList = [];

        await this._commonCrudService.get("PromotionCriteria/getByPromotion?Id="+this.PromotionCriteriaModel.promotionId, PromotionCriteriaModel).then(res => {
          if (res.succeeded == true) {
            this.PromotionCriteriaList = res.data;
          }
        })

        //reset
        this.resetItemCriteria();

        this.messageService.add({ severity: 'success', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_OK });
      }
      else {
        this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_ERROR });

      }

      this.isCritriaItemLoading = false;

    })



  }

  async saveOutcome() {

    let valid = true;

    this.PromotionOutcomeModel.promotionId = this.PromotionModel.promotionId;


    if (this.PromotionOutcomeModel.value == 0) {
      valid = false;
    }

    if (this.isMixAndMatch == true) {

      if (this.PromotionOutcomeModel.count == 0) {
        valid = false;
      }
    }

    else {
      if (this.PromotionOutcomeModel.slice == 0) {
        valid = false;
      }
    }



    if (valid == false) {
      this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_INVALID });
      return;
    }

    this.isOutcomeLoading = true;

    await this._commonCrudService.post("PromotionOutcome/Save", this.PromotionOutcomeModel, PromotionOutcomeModel).then(async res => {
      if (res.succeeded == true) {


        //rebind grid
        this.PromotionOucomeList = [];

        await this._commonCrudService.get("PromotionOutcome/getByPromotion?Id="+this.PromotionOutcomeModel.promotionId,PromotionOutcomeModel).then(res => {
          if (res.succeeded == true) {
            this.PromotionOucomeList = res.data;
          }
        })

        //reset
        this.resetOutcomeCriteria();

        this.messageService.add({ severity: 'success', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_OK });
      }
      else {
        this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_ERROR });

      }

      this.isOutcomeLoading = false;

    })



  }
  async saveBundle() {

    let valid = true;

    this.PromotionItemBundleModel.promotionId = this.PromotionModel.promotionId;


    if (this.PromotionItemBundleModel.quantity == 0) {
      valid = false;
    }

    if (this.PromotionItemBundleModel.itemCode.length == 0) {
      valid = false;
    }
   


    if (valid == false) {
      this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_INVALID });
      return;
    }

    this.isBundleLoading = true;

    await this._commonCrudService.post("PromotionItemBundle/Save", this.PromotionItemBundleModel, PromotionItemBundleModel).then(async res => {
      if (res.succeeded == true) {


        //rebind grid
        this.PromotionOucomeList = [];

        await this._commonCrudService.get("PromotionItemBundle/getByPromotion?Id="+this.PromotionItemBundleModel.promotionId, PromotionItemBundleListModel).then(res => {
          if (res.succeeded == true) {
            this.PromotionItemBundleList = res.data;
          }
        })

        //reset
        this.resetItemBundleCriteria();

        this.messageService.add({ severity: 'success', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_OK });
      }
      else {
        this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_ERROR });

      }

      this.isBundleLoading = false;

    })



  }

  async saveGroup() {

    let valid = true;

    this.PromotionMixGroupModel.promotionId = this.PromotionModel.promotionId;


    if (this.PromotionMixGroupModel.groupNo == 0) {
      valid = false;
    }
    if (this.PromotionMixGroupModel.slice == 0) {
      valid = false;
    }


    if (valid == false) {
      this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_INVALID });
      return;
    }

    this.isGroupLoading = true;
    await this._commonCrudService.post("PromotionMixGroup/Save", this.PromotionMixGroupModel, PromotionMixGroupModel).then(async res => {
      if (res.succeeded == true) {


        //rebind grid
        this.PromotionMixGroupList = [];

        await this._commonCrudService.get("PromotionMixGroup/getByPromotion?Id="+this.PromotionMixGroupModel.promotionId, PromotionMixGroupModel).then(res => {
          if (res.succeeded == true) {
            this.PromotionMixGroupList = res.data;
          }
        })

        //reset
        this.resetGroupCriteria();

        this.messageService.add({ severity: 'success', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_OK });
      }
      else {
        this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_ERROR });

      }

      this.isGroupLoading = false;

    })



  }
  async saveClientCriteria() {

    let valid = true;

    this.PromtionCriteriaClientModel.promotionId = this.PromotionModel.promotionId;

    if (this.PromtionCriteriaClientModel.clientAttributeId == 0) {
      valid = false;
    }
    if (this.PromtionCriteriaClientModel.promotionId == 0) {
      valid = false;
    }



    if (this.IsCustomClientAttr == false) {
      if (this.PromtionCriteriaClientModel.valueFrom.trim().length == 0) {
        valid = false;
      }


    }


    if (valid == false) {
      this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_INVALID });
      return;
    }

    this.isCritriaClientLoading = true;
    await this._commonCrudService.post("PromtionCriteriaClient/Save", this.PromtionCriteriaClientModel, PromtionCriteriaClientModel).then(async res => {
      if (res.succeeded == true) {


        //rebind grid
        this.PromtionCriteriaClientList = [];

        await this._commonCrudService.get("PromtionCriteriaClient/getByPromotion?Id="+this.PromtionCriteriaClientModel.promotionId, PromtionCriteriaClientModel).then(res => {
          if (res.succeeded == true) {
            this.PromtionCriteriaClientList = res.data;
          }
        })

        //reset
        this.resetClientCriteria();

        this.messageService.add({ severity: 'success', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_OK });
      }
      else {
        this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_ERROR });

      }

      this.isCritriaClientLoading = false;

    })



  }
  async saveSalesManCriteria() {

    let valid = true;

    this.PromtionCriteriaSalesManModel.promotionId = this.PromotionModel.promotionId;

    if (this.PromtionCriteriaSalesManModel.salesManAttributeId == 0) {
      valid = false;
    }
    if (this.PromtionCriteriaSalesManModel.promotionId == 0) {
      valid = false;
    }



    if (this.IsCustomSalesManAttr == false) {
      if (this.PromtionCriteriaSalesManModel.valueFrom.trim().length == 0) {
        valid = false;
      }

    }


    if (valid == false) {
      this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_INVALID });
      return;
    }

    this.isCritriaSalesManLoading = true;
    await this._commonCrudService.post("PromtionCriteriaSalesMan/Save", this.PromtionCriteriaSalesManModel, PromtionCriteriaSalesManModel).then(async res => {
      if (res.succeeded == true) {


        //rebind grid
        this.PromtionCriteriaSalesManList = [];

        await this._commonCrudService.get("PromtionCriteriaSalesMan/getByPromotion?Id="+this.PromtionCriteriaSalesManModel.promotionId, PromtionCriteriaSalesManModel).then(res => {
          if (res.succeeded == true) {
            this.PromtionCriteriaSalesManList = res.data;
          }
        })

        //reset
        this.resetSalesManCriteria();

        this.messageService.add({ severity: 'success', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_OK });
      }
      else {
        this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_ERROR });

      }

      this.isCritriaSalesManLoading = false;

    })



  }


  onPromotionTypeChange(event) {

    this.inputId = 0;
    this.outputId = 0;
    this.isMixAndMatch = false;

    this._commonCrudService.get("PromotionType/GetById?Id="+event.value, PromotionTypeModel).then(res => {
      if (res.succeeded == true) {
        if (res.data) {

          this.inputId = res.data.promotionInputId;
          this.outputId = res.data.promotionOutputId;

          if (this.inputId == 3 || this.inputId == 4) {
            this.isMixAndMatch = true;
          }

        }
      }
    })

  }
  checkCodeExist() {
    let valid = true;


    if (this.PromotionModel.promotionCode.trim().length == 0) {
      valid = false;
    }
    if (valid == true) {

      this._commonCrudService.post("Promotion/exists",this.PromotionModel,PromotionModel).then((res: { succeeded: boolean; data: PromotionModel; }) => {
        if (res.succeeded == true) {

          if (res.data && res.data.promotionId > 0) {
            this.PromotionModel = res.data;
            this.buildPromotion();
          }
          else {
            this.messageService.add({ severity: 'success', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_OK });
          }
        }
      })

    }
    else {
      this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_INVALID });

    }
  }


  addCritriaAttr() {
    var ref = this.dialogService.open(ManagePromotionCriteriaAttrComponent, {
      header: this.EDIT_ATTR_HEADER,
      data: { attributeId: this.PromotionCriteriaModel.attributeId },
      width: '500px',
      contentStyle: { "max-height": "600px", "height": "600px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe(() => {
      this.attributes = [];
      this.isLoading = true;
      this._commonCrudService.get("PromotionCriteriaAttr/GetAll", LookupModel).then(res => {
        if (res.succeeded = true) {
          this.attributes = res.data;
        }
        this.attributes.unshift({ id: 0, code: '--', name: '--' });
        this.isLoading = false;

      })
    });
  }
  addClientAttr() {
    var ref = this.dialogService.open(ManagePromotionClientAttrComponent, {
      header: this.EDIT_ATTR_HEADER,
      data: { clientAttributeId: this.PromtionCriteriaClientModel.clientAttributeId },
      width: '500px',
      contentStyle: { "max-height": "600px", "height": "600px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe(() => {
      this.attributesClient = [];
      this.isLoading = true;
      this._commonCrudService.get("PromtionCriteriaClientAttr/GetAll", LookupModel).then(res => {
        if (res.succeeded = true) {
          this.attributesClient = res.data;
        }
        this.attributesClient.unshift({ id: 0, code: '--', name: '--' });
        this.isLoading = false;

      })
    });
  }

  addSalesManAttr() {
    var ref = this.dialogService.open(ManagePromotionSalesManAttrComponent, {
      header: this.EDIT_ATTR_HEADER,
      data: { salesManAttributeId: this.PromtionCriteriaSalesManModel.salesManAttributeId },
      width: '500px',
      contentStyle: { "max-height": "600px", "height": "600px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe(() => {
      this.attributesSalesMan = [];
      this.isLoading = true;
      this._commonCrudService.get("PromtionCriteriaSalesManAttr/GetAll", LookupModel).then(res => {
        if (res.succeeded = true) {
          this.attributesSalesMan = res.data;
        }
        this.attributesSalesMan.unshift({ id: 0, code: '--', name: '--' });
        this.isLoading = false;

      })
    });
  }
  addPromotionType() {
    var ref = this.dialogService.open(ManagePromotionTypeComponent, {
      header: this.EDIT_TYPE_HEADER,
      data: { promotionTypeId: this.PromotionModel.promotionTypeId },
      width: '400px',
      contentStyle: { "max-height": "600px", "height": "600px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe(() => {
      this.promotionTypes = [];
      this.isLoading = true;
      this._commonCrudService.get("PromotionType/GetAll", LookupModel).then(res => {
        if (res.succeeded = true) {
          this.promotionTypes = res.data;
        }
        this.promotionTypes.unshift({ id: 0, code: '--', name: '--' });
        this.isLoading = false;

      })

    });
  }

  onAttrChange(event) {
    this.IsCustomAttr = false;

    if (event.value == 0) {
      this.IsCustomAttr = true;
    }
    else {
      this._commonCrudService.get("PromotionCriteriaAttr/GetById?Id="+event.value, PromotionCriteriaAttrModel).then(res => {
        if (res.succeeded == true) {
          if (res.data) {
            this.IsCustomAttr = res.data.isCustom;
          }
        }
      })
    }


  }
  onClientAttrChange(event) {
    this.IsCustomClientAttr = false;

    if (event.value == 0) {
      this.IsCustomClientAttr = true;
    }
    else {
      this._commonCrudService.get("PromtionCriteriaClientAttr/GetById?Id="+event.value, PromtionCriteriaClientAttrModel).then(res => {
        if (res.succeeded == true) {
          if (res.data) {
            this.IsCustomClientAttr = res.data.isCustom;
          }
        }
      })
    }


  }
  onSalesManAttrChange(event) {
    console.log(event);
    this.IsCustomSalesManAttr = false;

    if (event.value == 0) {
      this.IsCustomSalesManAttr = true;
    }
    else {
      this._commonCrudService.get("PromtionCriteriaSalesManAttr/GetById?Id="+event.value, PromtionCriteriaSalesManAttrModel).then(res => {
        if (res.succeeded == true) {
          if (res.data) {
            this.IsCustomSalesManAttr = res.data.isCustom;
          }
        }
      })
    }

  }

  choose_Item_Outcome() {
    var ref = this.dialogService.open(ChooserProductAllComponent, {
      header: this.CHOOSE,
      width: '90%',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((product: ItemListModel) => {

      if (product) {
        this.PromotionOutcomeModel.itemCode = product.itemCode;
      }

    });
  }

  choose_Item_Bundle() {
    var ref = this.dialogService.open(ChooserProductAllComponent, {
      header: this.CHOOSE,
      width: '80%',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((product: ItemListModel) => {

      if (product) {
        this.PromotionItemBundleModel.itemCode = product.itemCode;
        this.PromotionItemBundleModel.itemId = product.itemId;
      }

    });
  }

  async choose_Item_Criteria() {
    if (this.PromotionCriteriaModel.attributeId == 0) {
      return;
    }
    //get attribute
    let attribute = {} as PromotionCriteriaAttrModel;

    await this._commonCrudService.get("PromotionCriteriaAttr/GetById?Id="+this.PromotionCriteriaModel.attributeId, PromotionCriteriaAttrModel).then(res => {
      attribute = res.data;
    });

    if (!attribute) {
      return;
    }

    if (attribute.isCustom == true) {
      return;
    }


    if (attribute.attributeCode == 'ItemCode') {

      var ref = this.dialogService.open(ChooserProductAllComponent, {
        header: this.CHOOSE,
        width: '90%',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe((product: ItemListModel) => {

        if (product) {
          this.PromotionCriteriaModel.valueFrom = product.itemCode;
        }

      });

    }

    if (attribute.attributeCode == 'VendorCode') {

      var ref = this.dialogService.open(ChooserVendorComponent, {
        header: this.CHOOSE,
        width: '70%',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe((vendor: VendorListModel) => {

        if (vendor) {
          this.PromotionCriteriaModel.valueFrom = vendor.vendorCode;
        }

      });

    }

    if (attribute.attributeCode == 'ItemGroup') {
      var ref = this.dialogService.open(ChooserItemGroupComponent, {
        header: this.CHOOSE,
        width: '50%',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe((group: ItemGroupListModel) => {

        if (group) {
          this.PromotionCriteriaModel.valueFrom = group.itemGroupCode;
        }

      });
    }

    //select by 

  }

  async choose_Vendor() {
    var ref = this.dialogService.open(ChooserVendorComponent, {
      header: this.CHOOSE,
      width: '90%',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((vendor: VendorListModel) => {

      if (vendor) {
        this.PromotionModel.vendorCode = vendor.vendorCode;
      }

    });

  }

  async choose_Client_Criteria() {
    if (this.PromtionCriteriaClientModel.clientAttributeId == 0) {
      return;
    }
    //get attribute
    let attribute = {} as PromtionCriteriaClientAttrModel;

    await this._commonCrudService.get("PromtionCriteriaClientAttr/GetById?Id="+this.PromtionCriteriaClientModel.clientAttributeId, PromtionCriteriaClientAttrModel).then(res => {
      attribute = res.data;
    });

    if (!attribute) {
      return;
    }

    if (attribute.isCustom == true) {
      return;
    }


    if (attribute.clientAttributeCode == 'ClientCode') {

      var ref = this.dialogService.open(ChooserClientComponent, {
        header: this.CHOOSE,
        width: '90%',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });

      ref.onClose.subscribe((res: ClientListModel) => {

        if (res) {
          this.PromtionCriteriaClientModel.valueFrom = res.clientCode;
        }

      });

    }

    if (attribute.clientAttributeCode == 'BranchCode') {

      var ref = this.dialogService.open(ChooserBranchComponent, {
        header: this.CHOOSE,
        width: '60%',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });

      ref.onClose.subscribe((res: BranchListModel) => {

        if (res) {
          this.PromtionCriteriaClientModel.valueFrom = res.branchCode;
        }

      });

    }

    if (attribute.clientAttributeCode == 'ClientType') {

      var ref = this.dialogService.open(ChooserClientTypeComponent, {
        header: this.CHOOSE,
        width: '50%',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });

      ref.onClose.subscribe((res: ClientTypeListModel) => {

        if (res) {
          this.PromtionCriteriaClientModel.valueFrom = res.clientTypeCode;
        }

      });

    }

    if (attribute.clientAttributeCode == 'PaymentTerm') {

      var ref = this.dialogService.open(ChooserPaymentTermComponent, {
        header: this.CHOOSE,
        width: '50%',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });

      ref.onClose.subscribe((res: PaymentTermListModel) => {

        if (res) {
          this.PromtionCriteriaClientModel.valueFrom = res.paymentTermCode;
        }

      });

    }

    if (attribute.clientAttributeCode == 'Governerate') {

      var ref = this.dialogService.open(ChooserGovernerateComponent, {
        header: this.CHOOSE,
        width: '50%',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });

      ref.onClose.subscribe((res: GovernerateListModel) => {

        if (res) {
          this.PromtionCriteriaClientModel.valueFrom = res.governerateCode;
        }

      });

    }

    if (attribute.clientAttributeCode == 'City') {

      var ref = this.dialogService.open(ChooserCityComponent, {
        header: this.CHOOSE,
        width: '50%',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });

      ref.onClose.subscribe((res: CityListModel) => {

        if (res) {
          this.PromtionCriteriaClientModel.valueFrom = res.cityCode;
        }

      });

    }

    if (attribute.clientAttributeCode == 'LocationLevel') {

      var ref = this.dialogService.open(ChooserLocationLevelComponent, {
        header: this.CHOOSE,
        width: '50%',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });

      ref.onClose.subscribe((res: LocationLevelListModel) => {

        if (res) {
          this.PromtionCriteriaClientModel.valueFrom = res.locationLevelCode;
        }

      });

    }

    //select by 

  }

  async choose_SalesMan_Criteria() {
    if (this.PromtionCriteriaSalesManModel.salesManAttributeId == 0) {
      return;
    }
    //get attribute
    let attribute = {} as PromtionCriteriaSalesManAttrModel;

    await this._commonCrudService.get("PromtionCriteriaSalesManAttr/GetById?Id="+this.PromtionCriteriaSalesManModel.salesManAttributeId, PromtionCriteriaSalesManAttrModel).then(res => {
      attribute = res.data;
    });

    if (!attribute) {
      return;
    }

    if (attribute.isCustom == true) {
      return;
    }


    if (attribute.salesManAttributeCode == 'SalesManCode') {

      var ref = this.dialogService.open(ChooserRepresentativeComponent, {
        header: this.CHOOSE,
        data: { kindIds: '1,2' },

        width: '1200px',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });

      ref.onClose.subscribe((res: RepresentativeListModel) => {

        if (res) {
          this.PromtionCriteriaSalesManModel.valueFrom = res.representativeCode;
        }

      });

    }

    if (attribute.salesManAttributeCode == 'BranchCode') {

      var ref = this.dialogService.open(ChooserBranchComponent, {
        header: this.CHOOSE,
        width: '60%',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });

      ref.onClose.subscribe((res: BranchListModel) => {

        if (res) {
          this.PromtionCriteriaSalesManModel.valueFrom = res.branchCode;
        }

      });

    }

    //select by 

  }
  onactiveIndexChange(event){
    this.showBundle=false;
    this.showClientCriteria=false;
    this.showGroup=false;
    this.showItemCriteria=false;
    this.showOutcome=false;
    this.showSalesManCriteria=false;
  }
}
