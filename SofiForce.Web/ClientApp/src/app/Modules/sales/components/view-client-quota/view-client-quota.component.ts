import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { MessageService, PrimeNGConfig } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { ClientQuotaService } from 'src/app/core/services/ClientQuota.Service';
import { ItemQuotaService } from 'src/app/core/services/ItemQuota.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { UserService } from 'src/app/core/services/User.Service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { ClientQuotaSearchModel } from 'src/app/core/Models/SearchModels/ClientQuotaSearchModel';
import { ItemQuotaSearchModel } from 'src/app/core/Models/SearchModels/ItemQuotaSearchModel';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { ClientQuotaListModel } from 'src/app/core/Models/ListModels/ClientQuotaListModel';
import { ItemQuotaListModel } from 'src/app/core/Models/ListModels/ItemQuotaListModel';
import { ClientQuotaHistoryListModel } from 'src/app/core/Models/ListModels/ClientQuotaHistoryListModel';

@Component({
  selector: 'app-view-client-quota',
  templateUrl: './view-client-quota.component.html',
  styleUrls: ['./view-client-quota.component.scss']
})
export class ViewClientQuotaComponent implements OnInit {

  isLoading = false;

  searchClientModel: ClientQuotaSearchModel = {
    itemId: 0,
    itemCode: '',
    clientId: 0,
    clientCode: '',
    Take: 20,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    TermBy: ""

  }

  searchItemModel: ItemQuotaSearchModel = {
    itemId: 0,
    itemCode: '',
    Take: 0,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    TermBy: ""

  }

  quotaTotal = 0;
  quotaBalance = 0;
  quotaRemain = 0;

  gridClientModel: ResponseModel<ClientQuotaHistoryListModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }



  constructor(
    private ref: DynamicDialogRef,
    private _auth: UserService,
    private primengConfig: PrimeNGConfig,
    private messageService: MessageService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private _ItemQuotaService: ItemQuotaService,
    private _ClientQuotaService: ClientQuotaService,

    private _AppMessageService: AppMessageService,
    private config: DynamicDialogConfig,
  ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    //this._translateService.get('Batchs Details').subscribe((res) => { this.BATCHS = res });

    if (this.config.data.itemId) {
      this.searchClientModel.itemId = this.config.data.itemId
      this.searchItemModel.itemId = this.config.data.itemId

    }
    if (this.config.data.clientId) {
      this.searchClientModel.clientId = this.config.data.clientId
    }

  }

  ngOnInit(): void {

    this.buildform()

  }

  async buildform() {

    this.isLoading = true;
    await this._ItemQuotaService.Filter(this.searchItemModel).then(res => {

      if (res.data && res.data.length > 0) {
        this.quotaTotal = res.data[0].quantity;

      }

    });

    await this._ClientQuotaService.getHistory(this.searchClientModel.clientId, this.searchItemModel.itemId).then(resc => {

      if (resc.data && resc.data.length > 0) {
        this.gridClientModel = resc;
        this.quotaBalance = resc.data.reduce((sum, current) => sum + current.quantity, 0);
      }

    });

    this.quotaRemain = this.quotaTotal - this.quotaBalance;

    this.isLoading = false;


  }

}