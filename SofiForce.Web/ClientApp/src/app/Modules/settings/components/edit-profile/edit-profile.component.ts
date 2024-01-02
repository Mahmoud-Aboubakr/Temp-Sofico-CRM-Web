import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { MessageService } from 'primeng/api';
import { DialogService, DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { UserModel } from 'src/app/core/Models/DtoModels/UserModel';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { UserService } from 'src/app/core/services/User.Service';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { CommonCrudService } from '../../../../core/services/CommonCrud.service';
import { FileModel } from 'src/app/core/Models/DtoModels/FileModel';


@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.scss']
})
export class EditProfileComponent implements OnInit {

  model:UserModel;

  isLoading=false;

  constructor(
    private _user: UserService,
    private ref: DynamicDialogRef,
    private messageService: MessageService,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private config: DynamicDialogConfig,
    private _commonCrudService : CommonCrudService,

    ) { 

      this._translationLoaderService.loadTranslations(english, arabic);
      //this._translateService.get('Choose Branch').subscribe((res) => { this.CHOOSE_BRANCH = res });
      this.model= this._user.Current();

    }

  ngOnInit(): void {

  }

  save() {

    if(!this.model.realName  || this.model.realName=='' || this.model.realName==undefined || this.model.realName==null){
      return;
    }

    this.isLoading=true;
    this._commonCrudService.post("Users/update",this.model,UserModel).then(res=>{
      this.isLoading=false;
      if(res.succeeded==true){
        localStorage.setItem("user",JSON.stringify(res.data));
        this.ref.close();
        window.location.reload();
      }

      
    })

  }

  myUploader(event, form) {

    this.isLoading = true;
    this.model.avatar = '';

    event.files.forEach(file => {
      this._commonCrudService.parseFile(file,"Uploader/add",FileModel).then(res => {
        if (res.succeeded == true) {
          this.model.avatar = res.data.fileUrl;
        }
        this.isLoading = false;
      })
    });

    form.clear();

  }
}
