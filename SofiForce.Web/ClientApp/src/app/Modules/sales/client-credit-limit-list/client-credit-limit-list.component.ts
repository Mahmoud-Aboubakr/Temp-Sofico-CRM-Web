import { Component, OnInit } from '@angular/core';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { ManageJourneyPlanComponent } from '../components/manage-journey-plan/manage-journey-plan.component';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { TranslateService } from '@ngx-translate/core';
import { JourneyClearModel } from 'src/app/core/Models/DtoModels/JourneyClearModel';
import { ChooserClientComponent } from '../../shared/chooser-client/chooser-client.component';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { ChooserBranchComponent } from '../../shared/chooser-branch/chooser-branch.component';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { MenuService } from 'src/app/core/services/Menu.Service';
import { ClientCreditLimitListModel } from 'src/app/core/Models/ListModels/ClientCreditLimitListModel';
import { ClientCreditLimitSearchModel } from 'src/app/core/Models/SearchModels/ClientCreditLimitSearchModel';
import { ClientCreditLimitService } from 'src/app/core/services/ClientCreditLimit.Service';
import { UploaderService } from 'src/app/core/services/uploader.service';
import { JourneyUploadModel } from 'src/app/core/Models/DtoModels/JourneyUploadModel';
import { UploadModel } from 'src/app/core/Models/DtoModels/UploadModel';
import { ThirdPartyDraggable } from '@fullcalendar/interaction';
import { ClientCreditLimitModel } from 'src/app/core/Models/EntityModels/ClientCreditLimitModel';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-client-credit-limit-list',
  templateUrl: './client-credit-limit-list.component.html',
  styleUrls: ['./client-credit-limit-list.component.scss']
})
export class ClientCreditLimitListComponent implements OnInit {

  gridModel: ResponseModel<ClientCreditLimitListModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }

  searchModel: ClientCreditLimitSearchModel = {
    limitYear: 0,
    limitMonth: 0,
    clientId: 0,
    branchId: 0,
    Take: 30,
    Skip: 0,
    Term: '',
    TermBy: '',
    FilterBy: [],
    SortBy: undefined,
    clientCode: '',
    branchCode: ''
  }

  advanced = false;
  isLoading = false;
  isUploadDone = false;
  showUpload = false;
  first = 0;
  items: MenuItem[];
  menuItems: MenuItem[];
  cMenuItems: MenuItem[];

  selected: ClientCreditLimitListModel;

  clearModel: JourneyClearModel = {
    clearDate: new Date()
  };
  model: UploadModel = {
    filePath: '',
  };

  CHOOSE = '';
  MANAGE = '';

  constructor(
    private _AppMessageService: AppMessageService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _ClientCreditLimitService: ClientCreditLimitService,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private uploaderService: UploaderService,

    private _MenuService: MenuService,
    private _commonCrudService : CommonCrudService,
    ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Manage').subscribe((res) => { this.MANAGE = res });
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });


  }

  ngOnInit(): void {


    this.menuItems = [
      {
        label: 'Upload',
        icon: 'pi pi-fw pi-upload',
        command: (event) => this.Manage('upload'),
      },
      {
        label: 'Template',
        icon: 'pi pi-fw pi-cloud-download',
        command: (event) => this.Manage('template'),
      },
      {
        label: 'Download',
        icon: 'pi pi-fw pi-cloud-download',
        command: (event) => this.Manage('download'),
      },
      {
        separator: true
      },
      {
        label: 'Clear Month',
        icon: 'pi pi-fw pi-times',
        command: (event) => this.Manage('clear'),
      },
    ];


    this.cMenuItems = [
      {
        label: 'Delete',
        icon: 'pi pi-fw pi-times',
        command: (event) => this.Manage('delete'),
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

    await this._commonCrudService.post("ClientCreditLimit/filter", this.searchModel, ClientCreditLimitListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._commonCrudService.post("ClientCreditLimit/filter", this.searchModel, ClientCreditLimitListModel).then(res => {
        this.gridModel = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {


    this.selected = null;

    this.isLoading = true;
    await this._commonCrudService.post("ClientCreditLimit/filter", this.searchModel, ClientCreditLimitListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    this.first = 0;
    this.searchModel.Skip = 0;
    await this._commonCrudService.post("ClientCreditLimit/filter", this.searchModel, ClientCreditLimitListModel).then(res => {
      this.gridModel = res;
      this.isLoading = false;
    })
  }

  async clearFilter() {
    this.searchModel = {

      limitYear: 0,
      limitMonth: 0,
      clientId: 0,
      branchId: 0,
      Take: 30,
      Skip: 0,
      Term: '',
      TermBy: '',
      FilterBy: [],
      SortBy: undefined,
      clientCode: '',
      branchCode: ''
    }



  }


  async Manage(operation) {

    if (operation == 'upload') {
      this.showUpload = true;
      this.isUploadDone = false;
      this.model.filePath = '';
    }


    if (operation == 'clear') {
      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {

          this.isLoading = true;
          this._commonCrudService.post("ClientCreditLimit/deleteAll", this.clearModel, ClientCreditLimitSearchModel).then(res => {
            this.advancedFilter();
            this.isLoading = false;
          })

        },
        reject: () => {
          //reject action
        }
      });
    }
    if (operation == 'delete') {

      if (this.selected != null && this.selected.limitId > 0) {
        this.confirmationService.confirm({
          message: this._AppMessageService.MESSAGE_CONFIRM,
          accept: async () => {


            this.isLoading = true;
            let model = {} as ClientCreditLimitModel;
            model.limitId = this.selected.limitId;
            this._commonCrudService.post("ClientCreditLimit/Delete", model, ClientCreditLimitModel).then(res => {
              if (res.succeeded == true) {
                this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });
              }
              else {
                this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
              }
              
              this.advancedFilter();
              this.isLoading = false;

              
            })
          },
          reject: () => {
            //reject action
          }
        });
      }
    }
    if (operation == 'template') {
      this.isLoading = true;
      (await this._commonCrudService.getFile("ClientCreditLimit/template")).subscribe((data: any) => {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "SalesLimitTemplate";
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);


        this.isLoading = false;
      })
    }
    if (operation == 'download') {
      this.isLoading = true;
      (await this._commonCrudService.postFile("ClientCreditLimit/Download", this.searchModel)).subscribe((data: any) => {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "SalesLimit_" + new Date().toISOString().split('.')[0].replace(/[^\d]/gi, '');
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);


        this.isLoading = false;
      })
    }
    if (operation == 'stc') {
      this.isLoading = true;
      (await this._commonCrudService.getFile("ClientCreditLimit/missing")).subscribe((data: any) => {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "MissingRepresentatives_" + new Date().toISOString().split('.')[0].replace(/[^\d]/gi, '');
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
      header: this.CHOOSE,
      width: '600px',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((branch: BranchListModel) => {
      if (branch) {
        this.searchModel.branchCode = branch.branchCode;
        this.searchModel.branchId = branch.branchId;

        this.searchModel.clientId = 0;
        this.searchModel.clientCode = '';

      }
    });
  }
  clear_Branch() {
    this.searchModel.branchCode = '';
    this.searchModel.branchId = 0;

    this.searchModel.clientId = 0;
    this.searchModel.clientCode = '';
  }




  choose_Client() {
    var ref = this.dialogService.open(ChooserClientComponent, {
      header: this.CHOOSE,
      width: '1200px',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((obj: ClientListModel) => {
      if (obj) {


        this.searchModel.clientId = obj.clientId;
        this.searchModel.clientCode = obj.clientCode;


      }
    });
  }

  clear_Client() {
    this.searchModel.clientId = 0;
    this.searchModel.clientCode = '';
  }

  myUploader(event, form) {

    this.isLoading = true;
    this.isUploadDone = false;
    this.model.filePath = '';

    event.files.forEach(file => {
      this.uploaderService.Upload(file).then(res => {
        if (res.succeeded == true) {
          this.isUploadDone = true;
          this.model.filePath = res.data.fileName;
        }
        this.isLoading = false;
      })
    });

    form.clear();

  }

  async Upload() {
    this.isLoading = true;
    if (this.model.filePath.length > 0) {

      await this._commonCrudService.post("ClientCreditLimit/Create", this.model, ClientCreditLimitListModel).then(res => {
        if (res.succeeded == true) {
          this.isLoading = false;
          this.showUpload = false;

          this.advancedFilter();

        }
        else {
          this.messageService.add({ severity: 'error', detail: res.message });
        }

      })
    }
    else {
      this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });

    }
  }
  clearUpload() {
    this.model.filePath = '';
  }

}
