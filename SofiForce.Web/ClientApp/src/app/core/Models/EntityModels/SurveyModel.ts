import { SurveyDetailListModel } from "../ListModels/SurveyDetailListModel";


export class SurveyModel {
    surveyId: number;
    surveyCode: string;
    createDate: Date | null;
    serveyGroupId: number | null;
    surveyNameEn: string;
    surveyNameAr: string;
    isActive: boolean | null;
    details: SurveyDetailListModel[];
}