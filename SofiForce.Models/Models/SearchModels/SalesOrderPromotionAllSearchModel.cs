using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SalesOrderPromotionAllSearchModel : BaseSearchModel
    {
        public int PromotionId { get; set; }
        public int ClientId { get; set; }
        public double SalesId { get; set; }

        public string PromotionCode { get; set; }
        public string ClientCode { get; set; }
        public string InvoiceCode { get; set; }

        public DateTime? InvoiceDateFrom { get; set; }
        public DateTime? InvoiceDateTo { get; set; }

        

    }
}
