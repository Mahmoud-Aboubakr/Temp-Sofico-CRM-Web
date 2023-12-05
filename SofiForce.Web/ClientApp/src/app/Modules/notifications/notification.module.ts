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
import { CountdownModule } from 'ngx-countdown';
import { TruncatePipe } from 'src/app/core/Pipes/truncate/Truncate.pipe';
import { NgxGaugeModule } from 'ngx-gauge';
import { NotificationRoutingModule } from './notification-routing.module';
import { LayoutModule } from 'src/app/layout/layout.module';
import { PipeModule } from 'src/app/core/Pipes/pipe.module';



FullCalendarModule.registerPlugins([ // register FullCalendar plugins
  dayGridPlugin,
  timeGridPlugin,
  interactionPlugin
]);

@NgModule({
  imports: [
    CommonModule,
    NotificationRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    CountdownModule,
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
    NotificationRoutingModule.components,
  ],
  exports:[NotificationRoutingModule.components,],

  providers: [BsDatepickerModule,DynamicDialogRef,DynamicDialogConfig,TruncatePipe]
})
export class NotificationModule { }