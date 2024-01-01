import { Component, Input, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig } from 'primeng/dynamicdialog';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { TranslateService } from '@ngx-translate/core';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { BooleanService } from 'src/app/core/services/Boolean.Service';
import { UtilService } from 'src/app/core/services/util.service';
import { SalesOrderPromotionAllListModel } from 'src/app/core/Models/EntityModels/SalesOrderPromotionAllListModel';
import { SalesOrderPromotionAllSearchModel } from 'src/app/core/Models/SearchModels/SalesOrderPromotionAllSearchModel';
import { ManageSalesOrderComponent } from '../manage-sales-order/manage-sales-order.component';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';


@Component({
  selector: 'app-promotion-orders-list',
  templateUrl: './promotion-orders-list.component.html',
  styleUrls: ['./promotion-orders-list.component.scss']
})
export class PromotionOrdersListComponent implements OnInit {


  @Input() take = 20;
  @Input() clientId = 0;
  @Input() salesId = 0;
  @Input() promotionId = 0;
  @Input() isPopup = false;


  gridModel: ResponseModel<SalesOrderPromotionAllListModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }

  searchModel: SalesOrderPromotionAllSearchModel = {
    promotionId: 0,
    clientId: 0,
    salesId: 0,
    promotionCode: '',
    clientCode: '',
    invoiceCode: '',
    invoiceDateFrom: undefined,
    invoiceDateTo: undefined,
    Take: 20,
    Skip: 0,
    Term: '',
    TermBy: 'clientCode',
    FilterBy: [],
    SortBy: undefined
  }

  advanced = false;
  showExtend = false;
  isLoading = false;
  isLoadingExtend = false;
  showFilter=true;

  actions = false;

  first = 0;
  items: MenuItem[];
  menuItems: MenuItem[];

  selected: SalesOrderPromotionAllListModel


  CREATE_NEW_HEADER = '';
  EDIT_HEADER = '';
  REP_STC = '';
  USER_ACCRESS = '';
  CHOOSE = '';

  searchBy: LookupModel[] = [
    {id:1,code:'clientCode',name:'Client'},
    {id:2,code:'promotionCode',name:'Promotion'},
    {id:3,code:'invoiceCode',name:'Invoice'},

  ];

  constructor(
    private _AppMessageService: AppMessageService,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _BooleanService: BooleanService,
    private _UtilService: UtilService,
    private config: DynamicDialogConfig,
    private _commonCrudService : CommonCrudService,

  ) {
    this._translationLoaderService.loadTranslations(english, arabic);

    this._translateService.get('Add New Promotion').subscribe((res) => { this.CREATE_NEW_HEADER = res });
    this._translateService.get('Edit/View Promotion').subscribe((res) => { this.EDIT_HEADER = res });
    this._translateService.get('Promotion Statistics').subscribe((res) => { this.REP_STC = res });
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });


    if (this.config.data) {
      console.log("Dialog  Data");

      console.log(this.config.data);

      if (this.config.data.take) {
        this.searchModel.Take = +this.config.data.take;
      }

      if (this.config.data.salesId) {
        this.searchModel.salesId = +this.config.data.salesId;
      }
      if (this.config.data.promotionId) {
        this.searchModel.promotionId = +this.config.data.promotionId;
      }

      if (this.config.data.clientId) {
        this.searchModel.clientId = +this.config.data.clientId;
      }


      if (this.config.data.isPopup) {
        this.isPopup = this.config.data.isPopup;
      }

      
      if (this.config.data.showFilter) {
        this.showFilter = this.config.data.showFilter;
      }

    }
  }

  ngOnInit(): void {

    if (this.salesId > 0)
      this.searchModel.salesId = this.salesId;
    if (this.clientId > 0)
      this.searchModel.clientId = this.clientId;
    if (this.promotionId > 0)
      this.searchModel.promotionId = this.promotionId;
    if (this.take > 0)
      this.searchModel.Take = this.take;

    console.log(this.searchModel);

    this.menuItems = [
      {
        label: 'View Invoice',
        icon: 'pi pi-fw pi-eye',
        command: (e) => this.manage('v')
      },
    ];





  }

  OnTermChange(arg){
    localStorage.setItem("promotion-orders-list.component.termBy",arg.value);
  }

  async filter(event) {
    console.log(event);
    this.isLoading = true;
    this.searchModel.Skip = event.first;
    this.searchModel.Take = event.rows;
    console.log(this.searchModel);

    this.searchModel.SortBy = { Order: "", Property: "" }
    if (event.sortField) {
      this.searchModel.SortBy.Property = event.sortField;
      if (event.sortOrder == 1) {
        this.searchModel.SortBy.Order = "asc";
      }
      else {
        this.searchModel.SortBy.Order = "desc";
      }
    }

    await this._commonCrudService.post("Promotion/OrderPromotion", this.searchModel,SalesOrderPromotionAllListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._commonCrudService.post("Promotion/OrderPromotion", this.searchModel,SalesOrderPromotionAllListModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {
    this.isLoading = true;
    await this._commonCrudService.post("Promotion/OrderPromotion", this.searchModel,SalesOrderPromotionAllListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.searchModel.Skip = 0;
    await this._commonCrudService.post("Promotion/OrderPromotion", this.searchModel,SalesOrderPromotionAllListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel = {

      promotionId: 0,
      clientId: 0,
      salesId: 0,
      promotionCode: '',
      clientCode: '',
      invoiceCode: '',
      invoiceDateFrom: undefined,
      invoiceDateTo: undefined,
      Take: 20,
      Skip: 0,
      Term: '',
      TermBy: '',
      FilterBy: [],
      SortBy: undefined

    };
  }

  async onSelectionChange(event) {
    this.refreshMenu();
  }
  refreshMenu() {
  }
  async manage(mode) {

    if (mode == 'v') {
      if (this.selected && this.selected.salesId > 0) {
        var ref = this.dialogService.open(ManageSalesOrderComponent, {
          header: this.EDIT_HEADER,
          data: {
            salesId: this.selected.salesId,
            mode: mode,
          },
          width: '95%',
          height: '95vh',
        });

      }
    }

    if (mode == 'download') {
      this.isLoading = true;
      (await this._commonCrudService.postFile("Promotion/OrderPromotionDownload",this.searchModel)).subscribe((data: any) => {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "OrderPromotion_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);


        this.isLoading = false;
      })
    }
    

  }



}
