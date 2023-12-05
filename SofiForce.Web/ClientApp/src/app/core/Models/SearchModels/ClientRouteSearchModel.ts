import { BranchModel } from "../EntityModels/branchModel";
import { RepresentativeModel } from "../EntityModels/representativeModel";
import { StoreModel } from "../EntityModels/storeModel";
import { BaseSearchModel } from "./baseSearchModel";

export interface ClientRouteSearchModel extends BaseSearchModel {
   
    clientId:number;
    clientCode: string;

    branchId: number | null;
    branchCode: string | null;
   
    routeId: number | null;
    routeCode: string | null;

    routeTypeId: number | null;
    isActive: number | null;

   
}