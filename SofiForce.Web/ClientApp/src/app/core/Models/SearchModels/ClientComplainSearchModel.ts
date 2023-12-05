import { BaseSearchModel } from "./baseSearchModel";

export interface ClientComplainSearchModel extends BaseSearchModel {
    complainCode: string;
    branchId: number | null;
    branchCode: string | '';

    representativeId: number | null;
    representativeCode: string | '';

    clientId: number | null;
    clientCode: string | '';

    complainDate: Date | null;
    complainTypeId: number | null;
    complainTypeDetailId: number | null;
    phone: string;
    priorityId: number | null;
    complainStatusId: number | null;
    isClosed: number | null;
    departmentId: number | null;
}