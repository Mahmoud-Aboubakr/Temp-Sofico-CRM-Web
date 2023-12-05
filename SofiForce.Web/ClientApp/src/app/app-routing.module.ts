import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';


const routes: Routes = [
  { path: 'auth', loadChildren: () => import('./Modules/auth/auth.module').then(m => m.AuthModule) },
  { path: 'crm', loadChildren: () => import('./Modules/crm/crm.module').then(m => m.CRMModule) },
  { path: 'sales', loadChildren: () => import('./Modules/sales/sales.module').then(m => m.SalesModule) },
  { path: 'rtm', loadChildren: () => import('./Modules/rtm/rtm.module').then(m => m.RTMModule) },
  { path: 'inventory', loadChildren: () => import('./Modules/inventory/inventory.module').then(m => m.InventoryModule) },
  { path: 'settings', loadChildren: () => import('./Modules/settings/settings.module').then(m => m.SettingsModule) },
  { path: 'notification', loadChildren: () => import('./Modules/notifications/notification.module').then(m => m.NotificationModule) },

  { path: '', pathMatch: 'full', redirectTo: '/' },
  { path: '**', redirectTo: '/auth/error-401' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules, relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})

export class AppRoutingModule { }
