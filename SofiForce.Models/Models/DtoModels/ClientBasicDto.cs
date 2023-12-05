using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ClientBasicDto
    {
        public int ClientId { get; set; }
        public int? ClientAccountId { get; set; }
        public string ClientAccountCode { get; set; }

        public int? ClientTypeId { get; set; }
        public string ClientCode { get; set; }
        public string ClientNameAr { get; set; }
        public string ClientNameEn { get; set; }
        public int? BranchId { get; set; }
        public int? RegionId { get; set; }
        public int? ClientGroupId { get; set; }
        public int? ClientGroupSubId { get; set; }
        public int? BusinessUnitId { get; set; }

        public int? ClientClassificationId { get; set; }
        public decimal? CreditLimit { get; set; }
        public decimal? CreditBalance { get; set; }
        public int? PaymentTermId { get; set; }
        public bool? IsChain { get; set; }
        public string ResponsibleNameAr { get; set; }
        public string ResponsibleNameEn { get; set; }

        public bool? IsTaxable { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsCashDiscount { get; set; }
        public string TaxCode { get; set; }
        public string CommercialCode { get; set; }
    }
}
