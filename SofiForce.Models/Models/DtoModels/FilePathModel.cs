using System.Collections.Generic;

namespace Models
{
    public class supplementaryUploadDtoModel
    {
        public string FilePath { get; set; }
        public int ValidCount { get; set; }
        public int InValidCount { get; set; }

        public List<string> Errors { get; set; }=new List<string>(){ };

    }
}