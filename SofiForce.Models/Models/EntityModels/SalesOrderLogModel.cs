using System;

namespace Models
{
    public class SalesOrderLogModel
    {
        public long LogId { get; set; }
        public long? SalesId { get; set; }
        public DateTime? LogDate { get; set; }
        public string LogStatment { get; set; }
        public int? PurgeAfter { get; set; }
        public string IP { get; set; }
        public string Device { get; set; }
        public string OS { get; set; }
        public string Agent { get; set; }
        public int CBy { get; set; }
        public DateTime? CDate { get; set; }
    }
}
