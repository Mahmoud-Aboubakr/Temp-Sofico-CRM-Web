import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { TranslateService } from '@ngx-translate/core';

import { AppMessageService } from 'src/app/core/services/AppMessage.Service';


import { BooleanService } from 'src/app/core/services/Boolean.Service';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { ChooserBranchComponent } from '../../shared/chooser-branch/chooser-branch.component';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';

import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';


import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { ChooserRepresentativeComponent } from '../../shared/chooser-representative/chooser-representative.component';
import { ChooserClientComponent } from '../../shared/chooser-client/chooser-client.component';

import { ClientTypeService } from 'src/app/core/services/ClientType.Service';
import { ServeyGroupService } from 'src/app/core/services/ServeyGroup.Service';
import { ServeyStatusService } from 'src/app/core/services/ServeyStatus.Service';
import { ClientActivitySearchModel } from 'src/app/core/Models/SearchModels/ClientActivitySearchModel';
import { ClientActivityService } from 'src/app/core/services/ClientActivity.Service';
import { ClientActivityListModel } from 'src/app/core/Models/ListModels/ClientActivityListModel';
import { ManageActivityComponent } from '../components/manage-activity/manage-activity.component';
import { MenuService } from 'src/app/core/services/Menu.Service';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-call-activites',
  templateUrl: './call-activites.component.html',
  styleUrls: ['./call-activites.component.scss']
})
export class CallActivitesComponent implements OnInit {

  gridModel: ResponseModel<ClientActivityListModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }


  inJourney: LookupModel[] = [];
  isPositive: LookupModel[] = [];


  searchModel: ClientActivitySearchModel  = {
    clientId: 0,
    branchId: 0,
    representativeId: 0,
    activityTimeFrom: undefined,
    activityTimeTo: undefined,
    callAgainFrom: undefined,
    callAgainTo: undefined,
    inJourney: 0,
    inZone: 0,
    isPositive: 0,
    activityTypeId: 2,
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    clientCode: '',
    branchCode: '',
    representativeCode: '',
    TermBy:""

  }

  advanced = false;
  isLoading = false;
  actions = false;

  first = 0;
  menuItems: MenuItem[];
  selected: ClientActivityListModel;


  CREATE_NEW_HEADER = '';
  EDIT_HEADER = '';
  CHOOSE = '';

  constructor(
    private _AppMessageService: AppMessageService,
    private _ClientActivityService: ClientActivityService,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _BooleanService: BooleanService,


    private _ClientTypeService: ClientTypeService,
    private _ServeyGroupService: ServeyGroupService,
    private _ServeyStatusService: ServeyStatusService,

    private _MenuService:MenuService,
    private _commonCrudService : CommonCrudService,
  ) {
    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Ad New Information').subscribe((res) => { this.CREATE_NEW_HEADER = res });
    this._translateService.get('Edit Information').subscribe((res) => { this.EDIT_HEADER = res });
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });

  }

  ngOnInit(): void {



    this.menuItems = [
      {
        label: 'Create',
        icon: 'pi pi-fw pi-plus',
        command: (e) => this.manage('n')
      },
      {
        label: 'View',
        icon: 'pi pi-fw pi-eye',
        visible: false,
        command: (e) => this.manage('e')
      },
      {
        label: 'Export',
        icon: 'pi pi-fw pi-file-excel',
        command: (e) => this.manage('x')
      },
    ];



    this._BooleanService.GetAll(localStorage.getItem("lan")).then(res=>{
      this.isPositive=res;
      this.inJourney=res;

    })

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

    await this._commonCrudService.post("ClientActivity/Filter", this.searchModel, ClientActivityListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._commonCrudService.post("ClientActivity/Filter", this.searchModel, ClientActivityListModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {

    this.selected = null;

    this.isLoading = true;
    await this._commonCrudService.post("ClientActivity/Filter", this.searchModel, ClientActivityListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.searchModel.Skip = 0;
    await this._commonCrudService.post("ClientActivity/Filter", this.searchModel, ClientActivityListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel = {
      clientId: 0,
      branchId: 0,
      representativeId: 0,
      activityTimeFrom: undefined,
      activityTimeTo: undefined,
      callAgainFrom: undefined,
      callAgainTo: undefined,
      inJourney: 0,
      inZone: 0,
      isPositive: 0,
      activityTypeId: 2,
      Take: 30,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: undefined,
      clientCode: '',
      branchCode: '',
      representativeCode: '',
      TermBy:""
    }
  }

  async onSelectionChange(event) {
    this.refreshMenu();
  }
  refreshMenu() {

    this.menuItems[1].visible = false;
    if (this.selected != null && this.selected.activityId > 0) {
      this.menuItems[1].visible = true;
    }
  }
  async manage(mode) {

    if (mode == 'n') {

      var ref = this.dialogService.open(ManageActivityComponent, {
        header: this.CREATE_NEW_HEADER,
        width: '400px',
        height: '720px',
        contentStyle: { "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe(() => {
        this.selected = null;
        this.reloadFilter();
        this.refreshMenu();
      });
    }

    if (mode == 'e') {
      if (this.selected != null && this.selected.activityId > 0) {
        var ref = this.dialogService.open(ManageActivityComponent, {
          header: this.EDIT_HEADER,
          data: { activityId: this.selected.activityId },
          width: '400px',
          height: '720px',
          contentStyle: { "overflow": "auto" },
          baseZIndex: 10000
        });
        ref.onClose.subscribe(() => {
          this.selected = null;
          this.reloadFilter();
          this.refreshMenu();
        });
      }
    }

    if (mode == 'x') {
      this.isLoading = true;
      await (this._commonCrudService.postFile("ClientActivity/Export",this.searchModel)).subscribe((data: any) => {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "Calls_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'')
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);


        this.isLoading = false;
      })
    }


  }




  choose_Branch() {
    var ref = this.dialogService.open(ChooserBranchComponent, {
      header: this.CHOOSE,
      width: '600px',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((res: BranchListModel) => {
      if (res) {
        this.searchModel.branchCode = res.branchCode;
        this.searchModel.branchId = res.branchId;

        this.searchModel.representativeCode = '';
        this.searchModel.representativeId = 0;
        this.searchModel.clientCode = '';
        this.searchModel.clientId = 0;

      }
    });
  }



  choose_Client() {
    var ref = this.dialogService.open(ChooserClientComponent, {
      header: this.CHOOSE,
      data:{branchId:this.searchModel.branchId},
      width: '90%',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((res: ClientListModel) => {
      if (res) {
        this.searchModel.clientCode = res.clientCode;
        this.searchModel.clientId = res.clientId;
      }
    });
  }
  choose_Representative() {
    var ref = this.dialogService.open(ChooserRepresentativeComponent, {
      header: this.CHOOSE,
      data:{branchId:this.searchModel.branchId},
      width: '1200px',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((res: RepresentativeListModel) => {
      if (res) {
        this.searchModel.representativeCode = res.representativeCode;
        this.searchModel.representativeId = res.representativeId;
      }
    });
  }

  clear_Client() {
    this.searchModel.clientCode = '';
    this.searchModel.clientId = 0;
  }

  clear_Representative() {
    this.searchModel.representativeCode = '';
    this.searchModel.representativeId = 0;
  }
  clear_Branch() {
    this.searchModel.branchCode = '';
    this.searchModel.branchId = 0;
    this.searchModel.representativeCode = '';
    this.searchModel.representativeId = 0;
    this.searchModel.clientCode = '';
    this.searchModel.clientId = 0;
  }


}
