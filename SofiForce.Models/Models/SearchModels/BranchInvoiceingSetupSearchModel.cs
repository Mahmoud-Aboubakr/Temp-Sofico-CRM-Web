using System;
using System.Collections.Generic;

namespace Models
{
    public class BranchInvoiceingSetupSearchModel : BaseSearchModel
    {

        public int? ServiceWorkerId { get; set; }
        public int? IsEnabled { get; set; }
        public int? BranchId { get; set; }


    }
}