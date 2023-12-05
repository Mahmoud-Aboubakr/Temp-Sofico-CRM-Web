import { SupervisorModel } from "./supervisorModel";

export interface SupervisorTypeModel {
    supervisorTypeId: number;
    supervisorTypeCode: string;
    supervisorTypeNameEn: string;
    supervisorTypeNameAr: string;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    displayOrder: number | null;
    color: string;
    icon: string;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;

}