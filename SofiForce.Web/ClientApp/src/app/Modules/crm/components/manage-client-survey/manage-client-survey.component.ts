import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { ClientSurveyModel } from 'src/app/core/Models/EntityModels/ClientSurveyModel';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { BooleanService } from 'src/app/core/services/Boolean.Service';
import { ClientSurveyService } from 'src/app/core/services/ClientSurvey.Service';
import { ClientTypeService } from 'src/app/core/services/ClientType.Service';
import { ServeyGroupService } from 'src/app/core/services/ServeyGroup.Service';
import { ServeyStatusService } from 'src/app/core/services/ServeyStatus.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { ChooserBranchComponent } from 'src/app/Modules/shared/chooser-branch/chooser-branch.component';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { ChooserClientComponent } from 'src/app/Modules/shared/chooser-client/chooser-client.component';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { ChooserRepresentativeComponent } from 'src/app/Modules/shared/chooser-representative/chooser-representative.component';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { SurveyService } from 'src/app/core/services/Survey.Service';
import { SurveyModel } from 'src/app/core/Models/EntityModels/SurveyModel';
import { BranchService } from 'src/app/core/services/Branch.Service';
import { RepresentativeService } from 'src/app/core/services/Representative.Service';
import { ClientService } from 'src/app/core/services/Client.Service';

@Component({
  selector: 'app-manage-client-survey',
  templateUrl: './manage-client-survey.component.html',
  styleUrls: ['./manage-client-survey.component.scss']
})
export class ManageClientSurveyComponent implements OnInit {

  model: ClientSurveyModel = {
    inZone:true,
    distance:0
  } as ClientSurveyModel;

  isLoading = false;
  serveyStatus: LookupModel[] = [];
  survies: LookupModel[] = [];


  CHOOSE = '';
  selectedCategory: any = null;
  constructor(

    private _AppMessageService: AppMessageService,
    private _ClientSurveyService: ClientSurveyService,
    private _SurveyService: SurveyService,

    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _BooleanService: BooleanService,
    private config: DynamicDialogConfig,
    private ref: DynamicDialogRef,
    private _ClientTypeService: ClientTypeService,
    private _ServeyGroupService: ServeyGroupService,
    private _ServeyStatusService: ServeyStatusService,
    private _BranchService: BranchService,
    private _RepresentativeService: RepresentativeService,
    private _ClientService: ClientService,


  ) {

    this._translationLoaderService.loadTranslations(english, arabic);

    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });
    this.model.clientServeyId = 0;
    this.model.serveyModel = {} as SurveyModel;
    this.model.serveyModel.details = [];
    this.model.startTime = new Date();
    this.model.createTime = new Date();
    this.model.isClosed=false;

    if (this.config.data) {
      if (+this.config.data.clientServeyId > 0) {
        this.model.clientServeyId = +this.config.data.clientServeyId

  

 


      }
    }

  }

  ngOnInit(): void {


    this._ServeyStatusService.GetAll().then(res => {
      this.serveyStatus = res.data
    })

    this._SurveyService.GetAll().then(res => {
      this.survies = res.data
      this.survies.unshift({ id: 0, code: '0', name: '--' });
    })

    if (this.model.clientServeyId > 0) {
      this.isLoading = true;

      this._ClientSurveyService.getById(this.model.clientServeyId).then(res => {
        if (res.succeeded == true) {
          this.model = res.data;
          
          console.log(this.model);
          
          if(this.model.branchId>0){
            this._BranchService.GetByid(this.model.branchId).then(res=>{
              this.model.branchCode=res.data.branchCode;
            })
          }
          if(this.model.representativeId>0){
            this._RepresentativeService.getById(this.model.representativeId).then(res=>{
              this.model.representativeCode=res.data.representativeCode;
            })
          }
          if(this.model.clientId>0){
            this._ClientService.getById(this.model.clientId).then(res=>{
              this.model.clientCode=res.data.clientCode;
            })
          }


          if(res.data.startDate!=null){
            this.model.startDate=new Date(res.data.startDate);
          }

          if(res.data.startTime!=null){
            this.model.startTime=new Date(res.data.startTime);
          }

          if(res.data.createDate!=null){
            this.model.createDate=new Date(res.data.createDate);
          }

          if(res.data.createTime!=null){
            this.model.createTime=new Date(res.data.createTime);
          }

        }
        else {
          this.ref.close();
        }
        this.isLoading = false;

      })
    }

  }



  choose_Branch() {
    var ref = this.dialogService.open(ChooserBranchComponent, {
      header: this.CHOOSE,
      width: '600px',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((res: BranchListModel) => {
      if (res) {
        this.model.branchCode = res.branchCode;
        this.model.branchId = res.branchId;
        this.model.clientCode = '';
        this.model.clientId = 0;
        this.model.representativeCode = '';
        this.model.representativeId = 0;
      }
    });
  }



  choose_Client() {
    if (this.model.branchId > 0) {
      var ref = this.dialogService.open(ChooserClientComponent, {
        header: this.CHOOSE,
        data: { branchId: this.model.branchId },
        width: '90%',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe((res: ClientListModel) => {
        if (res) {
          this.model.clientCode = res.clientCode;
          this.model.clientId = res.clientId;
        }
      });
    }
    else {
      this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });
    }

  }
  choose_Representative() {
    if (this.model.branchId > 0) {
      var ref = this.dialogService.open(ChooserRepresentativeComponent, {
        header: this.CHOOSE,
        data: { branchId: this.model.branchId },
        width: '1200px',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe((res: RepresentativeListModel) => {
        if (res) {
          this.model.representativeCode = res.representativeCode;
          this.model.representativeId = res.representativeId;
        }
      });
    }
    else {
      this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });
    }
  }

  async onSurveyChange(e) {

    this.model.serveyModel = {} as SurveyModel;
    this.model.serveyModel.details = [];

    if (+e.value > 0) {
      console.log(e.value);
      this.isLoading = true;


      this._SurveyService.getById(e.value).then(res => {
        if (res.succeeded == true) {
          this.model.serveyModel = res.data;
        }
        this.isLoading = false;
      })
    }
  }
  async manage(operation) {



    if (operation == 'save') {
      console.log(this.model.serveyModel);

      let valid = true;

      if (this.model.clientId == undefined || this.model.clientId == 0) {
        valid = false;
      }
      if (this.model.serveyStatusId == undefined || this.model.serveyStatusId == 0) {
        valid = false;
      }
      if (this.model.surveyId == undefined || this.model.surveyId == 0) {
        valid = false;
      }
      if (this.model.branchId == undefined || this.model.branchId == 0) {
        valid = false;
      }
      if (this.model.representativeId == undefined || this.model.representativeId == 0) {
        valid = false;
      }

      if (valid == false) {
        this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });
        return;
      }
      this.isLoading = true;
      this._ClientSurveyService.Save(this.model).then(res => {

        if (res.succeeded == true) {
          this.ref.close();
        }

        this.isLoading = false;
      })
    }
  }

  onStatusChanged(arg) {
    if (arg.value == 2 || arg.value == 3) {
      this.model.isClosed = true;
    }
    else {
      this.model.isClosed = false;
    }
  }

}
