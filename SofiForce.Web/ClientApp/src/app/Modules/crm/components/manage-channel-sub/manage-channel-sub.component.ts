import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';

import { ChooserBranchComponent } from 'src/app/Modules/shared/chooser-branch/chooser-branch.component';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { BusinessUnitModel } from 'src/app/core/Models/EntityModels/BusinessUnitModel';
import { AlertService } from 'src/app/core/services/Alert.Service';
import { ClientGroupSubModel } from 'src/app/core/Models/EntityModels/clientGroupSubModel';
import { LookupModel } from 'src/app/core/Models/DtoModels/lookupModel';
import { ManageChannelMainComponent } from '../manage-channel-main/manage-channel-main.component';
import { ClientGroupModel } from 'src/app/core/Models/EntityModels/ClientGroupModel';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';
@Component({
  selector: 'app-manage-channel-sub',
  templateUrl: './manage-channel-sub.component.html',
  styleUrls: ['./manage-channel-sub.component.scss']
})
export class ManageChannelSubComponent implements OnInit {



  model = {
    clientGroupId:0,
    clientGroupSubId:0,

  } as ClientGroupSubModel;
  isLoading = true;
  MANAGE = '';
  MainChannels: LookupModel[] = [];
  constructor(
    private _AppMessageService: AppMessageService,

    private ref: DynamicDialogRef,
    private messageService: MessageService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private config: DynamicDialogConfig,
    private _AlertService: AlertService,
    private _commonCrudService : CommonCrudService,

  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    this._translateService.get('Manage').subscribe((res) => { this.MANAGE = res });

    this.model.isActive=true;

  }
  ngOnInit(): void {
    this.init();
  }

  async init() {


    this._commonCrudService.get("ClientGroup/GetAll", LookupModel).then(res => {
      this.MainChannels = res.data;
      this.MainChannels.unshift({ id: 0, code: '0', name: '--' });
    })

    if (this.config.data && this.config.data.clientGroupSubId>0) {
      await this._commonCrudService.get("ClientGroupSub/getById?Id="+this.config.data.clientGroupSubId, ClientGroupSubModel).then(res=>{
        if(res.succeeded==true){
          this.model=res.data;
        }
      })
    }

    this.isLoading = false;

  }

  
  manageLookups(type, Arg) {


    if (type == "ClientGroups") {
      var ref = this.dialogService.open(ManageChannelMainComponent, {
        header: this.MANAGE,
        data: { clientGroupId: Arg },
        width: '600px',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });

      ref.onClose.subscribe((res: ClientGroupModel) => {
        this._commonCrudService.get("ClientGroup/GetAll", LookupModel).then(res => {
          this.MainChannels = res.data;
          this.MainChannels.unshift({ id: 0, code: '0', name: '--' });
        })
      });

    }
  
   
  }

  Save() {

    if (this.model.clientGroupId == 0) {
      this._AlertService.Show('error', this._AppMessageService.MESSAGE_ERROR)

      return;
    }

    if (this.model.clientGroupSubNameAr == null || this.model.clientGroupSubNameEn.trim().length == 0) {
      this._AlertService.Show('error', this._AppMessageService.MESSAGE_ERROR)

      return;
    }

   

    this.isLoading = true;
    this._commonCrudService.post("ClientGroupSub/Save",this.model, ClientGroupSubModel).then(res => {

      if (res.succeeded == true) {
        this.ref.close();
        this._AlertService.Show('success', this._AppMessageService.MESSAGE_OK)
      }
      else {
        this._AlertService.Show('error', this._AppMessageService.MESSAGE_ERROR)
      }
      this.isLoading = false;
    })

  }


}
