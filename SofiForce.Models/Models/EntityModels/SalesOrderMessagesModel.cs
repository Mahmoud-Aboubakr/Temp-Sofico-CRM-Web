using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SalesOrderMessagesModel
    {
		public Int64? SalesMessageId { get; set; }
		public Int64? SalesId { get; set; }
		public Int32? UserId { get; set; }
		public DateTime? MessageDate { get; set; }
		public string Message { get; set; }
		
	}
}
