
import { SalesOrderDetailModel } from "./salesOrderDetailModel";
import { VendorModel } from "./vendorModel";

export interface ItemModel {
    itemId: number;
    vendorId: number | null;
    itemGroupId: string | null;
    acceptDays: number | null;
    isTaxable: boolean | null;
    itemCode: string;
    itemNameEn: string;
    itemNameAr: string;
    publicPrice: number | null;
    clientPrice: number | null;
    discount: number | null;
    isLocal: boolean | null;
    isActive: boolean | null;
    displayOrder: number | null;
    color: string;
    icon: string;
    hasPromotion: boolean | null;
    isNewAdded: boolean | null;
    isNewStocked: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
    vendor: VendorModel;

}