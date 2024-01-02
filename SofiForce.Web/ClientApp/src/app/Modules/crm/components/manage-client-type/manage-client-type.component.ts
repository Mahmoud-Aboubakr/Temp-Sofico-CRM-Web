import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';

import { AppMessageService } from 'src/app/core/services/AppMessage.Service';

import { AlertService } from 'src/app/core/services/Alert.Service';
import { ClientClassificationModel } from 'src/app/core/Models/EntityModels/ClientClassificationModel';
import { ClientTypeModel } from 'src/app/core/Models/EntityModels/ClientTypeModel';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';
@Component({
  selector: 'app-manage-client-type',
  templateUrl: './manage-client-type.component.html',
  styleUrls: ['./manage-client-type.component.scss']
})
export class ManageClientTypeComponent implements OnInit {


  model = {
clientTypeId:0,

  } as ClientTypeModel;
  isLoading = true;
  CHOOSE_BRANCH = '';

  constructor(
    private _AppMessageService: AppMessageService,

    private ref: DynamicDialogRef,
    private messageService: MessageService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private config: DynamicDialogConfig,
    private _AlertService: AlertService,
    private _commonCrudService : CommonCrudService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);

    this.model.isActive = true;

  }
  ngOnInit(): void {
    this.init();
  }

  async init() {

    if (this.config.data && this.config.data.clientTypeId > 0) {
      await this._commonCrudService.get("ClientType/getById?Id="+this.config.data.clientTypeId,ClientTypeModel).then(res => {
        if (res.succeeded == true) {
          this.model = res.data;
        }
      })
    }

    this.isLoading = false;

  }


  Save() {

    if (this.model.clientTypeNameAr == null || this.model.clientTypeNameEn.trim().length == 0) {
      this._AlertService.Show('error', this._AppMessageService.MESSAGE_ERROR)
      return;
    }



    this.isLoading = true;
    this._commonCrudService.post("ClientType/Save",this.model,ClientTypeModel).then(res => {

      if (res.succeeded == true) {
        this.ref.close();
        this._AlertService.Show('success', this._AppMessageService.MESSAGE_OK)
      }
      else {
        this._AlertService.Show('error', this._AppMessageService.MESSAGE_ERROR)
      }
      this.isLoading = false;
    })

  }


}
