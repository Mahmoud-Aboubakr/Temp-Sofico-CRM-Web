using System;

namespace Models
{
    public class AppUserModel
    {
        public int UserId { get; set; }
        public int? AppRoleId { get; set; }
        public int? UserGroupId { get; set; }
        public string RealName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? isOnline { get; set; }
        public bool? IsLocked { get; set; }
        public bool? MustChangeData { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool? MustChangePassword { get; set; }
        public bool? EmailVerified { get; set; }
        public string FirebaseId { get; set; }
        public string SignalrId { get; set; }
        public int? FailedCount { get; set; }
        public string DefaultRoute { get; set; }
        public string Phone { get; set; }
        public string WhatsApp { get; set; }
        public string Mobile { get; set; }
        public string ZoomId { get; set; }
        public string LinkedIn { get; set; }
        public string UserBio { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public string Email { get; set; }
        public string Internal { get; set; }
        public string JobTitle { get; set; }

        public string Address { get; set; }
        public string Zoom { get; set; }
        public string Fax { get; set; }
        public string Avatar { get; set; }


        public List<AppUserBranchListModel> Branchs { get; set; } = new List<AppUserBranchListModel>();
        public List<AppUserStoreListModel> Stores { get; set; }=new List<AppUserStoreListModel>();
        public List<RepresentativeListModel> Representatives { get; set; } = new List<RepresentativeListModel>();
        public List<SupervisorListModel> Supervisors { get; set; } = new List<SupervisorListModel>();
        public List<AppUserClientGroupListModel> ClientGroups { get; set; } = new List<AppUserClientGroupListModel>();

    }
}
