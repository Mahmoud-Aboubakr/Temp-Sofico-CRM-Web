import { Component, OnInit } from '@angular/core';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TranslateService } from '@ngx-translate/core';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { SalesOrderModel } from 'src/app/core/Models/EntityModels/salesOrderModel';
import { BranchListModel } from 'src/app/core/Models/ListModels/BranchListModel';
import { ChooserBranchComponent } from '../../shared/chooser-branch/chooser-branch.component';
import { ChooserClientComponent } from '../../shared/chooser-client/chooser-client.component';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { SalesOrderSourceService } from 'src/app/core/services/SalesOrderSource.Service';
import { SalesOrderStatusService } from 'src/app/core/services/SalesOrderStatus.Service';
import { PaymentTermService } from 'src/app/core/services/PaymentTerm.Service';
import { PriorityService } from 'src/app/core/services/Priority.Service';
import { SalesOrderTypeService } from 'src/app/core/services/SalesOrderType.Service';
import { UtilService } from 'src/app/core/services/util.service';
import { MenuService } from 'src/app/core/services/Menu.Service';
import { ClientRouteListModel } from 'src/app/core/Models/ListModels/ClientRouteListModel';
import { ClientRouteSearchModel } from 'src/app/core/Models/SearchModels/ClientRouteSearchModel';
import { ClientRouteService } from 'src/app/core/services/ClientRoute.Service';
import { UploaderService } from 'src/app/core/services/uploader.service';
import { FileModel } from 'src/app/core/Models/DtoModels/FileModel';
import { CommonCrudService } from 'src/app/core/services/CommonCrud.service';
import { ClientRouteModel } from 'src/app/core/Models/EntityModels/ClientRouteModel';


@Component({
  selector: 'app-client-routes',
  templateUrl: './client-routes.component.html',
  styleUrls: ['./client-routes.component.scss']
})
export class ClientRoutesComponent implements OnInit {


  orderModel: SalesOrderModel = {
    customDiscountTotal: 0,
    itemDiscountTotal: 0,
    taxTotal: 0,
    netTotal: 0,
    cashDiscountTotal: 0,
    itemTotal: 0,
    salesDate: this._UtilService.LocalDate(new Date()),
  } as SalesOrderModel;

  model: ResponseModel<ClientRouteListModel[]> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: []
  };

  clearModel: ClientRouteModel = {
    clientRouteId : 0,
    routeTypeId: 0,
    routeId: 0,
    clientId: 0,
    day1: true,
    day2: true,
    day3: true,
    day4: true,
    day5: true,
    day6: true,
    day7: true
  };

  isLoading = false;
  isUploadDone=false;
  first = 0;
  advanced = false;
  showUpload = false;

  orderTypes: LookupModel[] = [];


  HEADER_ERRORS = '';
  HEADER_MANAGE = '';
  HEADER_WORKFLOW = '';
  HEADER_LOG = '';
  HEADER_STC = '';
  CHOOSE = '';


  searchModel: ClientRouteSearchModel = {
    clientId: 0,
    clientCode: '',
    branchId: 0,
    branchCode: '',
    routeId: 0,
    Take: 30,
    Skip: 0,
    Term: '',
    TermBy: '',
    FilterBy: [],
    isActive:0,
    routeCode:'',
    routeTypeId:0,
    SortBy: {Order:"asc",Property:"clientId"}
  }
  menuItems: MenuItem[];
  cMenuItems: MenuItem[];
  selected: ClientRouteListModel;

  Payments: LookupModel[] = [];
  Priorites: LookupModel[] = [];
  Status: LookupModel[] = [];
  Types: LookupModel[] = [];
  Sources: LookupModel[] = [];

  file:FileModel={
    directory:"",
    fileName:"",
    fileSize:0,
    fileUrl:"",
  };
  searchBy: LookupModel[] = [
    {id:1,code:'clientCode',name:'Client Code'},
    {id:2,code:'clientName',name:'Client Name'},
    {id:3,code:'routeCode',name:'Route Code'},
    {id:4,code:'routeName',name:'Route Name'},
    {id:5,code:'branchCode',name:'Branch Code'},
    {id:6,code:'branchName',name:'Branch Name'},

  ];

  constructor(
    private _ClientRouteService: ClientRouteService,
    private _translationLoaderService: TranslationLoaderService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _AppMessageService: AppMessageService,
    private _PaymentTermService: PaymentTermService,
    private _SalesOrderSourceService: SalesOrderSourceService,
    private _SalesOrderStatusService: SalesOrderStatusService,
    private _SalesOrderTypeService: SalesOrderTypeService,
    private _UtilService: UtilService,
    private _PriorityService: PriorityService,
    private uploaderService: UploaderService,
    private ref: DynamicDialogRef,
    private _MenuService: MenuService,
    private _commonCrudService : CommonCrudService
  ) {

    this._translationLoaderService.loadTranslations(english, arabic);

    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });
    this._translateService.get('Order Log').subscribe((res) => { this.HEADER_LOG = res });
    this._translateService.get('Client Statisticals').subscribe((res) => { this.HEADER_STC = res });

    var found=localStorage.getItem("client-routes.component.termBy")
    if(found){
      this.searchModel.TermBy=found;
    }


    this.menuItems = [
      {
        label: 'Upload Journey',
        icon: 'pi pi-fw pi-upload',
        command: (event) => this.manage('upload'),
      },
      {
        label: 'Delete All Data',
        icon: 'pi pi-fw pi-times',
        command: (event) => this.manage('deleteAll'),
      },
      {
        label: 'Template',
        icon: 'pi pi-fw pi-cloud-download',
        command: (event) => this.manage('template'),
      },
      {
        label: 'Export',
        icon: 'pi pi-fw pi-cloud-download',
        command: (event) => this.manage('export'),
      },
    ];


    this.cMenuItems = [
      {
        label: 'Delete',
        icon: 'pi pi-fw pi-times',
        command: (event) => this.manage('delete'),
      },
    ];

  }


  OnTermChange(arg){
    localStorage.setItem("client-routes.component.termBy",arg.value);
  }

  ngOnInit(): void {



    this._translateService.get('Manage Order').subscribe((res) => { this.HEADER_MANAGE = res });
    this._translateService.get('Order Errors Details').subscribe((res) => { this.HEADER_ERRORS = res });
    this._translateService.get('Order Workflow Details').subscribe((res) => { this.HEADER_WORKFLOW = res });



    this._commonCrudService.get("PaymentTerm/GetAll", LookupModel).then(res => {
      this.Payments = res.data;
      this.Payments.unshift({ id: 0, code: '0', name: '--' });
    })

    this._commonCrudService.get("SalesOrderStatus/GetAll", LookupModel).then(res => {
      this.Status = res.data;
      this.Status.unshift({ id: 0, code: '0', name: '--' });

    })

    this._commonCrudService.get("Priority/GetAll", LookupModel).then(res => {
      this.Priorites = res.data;
      this.Priorites.unshift({ id: 0, code: '0', name: '--' });

    })

    this._commonCrudService.get("SalesOrderType/GetAll", LookupModel).then(res => {
      this.Types = res.data;
      this.Types.unshift({ id: 0, code: '0', name: '--' });
    })
    this._commonCrudService.get("SalesOrderSource/GetAll", LookupModel).then(res => {
      this.Sources = res.data;
    })
    this._commonCrudService.get("SalesOrderSource/GetAll", LookupModel).then(res => {
      this.Sources = res.data;
    })



  }


  async filter(event) {


    this.isLoading = true;
    this.searchModel.Skip = event.first;
    this.searchModel.Take = event.rows;


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

    await this._commonCrudService.post("ClientRoute/Filter", this.searchModel, ClientRouteListModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })


  }


  async smartFilter(event) {

    if (event.keyCode == 13) {
      this.first = 0;
      this.searchModel.Skip = 0;
      this.isLoading = true;
      await this._commonCrudService.post("ClientRoute/Filter", this.searchModel, ClientRouteListModel).then(res => {
        this.model = res;
        this.isLoading = false;
      })
    }

  }
  async reloadFilter() {

    this.isLoading = true;
    await this._commonCrudService.post("ClientRoute/Filter", this.searchModel, ClientRouteListModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })
  }
  async advancedFilter() {
    this.isLoading = true;
    await this._commonCrudService.post("ClientRoute/Filter", this.searchModel, ClientRouteListModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })
  }
  async clearFilter() {
    this.first = 0;
    this.isLoading = true;
    this.searchModel = {

      clientId: 0,
      clientCode: '',
      branchId: 0,
      branchCode: '',
      routeId: 0,
      Take: 30,
      Skip: 0,
      Term: '',
      TermBy: '',
      FilterBy: [],
      isActive:0,
      routeCode:'',
      routeTypeId:0,
      SortBy: {Order:"asc",Property:"clientId"}
    }
    await this._commonCrudService.post("ClientRoute/Filter", this.searchModel, ClientRouteListModel).then(res => {
      this.model = res;
      this.isLoading = false;
    })

  }

  async manage(mode) {

    if (mode == "deleteAll") {
      this.isLoading = true;
      this._commonCrudService.post("ClientRoute/clear", this.clearModel, ClientRouteModel).then(res => {
        this.advancedFilter();
        this.isLoading = false;
      })
    }
    if (mode == 'template') {
      this.isLoading = true;

      (await this._commonCrudService.getFile("ClientRoute/template")).subscribe((data: any) => {

       // console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "TargetTemplate_" + new Date().toISOString().split('.')[0].replace(/[^\d]/gi, '');
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);


        this.isLoading = false;
      })
    }
    if (mode == "upload") {
    this.showUpload=true;
    }

    if (mode == 'export') {
      this.isLoading = true;
      (await this._commonCrudService.postFile("ClientRoute/Export", this.searchModel)).subscribe((data: any) => {

        console.log(data);

        const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        const a = document.createElement('a');
        a.setAttribute('style', 'display:none;');
        document.body.appendChild(a);
        a.download = "ClientRoute_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
        a.href = URL.createObjectURL(downloadedFile);
        a.target = '_blank';
        a.click();
        document.body.removeChild(a);


        this.isLoading = false;
      })
    }
  }

  myUploader(event, form) {

    this.isLoading = true;
    this.isUploadDone = false;
    this.file.fileUrl = '';

    event.files.forEach(file => {
      this.uploaderService.Upload(file).then(res => {
        if (res.succeeded == true)
        {
          this.isUploadDone = true;
          this.file.fileUrl = res.data.fileName;
        }

        this.isLoading = false;
      })
    });

    form.clear();

  }

  async onSelectionChange(event) {
    this.selected = event;

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

      }
    });
  }
  clear_Branch() {
    this.searchModel.branchCode = '';
    this.searchModel.branchId = 0;
  }





  choose_Client() {
    var ref = this.dialogService.open(ChooserClientComponent, {
      header: this.CHOOSE,
      width: '90%',
      modal: true,
      height: "90%"
    });

    ref.onClose.subscribe((client: ClientListModel) => {
      if (client) {


        this.searchModel.clientCode = client.clientCode;
        this.searchModel.clientId = client.clientId;

      }
    });
  }

  clear_Client() {
    this.searchModel.clientCode = '';
    this.searchModel.clientId = 0;
  }





  FixedNumer(num: number) {
    if (!num) return 0;

    return Number(num.toFixed(3));
  }

  async save() {

    this.isLoading = true;
    if (this.file.fileUrl.length > 0) {

      await this._commonCrudService.post("ClientRoute/Upload", this.file, FileModel).then(res => {

        if(res.succeeded){
          this.isUploadDone=false;
          this.showUpload=false;
        }

        this._commonCrudService.post("ClientRoute/Filter", this.searchModel, ClientRouteListModel).then(res => {
          this.model = res;
          this.isLoading = false;
        })


      })
    }
  }

}
