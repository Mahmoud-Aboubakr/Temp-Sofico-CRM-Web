export interface CityListModel {
    cityId: number;
    governerateId: number | null;
    governerateName: string | null;
    cityName: string;
    cityCode: string;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    displayOrder: number | null;
    color: string;
    icon: string;
}