using System;

namespace Models
{
    public class PromtionCriteriaSalesManAttrCustomModel
    {
        public int SalesManCustomId { get; set; }
        public int? SalesManAttributeId { get; set; }
        public string ValueFrom { get; set; }
        public bool? IsActive { get; set; }

        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
