using System;

namespace Models
{
    public class ClientActivityModel
    {
        public string Id { get; set; }
        public bool? IsSynced { get; set; } = false;
        public DateTime? SyncDate { get; set; }

        public double? ActivityId { get; set; }
        public int? ClientId { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }

        public int? RepresentativeId { get; set; }
        public DateTime? ActivityDate { get; set; }
        public DateTime? ActivityTime { get; set; }
        public DateTime? CallAgain { get; set; }

        
        public int? Duration { get; set; }
        public bool? InJourney { get; set; }
        public bool? InZone { get; set; }

        public bool? IsPositive { get; set; }
        public int? ActivityTypeId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public decimal? Distance { get; set; }
        public double? SalesId { get; set; }
        public string Notes { get; set; }



        public bool Valid()
        {
            bool isvalid=true;

            if (this.ClientId==null || this.ClientId==0)
                isvalid=false;

            if (this.RepresentativeId == null || this.RepresentativeId == 0)
                isvalid = false;

            if (this.ActivityTypeId == null || this.ActivityTypeId == 0)
                isvalid = false;

            if (this.ActivityTime == null)
                isvalid = false;


            if (this.IsPositive == null)
                isvalid = false;

            if (this.InJourney == null)
                isvalid = false;

            if (this.InZone == null)
                isvalid = false;

            return isvalid;


        }
    }
}
