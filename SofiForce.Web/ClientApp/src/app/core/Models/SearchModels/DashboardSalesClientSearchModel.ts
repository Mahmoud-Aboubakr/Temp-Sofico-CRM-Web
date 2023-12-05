import { BaseSearchModel } from "./baseSearchModel";

export interface DashboardSalesClientSearchModel extends BaseSearchModel {
    clientId: number | null;
    clientCode: string | '';
}