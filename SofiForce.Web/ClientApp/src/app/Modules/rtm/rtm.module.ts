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
import { RTMRoutingModule } from './rtm-routing.module';
import { LayoutModule } from 'src/app/layout/layout.module';
import { PipeModule } from 'src/app/core/Pipes/pipe.module';
import { ManageOperationRequestDetailComponent } from './components/manage-operation-request-detail/manage-operation-request-detail.component';
import { MapViewerComponent } from './components/map-viewer/map-viewer.component';


FullCalendarModule.registerPlugins([ // register FullCalendar plugins
  dayGridPlugin,
  timeGridPlugin,
  interactionPlugin
]);

@NgModule({
  imports: [
    CommonModule,
    RTMRoutingModule,
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
    RTMRoutingModule.components,
  ],
  exports:[RTMRoutingModule.components,],

  providers: [BsDatepickerModule,DynamicDialogRef,DynamicDialogConfig,TruncatePipe]
})
export class RTMModule { }