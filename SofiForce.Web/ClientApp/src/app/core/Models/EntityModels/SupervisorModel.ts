// import { SupervisorTypeModel } from "./supervisorTypeModel";
import { BranchModel } from "./branchModel";
import { RepresentativeModel } from "./representativeModel";

export class SupervisorModel {
    supervisorId: number;
    supervisorTypeId: number | null;
    supervisorCode: string;
    companyCode: string;
    supervisorNameEn: string;
    supervisorNameAr: string;
    joinDate: Date | null;
    userId: number | null;
    branchId: number | null;
    branchCode: string;
    isActive: boolean | null;
    color: string;
    displayOrder: number | null;
    icon: string;
    canEdit: boolean | null;
    canDelete: boolean | null;
    notes: string;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;

    isTerminated: boolean | null;
    phone : string | null;
    phoneAlternative : string | null;
    terminationDate : Date | null;
    terminationReasonId : number | null;
    businessUnitId: number | null;
}