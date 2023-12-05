export interface SurveyDetailModel {
    surveyDetailId: number;
    surveyId: number | null;
    surveyQuestionEn: string;
    surveyQuestionAr: string;
    isMuliSelect: boolean | null;
}