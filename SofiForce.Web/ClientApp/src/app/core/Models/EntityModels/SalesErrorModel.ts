import { SalesOrderErrorModel } from "./salesOrderErrorModel";

export interface SalesErrorModel {
    salesErrorId: number;
    salesErrorCode: string;
    salesErrorNameEn: string;
    salesErrorNameAr: string;
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