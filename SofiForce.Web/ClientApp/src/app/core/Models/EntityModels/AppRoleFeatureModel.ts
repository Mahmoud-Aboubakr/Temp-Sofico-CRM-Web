import { AppRoleModel } from "./appRoleModel";
import { ApplicationFeatureModel } from "./applicationFeatureModel";
import { AppRoleFeaturePermissionModel } from "./appRoleFeaturePermissionModel";

export interface AppRoleFeatureModel {
    appRoleFeatueId: number;
    appRoleId: number | null;
    featueId: number | null;
    canRead: boolean | null;
    canWrite: boolean | null;
    canSearch: boolean | null;
    canPrint: boolean | null;
    fullAccess: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;

}