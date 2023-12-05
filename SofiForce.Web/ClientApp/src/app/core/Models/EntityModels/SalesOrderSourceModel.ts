import { SalesOrderModel } from "./salesOrderModel";

export interface SalesOrderSourceModel {
    salesOrderSourceId: number;
    salesOrderSourceCode: string;
    salesOrderSourceNameEn: string;
    salesOrderSourceNameAr: string;
    color: string;
    icon: string;
    displayOrder: number | null;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
 
}