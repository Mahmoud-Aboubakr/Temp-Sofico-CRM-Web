export class SalesOrderPromotionAllListModel {
    promotionCode: string;
    validFrom: Date | null;
    validTo: Date | null;
    isActive: boolean | null;
    promotionTypeName: string;
    priority: number | null;
    repeats: number | null;
    clientCode: string;
    clientName: string;
    salesCode: string;
    netTotal: number | null;
    invoiceDate: Date | null;
    invoiceCode: string;
    deliveryTotal: number | null;
    customDiscountTotal: number | null;
    customDiscountValue: number | null;
    customDiscountTypeId: number | null;
    cashDiscountTotal: number | null;
    taxTotal: number | null;
    itemDiscountTotal: number | null;
    itemTotal: number | null;
    promotionId: number | null;
    salesId: number | null;
    clientId: number | null;
    clientGroupName: string;
}