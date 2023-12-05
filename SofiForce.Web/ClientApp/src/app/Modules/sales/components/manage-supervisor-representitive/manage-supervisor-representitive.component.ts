import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig } from 'primeng/dynamicdialog';
import { BranchModel } from 'src/app/core/Models/EntityModels/branchModel';
import { SupervisorModel } from 'src/app/core/Models/EntityModels/supervisorModel';
import { RepresentativeListModel } from 'src/app/core/Models/ListModels/RepresentativeListModel';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { RepresentativeSearchModel } from 'src/app/core/Models/SearchModels/RepresentativeSearchModel';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { SupervisorService } from 'src/app/core/services/Supervisor.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { ChooserRepresentativeComponent } from 'src/app/Modules/shared/chooser-representative/chooser-representative.component';
import { RepresentativeService } from 'src/app/core/services/Representative.Service';

@Component({
  selector: 'app-manage-supervisor-representitive',
  templateUrl: './manage-supervisor-representitive.component.html',
  styleUrls: ['./manage-supervisor-representitive.component.scss']
})
export class ManageSupervisorRepresentitiveComponent implements OnInit {


  isLoading = true;

  model: SupervisorModel = {} as SupervisorModel;
  gridModel: ResponseModel<RepresentativeListModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }

  searchModel: RepresentativeSearchModel = {
    supervisorId: 0,
    supervisorCode: '',
    branchId: 0,
    branchCode: '',
    representativeName: '',
    terminationDate: undefined,
    joinDate: undefined,
    phone: '',
    kindId: 0,
    kindIds:'',
    isActive: 0,
    isTerminated: 0,
    terminationReasonId: 0,
    Take: 30,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    searchMode:0,
    businessUnitId:0,
    companyCode:'',
    TermBy:""

  }
  selected:RepresentativeListModel={} as RepresentativeListModel;
  first=0;

  CREATE_NEW_HEADER = '';
  EDIT_HEADER = '';
  MANAGE_REPRESENTITVE_HEADER = '';
  CHOOSE_REPRESENTITIVE = '';

  constructor(
    private _AppMessageService: AppMessageService,
    private _SupervisorService: SupervisorService,
    private _RepresentativeService:RepresentativeService,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private config: DynamicDialogConfig,
  ) {
    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Ad New Information').subscribe((res) => { this.CREATE_NEW_HEADER = res });
    this._translateService.get('Edit Information').subscribe((res) => { this.EDIT_HEADER = res });
    this._translateService.get('Manage Representitive').subscribe((res) => { this.MANAGE_REPRESENTITVE_HEADER = res });
    this._translateService.get('Select Representitive').subscribe((res) => { this.CHOOSE_REPRESENTITIVE = res });


  }

  ngOnInit(): void {


    if (this.config.data) {
      this.searchModel.supervisorId=+this.config.data.supervisorId;

       this._RepresentativeService.Filter(this.searchModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })

    }
  }

  async filter(event) {
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

    if (this.config.data) {
      this.isLoading = true;
      this.searchModel.supervisorId=+this.config.data.supervisorId;
       this._RepresentativeService.Filter(this.searchModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }

  async addNew(){
    var ref = this.dialogService.open(ChooserRepresentativeComponent, {
      header: this.CHOOSE_REPRESENTITIVE,
      width: '1000px',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe(async (sel) => {
      this.selected = null;
      if(sel!=null){
        // add to suppervisor
        this.isLoading = true;
        await this._RepresentativeService.getById(sel.representativeId).then(async res=>{
          if(res.succeeded==true){
            res.data.supervisorId=+this.config.data.supervisorId;
            await this._RepresentativeService.Save(res.data).then(res=>{
              this._RepresentativeService.Filter(this.searchModel).then(res => {
                this.gridModel = res;
                this.isLoading = false;
              });
            })
          }
          else
          {
            this.isLoading = false;
          }
        })
      }
    });
  }

  async remove(){
    if (this.selected != null && this.selected.supervisorId > 0) {
      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {
          this.isLoading = true;
          await this._RepresentativeService.getById(this.selected.representativeId).then(async res=>{
            if(res.succeeded==true){
              res.data.supervisorId=null;
              await this._RepresentativeService.Save(res.data).then(res=>{
                this._RepresentativeService.Filter(this.searchModel).then(res => {
                  this.gridModel = res;
                  this.isLoading = false;
                });
              })
            }
            else
            {
              this.isLoading = false;
            }
          })
        },
        reject: () => {
          //reject action
        }
      });

    }

  }



  async export()
  {
    this.isLoading=true;
    await (this._RepresentativeService.Export(this.searchModel)).subscribe((data:any)=> {


      const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      const a = document.createElement('a');
      a.setAttribute('style', 'display:none;');
      document.body.appendChild(a);
      a.download = "SupervisorRepresentitive_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
      a.href = URL.createObjectURL(downloadedFile);
      a.target = '_blank';
      a.click();
      document.body.removeChild(a);

     
      this.isLoading=false;
    })
  }

}
