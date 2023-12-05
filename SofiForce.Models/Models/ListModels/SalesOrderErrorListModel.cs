using System;
using System.Collections.Generic;

namespace Models
{
    public class SalesOrderErrorListModel
	{
		public string Id { get; set; }
		public double? ErrorId { get; set; }
		public double? SalesId { get; set; }
		public string ErrorDetail { get; set; }
		public DateTime? ErrorDate { get; set; }
	}
}
