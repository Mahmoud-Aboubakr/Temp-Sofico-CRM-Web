import { ClientModel } from "./clientModel";
import { GovernerateModel } from "./governerateModel";

export interface RegionModel {
    regionId: number;
    regionNameAr: string;
    regionNameEn: string;
    regionCode: string;
    isActive: boolean | null;
    displayOrder: number | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    color: string;
    icon: string;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;

}