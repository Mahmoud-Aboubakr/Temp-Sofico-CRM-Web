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
import { SalesRoutingModule } from './sales-routing.module';
import { LayoutModule } from 'src/app/layout/layout.module';
import { SharedComponentsModule } from '../shared/shared.components.module';
import { OrderControlComponent } from './order-control/order-control.component';
import { SyncManagerComponent } from './components/sync-manager/sync-manager.component';
import { SalemanPerformanceTrackingDetailsComponent } from './components/saleman-performance-tracking-details/saleman-performance-tracking-details.component';
import { ClientRoutesManagerComponent } from './components/client-routes-manager/client-routes-manager.component';
import { ClientRoutesComponent } from './client-routes/client-routes.component';
import { PromotionOrdersListComponent } from './components/promotion-orders-list/promotion-orders-list.component';
import { PromotionItemListComponent } from './components/promotion-item-list/promotion-item-list.component';
import { PromotionLineListComponent } from './components/promotion-line-list/promotion-line-list.component';
import { ClientCreditLimitListComponent } from './client-credit-limit-list/client-credit-limit-list.component';


FullCalendarModule.registerPlugins([ // register FullCalendar plugins
  dayGridPlugin,
  timeGridPlugin,
  interactionPlugin
]);

@NgModule({
  imports: [
    CommonModule,
    SalesRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    TranslateModule,
    LayoutModule,
    PipeModule,
    SharedComponentsModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyDdyth2EiAjU9m9eE_obC5fnTY1yeVNTJU'
    }),
    FullCalendarModule,
    CKEditorModule,
    NgprimeCommon,
    NgxGaugeModule,
  ],
  
  declarations: [
    SalesRoutingModule.components,




  ],
  exports:[
    SalesRoutingModule.components,  
  ],

  providers: [BsDatepickerModule,DynamicDialogRef,DynamicDialogConfig]
})
export class SalesModule { }