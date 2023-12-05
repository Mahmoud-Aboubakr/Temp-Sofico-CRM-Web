import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';

import { AppMessageService } from 'src/app/core/services/AppMessage.Service';

import { AlertService } from 'src/app/core/services/Alert.Service';
import { ClientGroupModel } from 'src/app/core/Models/EntityModels/ClientGroupModel';
import { ClientGroupService } from 'src/app/core/services/ClientGroup.Service';
@Component({
  selector: 'app-manage-channel-main',
  templateUrl: './manage-channel-main.component.html',
  styleUrls: ['./manage-channel-main.component.scss']
})
export class ManageChannelMainComponent implements OnInit {


  model = {
clientGroupId:0,

  } as ClientGroupModel;
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

    private _ClientGroupService: ClientGroupService,
    private _AlertService: AlertService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);

    this.model.isActive=true;

  }
  ngOnInit(): void {
    this.init();
  }

  async init() {

    if (this.config.data && this.config.data.clientGroupId>0) {
      await this._ClientGroupService.getById(+this.config.data.clientGroupId).then(res=>{
        if(res.succeeded==true){
          this.model=res.data;
        }
      })
    }

    this.isLoading = false;

  }


  Save() {

    if (this.model.clientGroupNameAr == null || this.model.clientGroupNameEn.trim().length == 0) {
      this._AlertService.Show('error', this._AppMessageService.MESSAGE_ERROR)
      return;
    }

   

    this.isLoading = true;
    this._ClientGroupService.Save(this.model).then(res => {

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
