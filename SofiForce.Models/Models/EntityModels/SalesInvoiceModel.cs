using System;

namespace Models
{
    public class SalesInvoiceModel
    {
        public int InvoiceId { get; set; }
        public string InvoiceCode { get; set; }
        public string SalesCode { get; set; }
        public int? InvoiceTypeId { get; set; }
        public int? InvoiceSourceId { get; set; }
        public int? ClientId { get; set; }
    }
}
