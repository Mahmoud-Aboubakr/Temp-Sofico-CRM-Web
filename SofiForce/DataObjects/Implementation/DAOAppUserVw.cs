/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 3/23/2023 3:30:38 PM
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SofiForce.DataObjects.Interfaces;

namespace SofiForce.DataObjects
{
	public partial class DAOAppUserVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _userId;
		protected Int32? _appRoleId;
		protected Int32? _userGroupId;
		protected string _realName;
		protected string _userName;
		protected bool? _isOnline;
		protected bool? _isLocked;
		protected bool? _mustChangeData;
		protected DateTime? _lastLogin;
		protected bool? _mustChangePassword;
		protected bool? _emailVerified;
		protected string _defaultRoute;
		protected string _phone;
		protected string _whatsApp;
		protected Int32? _expr1;
		protected string _userGroupCode;
		protected string _userGroupNameEn;
		protected string _userGroupNameAr;
		protected string _appRoleCode;
		protected string _appRoleNameEn;
		protected string _appRoleNameAr;
		#endregion

		#region class methods
		public DAOAppUserVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table AppUserVw
		///</Summary>
		///<returns>
		///IList-DAOAppUserVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOAppUserVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUserVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUserVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserVw> objList = new List<DAOAppUserVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserVw retObj = new DAOAppUserVw();
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._appRoleId					 = Convert.IsDBNull(row["AppRoleId"]) ? (Int32?)null : (Int32?)row["AppRoleId"];
						retObj._userGroupId					 = Convert.IsDBNull(row["UserGroupId"]) ? (Int32?)null : (Int32?)row["UserGroupId"];
						retObj._realName					 = Convert.IsDBNull(row["RealName"]) ? null : (string)row["RealName"];
						retObj._userName					 = Convert.IsDBNull(row["UserName"]) ? null : (string)row["UserName"];
						retObj._isOnline					 = Convert.IsDBNull(row["isOnline"]) ? (bool?)null : (bool?)row["isOnline"];
						retObj._isLocked					 = Convert.IsDBNull(row["IsLocked"]) ? (bool?)null : (bool?)row["IsLocked"];
						retObj._mustChangeData					 = Convert.IsDBNull(row["MustChangeData"]) ? (bool?)null : (bool?)row["MustChangeData"];
						retObj._lastLogin					 = Convert.IsDBNull(row["LastLogin"]) ? (DateTime?)null : (DateTime?)row["LastLogin"];
						retObj._mustChangePassword					 = Convert.IsDBNull(row["MustChangePassword"]) ? (bool?)null : (bool?)row["MustChangePassword"];
						retObj._emailVerified					 = Convert.IsDBNull(row["EmailVerified"]) ? (bool?)null : (bool?)row["EmailVerified"];
						retObj._defaultRoute					 = Convert.IsDBNull(row["DefaultRoute"]) ? null : (string)row["DefaultRoute"];
						retObj._phone					 = Convert.IsDBNull(row["Phone"]) ? null : (string)row["Phone"];
						retObj._whatsApp					 = Convert.IsDBNull(row["WhatsApp"]) ? null : (string)row["WhatsApp"];
						retObj._expr1					 = Convert.IsDBNull(row["Expr1"]) ? (Int32?)null : (Int32?)row["Expr1"];
						retObj._userGroupCode					 = Convert.IsDBNull(row["UserGroupCode"]) ? null : (string)row["UserGroupCode"];
						retObj._userGroupNameEn					 = Convert.IsDBNull(row["UserGroupNameEn"]) ? null : (string)row["UserGroupNameEn"];
						retObj._userGroupNameAr					 = Convert.IsDBNull(row["UserGroupNameAr"]) ? null : (string)row["UserGroupNameAr"];
						retObj._appRoleCode					 = Convert.IsDBNull(row["AppRoleCode"]) ? null : (string)row["AppRoleCode"];
						retObj._appRoleNameEn					 = Convert.IsDBNull(row["AppRoleNameEn"]) ? null : (string)row["AppRoleNameEn"];
						retObj._appRoleNameAr					 = Convert.IsDBNull(row["AppRoleNameAr"]) ? null : (string)row["AppRoleNameAr"];
						objList.Add(retObj);
					}
				}
				return objList;
			}
			catch
			{
				throw;
			}
			finally
			{
				staticConnection.Close();
				command.Dispose();
			}
		}

		///<Summary>
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 SelectAllCount()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUserVw_SelectAllCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{

				staticConnection.Open();
				Int32 retCount = (Int32)command.ExecuteScalar();

				return retCount;
			}
			catch
			{
				throw;
			}
			finally
			{
				staticConnection.Close();
				command.Dispose();
			}
		}

		///<Summary>
		///Select specific fields of all rows using criteriaquery api
		///This method returns specific fields of all data rows in the table using criteriaquery apiAppUserVw
		///</Summary>
		///<returns>
		///IDictionary-string, IList-object..
		///</returns>
		///<parameters>
		///IList<IDataProjection> listProjection, IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IDictionary<string, IList<object>> SelectAllByCriteriaProjection(IList<IDataProjection> listProjection, IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUserVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUserVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				IDictionary<string, IList<object>> dict = new Dictionary<string, IList<object>>();
				foreach (IDataProjection projection in listProjection)
				{
					IList<object> lst = new List<object>();
					dict.Add(projection.Member, lst);
					foreach (DataRow row in dt.Rows)
					{
						if (string.Compare(projection.Member, "UserId", true) == 0) lst.Add(Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"]);
						if (string.Compare(projection.Member, "AppRoleId", true) == 0) lst.Add(Convert.IsDBNull(row["AppRoleId"]) ? (Int32?)null : (Int32?)row["AppRoleId"]);
						if (string.Compare(projection.Member, "UserGroupId", true) == 0) lst.Add(Convert.IsDBNull(row["UserGroupId"]) ? (Int32?)null : (Int32?)row["UserGroupId"]);
						if (string.Compare(projection.Member, "RealName", true) == 0) lst.Add(Convert.IsDBNull(row["RealName"]) ? null : (string)row["RealName"]);
						if (string.Compare(projection.Member, "UserName", true) == 0) lst.Add(Convert.IsDBNull(row["UserName"]) ? null : (string)row["UserName"]);
						if (string.Compare(projection.Member, "isOnline", true) == 0) lst.Add(Convert.IsDBNull(row["isOnline"]) ? (bool?)null : (bool?)row["isOnline"]);
						if (string.Compare(projection.Member, "IsLocked", true) == 0) lst.Add(Convert.IsDBNull(row["IsLocked"]) ? (bool?)null : (bool?)row["IsLocked"]);
						if (string.Compare(projection.Member, "MustChangeData", true) == 0) lst.Add(Convert.IsDBNull(row["MustChangeData"]) ? (bool?)null : (bool?)row["MustChangeData"]);
						if (string.Compare(projection.Member, "LastLogin", true) == 0) lst.Add(Convert.IsDBNull(row["LastLogin"]) ? (DateTime?)null : (DateTime?)row["LastLogin"]);
						if (string.Compare(projection.Member, "MustChangePassword", true) == 0) lst.Add(Convert.IsDBNull(row["MustChangePassword"]) ? (bool?)null : (bool?)row["MustChangePassword"]);
						if (string.Compare(projection.Member, "EmailVerified", true) == 0) lst.Add(Convert.IsDBNull(row["EmailVerified"]) ? (bool?)null : (bool?)row["EmailVerified"]);
						if (string.Compare(projection.Member, "DefaultRoute", true) == 0) lst.Add(Convert.IsDBNull(row["DefaultRoute"]) ? null : (string)row["DefaultRoute"]);
						if (string.Compare(projection.Member, "Phone", true) == 0) lst.Add(Convert.IsDBNull(row["Phone"]) ? null : (string)row["Phone"]);
						if (string.Compare(projection.Member, "WhatsApp", true) == 0) lst.Add(Convert.IsDBNull(row["WhatsApp"]) ? null : (string)row["WhatsApp"]);
						if (string.Compare(projection.Member, "Expr1", true) == 0) lst.Add(Convert.IsDBNull(row["Expr1"]) ? (Int32?)null : (Int32?)row["Expr1"]);
						if (string.Compare(projection.Member, "UserGroupCode", true) == 0) lst.Add(Convert.IsDBNull(row["UserGroupCode"]) ? null : (string)row["UserGroupCode"]);
						if (string.Compare(projection.Member, "UserGroupNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["UserGroupNameEn"]) ? null : (string)row["UserGroupNameEn"]);
						if (string.Compare(projection.Member, "UserGroupNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["UserGroupNameAr"]) ? null : (string)row["UserGroupNameAr"]);
						if (string.Compare(projection.Member, "AppRoleCode", true) == 0) lst.Add(Convert.IsDBNull(row["AppRoleCode"]) ? null : (string)row["AppRoleCode"]);
						if (string.Compare(projection.Member, "AppRoleNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["AppRoleNameEn"]) ? null : (string)row["AppRoleNameEn"]);
						if (string.Compare(projection.Member, "AppRoleNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["AppRoleNameAr"]) ? null : (string)row["AppRoleNameAr"]);
					}
				}
				return dict;
			}
			catch
			{
				throw;
			}
			finally
			{
				staticConnection.Close();
				command.Dispose();
			}
		}

		///<Summary>
		///Select all rows by filter criteria
		///This method returns all data rows in the table using criteriaquery api AppUserVw
		///</Summary>
		///<returns>
		///IList-DAOAppUserVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOAppUserVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUserVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUserVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserVw> objList = new List<DAOAppUserVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserVw retObj = new DAOAppUserVw();
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._appRoleId					 = Convert.IsDBNull(row["AppRoleId"]) ? (Int32?)null : (Int32?)row["AppRoleId"];
						retObj._userGroupId					 = Convert.IsDBNull(row["UserGroupId"]) ? (Int32?)null : (Int32?)row["UserGroupId"];
						retObj._realName					 = Convert.IsDBNull(row["RealName"]) ? null : (string)row["RealName"];
						retObj._userName					 = Convert.IsDBNull(row["UserName"]) ? null : (string)row["UserName"];
						retObj._isOnline					 = Convert.IsDBNull(row["isOnline"]) ? (bool?)null : (bool?)row["isOnline"];
						retObj._isLocked					 = Convert.IsDBNull(row["IsLocked"]) ? (bool?)null : (bool?)row["IsLocked"];
						retObj._mustChangeData					 = Convert.IsDBNull(row["MustChangeData"]) ? (bool?)null : (bool?)row["MustChangeData"];
						retObj._lastLogin					 = Convert.IsDBNull(row["LastLogin"]) ? (DateTime?)null : (DateTime?)row["LastLogin"];
						retObj._mustChangePassword					 = Convert.IsDBNull(row["MustChangePassword"]) ? (bool?)null : (bool?)row["MustChangePassword"];
						retObj._emailVerified					 = Convert.IsDBNull(row["EmailVerified"]) ? (bool?)null : (bool?)row["EmailVerified"];
						retObj._defaultRoute					 = Convert.IsDBNull(row["DefaultRoute"]) ? null : (string)row["DefaultRoute"];
						retObj._phone					 = Convert.IsDBNull(row["Phone"]) ? null : (string)row["Phone"];
						retObj._whatsApp					 = Convert.IsDBNull(row["WhatsApp"]) ? null : (string)row["WhatsApp"];
						retObj._expr1					 = Convert.IsDBNull(row["Expr1"]) ? (Int32?)null : (Int32?)row["Expr1"];
						retObj._userGroupCode					 = Convert.IsDBNull(row["UserGroupCode"]) ? null : (string)row["UserGroupCode"];
						retObj._userGroupNameEn					 = Convert.IsDBNull(row["UserGroupNameEn"]) ? null : (string)row["UserGroupNameEn"];
						retObj._userGroupNameAr					 = Convert.IsDBNull(row["UserGroupNameAr"]) ? null : (string)row["UserGroupNameAr"];
						retObj._appRoleCode					 = Convert.IsDBNull(row["AppRoleCode"]) ? null : (string)row["AppRoleCode"];
						retObj._appRoleNameEn					 = Convert.IsDBNull(row["AppRoleNameEn"]) ? null : (string)row["AppRoleNameEn"];
						retObj._appRoleNameAr					 = Convert.IsDBNull(row["AppRoleNameAr"]) ? null : (string)row["AppRoleNameAr"];
						objList.Add(retObj);
					}
				}
				return objList;
			}
			catch
			{
				throw;
			}
			finally
			{
				staticConnection.Close();
				command.Dispose();
			}
		}

		///<Summary>
		///Select count of all rows using criteriaquery api
		///This method returns all data rows in the table using criteriaquery api AppUserVw
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion
		///</parameters>
		public static Int32 SelectAllByCriteriaCount(IList<IDataCriterion> listCriterion)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUserVw_SelectAllByCriteriaCount, null, listCriterion, null);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{

				staticConnection.Open();
				Int32 retCount = (Int32)command.ExecuteScalar();

				return retCount;
			}
			catch
			{
				throw;
			}
			finally
			{
				staticConnection.Close();
				command.Dispose();
			}
		}

		#endregion

		#region member properties

		public Int32? UserId
		{
			get
			{
				return _userId;
			}
			set
			{
				_userId = value;
			}
		}

		public Int32? AppRoleId
		{
			get
			{
				return _appRoleId;
			}
			set
			{
				_appRoleId = value;
			}
		}

		public Int32? UserGroupId
		{
			get
			{
				return _userGroupId;
			}
			set
			{
				_userGroupId = value;
			}
		}

		public string RealName
		{
			get
			{
				return _realName;
			}
			set
			{
				_realName = value;
			}
		}

		public string UserName
		{
			get
			{
				return _userName;
			}
			set
			{
				_userName = value;
			}
		}

		public bool? IsOnline
		{
			get
			{
				return _isOnline;
			}
			set
			{
				_isOnline = value;
			}
		}

		public bool? IsLocked
		{
			get
			{
				return _isLocked;
			}
			set
			{
				_isLocked = value;
			}
		}

		public bool? MustChangeData
		{
			get
			{
				return _mustChangeData;
			}
			set
			{
				_mustChangeData = value;
			}
		}

		public DateTime? LastLogin
		{
			get
			{
				return _lastLogin;
			}
			set
			{
				_lastLogin = value;
			}
		}

		public bool? MustChangePassword
		{
			get
			{
				return _mustChangePassword;
			}
			set
			{
				_mustChangePassword = value;
			}
		}

		public bool? EmailVerified
		{
			get
			{
				return _emailVerified;
			}
			set
			{
				_emailVerified = value;
			}
		}

		public string DefaultRoute
		{
			get
			{
				return _defaultRoute;
			}
			set
			{
				_defaultRoute = value;
			}
		}

		public string Phone
		{
			get
			{
				return _phone;
			}
			set
			{
				_phone = value;
			}
		}

		public string WhatsApp
		{
			get
			{
				return _whatsApp;
			}
			set
			{
				_whatsApp = value;
			}
		}

		public Int32? Expr1
		{
			get
			{
				return _expr1;
			}
			set
			{
				_expr1 = value;
			}
		}

		public string UserGroupCode
		{
			get
			{
				return _userGroupCode;
			}
			set
			{
				_userGroupCode = value;
			}
		}

		public string UserGroupNameEn
		{
			get
			{
				return _userGroupNameEn;
			}
			set
			{
				_userGroupNameEn = value;
			}
		}

		public string UserGroupNameAr
		{
			get
			{
				return _userGroupNameAr;
			}
			set
			{
				_userGroupNameAr = value;
			}
		}

		public string AppRoleCode
		{
			get
			{
				return _appRoleCode;
			}
			set
			{
				_appRoleCode = value;
			}
		}

		public string AppRoleNameEn
		{
			get
			{
				return _appRoleNameEn;
			}
			set
			{
				_appRoleNameEn = value;
			}
		}

		public string AppRoleNameAr
		{
			get
			{
				return _appRoleNameAr;
			}
			set
			{
				_appRoleNameAr = value;
			}
		}

		#endregion
	}
}

#region inline sql procs
namespace SofiForce.DataObjects
{
	public partial class InlineProcs
	{
		internal static string ctprAppUserVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[UserId]
			,[AppRoleId]
			,[UserGroupId]
			,[RealName]
			,[UserName]
			,[isOnline]
			,[IsLocked]
			,[MustChangeData]
			,[LastLogin]
			,[MustChangePassword]
			,[EmailVerified]
			,[DefaultRoute]
			,[Phone]
			,[WhatsApp]
			,[Expr1]
			,[UserGroupCode]
			,[UserGroupNameEn]
			,[UserGroupNameAr]
			,[AppRoleCode]
			,[AppRoleNameEn]
			,[AppRoleNameAr]
			FROM [dbo].[AppUserVw]
			";

		internal static string ctprAppUserVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[AppUserVw]
			";

		internal static string ctprAppUserVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[AppUserVw]
			##CRITERIA##
			";

		internal static string ctprAppUserVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[UserId]
			,[AppRoleId]
			,[UserGroupId]
			,[RealName]
			,[UserName]
			,[isOnline]
			,[IsLocked]
			,[MustChangeData]
			,[LastLogin]
			,[MustChangePassword]
			,[EmailVerified]
			,[DefaultRoute]
			,[Phone]
			,[WhatsApp]
			,[Expr1]
			,[UserGroupCode]
			,[UserGroupNameEn]
			,[UserGroupNameAr]
			,[AppRoleCode]
			,[AppRoleNameEn]
			,[AppRoleNameAr]
			FROM [dbo].[AppUserVw]
			##CRITERIA##
			";

		internal static string ctprAppUserVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[AppUserVw]
			##CRITERIA##
			";

	}
}
#endregion