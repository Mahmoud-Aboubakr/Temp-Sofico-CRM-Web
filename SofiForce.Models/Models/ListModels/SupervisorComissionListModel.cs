using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SupervisorComissionListModel
    {
		public Int32? ComissionId { get; set; }
		public Int32? SupervisorId { get; set; }
		public DateTime? ComissionDate { get; set; }
		public decimal? ComissionValue { get; set; }
		public bool? IsApproved { get; set; }
		public Int32? BusinessUnitId { get; set; }
		public Int32? SupervisorTypeId { get; set; }
		public string SupervisorTypeCode { get; set; }
		public string SupervisorTypeName { get; set; }
		public string CompanyCode { get; set; }
		public string SupervisorCode { get; set; }
		public string SupervisorName { get; set; }
		public Int32? BranchId { get; set; }
		public string BranchName { get; set; }
		public string BranchCode { get; set; }

		public Int32? ComissionTypeId { get; set; }
		public string ComissionTypeName { get; set; }

	}
}
