import { BaseSearchModel } from "./baseSearchModel";

export interface ClientQuotaSearchModel extends BaseSearchModel {
    itemId: number | null;
    itemCode: string | null;

    clientId: number | null;
    clientCode: string | null;

}