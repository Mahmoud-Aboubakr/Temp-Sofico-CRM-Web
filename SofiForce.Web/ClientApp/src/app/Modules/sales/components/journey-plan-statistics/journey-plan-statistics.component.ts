import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig } from 'primeng/dynamicdialog';
import { ResponseModel } from 'src/app/core/Models/ResponseModels/ResponseModel';
import { RepresentativeJourneyKBIDetailModel, RepresentativeJourneyKBIModel } from 'src/app/core/Models/StatisticalModels/RepresentativeJourneyKBIModel';
import { AppMessageService } from 'src/app/core/services/AppMessage.Service';
import { FormatterService } from 'src/app/core/services/Formatter.service';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';

@Component({
  selector: 'app-journey-plan-statistics',
  templateUrl: './journey-plan-statistics.component.html',
  styleUrls: ['./journey-plan-statistics.component.scss']
})
export class JourneyPlanStatisticsComponent implements OnInit {


  model: ResponseModel<RepresentativeJourneyKBIModel> = {
    message: "",
    statusCode: 0,
    executionDate: undefined,
    succeeded: false,
    total: 0,
    data: null
  };
  selected: RepresentativeJourneyKBIDetailModel;
  isLoading=false;

  constructor(
    private _FormatterService: FormatterService,
    private _translationLoaderService: TranslationLoaderService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private _AppMessageService: AppMessageService,
    private config: DynamicDialogConfig,
  ) { }

  ngOnInit(): void {

  }

  async exportReps(){

  }
}
