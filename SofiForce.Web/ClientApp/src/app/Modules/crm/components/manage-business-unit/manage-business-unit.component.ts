import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';

import { ChooserBranchComponent } from 'src/app/Modules/shared/chooser-branch/chooser-branch.component';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { BusinessUnitModel } from 'src/app/core/Models/EntityModels/BusinessUnitModel';
import { AlertService } from 'src/app/core/services/Alert.Service';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';
import { BranchModel } from '../../../../core/Models/EntityModels/branchModel';

@Component({
  selector: 'app-manage-business-unit',
  templateUrl: './manage-business-unit.component.html',
  styleUrls: ['./manage-business-unit.component.scss']
})
export class ManageBusinessUnitComponent implements OnInit {


  model = {
    businessUnitId:0,
    branchId:0,

  } as BusinessUnitModel;
  isLoading = true;
  CHOOSE_BRANCH = '';

  constructor(
    private _AppMessageService: AppMessageService,

    private ref: DynamicDialogRef,
    private messageService: MessageService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private config: DynamicDialogConfig,
    private _AlertService: AlertService,
    private _commonCrudService : CommonCrudService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);

    this.model.isActive=true;
    this.model.branchCode='';

  }
  ngOnInit(): void {
    this.init();
  }

  async init() {

    if (this.config.data && this.config.data.businessUnitId>0) {
      await this._commonCrudService.get("BusinessUnit/getById?Id="+this.config.data.businessUnitId,BusinessUnitModel).then(res=>{
        if(res.succeeded==true){
          this.model=res.data;
          this.model.branchCode = '';
        }
      })
    }

    if (this.config.data && this.config.data.branchId>0) {
      await this._commonCrudService.get("Branch/GetByid?Id="+this.config.data.branchId, BranchModel).then(res=>{
          this.model.branchId=res.data.branchId;
          this.model.branchCode = res.data.branchCode;
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

    if (this.model.businessUnitNameAr == null || this.model.businessUnitNameEn.trim().length == 0) {
      this._AlertService.Show('error', this._AppMessageService.MESSAGE_ERROR)

      return;
    }

   

    this.isLoading = true;
    this._commonCrudService.post("Client/Filter",this.model, BusinessUnitModel).then(res => {

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
