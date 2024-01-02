import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { PromotionTypeModel } from 'src/app/core/Models/EntityModels/PromotionTypeModel';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { UtilService } from 'src/app/core/services/util.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-manage-promotion-type',
  templateUrl: './manage-promotion-type.component.html',
  styleUrls: ['./manage-promotion-type.component.scss']
})
export class ManagePromotionTypeComponent implements OnInit {

  model: PromotionTypeModel = {
    isActive: true,
    canDelete: true,
    canEdit: true,
    displayOrder: 1,
    promotionInputId: 0,
    promotionOutputId: 0,
    promotionTypeCode: '',
    promotionTypeDesc: '',
    promotionTypeNameAr: '',
    promotionTypeId: 0,
    promotionTypeNameEn: ''
  } as PromotionTypeModel;

  inputs: LookupModel[] = [];
  outputs: LookupModel[] = [];
  isLoading = false;
  editMode="";


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
    private _commonCrudService : CommonCrudService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    //this._translateService.get('Add/Edit Attribute').subscribe((res) => { this.EDIT_ATTR_HEADER = res });

    if (this.config.data) {
      if (+this.config.data.promotionTypeId > 0) {
        this.model.promotionTypeId = +this.config.data.promotionTypeId;
      }
      if (this.config.data.promotionTypeId) {
        this.editMode = this.config.data.editMode;
      }

      
    }

  }

  ngOnInit(): void {

    this._commonCrudService.get("PromotionInput/GetAll", LookupModel).then(res => {
      if (res.succeeded = true) {
        this.inputs = res.data;
      }
      this.inputs.unshift({ id: 0, code: '--', name: '--' });
    })

    this._commonCrudService.get("PromotionOutput/GetAll", LookupModel).then(res => {
      if (res.succeeded = true) {
        this.outputs = res.data;
      }
      this.outputs.unshift({ id: 0, code: '--', name: '--' });
    })


    if(this.model.promotionTypeId>0){
      this.isLoading=true;

      this._commonCrudService.get("PromotionType/GetById?Id="+this.model.promotionTypeId, PromotionTypeModel).then(res=>{
        if(res.succeeded && res.data && res.data.promotionTypeId>0){

          this.model=res.data;

        }
        else
        {
          this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_ERROR });
          this.ref.close();
        }

        this.isLoading=false;
      })
    }
  }

  async Save() {

    let valid = true;
    if (this.model.promotionTypeCode.trim().length == 0) {
      valid = false;
    }
    if (this.model.promotionInputId == 0) {
      valid = false;
    }
    if (this.model.promotionOutputId == 0) {
      valid = false;
    }


    if (valid == false) {

      this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_INVALID });
      return;

    }

    this.isLoading = true;
    await this._commonCrudService.post("PromotionType/Save", this.model, PromotionTypeModel).then(res => {
      if (res.succeeded == true && res.data && res.data.promotionTypeId > 0) {
        this.ref.close();
      }
      else {
        this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_ERROR });

      }

    });
    this.isLoading = false;


  }

}
