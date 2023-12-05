import { BaseSearchModel } from "./baseSearchModel";

export interface SalesOrderPromotionSearchModel extends BaseSearchModel {
    outcomeType: number | null;
    itemId: number | null;
    itemCode: string | null;

    batchNo: string;
    vendorId: number | null;
    vendorCode: string | null;

    branchId: number | null;
    branchCode: string | null;

    clientId: number | null;
    clientCode: string | null;

    from: Date | null;
    to: Date | null;
    promotionCode: string;
    invoiceCode: string;
    promotionId: number;
    salesId: number;
}