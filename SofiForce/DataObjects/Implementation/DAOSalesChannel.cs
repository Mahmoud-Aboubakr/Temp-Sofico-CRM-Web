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
	public partial class DAOSalesChannel : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _salesChannelId;
		protected string _salesChannelCode;
		protected string _salesChannelNameEn;
		protected string _salesChannelNameAr;
		protected Int32? _displayOrder;
		protected string _color;
		protected string _icon;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		#endregion

		#region class methods
		public DAOSalesChannel()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table SalesChannel based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOSalesChannel
		///</returns>
		///<parameters>
		///Int32? salesChannelId
		///</parameters>
		public static DAOSalesChannel SelectOne(Int32? salesChannelId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesChannel_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesChannel");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SalesChannelId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)salesChannelId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOSalesChannel retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOSalesChannel();
					retObj._salesChannelId					 = Convert.IsDBNull(dt.Rows[0]["SalesChannelId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["SalesChannelId"];
					retObj._salesChannelCode					 = Convert.IsDBNull(dt.Rows[0]["SalesChannelCode"]) ? null : (string)dt.Rows[0]["SalesChannelCode"];
					retObj._salesChannelNameEn					 = Convert.IsDBNull(dt.Rows[0]["SalesChannelNameEn"]) ? null : (string)dt.Rows[0]["SalesChannelNameEn"];
					retObj._salesChannelNameAr					 = Convert.IsDBNull(dt.Rows[0]["SalesChannelNameAr"]) ? null : (string)dt.Rows[0]["SalesChannelNameAr"];
					retObj._displayOrder					 = Convert.IsDBNull(dt.Rows[0]["DisplayOrder"]) ? (Int32?)null : (Int32?)dt.Rows[0]["DisplayOrder"];
					retObj._color					 = Convert.IsDBNull(dt.Rows[0]["Color"]) ? null : (string)dt.Rows[0]["Color"];
					retObj._icon					 = Convert.IsDBNull(dt.Rows[0]["Icon"]) ? null : (string)dt.Rows[0]["Icon"];
					retObj._canEdit					 = Convert.IsDBNull(dt.Rows[0]["CanEdit"]) ? (bool?)null : (bool?)dt.Rows[0]["CanEdit"];
					retObj._canDelete					 = Convert.IsDBNull(dt.Rows[0]["CanDelete"]) ? (bool?)null : (bool?)dt.Rows[0]["CanDelete"];
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
		///this method allows the object to delete itself from the table SalesChannel based on its primary key
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
			command.CommandText = InlineProcs.ctprSalesChannel_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SalesChannelId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_salesChannelId?? (object)DBNull.Value));

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
		///This method saves a new object to the table SalesChannel
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
			command.CommandText = InlineProcs.ctprSalesChannel_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SalesChannelId", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _salesChannelId));
				command.Parameters.Add(CtSqlParameter.Get("@SalesChannelCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_salesChannelCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SalesChannelNameEn", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_salesChannelNameEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SalesChannelNameAr", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_salesChannelNameAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DisplayOrder", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_displayOrder?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Color", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_color?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_icon?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanEdit", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canEdit?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanDelete", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canDelete?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_salesChannelId					 = Convert.IsDBNull(command.Parameters["@SalesChannelId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@SalesChannelId"].Value;
				_salesChannelCode					 = Convert.IsDBNull(command.Parameters["@SalesChannelCode"].Value) ? null : (string)command.Parameters["@SalesChannelCode"].Value;
				_salesChannelNameEn					 = Convert.IsDBNull(command.Parameters["@SalesChannelNameEn"].Value) ? null : (string)command.Parameters["@SalesChannelNameEn"].Value;
				_salesChannelNameAr					 = Convert.IsDBNull(command.Parameters["@SalesChannelNameAr"].Value) ? null : (string)command.Parameters["@SalesChannelNameAr"].Value;
				_displayOrder					 = Convert.IsDBNull(command.Parameters["@DisplayOrder"].Value) ? (Int32?)null : (Int32?)command.Parameters["@DisplayOrder"].Value;
				_color					 = Convert.IsDBNull(command.Parameters["@Color"].Value) ? null : (string)command.Parameters["@Color"].Value;
				_icon					 = Convert.IsDBNull(command.Parameters["@Icon"].Value) ? null : (string)command.Parameters["@Icon"].Value;
				_canEdit					 = Convert.IsDBNull(command.Parameters["@CanEdit"].Value) ? (bool?)null : (bool?)command.Parameters["@CanEdit"].Value;
				_canDelete					 = Convert.IsDBNull(command.Parameters["@CanDelete"].Value) ? (bool?)null : (bool?)command.Parameters["@CanDelete"].Value;
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
		///This method returns all data rows in the table SalesChannel
		///</Summary>
		///<returns>
		///IList-DAOSalesChannel.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOSalesChannel> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesChannel_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesChannel");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSalesChannel> objList = new List<DAOSalesChannel>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSalesChannel retObj = new DAOSalesChannel();
						retObj._salesChannelId					 = Convert.IsDBNull(row["SalesChannelId"]) ? (Int32?)null : (Int32?)row["SalesChannelId"];
						retObj._salesChannelCode					 = Convert.IsDBNull(row["SalesChannelCode"]) ? null : (string)row["SalesChannelCode"];
						retObj._salesChannelNameEn					 = Convert.IsDBNull(row["SalesChannelNameEn"]) ? null : (string)row["SalesChannelNameEn"];
						retObj._salesChannelNameAr					 = Convert.IsDBNull(row["SalesChannelNameAr"]) ? null : (string)row["SalesChannelNameAr"];
						retObj._displayOrder					 = Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
						retObj._canEdit					 = Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"];
						retObj._canDelete					 = Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"];
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
			command.CommandText = InlineProcs.ctprSalesChannel_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiSalesChannel
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesChannel_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesChannel");
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
						if (string.Compare(projection.Member, "SalesChannelId", true) == 0) lst.Add(Convert.IsDBNull(row["SalesChannelId"]) ? (Int32?)null : (Int32?)row["SalesChannelId"]);
						if (string.Compare(projection.Member, "SalesChannelCode", true) == 0) lst.Add(Convert.IsDBNull(row["SalesChannelCode"]) ? null : (string)row["SalesChannelCode"]);
						if (string.Compare(projection.Member, "SalesChannelNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["SalesChannelNameEn"]) ? null : (string)row["SalesChannelNameEn"]);
						if (string.Compare(projection.Member, "SalesChannelNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["SalesChannelNameAr"]) ? null : (string)row["SalesChannelNameAr"]);
						if (string.Compare(projection.Member, "DisplayOrder", true) == 0) lst.Add(Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"]);
						if (string.Compare(projection.Member, "Color", true) == 0) lst.Add(Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"]);
						if (string.Compare(projection.Member, "Icon", true) == 0) lst.Add(Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"]);
						if (string.Compare(projection.Member, "CanEdit", true) == 0) lst.Add(Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"]);
						if (string.Compare(projection.Member, "CanDelete", true) == 0) lst.Add(Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"]);
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
		///This method returns all data rows in the table using criteriaquery api SalesChannel
		///</Summary>
		///<returns>
		///IList-DAOSalesChannel.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOSalesChannel> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesChannel_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesChannel");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSalesChannel> objList = new List<DAOSalesChannel>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSalesChannel retObj = new DAOSalesChannel();
						retObj._salesChannelId					 = Convert.IsDBNull(row["SalesChannelId"]) ? (Int32?)null : (Int32?)row["SalesChannelId"];
						retObj._salesChannelCode					 = Convert.IsDBNull(row["SalesChannelCode"]) ? null : (string)row["SalesChannelCode"];
						retObj._salesChannelNameEn					 = Convert.IsDBNull(row["SalesChannelNameEn"]) ? null : (string)row["SalesChannelNameEn"];
						retObj._salesChannelNameAr					 = Convert.IsDBNull(row["SalesChannelNameAr"]) ? null : (string)row["SalesChannelNameAr"];
						retObj._displayOrder					 = Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
						retObj._canEdit					 = Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"];
						retObj._canDelete					 = Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"];
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
		///This method returns all data rows in the table using criteriaquery api SalesChannel
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesChannel_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table SalesChannel based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprSalesChannel_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SalesChannelId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_salesChannelId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SalesChannelCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_salesChannelCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SalesChannelNameEn", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_salesChannelNameEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SalesChannelNameAr", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_salesChannelNameAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DisplayOrder", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_displayOrder?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Color", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_color?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_icon?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanEdit", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canEdit?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanDelete", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canDelete?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_salesChannelId					 = Convert.IsDBNull(command.Parameters["@SalesChannelId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@SalesChannelId"].Value;
				_salesChannelCode					 = Convert.IsDBNull(command.Parameters["@SalesChannelCode"].Value) ? null : (string)command.Parameters["@SalesChannelCode"].Value;
				_salesChannelNameEn					 = Convert.IsDBNull(command.Parameters["@SalesChannelNameEn"].Value) ? null : (string)command.Parameters["@SalesChannelNameEn"].Value;
				_salesChannelNameAr					 = Convert.IsDBNull(command.Parameters["@SalesChannelNameAr"].Value) ? null : (string)command.Parameters["@SalesChannelNameAr"].Value;
				_displayOrder					 = Convert.IsDBNull(command.Parameters["@DisplayOrder"].Value) ? (Int32?)null : (Int32?)command.Parameters["@DisplayOrder"].Value;
				_color					 = Convert.IsDBNull(command.Parameters["@Color"].Value) ? null : (string)command.Parameters["@Color"].Value;
				_icon					 = Convert.IsDBNull(command.Parameters["@Icon"].Value) ? null : (string)command.Parameters["@Icon"].Value;
				_canEdit					 = Convert.IsDBNull(command.Parameters["@CanEdit"].Value) ? (bool?)null : (bool?)command.Parameters["@CanEdit"].Value;
				_canDelete					 = Convert.IsDBNull(command.Parameters["@CanDelete"].Value) ? (bool?)null : (bool?)command.Parameters["@CanDelete"].Value;
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

		public Int32? SalesChannelId
		{
			get
			{
				return _salesChannelId;
			}
			set
			{
				_salesChannelId = value;
			}
		}

		public string SalesChannelCode
		{
			get
			{
				return _salesChannelCode;
			}
			set
			{
				_salesChannelCode = value;
			}
		}

		public string SalesChannelNameEn
		{
			get
			{
				return _salesChannelNameEn;
			}
			set
			{
				_salesChannelNameEn = value;
			}
		}

		public string SalesChannelNameAr
		{
			get
			{
				return _salesChannelNameAr;
			}
			set
			{
				_salesChannelNameAr = value;
			}
		}

		public Int32? DisplayOrder
		{
			get
			{
				return _displayOrder;
			}
			set
			{
				_displayOrder = value;
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

		public string Icon
		{
			get
			{
				return _icon;
			}
			set
			{
				_icon = value;
			}
		}

		public bool? CanEdit
		{
			get
			{
				return _canEdit;
			}
			set
			{
				_canEdit = value;
			}
		}

		public bool? CanDelete
		{
			get
			{
				return _canDelete;
			}
			set
			{
				_canDelete = value;
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
		internal static string ctprSalesChannel_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[SalesChannelId]
			,[SalesChannelCode]
			,[SalesChannelNameEn]
			,[SalesChannelNameAr]
			,[DisplayOrder]
			,[Color]
			,[Icon]
			,[CanEdit]
			,[CanDelete]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[SalesChannel]
			WHERE 
			[SalesChannelId] = @SalesChannelId
			";

		internal static string ctprSalesChannel_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[SalesChannel]
			WHERE 
			[SalesChannelId] = @SalesChannelId
			";

		internal static string ctprSalesChannel_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[SalesChannel]
			(
			[SalesChannelCode]
			,[SalesChannelNameEn]
			,[SalesChannelNameAr]
			,[DisplayOrder]
			,[Color]
			,[Icon]
			,[CanEdit]
			,[CanDelete]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			)
			VALUES
			(
			@SalesChannelCode
			,@SalesChannelNameEn
			,@SalesChannelNameAr
			,@DisplayOrder
			,@Color
			,@Icon
			,@CanEdit
			,@CanDelete
			,@CBy
			,@CDate
			,@EBy
			,@EDate
			)
			SELECT 
			@SalesChannelId = [SalesChannelId]
			,@SalesChannelCode = [SalesChannelCode]
			,@SalesChannelNameEn = [SalesChannelNameEn]
			,@SalesChannelNameAr = [SalesChannelNameAr]
			,@DisplayOrder = [DisplayOrder]
			,@Color = [Color]
			,@Icon = [Icon]
			,@CanEdit = [CanEdit]
			,@CanDelete = [CanDelete]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[SalesChannel]
			WHERE 
			[SalesChannelId] = SCOPE_IDENTITY()
			";

		internal static string ctprSalesChannel_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[SalesChannelId]
			,[SalesChannelCode]
			,[SalesChannelNameEn]
			,[SalesChannelNameAr]
			,[DisplayOrder]
			,[Color]
			,[Icon]
			,[CanEdit]
			,[CanDelete]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[SalesChannel]
			";

		internal static string ctprSalesChannel_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[SalesChannel]
			";

		internal static string ctprSalesChannel_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[SalesChannel]
			##CRITERIA##
			";

		internal static string ctprSalesChannel_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[SalesChannelId]
			,[SalesChannelCode]
			,[SalesChannelNameEn]
			,[SalesChannelNameAr]
			,[DisplayOrder]
			,[Color]
			,[Icon]
			,[CanEdit]
			,[CanDelete]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[SalesChannel]
			##CRITERIA##
			";

		internal static string ctprSalesChannel_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[SalesChannel]
			##CRITERIA##
			";

		internal static string ctprSalesChannel_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[SalesChannel]
			SET
			[SalesChannelCode] = @SalesChannelCode
			,[SalesChannelNameEn] = @SalesChannelNameEn
			,[SalesChannelNameAr] = @SalesChannelNameAr
			,[DisplayOrder] = @DisplayOrder
			,[Color] = @Color
			,[Icon] = @Icon
			,[CanEdit] = @CanEdit
			,[CanDelete] = @CanDelete
			,[CBy] = @CBy
			,[CDate] = @CDate
			,[EBy] = @EBy
			,[EDate] = @EDate
			WHERE 
			[SalesChannelId] = @SalesChannelId
			SELECT 
			@SalesChannelId = [SalesChannelId]
			,@SalesChannelCode = [SalesChannelCode]
			,@SalesChannelNameEn = [SalesChannelNameEn]
			,@SalesChannelNameAr = [SalesChannelNameAr]
			,@DisplayOrder = [DisplayOrder]
			,@Color = [Color]
			,@Icon = [Icon]
			,@CanEdit = [CanEdit]
			,@CanDelete = [CanDelete]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[SalesChannel]
			WHERE 
			[SalesChannelId] = @SalesChannelId
			";

	}
}
#endregion