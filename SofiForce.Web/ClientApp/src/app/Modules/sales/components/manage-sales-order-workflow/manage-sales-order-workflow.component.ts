import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MessageService, PrimeNGConfig } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { BranchModel } from 'src/app/core/Models/EntityModels/branchModel';
import { ClientModel } from 'src/app/core/Models/EntityModels/clientModel';
import { RepresentativeModel } from 'src/app/core/Models/EntityModels/representativeModel';
import { SalesOrderModel } from 'src/app/core/Models/EntityModels/salesOrderModel';
import { StoreModel } from 'src/app/core/Models/EntityModels/storeModel';
import { BranchSearchModel } from 'src/app/core/Models/SearchModels/BranchSearchModel';
import { RepresentativeSearchModel } from 'src/app/core/Models/SearchModels/RepresentativeSearchModel';
import { StoreSearchModel } from 'src/app/core/Models/SearchModels/StoreSearchModel';
import { BranchService } from 'src/app/core/services/Branch.Service';
import { ItemStoreService } from 'src/app/core/services/ItemStore.Service';
import { PaymentTermService } from 'src/app/core/services/PaymentTerm.Service';
import { PriorityService } from 'src/app/core/services/Priority.Service';
import { RepresentativeService } from 'src/app/core/services/Representative.Service';
import { SalesOrderService } from 'src/app/core/services/SalesOrder.Service';
import { SalesOrderSourceService } from 'src/app/core/services/SalesOrderSource.Service';
import { SalesOrderStatusService } from 'src/app/core/services/SalesOrderStatus.Service';
import { StoreService } from 'src/app/core/services/Store.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';
import { BranchListModel } from '../../../../core/Models/ListModels/BranchListModel';
import { StoreListModel } from '../../../../core/Models/ListModels/StoreListModel';

@Component({
  selector: 'app-manage-sales-order-workflow',
  templateUrl: './manage-sales-order-workflow.component.html',
  styleUrls: ['./manage-sales-order-workflow.component.scss']
})
export class ManageSalesOrderWorkflowComponent implements OnInit {

  isLoading=false;

  OrderStatus: LookupModel[] = [];
  DispatchStatus: LookupModel[] = [];

  model: SalesOrderModel = {} as SalesOrderModel;
  
  branchSearchModel: BranchSearchModel = {
    Take: 20,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    TermBy:""

  }
  storeSearchModel: StoreSearchModel = {
    Take: 20,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    branchId: 0,
    branchCode: '',
    storeTypeId: 0,
    isActive: 1,
    isOrder: 1,
    storeMode: 1,
    TermBy:""

  }



  constructor(
    private ref: DynamicDialogRef,
    private primengConfig: PrimeNGConfig,
    private messageService: MessageService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private _SalesOrderSourceService: SalesOrderSourceService,
    private _SalesOrderStatusService: SalesOrderStatusService,
    private _BranchService: BranchService,
    private _StoreService: StoreService,
    private _PriorityService: PriorityService,
    private _ItemStoreService: ItemStoreService,
    private _RepresentativeService: RepresentativeService,
    private confirmationService: ConfirmationService,
    private _SalesOrderService: SalesOrderService,
    private _PaymentTermService: PaymentTermService,
  
    private _commonCrudService : CommonCrudService,
    private config: DynamicDialogConfig,
  ) { 

    
    this.model.salesId=0;
    this.clear();

    if (this.config.data) {
      if(+this.config.data.salesId>0){
        this.model.salesId= +this.config.data.salesId
      }
    }

  }

  ngOnInit(): void {

    this.init();
  }

  clear() {
    this.model = {} as SalesOrderModel;
    this.model.salesDate = new Date();

    this.model.branchId = 0;
    this.model.branchCode = '';


    this.model.storeId = 0;
    this.model.storeCode = '';


  }
  async init() {

    this.isLoading = true;



    await this._commonCrudService.get("SalesOrderStatus/GetAll", LookupModel).then(res => {
      this.OrderStatus = res.data;
      //this.DispatchStatus = res.data.filter(a=>a.id>=5);

    })


    await this._commonCrudService.post("Branch/Filter", this.branchSearchModel,BranchListModel).then(res => {
      if (res.data) {
        if (res.data.length == 1) {
          this.model.branchId = res.data[0].branchId;
          this.model.branchCode = res.data[0].branchCode;

          this.storeSearchModel.branchId = res.data[0].branchId;

          this._commonCrudService.post("Store/Filter", this.storeSearchModel, StoreListModel).then(res => {
            if (res.data && res.data.length > 0) {
              this.model.storeId = res.data[0].storeId;
              this.model.storeCode = res.data[0].storeCode;
            }
          })
        }
      }
    })

    if(this.model.salesId>0){
      await this._commonCrudService.get("SalesOrder/getById?Id="+this.model.salesId, SalesOrderModel).then(res=>{
        if(res.succeeded==true){
          this.model=res.data;
          this.model.salesDate=new Date(res.data.salesTime)
        }
        else
        {
          this.ref.close();
        }
      })
    }

    this.isLoading = false;
  }

}
