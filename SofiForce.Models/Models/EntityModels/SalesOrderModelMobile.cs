using System;
using System.Collections.Generic;

namespace Models
{
    public class SalesOrderModelMobile
    {
        public string Id { get; set; }

        public double? SalesId { get; set; }
       
        public string SalesCode { get; set; }
        public int? SalesOrderTypeId { get; set; }
        public string SalesOrderTypeName { get; set; }

        public int? ClientId { get; set; }
        public string ClientName { get; set; } = String.Empty;
        public string ClientCode { get; set; } = String.Empty;

        public int? BranchId { get; set; }
        public string BranchName { get; set; } = String.Empty;

        public int? AgentId { get; set; }
        public string AgentName { get; set; } = String.Empty;

        public int? RepresentativeId { get; set; }
        public string RepresentativeName { get; set; } = String.Empty;

        public int? StoreId { get; set; }
        public string StoreName { get; set; } = String.Empty;

        public int? PriorityTypeId { get; set; }
        public string PriorityTypeName { get; set; } = String.Empty;

        public int? PaymentTermId { get; set; }
        public string PaymentTermName { get; set; } = String.Empty;

        public DateTime? SalesDate { get; set; }
        public DateTime? SalesTime { get; set; }
        public int? SalesOrderStatusId { get; set; }
        public string SalesOrderStatusName { get; set; } = String.Empty;

        public int? SalesOrderSourceId { get; set; }
        public string SalesOrderSourceName { get; set; } = String.Empty;

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? ItemTotal { get; set; }
        public double? ItemDiscountTotal { get; set; }
        public double? TaxTotal { get; set; }
        public double? CashDiscountTotal { get; set; }
        public double? CustomDiscountTotal { get; set; }
        public int? CustomDiscountTypeId { get; set; }
        public double? CustomDiscountValue { get; set; }

        public double? DeliveryTotal { get; set; }
        public double? NetTotal { get; set; }
        public string Notes { get; set; } = String.Empty;
        public int? InvoiceRetry { get; set; }
        public bool? HasError { get; set; }
        public bool? IsInvoiced { get; set; }
        public string InvoiceCode { get; set; }=String.Empty;
        public DateTime? InvoiceDate { get; set; }

        public bool? IsSynced { get; set; } = false;
        public DateTime? SyncDate { get; set; }

        public List<SalesOrderDetailListModel> SalesOrderDetails { get; set; }=new List<SalesOrderDetailListModel>();
        public List<SalesOrderPromotionOptionModel> PromotionOptions { get; set; } = new List<SalesOrderPromotionOptionModel>();


        
        public List<string> Errors { get; set; } = new List<string>();
        public List<string> Warnings { get; set; } = new List<string>();


        // added 20221508

        public double? SalesPerenId { get; set; }

    }
}
