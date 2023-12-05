import { SalesOrderModel } from "./salesOrderModel";

export interface SalesOrderLogModel {
    logId: number;
    salesId: number | null;
    logDate: Date | null;
    logStatment: string;
    purgeAfter: number | null;
    iP: string;
    device: string;
    oS: string;
    agent: string;
    cBy: number;
    cDate: Date | null;
 
}