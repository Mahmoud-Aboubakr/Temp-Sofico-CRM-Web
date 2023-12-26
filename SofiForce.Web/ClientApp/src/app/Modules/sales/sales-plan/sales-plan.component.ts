import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { TranslateService } from '@ngx-translate/core';

import { ChooserClientComponent } from '../../shared/chooser-client/chooser-client.component';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { ChooserBranchComponent } from '../../shared/chooser-branch/chooser-branch.component';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { ClientPlanService } from 'src/app/core/services/ClientPlan.Service';
import { ClientPlanListModel } from 'src/app/core/Models/ListModels/ClientPlanListModel';
import { ClientPlanSearchModel } from 'src/app/core/Models/SearchModels/ClientPlanSearchModel';
import { ClientPlanClearModel } from 'src/app/core/Models/DtoModels/ClientPlanClearModel';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { ManageSalesPlanCustomComponent } from '../components/manage-sales-plan-custom/manage-sales-plan-custom.component';
import { ClientPlanModel } from 'src/app/core/Models/EntityModels/ClientPlanModel';
import { ManageSalesPlanComponent } from '../components/manage-sales-plan/manage-sales-plan.component';
import { MenuService } from 'src/app/core/services/Menu.Service';
import { CommonCrudService } from 'src/app/core/services/CommonCrud.service';
import { ClientPlanDuplicateModel } from 'src/app/core/Models/DtoModels/ClientPlanDuplicateModel';

@Component({
  selector: 'app-sales-plan',
  templateUrl: './sales-plan.component.html',
  styleUrls: ['./sales-plan.component.scss']
})
export class SalesPlanComponent implements OnInit {


  gridModel: ResponseModel<ClientPlanListModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }

  searchModel: ClientPlanSearchModel = {
    clientId: 0,
    clientCode: '',
    branchId: 0,
    branchCode: '',
    clientTypeId: 0,
    fromDate: new Date(),
    toDate: new Date(),
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    TermBy:""

  }

  advanced = false;
  isLoading = false;
  first = 0;
  items: MenuItem[];
  menuItems: MenuItem[];
  selected: ClientPlanListModel;

  clearModel: ClientPlanClearModel = {
    clearDate: new Date()
  };


  MANAGE_PLAN_HEADER = '';
  GERNEY_STC_HEADER = '';


  CHOOSE_BRANCH = '';
  CHOOSE_CLIENT = '';

  constructor(
    private _AppMessageService: AppMessageService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _ClientPlanService: ClientPlanService,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private _MenuService:MenuService,
    private _commonCrudService : CommonCrudService,
  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Create Sales Plan').subscribe((res) => { this.MANAGE_PLAN_HEADER = res });
    this._translateService.get('Sales Plan Statistics').subscribe((res) => { this.GERNEY_STC_HEADER = res });

    this._translateService.get('Choose Branch').subscribe((res) => { this.CHOOSE_BRANCH = res });
    this._translateService.get('Choose Client').subscribe((res) => { this.CHOOSE_CLIENT = res });



  }

  ngOnInit(): void {


    this.menuItems = [
      {
        label: 'Upload',
        icon: 'pi pi-fw pi-upload',
        command: (event) => this.Manage('upload'),
      },
      {
        label: 'Delete All Data',
        icon: 'pi pi-fw pi-times',
        command: (event) => this.Manage('clear'),
      },
      {
        label: 'Template',
        icon: 'pi pi-fw pi-cloud-download',
        command: (event) => this.Manage('template'),
      },
    ];

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

    await this._commonCrudService.post("ClientPlan/filter", this.searchModel, ClientPlanListModel).then(res => {
      // await this._ClientPlanService.Filter(this.searchModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._commonCrudService.post("ClientPlan/filter", this.searchModel, ClientPlanListModel).then(res => {
        // await this._ClientPlanService.Filter(this.searchModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {

    this.selected=null;

    this.isLoading = true;
    await this._commonCrudService.post("ClientPlan/filter", this.searchModel, ClientPlanListModel).then(res => {
      // await this._ClientPlanService.Filter(this.searchModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.searchModel.Skip = 0;
    await this._commonCrudService.post("ClientPlan/filter", this.searchModel, ClientPlanListModel).then(res => {
      // await this._ClientPlanService.Filter(this.searchModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel = {
      clientId: 0,
      clientCode: '',
      branchId: 0,
      branchCode: '',
      clientTypeId: 0,
      fromDate: new Date(),
      toDate: new Date(),
      Take: 30,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: undefined,
    TermBy:""

    }

  }


  async Manage(operation) {

    if (operation == 'upload') {
      var ref = this.dialogService.open(ManageSalesPlanComponent, {
        header: this.MANAGE_PLAN_HEADER,
        width: '400px',
        contentStyle: { "max-height": "600px", "height": "600px", "overflow": "auto" },
        baseZIndex: 10000
      });


      ref.onClose.subscribe(() => {
        this.reloadFilter();

      });
    }

    if (operation == 'add') {
      var ref = this.dialogService.open(ManageSalesPlanCustomComponent, {
        header: this.MANAGE_PLAN_HEADER,
        width: '400px',
        contentStyle: { "max-height": "600px", "height": "600px", "overflow": "auto" },
        baseZIndex: 10000
      });


      ref.onClose.subscribe(() => {
        this.reloadFilter();

      });
    }
    if (operation == 'edit') {
      if (this.selected && this.selected.planId > 0) {
        var ref = this.dialogService.open(ManageSalesPlanCustomComponent, {
          data: { planId: this.selected.planId },
          header: this.MANAGE_PLAN_HEADER,
          width: '400px',
          contentStyle: { "max-height": "600px", "height": "600px", "overflow": "auto" },
          baseZIndex: 10000
        });


        ref.onClose.subscribe(() => {
          this.reloadFilter();

        });
      }

    }
    if (operation == 'delete') {
      if (this.selected != null && this.selected.planId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {


            this.isLoading = true;
            let model = {} as ClientPlanModel;
            model.planId = this.selected.planId;
            this._commonCrudService.post("ClientPlan/Delete", model, ClientPlanModel).then(res => {
              // this._ClientPlanService.Delete(model).then(res => {
              this.advancedFilter();
              this.refreshMenu();
              this.isLoading = false;

              if (res.succeeded == true) {
                this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });
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
    }
    if (operation == 'duplicate') {
      this.isLoading = true;
      this._commonCrudService.post("ClientPlan/Duplicate", this.clearModel, ClientPlanDuplicateModel).then(res => {
        // this._ClientPlanService.Duplicate(this.clearModel).then(res => {
        this.advancedFilter();
        this.isLoading = false;
      })
    }
    if (operation == 'clear') {
      this.isLoading = true;
      this._commonCrudService.post("ClientPlan/Clear", this.clearModel, ClientPlanClearModel).then(res => {
        // this._ClientPlanService.Clear(this.clearModel).then(res => {
        this.advancedFilter();
        this.isLoading = false;
      })
    }
    if (operation == 'template') {
      this.isLoading = true;

       (await this._commonCrudService.getFile("ClientPlan/template")).subscribe((data: any) => {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "TargetTemplate_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);


        this.isLoading = false;
      })
    }
    if (operation == 'download') {
      this.isLoading = true;
      (await this._ClientPlanService.Download(this.searchModel)).subscribe((data: any) => {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "CuurentTarget_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);


        this.isLoading = false;
      })
    }
    this.refreshMenu();
  }

  async onSelectionChange(event) {
    this.refreshMenu();
  }
  refreshMenu() {

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

        this.searchModel.branchId = branch.branchId;
        this.searchModel.branchCode = branch.branchCode;

        this.searchModel.clientId = 0;
        this.searchModel.clientCode = '';
      }
    });
  }
  clear_Branch() {
    this.searchModel.branchId = 0;
    this.searchModel.branchCode = '';

    this.searchModel.clientId = 0;
    this.searchModel.clientCode = '';
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

        this.searchModel.clientId=client.clientId;
        this.searchModel.clientCode = client.clientCode;

      }
    });
  }

  clear_Client() {

    this.searchModel.clientId=0;
    this.searchModel.clientCode = '';
  }

}
