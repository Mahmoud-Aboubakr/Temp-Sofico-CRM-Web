using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ExportSalesDetailModel
    {
        public string SalesCode { get; set; }
        public string InvoiceCode { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Batch { get; set; }
        public DateTime? Expiration { get; set; }
        public decimal? PublicPrice { get; set; }
        public decimal? ClientPrice { get; set; }
        public int? Quantity { get; set; }
        public decimal? Discount { get; set; }
        public decimal? TaxValue { get; set; }
        public decimal? ItemValue { get; set; }
        public decimal? NetValue { get; set; }
    }
}

