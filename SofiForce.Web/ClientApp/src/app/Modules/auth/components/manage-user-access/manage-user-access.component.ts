import { Component, Input, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { AppUserModel } from 'src/app/core/Models/EntityModels/appUserModel';
import { ApplicationFeatureService } from 'src/app/core/services/ApplicationFeature.Service';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { AppRoleService } from 'src/app/core/services/AppRole.Service';
import { AppUserGroupService } from 'src/app/core/services/AppUserGroup.Service';
import { BranchService } from 'src/app/core/services/Branch.Service';
import { BusinessUnitService } from 'src/app/core/services/BusinessUnit.Service';
import { RepresentativeService } from 'src/app/core/services/Representative.Service';
import { RepresentativeComissionService } from 'src/app/core/services/RepresentativeComission.Service';
import { RepresentativeJourneyService } from 'src/app/core/services/RepresentativeJourney.Service';
import { RepresentativeKindService } from 'src/app/core/services/RepresentativeKind.Service';
import { SupervisorService } from 'src/app/core/services/Supervisor.Service';
import { TerminationReasonService } from 'src/app/core/services/TerminationReason.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { UserService } from 'src/app/core/services/User.Service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { AppUserService } from 'src/app/core/services/AppUser.Service';
import { SupervisorModel } from 'src/app/core/Models/EntityModels/supervisorModel';
import { RepresentativeModel } from 'src/app/core/Models/EntityModels/representativeModel';
import { AppUserBranchListModel } from 'src/app/core/Models/ListModels/AppUserBranchListModel';
import { AppUserStoreListModel } from 'src/app/core/Models/ListModels/AppUserStoreListModel';
import { ChooserBranchComponent } from 'src/app/Modules/shared/chooser-branch/chooser-branch.component';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { AppUserBranchService } from 'src/app/core/services/AppUserBranch.Service';
import { AppUserBranchModel } from 'src/app/core/Models/EntityModels/appUserBranchModel';
import { ChooserStoreComponent } from 'src/app/Modules/shared/chooser-store/chooser-store.component';
import { StoreListModel } from 'src/app/core/Models/ListModels/StoreListModel';
import { AppUserStoreModel } from 'src/app/core/Models/EntityModels/appUserStoreModel';
import { AppUserStoreService } from 'src/app/core/services/AppUserStore.Service';
import { AppUserClientGroupListModel } from 'src/app/core/Models/ListModels/AppUserClientGroupListModel';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { SupervisorComissionService } from 'src/app/core/services/SupervisorComission.Service';
import { SupervisorListModel } from 'src/app/core/Models/ListModels/SupervisorListModel';
import { ChooserSupervisorComponent } from 'src/app/Modules/shared/chooser-supervisor/chooser-supervisor.component';
import { ChooserRepresentativeComponent } from 'src/app/Modules/shared/chooser-representative/chooser-representative.component';
import { ChooserClientGroupComponent } from 'src/app/Modules/shared/chooser-client-group/chooser-client-group.component';
import { ClientGroupListModel } from 'src/app/core/Models/ListModels/ClientGroupListModel';
import { AppUserClientGroupModel } from 'src/app/core/Models/EntityModels/AppUserClientGroupModel';
import { AppUserClientGroupService } from 'src/app/core/services/AppUserClientGroup.Service';

@Component({
  selector: 'app-manage-user-access',
  templateUrl: './manage-user-access.component.html',
  styleUrls: ['./manage-user-access.component.scss']
})
export class ManageUserAccessComponent implements OnInit {

  operationId: number;
  selectedIndex = 1;
  isLoading = false;
  items: MenuItem[];

  model: AppUserModel = {
    userId: 0,
    userName: '',
    mustChangeData: false,
    mustChangePassword: false,
    isLocked: false,
    branchs: [],
    stores: [],
    representatives: [],
    supervisors: [],
    clientGroups: [],
    defaultRoute: '',
    appRoleId: 0,
    userGroupId: 0,
    realName: '',
    password: '',
    isOnline: false,
    lastLogin: undefined,
    emailVerified: false,
    firebaseId: '',
    signalrId: '',
    failedCount: 0,
    phone: '',
    whatsApp: '',
    mobile: '',
    zoomId: '',
    linkedIn: '',
    userBio: '',
    latitude: 0,
    longitude: 0,
    email: '',
    internal: '',
    jobTitle: '',
    address: '',
    zoom: '',
    fax: '',
    avatar: ''
  };

  appRoles: LookupModel[] = [];
  userGroups: LookupModel[] = [];
  appFeatures: LookupModel[] = [];


  representativeId: 0;
  supervisorId: 0;


  selectedBranch: AppUserBranchListModel;
  selectedStore: AppUserStoreListModel;

  selectedSupervisor: SupervisorListModel;
  selectedRep: RepresentativeListModel;
  selectedClientGroup: AppUserClientGroupListModel;

  CHOOSE = '';
  constructor(
    private _AppMessageService: AppMessageService,

    private ref: DynamicDialogRef,
    private messageService: MessageService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private config: DynamicDialogConfig,
    private _RepresentativeKindService: RepresentativeKindService,
    private _RepresentativeService: RepresentativeService,
    private _TerminationReasonService: TerminationReasonService,
    private _BranchService: BranchService,
    private _SupervisorService: SupervisorService,
    private _BusinessUnitService: BusinessUnitService,
    private _RepresentativeComissionService: RepresentativeComissionService,
    private confirmationService: ConfirmationService,
    private _UserService: UserService,
    private _RepresentativeJourneyService: RepresentativeJourneyService,
    private _AppRoleService: AppRoleService,
    private _ApplicationFeatureService: ApplicationFeatureService,
    private _AppUserGroupService: AppUserGroupService,
    private _AppUserClientGroupService:AppUserClientGroupService,
    private _AppUserService: AppUserService,
    private _AppUserBranchService: AppUserBranchService,
    private _AppUserStoreService: AppUserStoreService,



  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });

    if (this.config.data && +this.config.data.userId) {
      this.model.userId = +this.config.data.userId;
    }


  }

  ngOnInit() {


    this.items = [
      {
        label: 'User Info',
        icon: 'fa fa-info-circle',
        command: (e) => this.manage(1)
      },
      {
        label: 'Branchs',
        icon: 'fa fa-map-marker',
        command: (e) => this.manage(2)
      },
      {
        label: 'Warehouses',
        icon: 'fa fa-building',
        command: (e) => this.manage(3)
      },
      {
        label: 'Supervisors',
        icon: 'fa fa-street-view',
        command: (e) => this.manage(4)
      },
      {
        label: 'Represetitives',
        icon: 'fa fa-male',
        command: (e) => this.manage(5)
      },
      {
        label: 'Sales Channels',
        icon: 'fa fa-cubes',
        command: (e) => this.manage(6)
      },

    ];



    this._AppRoleService.GetAll().then(res => {
      this.appRoles = res.data;
      this.appRoles.unshift({ id: 0, code: '0', name: '--' });
    })

    this.appFeatures.unshift({ id: 0, code: '0', name: '--' });

    this._AppUserGroupService.GetAll().then(res => {
      this.userGroups = res.data;
      this.userGroups.unshift({ id: 0, code: '0', name: '--' });
    })



    if (this.model.userId > 0) {
      this.isLoading = true;
      this._AppUserService.GetById(this.model.userId).then(res => {
        if (res.succeeded == true) {
          this.model = res.data;

          if(this.model.appRoleId>0){
            this._ApplicationFeatureService.GetByRoleId(this.model.appRoleId).then(res=>{
              this.appFeatures=res.data;
            })
          }
        }
        this.refreshMenu();

        this.isLoading = false;

      })
    }
    else {
      this.refreshMenu();

    }

  }

  async manage(index) {
    this.selectedIndex = index;
  }
  Save() {


    if (this.model.userName == null || this.model.realName.length==0) {
      return;
    }

    if (this.model.realName == null || this.model.realName.length==0) {

      return;
    }



    if (this.model.appRoleId == null || this.model.appRoleId == 0) {

      return;
    }

    if (this.model.userGroupId == null || this.model.userGroupId == 0) {

      return;
    }


    this.isLoading = true;
    this._AppUserService.Save(this.model).then(res => {
      if (res.succeeded == true) {

        if (this.model.userId == 0) {
          if (this.supervisorId > 0) {
            // update supervior access

            let smodel = {
              userId: res.data.userId,
              supervisorId: this.supervisorId,
            } as SupervisorModel;
            this._SupervisorService.CreateAccess(smodel).then(res => { });

          }
          if (this.representativeId > 0) {
            // update representative access

            let smodel = {
              userId: res.data.userId,
              representativeId: this.representativeId,
            } as RepresentativeModel;
            this._RepresentativeService.CreateAccess(smodel).then(res => { });
          }
        }

        this.model.userId = res.data.userId;
        this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });

        this.refreshMenu();
      }
      else {
        this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
      }
      this.isLoading = false;
    })

  }
  manageBranch(operation) {
    if (operation == 'add_branch') {


      var ref = this.dialogService.open(ChooserBranchComponent, {
        header: this.CHOOSE,
        width: '500px',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe((re: BranchListModel) => {
        if (re.branchId > 0) {
          var existBranch = this.model.branchs.find(a => a.branchId == re.branchId);
          if (!existBranch) {

            let userBranchModel: AppUserBranchModel = {
              branchId: re.branchId,
              userId: this.model.userId

            } as AppUserBranchModel;

            this.isLoading = true;
            this._AppUserBranchService.Save(userBranchModel).then(res => {
              this._AppUserBranchService.GetByUser(this.model.userId).then(re => {
                this.model.branchs = re.data;
                this.isLoading = false;
              })
            })

          }
        }
      });


    }
    if (operation == 'delete_branch') {


      if (this.selectedBranch != null && this.selectedBranch.userBranchId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;
            let userBranchModel: AppUserBranchModel = {
              userBranchId: this.selectedBranch.userBranchId
            } as AppUserBranchModel;
            this._AppUserBranchService.Delete(userBranchModel).then(re => {
              this._AppUserBranchService.GetByUser(this.model.userId).then(re => {
                this.model.branchs = re.data;
                this.isLoading = false;
                this.selectedBranch = null;
              })
            })

          },
          reject: () => {
            //reject action
          }
        });
      }



    }
    if (operation == 'reload_branch') {

      this.isLoading = true;
      this._AppUserBranchService.GetByUser(this.model.userId).then(re => {
        this.model.branchs = re.data;
        this.isLoading = false;
        this.selectedBranch = null;
      })

    }
  }


  manageStore(operation) {
    if (operation == 'add_store') {


      var ref = this.dialogService.open(ChooserStoreComponent, {
        header: this.CHOOSE,
        width: '1000px',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe((re: StoreListModel) => {
        if (re.storeId > 0) {
          var existStore = this.model.stores.find(a => a.storeId == re.storeId);
          if (!existStore) {

            let userStoreModel: AppUserStoreModel = {
              storeId: re.storeId,
              userId: this.model.userId

            } as AppUserStoreModel;

            this.isLoading = true;
            this._AppUserStoreService.Save(userStoreModel).then(res => {
              this._AppUserStoreService.GetByUser(this.model.userId).then(re => {
                this.model.stores = re.data;
                this.isLoading = false;
              })
            })

          }
        }
      });


    }
    if (operation == 'delete_store') {


      if (this.selectedStore != null && this.selectedStore.appUserStoreId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;
            let userStoreModel: AppUserStoreModel = {
              appUserStoreId: this.selectedStore.appUserStoreId
            } as AppUserStoreModel;
            this._AppUserStoreService.Delete(userStoreModel).then(re => {
              this._AppUserStoreService.GetByUser(this.model.userId).then(re => {
                this.model.stores = re.data;
                this.isLoading = false;
                this.selectedStore = null;
              })
            })

          },
          reject: () => {
            //reject action
          }
        });
      }



    }
    if (operation == 'reload_store') {

      this.isLoading = true;
      this._AppUserStoreService.GetByUser(this.model.userId).then(re => {
        this.model.stores = re.data;
        this.isLoading = false;
        this.selectedStore = null;
      })

    }


  }
  manageSupervisor(operation) {
    if (operation == 'add_supervisor') {


      var ref = this.dialogService.open(ChooserSupervisorComponent, {
        header: this.CHOOSE,
        width: '95%',
        contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe((re: SupervisorListModel) => {
        if (re.supervisorId > 0) {
          var existSupervisor = this.model.supervisors.find(a => a.supervisorId == re.supervisorId);
          if (!existSupervisor) {

            let supervisor: SupervisorModel = {
              supervisorId:re.supervisorId,
              userId:this.model.userId,
            } as SupervisorModel;

            this.isLoading = true;
            this._SupervisorService.CreateAccess(supervisor).then(res => {
              this._SupervisorService.GetByUser(this.model.userId).then(re => {
                this.model.supervisors = re.data;
                this.isLoading = false;

              })

              this.selectedSupervisor={ supervisorId:0} as SupervisorListModel;

            })

          }
        }
      });


    }
    if (operation == 'delete_supervisor') {


      if (this.selectedSupervisor != null && this.selectedSupervisor.supervisorId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;
            let supervior: SupervisorModel = {
              supervisorId: this.selectedSupervisor.supervisorId
            } as SupervisorModel;
            this._SupervisorService.DeleteAccess(supervior).then(re => {
              this._SupervisorService.GetByUser(this.model.userId).then(re => {
                this.model.supervisors = re.data;
                this.isLoading = false;
              })

              this.selectedSupervisor={ supervisorId:0} as SupervisorListModel;
            })


          },
          reject: () => {
            //reject action
          }
        });
      }

    }
    if (operation == 'reload_supervisor') {

      this.isLoading = true;
      this._SupervisorService.GetByUser(this.model.userId).then(re => {
        this.model.supervisors = re.data;
        this.isLoading = false;
       this.selectedSupervisor={ supervisorId:0} as SupervisorListModel;
      })

    }
  }
  manageRep(operation) {
    if (operation == 'add_rep') {


      var ref = this.dialogService.open(ChooserRepresentativeComponent, {
        header: this.CHOOSE,
        width: '95%',
        contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
        baseZIndex: 10000
      });

      ref.onClose.subscribe((re: RepresentativeListModel) => {
        if (re.representativeId > 0) {
          var existRep = this.model.representatives.find(a => a.representativeId == re.representativeId);
          if (!existRep) {

            let representative: RepresentativeModel = {
              representativeId:re.representativeId,
              userId:this.model.userId,
            } as RepresentativeModel;

            this.isLoading = true;
            this._RepresentativeService.CreateAccess(representative).then(res => {
              this._RepresentativeService.GetByUser(this.model.userId).then(re => {
                this.model.representatives = re.data;
                this.isLoading = false;

              })
              this.selectedRep={ representativeId:0} as RepresentativeListModel;
            })

          }
        }
      });


    }
    if (operation == 'delete_rep') {


      if (this.selectedRep != null && this.selectedRep.representativeId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;
            let supervior: RepresentativeModel = {
              representativeId: this.selectedRep.representativeId
            } as RepresentativeModel;

            this._RepresentativeService.DeleteAccess(supervior).then(re => {
              this._RepresentativeService.GetByUser(this.model.userId).then(re => {
                this.model.representatives = re.data;
                this.isLoading = false;
              })
              this.selectedRep={ representativeId:0} as RepresentativeListModel;
            })


          },
          reject: () => {
            //reject action
          }
        });
      }

    }
    if (operation == 'reload_rep') {

      this.isLoading = true;
      this._RepresentativeService.GetByUser(this.model.userId).then(re => {
        this.model.representatives = re.data;
        this.isLoading = false;
        this.selectedRep={ representativeId:0} as RepresentativeListModel;

      })

    }
  }
  manageGroup(operation){
    if (operation == 'add_group') {


      var ref = this.dialogService.open(ChooserClientGroupComponent, {
        header: this.CHOOSE,
        width: '600px',
        contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
        baseZIndex: 10000
      });

      ref.onClose.subscribe((re: ClientGroupListModel) => {
        if (re.clientGroupId > 0) {
          var existRep = this.model.clientGroups.find(a => a.clientGroupId == re.clientGroupId);
          if (!existRep) {

            let group: AppUserClientGroupModel = {
            appUserGroupId:0,
            clientGroupId:re.clientGroupId,
            userId:this.model.userId,
            } as AppUserClientGroupModel;

            this.isLoading = true;
            this._AppUserClientGroupService.Save(group).then(res => {
              this._AppUserClientGroupService.GetByUser(this.model.userId).then(re => {
                this.model.clientGroups = re.data;
                this.isLoading = false;

              })
              this.selectedClientGroup={ appUserGroupId:0} as AppUserClientGroupListModel;
            })

          }
        }
      });


    }
    if (operation == 'delete_group') {


      if (this.selectedClientGroup != null && this.selectedClientGroup.appUserGroupId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;
            let group: AppUserClientGroupModel = {
           appUserGroupId:this.selectedClientGroup.appUserGroupId,
              } as AppUserClientGroupModel;

            this._AppUserClientGroupService.Delete(group).then(re => {
              this._AppUserClientGroupService.GetByUser(this.model.userId).then(re => {
                this.model.clientGroups = re.data;
                this.isLoading = false;
              })
              this.selectedClientGroup={ appUserGroupId:0} as AppUserClientGroupListModel;
            })


          },
          reject: () => {
            //reject action
          }
        });
      }

    }
    if (operation == 'reload_group') {

      this.isLoading = true;
      this._AppUserClientGroupService.GetByUser(this.model.userId).then(re => {
        this.model.clientGroups = re.data;
        this.isLoading = false;
        this.selectedClientGroup={ appUserGroupId:0} as AppUserClientGroupListModel;

      })

    }
  }
  onRoleChange(arg) {
    this.isLoading = true;
    this.appFeatures = [];
    this._ApplicationFeatureService.GetByRoleId(arg.value).then(res => {
      this.appFeatures = res.data;
      this.appFeatures.unshift({ id: 0, code: '0', name: '--' });
      this.isLoading = false;
    })
  }
  refreshMenu() {
    this.items[1].disabled = true;
    this.items[2].disabled = true;
    this.items[3].disabled = true;
    this.items[4].disabled = true;
    this.items[5].disabled = true;

    if (this.model.userId > 0) {
      this.items[1].disabled = false;
      this.items[2].disabled = false;
      this.items[3].disabled = false;
      this.items[4].disabled = false;
      this.items[5].disabled = false;

    }
  }

}
