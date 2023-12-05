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
	public partial class DAOSalesError : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _salesErrorId;
		protected string _salesErrorCode;
		protected string _salesErrorNameEn;
		protected string _salesErrorNameAr;
		protected string _salesErrorTemplateAr;
		protected string _salesErrorTemplateEn;
		protected string _icon;
		protected string _color;
		protected Int32? _displayOrder;
		protected bool? _isActive;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected Int64? _rowId;
		#endregion

		#region class methods
		public DAOSalesError()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table SalesError based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOSalesError
		///</returns>
		///<parameters>
		///Int32? salesErrorId
		///</parameters>
		public static DAOSalesError SelectOne(Int32? salesErrorId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesError_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesError");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SalesErrorId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)salesErrorId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOSalesError retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOSalesError();
					retObj._salesErrorId					 = Convert.IsDBNull(dt.Rows[0]["SalesErrorId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["SalesErrorId"];
					retObj._salesErrorCode					 = Convert.IsDBNull(dt.Rows[0]["SalesErrorCode"]) ? null : (string)dt.Rows[0]["SalesErrorCode"];
					retObj._salesErrorNameEn					 = Convert.IsDBNull(dt.Rows[0]["SalesErrorNameEn"]) ? null : (string)dt.Rows[0]["SalesErrorNameEn"];
					retObj._salesErrorNameAr					 = Convert.IsDBNull(dt.Rows[0]["SalesErrorNameAr"]) ? null : (string)dt.Rows[0]["SalesErrorNameAr"];
					retObj._salesErrorTemplateAr					 = Convert.IsDBNull(dt.Rows[0]["SalesErrorTemplateAr"]) ? null : (string)dt.Rows[0]["SalesErrorTemplateAr"];
					retObj._salesErrorTemplateEn					 = Convert.IsDBNull(dt.Rows[0]["SalesErrorTemplateEn"]) ? null : (string)dt.Rows[0]["SalesErrorTemplateEn"];
					retObj._icon					 = Convert.IsDBNull(dt.Rows[0]["Icon"]) ? null : (string)dt.Rows[0]["Icon"];
					retObj._color					 = Convert.IsDBNull(dt.Rows[0]["Color"]) ? null : (string)dt.Rows[0]["Color"];
					retObj._displayOrder					 = Convert.IsDBNull(dt.Rows[0]["DisplayOrder"]) ? (Int32?)null : (Int32?)dt.Rows[0]["DisplayOrder"];
					retObj._isActive					 = Convert.IsDBNull(dt.Rows[0]["IsActive"]) ? (bool?)null : (bool?)dt.Rows[0]["IsActive"];
					retObj._canEdit					 = Convert.IsDBNull(dt.Rows[0]["CanEdit"]) ? (bool?)null : (bool?)dt.Rows[0]["CanEdit"];
					retObj._canDelete					 = Convert.IsDBNull(dt.Rows[0]["CanDelete"]) ? (bool?)null : (bool?)dt.Rows[0]["CanDelete"];
					retObj._cBy					 = Convert.IsDBNull(dt.Rows[0]["CBy"]) ? (Int32?)null : (Int32?)dt.Rows[0]["CBy"];
					retObj._cDate					 = Convert.IsDBNull(dt.Rows[0]["CDate"]) ? (DateTime?)null : (DateTime?)dt.Rows[0]["CDate"];
					retObj._eBy					 = Convert.IsDBNull(dt.Rows[0]["EBy"]) ? (Int32?)null : (Int32?)dt.Rows[0]["EBy"];
					retObj._eDate					 = Convert.IsDBNull(dt.Rows[0]["EDate"]) ? (DateTime?)null : (DateTime?)dt.Rows[0]["EDate"];
					retObj._rowId					 = Convert.IsDBNull(dt.Rows[0]["RowId"]) ? (Int64?)null : (Int64?)dt.Rows[0]["RowId"];
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
		///this method allows the object to delete itself from the table SalesError based on its primary key
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
			command.CommandText = InlineProcs.ctprSalesError_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SalesErrorId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_salesErrorId?? (object)DBNull.Value));

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
		///This method saves a new object to the table SalesError
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
			command.CommandText = InlineProcs.ctprSalesError_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SalesErrorId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_salesErrorId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SalesErrorCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_salesErrorCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SalesErrorNameEn", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_salesErrorNameEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SalesErrorNameAr", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_salesErrorNameAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SalesErrorTemplateAr", SqlDbType.NVarChar, -1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_salesErrorTemplateAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SalesErrorTemplateEn", SqlDbType.NVarChar, -1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_salesErrorTemplateEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_icon?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Color", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_color?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DisplayOrder", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_displayOrder?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanEdit", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canEdit?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanDelete", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canDelete?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@RowId", SqlDbType.BigInt, 8, ParameterDirection.Output, false, 19, 0, "", DataRowVersion.Proposed, _rowId));

				command.ExecuteNonQuery();

				_salesErrorId					 = Convert.IsDBNull(command.Parameters["@SalesErrorId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@SalesErrorId"].Value;
				_salesErrorCode					 = Convert.IsDBNull(command.Parameters["@SalesErrorCode"].Value) ? null : (string)command.Parameters["@SalesErrorCode"].Value;
				_salesErrorNameEn					 = Convert.IsDBNull(command.Parameters["@SalesErrorNameEn"].Value) ? null : (string)command.Parameters["@SalesErrorNameEn"].Value;
				_salesErrorNameAr					 = Convert.IsDBNull(command.Parameters["@SalesErrorNameAr"].Value) ? null : (string)command.Parameters["@SalesErrorNameAr"].Value;
				_salesErrorTemplateAr					 = Convert.IsDBNull(command.Parameters["@SalesErrorTemplateAr"].Value) ? null : (string)command.Parameters["@SalesErrorTemplateAr"].Value;
				_salesErrorTemplateEn					 = Convert.IsDBNull(command.Parameters["@SalesErrorTemplateEn"].Value) ? null : (string)command.Parameters["@SalesErrorTemplateEn"].Value;
				_icon					 = Convert.IsDBNull(command.Parameters["@Icon"].Value) ? null : (string)command.Parameters["@Icon"].Value;
				_color					 = Convert.IsDBNull(command.Parameters["@Color"].Value) ? null : (string)command.Parameters["@Color"].Value;
				_displayOrder					 = Convert.IsDBNull(command.Parameters["@DisplayOrder"].Value) ? (Int32?)null : (Int32?)command.Parameters["@DisplayOrder"].Value;
				_isActive					 = Convert.IsDBNull(command.Parameters["@IsActive"].Value) ? (bool?)null : (bool?)command.Parameters["@IsActive"].Value;
				_canEdit					 = Convert.IsDBNull(command.Parameters["@CanEdit"].Value) ? (bool?)null : (bool?)command.Parameters["@CanEdit"].Value;
				_canDelete					 = Convert.IsDBNull(command.Parameters["@CanDelete"].Value) ? (bool?)null : (bool?)command.Parameters["@CanDelete"].Value;
				_cBy					 = Convert.IsDBNull(command.Parameters["@CBy"].Value) ? (Int32?)null : (Int32?)command.Parameters["@CBy"].Value;
				_cDate					 = Convert.IsDBNull(command.Parameters["@CDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@CDate"].Value;
				_eBy					 = Convert.IsDBNull(command.Parameters["@EBy"].Value) ? (Int32?)null : (Int32?)command.Parameters["@EBy"].Value;
				_eDate					 = Convert.IsDBNull(command.Parameters["@EDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@EDate"].Value;
				_rowId					 = Convert.IsDBNull(command.Parameters["@RowId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@RowId"].Value;

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
		///This method returns all data rows in the table SalesError
		///</Summary>
		///<returns>
		///IList-DAOSalesError.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOSalesError> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesError_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesError");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSalesError> objList = new List<DAOSalesError>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSalesError retObj = new DAOSalesError();
						retObj._salesErrorId					 = Convert.IsDBNull(row["SalesErrorId"]) ? (Int32?)null : (Int32?)row["SalesErrorId"];
						retObj._salesErrorCode					 = Convert.IsDBNull(row["SalesErrorCode"]) ? null : (string)row["SalesErrorCode"];
						retObj._salesErrorNameEn					 = Convert.IsDBNull(row["SalesErrorNameEn"]) ? null : (string)row["SalesErrorNameEn"];
						retObj._salesErrorNameAr					 = Convert.IsDBNull(row["SalesErrorNameAr"]) ? null : (string)row["SalesErrorNameAr"];
						retObj._salesErrorTemplateAr					 = Convert.IsDBNull(row["SalesErrorTemplateAr"]) ? null : (string)row["SalesErrorTemplateAr"];
						retObj._salesErrorTemplateEn					 = Convert.IsDBNull(row["SalesErrorTemplateEn"]) ? null : (string)row["SalesErrorTemplateEn"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
						retObj._displayOrder					 = Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._canEdit					 = Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"];
						retObj._canDelete					 = Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"];
						retObj._cBy					 = Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"];
						retObj._cDate					 = Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"];
						retObj._eBy					 = Convert.IsDBNull(row["EBy"]) ? (Int32?)null : (Int32?)row["EBy"];
						retObj._eDate					 = Convert.IsDBNull(row["EDate"]) ? (DateTime?)null : (DateTime?)row["EDate"];
						retObj._rowId					 = Convert.IsDBNull(row["RowId"]) ? (Int64?)null : (Int64?)row["RowId"];
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
			command.CommandText = InlineProcs.ctprSalesError_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiSalesError
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesError_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesError");
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
						if (string.Compare(projection.Member, "SalesErrorId", true) == 0) lst.Add(Convert.IsDBNull(row["SalesErrorId"]) ? (Int32?)null : (Int32?)row["SalesErrorId"]);
						if (string.Compare(projection.Member, "SalesErrorCode", true) == 0) lst.Add(Convert.IsDBNull(row["SalesErrorCode"]) ? null : (string)row["SalesErrorCode"]);
						if (string.Compare(projection.Member, "SalesErrorNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["SalesErrorNameEn"]) ? null : (string)row["SalesErrorNameEn"]);
						if (string.Compare(projection.Member, "SalesErrorNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["SalesErrorNameAr"]) ? null : (string)row["SalesErrorNameAr"]);
						if (string.Compare(projection.Member, "SalesErrorTemplateAr", true) == 0) lst.Add(Convert.IsDBNull(row["SalesErrorTemplateAr"]) ? null : (string)row["SalesErrorTemplateAr"]);
						if (string.Compare(projection.Member, "SalesErrorTemplateEn", true) == 0) lst.Add(Convert.IsDBNull(row["SalesErrorTemplateEn"]) ? null : (string)row["SalesErrorTemplateEn"]);
						if (string.Compare(projection.Member, "Icon", true) == 0) lst.Add(Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"]);
						if (string.Compare(projection.Member, "Color", true) == 0) lst.Add(Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"]);
						if (string.Compare(projection.Member, "DisplayOrder", true) == 0) lst.Add(Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"]);
						if (string.Compare(projection.Member, "IsActive", true) == 0) lst.Add(Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"]);
						if (string.Compare(projection.Member, "CanEdit", true) == 0) lst.Add(Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"]);
						if (string.Compare(projection.Member, "CanDelete", true) == 0) lst.Add(Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"]);
						if (string.Compare(projection.Member, "CBy", true) == 0) lst.Add(Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"]);
						if (string.Compare(projection.Member, "CDate", true) == 0) lst.Add(Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"]);
						if (string.Compare(projection.Member, "EBy", true) == 0) lst.Add(Convert.IsDBNull(row["EBy"]) ? (Int32?)null : (Int32?)row["EBy"]);
						if (string.Compare(projection.Member, "EDate", true) == 0) lst.Add(Convert.IsDBNull(row["EDate"]) ? (DateTime?)null : (DateTime?)row["EDate"]);
						if (string.Compare(projection.Member, "RowId", true) == 0) lst.Add(Convert.IsDBNull(row["RowId"]) ? (Int64?)null : (Int64?)row["RowId"]);
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
		///This method returns all data rows in the table using criteriaquery api SalesError
		///</Summary>
		///<returns>
		///IList-DAOSalesError.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOSalesError> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesError_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesError");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSalesError> objList = new List<DAOSalesError>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSalesError retObj = new DAOSalesError();
						retObj._salesErrorId					 = Convert.IsDBNull(row["SalesErrorId"]) ? (Int32?)null : (Int32?)row["SalesErrorId"];
						retObj._salesErrorCode					 = Convert.IsDBNull(row["SalesErrorCode"]) ? null : (string)row["SalesErrorCode"];
						retObj._salesErrorNameEn					 = Convert.IsDBNull(row["SalesErrorNameEn"]) ? null : (string)row["SalesErrorNameEn"];
						retObj._salesErrorNameAr					 = Convert.IsDBNull(row["SalesErrorNameAr"]) ? null : (string)row["SalesErrorNameAr"];
						retObj._salesErrorTemplateAr					 = Convert.IsDBNull(row["SalesErrorTemplateAr"]) ? null : (string)row["SalesErrorTemplateAr"];
						retObj._salesErrorTemplateEn					 = Convert.IsDBNull(row["SalesErrorTemplateEn"]) ? null : (string)row["SalesErrorTemplateEn"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
						retObj._displayOrder					 = Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._canEdit					 = Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"];
						retObj._canDelete					 = Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"];
						retObj._cBy					 = Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"];
						retObj._cDate					 = Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"];
						retObj._eBy					 = Convert.IsDBNull(row["EBy"]) ? (Int32?)null : (Int32?)row["EBy"];
						retObj._eDate					 = Convert.IsDBNull(row["EDate"]) ? (DateTime?)null : (DateTime?)row["EDate"];
						retObj._rowId					 = Convert.IsDBNull(row["RowId"]) ? (Int64?)null : (Int64?)row["RowId"];
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
		///This method returns all data rows in the table using criteriaquery api SalesError
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesError_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table SalesError based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprSalesError_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SalesErrorId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_salesErrorId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SalesErrorCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_salesErrorCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SalesErrorNameEn", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_salesErrorNameEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SalesErrorNameAr", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_salesErrorNameAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SalesErrorTemplateAr", SqlDbType.NVarChar, -1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_salesErrorTemplateAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SalesErrorTemplateEn", SqlDbType.NVarChar, -1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_salesErrorTemplateEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_icon?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Color", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_color?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DisplayOrder", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_displayOrder?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanEdit", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canEdit?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanDelete", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canDelete?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@RowId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, false, 19, 0, "", DataRowVersion.Proposed, (object)_rowId?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_salesErrorId					 = Convert.IsDBNull(command.Parameters["@SalesErrorId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@SalesErrorId"].Value;
				_salesErrorCode					 = Convert.IsDBNull(command.Parameters["@SalesErrorCode"].Value) ? null : (string)command.Parameters["@SalesErrorCode"].Value;
				_salesErrorNameEn					 = Convert.IsDBNull(command.Parameters["@SalesErrorNameEn"].Value) ? null : (string)command.Parameters["@SalesErrorNameEn"].Value;
				_salesErrorNameAr					 = Convert.IsDBNull(command.Parameters["@SalesErrorNameAr"].Value) ? null : (string)command.Parameters["@SalesErrorNameAr"].Value;
				_salesErrorTemplateAr					 = Convert.IsDBNull(command.Parameters["@SalesErrorTemplateAr"].Value) ? null : (string)command.Parameters["@SalesErrorTemplateAr"].Value;
				_salesErrorTemplateEn					 = Convert.IsDBNull(command.Parameters["@SalesErrorTemplateEn"].Value) ? null : (string)command.Parameters["@SalesErrorTemplateEn"].Value;
				_icon					 = Convert.IsDBNull(command.Parameters["@Icon"].Value) ? null : (string)command.Parameters["@Icon"].Value;
				_color					 = Convert.IsDBNull(command.Parameters["@Color"].Value) ? null : (string)command.Parameters["@Color"].Value;
				_displayOrder					 = Convert.IsDBNull(command.Parameters["@DisplayOrder"].Value) ? (Int32?)null : (Int32?)command.Parameters["@DisplayOrder"].Value;
				_isActive					 = Convert.IsDBNull(command.Parameters["@IsActive"].Value) ? (bool?)null : (bool?)command.Parameters["@IsActive"].Value;
				_canEdit					 = Convert.IsDBNull(command.Parameters["@CanEdit"].Value) ? (bool?)null : (bool?)command.Parameters["@CanEdit"].Value;
				_canDelete					 = Convert.IsDBNull(command.Parameters["@CanDelete"].Value) ? (bool?)null : (bool?)command.Parameters["@CanDelete"].Value;
				_cBy					 = Convert.IsDBNull(command.Parameters["@CBy"].Value) ? (Int32?)null : (Int32?)command.Parameters["@CBy"].Value;
				_cDate					 = Convert.IsDBNull(command.Parameters["@CDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@CDate"].Value;
				_eBy					 = Convert.IsDBNull(command.Parameters["@EBy"].Value) ? (Int32?)null : (Int32?)command.Parameters["@EBy"].Value;
				_eDate					 = Convert.IsDBNull(command.Parameters["@EDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@EDate"].Value;
				_rowId					 = Convert.IsDBNull(command.Parameters["@RowId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@RowId"].Value;

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

		public Int32? SalesErrorId
		{
			get
			{
				return _salesErrorId;
			}
			set
			{
				_salesErrorId = value;
			}
		}

		public string SalesErrorCode
		{
			get
			{
				return _salesErrorCode;
			}
			set
			{
				_salesErrorCode = value;
			}
		}

		public string SalesErrorNameEn
		{
			get
			{
				return _salesErrorNameEn;
			}
			set
			{
				_salesErrorNameEn = value;
			}
		}

		public string SalesErrorNameAr
		{
			get
			{
				return _salesErrorNameAr;
			}
			set
			{
				_salesErrorNameAr = value;
			}
		}

		public string SalesErrorTemplateAr
		{
			get
			{
				return _salesErrorTemplateAr;
			}
			set
			{
				_salesErrorTemplateAr = value;
			}
		}

		public string SalesErrorTemplateEn
		{
			get
			{
				return _salesErrorTemplateEn;
			}
			set
			{
				_salesErrorTemplateEn = value;
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

		public Int64? RowId
		{
			get
			{
				return _rowId;
			}
			set
			{
				_rowId = value;
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
		internal static string ctprSalesError_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[SalesErrorId]
			,[SalesErrorCode]
			,[SalesErrorNameEn]
			,[SalesErrorNameAr]
			,[SalesErrorTemplateAr]
			,[SalesErrorTemplateEn]
			,[Icon]
			,[Color]
			,[DisplayOrder]
			,[IsActive]
			,[CanEdit]
			,[CanDelete]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			,[RowId]
			FROM [dbo].[SalesError]
			WHERE 
			[SalesErrorId] = @SalesErrorId
			";

		internal static string ctprSalesError_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[SalesError]
			WHERE 
			[SalesErrorId] = @SalesErrorId
			";

		internal static string ctprSalesError_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[SalesError]
			(
			[SalesErrorId]
			,[SalesErrorCode]
			,[SalesErrorNameEn]
			,[SalesErrorNameAr]
			,[SalesErrorTemplateAr]
			,[SalesErrorTemplateEn]
			,[Icon]
			,[Color]
			,[DisplayOrder]
			,[IsActive]
			,[CanEdit]
			,[CanDelete]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			)
			VALUES
			(
			@SalesErrorId
			,@SalesErrorCode
			,@SalesErrorNameEn
			,@SalesErrorNameAr
			,@SalesErrorTemplateAr
			,@SalesErrorTemplateEn
			,@Icon
			,@Color
			,@DisplayOrder
			,@IsActive
			,@CanEdit
			,@CanDelete
			,@CBy
			,@CDate
			,@EBy
			,@EDate
			)
			SELECT 
			@SalesErrorId = [SalesErrorId]
			,@SalesErrorCode = [SalesErrorCode]
			,@SalesErrorNameEn = [SalesErrorNameEn]
			,@SalesErrorNameAr = [SalesErrorNameAr]
			,@SalesErrorTemplateAr = [SalesErrorTemplateAr]
			,@SalesErrorTemplateEn = [SalesErrorTemplateEn]
			,@Icon = [Icon]
			,@Color = [Color]
			,@DisplayOrder = [DisplayOrder]
			,@IsActive = [IsActive]
			,@CanEdit = [CanEdit]
			,@CanDelete = [CanDelete]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			,@RowId = [RowId]
			FROM [dbo].[SalesError]
			WHERE 
			[SalesErrorId] = @SalesErrorId
			";

		internal static string ctprSalesError_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[SalesErrorId]
			,[SalesErrorCode]
			,[SalesErrorNameEn]
			,[SalesErrorNameAr]
			,[SalesErrorTemplateAr]
			,[SalesErrorTemplateEn]
			,[Icon]
			,[Color]
			,[DisplayOrder]
			,[IsActive]
			,[CanEdit]
			,[CanDelete]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			,[RowId]
			FROM [dbo].[SalesError]
			";

		internal static string ctprSalesError_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[SalesError]
			";

		internal static string ctprSalesError_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[SalesError]
			##CRITERIA##
			";

		internal static string ctprSalesError_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[SalesErrorId]
			,[SalesErrorCode]
			,[SalesErrorNameEn]
			,[SalesErrorNameAr]
			,[SalesErrorTemplateAr]
			,[SalesErrorTemplateEn]
			,[Icon]
			,[Color]
			,[DisplayOrder]
			,[IsActive]
			,[CanEdit]
			,[CanDelete]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			,[RowId]
			FROM [dbo].[SalesError]
			##CRITERIA##
			";

		internal static string ctprSalesError_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[SalesError]
			##CRITERIA##
			";

		internal static string ctprSalesError_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[SalesError]
			SET
			[SalesErrorCode] = @SalesErrorCode
			,[SalesErrorNameEn] = @SalesErrorNameEn
			,[SalesErrorNameAr] = @SalesErrorNameAr
			,[SalesErrorTemplateAr] = @SalesErrorTemplateAr
			,[SalesErrorTemplateEn] = @SalesErrorTemplateEn
			,[Icon] = @Icon
			,[Color] = @Color
			,[DisplayOrder] = @DisplayOrder
			,[IsActive] = @IsActive
			,[CanEdit] = @CanEdit
			,[CanDelete] = @CanDelete
			,[CBy] = @CBy
			,[CDate] = @CDate
			,[EBy] = @EBy
			,[EDate] = @EDate
			,[RowId] = @RowId
			WHERE 
			[SalesErrorId] = @SalesErrorId
			SELECT 
			@SalesErrorId = [SalesErrorId]
			,@SalesErrorCode = [SalesErrorCode]
			,@SalesErrorNameEn = [SalesErrorNameEn]
			,@SalesErrorNameAr = [SalesErrorNameAr]
			,@SalesErrorTemplateAr = [SalesErrorTemplateAr]
			,@SalesErrorTemplateEn = [SalesErrorTemplateEn]
			,@Icon = [Icon]
			,@Color = [Color]
			,@DisplayOrder = [DisplayOrder]
			,@IsActive = [IsActive]
			,@CanEdit = [CanEdit]
			,@CanDelete = [CanDelete]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			,@RowId = [RowId]
			FROM [dbo].[SalesError]
			WHERE 
			[SalesErrorId] = @SalesErrorId
			";

	}
}
#endregion
