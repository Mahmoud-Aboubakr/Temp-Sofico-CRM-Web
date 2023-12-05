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
	public partial class DAOStoreType : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _storeTypeId;
		protected string _storeTypeNameEn;
		protected string _storeTypeCode;
		protected string _storeTypeNameAr;
		protected bool? _isActive;
		protected Int32? _displayOrder;
		protected bool? _isOrder;
		protected string _icon;
		protected string _color;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		#endregion

		#region class methods
		public DAOStoreType()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table StoreType based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOStoreType
		///</returns>
		///<parameters>
		///Int32? storeTypeId
		///</parameters>
		public static DAOStoreType SelectOne(Int32? storeTypeId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprStoreType_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("StoreType");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@StoreTypeId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)storeTypeId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOStoreType retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOStoreType();
					retObj._storeTypeId					 = Convert.IsDBNull(dt.Rows[0]["StoreTypeId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["StoreTypeId"];
					retObj._storeTypeNameEn					 = Convert.IsDBNull(dt.Rows[0]["StoreTypeNameEn"]) ? null : (string)dt.Rows[0]["StoreTypeNameEn"];
					retObj._storeTypeCode					 = Convert.IsDBNull(dt.Rows[0]["StoreTypeCode"]) ? null : (string)dt.Rows[0]["StoreTypeCode"];
					retObj._storeTypeNameAr					 = Convert.IsDBNull(dt.Rows[0]["StoreTypeNameAr"]) ? null : (string)dt.Rows[0]["StoreTypeNameAr"];
					retObj._isActive					 = Convert.IsDBNull(dt.Rows[0]["IsActive"]) ? (bool?)null : (bool?)dt.Rows[0]["IsActive"];
					retObj._displayOrder					 = Convert.IsDBNull(dt.Rows[0]["DisplayOrder"]) ? (Int32?)null : (Int32?)dt.Rows[0]["DisplayOrder"];
					retObj._isOrder					 = Convert.IsDBNull(dt.Rows[0]["IsOrder"]) ? (bool?)null : (bool?)dt.Rows[0]["IsOrder"];
					retObj._icon					 = Convert.IsDBNull(dt.Rows[0]["Icon"]) ? null : (string)dt.Rows[0]["Icon"];
					retObj._color					 = Convert.IsDBNull(dt.Rows[0]["Color"]) ? null : (string)dt.Rows[0]["Color"];
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
		///this method allows the object to delete itself from the table StoreType based on its primary key
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
			command.CommandText = InlineProcs.ctprStoreType_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@StoreTypeId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_storeTypeId?? (object)DBNull.Value));

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
		///This method saves a new object to the table StoreType
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
			command.CommandText = InlineProcs.ctprStoreType_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@StoreTypeId", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _storeTypeId));
				command.Parameters.Add(CtSqlParameter.Get("@StoreTypeNameEn", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_storeTypeNameEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@StoreTypeCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_storeTypeCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@StoreTypeNameAr", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_storeTypeNameAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DisplayOrder", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_displayOrder?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsOrder", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isOrder?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_icon?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Color", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_color?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanEdit", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canEdit?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanDelete", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canDelete?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_storeTypeId					 = Convert.IsDBNull(command.Parameters["@StoreTypeId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@StoreTypeId"].Value;
				_storeTypeNameEn					 = Convert.IsDBNull(command.Parameters["@StoreTypeNameEn"].Value) ? null : (string)command.Parameters["@StoreTypeNameEn"].Value;
				_storeTypeCode					 = Convert.IsDBNull(command.Parameters["@StoreTypeCode"].Value) ? null : (string)command.Parameters["@StoreTypeCode"].Value;
				_storeTypeNameAr					 = Convert.IsDBNull(command.Parameters["@StoreTypeNameAr"].Value) ? null : (string)command.Parameters["@StoreTypeNameAr"].Value;
				_isActive					 = Convert.IsDBNull(command.Parameters["@IsActive"].Value) ? (bool?)null : (bool?)command.Parameters["@IsActive"].Value;
				_displayOrder					 = Convert.IsDBNull(command.Parameters["@DisplayOrder"].Value) ? (Int32?)null : (Int32?)command.Parameters["@DisplayOrder"].Value;
				_isOrder					 = Convert.IsDBNull(command.Parameters["@IsOrder"].Value) ? (bool?)null : (bool?)command.Parameters["@IsOrder"].Value;
				_icon					 = Convert.IsDBNull(command.Parameters["@Icon"].Value) ? null : (string)command.Parameters["@Icon"].Value;
				_color					 = Convert.IsDBNull(command.Parameters["@Color"].Value) ? null : (string)command.Parameters["@Color"].Value;
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
		///This method returns all data rows in the table StoreType
		///</Summary>
		///<returns>
		///IList-DAOStoreType.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOStoreType> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprStoreType_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("StoreType");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOStoreType> objList = new List<DAOStoreType>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOStoreType retObj = new DAOStoreType();
						retObj._storeTypeId					 = Convert.IsDBNull(row["StoreTypeId"]) ? (Int32?)null : (Int32?)row["StoreTypeId"];
						retObj._storeTypeNameEn					 = Convert.IsDBNull(row["StoreTypeNameEn"]) ? null : (string)row["StoreTypeNameEn"];
						retObj._storeTypeCode					 = Convert.IsDBNull(row["StoreTypeCode"]) ? null : (string)row["StoreTypeCode"];
						retObj._storeTypeNameAr					 = Convert.IsDBNull(row["StoreTypeNameAr"]) ? null : (string)row["StoreTypeNameAr"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._displayOrder					 = Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"];
						retObj._isOrder					 = Convert.IsDBNull(row["IsOrder"]) ? (bool?)null : (bool?)row["IsOrder"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
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
			command.CommandText = InlineProcs.ctprStoreType_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiStoreType
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprStoreType_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("StoreType");
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
						if (string.Compare(projection.Member, "StoreTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["StoreTypeId"]) ? (Int32?)null : (Int32?)row["StoreTypeId"]);
						if (string.Compare(projection.Member, "StoreTypeNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["StoreTypeNameEn"]) ? null : (string)row["StoreTypeNameEn"]);
						if (string.Compare(projection.Member, "StoreTypeCode", true) == 0) lst.Add(Convert.IsDBNull(row["StoreTypeCode"]) ? null : (string)row["StoreTypeCode"]);
						if (string.Compare(projection.Member, "StoreTypeNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["StoreTypeNameAr"]) ? null : (string)row["StoreTypeNameAr"]);
						if (string.Compare(projection.Member, "IsActive", true) == 0) lst.Add(Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"]);
						if (string.Compare(projection.Member, "DisplayOrder", true) == 0) lst.Add(Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"]);
						if (string.Compare(projection.Member, "IsOrder", true) == 0) lst.Add(Convert.IsDBNull(row["IsOrder"]) ? (bool?)null : (bool?)row["IsOrder"]);
						if (string.Compare(projection.Member, "Icon", true) == 0) lst.Add(Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"]);
						if (string.Compare(projection.Member, "Color", true) == 0) lst.Add(Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"]);
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
		///This method returns all data rows in the table using criteriaquery api StoreType
		///</Summary>
		///<returns>
		///IList-DAOStoreType.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOStoreType> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprStoreType_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("StoreType");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOStoreType> objList = new List<DAOStoreType>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOStoreType retObj = new DAOStoreType();
						retObj._storeTypeId					 = Convert.IsDBNull(row["StoreTypeId"]) ? (Int32?)null : (Int32?)row["StoreTypeId"];
						retObj._storeTypeNameEn					 = Convert.IsDBNull(row["StoreTypeNameEn"]) ? null : (string)row["StoreTypeNameEn"];
						retObj._storeTypeCode					 = Convert.IsDBNull(row["StoreTypeCode"]) ? null : (string)row["StoreTypeCode"];
						retObj._storeTypeNameAr					 = Convert.IsDBNull(row["StoreTypeNameAr"]) ? null : (string)row["StoreTypeNameAr"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._displayOrder					 = Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"];
						retObj._isOrder					 = Convert.IsDBNull(row["IsOrder"]) ? (bool?)null : (bool?)row["IsOrder"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
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
		///This method returns all data rows in the table using criteriaquery api StoreType
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprStoreType_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table StoreType based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprStoreType_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@StoreTypeId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_storeTypeId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@StoreTypeNameEn", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_storeTypeNameEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@StoreTypeCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_storeTypeCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@StoreTypeNameAr", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_storeTypeNameAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DisplayOrder", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_displayOrder?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsOrder", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isOrder?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_icon?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Color", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_color?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanEdit", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canEdit?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanDelete", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canDelete?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_storeTypeId					 = Convert.IsDBNull(command.Parameters["@StoreTypeId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@StoreTypeId"].Value;
				_storeTypeNameEn					 = Convert.IsDBNull(command.Parameters["@StoreTypeNameEn"].Value) ? null : (string)command.Parameters["@StoreTypeNameEn"].Value;
				_storeTypeCode					 = Convert.IsDBNull(command.Parameters["@StoreTypeCode"].Value) ? null : (string)command.Parameters["@StoreTypeCode"].Value;
				_storeTypeNameAr					 = Convert.IsDBNull(command.Parameters["@StoreTypeNameAr"].Value) ? null : (string)command.Parameters["@StoreTypeNameAr"].Value;
				_isActive					 = Convert.IsDBNull(command.Parameters["@IsActive"].Value) ? (bool?)null : (bool?)command.Parameters["@IsActive"].Value;
				_displayOrder					 = Convert.IsDBNull(command.Parameters["@DisplayOrder"].Value) ? (Int32?)null : (Int32?)command.Parameters["@DisplayOrder"].Value;
				_isOrder					 = Convert.IsDBNull(command.Parameters["@IsOrder"].Value) ? (bool?)null : (bool?)command.Parameters["@IsOrder"].Value;
				_icon					 = Convert.IsDBNull(command.Parameters["@Icon"].Value) ? null : (string)command.Parameters["@Icon"].Value;
				_color					 = Convert.IsDBNull(command.Parameters["@Color"].Value) ? null : (string)command.Parameters["@Color"].Value;
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

		public Int32? StoreTypeId
		{
			get
			{
				return _storeTypeId;
			}
			set
			{
				_storeTypeId = value;
			}
		}

		public string StoreTypeNameEn
		{
			get
			{
				return _storeTypeNameEn;
			}
			set
			{
				_storeTypeNameEn = value;
			}
		}

		public string StoreTypeCode
		{
			get
			{
				return _storeTypeCode;
			}
			set
			{
				_storeTypeCode = value;
			}
		}

		public string StoreTypeNameAr
		{
			get
			{
				return _storeTypeNameAr;
			}
			set
			{
				_storeTypeNameAr = value;
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

		public bool? IsOrder
		{
			get
			{
				return _isOrder;
			}
			set
			{
				_isOrder = value;
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
		internal static string ctprStoreType_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[StoreTypeId]
			,[StoreTypeNameEn]
			,[StoreTypeCode]
			,[StoreTypeNameAr]
			,[IsActive]
			,[DisplayOrder]
			,[IsOrder]
			,[Icon]
			,[Color]
			,[CanEdit]
			,[CanDelete]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[StoreType]
			WHERE 
			[StoreTypeId] = @StoreTypeId
			";

		internal static string ctprStoreType_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[StoreType]
			WHERE 
			[StoreTypeId] = @StoreTypeId
			";

		internal static string ctprStoreType_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[StoreType]
			(
			[StoreTypeNameEn]
			,[StoreTypeCode]
			,[StoreTypeNameAr]
			,[IsActive]
			,[DisplayOrder]
			,[IsOrder]
			,[Icon]
			,[Color]
			,[CanEdit]
			,[CanDelete]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			)
			VALUES
			(
			@StoreTypeNameEn
			,@StoreTypeCode
			,@StoreTypeNameAr
			,@IsActive
			,@DisplayOrder
			,@IsOrder
			,@Icon
			,@Color
			,@CanEdit
			,@CanDelete
			,@CBy
			,@CDate
			,@EBy
			,@EDate
			)
			SELECT 
			@StoreTypeId = [StoreTypeId]
			,@StoreTypeNameEn = [StoreTypeNameEn]
			,@StoreTypeCode = [StoreTypeCode]
			,@StoreTypeNameAr = [StoreTypeNameAr]
			,@IsActive = [IsActive]
			,@DisplayOrder = [DisplayOrder]
			,@IsOrder = [IsOrder]
			,@Icon = [Icon]
			,@Color = [Color]
			,@CanEdit = [CanEdit]
			,@CanDelete = [CanDelete]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[StoreType]
			WHERE 
			[StoreTypeId] = SCOPE_IDENTITY()
			";

		internal static string ctprStoreType_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[StoreTypeId]
			,[StoreTypeNameEn]
			,[StoreTypeCode]
			,[StoreTypeNameAr]
			,[IsActive]
			,[DisplayOrder]
			,[IsOrder]
			,[Icon]
			,[Color]
			,[CanEdit]
			,[CanDelete]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[StoreType]
			";

		internal static string ctprStoreType_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[StoreType]
			";

		internal static string ctprStoreType_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[StoreType]
			##CRITERIA##
			";

		internal static string ctprStoreType_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[StoreTypeId]
			,[StoreTypeNameEn]
			,[StoreTypeCode]
			,[StoreTypeNameAr]
			,[IsActive]
			,[DisplayOrder]
			,[IsOrder]
			,[Icon]
			,[Color]
			,[CanEdit]
			,[CanDelete]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[StoreType]
			##CRITERIA##
			";

		internal static string ctprStoreType_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[StoreType]
			##CRITERIA##
			";

		internal static string ctprStoreType_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[StoreType]
			SET
			[StoreTypeNameEn] = @StoreTypeNameEn
			,[StoreTypeCode] = @StoreTypeCode
			,[StoreTypeNameAr] = @StoreTypeNameAr
			,[IsActive] = @IsActive
			,[DisplayOrder] = @DisplayOrder
			,[IsOrder] = @IsOrder
			,[Icon] = @Icon
			,[Color] = @Color
			,[CanEdit] = @CanEdit
			,[CanDelete] = @CanDelete
			,[CBy] = @CBy
			,[CDate] = @CDate
			,[EBy] = @EBy
			,[EDate] = @EDate
			WHERE 
			[StoreTypeId] = @StoreTypeId
			SELECT 
			@StoreTypeId = [StoreTypeId]
			,@StoreTypeNameEn = [StoreTypeNameEn]
			,@StoreTypeCode = [StoreTypeCode]
			,@StoreTypeNameAr = [StoreTypeNameAr]
			,@IsActive = [IsActive]
			,@DisplayOrder = [DisplayOrder]
			,@IsOrder = [IsOrder]
			,@Icon = [Icon]
			,@Color = [Color]
			,@CanEdit = [CanEdit]
			,@CanDelete = [CanDelete]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[StoreType]
			WHERE 
			[StoreTypeId] = @StoreTypeId
			";

	}
}
#endregion
