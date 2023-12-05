import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from 'src/app/core/Common/auth.guard';
import { ManageClientComponent } from './components/manage-client/manage-client.component';
import { ClientsComponent } from './clients/clients.component';
import { ClientStatisticalComponent } from './components/client-statistical/client-statistical.component';
import { ClientComplainsComponent } from './client-complains/client-complains.component';
import { ManageClientComplainComponent } from './components/manage-client-complain/manage-client-complain.component';
import { ClientServiceRequestComponent } from './client-service-request/client-service-request.component';
import { ManageClientServiceRequestComponent } from './components/manage-client-service-request/manage-client-service-request.component';
import { ClientSurveyComponent } from './client-survey/client-survey.component';
import { ManageClientSurveyComponent } from './components/manage-client-survey/manage-client-survey.component';
import { ManageActivityComponent } from './components/manage-activity/manage-activity.component';
import { CallActivitesComponent } from './call-activites/call-activites.component';
import { VisitActivitesComponent } from './visit-activites/visit-activites.component';




const routes: Routes = [
  {
    path: 'Clients',
    component: ClientsComponent,
    canActivate:[AuthGuard],
    data: { title: 'Clients',code:'SFC-016' }
  },
  {
    path: 'complains',
    component: ClientComplainsComponent,
    canActivate:[AuthGuard],
    data: { title: 'complains',code:'SFC-022' }
  },
  {
    path: 'service-request',
    component: ClientServiceRequestComponent,
    canActivate:[AuthGuard],
    data: { title: 'Service Requests',code:'SFC-023' }
  },
  {
    path: 'Campains',
    component: ClientComplainsComponent,
    canActivate:[AuthGuard],
    data: { title: 'Campains',code:'SFC-022' }
  },
  {
    path: 'Survy',
    component: ClientSurveyComponent,
    canActivate:[AuthGuard],
    data: { title: 'Client Survy',code:'SFC-025' }
  },
  {
    path: 'calls',
    component: CallActivitesComponent,
    canActivate:[AuthGuard],
    data: { title: 'calls',code:'SFC-029' }
  },
  {
    path: 'visits',
    component: VisitActivitesComponent,
    canActivate:[AuthGuard],
    data: { title: 'Visits',code:'SFC-030' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CRMRoutingModule {
  static components = [
    ManageClientComponent,
    ClientsComponent,
    ClientStatisticalComponent,
    ClientComplainsComponent,
    ManageClientComplainComponent,
    ClientServiceRequestComponent,
    ManageClientServiceRequestComponent,
    ClientSurveyComponent,
    ManageClientSurveyComponent,
    ManageActivityComponent,
    CallActivitesComponent,
    VisitActivitesComponent,
  ];

}