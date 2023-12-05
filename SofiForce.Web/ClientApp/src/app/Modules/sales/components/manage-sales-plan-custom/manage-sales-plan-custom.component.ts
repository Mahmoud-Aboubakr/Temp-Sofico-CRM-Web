import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { UploaderService } from 'src/app/core/services/uploader.service';


import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';

import { JourneyUploadModel } from 'src/app/core/Models/DtoModels/JourneyUploadModel';
import { ClientPlanService } from 'src/app/core/services/ClientPlan.Service';
import { ClientPlanModel } from 'src/app/core/Models/EntityModels/ClientPlanModel';
import { ClientModel } from 'src/app/core/Models/EntityModels/clientModel';
import { ChooserClientComponent } from 'src/app/Modules/shared/chooser-client/chooser-client.component';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';

@Component({
  selector: 'app-manage-sales-plan-custom',
  templateUrl: './manage-sales-plan-custom.component.html',
  styleUrls: ['./manage-sales-plan-custom.component.scss']
})
export class ManageSalesPlanCustomComponent implements OnInit {


  isUploadDone = false;
  isLoading = false;



  model: ClientPlanModel = {} as ClientPlanModel;

  SELECT_CLIENT = '';



  constructor(

    private _Messages: AppMessageService,
    private ref: DynamicDialogRef,
    private messageService: MessageService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private _ClientPlanService: ClientPlanService,
    private uploaderService: UploaderService,
    private config: DynamicDialogConfig,
    private confirmationService: ConfirmationService
  ) {
    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Select Client').subscribe((res) => { this.SELECT_CLIENT = res });


    this.model.planYear = new Date().getFullYear();
    this.model.planMonth = new Date().getMonth() + 1;
    this.model.cDate = new Date();
    this.model.targetCall = 0;
    this.model.targetValue = 0;
    this.model.targetVisit = 0;


    this.model.clientCode = '';

    if (this.config.data) {
      if(+this.config.data.planId>0){
        this.model.planId= +this.config.data.planId
      }

    }
  }

  ngOnInit(): void {
    if (this.model.planId > 0) {
      this.fillModel();
    }

  }
  async fillModel() {

    await this._ClientPlanService.getById(this.model.planId).then(res => {
      if (res.succeeded) {
        if (res.data && res.data.planId > 0) {
          this.model = res.data;
        }
        else {
          this.ref.close();

        }
      }
      else {
        this.ref.close();
      }
    })

  }
  async save(event: Event) {


    if (!this.model.clientId || this.model.clientId == 0) {
      this.messageService.add({ severity: 'error', detail: this._Messages.MESSAGE_INVALID });
      return;
    }

    this.confirmationService.confirm({
      target: event.target,
      message: this._Messages.MESSAGE_CONFIRM,
      accept: async () => {
        this.isLoading = true;

        await this._ClientPlanService.Save(this.model).then(res => {
          if (res.succeeded == true) {

            this.model.planYear = new Date().getFullYear();
            this.model.planMonth = new Date().getMonth() + 1;
            this.model.cDate = new Date();
            this.model.targetCall = 0;
            this.model.targetValue = 0;
            this.model.targetVisit = 0;
            this.model.clientCode = '';
            this.model.clientId = 0;
            this.messageService.add({ severity: 'success', detail: this._Messages.MESSAGE_OK });
            this.ref.close();
          }
          else {
            this.messageService.add({ severity: 'error', detail: this._Messages.MESSAGE_ERROR });
          }
          this.isLoading = false;

        })
      },
      reject: () => {
        //reject action
      }
    });

  }

  async Chooser_Client() {
    var ref = this.dialogService.open(ChooserClientComponent, {
      header: this.SELECT_CLIENT,
      width: '80%',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });

    ref.onClose.subscribe((res: ClientListModel) => {
      this.model.clientId = res.clientId;
      this.model.clientCode = res.clientCode;
    });
  }

}
