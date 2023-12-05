import { BaseSearchModel } from "./baseSearchModel";

export interface SalesOrderPromotionAllSearchModel extends BaseSearchModel {
    promotionId: number;
    clientId: number;
    salesId: number;
    promotionCode: string;
    clientCode: string;
    invoiceCode: string;
    invoiceDateFrom: Date | null;
    invoiceDateTo: Date | null;
}