import { ClientModel } from "./clientModel";

export class ClientTypeModel {
    clientTypeId: number;
    clientTypeCode: string;
    clientTypeNameEn: string;
    clientTypeNameAr: string;
    icon: string;
    color: string;
    displayOrder: number | null;
    isActive: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;

    notes:string;
}