import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { OperationRequestDetailService } from 'src/app/core/services/OperationRequestDetail.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';


import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { OperationRequestDetailModel } from 'src/app/core/Models/EntityModels/OperationRequestDetailModel';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { GovernerateService } from 'src/app/core/services/Governerate.Service';
import { CityService } from 'src/app/core/services/City.Service';
import { DocumentTypeService } from 'src/app/core/services/DocumentType.Service';
import { LandmarkService } from 'src/app/core/services/Landmark.Service';
import { PreferredOperationService } from 'src/app/core/services/PreferredOperation.Service';
import { WeekDayService } from 'src/app/core/services/WeekDay.Service';
import { OperationStatusService } from 'src/app/core/services/OperationStatus.Service';
import { ClientTypeService } from 'src/app/core/services/ClientType.Service';
import { OperationRequestDetailLandmarkListModel } from 'src/app/core/Models/ListModels/OperationRequestDetailLandmarkListModel';
import { LocationLevelService } from 'src/app/core/services/LocationLevel.Service';
import { OperationRequestDetailPreferredTimeListModel } from 'src/app/core/Models/ListModels/OperationRequestDetailPreferredTimeListModel';
import { UploaderService } from 'src/app/core/services/uploader.service';
import { OperationRequestDetailDocumentListModel } from 'src/app/core/Models/ListModels/OperationRequestDetailDocumentListModel';
import { OperationRequestDetailRejectModel } from 'src/app/core/Models/DtoModels/OperationRequestDetailRejectModel';
import { OperationRejectReasonService } from 'src/app/core/services/OperationRejectReason.Service';
import { OperationRequestDetailApproveModel } from 'src/app/core/Models/DtoModels/OperationRequestDetailApproveModel';
import { ChooserClientComponent } from 'src/app/Modules/shared/chooser-client/chooser-client.component';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { OperationRequestDetailCodedModel } from 'src/app/core/Models/DtoModels/OperationRequestDetailCodedModel';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';


@Component({
  selector: 'app-manage-operation-request-detail',
  templateUrl: './manage-operation-request-detail.component.html',
  styleUrls: ['./manage-operation-request-detail.component.scss']
})
export class ManageOperationRequestDetailComponent implements OnInit {

  model = {} as OperationRequestDetailModel;

  MAP_VIEWER
  isLoading = false;

  Governerates: LookupModel[] = [];
  Cities: LookupModel[] = [];


  ClientTypes: LookupModel[] = [];
  LocationLevels: LookupModel[] = [];
  OperationStatuses: LookupModel[] = [];
  DocumentTypes: LookupModel[] = [];

  Landmarks: LookupModel[] = [];
  PreferredOperations: LookupModel[] = [];
  WeekDays: LookupModel[] = [];
  RejectReasons: LookupModel[] = [];

  items: MenuItem[];

  selectedLandmark = {} as OperationRequestDetailLandmarkListModel;
  selectedPreferred = {
    preferredOperationId: 1,
  } as OperationRequestDetailPreferredTimeListModel;
  selectedDocument = {} as OperationRequestDetailDocumentListModel;

  showLandmarks = false;
  showPreferreds = false;
  showDocuments = false;
  showReject = false;
  showApprove = false;
  showCoded = false;
  advanced=false;



  fromTime = new Date();
  toTime = new Date();

  CHOOSE_CLIENT = '';
  constructor(
    private ref: DynamicDialogRef,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private _AppMessageService: AppMessageService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _OperationRequestDetailService: OperationRequestDetailService,
    private activatedRoute: ActivatedRoute,
    private config: DynamicDialogConfig,
    private _GovernerateService: GovernerateService,
    private _CityService: CityService,
    private _LandmarkService: LandmarkService,
    private _PreferredOperationService: PreferredOperationService,
    private _WeekDayService: WeekDayService,
    private _DocumentTypeService: DocumentTypeService,
    private _OperationStatusService: OperationStatusService,
    private _ClientTypeService: ClientTypeService,
    private _LocationLevelService: LocationLevelService,
    private uploaderService: UploaderService,

    private _OperationRejectReasonService: OperationRejectReasonService,

    private _commonCrudService : CommonCrudService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Map Viewer').subscribe((res) => { this.MAP_VIEWER = res });
    this._translateService.get('Select Client').subscribe((res) => { this.CHOOSE_CLIENT = res });

    this.model.operationStatusId = 1;
    this.model.operationDate = new Date();
    this.model.isChain = false;
    this.model.accuracy = 0;

    if (this.config.data) {
      
      if (+this.config.data.detailId > 0) {
        this.model.detailId = +this.config.data.detailId
      }

    }


    this.items = [
      {
        label: 'Approved',
        icon: 'pi pi-fw pi-check',
        visible: false,
        command: (e) => this.manage('approve')
      },
      {
        label: 'Rejected',
        icon: 'pi pi-fw pi-times',
        visible: false,

        command: (e) => this.manage('reject')
      },
      {
        label: 'Coded',
        icon: 'pi pi-fw pi-user-plus',
        visible: false,

        command: (e) => this.manage('coded')
      },
    ];

  }

  ngOnInit(): void {

    this._commonCrudService.get("Governerate/GetAll", LookupModel).then(res => {
      this.Governerates = res.data;
      if (this.Governerates.length > 0) {
        this._commonCrudService.get("City/GetByGovernerate?Id="+this.Governerates[0].id, LookupModel).then(res => {
          this.Cities = res.data;
        })
      }
    });

    this._commonCrudService.get("Landmark/GetAll", LookupModel).then(res => {
      this.Landmarks = res.data;
    })
    this._commonCrudService.get("PreferredOperation/GetAll", LookupModel).then(res => {
      this.PreferredOperations = res.data;
    })
    this._commonCrudService.get("WeekDay/GetAll", LookupModel).then(res => {
      this.WeekDays = res.data;
    })
    this._commonCrudService.get("DocumentType/GetAll", LookupModel).then(res => {
      this.DocumentTypes = res.data;
    })

    this._commonCrudService.get("OperationStatus/GetAll", LookupModel).then(res => {
      this.OperationStatuses = res.data;
    })
    this._commonCrudService.get("ClientType/GetAll", LookupModel).then(res => {
      this.ClientTypes = res.data;
    })

    this._commonCrudService.get("LocationLevel/GetAll", LookupModel).then(res => {
      this.LocationLevels = res.data;
    })

    this._commonCrudService.get("OperationRejectReason/GetAll", LookupModel).then(res => {
      this.RejectReasons = res.data;
    })


    this.isLoading = true;
    if (this.model.detailId > 0) {
      this._commonCrudService.get("OperationRequestDetail/getById?Id="+this.model.detailId,OperationRequestDetailModel).then(async res => {
        if (res != null && res.succeeded == true && res.data.detailId > 0) {

         
          this.model = res.data;
          if(this.model.clientId>0){
            this.model.operationTypeId=2;
          }
          else
          {
            this.model.operationTypeId=1;
          }

          this.model.operationDate = new Date(res.data.operationDate);
          if (!this.model.landmarks || this.model.landmarks == null) {
            this.model.landmarks = [];
          }
          if (!this.model.preferredTimes || this.model.preferredTimes == null) {
            this.model.preferredTimes = [];
          }
          if (!this.model.documents || this.model.documents == null) {
            this.model.documents = [];
          }
          if (this.model.governerateId > 0) {
            await this._commonCrudService.get("City/GetByGovernerate?Id="+this.model.governerateId, LookupModel).then(res => {
              this.Cities = res.data;

            })
          }
          this.isLoading = false;

          this.refreshMenu();
        }
        else {
          this.ref.close();
        }
      })
    }
  }


  async manage(operation) {

    if (operation == "save") {

      if (this.isvalid() == false) {
        this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });
        return;
      }

      this.isLoading = true;
      this._commonCrudService.post("OperationRequestDetail/Save", this.model, OperationRequestDetailModel).then(res => {
        this.isLoading = false;
      });

    }

    if (operation == "approve") {
      this.showApprove = true;

    }

    if (operation == "reject") {
      this.showReject = true;
    }
    if (operation == "coded") {
      this.showCoded = true;
    }
  }


  isvalid() {

    let valid = true;

    if (this.model.operationId == null || this.model.operationId == 0)
      valid = false;
    if (this.model.clientTypeId == null || this.model.clientTypeId == 0)
      valid = false;
    if (!this.model.clientNameAr)
      valid = false;
    if (!this.model.clientNameEn)
      valid = false;
    if (this.model.governerateId == null || this.model.governerateId == 0)
      valid = false;
    if (this.model.cityId == null || this.model.cityId == 0)
      valid = false;
    if (this.model.locationLevelId == null || this.model.locationLevelId == 0)
      valid = false;
    if (!this.model.taxCode)
      valid = false;
    if (!this.model.commercialCode)
      valid = false;
    if (!this.model.address)
      valid = false;

    if (!this.model.mobile)
      valid = false;

    if (this.model.latitude == null || this.model.latitude == 0)
      valid = false;

    if (this.model.longitude == null || this.model.longitude == 0)
      valid = false;

    return valid;
  }


  async onGovernerateChange(e) {

    this.Cities = [];
    this.isLoading = true;

    this._commonCrudService.get("City/GetByGovernerate?Id="+e.value, LookupModel).then(res => {
      this.Cities = res.data;
      this.isLoading = false;
    })
  }

  manageLandmark(operation) {
    if (operation == 'add') {
      this.showLandmarks = true;
    }
    if (operation == 'delete') {
      if (this.selectedLandmark) {
        if (this.selectedLandmark.detaillandId) {

          let found = this.model.landmarks.find(a => a.detaillandId == this.selectedLandmark.detaillandId);
          if (found) {
            this.model.landmarks = this.model.landmarks.filter(function (row, index, arr) {
              return row.detaillandId != found.detaillandId;
            });
            this.selectedLandmark = {
              detailId: this.model.detailId,
              detaillandId: 0,
              landmarkId: 0
            } as OperationRequestDetailLandmarkListModel;
          }
        }
      }
    }
    if (operation == 'save') {
      let lm = {} as OperationRequestDetailLandmarkListModel;
      console.log(this.selectedLandmark);

      if (this.selectedLandmark) {
        if (this.selectedLandmark.landmarkId) {
          lm.detaillandId = -1 * Math.floor(Math.random() * (11111111 - 99999999 + 1));
          lm.landmarkId = this.selectedLandmark.landmarkId;
          lm.detailId = this.model.detailId;
          lm.landmarkName = this.Landmarks.find(a => a.id == this.selectedLandmark.landmarkId).name;
          let found = this.model.landmarks.find(a => a.landmarkId == lm.landmarkId);
          if (!found) {
            this.model.landmarks.push(lm);
          }
        }
      }

    }
  }


  managePreferred(operation) {
    if (operation == 'add') {
      this.showPreferreds = true;
    }
    if (operation == 'delete') {
      if (this.selectedPreferred) {
        if (this.selectedPreferred.preferredId) {

          let found = this.model.preferredTimes.find(a => a.preferredId == this.selectedPreferred.preferredId);
          if (found) {
            this.model.preferredTimes = this.model.preferredTimes.filter(function (row, index, arr) {
              return row.preferredId != found.preferredId;
            });

            this.selectedPreferred = {
              detailId: this.model.detailId,
              preferredId: 0,
              preferredOperationId: 1,
              weekDayId: 1
            } as OperationRequestDetailPreferredTimeListModel;
          }
        }
      }
    }
    if (operation == 'save') {

      if (this.selectedPreferred == null) {
        return;
      }

      if (this.selectedPreferred.preferredOperationId == null || this.selectedPreferred.preferredOperationId == 0) {
        return;
      }

      if (this.selectedPreferred.weekDayId == null || this.selectedPreferred.weekDayId == 0) {
        return;
      }

      if (this.fromTime == null) {
        return;
      }

      if (this.toTime == null) {
        return;
      }

      let time = {} as OperationRequestDetailPreferredTimeListModel;

      time.detailId = this.model.detailId;
      time.weekDayId = this.selectedPreferred.weekDayId;
      time.preferredOperationId = this.selectedPreferred.preferredOperationId;

      time.preferredId = -1 * Math.floor(Math.random() * (11111111 - 99999999 + 1))
      time.weekDayName = this.WeekDays.find(a => a.id == this.selectedPreferred.weekDayId).name;
      time.preferredOperationName = this.PreferredOperations.find(a => a.id == this.selectedPreferred.preferredOperationId).name;
      time.fromTime = this.fromTime.toTimeString().split(' ')[0];
      time.toTime = this.toTime.toTimeString().split(' ')[0];

      this.model.preferredTimes.push(time);

      this.selectedPreferred = {
        preferredOperationId: 1,
      } as OperationRequestDetailPreferredTimeListModel;
      this.fromTime = new Date();
      this.toTime = new Date();

      this.showPreferreds = false;


    }
  }

  manageDocument(operation) {
    if (operation == 'add') {
      this.showDocuments = true;
    }
    if (operation == 'delete') {
      if (this.selectedDocument) {
        if (this.selectedDocument.detailDocumentId) {

          let found = this.model.documents.find(a => a.detailDocumentId == this.selectedDocument.detailDocumentId);
          if (found) {
            this.model.documents = this.model.documents.filter(function (row, index, arr) {
              return row.detailDocumentId != found.detailDocumentId;
            });
            this.selectedDocument = {
              detailId: this.model.detailId,
              detailDocumentId: 0,
              documentTypeId: 1
            } as OperationRequestDetailDocumentListModel;
          }
        }
      }
    }

  }

  myUploader(event, form) {

    this.isLoading = true;
    let document = {} as OperationRequestDetailDocumentListModel;

    document.documentPath = '';

    event.files.forEach(file => {
      this.uploaderService.Upload(file).then(res => {
        if (res.succeeded == true) {


          let found = this.model.documents.find(a => a.detailDocumentId == this.selectedDocument.detailDocumentId);

          if (!found) {

            document.detailDocumentId = -1 * Math.floor(Math.random() * (11111111 - 99999999 + 1));
            document.documentPath = res.data.fileUrl;
            document.documentTypeId = this.selectedDocument.documentTypeId;
            document.documentTypeName = this.DocumentTypes.find(a => a.id === document.documentTypeId).name;

            this.showDocuments = false;


            this.model.documents.push(document);
          }

        }
        this.isLoading = false;
      })
    });

    form.clear();

  }
  reject() {

    if (this.model.accuracy == null || this.model.accuracy==0) {
      this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });
      return;
    }

    if (this.model.operationRejectReasonId == null || this.model.operationRejectReasonId==0) {
      this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });
      return;
    }

    this.isLoading = true;
    let rejectModel = {} as OperationRequestDetailRejectModel;
    rejectModel.detailId = this.model.detailId;
    rejectModel.accuracy = this.model.accuracy;
    rejectModel.operationRejectReasonId = this.model.operationRejectReasonId;
    rejectModel.operationTypeId=this.model.operationTypeId;

    this._commonCrudService.post("OperationRequestDetail/reject", rejectModel, OperationRequestDetailRejectModel).then(res => {
      this.isLoading = false;
      this.showReject = false;
      this.ref.close();
    });
  }
  approve() {

    if (this.isvalid() == false) {
      this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });
      return;
    }

    if (this.model.accuracy == null || this.model.accuracy==0) {
      this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });
      return;
    }

    this.isLoading = true;
    let approveModel = {} as OperationRequestDetailApproveModel;
    approveModel.detailId = this.model.detailId;
    approveModel.accuracy = this.model.accuracy;
    approveModel.operationTypeId=this.model.operationTypeId;

    console.log(approveModel);

    this._commonCrudService.post("OperationRequestDetail/approve", approveModel, OperationRequestDetailApproveModel).then(res => {
      this.isLoading = false;
      this.showReject = false;
      this.ref.close();
    });
  }
  coded() {

    if (this.isvalid() == false) {
      this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });
      return;
    }

    if (this.model.clientId == null || this.model.clientId==0) {
      this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });
      return;
    }

    this.isLoading = true;
    let codedModel = {} as OperationRequestDetailCodedModel;
    codedModel.detailId = this.model.detailId;
    codedModel.clientId = this.model.clientId;
    codedModel.operationTypeId=this.model.operationTypeId;

    this._commonCrudService.post("OperationRequestDetail/coded", codedModel, OperationRequestDetailCodedModel).then(res => {
      this.isLoading = false;
      this.showCoded = false;
      this.ref.close();
    });
  }
  Chooser_Client() {
    var ref = this.dialogService.open(ChooserClientComponent, {
      header: this.CHOOSE_CLIENT,
      width: '90%',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((sel: ClientListModel) => {
      if (sel != null) {
        this.model.clientCode = sel.clientCode;
        this.model.clientId = sel.clientId;
      }
    });
  }

  refreshMenu() {

    this.items[0].visible = false;
    this.items[1].visible = false;
    this.items[2].visible = false;

    if (this.model) {


      if(this.model.operationTypeId==1){
        if (this.model.operationStatusId == 1) {
          this.items[0].visible = true;
          this.items[1].visible = true;
        }
  
        if (this.model.operationStatusId == 2) {
          this.items[2].visible = true;
        }
      }
      else
      {
        if (this.model.operationStatusId == undefined || this.model.operationStatusId==null) {
          this.items[0].visible = true;
          this.items[1].visible = true;
        }
      }


    }
  }
}
