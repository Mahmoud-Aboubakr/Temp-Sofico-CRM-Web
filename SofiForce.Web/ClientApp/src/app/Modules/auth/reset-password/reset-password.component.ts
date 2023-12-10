import { Component, OnInit, ViewChild } from '@angular/core';
import { CarouselConfig } from 'ngx-bootstrap/carousel';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, Router } from '@angular/router';


import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { TranslateService } from '@ngx-translate/core';
import { UserService } from 'src/app/core/services/User.Service';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { AppUserModel } from 'src/app/core/Models/EntityModels/appUserModel';
import { UserModel } from 'src/app/core/Models/DtoModels/UserModel';
import { AlertService } from 'src/app/core/services/Alert.Service';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';


@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss'],
  providers: [
    { provide: CarouselConfig, useValue: { interval: 3000, noPause: true, showIndicators: false } },
    MessageService
  ]
})
export class ResetPasswordComponent implements OnInit {
  public resetForm: FormGroup;
  public errorMessage: string = '';
  public showError: boolean;
  private _returnUrl: string;

  showNotification = false;

  isLoading = false;
  error = '';
  lan = 'en';

  user: UserModel;

  @ViewChild('ngOtpInput') ngOtpInputRef:any;
  constructor(
    private _formBuilder: FormBuilder, private _router: Router, private _route: ActivatedRoute,
    private messageService: MessageService,
    private _UserService: UserService,
    private dialogRef: DynamicDialogRef,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private _AlertService: AlertService,
    private _commonCrudService : CommonCrudService,) {
    this._translationLoaderService.loadTranslations(english, arabic);
    this.lan = this._translateService.currentLang

    this.user = this._router.getCurrentNavigation().extras.state as UserModel;

    
    
  }

  ngOnInit(): void {

    this.dialogService.dialogComponentRefMap.forEach(dialog => {
      dialog.destroy();
    });

    this._translateService.get('Error , please try again').subscribe((res) => { this.error = res });
    this.resetForm = this._formBuilder.group({
      userid: [0],
      userName: ['', [Validators.required]],
      password: ['', Validators.required],
      
    });

    if(this.user.userId>0){
      this.resetForm.patchValue({userid:this.user.userId,userName:this.user.username,password:''})
    }
  }

  async ResetPassword() {


    if(!this.ngOtpInputRef.currentVal){

      return;
    }


    this.resetForm.patchValue({password:this.ngOtpInputRef.currentVal});

    this.isLoading = true;
    await this._commonCrudService.post("Users/ResetPassword", this.resetForm.value, UserModel).then(re => {




      this.isLoading = false;

      if (re.succeeded == true) {
        this._UserService.onAuthorizationChange.next({ show: true, data: this.user });
        localStorage.setItem('sfc_token', this.user.token);
        localStorage.setItem('user', JSON.stringify(this.user));
        if (this.user.defualtUrl && this.user.defualtUrl.length > 0)
          this._router.navigateByUrl(this.user.defualtUrl);
        else
          this._router.navigateByUrl("/sales/myorders");
      }
      else {
        this._AlertService.Show('error', this.error);

      }

    })

  }

}
