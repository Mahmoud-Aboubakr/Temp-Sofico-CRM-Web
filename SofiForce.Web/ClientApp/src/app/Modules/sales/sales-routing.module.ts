import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';



import { AuthGuard } from 'src/app/core/Common/auth.guard';
import { JourneyPlanComponent } from './journey-plan/journey-plan.component';
import { ManageJourneyPlanComponent } from './components/manage-journey-plan/manage-journey-plan.component';
import { JourneyPlanStatisticsComponent } from './components/journey-plan-statistics/journey-plan-statistics.component';
import { ManageSalesPlanComponent } from './components/manage-sales-plan/manage-sales-plan.component';
import { SalesPlanStatisticsComponent } from './components/sales-plan-statistics/sales-plan-statistics.component';
import { SalesPlanComponent } from './sales-plan/sales-plan.component';
import { ManageSalesPlanCustomComponent } from './components/manage-sales-plan-custom/manage-sales-plan-custom.component';
import { BranchsComponent } from './branchs/branchs.component';
import { SupervisorsComponent } from './supervisors/supervisors.component';
import { RepresentitivesComponent } from './representitives/representitives.component';
import { ManageSupervisorComponent } from './components/manage-supervisor/manage-supervisor.component';
import { ManageRepreseentitiveComponent } from './components/manage-represeentitive/manage-represeentitive.component';
import { ManageBranchComponent } from './components/manage-branch/manage-branch.component';
import { ManageSupervisorRepresentitiveComponent } from './components/manage-supervisor-representitive/manage-supervisor-representitive.component';
import { SupervisorStatisticsComponent } from './components/supervisor-statistics/supervisor-statistics.component';
import { RepresentitiveStatisticsComponent } from './components/representitive-statistics/representitive-statistics.component';
import { ManageSalesOrderComponent } from './components/manage-sales-order/manage-sales-order.component';
import { MyDashboardComponent } from './my-dashboard/my-dashboard.component';
import { MyPlanComponent } from './my-plan/my-plan.component';
import { OrderAllComponent } from './order-all/order-all.component';
import { SalesControlRepresentativeComponent } from './sales-control-representative/sales-control-representative.component';
import { SalesControlSupervisorComponent } from './sales-control-supervisor/sales-control-supervisor.component';
import { SalesControlBranchComponent } from './sales-control-branch/sales-control-branch.component';
import { ManageSalesOrderWorkflowComponent } from './components/manage-sales-order-workflow/manage-sales-order-workflow.component';
import { SalesControlClientComponent } from './sales-control-client/sales-control-client.component';
import { TrackingGpsComponent } from './tracking-gps/tracking-gps.component';
import { TrackingGpsDetailComponent } from './components/tracking-gps-detail/tracking-gps-detail.component';
import { SalesDashboardComponent } from './sales-dashboard/sales-dashboard.component';
import { PromotionsComponent } from './promotions/promotions.component';
import { PromotionsCashComponent } from './promotions-cash/promotions-cash.component';
import { ManagePromotionTypeComponent } from './components/manage-promotion-type/manage-promotion-type.component';
import { ManagePromotionClientAttrComponent } from './components/manage-promotion-client-attr/manage-promotion-client-attr.component';
import { ManagePromotionCriteriaAttrComponent } from './components/manage-promotion-criteria-attr/manage-promotion-criteria-attr.component';
import { ViewSalesOrderLogComponent } from './components/view-sales-order-log/view-sales-order-log.component';
import { ViewClientQuotaComponent } from './components/view-client-quota/view-client-quota.component';
import { ManagePromotionComponent } from './components/manage-promotion/manage-promotion.component';
import { ViewPromotionComponent } from './components/view-promotion/view-promotion.component';
import { ViewStoreBalanceComponent } from './components/view-store-balance/view-store-balance.component';
import { PromotionsConditionComponent } from './promotions-condition/promotions-condition.component';
import { PromotionsGroupComponent } from './promotions-group/promotions-group.component';
import { PromotionsItemAttributeComponent } from './promotions-item-attribute/promotions-item-attribute.component';
import { PromotionsClientAttributeComponent } from './promotions-client-attribute/promotions-client-attribute.component';
import { PromotionsSalesmanAttributeComponent } from './promotions-salesman-attribute/promotions-salesman-attribute.component';
import { ManagePromotionSalesManAttrComponent } from './components/manage-promotion-salesman-attr/manage-promotion-salesman-attr.component';
import { ManagePromotionBundleComponent } from './components/manage-promotion-bundle/manage-promotion-bundle.component';
import { PromotionsGeneralComponent } from './promotions-general/promotions-general.component';
import { PromotionsBundleComponent } from './promotions-bundle/promotions-bundle.component';
import { SalesOrderRejectedComponent } from './sales-order-rejected/sales-order-rejected.component';
import { SalesMonitorBranchComponent } from './sales-monitor-branch/sales-monitor-branch.component';
import { OrderRejectedComponent } from './order-rejected/order-rejected.component';
import { ManagePromotionUploadComponent } from './components/manage-promotion-upload/manage-promotion-upload.component';
import { OrderConfirmedComponent } from './order-confirmed/order-confirmed.component';
import { OrderExternalComponent } from './order-external/order-external.component';
import { OrderReturnComponent } from './order-return/order-return.component';
import { OrderTransferComponent } from './order-transfer/order-transfer.component';
import { ManageReturnValidComponent } from './components/manage-return-valid/manage-return-valid.component';
import { ManageReturnExpiredComponent } from './components/manage-return-expired/manage-return-expired.component';
import { ManageExporterComponent } from './components/manage-exporter/manage-exporter.component';
import { ManageSupervisorComissionComponent } from './components/manage-supervisor-comission/manage-supervisor-comission.component';
import { ManageRepresentativeComissionComponent } from './components/manage-representative-comission/manage-representative-comission.component';
import { RouteSetupListComponent } from './route-setup-list/route-setup-list.component';
import { OrderControlComponent } from './order-control/order-control.component';
import { SyncManagerComponent } from './components/sync-manager/sync-manager.component';
import { SalemanPerformanceTrackingDetailsComponent } from './components/saleman-performance-tracking-details/saleman-performance-tracking-details.component';
import { ClientRoutesManagerComponent } from './components/client-routes-manager/client-routes-manager.component';
import { ClientRoutesComponent } from './client-routes/client-routes.component';
import { OrderCashAllComponent } from './order-cash-all/order-cash-all.component';
import { PromotionLineListComponent } from './components/promotion-line-list/promotion-line-list.component';
import { PromotionOrdersListComponent } from './components/promotion-orders-list/promotion-orders-list.component';
import { PromotionItemListComponent } from './components/promotion-item-list/promotion-item-list.component';
import { ClientCreditLimitListComponent } from './client-credit-limit-list/client-credit-limit-list.component';




const routes: Routes = [
  {
    path: 'Dashboard',
    component: SalesDashboardComponent,
    canActivate:[AuthGuard],
    data: { title: 'Sales Dashboard',code:'SFC-021' }
  },
  {
    path: 'journey',
    component: JourneyPlanComponent,
    canActivate:[AuthGuard],
    data: { title: 'Journy Plan',code:'SFC-012' }
  },
  {
    path: 'plan',
    component: SalesPlanComponent,
    canActivate:[AuthGuard],
    data: { title: 'Sales Plan',code:'SFC-013' }
  },
  {
    path: 'branchs',
    component: BranchsComponent,
    canActivate:[AuthGuard],
    data: { title: 'Branchs',code:'SFC-014' }
  },
  {
    path: 'Supervisors',
    component: SupervisorsComponent,
    canActivate:[AuthGuard],
    data: { title: 'Supervisors',code:'SFC-015' }
  },
  {
    path: 'Representitives',
    component: RepresentitivesComponent,
    canActivate:[AuthGuard],
    data: { title: 'Representitives',code:'SFC-017' }
  },
  {
    path: 'all',
    component: OrderAllComponent,
    canActivate:[AuthGuard],
    data: { title: 'Sales Orders',code:'SFC-004' }
  },
  {
    path: 'cash',
    component: OrderCashAllComponent,
    canActivate:[AuthGuard],
    data: { title: 'Cash SalesOrder',code:'SFC-055' }
  },
  {
    path: 'rejected',
    component: OrderRejectedComponent,
    canActivate:[AuthGuard],
    data: { title: 'Rejected Orders',code:'SFC-043' }
  },
  {
    path: 'confirmed',
    component: OrderConfirmedComponent,
    canActivate:[AuthGuard],
    data: { title: 'Confirmed Orders',code:'SFC-044' }
  },
  {
    path: 'external',
    component: OrderExternalComponent,
    canActivate:[AuthGuard],
    data: { title: 'External Orders',code:'SFC-005' }
  },
  {
    path: 'transfer',
    component: OrderTransferComponent,
    canActivate:[AuthGuard],
    data: { title: 'Transfer Orders',code:'SFC-046' }
  },
  {
    path: 'return-order',
    component: OrderReturnComponent,
    canActivate:[AuthGuard],
    data: { title: 'Return Orders',code:'SFC-045' }
  },
  {
    path: 'myplan',
    component: MyPlanComponent,
    canActivate:[AuthGuard],
    data: { title: 'My Plan',code:'SFC-002' }
  },
  {
    path: 'mydashboard',
    component: MyDashboardComponent,
    canActivate:[AuthGuard],
    data: { title: 'My Dashbaord',code:'SFC-001' }
  },
  {
    path: 'control/Representative',
    component: SalesControlRepresentativeComponent,
    canActivate:[AuthGuard],
    data: { title: 'Representative Control',code:'SFC-009' }
  },
  {
    path: 'control/Supervisor',
    component: SalesControlSupervisorComponent,
    canActivate:[AuthGuard],
    data: { title: 'Supervisor Control',code:'SFC-008' }
  },
  {
    path: 'control/Branch',
    component: SalesControlBranchComponent,
    canActivate:[AuthGuard],
    data: { title: 'Branch Control',code:'SFC-007' }
  },
  {
    path: 'control/Client',
    component: SalesControlClientComponent,
    canActivate:[AuthGuard],
    data: { title: 'Client Control' ,code:'SFC-010'}
  },
  {
    path: 'tracking/gps',
    component: TrackingGpsComponent,
    canActivate:[AuthGuard],
    data: { title: 'GPS Tracking',code:'SFC-011' }
  },
    {
    path: 'promotions',
    component: PromotionsComponent,
    canActivate:[AuthGuard],
    data: { title: 'Promotions',code:'SFC-028' }
  },
  {
    path: 'cash-plan',
    component: PromotionsCashComponent,
    canActivate:[AuthGuard],
    data: { title: 'cash plan',code:'SFC-035' }
  },
  {
    path: 'supplementary',
    component: PromotionsGeneralComponent,
    canActivate:[AuthGuard],
    data: { title: 'supplementary',code:'SFC-041' }
  },
  {
    path: 'bundles',
    component: PromotionsBundleComponent,
    canActivate:[AuthGuard],
    data: { title: 'Bundles',code:'SFC-042' }
  },
  {
    path: 'promotions/conditions',
    component: PromotionsConditionComponent,
    canActivate:[AuthGuard],
    data: { title: 'promotions Conditions',code:'SFC-036' }
  },
  {
    path: 'promotions/groups',
    component: PromotionsGroupComponent,
    canActivate:[AuthGuard],
    data: { title: 'Promotion Group',code:'SFC-037' }
  },
  {
    path: 'promotions/item-attr',
    component: PromotionsItemAttributeComponent,
    canActivate:[AuthGuard],
    data: { title: 'Promotion Item Attribute',code:'SFC-038' }
  },
  {
    path: 'promotions/client-attr',
    component: PromotionsClientAttributeComponent,
    canActivate:[AuthGuard],
    data: { title: 'Promotion Client Attribute',code:'SFC-039' }
  },
  {
    path: 'promotions/salesman-attr',
    component: PromotionsSalesmanAttributeComponent,
    canActivate:[AuthGuard],
    data: { title: 'Promotion Salesman Attribute',code:'SFC-040' }
  },
  {
    path: 'rejected',
    component: SalesOrderRejectedComponent,
    canActivate:[AuthGuard],
    data: { title: 'Promotion Salesman Attribute',code:'SFC-040' }
  },
  {
    path: 'monitor',
    component: SalesMonitorBranchComponent,
    canActivate:[AuthGuard],
    data: { title: 'Orders Monitor',code:'SFC-040' }
  },
  {
    path: 'Routes',
    component: RouteSetupListComponent,
    canActivate:[AuthGuard],
    data: { title: 'Routes Setup',code:'SFC-049' }
  },
  {
    path: 'control',
    component: OrderControlComponent,
    canActivate:[AuthGuard],
    data: { title: 'Order Control',code:'SFC-050' }
  },
  {
    path: 'client-routes',
    component: ClientRoutesComponent,
    canActivate:[AuthGuard],
    data: { title: 'Client Routes',code:'SFC-053' }
  },
  {
    path: 'reports/promotion-outcome',
    component: PromotionLineListComponent,
    canActivate:[AuthGuard],
    data: { title: 'Promotion Outcome Report',code:'SFC-056' }
  },
  {
    path: 'sales-limit',
    component: ClientCreditLimitListComponent,
    canActivate:[AuthGuard],
    data: { title: 'Sales Limit Manager',code:'SFC-057' }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SalesRoutingModule {
  static components = [
    JourneyPlanComponent,
    SalesPlanComponent,
    ManageJourneyPlanComponent,
    JourneyPlanStatisticsComponent,
    ManageSalesPlanComponent,
    SalesPlanStatisticsComponent,
    ManageSalesPlanCustomComponent,
    BranchsComponent,
    SupervisorsComponent,
    RepresentitivesComponent,
    ManageSupervisorComponent,
    ManageBranchComponent,
    ManageRepreseentitiveComponent,
    ManageSupervisorRepresentitiveComponent,
    SupervisorStatisticsComponent,
    RepresentitiveStatisticsComponent,
    ManageSalesOrderComponent,
    MyDashboardComponent,
    MyPlanComponent,
    OrderAllComponent,  
    SalesControlRepresentativeComponent,
    SalesControlSupervisorComponent,
    SalesControlBranchComponent,
    ManageSalesOrderWorkflowComponent,
    SalesControlClientComponent,
    TrackingGpsComponent,
    TrackingGpsDetailComponent,
    SalesDashboardComponent,
    PromotionsComponent,
    PromotionsComponent,
    ManagePromotionComponent,
    ViewPromotionComponent,
    ViewStoreBalanceComponent,
    ViewClientQuotaComponent,
    ViewSalesOrderLogComponent,
    ManagePromotionCriteriaAttrComponent,
    ManagePromotionClientAttrComponent,
    ManagePromotionTypeComponent,
    PromotionsCashComponent,
    PromotionsConditionComponent,
    PromotionsGroupComponent,
    PromotionsItemAttributeComponent,
    PromotionsClientAttributeComponent,
    PromotionsSalesmanAttributeComponent,
    ManagePromotionSalesManAttrComponent,
    ManagePromotionBundleComponent,
    PromotionsGeneralComponent,
    PromotionsBundleComponent,
    SalesOrderRejectedComponent,
    SalesMonitorBranchComponent,
    ManagePromotionUploadComponent,
    OrderRejectedComponent,
    OrderConfirmedComponent,
    OrderExternalComponent,
    OrderReturnComponent,
    ManageReturnValidComponent,
    ManageReturnExpiredComponent,
    OrderTransferComponent,
    ManageExporterComponent,
    ManageSupervisorComissionComponent,
    ManageRepresentativeComissionComponent,
    RouteSetupListComponent,
    OrderControlComponent,
    SyncManagerComponent,
    SalemanPerformanceTrackingDetailsComponent,
    ClientRoutesManagerComponent,
    ClientRoutesComponent,
    OrderCashAllComponent,
    PromotionOrdersListComponent,
    PromotionItemListComponent,
    PromotionLineListComponent,
    ClientCreditLimitListComponent,
  ];

}