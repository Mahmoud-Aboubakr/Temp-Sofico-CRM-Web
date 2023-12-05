using Models;
using SofiForce.Models.StatisticalModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SofiForce.Web.Dapper.Interface
{
    public interface INotificationManager
    {

        Task InsertNotification_Users(int CBy, int NotificationId, int UserGroupId, int? UserId);

    }
}
