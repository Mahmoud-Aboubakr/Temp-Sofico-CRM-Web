import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig } from 'primeng/dynamicdialog';
import { BranchModel } from 'src/app/core/Models/EntityModels/branchModel';
import { RepresentativeModel } from 'src/app/core/Models/EntityModels/representativeModel';
import { SupervisorModel } from 'src/app/core/Models/EntityModels/supervisorModel';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { FormatterService } from 'src/app/core/services/Formatter.service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TrackingService } from 'src/app/core/services/Tracking.Service';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { SalesControlSearchModel } from 'src/app/core/Models/SearchModels/SalesControlSearchModel';
import { ClientModel } from 'src/app/core/Models/EntityModels/clientModel';
import { SalesControlClientComponent } from '../../sales-control-client/sales-control-client.component';
import { GPSTrackingDetailSearchModel } from 'src/app/core/Models/SearchModels/GPSTrackingDetailSearchModel';

import { ManageSalesOrderComponent } from '../manage-sales-order/manage-sales-order.component';
import { TrakingRepresentativeDetailModel } from 'src/app/core/Models/ListModels/TrakingRepresentativeDetailModel';



declare var google: any;
@Component({
  selector: 'app-tracking-gps-detail',
  templateUrl: './tracking-gps-detail.component.html',
  styleUrls: ['./tracking-gps-detail.component.scss']
})
export class TrackingGpsDetailComponent implements OnInit {

  model: ResponseModel<TrakingRepresentativeDetailModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: null
  };

  searchModel: GPSTrackingDetailSearchModel = {
    representativeId: 0,
    trackingDate: new Date(),
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    TermBy:""

  };

  isLoading = false;

  CHOOSE_BRANCH = '';
  CHOOSE_SUPERVISOR = '';
  CHOOSE_REPRESENTITIVE = '';
  SHOW_REPRESENTITIVE = '';
  HEADER_MANAGE='';
  pop = false;
  player = false;

  menuItems: MenuItem[];

  options: any;

  overlays: any[];

  public innerWidth: any;
  public innerHeight: any;

  positive = 0;
  negative = 0;

  mode = 1;
  speed = 1;

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
  ) {

    this._translationLoaderService.loadTranslations(english, arabic);



    if (this.config.data) {
      if (this.config.data.representativeId) {
        this.searchModel.representativeId = +this.config.data.representativeId;
      }
    }
    if (this.config.data) {
      if (this.config.data.mode) {
        this.mode = +this.config.data.mode;
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
      zoom: 15,
      mapId: '2df52e872b9212a'
    };

    this.overlays = [
      //new google.maps.Marker({ position: { lat: 36.879466, lng: 30.667648 }, title: "Konyaalti",icon:'assets/images/marker_icon.png',data:'55' }),
    ];

    this.reload();


    setInterval(() => {
      if (this.player == false) {
        this.reload()
      }
    }, 1000 * 60)

  }

  handleMapClick(event) {
    //event: MouseEvent of Google Maps api
    console.log(event.latLng.lat());
    console.log(event.latLng.lng());
  }

  handleOverlayClick(event) {
    console.log(event.overlay.data);
    if(event.overlay.data && event.overlay.data>0){
      var ref = this.dialogService.open(ManageSalesOrderComponent, {
        header: this.HEADER_MANAGE,
        data: {
          salesId: event.overlay.data,
          mode: 'edit',
        },
        width: '95%',
        height: '95vh',
      });
    }
  }

  reload() {

    this._TrackingService.getDetails(this.searchModel).then(res => {



      if (res.succeeded == true) {
        this.model = res;

        this.overlays = [];
        this.options.center.lat = 30.065774;
        this.options.center.lng = 31.338034;

        this.positive = 0;
        this.negative = 0;

        this.model.data.filter(a => a.isPositive == true).reduce((a, b) => this.positive++, 0);
        this.model.data.filter(a => a.isPositive == false).reduce((a, b) => this.negative++, 0);


        let mapPath = [];

        res.data.forEach(element => {
          if (element.latitude > 0 && element.longitude > 0) {

            mapPath.push({ lat: element.latitude, lng: element.longitude })

            if (element.isPositive != null) {
              this.overlays.push(new google.maps.Marker({ position: { lat: element.latitude, lng: element.longitude }, title: element.clientName, icon: element.isPositive == true ? 'assets/images/marker_icon_online.png' : 'assets/images/marker_icon_offline.png', data: element.salesId }))
            }

            this.options.center.lat = element.latitude;
            this.options.center.lng = element.longitude;
          }
        });


        this.overlays.push(new google.maps.Polyline({
          path: mapPath, geodesic: true, strokeColor: '#FFC107', strokeOpacity: 0.9, strokeWeight: 3
        }));


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



  async showRepSTC() {

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
    TermBy:""

    };

    search.branchId = 0;
    search.branchCode = '';

    search.supervisorId = 0;
    search.supervisorCode = '';

    search.representativeId = this.searchModel.representativeId;
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

  showDetails(mode) {

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
  playGPS() {
    this.player = true;
    this.overlays = [];
    let index = 0;
    let mapPath: any[] = [];
    let t= 100 * (10-(this.speed));
    setInterval(() => {
      mapPath=this.drawSingle(index, mapPath);
      index++;
    }, t,true)
  }
  pauseGPS() {
    this.player = false;
    this.reload();
  }
  drawSingle(index, mapPath) {
    if(this.model.data.length>0){
      if(index<this.model.data.length){
        if (this.model.data[index].latitude > 0 && this.model.data[index].longitude > 0) {

          mapPath.push({ lat: this.model.data[index].latitude, lng: this.model.data[index].longitude })
    
          if (this.model.data[index].isPositive != null) {
            this.overlays.push(new google.maps.Marker({ position: { lat: this.model.data[index].latitude, lng: this.model.data[index].longitude }, title: '', icon: this.model.data[index].isPositive == true ? 'assets/images/marker_icon_online.png' : 'assets/images/marker_icon_offline.png', data: this.model.data[index].salesId }))
          }
    
          this.options.center.lat = this.model.data[index].latitude;
          this.options.center.lng = this.model.data[index].longitude;
        }
    
        this.overlays.push(new google.maps.Polyline({
          path: mapPath, geodesic: true, strokeColor: '#FFC107', strokeOpacity: 0.9, strokeWeight: 3
        }));
      }
    }


    return mapPath;
  }

  
}
