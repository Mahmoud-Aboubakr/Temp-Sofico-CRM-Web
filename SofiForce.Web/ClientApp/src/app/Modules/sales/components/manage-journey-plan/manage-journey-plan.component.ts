import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';


import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { JourneyUploadModel } from 'src/app/core/Models/DtoModels/JourneyUploadModel';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';
import { RepresentativeJourneyListModel } from '../../../../core/Models/ListModels/RepresentativeJourneyListModel';
import { FileModel } from 'src/app/core/Models/DtoModels/FileModel';


@Component({
  selector: 'app-manage-journey-plan',
  templateUrl: './manage-journey-plan.component.html',
  styleUrls: ['./manage-journey-plan.component.scss']
})
export class ManageJourneyPlanComponent implements OnInit {

  isUploadDone = false;
  isLoading = false;

  model: JourneyUploadModel = {
    filePath: '',
    uploadDate: new Date()
  };
  constructor(


    private ref: DynamicDialogRef,
    private messageService: MessageService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private _commonCrudService : CommonCrudService,
    private config: DynamicDialogConfig,
  ) {
    this._translationLoaderService.loadTranslations(english, arabic);
  }

  ngOnInit(): void {
  }


  myUploader(event, form) {

    this.isLoading = true;
    this.isUploadDone = false;
    this.model.filePath = '';

    event.files.forEach(file => {
      this._commonCrudService.parseFile(file,"Uploader/add",FileModel).then(res => {
        if (res.succeeded == true) {
          this.isUploadDone = true;
          this.model.filePath = res.data.fileName;
        }
        this.isLoading = false;
      })
    });

    form.clear();

  }
  async save() {

    this.isLoading = true;
    if (this.model.filePath.length > 0) {

      await this._commonCrudService.post("RepresentativeJourney/Create", this.model, RepresentativeJourneyListModel).then(res => {
        this.isLoading = false;

        this.ref.close();

      })


    }
    else {

    }
  }

}
