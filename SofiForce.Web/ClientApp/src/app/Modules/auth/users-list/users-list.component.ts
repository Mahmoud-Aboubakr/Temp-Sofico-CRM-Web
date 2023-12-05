import { Component, OnInit } from '@angular/core';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TranslateService } from '@ngx-translate/core';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { SalesOrderModel } from 'src/app/core/Models/EntityModels/salesOrderModel';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { ChooserBranchComponent } from '../../shared/chooser-branch/chooser-branch.component';
import { ChooserClientComponent } from '../../shared/chooser-client/chooser-client.component';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { SalesOrderSourceService } from 'src/app/core/services/SalesOrderSource.Service';
import { SalesOrderStatusService } from 'src/app/core/services/SalesOrderStatus.Service';
import { PaymentTermService } from 'src/app/core/services/PaymentTerm.Service';
import { PriorityService } from 'src/app/core/services/Priority.Service';
import { SalesOrderTypeService } from 'src/app/core/services/SalesOrderType.Service';
import { UtilService } from 'src/app/core/services/util.service';
import { MenuService } from 'src/app/core/services/Menu.Service';
import { ClientRouteListModel } from 'src/app/core/Models/ListModels/ClientRouteListModel';
import { ClientRouteSearchModel } from 'src/app/core/Models/SearchModels/ClientRouteSearchModel';
import { ClientRouteService } from 'src/app/core/services/ClientRoute.Service';
import { UploaderService } from 'src/app/core/services/uploader.service';
import { FileModel } from 'src/app/core/Models/DtoModels/FileModel';
import { AppUserService } from 'src/app/core/services/AppUser.Service';
import { AppUserListModel } from 'src/app/core/Models/ListModels/AppUserListModel';
import { AppUserSearchModel } from 'src/app/core/Models/SearchModels/AppUserSearchModel';
import { AppUserModel } from 'src/app/core/Models/EntityModels/appUserModel';
import { ManageUserAccessComponent } from '../components/manage-user-access/manage-user-access.component';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {


  orderModel: SalesOrderModel = {
    customDiscountTotal: 0,
    itemDiscountTotal: 0,
    taxTotal: 0,
    netTotal: 0,
    cashDiscountTotal: 0,
    itemTotal: 0,
    salesDate: this._UtilService.LocalDate(new Date()),
  } as SalesOrderModel;

  model: ResponseModel<AppUserListModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: []
  };


  isLoading = false;
  isUploadDone = false;
  first = 0;
  advanced = false;
  showUpload = false;

  orderTypes: LookupModel[] = [];


  CHOOSE = '';
  MANAGE = "";

  NewPassword = "";

ShowReset=false;

  searchModel: AppUserSearchModel = {
    SortBy: { Order: "asc", Property: "clientId" },
    appRoleId: 0,
    userGroupId: 0,
    isOnline: 0,
    isLocked: 0,
    lastLogin: null,
    mustChangePassword: 0,
    Take: 30,
    Skip: 0,
    Term: '',
    TermBy: '',
    FilterBy: []
  }
  menuItems: MenuItem[];
  cMenuItems: MenuItem[];
  selected: AppUserListModel;

  Payments: LookupModel[] = [];
  Priorites: LookupModel[] = [];
  Status: LookupModel[] = [];
  Types: LookupModel[] = [];
  Sources: LookupModel[] = [];

  file: FileModel = {
    directory: "",
    fileName: "",
    fileSize: 0,
    fileUrl: "",
  };
  searchBy: LookupModel[] = [
    { id: 1, code: 'userName', name: 'User Name' },
    { id: 2, code: 'realName', name: 'Real Name' },

  ];

  constructor(
    private _AppUserService: AppUserService,
    private _translationLoaderService: TranslationLoaderService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _AppMessageService: AppMessageService,

    private _UtilService: UtilService,
    private uploaderService: UploaderService,
    private ref: DynamicDialogRef,
    private _MenuService: MenuService,
  ) {

    this._translationLoaderService.loadTranslations(english, arabic);

    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });
    this._translateService.get('Manage User Access').subscribe((res) => { this.MANAGE = res });


    var found = localStorage.getItem("users-list.component.termBy")
    if (found) {
      this.searchModel.TermBy = found;
    }


    this.menuItems = [
      {
        label: 'Create New',
        icon: 'pi pi-fw pi-upload',
        command: (event) => this.manage('new'),
      },

    ];


    this.cMenuItems = [
      {
        label: 'Manage User',
        icon: 'fa fa-pencil-square-o',
        command: (event) => this.manage('manage'),
      },
      {
        label: 'Delete',
        icon: 'fa fa-times',
        command: (event) => this.manage('delete'),
      },
      {
        label: 'Reset Password',
        icon: 'fa fa-key',
        command: (event) => this.manage('reset'),
      },
      {
        label: 'Activate',
        icon: 'fa fa-toggle-on',
        command: (event) => this.manage('activate'),
      },
      {
        label: 'De activate',
        icon: 'fa fa-toggle-off',
        command: (event) => this.manage('deactivate'),
      },
      {
        label: 'Force Logout',
        icon: 'fa fa-power-off',
        command: (event) => this.manage('logout'),
      },
    ];

  }


  OnTermChange(arg) {
    localStorage.setItem("users-list.component.termBy", arg.value);
  }

  ngOnInit(): void {


  }


  async filter(event) {


    this.isLoading = true;
    this.searchModel.Skip = event.first;
    this.searchModel.Take = event.rows;


    this.searchModel.SortBy = { Order: "", Property: "" }
    if (event.sortField) {
      this.searchModel.SortBy.Property = event.sortField;
      if (event.sortOrder == 1) {
        this.searchModel.SortBy.Order = "asc";
      }
      else {
        this.searchModel.SortBy.Order = "desc";

      }
    }

    await this._AppUserService.Filter(this.searchModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._AppUserService.Filter(this.searchModel).then(res => {
        this.model = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {

    this.isLoading = true;
    await this._AppUserService.Filter(this.searchModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    await this._AppUserService.Filter(this.searchModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })
  }
  async clearFilter() {
    this.first = 0;
    this.isLoading = true;
    this.searchModel = {

      SortBy: { Order: "asc", Property: "clientId" },
      appRoleId: 0,
      userGroupId: 0,
      isOnline: 0,
      isLocked: 0,
      lastLogin: null,
      mustChangePassword: 0,
      Take: 30,
      Skip: 0,
      Term: '',
      TermBy: '',
      FilterBy: []
    }
    await this._AppUserService.Filter(this.searchModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })

  }

  async manage(mode) {

    if (mode == "new") {
      var ref = this.dialogService.open(ManageUserAccessComponent, {
        data: { userId: 0 },
        header: this.MANAGE,
        width: '90%',
        modal: true,
        height: "90%"
      });

      ref.onClose.subscribe((user: AppUserListModel) => {
        this.reloadFilter();
      });
    }
    if (mode == "manage") {
      if (this.selected && this.selected.userId > 0) {
        var ref = this.dialogService.open(ManageUserAccessComponent, {
          data: { userId: this.selected.userId },
          header: this.MANAGE,
          width: '90%',
          modal: true,
          height: "90%"
        });

        ref.onClose.subscribe((user: AppUserListModel) => {
          this.reloadFilter();
        });
      }

    }

    if (mode == "delete") {
      if (this.selected != null && this.selected.userId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;
            let user: AppUserModel = {
              userId: this.selected.userId,
            } as AppUserModel;

            this._AppUserService.Delete(user).then(re => {
              this.reloadFilter();
            })


          },
          reject: () => {
            //reject action
          }
        });
      }

    }

    if (mode == "activate") {
      if (this.selected != null && this.selected.userId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;
            let user: AppUserModel = {
              userId: this.selected.userId,
            } as AppUserModel;

            this._AppUserService.Activate(user).then(re => {
              this.reloadFilter();
            })


          },
          reject: () => {
            //reject action
          }
        });
      }

    }

    if (mode == "deactivate") {
      if (this.selected != null && this.selected.userId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;
            let user: AppUserModel = {
              userId: this.selected.userId,
            } as AppUserModel;

            this._AppUserService.DeActivate(user).then(re => {
              this.reloadFilter();
            })


          },
          reject: () => {
            //reject action
          }
        });
      }

    }

    if (mode == "logout") {
      if (this.selected != null && this.selected.userId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;
            let user: AppUserModel = {
              userId: this.selected.userId,
            } as AppUserModel;

            this._AppUserService.DeActivate(user).then(re => {
              this.reloadFilter();
            })


          },
          reject: () => {
            //reject action
          }
        });
      }

    }

    if (mode == "reset") {
    

      this.ShowReset=true;

    }


  }
  async ResetPassword(){
    if (this.selected != null && this.selected.userId > 0 && this.NewPassword &&this.NewPassword.length>=5) {
      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {

          this.isLoading = true;
          let user: AppUserModel = {
            userId: this.selected.userId,
            password:this.NewPassword
          } as AppUserModel;

          this._AppUserService.ResetPassword(user).then(re => {
            this.isLoading=false;
            this.ShowReset=false;
          })


        },
        reject: () => {
          //reject action
        }
      });
    }
  }
  async onSelectionChange(event) {
    this.selected = event;

  }
}
