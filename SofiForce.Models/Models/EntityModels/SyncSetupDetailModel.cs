using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SyncSetupDetailModel
    {
		public Int64? DetailId { get; set; }
		public Int32? SetupId { get; set; }
		public Int32? UserId { get; set; }
		public DateTime? SyncDate { get; set; }
		public string Payload1 { get; set; }
		public string Payload2 { get; set; }
		public string Payload3 { get; set; }
		public string Payload4 { get; set; }

		public bool? IsDone { get; set; }
		public string Message { get; set; }
	}
}
