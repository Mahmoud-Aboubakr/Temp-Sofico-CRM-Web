import { BaseSearchModel } from "./baseSearchModel";

export class ClientCreditLimitSearchModel extends BaseSearchModel {
    limitYear: number;
    limitMonth: number;
    clientId: number;
    clientCode: string;

    branchId: number;
    branchCode: string;

}