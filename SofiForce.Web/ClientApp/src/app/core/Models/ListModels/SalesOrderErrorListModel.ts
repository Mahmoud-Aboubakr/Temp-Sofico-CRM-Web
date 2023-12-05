export interface SalesOrderErrorListModel {
    errorId: number | null;
    salesId: number | null;
    salesErrorId: number | null;
    salesErrorName: string;
    salesErrorCode: string;
    errorDetail:string;
    errorDate:Date;
}