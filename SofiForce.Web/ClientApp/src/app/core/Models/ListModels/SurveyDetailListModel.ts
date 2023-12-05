export interface SurveyDetailListModel {
    surveyDetailId: number | null;
    surveyQuestion: string;
    isMuliSelect: boolean | null;
    answers: SurveyDetailAnswerListModel[];
    selectedAnswerSingle: number;
    selectedAnswerMulti:any[],
}

export interface SurveyDetailAnswerListModel {
    detailAnswerId: number;
    answer: string;
    isSelected: boolean | null;
}