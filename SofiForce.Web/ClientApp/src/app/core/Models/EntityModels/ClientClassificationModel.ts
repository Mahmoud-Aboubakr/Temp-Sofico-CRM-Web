import { ClientModel } from "./clientModel";

export interface ClientClassificationModel {
    clientClassificationId: number;
    clientClassificationCode: string;

    clientClassificationNameEn: string;
    clientClassificationNameAr: string;
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

    notes:string;

}