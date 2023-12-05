import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { AuthGuard } from 'src/app/core/Common/auth.guard';
import { ScanRequestComponent } from '../rtm/operation-request/scan-request.component';
import { WarehousesComponent } from './warehouses/warehouses.component';
import { VendorsComponent } from './vendors/vendors.component';
import { ProductsComponent } from './products/products.component';
import { ManageProductComponent } from './components/manage-product/manage-product.component';
import { ManageVendorComponent } from './components/manage-vendor/manage-vendor.component';
import { ManageWarehouseComponent } from './components/manage-warehouse/manage-warehouse.component';






const routes: Routes = [
  {
    path: 'products',
    component: ProductsComponent,
    canActivate:[AuthGuard],
    data: { title: 'products',code:'SFC-019' }
  },
  {
    path: 'suppliers',
    component: VendorsComponent,
    canActivate:[AuthGuard],
    data: { title: 'suppliers' ,code:'SFC-018'}
  },
  {
    path: 'warehouses',
    component: WarehousesComponent,
    canActivate:[AuthGuard],
    data: { title: 'warehouses' ,code:'SFC-020'}
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class InventoryRoutingModule {
  static components = [
    WarehousesComponent,
    VendorsComponent,
    ProductsComponent,
    ManageProductComponent,
    ManageVendorComponent,
    ManageWarehouseComponent,
  ];

}