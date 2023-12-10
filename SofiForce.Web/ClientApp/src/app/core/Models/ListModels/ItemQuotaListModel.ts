export class ItemQuotaListModel {
    quantity: number | null;
    itemId: number | null;
    itemCode: string;
    itemName: string;
    publicPrice: number | null;
    clientPrice: number | null;
    discount: number | null;
    isActive: boolean | null;
    fromDate:Date;
    toDate:Date;
}