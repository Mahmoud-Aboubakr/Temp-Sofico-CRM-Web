import { BaseSearchModel } from "./baseSearchModel";

export interface RepresentativeJourneySearchModel extends BaseSearchModel {
    representativeId: number | null;
    represtitiveUserId: number | null;
    supervisorId: number | null;
    routeId: number | null;
    branchId: number | null;
    kindId: number | null;
    routeTypeId:number | null;

    representativeCode: string | '';
    represtitiveUserCode: string | '';
    supervisorCode: string | '';
    routeCode: string | '';
    branchCode: string | '';
    kindCode: string | '';
}