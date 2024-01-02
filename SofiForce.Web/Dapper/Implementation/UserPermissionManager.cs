using Dapper;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Models;
using SofiForce.BusinessObjects;
using SofiForce.DataObjects;
using SofiForce.Web.Dapper.Interface;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace SofiForce.Web.Dapper.Implementation;

public class UserPermissionManager : IUserPermissionManager
{
	private readonly DapperContext _context;

    public UserPermissionManager(DapperContext context)
    {
        _context = context;
    }


    public List<AppRoleFeaturePermissionListModel> getUserPermission(int userId)
    {
        List<AppRoleFeaturePermissionListModel> model = new List<AppRoleFeaturePermissionListModel>();
        try
		{
            using (var connection = _context.CreateConnection())
            {
                var param = new
                {
                    @UserId = userId
                };
                model = connection.Query<AppRoleFeaturePermissionListModel>
                    ("GetUserFeaturePermission", 
                    param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout:120
                    ).ToList();

            }
        }
		catch (System.Exception)
		{

			throw;
		}
        return model;
    }

}
