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
	public partial class DAORepresentativeQuota : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int64? _quotaId;
		protected Int32? _representativeId;
		protected Int32? _itemId;
		protected Int32? _quantity;
		protected Int32? _cBy;
		protected Int32? _eBy;
		protected DateTime? _cDate;
		protected DateTime? _eDate;
		#endregion

		#region class methods
		public DAORepresentativeQuota()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table Representative_Quota based on the primary key(s)
		///</Summary>
		///<returns>
		///DAORepresentativeQuota
		///</returns>
		///<parameters>
		///Int64? quotaId
		///</parameters>
		public static DAORepresentativeQuota SelectOne(Int64? quotaId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprRepresentative_Quota_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Representative_Quota");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@QuotaId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)quotaId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAORepresentativeQuota retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAORepresentativeQuota();
					retObj._quotaId					 = Convert.IsDBNull(dt.Rows[0]["QuotaId"]) ? (Int64?)null : (Int64?)dt.Rows[0]["QuotaId"];
					retObj._representativeId					 = Convert.IsDBNull(dt.Rows[0]["RepresentativeId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["RepresentativeId"];
					retObj._itemId					 = Convert.IsDBNull(dt.Rows[0]["ItemId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["ItemId"];
					retObj._quantity					 = Convert.IsDBNull(dt.Rows[0]["Quantity"]) ? (Int32?)null : (Int32?)dt.Rows[0]["Quantity"];
					retObj._cBy					 = Convert.IsDBNull(dt.Rows[0]["CBy"]) ? (Int32?)null : (Int32?)dt.Rows[0]["CBy"];
					retObj._eBy					 = Convert.IsDBNull(dt.Rows[0]["EBy"]) ? (Int32?)null : (Int32?)dt.Rows[0]["EBy"];
					retObj._cDate					 = Convert.IsDBNull(dt.Rows[0]["CDate"]) ? (DateTime?)null : (DateTime?)dt.Rows[0]["CDate"];
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
		///this method allows the object to delete itself from the table Representative_Quota based on its primary key
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
			command.CommandText = InlineProcs.ctprRepresentative_Quota_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@QuotaId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)_quotaId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table Representative_Quota based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAORepresentativeQuota.
		///</returns>
		///<parameters>
		///Int32? representativeId
		///</parameters>
		public static IList<DAORepresentativeQuota> SelectAllByRepresentativeId(Int32? representativeId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprRepresentative_Quota_SelectAllByRepresentativeId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Representative_Quota");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@RepresentativeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)representativeId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAORepresentativeQuota> objList = new List<DAORepresentativeQuota>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAORepresentativeQuota retObj = new DAORepresentativeQuota();
						retObj._quotaId					 = Convert.IsDBNull(row["QuotaId"]) ? (Int64?)null : (Int64?)row["QuotaId"];
						retObj._representativeId					 = Convert.IsDBNull(row["RepresentativeId"]) ? (Int32?)null : (Int32?)row["RepresentativeId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._quantity					 = Convert.IsDBNull(row["Quantity"]) ? (Int32?)null : (Int32?)row["Quantity"];
						retObj._cBy					 = Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"];
						retObj._eBy					 = Convert.IsDBNull(row["EBy"]) ? (Int32?)null : (Int32?)row["EBy"];
						retObj._cDate					 = Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"];
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
		///Int32? representativeId
		///</parameters>
		public static Int32 SelectAllByRepresentativeIdCount(Int32? representativeId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprRepresentative_Quota_SelectAllByRepresentativeIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@RepresentativeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)representativeId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table Representative_Quota with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? representativeId
		///</parameters>
		public static void DeleteAllByRepresentativeId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? representativeId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprRepresentative_Quota_DeleteAllByRepresentativeId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@RepresentativeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)representativeId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table Representative_Quota based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAORepresentativeQuota.
		///</returns>
		///<parameters>
		///Int32? itemId
		///</parameters>
		public static IList<DAORepresentativeQuota> SelectAllByItemId(Int32? itemId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprRepresentative_Quota_SelectAllByItemId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Representative_Quota");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ItemId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)itemId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAORepresentativeQuota> objList = new List<DAORepresentativeQuota>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAORepresentativeQuota retObj = new DAORepresentativeQuota();
						retObj._quotaId					 = Convert.IsDBNull(row["QuotaId"]) ? (Int64?)null : (Int64?)row["QuotaId"];
						retObj._representativeId					 = Convert.IsDBNull(row["RepresentativeId"]) ? (Int32?)null : (Int32?)row["RepresentativeId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._quantity					 = Convert.IsDBNull(row["Quantity"]) ? (Int32?)null : (Int32?)row["Quantity"];
						retObj._cBy					 = Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"];
						retObj._eBy					 = Convert.IsDBNull(row["EBy"]) ? (Int32?)null : (Int32?)row["EBy"];
						retObj._cDate					 = Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"];
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
		///Int32? itemId
		///</parameters>
		public static Int32 SelectAllByItemIdCount(Int32? itemId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprRepresentative_Quota_SelectAllByItemIdCount;
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
		///This method deletes all rows in the table Representative_Quota with a given foreign key
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
			command.CommandText = InlineProcs.ctprRepresentative_Quota_DeleteAllByItemId;
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
		///Insert a new row
		///This method saves a new object to the table Representative_Quota
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
			command.CommandText = InlineProcs.ctprRepresentative_Quota_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@QuotaId", SqlDbType.BigInt, 8, ParameterDirection.Output, false, 19, 0, "", DataRowVersion.Proposed, _quotaId));
				command.Parameters.Add(CtSqlParameter.Get("@RepresentativeId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_representativeId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ItemId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_itemId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Quantity", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_quantity?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_quotaId					 = Convert.IsDBNull(command.Parameters["@QuotaId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@QuotaId"].Value;
				_representativeId					 = Convert.IsDBNull(command.Parameters["@RepresentativeId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@RepresentativeId"].Value;
				_itemId					 = Convert.IsDBNull(command.Parameters["@ItemId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ItemId"].Value;
				_quantity					 = Convert.IsDBNull(command.Parameters["@Quantity"].Value) ? (Int32?)null : (Int32?)command.Parameters["@Quantity"].Value;
				_cBy					 = Convert.IsDBNull(command.Parameters["@CBy"].Value) ? (Int32?)null : (Int32?)command.Parameters["@CBy"].Value;
				_eBy					 = Convert.IsDBNull(command.Parameters["@EBy"].Value) ? (Int32?)null : (Int32?)command.Parameters["@EBy"].Value;
				_cDate					 = Convert.IsDBNull(command.Parameters["@CDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@CDate"].Value;
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
		///This method returns all data rows in the table Representative_Quota
		///</Summary>
		///<returns>
		///IList-DAORepresentativeQuota.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAORepresentativeQuota> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprRepresentative_Quota_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Representative_Quota");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAORepresentativeQuota> objList = new List<DAORepresentativeQuota>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAORepresentativeQuota retObj = new DAORepresentativeQuota();
						retObj._quotaId					 = Convert.IsDBNull(row["QuotaId"]) ? (Int64?)null : (Int64?)row["QuotaId"];
						retObj._representativeId					 = Convert.IsDBNull(row["RepresentativeId"]) ? (Int32?)null : (Int32?)row["RepresentativeId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._quantity					 = Convert.IsDBNull(row["Quantity"]) ? (Int32?)null : (Int32?)row["Quantity"];
						retObj._cBy					 = Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"];
						retObj._eBy					 = Convert.IsDBNull(row["EBy"]) ? (Int32?)null : (Int32?)row["EBy"];
						retObj._cDate					 = Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"];
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
			command.CommandText = InlineProcs.ctprRepresentative_Quota_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiRepresentative_Quota
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprRepresentative_Quota_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Representative_Quota");
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
						if (string.Compare(projection.Member, "QuotaId", true) == 0) lst.Add(Convert.IsDBNull(row["QuotaId"]) ? (Int64?)null : (Int64?)row["QuotaId"]);
						if (string.Compare(projection.Member, "RepresentativeId", true) == 0) lst.Add(Convert.IsDBNull(row["RepresentativeId"]) ? (Int32?)null : (Int32?)row["RepresentativeId"]);
						if (string.Compare(projection.Member, "ItemId", true) == 0) lst.Add(Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"]);
						if (string.Compare(projection.Member, "Quantity", true) == 0) lst.Add(Convert.IsDBNull(row["Quantity"]) ? (Int32?)null : (Int32?)row["Quantity"]);
						if (string.Compare(projection.Member, "CBy", true) == 0) lst.Add(Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"]);
						if (string.Compare(projection.Member, "EBy", true) == 0) lst.Add(Convert.IsDBNull(row["EBy"]) ? (Int32?)null : (Int32?)row["EBy"]);
						if (string.Compare(projection.Member, "CDate", true) == 0) lst.Add(Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"]);
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
		///This method returns all data rows in the table using criteriaquery api Representative_Quota
		///</Summary>
		///<returns>
		///IList-DAORepresentativeQuota.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAORepresentativeQuota> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprRepresentative_Quota_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Representative_Quota");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAORepresentativeQuota> objList = new List<DAORepresentativeQuota>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAORepresentativeQuota retObj = new DAORepresentativeQuota();
						retObj._quotaId					 = Convert.IsDBNull(row["QuotaId"]) ? (Int64?)null : (Int64?)row["QuotaId"];
						retObj._representativeId					 = Convert.IsDBNull(row["RepresentativeId"]) ? (Int32?)null : (Int32?)row["RepresentativeId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._quantity					 = Convert.IsDBNull(row["Quantity"]) ? (Int32?)null : (Int32?)row["Quantity"];
						retObj._cBy					 = Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"];
						retObj._eBy					 = Convert.IsDBNull(row["EBy"]) ? (Int32?)null : (Int32?)row["EBy"];
						retObj._cDate					 = Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"];
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
		///This method returns all data rows in the table using criteriaquery api Representative_Quota
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprRepresentative_Quota_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table Representative_Quota based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprRepresentative_Quota_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@QuotaId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, false, 19, 0, "", DataRowVersion.Proposed, (object)_quotaId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@RepresentativeId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_representativeId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ItemId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_itemId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Quantity", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_quantity?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_quotaId					 = Convert.IsDBNull(command.Parameters["@QuotaId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@QuotaId"].Value;
				_representativeId					 = Convert.IsDBNull(command.Parameters["@RepresentativeId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@RepresentativeId"].Value;
				_itemId					 = Convert.IsDBNull(command.Parameters["@ItemId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ItemId"].Value;
				_quantity					 = Convert.IsDBNull(command.Parameters["@Quantity"].Value) ? (Int32?)null : (Int32?)command.Parameters["@Quantity"].Value;
				_cBy					 = Convert.IsDBNull(command.Parameters["@CBy"].Value) ? (Int32?)null : (Int32?)command.Parameters["@CBy"].Value;
				_eBy					 = Convert.IsDBNull(command.Parameters["@EBy"].Value) ? (Int32?)null : (Int32?)command.Parameters["@EBy"].Value;
				_cDate					 = Convert.IsDBNull(command.Parameters["@CDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@CDate"].Value;
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

		public Int64? QuotaId
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

		public Int32? RepresentativeId
		{
			get
			{
				return _representativeId;
			}
			set
			{
				_representativeId = value;
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
		internal static string ctprRepresentative_Quota_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[QuotaId]
			,[RepresentativeId]
			,[ItemId]
			,[Quantity]
			,[CBy]
			,[EBy]
			,[CDate]
			,[EDate]
			FROM [dbo].[Representative_Quota]
			WHERE 
			[QuotaId] = @QuotaId
			";

		internal static string ctprRepresentative_Quota_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[Representative_Quota]
			WHERE 
			[QuotaId] = @QuotaId
			";

		internal static string ctprRepresentative_Quota_SelectAllByRepresentativeId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[QuotaId]
			,[RepresentativeId]
			,[ItemId]
			,[Quantity]
			,[CBy]
			,[EBy]
			,[CDate]
			,[EDate]
			FROM [dbo].[Representative_Quota]
			WHERE 
			[RepresentativeId] = @RepresentativeId OR ([RepresentativeId] IS NULL AND @RepresentativeId IS NULL)
			";

		internal static string ctprRepresentative_Quota_SelectAllByRepresentativeIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Representative_Quota]
			WHERE 
			[RepresentativeId] = @RepresentativeId OR ([RepresentativeId] IS NULL AND @RepresentativeId IS NULL)
			";

		internal static string ctprRepresentative_Quota_DeleteAllByRepresentativeId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[Representative_Quota]
			WHERE 
			[RepresentativeId] = @RepresentativeId OR ([RepresentativeId] IS NULL AND @RepresentativeId IS NULL)
			";

		internal static string ctprRepresentative_Quota_SelectAllByItemId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[QuotaId]
			,[RepresentativeId]
			,[ItemId]
			,[Quantity]
			,[CBy]
			,[EBy]
			,[CDate]
			,[EDate]
			FROM [dbo].[Representative_Quota]
			WHERE 
			[ItemId] = @ItemId OR ([ItemId] IS NULL AND @ItemId IS NULL)
			";

		internal static string ctprRepresentative_Quota_SelectAllByItemIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Representative_Quota]
			WHERE 
			[ItemId] = @ItemId OR ([ItemId] IS NULL AND @ItemId IS NULL)
			";

		internal static string ctprRepresentative_Quota_DeleteAllByItemId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[Representative_Quota]
			WHERE 
			[ItemId] = @ItemId OR ([ItemId] IS NULL AND @ItemId IS NULL)
			";

		internal static string ctprRepresentative_Quota_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[Representative_Quota]
			(
			[RepresentativeId]
			,[ItemId]
			,[Quantity]
			,[CBy]
			,[EBy]
			,[CDate]
			,[EDate]
			)
			VALUES
			(
			@RepresentativeId
			,@ItemId
			,@Quantity
			,@CBy
			,@EBy
			,@CDate
			,@EDate
			)
			SELECT 
			@QuotaId = [QuotaId]
			,@RepresentativeId = [RepresentativeId]
			,@ItemId = [ItemId]
			,@Quantity = [Quantity]
			,@CBy = [CBy]
			,@EBy = [EBy]
			,@CDate = [CDate]
			,@EDate = [EDate]
			FROM [dbo].[Representative_Quota]
			WHERE 
			[QuotaId] = SCOPE_IDENTITY()
			";

		internal static string ctprRepresentative_Quota_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[QuotaId]
			,[RepresentativeId]
			,[ItemId]
			,[Quantity]
			,[CBy]
			,[EBy]
			,[CDate]
			,[EDate]
			FROM [dbo].[Representative_Quota]
			";

		internal static string ctprRepresentative_Quota_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Representative_Quota]
			";

		internal static string ctprRepresentative_Quota_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Representative_Quota]
			##CRITERIA##
			";

		internal static string ctprRepresentative_Quota_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[QuotaId]
			,[RepresentativeId]
			,[ItemId]
			,[Quantity]
			,[CBy]
			,[EBy]
			,[CDate]
			,[EDate]
			FROM [dbo].[Representative_Quota]
			##CRITERIA##
			";

		internal static string ctprRepresentative_Quota_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Representative_Quota]
			##CRITERIA##
			";

		internal static string ctprRepresentative_Quota_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[Representative_Quota]
			SET
			[RepresentativeId] = @RepresentativeId
			,[ItemId] = @ItemId
			,[Quantity] = @Quantity
			,[CBy] = @CBy
			,[EBy] = @EBy
			,[CDate] = @CDate
			,[EDate] = @EDate
			WHERE 
			[QuotaId] = @QuotaId
			SELECT 
			@QuotaId = [QuotaId]
			,@RepresentativeId = [RepresentativeId]
			,@ItemId = [ItemId]
			,@Quantity = [Quantity]
			,@CBy = [CBy]
			,@EBy = [EBy]
			,@CDate = [CDate]
			,@EDate = [EDate]
			FROM [dbo].[Representative_Quota]
			WHERE 
			[QuotaId] = @QuotaId
			";

	}
}
#endregion
