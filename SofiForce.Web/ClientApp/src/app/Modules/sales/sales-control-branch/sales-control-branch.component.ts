import { Component, OnInit } from '@angular/core';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { DialogService } from 'primeng/dynamicdialog';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { FormatterService } from 'src/app/core/services/Formatter.service';
import { SalesControlSearchModel } from 'src/app/core/Models/SearchModels/SalesControlSearchModel';

import { SalesBranchControlDetailModel, SalesBranchControlModel } from 'src/app/core/Models/StatisticalModels/SalesBranchControlModel';
import { SalesControlService } from 'src/app/core/services/SalesControl.Service';


import { saveAsPng } from 'save-html-as-image';
import { ChooserBranchComponent } from '../../shared/chooser-branch/chooser-branch.component';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { SalesControlSupervisorComponent } from '../sales-control-supervisor/sales-control-supervisor.component';
import { MenuService } from 'src/app/core/services/Menu.Service';
import { UserModel } from 'src/app/core/Models/DtoModels/UserModel';
import { UserService } from 'src/app/core/services/User.Service';

@Component({
  selector: 'app-sales-control-branch',
  templateUrl: './sales-control-branch.component.html',
  styleUrls: ['./sales-control-branch.component.scss']
})
export class SalesControlBranchComponent implements OnInit {

  model: ResponseModel<SalesBranchControlModel> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: {
      callAll: 0,
      callNegative: 0,
      callPercentage: 0,
      callPostitive: 0,
      clientAll: 0,
      clientCoverage: 0,
      orders: 0,
      perormanceLabel: '',
      perormancePercentage: 0,
      salesControlDetails: [],
      salesDate: new Date(),
      salesDays: 0,
      salesPercentage: 0,
      salesValue: 0,
      targetCall: 0,
      targetValue: 0,
      targetVisit: 0,
      visitAll: 0,
      visitNegative: 0,
      visitPercentage: 0,
    } as SalesBranchControlModel

  };
  searchModel: SalesControlSearchModel = {
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
  selected: SalesBranchControlDetailModel;
  advanced = false;
  isLoading = true;
  menuItems: MenuItem[];


  CHOOSE_BRANCH = '';
  SHOW_SUPERVISOR = '';
  current: UserModel;
  pop = false;
  showSTC = true;
  constructor(
    private _FormatterService: FormatterService,
    private _SalesControlService: SalesControlService,
    private _translationLoaderService: TranslationLoaderService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _AppMessageService: AppMessageService,
    private _MenuService: MenuService,
    private _user: UserService,
  ) {
    this.current = _user.Current();
    this._translationLoaderService.loadTranslations(english, arabic);


    this.searchModel.branchId = 0;
    this.searchModel.branchCode = '';

    this.searchModel.supervisorId = 0;
    this.searchModel.supervisorCode = '';

    this.searchModel.representativeId = 0;
    this.searchModel.representativeCode = '';

    this.searchModel.clientId = 0;
    this.searchModel.clientCode = '';

    this.searchModel.fromDate = new Date();
    this.searchModel.toDate = new Date();

    console.log(this.searchModel);



  }

  ngOnInit(): void {


    this._translateService.get('Choose Branch').subscribe((res) => { this.CHOOSE_BRANCH = res });

    this._translateService.get('Supervisors Details').subscribe((res) => { this.SHOW_SUPERVISOR = res });


    this.reload();


  }
  hideSTC() {
    this.showSTC = !this.showSTC;
  }
  async reload() {
    this.isLoading = true;
    this._SalesControlService.getBranch(this.searchModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {

    this.searchModel.branchId = 0;
    this.searchModel.branchCode = '';
    this.searchModel.supervisorId = 0;
    this.searchModel.supervisorCode = '';

    this.searchModel.representativeId = 0;
    this.searchModel.representativeCode = '';

    this.searchModel.clientId = 0;
    this.searchModel.clientCode = '';

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
  async exportExcel() {
    this.isLoading = true;
    await (this._SalesControlService.branchExport(this.searchModel)).subscribe((data: any) => {

      console.log(data);

      const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      const a = document.createElement('a');
      a.setAttribute('style', 'display:none;');
      document.body.appendChild(a);
      a.download = "BranchSales_" + new Date().toISOString().split('.')[0].replace(/[^\d]/gi, '');
      a.href = URL.createObjectURL(downloadedFile);
      a.target = '_blank';
      a.click();
      document.body.removeChild(a);


      this.isLoading = false;
    })
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


  showSupervisors(branchId) {


    let mySearch: SalesControlSearchModel = {
      Take: this.searchModel.Take,
      Skip: this.searchModel.Skip,
      Term: this.searchModel.Term,
      FilterBy: this.searchModel.FilterBy,
      SortBy: this.searchModel.SortBy,
      branchId: branchId,
      supervisorId: this.searchModel.supervisorId,
      representativeId: this.searchModel.representativeId,
      fromDate: this.searchModel.fromDate,
      toDate: this.searchModel.toDate,
      branchCode: this.searchModel.branchCode,
      supervisorCode: this.searchModel.supervisorCode,
      representativeCode: this.searchModel.representativeCode,
      clientId: this.searchModel.clientId,
      clientCode: this.searchModel.clientCode,
      TermBy:"",
    };

    var ref = this.dialogService.open(SalesControlSupervisorComponent, {
      data: {
        searchModel: mySearch,
        pop: true,
      },
      header: this.SHOW_SUPERVISOR,
      width: '95%',
      modal: true,
      contentStyle: { "max-height": "100vh", "height": "100vh", "overflow": "auto" },
      baseZIndex: 10000
    });


  }

  getTotals(col){
    if(!this.model.data.salesControlDetails){
      return 0;
    }
    
    if(col=='sales'){
      return this.model.data.salesControlDetails.
                        reduce((sum, current) => sum + current.salesValue, 0); 
    }
    if(col=='target'){
      return this.model.data.salesControlDetails.
                        reduce((sum, current) => sum + current.targetValue, 0); 
    }
    if(col=='visits'){
      return this.model.data.salesControlDetails.
                        reduce((sum, current) => sum + current.visitAll, 0); 
    }
    if(col=='visitstarget'){
      return this.model.data.salesControlDetails.
                        reduce((sum, current) => sum + current.targetVisit, 0); 
    }

    if(col=='calls'){
      return this.model.data.salesControlDetails.
                        reduce((sum, current) => sum + current.callAll, 0); 
    }

    if(col=='callstarget'){
      return this.model.data.salesControlDetails.
                        reduce((sum, current) => sum + current.targetCall, 0); 
    }

    if(col=='client'){
      return this.model.data.salesControlDetails.
                        reduce((sum, current) => sum + current.clientAll, 0); 
    }

    
    if(col=='coverage'){
      return this.model.data.salesControlDetails.
                        reduce((sum, current) => sum + current.clientCoverage, 0); 
    }

    if(col=='order'){
      return this.model.data.salesControlDetails.
                        reduce((sum, current) => sum + current.orders, 0); 
    }
    
  }
}
