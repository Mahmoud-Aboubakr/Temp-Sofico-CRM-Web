import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { MessageService, PrimeNGConfig } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { PromotionViewModel } from 'src/app/core/Models/EntityModels/PromotionViewModel';
import { PromotionSearchModel } from 'src/app/core/Models/SearchModels/PromotionSearchModel';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { ItemPromotionService } from 'src/app/core/services/ItemPromotion.Service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { UserService } from 'src/app/core/services/User.Service';


import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';

@Component({
  selector: 'app-view-promotion',
  templateUrl: './view-promotion.component.html',
  styleUrls: ['./view-promotion.component.scss']
})
export class ViewPromotionComponent implements OnInit {



  constructor(
    private ref: DynamicDialogRef,
    private _auth: UserService,
    private primengConfig: PrimeNGConfig,
    private messageService: MessageService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private _ItemPromotionService: ItemPromotionService,
    private _AppMessageService: AppMessageService,
    private config: DynamicDialogConfig,
  ) {

    

  }

  ngOnInit(): void {


  }

}
