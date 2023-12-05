export interface PromotionOrderHistoryModel {
    historyId: number;
    promotionId: number | null;
    clientId: number | null;
    invoiceCode: string;
    invoiceDate: Date | null;
}