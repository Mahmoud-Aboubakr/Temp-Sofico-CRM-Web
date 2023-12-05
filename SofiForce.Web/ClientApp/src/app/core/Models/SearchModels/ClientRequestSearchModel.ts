import { BaseSearchModel } from "./baseSearchModel";

export interface ClientRequestSearchModel extends BaseSearchModel {
    requestCode: string;
    branchId: number | null;
    branchCode: string | '';

    representativeId: number | null;
    representativeCode: string | '';

    clientId: number | null;
    clientCode: string | '';

    requestDate: Date | null;
    requestTypeId: number | null;
    requestTypeDetailId: number | null;
    phone: string;
    priorityId: number | null;
    requestStatusId: number | null;
    isClosed: number | null;
    departmentId: number | null;
}