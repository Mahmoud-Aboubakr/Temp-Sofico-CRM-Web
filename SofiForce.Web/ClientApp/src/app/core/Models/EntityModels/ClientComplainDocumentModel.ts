export interface ClientComplainDocumentModel {
    complainDocumentId: number;
    complainId: number | null;
    documentPath: string;
    uploadDate: Date | null;
    documentExt: string;
    documentSize: number | null;
}