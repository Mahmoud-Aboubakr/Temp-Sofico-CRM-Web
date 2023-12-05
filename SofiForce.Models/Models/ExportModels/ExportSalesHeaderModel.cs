using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ExportSalesHeaderModel
    {
        public string SalesCode { get; set; }
        public string InvoiceCode { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string InvoiceType { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string StoreCode { get; set; }
        public string StoreName { get; set; }
        public string SalesManCode { get; set; }
        public string SalesManName { get; set; }
        public string PaymentTerm { get; set; }
        public DateTime? SalesTime { get; set; }
        public string SalesChannel { get; set; }
        public string SalesPool { get; set; }
        public decimal? ItemTotal { get; set; }
        public decimal? OfferDiscount { get; set; }
        public decimal? TaxTotal { get; set; }
        public decimal? CashDiscount { get; set; }
        public decimal? CashPercentage { get; set; }


        
        public decimal? NetTotal { get; set; }
        public decimal? OpenValue { get; set; }

        public string ClaimNo { get; set; }


    }
}

