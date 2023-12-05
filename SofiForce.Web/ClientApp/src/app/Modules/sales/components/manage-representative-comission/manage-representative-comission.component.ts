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
import { RepresentativeComissionService } from 'src/app/core/services/RepresentativeComission.Service';
import { RepresentativeComissionModel } from 'src/app/core/Models/EntityModels/RepresentativeComissionModel';
import { RepresentativeService } from 'src/app/core/services/Representative.Service';
import { ChooserRepresentativeComponent } from 'src/app/Modules/shared/chooser-representative/chooser-representative.component';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';

@Component({
  selector: 'app-manage-representative-comission',
  templateUrl: './manage-representative-comission.component.html',
  styleUrls: ['./manage-representative-comission.component.scss']
})
export class ManageRepresentativeComissionComponent implements OnInit {


  model = {

    comissionId:0,
    comissionDate:new Date(),
    comissionTypeId:0,
    comissionValue:0,
    isApproved:false,
    notes:'',
    representativeCode:'',
    representativeId:0
    
  }  as RepresentativeComissionModel;

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

    private _RepresentativeComissionService: RepresentativeComissionService,
    private _ComissionTypeService: ComissionTypeService,
    private _RepresentativeService:RepresentativeService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);

    if (this.config.data && +this.config.data.representativeId>0) {
      this.model.representativeId=+this.config.data.representativeId;
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
      await this._RepresentativeComissionService.getById(this.model.comissionId).then(res=>{
        if(res.succeeded==true){

          this.model=res.data;
          this.model.comissionDate=new Date(this.model.comissionDate);
          if(this.model.representativeId>0){
            this._RepresentativeService.getById(this.model.representativeId).then(res=>{
              if(res.succeeded==true){
                this.model.representativeCode=res.data.representativeCode;
                this.model.representativeId=res.data.representativeId;
              }
            })
          }

        }
      })
    }

    if(this.model.representativeId>0){
      this._RepresentativeService.getById(this.model.representativeId).then(res=>{
        if(res.succeeded==true){
          this.model.representativeCode=res.data.representativeCode;
          this.model.representativeId=res.data.representativeId;
        }
      })
    }

    this.isLoading = false;

  }

  Chooser_Representative(){
    var ref = this.dialogService.open(ChooserRepresentativeComponent, {
      header: this.CHOOSE_BRANCH,
      width: '90%',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((re:RepresentativeListModel) => {
      this.model.representativeCode = re.representativeCode;
      this.model.representativeId = re.representativeId;
    });
  }
  Save() {

    if (this.model.representativeId == 0) {

      return;
    }

    if (this.model.comissionDate == null ) {

      return;
    }

    if (this.model.comissionValue == null || this.model.comissionValue == 0) {

      return;
    }

    this.isLoading = true;
    this._RepresentativeComissionService.Save(this.model).then(res => {

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
