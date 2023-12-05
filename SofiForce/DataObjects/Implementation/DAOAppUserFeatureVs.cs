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
	public partial class DAOAppUserFeatureVs : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _userId;
		protected Int32? _appRoleId;
		protected string _appRoleCode;
		protected Int32? _featueId;
		protected Int32? _applicationId;
		protected string _featueCode;
		protected string _featueNameEn;
		protected string _featueNameAr;
		protected string _featuePath;
		protected bool? _isNew;
		protected bool? _isUpdated;
		protected bool? _isActive;
		#endregion

		#region class methods
		public DAOAppUserFeatureVs()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table AppUserFeatureVs
		///</Summary>
		///<returns>
		///IList-DAOAppUserFeatureVs.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOAppUserFeatureVs> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUserFeatureVs_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUserFeatureVs");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserFeatureVs> objList = new List<DAOAppUserFeatureVs>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserFeatureVs retObj = new DAOAppUserFeatureVs();
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._appRoleId					 = Convert.IsDBNull(row["AppRoleId"]) ? (Int32?)null : (Int32?)row["AppRoleId"];
						retObj._appRoleCode					 = Convert.IsDBNull(row["AppRoleCode"]) ? null : (string)row["AppRoleCode"];
						retObj._featueId					 = Convert.IsDBNull(row["FeatueId"]) ? (Int32?)null : (Int32?)row["FeatueId"];
						retObj._applicationId					 = Convert.IsDBNull(row["ApplicationId"]) ? (Int32?)null : (Int32?)row["ApplicationId"];
						retObj._featueCode					 = Convert.IsDBNull(row["FeatueCode"]) ? null : (string)row["FeatueCode"];
						retObj._featueNameEn					 = Convert.IsDBNull(row["FeatueNameEn"]) ? null : (string)row["FeatueNameEn"];
						retObj._featueNameAr					 = Convert.IsDBNull(row["FeatueNameAr"]) ? null : (string)row["FeatueNameAr"];
						retObj._featuePath					 = Convert.IsDBNull(row["FeatuePath"]) ? null : (string)row["FeatuePath"];
						retObj._isNew					 = Convert.IsDBNull(row["IsNew"]) ? (bool?)null : (bool?)row["IsNew"];
						retObj._isUpdated					 = Convert.IsDBNull(row["IsUpdated"]) ? (bool?)null : (bool?)row["IsUpdated"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
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
			command.CommandText = InlineProcs.ctprAppUserFeatureVs_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiAppUserFeatureVs
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUserFeatureVs_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUserFeatureVs");
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
						if (string.Compare(projection.Member, "AppRoleCode", true) == 0) lst.Add(Convert.IsDBNull(row["AppRoleCode"]) ? null : (string)row["AppRoleCode"]);
						if (string.Compare(projection.Member, "FeatueId", true) == 0) lst.Add(Convert.IsDBNull(row["FeatueId"]) ? (Int32?)null : (Int32?)row["FeatueId"]);
						if (string.Compare(projection.Member, "ApplicationId", true) == 0) lst.Add(Convert.IsDBNull(row["ApplicationId"]) ? (Int32?)null : (Int32?)row["ApplicationId"]);
						if (string.Compare(projection.Member, "FeatueCode", true) == 0) lst.Add(Convert.IsDBNull(row["FeatueCode"]) ? null : (string)row["FeatueCode"]);
						if (string.Compare(projection.Member, "FeatueNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["FeatueNameEn"]) ? null : (string)row["FeatueNameEn"]);
						if (string.Compare(projection.Member, "FeatueNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["FeatueNameAr"]) ? null : (string)row["FeatueNameAr"]);
						if (string.Compare(projection.Member, "FeatuePath", true) == 0) lst.Add(Convert.IsDBNull(row["FeatuePath"]) ? null : (string)row["FeatuePath"]);
						if (string.Compare(projection.Member, "IsNew", true) == 0) lst.Add(Convert.IsDBNull(row["IsNew"]) ? (bool?)null : (bool?)row["IsNew"]);
						if (string.Compare(projection.Member, "IsUpdated", true) == 0) lst.Add(Convert.IsDBNull(row["IsUpdated"]) ? (bool?)null : (bool?)row["IsUpdated"]);
						if (string.Compare(projection.Member, "IsActive", true) == 0) lst.Add(Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"]);
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
		///This method returns all data rows in the table using criteriaquery api AppUserFeatureVs
		///</Summary>
		///<returns>
		///IList-DAOAppUserFeatureVs.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOAppUserFeatureVs> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUserFeatureVs_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUserFeatureVs");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserFeatureVs> objList = new List<DAOAppUserFeatureVs>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserFeatureVs retObj = new DAOAppUserFeatureVs();
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._appRoleId					 = Convert.IsDBNull(row["AppRoleId"]) ? (Int32?)null : (Int32?)row["AppRoleId"];
						retObj._appRoleCode					 = Convert.IsDBNull(row["AppRoleCode"]) ? null : (string)row["AppRoleCode"];
						retObj._featueId					 = Convert.IsDBNull(row["FeatueId"]) ? (Int32?)null : (Int32?)row["FeatueId"];
						retObj._applicationId					 = Convert.IsDBNull(row["ApplicationId"]) ? (Int32?)null : (Int32?)row["ApplicationId"];
						retObj._featueCode					 = Convert.IsDBNull(row["FeatueCode"]) ? null : (string)row["FeatueCode"];
						retObj._featueNameEn					 = Convert.IsDBNull(row["FeatueNameEn"]) ? null : (string)row["FeatueNameEn"];
						retObj._featueNameAr					 = Convert.IsDBNull(row["FeatueNameAr"]) ? null : (string)row["FeatueNameAr"];
						retObj._featuePath					 = Convert.IsDBNull(row["FeatuePath"]) ? null : (string)row["FeatuePath"];
						retObj._isNew					 = Convert.IsDBNull(row["IsNew"]) ? (bool?)null : (bool?)row["IsNew"];
						retObj._isUpdated					 = Convert.IsDBNull(row["IsUpdated"]) ? (bool?)null : (bool?)row["IsUpdated"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
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
		///This method returns all data rows in the table using criteriaquery api AppUserFeatureVs
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUserFeatureVs_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public Int32? FeatueId
		{
			get
			{
				return _featueId;
			}
			set
			{
				_featueId = value;
			}
		}

		public Int32? ApplicationId
		{
			get
			{
				return _applicationId;
			}
			set
			{
				_applicationId = value;
			}
		}

		public string FeatueCode
		{
			get
			{
				return _featueCode;
			}
			set
			{
				_featueCode = value;
			}
		}

		public string FeatueNameEn
		{
			get
			{
				return _featueNameEn;
			}
			set
			{
				_featueNameEn = value;
			}
		}

		public string FeatueNameAr
		{
			get
			{
				return _featueNameAr;
			}
			set
			{
				_featueNameAr = value;
			}
		}

		public string FeatuePath
		{
			get
			{
				return _featuePath;
			}
			set
			{
				_featuePath = value;
			}
		}

		public bool? IsNew
		{
			get
			{
				return _isNew;
			}
			set
			{
				_isNew = value;
			}
		}

		public bool? IsUpdated
		{
			get
			{
				return _isUpdated;
			}
			set
			{
				_isUpdated = value;
			}
		}

		public bool? IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActive = value;
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
		internal static string ctprAppUserFeatureVs_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[UserId]
			,[AppRoleId]
			,[AppRoleCode]
			,[FeatueId]
			,[ApplicationId]
			,[FeatueCode]
			,[FeatueNameEn]
			,[FeatueNameAr]
			,[FeatuePath]
			,[IsNew]
			,[IsUpdated]
			,[IsActive]
			FROM [dbo].[AppUserFeatureVs]
			";

		internal static string ctprAppUserFeatureVs_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[AppUserFeatureVs]
			";

		internal static string ctprAppUserFeatureVs_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[AppUserFeatureVs]
			##CRITERIA##
			";

		internal static string ctprAppUserFeatureVs_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[UserId]
			,[AppRoleId]
			,[AppRoleCode]
			,[FeatueId]
			,[ApplicationId]
			,[FeatueCode]
			,[FeatueNameEn]
			,[FeatueNameAr]
			,[FeatuePath]
			,[IsNew]
			,[IsUpdated]
			,[IsActive]
			FROM [dbo].[AppUserFeatureVs]
			##CRITERIA##
			";

		internal static string ctprAppUserFeatureVs_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[AppUserFeatureVs]
			##CRITERIA##
			";

	}
}
#endregion