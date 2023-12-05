import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-error-dialog',
  templateUrl: './error-dialog.component.html',
  styleUrls: ['./error-dialog.component.scss']
})
export class ErrorDialogComponent implements OnInit {

  message = '';
  level = 'e';
  constructor(
    private ref: DynamicDialogRef,
    private messageService: MessageService,
    private _translateService: TranslateService,
    private config: DynamicDialogConfig,
    private _translationLoaderService: TranslationLoaderService,) {
    this._translationLoaderService.loadTranslations(english, arabic);

    if (this.config.data) {
      this.level = this.config.data.level;
      this._translateService.get(this.config.data.message).subscribe((res) => { this.message = res });
    }
  }

  ngOnInit(): void {
  }

}
