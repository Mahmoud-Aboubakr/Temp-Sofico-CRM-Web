using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientModel
    {
        public int ClientId { get; set; }
        public int? BusinessUnitId { get; set; }
        public int? ClientAccountId { get; set; }
        public int? ClientTypeId { get; set; }
        public string ClientCode { get; set; }
        public string ClientNameAr { get; set; }
        public string ClientNameEn { get; set; }
        public int? BranchId { get; set; }
        public int? RegionId { get; set; }
        public int? GovernerateId { get; set; }
        public int? CityId { get; set; }
        public int? LocationLevelId { get; set; }
        public int? ClientGroupId { get; set; }
        public int? ClientGroupSubId { get; set; }
        public int? ClientClassificationId { get; set; }
        public decimal? CreditLimit { get; set; }
        public decimal? CreditBalance { get; set; }
        public int? PaymentTermId { get; set; }
        public bool? IsChain { get; set; }
        public string ResponsibleNameAr { get; set; }
        public string ResponsibleNameEn { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Property { get; set; }
        public string Address { get; set; }
        public string Landmark { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string WhatsApp { get; set; }
        public bool? IsActive { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string TaxCode { get; set; }
        public string CommercialCode { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
        public bool? IsTaxable { get; set; }

        public int? IsCashDiscount { get; set; }
        public List<ClientDocumentListModel> Documents { get; set; }
        public List<ClientLandmarkListModel> Landmarks { get; set; }
        public List<ClientPreferredTimeListModel> PreferredTimes { get; set; }

    }
}
