import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { ErrorPageComponent } from './error-page/error-page.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { ManageUserAccessComponent } from './components/manage-user-access/manage-user-access.component';
import { UsersListComponent } from './users-list/users-list.component';
import { AuthGuard } from 'src/app/core/Common/auth.guard';


const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
    data: { title: ':: Sofico Fieldforce :: Log In' }
  },
  {
    path: 'reset',
    component: ResetPasswordComponent,
    data: { title: ':: Sofico Fieldforce :: Reset Password' }
  },
  {
    path: 'error-401',
    component: ErrorPageComponent,
    data: { title: ':: Sofico Fieldforce :: Error-404' }
  },
  {
    path: 'users',
    canActivate:[AuthGuard],
    component: UsersListComponent,
    data: { title: 'users',code:'SFC-054' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AuthRoutingModule {

  static components = [
    LoginComponent,
    ErrorPageComponent,
    ResetPasswordComponent,
    ManageUserAccessComponent
  ];
}