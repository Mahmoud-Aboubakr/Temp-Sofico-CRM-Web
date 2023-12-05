using System;
using System.Collections.Generic;

namespace Models
{
    public class OperationRequestDetailModel
    {
        public string Id { get; set; }
        public int? DetailId { get; set; }
        public int? OperationId { get; set; }
        public int? OperationTypeId { get; set; }   

        public DateTime? OperationDate { get; set; }
        public int? ClientId { get; set; }
        public string ClientCode { get; set; }
       

        public int? ClientTypeId { get; set; }
        public string ClientTypeName { get; set; }

        public string ClientNameAr { get; set; }
        public string ClientNameEn { get; set; }
        public int? RegionId { get; set; }
        public string RegionName { get; set; }

        public int? GovernerateId { get; set; }
        public string GovernerateName { get; set; }

        public int? CityId { get; set; }
        public string CityName { get; set; }

        public int? LocationLevelId { get; set; }
        public string LocationLevelName { get; set; }

        public bool? IsChain { get; set; }
        public string ResponsibleNameEn { get; set; }
        public string ResponsibleNameAr { get; set; }
        public string Building { get; set; }
        public string TaxCode { get; set; }
        public string CommercialCode { get; set; }
        public string Floor { get; set; }
        public string Property { get; set; }
        public string Address { get; set; }
        public string Landmark { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string WhatsApp { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public decimal? Accuracy { get; set; }
        public bool? InZone { get; set; }
        public int? OperationStatusId { get; set; }
        public string OperationStatusName { get; set; }


        public int? OperationRejectReasonId { get; set; }
        public string OperationRejectReasonName { get; set; }

        public bool? IsSynced { get; set; } = false;
        public DateTime? SyncDate { get; set; }


        public List<OperationRequestDetailDocumentListModel> Documents { get; set; } = new List<OperationRequestDetailDocumentListModel>();
        public List<OperationRequestDetailLandmarkListModel> Landmarks { get; set; } = new List<OperationRequestDetailLandmarkListModel>();
        public List<OperationRequestDetailPreferredTimeListModel> PreferredTimes { get; set; } = new List<OperationRequestDetailPreferredTimeListModel>();


        public bool IsValid()
        {
            bool valid = true;

            if(OperationId==null || OperationId==0)
                valid = false;

            if (ClientTypeId == null || ClientTypeId == 0)
                valid = false;

            if (string.IsNullOrEmpty(ClientNameAr))
                valid = false;

            if (string.IsNullOrEmpty(ClientNameEn))
                valid = false;

            if (GovernerateId == null || GovernerateId == 0)
                valid = false;

            if (CityId == null || CityId == 0)
                valid = false;

            if (LocationLevelId == null || LocationLevelId == 0)
                valid = false;

            if (string.IsNullOrEmpty(TaxCode))
                valid = false;

            if (string.IsNullOrEmpty(CommercialCode))
                valid = false;

            if (string.IsNullOrEmpty(Address))
                valid = false;

            if (string.IsNullOrEmpty(Mobile))
                valid = false;

            if (Latitude == null || Latitude == 0)
                valid = false;

            if (Longitude == null || Longitude == 0)
                valid = false;

            return valid;
        }

    }
}
