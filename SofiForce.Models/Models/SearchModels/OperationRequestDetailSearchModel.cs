using System;
using System.Collections.Generic;

namespace Models
{
    public class OperationRequestDetailSearchModel : BaseSearchModel
    {

		
		public Int32? ClientId { get; set; }
		public int? OperationTypeId { get; set; }
		public int? RepresentativeId { get; set; }
		public Int32? OperationId { get; set; }
		public Int32? ClientTypeId { get; set; }
		public Int32? RegionId { get; set; }
		public Int32? GovernerateId { get; set; }
		public Int32? CityId { get; set; }
		public Int32? LocationLevelId { get; set; }
		public Int32? OperationStatusId { get; set; }
		public Int32? OperationRejectReasonId { get; set; }
		public DateTime? OperationDate { get; set; }


	}
}