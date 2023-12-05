import { AppUserModel } from "./appUserModel";
import { AppRoleModel } from "./appRoleModel";

export interface AppRoleUserModel {
    appRoleUserId: number;
    userId: number | null;
    appRoleId: number | null;

}