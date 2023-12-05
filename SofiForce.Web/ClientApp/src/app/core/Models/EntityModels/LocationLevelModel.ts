export interface LocationLevelModel {
    locationLevelId: number;
    locationLevelNameAr: string;
    locationLevelNameEn: string;
    icon: string;
    color: string;
    displayOrder: number | null;
    isActive: boolean | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;

}