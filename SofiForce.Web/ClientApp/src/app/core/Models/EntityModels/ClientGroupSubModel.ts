import { ClientGroupModel } from "./clientGroupModel";
import { ClientModel } from "./clientModel";

export class ClientGroupSubModel {
    clientGroupSubId: number;
    clientGroupId: number | null;
    clientGroupSubCode: string;
    clientGroupSubNameEn: string;
    clientGroupSubNameAr: string;
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