import { VendorGroupModel } from "./vendorGroupModel";
import { ItemModel } from "./itemModel";

export interface VendorModel {
    vendorId: number;
    vendorCode: string;
    vendorGroupId: number | null;
    vendorNameEn: string;
    vendorNameAr: string;
    isLocal: boolean | null;
    isActive: boolean | null;
    displayOrder: number | null;
    color: string;
    icon: string;
    canEdit: boolean | null;
    canDelete: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}