import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { BranchService } from 'src/app/core/services/Branch.Service';
import { ClientService } from 'src/app/core/services/Client.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { ChooserBranchComponent } from 'src/app/Modules/shared/chooser-branch/chooser-branch.component';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { ChooserClientComponent } from 'src/app/Modules/shared/chooser-client/chooser-client.component';
import { ClientActivityModel } from 'src/app/core/Models/EntityModels/ClientActivityModel';
import { ChooserRepresentativeComponent } from 'src/app/Modules/shared/chooser-representative/chooser-representative.component';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { RepresentativeSearchModel } from 'src/app/core/Models/SearchModels/RepresentativeSearchModel';
import { UserService } from 'src/app/core/services/User.Service';
import { UserModel } from 'src/app/core/Models/DtoModels/UserModel';
import { RepresentativeService } from 'src/app/core/services/Representative.Service';
import { ManageSalesOrderComponent } from 'src/app/Modules/sales/components/manage-sales-order/manage-sales-order.component';
import { SalesOrderModel } from 'src/app/core/Models/EntityModels/salesOrderModel';
import { ClientActivityService } from 'src/app/core/services/ClientActivity.Service';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { ActivityTypeService } from 'src/app/core/services/ActivityType.Service';
import { UtilService } from 'src/app/core/services/util.service';
import { ClientStatisticalComponent } from '../client-statistical/client-statistical.component';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';
import { RepresentativeModel } from "src/app/core/Models/EntityModels/representativeModel";
import { ClientModel } from '../../../../core/Models/EntityModels/clientModel';
declare var google: any;

@Component({
  selector: 'app-manage-activity',
  templateUrl: './manage-activity.component.html',
  styleUrls: ['./manage-activity.component.scss']
})
export class ManageActivityComponent implements OnInit {

  model = {
    inZone:true,
    distance:0
  } as ClientActivityModel;

  CHOOSE = '';
  CLIENT_STC='';
  isLoading = false;
  options: any;
  overlays: any[];
  current: UserModel;
  ActivityTypes: LookupModel[] = [];

  constructor(

    private auth: UserService,
    private ref: DynamicDialogRef,
    private _UtilService: UtilService,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private _AppMessageService: AppMessageService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _ClientService: ClientService,
    private _BranchService: BranchService,
    private _RepresentativeService: RepresentativeService,
    private _ClientActivityService: ClientActivityService,
    private activatedRoute: ActivatedRoute,
    private config: DynamicDialogConfig,
    private _ActivityTypeService: ActivityTypeService,
    private _commonCrudService : CommonCrudService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });
    this._translateService.get('Client Statisticals').subscribe((res) => { this.CLIENT_STC = res });

    this.model.clientCode = '';
    this.model.representativeCode = '';
    this.model.activityDate = this._UtilService.LocalDate(new Date())
    this.model.activityTime = this._UtilService.LocalDate(new Date())
    this.model.isPositive = false;
    this.model.inJourney = true;
    this.model.inZone = true;
    this.model.notes = '';
    this.model.clientId = 0;
    this.model.activityTypeId = 2;
    this.model.inZone = true;
    this.model.distance = 0;
    this.model.inJourney = true;
    this.model.activityId = 0;


    this.current = this.auth.Current();


    if (this.config.data) {

      if (+this.config.data.clientId > 0) {
        this.model.clientId = +this.config.data.clientId
      }
      if (+this.config.data.activityId > 0) {
        this.model.activityId = +this.config.data.activityId
      }

    }

  }

  ngOnInit(): void {


    this.options = {
      center: { lat: 30.065774, lng: 31.338034 },
      zoom: 12,
      mapId: '2df52e872b9212a'
    };

    this.overlays=[];

    if (this.current && this.current.representativeId > 0) {
      this._commonCrudService.get("Representative/getById?Id="+this.current.representativeId, RepresentativeModel).then(res => {
        this.model.representativeCode = res.data.representativeCode;
        this.model.representativeId = res.data.representativeId;
      })
    }

    this._commonCrudService.get("ActivityType/GetAll", LookupModel).then(res => {
      this.ActivityTypes = res.data;
    })

    if (this.model.clientId > 0) {
      this._commonCrudService.get("Client/getById?Id="+this.model.clientId, ClientModel).then(res => {
        this.model.clientCode = res.data.clientCode;
      })
    }

    if (this.model.activityId > 0) {
      this.isLoading=true;
      this._commonCrudService.get("ClientActivity/getById?Id="+this.model.activityId, ClientActivityModel).then(res => {
        if (res.succeeded == true) {
          this.model = res.data;
          if (this.model.activityDate != null)
            this.model.activityDate = this._UtilService.LocalDate(this.model.activityDate);
          if (this.model.activityTime != null)
            this.model.activityTime = this._UtilService.LocalDate(this.model.activityTime);
          if (this.model.callAgain != null)
            this.model.callAgain = this._UtilService.LocalDate(this.model.callAgain);

          if (this.model.clientId > 0) {
            this._commonCrudService.get("Client/getById?Id="+this.model.clientId, ClientModel).then(res=>{
              this.model.clientCode=res.data.clientCode;
            })
          }
          if (this.model.representativeId > 0) {
            this._commonCrudService.get("Representative/getById?Id="+this.model.representativeId, RepresentativeModel).then(res=>{
              this.model.representativeCode=res.data.representativeCode;
            })
          }

          if(this.model.latitude>0 && this.model.longitude>0){
              this.overlays.push(new google.maps.Marker({ position: { lat: this.model.latitude, lng: this.model.longitude }, 
                title: this.model.clientCode, 
                icon:this.model.isPositive==false ? 'assets/images/marker_icon_offline.png' : 'assets/images/marker_icon_online.png', 
                data: 0
              }));

              this.options = {
                center: { lat: this.model.latitude, lng: this.model.longitude },
                zoom: 15,
                mapId: '2df52e872b9212a'
              };
          }
        }
        else {
          this.ref.close()
        }

        this.isLoading=false;
      })
    }

  }


  onTick(e) {

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
      }
    });
  }
  manage(operation) {
    if (operation == 'n') {

      if (this.model.clientId == 0 || this.model.representativeId == 0) {
        return;
      }


      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {
          this.isLoading = true;
          this.model.isPositive = false;
          if (this.model.callAgain != null) {
            this.model.callAgain = this._UtilService.LocalDate(this.model.callAgain);
          }
          this._commonCrudService.post("ClientActivity/Save",this.model, ClientActivityModel).then(res => {
            this.isLoading = false;

            if (res.succeeded == true) {
              this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });
              this.ref.close(this.model);
            }
            else {
              this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
            }
          })
        },
        reject: () => {
          //reject action
        }
      });

    }
    if (operation == 'p') {

      if (this.model.clientId == 0 || this.model.representativeId == 0) {
        return;
      }
      var ref = this.dialogService.open(ManageSalesOrderComponent, {
        data: { clientId: this.model.clientId },
        header: this.CHOOSE,
        width: '95%',
        height: '95vh',
      });

      ref.onClose.subscribe((res: SalesOrderModel) => {
        if (res) {
          if (res.salesId > 0) {
            this.model.salesId = res.salesId;
            this.ref.close(this.model);
          }
        }
      });
    }
  }


  showClientStc(){
    if (this.model != null && this.model.clientId > 0) {


      var ref = this.dialogService.open(ClientStatisticalComponent, {
        header: this.CLIENT_STC,
        data: { clientId: this.model.clientId },
        width: '90%',
        height: '90%',
        contentStyle: { "overflow": "auto" },
        baseZIndex: 10000
      });
      
    }
  }

}
