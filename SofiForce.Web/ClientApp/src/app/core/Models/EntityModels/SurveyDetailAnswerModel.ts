export interface SurveyDetailAnswerModel {
    detailAnswerId: number;
    surveyDetailId: number | null;
    surveyId: number | null;
    answerEn: string;
    answerAr: string;
}