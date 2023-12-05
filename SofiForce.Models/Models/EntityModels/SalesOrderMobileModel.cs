using System;
using System.Collections.Generic;

namespace Models
{
    public class SalesOrderMobileModel
    {
        public string Id { get; set; }
        public bool? IsSynced { get; set; } = false;
        public bool? HasError { get; set; } = false;

        public DateTime? SyncDate { get; set; }
        public double? SalesId { get; set; }
        public string SalesCode { get; set; }
        public int? ClientId { get; set; }
        public string ClientName { get; set; } = String.Empty;
        public string ClientCode { get; set; } = String.Empty;
        public int? BranchId { get; set; }
        public int? RepresentativeId { get; set; }
        public int? StoreId { get; set; }
        public DateTime? SalesDate { get; set; }
        public DateTime? SalesTime { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? ItemTotal { get; set; }
        public double? ItemDiscountTotal { get; set; }
        public double? TaxTotal { get; set; }
        public double? CashDiscountTotal { get; set; }
        public double? CustomDiscountTotal { get; set; }

        public double? DeliveryTotal { get; set; }
        public double? NetTotal { get; set; }
        public string Notes { get; set; } = String.Empty;
      


        public List<SalesOrderDetailMobileListModel> SalesOrderDetails { get; set; }=new List<SalesOrderDetailMobileListModel>();
        public List<SalesOrderPromotionMobileOptionModel> PromotionOptions { get; set; } = new List<SalesOrderPromotionMobileOptionModel>();

        public List<string> Errors { get; set; } = new List<string>();
        public List<string> Warnings { get; set; } = new List<string>();



    }
}
