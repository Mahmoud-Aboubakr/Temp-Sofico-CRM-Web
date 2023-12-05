import { BaseSearchModel } from "./baseSearchModel";

export interface RouteSetupSearchModel extends BaseSearchModel {
    branchId: number | null;
    routeTypeId: number | null;
    branchCode: string | null;
    routeTypeCode: string | null;
    isActive: number | null;
}