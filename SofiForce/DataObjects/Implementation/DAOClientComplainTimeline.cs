/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 9/9/2023 5:10:24 PM
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SofiForce.DataObjects.Interfaces;

namespace SofiForce.DataObjects
{
	public partial class DAOClientComplainTimeline : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int64? _timelineId;
		protected Int64? _complainId;
		protected Int32? _complainStatusId;
		protected Int32? _userId;
		protected DateTime? _timelineDate;
		protected string _notes;
		#endregion

		#region class methods
		public DAOClientComplainTimeline()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table Client_Complain_Timeline based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOClientComplainTimeline
		///</returns>
		///<parameters>
		///Int64? timelineId
		///</parameters>
		public static DAOClientComplainTimeline SelectOne(Int64? timelineId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Complain_Timeline_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Complain_Timeline");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@TimelineId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)timelineId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOClientComplainTimeline retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOClientComplainTimeline();
					retObj._timelineId					 = Convert.IsDBNull(dt.Rows[0]["TimelineId"]) ? (Int64?)null : (Int64?)dt.Rows[0]["TimelineId"];
					retObj._complainId					 = Convert.IsDBNull(dt.Rows[0]["ComplainId"]) ? (Int64?)null : (Int64?)dt.Rows[0]["ComplainId"];
					retObj._complainStatusId					 = Convert.IsDBNull(dt.Rows[0]["ComplainStatusId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["ComplainStatusId"];
					retObj._userId					 = Convert.IsDBNull(dt.Rows[0]["UserId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["UserId"];
					retObj._timelineDate					 = Convert.IsDBNull(dt.Rows[0]["TimelineDate"]) ? (DateTime?)null : (DateTime?)dt.Rows[0]["TimelineDate"];
					retObj._notes					 = Convert.IsDBNull(dt.Rows[0]["Notes"]) ? null : (string)dt.Rows[0]["Notes"];
				}
				return retObj;
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
		///Delete one row by primary key(s)
		///this method allows the object to delete itself from the table Client_Complain_Timeline based on its primary key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Complain_Timeline_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@TimelineId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)_timelineId?? (object)DBNull.Value));

				command.ExecuteNonQuery();

			}
			catch
			{
				throw;
			}
			finally
			{
				command.Dispose();
			}
		}

		///<Summary>
		///Select all rows by foreign key
		///This method returns all data rows in the table Client_Complain_Timeline based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOClientComplainTimeline.
		///</returns>
		///<parameters>
		///Int64? complainId
		///</parameters>
		public static IList<DAOClientComplainTimeline> SelectAllByComplainId(Int64? complainId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Complain_Timeline_SelectAllByComplainId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Complain_Timeline");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ComplainId", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)complainId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientComplainTimeline> objList = new List<DAOClientComplainTimeline>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientComplainTimeline retObj = new DAOClientComplainTimeline();
						retObj._timelineId					 = Convert.IsDBNull(row["TimelineId"]) ? (Int64?)null : (Int64?)row["TimelineId"];
						retObj._complainId					 = Convert.IsDBNull(row["ComplainId"]) ? (Int64?)null : (Int64?)row["ComplainId"];
						retObj._complainStatusId					 = Convert.IsDBNull(row["ComplainStatusId"]) ? (Int32?)null : (Int32?)row["ComplainStatusId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._timelineDate					 = Convert.IsDBNull(row["TimelineDate"]) ? (DateTime?)null : (DateTime?)row["TimelineDate"];
						retObj._notes					 = Convert.IsDBNull(row["Notes"]) ? null : (string)row["Notes"];
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
		///Int64? complainId
		///</parameters>
		public static Int32 SelectAllByComplainIdCount(Int64? complainId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Complain_Timeline_SelectAllByComplainIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ComplainId", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)complainId?? (object)DBNull.Value));

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
		///Delete all by foreign key
		///This method deletes all rows in the table Client_Complain_Timeline with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int64? complainId
		///</parameters>
		public static void DeleteAllByComplainId(zSofiForceConn_TxConnectionProvider connectionProvider, Int64? complainId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Complain_Timeline_DeleteAllByComplainId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ComplainId", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)complainId?? (object)DBNull.Value));

				command.ExecuteNonQuery();

			}
			catch
			{
				throw;
			}
			finally
			{
				command.Dispose();
			}
		}

		///<Summary>
		///Select all rows by foreign key
		///This method returns all data rows in the table Client_Complain_Timeline based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOClientComplainTimeline.
		///</returns>
		///<parameters>
		///Int32? complainStatusId
		///</parameters>
		public static IList<DAOClientComplainTimeline> SelectAllByComplainStatusId(Int32? complainStatusId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Complain_Timeline_SelectAllByComplainStatusId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Complain_Timeline");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ComplainStatusId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)complainStatusId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientComplainTimeline> objList = new List<DAOClientComplainTimeline>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientComplainTimeline retObj = new DAOClientComplainTimeline();
						retObj._timelineId					 = Convert.IsDBNull(row["TimelineId"]) ? (Int64?)null : (Int64?)row["TimelineId"];
						retObj._complainId					 = Convert.IsDBNull(row["ComplainId"]) ? (Int64?)null : (Int64?)row["ComplainId"];
						retObj._complainStatusId					 = Convert.IsDBNull(row["ComplainStatusId"]) ? (Int32?)null : (Int32?)row["ComplainStatusId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._timelineDate					 = Convert.IsDBNull(row["TimelineDate"]) ? (DateTime?)null : (DateTime?)row["TimelineDate"];
						retObj._notes					 = Convert.IsDBNull(row["Notes"]) ? null : (string)row["Notes"];
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
		///Int32? complainStatusId
		///</parameters>
		public static Int32 SelectAllByComplainStatusIdCount(Int32? complainStatusId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Complain_Timeline_SelectAllByComplainStatusIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ComplainStatusId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)complainStatusId?? (object)DBNull.Value));

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
		///Delete all by foreign key
		///This method deletes all rows in the table Client_Complain_Timeline with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? complainStatusId
		///</parameters>
		public static void DeleteAllByComplainStatusId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? complainStatusId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Complain_Timeline_DeleteAllByComplainStatusId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ComplainStatusId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)complainStatusId?? (object)DBNull.Value));

				command.ExecuteNonQuery();

			}
			catch
			{
				throw;
			}
			finally
			{
				command.Dispose();
			}
		}

		///<Summary>
		///Insert a new row
		///This method saves a new object to the table Client_Complain_Timeline
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Insert()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Complain_Timeline_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@TimelineId", SqlDbType.BigInt, 8, ParameterDirection.Output, false, 19, 0, "", DataRowVersion.Proposed, _timelineId));
				command.Parameters.Add(CtSqlParameter.Get("@ComplainId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, true, 19, 0, "", DataRowVersion.Proposed, (object)_complainId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ComplainStatusId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_complainStatusId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@UserId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_userId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@TimelineDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_timelineDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Notes", SqlDbType.NVarChar, -1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_notes?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_timelineId					 = Convert.IsDBNull(command.Parameters["@TimelineId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@TimelineId"].Value;
				_complainId					 = Convert.IsDBNull(command.Parameters["@ComplainId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@ComplainId"].Value;
				_complainStatusId					 = Convert.IsDBNull(command.Parameters["@ComplainStatusId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ComplainStatusId"].Value;
				_userId					 = Convert.IsDBNull(command.Parameters["@UserId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@UserId"].Value;
				_timelineDate					 = Convert.IsDBNull(command.Parameters["@TimelineDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@TimelineDate"].Value;
				_notes					 = Convert.IsDBNull(command.Parameters["@Notes"].Value) ? null : (string)command.Parameters["@Notes"].Value;

			}
			catch
			{
				throw;
			}
			finally
			{
				command.Dispose();
			}
		}

		///<Summary>
		///Select all rows
		///This method returns all data rows in the table Client_Complain_Timeline
		///</Summary>
		///<returns>
		///IList-DAOClientComplainTimeline.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOClientComplainTimeline> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Complain_Timeline_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Complain_Timeline");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientComplainTimeline> objList = new List<DAOClientComplainTimeline>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientComplainTimeline retObj = new DAOClientComplainTimeline();
						retObj._timelineId					 = Convert.IsDBNull(row["TimelineId"]) ? (Int64?)null : (Int64?)row["TimelineId"];
						retObj._complainId					 = Convert.IsDBNull(row["ComplainId"]) ? (Int64?)null : (Int64?)row["ComplainId"];
						retObj._complainStatusId					 = Convert.IsDBNull(row["ComplainStatusId"]) ? (Int32?)null : (Int32?)row["ComplainStatusId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._timelineDate					 = Convert.IsDBNull(row["TimelineDate"]) ? (DateTime?)null : (DateTime?)row["TimelineDate"];
						retObj._notes					 = Convert.IsDBNull(row["Notes"]) ? null : (string)row["Notes"];
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
			command.CommandText = InlineProcs.ctprClient_Complain_Timeline_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiClient_Complain_Timeline
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Complain_Timeline_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Complain_Timeline");
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
		///This method returns all data rows in the table using criteriaquery api Client_Complain_Timeline
		///</Summary>
		///<returns>
		///IList-DAOClientComplainTimeline.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOClientComplainTimeline> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Complain_Timeline_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Complain_Timeline");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientComplainTimeline> objList = new List<DAOClientComplainTimeline>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientComplainTimeline retObj = new DAOClientComplainTimeline();
						retObj._timelineId					 = Convert.IsDBNull(row["TimelineId"]) ? (Int64?)null : (Int64?)row["TimelineId"];
						retObj._complainId					 = Convert.IsDBNull(row["ComplainId"]) ? (Int64?)null : (Int64?)row["ComplainId"];
						retObj._complainStatusId					 = Convert.IsDBNull(row["ComplainStatusId"]) ? (Int32?)null : (Int32?)row["ComplainStatusId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._timelineDate					 = Convert.IsDBNull(row["TimelineDate"]) ? (DateTime?)null : (DateTime?)row["TimelineDate"];
						retObj._notes					 = Convert.IsDBNull(row["Notes"]) ? null : (string)row["Notes"];
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
		///This method returns all data rows in the table using criteriaquery api Client_Complain_Timeline
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Complain_Timeline_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///Update one row by primary key(s)
		///This method allows the object to update itself in the table Client_Complain_Timeline based on its primary key(s)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Update()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Complain_Timeline_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@TimelineId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, false, 19, 0, "", DataRowVersion.Proposed, (object)_timelineId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ComplainId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, true, 19, 0, "", DataRowVersion.Proposed, (object)_complainId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ComplainStatusId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_complainStatusId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@UserId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_userId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@TimelineDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_timelineDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Notes", SqlDbType.NVarChar, -1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_notes?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_timelineId					 = Convert.IsDBNull(command.Parameters["@TimelineId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@TimelineId"].Value;
				_complainId					 = Convert.IsDBNull(command.Parameters["@ComplainId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@ComplainId"].Value;
				_complainStatusId					 = Convert.IsDBNull(command.Parameters["@ComplainStatusId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ComplainStatusId"].Value;
				_userId					 = Convert.IsDBNull(command.Parameters["@UserId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@UserId"].Value;
				_timelineDate					 = Convert.IsDBNull(command.Parameters["@TimelineDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@TimelineDate"].Value;
				_notes					 = Convert.IsDBNull(command.Parameters["@Notes"].Value) ? null : (string)command.Parameters["@Notes"].Value;

			}
			catch
			{
				throw;
			}
			finally
			{
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

		#endregion
	}
}

#region inline sql procs
namespace SofiForce.DataObjects
{
	public partial class InlineProcs
	{
		internal static string ctprClient_Complain_Timeline_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[TimelineId]
			,[ComplainId]
			,[ComplainStatusId]
			,[UserId]
			,[TimelineDate]
			,[Notes]
			FROM [dbo].[Client_Complain_Timeline]
			WHERE 
			[TimelineId] = @TimelineId
			";

		internal static string ctprClient_Complain_Timeline_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[Client_Complain_Timeline]
			WHERE 
			[TimelineId] = @TimelineId
			";

		internal static string ctprClient_Complain_Timeline_SelectAllByComplainId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[TimelineId]
			,[ComplainId]
			,[ComplainStatusId]
			,[UserId]
			,[TimelineDate]
			,[Notes]
			FROM [dbo].[Client_Complain_Timeline]
			WHERE 
			[ComplainId] = @ComplainId OR ([ComplainId] IS NULL AND @ComplainId IS NULL)
			";

		internal static string ctprClient_Complain_Timeline_SelectAllByComplainIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_Complain_Timeline]
			WHERE 
			[ComplainId] = @ComplainId OR ([ComplainId] IS NULL AND @ComplainId IS NULL)
			";

		internal static string ctprClient_Complain_Timeline_DeleteAllByComplainId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[Client_Complain_Timeline]
			WHERE 
			[ComplainId] = @ComplainId OR ([ComplainId] IS NULL AND @ComplainId IS NULL)
			";

		internal static string ctprClient_Complain_Timeline_SelectAllByComplainStatusId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[TimelineId]
			,[ComplainId]
			,[ComplainStatusId]
			,[UserId]
			,[TimelineDate]
			,[Notes]
			FROM [dbo].[Client_Complain_Timeline]
			WHERE 
			[ComplainStatusId] = @ComplainStatusId OR ([ComplainStatusId] IS NULL AND @ComplainStatusId IS NULL)
			";

		internal static string ctprClient_Complain_Timeline_SelectAllByComplainStatusIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_Complain_Timeline]
			WHERE 
			[ComplainStatusId] = @ComplainStatusId OR ([ComplainStatusId] IS NULL AND @ComplainStatusId IS NULL)
			";

		internal static string ctprClient_Complain_Timeline_DeleteAllByComplainStatusId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[Client_Complain_Timeline]
			WHERE 
			[ComplainStatusId] = @ComplainStatusId OR ([ComplainStatusId] IS NULL AND @ComplainStatusId IS NULL)
			";

		internal static string ctprClient_Complain_Timeline_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[Client_Complain_Timeline]
			(
			[ComplainId]
			,[ComplainStatusId]
			,[UserId]
			,[TimelineDate]
			,[Notes]
			)
			VALUES
			(
			@ComplainId
			,@ComplainStatusId
			,@UserId
			,@TimelineDate
			,@Notes
			)
			SELECT 
			@TimelineId = [TimelineId]
			,@ComplainId = [ComplainId]
			,@ComplainStatusId = [ComplainStatusId]
			,@UserId = [UserId]
			,@TimelineDate = [TimelineDate]
			,@Notes = [Notes]
			FROM [dbo].[Client_Complain_Timeline]
			WHERE 
			[TimelineId] = SCOPE_IDENTITY()
			";

		internal static string ctprClient_Complain_Timeline_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[TimelineId]
			,[ComplainId]
			,[ComplainStatusId]
			,[UserId]
			,[TimelineDate]
			,[Notes]
			FROM [dbo].[Client_Complain_Timeline]
			";

		internal static string ctprClient_Complain_Timeline_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_Complain_Timeline]
			";

		internal static string ctprClient_Complain_Timeline_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Client_Complain_Timeline]
			##CRITERIA##
			";

		internal static string ctprClient_Complain_Timeline_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[TimelineId]
			,[ComplainId]
			,[ComplainStatusId]
			,[UserId]
			,[TimelineDate]
			,[Notes]
			FROM [dbo].[Client_Complain_Timeline]
			##CRITERIA##
			";

		internal static string ctprClient_Complain_Timeline_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Client_Complain_Timeline]
			##CRITERIA##
			";

		internal static string ctprClient_Complain_Timeline_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[Client_Complain_Timeline]
			SET
			[ComplainId] = @ComplainId
			,[ComplainStatusId] = @ComplainStatusId
			,[UserId] = @UserId
			,[TimelineDate] = @TimelineDate
			,[Notes] = @Notes
			WHERE 
			[TimelineId] = @TimelineId
			SELECT 
			@TimelineId = [TimelineId]
			,@ComplainId = [ComplainId]
			,@ComplainStatusId = [ComplainStatusId]
			,@UserId = [UserId]
			,@TimelineDate = [TimelineDate]
			,@Notes = [Notes]
			FROM [dbo].[Client_Complain_Timeline]
			WHERE 
			[TimelineId] = @TimelineId
			";

	}
}
#endregion
