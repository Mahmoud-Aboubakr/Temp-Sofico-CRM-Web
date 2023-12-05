using System;
using System.Collections.Generic;

namespace Models
{
    public class LookupModel
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }


    }


    public class CallSource
    {
        public int CallSourceId { get; set; }
        public string CallSourceCode { get; set; }

        public string CallSourceNameAr { get; set; }
        public string CallSourceNameEn { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsActive { get; set; }

    }


    public class CallCategory
    {
        public int CallCategoryId { get; set; }
        public string CallCategoryCode { get; set; }

        public string CallCategoryNameAr { get; set; }
        public string CallCategoryNameEn { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsActive { get; set; }

    }

    public class CallReason
    {
        public int CallReasonId { get; set; }
        public int CallCategoryId { get; set; }

        public string CallReasonCode { get; set; }

        public string CallReasonNameAr { get; set; }
        public string CallReasonNameEn { get; set; }

        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsActive { get; set; }

    }

    public class CallStatus
    {
        public int CallStatusId { get; set; }


        public string CallStatusCode { get; set; }

        public string CallStatusNameAr { get; set; }
        public string CallStatusNameEn { get; set; }

        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsActive { get; set; }

    }


    public class ClientDocumentType
    {
        public int DocumentTypeId { get; set; }

        public string DocumentTypeCode { get; set; }

        public string DocumentTypeNameEn { get; set; }
        public string DocumentTypeNameAr { get; set; }


        public bool CanDelete { get; set; }
        public bool CanEdit { get; set; }
        public bool IsActive { get; set; }
        public bool IsRequired { get; set; }

        
        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }

    }

    public class ClientNewStatus
    {
        public int StatusId { get; set; }

        public string StatusCode { get; set; }

        public string StatusNameEn { get; set; }
        public string StatusNameAr { get; set; }


        public bool CanDelete { get; set; }
        public bool CanEdit { get; set; }
        public bool IsActive { get; set; }



        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }

    }

    public class LocationCharacteristic
    {
        public int CharacteristicId { get; set; }

        public string CharacteristicCode { get; set; }

        public string CharacteristicNameEn { get; set; }
        public string CharacteristicNameAr { get; set; }


        public bool IsActive { get; set; }



        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }

    }
    public class ClientNewRejectReason
    {
        public int RejectReasonId { get; set; }

        public string RejectReasonCode { get; set; }

        public string RejectReasonNameEn { get; set; }
        public string RejectReasonNameAr { get; set; }


        public bool CanDelete { get; set; }
        public bool CanEdit { get; set; }
        public bool IsActive { get; set; }



        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }

    }
    public class ClientNewSource
    {
        public int SourceId { get; set; }

        public string SourceCode { get; set; }

        public string SourceNameEn { get; set; }
        public string SourceNameAr { get; set; }


        public bool CanDelete { get; set; }
        public bool CanEdit { get; set; }
        public bool IsActive { get; set; }



        public string Icon { get; set; }
        public string Color { get; set; }
        public int? DisplayOrder { get; set; }

    }

    public class ClientClassification
    {
        public Int32? ClassificationId { get; set; }
        public string ClassificationCode { get; set; }
        public string ClassificationNameAr { get; set; }
        public string ClassificationNameEn { get; set; }

        public bool? IsActive { get; set; }
        public Int32? DisplayOrder { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
    }

    


}