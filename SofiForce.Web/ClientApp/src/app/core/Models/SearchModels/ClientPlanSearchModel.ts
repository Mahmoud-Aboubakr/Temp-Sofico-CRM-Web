import { BaseSearchModel } from "./baseSearchModel";

export interface ClientPlanSearchModel extends BaseSearchModel {
    clientId: number | null;
    clientCode: string;

    branchId: number | null;
    branchCode: string;

    clientTypeId: number | null;
    
    fromDate: Date | null;
    toDate: Date | null;
}