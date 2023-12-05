using System;
using System.Collections.Generic;

namespace Models
{
    public class OperationRequestSearchModel : BaseSearchModel
    {
		public string OperationCode { get; set; }

	
		public Int32? GovernerateId { get; set; }
		public Int32? OperationTypeId { get; set; }
		public Int32? RepresentativeId { get; set; }
		public DateTime? OperationDate { get; set; }
		public DateTime? StartDate { get; set; }

		public Int32? IsClosed { get; set; }


	}
}