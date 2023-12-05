using System;
using System.Collections.Generic;

namespace Models
{
    public class OperationRequestListModel
	{
		public Int32? OperationId { get; set; }
		public string OperationCode { get; set; }
		public Int32? AgentId { get; set; }
		public Int32? OperationTypeId { get; set; }
		public Int32? RepresentativeId { get; set; }
		public Int32? GovernerateId { get; set; }

		public DateTime? StartDate { get; set; }
		public Int32? TargetDays { get; set; }

		public bool? IsClosed { get; set; }
		public DateTime? CloseDate { get; set; }
		public string RepresentativeCode { get; set; }
		public string RepresentativeName { get; set; }
		public string GovernerateName { get; set; }
		public string MapPoints { get; set; }

		public List<GeoPoint> MapPointList { get; set; }


		public string OperationTypeName { get; set; }
		public string Phone { get; set; }


		public DateTime? OperationDate { get; set; }
		public decimal? Accuracy { get; set; }
		public decimal? ClientsPerformance { get; set; }
		public decimal? DaysPerformance { get; set; }
		public Int32? ActualClients { get; set; }
		public Int32? TargetClients { get; set; }
		public Int32? ActualDays { get; set; }


	}
}
