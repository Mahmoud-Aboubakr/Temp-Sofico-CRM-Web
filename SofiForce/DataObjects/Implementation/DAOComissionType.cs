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
	public partial class DAOComissionType : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _comissionTypeId;
		protected string _comissionTypeCode;
		protected string _comissionTypeNameEn;
		protected string _comissionTypeNameAr;
		protected string _icon;
		protected string _color;
		protected string _displayOrder;
		protected bool? _isActive;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		#endregion

		#region class methods
		public DAOComissionType()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table ComissionType based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOComissionType
		///</returns>
		///<parameters>
		///Int32? comissionTypeId
		///</parameters>
		public static DAOComissionType SelectOne(Int32? comissionTypeId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprComissionType_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("ComissionType");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ComissionTypeId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)comissionTypeId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOComissionType retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOComissionType();
					retObj._comissionTypeId					 = Convert.IsDBNull(dt.Rows[0]["ComissionTypeId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["ComissionTypeId"];
					retObj._comissionTypeCode					 = Convert.IsDBNull(dt.Rows[0]["ComissionTypeCode"]) ? null : (string)dt.Rows[0]["ComissionTypeCode"];
					retObj._comissionTypeNameEn					 = Convert.IsDBNull(dt.Rows[0]["ComissionTypeNameEn"]) ? null : (string)dt.Rows[0]["ComissionTypeNameEn"];
					retObj._comissionTypeNameAr					 = Convert.IsDBNull(dt.Rows[0]["ComissionTypeNameAr"]) ? null : (string)dt.Rows[0]["ComissionTypeNameAr"];
					retObj._icon					 = Convert.IsDBNull(dt.Rows[0]["Icon"]) ? null : (string)dt.Rows[0]["Icon"];
					retObj._color					 = Convert.IsDBNull(dt.Rows[0]["Color"]) ? null : (string)dt.Rows[0]["Color"];
					retObj._displayOrder					 = Convert.IsDBNull(dt.Rows[0]["DisplayOrder"]) ? null : (string)dt.Rows[0]["DisplayOrder"];
					retObj._isActive					 = Convert.IsDBNull(dt.Rows[0]["IsActive"]) ? (bool?)null : (bool?)dt.Rows[0]["IsActive"];
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
		///this method allows the object to delete itself from the table ComissionType based on its primary key
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
			command.CommandText = InlineProcs.ctprComissionType_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ComissionTypeId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_comissionTypeId?? (object)DBNull.Value));

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
		///This method saves a new object to the table ComissionType
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
			command.CommandText = InlineProcs.ctprComissionType_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ComissionTypeId", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _comissionTypeId));
				command.Parameters.Add(CtSqlParameter.Get("@ComissionTypeCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_comissionTypeCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ComissionTypeNameEn", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_comissionTypeNameEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ComissionTypeNameAr", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_comissionTypeNameAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_icon?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Color", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_color?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DisplayOrder", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_displayOrder?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanEdit", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canEdit?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanDelete", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canDelete?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_comissionTypeId					 = Convert.IsDBNull(command.Parameters["@ComissionTypeId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ComissionTypeId"].Value;
				_comissionTypeCode					 = Convert.IsDBNull(command.Parameters["@ComissionTypeCode"].Value) ? null : (string)command.Parameters["@ComissionTypeCode"].Value;
				_comissionTypeNameEn					 = Convert.IsDBNull(command.Parameters["@ComissionTypeNameEn"].Value) ? null : (string)command.Parameters["@ComissionTypeNameEn"].Value;
				_comissionTypeNameAr					 = Convert.IsDBNull(command.Parameters["@ComissionTypeNameAr"].Value) ? null : (string)command.Parameters["@ComissionTypeNameAr"].Value;
				_icon					 = Convert.IsDBNull(command.Parameters["@Icon"].Value) ? null : (string)command.Parameters["@Icon"].Value;
				_color					 = Convert.IsDBNull(command.Parameters["@Color"].Value) ? null : (string)command.Parameters["@Color"].Value;
				_displayOrder					 = Convert.IsDBNull(command.Parameters["@DisplayOrder"].Value) ? null : (string)command.Parameters["@DisplayOrder"].Value;
				_isActive					 = Convert.IsDBNull(command.Parameters["@IsActive"].Value) ? (bool?)null : (bool?)command.Parameters["@IsActive"].Value;
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
		///This method returns all data rows in the table ComissionType
		///</Summary>
		///<returns>
		///IList-DAOComissionType.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOComissionType> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprComissionType_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("ComissionType");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOComissionType> objList = new List<DAOComissionType>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOComissionType retObj = new DAOComissionType();
						retObj._comissionTypeId					 = Convert.IsDBNull(row["ComissionTypeId"]) ? (Int32?)null : (Int32?)row["ComissionTypeId"];
						retObj._comissionTypeCode					 = Convert.IsDBNull(row["ComissionTypeCode"]) ? null : (string)row["ComissionTypeCode"];
						retObj._comissionTypeNameEn					 = Convert.IsDBNull(row["ComissionTypeNameEn"]) ? null : (string)row["ComissionTypeNameEn"];
						retObj._comissionTypeNameAr					 = Convert.IsDBNull(row["ComissionTypeNameAr"]) ? null : (string)row["ComissionTypeNameAr"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
						retObj._displayOrder					 = Convert.IsDBNull(row["DisplayOrder"]) ? null : (string)row["DisplayOrder"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
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
			command.CommandText = InlineProcs.ctprComissionType_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiComissionType
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprComissionType_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("ComissionType");
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
						if (string.Compare(projection.Member, "ComissionTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["ComissionTypeId"]) ? (Int32?)null : (Int32?)row["ComissionTypeId"]);
						if (string.Compare(projection.Member, "ComissionTypeCode", true) == 0) lst.Add(Convert.IsDBNull(row["ComissionTypeCode"]) ? null : (string)row["ComissionTypeCode"]);
						if (string.Compare(projection.Member, "ComissionTypeNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["ComissionTypeNameEn"]) ? null : (string)row["ComissionTypeNameEn"]);
						if (string.Compare(projection.Member, "ComissionTypeNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["ComissionTypeNameAr"]) ? null : (string)row["ComissionTypeNameAr"]);
						if (string.Compare(projection.Member, "Icon", true) == 0) lst.Add(Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"]);
						if (string.Compare(projection.Member, "Color", true) == 0) lst.Add(Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"]);
						if (string.Compare(projection.Member, "DisplayOrder", true) == 0) lst.Add(Convert.IsDBNull(row["DisplayOrder"]) ? null : (string)row["DisplayOrder"]);
						if (string.Compare(projection.Member, "IsActive", true) == 0) lst.Add(Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"]);
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
		///This method returns all data rows in the table using criteriaquery api ComissionType
		///</Summary>
		///<returns>
		///IList-DAOComissionType.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOComissionType> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprComissionType_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("ComissionType");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOComissionType> objList = new List<DAOComissionType>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOComissionType retObj = new DAOComissionType();
						retObj._comissionTypeId					 = Convert.IsDBNull(row["ComissionTypeId"]) ? (Int32?)null : (Int32?)row["ComissionTypeId"];
						retObj._comissionTypeCode					 = Convert.IsDBNull(row["ComissionTypeCode"]) ? null : (string)row["ComissionTypeCode"];
						retObj._comissionTypeNameEn					 = Convert.IsDBNull(row["ComissionTypeNameEn"]) ? null : (string)row["ComissionTypeNameEn"];
						retObj._comissionTypeNameAr					 = Convert.IsDBNull(row["ComissionTypeNameAr"]) ? null : (string)row["ComissionTypeNameAr"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
						retObj._displayOrder					 = Convert.IsDBNull(row["DisplayOrder"]) ? null : (string)row["DisplayOrder"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
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
		///This method returns all data rows in the table using criteriaquery api ComissionType
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprComissionType_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table ComissionType based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprComissionType_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ComissionTypeId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_comissionTypeId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ComissionTypeCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_comissionTypeCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ComissionTypeNameEn", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_comissionTypeNameEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ComissionTypeNameAr", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_comissionTypeNameAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_icon?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Color", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_color?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DisplayOrder", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_displayOrder?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanEdit", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canEdit?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanDelete", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canDelete?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_comissionTypeId					 = Convert.IsDBNull(command.Parameters["@ComissionTypeId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ComissionTypeId"].Value;
				_comissionTypeCode					 = Convert.IsDBNull(command.Parameters["@ComissionTypeCode"].Value) ? null : (string)command.Parameters["@ComissionTypeCode"].Value;
				_comissionTypeNameEn					 = Convert.IsDBNull(command.Parameters["@ComissionTypeNameEn"].Value) ? null : (string)command.Parameters["@ComissionTypeNameEn"].Value;
				_comissionTypeNameAr					 = Convert.IsDBNull(command.Parameters["@ComissionTypeNameAr"].Value) ? null : (string)command.Parameters["@ComissionTypeNameAr"].Value;
				_icon					 = Convert.IsDBNull(command.Parameters["@Icon"].Value) ? null : (string)command.Parameters["@Icon"].Value;
				_color					 = Convert.IsDBNull(command.Parameters["@Color"].Value) ? null : (string)command.Parameters["@Color"].Value;
				_displayOrder					 = Convert.IsDBNull(command.Parameters["@DisplayOrder"].Value) ? null : (string)command.Parameters["@DisplayOrder"].Value;
				_isActive					 = Convert.IsDBNull(command.Parameters["@IsActive"].Value) ? (bool?)null : (bool?)command.Parameters["@IsActive"].Value;
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

		public Int32? ComissionTypeId
		{
			get
			{
				return _comissionTypeId;
			}
			set
			{
				_comissionTypeId = value;
			}
		}

		public string ComissionTypeCode
		{
			get
			{
				return _comissionTypeCode;
			}
			set
			{
				_comissionTypeCode = value;
			}
		}

		public string ComissionTypeNameEn
		{
			get
			{
				return _comissionTypeNameEn;
			}
			set
			{
				_comissionTypeNameEn = value;
			}
		}

		public string ComissionTypeNameAr
		{
			get
			{
				return _comissionTypeNameAr;
			}
			set
			{
				_comissionTypeNameAr = value;
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

		public string DisplayOrder
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

		#endregion
	}
}

#region inline sql procs
namespace SofiForce.DataObjects
{
	public partial class InlineProcs
	{
		internal static string ctprComissionType_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[ComissionTypeId]
			,[ComissionTypeCode]
			,[ComissionTypeNameEn]
			,[ComissionTypeNameAr]
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
			FROM [dbo].[ComissionType]
			WHERE 
			[ComissionTypeId] = @ComissionTypeId
			";

		internal static string ctprComissionType_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[ComissionType]
			WHERE 
			[ComissionTypeId] = @ComissionTypeId
			";

		internal static string ctprComissionType_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[ComissionType]
			(
			[ComissionTypeCode]
			,[ComissionTypeNameEn]
			,[ComissionTypeNameAr]
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
			@ComissionTypeCode
			,@ComissionTypeNameEn
			,@ComissionTypeNameAr
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
			@ComissionTypeId = [ComissionTypeId]
			,@ComissionTypeCode = [ComissionTypeCode]
			,@ComissionTypeNameEn = [ComissionTypeNameEn]
			,@ComissionTypeNameAr = [ComissionTypeNameAr]
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
			FROM [dbo].[ComissionType]
			WHERE 
			[ComissionTypeId] = SCOPE_IDENTITY()
			";

		internal static string ctprComissionType_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[ComissionTypeId]
			,[ComissionTypeCode]
			,[ComissionTypeNameEn]
			,[ComissionTypeNameAr]
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
			FROM [dbo].[ComissionType]
			";

		internal static string ctprComissionType_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[ComissionType]
			";

		internal static string ctprComissionType_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[ComissionType]
			##CRITERIA##
			";

		internal static string ctprComissionType_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[ComissionTypeId]
			,[ComissionTypeCode]
			,[ComissionTypeNameEn]
			,[ComissionTypeNameAr]
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
			FROM [dbo].[ComissionType]
			##CRITERIA##
			";

		internal static string ctprComissionType_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[ComissionType]
			##CRITERIA##
			";

		internal static string ctprComissionType_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[ComissionType]
			SET
			[ComissionTypeCode] = @ComissionTypeCode
			,[ComissionTypeNameEn] = @ComissionTypeNameEn
			,[ComissionTypeNameAr] = @ComissionTypeNameAr
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
			WHERE 
			[ComissionTypeId] = @ComissionTypeId
			SELECT 
			@ComissionTypeId = [ComissionTypeId]
			,@ComissionTypeCode = [ComissionTypeCode]
			,@ComissionTypeNameEn = [ComissionTypeNameEn]
			,@ComissionTypeNameAr = [ComissionTypeNameAr]
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
			FROM [dbo].[ComissionType]
			WHERE 
			[ComissionTypeId] = @ComissionTypeId
			";

	}
}
#endregion
