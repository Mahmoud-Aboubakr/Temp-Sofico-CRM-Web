import { Component, OnInit } from '@angular/core';
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
import { AlertService } from 'src/app/core/services/Alert.Service';
import { CommonCrudService } from '../../../core/services/CommonCrud.service';
import { UserModel } from '../../../core/Models/DtoModels/UserModel';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  providers: [
    { provide: CarouselConfig, useValue: { interval: 3000, noPause: true, showIndicators: false } },
    MessageService
  ]
})
export class LoginComponent implements OnInit {
  public loginForm: FormGroup;
  public errorMessage: string = '';
  public showError: boolean;
  private _returnUrl: string;

  showNotification = false;

  isLoading = false;
  Invalid_username_or_Password = '';
  USER_BOLCKED = '';

  Error = '';
  lan = 'en';

  constructor(
    private _formBuilder: FormBuilder, private _router: Router, private _route: ActivatedRoute,
    private messageService: MessageService,
    private _UserService: UserService,
    private dialogRef: DynamicDialogRef,
    private dialogService: DialogService,
    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private _AlertService: AlertService,
    private _commonCrudService : CommonCrudService,

  ) {
    this._translationLoaderService.loadTranslations(english, arabic);
    this.lan = this._translateService.currentLang

  }

  ngOnInit(): void {

    this.dialogService.dialogComponentRefMap.forEach(dialog => {
      dialog.destroy();
    });

    localStorage.removeItem('sfc_token');
    localStorage.removeItem('user');
    this._translateService.get('Invalid username or Password').subscribe((res) => { this.Invalid_username_or_Password = res });
    this._translateService.get('Error').subscribe((res) => { this.Error = res });
    this._translateService.get('User has been blocked please call system adminstrator').subscribe((res) => { this.Error = res });

    this._UserService.onAuthorizationChange.next({ show: false, data: null });

    this.loginForm = this._formBuilder.group({
      userName: ['', [Validators.required]],
      password: ['', Validators.required]
    });
  }

  async login() {

    this.isLoading = true;
    await this._commonCrudService.post("Users/Auth", this.loginForm.value, UserModel).then(res => {
      this.isLoading = false;

      if (res.succeeded == true) {

        if (res.data.isLocked) {
          this.showNotification = true;
          this._AlertService.Show('error', this.USER_BOLCKED);
        }
        else {

          if (res.data.mustChangePassword == true) {
            this._router.navigateByUrl("/auth/reset", { state: res.data });
          }
          else {
            this._UserService.onAuthorizationChange.next({ show: true, data: res.data });
            localStorage.setItem('sfc_token', res.data.token);
            localStorage.setItem('user', JSON.stringify(res.data));
            this._router.navigateByUrl(res.data.defualtUrl);
          }


        }
      }
      else {
        this._AlertService.Show('error', this.Invalid_username_or_Password);

      }

    })

  }

}
