using Models;
using System.Collections.Generic;

namespace SofiForce.Web.Dapper.Interface;

public interface IUserPermissionManager
{
    List<AppRoleFeaturePermissionListModel> getUserPermission(int userId);

}
