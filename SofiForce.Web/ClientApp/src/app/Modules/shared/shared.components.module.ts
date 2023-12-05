import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { FullCalendarModule } from '@fullcalendar/angular'; // the main connector. must go first
import dayGridPlugin from '@fullcalendar/daygrid'; // a plugin
import interactionPlugin from '@fullcalendar/interaction'; // a plugin
import timeGridPlugin from '@fullcalendar/timegrid';
import { AgmCoreModule } from '@agm/core';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';


import { NgprimeCommon } from 'src/app/core/Common/ngprime.common';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';

import { TranslateModule } from '@ngx-translate/core';
import { NgxGaugeModule } from 'ngx-gauge';

import { PipeModule } from '../../core/Pipes/pipe.module';
import { LayoutModule } from 'src/app/layout/layout.module';
import { ChooserClientComponent } from './chooser-client/chooser-client.component';
import { ChooserProductComponent } from './chooser-product/chooser-product.component';
import { ChooserRepresentativeComponent } from './chooser-representative/chooser-representative.component';
import { ChooserBatchComponent } from './chooser-batch/chooser-batch.component';
import { ChooserVendorComponent } from './chooser-vendor/chooser-vendor.component';
import { ChooserBranchComponent } from './chooser-branch/chooser-branch.component';
import { ChooserSupervisorComponent } from './chooser-supervisor/chooser-supervisor.component';
import { ChooserStoreComponent } from './chooser-store/chooser-store.component';
import { ChooserPromotionComponent } from './chooser-promotion/chooser-promotion.component';
import { ErrorDialogComponent } from './dialogs/error-dialog/error-dialog.component';
import { ChooserItemGroupComponent } from './chooser-item-group/chooser-item-group.component';
import { ChooserClientTypeComponent } from './chooser-client-type/chooser-client-type.component';
import { ChooserPaymentTermComponent } from './chooser-payment-term/chooser-payment-term.component';
import { ChooserGovernerateComponent } from './chooser-governerate/chooser-governerate.component';
import { ChooserCityComponent } from './chooser-city/chooser-city.component';
import { ChooserLocationLevelComponent } from './chooser-location-level/chooser-location-level.component';
import { ChooserRouteComponent } from './chooser-route/chooser-route.component';
import { ChooserProductAllComponent } from './chooser-product-all/chooser-product-all.component';
import { ChooserClientGroupComponent } from './chooser-client-group/chooser-client-group.component';
import { ChooserInvoiceComponent } from './chooser-invoice/chooser-invoice.component';
import { ChooserClientAttributeComponent } from './chooser-client-attribute/chooser-client-attribute.component';

FullCalendarModule.registerPlugins([ // register FullCalendar plugins
  dayGridPlugin,
  timeGridPlugin,
  interactionPlugin
]);

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    TranslateModule,
    LayoutModule,
    PipeModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyDdyth2EiAjU9m9eE_obC5fnTY1yeVNTJU'
    }),
    FullCalendarModule,
    CKEditorModule,
    NgprimeCommon,
    NgxGaugeModule,
  ],
  declarations: [

    ChooserClientComponent,
    ChooserProductComponent,
    ChooserRepresentativeComponent,
    ChooserBatchComponent,
    ChooserVendorComponent,
    ChooserBranchComponent,
    ChooserSupervisorComponent,
    ChooserStoreComponent,
    ChooserPromotionComponent,
    ErrorDialogComponent,
    ChooserItemGroupComponent,
    ChooserClientTypeComponent,
    ChooserPaymentTermComponent,
    ChooserGovernerateComponent,
    ChooserCityComponent,
    ChooserLocationLevelComponent,
    ChooserRouteComponent,
    ChooserProductAllComponent,
    ChooserClientGroupComponent,
    ChooserInvoiceComponent,
    ChooserClientAttributeComponent,
    
  ],
  exports:[
    ChooserClientComponent,
    ChooserProductComponent,
    ChooserRepresentativeComponent,
    ChooserBatchComponent,
    ChooserVendorComponent,
    ChooserBranchComponent,
    ChooserSupervisorComponent,
    ChooserStoreComponent,
  ],

  providers: [BsDatepickerModule, DynamicDialogRef, DynamicDialogConfig]
})
export class SharedComponentsModule { }