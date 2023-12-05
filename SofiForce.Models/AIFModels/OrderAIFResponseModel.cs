using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class OrderAIFResponseModel
    {

        public DateTime InvoiceDate { get; set; }
        public string InvoiceId { get; set; }
        public string Message { get; set; }
        public int ResponseCode { get; set; }
        public double? HeaderRecId { get; set; }



    }
}