/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 9/9/2023 5:10:23 PM
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SofiForce.DataObjects.Interfaces;

namespace SofiForce.DataObjects
{
	public partial class DAOClientQuota : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _quotaId;
		protected Int32? _itemId;
		protected Int32? _clientId;
		protected Int32? _quantity;
		protected Int32? _remain;
		protected DateTime? _fromDate;
		protected DateTime? _toDate;
		#endregion

		#region class methods
		public DAOClientQuota()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table Client_Quota based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOClientQuota
		///</returns>
		///<parameters>
		///Int32? quotaId
		///</parameters>
		public static DAOClientQuota SelectOne(Int32? quotaId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Quota_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Quota");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@QuotaId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)quotaId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOClientQuota retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOClientQuota();
					retObj._quotaId					 = Convert.IsDBNull(dt.Rows[0]["QuotaId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["QuotaId"];
					retObj._itemId					 = Convert.IsDBNull(dt.Rows[0]["ItemId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["ItemId"];
					retObj._clientId					 = Convert.IsDBNull(dt.Rows[0]["ClientId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["ClientId"];
					retObj._quantity					 = Convert.IsDBNull(dt.Rows[0]["Quantity"]) ? (Int32?)null : (Int32?)dt.Rows[0]["Quantity"];
					retObj._remain					 = Convert.IsDBNull(dt.Rows[0]["Remain"]) ? (Int32?)null : (Int32?)dt.Rows[0]["Remain"];
					retObj._fromDate					 = Convert.IsDBNull(dt.Rows[0]["FromDate"]) ? (DateTime?)null : (DateTime?)dt.Rows[0]["FromDate"];
					retObj._toDate					 = Convert.IsDBNull(dt.Rows[0]["ToDate"]) ? (DateTime?)null : (DateTime?)dt.Rows[0]["ToDate"];
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
		///this method allows the object to delete itself from the table Client_Quota based on its primary key
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
			command.CommandText = InlineProcs.ctprClient_Quota_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@QuotaId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_quotaId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table Client_Quota based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOClientQuota.
		///</returns>
		///<parameters>
		///Int32? itemId
		///</parameters>
		public static IList<DAOClientQuota> SelectAllByItemId(Int32? itemId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Quota_SelectAllByItemId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Quota");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ItemId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)itemId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientQuota> objList = new List<DAOClientQuota>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientQuota retObj = new DAOClientQuota();
						retObj._quotaId					 = Convert.IsDBNull(row["QuotaId"]) ? (Int32?)null : (Int32?)row["QuotaId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._quantity					 = Convert.IsDBNull(row["Quantity"]) ? (Int32?)null : (Int32?)row["Quantity"];
						retObj._remain					 = Convert.IsDBNull(row["Remain"]) ? (Int32?)null : (Int32?)row["Remain"];
						retObj._fromDate					 = Convert.IsDBNull(row["FromDate"]) ? (DateTime?)null : (DateTime?)row["FromDate"];
						retObj._toDate					 = Convert.IsDBNull(row["ToDate"]) ? (DateTime?)null : (DateTime?)row["ToDate"];
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
		///Int32? itemId
		///</parameters>
		public static Int32 SelectAllByItemIdCount(Int32? itemId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Quota_SelectAllByItemIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ItemId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)itemId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table Client_Quota with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? itemId
		///</parameters>
		public static void DeleteAllByItemId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? itemId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Quota_DeleteAllByItemId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ItemId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)itemId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table Client_Quota based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOClientQuota.
		///</returns>
		///<parameters>
		///Int32? clientId
		///</parameters>
		public static IList<DAOClientQuota> SelectAllByClientId(Int32? clientId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Quota_SelectAllByClientId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Quota");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ClientId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)clientId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientQuota> objList = new List<DAOClientQuota>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientQuota retObj = new DAOClientQuota();
						retObj._quotaId					 = Convert.IsDBNull(row["QuotaId"]) ? (Int32?)null : (Int32?)row["QuotaId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._quantity					 = Convert.IsDBNull(row["Quantity"]) ? (Int32?)null : (Int32?)row["Quantity"];
						retObj._remain					 = Convert.IsDBNull(row["Remain"]) ? (Int32?)null : (Int32?)row["Remain"];
						retObj._fromDate					 = Convert.IsDBNull(row["FromDate"]) ? (DateTime?)null : (DateTime?)row["FromDate"];
						retObj._toDate					 = Convert.IsDBNull(row["ToDate"]) ? (DateTime?)null : (DateTime?)row["ToDate"];
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
			command.CommandText = InlineProcs.ctprClient_Quota_SelectAllByClientIdCount;
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
		///This method deletes all rows in the table Client_Quota with a given foreign key
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
			command.CommandText = InlineProcs.ctprClient_Quota_DeleteAllByClientId;
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
		///This method saves a new object to the table Client_Quota
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
			command.CommandText = InlineProcs.ctprClient_Quota_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@QuotaId", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _quotaId));
				command.Parameters.Add(CtSqlParameter.Get("@ItemId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_itemId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ClientId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_clientId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Quantity", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_quantity?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Remain", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_remain?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@FromDate", SqlDbType.Date, 3, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_fromDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ToDate", SqlDbType.Date, 3, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_toDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_quotaId					 = Convert.IsDBNull(command.Parameters["@QuotaId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@QuotaId"].Value;
				_itemId					 = Convert.IsDBNull(command.Parameters["@ItemId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ItemId"].Value;
				_clientId					 = Convert.IsDBNull(command.Parameters["@ClientId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ClientId"].Value;
				_quantity					 = Convert.IsDBNull(command.Parameters["@Quantity"].Value) ? (Int32?)null : (Int32?)command.Parameters["@Quantity"].Value;
				_remain					 = Convert.IsDBNull(command.Parameters["@Remain"].Value) ? (Int32?)null : (Int32?)command.Parameters["@Remain"].Value;
				_fromDate					 = Convert.IsDBNull(command.Parameters["@FromDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@FromDate"].Value;
				_toDate					 = Convert.IsDBNull(command.Parameters["@ToDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@ToDate"].Value;

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
		///This method returns all data rows in the table Client_Quota
		///</Summary>
		///<returns>
		///IList-DAOClientQuota.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOClientQuota> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Quota_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Quota");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientQuota> objList = new List<DAOClientQuota>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientQuota retObj = new DAOClientQuota();
						retObj._quotaId					 = Convert.IsDBNull(row["QuotaId"]) ? (Int32?)null : (Int32?)row["QuotaId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._quantity					 = Convert.IsDBNull(row["Quantity"]) ? (Int32?)null : (Int32?)row["Quantity"];
						retObj._remain					 = Convert.IsDBNull(row["Remain"]) ? (Int32?)null : (Int32?)row["Remain"];
						retObj._fromDate					 = Convert.IsDBNull(row["FromDate"]) ? (DateTime?)null : (DateTime?)row["FromDate"];
						retObj._toDate					 = Convert.IsDBNull(row["ToDate"]) ? (DateTime?)null : (DateTime?)row["ToDate"];
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
			command.CommandText = InlineProcs.ctprClient_Quota_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiClient_Quota
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Quota_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Quota");
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
						if (string.Compare(projection.Member, "QuotaId", true) == 0) lst.Add(Convert.IsDBNull(row["QuotaId"]) ? (Int32?)null : (Int32?)row["QuotaId"]);
						if (string.Compare(projection.Member, "ItemId", true) == 0) lst.Add(Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"]);
						if (string.Compare(projection.Member, "ClientId", true) == 0) lst.Add(Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"]);
						if (string.Compare(projection.Member, "Quantity", true) == 0) lst.Add(Convert.IsDBNull(row["Quantity"]) ? (Int32?)null : (Int32?)row["Quantity"]);
						if (string.Compare(projection.Member, "Remain", true) == 0) lst.Add(Convert.IsDBNull(row["Remain"]) ? (Int32?)null : (Int32?)row["Remain"]);
						if (string.Compare(projection.Member, "FromDate", true) == 0) lst.Add(Convert.IsDBNull(row["FromDate"]) ? (DateTime?)null : (DateTime?)row["FromDate"]);
						if (string.Compare(projection.Member, "ToDate", true) == 0) lst.Add(Convert.IsDBNull(row["ToDate"]) ? (DateTime?)null : (DateTime?)row["ToDate"]);
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
		///This method returns all data rows in the table using criteriaquery api Client_Quota
		///</Summary>
		///<returns>
		///IList-DAOClientQuota.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOClientQuota> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Quota_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Quota");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientQuota> objList = new List<DAOClientQuota>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientQuota retObj = new DAOClientQuota();
						retObj._quotaId					 = Convert.IsDBNull(row["QuotaId"]) ? (Int32?)null : (Int32?)row["QuotaId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._quantity					 = Convert.IsDBNull(row["Quantity"]) ? (Int32?)null : (Int32?)row["Quantity"];
						retObj._remain					 = Convert.IsDBNull(row["Remain"]) ? (Int32?)null : (Int32?)row["Remain"];
						retObj._fromDate					 = Convert.IsDBNull(row["FromDate"]) ? (DateTime?)null : (DateTime?)row["FromDate"];
						retObj._toDate					 = Convert.IsDBNull(row["ToDate"]) ? (DateTime?)null : (DateTime?)row["ToDate"];
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
		///This method returns all data rows in the table using criteriaquery api Client_Quota
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Quota_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table Client_Quota based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprClient_Quota_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@QuotaId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_quotaId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ItemId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_itemId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ClientId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_clientId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Quantity", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_quantity?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Remain", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_remain?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@FromDate", SqlDbType.Date, 3, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_fromDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ToDate", SqlDbType.Date, 3, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_toDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_quotaId					 = Convert.IsDBNull(command.Parameters["@QuotaId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@QuotaId"].Value;
				_itemId					 = Convert.IsDBNull(command.Parameters["@ItemId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ItemId"].Value;
				_clientId					 = Convert.IsDBNull(command.Parameters["@ClientId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ClientId"].Value;
				_quantity					 = Convert.IsDBNull(command.Parameters["@Quantity"].Value) ? (Int32?)null : (Int32?)command.Parameters["@Quantity"].Value;
				_remain					 = Convert.IsDBNull(command.Parameters["@Remain"].Value) ? (Int32?)null : (Int32?)command.Parameters["@Remain"].Value;
				_fromDate					 = Convert.IsDBNull(command.Parameters["@FromDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@FromDate"].Value;
				_toDate					 = Convert.IsDBNull(command.Parameters["@ToDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@ToDate"].Value;

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

		public Int32? QuotaId
		{
			get
			{
				return _quotaId;
			}
			set
			{
				_quotaId = value;
			}
		}

		public Int32? ItemId
		{
			get
			{
				return _itemId;
			}
			set
			{
				_itemId = value;
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

		public Int32? Quantity
		{
			get
			{
				return _quantity;
			}
			set
			{
				_quantity = value;
			}
		}

		public Int32? Remain
		{
			get
			{
				return _remain;
			}
			set
			{
				_remain = value;
			}
		}

		public DateTime? FromDate
		{
			get
			{
				return _fromDate;
			}
			set
			{
				_fromDate = value;
			}
		}

		public DateTime? ToDate
		{
			get
			{
				return _toDate;
			}
			set
			{
				_toDate = value;
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
		internal static string ctprClient_Quota_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[QuotaId]
			,[ItemId]
			,[ClientId]
			,[Quantity]
			,[Remain]
			,[FromDate]
			,[ToDate]
			FROM [dbo].[Client_Quota]
			WHERE 
			[QuotaId] = @QuotaId
			";

		internal static string ctprClient_Quota_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[Client_Quota]
			WHERE 
			[QuotaId] = @QuotaId
			";

		internal static string ctprClient_Quota_SelectAllByItemId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[QuotaId]
			,[ItemId]
			,[ClientId]
			,[Quantity]
			,[Remain]
			,[FromDate]
			,[ToDate]
			FROM [dbo].[Client_Quota]
			WHERE 
			[ItemId] = @ItemId OR ([ItemId] IS NULL AND @ItemId IS NULL)
			";

		internal static string ctprClient_Quota_SelectAllByItemIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_Quota]
			WHERE 
			[ItemId] = @ItemId OR ([ItemId] IS NULL AND @ItemId IS NULL)
			";

		internal static string ctprClient_Quota_DeleteAllByItemId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[Client_Quota]
			WHERE 
			[ItemId] = @ItemId OR ([ItemId] IS NULL AND @ItemId IS NULL)
			";

		internal static string ctprClient_Quota_SelectAllByClientId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[QuotaId]
			,[ItemId]
			,[ClientId]
			,[Quantity]
			,[Remain]
			,[FromDate]
			,[ToDate]
			FROM [dbo].[Client_Quota]
			WHERE 
			[ClientId] = @ClientId OR ([ClientId] IS NULL AND @ClientId IS NULL)
			";

		internal static string ctprClient_Quota_SelectAllByClientIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_Quota]
			WHERE 
			[ClientId] = @ClientId OR ([ClientId] IS NULL AND @ClientId IS NULL)
			";

		internal static string ctprClient_Quota_DeleteAllByClientId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[Client_Quota]
			WHERE 
			[ClientId] = @ClientId OR ([ClientId] IS NULL AND @ClientId IS NULL)
			";

		internal static string ctprClient_Quota_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[Client_Quota]
			(
			[ItemId]
			,[ClientId]
			,[Quantity]
			,[Remain]
			,[FromDate]
			,[ToDate]
			)
			VALUES
			(
			@ItemId
			,@ClientId
			,@Quantity
			,@Remain
			,@FromDate
			,@ToDate
			)
			SELECT 
			@QuotaId = [QuotaId]
			,@ItemId = [ItemId]
			,@ClientId = [ClientId]
			,@Quantity = [Quantity]
			,@Remain = [Remain]
			,@FromDate = [FromDate]
			,@ToDate = [ToDate]
			FROM [dbo].[Client_Quota]
			WHERE 
			[QuotaId] = SCOPE_IDENTITY()
			";

		internal static string ctprClient_Quota_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[QuotaId]
			,[ItemId]
			,[ClientId]
			,[Quantity]
			,[Remain]
			,[FromDate]
			,[ToDate]
			FROM [dbo].[Client_Quota]
			";

		internal static string ctprClient_Quota_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_Quota]
			";

		internal static string ctprClient_Quota_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Client_Quota]
			##CRITERIA##
			";

		internal static string ctprClient_Quota_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[QuotaId]
			,[ItemId]
			,[ClientId]
			,[Quantity]
			,[Remain]
			,[FromDate]
			,[ToDate]
			FROM [dbo].[Client_Quota]
			##CRITERIA##
			";

		internal static string ctprClient_Quota_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Client_Quota]
			##CRITERIA##
			";

		internal static string ctprClient_Quota_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[Client_Quota]
			SET
			[ItemId] = @ItemId
			,[ClientId] = @ClientId
			,[Quantity] = @Quantity
			,[Remain] = @Remain
			,[FromDate] = @FromDate
			,[ToDate] = @ToDate
			WHERE 
			[QuotaId] = @QuotaId
			SELECT 
			@QuotaId = [QuotaId]
			,@ItemId = [ItemId]
			,@ClientId = [ClientId]
			,@Quantity = [Quantity]
			,@Remain = [Remain]
			,@FromDate = [FromDate]
			,@ToDate = [ToDate]
			FROM [dbo].[Client_Quota]
			WHERE 
			[QuotaId] = @QuotaId
			";

	}
}
#endregion
