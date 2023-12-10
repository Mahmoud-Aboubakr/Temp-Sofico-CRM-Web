import { AppUserBranchListModel } from "../ListModels/AppUserBranchListModel";
import { AppUserClientGroupListModel } from "../ListModels/AppUserClientGroupListModel";
import { AppUserStoreListModel } from "../ListModels/AppUserStoreListModel";
import { RepresentativeListModel } from "../ListModels/RepresentativeListModel";
import { SupervisorListModel } from "../ListModels/SupervisorListModel";


export class AppUserModel {
    userId: number;
    appRoleId: number | null;
    userGroupId: number | null;
    realName: string;
    userName: string;
    password: string;
    isOnline: boolean | null;
    isLocked: boolean | null;
    mustChangeData: boolean | null;
    lastLogin: Date | null;
    mustChangePassword: boolean | null;
    emailVerified: boolean | null;
    firebaseId: string;
    signalrId: string;
    failedCount: number | null;
    defaultRoute: string;
    phone: string;
    whatsApp: string;
    mobile: string;
    zoomId: string;
    linkedIn: string;
    userBio: string;
    latitude: number | null;
    longitude: number | null;
    email: string;
    internal: string;
    jobTitle: string;
    address: string;
    zoom: string;
    fax: string;
    avatar: string;
    branchs: AppUserBranchListModel[];
    stores: AppUserStoreListModel[];
    representatives: RepresentativeListModel[];
    supervisors: SupervisorListModel[];
    clientGroups: AppUserClientGroupListModel[];
}