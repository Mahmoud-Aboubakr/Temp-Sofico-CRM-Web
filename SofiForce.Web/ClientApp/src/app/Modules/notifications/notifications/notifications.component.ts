import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';

import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';

import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { NotificationListModel } from 'src/app/core/Models/ListModels/NotificationListModel';
import { NotificationSearchModel } from 'src/app/core/Models/SearchModels/NotificationSearchModel';
import { ManageNotificationComponent } from '../components/manage-notification/manage-notification.component';
import { UtilService } from 'src/app/core/services/util.service';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.scss']
})
export class NotificationsComponent implements OnInit {

  gridModel: ResponseModel<NotificationListModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }

  searchModel: NotificationSearchModel = {
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    notificationDate: undefined,
    priorityId: 0,
    notificationTypeId: 0,
    userGroupId: 0,
    isReaded:0,
    TermBy:""
  }

  advanced = false;
  isLoading = false;
  first = 0;
  menuItems: MenuItem[];
  selected: NotificationListModel;




  MANAGE_HEADER = '';


  notificationTypes: LookupModel[] = [];
  userGroups: LookupModel[] = [];
  priorities: LookupModel[] = [];

  constructor(

    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private _UtilService: UtilService,
    private _commonCrudService : CommonCrudService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Manage Notification').subscribe((res) => { this.MANAGE_HEADER = res });


  }

  ngOnInit(): void {

    this.menuItems = [
      {
        label: 'Create',
        icon: 'pi pi-fw pi-plus',
        command: (e) => this.manage('create')
      },
    ];


    this._commonCrudService.get("NotificationType/GetAll", LookupModel).then(res=>{
      this.notificationTypes=res.data;
      this.notificationTypes.unshift({id:0,code:'0',name:'--'})

    })

    this._commonCrudService.get("UserGroup/GetAll", LookupModel).then(res=>{
      this.userGroups=res.data;
      this.userGroups.unshift({id:0,code:'0',name:'--'})

    })

    this._commonCrudService.get("Priority/GetAll",LookupModel).then(res=>{
      this.priorities=res.data;
      this.priorities.unshift({id:0,code:'0',name:'--'})

    })
  

  }

  async manage(operation) {
    if (operation == 'create') {
      var ref = this.dialogService.open(ManageNotificationComponent, {
        header: this.MANAGE_HEADER,
        width: '400px',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });

      ref.onClose.subscribe(() => {
        this.selected = null;
        this.reloadFilter();
      });
    }

  }


  async filter(event) {
    console.log(event);
    this.isLoading = true;
    this.searchModel.Skip = event.first;
    this.searchModel.Take = event.rows;
    console.log(this.searchModel);

    this.searchModel.SortBy = { Order: "desc", Property: "notificationId" }
    
    if (event.sortField) {
      this.searchModel.SortBy.Property = event.sortField;
      if (event.sortOrder == 1) {
        this.searchModel.SortBy.Order = "asc";
      }
      else {
        this.searchModel.SortBy.Order = "desc";

      }
    }

    await this._commonCrudService.post("Notification/Filter", this.searchModel, NotificationListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      this.selected=null;

      await this._commonCrudService.post("Notification/Filter", this.searchModel, NotificationListModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {

    this.isLoading = true;
    this.selected=null;
      
    await this._commonCrudService.post("Notification/Filter", this.searchModel, NotificationListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.selected=null;
      
    this.searchModel.Skip = 0;
    await this._commonCrudService.post("Notification/Filter", this.searchModel, NotificationListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel={
      Take: 30,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: undefined,
      notificationDate: undefined,
      priorityId: 0,
      notificationTypeId: 0,
      userGroupId: 0,
      isReaded:0,
      TermBy:""
    }
    
  }
}
