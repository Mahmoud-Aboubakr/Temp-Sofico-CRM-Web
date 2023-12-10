import { ClientActivityListModel } from "../ListModels/ClientActivityListModel";
import { ClientComplainListModel } from "../ListModels/ClientComplainListModel";
import { ClientListModel } from "../ListModels/ClientListModel";
import { ClientServiceRequestListModel } from "../ListModels/ClientServiceRequestListModel";
import { ClientSurveyListModel } from "../ListModels/ClientSurveyListModel";
import { SalesOrderListModel } from "../ListModels/SalesOrderListModel";


export class ClientStatisticalModel {
    timelines: DashboardClientTimelineModel[];
    perfromanceModel: DashboardClientPerfromanceModel;
    orders: SalesOrderListModel[];
    visits: ClientActivityListModel[];
    calls: ClientActivityListModel[];
    complains: ClientComplainListModel[];
    requests: ClientServiceRequestListModel[];
    survies: ClientSurveyListModel[];
    vendors: DashboardClientSalesVendorModel[];
    items: DashboardClientSalesItemModel[];
    clientModel: ClientListModel;
}

export class DashboardClientTimelineModel {
    lineLabel: number;
    lineValue: number;
    lineTarget: number;
}

export class DashboardClientPerfromanceModel {
    label: string;
    percentage: number;
    sales: number;
    target: number;
}

export class DashboardClientSalesItemModel {
    itemId: number;
    itemCode: string;
    itemName: string;
    lineValue: number;
    percentage: number;
    lastInvoice:Date;
}

export class DashboardClientSalesVendorModel {
    vendorId: number;
    vendorCode: string;
    vendorName: string;
    lineValue: number;
    percentage: number;
    lastInvoice:Date;
}