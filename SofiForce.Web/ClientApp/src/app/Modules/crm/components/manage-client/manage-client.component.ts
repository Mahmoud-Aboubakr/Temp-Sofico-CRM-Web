import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';

import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { GovernerateService } from 'src/app/core/services/Governerate.Service';
import { CityService } from 'src/app/core/services/City.Service';
import { DocumentTypeService } from 'src/app/core/services/DocumentType.Service';
import { LandmarkService } from 'src/app/core/services/Landmark.Service';
import { PreferredOperationService } from 'src/app/core/services/PreferredOperation.Service';
import { WeekDayService } from 'src/app/core/services/WeekDay.Service';
import { OperationStatusService } from 'src/app/core/services/OperationStatus.Service';
import { ClientTypeService } from 'src/app/core/services/ClientType.Service';
import { LocationLevelService } from 'src/app/core/services/LocationLevel.Service';
import { UploaderService } from 'src/app/core/services/uploader.service';
import { OperationRejectReasonService } from 'src/app/core/services/OperationRejectReason.Service';
import { ClientModel } from 'src/app/core/Models/EntityModels/clientModel';
import { ClientLandmarkListModel } from 'src/app/core/Models/ListModels/ClientLandmarkListModel';
import { ClientPreferredTimeListModel } from 'src/app/core/Models/ListModels/ClientPreferredTimeListModel';
import { ClientDocumentListModel } from 'src/app/core/Models/ListModels/clientDocumentListModel';
import { ClientService } from 'src/app/core/services/Client.Service';
import { BranchService } from 'src/app/core/services/Branch.Service';
import { ClientGroupService } from 'src/app/core/services/ClientGroup.Service';
import { ClientGroupSubService } from 'src/app/core/services/ClientGroupSub.Service';
import { ClientClassificationService } from 'src/app/core/services/ClientClassification.Service';
import { PaymentTermService } from 'src/app/core/services/PaymentTerm.Service';
import { ManageBusinessUnitComponent } from '../manage-business-unit/manage-business-unit.component';
import { BusinessUnitModel } from 'src/app/core/Models/EntityModels/BusinessUnitModel';
import { BusinessUnitService } from 'src/app/core/services/BusinessUnit.Service';
import { AlertService } from 'src/app/core/services/Alert.Service';
import { ManageChannelMainComponent } from '../manage-channel-main/manage-channel-main.component';
import { ClientGroupModel } from 'src/app/core/Models/EntityModels/ClientGroupModel';
import { ManageClassificationComponent } from '../manage-classification/manage-classification.component';
import { ClientClassificationModel } from 'src/app/core/Models/EntityModels/ClientClassificationModel';
import { ManageClientTypeComponent } from '../manage-client-type/manage-client-type.component';
import { ClientTypeModel } from 'src/app/core/Models/EntityModels/ClientTypeModel';
import { ManageChannelSubComponent } from '../manage-channel-sub/manage-channel-sub.component';
import { ClientGroupSubModel } from 'src/app/core/Models/EntityModels/clientGroupSubModel';
import { ClientRouteListModel } from 'src/app/core/Models/ListModels/ClientRouteListModel';
import { ClientRouteService } from 'src/app/core/services/ClientRoute.Service';
import { ChooserRouteComponent } from 'src/app/Modules/shared/chooser-route/chooser-route.component';
import { RouteSetupListModel } from 'src/app/core/Models/ListModels/RouteSetupListModel';
import { ClientRouteModel } from 'src/app/core/Models/EntityModels/ClientRouteModel';
import { ManageRouteSetupComponent } from '../manage-route-setup/manage-route-setup.component';
import { PromtionCriteriaClientAttrCustomListModel } from 'src/app/core/Models/ListModels/PromtionCriteriaClientAttrCustomListModel';
import { PromtionCriteriaClientAttrCustomService } from 'src/app/core/services/promotion/PromtionCriteriaClientAttrCustom.Service';
import { ChooserClientAttributeComponent } from 'src/app/Modules/shared/chooser-client-attribute/chooser-client-attribute.component';
import { PromtionCriteriaClientAttrModel } from 'src/app/core/Models/EntityModels/PromtionCriteriaClientAttrModel';
import { PromtionCriteriaClientAttrCustomModel } from 'src/app/core/Models/EntityModels/PromtionCriteriaClientAttrCustomModel';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';
import { BranchModel } from '../../../../core/Models/EntityModels/branchModel';
import { FileModel } from '../../../../core/Models/DtoModels/FileModel';

declare var google: any;

@Component({
  selector: 'app-manage-client',
  templateUrl: './manage-client.component.html',
  styleUrls: ['./manage-client.component.scss']
})
export class ManageClientComponent implements OnInit {

  model = {} as ClientModel;

  MAP_VIEWER
  isLoading = false;

  Governerates: LookupModel[] = [];
  Cities: LookupModel[] = [];

  MainChannels: LookupModel[] = [];
  BusinessUnits: LookupModel[] = [];

  SubChannels: LookupModel[] = [];
  Classfications: LookupModel[] = [];
  PaymentTerms: LookupModel[] = [];

  ClientTypes: LookupModel[] = [];
  LocationLevels: LookupModel[] = [];
  DocumentTypes: LookupModel[] = [];

  Landmarks: LookupModel[] = [];
  PreferredOperations: LookupModel[] = [];
  WeekDays: LookupModel[] = [];


  ClientRoutes: ClientRouteListModel[] = [];
  selectedLandmark = {} as ClientLandmarkListModel;
  selectedClientRoute = {

    clientId: 0,
    clientRouteId: 0,
    day1: false,
    day2: false,
    day3: false,
    day4: false,
    day5: false,
    day6: false,
    day7: false,
    routeCode: "",
    routeId: 0,
    routeName: "",
    routeTypeCode: "",
    routeTypeId: 0,
    routeTypeName: ""

  } as ClientRouteListModel;

  clientAttributes: PromtionCriteriaClientAttrCustomListModel[] = [];
  selectedAttribute: PromtionCriteriaClientAttrCustomListModel = {
    clientCode: '',
    clientId: 0,
    clientName: '',
    clientCustomId: 0,
    clientAttributeId: 0,
    clientAttributeCode: '',
    clientAttributeName: '',
    isCustom: false
  }

  selectedPreferred = {
    preferredOperationId: 1,
  } as ClientPreferredTimeListModel;
  selectedDocument = {} as ClientDocumentListModel;

  showLandmarks = false;
  showPreferreds = false;
  showRoute = false;

  showDocuments = false;
  advanced = false;



  fromTime = new Date();
  toTime = new Date();

  CHOOSE = '';
  MANAGE = '';

  items: MenuItem[];
  selectedIndex = 1;
  options: any;
  overlays: any[];
  maker = { lat: 30.065774, lng: 31.338034 };

  constructor(
    private ref: DynamicDialogRef,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private _AppMessageService: AppMessageService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _ClientService: ClientService,
    private _BranchService: BranchService,
    private cdr: ChangeDetectorRef,
    private activatedRoute: ActivatedRoute,
    private config: DynamicDialogConfig,
    private _GovernerateService: GovernerateService,
    private _CityService: CityService,
    private _LandmarkService: LandmarkService,
    private _ClientRouteService: ClientRouteService,
    private _PreferredOperationService: PreferredOperationService,
    private _WeekDayService: WeekDayService,
    private _DocumentTypeService: DocumentTypeService,
    private _OperationStatusService: OperationStatusService,
    private _ClientTypeService: ClientTypeService,
    private _LocationLevelService: LocationLevelService,
    private uploaderService: UploaderService,
    private _ClientGroupService: ClientGroupService,
    private _ClientGroupSubService: ClientGroupSubService,
    private _ClientClassificationService: ClientClassificationService,
    private _PaymentTermService: PaymentTermService,
    private _BusinessUnitService: BusinessUnitService,
    private _AlertService: AlertService,

    private _OperationRejectReasonService: OperationRejectReasonService,
    private _PromtionCriteriaClientAttrCustomService: PromtionCriteriaClientAttrCustomService,
    private _commonCrudService : CommonCrudService,


  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Map Viewer').subscribe((res) => { this.MAP_VIEWER = res });
    this._translateService.get('Select').subscribe((res) => { this.CHOOSE = res });
    this._translateService.get('Manage').subscribe((res) => { this.MANAGE = res });


    this.model.isChain = false;
    this.model.isActive = true;
    this.model.isTaxable = true;
    this.model.clientId = 0
    this.model.documents = [];
    this.model.landmarks = [];
    this.model.preferredTimes = [];

    this.items = [
      {
        label: 'Basic Info',
        icon: 'fa fa-info-circle',
        command: (e) => this.manage(1)
      },
      {
        label: 'Custom Attribute',
        icon: 'fa fa-info-circle',
        command: (e) => this.manage(10)
      },
      {
        label: 'Contacts',
        icon: 'fa fa-phone-square',
        command: (e) => this.manage(2)
      },
      {
        label: 'Address',
        icon: 'fa fa-map-marker',
        command: (e) => this.manage(3)
      },
      {
        label: 'Landmarks',
        icon: 'fa fa-building',
        command: (e) => this.manage(4)
      },
      {
        label: 'Perffered Times',
        icon: 'fa fa-clock-o',
        command: (e) => this.manage(5)
      },
      {
        label: 'Route Setup',
        icon: 'fa fa-street-view',
        command: (e) => this.manage(8)
      },
      {
        label: 'Documents',
        icon: 'fa fa-picture-o',
        command: (e) => this.manage(9)
      },
    ];


    this.options = {
      center: this.maker,
      zoom: 5,
      mapId: '2df52e872b9212a',
      mapTypeControl: false,
      streetViewControl: false,
      keyboardShortcuts: false,
    };

    this.overlays = [
    ];



    if (this.config.data) {

      if (+this.config.data.clientId > 0) {
        this.model.clientId = +this.config.data.clientId
      }

    }

  }

  cssClass = 'p-button-warn';
  ngOnInit(): void {

    this._commonCrudService.get("Governerate/GetAll", LookupModel).then(res => {
      this.Governerates = res.data;

      if (this.Governerates.length > 0) {
        this._commonCrudService.get("City/GetByGovernerate?Id="+this.Governerates[0].id, LookupModel).then(res => {
          this.Cities = res.data;
          this.Cities.unshift({ id: 0, code: '0', name: '--' });
        })
      }

      this.Governerates.unshift({ id: 0, code: '0', name: '--' });
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

    this._commonCrudService.get("ClientType/GetAll", LookupModel).then(res => {
      this.ClientTypes = res.data;
      this.ClientTypes.unshift({ id: 0, code: '0', name: '--' });
    })

    this._commonCrudService.get("LocationLevel/GetAll", LookupModel).then(res => {
      this.LocationLevels = res.data;
      this.LocationLevels.unshift({ id: 0, code: '0', name: '--' });
    })


    this._commonCrudService.get("ClientGroup/GetAll", LookupModel).then(res => {
      this.MainChannels = res.data;
      this.MainChannels.unshift({ id: 0, code: '0', name: '--' });
    })

    this._commonCrudService.get("ClientClassification/GetAll", LookupModel).then(res => {
      this.Classfications = res.data;
      this.Classfications.unshift({ id: 0, code: '0', name: '--' });
    })

    this._commonCrudService.get("PaymentTerm/GetAll", LookupModel).then(res => {
      this.PaymentTerms = res.data;
      this.PaymentTerms.unshift({ id: 0, code: '0', name: '--' });
    })


    this.SubChannels.unshift({ id: 0, code: '0', name: '--' });

    if (this.model.clientId > 0) {
      this.fillForm()
    }
  }


  async fillForm() {
    this.isLoading = true;
    this._commonCrudService.get("Client/getById?Id="+this.model.clientId, ClientModel).then(async res => {
      if (res != null && res.succeeded == true && res.data.clientId > 0) {


        this.model = res.data;

        if (this.model.branchId > 0) {
          this._commonCrudService.get("Branch/GetByid?Id="+this.model.branchId, BranchModel).then(res => {
            this.model.branchCode = res.data.branchCode;
          })

          this._commonCrudService.get("BusinessUnit/getByBranch?Id="+this.model.branchId, LookupModel).then(res => {
            this.BusinessUnits = res.data;
            this.BusinessUnits.unshift({ id: 0, code: '0', name: '--' });
          })

        }

        if (this.model.clientGroupId > 0) {
          await this._commonCrudService.get("ClientGroupSub/GetByClientGroup?Id="+this.model.clientGroupId, LookupModel).then(res => {
            this.SubChannels = res.data;
            this.SubChannels.unshift({ id: 0, code: '0', name: '--' });
          })
        }

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
            this.Cities.unshift({ id: 0, code: '0', name: '--' });
          })
        }


        if(this.model.latitude>0 && this.model.longitude>0){
          this.overlays=[];
          this.overlays.push(new google.maps.Marker({ position: {lat:this.model.latitude,lng:this.model.longitude}, icon: "assets/images/marker_icon_online.png", title: "Client Location" }),);
          this.options.center.lat=this.model.latitude;
          this.options.center.lng=this.model.longitude;
    
        }


        this._commonCrudService.get("PromtionCriteriaClientAttrCustom/getByClient?Id="+this.model.clientId, PromtionCriteriaClientAttrCustomListModel).then(res=>{
          if(res.succeeded==true){
            this.clientAttributes=res.data;
          }
        })
        

        this.isLoading = false;

      }
      else {
        this.ref.close();
      }
    })

    // get client routes
    this._commonCrudService.get("ClientRoute/getById?Id="+this.model.clientId, ClientRouteListModel).then(res => {
      this.ClientRoutes = res.data;
    })



  }

  async manage(index) {
    this.selectedIndex = index;
  }



  async onGovernerateChange(e) {

    this.Cities = [];
    this.isLoading = true;

    this._commonCrudService.get("City/GetByGovernerate?Id="+e.value, LookupModel).then(res => {
      this.Cities = res.data;
      this.isLoading = false;
      this.Cities.unshift({ id: 0, code: '0', name: '--' });
    })
  }
  async onChannelChange(e) {
    this.SubChannels = [];
    this.isLoading = true;

    this._commonCrudService.get("ClientGroupSub/GetByClientGroup?Id="+e.value, LookupModel).then(res => {
      this.SubChannels = res.data;
      this.isLoading = false;
      this.SubChannels.unshift({ id: 0, code: '0', name: '--' });

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
              clientId: this.model.clientId,
              detaillandId: 0,
              landmarkId: 0
            } as ClientLandmarkListModel;
          }
        }
      }
    }
    if (operation == 'save') {
      let lm = {} as ClientLandmarkListModel;
      console.log(this.selectedLandmark);

      if (this.selectedLandmark) {
        if (this.selectedLandmark.landmarkId) {
          lm.detaillandId = -1 * Math.floor(Math.random() * (11111111 - 99999999 + 1));
          lm.landmarkId = this.selectedLandmark.landmarkId;
          lm.clientId = this.model.clientId;
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
              clientId: this.model.clientId,
              preferredId: 0,
              preferredOperationId: 1,
              weekDayId: 1
            } as ClientPreferredTimeListModel;
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

      let time = {} as ClientPreferredTimeListModel;

      time.clientId = this.model.clientId;
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
      } as ClientPreferredTimeListModel;
      this.fromTime = new Date();
      this.toTime = new Date();

      this.showPreferreds = false;


    }
  }

  manageRoute(operation) {
    if (operation == 'add') {
      this.showRoute = true;
    }
    if (operation == 'reload') {
      this.isLoading = true;
      this.selectedClientRoute = {
        clientId: 0,
        clientRouteId: 0,
        day1: false,
        day2: false,
        day3: false,
        day4: false,
        day5: false,
        day6: false,
        day7: false,
        routeCode: "",
        routeId: 0,
        routeName: "",
        routeTypeCode: "",
        routeTypeId: 0,
        routeTypeName: ""
      } as ClientRouteListModel;

      this._commonCrudService.get("ClientRoute/getById?Id="+this.model.clientId, ClientRouteListModel).then(res => {
        this.ClientRoutes = res.data;
      })

      this.isLoading = false;
    }
    if (operation == 'delete') {
      if (this.selectedClientRoute) {
        if (this.selectedClientRoute.clientRouteId) {

          let route = {} as ClientRouteModel;

          route.clientRouteId = this.selectedClientRoute.clientRouteId;
          this.isLoading = true;
          this._commonCrudService.post("ClientRoute/Delete", route, ClientRouteModel).then(async res => {
            if (res.succeeded == true) {
              this.selectedClientRoute = {
                clientId: 0,
                clientRouteId: 0,
                day1: false,
                day2: false,
                day3: false,
                day4: false,
                day5: false,
                day6: false,
                day7: false,
                routeCode: "",
                routeId: 0,
                routeName: "",
                routeTypeCode: "",
                routeTypeId: 0,
                routeTypeName: ""
              } as ClientRouteListModel;
              this._AlertService.Show('success', this._AppMessageService.MESSAGE_OK)
            }
            else {
              this._AlertService.Show('error', this._AppMessageService.MESSAGE_ERROR)
            }

            await this._commonCrudService.get("ClientRoute/getById?Id="+this.model.clientId, ClientRouteListModel).then(res => {
              this.ClientRoutes = res.data;
            })

            this.isLoading = false;


          })


        }
      }
    }
    if (operation == 'save') {

      if (this.selectedClientRoute == null) {
        return;
      }

      if (this.selectedClientRoute.routeId == null || this.selectedClientRoute.routeId == 0) {
        return;
      }



      let route = {} as ClientRouteModel;

      route.clientRouteId = this.selectedClientRoute.clientRouteId;
      route.clientId = this.model.clientId;
      route.routeId = this.selectedClientRoute.routeId;
      route.routeTypeId = this.selectedClientRoute.routeTypeId;

      route.day1 = this.selectedClientRoute.day1;
      route.day2 = this.selectedClientRoute.day2;
      route.day3 = this.selectedClientRoute.day3;
      route.day4 = this.selectedClientRoute.day4;
      route.day5 = this.selectedClientRoute.day5;
      route.day6 = this.selectedClientRoute.day6;
      route.day7 = this.selectedClientRoute.day7;

      this.isLoading = true;
      this._commonCrudService.post("ClientRoute/Save", route, FileModel).then(async res => {

        if (res.succeeded == true) {


          if (res.succeeded == true) {
            this.selectedClientRoute = {
              clientId: 0,
              clientRouteId: 0,
              day1: false,
              day2: false,
              day3: false,
              day4: false,
              day5: false,
              day6: false,
              day7: false,
              routeCode: "",
              routeId: 0,
              routeName: "",
              routeTypeCode: "",
              routeTypeId: 0,
              routeTypeName: ""
            } as ClientRouteListModel;
            this._AlertService.Show('success', this._AppMessageService.MESSAGE_OK)
          }
          else {
            this._AlertService.Show('error', this._AppMessageService.MESSAGE_ERROR)
          }


          await this._commonCrudService.get("ClientRoute/getById?Id="+this.model.clientId, ClientRouteListModel).then(res => {
            this.ClientRoutes = res.data;
          })

          this.showRoute = false;

          this.isLoading = false;

        }
        this.isLoading = false;
      })


    }
  }
  manageDocument(operation) {
    if (operation == 'add') {
      this.showDocuments = true;
    }
    if (operation == 'delete') {
      if (this.selectedDocument) {
        if (this.selectedDocument.clientDocumentId) {

          let found = this.model.documents.find(a => a.clientDocumentId == this.selectedDocument.clientDocumentId);
          if (found) {
            this.model.documents = this.model.documents.filter(function (row, index, arr) {
              return row.clientDocumentId != found.clientDocumentId;
            });
            this.selectedDocument = {
              clientId: this.model.clientId,
              clientDocumentId: 0,
              documentTypeId: 1,

            } as ClientDocumentListModel;
          }
        }
      }
    }

  }

  manageAttribute(operation){
    if (operation == 'add') {
      // show attribute

      var ref = this.dialogService.open(ChooserClientAttributeComponent, {
        header: this.CHOOSE,
        width: '500px',
        contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe((res: PromtionCriteriaClientAttrModel) => {
        if (res) {
          // add attribute
          let model={
            valueFrom:this.model.clientCode,
            clientAttributeId:res.clientAttributeId,
            isActive:true,
            clientCustomId:0,
          } as PromtionCriteriaClientAttrCustomModel;
          this.isLoading=true;
          this._commonCrudService.post("PromtionCriteriaClientAttrCustom/Save", model, PromtionCriteriaClientAttrCustomModel).then(ressave=>{
            if(ressave.succeeded==true){
              this._commonCrudService.get("PromtionCriteriaClientAttrCustom/getByClient?Id="+this.model.clientId, PromtionCriteriaClientAttrCustomListModel).then(res=>{
                if(res.succeeded==true){
                  this.clientAttributes=res.data;
                }
                this.isLoading=false;
              })
            }
            else
            {
              this.isLoading=false;

            }
           
          })
        }
      });
    }
    if (operation == 'delete') {
      if (this.selectedAttribute) {
        if (this.selectedAttribute.clientCustomId) {
          // add attribute
          let model={
            clientCustomId:this.selectedAttribute.clientCustomId,
          } as PromtionCriteriaClientAttrCustomModel;
          this.isLoading=true;
          this._commonCrudService.post("PromtionCriteriaClientAttrCustom/Delete",model, PromtionCriteriaClientAttrCustomModel).then(ressave=>{
            if(ressave.succeeded==true){
              this._commonCrudService.get("PromtionCriteriaClientAttrCustom/getByClient?Id="+this.model.clientId, PromtionCriteriaClientAttrCustomListModel).then(res=>{
                if(res.succeeded==true){
                  this.clientAttributes=res.data;
                }
                this.isLoading=false;
              })
            }
            else
            {
              this.isLoading=false;
            }
           
          })
        }
      }
    }
    if (operation == 'reload') {
     
      this.isLoading=true;
      this._commonCrudService.get("PromtionCriteriaClientAttrCustom/getByClient?Id="+this.model.clientId, PromtionCriteriaClientAttrCustomListModel).then(res=>{
        if(res.succeeded==true){
          this.clientAttributes=res.data;
        }
        this.selectedAttribute={
          clientCode: '',
          clientId: 0,
          clientName: '',
          clientCustomId: 0,
          clientAttributeId: 0,
          clientAttributeCode: '',
          clientAttributeName: '',
          isCustom: false
        };
        this.isLoading=false;
      })
    }
  }

  myUploader(event, form) {

    this.isLoading = true;
    let document = {} as ClientDocumentListModel;

    document.documentPath = '';

    event.files.forEach(file => {
      this.uploaderService.Upload(file).then(res => {
        if (res.succeeded == true) {


          let found = this.model.documents.find(a => a.clientDocumentId == this.selectedDocument.clientDocumentId);

          if (!found) {

            document.clientDocumentId = -1 * Math.floor(Math.random() * (11111111 - 99999999 + 1));
            document.documentPath = res.data.fileUrl;
            document.documentTypeId = this.selectedDocument.documentTypeId;
            document.documentTypeName = this.DocumentTypes.find(a => a.id === document.documentTypeId).name;

            this.showDocuments = false;


            this.model.documents.push(document);

            // add document to server



          }

        }
        this.isLoading = false;
      })
    });

    form.clear();

  }





  SaveBasic() {
    this.isLoading = true;
    this._commonCrudService.post("Client/SaveBasic",this.model,ClientModel).then(res => {
      if (res.succeeded == true) {
        this._AlertService.Show('success', this._AppMessageService.MESSAGE_OK)
      }
      else {
        this._AlertService.Show('error', this._AppMessageService.MESSAGE_ERROR)
      }
      this.isLoading = false;
    });
  }
  SaveContacts() {
    this.isLoading = true;
    this._commonCrudService.post("Client/SaveContacts",this.model,ClientModel).then(res => {

      if (res.succeeded == true) {
        this._AlertService.Show('success', this._AppMessageService.MESSAGE_OK)
      }
      else {
        this._AlertService.Show('error', this._AppMessageService.MESSAGE_ERROR)
      }
      this.isLoading = false;
    });
  }

  SaveAddress() {
    if(this.model.locationLevelId==0 || this.model.locationLevelId==null || this.model.locationLevelId==undefined){
      this._AlertService.Show('error', this._AppMessageService.MESSAGE_INVALID)
      return;
    }
    this.isLoading = true;
    this._commonCrudService.post("Client/SaveAddress",this.model,ClientModel).then(res => {

      if (res.succeeded == true) {
        this._AlertService.Show('success', this._AppMessageService.MESSAGE_OK)
      }
      else {
        this._AlertService.Show('error', this._AppMessageService.MESSAGE_ERROR)
      }
      this.isLoading = false;
    });
  }

  SaveLandMarks() {
    
    this.isLoading = true;
    this._commonCrudService.post("Client/SaveLandMarks",this.model,ClientModel).then(res => {

      if (res.succeeded == true) {
        this._AlertService.Show('success', this._AppMessageService.MESSAGE_OK)
      }
      else {
        this._AlertService.Show('error', this._AppMessageService.MESSAGE_ERROR)
      }
      this.isLoading = false;
    });
  }
  SavePrefferds() {
    
    this.isLoading = true;
    this._commonCrudService.post("Client/SavePrefferds",this.model,ClientModel).then(res => {

      if (res.succeeded == true) {
        this._AlertService.Show('success', this._AppMessageService.MESSAGE_OK)
      }
      else {
        this._AlertService.Show('error', this._AppMessageService.MESSAGE_ERROR)
      }
      this.isLoading = false;
    });
  }
  SaveDocuments() {
    
    this.isLoading = true;
    this._commonCrudService.post("Client/SaveDocuments",this.model,ClientModel).then(res => {

      if (res.succeeded == true) {
        this._AlertService.Show('success', this._AppMessageService.MESSAGE_OK)
      }
      else {
        this._AlertService.Show('error', this._AppMessageService.MESSAGE_ERROR)
      }
      this.isLoading = false;
    });
  }

  manageLookups(type, Arg) {

    if (type == "BusinessUnits") {

      if (this.model.branchId > 0) {

        var ref = this.dialogService.open(ManageBusinessUnitComponent, {
          header: this.MANAGE,
          data: { businessUnitId: Arg, branchId: this.model.branchId },
          width: '600px',
          contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
          baseZIndex: 10000
        });

        ref.onClose.subscribe((res: BusinessUnitModel) => {
          this._commonCrudService.get("BusinessUnit/getByBranch?Id="+this.model.branchId, LookupModel).then(res => {
            this.BusinessUnits = res.data;
            this.BusinessUnits.unshift({ id: 0, code: '0', name: '--' });
          })
        });

      }
      else {
        this._AlertService.Show('error', this._AppMessageService.MESSAGE_INVALID)

      }

    }

    if (type == "SubChannels") {

      if (this.model.clientGroupId > 0) {

        var ref = this.dialogService.open(ManageChannelSubComponent, {
          header: this.MANAGE,
          data: { clientGroupSubId: Arg, clientGroupId: this.model.clientGroupId },
          width: '600px',
          contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
          baseZIndex: 10000
        });

        ref.onClose.subscribe((res: ClientGroupSubModel) => {
          this._commonCrudService.get("ClientGroupSub/GetByClientGroup?Id="+this.model.clientGroupId, LookupModel).then(res => {
            this.SubChannels = res.data;
            this.SubChannels.unshift({ id: 0, code: '0', name: '--' });
          })
        });

      }
      else {
        this._AlertService.Show('error', this._AppMessageService.MESSAGE_INVALID)

      }

    }

    if (type == "ClientGroups") {
      var ref = this.dialogService.open(ManageChannelMainComponent, {
        header: this.MANAGE,
        data: { clientGroupId: Arg },
        width: '600px',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });

      ref.onClose.subscribe((res: ClientGroupModel) => {
        this._commonCrudService.get("ClientGroup/GetAll", LookupModel).then(res => {
          this.MainChannels = res.data;
          this.MainChannels.unshift({ id: 0, code: '0', name: '--' });
        })
      });

    }
    if (type == "Classfications") {
      var ref = this.dialogService.open(ManageClassificationComponent, {
        header: this.MANAGE,
        data: { clientClassificationId: Arg },
        width: '600px',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });

      ref.onClose.subscribe((res: ClientClassificationModel) => {
        this._commonCrudService.get("ClientClassification/GetAll", LookupModel).then(res => {
          this.Classfications = res.data;
          this.Classfications.unshift({ id: 0, code: '0', name: '--' });
        })
      });

    }

    if (type == "ClientTypes") {
      var ref = this.dialogService.open(ManageClientTypeComponent, {
        header: this.MANAGE,
        data: { clientTypeId: Arg },
        width: '600px',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });

      ref.onClose.subscribe((res: ClientTypeModel) => {
        this._commonCrudService.get("ClientType/GetAll", LookupModel).then(res => {
          this.ClientTypes = res.data;
          this.ClientTypes.unshift({ id: 0, code: '0', name: '--' });
        })
      });

    }
  }

  Chooser_Route() {
    var ref = this.dialogService.open(ChooserRouteComponent, {
      header: this.CHOOSE,
      width: '1000px',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((res: RouteSetupListModel) => {
      if (res) {
        this.selectedClientRoute.routeCode = res.routeCode;
        this.selectedClientRoute.routeTypeId = res.routeTypeId;
        this.selectedClientRoute.routeId = res.routeId;
      }
    });
  }

  add_Route() {
    var ref = this.dialogService.open(ManageRouteSetupComponent, {
      header: this.MANAGE,
      data: { routeId: this.selectedClientRoute.routeId },
      width: '400px',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
  }
  async drawMarker(event){
    console.log(this.model.latitude +' '+ this.model.longitude);
    this.isLoading=true;
    if(this.model.latitude>0 && this.model.longitude>0){
      this.overlays=[];
      this.overlays.push(new google.maps.Marker({ position: {lat:this.model.latitude,lng:this.model.longitude}, icon: "assets/images/marker_icon_online.png", title: "Client Location" }),);
      this.options.center.lat=this.model.latitude;
      this.options.center.lng=this.model.longitude;

    }
    else
    {
      this.overlays=[];
      this.options.center.lat=undefined;
      this.options.center.lng=undefined;  
    }
    this.isLoading=false;

    this.cdr.detectChanges();
  }


}
