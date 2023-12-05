export interface ClientDocumentListModel {
    clientDocumentId: number;
    clientId: number | null;
    documentTypeId: number | null;
    documentPath: string;
    uploadDate: Date | null;
    documentExt: string;
    documentSize: number | null;
    documentTypeName: string;
}