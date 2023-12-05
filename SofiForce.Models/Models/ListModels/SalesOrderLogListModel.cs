using System;

namespace Models
{
    public class SalesOrderLogListModel
    {
		public Int32? UserId { get; set; }
		public DateTime? LogDate { get; set; }
		public Int32? SalesOrderLogTypeId { get; set; }
		public Int64? SalesId { get; set; }
		public Int64? LogId { get; set; }
		public string SalesOrderLogTypeName { get; set; }
		public string RealName { get; set; }
	}
}
