import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MenuItem, MessageService, PrimeNGConfig } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { ChooserClientComponent } from 'src/app/Modules/shared/chooser-client/chooser-client.component';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { UserService } from 'src/app/core/services/User.Service';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { UtilService } from 'src/app/core/services/util.service';
import { SyncSetupDetailModel } from 'src/app/core/Models/EntityModels/SyncSetupDetailModel';
import { SyncSetupDetailSearchModel } from 'src/app/core/Models/SearchModels/SyncSetupDetailSearchModel';
import { SyncSetupDetailService } from 'src/app/core/services/SyncSetupDetail.Service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { ChooserStoreComponent } from 'src/app/Modules/shared/chooser-store/chooser-store.component';
import { StoreListModel } from 'src/app/core/Models/ListModels/StoreListModel';
import { ItemListModel } from 'src/app/core/Models/ListModels/ItemListModel';
import { ChooserProductAllComponent } from 'src/app/Modules/shared/chooser-product-all/chooser-product-all.component';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-sync-manager',
  templateUrl: './sync-manager.component.html',
  styleUrls: ['./sync-manager.component.scss']
})
export class SyncManagerComponent implements OnInit {

  selectedIndex = 1;
  isLoading = false;
  items: MenuItem[];

  ClientList: SyncSetupDetailModel[]=[];
  WarehouseList: SyncSetupDetailModel[]=[];
  QuotaList: SyncSetupDetailModel[]=[];
  PromotionList: SyncSetupDetailModel[]=[];
  ProductList: SyncSetupDetailModel[]=[];

  ClientSelection: SyncSetupDetailModel={
    setupId:1,
    payload1:"",
    payload2:"",
    payload3:"",
    payload4:"",
    detailId:0,
  } as SyncSetupDetailModel;



  WarehouseSelection: SyncSetupDetailModel={
    setupId:2,
    payload1:"",
    payload2:"",
    payload3:"",
    payload4:"",
    detailId:0,
  } as SyncSetupDetailModel;

  QuotaSelection: SyncSetupDetailModel={
    setupId:3,
    payload1:"",
    payload2:"",
    payload3:"",
    payload4:"",
    detailId:0,
  } as SyncSetupDetailModel;

  PromotionSelection: SyncSetupDetailModel={
    setupId:4,
    payload1:"",
    payload2:"",
    payload3:"",
    payload4:"",
    detailId:0,
  } as SyncSetupDetailModel;

  ProductSelection: SyncSetupDetailModel={
    setupId:5,
    payload1:"",
    payload2:"",
    payload3:"",
    payload4:"",
    detailId:0,
  } as SyncSetupDetailModel;

 
  searchModel: SyncSetupDetailSearchModel={
    setupId:1,
    Skip:0,
    Take:0,
    FilterBy:[],
    SortBy:{Order:"desc",Property:"detailId"},
    Term:"",
    TermBy:""
  } as SyncSetupDetailSearchModel;

  showClient=false;
  showWarehouse=false;
  showQuota=false;
  showPromotion=false;
  showProduct=false;

  CHOOSE='';

  StoreId=0;

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
    private _commonCrudService : CommonCrudService,

  ) {
    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });
    this.StoreId=_auth.Current().storeId;
  }

  ngOnInit(): void {

    this.items = [
      {
        label: 'Clients',
        icon: 'fa fa-info-circle',
        command: (e) => this.manage(1)
      },
      {
        label: 'Warehouse',
        icon: 'fa fa-users',
        command: (e) => this.manage(2)
      },
      {
        label: 'Quota',
        icon: 'fa fa-money',
        command: (e) => this.manage(3)
      },
      {
        label: 'Promotion',
        icon: 'fa fa-money',
        command: (e) => this.manage(4)

      },
      {
        label: 'Products',
        icon: 'fa fa-unlock-alt',
        badge: "2",
        command: (e) => this.manage(5)
      },
    ];
    this.loadData();
  }
  manage(index) {
    this.selectedIndex = index;
    this.loadData();
  }

  loadData(){
    
    this.searchModel.setupId=this.selectedIndex;
    this.isLoading=true;
    this._commonCrudService.post("SyncSetupDetail/Filter", this.searchModel,SyncSetupDetailModel).then(res=>{
      if(res.succeeded==true){
        if(this.selectedIndex==1){
          this.ClientList=res.data;
        }
        if(this.selectedIndex==2){
          this.WarehouseList=res.data;
        }
        if(this.selectedIndex==3){
          this.QuotaList=res.data;
        }
        if(this.selectedIndex==4){
          this.PromotionList=res.data;
        }
        if(this.selectedIndex==5){
          this.ProductList=res.data;
        }


        this.ClientSelection.detailId=0;
        this.ClientSelection.payload1="";
        this.ClientSelection.payload2="";
        this.ClientSelection.payload3="";
        this.ClientSelection.payload4="";


        this.WarehouseSelection.detailId=0;
        this.WarehouseSelection.payload1="";
        this.WarehouseSelection.payload2="";
        this.WarehouseSelection.payload3="";
        this.WarehouseSelection.payload4="";

        
        this.QuotaSelection.detailId=0;
        this.QuotaSelection.payload1="";
        this.QuotaSelection.payload2="";
        this.QuotaSelection.payload3="";
        this.QuotaSelection.payload4="";

        this.PromotionSelection.detailId=0;
        this.PromotionSelection.payload1="";
        this.PromotionSelection.payload2="";
        this.PromotionSelection.payload3="";
        this.PromotionSelection.payload4="";

        this.ProductSelection.detailId=0;
        this.ProductSelection.payload1="";
        this.ProductSelection.payload2="";
        this.ProductSelection.payload3="";
        this.ProductSelection.payload4="";



      }
      this.isLoading=false;
    })
  }
  reload(){
    this.loadData();
  }
  addLine(){
    if(this.selectedIndex==1){
      this.showClient=true;
    }
    if(this.selectedIndex==2){
      this.showWarehouse=true;
    }
    if(this.selectedIndex==3){
      this.showQuota=true;
    }
    if(this.selectedIndex==4){
      this.showPromotion=true;
    }
    if(this.selectedIndex==5){
      this.showProduct=true;
    }
  }
  deleteLine(){
    if(this.selectedIndex==1){
      if(this.ClientSelection && this.ClientSelection.detailId>0){
        this._commonCrudService.post("SyncSetupDetail/Delete", this.ClientSelection, SyncSetupDetailModel).then(res=>{
          this.loadData();
          this.ClientSelection.detailId=0;
          this.ClientSelection.payload1="";
          this.ClientSelection.payload2="";
          this.ClientSelection.payload3="";
          this.ClientSelection.payload4="";
        })
      }
    }
    if(this.selectedIndex==2){
      if(this.WarehouseSelection && this.WarehouseSelection.detailId>0){
        this._commonCrudService.post("SyncSetupDetail/Delete", this.WarehouseSelection, SyncSetupDetailModel).then(res=>{
          this.loadData();
          this.WarehouseSelection.detailId=0;
          this.WarehouseSelection.payload1="";
          this.WarehouseSelection.payload2="";
          this.WarehouseSelection.payload3="";
          this.WarehouseSelection.payload4="";

        })
      }
    }
    if(this.selectedIndex==3){
      if(this.QuotaSelection && this.QuotaSelection.detailId>0){
        this._commonCrudService.post("SyncSetupDetail/Delete", this.QuotaSelection, SyncSetupDetailModel).then(res=>{
          this.loadData();
          this.QuotaSelection.detailId=0;
          this.QuotaSelection.payload1="";
          this.QuotaSelection.payload2="";
          this.QuotaSelection.payload3="";
          this.QuotaSelection.payload4="";

        })
      }
    }
    if(this.selectedIndex==4){
      if(this.PromotionSelection && this.PromotionSelection.detailId>0){
        this._commonCrudService.post("SyncSetupDetail/Delete", this.PromotionSelection, SyncSetupDetailModel).then(res=>{
          this.loadData();
          this.PromotionSelection.detailId=0;
          this.PromotionSelection.payload1="";
          this.PromotionSelection.payload2="";
          this.PromotionSelection.payload3="";
          this.PromotionSelection.payload4="";

        })
      }
    }
    if(this.selectedIndex==5){
      if(this.ProductSelection && this.ProductSelection.detailId>0){
        this._commonCrudService.post("SyncSetupDetail/Delete", this.ProductSelection, SyncSetupDetailModel).then(res=>{
          this.loadData();
          this.ProductSelection.detailId=0;
          this.ProductSelection.payload1="";
          this.ProductSelection.payload2="";
          this.ProductSelection.payload3="";
          this.ProductSelection.payload4="";

        })
      }
    }
  }
  save(){
    if(this.selectedIndex==1){

      if(this.ClientSelection.payload2){
        this.isLoading=true;

        this._commonCrudService.post("SyncSetupDetail/Save", this.ClientSelection, SyncSetupDetailModel).then(res=>{
          this.loadData();
          this.ClientSelection.detailId=0;
          this.ClientSelection.payload1="";
          this.ClientSelection.payload2="";
          this.ClientSelection.payload3="";
          this.ClientSelection.payload4="";

        })
      }
    }
    if(this.selectedIndex==2){

      if(this.WarehouseSelection.payload2 && this.WarehouseSelection.payload3){
        this.isLoading=true;

        this._commonCrudService.post("SyncSetupDetail/Save", this.WarehouseSelection, SyncSetupDetailModel).then(res=>{
          this.loadData();
          this.WarehouseSelection.detailId=0;
          this.WarehouseSelection.payload1="";
          this.WarehouseSelection.payload2="";
          this.WarehouseSelection.payload3="";
          this.WarehouseSelection.payload4="";
        })
      }
    }

    if(this.selectedIndex==3){

      if(this.QuotaSelection.payload1){
        this.isLoading=true;

        this._commonCrudService.post("SyncSetupDetail/Save", this.QuotaSelection, SyncSetupDetailModel).then(res=>{
          this.loadData();
          this.QuotaSelection.detailId=0;
          this.QuotaSelection.payload1="";
          this.QuotaSelection.payload2="";
          this.QuotaSelection.payload3="";
          this.QuotaSelection.payload4="";
        })
      }
    }

    if(this.selectedIndex==4){

      if(this.PromotionSelection.payload1){
        this.isLoading=true;

        this._commonCrudService.post("SyncSetupDetail/Save", this.PromotionSelection, SyncSetupDetailModel).then(res=>{
          this.loadData();
          this.PromotionSelection.detailId=0;
          this.PromotionSelection.payload1="";
          this.PromotionSelection.payload2="";
          this.PromotionSelection.payload3="";
          this.PromotionSelection.payload4="";
        })
      }
    }
    if(this.selectedIndex==5){

      if(this.ProductSelection.payload1){
        this.isLoading=true;

        this._commonCrudService.post("SyncSetupDetail/Save", this.ProductSelection, SyncSetupDetailModel).then(res=>{
          this.loadData();
          this.ProductSelection.detailId=0;
          this.ProductSelection.payload1="";
          this.ProductSelection.payload2="";
          this.ProductSelection.payload3="";
          this.ProductSelection.payload4="";
        })
      }
    }

  }

  async choose_Client() {
  


      var ref = this.dialogService.open(ChooserClientComponent, {
        header: this.CHOOSE,
        width: '90%',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });

      ref.onClose.subscribe((res: ClientListModel) => {

        if (res) {
          if(this.selectedIndex==1){
            this.ClientSelection.payload1=res.branchCode;
            this.ClientSelection.payload2=res.clientCode;
            this.ClientSelection.payload3=res.clientName;
            this.ClientSelection.payload4="";

          }
          if(this.selectedIndex==3){
            this.QuotaSelection.payload3=res.clientCode;
            this.QuotaSelection.payload4=res.clientName;

          }
        }

      });

    

  }
  async choose_Store() {
  


    var ref = this.dialogService.open(ChooserStoreComponent, {
      header: this.CHOOSE,
      width: '90%',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });

    ref.onClose.subscribe((res: StoreListModel) => {

      if (res) {
        if(this.selectedIndex==2){
          this.WarehouseSelection.payload1=res.branchCode;
          this.WarehouseSelection.payload2=res.storeCode;
          this.StoreId=res.storeId;
          
        }
       
      }

    });

  

}
async choose_Item() {
  


  var ref = this.dialogService.open(ChooserProductAllComponent, {
    header: this.CHOOSE,
    data:{storeId:this.StoreId},
    width: '90%',
    contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
    baseZIndex: 10000
  });

  ref.onClose.subscribe((res: ItemListModel) => {

    if (res) {
      if(this.selectedIndex==2){
        this.WarehouseSelection.payload3=res.itemCode;
        this.WarehouseSelection.payload4=res.itemName;
      }
      if(this.selectedIndex==3){
        this.QuotaSelection.payload1=res.itemCode;
        this.QuotaSelection.payload2=res.itemName;
      }
      if(this.selectedIndex==4){
        this.PromotionSelection.payload1=res.itemCode;
        this.PromotionSelection.payload2=res.itemName;
      }
      if(this.selectedIndex==5){
        this.ProductSelection.payload1=res.itemCode;
        this.ProductSelection.payload2=res.itemName;
      }
    }

  });



}
}
