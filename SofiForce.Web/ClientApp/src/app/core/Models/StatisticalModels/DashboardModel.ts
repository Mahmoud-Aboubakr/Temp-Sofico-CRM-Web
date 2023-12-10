import { DashboardTimelineModel } from "./DashboardTimelineModel";

export class DashboardSalesModel {
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


export class DashboardPerfromanceModel {
    label: string;
    percentage: number;
    sales: number;
    target: number;
}

export class DashboardKBI {
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

export class DashboardOrderKBIModel {
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

export class DashboardChannelModel {
    label: string;
    percentage: number;
    sales: number;
    target: number;
    color:string;
}

export class TimelineModel {
    label: string;
    value: number;
}

export class DashboardSalesItemModel {
    itemId: string;
    itemCode: number;
    itemName: number;
    lineValue: number;
    percentage: number;
}

export class DashboardSalesVendorModel {
    vendorId: string;
    vendorCode: number;
    vendorName: number;
    lineValue: number;
    percentage: number;
}