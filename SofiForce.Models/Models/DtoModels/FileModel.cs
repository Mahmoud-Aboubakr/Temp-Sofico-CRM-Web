using System.Collections.Generic;

namespace Models
{
    public class FileModel
    {
        int? Id { get; set; }
        public string FileUrl { get; set; }
        public string LocalPath { get; set; }

        public string Directory { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }

    }
}