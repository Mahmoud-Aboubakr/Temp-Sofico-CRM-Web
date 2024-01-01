import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { NotificationModel } from 'src/app/core/Models/EntityModels/NotificationModel';
import { UtilService } from 'src/app/core/services/util.service';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';


@Component({
  selector: 'app-manage-notification',
  templateUrl: './manage-notification.component.html',
  styleUrls: ['./manage-notification.component.scss']
})
export class ManageNotificationComponent implements OnInit {

  model: NotificationModel = {
    notificationId: 0,
    notificationDate: undefined,
    scheduleTime: undefined,
    notificationDateTime: undefined,
    priorityId: 0,
    message: '',
    notificationTypeId: 0,
    userGroupId: 0,
    UserId: 0
  };

  isLoading = false;
  CHOOSE = '';

  notificationTypes: LookupModel[] = [];
  userGroups: LookupModel[] = [];
  priorities: LookupModel[] = [];


  items: MenuItem[];

  showDocuments = false;

  constructor(

    private ref: DynamicDialogRef,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private _AppMessageService: AppMessageService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private activatedRoute: ActivatedRoute,
    private config: DynamicDialogConfig,
    private _UtilService: UtilService,
    private _commonCrudService : CommonCrudService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });
    
    this.model.notificationDate = _UtilService.LocalDate(new Date());
    this.model.scheduleTime = _UtilService.LocalDate(new Date());
    this.model.notificationDateTime = _UtilService.LocalDate(new Date());


    if (this.config.data) {

      if (+this.config.data.notificationId > 0) {
        this.model.notificationId = +this.config.data.notificationId
      }

    }
  }

  ngOnInit(): void {

    this._commonCrudService.get("NotificationType/GetAll", LookupModel).then(res=>{
      this.notificationTypes=res.data;
    })

    this._commonCrudService.get("UserGroup/GetAll", LookupModel).then(res=>{
      this.userGroups=res.data;
    })

    this._commonCrudService.get("Priority/GetAll", LookupModel).then(res=>{
      this.priorities=res.data;
    })
  }



  save() {
    let valid = true;

    if (this.model.userGroupId == undefined || this.model.userGroupId == 0) {
      valid = false;
      return;
    }

    if (this.model.priorityId == undefined || this.model.priorityId == 0) {
      valid = false;
      return;
    }

    if (this.model.notificationTypeId == undefined || this.model.notificationTypeId == 0) {
      valid = false;
      return;
    }


    if (this.model.message == undefined ||this.model.message==null || this.model.message == '0') {
      valid = false;
      return;
    }
  

    if (valid == true) {

      this.isLoading = true;

      this._commonCrudService.post("Notification/Save",this.model, NotificationModel).then(res => {
        
        this.isLoading = false;
                
        if (res.succeeded == true && res.data.notificationId > 0) {
          this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });
          this.ref.close(this.model);
          this.model.notificationId=res.data.notificationId;
        }
        else {
          this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });
        }
      })

    }


  }
}
