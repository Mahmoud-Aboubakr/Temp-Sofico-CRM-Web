using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientListModel
    {

		public string ClientCode { get; set; }
		public string ClientName { get; set; }
		public Int32? BranchId { get; set; }
		public string BranchName { get; set; }
		public string BranchCode { get; set; }
		public decimal? CreditLimit { get; set; }
		public decimal? CreditBalance { get; set; }
		public string Phone { get; set; }
		public string Mobile { get; set; }
		public string WhatsApp { get; set; }
		public bool? IsActive { get; set; }
		public Int32? ClientId { get; set; }
		public string ClientTypeName { get; set; }
		public Int32? ClientTypeId { get; set; }
		public Int32? ClientAccountId { get; set; }
		public Int32? RegionId { get; set; }
		public Int32? GovernerateId { get; set; }
		public Int32? CityId { get; set; }
		public Int32? ClientGroupId { get; set; }
		public Int32? ClientGroupSubId { get; set; }
		public Int32? ClientClassificationId { get; set; }
		public Int32? PaymentTermId { get; set; }
		public bool? IsTaxable { get; set; }
		public double? Longitude { get; set; }
		public double? Latitude { get; set; }
		public string GovernerateName { get; set; }
		public string CityName { get; set; }
		public string TaxCode { get; set; }
		public string CommercialCode { get; set; }
		public bool? IsChain { get; set; }
		public Int32? LocationLevelId { get; set; }
		public string ClientGroupSubCode { get; set; }
		public string ClientGroupSubName { get; set; }
		public string ClientGroupCode { get; set; }
		public string ClientGroupName { get; set; }
		public bool? IsNew { get; set; }
		public bool? NeedValidation { get; set; }
		public string BusinessUnitCode { get; set; }
		public string BusinessUnitName { get; set; }
		public Int32? BusinessUnitId { get; set; }
		public bool? IsCashDiscount { get; set; }
		public bool? InRoute { get; set; }
		public Int32? CashGroupId { get; set; }
		public string GovernerateCode { get; set; }
		public string CityCode { get; set; }
        public string BusinessUnitNameAr { get; set; }
        public string BusinessUnitNameEn { get; set; }
        public string ClientGroupNameAr { get; set; }
        public string ClientGroupNameEn { get; set; }
        public string ClientGroupSubNameAr { get; set; }
        public string ClientGroupSubNameEn { get; set; }
        public string BranchNameAr { get; set; }
        public string BranchNameEn { get; set; }
        public string ClientNameAr { get; set; }
        public string ClientNameEn { get; set; }
        public string ClientTypeNameAr { get; set; }
        public string ClientTypeNameEn { get; set; }
        public string GovernerateNameAr { get; set; }
        public string GovernerateNameEn { get; set; }
        public string CityNameAr { get; set; }
        public string CityNameEn { get; set; }
        public int pageCount { get; set; }


    }
}
