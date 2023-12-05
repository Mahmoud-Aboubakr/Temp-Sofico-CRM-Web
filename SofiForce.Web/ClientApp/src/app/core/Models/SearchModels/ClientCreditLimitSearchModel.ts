import { BaseSearchModel } from "./baseSearchModel";

export interface ClientCreditLimitSearchModel extends BaseSearchModel {
    limitYear: number;
    limitMonth: number;
    clientId: number;
    clientCode: string;

    branchId: number;
    branchCode: string;

}