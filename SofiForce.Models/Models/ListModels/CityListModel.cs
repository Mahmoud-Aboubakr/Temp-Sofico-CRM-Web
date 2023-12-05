using System;
using System.Collections.Generic;

namespace Models
{
    public class CityListModel
    {
        public int CityId { get; set; }
        public int? GovernerateId { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public int? DisplayOrder { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }



    }
}
