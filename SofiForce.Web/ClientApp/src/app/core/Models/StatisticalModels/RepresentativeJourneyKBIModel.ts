export interface RepresentativeJourneyKBIModel {
    allClients: number;
    clients: number;
    allRepresentatives: number;
    representatives: number;
    clientPerformance: number;
    representativePerformance: number;
    perormancePercentage: number;
    perormanceLabel: string;
    detailModels: RepresentativeJourneyKBIDetailModel[];
}

export interface RepresentativeJourneyKBIDetailModel {
    branchId: number;
    branchCode: string;
    branchName: string;
    allClients: number;
    clients: number;
    allRepresentatives: number;
    representatives: number;
    clientPerformance: number;
    representativePerformance: number;
    perormancePercentage: number;
    perormanceLabel: string;
}