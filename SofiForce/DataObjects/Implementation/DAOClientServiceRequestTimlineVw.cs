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
	public partial class DAOClientServiceRequestTimlineVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int64? _timelineId;
		protected Int64? _requestId;
		protected Int32? _requestStatusId;
		protected Int32? _userId;
		protected DateTime? _timelineDate;
		protected string _notes;
		protected string _requestStatusNameEn;
		protected string _requestStatusNameAr;
		protected string _realName;
		protected string _color;
		#endregion

		#region class methods
		public DAOClientServiceRequestTimlineVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table Client_ServiceRequest_TimlineVw
		///</Summary>
		///<returns>
		///IList-DAOClientServiceRequestTimlineVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOClientServiceRequestTimlineVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_ServiceRequest_TimlineVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_ServiceRequest_TimlineVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientServiceRequestTimlineVw> objList = new List<DAOClientServiceRequestTimlineVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientServiceRequestTimlineVw retObj = new DAOClientServiceRequestTimlineVw();
						retObj._timelineId					 = Convert.IsDBNull(row["TimelineId"]) ? (Int64?)null : (Int64?)row["TimelineId"];
						retObj._requestId					 = Convert.IsDBNull(row["RequestId"]) ? (Int64?)null : (Int64?)row["RequestId"];
						retObj._requestStatusId					 = Convert.IsDBNull(row["RequestStatusId"]) ? (Int32?)null : (Int32?)row["RequestStatusId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._timelineDate					 = Convert.IsDBNull(row["TimelineDate"]) ? (DateTime?)null : (DateTime?)row["TimelineDate"];
						retObj._notes					 = Convert.IsDBNull(row["Notes"]) ? null : (string)row["Notes"];
						retObj._requestStatusNameEn					 = Convert.IsDBNull(row["RequestStatusNameEn"]) ? null : (string)row["RequestStatusNameEn"];
						retObj._requestStatusNameAr					 = Convert.IsDBNull(row["RequestStatusNameAr"]) ? null : (string)row["RequestStatusNameAr"];
						retObj._realName					 = Convert.IsDBNull(row["RealName"]) ? null : (string)row["RealName"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
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
			command.CommandText = InlineProcs.ctprClient_ServiceRequest_TimlineVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiClient_ServiceRequest_TimlineVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_ServiceRequest_TimlineVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_ServiceRequest_TimlineVw");
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
						if (string.Compare(projection.Member, "RequestId", true) == 0) lst.Add(Convert.IsDBNull(row["RequestId"]) ? (Int64?)null : (Int64?)row["RequestId"]);
						if (string.Compare(projection.Member, "RequestStatusId", true) == 0) lst.Add(Convert.IsDBNull(row["RequestStatusId"]) ? (Int32?)null : (Int32?)row["RequestStatusId"]);
						if (string.Compare(projection.Member, "UserId", true) == 0) lst.Add(Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"]);
						if (string.Compare(projection.Member, "TimelineDate", true) == 0) lst.Add(Convert.IsDBNull(row["TimelineDate"]) ? (DateTime?)null : (DateTime?)row["TimelineDate"]);
						if (string.Compare(projection.Member, "Notes", true) == 0) lst.Add(Convert.IsDBNull(row["Notes"]) ? null : (string)row["Notes"]);
						if (string.Compare(projection.Member, "RequestStatusNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["RequestStatusNameEn"]) ? null : (string)row["RequestStatusNameEn"]);
						if (string.Compare(projection.Member, "RequestStatusNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["RequestStatusNameAr"]) ? null : (string)row["RequestStatusNameAr"]);
						if (string.Compare(projection.Member, "RealName", true) == 0) lst.Add(Convert.IsDBNull(row["RealName"]) ? null : (string)row["RealName"]);
						if (string.Compare(projection.Member, "Color", true) == 0) lst.Add(Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"]);
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
		///This method returns all data rows in the table using criteriaquery api Client_ServiceRequest_TimlineVw
		///</Summary>
		///<returns>
		///IList-DAOClientServiceRequestTimlineVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOClientServiceRequestTimlineVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_ServiceRequest_TimlineVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_ServiceRequest_TimlineVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientServiceRequestTimlineVw> objList = new List<DAOClientServiceRequestTimlineVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientServiceRequestTimlineVw retObj = new DAOClientServiceRequestTimlineVw();
						retObj._timelineId					 = Convert.IsDBNull(row["TimelineId"]) ? (Int64?)null : (Int64?)row["TimelineId"];
						retObj._requestId					 = Convert.IsDBNull(row["RequestId"]) ? (Int64?)null : (Int64?)row["RequestId"];
						retObj._requestStatusId					 = Convert.IsDBNull(row["RequestStatusId"]) ? (Int32?)null : (Int32?)row["RequestStatusId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._timelineDate					 = Convert.IsDBNull(row["TimelineDate"]) ? (DateTime?)null : (DateTime?)row["TimelineDate"];
						retObj._notes					 = Convert.IsDBNull(row["Notes"]) ? null : (string)row["Notes"];
						retObj._requestStatusNameEn					 = Convert.IsDBNull(row["RequestStatusNameEn"]) ? null : (string)row["RequestStatusNameEn"];
						retObj._requestStatusNameAr					 = Convert.IsDBNull(row["RequestStatusNameAr"]) ? null : (string)row["RequestStatusNameAr"];
						retObj._realName					 = Convert.IsDBNull(row["RealName"]) ? null : (string)row["RealName"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
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
		///This method returns all data rows in the table using criteriaquery api Client_ServiceRequest_TimlineVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_ServiceRequest_TimlineVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public Int64? RequestId
		{
			get
			{
				return _requestId;
			}
			set
			{
				_requestId = value;
			}
		}

		public Int32? RequestStatusId
		{
			get
			{
				return _requestStatusId;
			}
			set
			{
				_requestStatusId = value;
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

		public string RequestStatusNameEn
		{
			get
			{
				return _requestStatusNameEn;
			}
			set
			{
				_requestStatusNameEn = value;
			}
		}

		public string RequestStatusNameAr
		{
			get
			{
				return _requestStatusNameAr;
			}
			set
			{
				_requestStatusNameAr = value;
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

		public string Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
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
		internal static string ctprClient_ServiceRequest_TimlineVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[TimelineId]
			,[RequestId]
			,[RequestStatusId]
			,[UserId]
			,[TimelineDate]
			,[Notes]
			,[RequestStatusNameEn]
			,[RequestStatusNameAr]
			,[RealName]
			,[Color]
			FROM [dbo].[Client_ServiceRequest_TimlineVw]
			";

		internal static string ctprClient_ServiceRequest_TimlineVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_ServiceRequest_TimlineVw]
			";

		internal static string ctprClient_ServiceRequest_TimlineVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Client_ServiceRequest_TimlineVw]
			##CRITERIA##
			";

		internal static string ctprClient_ServiceRequest_TimlineVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[TimelineId]
			,[RequestId]
			,[RequestStatusId]
			,[UserId]
			,[TimelineDate]
			,[Notes]
			,[RequestStatusNameEn]
			,[RequestStatusNameAr]
			,[RealName]
			,[Color]
			FROM [dbo].[Client_ServiceRequest_TimlineVw]
			##CRITERIA##
			";

		internal static string ctprClient_ServiceRequest_TimlineVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Client_ServiceRequest_TimlineVw]
			##CRITERIA##
			";

	}
}
#endregion
