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
	public partial class DAOAppUserBranchVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _userBranchId;
		protected Int32? _branchId;
		protected Int32? _userId;
		protected string _branchCode;
		protected string _branchNameAr;
		protected string _branchNameEn;
		#endregion

		#region class methods
		public DAOAppUserBranchVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table AppUser_BranchVw
		///</Summary>
		///<returns>
		///IList-DAOAppUserBranchVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOAppUserBranchVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_BranchVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_BranchVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserBranchVw> objList = new List<DAOAppUserBranchVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserBranchVw retObj = new DAOAppUserBranchVw();
						retObj._userBranchId					 = Convert.IsDBNull(row["UserBranchId"]) ? (Int32?)null : (Int32?)row["UserBranchId"];
						retObj._branchId					 = Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._branchCode					 = Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"];
						retObj._branchNameAr					 = Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"];
						retObj._branchNameEn					 = Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"];
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
			command.CommandText = InlineProcs.ctprAppUser_BranchVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiAppUser_BranchVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUser_BranchVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_BranchVw");
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
						if (string.Compare(projection.Member, "UserBranchId", true) == 0) lst.Add(Convert.IsDBNull(row["UserBranchId"]) ? (Int32?)null : (Int32?)row["UserBranchId"]);
						if (string.Compare(projection.Member, "BranchId", true) == 0) lst.Add(Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"]);
						if (string.Compare(projection.Member, "UserId", true) == 0) lst.Add(Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"]);
						if (string.Compare(projection.Member, "BranchCode", true) == 0) lst.Add(Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"]);
						if (string.Compare(projection.Member, "BranchNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"]);
						if (string.Compare(projection.Member, "BranchNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"]);
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
		///This method returns all data rows in the table using criteriaquery api AppUser_BranchVw
		///</Summary>
		///<returns>
		///IList-DAOAppUserBranchVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOAppUserBranchVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUser_BranchVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_BranchVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserBranchVw> objList = new List<DAOAppUserBranchVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserBranchVw retObj = new DAOAppUserBranchVw();
						retObj._userBranchId					 = Convert.IsDBNull(row["UserBranchId"]) ? (Int32?)null : (Int32?)row["UserBranchId"];
						retObj._branchId					 = Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._branchCode					 = Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"];
						retObj._branchNameAr					 = Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"];
						retObj._branchNameEn					 = Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"];
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
		///This method returns all data rows in the table using criteriaquery api AppUser_BranchVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUser_BranchVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public Int32? UserBranchId
		{
			get
			{
				return _userBranchId;
			}
			set
			{
				_userBranchId = value;
			}
		}

		public Int32? BranchId
		{
			get
			{
				return _branchId;
			}
			set
			{
				_branchId = value;
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

		public string BranchCode
		{
			get
			{
				return _branchCode;
			}
			set
			{
				_branchCode = value;
			}
		}

		public string BranchNameAr
		{
			get
			{
				return _branchNameAr;
			}
			set
			{
				_branchNameAr = value;
			}
		}

		public string BranchNameEn
		{
			get
			{
				return _branchNameEn;
			}
			set
			{
				_branchNameEn = value;
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
		internal static string ctprAppUser_BranchVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[UserBranchId]
			,[BranchId]
			,[UserId]
			,[BranchCode]
			,[BranchNameAr]
			,[BranchNameEn]
			FROM [dbo].[AppUser_BranchVw]
			";

		internal static string ctprAppUser_BranchVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[AppUser_BranchVw]
			";

		internal static string ctprAppUser_BranchVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[AppUser_BranchVw]
			##CRITERIA##
			";

		internal static string ctprAppUser_BranchVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[UserBranchId]
			,[BranchId]
			,[UserId]
			,[BranchCode]
			,[BranchNameAr]
			,[BranchNameEn]
			FROM [dbo].[AppUser_BranchVw]
			##CRITERIA##
			";

		internal static string ctprAppUser_BranchVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[AppUser_BranchVw]
			##CRITERIA##
			";

	}
}
#endregion
