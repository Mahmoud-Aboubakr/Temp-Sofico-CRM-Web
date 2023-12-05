import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CarouselModule } from 'ngx-bootstrap/carousel';
import { ReactiveFormsModule } from '@angular/forms';

import { NgprimeCommon } from 'src/app/core/Common/ngprime.common';
import { TranslateModule } from '@ngx-translate/core';
import { AuthRoutingModule } from './auth-routing.module';
import { DynamicDialogRef } from 'primeng/dynamicdialog';
import { NgOtpInputModule } from  'ng-otp-input';
import { UsersListComponent } from './users-list/users-list.component';

@NgModule({
  imports: [
    CommonModule,
    AuthRoutingModule,
    TranslateModule,
    ReactiveFormsModule,
    CarouselModule.forRoot(),
    NgprimeCommon,
    NgOtpInputModule 

  ],
  declarations: [AuthRoutingModule.components, UsersListComponent],
  exports:[AuthRoutingModule.components],
  providers: [DynamicDialogRef]
})
export class AuthModule { }