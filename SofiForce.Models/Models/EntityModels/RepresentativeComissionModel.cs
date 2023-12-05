using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RepresentativeComissionModel
    {
		public Int32? ComissionId { get; set; }
		public Int32? RepresentativeId { get; set; }
		public DateTime? ComissionDate { get; set; }
		public decimal? ComissionValue { get; set; }
		public bool? IsApproved { get; set; }

		public Int32? ComissionTypeId { get; set; }
		public string Notes { get; set; }
	}
}
