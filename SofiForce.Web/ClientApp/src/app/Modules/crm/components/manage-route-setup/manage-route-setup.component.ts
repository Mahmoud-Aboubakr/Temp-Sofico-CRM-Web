import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';

import { ChooserBranchComponent } from 'src/app/Modules/shared/chooser-branch/chooser-branch.component';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { BranchService } from 'src/app/core/services/Branch.Service';
import { BusinessUnitService } from 'src/app/core/services/BusinessUnit.Service';
import { BusinessUnitModel } from 'src/app/core/Models/EntityModels/BusinessUnitModel';
import { AlertService } from 'src/app/core/services/Alert.Service';
import { RouteSetupModel } from 'src/app/core/Models/EntityModels/RouteSetupModel';
import { RouteSetupService } from 'src/app/core/services/RouteSetup.Service';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { RouteTypeService } from 'src/app/core/services/RouteType.Service';
@Component({
  selector: 'app-manage-route-setup',
  templateUrl: './manage-route-setup.component.html',
  styleUrls: ['./manage-route-setup.component.scss']
})
export class ManageRouteSetupComponent implements OnInit {


  model = {
branchId:0,
routeId:0,
routeTypeId:0,


  } as RouteSetupModel;
  isLoading = true;
  CHOOSE_BRANCH = '';

  routeTypes:LookupModel[]=[];

  constructor(
    private _AppMessageService: AppMessageService,

    private ref: DynamicDialogRef,
    private messageService: MessageService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private config: DynamicDialogConfig,
    private _BranchService: BranchService,
    private _RouteSetupService: RouteSetupService,
    private _RouteTypeService: RouteTypeService,

    private _AlertService: AlertService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);

    this.model.isActive=true;
    this.model.branchCode='';

  }
  ngOnInit(): void {

    this._RouteTypeService.GetAll().then(res => {
      this.routeTypes = res.data;
    })

    this.init();
  }

  async init() {

    if (this.config.data && this.config.data.routeId>0) {
      await this._RouteSetupService.getById(+this.config.data.routeId).then(res=>{
        if(res.succeeded==true){
          this.model=res.data;
          
          this._BranchService.GetByid(this.model.branchId).then(res=>{
            if(res.succeeded==true){
              this.model.branchCode=res.data.branchCode;
            }
          })
          
        }
      })
    }
    this.isLoading = false;

  }
  Chooser_Branch() {
    var ref = this.dialogService.open(ChooserBranchComponent, {
      header: this.CHOOSE_BRANCH,
      data: [{ SupervisorId: 0 }],
      width: '600px',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((re) => {
      this.model.branchCode = re.branchCode;
      this.model.branchId = re.branchId;
    });
  }

  Save() {

    if (this.model.branchId == 0) {
      this._AlertService.Show('error', this._AppMessageService.MESSAGE_ERROR)

      return;
    }

    if (this.model.routeTypeId == 0) {
      this._AlertService.Show('error', this._AppMessageService.MESSAGE_ERROR)

      return;
    }

    if (this.model.routeNameAr == null || this.model.routeNameEn.trim().length == 0) {
      this._AlertService.Show('error', this._AppMessageService.MESSAGE_ERROR)

      return;
    }

   

    this.isLoading = true;
    this._RouteSetupService.Save(this.model).then(res => {

      if (res.succeeded == true) {
        this.ref.close();
        this._AlertService.Show('success', this._AppMessageService.MESSAGE_OK)
      }
      else {
        this._AlertService.Show('error', this._AppMessageService.MESSAGE_ERROR)
      }
      this.isLoading = false;
    })

  }


}
