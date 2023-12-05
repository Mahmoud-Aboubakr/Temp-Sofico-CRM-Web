import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from 'src/app/core/Common/auth.guard';

import { ScanRequestComponent } from './operation-request/scan-request.component';
import { ManageScanRequestComponent } from './components/manage-operation-request/manage-scan-request.component';
import { ManageScanListComponent } from './components/manage-scan-list/manage-scan-list.component';
import { ManageValidationListComponent } from './components/manage-validation-list/manage-validation-list.component';
import { ManageValidationRequestComponent } from './components/manage-validation-request/manage-validation-request.component';
import { ValidationRequestComponent } from './validation-request/validation-request.component';
import { ManageOperationRequestDetailComponent } from './components/manage-operation-request-detail/manage-operation-request-detail.component';
import { MapViewerComponent } from './components/map-viewer/map-viewer.component';




const routes: Routes = [
  {
    path: 'scan',
    component: ScanRequestComponent,
    canActivate:[AuthGuard],
    data: { title: 'Scan Request',code:'SFC-026' }
  },
  {
    path: 'validation',
    component: ValidationRequestComponent,
    canActivate:[AuthGuard],
    data: { title: 'Validation Request',code:'SFC-027' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RTMRoutingModule {
  static components = [
    ManageScanRequestComponent,
    ScanRequestComponent,
    ManageScanListComponent,
    ManageValidationListComponent,
    ManageValidationRequestComponent,
    ValidationRequestComponent,
    ManageOperationRequestDetailComponent,
    MapViewerComponent,
  ];

}