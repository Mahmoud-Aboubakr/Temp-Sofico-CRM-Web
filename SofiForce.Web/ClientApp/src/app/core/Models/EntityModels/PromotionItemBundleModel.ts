export class PromotionItemBundleModel {
    bundleId: number | null;
    promotionId: number | null;
    itemId: number;
    itemCode: string;

    quantity: number | null;
    isMandatory: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}