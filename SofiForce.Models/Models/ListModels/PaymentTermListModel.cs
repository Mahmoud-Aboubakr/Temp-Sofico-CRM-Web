using System;
using System.Collections.Generic;

namespace Models
{
    public class PaymentTermListModel
    {

        public int PaymentTermId { get; set; }
        public string PaymentTermCode { get; set; }
        public string PaymentTermName { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public bool? IsActive { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }


    }
}
