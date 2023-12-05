import { SalesOrderModel } from "./salesOrderModel";
import { ItemModel } from "./itemModel";

export interface SalesOrderDetailModel {
    detailId: number;
    salesId: number | null;
    itemId: number | null;
    publicPrice: number | null;
    clientPrice: number | null;
    quantity: number | null;
    lineValue: number | null;
    lineValueBefore: number | null;

    discount: number | null;
    taxValue: number | null;
    isBouns: boolean | null;
    hasPromotion:boolean;
    promotionCode: string;
    itemStoreId: number | null;
    salesOrder: SalesOrderModel;
    itemName: string;
    vendorName:string;
    batch:string;
    expiration:Date;
    itemCode:string;
    unitId: number | null;

}