import { AppRoleFeatureModel } from "./appRoleFeatureModel";
import { ApplicationFeaturePermissionModel } from "./applicationFeaturePermissionModel";

export interface AppRoleFeaturePermissionModel {
    rolePermissionId: number;
    appRoleFeatueId: number | null;
    featurePermissionId: number | null;
    isAllowed: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;

}