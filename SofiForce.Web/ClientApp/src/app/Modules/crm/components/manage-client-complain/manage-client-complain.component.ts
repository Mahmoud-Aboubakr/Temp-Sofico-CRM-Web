import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { ClientComplainModel } from 'src/app/core/Models/EntityModels/ClientComplainModel';
import { ChooserClientComponent } from 'src/app/Modules/shared/chooser-client/chooser-client.component';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { ChooserRepresentativeComponent } from 'src/app/Modules/shared/chooser-representative/chooser-representative.component';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { ClientComplainDocumentModel } from 'src/app/core/Models/EntityModels/ClientComplainDocumentModel';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';
import { ClientModel } from '../../../../core/Models/EntityModels/clientModel';
import { RepresentativeModel } from '../../../../core/Models/EntityModels/representativeModel';
import { FileModel } from 'src/app/core/Models/DtoModels/FileModel';


@Component({
  selector: 'app-manage-client-complain',
  templateUrl: './manage-client-complain.component.html',
  styleUrls: ['./manage-client-complain.component.scss']
})
export class ManageClientComplainComponent implements OnInit {

  model: ClientComplainModel = {
    inZone:true,
    distance:0
  } as ClientComplainModel;
  isLoading = false;
  CHOOSE = '';

  ComplainTypes: LookupModel[] = [];
  ComplainTypeDetails: LookupModel[] = [];
  Priorities: LookupModel[] = [];
  ComplainStatus: LookupModel[] = [];
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
    private activatedRoute: ActivatedRoute,
    private config: DynamicDialogConfig,
    private _commonCrudService : CommonCrudService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });
    this.model.branchCode = '';
    this.model.branchId = 0;
    this.model.representativeCode = '';
    this.model.representativeId = 0;
    this.model.clientCode = '';
    this.model.clientId = 0;
    this.model.complainDate = new Date();
    this.model.complainTime = new Date();
    this.model.complainCode = 'CMP-0000000';
    this.model.complainStatusId = 1;
    this.model.documents = [];


    if (this.config.data) {

      if (+this.config.data.complainId > 0) {
        this.model.complainId = +this.config.data.complainId
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


    this._commonCrudService.get("ComplainType/GetAll", LookupModel).then(res => {
      this.ComplainTypes = res.data;
      if (this.ComplainTypes.length > 0) {
        this._commonCrudService.get("ComplainTypeDetail/GetByTypeId?Id="+this.ComplainTypes[0].id, LookupModel).then(res => {
          this.ComplainTypeDetails = res.data;
        })
      }
    })

    this._commonCrudService.get("ComplainStatus/GetAll", LookupModel).then(res => {
      this.ComplainStatus = res.data

      this.model.timeLine = [];
      this.ComplainStatus.forEach((e) => {
        this.model.timeLine.push(
          {
            complainId: this.model.complainId,
            complainStatusId: e.id,
            complainStatusName: e.name,
            notes: '',
            timelineDate: null,
            timelineId: 0,
            userId: 0,
            userName:''
          });
      })
      this.model.timeLine[0].timelineDate = new Date();

    })

    this._commonCrudService.get("Department/GetAll", LookupModel).then(res => {
      this.Departments = res.data
      this.Departments.unshift({ id: 0, code: '0', name: '--' });
    })


    this._commonCrudService.get("Priority/GetAll", LookupModel).then(res => {
      this.Priorities = res.data
    })

  

    if (this.model.complainId > 0) {
      this.isLoading = true;
      this._commonCrudService.get("ClientComplain/getById?Id="+this.model.complainId, ClientComplainModel).then(async res => {
        if (res != null && res.succeeded == true && res.data.clientId > 0) {


          this.model = res.data;

          if(this.model.closeDate)
          {
            this.model.closeDate=new Date(res.data.closeDate);
          }
          if(this.model.complainDate)
          {
            this.model.complainDate=new Date(res.data.complainDate);
          }  
          if(this.model.complainTime)
          {
            this.model.complainTime=new Date(res.data.complainTime);
          }            

          if (this.model.clientId > 0) {
            this._commonCrudService.get("Client/getById?Id="+this.model.clientId, ClientModel).then(res => {
              this.model.clientCode = res.data.clientCode;
            })
          }

          if (this.model.representativeId > 0) {
            this._commonCrudService.get("Representative/getById?Id="+this.model.representativeId, RepresentativeModel).then(res => {
              this.model.representativeCode = res.data.representativeCode;
            })
          }

          if (this.model.complainTypeId > 0) {
            this._commonCrudService.get("ComplainTypeDetail/GetByTypeId?Id="+this.model.complainTypeId, LookupModel).then(res => {
              this.ComplainTypeDetails = res.data;
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
    this._commonCrudService.get("ComplainTypeDetail/GetByTypeId?Id="+arg.value, LookupModel).then(res => {
      this.ComplainTypeDetails = res.data;
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
      this.model = {} as ClientComplainModel;

      this.model.branchCode = '';
      this.model.branchId = 0;
      this.model.representativeCode = '';
      this.model.representativeId = 0;
      this.model.clientCode = '';
      this.model.clientId = 0;
      this.model.complainDate = new Date();
      this.model.complainCode = 'CMP-0000000';
      this.model.complainStatusId = 1;
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
          this.model.complainStatusId = 2;
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
          this.model.complainStatusId = 3;
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

    if (this.model.complainTypeId == undefined || this.model.complainTypeId == 0) {
      valid = false;
      return;
    }
    if (this.model.complainTypeDetailId == undefined || this.model.complainTypeDetailId == 0) {
      valid = false;
      return;
    }
    if (this.model.priorityId == undefined || this.model.priorityId == 0) {
      valid = false;
      return;
    }
    if (this.model.complainStatusId == undefined || this.model.complainStatusId == 0) {
      valid = false;
      return;
    }

    if (valid == true) {

      this.isLoading = true;

      this._commonCrudService.post("ClientComplain/Save", this.model, ClientComplainModel).then(res => {
        if (res.succeeded == true && res.data.complainId > 0) {
          this.model = res.data;

          if(this.model.closeDate)
          {
            this.model.closeDate=new Date(res.data.closeDate);
          }
          if(this.model.complainDate)
          {
            this.model.complainDate=new Date(res.data.complainDate);
          }  
          if(this.model.complainTime)
          {
            this.model.complainTime=new Date(res.data.complainTime);
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
      let found = this.model.documents.find(a => a.complainDocumentId == object.complainDocumentId);
      if (found) {
        this.model.documents = this.model.documents.filter(function (row, index, arr) {
          return row.complainDocumentId != found.complainDocumentId;
        });
      }
    }
  }

  myUploader(event, form) {

    this.isLoading = true;
    let document = {} as ClientComplainDocumentModel;

    document.documentPath = '';

    event.files.forEach(file => {
      this._commonCrudService.parseFile(file,"Uploader/add",FileModel).then(res => {
        if (res.succeeded == true) {
          document.complainDocumentId = -1 * Math.floor(Math.random() * (11111111 - 99999999 + 1));
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
