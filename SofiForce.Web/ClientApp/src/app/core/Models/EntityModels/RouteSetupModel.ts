export interface RouteSetupModel {
    routeId: number | null;
    routeTypeId: number | null;
    branchId: number | null;
    branchCode:string;
    routeCode: string;
    routeNameEn: string;
    routeNameAr: string;
    isActive: boolean | null;
    color: string;
    icon: string;
    canEdit: boolean | null;
    canDelete: boolean | null;
    notes:string;
}