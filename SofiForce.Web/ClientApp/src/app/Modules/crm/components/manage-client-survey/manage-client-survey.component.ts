import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { ClientSurveyModel } from 'src/app/core/Models/EntityModels/ClientSurveyModel';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { BooleanService } from 'src/app/core/services/Boolean.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { ChooserBranchComponent } from 'src/app/Modules/shared/chooser-branch/chooser-branch.component';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { ChooserClientComponent } from 'src/app/Modules/shared/chooser-client/chooser-client.component';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { ChooserRepresentativeComponent } from 'src/app/Modules/shared/chooser-representative/chooser-representative.component';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { SurveyModel } from 'src/app/core/Models/EntityModels/SurveyModel';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';
import { BranchModel } from '../../../../core/Models/EntityModels/branchModel';
import { ClientModel } from '../../../../core/Models/EntityModels/clientModel';
import { RepresentativeModel } from '../../../../core/Models/EntityModels/representativeModel';

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
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _BooleanService: BooleanService,
    private config: DynamicDialogConfig,
    private ref: DynamicDialogRef,
    private _commonCrudService : CommonCrudService,


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


    this._commonCrudService.get("ServeyStatus/GetAll", LookupModel).then(res => {
      this.serveyStatus = res.data
    })

    this._commonCrudService.get("Survey/GetAll", LookupModel).then(res => {
      this.survies = res.data
      this.survies.unshift({ id: 0, code: '0', name: '--' });
    })

    if (this.model.clientServeyId > 0) {
      this.isLoading = true;

      this._commonCrudService.get("ClientSurvey/getById?Id="+this.model.clientServeyId, ClientSurveyModel).then(res => {
        if (res.succeeded == true) {
          this.model = res.data;
          
          console.log(this.model);
          
          if(this.model.branchId>0){
            this._commonCrudService.get("Branch/GetByid?Id="+this.model.branchId,BranchModel).then(res=>{
              this.model.branchCode=res.data.branchCode;
            })
          }
          if(this.model.representativeId>0){
            this._commonCrudService.get("Representative/getById?Id="+this.model.representativeId,RepresentativeModel).then(res=>{
              this.model.representativeCode=res.data.representativeCode;
            })
          }
          if(this.model.clientId>0){
            this._commonCrudService.get("Client/getById?Id="+this.model.clientId,ClientModel).then(res=>{
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


      this._commonCrudService.get("Survey/getById?Id="+e.value, SurveyModel).then(res => {
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
      this._commonCrudService.post("ClientSurvey/Save",this.model,ClientSurveyModel).then(res => {

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
