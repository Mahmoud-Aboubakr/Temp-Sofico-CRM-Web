import { SalesOrderModel } from "./salesOrderModel";

export interface SalesOrderTypeModel {
    salesOrderTypeId: number;
    salesOrderTypeCode: string;
    salesOrderTypeNameEn: string;
    salesOrderTypeNameAr: string;
    icon: string;
    color: string;
    isActive: boolean | null;
    displayOrder: number | null;
    canDelete: boolean | null;
    canEdit: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}