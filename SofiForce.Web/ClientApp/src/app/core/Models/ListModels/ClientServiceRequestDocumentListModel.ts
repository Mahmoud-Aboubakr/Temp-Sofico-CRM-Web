export interface ClientServiceRequestDocumentListModel {
    documentSize: number | null;
    documentExt: string;
    uploadDate: Date | null;
    documentPath: string;
    requestId: number | null;
    requestDocumentId: number;
}