export interface RepresentativeComissionModel {
    comissionId: number | null;
    representativeId: number | null;
    representativeCode: string | null;

    comissionDate: Date | null;
    comissionValue: number | null;
    isApproved: boolean | null;
    comissionTypeId: number | null;
    notes: string|null;
}