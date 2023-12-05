import { SalesOrderModel } from "./salesOrderModel";

export interface PriorityModel {
    priorityId: number;
    priorityNameAr: string;
    priorityNameEn: string;
    icon: string;
    color: string;
    displayOrder: number | null;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;

}