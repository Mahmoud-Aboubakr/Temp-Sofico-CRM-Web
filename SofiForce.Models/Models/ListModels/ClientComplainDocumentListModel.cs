using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientComplainDocumentListModel
    {
        public string Id { get; set; }
        public int? DocumentSize { get; set; }
        public string DocumentExt { get; set; }
        public DateTime? UploadDate { get; set; }
        public string DocumentPath { get; set; }
        public long? ComplainId { get; set; }
        public long ComplainDocumentId { get; set; }

    }
}
