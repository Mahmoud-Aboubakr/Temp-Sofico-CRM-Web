import { ClientComplainDocumentModel } from "./ClientComplainDocumentModel";
import { ClientComplainTimelineListModel } from "./ClientComplainTimelineModel";

export class ClientComplainModel {
    complainId: number;
    complainCode: string;
    branchId: number | null;
    branchCode: string | null;
    representativeId: number | null;
    representativeCode: string;
    clientId: number | null;
    clientCode: string;

    complainDate: Date | null;
    complainTime: Date | null;
    complainTypeId: number | null;
    complainTypeDetailId: number | null;
    phone: string;
    phoneAlternative: string;
    priorityId: number | null;
    complainStatusId: number | null;
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


    documents: ClientComplainDocumentModel[];
    timeLine: ClientComplainTimelineListModel[];

}