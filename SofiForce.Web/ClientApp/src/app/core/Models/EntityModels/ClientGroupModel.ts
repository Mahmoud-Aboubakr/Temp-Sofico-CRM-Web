import { ClientModel } from "./clientModel";
import { ClientGroupSubModel } from "./clientGroupSubModel";

export interface ClientGroupModel {
    clientGroupId: number;
    clientGroupCode: string;
    clientGroupNameEn: string;
    clientGroupNameAr: string;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    icon: string;
    color: string;
    displayOrder: number | null;
    notes:string;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}