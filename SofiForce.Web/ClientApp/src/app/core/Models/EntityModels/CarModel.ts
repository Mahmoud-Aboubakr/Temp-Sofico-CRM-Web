import { ManufacturerModel } from "./manufacturerModel";

export interface CarModel {
    carId: number;
    carTypeId: number | null;
    carCode: string;
    carNo: string;
    model: string;
    manufacturerId: number | null;
    yearManufactur: number | null;
    isActive: boolean | null;
    color: string;
    icon: string;
    displayOrder: number | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    latitude: number | null;
    longitude: number | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
   
}