import { BaseSearchModel } from "./baseSearchModel";

export interface ClientActivitySearchModel extends BaseSearchModel {
    clientId: number | null;
    clientCode: string | null;
    branchId: number | null;
    branchCode: string | '';
    representativeId: number | null;
    representativeCode: string | '';
    activityTimeFrom: Date | null;
    activityTimeTo: Date | null;
    callAgainFrom: Date | null;
    callAgainTo: Date | null;
    inJourney: number | null;
    inZone: number | null;
    isPositive: number | null;
    activityTypeId: number | null;
}