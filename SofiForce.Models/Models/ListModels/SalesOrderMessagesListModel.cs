using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SalesOrderMessagesListModel
    {
		public Int64? SalesMessageId { get; set; }
		public Int64? SalesId { get; set; }
		public Int32? UserId { get; set; }
		public DateTime? MessageDate { get; set; }
		public string Message { get; set; }
		public string RealName { get; set; }
		public string UserName { get; set; }
		public string Avatar { get; set; }
		public string JobTitle { get; set; }
	}
}
