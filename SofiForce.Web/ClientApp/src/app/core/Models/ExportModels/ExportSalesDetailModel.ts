export interface ExportSalesDetailModel {
    salesCode: string;
    invoiceCode: string;
    invoiceDate: Date | null;
    vendorCode: string;
    vendorName: string;
    itemCode: string;
    itemName: string;
    batch: string;
    expiration: Date | null;
    publicPrice: number | null;
    clientPrice: number | null;
    quantity: number | null;
    discount: number | null;
    taxValue: number | null;
    itemValue: number | null;
    netValue: number | null;
}