import { ClientActivityListModel } from "../ListModels/ClientActivityListModel";
import { ClientComplainListModel } from "../ListModels/ClientComplainListModel";
import { ClientListModel } from "../ListModels/ClientListModel";
import { ClientServiceRequestListModel } from "../ListModels/ClientServiceRequestListModel";
import { ClientSurveyListModel } from "../ListModels/ClientSurveyListModel";
import { SalesOrderListModel } from "../ListModels/SalesOrderListModel";


export interface ClientStatisticalModel {
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

export interface DashboardClientTimelineModel {
    lineLabel: number;
    lineValue: number;
    lineTarget: number;
}

export interface DashboardClientPerfromanceModel {
    label: string;
    percentage: number;
    sales: number;
    target: number;
}

export interface DashboardClientSalesItemModel {
    itemId: number;
    itemCode: string;
    itemName: string;
    lineValue: number;
    percentage: number;
    lastInvoice:Date;
}

export interface DashboardClientSalesVendorModel {
    vendorId: number;
    vendorCode: string;
    vendorName: string;
    lineValue: number;
    percentage: number;
    lastInvoice:Date;
}