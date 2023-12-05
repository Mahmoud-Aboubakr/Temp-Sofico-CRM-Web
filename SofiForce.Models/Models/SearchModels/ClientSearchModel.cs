using System;
using System.Collections.Generic;

namespace Models
{
    public class ClientSearchModel : BaseSearchModel
    {
		public Int32? ClientId { get; set; }
		public string ClientCode { get; set; }
		public string ClientName { get; set; }
		public Int32? ClientTypeId { get; set; }
		public Int32? BranchId { get; set; }
		public Int32? BranchSubId { get; set; }
		public Int32? RegionId { get; set; }
		public Int32? GovernerateId { get; set; }
		public Int32? CityId { get; set; }
		public Int32? AreaId { get; set; }
		public Int32? ClientGroupId { get; set; }
		public Int32? ClientGroupSubId { get; set; }
		public Int32? BusinessUnitId { get; set; }

		public Int32? InRoute { get; set; }
		public Int32 IsNew { get; set; }
		public Int32 NeedValidation { get; set; }	
		public string Phone { get; set; }
		public string Mobile { get; set; }
		public string WhatsApp { get; set; }
		public int? IsActive { get; set; }
		public int? IsTaxable { get; set; }
		public int? IsChain { get; set; }


		public int? LocationLevelId { get; set; }
		public int? ClientClassificationId { get; set; }
		public int? PaymentTermId { get; set; }
		public string TaxCode { get; set; }
		public string CommercialCode { get; set; }


	}
}