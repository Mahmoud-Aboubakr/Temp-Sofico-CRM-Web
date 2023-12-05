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
	public partial class DAOSalesOrderLinePromotion : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int64? _lineId;
		protected Int64? _salesId;
		protected Int32? _itemId;
		protected Int32? _promotionId;
		protected decimal? _outcome;
		protected Int32? _itemStoreId;
		protected Int32? _outcomeType;
		#endregion

		#region class methods
		public DAOSalesOrderLinePromotion()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table SalesOrder_Line_Promotion based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOSalesOrderLinePromotion
		///</returns>
		///<parameters>
		///Int64? lineId
		///</parameters>
		public static DAOSalesOrderLinePromotion SelectOne(Int64? lineId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesOrder_Line_Promotion_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_Line_Promotion");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@LineId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)lineId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOSalesOrderLinePromotion retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOSalesOrderLinePromotion();
					retObj._lineId					 = Convert.IsDBNull(dt.Rows[0]["LineId"]) ? (Int64?)null : (Int64?)dt.Rows[0]["LineId"];
					retObj._salesId					 = Convert.IsDBNull(dt.Rows[0]["SalesId"]) ? (Int64?)null : (Int64?)dt.Rows[0]["SalesId"];
					retObj._itemId					 = Convert.IsDBNull(dt.Rows[0]["ItemId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["ItemId"];
					retObj._promotionId					 = Convert.IsDBNull(dt.Rows[0]["PromotionId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["PromotionId"];
					retObj._outcome					 = Convert.IsDBNull(dt.Rows[0]["Outcome"]) ? (decimal?)null : (decimal?)dt.Rows[0]["Outcome"];
					retObj._itemStoreId					 = Convert.IsDBNull(dt.Rows[0]["ItemStoreId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["ItemStoreId"];
					retObj._outcomeType					 = Convert.IsDBNull(dt.Rows[0]["OutcomeType"]) ? (Int32?)null : (Int32?)dt.Rows[0]["OutcomeType"];
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
		///this method allows the object to delete itself from the table SalesOrder_Line_Promotion based on its primary key
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
			command.CommandText = InlineProcs.ctprSalesOrder_Line_Promotion_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@LineId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)_lineId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table SalesOrder_Line_Promotion based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOSalesOrderLinePromotion.
		///</returns>
		///<parameters>
		///Int64? salesId
		///</parameters>
		public static IList<DAOSalesOrderLinePromotion> SelectAllBySalesId(Int64? salesId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesOrder_Line_Promotion_SelectAllBySalesId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_Line_Promotion");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SalesId", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)salesId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSalesOrderLinePromotion> objList = new List<DAOSalesOrderLinePromotion>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSalesOrderLinePromotion retObj = new DAOSalesOrderLinePromotion();
						retObj._lineId					 = Convert.IsDBNull(row["LineId"]) ? (Int64?)null : (Int64?)row["LineId"];
						retObj._salesId					 = Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._outcome					 = Convert.IsDBNull(row["Outcome"]) ? (decimal?)null : (decimal?)row["Outcome"];
						retObj._itemStoreId					 = Convert.IsDBNull(row["ItemStoreId"]) ? (Int32?)null : (Int32?)row["ItemStoreId"];
						retObj._outcomeType					 = Convert.IsDBNull(row["OutcomeType"]) ? (Int32?)null : (Int32?)row["OutcomeType"];
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
		///Int64? salesId
		///</parameters>
		public static Int32 SelectAllBySalesIdCount(Int64? salesId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesOrder_Line_Promotion_SelectAllBySalesIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SalesId", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)salesId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table SalesOrder_Line_Promotion with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int64? salesId
		///</parameters>
		public static void DeleteAllBySalesId(zSofiForceConn_TxConnectionProvider connectionProvider, Int64? salesId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesOrder_Line_Promotion_DeleteAllBySalesId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SalesId", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)salesId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table SalesOrder_Line_Promotion based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOSalesOrderLinePromotion.
		///</returns>
		///<parameters>
		///Int32? itemId
		///</parameters>
		public static IList<DAOSalesOrderLinePromotion> SelectAllByItemId(Int32? itemId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesOrder_Line_Promotion_SelectAllByItemId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_Line_Promotion");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ItemId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)itemId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSalesOrderLinePromotion> objList = new List<DAOSalesOrderLinePromotion>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSalesOrderLinePromotion retObj = new DAOSalesOrderLinePromotion();
						retObj._lineId					 = Convert.IsDBNull(row["LineId"]) ? (Int64?)null : (Int64?)row["LineId"];
						retObj._salesId					 = Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._outcome					 = Convert.IsDBNull(row["Outcome"]) ? (decimal?)null : (decimal?)row["Outcome"];
						retObj._itemStoreId					 = Convert.IsDBNull(row["ItemStoreId"]) ? (Int32?)null : (Int32?)row["ItemStoreId"];
						retObj._outcomeType					 = Convert.IsDBNull(row["OutcomeType"]) ? (Int32?)null : (Int32?)row["OutcomeType"];
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
			command.CommandText = InlineProcs.ctprSalesOrder_Line_Promotion_SelectAllByItemIdCount;
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
		///This method deletes all rows in the table SalesOrder_Line_Promotion with a given foreign key
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
			command.CommandText = InlineProcs.ctprSalesOrder_Line_Promotion_DeleteAllByItemId;
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
		///This method returns all data rows in the table SalesOrder_Line_Promotion based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOSalesOrderLinePromotion.
		///</returns>
		///<parameters>
		///Int32? promotionId
		///</parameters>
		public static IList<DAOSalesOrderLinePromotion> SelectAllByPromotionId(Int32? promotionId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesOrder_Line_Promotion_SelectAllByPromotionId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_Line_Promotion");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PromotionId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)promotionId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSalesOrderLinePromotion> objList = new List<DAOSalesOrderLinePromotion>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSalesOrderLinePromotion retObj = new DAOSalesOrderLinePromotion();
						retObj._lineId					 = Convert.IsDBNull(row["LineId"]) ? (Int64?)null : (Int64?)row["LineId"];
						retObj._salesId					 = Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._outcome					 = Convert.IsDBNull(row["Outcome"]) ? (decimal?)null : (decimal?)row["Outcome"];
						retObj._itemStoreId					 = Convert.IsDBNull(row["ItemStoreId"]) ? (Int32?)null : (Int32?)row["ItemStoreId"];
						retObj._outcomeType					 = Convert.IsDBNull(row["OutcomeType"]) ? (Int32?)null : (Int32?)row["OutcomeType"];
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
		///Int32? promotionId
		///</parameters>
		public static Int32 SelectAllByPromotionIdCount(Int32? promotionId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesOrder_Line_Promotion_SelectAllByPromotionIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PromotionId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)promotionId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table SalesOrder_Line_Promotion with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? promotionId
		///</parameters>
		public static void DeleteAllByPromotionId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? promotionId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesOrder_Line_Promotion_DeleteAllByPromotionId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PromotionId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)promotionId?? (object)DBNull.Value));

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
		///This method saves a new object to the table SalesOrder_Line_Promotion
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
			command.CommandText = InlineProcs.ctprSalesOrder_Line_Promotion_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@LineId", SqlDbType.BigInt, 8, ParameterDirection.Output, false, 19, 0, "", DataRowVersion.Proposed, _lineId));
				command.Parameters.Add(CtSqlParameter.Get("@SalesId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, true, 19, 0, "", DataRowVersion.Proposed, (object)_salesId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ItemId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_itemId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@PromotionId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_promotionId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Outcome", SqlDbType.Decimal, 9, ParameterDirection.InputOutput, true, 18, 3, "", DataRowVersion.Proposed, (object)_outcome?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ItemStoreId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_itemStoreId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@OutcomeType", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_outcomeType?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_lineId					 = Convert.IsDBNull(command.Parameters["@LineId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@LineId"].Value;
				_salesId					 = Convert.IsDBNull(command.Parameters["@SalesId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@SalesId"].Value;
				_itemId					 = Convert.IsDBNull(command.Parameters["@ItemId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ItemId"].Value;
				_promotionId					 = Convert.IsDBNull(command.Parameters["@PromotionId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@PromotionId"].Value;
				_outcome					 = Convert.IsDBNull(command.Parameters["@Outcome"].Value) ? (decimal?)null : (decimal?)command.Parameters["@Outcome"].Value;
				_itemStoreId					 = Convert.IsDBNull(command.Parameters["@ItemStoreId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ItemStoreId"].Value;
				_outcomeType					 = Convert.IsDBNull(command.Parameters["@OutcomeType"].Value) ? (Int32?)null : (Int32?)command.Parameters["@OutcomeType"].Value;

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
		///This method returns all data rows in the table SalesOrder_Line_Promotion
		///</Summary>
		///<returns>
		///IList-DAOSalesOrderLinePromotion.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOSalesOrderLinePromotion> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesOrder_Line_Promotion_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_Line_Promotion");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSalesOrderLinePromotion> objList = new List<DAOSalesOrderLinePromotion>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSalesOrderLinePromotion retObj = new DAOSalesOrderLinePromotion();
						retObj._lineId					 = Convert.IsDBNull(row["LineId"]) ? (Int64?)null : (Int64?)row["LineId"];
						retObj._salesId					 = Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._outcome					 = Convert.IsDBNull(row["Outcome"]) ? (decimal?)null : (decimal?)row["Outcome"];
						retObj._itemStoreId					 = Convert.IsDBNull(row["ItemStoreId"]) ? (Int32?)null : (Int32?)row["ItemStoreId"];
						retObj._outcomeType					 = Convert.IsDBNull(row["OutcomeType"]) ? (Int32?)null : (Int32?)row["OutcomeType"];
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
			command.CommandText = InlineProcs.ctprSalesOrder_Line_Promotion_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiSalesOrder_Line_Promotion
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesOrder_Line_Promotion_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_Line_Promotion");
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
						if (string.Compare(projection.Member, "LineId", true) == 0) lst.Add(Convert.IsDBNull(row["LineId"]) ? (Int64?)null : (Int64?)row["LineId"]);
						if (string.Compare(projection.Member, "SalesId", true) == 0) lst.Add(Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"]);
						if (string.Compare(projection.Member, "ItemId", true) == 0) lst.Add(Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"]);
						if (string.Compare(projection.Member, "PromotionId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"]);
						if (string.Compare(projection.Member, "Outcome", true) == 0) lst.Add(Convert.IsDBNull(row["Outcome"]) ? (decimal?)null : (decimal?)row["Outcome"]);
						if (string.Compare(projection.Member, "ItemStoreId", true) == 0) lst.Add(Convert.IsDBNull(row["ItemStoreId"]) ? (Int32?)null : (Int32?)row["ItemStoreId"]);
						if (string.Compare(projection.Member, "OutcomeType", true) == 0) lst.Add(Convert.IsDBNull(row["OutcomeType"]) ? (Int32?)null : (Int32?)row["OutcomeType"]);
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
		///This method returns all data rows in the table using criteriaquery api SalesOrder_Line_Promotion
		///</Summary>
		///<returns>
		///IList-DAOSalesOrderLinePromotion.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOSalesOrderLinePromotion> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesOrder_Line_Promotion_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_Line_Promotion");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSalesOrderLinePromotion> objList = new List<DAOSalesOrderLinePromotion>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSalesOrderLinePromotion retObj = new DAOSalesOrderLinePromotion();
						retObj._lineId					 = Convert.IsDBNull(row["LineId"]) ? (Int64?)null : (Int64?)row["LineId"];
						retObj._salesId					 = Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._outcome					 = Convert.IsDBNull(row["Outcome"]) ? (decimal?)null : (decimal?)row["Outcome"];
						retObj._itemStoreId					 = Convert.IsDBNull(row["ItemStoreId"]) ? (Int32?)null : (Int32?)row["ItemStoreId"];
						retObj._outcomeType					 = Convert.IsDBNull(row["OutcomeType"]) ? (Int32?)null : (Int32?)row["OutcomeType"];
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
		///This method returns all data rows in the table using criteriaquery api SalesOrder_Line_Promotion
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesOrder_Line_Promotion_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table SalesOrder_Line_Promotion based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprSalesOrder_Line_Promotion_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@LineId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, false, 19, 0, "", DataRowVersion.Proposed, (object)_lineId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SalesId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, true, 19, 0, "", DataRowVersion.Proposed, (object)_salesId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ItemId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_itemId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@PromotionId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_promotionId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Outcome", SqlDbType.Decimal, 9, ParameterDirection.InputOutput, true, 18, 3, "", DataRowVersion.Proposed, (object)_outcome?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ItemStoreId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_itemStoreId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@OutcomeType", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_outcomeType?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_lineId					 = Convert.IsDBNull(command.Parameters["@LineId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@LineId"].Value;
				_salesId					 = Convert.IsDBNull(command.Parameters["@SalesId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@SalesId"].Value;
				_itemId					 = Convert.IsDBNull(command.Parameters["@ItemId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ItemId"].Value;
				_promotionId					 = Convert.IsDBNull(command.Parameters["@PromotionId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@PromotionId"].Value;
				_outcome					 = Convert.IsDBNull(command.Parameters["@Outcome"].Value) ? (decimal?)null : (decimal?)command.Parameters["@Outcome"].Value;
				_itemStoreId					 = Convert.IsDBNull(command.Parameters["@ItemStoreId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ItemStoreId"].Value;
				_outcomeType					 = Convert.IsDBNull(command.Parameters["@OutcomeType"].Value) ? (Int32?)null : (Int32?)command.Parameters["@OutcomeType"].Value;

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

		public Int64? LineId
		{
			get
			{
				return _lineId;
			}
			set
			{
				_lineId = value;
			}
		}

		public Int64? SalesId
		{
			get
			{
				return _salesId;
			}
			set
			{
				_salesId = value;
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

		public Int32? PromotionId
		{
			get
			{
				return _promotionId;
			}
			set
			{
				_promotionId = value;
			}
		}

		public decimal? Outcome
		{
			get
			{
				return _outcome;
			}
			set
			{
				_outcome = value;
			}
		}

		public Int32? ItemStoreId
		{
			get
			{
				return _itemStoreId;
			}
			set
			{
				_itemStoreId = value;
			}
		}

		public Int32? OutcomeType
		{
			get
			{
				return _outcomeType;
			}
			set
			{
				_outcomeType = value;
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
		internal static string ctprSalesOrder_Line_Promotion_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[LineId]
			,[SalesId]
			,[ItemId]
			,[PromotionId]
			,[Outcome]
			,[ItemStoreId]
			,[OutcomeType]
			FROM [dbo].[SalesOrder_Line_Promotion]
			WHERE 
			[LineId] = @LineId
			";

		internal static string ctprSalesOrder_Line_Promotion_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[SalesOrder_Line_Promotion]
			WHERE 
			[LineId] = @LineId
			";

		internal static string ctprSalesOrder_Line_Promotion_SelectAllBySalesId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[LineId]
			,[SalesId]
			,[ItemId]
			,[PromotionId]
			,[Outcome]
			,[ItemStoreId]
			,[OutcomeType]
			FROM [dbo].[SalesOrder_Line_Promotion]
			WHERE 
			[SalesId] = @SalesId OR ([SalesId] IS NULL AND @SalesId IS NULL)
			";

		internal static string ctprSalesOrder_Line_Promotion_SelectAllBySalesIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[SalesOrder_Line_Promotion]
			WHERE 
			[SalesId] = @SalesId OR ([SalesId] IS NULL AND @SalesId IS NULL)
			";

		internal static string ctprSalesOrder_Line_Promotion_DeleteAllBySalesId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[SalesOrder_Line_Promotion]
			WHERE 
			[SalesId] = @SalesId OR ([SalesId] IS NULL AND @SalesId IS NULL)
			";

		internal static string ctprSalesOrder_Line_Promotion_SelectAllByItemId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[LineId]
			,[SalesId]
			,[ItemId]
			,[PromotionId]
			,[Outcome]
			,[ItemStoreId]
			,[OutcomeType]
			FROM [dbo].[SalesOrder_Line_Promotion]
			WHERE 
			[ItemId] = @ItemId OR ([ItemId] IS NULL AND @ItemId IS NULL)
			";

		internal static string ctprSalesOrder_Line_Promotion_SelectAllByItemIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[SalesOrder_Line_Promotion]
			WHERE 
			[ItemId] = @ItemId OR ([ItemId] IS NULL AND @ItemId IS NULL)
			";

		internal static string ctprSalesOrder_Line_Promotion_DeleteAllByItemId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[SalesOrder_Line_Promotion]
			WHERE 
			[ItemId] = @ItemId OR ([ItemId] IS NULL AND @ItemId IS NULL)
			";

		internal static string ctprSalesOrder_Line_Promotion_SelectAllByPromotionId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[LineId]
			,[SalesId]
			,[ItemId]
			,[PromotionId]
			,[Outcome]
			,[ItemStoreId]
			,[OutcomeType]
			FROM [dbo].[SalesOrder_Line_Promotion]
			WHERE 
			[PromotionId] = @PromotionId OR ([PromotionId] IS NULL AND @PromotionId IS NULL)
			";

		internal static string ctprSalesOrder_Line_Promotion_SelectAllByPromotionIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[SalesOrder_Line_Promotion]
			WHERE 
			[PromotionId] = @PromotionId OR ([PromotionId] IS NULL AND @PromotionId IS NULL)
			";

		internal static string ctprSalesOrder_Line_Promotion_DeleteAllByPromotionId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[SalesOrder_Line_Promotion]
			WHERE 
			[PromotionId] = @PromotionId OR ([PromotionId] IS NULL AND @PromotionId IS NULL)
			";

		internal static string ctprSalesOrder_Line_Promotion_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[SalesOrder_Line_Promotion]
			(
			[SalesId]
			,[ItemId]
			,[PromotionId]
			,[Outcome]
			,[ItemStoreId]
			,[OutcomeType]
			)
			VALUES
			(
			@SalesId
			,@ItemId
			,@PromotionId
			,@Outcome
			,@ItemStoreId
			,@OutcomeType
			)
			SELECT 
			@LineId = [LineId]
			,@SalesId = [SalesId]
			,@ItemId = [ItemId]
			,@PromotionId = [PromotionId]
			,@Outcome = [Outcome]
			,@ItemStoreId = [ItemStoreId]
			,@OutcomeType = [OutcomeType]
			FROM [dbo].[SalesOrder_Line_Promotion]
			WHERE 
			[LineId] = SCOPE_IDENTITY()
			";

		internal static string ctprSalesOrder_Line_Promotion_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[LineId]
			,[SalesId]
			,[ItemId]
			,[PromotionId]
			,[Outcome]
			,[ItemStoreId]
			,[OutcomeType]
			FROM [dbo].[SalesOrder_Line_Promotion]
			";

		internal static string ctprSalesOrder_Line_Promotion_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[SalesOrder_Line_Promotion]
			";

		internal static string ctprSalesOrder_Line_Promotion_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[SalesOrder_Line_Promotion]
			##CRITERIA##
			";

		internal static string ctprSalesOrder_Line_Promotion_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[LineId]
			,[SalesId]
			,[ItemId]
			,[PromotionId]
			,[Outcome]
			,[ItemStoreId]
			,[OutcomeType]
			FROM [dbo].[SalesOrder_Line_Promotion]
			##CRITERIA##
			";

		internal static string ctprSalesOrder_Line_Promotion_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[SalesOrder_Line_Promotion]
			##CRITERIA##
			";

		internal static string ctprSalesOrder_Line_Promotion_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[SalesOrder_Line_Promotion]
			SET
			[SalesId] = @SalesId
			,[ItemId] = @ItemId
			,[PromotionId] = @PromotionId
			,[Outcome] = @Outcome
			,[ItemStoreId] = @ItemStoreId
			,[OutcomeType] = @OutcomeType
			WHERE 
			[LineId] = @LineId
			SELECT 
			@LineId = [LineId]
			,@SalesId = [SalesId]
			,@ItemId = [ItemId]
			,@PromotionId = [PromotionId]
			,@Outcome = [Outcome]
			,@ItemStoreId = [ItemStoreId]
			,@OutcomeType = [OutcomeType]
			FROM [dbo].[SalesOrder_Line_Promotion]
			WHERE 
			[LineId] = @LineId
			";

	}
}
#endregion
