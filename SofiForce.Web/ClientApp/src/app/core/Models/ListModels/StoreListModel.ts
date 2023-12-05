export interface StoreListModel {
    storeId: number | null;
    branchId: number | null;
    storeTypeId: number | null;
    storeName: string;
    storeCode: string;
    isActive: boolean | null;
    icon: string;
    color: string;
    displayOrder: number | null;
    canDelete: boolean | null;
    canEdit: boolean | null;
    branchName: string;
    branchCode: string;
    storeTypeName: string;
    isOrder:boolean;
}