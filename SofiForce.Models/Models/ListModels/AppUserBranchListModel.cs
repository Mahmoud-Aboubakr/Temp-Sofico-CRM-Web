using System;

namespace Models
{
    public class AppUserBranchListModel
    {
        public int UserBranchId { get; set; }
        public int? BranchId { get; set; }
        public int? UserId { get; set; }

        public string BranchCode { get; set; }
        public string BranchName { get; set; }
    }
}
