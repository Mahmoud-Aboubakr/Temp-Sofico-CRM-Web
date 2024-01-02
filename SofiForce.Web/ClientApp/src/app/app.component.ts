import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { filter } from 'rxjs/operators';



import { TranslateService } from '@ngx-translate/core';
import * as signalR from '@microsoft/signalr';
import { environment } from 'src/environments/environment';
import { NotificationDtoModel } from './core/Models/DtoModels/NotificationDtoModel';
import { UserService } from './core/services/User.Service';
import { NotificationSearchModel } from './core/Models/SearchModels/NotificationSearchModel';
import { DialogService } from 'primeng/dynamicdialog';
import { CommonCrudService } from './core/services/CommonCrud.service';
import { WebSetting } from './core/Models/EntityModels/WebSetting';
import { UserNotificationListModel } from './core/Models/ListModels/UserNotificationListModel';
import { NotificationModel } from './core/Models/EntityModels/NotificationModel';
import { UtilService } from './core/services/util.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']

})
export class AppComponent implements OnInit {
  title = 'Sofico';
  greenClass: any;
  orageClass: boolean;
  blushClass: boolean;
  cyanClass: boolean = true;
  timberClass: boolean;
  blueClass: boolean;
  amethystClass: boolean;
  IsAuth: boolean = false;

  displayModal = false;
  showNotification = false;
  isLoading = false;
  notification: NotificationDtoModel = {} as NotificationDtoModel;


  searchModel: NotificationSearchModel = {
    Take: 10000,
    Skip: 0,
    Term: '',
    FilterBy: [],
    SortBy: undefined,
    notificationDate: undefined,
    priorityId: 0,
    notificationTypeId: 0,
    userGroupId: 0,
    isReaded: 2,
    TermBy:""
  }
  EDIT_HEADER = '';
  constructor(private router: Router,
    private _translateService: TranslateService,
    private _auth: UserService,
    private dialogService: DialogService,
    private activatedRoute: ActivatedRoute,
    private titleService: Title,
    private _CommonCrudService:CommonCrudService, 
    private _Utilervice:UtilService,
    ) {


    this._translateService.addLangs(['en', 'ar']);

    // Set the default language
    this._translateService.setDefaultLang('en');

    if (localStorage.getItem("lan")) {
      this._translateService.use(localStorage.getItem("lan"));
    }


    this._translateService.get('Promotion Details').subscribe((res) => { this.EDIT_HEADER = res });

    this._CommonCrudService.post("Notification/My",this.searchModel,UserNotificationListModel).then(res => {
      if (res.succeeded == true) {
        var unreadedCount = res.data.filter(re => re.isReaded == false).length;
        this._Utilervice.Counter.next(unreadedCount);
      }
    })

    setInterval(() => {
      this._CommonCrudService.post("Notification/My",this.searchModel,UserNotificationListModel).then(res => {
        if (res.succeeded == true) {
          var unreadedCount = res.data.filter(re => re.isReaded == false).length;
          this._Utilervice.Counter.next(unreadedCount);
        }
      })
    }, 60 * 1000)


  }
  ngOnInit(): void {


    (function (d, m) {
      var kommunicateSettings = {
        appId: "3e02f1c0e9c19263dabab2e2cdb7f1c01",
        popupWidget: true,
        automaticChatOpenOnNavigation: true,
      };
      var s = document.createElement("script");
      s.type = "text/javascript";
      s.async = true;
      s.src = "https://widget.kommunicate.io/v2/kommunicate.app";
      var h = document.getElementsByTagName("head")[0];
      h.appendChild(s);
      (window as any).kommunicate = m;
      m._globals = kommunicateSettings;
    })(document, (window as any).kommunicate || {});



    if (window.location.pathname.toLowerCase().startsWith("/auth")) {
      this.IsAuth = false;
    }
    else {
      this.IsAuth = true;
    }
    
    this._CommonCrudService.get("Setting/WebSetting",WebSetting).then(res=>{
      
    })

    const body = document.getElementsByTagName('body')[0];

    if (localStorage.getItem("lan") && localStorage.getItem("lan") == "ar") {
      body.classList.add('rtl');
    }



    if (localStorage.getItem("menu")) {
      body.classList.add('offcanvas-active');
    }

    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd),
    )
      .subscribe(() => {

        var rt = this.getChild(this.activatedRoute)

        rt.data.subscribe(data => {
          this.titleService.setTitle(data.title)
        })
      });

    setTimeout(() => {

      document.getElementsByClassName('page-loader-wrapper')[0].classList.add("HideDiv");

    }, 1000);

    /*
    var token = localStorage.getItem('sfc_token')

    const connection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Information)
      .withUrl(environment.urlHub + 'AppHub' + '?access_token=' + token)
      .build();

    connection.start().then(function () {
      console.log('SignalR Connected!');
    }).catch(function (err) {
      return console.log(err.toString());
    });

    connection.on("notify", (data) => {
      console.log(data);
      this.notification = data;
      this.showNotification = true;
    });

    

    connection.on("lock", (data) => {
      console.log(data);
      this.router.navigateByUrl("/auth/login");
    });


    connection.on("promo", (data) => {
      var ref = this.dialogService.open(ManagePromotionComponent, {
        header: this.EDIT_HEADER,
        data: { promotionId: data,promotionCategoryId:2 },
        width: '900px',
        contentStyle: { "max-height": "700px", "height": "700px", "overflow": "auto" },
        baseZIndex: 10000
      });
    });
*/
    var current = this._auth.Current();
    if (current == null || current == undefined) {
      this.router.navigateByUrl("/auth/login");
    }

  var current=this._auth.Current();
  if(current && current.defualtUrl){
    this.router.navigateByUrl(current.defualtUrl);
  }

  }


  getChild(activatedRoute: ActivatedRoute) {
    if (activatedRoute.firstChild) {
      return this.getChild(activatedRoute.firstChild);
    } else {
      return activatedRoute;
    }
  }
  toggleThemeSetting() {
    const className = document.getElementsByClassName('themesetting')[0];
    className.classList.toggle('open');
  }


  closeMenu() {
    document.getElementsByClassName('right_sidebar')[0].classList.remove("open");
    document.getElementsByClassName('user_div')[0].classList.remove("open");
    document.getElementsByClassName('overlay')[0].classList.remove("open");
  }
  markAsReaded() {
    this.isLoading = true;
    this._CommonCrudService.post("Notification/markAsRead",this.notification,NotificationModel).then(res => {
      this.isLoading = false;
      this.showNotification = false;
    });
  }
  
}
