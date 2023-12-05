using System;
using System.Collections.Generic;

namespace Models
{
    public class OperationRequestDetailDocumentListModel
    {

        public string Id { get; set; }
        public int? DocumentSize { get; set; }
        public string DocumentExt { get; set; }
        public DateTime? UploadDate { get; set; }
        public string DocumentPath { get; set; }
        public int? DocumentTypeId { get; set; }
        public long? DetailId { get; set; }
        public long DetailDocumentId { get; set; }
        public string DocumentTypeName { get; set; }
    }
}
