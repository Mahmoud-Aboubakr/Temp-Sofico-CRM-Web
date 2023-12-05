using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SalesOrderPromotionAllListModel
    {
        public string PromotionCode { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public bool? IsActive { get; set; }
        public string PromotionTypeName { get; set; }

        public Int32? Priority { get; set; }
        public Int32? Repeats { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string SalesCode { get; set; }
        public decimal? NetTotal { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string InvoiceCode { get; set; }
        public decimal? DeliveryTotal { get; set; }
        public decimal? CustomDiscountTotal { get; set; }
        public decimal? CustomDiscountValue { get; set; }
        public Int32? CustomDiscountTypeId { get; set; }
        public decimal? CashDiscountTotal { get; set; }
        public decimal? TaxTotal { get; set; }
        public decimal? ItemDiscountTotal { get; set; }
        public decimal? ItemTotal { get; set; }
        public Int32? PromotionId { get; set; }
        public Int64? SalesId { get; set; }

        public int? ClientId { get; set; }

        public string ClientGroupName { get; set; }
    }
}
