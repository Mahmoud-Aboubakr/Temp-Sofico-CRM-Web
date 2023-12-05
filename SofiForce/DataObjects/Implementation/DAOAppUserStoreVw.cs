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
	public partial class DAOAppUserStoreVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _appUserStoreId;
		protected Int32? _userId;
		protected Int32? _storeId;
		protected string _storeCode;
		protected string _storeNameAr;
		protected string _storeNameEn;
		protected string _storeTypeNameAr;
		protected string _storeTypeCode;
		protected string _storeTypeNameEn;
		#endregion

		#region class methods
		public DAOAppUserStoreVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table AppUser_StoreVw
		///</Summary>
		///<returns>
		///IList-DAOAppUserStoreVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOAppUserStoreVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_StoreVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_StoreVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserStoreVw> objList = new List<DAOAppUserStoreVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserStoreVw retObj = new DAOAppUserStoreVw();
						retObj._appUserStoreId					 = Convert.IsDBNull(row["AppUserStoreId"]) ? (Int32?)null : (Int32?)row["AppUserStoreId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._storeId					 = Convert.IsDBNull(row["StoreId"]) ? (Int32?)null : (Int32?)row["StoreId"];
						retObj._storeCode					 = Convert.IsDBNull(row["StoreCode"]) ? null : (string)row["StoreCode"];
						retObj._storeNameAr					 = Convert.IsDBNull(row["StoreNameAr"]) ? null : (string)row["StoreNameAr"];
						retObj._storeNameEn					 = Convert.IsDBNull(row["StoreNameEn"]) ? null : (string)row["StoreNameEn"];
						retObj._storeTypeNameAr					 = Convert.IsDBNull(row["StoreTypeNameAr"]) ? null : (string)row["StoreTypeNameAr"];
						retObj._storeTypeCode					 = Convert.IsDBNull(row["StoreTypeCode"]) ? null : (string)row["StoreTypeCode"];
						retObj._storeTypeNameEn					 = Convert.IsDBNull(row["StoreTypeNameEn"]) ? null : (string)row["StoreTypeNameEn"];
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
			command.CommandText = InlineProcs.ctprAppUser_StoreVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiAppUser_StoreVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUser_StoreVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_StoreVw");
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
						if (string.Compare(projection.Member, "AppUserStoreId", true) == 0) lst.Add(Convert.IsDBNull(row["AppUserStoreId"]) ? (Int32?)null : (Int32?)row["AppUserStoreId"]);
						if (string.Compare(projection.Member, "UserId", true) == 0) lst.Add(Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"]);
						if (string.Compare(projection.Member, "StoreId", true) == 0) lst.Add(Convert.IsDBNull(row["StoreId"]) ? (Int32?)null : (Int32?)row["StoreId"]);
						if (string.Compare(projection.Member, "StoreCode", true) == 0) lst.Add(Convert.IsDBNull(row["StoreCode"]) ? null : (string)row["StoreCode"]);
						if (string.Compare(projection.Member, "StoreNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["StoreNameAr"]) ? null : (string)row["StoreNameAr"]);
						if (string.Compare(projection.Member, "StoreNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["StoreNameEn"]) ? null : (string)row["StoreNameEn"]);
						if (string.Compare(projection.Member, "StoreTypeNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["StoreTypeNameAr"]) ? null : (string)row["StoreTypeNameAr"]);
						if (string.Compare(projection.Member, "StoreTypeCode", true) == 0) lst.Add(Convert.IsDBNull(row["StoreTypeCode"]) ? null : (string)row["StoreTypeCode"]);
						if (string.Compare(projection.Member, "StoreTypeNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["StoreTypeNameEn"]) ? null : (string)row["StoreTypeNameEn"]);
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
		///This method returns all data rows in the table using criteriaquery api AppUser_StoreVw
		///</Summary>
		///<returns>
		///IList-DAOAppUserStoreVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOAppUserStoreVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUser_StoreVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_StoreVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserStoreVw> objList = new List<DAOAppUserStoreVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserStoreVw retObj = new DAOAppUserStoreVw();
						retObj._appUserStoreId					 = Convert.IsDBNull(row["AppUserStoreId"]) ? (Int32?)null : (Int32?)row["AppUserStoreId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._storeId					 = Convert.IsDBNull(row["StoreId"]) ? (Int32?)null : (Int32?)row["StoreId"];
						retObj._storeCode					 = Convert.IsDBNull(row["StoreCode"]) ? null : (string)row["StoreCode"];
						retObj._storeNameAr					 = Convert.IsDBNull(row["StoreNameAr"]) ? null : (string)row["StoreNameAr"];
						retObj._storeNameEn					 = Convert.IsDBNull(row["StoreNameEn"]) ? null : (string)row["StoreNameEn"];
						retObj._storeTypeNameAr					 = Convert.IsDBNull(row["StoreTypeNameAr"]) ? null : (string)row["StoreTypeNameAr"];
						retObj._storeTypeCode					 = Convert.IsDBNull(row["StoreTypeCode"]) ? null : (string)row["StoreTypeCode"];
						retObj._storeTypeNameEn					 = Convert.IsDBNull(row["StoreTypeNameEn"]) ? null : (string)row["StoreTypeNameEn"];
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
		///This method returns all data rows in the table using criteriaquery api AppUser_StoreVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUser_StoreVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public Int32? AppUserStoreId
		{
			get
			{
				return _appUserStoreId;
			}
			set
			{
				_appUserStoreId = value;
			}
		}

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

		public Int32? StoreId
		{
			get
			{
				return _storeId;
			}
			set
			{
				_storeId = value;
			}
		}

		public string StoreCode
		{
			get
			{
				return _storeCode;
			}
			set
			{
				_storeCode = value;
			}
		}

		public string StoreNameAr
		{
			get
			{
				return _storeNameAr;
			}
			set
			{
				_storeNameAr = value;
			}
		}

		public string StoreNameEn
		{
			get
			{
				return _storeNameEn;
			}
			set
			{
				_storeNameEn = value;
			}
		}

		public string StoreTypeNameAr
		{
			get
			{
				return _storeTypeNameAr;
			}
			set
			{
				_storeTypeNameAr = value;
			}
		}

		public string StoreTypeCode
		{
			get
			{
				return _storeTypeCode;
			}
			set
			{
				_storeTypeCode = value;
			}
		}

		public string StoreTypeNameEn
		{
			get
			{
				return _storeTypeNameEn;
			}
			set
			{
				_storeTypeNameEn = value;
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
		internal static string ctprAppUser_StoreVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[AppUserStoreId]
			,[UserId]
			,[StoreId]
			,[StoreCode]
			,[StoreNameAr]
			,[StoreNameEn]
			,[StoreTypeNameAr]
			,[StoreTypeCode]
			,[StoreTypeNameEn]
			FROM [dbo].[AppUser_StoreVw]
			";

		internal static string ctprAppUser_StoreVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[AppUser_StoreVw]
			";

		internal static string ctprAppUser_StoreVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[AppUser_StoreVw]
			##CRITERIA##
			";

		internal static string ctprAppUser_StoreVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[AppUserStoreId]
			,[UserId]
			,[StoreId]
			,[StoreCode]
			,[StoreNameAr]
			,[StoreNameEn]
			,[StoreTypeNameAr]
			,[StoreTypeCode]
			,[StoreTypeNameEn]
			FROM [dbo].[AppUser_StoreVw]
			##CRITERIA##
			";

		internal static string ctprAppUser_StoreVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[AppUser_StoreVw]
			##CRITERIA##
			";

	}
}
#endregion