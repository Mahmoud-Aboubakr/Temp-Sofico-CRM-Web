import { SalesOrderModel } from "./salesOrderModel";

export interface SalesOrderStatusModel {
    salesOrderStatusId: number;
    salesOrderStatusCode: string;
    salesOrderStatusNameEn: string;
    salesOrderStatusNameAr: string;
    icon: string;
    color: string;
    displayOrder: number | null;
    isActive: boolean | null;
    canDelete: boolean | null;
    canEdit: boolean | null;

}