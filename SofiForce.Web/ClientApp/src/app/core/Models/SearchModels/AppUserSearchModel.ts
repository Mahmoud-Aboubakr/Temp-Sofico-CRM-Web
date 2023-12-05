import { BaseSearchModel } from "./baseSearchModel";

export interface AppUserSearchModel extends BaseSearchModel {
    appRoleId: number | null;
    userGroupId: number | null;
    isOnline: number | null;
    isLocked: number | null;
    lastLogin: Date | null;
    mustChangePassword: number | null;
}