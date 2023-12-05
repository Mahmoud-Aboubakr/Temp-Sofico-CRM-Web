using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofiForce.Models.SyncModels
{
    public class InvoiceSyncModel
    {
        public double? SalesId { get; set; }   
        public int? ClientId { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public double? NetTotal { get; set; }
        public String? InvoiceCode { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public String? SalesOrderTypeName { get; set; }
        public String? PaymentTermName { get; set; }
        public double? CashDiscountTotal { get; set; }
        public double? ItemTotal { get; set; }
        public double? ItemDiscountTotal { get; set; }
        public double? TaxTotal { get; set; }
    }
}
