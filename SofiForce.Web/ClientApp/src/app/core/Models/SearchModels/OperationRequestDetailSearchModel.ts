import { BaseSearchModel } from "./baseSearchModel";

export interface OperationRequestDetailSearchModel extends BaseSearchModel {
    clientId: number | null;
    operationId: number | null;
    clientTypeId: number | null;
    regionId: number | null;
    governerateId: number | null;
    cityId: number | null;
    locationLevelId: number | null;
    operationStatusId: number | null;
    operationRejectReasonId: number | null;

    operationDate: Date | null;
}