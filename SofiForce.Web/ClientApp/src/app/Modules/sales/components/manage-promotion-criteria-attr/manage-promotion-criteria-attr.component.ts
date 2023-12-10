import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { UtilService } from 'src/app/core/services/util.service';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { PromotionCriteriaAttrCustomModel } from 'src/app/core/Models/EntityModels/PromotionCriteriaAttrCustomModel';
import { PromotionCriteriaAttrModel } from 'src/app/core/Models/EntityModels/PromotionCriteriaAttrModel';
import { PromotionCriteriaAttrService } from 'src/app/core/services/promotion/PromotionCriteriaAttr.Service';
import { PromotionCriteriaAttrCustomService } from 'src/app/core/services/promotion/PromotionCriteriaAttrCustom.Service';
import { ItemListModel } from 'src/app/core/Models/ListModels/ItemListModel';
import { UserModel } from 'src/app/core/Models/DtoModels/UserModel';
import { ChooserProductAllComponent } from 'src/app/Modules/shared/chooser-product-all/chooser-product-all.component';
import { PromotionCriteriaAttrCustomListModel } from 'src/app/core/Models/ListModels/PromotionCriteriaAttrCustomListModel';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-manage-promotion-criteria-attr',
  templateUrl: './manage-promotion-criteria-attr.component.html',
  styleUrls: ['./manage-promotion-criteria-attr.component.scss']
})
export class ManagePromotionCriteriaAttrComponent implements OnInit {


  current: UserModel;
  
  model: PromotionCriteriaAttrModel = {
    attributeCode: '',
    attributeId: 0,
    attributeNameAr: '',
    attributeNameDesc: '',
    attributeNameEn: '',
    displayOrder: 0,
    canDelete: false,
    canEdit: false,
    isActive: true,
    isCustom: true,

  } as PromotionCriteriaAttrModel;

  PromotionCriteriaAttrCustomModel: PromotionCriteriaAttrCustomModel = {
    attributeId: 0,
    customId: 0,
    valueFrom: '',

    isActive: true,

  } as PromotionCriteriaAttrCustomModel;

  PromotionCriteriaAttrCustomList: PromotionCriteriaAttrCustomListModel[] = [];


  isLoading = false;
  isItemLoading = false;
  isUploadDone = false;
  showItems = false;
  showUpload=false;
  editMode = "";
  CHOOSE='';

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
    private _commonCrudService : CommonCrudService,


    private _PromotionCriteriaAttrService: PromotionCriteriaAttrService,
    private _PromotionCriteriaAttrCustomService:PromotionCriteriaAttrCustomService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });

    if (this.config.data) {
      if (+this.config.data.attributeId > 0) {
        this.model.attributeId = +this.config.data.attributeId;
      }
      if (this.config.data.editMode) {
        this.editMode = this.config.data.editMode;
      }
    }

  }

  ngOnInit(): void {

    if (this.model.attributeId > 0) {
      this.isLoading = true;
      //get by id

      this._commonCrudService.get("PromotionCriteriaAttr/GetById?Id="+this.model.attributeId, PromotionCriteriaAttrModel).then(res => {
        if (res.succeeded == true) {
          if (res.data) {
            this.model = res.data;
          }

          this.isLoading = false;

        }
      })

      this._commonCrudService.get("PromotionCriteriaAttrCustom/getByAttribute?Id="+this.model.attributeId, PromotionCriteriaAttrCustomListModel).then(res => {
        if (res.succeeded == true) {
          this.PromotionCriteriaAttrCustomList = res.data;
        }
      })


    }
  }

  async Save() {

    let valid = true;
    if (this.model.attributeCode.trim().length == 0) {
      valid = false;
    }


    if (valid == false) {

      this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_INVALID });
      return;

    }

    this.isLoading = true;
    await this._commonCrudService.post("PromotionCriteriaAttr/Save",this.model,PromotionCriteriaAttrModel).then(res => {
      if (res.succeeded == true && res.data && res.data.attributeId > 0) {
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

    this.PromotionCriteriaAttrCustomModel.attributeId=this.model.attributeId;

    if (this.PromotionCriteriaAttrCustomModel.attributeId == 0) {
      valid = false;
    }

    if (this.PromotionCriteriaAttrCustomModel.valueFrom.trim().length == 0) {
      valid = false;
    }



    if (valid == false) {

      this.messageService.add({ severity: 'error', summary: "Soficopharm", detail: this._AppMessageService.MESSAGE_INVALID });
      return;

    }


    this.isItemLoading = true;
    await this._commonCrudService.post("PromotionCriteriaAttrCustom/Save",this.PromotionCriteriaAttrCustomModel,PromotionCriteriaAttrCustomModel).then(async res => {
      if (res.succeeded == true) {


        //rebind grid

        await this._commonCrudService.get("PromotionCriteriaAttrCustom/getByAttribute?Id="+this.model.attributeId,PromotionCriteriaAttrCustomListModel).then(res => {
          if (res.succeeded == true) {
            this.PromotionCriteriaAttrCustomList = res.data;
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
  
  deleteLine() {
    this.isItemLoading = true;
     this._commonCrudService.post("PromotionCriteriaAttrCustom/Delete",this.PromotionCriteriaAttrCustomModel,PromotionCriteriaAttrCustomModel).then(async res => {
      if (res.succeeded == true) {


        //rebind grid

        await this._commonCrudService.get("PromotionCriteriaAttrCustom/getByAttribute?Id="+this.model.attributeId,PromotionCriteriaAttrCustomListModel).then(res => {
          if (res.succeeded == true) {
            this.PromotionCriteriaAttrCustomList = res.data;
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
  resetAttributeModel() {
    this.PromotionCriteriaAttrCustomModel = {

      attributeId: 0,
      customId: 0,
      valueFrom: '',

      isActive: true,

    } as PromotionCriteriaAttrCustomModel;
  }

  deleteAll() {
    if (this.model.attributeId != null && this.model.attributeId > 0) {
      this.confirmationService.confirm({
        message: this._AppMessageService.MESSAGE_CONFIRM,
        accept: async () => {
          this.isLoading = true;
          let model = {} as PromotionCriteriaAttrModel;
          model.attributeId = this.model.attributeId;
          this._commonCrudService.post("PromotionCriteriaAttrCustom/DeleteAll",model,PromotionCriteriaAttrModel).then(async res => {

            if (res.succeeded == true) {
              this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });

              //rebind grid
              await this._commonCrudService.get("PromotionCriteriaAttrCustom/getByAttribute?Id="+this.model.attributeId,PromotionCriteriaAttrCustomListModel).then(res => {
                if (res.succeeded == true) {
                  this.PromotionCriteriaAttrCustomList = res.data;
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
    let model = {} as PromotionCriteriaAttrModel;
    model.attributeId = this.model.attributeId;
    await (this._commonCrudService.postFile("PromotionCriteriaAttrCustom/download",model)).subscribe((data:any)=> {

      console.log(data);

      const downloadedFile = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      const a = document.createElement('a');
      a.setAttribute('style', 'display:none;');
      document.body.appendChild(a);
      a.download = "ItemAttribute_"+new Date().toISOString().split('.')[0].replace(/[^\d]/gi,'');
      a.href = URL.createObjectURL(downloadedFile);
      a.target = '_blank';
      a.click();
      document.body.removeChild(a);

     
      this.isLoading=false;
    })
  }


  async reload() {
    this.isLoading=true;
    this.resetAttributeModel();

    await this._commonCrudService.get("PromotionCriteriaAttrCustom/getByAttribute?Id="+this.model.attributeId,PromotionCriteriaAttrCustomListModel).then(res => {
      
      if (res.succeeded == true) {

        this.PromotionCriteriaAttrCustomList = res.data;
      }

      this.isLoading = false;
    })
  }

  choose_item(){
    var ref = this.dialogService.open(ChooserProductAllComponent, {
      header: this.CHOOSE,
      width: '80%',
      contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
      baseZIndex: 10000
    });
    ref.onClose.subscribe((product:ItemListModel) => {
      
      if(product){
        this.PromotionCriteriaAttrCustomModel.valueFrom=product.itemCode;
      }

    });
  }

  
  myUploader(event, form) {

    this.isLoading = true;
    this.isUploadDone = false;

    event.files.forEach(file => {
      this._PromotionCriteriaAttrCustomService.Upload(file, this.model.attributeId).then(async res => {
        if (res.succeeded == true) {
          this.showUpload = false;
          await this._commonCrudService.get("PromotionCriteriaAttrCustom/getByAttribute?Id="+this.model.attributeId,PromotionCriteriaAttrCustomListModel).then(res => {
            if (res.succeeded == true) {
              this.PromotionCriteriaAttrCustomList = res.data;

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
