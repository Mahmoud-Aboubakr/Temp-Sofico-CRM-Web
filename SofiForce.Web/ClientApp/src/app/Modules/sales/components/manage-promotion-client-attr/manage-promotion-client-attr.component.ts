import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { UtilService } from 'src/app/core/services/util.service';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { PromotionCriteriaAttrModel } from 'src/app/core/Models/EntityModels/PromotionCriteriaAttrModel';
import { PromotionCriteriaAttrService } from 'src/app/core/services/promotion/PromotionCriteriaAttr.Service';
import { PromtionCriteriaClientAttrCustomService } from 'src/app/core/services/promotion/PromtionCriteriaClientAttrCustom.Service';
import { PromtionCriteriaClientAttrCustomModel } from 'src/app/core/Models/EntityModels/PromtionCriteriaClientAttrCustomModel';
import { PromtionCriteriaClientAttrService } from 'src/app/core/services/promotion/PromtionCriteriaClientAttr.Service';
import { PromtionCriteriaClientAttrModel } from 'src/app/core/Models/EntityModels/PromtionCriteriaClientAttrModel';
import { ClientListModel } from 'src/app/core/Models/ListModels/ClientListModel';
import { ChooserClientComponent } from 'src/app/Modules/shared/chooser-client/chooser-client.component';
import { UploaderService } from 'src/app/core/services/uploader.service';
import { PromtionCriteriaClientAttrCustomListModel } from 'src/app/core/Models/ListModels/PromtionCriteriaClientAttrCustomListModel';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';
@Component({
  selector: 'app-manage-promotion-client-attr',
  templateUrl: './manage-promotion-client-attr.component.html',
  styleUrls: ['./manage-promotion-client-attr.component.scss']
})
export class ManagePromotionClientAttrComponent implements OnInit {



  model: PromtionCriteriaClientAttrModel = {
    clientAttributeId: 0,
    canEdit: true,
    canDelete: true,
    clientAttributeCode: '',
    clientAttributeDesc: '',
    clientAttributeNameAr: '',
    clientAttributeNameEn: '',
    displayOrder: 0,
    isActive: true,
    isCustom: true,



  } as PromtionCriteriaClientAttrModel;

  PromtionCriteriaClientAttrCustomModel: PromtionCriteriaClientAttrCustomModel = {
    clientAttributeId: 0,
    clientCustomId: 0,
    valueFrom: '',

    isActive: true,

  } as PromtionCriteriaClientAttrCustomModel;

  PromtionCriteriaClientAttrCustomList: PromtionCriteriaClientAttrCustomListModel[] = [];


  isLoading = false;
  isItemLoading = false;

  showItems = false;
  showUpload = false;
  isUploadDone = false;
  editMode = "";
  CHOOSE = '';

  constructor(
    private _AppMessageService: AppMessageService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private ref: DynamicDialogRef,
    private dialogService: DialogService,
    private config: DynamicDialogConfig,
    private _UtilService: UtilService,
    private uploaderService: UploaderService,

    private _PromtionCriteriaClientAttrService: PromtionCriteriaClientAttrService,
    private _PromtionCriteriaClientAttrCustomService: PromtionCriteriaClientAttrCustomService,
    private _commonCrudService : CommonCrudService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });

    if (this.config.data) {
      if (+this.config.data.clientAttributeId > 0) {
        this.model.clientAttributeId = +this.config.data.clientAttributeId;
      }
      if (this.config.data.editMode) {
        this.editMode = this.config.data.editMode;
      }
    }

  }

  ngOnInit(): void {

    if (this.model.clientAttributeId > 0) {
      this.isLoading = true;
      //get by id

      this._commonCrudService.get("PromtionCriteriaClientAttr/GetById?Id="+this.model.clientAttributeId, PromtionCriteriaClientAttrModel).then(res => {
        if (res.succeeded == true) {
          if (res.data) {
            this.model = res.data;
          }

          this.isLoading = false;

        }
      })

      this._commonCrudService.get("PromtionCriteriaClientAttrCustom/getByAttribute?Id="+this.model.clientAttributeId, PromtionCriteriaClientAttrCustomListModel).then(res => {
        if (res.succeeded == true) {
          this.PromtionCriteriaClientAttrCustomList = res.data;
        }
      })


    }
  }

  async Save() {

    let valid = true;
    if (this.model.clientAttributeCode.trim().length == 0) {
      valid = false;
    }


    if (valid == false) {

      this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_INVALID });
      return;

    }

    this.isLoading = true;
    await this._commonCrudService.post("PromtionCriteriaClientAttr/Save", this.model, PromtionCriteriaClientAttrModel).then(res => {
      if (res.succeeded == true && res.data && res.data.clientAttributeId > 0) {
        this.model = res.data;
      }
      else {
        this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_ERROR });
      }

    });
    this.isLoading = false;

  }

  async saveItem() {
    let valid = true;

    this.PromtionCriteriaClientAttrCustomModel.clientAttributeId = this.model.clientAttributeId;

    if (this.PromtionCriteriaClientAttrCustomModel.clientAttributeId == 0) {
      valid = false;
    }

    if (this.PromtionCriteriaClientAttrCustomModel.valueFrom.trim().length == 0) {
      valid = false;
    }



    if (valid == false) {

      this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_INVALID });
      return;

    }


    this.isItemLoading = true;
    await this._commonCrudService.post("PromtionCriteriaClientAttrCustom/Save", this.PromtionCriteriaClientAttrCustomModel, PromtionCriteriaClientAttrCustomModel).then(async res => {
      if (res.succeeded == true) {


        //rebind grid
        this.PromtionCriteriaClientAttrCustomList = [];

        await this._commonCrudService.get("PromtionCriteriaClientAttrCustom/getByAttribute?Id="+this.model.clientAttributeId, PromtionCriteriaClientAttrCustomListModel).then(res => {
          if (res.succeeded == true) {
            this.PromtionCriteriaClientAttrCustomList = res.data;
          }
        })

        //reset
        this.resetAttributeModel();

        this.messageService.add({ severity: 'success', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_OK });
      }
      else {
        this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_ERROR });

      }

      this.isItemLoading = false;

    })


  }
  addLine() {
    this.resetAttributeModel();
    this.showItems = true;
  }
  uploadExcelPopup() {
    this.showUpload = true;
  }
  editLine() {
    this.showItems = true;
  }
  deleteLine() {


    if (this.PromtionCriteriaClientAttrCustomModel.clientCustomId > 0) {

      this.isLoading = true;
      this._commonCrudService.post("PromtionCriteriaClientAttrCustom/Delete", this.PromtionCriteriaClientAttrCustomModel, PromtionCriteriaClientAttrCustomModel).then(async res => {
        if (res.succeeded == true) {


          
          //rebind grid
          await this._commonCrudService.get("PromtionCriteriaClientAttrCustom/getByAttribute?Id="+this.model.clientAttributeId, PromtionCriteriaClientAttrCustomListModel).then(res => {
            if (res.succeeded == true) {
              this.PromtionCriteriaClientAttrCustomList = res.data;
            }
          })

          //reset
          this.resetAttributeModel();

          this.messageService.add({ severity: 'success', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_OK });
          this.isLoading=false;
        }
        else {
          this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_ERROR });

        }

        this.isItemLoading = false;

      })
    }
    else {
      this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_ERROR });

    }



  }

  deleteAll() {
    if (this.model.clientAttributeId != null && this.model.clientAttributeId > 0) {
      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {
          this.isLoading = true;
          let model = {} as PromtionCriteriaClientAttrModel;
          model.clientAttributeId = this.model.clientAttributeId;
          this._commonCrudService.post("PromtionCriteriaClientAttrCustom/DeleteAll", model, PromtionCriteriaClientAttrModel).then(async res => {

            if (res.succeeded == true) {
              this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });

              //rebind grid
              await this._commonCrudService.get("PromtionCriteriaClientAttrCustom/getByAttribute?Id="+this.model.clientAttributeId, PromtionCriteriaClientAttrCustomListModel).then(res => {
                if (res.succeeded == true) {
                  this.PromtionCriteriaClientAttrCustomList = res.data;
                }
              })
            }
            else {
              this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });
            }

            this.isLoading = false;
          })
        },
        reject: () => {
          //reject action
        }
      });
    }
  }
  async downloadExcel() {
    this.isLoading=true;
    let model = {} as PromtionCriteriaClientAttrModel;
    model.clientAttributeId = this.model.clientAttributeId;
    await (this._commonCrudService.postFile("PromtionCriteriaClientAttrCustom/download", model)).subscribe((data:any)=> {

      console.log(data);

      const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      const a = document.createElement('a');
      a.setAttribute('style', 'display:none;');
      document.body.appendChild(a);
      a.download = "ClientAttribute_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
      a.href = URL.createObjectURL(downloadedFile);
      a.target = '_blank';
      a.click();
      document.body.removeChild(a);

     
      this.isLoading=false;
    })
  }
  resetAttributeModel() {
    this.PromtionCriteriaClientAttrCustomModel = {

      clientAttributeId: 0,
      clientCustomId: 0,
      valueFrom: '',

      isActive: true,

    } as PromtionCriteriaClientAttrCustomModel;
  }

  async reload() {
    this.isLoading=true;
    this.resetAttributeModel();

    await this._commonCrudService.get("PromtionCriteriaClientAttrCustom/getByAttribute?Id="+this.model.clientAttributeId, PromtionCriteriaClientAttrCustomListModel).then(res => {
      
      if (res.succeeded == true) {

        this.PromtionCriteriaClientAttrCustomList = res.data;
      }

      this.isLoading = false;
    })
  }

  choose_Client() {
    var ref = this.dialogService.open(ChooserClientComponent, {
      header: this.CHOOSE,
      width: '90%',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });

    ref.onClose.subscribe((res: ClientListModel) => {

      if (res) {
        this.PromtionCriteriaClientAttrCustomModel.valueFrom = res.clientCode;
      }

    });
  }

  myUploader(event, form) {

    this.isLoading = true;
    this.isUploadDone = false;

    event.files.forEach(file => {
      this._PromtionCriteriaClientAttrCustomService.Upload(file, this.model.clientAttributeId).then(async res => {
        if (res.succeeded == true) {
          this.showUpload = false;
          await this._commonCrudService.get("PromtionCriteriaClientAttrCustom/getByAttribute?Id="+this.model.clientAttributeId, PromtionCriteriaClientAttrCustomListModel).then(res => {
            if (res.succeeded == true) {
              this.PromtionCriteriaClientAttrCustomList = res.data;

            }
          })
        }
        else {
          this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: res.message });
        }

        this.isLoading = false;
      })
    });

    form.clear();

  }
}
