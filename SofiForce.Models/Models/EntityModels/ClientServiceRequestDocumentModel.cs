using System;

namespace Models
{
    public class ClientServiceRequestDocumentModel
    {
        public long RequestDocumentId { get; set; }
        public long? RequestId { get; set; }
        public string DocumentPath { get; set; }
        public DateTime? UploadDate { get; set; }
        public string DocumentExt { get; set; }
        public int? DocumentSize { get; set; }
    }
}
