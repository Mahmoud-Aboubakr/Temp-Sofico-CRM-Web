import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MenuItem, MessageService, PrimeNGConfig } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { ChooserBranchComponent } from 'src/app/Modules/shared/chooser-branch/chooser-branch.component';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { RepresentativeModel } from 'src/app/core/Models/EntityModels/representativeModel';
import { ChooserSupervisorComponent } from 'src/app/Modules/shared/chooser-supervisor/chooser-supervisor.component';
import { RepresentativeComissionModel } from 'src/app/core/Models/EntityModels/RepresentativeComissionModel';
import { RepresentativeComissionListModel } from 'src/app/core/Models/ListModels/RepresentativeComissionListModel';
import { ManageRepresentativeComissionComponent } from '../manage-representative-comission/manage-representative-comission.component';
import { RepresentativeJourneyListModel } from 'src/app/core/Models/ListModels/RepresentativeJourneyListModel';
import { ChooserRouteComponent } from 'src/app/Modules/shared/chooser-route/chooser-route.component';
import { RouteSetupListModel } from 'src/app/core/Models/ListModels/RouteSetupListModel';
import { RepresentativeJourneyModel } from 'src/app/core/Models/EntityModels/RepresentativeJourneyModel';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';
import { BranchModel } from '../../../../core/Models/EntityModels/branchModel';
import { SupervisorModel } from '../../../../core/Models/EntityModels/supervisorModel';

@Component({
  selector: 'app-manage-represeentitive',
  templateUrl: './manage-represeentitive.component.html',
  styleUrls: ['./manage-represeentitive.component.scss']
})
export class ManageRepreseentitiveComponent implements OnInit {


  model = {} as RepresentativeModel;
  RepresentativeKinds: LookupModel[] = [];
  BusinessUnits: LookupModel[] = [];

  isLoading = true;

  TerminationReasons: LookupModel[] = [];

  CHOOSE = '';
  selectedIndex = 1;

  selectedComission: RepresentativeComissionListModel = {
    comissionId: 0,
  } as RepresentativeComissionListModel;

  selectedRoute: RepresentativeJourneyListModel = {
    routeId: 0,
    representativeId: 0
  } as RepresentativeJourneyListModel;





  Comissions: RepresentativeComissionListModel[] = [];
  routes: RepresentativeJourneyListModel[] = [];
  items: MenuItem[];
  constructor(
    private _AppMessageService: AppMessageService,

    private ref: DynamicDialogRef,

    private messageService: MessageService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private config: DynamicDialogConfig,
    private confirmationService: ConfirmationService,
    private _commonCrudService : CommonCrudService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });

    this.model.joinDate = new Date();
    this.model.isActive = true;

    this.items = [
      {
        label: 'Basic Info',
        icon: 'fa fa-info-circle',
        command: (e) => this.manage(1)
      },
      {
        label: 'Routes Setup',
        icon: 'fa fa-road',
        command: (e) => this.manage(2)
      },
      {
        label: 'Comissions',
        icon: 'fa fa-money',
        command: (e) => this.manage(3)
      },

    ];
  }
  ngOnInit(): void {
    this.init();
  }

  async manage(index) {
    this.selectedIndex = index;
  }
  async init() {

    await this._commonCrudService.get("TerminationReason/GetAll", LookupModel).then(res => {
      this.TerminationReasons = res.data;
    })

    await this._commonCrudService.get("RepresentativeKind/GetAll", LookupModel).then(res => {
      this.RepresentativeKinds = res.data;
    })

    if (this.config.data) {
      await this._commonCrudService.get("Representative/getById?Id="+this.config.data.representativeId, RepresentativeModel).then(res => {
        if (res.succeeded == true) {
          this.model = res.data;
          this.model.joinDate = new Date(res.data.joinDate);

          this.model.branchCode = '';
          this.model.supervisorCode = '';




          if (this.model.branchId > 0) {
            this._commonCrudService.get("Branch/GetByid?Id="+this.model.branchId, BranchModel).then(res => {
              this.model.branchCode = res.data.branchCode;

              this._commonCrudService.get("BusinessUnit/getByBranch?Id="+this.model.branchId, LookupModel).then(res => {
                this.BusinessUnits = res.data;
              })
            })
          }

          if (this.model.supervisorId > 0) {
            this._commonCrudService.get("Supervisor/getById?Id="+this.model.supervisorId,SupervisorModel).then(res => {
              this.model.supervisorCode = res.data.supervisorCode;
            })
          }
        }
      })

      await this._commonCrudService.get("RepresentativeComission/getByRepresentative?Id="+this.model.representativeId, RepresentativeComissionListModel).then(res => {
        if (res.succeeded == true) {
          this.Comissions = res.data;
        }
      });
      await this._commonCrudService.get("RepresentativeJourney/getByRepresentative?Id="+this.model.representativeId, RepresentativeJourneyListModel).then(res => {
        if (res.succeeded == true) {
          this.routes = res.data;
        }
      });

    }

    this.isLoading = false;

  }
  Chooser_Branch() {
    var ref = this.dialogService.open(ChooserBranchComponent, {
      header: this.CHOOSE,
      width: '500px',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((re) => {
      this.model.branchCode = re.branchCode;
      this.model.branchId = re.branchId;
    });
  }
  Chooser_Supervisor() {
    if (this.model != null && this.model.branchId > 0) {
      var ref = this.dialogService.open(ChooserSupervisorComponent, {
        header: this.CHOOSE,
        data: { branchId: this.model.branchId },
        width: '1200px',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe((re) => {
        this.model.supervisorCode = re.supervisorCode;
        this.model.supervisorId = re.supervisorId;
      });
    }

  }
  Save() {

    if (this.model.branchId == 0) {

      return;
    }

    if (this.model.representativeCode == null || this.model.representativeCode.trim().length == 0) {

      return;
    }

    if (this.model.representativeNameAr == null || this.model.representativeNameAr.trim().length == 0) {

      return;
    }

    if (this.model.representativeNameEn == null || this.model.representativeNameEn.trim().length == 0) {

      return;
    }

    if (this.model.kindId == null || this.model.kindId == 0) {

      return;
    }

    if (this.model.representativeCode == null || this.model.representativeCode.trim().length == 0) {

      return;
    }


    this.isLoading = true;
    this._commonCrudService.post("Representative/Save", this.model, RepresentativeModel).then(res => {

      if (res.succeeded == true) {
        this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });
      }
      else {
        this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
      }
      this.isLoading = false;
    })

  }

  manageCom(operation) {
    if (operation == "add_com") {
      var ref = this.dialogService.open(ManageRepresentativeComissionComponent, {
        header: this.CHOOSE,
        data: { representativeId: this.model.representativeId },
        width: '400px',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe((re: RepresentativeComissionModel) => {
        this.isLoading = true;

        this._commonCrudService.get("RepresentativeComission/getByRepresentative?Id="+this.model.representativeId, RepresentativeComissionListModel).then(res => {
          if (res.succeeded == true) {
            this.Comissions = res.data;
          }
          this.isLoading = false;
        })
      });
    }
    if (operation == "edit_com") {
      if (this.selectedComission && this.selectedComission.comissionId > 0 && this.selectedComission.isApproved != true) {
        var ref = this.dialogService.open(ManageRepresentativeComissionComponent, {
          header: this.CHOOSE,
          data: { representativeId: this.model.representativeId, comissionId: this.selectedComission.comissionId },
          width: '400px',
          contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
          baseZIndex: 10000
        });
        ref.onClose.subscribe((re: RepresentativeComissionModel) => {
          this.isLoading = true;

          this._commonCrudService.get("RepresentativeComission/getByRepresentative?Id="+this.model.representativeId, RepresentativeComissionListModel).then(res => {
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

            let model: RepresentativeComissionModel = {
              comissionId: this.selectedComission.comissionId
            } as RepresentativeComissionModel;

            this._commonCrudService.post("RepresentativeComission/Delete", model, RepresentativeComissionModel).then(async res => {
                await this._commonCrudService.get("RepresentativeComission/getByRepresentative?Id="+this.model.representativeId,RepresentativeComissionListModel).then(res => {
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
      this._commonCrudService.get("RepresentativeComission/getByRepresentative?Id="+this.model.representativeId, RepresentativeComissionListModel).then(res => {
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

            let model: RepresentativeComissionModel = {
              comissionId: this.selectedComission.comissionId
            } as RepresentativeComissionModel;

            this._commonCrudService.post("RepresentativeComission/approve", model, RepresentativeComissionModel).then(async res => {
              await this._commonCrudService.get("RepresentativeComission/getByRepresentative?Id="+this.model.representativeId,RepresentativeComissionListModel).then(res => {
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
    } as RepresentativeComissionListModel;
  }

  manageRoute(operation) {
    if (operation == "add_route") {
      var ref = this.dialogService.open(ChooserRouteComponent, {
        header: this.CHOOSE,
        width: '80%',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe((re: RouteSetupListModel) => {
        this.isLoading = true;

        // add route
        let model: RepresentativeJourneyModel = {
          routeId: re.routeId,
          representativeId: this.model.representativeId

        } as RepresentativeJourneyModel;

        this._commonCrudService.post("RepresentativeJourney/Add", model, RepresentativeJourneyModel).then(async res => {
          await this._commonCrudService.get("RepresentativeJourney/getByRepresentative?Id="+this.model.representativeId, RepresentativeJourneyListModel).then(res => {
            if (res.succeeded == true) {
              this.routes = res.data;
            }
          })
          this.isLoading = false;
        });

      });
    }
    if (operation == "delete_route") {
      if (this.selectedRoute && this.selectedRoute.routeId > 0) {

        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {

            this.isLoading = true;

            let model: RepresentativeJourneyModel = {
              routeId: this.selectedRoute.routeId,
              representativeId: this.model.representativeId

            } as RepresentativeJourneyModel;

            this._commonCrudService.post("RepresentativeJourney/Delete",model, RepresentativeJourneyModel).then(async res => {
              await this._commonCrudService.get("RepresentativeJourney/getByRepresentative?Id="+this.model.representativeId, RepresentativeJourneyListModel).then(res => {
                if (res.succeeded == true) {
                  this.routes = res.data;

                }

              })
              this.isLoading = false;

              this.selectedRoute = {
                routeId: 0,
                representativeId: 0,
              } as RepresentativeJourneyListModel;
            });

          },
          reject: () => {
            //reject action


          }
        });
      }
    }
    if (operation == "reload_route") {
      this.isLoading = true;
      this._commonCrudService.get("RepresentativeJourney/getByRepresentative?Id="+this.model.representativeId, RepresentativeJourneyListModel).then(res => {
        if (res.succeeded == true) {
          this.routes = res.data;
        }
        this.selectedComission = null;
        this.isLoading = false;
      });
    }


  }


}
