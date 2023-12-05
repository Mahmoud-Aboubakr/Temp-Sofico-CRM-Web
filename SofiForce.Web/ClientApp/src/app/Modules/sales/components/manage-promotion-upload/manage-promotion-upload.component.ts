import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import {  supplementaryUploadDtoModel } from 'src/app/core/Models/DtoModels/FilePathModel';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { ClientPlanService } from 'src/app/core/services/ClientPlan.Service';
import { PromotionService } from 'src/app/core/services/promotion/Promotion.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { UploaderService } from 'src/app/core/services/uploader.service';

@Component({
  selector: 'app-manage-promotion-upload',
  templateUrl: './manage-promotion-upload.component.html',
  styleUrls: ['./manage-promotion-upload.component.scss']
})
export class ManagePromotionUploadComponent implements OnInit {

  isLoading = false;
  isUploadDone = false;

  model: supplementaryUploadDtoModel = {
    filePath: '',
    errors:[],
    inValidCount:0,
    validCount:0
  };

  clearCurrent = false;
  constructor(

    private ref: DynamicDialogRef,
    private messageService: MessageService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private _ClientPlanService: ClientPlanService,
    private uploaderService: UploaderService,
    private config: DynamicDialogConfig,
    private _AppMessageService: AppMessageService,
    private _PromotionService: PromotionService,


  ) { }

  ngOnInit(): void {
  }


  myUploader(event, form) {

    this.isLoading = true;
    this.isUploadDone = false;
    this.model.filePath = '';
    this.model.errors=[];
    this.model.inValidCount=0;
    this.model.validCount=0;

    event.files.forEach(file => {
      this.uploaderService.Upload(file).then(res => {
        this.model.errors=[];
        if (res.succeeded == true) {
          this.isUploadDone = true;
          this.model.filePath = res.data.fileName;
        }
        this.isLoading = false;
      })
    });

    form.clear();

  }

  async save() {
    if (this.model.filePath == null || this.model.filePath.trim().length == 0) {

      return;
    }


    this.isLoading = true;
    this._PromotionService.Upload(this.model).then(res => {

      this.model=res.data;

      if (res.succeeded == true) {
        this.ref.close();
        this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });
      }
      else {
        this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
      }
      this.isLoading = false;
    })
  }

}
