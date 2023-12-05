import { CarModel } from "./carModel";

export interface ManufacturerModel {
    manufacturerId: number;
    manufacturerCode: string;
    manufacturerNameEn: string;
    manufacturerNameAr: string;
    color: string;
    icon: string;
    displayOrder: number | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    isActive: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
}