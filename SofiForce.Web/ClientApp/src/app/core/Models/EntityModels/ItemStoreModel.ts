import { ItemModel } from "./itemModel";
import { BranchModel } from "./branchModel";
import { StoreModel } from "./storeModel";

export interface ItemStoreModel {
    itemStoreId: number;
    itemId: number | null;
    branchId: number | null;
    storeId: number | null;
    quantity: number | null;
    onHand: number | null;
    expireDate: Date | null;
    batchNo: string;

}