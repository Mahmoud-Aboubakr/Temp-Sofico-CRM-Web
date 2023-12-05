using System;


namespace Models
{
    public class OperationRequestDetailListModel
	{
		public Int64? DetailId { get; set; }
		public Int32? OperationId { get; set; }
		public Int32? ClientId { get; set; }
		public Int32? ClientTypeId { get; set; }
		public int? OperationTypeId { get; set; }
		public string ClientName { get; set; }
		public Int32? RegionId { get; set; }
		public Int32? GovernerateId { get; set; }
		public Int32? CityId { get; set; }
		public Int32? LocationLevelId { get; set; }
		public bool? IsChain { get; set; }
		public string ResponsibleName { get; set; }
		public string Building { get; set; }
		public string Floor { get; set; }
		public string Property { get; set; }
		public string Landmark { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public string Mobile { get; set; }
		public string WhatsApp { get; set; }
		public double? Latitude { get; set; }
		public double? Longitude { get; set; }
		public Int32? OperationStatusId { get; set; }
		public string ClientCode { get; set; }
		public string GovernerateName { get; set; }
		public string CityName { get; set; }
		public string LocationLevelName { get; set; }
		public string OperationStatusName { get; set; }

		public decimal? Accuracy { get; set; }	
		public string ClientTypeName {get;set;}
		public DateTime? OperationDate { get; set; }

	}
}
