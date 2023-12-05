import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { SupervisorService } from 'src/app/core/services/Supervisor.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { ChooserSupervisorComponent } from 'src/app/Modules/shared/chooser-supervisor/chooser-supervisor.component';
import { ComissionTypeService } from 'src/app/core/services/ComissionType.Service';
import { SupervisorComissionService } from 'src/app/core/services/SupervisorComission.Service';
import { SupervisorComissionModel } from 'src/app/core/Models/EntityModels/SupervisorComissionModel';
@Component({
  selector: 'app-manage-supervisor-comission',
  templateUrl: './manage-supervisor-comission.component.html',
  styleUrls: ['./manage-supervisor-comission.component.scss']
})
export class ManageSupervisorComissionComponent implements OnInit {



  model = {
    comissionId:0, 
    comissionValue:0,
    comissionDate:new Date(),
    comissionTypeId:0,
    isApproved:false,
    notes:'',
    supervisorId:0,
    supervisorCode:'',
  } as SupervisorComissionModel;

  ComissionTypes: LookupModel[] = [];

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

    private _SupervisorComissionService: SupervisorComissionService,
    private _ComissionTypeService: ComissionTypeService,
    private _SupervisorService:SupervisorService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);

    if (this.config.data && +this.config.data.supervisorId>0) {
      this.model.supervisorId=+this.config.data.supervisorId;
    }
    if (this.config.data && +this.config.data.comissionId>0) {
      this.model.comissionId=+this.config.data.comissionId;
    }
  }
  ngOnInit(): void {
    this.init();
  }

  async init() {

    await this._ComissionTypeService.GetAll().then(res=>{
      this.ComissionTypes=res.data;
    })

   

    if (this.model.comissionId>0) {
      await this._SupervisorComissionService.getById(this.model.comissionId).then(res=>{
        if(res.succeeded==true){

          this.model=res.data;
          this.model.comissionDate=new Date(this.model.comissionDate);
          if(this.model.supervisorId>0){
            this._SupervisorService.getById(this.model.supervisorId).then(res=>{
              if(res.succeeded==true){
                this.model.supervisorCode=res.data.supervisorCode;
                this.model.supervisorId=res.data.supervisorId;
              }
            })
          }

        }
      })
    }

    if(this.model.supervisorId>0){
      this._SupervisorService.getById(this.model.supervisorId).then(res=>{
        if(res.succeeded==true){
          this.model.supervisorCode=res.data.supervisorCode;
          this.model.supervisorId=res.data.supervisorId;
        }
      })
    }

    this.isLoading = false;

  }

  Chooser_Supervisor(){
    var ref = this.dialogService.open(ChooserSupervisorComponent, {
      header: this.CHOOSE_BRANCH,
      width: '1200px',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((re) => {
      this.model.supervisorCode = re.supervisorCode;
      this.model.supervisorId = re.supervisorId;
    });
  }
  Save() {

    if (this.model.supervisorId == 0) {

      return;
    }

    if (this.model.comissionDate == null ) {

      return;
    }

    if (this.model.comissionValue == null || this.model.comissionValue == 0) {

      return;
    }

    this.isLoading = true;
    this._SupervisorComissionService.Save(this.model).then(res => {

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

}
