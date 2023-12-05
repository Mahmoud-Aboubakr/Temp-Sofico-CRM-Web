import { ClientModel } from "./clientModel";
import { SalesOrderModel } from "./salesOrderModel";

export interface PaymentTermModel {
    paymentTermId: number;
    paymentTermCode: string;
    paymentTermNameAr: string;
    paymentTermNameEn: string;
    icon: string;
    color: string;
    isActive: boolean | null;
    displayOrder: number | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}