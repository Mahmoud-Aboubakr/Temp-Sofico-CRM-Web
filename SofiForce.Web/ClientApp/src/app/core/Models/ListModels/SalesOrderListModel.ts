export class SalesOrderListModel {
    salesId: number;
    salesCode: string;
    clientId: number | null;
    salesDate: Date | null;
    operationDate: Date | null;
    itemTotal: number | null;
    itemDiscountTotal: number | null;
    taxTotal: number | null;
    cashDiscountTotal: number | null;
    netTotal: number | null;
    isInvoiced: boolean | null;
    invoiceCode: string;
    invoiceDate: Date | null;
    clientCode: string;
    clientName: string;
    branchName: string;
    branchCode: string;
    representativeCode: string;
    representativeName: string;
    storeName: string;
    storeCode: string;
    salesOrderSourceName: string;
    salesOrderStatusId: number;
    salesOrderTypeId:number;
    salesOrderSourceId:number;
    salesOrderStatusName: string;
    salesOrderTypeName: string;
    paymentTermName: string;
    hasError:Boolean|false;
    inprogress:Boolean|false
    isBackoffice:Boolean|false

}