import { VendorModel } from "./vendorModel";

export interface VendorGroupModel {
    vendorGroupId: number;
    vendorGroupCode: string;
    vendorGroupNameEn: string;
    vendorGroupNameAr: string;
    isActive: boolean | null;
    displayOrder: number | null;
    icon: string;
    color: string;
    canEdit: boolean | null;
    canDelete: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;

}