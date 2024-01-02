export class VendorListModel {
    vendorId: number;
    vendorCode: string;
    vendorGroupId: number | null;
    vendorName: string;
    isLocal: boolean | null;
    isActive: boolean | null;
    displayOrder: number | null;
    color: string;
    icon: string;
    canEdit: boolean | null;
    canDelete: boolean | null;
    vendorGroupName: string;
}