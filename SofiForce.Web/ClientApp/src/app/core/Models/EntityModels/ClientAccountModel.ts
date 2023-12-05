import { ClientModel } from "./clientModel";

export interface ClientAccountModel {
    clientAccountId: number;
    clientAccountCode: string;
    clientAccountNameAr: string;
    clientAccountNameEn: string;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    icon: string;
    color: string;
    displayOrder: number | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;

}