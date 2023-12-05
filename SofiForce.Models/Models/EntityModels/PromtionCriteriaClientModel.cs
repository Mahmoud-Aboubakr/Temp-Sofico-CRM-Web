using System;

namespace Models
{
    public class PromtionCriteriaClientModel
    {
        public int ClientCriteriaId { get; set; }
        public int? PromotionId { get; set; }
        public int? ClientAttributeId { get; set; }
        public string ClientAttributeCode { get; set; }

        
        public string ValueFrom { get; set; }
        public bool? Excluded { get; set; }
        public bool? IsActive { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
