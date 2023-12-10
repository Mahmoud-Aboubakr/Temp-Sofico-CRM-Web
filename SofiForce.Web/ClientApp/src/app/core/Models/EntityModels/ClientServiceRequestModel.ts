import { ClientServiceRequestDocumentListModel } from "../ListModels/ClientServiceRequestDocumentListModel";
import { ClientServiceRequestTimlineListModel } from "../ListModels/ClientServiceRequestTimlineListModel";


export class ClientServiceRequestModel {
    requestId: number;
    requestCode: string;
    branchId: number | null;
    branchCode: string;
    representativeId: number | null;
    representativeCode: string;

    clientId: number | null;
    clientCode: string ;

    requestDate: Date | null;
    requestTime: Date | null;
    requestTypeId: number | null;
    requestTypeDetailId: number | null;
    phone: string;
    phoneAlternative: string;
    priorityId: number | null;
    requestStatusId: number | null;
    isClosed: boolean | null;
    closeDate: Date | null;
    duration: number | null;
    latitude: number | null;
    longitude: number | null;
    notes: string;
    replay:string;
    departmentId: number | null;

    inZone: boolean ;
    distance: number ;
    
    timeLine: ClientServiceRequestTimlineListModel[];
    documents: ClientServiceRequestDocumentListModel[];
}