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
	public partial class DAONotificationVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _notificationId;
		protected DateTime? _notificationDate;
		protected DateTime? _scheduleTime;
		protected DateTime? _notificationDateTime;
		protected Int32? _priorityId;
		protected Int32? _notificationTypeId;
		protected string _notificationTypeNameEn;
		protected string _notificationTypeNameAr;
		protected Int32? _userCount;
		protected Int32? _readed;
		protected Int32? _notReaded;
		protected string _priorityNameAr;
		protected string _priorityNameEn;
		protected Int32? _userGroupId;
		protected Int32? _userId;
		protected string _userGroupNameEn;
		protected string _userGroupNameAr;
		protected string _priorityColor;
		#endregion

		#region class methods
		public DAONotificationVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table NotificationVw
		///</Summary>
		///<returns>
		///IList-DAONotificationVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAONotificationVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprNotificationVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("NotificationVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAONotificationVw> objList = new List<DAONotificationVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAONotificationVw retObj = new DAONotificationVw();
						retObj._notificationId					 = Convert.IsDBNull(row["NotificationId"]) ? (Int32?)null : (Int32?)row["NotificationId"];
						retObj._notificationDate					 = Convert.IsDBNull(row["NotificationDate"]) ? (DateTime?)null : (DateTime?)row["NotificationDate"];
						retObj._scheduleTime					 = Convert.IsDBNull(row["ScheduleTime"]) ? (DateTime?)null : (DateTime?)row["ScheduleTime"];
						retObj._notificationDateTime					 = Convert.IsDBNull(row["NotificationDateTime"]) ? (DateTime?)null : (DateTime?)row["NotificationDateTime"];
						retObj._priorityId					 = Convert.IsDBNull(row["PriorityId"]) ? (Int32?)null : (Int32?)row["PriorityId"];
						retObj._notificationTypeId					 = Convert.IsDBNull(row["NotificationTypeId"]) ? (Int32?)null : (Int32?)row["NotificationTypeId"];
						retObj._notificationTypeNameEn					 = Convert.IsDBNull(row["NotificationTypeNameEn"]) ? null : (string)row["NotificationTypeNameEn"];
						retObj._notificationTypeNameAr					 = Convert.IsDBNull(row["NotificationTypeNameAr"]) ? null : (string)row["NotificationTypeNameAr"];
						retObj._userCount					 = Convert.IsDBNull(row["UserCount"]) ? (Int32?)null : (Int32?)row["UserCount"];
						retObj._readed					 = Convert.IsDBNull(row["Readed"]) ? (Int32?)null : (Int32?)row["Readed"];
						retObj._notReaded					 = Convert.IsDBNull(row["NotReaded"]) ? (Int32?)null : (Int32?)row["NotReaded"];
						retObj._priorityNameAr					 = Convert.IsDBNull(row["PriorityNameAr"]) ? null : (string)row["PriorityNameAr"];
						retObj._priorityNameEn					 = Convert.IsDBNull(row["PriorityNameEn"]) ? null : (string)row["PriorityNameEn"];
						retObj._userGroupId					 = Convert.IsDBNull(row["UserGroupId"]) ? (Int32?)null : (Int32?)row["UserGroupId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._userGroupNameEn					 = Convert.IsDBNull(row["UserGroupNameEn"]) ? null : (string)row["UserGroupNameEn"];
						retObj._userGroupNameAr					 = Convert.IsDBNull(row["UserGroupNameAr"]) ? null : (string)row["UserGroupNameAr"];
						retObj._priorityColor					 = Convert.IsDBNull(row["PriorityColor"]) ? null : (string)row["PriorityColor"];
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
			command.CommandText = InlineProcs.ctprNotificationVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiNotificationVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprNotificationVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("NotificationVw");
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
						if (string.Compare(projection.Member, "NotificationId", true) == 0) lst.Add(Convert.IsDBNull(row["NotificationId"]) ? (Int32?)null : (Int32?)row["NotificationId"]);
						if (string.Compare(projection.Member, "NotificationDate", true) == 0) lst.Add(Convert.IsDBNull(row["NotificationDate"]) ? (DateTime?)null : (DateTime?)row["NotificationDate"]);
						if (string.Compare(projection.Member, "ScheduleTime", true) == 0) lst.Add(Convert.IsDBNull(row["ScheduleTime"]) ? (DateTime?)null : (DateTime?)row["ScheduleTime"]);
						if (string.Compare(projection.Member, "NotificationDateTime", true) == 0) lst.Add(Convert.IsDBNull(row["NotificationDateTime"]) ? (DateTime?)null : (DateTime?)row["NotificationDateTime"]);
						if (string.Compare(projection.Member, "PriorityId", true) == 0) lst.Add(Convert.IsDBNull(row["PriorityId"]) ? (Int32?)null : (Int32?)row["PriorityId"]);
						if (string.Compare(projection.Member, "NotificationTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["NotificationTypeId"]) ? (Int32?)null : (Int32?)row["NotificationTypeId"]);
						if (string.Compare(projection.Member, "NotificationTypeNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["NotificationTypeNameEn"]) ? null : (string)row["NotificationTypeNameEn"]);
						if (string.Compare(projection.Member, "NotificationTypeNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["NotificationTypeNameAr"]) ? null : (string)row["NotificationTypeNameAr"]);
						if (string.Compare(projection.Member, "UserCount", true) == 0) lst.Add(Convert.IsDBNull(row["UserCount"]) ? (Int32?)null : (Int32?)row["UserCount"]);
						if (string.Compare(projection.Member, "Readed", true) == 0) lst.Add(Convert.IsDBNull(row["Readed"]) ? (Int32?)null : (Int32?)row["Readed"]);
						if (string.Compare(projection.Member, "NotReaded", true) == 0) lst.Add(Convert.IsDBNull(row["NotReaded"]) ? (Int32?)null : (Int32?)row["NotReaded"]);
						if (string.Compare(projection.Member, "PriorityNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["PriorityNameAr"]) ? null : (string)row["PriorityNameAr"]);
						if (string.Compare(projection.Member, "PriorityNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["PriorityNameEn"]) ? null : (string)row["PriorityNameEn"]);
						if (string.Compare(projection.Member, "UserGroupId", true) == 0) lst.Add(Convert.IsDBNull(row["UserGroupId"]) ? (Int32?)null : (Int32?)row["UserGroupId"]);
						if (string.Compare(projection.Member, "UserId", true) == 0) lst.Add(Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"]);
						if (string.Compare(projection.Member, "UserGroupNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["UserGroupNameEn"]) ? null : (string)row["UserGroupNameEn"]);
						if (string.Compare(projection.Member, "UserGroupNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["UserGroupNameAr"]) ? null : (string)row["UserGroupNameAr"]);
						if (string.Compare(projection.Member, "PriorityColor", true) == 0) lst.Add(Convert.IsDBNull(row["PriorityColor"]) ? null : (string)row["PriorityColor"]);
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
		///This method returns all data rows in the table using criteriaquery api NotificationVw
		///</Summary>
		///<returns>
		///IList-DAONotificationVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAONotificationVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprNotificationVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("NotificationVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAONotificationVw> objList = new List<DAONotificationVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAONotificationVw retObj = new DAONotificationVw();
						retObj._notificationId					 = Convert.IsDBNull(row["NotificationId"]) ? (Int32?)null : (Int32?)row["NotificationId"];
						retObj._notificationDate					 = Convert.IsDBNull(row["NotificationDate"]) ? (DateTime?)null : (DateTime?)row["NotificationDate"];
						retObj._scheduleTime					 = Convert.IsDBNull(row["ScheduleTime"]) ? (DateTime?)null : (DateTime?)row["ScheduleTime"];
						retObj._notificationDateTime					 = Convert.IsDBNull(row["NotificationDateTime"]) ? (DateTime?)null : (DateTime?)row["NotificationDateTime"];
						retObj._priorityId					 = Convert.IsDBNull(row["PriorityId"]) ? (Int32?)null : (Int32?)row["PriorityId"];
						retObj._notificationTypeId					 = Convert.IsDBNull(row["NotificationTypeId"]) ? (Int32?)null : (Int32?)row["NotificationTypeId"];
						retObj._notificationTypeNameEn					 = Convert.IsDBNull(row["NotificationTypeNameEn"]) ? null : (string)row["NotificationTypeNameEn"];
						retObj._notificationTypeNameAr					 = Convert.IsDBNull(row["NotificationTypeNameAr"]) ? null : (string)row["NotificationTypeNameAr"];
						retObj._userCount					 = Convert.IsDBNull(row["UserCount"]) ? (Int32?)null : (Int32?)row["UserCount"];
						retObj._readed					 = Convert.IsDBNull(row["Readed"]) ? (Int32?)null : (Int32?)row["Readed"];
						retObj._notReaded					 = Convert.IsDBNull(row["NotReaded"]) ? (Int32?)null : (Int32?)row["NotReaded"];
						retObj._priorityNameAr					 = Convert.IsDBNull(row["PriorityNameAr"]) ? null : (string)row["PriorityNameAr"];
						retObj._priorityNameEn					 = Convert.IsDBNull(row["PriorityNameEn"]) ? null : (string)row["PriorityNameEn"];
						retObj._userGroupId					 = Convert.IsDBNull(row["UserGroupId"]) ? (Int32?)null : (Int32?)row["UserGroupId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._userGroupNameEn					 = Convert.IsDBNull(row["UserGroupNameEn"]) ? null : (string)row["UserGroupNameEn"];
						retObj._userGroupNameAr					 = Convert.IsDBNull(row["UserGroupNameAr"]) ? null : (string)row["UserGroupNameAr"];
						retObj._priorityColor					 = Convert.IsDBNull(row["PriorityColor"]) ? null : (string)row["PriorityColor"];
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
		///This method returns all data rows in the table using criteriaquery api NotificationVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprNotificationVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public Int32? NotificationId
		{
			get
			{
				return _notificationId;
			}
			set
			{
				_notificationId = value;
			}
		}

		public DateTime? NotificationDate
		{
			get
			{
				return _notificationDate;
			}
			set
			{
				_notificationDate = value;
			}
		}

		public DateTime? ScheduleTime
		{
			get
			{
				return _scheduleTime;
			}
			set
			{
				_scheduleTime = value;
			}
		}

		public DateTime? NotificationDateTime
		{
			get
			{
				return _notificationDateTime;
			}
			set
			{
				_notificationDateTime = value;
			}
		}

		public Int32? PriorityId
		{
			get
			{
				return _priorityId;
			}
			set
			{
				_priorityId = value;
			}
		}

		public Int32? NotificationTypeId
		{
			get
			{
				return _notificationTypeId;
			}
			set
			{
				_notificationTypeId = value;
			}
		}

		public string NotificationTypeNameEn
		{
			get
			{
				return _notificationTypeNameEn;
			}
			set
			{
				_notificationTypeNameEn = value;
			}
		}

		public string NotificationTypeNameAr
		{
			get
			{
				return _notificationTypeNameAr;
			}
			set
			{
				_notificationTypeNameAr = value;
			}
		}

		public Int32? UserCount
		{
			get
			{
				return _userCount;
			}
			set
			{
				_userCount = value;
			}
		}

		public Int32? Readed
		{
			get
			{
				return _readed;
			}
			set
			{
				_readed = value;
			}
		}

		public Int32? NotReaded
		{
			get
			{
				return _notReaded;
			}
			set
			{
				_notReaded = value;
			}
		}

		public string PriorityNameAr
		{
			get
			{
				return _priorityNameAr;
			}
			set
			{
				_priorityNameAr = value;
			}
		}

		public string PriorityNameEn
		{
			get
			{
				return _priorityNameEn;
			}
			set
			{
				_priorityNameEn = value;
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

		public string PriorityColor
		{
			get
			{
				return _priorityColor;
			}
			set
			{
				_priorityColor = value;
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
		internal static string ctprNotificationVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[NotificationId]
			,[NotificationDate]
			,[ScheduleTime]
			,[NotificationDateTime]
			,[PriorityId]
			,[NotificationTypeId]
			,[NotificationTypeNameEn]
			,[NotificationTypeNameAr]
			,[UserCount]
			,[Readed]
			,[NotReaded]
			,[PriorityNameAr]
			,[PriorityNameEn]
			,[UserGroupId]
			,[UserId]
			,[UserGroupNameEn]
			,[UserGroupNameAr]
			,[PriorityColor]
			FROM [dbo].[NotificationVw]
			";

		internal static string ctprNotificationVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[NotificationVw]
			";

		internal static string ctprNotificationVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[NotificationVw]
			##CRITERIA##
			";

		internal static string ctprNotificationVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[NotificationId]
			,[NotificationDate]
			,[ScheduleTime]
			,[NotificationDateTime]
			,[PriorityId]
			,[NotificationTypeId]
			,[NotificationTypeNameEn]
			,[NotificationTypeNameAr]
			,[UserCount]
			,[Readed]
			,[NotReaded]
			,[PriorityNameAr]
			,[PriorityNameEn]
			,[UserGroupId]
			,[UserId]
			,[UserGroupNameEn]
			,[UserGroupNameAr]
			,[PriorityColor]
			FROM [dbo].[NotificationVw]
			##CRITERIA##
			";

		internal static string ctprNotificationVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[NotificationVw]
			##CRITERIA##
			";

	}
}
#endregion
