import { Component, OnInit } from '@angular/core';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { DialogService } from 'primeng/dynamicdialog';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';

import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { FormatterService } from 'src/app/core/services/Formatter.service';

import { saveAsPng } from 'save-html-as-image';
import { ChooserBranchComponent } from '../../shared/chooser-branch/chooser-branch.component';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { SalesControlSupervisorComponent } from '../sales-control-supervisor/sales-control-supervisor.component';
import { OrderMonitorDetailModel, OrderMonitorModel } from 'src/app/core/Models/StatisticalModels/OrderMonitorModel';
import { SalesMonitorSearchModel } from 'src/app/core/Models/SearchModels/SalesMonitorSearchModel';
import { BranchInvoiceingSetupModel } from 'src/app/core/Models/EntityModels/BranchInvoiceingSetupModel';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-sales-monitor-branch',
  templateUrl: './sales-monitor-branch.component.html',
  styleUrls: ['./sales-monitor-branch.component.scss']
})
export class SalesMonitorBranchComponent implements OnInit {

  menu: MenuItem[];



  model: OrderMonitorModel = {
    confirmed: 0,
    invoiced: 0,
    opened: 0,
    perormance: 0,
    transfered: 0,
    details: []
  } as OrderMonitorModel


  searchModel:SalesMonitorSearchModel={
    branchId:0,
  }as SalesMonitorSearchModel;

  selected: OrderMonitorDetailModel;
  advanced = false;
  isLoading = true;
  menuItems: MenuItem[];


  CHOOSE_BRANCH = '';
  SHOW_SUPERVISOR = '';

  pop = false;
  constructor(
    private _FormatterService: FormatterService,
    private _translationLoaderService: TranslationLoaderService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _AppMessageService: AppMessageService,
    private _commonCrudService : CommonCrudService
  ) {

    this._translationLoaderService.loadTranslations(english, arabic);

  }

  ngOnInit(): void {


    //this._translateService.get('Choose Branch').subscribe((res) => { this.CHOOSE_BRANCH = res });

    //this._translateService.get('Supervisors Details').subscribe((res) => { this.SHOW_SUPERVISOR = res });


    this.menu = [
      {
        label: 'Actions',
        icon: 'fa fa-shield',
        items:[{
          label: 'Enable',
          icon: 'fa fa-unlock-alt',
          command: (e) => this.manage('enable',true)
        },
        {
          label: 'Disable',
          icon: 'fa fa-lock',
          command: (e) => this.manage('enable',false)
        }
      ],
          
      },
      {
        separator: true,
      },
      {
        label: 'Service Worker',
        icon: 'fa fa-bolt',
        items:[{
          label: 'Worker 1',
          command: (e) => this.manage('worker',1)
        },
        {
          label: 'Worker 2',
          command: (e) => this.manage('worker',2)
        }
        ,
        {
          label: 'Worker 3',
          command: (e) => this.manage('worker',3)
        }
        ,
        {
          label: 'Worker 4',
          command: (e) => this.manage('worker',4)
        }
        ,
        {
          label: 'Worker 5',
          command: (e) => this.manage('worker',5)
        }
      ],
      },
     
    ];

    this.menuItems = [
     {
      label: 'Enable All',
      icon: 'fa fa-unlock-alt',
      command: (e) => this.manage('enableAll',true)
     },
     {
      label: 'Disable All',
      icon: 'fa fa-lock',
      command: (e) => this.manage('disableAll',true)
     }
     
    ];

    this.reload();


    setInterval(async ()=> { 
      //await  this._OrderMonitorService.getMonitor(this.searchModel).then(res => {
      //  this.model = res.data;
      //})
     }, 60*1000);


  }
async manage(operation,arg){

  if(operation=="worker"){
    let woker:BranchInvoiceingSetupModel={} as BranchInvoiceingSetupModel;
    
    woker.branchId=this.selected.branchId;
    woker.isEnabled=this.selected.isEnabled;
    woker.serviceWorkerId=arg;

    this.isLoading = true;
    this._commonCrudService.post("BranchInvoiceingSetup/Save", woker, BranchInvoiceingSetupModel).then(a=>{
      this.reload();
    })
  }
  if(operation=="enable"){
    let woker:BranchInvoiceingSetupModel={} as BranchInvoiceingSetupModel;
    
    woker.branchId=this.selected.branchId;
    woker.isEnabled=arg;
    woker.serviceWorkerId=this.selected.serviceWorkerId;

    this.isLoading = true;
    this._commonCrudService.post("BranchInvoiceingSetup/Save", woker, BranchInvoiceingSetupModel).then(a=>{
      this.reload();
    })
  }
  if(operation=='enableAll'){
    this.isLoading = true;
    this._commonCrudService.get("BranchInvoiceingSetup/enableAll", BranchInvoiceingSetupModel).then(a=>{
      this.reload();
    })
  }
  if(operation=='disableAll'){
    this.isLoading = true;
    this._commonCrudService.get("BranchInvoiceingSetup/disableAll", BranchInvoiceingSetupModel).then(a=>{
      this.reload();
    })
  }
}
  async reload() {
    this.isLoading = true;
    this._commonCrudService.post("OrderMonitor/getMonitor", this.searchModel, OrderMonitorModel).then(res => {
      console.log(res.data);
      this.model = res.data;
      this.isLoading = false;
    })
  }

  async clearFilter() {

    this.searchModel.branchId = 0;
    

    await this.reload();

  }
  async advancedFilter() {
    await this.reload();
  }
  async onSelectionChange(event) {
    //this.refreshMenu();
  }


  export(element) {
    const node = document.getElementById(element);

    //download the node as png. Image (2019-12-01).png
    saveAsPng(node);
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


}

