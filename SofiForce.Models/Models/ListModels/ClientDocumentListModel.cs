using System;

namespace Models
{
    public class ClientDocumentListModel
    {
        public int ClientDocumentId { get; set; }
        public int? ClientId { get; set; }
        public int? DocumentTypeId { get; set; }
        public string DocumentPath { get; set; }
        public DateTime? UploadDate { get; set; }
        public string DocumentExt { get; set; }
        public int? DocumentSize { get; set; }
        public string DocumentTypeName { get; set; }
    }
}
