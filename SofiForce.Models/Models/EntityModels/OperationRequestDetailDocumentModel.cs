using System;

namespace Models
{
    public class OperationRequestDetailDocumentModel
    {
        public long DetailDocumentId { get; set; }
        public long? DetailId { get; set; }
        public int? DocumentTypeId { get; set; }
        public string DocumentPath { get; set; }
        public DateTime? UploadDate { get; set; }
        public string DocumentExt { get; set; }
        public int? DocumentSize { get; set; }
    }
}
