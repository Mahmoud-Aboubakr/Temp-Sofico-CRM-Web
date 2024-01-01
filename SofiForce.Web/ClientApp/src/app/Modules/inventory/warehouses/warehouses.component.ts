import { Component, OnInit } from '@angular/core';
import { MenuItem, MessageService } from 'primeng/api';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';


import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { StoreListModel } from 'src/app/core/Models/ListModels/StoreListModel';
import { StoreSearchModel } from 'src/app/core/Models/SearchModels/StoreSearchModel';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-warehouses',
  templateUrl: './warehouses.component.html',
  styleUrls: ['./warehouses.component.scss']
})
export class WarehousesComponent implements OnInit {

  gridModel: ResponseModel<StoreListModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: []
  };

  selected={} as StoreListModel;

  searchModel: StoreSearchModel = {
    branchId: 0,
    branchCode: '',
    storeTypeId: 0,
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    isActive: 0,
    isOrder: 0,
    storeMode: 0,
    TermBy:""
  }

  advanced=false;
  isLoading = false;
  first=0;

  menuItems: MenuItem[];
  constructor(
    private ref: DynamicDialogRef, 
    private messageService: MessageService,
    private config: DynamicDialogConfig,
    private _translationLoaderService: TranslationLoaderService,
    private _commonCrudService : CommonCrudService,
    ) { 
    this._translationLoaderService.loadTranslations(english, arabic);



  }

  async ngOnInit() {

    this.menuItems = [
      {
        label: 'Create',
        icon: 'pi pi-fw pi-plus',
        command: (e) => this.manage('n')
      },
      {
        label: 'Edit',
        icon: 'pi pi-fw pi-pencil',
        visible: false,
        command: (e) => this.manage('e')
      },
      {
        label: 'Delete',
        icon: 'pi pi-fw pi-times',
        visible: false,
        command: (e) => this.manage('d')
      },
      {
        label: 'Statistics',
        icon: 'pi pi-fw pi-chart-line',
        visible: false,
        command: (e) => this.manage('s')

      },
      {
        label: 'Export',
        icon: 'pi pi-fw pi-file-excel',
        command: (e) => this.manage('x')
      },
    ];
  }

  async filter(event) {
    console.log(event);
    this.isLoading = true;
    this.searchModel.Skip = event.first;
    this.searchModel.Take = event.rows;


    if (event.sortField) {
      this.searchModel.SortBy.Property = event.sortField;
      if (event.sortOrder == 1) {
        this.searchModel.SortBy.Order = "asc";
      }
      else {
        this.searchModel.SortBy.Order = "desc";

      }
    }

    await this._commonCrudService.post("Store/Filter",this.searchModel,StoreListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
      if(this.gridModel.succeeded==false){
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Internal Server Error , call system administrator' });
      }
    })
    
  }


  async reloadFilter() {

    this.selected = null;

    this.isLoading = true;
    await this._commonCrudService.post("Store/Filter",this.searchModel,StoreListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.searchModel.Skip = 0;
    await this._commonCrudService.post("Store/Filter",this.searchModel,StoreListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel = {
      branchId: 0,
      branchCode: '',
      storeTypeId: 0,
      Take: 30,
      Skip: 0,
      Term: '',
      FilterBy: [],
      SortBy: undefined,
      isActive: 0,
      isOrder: 0,
      storeMode: 0,
      TermBy:""
    }
  }

  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._commonCrudService.post("Store/Filter",this.searchModel,StoreListModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }
  onRowDblClick(e,data){
    this.manage('e');
  }

  async manage(operation){

  }

  async onSelectionChange(event) {
    this.refreshMenu();
  }
  refreshMenu(){
    
    this.menuItems[1].visible = false;
    this.menuItems[2].visible = false;
    this.menuItems[3].visible = false;

    if (this.selected != null && this.selected.storeId>0) {
      this.menuItems[1].visible = true;
      this.menuItems[2].visible = true;
      this.menuItems[3].visible = true;
    }
  }

}
