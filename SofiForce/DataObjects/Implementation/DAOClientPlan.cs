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
	public partial class DAOClientPlan : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int64? _planId;
		protected Int32? _clientId;
		protected DateTime? _targetDate;
		protected decimal? _targetValue;
		protected Int32? _targetVisit;
		protected Int32? _targetCall;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		#endregion

		#region class methods
		public DAOClientPlan()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table Client_plan based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOClientPlan
		///</returns>
		///<parameters>
		///Int64? planId
		///</parameters>
		public static DAOClientPlan SelectOne(Int64? planId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_plan_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_plan");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PlanId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)planId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOClientPlan retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOClientPlan();
					retObj._planId					 = Convert.IsDBNull(dt.Rows[0]["PlanId"]) ? (Int64?)null : (Int64?)dt.Rows[0]["PlanId"];
					retObj._clientId					 = Convert.IsDBNull(dt.Rows[0]["ClientId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["ClientId"];
					retObj._targetDate					 = Convert.IsDBNull(dt.Rows[0]["TargetDate"]) ? (DateTime?)null : (DateTime?)dt.Rows[0]["TargetDate"];
					retObj._targetValue					 = Convert.IsDBNull(dt.Rows[0]["TargetValue"]) ? (decimal?)null : (decimal?)dt.Rows[0]["TargetValue"];
					retObj._targetVisit					 = Convert.IsDBNull(dt.Rows[0]["TargetVisit"]) ? (Int32?)null : (Int32?)dt.Rows[0]["TargetVisit"];
					retObj._targetCall					 = Convert.IsDBNull(dt.Rows[0]["TargetCall"]) ? (Int32?)null : (Int32?)dt.Rows[0]["TargetCall"];
					retObj._cBy					 = Convert.IsDBNull(dt.Rows[0]["CBy"]) ? (Int32?)null : (Int32?)dt.Rows[0]["CBy"];
					retObj._cDate					 = Convert.IsDBNull(dt.Rows[0]["CDate"]) ? (DateTime?)null : (DateTime?)dt.Rows[0]["CDate"];
					retObj._eBy					 = Convert.IsDBNull(dt.Rows[0]["EBy"]) ? (Int32?)null : (Int32?)dt.Rows[0]["EBy"];
					retObj._eDate					 = Convert.IsDBNull(dt.Rows[0]["EDate"]) ? (DateTime?)null : (DateTime?)dt.Rows[0]["EDate"];
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
		///this method allows the object to delete itself from the table Client_plan based on its primary key
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
			command.CommandText = InlineProcs.ctprClient_plan_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PlanId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)_planId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table Client_plan based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOClientPlan.
		///</returns>
		///<parameters>
		///Int32? clientId
		///</parameters>
		public static IList<DAOClientPlan> SelectAllByClientId(Int32? clientId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_plan_SelectAllByClientId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_plan");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ClientId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)clientId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientPlan> objList = new List<DAOClientPlan>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientPlan retObj = new DAOClientPlan();
						retObj._planId					 = Convert.IsDBNull(row["PlanId"]) ? (Int64?)null : (Int64?)row["PlanId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._targetDate					 = Convert.IsDBNull(row["TargetDate"]) ? (DateTime?)null : (DateTime?)row["TargetDate"];
						retObj._targetValue					 = Convert.IsDBNull(row["TargetValue"]) ? (decimal?)null : (decimal?)row["TargetValue"];
						retObj._targetVisit					 = Convert.IsDBNull(row["TargetVisit"]) ? (Int32?)null : (Int32?)row["TargetVisit"];
						retObj._targetCall					 = Convert.IsDBNull(row["TargetCall"]) ? (Int32?)null : (Int32?)row["TargetCall"];
						retObj._cBy					 = Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"];
						retObj._cDate					 = Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"];
						retObj._eBy					 = Convert.IsDBNull(row["EBy"]) ? (Int32?)null : (Int32?)row["EBy"];
						retObj._eDate					 = Convert.IsDBNull(row["EDate"]) ? (DateTime?)null : (DateTime?)row["EDate"];
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
		///Int32? clientId
		///</parameters>
		public static Int32 SelectAllByClientIdCount(Int32? clientId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_plan_SelectAllByClientIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ClientId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)clientId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table Client_plan with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? clientId
		///</parameters>
		public static void DeleteAllByClientId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? clientId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_plan_DeleteAllByClientId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ClientId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)clientId?? (object)DBNull.Value));

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
		///This method saves a new object to the table Client_plan
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
			command.CommandText = InlineProcs.ctprClient_plan_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PlanId", SqlDbType.BigInt, 8, ParameterDirection.Output, false, 19, 0, "", DataRowVersion.Proposed, _planId));
				command.Parameters.Add(CtSqlParameter.Get("@ClientId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_clientId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@TargetDate", SqlDbType.Date, 3, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_targetDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@TargetValue", SqlDbType.Decimal, 9, ParameterDirection.InputOutput, true, 18, 3, "", DataRowVersion.Proposed, (object)_targetValue?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@TargetVisit", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_targetVisit?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@TargetCall", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_targetCall?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_planId					 = Convert.IsDBNull(command.Parameters["@PlanId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@PlanId"].Value;
				_clientId					 = Convert.IsDBNull(command.Parameters["@ClientId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ClientId"].Value;
				_targetDate					 = Convert.IsDBNull(command.Parameters["@TargetDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@TargetDate"].Value;
				_targetValue					 = Convert.IsDBNull(command.Parameters["@TargetValue"].Value) ? (decimal?)null : (decimal?)command.Parameters["@TargetValue"].Value;
				_targetVisit					 = Convert.IsDBNull(command.Parameters["@TargetVisit"].Value) ? (Int32?)null : (Int32?)command.Parameters["@TargetVisit"].Value;
				_targetCall					 = Convert.IsDBNull(command.Parameters["@TargetCall"].Value) ? (Int32?)null : (Int32?)command.Parameters["@TargetCall"].Value;
				_cBy					 = Convert.IsDBNull(command.Parameters["@CBy"].Value) ? (Int32?)null : (Int32?)command.Parameters["@CBy"].Value;
				_cDate					 = Convert.IsDBNull(command.Parameters["@CDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@CDate"].Value;
				_eBy					 = Convert.IsDBNull(command.Parameters["@EBy"].Value) ? (Int32?)null : (Int32?)command.Parameters["@EBy"].Value;
				_eDate					 = Convert.IsDBNull(command.Parameters["@EDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@EDate"].Value;

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
		///This method returns all data rows in the table Client_plan
		///</Summary>
		///<returns>
		///IList-DAOClientPlan.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOClientPlan> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_plan_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_plan");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientPlan> objList = new List<DAOClientPlan>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientPlan retObj = new DAOClientPlan();
						retObj._planId					 = Convert.IsDBNull(row["PlanId"]) ? (Int64?)null : (Int64?)row["PlanId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._targetDate					 = Convert.IsDBNull(row["TargetDate"]) ? (DateTime?)null : (DateTime?)row["TargetDate"];
						retObj._targetValue					 = Convert.IsDBNull(row["TargetValue"]) ? (decimal?)null : (decimal?)row["TargetValue"];
						retObj._targetVisit					 = Convert.IsDBNull(row["TargetVisit"]) ? (Int32?)null : (Int32?)row["TargetVisit"];
						retObj._targetCall					 = Convert.IsDBNull(row["TargetCall"]) ? (Int32?)null : (Int32?)row["TargetCall"];
						retObj._cBy					 = Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"];
						retObj._cDate					 = Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"];
						retObj._eBy					 = Convert.IsDBNull(row["EBy"]) ? (Int32?)null : (Int32?)row["EBy"];
						retObj._eDate					 = Convert.IsDBNull(row["EDate"]) ? (DateTime?)null : (DateTime?)row["EDate"];
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
			command.CommandText = InlineProcs.ctprClient_plan_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiClient_plan
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_plan_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_plan");
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
						if (string.Compare(projection.Member, "PlanId", true) == 0) lst.Add(Convert.IsDBNull(row["PlanId"]) ? (Int64?)null : (Int64?)row["PlanId"]);
						if (string.Compare(projection.Member, "ClientId", true) == 0) lst.Add(Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"]);
						if (string.Compare(projection.Member, "TargetDate", true) == 0) lst.Add(Convert.IsDBNull(row["TargetDate"]) ? (DateTime?)null : (DateTime?)row["TargetDate"]);
						if (string.Compare(projection.Member, "TargetValue", true) == 0) lst.Add(Convert.IsDBNull(row["TargetValue"]) ? (decimal?)null : (decimal?)row["TargetValue"]);
						if (string.Compare(projection.Member, "TargetVisit", true) == 0) lst.Add(Convert.IsDBNull(row["TargetVisit"]) ? (Int32?)null : (Int32?)row["TargetVisit"]);
						if (string.Compare(projection.Member, "TargetCall", true) == 0) lst.Add(Convert.IsDBNull(row["TargetCall"]) ? (Int32?)null : (Int32?)row["TargetCall"]);
						if (string.Compare(projection.Member, "CBy", true) == 0) lst.Add(Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"]);
						if (string.Compare(projection.Member, "CDate", true) == 0) lst.Add(Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"]);
						if (string.Compare(projection.Member, "EBy", true) == 0) lst.Add(Convert.IsDBNull(row["EBy"]) ? (Int32?)null : (Int32?)row["EBy"]);
						if (string.Compare(projection.Member, "EDate", true) == 0) lst.Add(Convert.IsDBNull(row["EDate"]) ? (DateTime?)null : (DateTime?)row["EDate"]);
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
		///This method returns all data rows in the table using criteriaquery api Client_plan
		///</Summary>
		///<returns>
		///IList-DAOClientPlan.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOClientPlan> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_plan_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_plan");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientPlan> objList = new List<DAOClientPlan>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientPlan retObj = new DAOClientPlan();
						retObj._planId					 = Convert.IsDBNull(row["PlanId"]) ? (Int64?)null : (Int64?)row["PlanId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._targetDate					 = Convert.IsDBNull(row["TargetDate"]) ? (DateTime?)null : (DateTime?)row["TargetDate"];
						retObj._targetValue					 = Convert.IsDBNull(row["TargetValue"]) ? (decimal?)null : (decimal?)row["TargetValue"];
						retObj._targetVisit					 = Convert.IsDBNull(row["TargetVisit"]) ? (Int32?)null : (Int32?)row["TargetVisit"];
						retObj._targetCall					 = Convert.IsDBNull(row["TargetCall"]) ? (Int32?)null : (Int32?)row["TargetCall"];
						retObj._cBy					 = Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"];
						retObj._cDate					 = Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"];
						retObj._eBy					 = Convert.IsDBNull(row["EBy"]) ? (Int32?)null : (Int32?)row["EBy"];
						retObj._eDate					 = Convert.IsDBNull(row["EDate"]) ? (DateTime?)null : (DateTime?)row["EDate"];
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
		///This method returns all data rows in the table using criteriaquery api Client_plan
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_plan_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table Client_plan based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprClient_plan_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PlanId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, false, 19, 0, "", DataRowVersion.Proposed, (object)_planId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ClientId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_clientId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@TargetDate", SqlDbType.Date, 3, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_targetDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@TargetValue", SqlDbType.Decimal, 9, ParameterDirection.InputOutput, true, 18, 3, "", DataRowVersion.Proposed, (object)_targetValue?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@TargetVisit", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_targetVisit?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@TargetCall", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_targetCall?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_planId					 = Convert.IsDBNull(command.Parameters["@PlanId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@PlanId"].Value;
				_clientId					 = Convert.IsDBNull(command.Parameters["@ClientId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ClientId"].Value;
				_targetDate					 = Convert.IsDBNull(command.Parameters["@TargetDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@TargetDate"].Value;
				_targetValue					 = Convert.IsDBNull(command.Parameters["@TargetValue"].Value) ? (decimal?)null : (decimal?)command.Parameters["@TargetValue"].Value;
				_targetVisit					 = Convert.IsDBNull(command.Parameters["@TargetVisit"].Value) ? (Int32?)null : (Int32?)command.Parameters["@TargetVisit"].Value;
				_targetCall					 = Convert.IsDBNull(command.Parameters["@TargetCall"].Value) ? (Int32?)null : (Int32?)command.Parameters["@TargetCall"].Value;
				_cBy					 = Convert.IsDBNull(command.Parameters["@CBy"].Value) ? (Int32?)null : (Int32?)command.Parameters["@CBy"].Value;
				_cDate					 = Convert.IsDBNull(command.Parameters["@CDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@CDate"].Value;
				_eBy					 = Convert.IsDBNull(command.Parameters["@EBy"].Value) ? (Int32?)null : (Int32?)command.Parameters["@EBy"].Value;
				_eDate					 = Convert.IsDBNull(command.Parameters["@EDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@EDate"].Value;

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

		public Int64? PlanId
		{
			get
			{
				return _planId;
			}
			set
			{
				_planId = value;
			}
		}

		public Int32? ClientId
		{
			get
			{
				return _clientId;
			}
			set
			{
				_clientId = value;
			}
		}

		public DateTime? TargetDate
		{
			get
			{
				return _targetDate;
			}
			set
			{
				_targetDate = value;
			}
		}

		public decimal? TargetValue
		{
			get
			{
				return _targetValue;
			}
			set
			{
				_targetValue = value;
			}
		}

		public Int32? TargetVisit
		{
			get
			{
				return _targetVisit;
			}
			set
			{
				_targetVisit = value;
			}
		}

		public Int32? TargetCall
		{
			get
			{
				return _targetCall;
			}
			set
			{
				_targetCall = value;
			}
		}

		public Int32? CBy
		{
			get
			{
				return _cBy;
			}
			set
			{
				_cBy = value;
			}
		}

		public DateTime? CDate
		{
			get
			{
				return _cDate;
			}
			set
			{
				_cDate = value;
			}
		}

		public Int32? EBy
		{
			get
			{
				return _eBy;
			}
			set
			{
				_eBy = value;
			}
		}

		public DateTime? EDate
		{
			get
			{
				return _eDate;
			}
			set
			{
				_eDate = value;
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
		internal static string ctprClient_plan_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[PlanId]
			,[ClientId]
			,[TargetDate]
			,[TargetValue]
			,[TargetVisit]
			,[TargetCall]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Client_plan]
			WHERE 
			[PlanId] = @PlanId
			";

		internal static string ctprClient_plan_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[Client_plan]
			WHERE 
			[PlanId] = @PlanId
			";

		internal static string ctprClient_plan_SelectAllByClientId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[PlanId]
			,[ClientId]
			,[TargetDate]
			,[TargetValue]
			,[TargetVisit]
			,[TargetCall]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Client_plan]
			WHERE 
			[ClientId] = @ClientId OR ([ClientId] IS NULL AND @ClientId IS NULL)
			";

		internal static string ctprClient_plan_SelectAllByClientIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_plan]
			WHERE 
			[ClientId] = @ClientId OR ([ClientId] IS NULL AND @ClientId IS NULL)
			";

		internal static string ctprClient_plan_DeleteAllByClientId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[Client_plan]
			WHERE 
			[ClientId] = @ClientId OR ([ClientId] IS NULL AND @ClientId IS NULL)
			";

		internal static string ctprClient_plan_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[Client_plan]
			(
			[ClientId]
			,[TargetDate]
			,[TargetValue]
			,[TargetVisit]
			,[TargetCall]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			)
			VALUES
			(
			@ClientId
			,@TargetDate
			,@TargetValue
			,@TargetVisit
			,@TargetCall
			,@CBy
			,@CDate
			,@EBy
			,@EDate
			)
			SELECT 
			@PlanId = [PlanId]
			,@ClientId = [ClientId]
			,@TargetDate = [TargetDate]
			,@TargetValue = [TargetValue]
			,@TargetVisit = [TargetVisit]
			,@TargetCall = [TargetCall]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[Client_plan]
			WHERE 
			[PlanId] = SCOPE_IDENTITY()
			";

		internal static string ctprClient_plan_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[PlanId]
			,[ClientId]
			,[TargetDate]
			,[TargetValue]
			,[TargetVisit]
			,[TargetCall]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Client_plan]
			";

		internal static string ctprClient_plan_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_plan]
			";

		internal static string ctprClient_plan_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Client_plan]
			##CRITERIA##
			";

		internal static string ctprClient_plan_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[PlanId]
			,[ClientId]
			,[TargetDate]
			,[TargetValue]
			,[TargetVisit]
			,[TargetCall]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Client_plan]
			##CRITERIA##
			";

		internal static string ctprClient_plan_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Client_plan]
			##CRITERIA##
			";

		internal static string ctprClient_plan_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[Client_plan]
			SET
			[ClientId] = @ClientId
			,[TargetDate] = @TargetDate
			,[TargetValue] = @TargetValue
			,[TargetVisit] = @TargetVisit
			,[TargetCall] = @TargetCall
			,[CBy] = @CBy
			,[CDate] = @CDate
			,[EBy] = @EBy
			,[EDate] = @EDate
			WHERE 
			[PlanId] = @PlanId
			SELECT 
			@PlanId = [PlanId]
			,@ClientId = [ClientId]
			,@TargetDate = [TargetDate]
			,@TargetValue = [TargetValue]
			,@TargetVisit = [TargetVisit]
			,@TargetCall = [TargetCall]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[Client_plan]
			WHERE 
			[PlanId] = @PlanId
			";

	}
}
#endregion
