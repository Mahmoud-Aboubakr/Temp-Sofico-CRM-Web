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
	public partial class DAOAppUserNotificationVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _userNotificationId;
		protected Int32? _notificationId;
		protected Int32? _userId;
		protected DateTime? _readDate;
		protected bool? _isReaded;
		protected string _message;
		protected string _priorityNameAr;
		protected string _priorityNameEn;
		protected string _notificationTypeNameAr;
		protected string _notificationTypeNameEn;
		protected Int32? _notificationTypeId;
		protected Int32? _priorityId;
		protected DateTime? _notificationDateTime;
		protected DateTime? _scheduleTime;
		protected DateTime? _notificationDate;
		protected string _signalrId;
		protected string _firebaseId;
		protected Int32? _userGroupId;
		protected string _priorityColor;
		protected string _userGroupNameEn;
		protected string _userGroupNameAr;
		#endregion

		#region class methods
		public DAOAppUserNotificationVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table AppUser_NotificationVw
		///</Summary>
		///<returns>
		///IList-DAOAppUserNotificationVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOAppUserNotificationVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_NotificationVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_NotificationVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserNotificationVw> objList = new List<DAOAppUserNotificationVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserNotificationVw retObj = new DAOAppUserNotificationVw();
						retObj._userNotificationId					 = Convert.IsDBNull(row["UserNotificationId"]) ? (Int32?)null : (Int32?)row["UserNotificationId"];
						retObj._notificationId					 = Convert.IsDBNull(row["NotificationId"]) ? (Int32?)null : (Int32?)row["NotificationId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._readDate					 = Convert.IsDBNull(row["ReadDate"]) ? (DateTime?)null : (DateTime?)row["ReadDate"];
						retObj._isReaded					 = Convert.IsDBNull(row["IsReaded"]) ? (bool?)null : (bool?)row["IsReaded"];
						retObj._message					 = Convert.IsDBNull(row["Message"]) ? null : (string)row["Message"];
						retObj._priorityNameAr					 = Convert.IsDBNull(row["PriorityNameAr"]) ? null : (string)row["PriorityNameAr"];
						retObj._priorityNameEn					 = Convert.IsDBNull(row["PriorityNameEn"]) ? null : (string)row["PriorityNameEn"];
						retObj._notificationTypeNameAr					 = Convert.IsDBNull(row["NotificationTypeNameAr"]) ? null : (string)row["NotificationTypeNameAr"];
						retObj._notificationTypeNameEn					 = Convert.IsDBNull(row["NotificationTypeNameEn"]) ? null : (string)row["NotificationTypeNameEn"];
						retObj._notificationTypeId					 = Convert.IsDBNull(row["NotificationTypeId"]) ? (Int32?)null : (Int32?)row["NotificationTypeId"];
						retObj._priorityId					 = Convert.IsDBNull(row["PriorityId"]) ? (Int32?)null : (Int32?)row["PriorityId"];
						retObj._notificationDateTime					 = Convert.IsDBNull(row["NotificationDateTime"]) ? (DateTime?)null : (DateTime?)row["NotificationDateTime"];
						retObj._scheduleTime					 = Convert.IsDBNull(row["ScheduleTime"]) ? (DateTime?)null : (DateTime?)row["ScheduleTime"];
						retObj._notificationDate					 = Convert.IsDBNull(row["NotificationDate"]) ? (DateTime?)null : (DateTime?)row["NotificationDate"];
						retObj._signalrId					 = Convert.IsDBNull(row["SignalrId"]) ? null : (string)row["SignalrId"];
						retObj._firebaseId					 = Convert.IsDBNull(row["FirebaseId"]) ? null : (string)row["FirebaseId"];
						retObj._userGroupId					 = Convert.IsDBNull(row["UserGroupId"]) ? (Int32?)null : (Int32?)row["UserGroupId"];
						retObj._priorityColor					 = Convert.IsDBNull(row["PriorityColor"]) ? null : (string)row["PriorityColor"];
						retObj._userGroupNameEn					 = Convert.IsDBNull(row["UserGroupNameEn"]) ? null : (string)row["UserGroupNameEn"];
						retObj._userGroupNameAr					 = Convert.IsDBNull(row["UserGroupNameAr"]) ? null : (string)row["UserGroupNameAr"];
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
			command.CommandText = InlineProcs.ctprAppUser_NotificationVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiAppUser_NotificationVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUser_NotificationVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_NotificationVw");
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
						if (string.Compare(projection.Member, "UserNotificationId", true) == 0) lst.Add(Convert.IsDBNull(row["UserNotificationId"]) ? (Int32?)null : (Int32?)row["UserNotificationId"]);
						if (string.Compare(projection.Member, "NotificationId", true) == 0) lst.Add(Convert.IsDBNull(row["NotificationId"]) ? (Int32?)null : (Int32?)row["NotificationId"]);
						if (string.Compare(projection.Member, "UserId", true) == 0) lst.Add(Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"]);
						if (string.Compare(projection.Member, "ReadDate", true) == 0) lst.Add(Convert.IsDBNull(row["ReadDate"]) ? (DateTime?)null : (DateTime?)row["ReadDate"]);
						if (string.Compare(projection.Member, "IsReaded", true) == 0) lst.Add(Convert.IsDBNull(row["IsReaded"]) ? (bool?)null : (bool?)row["IsReaded"]);
						if (string.Compare(projection.Member, "Message", true) == 0) lst.Add(Convert.IsDBNull(row["Message"]) ? null : (string)row["Message"]);
						if (string.Compare(projection.Member, "PriorityNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["PriorityNameAr"]) ? null : (string)row["PriorityNameAr"]);
						if (string.Compare(projection.Member, "PriorityNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["PriorityNameEn"]) ? null : (string)row["PriorityNameEn"]);
						if (string.Compare(projection.Member, "NotificationTypeNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["NotificationTypeNameAr"]) ? null : (string)row["NotificationTypeNameAr"]);
						if (string.Compare(projection.Member, "NotificationTypeNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["NotificationTypeNameEn"]) ? null : (string)row["NotificationTypeNameEn"]);
						if (string.Compare(projection.Member, "NotificationTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["NotificationTypeId"]) ? (Int32?)null : (Int32?)row["NotificationTypeId"]);
						if (string.Compare(projection.Member, "PriorityId", true) == 0) lst.Add(Convert.IsDBNull(row["PriorityId"]) ? (Int32?)null : (Int32?)row["PriorityId"]);
						if (string.Compare(projection.Member, "NotificationDateTime", true) == 0) lst.Add(Convert.IsDBNull(row["NotificationDateTime"]) ? (DateTime?)null : (DateTime?)row["NotificationDateTime"]);
						if (string.Compare(projection.Member, "ScheduleTime", true) == 0) lst.Add(Convert.IsDBNull(row["ScheduleTime"]) ? (DateTime?)null : (DateTime?)row["ScheduleTime"]);
						if (string.Compare(projection.Member, "NotificationDate", true) == 0) lst.Add(Convert.IsDBNull(row["NotificationDate"]) ? (DateTime?)null : (DateTime?)row["NotificationDate"]);
						if (string.Compare(projection.Member, "SignalrId", true) == 0) lst.Add(Convert.IsDBNull(row["SignalrId"]) ? null : (string)row["SignalrId"]);
						if (string.Compare(projection.Member, "FirebaseId", true) == 0) lst.Add(Convert.IsDBNull(row["FirebaseId"]) ? null : (string)row["FirebaseId"]);
						if (string.Compare(projection.Member, "UserGroupId", true) == 0) lst.Add(Convert.IsDBNull(row["UserGroupId"]) ? (Int32?)null : (Int32?)row["UserGroupId"]);
						if (string.Compare(projection.Member, "PriorityColor", true) == 0) lst.Add(Convert.IsDBNull(row["PriorityColor"]) ? null : (string)row["PriorityColor"]);
						if (string.Compare(projection.Member, "UserGroupNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["UserGroupNameEn"]) ? null : (string)row["UserGroupNameEn"]);
						if (string.Compare(projection.Member, "UserGroupNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["UserGroupNameAr"]) ? null : (string)row["UserGroupNameAr"]);
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
		///This method returns all data rows in the table using criteriaquery api AppUser_NotificationVw
		///</Summary>
		///<returns>
		///IList-DAOAppUserNotificationVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOAppUserNotificationVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUser_NotificationVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_NotificationVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserNotificationVw> objList = new List<DAOAppUserNotificationVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserNotificationVw retObj = new DAOAppUserNotificationVw();
						retObj._userNotificationId					 = Convert.IsDBNull(row["UserNotificationId"]) ? (Int32?)null : (Int32?)row["UserNotificationId"];
						retObj._notificationId					 = Convert.IsDBNull(row["NotificationId"]) ? (Int32?)null : (Int32?)row["NotificationId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._readDate					 = Convert.IsDBNull(row["ReadDate"]) ? (DateTime?)null : (DateTime?)row["ReadDate"];
						retObj._isReaded					 = Convert.IsDBNull(row["IsReaded"]) ? (bool?)null : (bool?)row["IsReaded"];
						retObj._message					 = Convert.IsDBNull(row["Message"]) ? null : (string)row["Message"];
						retObj._priorityNameAr					 = Convert.IsDBNull(row["PriorityNameAr"]) ? null : (string)row["PriorityNameAr"];
						retObj._priorityNameEn					 = Convert.IsDBNull(row["PriorityNameEn"]) ? null : (string)row["PriorityNameEn"];
						retObj._notificationTypeNameAr					 = Convert.IsDBNull(row["NotificationTypeNameAr"]) ? null : (string)row["NotificationTypeNameAr"];
						retObj._notificationTypeNameEn					 = Convert.IsDBNull(row["NotificationTypeNameEn"]) ? null : (string)row["NotificationTypeNameEn"];
						retObj._notificationTypeId					 = Convert.IsDBNull(row["NotificationTypeId"]) ? (Int32?)null : (Int32?)row["NotificationTypeId"];
						retObj._priorityId					 = Convert.IsDBNull(row["PriorityId"]) ? (Int32?)null : (Int32?)row["PriorityId"];
						retObj._notificationDateTime					 = Convert.IsDBNull(row["NotificationDateTime"]) ? (DateTime?)null : (DateTime?)row["NotificationDateTime"];
						retObj._scheduleTime					 = Convert.IsDBNull(row["ScheduleTime"]) ? (DateTime?)null : (DateTime?)row["ScheduleTime"];
						retObj._notificationDate					 = Convert.IsDBNull(row["NotificationDate"]) ? (DateTime?)null : (DateTime?)row["NotificationDate"];
						retObj._signalrId					 = Convert.IsDBNull(row["SignalrId"]) ? null : (string)row["SignalrId"];
						retObj._firebaseId					 = Convert.IsDBNull(row["FirebaseId"]) ? null : (string)row["FirebaseId"];
						retObj._userGroupId					 = Convert.IsDBNull(row["UserGroupId"]) ? (Int32?)null : (Int32?)row["UserGroupId"];
						retObj._priorityColor					 = Convert.IsDBNull(row["PriorityColor"]) ? null : (string)row["PriorityColor"];
						retObj._userGroupNameEn					 = Convert.IsDBNull(row["UserGroupNameEn"]) ? null : (string)row["UserGroupNameEn"];
						retObj._userGroupNameAr					 = Convert.IsDBNull(row["UserGroupNameAr"]) ? null : (string)row["UserGroupNameAr"];
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
		///This method returns all data rows in the table using criteriaquery api AppUser_NotificationVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUser_NotificationVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public Int32? UserNotificationId
		{
			get
			{
				return _userNotificationId;
			}
			set
			{
				_userNotificationId = value;
			}
		}

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

		public DateTime? ReadDate
		{
			get
			{
				return _readDate;
			}
			set
			{
				_readDate = value;
			}
		}

		public bool? IsReaded
		{
			get
			{
				return _isReaded;
			}
			set
			{
				_isReaded = value;
			}
		}

		public string Message
		{
			get
			{
				return _message;
			}
			set
			{
				_message = value;
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

		public string SignalrId
		{
			get
			{
				return _signalrId;
			}
			set
			{
				_signalrId = value;
			}
		}

		public string FirebaseId
		{
			get
			{
				return _firebaseId;
			}
			set
			{
				_firebaseId = value;
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

		#endregion
	}
}

#region inline sql procs
namespace SofiForce.DataObjects
{
	public partial class InlineProcs
	{
		internal static string ctprAppUser_NotificationVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[UserNotificationId]
			,[NotificationId]
			,[UserId]
			,[ReadDate]
			,[IsReaded]
			,[Message]
			,[PriorityNameAr]
			,[PriorityNameEn]
			,[NotificationTypeNameAr]
			,[NotificationTypeNameEn]
			,[NotificationTypeId]
			,[PriorityId]
			,[NotificationDateTime]
			,[ScheduleTime]
			,[NotificationDate]
			,[SignalrId]
			,[FirebaseId]
			,[UserGroupId]
			,[PriorityColor]
			,[UserGroupNameEn]
			,[UserGroupNameAr]
			FROM [dbo].[AppUser_NotificationVw]
			";

		internal static string ctprAppUser_NotificationVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[AppUser_NotificationVw]
			";

		internal static string ctprAppUser_NotificationVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[AppUser_NotificationVw]
			##CRITERIA##
			";

		internal static string ctprAppUser_NotificationVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[UserNotificationId]
			,[NotificationId]
			,[UserId]
			,[ReadDate]
			,[IsReaded]
			,[Message]
			,[PriorityNameAr]
			,[PriorityNameEn]
			,[NotificationTypeNameAr]
			,[NotificationTypeNameEn]
			,[NotificationTypeId]
			,[PriorityId]
			,[NotificationDateTime]
			,[ScheduleTime]
			,[NotificationDate]
			,[SignalrId]
			,[FirebaseId]
			,[UserGroupId]
			,[PriorityColor]
			,[UserGroupNameEn]
			,[UserGroupNameAr]
			FROM [dbo].[AppUser_NotificationVw]
			##CRITERIA##
			";

		internal static string ctprAppUser_NotificationVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[AppUser_NotificationVw]
			##CRITERIA##
			";

	}
}
#endregion
