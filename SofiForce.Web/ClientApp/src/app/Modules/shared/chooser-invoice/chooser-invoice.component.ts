import { Component, OnInit } from '@angular/core';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TranslateService } from '@ngx-translate/core';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { SalesOrderSearchModel } from 'src/app/core/Models/SearchModels/SalesOrderSearchModel';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { SalesOrderListModel } from 'src/app/core/Models/ListModels/SalesOrderListModel';
import { SalesOrderService } from 'src/app/core/services/SalesOrder.Service';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { SalesOrderModel } from 'src/app/core/Models/EntityModels/salesOrderModel';

import { SalesOrderSourceService } from 'src/app/core/services/SalesOrderSource.Service';
import { SalesOrderStatusService } from 'src/app/core/services/SalesOrderStatus.Service';
import { PaymentTermService } from 'src/app/core/services/PaymentTerm.Service';
import { PriorityService } from 'src/app/core/services/Priority.Service';
import { SalesOrderTypeService } from 'src/app/core/services/SalesOrderType.Service';
import { UtilService } from 'src/app/core/services/util.service';
import { MenuService } from 'src/app/core/services/Menu.Service';

@Component({
  selector: 'app-chooser-invoice',
  templateUrl: './chooser-invoice.component.html',
  styleUrls: ['./chooser-invoice.component.scss']
})
export class ChooserInvoiceComponent implements OnInit {

  orderModel: SalesOrderModel = {
    customDiscountTotal: 0,
    itemDiscountTotal: 0,
    taxTotal: 0,
    netTotal: 0,
    cashDiscountTotal: 0,
    itemTotal: 0,
    salesDate: this._UtilService.LocalDate(new Date()),
  } as SalesOrderModel;

  model: ResponseModel<SalesOrderListModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: []
  };


  isLoading = false;
  first = 0;
  advanced = false;
  showOption = false;

  orderTypes: LookupModel[] = [];


  HEADER_ERRORS = '';
  HEADER_MANAGE = '';
  HEADER_WORKFLOW = '';
  HEADER_LOG = '';
  HEADER_STC = '';


  searchModel: SalesOrderSearchModel = {
    salesCode: '',
    clientCode: '',
    branchId: 0,
    branchCode: undefined,
    representativeId: 0,
    representativeCode: undefined,
    storeId: 0,
    storeCode: undefined,
    priorityTypeId: 0,
    salesDate: undefined,
    salesOrderStatusId: 4,
    salesOrderTypeId: 1,
    salesOrderSourceId: [0],
    invoiceDate: undefined,
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    filterMode: 0,
    clientId: 0,
    isInvoiced: 0,
    TermBy:"",
    cashDiscountOnly:false,

  }
  selected: SalesOrderListModel;

  searchBy: LookupModel[] = [
    {id:1,code:'representativeCode',name:'SalesMan'},
    {id:2,code:'clientCode',name:'Client Code'},
    {id:3,code:'branchCode',name:'Branch Code'},
    {id:4,code:'storeCode',name:'Store Code'},
    {id:5,code:'invoiceCode',name:'Invoice Code'},
    {id:6,code:'salesCode',name:'Order Code'},
  ];

  constructor(
    private _SalesOrderService: SalesOrderService,
    private _translationLoaderService: TranslationLoaderService,
    private ref: DynamicDialogRef, 
    private _UtilService: UtilService,
  

    private _MenuService: MenuService,
  ) {

    this._translationLoaderService.loadTranslations(english, arabic);

    var found=localStorage.getItem("chooser-invoice.component.termBy")
    if(found){
      console.log(found);
      this.searchModel.TermBy=found;
    }
  }

  OnTermChange(arg){
    localStorage.setItem("chooser-invoice.component.termBy",arg.value);
  }

  ngOnInit(): void {

  }


  async filter(event) {


    this.isLoading = true;
    this.searchModel.Skip = event.first;
    this.searchModel.Take = event.rows;


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

    await this._SalesOrderService.Filter(this.searchModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._SalesOrderService.Filter(this.searchModel).then(res => {
        this.model = res;
        this.isLoading = false;
      })
    }
  }

  async reloadFilter() {

    this.isLoading = true;
    await this._SalesOrderService.Filter(this.searchModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })
  }

  async advancedFilter() {
    this.isLoading = true;
    await this._SalesOrderService.Filter(this.searchModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.first = 0;
    this.isLoading = true;
    this.searchModel = {
      salesCode: '',
      clientCode: '',
      branchId: 0,
      branchCode: undefined,
      representativeId: 0,
      representativeCode: undefined,
      storeId: 0,
      storeCode: undefined,
      priorityTypeId: 0,
      salesDate: undefined,
      salesOrderStatusId: 0,
      salesOrderTypeId: 1,
      salesOrderSourceId: [0],
      invoiceDate: undefined,
      Take: 30,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: undefined,
      filterMode: 0,
      clientId: 0,
      isInvoiced: 0,
    TermBy:"",
    cashDiscountOnly:false,

    }
    await this._SalesOrderService.Filter(this.searchModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })

  }

  async onSelectionChange(event) {
    this.selected = event;

  }

  FixedNumer(num: number) {
    if (!num) return 0;

    return Number(num.toFixed(3));
  }
  async onRowDblClick(e,data){
    if(data){
      this.ref.close(data);
    }
  }
}
