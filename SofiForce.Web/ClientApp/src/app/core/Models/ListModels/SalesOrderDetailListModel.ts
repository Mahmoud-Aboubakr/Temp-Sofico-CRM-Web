export interface SalesOrderDetailListModel {
    id: string;
    parentId: number | null;
    detailId: number | null;
    salesId: number | null;
    itemId: number | null;
    itemGroupId: number | null;
    publicPrice: number | null;
    clientPrice: number | null;
    quantity: number | null;
    lineValue: number | null;
    discount: number | null;
    taxValue: number | null;
    isBouns: boolean | null;
    hasPromotion: boolean | null;
    promotionCode: string;
    itemStoreId: number | null;
    batch: string;
    expiration: Date | null;
    itemCode: string;
    itemName: string;
    vendorName: string;
    vendorCode: string;
    unitId: number | null;
    customDiscount: number | null;
    cashDiscount: number | null;
    totalReturn: number | null;
    returnQuantity: number | null;
    availability: number | null;
    clientId: number | null;
    invoiceCode: string;
    invoiceDate: Date | null;
    isNewStocked: boolean;
    isNewAdded: boolean;
    quota: number;
}


export interface SalesOrderPromotionOptionModel {
    rowId:number;
    itemCode: string;
    promotionId:string;
    itemName:string;
    selected: boolean;
    quantity:number;
    batchs: SalesOrderDetailListModel[];
}