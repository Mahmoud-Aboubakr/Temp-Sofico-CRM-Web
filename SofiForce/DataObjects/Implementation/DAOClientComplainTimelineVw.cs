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
	public partial class DAOClientComplainTimelineVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int64? _timelineId;
		protected Int64? _complainId;
		protected Int32? _complainStatusId;
		protected Int32? _userId;
		protected DateTime? _timelineDate;
		protected string _notes;
		protected string _complainStatusNameEn;
		protected string _complainStatusNameAr;
		#endregion

		#region class methods
		public DAOClientComplainTimelineVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table Client_Complain_TimelineVw
		///</Summary>
		///<returns>
		///IList-DAOClientComplainTimelineVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOClientComplainTimelineVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Complain_TimelineVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Complain_TimelineVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientComplainTimelineVw> objList = new List<DAOClientComplainTimelineVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientComplainTimelineVw retObj = new DAOClientComplainTimelineVw();
						retObj._timelineId					 = Convert.IsDBNull(row["TimelineId"]) ? (Int64?)null : (Int64?)row["TimelineId"];
						retObj._complainId					 = Convert.IsDBNull(row["ComplainId"]) ? (Int64?)null : (Int64?)row["ComplainId"];
						retObj._complainStatusId					 = Convert.IsDBNull(row["ComplainStatusId"]) ? (Int32?)null : (Int32?)row["ComplainStatusId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._timelineDate					 = Convert.IsDBNull(row["TimelineDate"]) ? (DateTime?)null : (DateTime?)row["TimelineDate"];
						retObj._notes					 = Convert.IsDBNull(row["Notes"]) ? null : (string)row["Notes"];
						retObj._complainStatusNameEn					 = Convert.IsDBNull(row["ComplainStatusNameEn"]) ? null : (string)row["ComplainStatusNameEn"];
						retObj._complainStatusNameAr					 = Convert.IsDBNull(row["ComplainStatusNameAr"]) ? null : (string)row["ComplainStatusNameAr"];
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
			command.CommandText = InlineProcs.ctprClient_Complain_TimelineVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiClient_Complain_TimelineVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Complain_TimelineVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Complain_TimelineVw");
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
						if (string.Compare(projection.Member, "TimelineId", true) == 0) lst.Add(Convert.IsDBNull(row["TimelineId"]) ? (Int64?)null : (Int64?)row["TimelineId"]);
						if (string.Compare(projection.Member, "ComplainId", true) == 0) lst.Add(Convert.IsDBNull(row["ComplainId"]) ? (Int64?)null : (Int64?)row["ComplainId"]);
						if (string.Compare(projection.Member, "ComplainStatusId", true) == 0) lst.Add(Convert.IsDBNull(row["ComplainStatusId"]) ? (Int32?)null : (Int32?)row["ComplainStatusId"]);
						if (string.Compare(projection.Member, "UserId", true) == 0) lst.Add(Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"]);
						if (string.Compare(projection.Member, "TimelineDate", true) == 0) lst.Add(Convert.IsDBNull(row["TimelineDate"]) ? (DateTime?)null : (DateTime?)row["TimelineDate"]);
						if (string.Compare(projection.Member, "Notes", true) == 0) lst.Add(Convert.IsDBNull(row["Notes"]) ? null : (string)row["Notes"]);
						if (string.Compare(projection.Member, "ComplainStatusNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["ComplainStatusNameEn"]) ? null : (string)row["ComplainStatusNameEn"]);
						if (string.Compare(projection.Member, "ComplainStatusNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["ComplainStatusNameAr"]) ? null : (string)row["ComplainStatusNameAr"]);
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
		///This method returns all data rows in the table using criteriaquery api Client_Complain_TimelineVw
		///</Summary>
		///<returns>
		///IList-DAOClientComplainTimelineVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOClientComplainTimelineVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Complain_TimelineVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Complain_TimelineVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientComplainTimelineVw> objList = new List<DAOClientComplainTimelineVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientComplainTimelineVw retObj = new DAOClientComplainTimelineVw();
						retObj._timelineId					 = Convert.IsDBNull(row["TimelineId"]) ? (Int64?)null : (Int64?)row["TimelineId"];
						retObj._complainId					 = Convert.IsDBNull(row["ComplainId"]) ? (Int64?)null : (Int64?)row["ComplainId"];
						retObj._complainStatusId					 = Convert.IsDBNull(row["ComplainStatusId"]) ? (Int32?)null : (Int32?)row["ComplainStatusId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._timelineDate					 = Convert.IsDBNull(row["TimelineDate"]) ? (DateTime?)null : (DateTime?)row["TimelineDate"];
						retObj._notes					 = Convert.IsDBNull(row["Notes"]) ? null : (string)row["Notes"];
						retObj._complainStatusNameEn					 = Convert.IsDBNull(row["ComplainStatusNameEn"]) ? null : (string)row["ComplainStatusNameEn"];
						retObj._complainStatusNameAr					 = Convert.IsDBNull(row["ComplainStatusNameAr"]) ? null : (string)row["ComplainStatusNameAr"];
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
		///This method returns all data rows in the table using criteriaquery api Client_Complain_TimelineVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Complain_TimelineVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public Int64? TimelineId
		{
			get
			{
				return _timelineId;
			}
			set
			{
				_timelineId = value;
			}
		}

		public Int64? ComplainId
		{
			get
			{
				return _complainId;
			}
			set
			{
				_complainId = value;
			}
		}

		public Int32? ComplainStatusId
		{
			get
			{
				return _complainStatusId;
			}
			set
			{
				_complainStatusId = value;
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

		public DateTime? TimelineDate
		{
			get
			{
				return _timelineDate;
			}
			set
			{
				_timelineDate = value;
			}
		}

		public string Notes
		{
			get
			{
				return _notes;
			}
			set
			{
				_notes = value;
			}
		}

		public string ComplainStatusNameEn
		{
			get
			{
				return _complainStatusNameEn;
			}
			set
			{
				_complainStatusNameEn = value;
			}
		}

		public string ComplainStatusNameAr
		{
			get
			{
				return _complainStatusNameAr;
			}
			set
			{
				_complainStatusNameAr = value;
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
		internal static string ctprClient_Complain_TimelineVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[TimelineId]
			,[ComplainId]
			,[ComplainStatusId]
			,[UserId]
			,[TimelineDate]
			,[Notes]
			,[ComplainStatusNameEn]
			,[ComplainStatusNameAr]
			FROM [dbo].[Client_Complain_TimelineVw]
			";

		internal static string ctprClient_Complain_TimelineVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_Complain_TimelineVw]
			";

		internal static string ctprClient_Complain_TimelineVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Client_Complain_TimelineVw]
			##CRITERIA##
			";

		internal static string ctprClient_Complain_TimelineVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[TimelineId]
			,[ComplainId]
			,[ComplainStatusId]
			,[UserId]
			,[TimelineDate]
			,[Notes]
			,[ComplainStatusNameEn]
			,[ComplainStatusNameAr]
			FROM [dbo].[Client_Complain_TimelineVw]
			##CRITERIA##
			";

		internal static string ctprClient_Complain_TimelineVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Client_Complain_TimelineVw]
			##CRITERIA##
			";

	}
}
#endregion