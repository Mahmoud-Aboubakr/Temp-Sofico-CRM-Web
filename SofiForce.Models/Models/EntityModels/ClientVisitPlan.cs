using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ClientVisitPlan
    {
		public Int32? ClientRouteId { get; set; }
		public Int32? ClientId { get; set; }
		public bool? Day1 { get; set; }
		public bool? Day2 { get; set; }
		public bool? Day3 { get; set; }
		public bool? Day4 { get; set; }
		public bool? Day5 { get; set; }
		public bool? Day6 { get; set; }
		public bool? Day7 { get; set; }
	}
}
