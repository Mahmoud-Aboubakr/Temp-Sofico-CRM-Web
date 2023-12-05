using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;


namespace Models
{
    public class OrderAIFRequestModel
    {
        [Required]
        public string CustAccount { get; set; }
        [Required]
        public string SalesManId { get; set; }
        [Required]
        public string InventSiteId { get; set; }
        [Required]
        public string InventLocationId { get; set; }
        [Required]
        public string CustomerReference { get; set; }
        [Required]
        public int OrderSource { get; set; }
        [Required]
        public DateTime transDate { get; set; }

        public string SalesTakerId { get; set; }

        public string ShipCarrierAccount { get; set; }

        public decimal CashDisc { set; get; }

        public decimal CashDiscValue { get; set; }

        // [Required]
        //public double Cash { get; set; }

        //[Required]
        // public double Visa { get; set; }

        public List<payment> Payment { set; get; }
        
        public class payment
        {
            public string Payment { set; get; }

            public decimal Value { set; get; }
            public string Reference { set; get; }

        }

        [Required]
        public List<SalesLine> salesLine { set; get; }


        public class SalesLine
        {
            public string ItemId { set; get; }
            public decimal Quantity { set; get; }
            public string Batch { set; get; }
            public decimal Price { set; get; }


            public decimal Discount { set; get; }
            public string Unit { set; get; }
            //public bool isPromo { get; set; }
        }

      
     
    }
}