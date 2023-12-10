import { Component, OnInit } from '@angular/core';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { OperationRequestModel } from 'src/app/core/Models/EntityModels/OperationRequestModel';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { RepresentativeService } from 'src/app/core/services/Representative.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { TranslateService } from '@ngx-translate/core';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ChooserRepresentativeComponent } from 'src/app/Modules/shared/chooser-representative/chooser-representative.component';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { UploaderService } from 'src/app/core/services/uploader.service';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { OperationRequestService } from 'src/app/core/services/OperationRequest.Service';
import { GeoPoint } from 'src/app/core/Models/DtoModels/GeoPoint';
import { GovernerateService } from 'src/app/core/services/Governerate.Service';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';
import { RepresentativeModel } from '../../../../core/Models/EntityModels/representativeModel';


declare var google: any;

@Component({
  selector: 'app-manage-validation-request',
  templateUrl: './manage-validation-request.component.html',
  styleUrls: ['./manage-validation-request.component.scss']
})
export class ManageValidationRequestComponent implements OnInit {

  isLoading = false;
  options: any;
  overlays: any[];
  isUploadDone = false;
  model: OperationRequestModel = {} as OperationRequestModel;

  CHOOSE_REPRESENTITIVE = ''
  CHOOSE_BRANCH = ''

  mapMode = 1;
  mapModes: LookupModel[] = [];
  Governerates: LookupModel[] = [];

  points: GeoPoint[] = [];

  constructor(
    private ref: DynamicDialogRef,
    private _AppMessageService: AppMessageService,
    private _RepresentativeService: RepresentativeService,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private config: DynamicDialogConfig,
    private _uploaderService: UploaderService,
    private _OperationRequestService: OperationRequestService,
    private _GovernerateService: GovernerateService,

    private _commonCrudService : CommonCrudService,


  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Select Representitive').subscribe((res) => { this.CHOOSE_REPRESENTITIVE = res });
    this._translateService.get('Select Branch').subscribe((res) => { this.CHOOSE_BRANCH = res });

    this.mapModes.push({ id: 1, code: '1', name: 'File Upload' });
    this.mapModes.push({ id: 2, code: '2', name: 'Draw Map' });


    this.model.operationDate = new Date();
    this.model.representativecode = '';
    this.model.accuracy = 0;


    if (this.config.data) {
      if (+this.config.data.operationId > 0) {
        this.model.operationId = +this.config.data.operationId
      }
    }


  }

  ngOnInit(): void {

    this.options = {
      center: { lat: 30.065774, lng: 31.338034 },
      zoom: 12,
      mapId: '2df52e872b9212a'
    };

    this.overlays = [

    ];

    this._commonCrudService.get("Governerate/GetAll", LookupModel).then(res => {
      this.Governerates = res.data;
    })

    if (this.model.operationId > 0) {
      this.fillForm();
    }
  }

  async fillForm() {
    this.isLoading = true;
    this._commonCrudService.get("OperationRequest/getById?Id="+this.model.operationId, OperationRequestModel).then(async res => {

      this.model = res.data;
      if (this.model.closeDate)
        this.model.closeDate = new Date(this.model.closeDate);
      if (this.model.operationDate)
        this.model.operationDate = new Date(this.model.operationDate);
      if (this.model.startDate)
        this.model.startDate = new Date(this.model.startDate);

      this.model.representativecode = '';

      if (this.model.representativeId > 0) {
        await this._commonCrudService.get("Representative/getById?Id="+this.model.representativeId, RepresentativeModel).then(res => {
          this.model.representativecode = res.data.representativeCode;
        })
      }

      this.points=JSON.parse(this.model.mapPoints);
      
      this.points.forEach(element => {
        this.overlays.push(new google.maps.Marker({ position: { lat: element.lat, lng: element.lng }, title: '', icon:'assets/images/marker_icon_offline.png', data: 0}))
      });

      if (this.points.length > 0) {
        this.options.center = this.points[0];
      }

      this.isLoading = false;

    })
  }

  handleOverlayClick(event) {
  }


  Chooser_Represtitive() {
    var ref = this.dialogService.open(ChooserRepresentativeComponent, {
      data: { kindId: '5' },
      header: this.CHOOSE_REPRESENTITIVE,
      width: '1200px',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((sel: RepresentativeListModel) => {
      if (sel != null) {
        this.model.representativeId = sel.representativeId;
        this.model.representativecode = sel.representativeCode;
      }
    });
  }

  async Save() {
    let valid = true;
    if (!this.model.governerateId || this.model.governerateId == 0) {
      valid = false;
    }
    if (!this.model.representativeId || this.model.representativeId == 0) {
      valid = false;
    }
    if (!this.model.targetDays || this.model.targetDays == 0) {
      valid = false;
    }

    if (this.points.length == 0) {
      valid = false;
    }

    if (valid == false) {
      this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });
      return;
    }


    this.model.mapPoints = JSON.stringify(this.points);
    this.model.operationTypeId = 2;
    this.isLoading = true;
    await this._commonCrudService.post("OperationRequest/Save",this.model, OperationRequestModel).then(res => {

      this.isLoading = false;

      if (res.succeeded == true) {
        this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });
        this.ref.close();
      }
      else {
        this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
      }

    })
  }

  myUploader(event, form) {

    this.isLoading = true;
    this.isUploadDone = false;
    //this.model.filePath = '';

    this.overlays = [];
    this.points = [];

    event.files.forEach(file => {
      this._OperationRequestService.parseClients(file).then(res => {
        if (res.succeeded == true) {
          this.isUploadDone = true;
          this.points = res.data;
         
          this.points.forEach(element => {
            this.overlays.push(new google.maps.Marker({ position: { lat: element.lat, lng: element.lng }, title: element.label, icon:'assets/images/marker_icon_offline.png', data: 0}))
          });

          if (this.points.length > 0) {
            this.options.center = this.points[0];
          }
        }
        this.isLoading = false;
      })
    });

    form.clear();

  }
}
