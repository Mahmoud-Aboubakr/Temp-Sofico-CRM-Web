import { Component, OnInit } from '@angular/core';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { OperationRequestModel } from 'src/app/core/Models/EntityModels/OperationRequestModel';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { TranslateService } from '@ngx-translate/core';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { ChooserRepresentativeComponent } from 'src/app/Modules/shared/chooser-representative/chooser-representative.component';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { GeoPoint } from 'src/app/core/Models/DtoModels/GeoPoint';
import { ManageOperationRequestDetailComponent } from '../manage-operation-request-detail/manage-operation-request-detail.component';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';
import { RepresentativeModel } from '../../../../core/Models/EntityModels/representativeModel';

declare var google: any;

@Component({
  selector: 'app-manage-scan-request',
  templateUrl: './manage-scan-request.component.html',
  styleUrls: ['./manage-scan-request.component.scss']
})
export class ManageScanRequestComponent implements OnInit {

  isLoading = false;
  options: any;
  overlays: any[];
  isUploadDone = false;
  model: OperationRequestModel = {} as OperationRequestModel;
  items:MenuItem[]=[];
  CHOOSE_REPRESENTITIVE = ''
  CHOOSE_BRANCH = ''
  selectedIndex=1;
  mapMode = 1;
  mapModes: LookupModel[] = [];
  Governerates: LookupModel[] = [];

  points: GeoPoint[] = [];


  CLIENTS_HEADER='';

  constructor(
    private ref: DynamicDialogRef,
    private _AppMessageService: AppMessageService,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private config: DynamicDialogConfig,
    private _commonCrudService : CommonCrudService,


  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Select Representitive').subscribe((res) => { this.CHOOSE_REPRESENTITIVE = res });
    this._translateService.get('Select Branch').subscribe((res) => { this.CHOOSE_BRANCH = res });
    this._translateService.get('Client Details').subscribe((res) => { this.CLIENTS_HEADER = res });

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


    this.items = [
      {
        label: 'Basic Info',
        icon: 'fa fa-info-circle',
        command: (e) => this.manage(1)
      },
      {
        label: 'Clients',
        icon: 'fa fa-phone-square',
        command: (e) => this.manage(2)
      },
      
    ];



  }
  manage(index){
    this.selectedIndex=index;
  }

  ngOnInit(): void {

    this.options = {
      center: { lat: 30.065774, lng: 31.338034 },
      zoom: 12,
      mapId: '2df52e872b9212a',
      mapTypeControl: false,
      streetViewControl: false,
      keyboardShortcuts: false,
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
      this.overlays.push(

        new google.maps.Polygon({
          paths: [
            this.points
          ], strokeOpacity: 0.5, strokeWeight: 1, fillColor: '#FFC107', fillOpacity: 0.35
        }),

      )
      if (this.points.length > 0) {
        this.options.center = this.points[this.points.length-1];
      }

      await this.fillMap();

      this.isLoading = false;

    })
  }
  async fillMap(){
    this._commonCrudService.get("OperationRequestDetail/getPoints?Id="+this.model.operationId, GeoPoint).then(res=>{
      res.data.forEach(element => {
        this.overlays.push(
          new google.maps.Marker({position: {lat: element.lat, lng: element.lng}, title:element.label,icon:'assets/images/marker_icon_online.png',myData:element.id}),
          
        )
      });
    })
  }

  handleMapClick(event) {
    if (this.mapMode == 2) {
      //event: MouseEvent of Google Maps api
      console.log(event.latLng.lat());
      console.log(event.latLng.lng());
      this.points.push({ lat: event.latLng.lat(), lng: event.latLng.lng(),label:'' ,id:0})


      this.isLoading = true;

      this.overlays = [];
      this.overlays.push(

        new google.maps.Polygon({
          paths: [
            this.points
          ], strokeOpacity: 0.5, strokeWeight: 1, fillColor: '#FFC107', fillOpacity: 0.35
        }),

      )
      if (this.points.length > 0) {
        this.options.center = this.points[0];
      }

      this.isLoading = false;
    }

  }

  handleOverlayClick(event) {
    if(event.overlay.myData>0){
      var ref = this.dialogService.open(ManageOperationRequestDetailComponent, {
        data: { detailId: event.overlay.myData },
        header: this.CLIENTS_HEADER,
        width: '90%',
        height: '90%',
        contentStyle: { "overflow": "auto" },
        baseZIndex: 10000
      });
    }
  }


  Chooser_Represtitive() {
    var ref = this.dialogService.open(ChooserRepresentativeComponent, {
      data: { kindId: '5' },
      header: this.CHOOSE_REPRESENTITIVE,
      width: '90%',
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
    this.model.operationTypeId = 1;
    this.isLoading = true;
    await this._commonCrudService.post("OperationRequest/Save", this.model, OperationRequestModel).then(res => {

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
      this._commonCrudService.parseFile(file,"OperationRequest/parse",GeoPoint).then(res => {
        if (res.succeeded == true) {
          this.isUploadDone = true;
          this.points = res.data;
          this.overlays.push(
            new google.maps.Polygon({
              paths: [
                this.points
              ], strokeOpacity: 0.5, strokeWeight: 1, fillColor: '#FFC107', fillOpacity: 0.35
            }),
          )

          if (this.points.length > 0) {
            this.options.center = this.points[0];
          }
        }
        this.isLoading = false;
      })
    });

    form.clear();

  }
  onModeChange(arg) {
    //{ lat: 36.9177, lng: 30.7854 }, { lat: 36.8851, lng: 30.7802 }, { lat: 36.8829, lng: 30.8111 }, { lat: 36.9177, lng: 30.8159 }
    this.isLoading = true;
    this.overlays = [];
    this.points = [];
    this.overlays.push(

      new google.maps.Polygon({
        paths: [
          this.points
        ], strokeOpacity: 0.5, strokeWeight: 1, fillColor: '#FFC107', fillOpacity: 0.35
      }),

    )
    if (this.points.length > 0) {
      this.options.center = this.points[0];
    }
    this.isLoading = false;

  }
}
