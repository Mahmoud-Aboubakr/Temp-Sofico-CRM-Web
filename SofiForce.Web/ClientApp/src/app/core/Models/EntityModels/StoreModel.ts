import { BranchModel } from "./branchModel";
import { StoreTypeModel } from "./storeTypeModel";
import { AppUserStoreModel } from "./appUserStoreModel";
import { ItemStoreModel } from "./itemStoreModel";
import { SalesOrderModel } from "./salesOrderModel";

export interface StoreModel {
    storeId: number;
    branchId: number | null;
    storeTypeId: number | null;
    storeNameEn: string;
    storeNameAr: string;
    storeCode: string;
    isActive: boolean | null;
    icon: string;
    color: string;
    displayOrder: number | null;
    recId: number | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;

}