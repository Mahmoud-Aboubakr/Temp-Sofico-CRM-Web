using System;

namespace Models
{
    public class PromtionCriteriaClientAttrCustomModel
    {
        public int ClientCustomId { get; set; }
        public int? ClientAttributeId { get; set; }
        public string ValueFrom { get; set; }
        public bool? IsActive { get; set; }

        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
