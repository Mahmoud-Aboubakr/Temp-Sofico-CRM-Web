using System;

namespace Models
{
    public class ClientDocumentModel
    {
        public int ClientDocumentId { get; set; }
        public int? ClientId { get; set; }
        public int? DocumentTypeId { get; set; }
        public string DocumentPath { get; set; }
        public DateTime? UploadDate { get; set; }
        public string DocumentExt { get; set; }
        public string DocumentSize { get; set; }
    }
}
