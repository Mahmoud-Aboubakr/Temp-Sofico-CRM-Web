import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { BranchService } from 'src/app/core/services/Branch.Service';
import { ClientComplainService } from 'src/app/core/services/ClientComplain.Service';
import { RepresentativeService } from 'src/app/core/services/Representative.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { ClientComplainModel } from 'src/app/core/Models/EntityModels/ClientComplainModel';
import { ChooserClientComponent } from 'src/app/Modules/shared/chooser-client/chooser-client.component';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { ChooserRepresentativeComponent } from 'src/app/Modules/shared/chooser-representative/chooser-representative.component';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { ComplainTypeService } from 'src/app/core/services/ComplainType.Service';
import { ComplainTypeDetailService } from 'src/app/core/services/ComplainTypeDetail.Service';
import { DepartmentService } from 'src/app/core/services/Department.Service';
import { ComplainStatusService } from 'src/app/core/services/ComplainStatus.Service';
import { PriorityService } from 'src/app/core/services/Priority.Service';
import { UploaderService } from 'src/app/core/services/uploader.service';
import { ClientComplainDocumentModel } from 'src/app/core/Models/EntityModels/ClientComplainDocumentModel';
import { ClientService } from 'src/app/core/services/Client.Service';
import { NotificationModel } from 'src/app/core/Models/EntityModels/NotificationModel';
import { UtilService } from 'src/app/core/services/util.service';
import { NotificationTypeService } from 'src/app/core/services/NotificationType.Service';
import { UserGroupService } from 'src/app/core/services/UserGroup.Service';
import { NotificationService } from 'src/app/core/services/Notification.Service';


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
    private _NotificationService: NotificationService,
    private activatedRoute: ActivatedRoute,
    private config: DynamicDialogConfig,
    private _NotificationTypeService: NotificationTypeService,
    private _UserGroupService: UserGroupService,
    private _PriorityService: PriorityService,
    private _UtilService: UtilService,

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

    this._NotificationTypeService.GetAll().then(res=>{
      this.notificationTypes=res.data;
    })

    this._UserGroupService.GetAll().then(res=>{
      this.userGroups=res.data;
    })

    this._PriorityService.GetAll().then(res=>{
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

      this._NotificationService.Save(this.model).then(res => {
        
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
