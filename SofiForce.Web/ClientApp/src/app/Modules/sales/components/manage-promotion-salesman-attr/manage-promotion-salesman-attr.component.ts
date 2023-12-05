import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { UtilService } from 'src/app/core/services/util.service';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { PromtionCriteriaSalesManAttrCustomService } from 'src/app/core/services/promotion/PromtionCriteriaSalesManAttrCustom.Service';
import { PromtionCriteriaSalesManAttrCustomModel } from 'src/app/core/Models/EntityModels/PromtionCriteriaSalesManAttrCustomModel';
import { PromtionCriteriaSalesManAttrService } from 'src/app/core/services/promotion/PromtionCriteriaSalesManAttr.Service';
import { PromtionCriteriaSalesManAttrModel } from 'src/app/core/Models/EntityModels/PromtionCriteriaSalesManAttrModel';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { ChooserRepresentativeComponent } from 'src/app/Modules/shared/chooser-representative/chooser-representative.component';
@Component({
  selector: 'app-manage-promotion-salesman-attr',
  templateUrl: './manage-promotion-salesman-attr.component.html',
  styleUrls: ['./manage-promotion-salesman-attr.component.scss']
})
export class ManagePromotionSalesManAttrComponent implements OnInit {



  model: PromtionCriteriaSalesManAttrModel = {
    salesManAttributeId:0,
    canEdit:true,
    canDelete:true,
    salesManAttributeCode:'',
    salesManAttributeDesc:'',
    salesManAttributeNameAr:'',
    salesManAttributeNameEn:'',
    displayOrder:0,
    isActive:true,
    isCustom:true,


  } as PromtionCriteriaSalesManAttrModel;

  PromtionCriteriaSalesManAttrCustomModel: PromtionCriteriaSalesManAttrCustomModel = {
    salesManAttributeId: 0,
    salesManCustomId: 0,
    valueFrom: '',

    isActive: true,

  } as PromtionCriteriaSalesManAttrCustomModel;

  PromtionCriteriaSalesManAttrCustomList: PromtionCriteriaSalesManAttrCustomModel[] = [];


  isLoading = false;
  isItemLoading = false;

  showItems = false;

  editMode = "";
  CHOOSE='';
  PromtionCriteriaSalesManModel: any;


  constructor(
    private _AppMessageService: AppMessageService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private ref: DynamicDialogRef,
    private dialogService: DialogService,
    private config: DynamicDialogConfig,
    private _UtilService: UtilService,


    private _PromtionCriteriaSalesManAttrService: PromtionCriteriaSalesManAttrService,
    private _PromtionCriteriaSalesManAttrCustomService:PromtionCriteriaSalesManAttrCustomService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });

    if (this.config.data) {
      if (+this.config.data.salesManAttributeId > 0) {
        this.model.salesManAttributeId = +this.config.data.salesManAttributeId;
      }
      if (this.config.data.editMode) {
        this.editMode = this.config.data.editMode;
      }
    }

  }

  ngOnInit(): void {

    if (this.model.salesManAttributeId > 0) {
      this.isLoading = true;
      //get by id

      this._PromtionCriteriaSalesManAttrService.GetById(this.model.salesManAttributeId).then(res => {
        if (res.succeeded == true) {
          if (res.data) {
            this.model = res.data;
          }

          this.isLoading = false;

        }
      })

      this._PromtionCriteriaSalesManAttrCustomService.getByAttribute(this.model.salesManAttributeId).then(res => {
        if (res.succeeded == true) {
          this.PromtionCriteriaSalesManAttrCustomList = res.data;
        }
      })


    }
  }

  async Save() {

    let valid = true;
    if (this.model.salesManAttributeCode.trim().length == 0) {
      valid = false;
    }


    if (valid == false) {

      this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_INVALID });
      return;

    }

    this.isLoading = true;
    await this._PromtionCriteriaSalesManAttrService.Save(this.model).then(res => {
      if (res.succeeded == true && res.data && res.data.salesManAttributeId > 0) {
        this.model = res.data;
      }
      else {
        this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_ERROR });
      }

    });
    this.isLoading = false;

  }

  async saveItem() {
    let valid = true;

    this.PromtionCriteriaSalesManAttrCustomModel.salesManAttributeId=this.model.salesManAttributeId;

    if (this.PromtionCriteriaSalesManAttrCustomModel.salesManAttributeId == 0) {
      valid = false;
    }

    if (this.PromtionCriteriaSalesManAttrCustomModel.valueFrom.trim().length == 0) {
      valid = false;
    }


    if (valid == false) {

      this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_INVALID });
      return;

    }


    this.isItemLoading = true;
    await this._PromtionCriteriaSalesManAttrCustomService.Save(this.PromtionCriteriaSalesManAttrCustomModel).then(async res => {
      if (res.succeeded == true) {


        //rebind grid
        this.PromtionCriteriaSalesManAttrCustomList = [];

        await this._PromtionCriteriaSalesManAttrCustomService.getByAttribute(this.model.salesManAttributeId).then(res => {
          if (res.succeeded == true) {
            this.PromtionCriteriaSalesManAttrCustomList = res.data;
          }
        })

        //reset
        this.resetAttributeModel();

        this.messageService.add({ severity: 'success', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_OK });
      }
      else {
        this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_ERROR });

      }

      this.isItemLoading = false;

    })


  }
  addLine() {
    this.resetAttributeModel();
    this.showItems = true;
  }
  editLine() {
    this.showItems = true;
  }
  deleteLine() {

  }
  resetAttributeModel() {
    this.PromtionCriteriaSalesManAttrCustomModel = {

      salesManAttributeId: 0,
      salesManCustomId: 0,
      valueFrom: '',

      isActive: true,

    } as PromtionCriteriaSalesManAttrCustomModel;
  }


  choose_SalesMan(){
    var ref = this.dialogService.open(ChooserRepresentativeComponent, {
      header: this.CHOOSE,
      data:{kindIds:'1,2'},
      
      width: '1200px',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });

    ref.onClose.subscribe((res:RepresentativeListModel) => {
      
      if(res){
        this.PromtionCriteriaSalesManAttrCustomModel.valueFrom=res.representativeCode;
      }

    });
  }
}
