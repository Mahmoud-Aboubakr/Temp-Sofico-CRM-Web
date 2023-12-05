import { AppUserBranchModel } from "./appUserBranchModel";
import { ClientModel } from "./clientModel";
import { ItemStoreModel } from "./itemStoreModel";
import { RepresentativeModel } from "./representativeModel";
import { SalesOrderModel } from "./salesOrderModel";
import { StoreModel } from "./storeModel";

export interface BranchModel {
    branchId: number;
    branchNameEn: string;
    branchNameAr: string;
    branchCode: string;
    isActive: boolean | null;
    color: string;
    icon: string;
    displayOrder: number | null;
    expenseRate: number | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    latitude: number | null;
    longitude: number | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;

}