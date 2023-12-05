using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RepresentativeComissionListModel
    {
        public int RepresentativeId { get; set; }
        public string RepresentativeCode { get; set; }
        public string RepresentativeName { get; set; }

		public Int32? ComissionId { get; set; }
		public Int32? SupervisorId { get; set; }
		public DateTime? ComissionDate { get; set; }
		public decimal? ComissionValue { get; set; }
		public bool? IsApproved { get; set; }
		public Int32? BusinessUnitId { get; set; }
		public Int32? kindId { get; set; }
		public string kindCode { get; set; }
		public string kindName { get; set; }
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
