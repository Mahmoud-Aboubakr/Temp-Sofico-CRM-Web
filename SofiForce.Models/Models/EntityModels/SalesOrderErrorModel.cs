using System;

namespace Models
{
    public class SalesOrderErrorModel
    {
        public long ErrorId { get; set; }
        public long? SalesId { get; set; }
        public int? SalesErrorId { get; set; }
        public string ErrorDetailAr { get; set; }
        public string ErrorDetailEn { get; set; }
        public DateTime? ErrorDate { get; set; }
    }
}
