import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { SupervisorService } from 'src/app/core/services/Supervisor.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { SupervisorModel } from 'src/app/core/Models/EntityModels/supervisorModel';
import { BranchModel } from 'src/app/core/Models/EntityModels/branchModel';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { SupervisorTypeService } from 'src/app/core/services/SupervisorType.Service';
import { ChooserBranchComponent } from 'src/app/Modules/shared/chooser-branch/chooser-branch.component';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { TerminationReasonService } from 'src/app/core/services/TerminationReason.Service';
import { BranchService } from 'src/app/core/services/Branch.Service';
import { BusinessUnitService } from 'src/app/core/services/BusinessUnit.Service';
import { SupervisorListModel } from 'src/app/core/Models/ListModels/SupervisorListModel';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { RepresentativeSearchModel } from 'src/app/core/Models/SearchModels/RepresentativeSearchModel';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { RepresentativeService } from 'src/app/core/services/Representative.Service';
import { ChooserRepresentativeComponent } from 'src/app/Modules/shared/chooser-representative/chooser-representative.component';
import { RepresentativeModel } from 'src/app/core/Models/EntityModels/representativeModel';
import { SupervisorComissionService } from 'src/app/core/services/SupervisorComission.Service';
import { SupervisorComissionListModel } from 'src/app/core/Models/ListModels/SupervisorComissionListModel';
import { SupervisorComissionModel } from 'src/app/core/Models/EntityModels/SupervisorComissionModel';
import { AppUserModel } from 'src/app/core/Models/EntityModels/appUserModel';
import { UserService } from 'src/app/core/services/User.Service';
import { ManageSupervisorComissionComponent } from '../manage-supervisor-comission/manage-supervisor-comission.component';

@Component({
  selector: 'app-manage-supervisor',
  templateUrl: './manage-supervisor.component.html',
  styleUrls: ['./manage-supervisor.component.scss']
})
export class ManageSupervisorComponent implements OnInit {


  model = {} as SupervisorModel;
  supervisorTypes: LookupModel[] = [];
  BusinessUnits: LookupModel[] = [];
  isLoading = true;
  selectedIndex = 1;
  TerminationReasons: LookupModel[] = [];

  CHOOSE = '';
  items: MenuItem[];

  selectedSalesMan: RepresentativeListModel = {
    representativeId: 0,
  } as RepresentativeListModel;

  selectedComission: SupervisorComissionListModel = {
    comissionId: 0,
  } as SupervisorComissionListModel;

  userModel: AppUserModel = {
    userId: 0,
  } as AppUserModel;

  SalesMan: RepresentativeListModel[] = [];
  Comissions: SupervisorComissionListModel[] = [];

  constructor(
    private _AppMessageService: AppMessageService,

    private ref: DynamicDialogRef,
    private messageService: MessageService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private config: DynamicDialogConfig,
    private _SupervisorTypeService: SupervisorTypeService,
    private _SupervisorService: SupervisorService,
    private _BranchService: BranchService,
    private _TerminationReasonService: TerminationReasonService,
    private _BusinessUnitService: BusinessUnitService,
    private confirmationService: ConfirmationService,
    private _SupervisorComissionService: SupervisorComissionService,
    private _UserService: UserService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });

    this.model.joinDate = new Date();
    this.model.isActive = true;
    this.model.branchCode = '';



    this.items = [
      {
        label: 'Basic Info',
        icon: 'fa fa-info-circle',
        command: (e) => this.manage(1)
      },
      {
        label: 'Sales Mans',
        icon: 'fa fa-users',
        command: (e) => this.manage(2)
      },
      {
        label: 'Comissions',
        icon: 'fa fa-money',
        command: (e) => this.manage(3)
      },
     
    ];
  }

  async manage(index) {
    this.selectedIndex = index;
  }
  ngOnInit(): void {
    this.init();
  }

  async init() {

    await this._TerminationReasonService.GetAll().then(res => {
      this.TerminationReasons = res.data;
    })

    await this._SupervisorTypeService.GetAll().then(res => {
      this.supervisorTypes = res.data;
    })

    if (this.config.data) {
      await this._SupervisorService.getById(+this.config.data.supervisorId).then(res => {
        if (res.succeeded == true) {
          this.model = res.data;
          this.model.joinDate = new Date(res.data.joinDate);

          this.model.branchCode = '';

          if (this.model.userId > 0) {
            this._UserService.getById(this.model.userId).then(res => {
              if (res.succeeded == true) {
                this.userModel = res.data;
              }
            })
          }


          if (this.model.branchId > 0) {
            this._BranchService.GetByid(this.model.branchId).then(res => {
              this.model.branchCode = res.data.branchCode;

              this._BusinessUnitService.getByBranch(this.model.branchId).then(res => {
                this.BusinessUnits = res.data;
              })
            })
          }
        }
      })

      await this._SupervisorService.getReps(this.model.supervisorId).then(res => {
        if (res.succeeded == true) {
          this.SalesMan = res.data;
        }
      })

      await this._SupervisorComissionService.getBySupervisor(this.model.supervisorId).then(res => {
        if (res.succeeded == true) {
          this.Comissions = res.data;
        }
      });

    }

    this.isLoading = false;

  }

  manageRep(operation) {
    if (operation == "add_rep") {
      var ref = this.dialogService.open(ChooserRepresentativeComponent, {
        header: this.CHOOSE,
        width: '90%',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe((re: RepresentativeListModel) => {
        if (re && re.representativeId > 0) {

          this.isLoading = true;
          let model: RepresentativeModel = {
            representativeId: re.representativeId,
            supervisorId: this.model.supervisorId,
          } as RepresentativeModel;

          this._SupervisorService.addRep(model).then(async res => {
            await this._SupervisorService.getReps(this.model.supervisorId).then(res => {
              if (res.succeeded == true) {
                this.SalesMan = res.data;
              }
            })

            this.isLoading = false;
          });

        }
      });
    }
    if (operation == "delete_rep") {
      if (this.selectedSalesMan && this.selectedSalesMan.representativeId > 0) {

        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;
            let model: RepresentativeModel = {
              representativeId: this.selectedSalesMan.representativeId,
              supervisorId: this.model.supervisorId,
            } as RepresentativeModel;

            this._SupervisorService.deleteRep(model).then(async res => {
              await this._SupervisorService.getReps(this.model.supervisorId).then(res => {
                if (res.succeeded == true) {
                  this.SalesMan = res.data;
                }
              })

              this.isLoading = false;
            });

          },
          reject: () => {
            //reject action
          }
        });
      }

    }
    if (operation == "reload_rep") {
      this.isLoading = true;
      this._SupervisorService.getReps(this.model.supervisorId).then(res => {
        if (res.succeeded == true) {
          this.SalesMan = res.data;
        }
        this.isLoading = false;
        this.selectedSalesMan = null;
      })
    }
  }
  manageCom(operation) {
    if (operation == "add_com") {
      var ref = this.dialogService.open(ManageSupervisorComissionComponent, {
        header: this.CHOOSE,
        data: { supervisorId: this.model.supervisorId },
        width: '400px',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe((re: SupervisorComissionModel) => {
        this.isLoading = true;

        this._SupervisorComissionService.getBySupervisor(this.model.supervisorId).then(res => {
          if (res.succeeded == true) {
            this.Comissions = res.data;
          }
          this.isLoading = false;
        })
      });
    }
    if (operation == "edit_com") {
      if (this.selectedComission && this.selectedComission.comissionId > 0 && this.selectedComission.isApproved != true) {
        var ref = this.dialogService.open(ManageSupervisorComissionComponent, {
          header: this.CHOOSE,
          data: { supervisorId: this.model.supervisorId, comissionId: this.selectedComission.comissionId },
          width: '400px',
          contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
          baseZIndex: 10000
        });
        ref.onClose.subscribe((re: SupervisorComissionModel) => {
          this.isLoading = true;

          this._SupervisorComissionService.getBySupervisor(this.model.supervisorId).then(res => {
            if (res.succeeded == true) {
              this.Comissions = res.data;
            }
            this.isLoading = false;
          })
        });
      }
    }
    if (operation == "delete_com") {
      if (this.selectedComission && this.selectedComission.comissionId > 0 && this.selectedComission.isApproved != true) {

        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;

            let model: SupervisorComissionModel = {
              comissionId: this.selectedComission.comissionId
            } as SupervisorComissionModel;

            this._SupervisorComissionService.Delete(model).then(async res => {
              await this._SupervisorComissionService.getBySupervisor(this.model.supervisorId).then(res => {
                if (res.succeeded == true) {
                  this.Comissions = res.data;
                }
              })

              this.isLoading = false;
            });

          },
          reject: () => {
            //reject action
          }
        });
      }
    }
    if (operation == "reload_com") {
      this.isLoading = true;
      this._SupervisorComissionService.getBySupervisor(this.model.supervisorId).then(res => {
        if (res.succeeded == true) {
          this.Comissions = res.data;
        }
        this.selectedComission = null;
        this.isLoading = false;
      });
    }
    if (operation == "approve_com") {
      if (this.selectedComission && this.selectedComission.comissionId > 0) {

        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;

            let model: SupervisorComissionModel = {
              comissionId: this.selectedComission.comissionId
            } as SupervisorComissionModel;

            this._SupervisorComissionService.Approve(model).then(async res => {
              await this._SupervisorComissionService.getBySupervisor(this.model.supervisorId).then(res => {
                if (res.succeeded == true) {
                  this.Comissions = res.data;
                }
              })

              this.isLoading = false;
            });

          },
          reject: () => {
            //reject action
          }
        });
      }
    }
    this.selectedComission = {
      comissionId: 0,
    } as SupervisorComissionListModel;
  }
  Chooser_Branch() {
    var ref = this.dialogService.open(ChooserBranchComponent, {
      header: this.CHOOSE,
      data: [{ SupervisorId: 0 }],
      width: '600px',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((re) => {
      this.model.branchCode = re.branchCode;
      this.model.branchId = re.branchId;

      this.model.businessUnitId = 0;

      this._BusinessUnitService.getByBranch(this.model.branchId).then(res => {
        this.BusinessUnits = res.data;
      })

    });
  }

  Save() {

    if (this.model.branchId == 0) {

      return;
    }

    if (this.model.supervisorNameAr == null || this.model.supervisorNameAr.trim().length == 0) {

      return;
    }

    if (this.model.supervisorNameEn == null || this.model.supervisorNameEn.trim().length == 0) {

      return;
    }

    if (this.model.supervisorTypeId == null || this.model.supervisorTypeId == 0) {

      return;
    }


    this.isLoading = true;
    this._SupervisorService.Save(this.model).then(res => {

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

  CreateAccess() {
    if(this.model.supervisorId>0){
      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {
  
          this.isLoading = true;
          let model: SupervisorModel = {
            supervisorId: this.model.supervisorId,
          } as SupervisorModel;
  
          this._SupervisorService.CreateAccess(model).then(async res => {
            if (res.succeeded == true) {
              this.model.userId = res.data.userId;
  
              if (this.model.userId > 0) {
                await this._UserService.getById(this.model.userId).then(res => {
                  if (res.succeeded == true) {
                    this.userModel = res.data;
                  }
                })
              }
            }
            this.isLoading = false;
          });
  
        },
        reject: () => {
          //reject action
        }
      });
    }
    else
    {
      this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });
    }
    
  }




}
