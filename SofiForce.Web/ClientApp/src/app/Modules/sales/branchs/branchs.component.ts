import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { TranslateService } from '@ngx-translate/core';
import { BranchSearchModel } from 'src/app/core/Models/SearchModels/BranchSearchModel';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { SalesControlSupervisorComponent } from '../sales-control-supervisor/sales-control-supervisor.component';
import { SalesControlSearchModel } from 'src/app/core/Models/SearchModels/SalesControlSearchModel';
import { BranchModel } from 'src/app/core/Models/EntityModels/branchModel';
import { SupervisorModel } from 'src/app/core/Models/EntityModels/supervisorModel';
import { RepresentativeModel } from 'src/app/core/Models/EntityModels/representativeModel';
import { ClientModel } from 'src/app/core/Models/EntityModels/clientModel';
import { ManageBranchComponent } from '../components/manage-branch/manage-branch.component';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';
@Component({
  selector: 'app-branchs',
  templateUrl: './branchs.component.html',
  styleUrls: ['./branchs.component.scss']
})
export class BranchsComponent implements OnInit {

  gridModel: ResponseModel<BranchListModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }

  searchModel: BranchSearchModel = {
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
  selected: BranchListModel;


  MANAGE_HEADER = '';
  SHOW_STC = ''
  EDIT_HEADER=''
  constructor(
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private _AppMessageService: AppMessageService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _commonCrudService : CommonCrudService,
  ) {
    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Manage').subscribe((res) => { this.MANAGE_HEADER = res });
    this._translateService.get('Sales Control Statistcs').subscribe((res) => { this.SHOW_STC = res });
    this._translateService.get('Add / Edit Branch').subscribe((res) => { this.EDIT_HEADER = res });

  }

  ngOnInit(): void {

    

    this.menuItems = [
      {
        label: 'Create',
        icon: 'pi pi-fw pi-plus',
        command: (e) => this.manage('create')
      },
      {
        label: 'Edit',
        icon: 'pi pi-fw pi-copy',
        command: (e) => this.manage('edit')
      },
      {
        label: 'Delete',
        icon: 'pi pi-fw pi-copy',
        command: (e) => this.manage('delete')
      },
      {
        label: 'Sales Statistics',
        icon: 'pi pi-fw pi-chart-bar',
        command: (e) => this.manage('stc')
      },
      {
        label: 'Export',
        icon: 'pi pi-fw pi-cloud-download',
        command: (e) => this.manage('export')
      },
    ];


    this.refreshMenu();

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

    await this._commonCrudService.post("Branch/Filter", this.searchModel, BranchListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      this.selected=null;
      await this._commonCrudService.post("Branch/Filter", this.searchModel, BranchListModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {


    this.isLoading = true;
    this.selected=null;
    await this._commonCrudService.post("Branch/Filter", this.searchModel, BranchListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.searchModel.Skip = 0;
    this.selected=null;
    await this._commonCrudService.post("Branch/Filter", this.searchModel, BranchListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel = {
      Take: 30,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: undefined,
      TermBy:""
    }
  }

  async manage(operation) {

    if (operation == 'create') {
      var ref = this.dialogService.open(ManageBranchComponent, {
        header: this.EDIT_HEADER,
        width: '500px',
        contentStyle: { "max-height": "600px", "height": "600px", "overflow": "auto" },
        baseZIndex: 10000
      });

      ref.onClose.subscribe(() => {
        this.selected = null;
        this.reloadFilter();
        this.refreshMenu();
      });
    }

    if (operation == 'edit') {
      if(this.selected!=null && this.selected.branchId>0){
        var ref = this.dialogService.open(ManageBranchComponent, {
          data:{branchId:this.selected.branchId},
          header: this.EDIT_HEADER,
          width: '500px',
          contentStyle: { "max-height": "600px", "height": "600px", "overflow": "auto" },
          baseZIndex: 10000
        });
  
        ref.onClose.subscribe(() => {
          this.selected = null;
          this.reloadFilter();
          this.refreshMenu();
        });
      }
    }

    if (operation == 'delete') {
      if (this.selected != null && this.selected.branchId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {
            this.isLoading = true;
            let model = {} as BranchModel;
            model.branchId = this.selected.branchId;
            this._commonCrudService.post("Branch/Delete", model, BranchModel).then(res => {
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

    if (operation == 'stc') {

      let search: SalesControlSearchModel = {
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



      search.branchId = this.selected.branchId;
      search.branchCode = this.selected.branchCode;

      search.supervisorId = 0;
      search.supervisorCode = '';

      search.representativeId = 0;
      search.representativeCode = '';

      search.clientId = 0;
      search.clientCode = '';

      search.fromDate = new Date(new Date().getFullYear(), new Date().getMonth(), 1, new Date().getHours(), new Date().getMinutes(), new Date().getSeconds());
      search.toDate = new Date();

      console.log(search);
      
      var ref = this.dialogService.open(SalesControlSupervisorComponent, {
        data: {
          searchModel: search,
          pop: true,
        },
        header: this.SHOW_STC,
        modal: true,
        height: "90%"
      });
    }

    if (operation == 'export') {

      this.isLoading = true;
      await (this._commonCrudService.postFile("Branch/Export", this.searchModel)).subscribe((data: any) => {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "Branchs_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);


        this.isLoading = false;
      })
    }

    this.selected=null;
    this.refreshMenu();
  }
  onSelectionChange() {
    this.refreshMenu();
  }
  refreshMenu() {

    this.menuItems[1].visible = false;
    this.menuItems[2].visible = false;
    this.menuItems[3].visible = false;

    if (this.selected != null && this.selected.branchId > 0) {
      
      this.menuItems[1].visible = true;
      this.menuItems[2].visible = true;
      this.menuItems[3].visible = true;

    }
  }
}
