export interface ClientQuotaListModel {
    itemId: number | null;
    clientId: number | null;
    quantity: number | null;
    remain: number | null;
    clientName: string;
    clientCode: string;
    itemCode: string;
    itemName: string;
    publicPrice: number | null;
    clientPrice: number | null;
    discount: number | null;
    fromDate:Date;
    toDate:Date;
}