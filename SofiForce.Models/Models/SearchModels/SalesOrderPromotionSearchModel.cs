using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofiForce.Models.Models.SearchModels
{
    public class SalesOrderPromotionSearchModel: BaseSearchModel
    {
        public int? OutcomeType { get; set; }
        public int? ItemId { get; set; }
        public string BatchNo { get; set; }
        public int? VendorId { get; set; }
        public int? BranchId { get; set; }

        public int? ClientId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string PromotionCode { get; set; }
        public string InvoiceCode { get; set; }

        public int PromotionId { get; set; }
        public double SalesId { get; set; }


    }
}
