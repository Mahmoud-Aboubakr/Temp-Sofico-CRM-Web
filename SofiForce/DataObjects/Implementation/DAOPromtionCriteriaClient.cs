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
	public partial class DAOPromtionCriteriaClient : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _clientCriteriaId;
		protected Int32? _promotionId;
		protected Int32? _clientAttributeId;
		protected string _valueFrom;
		protected bool? _excluded;
		protected bool? _isActive;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		#endregion

		#region class methods
		public DAOPromtionCriteriaClient()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table PromtionCriteriaClient based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOPromtionCriteriaClient
		///</returns>
		///<parameters>
		///Int32? clientCriteriaId
		///</parameters>
		public static DAOPromtionCriteriaClient SelectOne(Int32? clientCriteriaId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprPromtionCriteriaClient_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromtionCriteriaClient");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ClientCriteriaId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)clientCriteriaId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOPromtionCriteriaClient retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOPromtionCriteriaClient();
					retObj._clientCriteriaId					 = Convert.IsDBNull(dt.Rows[0]["ClientCriteriaId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["ClientCriteriaId"];
					retObj._promotionId					 = Convert.IsDBNull(dt.Rows[0]["PromotionId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["PromotionId"];
					retObj._clientAttributeId					 = Convert.IsDBNull(dt.Rows[0]["ClientAttributeId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["ClientAttributeId"];
					retObj._valueFrom					 = Convert.IsDBNull(dt.Rows[0]["ValueFrom"]) ? null : (string)dt.Rows[0]["ValueFrom"];
					retObj._excluded					 = Convert.IsDBNull(dt.Rows[0]["Excluded"]) ? (bool?)null : (bool?)dt.Rows[0]["Excluded"];
					retObj._isActive					 = Convert.IsDBNull(dt.Rows[0]["IsActive"]) ? (bool?)null : (bool?)dt.Rows[0]["IsActive"];
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
		///this method allows the object to delete itself from the table PromtionCriteriaClient based on its primary key
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
			command.CommandText = InlineProcs.ctprPromtionCriteriaClient_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ClientCriteriaId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_clientCriteriaId?? (object)DBNull.Value));

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
		///Select one row by unique constraint
		///This method returns one row from the table PromtionCriteriaClient based on a unique constraint
		///</Summary>
		///<returns>
		///DAOPromtionCriteriaClient
		///</returns>
		///<parameters>
		///Int32? promotionId, Int32? clientAttributeId, string valueFrom
		///</parameters>
		public static DAOPromtionCriteriaClient SelectOneByUniqueFields(Int32? promotionId, Int32? clientAttributeId, string valueFrom)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprPromtionCriteriaClient_SelectOneByUniqueFields;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromtionCriteriaClient");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PromotionId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)promotionId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ClientAttributeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)clientAttributeId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ValueFrom", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)valueFrom?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOPromtionCriteriaClient retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOPromtionCriteriaClient();
					retObj._clientCriteriaId					 = Convert.IsDBNull(dt.Rows[0]["ClientCriteriaId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["ClientCriteriaId"];
					retObj._promotionId					 = Convert.IsDBNull(dt.Rows[0]["PromotionId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["PromotionId"];
					retObj._clientAttributeId					 = Convert.IsDBNull(dt.Rows[0]["ClientAttributeId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["ClientAttributeId"];
					retObj._valueFrom					 = Convert.IsDBNull(dt.Rows[0]["ValueFrom"]) ? null : (string)dt.Rows[0]["ValueFrom"];
					retObj._excluded					 = Convert.IsDBNull(dt.Rows[0]["Excluded"]) ? (bool?)null : (bool?)dt.Rows[0]["Excluded"];
					retObj._isActive					 = Convert.IsDBNull(dt.Rows[0]["IsActive"]) ? (bool?)null : (bool?)dt.Rows[0]["IsActive"];
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
		///Delete one row by unique constraint
		///This method deletes one row from the table PromtionCriteriaClient based on a unique constraint
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///Int32? promotionId, Int32? clientAttributeId, string valueFrom
		///</parameters>
		public virtual void DeleteOneByUniqueFields(Int32? promotionId, Int32? clientAttributeId, string valueFrom)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprPromtionCriteriaClient_DeleteOneByUniqueFields;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PromotionId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)_promotionId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ClientAttributeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)_clientAttributeId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ValueFrom", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)_valueFrom?? (object)DBNull.Value));

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
		///This method saves a new object to the table PromtionCriteriaClient
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
			command.CommandText = InlineProcs.ctprPromtionCriteriaClient_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ClientCriteriaId", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _clientCriteriaId));
				command.Parameters.Add(CtSqlParameter.Get("@PromotionId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_promotionId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ClientAttributeId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_clientAttributeId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ValueFrom", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_valueFrom?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Excluded", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_excluded?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_clientCriteriaId					 = Convert.IsDBNull(command.Parameters["@ClientCriteriaId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ClientCriteriaId"].Value;
				_promotionId					 = Convert.IsDBNull(command.Parameters["@PromotionId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@PromotionId"].Value;
				_clientAttributeId					 = Convert.IsDBNull(command.Parameters["@ClientAttributeId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ClientAttributeId"].Value;
				_valueFrom					 = Convert.IsDBNull(command.Parameters["@ValueFrom"].Value) ? null : (string)command.Parameters["@ValueFrom"].Value;
				_excluded					 = Convert.IsDBNull(command.Parameters["@Excluded"].Value) ? (bool?)null : (bool?)command.Parameters["@Excluded"].Value;
				_isActive					 = Convert.IsDBNull(command.Parameters["@IsActive"].Value) ? (bool?)null : (bool?)command.Parameters["@IsActive"].Value;
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
		///This method returns all data rows in the table PromtionCriteriaClient
		///</Summary>
		///<returns>
		///IList-DAOPromtionCriteriaClient.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOPromtionCriteriaClient> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprPromtionCriteriaClient_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromtionCriteriaClient");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOPromtionCriteriaClient> objList = new List<DAOPromtionCriteriaClient>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOPromtionCriteriaClient retObj = new DAOPromtionCriteriaClient();
						retObj._clientCriteriaId					 = Convert.IsDBNull(row["ClientCriteriaId"]) ? (Int32?)null : (Int32?)row["ClientCriteriaId"];
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._clientAttributeId					 = Convert.IsDBNull(row["ClientAttributeId"]) ? (Int32?)null : (Int32?)row["ClientAttributeId"];
						retObj._valueFrom					 = Convert.IsDBNull(row["ValueFrom"]) ? null : (string)row["ValueFrom"];
						retObj._excluded					 = Convert.IsDBNull(row["Excluded"]) ? (bool?)null : (bool?)row["Excluded"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
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
			command.CommandText = InlineProcs.ctprPromtionCriteriaClient_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiPromtionCriteriaClient
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromtionCriteriaClient_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromtionCriteriaClient");
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
						if (string.Compare(projection.Member, "ClientCriteriaId", true) == 0) lst.Add(Convert.IsDBNull(row["ClientCriteriaId"]) ? (Int32?)null : (Int32?)row["ClientCriteriaId"]);
						if (string.Compare(projection.Member, "PromotionId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"]);
						if (string.Compare(projection.Member, "ClientAttributeId", true) == 0) lst.Add(Convert.IsDBNull(row["ClientAttributeId"]) ? (Int32?)null : (Int32?)row["ClientAttributeId"]);
						if (string.Compare(projection.Member, "ValueFrom", true) == 0) lst.Add(Convert.IsDBNull(row["ValueFrom"]) ? null : (string)row["ValueFrom"]);
						if (string.Compare(projection.Member, "Excluded", true) == 0) lst.Add(Convert.IsDBNull(row["Excluded"]) ? (bool?)null : (bool?)row["Excluded"]);
						if (string.Compare(projection.Member, "IsActive", true) == 0) lst.Add(Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"]);
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
		///This method returns all data rows in the table using criteriaquery api PromtionCriteriaClient
		///</Summary>
		///<returns>
		///IList-DAOPromtionCriteriaClient.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOPromtionCriteriaClient> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromtionCriteriaClient_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromtionCriteriaClient");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOPromtionCriteriaClient> objList = new List<DAOPromtionCriteriaClient>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOPromtionCriteriaClient retObj = new DAOPromtionCriteriaClient();
						retObj._clientCriteriaId					 = Convert.IsDBNull(row["ClientCriteriaId"]) ? (Int32?)null : (Int32?)row["ClientCriteriaId"];
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._clientAttributeId					 = Convert.IsDBNull(row["ClientAttributeId"]) ? (Int32?)null : (Int32?)row["ClientAttributeId"];
						retObj._valueFrom					 = Convert.IsDBNull(row["ValueFrom"]) ? null : (string)row["ValueFrom"];
						retObj._excluded					 = Convert.IsDBNull(row["Excluded"]) ? (bool?)null : (bool?)row["Excluded"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
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
		///This method returns all data rows in the table using criteriaquery api PromtionCriteriaClient
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromtionCriteriaClient_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table PromtionCriteriaClient based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprPromtionCriteriaClient_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ClientCriteriaId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_clientCriteriaId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@PromotionId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_promotionId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ClientAttributeId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_clientAttributeId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ValueFrom", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_valueFrom?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Excluded", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_excluded?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_clientCriteriaId					 = Convert.IsDBNull(command.Parameters["@ClientCriteriaId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ClientCriteriaId"].Value;
				_promotionId					 = Convert.IsDBNull(command.Parameters["@PromotionId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@PromotionId"].Value;
				_clientAttributeId					 = Convert.IsDBNull(command.Parameters["@ClientAttributeId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ClientAttributeId"].Value;
				_valueFrom					 = Convert.IsDBNull(command.Parameters["@ValueFrom"].Value) ? null : (string)command.Parameters["@ValueFrom"].Value;
				_excluded					 = Convert.IsDBNull(command.Parameters["@Excluded"].Value) ? (bool?)null : (bool?)command.Parameters["@Excluded"].Value;
				_isActive					 = Convert.IsDBNull(command.Parameters["@IsActive"].Value) ? (bool?)null : (bool?)command.Parameters["@IsActive"].Value;
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

		public Int32? ClientCriteriaId
		{
			get
			{
				return _clientCriteriaId;
			}
			set
			{
				_clientCriteriaId = value;
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

		public Int32? ClientAttributeId
		{
			get
			{
				return _clientAttributeId;
			}
			set
			{
				_clientAttributeId = value;
			}
		}

		public string ValueFrom
		{
			get
			{
				return _valueFrom;
			}
			set
			{
				_valueFrom = value;
			}
		}

		public bool? Excluded
		{
			get
			{
				return _excluded;
			}
			set
			{
				_excluded = value;
			}
		}

		public bool? IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActive = value;
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
		internal static string ctprPromtionCriteriaClient_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[ClientCriteriaId]
			,[PromotionId]
			,[ClientAttributeId]
			,[ValueFrom]
			,[Excluded]
			,[IsActive]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[PromtionCriteriaClient]
			WHERE 
			[ClientCriteriaId] = @ClientCriteriaId
			";

		internal static string ctprPromtionCriteriaClient_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[PromtionCriteriaClient]
			WHERE 
			[ClientCriteriaId] = @ClientCriteriaId
			";

		internal static string ctprPromtionCriteriaClient_SelectOneByUniqueFields = @"
			-- Select one row by a unique constraint
			-- selects all rows from the table
			SELECT 
			[ClientCriteriaId]
			,[PromotionId]
			,[ClientAttributeId]
			,[ValueFrom]
			,[Excluded]
			,[IsActive]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[PromtionCriteriaClient]
			WHERE 
			[PromotionId] = @PromotionId
			AND [ClientAttributeId] = @ClientAttributeId
			AND [ValueFrom] = @ValueFrom
			";

		internal static string ctprPromtionCriteriaClient_DeleteOneByUniqueFields = @"
			
			-- delete all matching from the table
			DELETE [dbo].[PromtionCriteriaClient]
			WHERE 
			[PromotionId] = @PromotionId
			AND [ClientAttributeId] = @ClientAttributeId
			AND [ValueFrom] = @ValueFrom
			";

		internal static string ctprPromtionCriteriaClient_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[PromtionCriteriaClient]
			(
			[PromotionId]
			,[ClientAttributeId]
			,[ValueFrom]
			,[Excluded]
			,[IsActive]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			)
			VALUES
			(
			@PromotionId
			,@ClientAttributeId
			,@ValueFrom
			,@Excluded
			,@IsActive
			,@CBy
			,@CDate
			,@EBy
			,@EDate
			)
			SELECT 
			@ClientCriteriaId = [ClientCriteriaId]
			,@PromotionId = [PromotionId]
			,@ClientAttributeId = [ClientAttributeId]
			,@ValueFrom = [ValueFrom]
			,@Excluded = [Excluded]
			,@IsActive = [IsActive]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[PromtionCriteriaClient]
			WHERE 
			[ClientCriteriaId] = SCOPE_IDENTITY()
			";

		internal static string ctprPromtionCriteriaClient_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[ClientCriteriaId]
			,[PromotionId]
			,[ClientAttributeId]
			,[ValueFrom]
			,[Excluded]
			,[IsActive]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[PromtionCriteriaClient]
			";

		internal static string ctprPromtionCriteriaClient_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[PromtionCriteriaClient]
			";

		internal static string ctprPromtionCriteriaClient_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[PromtionCriteriaClient]
			##CRITERIA##
			";

		internal static string ctprPromtionCriteriaClient_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[ClientCriteriaId]
			,[PromotionId]
			,[ClientAttributeId]
			,[ValueFrom]
			,[Excluded]
			,[IsActive]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[PromtionCriteriaClient]
			##CRITERIA##
			";

		internal static string ctprPromtionCriteriaClient_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[PromtionCriteriaClient]
			##CRITERIA##
			";

		internal static string ctprPromtionCriteriaClient_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[PromtionCriteriaClient]
			SET
			[PromotionId] = @PromotionId
			,[ClientAttributeId] = @ClientAttributeId
			,[ValueFrom] = @ValueFrom
			,[Excluded] = @Excluded
			,[IsActive] = @IsActive
			,[CBy] = @CBy
			,[CDate] = @CDate
			,[EBy] = @EBy
			,[EDate] = @EDate
			WHERE 
			[ClientCriteriaId] = @ClientCriteriaId
			SELECT 
			@ClientCriteriaId = [ClientCriteriaId]
			,@PromotionId = [PromotionId]
			,@ClientAttributeId = [ClientAttributeId]
			,@ValueFrom = [ValueFrom]
			,@Excluded = [Excluded]
			,@IsActive = [IsActive]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[PromtionCriteriaClient]
			WHERE 
			[ClientCriteriaId] = @ClientCriteriaId
			";

	}
}
#endregion
