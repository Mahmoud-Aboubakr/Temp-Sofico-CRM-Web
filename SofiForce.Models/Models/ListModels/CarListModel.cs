using System;
using System.Collections.Generic;

namespace Models
{
    public class CarListModel
    {
		public string BranchCode { get; set; }
		public string BranchName { get; set; }
		public string CarNo { get; set; }
		public string CarCode { get; set; }
		public Int32? BranchId { get; set; }
		public Int32? CarId { get; set; }
		public Int32? CarTypeId { get; set; }
		public string CarTypeCode { get; set; }
		public string CarTypeName { get; set; }
		public Int32? ManufacturerId { get; set; }
		public Int32? YearManufactur { get; set; }
		public string ManufacturerCode { get; set; }
		public string ManufacturerName { get; set; }
		public string Model { get; set; }
		public bool? IsActive { get; set; }
	}
}
