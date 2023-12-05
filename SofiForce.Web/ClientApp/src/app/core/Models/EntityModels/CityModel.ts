export interface CityModel {
    cityId: number;
    governerateId: number | null;
    cityNameAr: string;
    cityNameEn: string;
    cityCode: string;
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