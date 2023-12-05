using System;

namespace Models
{
    public class VacationModel
    {
        public int VacationId { get; set; }
        public int? VacationTypeId { get; set; }
        public DateTime? VacationDate { get; set; }
        public string Notes { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? Eby { get; set; }
        public DateTime? EDate { get; set; }
    }
}
