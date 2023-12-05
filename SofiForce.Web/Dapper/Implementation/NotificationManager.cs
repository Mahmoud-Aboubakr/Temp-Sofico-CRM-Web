using Dapper;
using SofiForce.Web.Dapper.Interface;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlClient;
using System;
using SofiForce.Models.StatisticalModels;
using System.Collections.Generic;
using Models;
using static SofiForce.Web.Common.DateTimExtensions;

namespace SofiForce.Web.Dapper.Implementation
{
    public class NotificationManager : INotificationManager
    {

        private readonly DapperContext _context;

        public NotificationManager(DapperContext context)
        {
            _context = context;
        }

        public Task InsertNotification_Users(int CBy, int NotificationId, int UserGroupId, int? UserId)
        {
            List<TrakingRepresentativeModel> model = new List<TrakingRepresentativeModel>();

            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var param = new
                    {
                        @CBy = @CBy,
                        @NotificationId = NotificationId,
                        @UserGroupId = UserGroupId,
                        @UserId = UserId > 0 ? UserId : null,
                    };
                    model = connection.Query<TrakingRepresentativeModel>("Batch_Create_Notification_User", param, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return Task.CompletedTask;
        }
    }
}
