import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EditProfileComponent } from './components/edit-profile/edit-profile.component';
import { LanguageChooserComponent } from './components/language-chooser/language-chooser.component';



const routes: Routes = [
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SettingsRoutingModule {
  static components = [
    LanguageChooserComponent,
    EditProfileComponent,
  ];

}