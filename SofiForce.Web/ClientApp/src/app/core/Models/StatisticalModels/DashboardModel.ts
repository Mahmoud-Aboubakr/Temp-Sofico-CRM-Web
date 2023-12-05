import { DashboardTimelineModel } from "./DashboardTimelineModel";

export interface DashboardSalesModel {
    kbiModel:DashboardKBI;
    perfromanceModel: DashboardPerfromanceModel;
    orderKBIModel: DashboardOrderKBIModel;
    timelines: DashboardTimelineModel[];
    channels:DashboardChannelModel[];
    hours:TimelineModel[];

    vendorSales:DashboardSalesVendorModel[];
    vendorHotSales:DashboardSalesVendorModel[];
    itemSales:DashboardSalesItemModel[];

}


export interface DashboardPerfromanceModel {
    label: string;
    percentage: number;
    sales: number;
    target: number;
}

export interface DashboardKBI {
    branchs: number;
    clients: number;
    distributors: number;
    representatives: number;
    items: number;
    vendors: number;
    allBranchs: number;
    allClients: number;
    allRepresentative: number;
    allDistributors: number;
    allItems: number;
    allVendors: number;
    branchPercentage: number;
    clientPercentage: number;
    distributorPercentage: number;
    representativePercentage: number;
    itemPercentage: number;
    vendorPercentage: number;
}

export interface DashboardOrderKBIModel {
    allOrder: number;
    opened: number;
    confirmed: number;
    invoiced: number;
    rejected: number;
    printed: number;
    dispatched: number;
    delivered: number;
    openedValue: number;
    confirmedValue: number;
    invoicedValue: number;
    rejectedValue: number;
    printedValue: number;
    dispatchedValue: number;
    deliveredValue: number;
    openedPercentage: number;
    confirmedPercentage: number;
    invoicedPercentage: number;
    rejectedPercentage: number;
    printedPercentage: number;
    dispatchedPercentage: number;
    deliveredPercentage: number;
}

export interface DashboardChannelModel {
    label: string;
    percentage: number;
    sales: number;
    target: number;
    color:string;
}

export interface TimelineModel {
    label: string;
    value: number;
}

export interface DashboardSalesItemModel {
    itemId: string;
    itemCode: number;
    itemName: number;
    lineValue: number;
    percentage: number;
}

export interface DashboardSalesVendorModel {
    vendorId: string;
    vendorCode: number;
    vendorName: number;
    lineValue: number;
    percentage: number;
}