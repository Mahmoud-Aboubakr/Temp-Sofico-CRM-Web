import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { BranchModel } from 'src/app/core/Models/EntityModels/branchModel';

import { BranchService } from 'src/app/core/services/Branch.Service';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-manage-branch',
  templateUrl: './manage-branch.component.html',
  styleUrls: ['./manage-branch.component.scss']
})
export class ManageBranchComponent implements OnInit {

  isLoading = false;



  model: BranchModel = {} as BranchModel;

  constructor(private _AppMessageService: AppMessageService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _BranchService: BranchService,
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private ref: DynamicDialogRef,
    private dialogService: DialogService,
    private _commonCrudService : CommonCrudService,
    private config: DynamicDialogConfig,
  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    //this._translateService.get('Choose Branch').subscribe((res) => { this.CHOOSE_BRANCH = res });





    if (this.config.data) {
      if (+this.config.data.branchId > 0) {
        this.model.branchId = +this.config.data.branchId
      }
    }

  }

  ngOnInit(): void {
    if (this.model.branchId > 0) {
      this.fillModel();
    }
  }
  async fillModel() {

    await this._commonCrudService.get("Branch/GetByid?Id="+this.model.branchId, BranchModel).then(res => {
      if (res.succeeded) {
        if (res.data && res.data.branchId > 0) {
          this.model = res.data;
        }
        else {
          this.ref.close();

        }
      }
      else {
        this.ref.close();
      }
    })

  }



  async save() {

    if (this.isValid() == false) {
      this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_INVALID });
      return;
    }

    this.isLoading = true;
    await this._commonCrudService.post("Branch/Save", this.model,BranchModel).then(res => {
      if (res.succeeded == true) {
        this.ref.close();
        this.messageService.add({ severity: 'success', detail: this._AppMessageService.MESSAGE_OK });
      }
      else {
        this.messageService.add({ severity: 'error', detail: this._AppMessageService.MESSAGE_ERROR });

      }

      this.isLoading = false;
    })

  }

  isValid() {

    let valid = true;

    if (this.model.branchCode == null)
      valid = false;

    if (this.model.branchNameAr == null)
      valid = false;

    if (this.model.branchNameEn == null)
      valid = false;

    return valid;

  }
}
