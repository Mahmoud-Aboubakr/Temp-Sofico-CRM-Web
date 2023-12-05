export interface PromotionItemListModel {
    itemCode: string;
    itemName: string;
    itemId: number | null;
    vendorCode: string;
    vendorGroupId: number | null;
    vendorName: string;
    vendorId: number | null;
    publicPrice: number | null;
    clientPrice: number | null;
    discount: number | null;
    validTo: Date | null;
    validFrom: Date | null;
    repeatsNo: number | null;
    promotionCode: string;
    priorityValue: number | null;
    priorityCode: string;
    PromotionCategoryId: number | null;
    exclude: boolean | null;
}