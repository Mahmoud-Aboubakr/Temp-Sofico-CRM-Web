import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';


import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { RouteSetupListModel } from 'src/app/core/Models/ListModels/RouteSetupListModel';
import { RouteSetupSearchModel } from 'src/app/core/Models/SearchModels/RouteSetupSearchModel';
import { RouteSetupService } from 'src/app/core/services/RouteSetup.Service';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { TranslateService } from '@ngx-translate/core';
import { RouteTypeService } from 'src/app/core/services/RouteType.Service';
import { ChooserBranchComponent } from '../../shared/chooser-branch/chooser-branch.component';
import { ManageRouteSetupComponent } from '../../crm/components/manage-route-setup/manage-route-setup.component';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { RouteSetupModel } from 'src/app/core/Models/EntityModels/RouteSetupModel';
@Component({
  selector: 'app-route-setup-list',
  templateUrl: './route-setup-list.component.html',
  styleUrls: ['./route-setup-list.component.scss']
})
export class RouteSetupListComponent implements OnInit {

  menu: MenuItem[];
  menuContext: MenuItem[];
  isLoading=false;
  model: ResponseModel<RouteSetupListModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: []
  };

  selected={} as RouteSetupListModel;

  searchModel: RouteSetupSearchModel = {
    branchId: 0,
    routeTypeId: 0,
    branchCode: '',
    routeTypeCode: '',
    isActive: 0,
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    TermBy:""

  }

  advanced=false;
  first=0;
  routeTypes:LookupModel[]=[];
  CHOOSE='';
  MANAGE='';

  constructor(
    private _RouteSetupService: RouteSetupService,
    private ref: DynamicDialogRef, 
    private _translateService: TranslateService,
    private messageService: MessageService,
    private config: DynamicDialogConfig,
    private dialogService: DialogService,
    private _RouteTypeService: RouteTypeService,
    private confirmationService: ConfirmationService,
    private _AppMessageService: AppMessageService,
    private _translationLoaderService: TranslationLoaderService,) { 
    this._translationLoaderService.loadTranslations(english, arabic);

    if (this.config.data) {
        this.searchModel= this.config.data.searchModel;
    }


    this.menuContext = [
      {
        label: 'Manage',
        icon: 'fa fa-pencil',
        command: (e) => this.manage('edit')
      },
      {
        label: 'Delete ',
        icon: 'fa fa-times',
        command: (e) => this.manage('delete')
      },
    ];

    this.menu = [
      {
        label: 'Add',
        icon: 'fa fa-pencil',
        command: (e) => this.manage('add')
      },
      {
        separator:true,
      },
      {
        label: 'Export ',
        icon: 'fa fa-times',
        command: (e) => this.manage('export')
      },
    ];
  }

  async ngOnInit() {
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });
    this._translateService.get('Manage').subscribe((res) => { this.MANAGE = res });

    this._RouteTypeService.GetAll().then(res => {
      this.routeTypes = res.data;
      this.routeTypes.unshift({id:0,name:'--',code:'0'});
    })
  }

  async filter(event) {
    console.log(event);
    this.isLoading = true;
    this.searchModel.Skip = event.first;



    if (event.sortField) {
      this.searchModel.SortBy.Property = event.sortField;
      if (event.sortOrder == 1) {
        this.searchModel.SortBy.Order = "asc";
      }
      else {
        this.searchModel.SortBy.Order = "desc";

      }
    }

    await this._RouteSetupService.Filter(this.searchModel).then(res => {
      this.model = res;
      this.isLoading = false;
      if(this.model.succeeded==false){
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Internal Server Error , call system administrator' });
      }
    })

   
  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first=0;
      this.searchModel.Skip=0;
      this.isLoading = true;
      await this._RouteSetupService.Filter(this.searchModel).then(res => {
        this.model = res;
        this.isLoading = false;
      })
    }

  }

  async advancedFilter() {
    this.isLoading = true;
    this.first=0;
    this.searchModel.Skip=0;

    await this._RouteSetupService.Filter(this.searchModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })

   
  }
  async advancedClear() {
    this.first=0;
    this.isLoading = true;
    await this._RouteSetupService.Filter(this.searchModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })

   
  }
  async onRowDblClick(e,data){
    if(data){
      this.manage("edit");
    }
  }

  Chooser_Branch() {
    var ref = this.dialogService.open(ChooserBranchComponent, {
      header: this.CHOOSE,
      width: '400px',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((re) => {
      this.searchModel.branchCode = re.branchCode;
      this.searchModel.branchId = re.branchId;
    });
  }
  Clear_Branch(){
    this.searchModel.branchCode = '';
    this.searchModel.branchId = 0;
  }

  async manage(operation){
    
    if(operation=='add'){
      var ref = this.dialogService.open(ManageRouteSetupComponent, {
        header: this.MANAGE,
        width: '400px',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });
      ref.onClose.subscribe((re) => {
       this.advancedFilter();
      });
    }

    if(operation=='edit'){
      if(this.selected.routeId>0){
        var ref = this.dialogService.open(ManageRouteSetupComponent, {
          header: this.MANAGE,
          data:{routeId:this.selected.routeId},
          width: '400px',
          contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
          baseZIndex: 10000
        });
        ref.onClose.subscribe((re) => {
         this.advancedFilter();
        });
      }

    }

    if (operation == 'delete') {

      if (this.selected != null && this.selected.routeId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {


            this.isLoading = true;
            let model = {} as RouteSetupModel;
            model.routeId = this.selected.routeId;
            this._RouteSetupService.Delete(model).then(res => {
              this.advancedFilter();
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

    if(operation=='export'){
      this.isLoading=true;
      await (this._RouteSetupService.Export(this.searchModel)).subscribe((data:any)=> {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "Routes_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);

       
        this.isLoading=false;
      })
    }

  }

}
