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
	public partial class DAOClientTransaction : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int64? _transactionId;
		protected Int32? _clientId;
		protected Int32? _transactionTypeId;
		protected string _transactionCode;
		protected DateTime? _transactionDate;
		protected decimal? _transactionValue;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		#endregion

		#region class methods
		public DAOClientTransaction()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table Client_Transaction based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOClientTransaction
		///</returns>
		///<parameters>
		///Int64? transactionId
		///</parameters>
		public static DAOClientTransaction SelectOne(Int64? transactionId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Transaction_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Transaction");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@TransactionId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)transactionId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOClientTransaction retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOClientTransaction();
					retObj._transactionId					 = Convert.IsDBNull(dt.Rows[0]["TransactionId"]) ? (Int64?)null : (Int64?)dt.Rows[0]["TransactionId"];
					retObj._clientId					 = Convert.IsDBNull(dt.Rows[0]["ClientId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["ClientId"];
					retObj._transactionTypeId					 = Convert.IsDBNull(dt.Rows[0]["TransactionTypeId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["TransactionTypeId"];
					retObj._transactionCode					 = Convert.IsDBNull(dt.Rows[0]["TransactionCode"]) ? null : (string)dt.Rows[0]["TransactionCode"];
					retObj._transactionDate					 = Convert.IsDBNull(dt.Rows[0]["TransactionDate"]) ? (DateTime?)null : (DateTime?)dt.Rows[0]["TransactionDate"];
					retObj._transactionValue					 = Convert.IsDBNull(dt.Rows[0]["TransactionValue"]) ? (decimal?)null : (decimal?)dt.Rows[0]["TransactionValue"];
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
		///this method allows the object to delete itself from the table Client_Transaction based on its primary key
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
			command.CommandText = InlineProcs.ctprClient_Transaction_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@TransactionId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)_transactionId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table Client_Transaction based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOClientTransaction.
		///</returns>
		///<parameters>
		///Int32? clientId
		///</parameters>
		public static IList<DAOClientTransaction> SelectAllByClientId(Int32? clientId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Transaction_SelectAllByClientId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Transaction");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ClientId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)clientId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientTransaction> objList = new List<DAOClientTransaction>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientTransaction retObj = new DAOClientTransaction();
						retObj._transactionId					 = Convert.IsDBNull(row["TransactionId"]) ? (Int64?)null : (Int64?)row["TransactionId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._transactionTypeId					 = Convert.IsDBNull(row["TransactionTypeId"]) ? (Int32?)null : (Int32?)row["TransactionTypeId"];
						retObj._transactionCode					 = Convert.IsDBNull(row["TransactionCode"]) ? null : (string)row["TransactionCode"];
						retObj._transactionDate					 = Convert.IsDBNull(row["TransactionDate"]) ? (DateTime?)null : (DateTime?)row["TransactionDate"];
						retObj._transactionValue					 = Convert.IsDBNull(row["TransactionValue"]) ? (decimal?)null : (decimal?)row["TransactionValue"];
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
			command.CommandText = InlineProcs.ctprClient_Transaction_SelectAllByClientIdCount;
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
		///This method deletes all rows in the table Client_Transaction with a given foreign key
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
			command.CommandText = InlineProcs.ctprClient_Transaction_DeleteAllByClientId;
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
		///Select all rows by foreign key
		///This method returns all data rows in the table Client_Transaction based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOClientTransaction.
		///</returns>
		///<parameters>
		///Int32? transactionTypeId
		///</parameters>
		public static IList<DAOClientTransaction> SelectAllByTransactionTypeId(Int32? transactionTypeId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Transaction_SelectAllByTransactionTypeId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Transaction");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@TransactionTypeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)transactionTypeId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientTransaction> objList = new List<DAOClientTransaction>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientTransaction retObj = new DAOClientTransaction();
						retObj._transactionId					 = Convert.IsDBNull(row["TransactionId"]) ? (Int64?)null : (Int64?)row["TransactionId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._transactionTypeId					 = Convert.IsDBNull(row["TransactionTypeId"]) ? (Int32?)null : (Int32?)row["TransactionTypeId"];
						retObj._transactionCode					 = Convert.IsDBNull(row["TransactionCode"]) ? null : (string)row["TransactionCode"];
						retObj._transactionDate					 = Convert.IsDBNull(row["TransactionDate"]) ? (DateTime?)null : (DateTime?)row["TransactionDate"];
						retObj._transactionValue					 = Convert.IsDBNull(row["TransactionValue"]) ? (decimal?)null : (decimal?)row["TransactionValue"];
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
		///Int32? transactionTypeId
		///</parameters>
		public static Int32 SelectAllByTransactionTypeIdCount(Int32? transactionTypeId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Transaction_SelectAllByTransactionTypeIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@TransactionTypeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)transactionTypeId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table Client_Transaction with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? transactionTypeId
		///</parameters>
		public static void DeleteAllByTransactionTypeId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? transactionTypeId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Transaction_DeleteAllByTransactionTypeId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@TransactionTypeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)transactionTypeId?? (object)DBNull.Value));

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
		///This method saves a new object to the table Client_Transaction
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
			command.CommandText = InlineProcs.ctprClient_Transaction_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@TransactionId", SqlDbType.BigInt, 8, ParameterDirection.Output, false, 19, 0, "", DataRowVersion.Proposed, _transactionId));
				command.Parameters.Add(CtSqlParameter.Get("@ClientId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_clientId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@TransactionTypeId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_transactionTypeId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@TransactionCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_transactionCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@TransactionDate", SqlDbType.Date, 3, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_transactionDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@TransactionValue", SqlDbType.Decimal, 9, ParameterDirection.InputOutput, true, 18, 3, "", DataRowVersion.Proposed, (object)_transactionValue?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_transactionId					 = Convert.IsDBNull(command.Parameters["@TransactionId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@TransactionId"].Value;
				_clientId					 = Convert.IsDBNull(command.Parameters["@ClientId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ClientId"].Value;
				_transactionTypeId					 = Convert.IsDBNull(command.Parameters["@TransactionTypeId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@TransactionTypeId"].Value;
				_transactionCode					 = Convert.IsDBNull(command.Parameters["@TransactionCode"].Value) ? null : (string)command.Parameters["@TransactionCode"].Value;
				_transactionDate					 = Convert.IsDBNull(command.Parameters["@TransactionDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@TransactionDate"].Value;
				_transactionValue					 = Convert.IsDBNull(command.Parameters["@TransactionValue"].Value) ? (decimal?)null : (decimal?)command.Parameters["@TransactionValue"].Value;
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
		///This method returns all data rows in the table Client_Transaction
		///</Summary>
		///<returns>
		///IList-DAOClientTransaction.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOClientTransaction> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Transaction_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Transaction");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientTransaction> objList = new List<DAOClientTransaction>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientTransaction retObj = new DAOClientTransaction();
						retObj._transactionId					 = Convert.IsDBNull(row["TransactionId"]) ? (Int64?)null : (Int64?)row["TransactionId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._transactionTypeId					 = Convert.IsDBNull(row["TransactionTypeId"]) ? (Int32?)null : (Int32?)row["TransactionTypeId"];
						retObj._transactionCode					 = Convert.IsDBNull(row["TransactionCode"]) ? null : (string)row["TransactionCode"];
						retObj._transactionDate					 = Convert.IsDBNull(row["TransactionDate"]) ? (DateTime?)null : (DateTime?)row["TransactionDate"];
						retObj._transactionValue					 = Convert.IsDBNull(row["TransactionValue"]) ? (decimal?)null : (decimal?)row["TransactionValue"];
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
			command.CommandText = InlineProcs.ctprClient_Transaction_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiClient_Transaction
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Transaction_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Transaction");
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
						if (string.Compare(projection.Member, "TransactionId", true) == 0) lst.Add(Convert.IsDBNull(row["TransactionId"]) ? (Int64?)null : (Int64?)row["TransactionId"]);
						if (string.Compare(projection.Member, "ClientId", true) == 0) lst.Add(Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"]);
						if (string.Compare(projection.Member, "TransactionTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["TransactionTypeId"]) ? (Int32?)null : (Int32?)row["TransactionTypeId"]);
						if (string.Compare(projection.Member, "TransactionCode", true) == 0) lst.Add(Convert.IsDBNull(row["TransactionCode"]) ? null : (string)row["TransactionCode"]);
						if (string.Compare(projection.Member, "TransactionDate", true) == 0) lst.Add(Convert.IsDBNull(row["TransactionDate"]) ? (DateTime?)null : (DateTime?)row["TransactionDate"]);
						if (string.Compare(projection.Member, "TransactionValue", true) == 0) lst.Add(Convert.IsDBNull(row["TransactionValue"]) ? (decimal?)null : (decimal?)row["TransactionValue"]);
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
		///This method returns all data rows in the table using criteriaquery api Client_Transaction
		///</Summary>
		///<returns>
		///IList-DAOClientTransaction.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOClientTransaction> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Transaction_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Transaction");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientTransaction> objList = new List<DAOClientTransaction>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientTransaction retObj = new DAOClientTransaction();
						retObj._transactionId					 = Convert.IsDBNull(row["TransactionId"]) ? (Int64?)null : (Int64?)row["TransactionId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._transactionTypeId					 = Convert.IsDBNull(row["TransactionTypeId"]) ? (Int32?)null : (Int32?)row["TransactionTypeId"];
						retObj._transactionCode					 = Convert.IsDBNull(row["TransactionCode"]) ? null : (string)row["TransactionCode"];
						retObj._transactionDate					 = Convert.IsDBNull(row["TransactionDate"]) ? (DateTime?)null : (DateTime?)row["TransactionDate"];
						retObj._transactionValue					 = Convert.IsDBNull(row["TransactionValue"]) ? (decimal?)null : (decimal?)row["TransactionValue"];
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
		///This method returns all data rows in the table using criteriaquery api Client_Transaction
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Transaction_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table Client_Transaction based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprClient_Transaction_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@TransactionId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, false, 19, 0, "", DataRowVersion.Proposed, (object)_transactionId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ClientId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_clientId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@TransactionTypeId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_transactionTypeId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@TransactionCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_transactionCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@TransactionDate", SqlDbType.Date, 3, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_transactionDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@TransactionValue", SqlDbType.Decimal, 9, ParameterDirection.InputOutput, true, 18, 3, "", DataRowVersion.Proposed, (object)_transactionValue?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_transactionId					 = Convert.IsDBNull(command.Parameters["@TransactionId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@TransactionId"].Value;
				_clientId					 = Convert.IsDBNull(command.Parameters["@ClientId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ClientId"].Value;
				_transactionTypeId					 = Convert.IsDBNull(command.Parameters["@TransactionTypeId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@TransactionTypeId"].Value;
				_transactionCode					 = Convert.IsDBNull(command.Parameters["@TransactionCode"].Value) ? null : (string)command.Parameters["@TransactionCode"].Value;
				_transactionDate					 = Convert.IsDBNull(command.Parameters["@TransactionDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@TransactionDate"].Value;
				_transactionValue					 = Convert.IsDBNull(command.Parameters["@TransactionValue"].Value) ? (decimal?)null : (decimal?)command.Parameters["@TransactionValue"].Value;
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

		public Int64? TransactionId
		{
			get
			{
				return _transactionId;
			}
			set
			{
				_transactionId = value;
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

		public Int32? TransactionTypeId
		{
			get
			{
				return _transactionTypeId;
			}
			set
			{
				_transactionTypeId = value;
			}
		}

		public string TransactionCode
		{
			get
			{
				return _transactionCode;
			}
			set
			{
				_transactionCode = value;
			}
		}

		public DateTime? TransactionDate
		{
			get
			{
				return _transactionDate;
			}
			set
			{
				_transactionDate = value;
			}
		}

		public decimal? TransactionValue
		{
			get
			{
				return _transactionValue;
			}
			set
			{
				_transactionValue = value;
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
		internal static string ctprClient_Transaction_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[TransactionId]
			,[ClientId]
			,[TransactionTypeId]
			,[TransactionCode]
			,[TransactionDate]
			,[TransactionValue]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Client_Transaction]
			WHERE 
			[TransactionId] = @TransactionId
			";

		internal static string ctprClient_Transaction_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[Client_Transaction]
			WHERE 
			[TransactionId] = @TransactionId
			";

		internal static string ctprClient_Transaction_SelectAllByClientId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[TransactionId]
			,[ClientId]
			,[TransactionTypeId]
			,[TransactionCode]
			,[TransactionDate]
			,[TransactionValue]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Client_Transaction]
			WHERE 
			[ClientId] = @ClientId OR ([ClientId] IS NULL AND @ClientId IS NULL)
			";

		internal static string ctprClient_Transaction_SelectAllByClientIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_Transaction]
			WHERE 
			[ClientId] = @ClientId OR ([ClientId] IS NULL AND @ClientId IS NULL)
			";

		internal static string ctprClient_Transaction_DeleteAllByClientId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[Client_Transaction]
			WHERE 
			[ClientId] = @ClientId OR ([ClientId] IS NULL AND @ClientId IS NULL)
			";

		internal static string ctprClient_Transaction_SelectAllByTransactionTypeId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[TransactionId]
			,[ClientId]
			,[TransactionTypeId]
			,[TransactionCode]
			,[TransactionDate]
			,[TransactionValue]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Client_Transaction]
			WHERE 
			[TransactionTypeId] = @TransactionTypeId OR ([TransactionTypeId] IS NULL AND @TransactionTypeId IS NULL)
			";

		internal static string ctprClient_Transaction_SelectAllByTransactionTypeIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_Transaction]
			WHERE 
			[TransactionTypeId] = @TransactionTypeId OR ([TransactionTypeId] IS NULL AND @TransactionTypeId IS NULL)
			";

		internal static string ctprClient_Transaction_DeleteAllByTransactionTypeId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[Client_Transaction]
			WHERE 
			[TransactionTypeId] = @TransactionTypeId OR ([TransactionTypeId] IS NULL AND @TransactionTypeId IS NULL)
			";

		internal static string ctprClient_Transaction_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[Client_Transaction]
			(
			[ClientId]
			,[TransactionTypeId]
			,[TransactionCode]
			,[TransactionDate]
			,[TransactionValue]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			)
			VALUES
			(
			@ClientId
			,@TransactionTypeId
			,@TransactionCode
			,@TransactionDate
			,@TransactionValue
			,@CBy
			,@CDate
			,@EBy
			,@EDate
			)
			SELECT 
			@TransactionId = [TransactionId]
			,@ClientId = [ClientId]
			,@TransactionTypeId = [TransactionTypeId]
			,@TransactionCode = [TransactionCode]
			,@TransactionDate = [TransactionDate]
			,@TransactionValue = [TransactionValue]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[Client_Transaction]
			WHERE 
			[TransactionId] = SCOPE_IDENTITY()
			";

		internal static string ctprClient_Transaction_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[TransactionId]
			,[ClientId]
			,[TransactionTypeId]
			,[TransactionCode]
			,[TransactionDate]
			,[TransactionValue]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Client_Transaction]
			";

		internal static string ctprClient_Transaction_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_Transaction]
			";

		internal static string ctprClient_Transaction_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Client_Transaction]
			##CRITERIA##
			";

		internal static string ctprClient_Transaction_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[TransactionId]
			,[ClientId]
			,[TransactionTypeId]
			,[TransactionCode]
			,[TransactionDate]
			,[TransactionValue]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Client_Transaction]
			##CRITERIA##
			";

		internal static string ctprClient_Transaction_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Client_Transaction]
			##CRITERIA##
			";

		internal static string ctprClient_Transaction_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[Client_Transaction]
			SET
			[ClientId] = @ClientId
			,[TransactionTypeId] = @TransactionTypeId
			,[TransactionCode] = @TransactionCode
			,[TransactionDate] = @TransactionDate
			,[TransactionValue] = @TransactionValue
			,[CBy] = @CBy
			,[CDate] = @CDate
			,[EBy] = @EBy
			,[EDate] = @EDate
			WHERE 
			[TransactionId] = @TransactionId
			SELECT 
			@TransactionId = [TransactionId]
			,@ClientId = [ClientId]
			,@TransactionTypeId = [TransactionTypeId]
			,@TransactionCode = [TransactionCode]
			,@TransactionDate = [TransactionDate]
			,@TransactionValue = [TransactionValue]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[Client_Transaction]
			WHERE 
			[TransactionId] = @TransactionId
			";

	}
}
#endregion