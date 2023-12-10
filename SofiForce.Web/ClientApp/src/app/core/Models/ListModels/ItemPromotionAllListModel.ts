export class ItemPromotionAllListModel {
    promotionId: number | null;
    promotionCode: string;
    validFrom: Date | null;
    validTo: Date | null;
    isActive: boolean | null;
    promotionTypeId: number | null;
    promotionTypeName: string;
    priority: number | null;
    repeats: number | null;
    itemCode: string;
    itemName: string;
}