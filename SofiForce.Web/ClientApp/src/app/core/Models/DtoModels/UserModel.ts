export class UserModel {
    userId: number;
    appRoleId: number;
    branchId: number;
    storeId: number;
    representativeId : number;
    isLocked:boolean;
    mustChangeData:boolean;
    mustChangePassword:boolean;

    realName: string;
    username: string;
    whatsApp: string;
    jobTitle: string;
    internal: string;
    zoom: string;
    linkedin: string;
    phone: string;
    email: string;
    bio: string;
    address: string;
    fax: string;
    mobile: string;
    defualtUrl: string;
    avatar: string;
    token: string;
    userFeatures: UserFeature[];
}

export interface UserFeature {
    isNew: boolean | null;
    isUpdated: boolean | null;
    featureCode: string;
    featureName: string;
    userFeaturePermissions: UserFeaturePermission[];
}

export interface UserFeaturePermission {
    permissionCode: string;
    permissionName: string;
    isAllowed: boolean;
}