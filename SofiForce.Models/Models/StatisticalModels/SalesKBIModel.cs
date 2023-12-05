using System;
using System.Collections.Generic;

namespace SofiForce.Models.StatisticalModels
{
    public class SalesKBIModel
    {

        public long SalesValue { get; set; }
        public int ClientCoverage { get; set; }
        public int Orders { get; set; }
        public int SalesDays { get; set; }

        public DateTime? InvoiceDate { get; set; }

    }

}
