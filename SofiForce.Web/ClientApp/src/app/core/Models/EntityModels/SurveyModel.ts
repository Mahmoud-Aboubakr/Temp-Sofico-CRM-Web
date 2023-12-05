import { SurveyDetailListModel } from "../ListModels/SurveyDetailListModel";


export interface SurveyModel {
    surveyId: number;
    surveyCode: string;
    createDate: Date | null;
    serveyGroupId: number | null;
    surveyNameEn: string;
    surveyNameAr: string;
    isActive: boolean | null;
    details: SurveyDetailListModel[];
}