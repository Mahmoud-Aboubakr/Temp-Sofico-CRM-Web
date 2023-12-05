using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SalesOrderAddressModel
    {
        public long SalesAddressId { get; set; }
        public long? SalesId { get; set; }
        public int? RegionId { get; set; }
        public int? GovernerateId { get; set; }
        public int? CityId { get; set; }
        public string Address { get; set; }
        public string Landmark { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Property { get; set; }
        public string Mobile { get; set; }
        public string WhatsApp { get; set; }
        public string Phone { get; set; }

        public bool? UpdateClient { get; set; }=false;

    }
}

