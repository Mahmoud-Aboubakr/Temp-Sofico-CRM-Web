import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig } from 'primeng/dynamicdialog';
import { BranchModel } from 'src/app/core/Models/EntityModels/branchModel';
import { RepresentativeModel } from 'src/app/core/Models/EntityModels/representativeModel';
import { SupervisorModel } from 'src/app/core/Models/EntityModels/supervisorModel';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { SupervisorListModel } from 'src/app/core/Models/ListModels/SupervisorListModel';
import { GPSTrackingSearchModel } from 'src/app/core/Models/SearchModels/GPSTrackingSearchModel';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { FormatterService } from 'src/app/core/services/Formatter.service';
import { SalesControlService } from 'src/app/core/services/SalesControl.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { ChooserBranchComponent } from '../../shared/chooser-branch/chooser-branch.component';
import { ChooserRepresentativeComponent } from '../../shared/chooser-representative/chooser-representative.component';
import { ChooserSupervisorComponent } from '../../shared/chooser-supervisor/chooser-supervisor.component';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { TrackingService } from 'src/app/core/services/Tracking.Service';
import { TrakingRepresentativeModel } from 'src/app/core/Models/DtoModels/TrakingRepresentativeModel';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { SalesControlRepresentativeComponent } from '../sales-control-representative/sales-control-representative.component';
import { SalesControlSearchModel } from 'src/app/core/Models/SearchModels/SalesControlSearchModel';
import { ClientModel } from 'src/app/core/Models/EntityModels/clientModel';
import { TrackingGpsDetailComponent } from '../components/tracking-gps-detail/tracking-gps-detail.component';
import { SalesControlClientComponent } from '../sales-control-client/sales-control-client.component';
import { MenuService } from 'src/app/core/services/Menu.Service';
import { RepresentativeKindModel } from 'src/app/core/Models/EntityModels/representativeKindModel';
import { RepresentativeKindService } from 'src/app/core/services/RepresentativeKind.Service';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { KBISummeryModel } from 'src/app/core/Models/StatisticalModels/SummeryDetailModel';
import { TrakingRepresentativeDetailModel } from 'src/app/core/Models/ListModels/TrakingRepresentativeDetailModel';
import { ManageSalesOrderComponent } from '../components/manage-sales-order/manage-sales-order.component';
import { async } from 'rxjs/internal/scheduler/async';




declare var google: any;

@Component({
  selector: 'app-tracking-gps',
  templateUrl: './tracking-gps.component.html',
  styleUrls: ['./tracking-gps.component.scss']
})
export class TrackingGpsComponent implements OnInit {

  HEADER_MANAGE = '';
  summeryWidth = '350';
  expanded = false;
  expandIcon = 'fa fa-arrow-right';

  kinds: LookupModel[] = [];
  representativeId = 0;
  timePeriodSelected = 1;

  trackingDetails: ResponseModel<TrakingRepresentativeDetailModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }

  model: ResponseModel<TrakingRepresentativeModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: null
  };

  summeryModel: KBISummeryModel = {
    performanceValue: 0,
    performanceLabel: '',
    salesTotal: 0,
    salesTarget: 0,
    salesP: 0,
    visitTotal: 0,
    visitTarget: 0,
    visitP: 0,
    callTotal: 0,
    callTarget: 0,
    callP: 0,
    orders: 0,
    clients: 0,
    clientsTarget: 0,
    representativeId: 0,
    representativeCode: '',
    representativeName: '',
    phone: '',
    lastTrackDate: null,
    idealFor: 0,
    clientsP: 0,
    days: 0,
    daysTarget: 0,
    daysP: 0,
    firstOrder: undefined,
    lastOrder: undefined,

  };
  timePeriods = [
    { id: 1, name: "TDY" },
    { id: 2, name: "WTD" },
    { id: 3, name: "MTD" },
    { id: 4, name: "QTD" },
    { id: 5, name: "YTD" },
  ];



  isPlaying = false;
  isPaused = false;



  gridData: TrakingRepresentativeModel[] = [];
  selected: TrakingRepresentativeModel;

  searchModel: GPSTrackingSearchModel = {
    branchId: 0,
    branchCode: '',
    statusId: 0,
    supervisorId: 0,
    representativeKindId: 1,
    supervisorCode: '',
    representativeId: 0,
    representativeCode: '',
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    TermBy: ""

  };

  isLoading = true;
  advanced = false;
  details = false;
  summery = false;
  summeryLoading = false;
  summeryDetailLoading = false;

  CHOOSE_BRANCH = '';
  CHOOSE_SUPERVISOR = '';
  CHOOSE_REPRESENTITIVE = '';
  SHOW_REPRESENTITIVE = '';

  pop = false;

  menuItems: MenuItem[];

  options: any;

  overlays: any[];

  public innerWidth: any;
  public innerHeight: any;

  online = 0;
  offline = 0;


  millisecondsToWait = 1000;

  optionsDetail: any;
  overlaysDetail: any[];

  optionsDetailTemp: any;
  overlaysDetailTemp: any[];

  walking: { lat: 0, lng: 0 };

  trackModel = {
    representativeId: 0,
    trackingDate: new Date(),
    Skip: 0,
    Take: 2000,
    SortBy: { Order: "", Property: "" }
  };
  constructor(
    private _FormatterService: FormatterService,
    private _TrackingService: TrackingService,
    private _translationLoaderService: TranslationLoaderService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _AppMessageService: AppMessageService,
    private config: DynamicDialogConfig,
    private _MenuService: MenuService,
    private _RepresentativeKindService: RepresentativeKindService,

  ) {


    this.optionsDetail = {
      center: { lat: 30.065774, lng: 31.338034 },
      zoom: 13,
      mapId: '2df52e872b9212a'
    };

    this.overlaysDetail = [

    ];
    this._translationLoaderService.loadTranslations(english, arabic);



    if (this.config.data) {
      if (this.config.data.searchModel) {
        this.searchModel = this.config.data.searchModel;
      }
      if (this.config.data.pop) {
        this.pop = true;
      }
    }



  }

  ngOnInit(): void {

    this.innerWidth = window.innerWidth;
    this.innerHeight = window.innerHeight;
    this._translateService.get('Choose Branch').subscribe((res) => { this.CHOOSE_BRANCH = res });
    this._translateService.get('Choose Supervisor').subscribe((res) => { this.CHOOSE_SUPERVISOR = res });
    this._translateService.get('Choose Sales Man').subscribe((res) => { this.CHOOSE_REPRESENTITIVE = res });
    this._translateService.get('Representative Detail').subscribe((res) => { this.SHOW_REPRESENTITIVE = res });
    this._translateService.get('Order Details').subscribe((res) => { this.HEADER_MANAGE = res });


    this.options = {
      center: { lat: 30.065774, lng: 31.338034 },
      zoom: 12,
      mapId: '2df52e872b9212a'
    };

    this.overlays = [
      //new google.maps.Marker({ position: { lat: 36.879466, lng: 30.667648 }, title: "Konyaalti",icon:'assets/images/marker_icon.png',data:'55' }),
    ];

    this.reload();

    this._RepresentativeKindService.GetAll().then(res => {
      this.kinds = res.data;
    })

    setInterval(() => {
      this.reload()
    }, 1000 * 60)

  }

  handleMapClick(event) {
    //event: MouseEvent of Google Maps api
    this.summery = false;
    this.representativeId = 0;
  }

  handleOverlayClick(event) {
    //event.originalEvent: MouseEvent of Google Maps api
    //event.overlay: Clicked overlay
    //event.map: Map instance
    this.summery = true;
    this.summeryLoading = true;
    this.expanded = false;
    this.expandIcon = 'fa fa-arrow-right';
    this.summeryWidth = "350";

    console.log(event.overlay);
    //this.showRepLocator(+event.overlay.data);
    this.representativeId = +event.overlay.data;
    this._TrackingService.getSummery(+event.overlay.data, this.timePeriodSelected).then(res => {
      this.summeryModel = res.data
      this.summeryLoading = false;
    });
  }

  reload() {

    this._TrackingService.getRepresentative(this.searchModel).then(res => {



      if (res.succeeded == true) {
        this.model = res;

        this.overlays = [];
        this.options.center.lat = 30.065774;
        this.options.center.lng = 31.338034;

        this.online = 0;
        this.offline = 0;

        this.model.data.filter(a => a.isOnline == true).reduce((a, b) => this.online++, 0);
        this.model.data.filter(a => a.isOnline != true).reduce((a, b) => this.offline++, 0);


        res.data.forEach(element => {
          if (element.latitude > 0 && element.longitude > 0) {
            this.overlays.push(new google.maps.Marker({ position: { lat: element.latitude, lng: element.longitude }, title: element.representativeName, icon: element.isOnline == true ? 'assets/images/marker_icon_online.png' : 'assets/images/marker_icon_offline.png', data: element.representativeId }))
            this.options.center.lat = element.latitude;
            this.options.center.lng = element.longitude;
          }
        });

        var center = res.data.filter(a => a.latitude > 0);

        if (center && center.length > 0) {
          this.options.center.lat = center[0].latitude;
          this.options.center.lng = center[0].longitude;
        }


      }



      this.isLoading = false;
    })
  }

  async clearFilter() {

    await this.reload();

  }
  async advancedFilter() {
    await this.reload();
  }

  choose_Branch() {
    var ref = this.dialogService.open(ChooserBranchComponent, {
      header: this.CHOOSE_BRANCH,
      width: '600px',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((branch: BranchListModel) => {
      if (branch) {
        this.searchModel.branchCode = branch.branchCode;
        this.searchModel.branchId = branch.branchId;

        this.searchModel.supervisorCode = '';
        this.searchModel.supervisorId = 0;

        this.searchModel.representativeCode = '';
        this.searchModel.representativeId = 0;

      }
    });
  }
  clear_Branch() {
    this.searchModel.branchCode = '';
    this.searchModel.branchId = 0;
  }

  choose_Supervisor() {
    var ref = this.dialogService.open(ChooserSupervisorComponent, {
      header: this.CHOOSE_SUPERVISOR,
      width: '1200px',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((supervisor: SupervisorListModel) => {
      if (supervisor) {

        this.searchModel.supervisorCode = supervisor.supervisorCode;
        this.searchModel.supervisorId = supervisor.supervisorId;

        this.searchModel.representativeCode = '';
        this.searchModel.representativeId = 0;

      }
    });
  }

  clear_Supervisor() {
    this.searchModel.supervisorCode = '';
    this.searchModel.supervisorId = 0;
  }

  choose_Representative() {
    var ref = this.dialogService.open(ChooserRepresentativeComponent, {
      header: this.CHOOSE_SUPERVISOR,
      width: '1200px',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((represeentitive: RepresentativeListModel) => {
      if (represeentitive) {



        this.searchModel.representativeCode = represeentitive.representativeCode;
        this.searchModel.representativeId = represeentitive.representativeId;

      }
    });
  }

  clear_Representative() {
    this.searchModel.representativeCode = '';
    this.searchModel.representativeId = 0;
  }


  showDetails(mode) {
    if (mode == 1) {
      this.gridData = this.model.data;

    }
    if (mode == 2) {
      this.gridData = this.model.data.filter(a => a.isOnline == true);

    }
    if (mode == 3) {
      this.gridData = this.model.data.filter(a => a.isOnline == false || a.latitude == null);

    }

    this.details = !this.details;
  }

  async showRepSTC(representativeId) {

    let search: SalesControlSearchModel = {
      Take: 30,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: undefined,
      branchId: 0,
      supervisorId: 0,
      representativeId: 0,
      fromDate: undefined,
      toDate: undefined,
      branchCode: undefined,
      supervisorCode: undefined,
      representativeCode: undefined,
      clientId: 0,
      clientCode: undefined,
      TermBy: ""

    };



    search.branchId = 0;
    search.branchCode = '';

    search.supervisorId = 0;
    search.supervisorCode = '';

    search.representativeId = representativeId;
    search.representativeCode = '';

    search.clientId = 0;
    search.clientCode = '';

    search.fromDate = new Date(new Date().getFullYear(), new Date().getMonth(), 1, new Date().getHours(), new Date().getMinutes(), new Date().getSeconds());
    search.toDate = new Date();

    var ref = this.dialogService.open(SalesControlClientComponent, {
      data: {
        searchModel: search,
        pop: true,
      },
      header: this.SHOW_REPRESENTITIVE,
      width: '90%',
      modal: true,
      height: "90%"
    });

  }
  async showRepLocator(representativeId) {

    var ref = this.dialogService.open(TrackingGpsDetailComponent, {
      data: {
        representativeId: representativeId
      },
      header: this.SHOW_REPRESENTITIVE,
      width: '90%',
      modal: true,
      height: "90%"
    });
  }
  getFormated(number) {
    if (number == undefined || number == null)
      return 0;
    return this._FormatterService.kFormatter(number);
  }

  getCommaFormated(number) {
    if (number == undefined || number == null)
      return 0;
    return this._FormatterService.CommaFormatter(number);
  }

  showSummeryDetails() {


    if (this.expanded == true) {
      this.expandIcon = 'fa fa-arrow-right';
      this.summeryWidth = "350";
      this.expanded = false;
    }
    else {
      this.expandIcon = 'fa fa-arrow-left';
      this.summeryWidth = "1400";

      this.expanded = true;
      this.trackingDetails.data = [];
      this.summeryDetailLoading = true;
      this.trackModel.representativeId = this.representativeId;

      this.buildMap();
    }
  }



  getCenterPoint(geoPoints: Array<{ latitude: number, longitude: number }>): { latitude: number, longitude: number } {
    let latitudeSum = 0;
    let longitudeSum = 0;

    for (const point of geoPoints) {
      latitudeSum += point.latitude;
      longitudeSum += point.longitude;
    }

    const latitudeAverage = latitudeSum / geoPoints.length;
    const longitudeAverage = longitudeSum / geoPoints.length;

    return {
      latitude: latitudeAverage,
      longitude: longitudeAverage
    };
  }

  showInvoice(salesId) {
    var ref = this.dialogService.open(ManageSalesOrderComponent, {
      header: this.HEADER_MANAGE,
      data: {
        salesId: salesId,
        mode: 'v',
      },
      width: '95%',
      height: '95vh',
    });
  }
  onDateChange(arg) {

    console.log(arg);
    this.trackingDetails.data = [];
    this.summeryDetailLoading = true;
    this.trackModel.trackingDate = new Date(arg);
    this.buildMap();

  }

  buildMap() {
    this.summeryDetailLoading = true;
    this._TrackingService.getDetails(this.trackModel).then(res => {
      this.trackingDetails = res;
      this.summeryDetailLoading = false;

      if (res.succeeded == true) {


        this.overlaysDetail = [];
        this.optionsDetail.center.lat = 30.065774;
        this.optionsDetail.center.lng = 31.338034;


        let mapPath = [];

        res.data.forEach(element => {
          if (element.latitude > 0 && element.longitude > 0) {

            mapPath.push({ lat: element.latitude, lng: element.longitude })

            if (element.isPositive == true) {
              this.overlaysDetail.push(new google.maps.Marker({ position: { lat: element.latitude, lng: element.longitude }, title: element.clientName, icon: 'assets/images/marker_icon_online.png', data: element.salesId }))
            }
            else {
              this.overlaysDetail.push(new google.maps.Marker({ position: { lat: element.latitude, lng: element.longitude }, title: element.clientName, icon: 'assets/images/dot.png', data: element.salesId }))

            }

          }
        });




        let center = res.data.filter(a => a.latitude > 0);
        var cn = this.getCenterPoint(center);
        this.optionsDetail.center.lat = cn.latitude;
        this.optionsDetail.center.lng = cn.longitude;


        this.overlaysDetail.push(




          new google.maps.Polyline({
            path: mapPath, geodesic: true, strokeColor: '#FFC107', strokeOpacity: 0.9, strokeWeight: 5
          })

        );






        this.overlaysDetail.push(new google.maps.Marker({ position: { lat: center[0].latitude, lng: center[0].longitude }, title: "Start Journey", icon: 'assets/images/marker_icon_walking_start.png', data: 'w' }))
        this.overlaysDetail.push(new google.maps.Marker({ position: { lat: center[center.length - 1].latitude, lng: center[center.length - 1].longitude }, title: "End Journey", icon: 'assets/images/marker_icon_walking_end.png', data: 'w' }))


      }

    })
  }
  onTimeChange(arg) {
    this.summeryLoading = true;
    this.timePeriodSelected = arg.option.id;
    this._TrackingService.getSummery(this.representativeId, this.timePeriodSelected).then(res => {
      this.summeryModel = res.data
      this.summeryLoading = false;
    });
  }
  player(mode) {
    //play
    if (mode == 1) {
      this.isPlaying = true;
      this.isPaused=false;
      let index = 0;
      this.optionsDetailTemp=this.optionsDetail;
      this.overlaysDetailTemp=this.overlaysDetail;

      let mapPath: any[] = [];
      this.overlaysDetail = [];

      setInterval( () => {
        mapPath = this.drawLine(index, mapPath);
        index++;
      }, this.millisecondsToWait, true)
    }
    //pause
    if (mode == 2) {
      this.isPaused = !this.isPaused ;
    }
    //stop
    if (mode == 3) {
      this.isPlaying = !this.isPlaying;
      this.isPaused=false;

      this.optionsDetail=this.optionsDetailTemp;
      this.overlaysDetail=this.overlaysDetailTemp;
      
    }

    if (mode == 4) {
      this.millisecondsToWait = 1000;
    }
    if (mode == 5) {
      this.millisecondsToWait = 700;
    }
    if (mode == 5) {
      this.millisecondsToWait = 500;
    }
  }

   drawLine(index, mapPath) {

    this.summeryDetailLoading=true;

    if(this.isPaused==false){

    
    if (this.trackingDetails.data.length > 0) {
      if (index < this.trackingDetails.data.length) {
        let element = this.trackingDetails.data[index];


        // draw markers
        if (element.isPositive == true) {
          this.overlaysDetail.push(new google.maps.Marker({ position: { lat: element.latitude, lng: element.longitude }, title: element.clientName, icon: 'assets/images/marker_icon_online.png', data: element.salesId }))
        }
        else {
          this.overlaysDetail.push(new google.maps.Marker({ position: { lat: element.latitude, lng: element.longitude }, title: element.clientName, icon: 'assets/images/dot.png', data: element.salesId }))

        }

        // draw center
        this.optionsDetail.center.lat = element.latitude;
        this.optionsDetail.center.lng = element.longitude;


        // draw plyline
        mapPath.push({ lat: element.latitude, lng: element.longitude })
        this.overlaysDetail.push(
          new google.maps.Polyline({
            path: mapPath, geodesic: true, strokeColor: '#FFC107', strokeOpacity: 0.9, strokeWeight: 5
          })

        );

        // draw start end
        if (index == 0)
          this.overlaysDetail.push(new google.maps.Marker({ position: { lat: element.latitude, lng: element.longitude }, title: "Start Journey", icon: 'assets/images/marker_icon_walking_start.png', data: 'w' }))
        if (index == this.trackingDetails.data.length - 1) {
          this.overlaysDetail.push(new google.maps.Marker({ position: { lat: element.latitude, lng: element.longitude }, title: "End Journey", icon: 'assets/images/marker_icon_walking_end.png', data: 'w' }))

        }




      }
    }
  }

    this.summeryDetailLoading=false;



    return mapPath;
  }


}
