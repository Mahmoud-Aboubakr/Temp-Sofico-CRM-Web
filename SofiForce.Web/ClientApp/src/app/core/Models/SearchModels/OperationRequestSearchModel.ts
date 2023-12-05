import { BaseSearchModel } from "./baseSearchModel";

export interface OperationRequestSearchModel extends BaseSearchModel {
    operationCode: string;
    operationTypeId: number | null;
    representativeId: number | null;
    representativeCode: string | null;
    governerateId:number |null;
    operationDate: Date | null;
    startDate: Date | null;
    isClosed: number | null;
}