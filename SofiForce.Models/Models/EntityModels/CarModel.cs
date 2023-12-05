using System;

namespace Models
{
    public class CarModel
    {
        public int CarId { get; set; }
        public int? CarTypeId { get; set; }
        public string CarCode { get; set; }
        public string CarNo { get; set; }
        public string Model { get; set; }
        public int? ManufacturerId { get; set; }
        public int? YearManufactur { get; set; }
        public bool? IsActive { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }
    }
}
