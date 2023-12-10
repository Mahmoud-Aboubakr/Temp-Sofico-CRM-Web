export class ItemStoreListModel {
    itemStoreId: number | null;
    itemId: number | null;
    branchId: number | null;
    storeId: number | null;
    quantity: number | null;
    onHand: number | null;
    expireDate: Date | null;
    batchNo: string;
    acceptDays: number | null;
    itemCode: string;
    itemName: string;
    vendorName: string;
    vendorId: number | null;
    available: number | null;
    unitId:number;
    isActive:boolean;
    
    storeCode: string;
    storeName: string;
    branchCode: string;
    branchName: string;

}