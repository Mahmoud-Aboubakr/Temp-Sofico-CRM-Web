using System;

namespace Models
{
    public class ClientServiceRequestDocumentListModel
    {
        public string Id { get; set; }
        public int? DocumentSize { get; set; }
        public string DocumentExt { get; set; }
        public DateTime? UploadDate { get; set; }
        public string DocumentPath { get; set; }
        public long? RequestId { get; set; }
        public long RequestDocumentId { get; set; }
    }
}
