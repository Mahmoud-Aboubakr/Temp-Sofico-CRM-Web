import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { BranchService } from 'src/app/core/services/Branch.Service';
import { ClientRequestService } from 'src/app/core/services/ClientRequest.Service';
import { RepresentativeService } from 'src/app/core/services/Representative.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { ChooserClientComponent } from 'src/app/Modules/shared/chooser-client/chooser-client.component';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { ChooserRepresentativeComponent } from 'src/app/Modules/shared/chooser-representative/chooser-representative.component';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { RequestTypeService } from 'src/app/core/services/RequestType.Service';
import { RequestTypeDetailService } from 'src/app/core/services/RequestTypeDetail.Service';
import { DepartmentService } from 'src/app/core/services/Department.Service';
import { RequestStatusService } from 'src/app/core/services/RequestStatus.Service';
import { PriorityService } from 'src/app/core/services/Priority.Service';
import { UploaderService } from 'src/app/core/services/uploader.service';
import { ClientService } from 'src/app/core/services/Client.Service';
import { ClientServiceRequestModel } from 'src/app/core/Models/EntityModels/ClientServiceRequestModel';
import { ClientServiceRequestDocumentModel } from 'src/app/core/Models/EntityModels/ClientServiceRequestDocumentModel';

@Component({
  selector: 'app-manage-client-service-request',
  templateUrl: './manage-client-service-request.component.html',
  styleUrls: ['./manage-client-service-request.component.scss']
})
export class ManageClientServiceRequestComponent implements OnInit {

  model: ClientServiceRequestModel = {
    inZone:true,
    distance:0
  } as ClientServiceRequestModel;
  isLoading = false;
  CHOOSE = '';

  RequestTypes: LookupModel[] = [];
  RequestTypeDetails: LookupModel[] = [];
  Priorities: LookupModel[] = [];
  RequestStatus: LookupModel[] = [];
  Departments: LookupModel[] = [];

  items: MenuItem[];

  showDocuments = false;

  constructor(

    private ref: DynamicDialogRef,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private _AppMessageService: AppMessageService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _ClientRequestService: ClientRequestService,
    private _BranchService: BranchService,
    private _ClientService: ClientService,

    private activatedRoute: ActivatedRoute,
    private config: DynamicDialogConfig,
    private _RepresentativeService: RepresentativeService,

    private _RequestTypeService: RequestTypeService,
    private _RequestTypeDetailService: RequestTypeDetailService,
    private _DepartmentService: DepartmentService,
    private _RequestStatusService: RequestStatusService,
    private _PriorityService: PriorityService,
    private uploaderService: UploaderService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });
    this.model.branchCode = '';
    this.model.branchId = 0;
    this.model.representativeCode = '';
    this.model.representativeId = 0;
    this.model.clientCode = '';
    this.model.clientId = 0;
    this.model.requestDate = new Date();
    this.model.requestTime = new Date();
    this.model.requestCode = 'SRT-0000000';
    this.model.requestStatusId = 1;
    this.model.documents = [];


    if (this.config.data) {

      if (+this.config.data.requestId > 0) {
        this.model.requestId = +this.config.data.requestId
      }

    }
  }

  ngOnInit(): void {


    this.items = [
      {
        label: 'clear',
        icon: 'pi pi-fw pi-times',
        visible: true,
        command: (e) => this.manage('clear')
      },
      {
        label: 'Escalate',
        icon: 'pi pi-fw pi-bolt',
        visible: true,
        command: (e) => this.manage('escalate')
      },
      {
        label: 'closed',
        icon: 'pi pi-fw pi-check',
        visible: true,

        command: (e) => this.manage('closed')
      },
    ];


    this._RequestTypeService.GetAll().then(res => {
      this.RequestTypes = res.data;
      if (this.RequestTypes.length > 0) {
        this._RequestTypeDetailService.GetByTypeId(this.RequestTypes[0].id).then(res => {
          this.RequestTypeDetails = res.data;
        })
      }
    })

    this._RequestStatusService.GetAll().then(res => {
      this.RequestStatus = res.data

      this.model.timeLine = [];
      this.RequestStatus.forEach((e) => {
        this.model.timeLine.push(
          {
            requestId: this.model.requestId,
            requestStatusId: e.id,
            requestStatusName: e.name,
            notes: '',
            timelineDate: null,
            timelineId: 0,
            userId: 0,
            realName:'',
            color:''
          });
      })
      this.model.timeLine[0].timelineDate = new Date();

    })

    this._DepartmentService.GetAll().then(res => {
      this.Departments = res.data
      this.Departments.unshift({ id: 0, code: '0', name: '--' });
    })


    this._PriorityService.GetAll().then(res => {
      this.Priorities = res.data
    })

  

    if (this.model.requestId > 0) {
      this.isLoading = true;
      this._ClientRequestService.getById(this.model.requestId).then(async res => {
        if (res != null && res.succeeded == true && res.data.clientId > 0) {


          this.model = res.data;

          if(this.model.closeDate)
          {
            this.model.closeDate=new Date(res.data.closeDate);
          }
          if(this.model.requestDate)
          {
            this.model.requestDate=new Date(res.data.requestDate);
          }  
          if(this.model.requestTime)
          {
            this.model.requestTime=new Date(res.data.requestTime);
          }            

          if (this.model.clientId > 0) {
            this._ClientService.getById(this.model.clientId).then(res => {
              this.model.clientCode = res.data.clientCode;
            })
          }

          if (this.model.representativeId > 0) {
            this._RepresentativeService.getById(this.model.representativeId).then(res => {
              this.model.representativeCode = res.data.representativeCode;
            })
          }

          if (this.model.requestTypeId > 0) {
            this._RequestTypeDetailService.GetByTypeId(this.model.requestTypeId).then(res => {
              this.RequestTypeDetails = res.data;
            })
          }

          if (!this.model.documents || this.model.documents == null) {
            this.model.documents = [];
          }

          if (!this.model.timeLine || this.model.timeLine == null) {
            this.model.timeLine = [];
          }

          this.isLoading = false;

        }
        else {
          this.ref.close();
        }
      })
    }

  }
  async onTypeChange(arg) {
    this.isLoading = true;
    this._RequestTypeDetailService.GetByTypeId(arg.value).then(res => {
      this.RequestTypeDetails = res.data;
      this.isLoading = false;
    })
  }
  choose_Client() {
    var ref = this.dialogService.open(ChooserClientComponent, {
      header: this.CHOOSE,
      width: '90%',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((res: ClientListModel) => {
      if (res) {
        this.model.clientCode = res.clientCode;
        this.model.clientId = res.clientId;
        this.model.branchId = res.branchId;
      }
    });
  }
  choose_Representative() {
    var ref = this.dialogService.open(ChooserRepresentativeComponent, {
      header: this.CHOOSE,
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
  manage(operation) {
    if (operation == 'clear') {
      this.model = {} as ClientServiceRequestModel;

      this.model.branchCode = '';
      this.model.branchId = 0;
      this.model.representativeCode = '';
      this.model.representativeId = 0;
      this.model.clientCode = '';
      this.model.clientId = 0;
      this.model.requestDate = new Date();
      this.model.requestCode = 'SRT-0000000';
      this.model.requestStatusId = 1;
      this.model.documents = [];

    }
    if (operation == 'save') {
      this.save();
    }
    if (operation == 'escalate') {
      if (this.model.departmentId == undefined || this.model.departmentId == 0) {
        this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });
        return;
      }

      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {
          this.model.requestStatusId = 2;
          this.save();

        },
        reject: () => {
          //reject action
        }
      });
    }
    if (operation == 'closed') {
      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {
          this.model.requestStatusId = 3;
          this.model.isClosed = true;
          this.model.closeDate = new Date();
          this.save();
        },
        reject: () => {
          //reject action
        }
      });
    }
  }

  save() {
    let valid = true;

    if (this.model.clientId == undefined || this.model.clientId == 0) {
      valid = false;
      return;
    }

    if (this.model.representativeId == undefined || this.model.representativeId == 0) {
      valid = false;
      return;
    }

    if (this.model.requestTypeId == undefined || this.model.requestTypeId == 0) {
      valid = false;
      return;
    }
    if (this.model.requestTypeDetailId == undefined || this.model.requestTypeDetailId == 0) {
      valid = false;
      return;
    }
    if (this.model.priorityId == undefined || this.model.priorityId == 0) {
      valid = false;
      return;
    }
    if (this.model.requestStatusId == undefined || this.model.requestStatusId == 0) {
      valid = false;
      return;
    }

    if (valid == true) {

      this.isLoading = true;

      this._ClientRequestService.Save(this.model).then(res => {
        if (res.succeeded == true && res.data.requestId > 0) {
          this.model = res.data;

          if(this.model.closeDate)
          {
            this.model.closeDate=new Date(res.data.closeDate);
          }
          if(this.model.requestDate)
          {
            this.model.requestDate=new Date(res.data.requestDate);
          }  
          if(this.model.requestTime)
          {
            this.model.requestTime=new Date(res.data.requestTime);
          }  

          this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });
        }
        else {
          this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });
        }
        this.isLoading = false;

      })

    }


  }

  manageDocument(operation, object) {
    if (operation == 'add') {
      this.showDocuments = true;
    }
    if (operation == 'delete') {
      let found = this.model.documents.find(a => a.requestDocumentId == object.RequestDocumentId);
      if (found) {
        this.model.documents = this.model.documents.filter(function (row, index, arr) {
          return row.requestDocumentId != found.requestDocumentId;
        });
      }
    }
  }

  myUploader(event, form) {

    this.isLoading = true;
    let document = {} as ClientServiceRequestDocumentModel;

    document.documentPath = '';

    event.files.forEach(file => {
      this.uploaderService.Upload(file).then(res => {
        if (res.succeeded == true) {
          document.requestDocumentId = -1 * Math.floor(Math.random() * (11111111 - 99999999 + 1));
          document.documentPath = res.data.fileUrl;
          this.showDocuments = false;
          this.model.documents.push(document);

        }
        this.isLoading = false;
      })
    });

    form.clear();

  }

}
