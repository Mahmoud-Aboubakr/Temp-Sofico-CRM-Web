import { BranchModel } from "./branchModel";
import { AppUserModel } from "./appUserModel";
// import { SupervisorModel } from "./supervisorModel";
// import { RepresentativeKindModel } from "./representativeKindModel";
import { SalesOrderModel } from "./salesOrderModel";

export class RepresentativeModel {
    representativeId: number;
    branchId: number | null;
    branchCode: string | null;
    userId: number | null;
    supervisorId: number | null;
    kindId: number | null;
    companyCode: string;
    representativeCode: string;
    representativeNameAr: string;
    representativeNameEn: string;
    isActive: boolean | null;
    displayOrder: number | null;
    canEdit: boolean | null;
    canDelete: boolean | null;
    icon: string;
    color: string;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;

    isTerminated: boolean | null;
    phone : string | null;
    phoneAlternative : string | null;
    terminationDate : Date | null;
    terminationReasonId : number | null;
    businessUnitId : number | null;

    joinDate:Date |null;
    supervisorCode: string;
    
    notes:string | null
}