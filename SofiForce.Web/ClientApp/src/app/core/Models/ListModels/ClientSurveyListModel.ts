export interface ClientSurveyListModel {
    branchId: number | null;
    branchCode: string;
    branchName: string;
    clientTypeId: number | null;
    clientServeyId: number;
    surveyId: number;
    serveyStatusId: number | null;
    clientId: number | null;
    clientCode: string;
    clientName: string;
    createDate: Date | null;
    createTime: Date | null;
    startDate: Date | null;
    startTime: Date | null;
    surveyName: string;
    serveyStatusName: string;
    serveyGroupId: number | null;
    serveyGroupName: string;
    representativeId: number | null;
    representativeCode: string;
    representativeName: string;
    isClosed: boolean | null;
    serveyStatusColor:string;
}