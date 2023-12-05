import { SurveyModel } from "./SurveyModel";

export interface ClientSurveyModel {
    clientServeyId: number;
    surveyId: number;
    surveyCode: string;

    clientId: number | null;
    clientCode: string;

    branchId: number | null;
    branchCode: string;

    representativeId: number | null;
    representativeCode: string;

    isClosed: boolean;


    serveyStatusId: number | null;
    createDate: Date | null;
    createTime: Date | null;
    startDate: Date | null;
    startTime: Date | null;

    notes:string;

    inZone: boolean ;
    distance: number ;
    latitude: number | null;
    longitude: number | null;


    serveyModel:SurveyModel;
}