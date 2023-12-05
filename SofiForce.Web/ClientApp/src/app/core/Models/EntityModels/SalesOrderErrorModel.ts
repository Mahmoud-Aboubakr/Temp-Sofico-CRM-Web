import { SalesOrderModel } from "./salesOrderModel";
import { SalesErrorModel } from "./salesErrorModel";

export interface SalesOrderErrorModel {
    errorId: number;
    salesId: number | null;
    salesErrorId: number | null;

}