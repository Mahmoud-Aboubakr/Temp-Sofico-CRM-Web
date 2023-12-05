export interface RepresentativeUserAccessDTO {
    userId: number | null;
    representativeId: number | null;
    employeeCode: string;
    branchId: number[];
    storeId: number[];
    userGroupId: number | null;
    appRoleId: number | null;
    defaultRoute: string;
    password: string;
}