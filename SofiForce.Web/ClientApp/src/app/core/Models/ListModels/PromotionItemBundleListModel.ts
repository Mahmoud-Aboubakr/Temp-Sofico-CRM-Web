export class PromotionItemBundleListModel {
    bundleId: number | null;
    promotionId: number | null;
    itemId: number;
    itemCode: string;
    itemName: string;

    quantity: number | null;
    isMandatory: boolean | null;
}