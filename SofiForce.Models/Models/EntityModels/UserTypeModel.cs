using System;
using System.Collections.Generic;

namespace Models
{
    public class UserTypeModel
    {
        public UserTypeModel()
        {
            this.AppUsers = new List<AppUserModel>();
        }

        public int UserTypeId { get; set; }
        public string UserTypeCode { get; set; }
        public string UserTypeNameEn { get; set; }
        public string UserTypeNameAr { get; set; }
        public bool? IsActive { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public int? DisplayOrder { get; set; }
        public int? CBy { get; set; }
        public DateTime? CDate { get; set; }
        public int? EBy { get; set; }
        public DateTime? EDate { get; set; }

        public List<AppUserModel> AppUsers { get; set; }
    }
}
