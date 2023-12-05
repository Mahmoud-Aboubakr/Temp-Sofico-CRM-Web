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
import {  SettingsRoutingModule } from './settings-routing.module';
import { LayoutModule } from 'src/app/layout/layout.module';
import { SharedComponentsModule } from '../shared/shared.components.module';
import { EditProfileComponent } from './components/edit-profile/edit-profile.component';


FullCalendarModule.registerPlugins([ // register FullCalendar plugins
  dayGridPlugin,
  timeGridPlugin,
  interactionPlugin
]);

@NgModule({
  imports: [
    CommonModule,
    SettingsRoutingModule,
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
    SettingsRoutingModule.components,
  ],
  exports:[
    SettingsRoutingModule.components,  
  ],

  providers: [BsDatepickerModule,DynamicDialogRef,DynamicDialogConfig]
})
export class SettingsModule { }