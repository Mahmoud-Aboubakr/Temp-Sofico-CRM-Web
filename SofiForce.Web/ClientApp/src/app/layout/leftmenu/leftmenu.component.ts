import { Component, OnInit, Inject, Directive } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { AppComponent } from 'src/app/app.component';

import { locale as english } from './i18n/en';
import { locale as arabic } from './i18n/ar';
import { DialogService } from 'primeng/dynamicdialog';
import { MenuItem } from 'primeng/api';
import { TranslationLoaderService } from 'src/app/core/services/translation-loader.service';
import { UserModel } from 'src/app/core/Models/DtoModels/UserModel';
import { UserService } from 'src/app/core/services/User.Service';
import { LanguageChooserComponent } from 'src/app/Modules/settings/components/language-chooser/language-chooser.component';
import { ManageActivityComponent } from 'src/app/Modules/crm/components/manage-activity/manage-activity.component';
import { ManageClientComplainComponent } from 'src/app/Modules/crm/components/manage-client-complain/manage-client-complain.component';
import { ManageClientServiceRequestComponent } from 'src/app/Modules/crm/components/manage-client-service-request/manage-client-service-request.component';
import { ManageClientSurveyComponent } from 'src/app/Modules/crm/components/manage-client-survey/manage-client-survey.component';
import { ManageSalesOrderComponent } from 'src/app/Modules/sales/components/manage-sales-order/manage-sales-order.component';
import { ChooserPromotionComponent } from 'src/app/Modules/shared/chooser-promotion/chooser-promotion.component';
import { EditProfileComponent } from 'src/app/Modules/settings/components/edit-profile/edit-profile.component';
import { ManageExporterComponent } from 'src/app/Modules/sales/components/manage-exporter/manage-exporter.component';
import { ChooserProductComponent } from 'src/app/Modules/shared/chooser-product/chooser-product.component';
import { ChooserClientComponent } from 'src/app/Modules/shared/chooser-client/chooser-client.component';
import { SyncManagerComponent } from 'src/app/Modules/sales/components/sync-manager/sync-manager.component';
import { CommonCrudService } from '../../core/services/CommonCrud.service';
import { UtilService } from 'src/app/core/services/util.service';



@Component({
  selector: 'app-leftmenu',
  templateUrl: './leftmenu.component.html',
  styleUrls: ['./leftmenu.component.scss']
})
export class LeftmenuComponent implements OnInit {

  items: MenuItem[];
  current: UserModel;

  CHOOSE_LANGUAGE_HEADER = '';
  MANAGE_CALL = '';
  MANAGE_COMPLAIN = '';
  MANAGE_SURVEY = '';
  MANAGE_REQUEST = '';
  MANAGE_PROFILE = '';
  MANAGE_EXPORT = '';
  MANAGE_SYNC = '';

  CHOOSE = '';


  PROMOTIONS = '';

  showMenu = false;
  showOrder = false;


  notificationCount = 0;





  isCollapsedOrder = false;
  isCollapsedPerformance = true;
  isCollapsedTracking = true;
  isCollapsedCS = true;
  isCollapsedRTM = true;
  isCollapsedOffers = true;
  isCollapsedSetup = true;
  isCollapsedSecurity = true;
  isCollapsedReport = true;

  isCollapsedOrderControl=false;
  isTimeOff=true;
  displayTerminal=false;

  constructor(

    private _translateService: TranslateService,
    private _translationLoaderService: TranslationLoaderService,
    private _UserService: UserService,
    private dialogService: DialogService,
    private _router: Router,
    private _commonCrudService : CommonCrudService,
    private _UtilService : UtilService,
    ) {


    this._translationLoaderService.loadTranslations(english, arabic);
    this.current = JSON.parse(localStorage.getItem('user'))
    this._translateService.get('Choose language').subscribe((res) => { this.CHOOSE_LANGUAGE_HEADER = res });
    this._translateService.get('Create new call').subscribe((res) => { this.MANAGE_CALL = res });
    this._translateService.get('Promotions').subscribe((res) => { this.PROMOTIONS = res });
    this._translateService.get('Create new complain').subscribe((res) => { this.MANAGE_COMPLAIN = res });
    this._translateService.get('Create new Survey').subscribe((res) => { this.MANAGE_SURVEY = res });
    this._translateService.get('Create new Request').subscribe((res) => { this.MANAGE_REQUEST = res });
    this._translateService.get('Manage Profile').subscribe((res) => { this.MANAGE_PROFILE = res });
    this._translateService.get('Export Wizard').subscribe((res) => { this.MANAGE_EXPORT = res });
    this._translateService.get('Sync Manager').subscribe((res) => { this.MANAGE_SYNC = res });

    this._translateService.get('Choose').subscribe((res) => { this.CHOOSE = res });


    

    this._UtilService.Counter.subscribe(res => {
      this.notificationCount = res;
    })


    this._UserService.onAuthorizationChange.subscribe((res: any) => {
      this.showMenu = res.show;
      this.current = res.data;
    })

    this.showMenu = this._UserService.IsAuthorized()


    if ((this._router.url).startsWith('/sales')) {
      //this.isCollapsed = false;
    }

   


  }

  isArabic = true;
  slidemenu=false;
  toogleGroup=true;
  ngOnInit(): void {
  }
  toggleMenu() {

    this.slidemenu=!this.slidemenu;
  }


  ngAfterViewInit() {

  }



  logout() {
    localStorage.removeItem('user');
    localStorage.removeItem('sfc_token');
    this._router.navigateByUrl("/auth/login");
    this.showMenu = false;
  }

  ChangeLan(lang) {
    // Use a language
    localStorage.setItem("lan", lang);
    this._translateService.use(lang);

    if (lang == "ar") {
      this.isArabic = true;
    }
    else {
      this.isArabic = false;
    }

    window.location.reload();

  }

  CanView(code) {

    if (this.current == null || this.current.userFeatures == undefined || this.current.userFeatures == null) {
      return false;
    }

    let allowed = false;

    if (this.current != null) {

      var exist = this.current.userFeatures.find(a => a.featureCode == code);
      if (exist) {
        allowed = true;
      }

    }
    return allowed;

  }
  CanViewGroup(group: any[]) {


    if (this.current == null || this.current.userFeatures == undefined || this.current.userFeatures == null) {
      return false;
    }

    let allowed = false;

    if (group) {
      group.forEach(element => {
        var exist = this.current.userFeatures.find(a => a.featureCode == element);
        if (exist) {
          allowed = true;
        }
      });

    }
    return allowed;

  }

  choose_Language() {
    var ref = this.dialogService.open(LanguageChooserComponent, {
      header: this.CHOOSE_LANGUAGE_HEADER,
      width: '250px',
      contentStyle: { "max-height": "200px", "height": "200px", "overflow": "auto" },
      baseZIndex: 10000
    });

    ref.onClose.subscribe((lan) => {
      if (lan) {
        this.ChangeLan(lan);
      }
    });
  }
  getToHome() {
    if (this.current.defualtUrl) {
      this._router.navigateByUrl(this.current.defualtUrl);
    }
  }

  manage(operation) {

    
   
    if (operation == 'products') {
      var ref = this.dialogService.open(ChooserProductComponent, {
        data: {
          branchId: this.current.branchId,
          storeId: this.current.storeId
        },
        header: this.CHOOSE,
        width: '90%',
        contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
        baseZIndex: 10000
      });
    }

    if (operation == 'clients') {
      var ref = this.dialogService.open(ChooserClientComponent, {
        header: this.CHOOSE,
        width: '90%',
        contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
        baseZIndex: 10000
      });
    }

    if (operation == 'call') {
      var ref = this.dialogService.open(ManageActivityComponent, {
        data: { clientId: 0 },
        header: this.MANAGE_CALL,
        width: '400px',
        contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
        baseZIndex: 10000
      });
    }

    if (operation == 'complain') {
      var ref = this.dialogService.open(ManageClientComplainComponent, {
        data: { clientId: 0 },
        header: this.MANAGE_COMPLAIN,
        width: '1000px',
        contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
        baseZIndex: 10000
      });
    }

    if (operation == 'request') {
      var ref = this.dialogService.open(ManageClientServiceRequestComponent, {
        data: { clientId: 0 },
        header: this.MANAGE_REQUEST,
        width: '1000px',
        contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
        baseZIndex: 10000
      });
    }
    if (operation == 'survey') {
      var ref = this.dialogService.open(ManageClientSurveyComponent, {
        data: { clientId: 0 },
        header: this.MANAGE_SURVEY,
        width: '1200px',
        contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
        baseZIndex: 10000
      });
    }
    if (operation == 'sync') {
      var ref = this.dialogService.open(SyncManagerComponent, {
        header: this.MANAGE_SYNC,
        width: '1200px',
        contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
        baseZIndex: 10000
      });
    }

    if (operation == 'notification') {
      this._router.navigateByUrl("/notification/my")

    }

    if (operation == 'plan') {
      this._router.navigateByUrl("/sales/myplan")
    }

    if (operation == 'dashboard') {
      this._router.navigateByUrl("/sales/Dashboard")
    }

    if (operation == 'order') {
      var ref = this.dialogService.open(ManageSalesOrderComponent, {
        header: this.MANAGE_CALL,
        width: '95%',
        height: '95vh',
      });
    }

    if (operation == 'promotion') {
      var ref = this.dialogService.open(ChooserPromotionComponent, {
        header: this.CHOOSE,
        data: {
          branchId: this.current.branchId,
          storeId: this.current.storeId
        },
        width: '90%',
        contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
      });
    }

    if (operation == "home") {
      let model = {} as UserModel;
      model.defualtUrl = this._router.url;

      this._commonCrudService.post("Users/updateDefault", model, UserModel).then(res => {

        let user = this._UserService.Current();
        user.defualtUrl = this._router.url;
        localStorage.setItem("user", JSON.stringify(user));
        window.location.reload();
      });

    }

    if (operation == 'export') {
      var ref = this.dialogService.open(ManageExporterComponent, {
        data: { clientId: 0 },
        header: this.MANAGE_EXPORT,
        width: '600px',
        contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
        baseZIndex: 10000
      });
    }

  }
  openProfile() {
    var ref = this.dialogService.open(EditProfileComponent, {
      header: this.MANAGE_PROFILE,
      width: '500px',
      contentStyle: { "max-height": "720px", "height": "720px", "overflow": "auto" },
      baseZIndex: 10000
    });
  }
}
