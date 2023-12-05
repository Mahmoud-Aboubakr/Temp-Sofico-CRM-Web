import { BranchModel } from "./branchModel";
import { AppUserModel } from "./appUserModel";

export interface AppUserBranchModel {
    userBranchId: number;
    branchId: number | null;
    userId: number | null;

}