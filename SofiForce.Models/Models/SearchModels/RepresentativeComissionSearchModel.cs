using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RepresentativeComissionSearchModel:BaseSearchModel
    {
		public Int32? SupervisorId { get; set; }
		public DateTime? ComissionDateFrom { get; set; }
		public DateTime? ComissionDateTo { get; set; }

		public int? IsApproved { get; set; }
		public Int32? BusinessUnitId { get; set; }
		public Int32? kindId { get; set; }
		public Int32? ComissionTypeId { get; set; }
		public Int32? BranchId { get; set; }
	}
}
