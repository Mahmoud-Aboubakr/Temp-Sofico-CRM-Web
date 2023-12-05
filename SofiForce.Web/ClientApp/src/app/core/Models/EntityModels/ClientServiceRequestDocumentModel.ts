export interface ClientServiceRequestDocumentModel {
    requestDocumentId: number;
    requestId: number | null;
    documentPath: string;
    uploadDate: Date | null;
    documentExt: string;
    documentSize: number | null;
}