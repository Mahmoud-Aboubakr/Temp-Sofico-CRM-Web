using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofiForce.Models.Models.EntityModels
{
    public class SalesOrderDispatchModel
    {

        public long DispatchId { get; set; }
        public long? SalesId { get; set; }
        public string DispatchCode { get; set; }
        public DateTime? DispatchDate { get; set; }
        public DateTime? DispatchTime { get; set; }
        public DateTime? ShiftDate { get; set; }
        public int? DistributorId { get; set; }
        public int? CarId { get; set; }
        public int? DriverId { get; set; }
        public bool? InZone { get; set; }
        public decimal? Distance { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? FeedbackId { get; set; }

    }
}
