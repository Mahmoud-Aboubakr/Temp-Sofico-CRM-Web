import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { StoreListModel } from 'src/app/core/Models/ListModels/StoreListModel';
import { ExportSearchModel } from 'src/app/core/Models/SearchModels/ExportSearchModel';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { MenuService } from 'src/app/core/services/Menu.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { UtilService } from 'src/app/core/services/util.service';
import { ChooserBranchComponent } from 'src/app/Modules/shared/chooser-branch/chooser-branch.component';
import { ChooserClientComponent } from 'src/app/Modules/shared/chooser-client/chooser-client.component';
import { ChooserRepresentativeComponent } from 'src/app/Modules/shared/chooser-representative/chooser-representative.component';
import { ChooserStoreComponent } from 'src/app/Modules/shared/chooser-store/chooser-store.component';


import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { ChooserVendorComponent } from 'src/app/Modules/shared/chooser-vendor/chooser-vendor.component';
import { VendorListModel } from 'src/app/core/Models/ListModels/VendorListModel';
import { ItemListModel } from 'src/app/core/Models/ListModels/ItemListModel';
import { ExportModel } from 'src/app/core/Models/DtoModels/ExportModel';
import { SalesExportService } from 'src/app/core/services/SalesExport.Service';
import { DownloaderService } from 'src/app/core/services/downloader.service';
import { UserService } from 'src/app/core/services/User.Service';
import { UserModel } from 'src/app/core/Models/DtoModels/UserModel';
import { ChooserProductAllComponent } from 'src/app/Modules/shared/chooser-product-all/chooser-product-all.component';

@Component({
  selector: 'app-manage-exporter',
  templateUrl: './manage-exporter.component.html',
  styleUrls: ['./manage-exporter.component.scss']
})
export class ManageExporterComponent implements OnInit {

  activeIndex: number = 0;
  selectedReport;
  items: MenuItem[];
  reports: any[] = [

    { name: 'Sales invoice total per client',Id:1, key: 'SFC-101', disabled: false },

    { name: 'Sales invoice details with batch/expire',Id:2, key: 'SFC-102', disabled: false },
    { name: 'Warehouse summery per product',Id:3, key: 'SFC-103', disabled: true },
    { name: 'Warehouse summery per batch/expire',Id:4, key: 'SFC-104', disabled: true },
    { name: 'Vendor daily report summery (sales,warehouse,purchase)',Id:5, key: 'SFC-105', disabled: true },
    { name: 'Vendor monthy report summery',Id:6, key: 'SFC-106', disabled: true },

  ];

  searchModel: ExportSearchModel = {
    fromDate: new Date(),
    toDate: new Date(),
    clientId: 0,
    clientCode: '',
    branchId: 0,
    branchCode: '',
    storeId: 0,
    storeCode: '',
    vendorId: 0,
    vendorCode: '',
    itemId: 0,
    itemCode: '',
    Take: 0,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    representativeId: 0,
    representativeCode: '',
    TermBy:""
  }

  HEADER_ERRORS = '';
  HEADER_MANAGE = '';
  HEADER_WORKFLOW = '';
  HEADER_LOG = '';
  HEADER_STC = '';
  CHOOSE_BRANCH = '';
  CHOOSE_SUPERVISOR = '';
  CHOOSE_REPRESENTITIVE = '';
  CHOOSE_CLIENT = '';
  CHOOSE_VENDOR = '';
  CHOOSE_ITEM = '';

  exportModel: ExportModel = {
    fileUrl: "",
    total: 0
  } as ExportModel;

  isLoading = false;
  progress = 0;
  totalSeconds:number=0;
  current:UserModel;
  constructor(

    private _translationLoaderService: TranslationLoaderService,
    private dialogService: DialogService,
    
    private _translateService: TranslateService,
    private _DownloaderService:DownloaderService,
    private ref: DynamicDialogRef,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _AppMessageService: AppMessageService,
    private _UtilService: UtilService,
    private _MenuService: MenuService,
    private _SalesExportService: SalesExportService,
    private _UserService:UserService,
  ) {

    this._translationLoaderService.loadTranslations(english, arabic);

    this._translateService.get('Choose Branch').subscribe((res) => { this.CHOOSE_BRANCH = res });
    this._translateService.get('Choose Supervisor').subscribe((res) => { this.CHOOSE_SUPERVISOR = res });
    this._translateService.get('Choose Sales Man').subscribe((res) => { this.CHOOSE_REPRESENTITIVE = res });
    this._translateService.get('Choose Client').subscribe((res) => { this.CHOOSE_CLIENT = res });
    this._translateService.get('Choose Vendor').subscribe((res) => { this.CHOOSE_VENDOR = res });
    this._translateService.get('Choose Item').subscribe((res) => { this.CHOOSE_ITEM = res });

  }

  ngOnInit(): void {

    this.current=this._UserService.Current();

    this.items = [{
      label: 'Report',
    },
    {
      label: 'Criteria',
    },
    {
      label: 'Execute',
    },
    {
      label: 'Download',
    }
    ];
  }

  MoveNext() {
    if (this.activeIndex < 3)
      this.activeIndex++;

    if (this.activeIndex == 2) {
      this.isLoading = true;
      this.totalSeconds=0;
      this.progress=0;
      this.exportModel.total=0;
      this.exportModel.fileUrl="";

      var xx=new Date();
      if(this.selectedReport.Id==1){
        this._SalesExportService.ExportInvoiceHeader(this.searchModel).then(res => {
          console.log(res.data);
          this.progress=100;
          this.exportModel=res.data;
          this.isLoading = false;
          var yy=new Date();
          this.totalSeconds =(yy.getTime() - xx.getTime()) / 1000;
        });
      }
      if(this.selectedReport.Id==2){
        this._SalesExportService.ExportInvoiceDetail(this.searchModel).then(res => {
          console.log(res.data);
          this.progress=100;
          this.exportModel=res.data;
          this.isLoading = false;
          var yy=new Date();
          this.totalSeconds =(yy.getTime() - xx.getTime()) / 1000;
        });
      }

    }
  }
  isvalidModel(){
   
    if(!this.searchModel.fromDate || this.searchModel.fromDate==null || this.searchModel.fromDate==undefined){
      return false;
    }

    if(!this.searchModel.toDate || this.searchModel.toDate==null || this.searchModel.toDate==undefined){
      return false;
    }

    if(!this.searchModel.toDate || this.searchModel.toDate==null || this.searchModel.toDate==undefined){
      return false;
    }
    if(this.searchModel.toDate <this.searchModel.fromDate){
      return false;
    }
    if(this.searchModel.toDate.getMonth()!=this.searchModel.fromDate.getMonth()){
      return false;
    }

    if(this.searchModel.toDate.getFullYear()!=this.searchModel.fromDate.getFullYear()){
      return false;
    }

    return true;
  }
  async Download() {
    if (this.exportModel.fileUrl && this.exportModel.fileUrl.length > 0) {
      this.isLoading = true;
      (await this._DownloaderService.DownloadExcel(this.exportModel.fileUrl)).subscribe((data: any) => {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "Export_"+this.selectedReport.Id+"_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);

        
        this.isLoading = false;
        this.ref.close();
      })
    }
  }

  MoveBack() {
    if (this.activeIndex > 0)
      this.activeIndex--;

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

      }
    });
  }
  clear_Branch() {
    this.searchModel.branchCode = '';
    this.searchModel.branchId = 0;
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

  choose_Client() {
    var ref = this.dialogService.open(ChooserClientComponent, {
      header: this.CHOOSE_CLIENT,
      width: '90%',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((client: ClientListModel) => {
      if (client) {


        this.searchModel.clientCode = client.clientCode;
        this.searchModel.clientId = client.clientId;

      }
    });
  }

  clear_Client() {
    this.searchModel.clientCode = '';
    this.searchModel.clientId = 0;
  }


  choose_Vendor() {
    var ref = this.dialogService.open(ChooserVendorComponent, {
      header: this.CHOOSE_VENDOR,
      width: '90%',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((client: VendorListModel) => {
      if (client) {


        this.searchModel.vendorCode = client.vendorCode;
        this.searchModel.vendorId = client.vendorId;

      }
    });
  }

  clear_Vendor() {
    this.searchModel.vendorCode = '';
    this.searchModel.vendorId = 0;
  }

  choose_Item() {
    var ref = this.dialogService.open(ChooserProductAllComponent, {
      header: this.CHOOSE_ITEM,
      width: '90%',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((client: ItemListModel) => {
      if (client) {


        this.searchModel.itemCode = client.itemCode;
        this.searchModel.itemId = client.itemId;

      }
    });
  }

  clear_Item() {
    this.searchModel.itemCode = '';
    this.searchModel.itemId = 0;
  }



  choose_Store() {
    var ref = this.dialogService.open(ChooserStoreComponent, {
      header: this.CHOOSE_CLIENT,
      width: '1100px',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((store: StoreListModel) => {
      if (store) {


        this.searchModel.storeCode = store.storeCode;
        this.searchModel.storeId = store.storeId;

      }
    });
  }

  clear_Store() {
    this.searchModel.storeCode = '';
    this.searchModel.storeId = 0;
  }

  FixedNumer(num: number) {
    if (!num) return 0;

    return Number(num.toFixed(3));
  }

}
