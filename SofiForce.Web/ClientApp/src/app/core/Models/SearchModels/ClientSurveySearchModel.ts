import { BaseSearchModel } from "./baseSearchModel";

export interface ClientSurveySearchModel extends BaseSearchModel {
    branchId: number | null;
    branchCode: string;

    clientTypeId: number | null;
    surveyId: number;
    surveyCode:string;
    serveyStatusId: number | null;
    clientId: number | null;
    clientCode:string;
    createDate: Date | null;
    startDate: Date | null;
    serveyGroupId: number | null;
    representativeId: number | null;
    representativeCode:string;
    isClosed: number | null;
}