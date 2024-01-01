import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { MessageService, PrimeNGConfig } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { SalesOrderLogListModel } from 'src/app/core/Models/ListModels/SalesOrderLogListModel';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';

@Component({
  selector: 'app-view-sales-order-log',
  templateUrl: './view-sales-order-log.component.html',
  styleUrls: ['./view-sales-order-log.component.scss']
})
export class ViewSalesOrderLogComponent implements OnInit {

  gridModel: ResponseModel<SalesOrderLogListModel[]> = {
    message: '',
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    data: [],
    total: 0
  }

  salesId = 0;
  isLoading = false;

  constructor(
    private _translationLoaderService: TranslationLoaderService,
    private _translateService: TranslateService,
    private dialogService: DialogService,
    private _AppMessageService: AppMessageService,
    private messageService: MessageService,
    private config: DynamicDialogConfig,
    private _commonCrudService : CommonCrudService,
    ) {

    this._translationLoaderService.loadTranslations(english, arabic);
    //this._translateService.get('Batchs Details').subscribe((res) => { this.BATCHS = res });


    if (this.config.data.salesId) {
      this.salesId = +this.config.data.salesId
    }
  }

  ngOnInit(): void {
    this._commonCrudService.get("SalesOrderLog/getbyId?SalesId="+this.salesId, SalesOrderLogListModel).then(res => {
      this.gridModel = res;
    })
  }






}
