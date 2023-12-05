import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { MenuItem } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';

import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';

import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';

import { NotificationService } from 'src/app/core/services/Notification.Service';
import { NotificationListModel } from 'src/app/core/Models/ListModels/NotificationListModel';
import { NotificationSearchModel } from 'src/app/core/Models/SearchModels/NotificationSearchModel';
import { ManageNotificationComponent } from '../components/manage-notification/manage-notification.component';
import { NotificationTypeService } from 'src/app/core/services/NotificationType.Service';
import { UserGroupService } from 'src/app/core/services/UserGroup.Service';
import { PriorityService } from 'src/app/core/services/Priority.Service';
import { UtilService } from 'src/app/core/services/util.service';
import { UserNotificationListModel } from 'src/app/core/Models/ListModels/UserNotificationListModel';
import { NotificationModel } from 'src/app/core/Models/EntityModels/NotificationModel';
import { BooleanService } from 'src/app/core/services/Boolean.Service';
import { MenuService } from 'src/app/core/services/Menu.Service';

@Component({
  selector: 'app-my-notifications',
  templateUrl: './my-notifications.component.html',
  styleUrls: ['./my-notifications.component.scss']
})
export class MyNotificationsComponent implements OnInit {

  gridModel: ResponseModel<UserNotificationListModel[]> = {
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
    isReaded: 0,
    TermBy:""
  }

  advanced = false;
  isLoading = false;
  first = 0;
  menuItems: MenuItem[];

  selected: UserNotificationListModel = {} as UserNotificationListModel;




  MANAGE_HEADER = '';


  notificationTypes: LookupModel[] = [];
  userGroups: LookupModel[] = [];
  priorities: LookupModel[] = [];
  Status: LookupModel[] = [];

  showNotification = false;

  constructor(

    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private _NotificationService: NotificationService,
    private _NotificationTypeService: NotificationTypeService,
    private _UserGroupService: UserGroupService,
    private _PriorityService: PriorityService,
    private _UtilService: UtilService,
    private _BooleanService: BooleanService,
    private _MenuService:MenuService,


  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Manage Notification').subscribe((res) => { this.MANAGE_HEADER = res });

    this.selected.message = '';





  }


  async onSelectionChange(event) {
    this.selected = event;
  }

  ngOnInit(): void {


    this.menuItems = [
      {
        label: 'View',
        icon: 'pi pi-fw pi-eye',
        command: (e) => this.manage('v')
      },

    ];

    this._NotificationTypeService.GetAll().then(res => {
      this.notificationTypes = res.data;
      this.notificationTypes.unshift({ id: 0, code: '0', name: '--' })

    })

    this._UserGroupService.GetAll().then(res => {
      this.userGroups = res.data;
      this.userGroups.unshift({ id: 0, code: '0', name: '--' })

    })

    this._PriorityService.GetAll().then(res => {
      this.priorities = res.data;
      this.priorities.unshift({ id: 0, code: '0', name: '--' })

    })


    
    this.Status.push({ id: 0, code: '0', name: '--' });
    this.Status.push({ id: 1, code: '1', name: 'Readed Only' });
    this.Status.push({ id: 2, code: '2', name: 'Un Readed Only' });



  }

  async manage(operation) {
    if (operation == 'v') {
      this.showNotification = true;
    }

  }


  async filter(event) {
    console.log(event);
    this.isLoading = true;
    this.searchModel.Skip = event.first;
    this.searchModel.Take = event.rows;
    console.log(this.searchModel);

    this.searchModel.SortBy = { Order: "notificationId", Property: "desc" }
    if (event.sortField) {
      this.searchModel.SortBy.Property = event.sortField;
      if (event.sortOrder == 1) {
        this.searchModel.SortBy.Order = "asc";
      }
      else {
        this.searchModel.SortBy.Order = "desc";

      }
    }

    await this._NotificationService.My(this.searchModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      this.selected = {} as UserNotificationListModel;
      this.selected.message = '';


      await this._NotificationService.My(this.searchModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {

    this.isLoading = true;
    this.selected = {} as UserNotificationListModel;
    this.selected.message = '';


    await this._NotificationService.My(this.searchModel).then(res => {
      this.gridModel = res;

      var unreadedCount = res.data.filter(re => re.isReaded == false).length;
      this._NotificationService.notificationCount.next(unreadedCount);

      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.selected = {} as UserNotificationListModel;
    this.selected.message = '';


    this.searchModel.Skip = 0;
    await this._NotificationService.My(this.searchModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel = {
      Take: 30,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: undefined,
      notificationDate: undefined,
      priorityId: 0,
      notificationTypeId: 0,
      userGroupId: 0,
      isReaded: 0,
      TermBy:""
    }

  }

  markAsReaded() {
    this.isLoading = true;
    let model = {} as NotificationModel;
    model.notificationId = this.selected.notificationId
    this._NotificationService.MarkAsRead(model).then(res => {
      this.reloadFilter();
      this.isLoading = false;
      this.showNotification = false;
    });
  }

}