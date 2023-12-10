export class AppUserListModel {
    userId: number | null;
    appRoleId: number | null;
    userGroupId: number | null;
    realName: string;
    userName: string;
    isOnline: boolean | null;
    isLocked: boolean | null;
    mustChangeData: boolean | null;
    lastLogin: Date | null;
    mustChangePassword: boolean | null;
    emailVerified: boolean | null;
    defaultRoute: string;
    phone: string;
    whatsApp: string;
    userGroupCode: string;
    userGroupName: string;
    appRoleCode: string;
    appRoleName: string;
}