import { RegionModel } from "./regionModel";
import { CityModel } from "./cityModel";
import { ClientModel } from "./clientModel";

export interface GovernerateModel {
    governerateId: number;
    regionId: number | null;
    governerateCode: string;
    governerateNameAr: string;
    governerateNameEn: string;
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