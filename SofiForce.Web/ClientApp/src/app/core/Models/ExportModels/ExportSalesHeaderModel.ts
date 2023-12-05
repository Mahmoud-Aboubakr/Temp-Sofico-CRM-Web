export interface ExportSalesHeaderModel {
    salesCode: string;
    invoiceCode: string;
    invoiceDate: Date | null;
    invoiceType: string;
    clientCode: string;
    clientName: string;
    branchCode: string;
    branchName: string;
    storeCode: string;
    storeName: string;
    salesManCode: string;
    salesManName: string;
    paymentTerm: string;
    salesTime: Date | null;
    salesChannel: string;
    salesPool: string;
    itemTotal: number | null;
    offerDiscount: number | null;
    taxTotal: number | null;
    cashDiscount: number | null;
    cashPercentage: number | null;
    netTotal: number | null;
    openValue: number | null;
}