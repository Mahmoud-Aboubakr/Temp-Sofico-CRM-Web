import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ManageNotificationComponent } from './components/manage-notification/manage-notification.component';
import { MyNotificationsComponent } from './my-notifications/my-notifications.component';
import { NotificationsComponent } from './notifications/notifications.component';





const routes: Routes = [
  {
    path: 'my',
    component: MyNotificationsComponent,
    //canActivate:[AuthGuard],
    data: { title: 'My Notification',code:'SFC-032' }
  },
  {
    path: 'all',
    component: NotificationsComponent,
    //canActivate:[AuthGuard],
    data: { title: 'My Notification',code:'SFC-031' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class NotificationRoutingModule {
  static components = [
    ManageNotificationComponent,
    NotificationsComponent,
    MyNotificationsComponent
  ];

}