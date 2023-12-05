import { ClientModel } from "./clientModel";

export interface ClientPlanModel {
    planId: number;
    clientId: number | null;
    planYear: number | null;
    planMonth: number | null;
    targetValue: number | null;
    targetVisit: number | null;
    targetCall: number | null;
    cBy: number | null;
    cDate: Date | null;
    eBy: number | null;
    eDate: Date | null;
    clientCode: string | null;
}