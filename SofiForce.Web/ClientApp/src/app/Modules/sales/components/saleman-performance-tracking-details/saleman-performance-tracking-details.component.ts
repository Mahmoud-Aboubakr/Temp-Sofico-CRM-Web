import { Component, Input, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MessageService, PrimeNGConfig } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { PerformanceSalesmanModel } from 'src/app/core/Models/StatisticalModels/PerformanceSalesmanModel';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { SyncSetupDetailService } from 'src/app/core/services/SyncSetupDetail.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { UserService } from 'src/app/core/services/User.Service';
import { UtilService } from 'src/app/core/services/util.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { BranchService } from 'src/app/core/services/Branch.Service';
import { BranchModel } from 'src/app/core/Models/EntityModels/branchModel';
import { RepresentativeModel } from 'src/app/core/Models/EntityModels/representativeModel';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';

declare var google: any;



@Component({
  selector: 'app-saleman-performance-tracking-details',
  templateUrl: './saleman-performance-tracking-details.component.html',
  styleUrls: ['./saleman-performance-tracking-details.component.scss']
})
export class SalemanPerformanceTrackingDetailsComponent implements OnInit {

  isLoading=false;
  @Input() model:PerformanceSalesmanModel;

  CHOOSE="";

  options: any;
  overlays: any[];


  representative:RepresentativeModel={
    branchCode:"",
    representativeCode:"",
    representativeNameEn:"",
  } as RepresentativeModel;
  
  constructor(
    private ref: DynamicDialogRef,
    private _auth: UserService,
    private primengConfig: PrimeNGConfig,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private confirmationService: ConfirmationService,
    private _AppMessageService: AppMessageService,
    private config: DynamicDialogConfig,
    private _UtilService: UtilService,
    private messageService: MessageService,
    private _SyncSetupDetailService:SyncSetupDetailService,
    private _BranchService:BranchService,
    private _commonCrudService : CommonCrudService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });
   }

  ngOnInit(): void {
    console.log(this.model);

    this.options = {
      center: { lat: 30.065774, lng: 31.338034 },
      zoom: 15,
      mapId: '2df52e872b9212a'
    };

    this.overlays = [
      new google.maps.Marker({ position: { lat: 30.065774, lng: 31.338034  }, title: "Konyaalti",icon:'assets/images/marker_icon.png',data:'55' }),
    ];


    this.buildView();
  }
  async buildView(){

    this.isLoading=true;
    this.isLoading=false;

  }
  

  handleMapClick(event) {
    //event: MouseEvent of Google Maps api
    console.log(event.latLng.lat());
    console.log(event.latLng.lng());
  }

  handleOverlayClick(event) {
  }
}
