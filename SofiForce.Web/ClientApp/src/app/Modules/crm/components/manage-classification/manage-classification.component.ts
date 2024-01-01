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
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-manage-classification',
  templateUrl: './manage-classification.component.html',
  styleUrls: ['./manage-classification.component.scss']
})
export class ManageClassificationComponent implements OnInit {


  model = {
    clientClassificationId: 0,

  } as ClientClassificationModel;
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

    if (this.config.data && this.config.data.clientClassificationId > 0) {
      await this._commonCrudService.get("Representative/getById?Id="+this.config.data.clientClassificationId, ClientClassificationModel).then(res => {
        if (res.succeeded == true) {
          this.model = res.data;
        }
      })
    }

    this.isLoading = false;

  }


  Save() {

    if (this.model.clientClassificationNameAr == null || this.model.clientClassificationNameEn.trim().length == 0) {
      this._AlertService.Show('error', this._AppMessageService.MESSAGE_ERROR)
      return;
    }



    this.isLoading = true;
    this._commonCrudService.post("ClientClassification/Save",this.model, ClientClassificationModel).then(res => {

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
