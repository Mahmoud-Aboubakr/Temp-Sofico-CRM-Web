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
	public partial class DAORejectReason : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _rejectReasonId;
		protected string _rejectReasonCode;
		protected string _rejectReasonNameEn;
		protected string _rejectReasonNameAr;
		protected bool? _isActive;
		protected bool? _isDeleted;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected Int32? _displayOrder;
		protected string _color;
		protected string _icon;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		#endregion

		#region class methods
		public DAORejectReason()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table RejectReason based on the primary key(s)
		///</Summary>
		///<returns>
		///DAORejectReason
		///</returns>
		///<parameters>
		///Int32? rejectReasonId
		///</parameters>
		public static DAORejectReason SelectOne(Int32? rejectReasonId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprRejectReason_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("RejectReason");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@RejectReasonId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)rejectReasonId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAORejectReason retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAORejectReason();
					retObj._rejectReasonId					 = Convert.IsDBNull(dt.Rows[0]["RejectReasonId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["RejectReasonId"];
					retObj._rejectReasonCode					 = Convert.IsDBNull(dt.Rows[0]["RejectReasonCode"]) ? null : (string)dt.Rows[0]["RejectReasonCode"];
					retObj._rejectReasonNameEn					 = Convert.IsDBNull(dt.Rows[0]["RejectReasonNameEn"]) ? null : (string)dt.Rows[0]["RejectReasonNameEn"];
					retObj._rejectReasonNameAr					 = Convert.IsDBNull(dt.Rows[0]["RejectReasonNameAr"]) ? null : (string)dt.Rows[0]["RejectReasonNameAr"];
					retObj._isActive					 = Convert.IsDBNull(dt.Rows[0]["IsActive"]) ? (bool?)null : (bool?)dt.Rows[0]["IsActive"];
					retObj._isDeleted					 = Convert.IsDBNull(dt.Rows[0]["IsDeleted"]) ? (bool?)null : (bool?)dt.Rows[0]["IsDeleted"];
					retObj._canEdit					 = Convert.IsDBNull(dt.Rows[0]["CanEdit"]) ? (bool?)null : (bool?)dt.Rows[0]["CanEdit"];
					retObj._canDelete					 = Convert.IsDBNull(dt.Rows[0]["CanDelete"]) ? (bool?)null : (bool?)dt.Rows[0]["CanDelete"];
					retObj._displayOrder					 = Convert.IsDBNull(dt.Rows[0]["DisplayOrder"]) ? (Int32?)null : (Int32?)dt.Rows[0]["DisplayOrder"];
					retObj._color					 = Convert.IsDBNull(dt.Rows[0]["Color"]) ? null : (string)dt.Rows[0]["Color"];
					retObj._icon					 = Convert.IsDBNull(dt.Rows[0]["Icon"]) ? null : (string)dt.Rows[0]["Icon"];
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
		///this method allows the object to delete itself from the table RejectReason based on its primary key
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
			command.CommandText = InlineProcs.ctprRejectReason_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@RejectReasonId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_rejectReasonId?? (object)DBNull.Value));

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
		///This method saves a new object to the table RejectReason
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
			command.CommandText = InlineProcs.ctprRejectReason_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@RejectReasonId", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _rejectReasonId));
				command.Parameters.Add(CtSqlParameter.Get("@RejectReasonCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_rejectReasonCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@RejectReasonNameEn", SqlDbType.NVarChar, 500, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_rejectReasonNameEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@RejectReasonNameAr", SqlDbType.NVarChar, 500, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_rejectReasonNameAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsDeleted", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isDeleted?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanEdit", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canEdit?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanDelete", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canDelete?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DisplayOrder", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_displayOrder?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Color", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_color?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_icon?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_rejectReasonId					 = Convert.IsDBNull(command.Parameters["@RejectReasonId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@RejectReasonId"].Value;
				_rejectReasonCode					 = Convert.IsDBNull(command.Parameters["@RejectReasonCode"].Value) ? null : (string)command.Parameters["@RejectReasonCode"].Value;
				_rejectReasonNameEn					 = Convert.IsDBNull(command.Parameters["@RejectReasonNameEn"].Value) ? null : (string)command.Parameters["@RejectReasonNameEn"].Value;
				_rejectReasonNameAr					 = Convert.IsDBNull(command.Parameters["@RejectReasonNameAr"].Value) ? null : (string)command.Parameters["@RejectReasonNameAr"].Value;
				_isActive					 = Convert.IsDBNull(command.Parameters["@IsActive"].Value) ? (bool?)null : (bool?)command.Parameters["@IsActive"].Value;
				_isDeleted					 = Convert.IsDBNull(command.Parameters["@IsDeleted"].Value) ? (bool?)null : (bool?)command.Parameters["@IsDeleted"].Value;
				_canEdit					 = Convert.IsDBNull(command.Parameters["@CanEdit"].Value) ? (bool?)null : (bool?)command.Parameters["@CanEdit"].Value;
				_canDelete					 = Convert.IsDBNull(command.Parameters["@CanDelete"].Value) ? (bool?)null : (bool?)command.Parameters["@CanDelete"].Value;
				_displayOrder					 = Convert.IsDBNull(command.Parameters["@DisplayOrder"].Value) ? (Int32?)null : (Int32?)command.Parameters["@DisplayOrder"].Value;
				_color					 = Convert.IsDBNull(command.Parameters["@Color"].Value) ? null : (string)command.Parameters["@Color"].Value;
				_icon					 = Convert.IsDBNull(command.Parameters["@Icon"].Value) ? null : (string)command.Parameters["@Icon"].Value;
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
		///This method returns all data rows in the table RejectReason
		///</Summary>
		///<returns>
		///IList-DAORejectReason.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAORejectReason> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprRejectReason_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("RejectReason");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAORejectReason> objList = new List<DAORejectReason>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAORejectReason retObj = new DAORejectReason();
						retObj._rejectReasonId					 = Convert.IsDBNull(row["RejectReasonId"]) ? (Int32?)null : (Int32?)row["RejectReasonId"];
						retObj._rejectReasonCode					 = Convert.IsDBNull(row["RejectReasonCode"]) ? null : (string)row["RejectReasonCode"];
						retObj._rejectReasonNameEn					 = Convert.IsDBNull(row["RejectReasonNameEn"]) ? null : (string)row["RejectReasonNameEn"];
						retObj._rejectReasonNameAr					 = Convert.IsDBNull(row["RejectReasonNameAr"]) ? null : (string)row["RejectReasonNameAr"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._isDeleted					 = Convert.IsDBNull(row["IsDeleted"]) ? (bool?)null : (bool?)row["IsDeleted"];
						retObj._canEdit					 = Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"];
						retObj._canDelete					 = Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"];
						retObj._displayOrder					 = Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
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
			command.CommandText = InlineProcs.ctprRejectReason_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiRejectReason
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprRejectReason_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("RejectReason");
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
						if (string.Compare(projection.Member, "RejectReasonId", true) == 0) lst.Add(Convert.IsDBNull(row["RejectReasonId"]) ? (Int32?)null : (Int32?)row["RejectReasonId"]);
						if (string.Compare(projection.Member, "RejectReasonCode", true) == 0) lst.Add(Convert.IsDBNull(row["RejectReasonCode"]) ? null : (string)row["RejectReasonCode"]);
						if (string.Compare(projection.Member, "RejectReasonNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["RejectReasonNameEn"]) ? null : (string)row["RejectReasonNameEn"]);
						if (string.Compare(projection.Member, "RejectReasonNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["RejectReasonNameAr"]) ? null : (string)row["RejectReasonNameAr"]);
						if (string.Compare(projection.Member, "IsActive", true) == 0) lst.Add(Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"]);
						if (string.Compare(projection.Member, "IsDeleted", true) == 0) lst.Add(Convert.IsDBNull(row["IsDeleted"]) ? (bool?)null : (bool?)row["IsDeleted"]);
						if (string.Compare(projection.Member, "CanEdit", true) == 0) lst.Add(Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"]);
						if (string.Compare(projection.Member, "CanDelete", true) == 0) lst.Add(Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"]);
						if (string.Compare(projection.Member, "DisplayOrder", true) == 0) lst.Add(Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"]);
						if (string.Compare(projection.Member, "Color", true) == 0) lst.Add(Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"]);
						if (string.Compare(projection.Member, "Icon", true) == 0) lst.Add(Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"]);
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
		///This method returns all data rows in the table using criteriaquery api RejectReason
		///</Summary>
		///<returns>
		///IList-DAORejectReason.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAORejectReason> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprRejectReason_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("RejectReason");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAORejectReason> objList = new List<DAORejectReason>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAORejectReason retObj = new DAORejectReason();
						retObj._rejectReasonId					 = Convert.IsDBNull(row["RejectReasonId"]) ? (Int32?)null : (Int32?)row["RejectReasonId"];
						retObj._rejectReasonCode					 = Convert.IsDBNull(row["RejectReasonCode"]) ? null : (string)row["RejectReasonCode"];
						retObj._rejectReasonNameEn					 = Convert.IsDBNull(row["RejectReasonNameEn"]) ? null : (string)row["RejectReasonNameEn"];
						retObj._rejectReasonNameAr					 = Convert.IsDBNull(row["RejectReasonNameAr"]) ? null : (string)row["RejectReasonNameAr"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._isDeleted					 = Convert.IsDBNull(row["IsDeleted"]) ? (bool?)null : (bool?)row["IsDeleted"];
						retObj._canEdit					 = Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"];
						retObj._canDelete					 = Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"];
						retObj._displayOrder					 = Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
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
		///This method returns all data rows in the table using criteriaquery api RejectReason
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprRejectReason_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table RejectReason based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprRejectReason_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@RejectReasonId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_rejectReasonId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@RejectReasonCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_rejectReasonCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@RejectReasonNameEn", SqlDbType.NVarChar, 500, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_rejectReasonNameEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@RejectReasonNameAr", SqlDbType.NVarChar, 500, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_rejectReasonNameAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsDeleted", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isDeleted?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanEdit", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canEdit?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanDelete", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canDelete?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DisplayOrder", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_displayOrder?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Color", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_color?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_icon?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_rejectReasonId					 = Convert.IsDBNull(command.Parameters["@RejectReasonId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@RejectReasonId"].Value;
				_rejectReasonCode					 = Convert.IsDBNull(command.Parameters["@RejectReasonCode"].Value) ? null : (string)command.Parameters["@RejectReasonCode"].Value;
				_rejectReasonNameEn					 = Convert.IsDBNull(command.Parameters["@RejectReasonNameEn"].Value) ? null : (string)command.Parameters["@RejectReasonNameEn"].Value;
				_rejectReasonNameAr					 = Convert.IsDBNull(command.Parameters["@RejectReasonNameAr"].Value) ? null : (string)command.Parameters["@RejectReasonNameAr"].Value;
				_isActive					 = Convert.IsDBNull(command.Parameters["@IsActive"].Value) ? (bool?)null : (bool?)command.Parameters["@IsActive"].Value;
				_isDeleted					 = Convert.IsDBNull(command.Parameters["@IsDeleted"].Value) ? (bool?)null : (bool?)command.Parameters["@IsDeleted"].Value;
				_canEdit					 = Convert.IsDBNull(command.Parameters["@CanEdit"].Value) ? (bool?)null : (bool?)command.Parameters["@CanEdit"].Value;
				_canDelete					 = Convert.IsDBNull(command.Parameters["@CanDelete"].Value) ? (bool?)null : (bool?)command.Parameters["@CanDelete"].Value;
				_displayOrder					 = Convert.IsDBNull(command.Parameters["@DisplayOrder"].Value) ? (Int32?)null : (Int32?)command.Parameters["@DisplayOrder"].Value;
				_color					 = Convert.IsDBNull(command.Parameters["@Color"].Value) ? null : (string)command.Parameters["@Color"].Value;
				_icon					 = Convert.IsDBNull(command.Parameters["@Icon"].Value) ? null : (string)command.Parameters["@Icon"].Value;
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

		public Int32? RejectReasonId
		{
			get
			{
				return _rejectReasonId;
			}
			set
			{
				_rejectReasonId = value;
			}
		}

		public string RejectReasonCode
		{
			get
			{
				return _rejectReasonCode;
			}
			set
			{
				_rejectReasonCode = value;
			}
		}

		public string RejectReasonNameEn
		{
			get
			{
				return _rejectReasonNameEn;
			}
			set
			{
				_rejectReasonNameEn = value;
			}
		}

		public string RejectReasonNameAr
		{
			get
			{
				return _rejectReasonNameAr;
			}
			set
			{
				_rejectReasonNameAr = value;
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

		public bool? IsDeleted
		{
			get
			{
				return _isDeleted;
			}
			set
			{
				_isDeleted = value;
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
		internal static string ctprRejectReason_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[RejectReasonId]
			,[RejectReasonCode]
			,[RejectReasonNameEn]
			,[RejectReasonNameAr]
			,[IsActive]
			,[IsDeleted]
			,[CanEdit]
			,[CanDelete]
			,[DisplayOrder]
			,[Color]
			,[Icon]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[RejectReason]
			WHERE 
			[RejectReasonId] = @RejectReasonId
			";

		internal static string ctprRejectReason_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[RejectReason]
			WHERE 
			[RejectReasonId] = @RejectReasonId
			";

		internal static string ctprRejectReason_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[RejectReason]
			(
			[RejectReasonCode]
			,[RejectReasonNameEn]
			,[RejectReasonNameAr]
			,[IsActive]
			,[IsDeleted]
			,[CanEdit]
			,[CanDelete]
			,[DisplayOrder]
			,[Color]
			,[Icon]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			)
			VALUES
			(
			@RejectReasonCode
			,@RejectReasonNameEn
			,@RejectReasonNameAr
			,@IsActive
			,@IsDeleted
			,@CanEdit
			,@CanDelete
			,@DisplayOrder
			,@Color
			,@Icon
			,@CBy
			,@CDate
			,@EBy
			,@EDate
			)
			SELECT 
			@RejectReasonId = [RejectReasonId]
			,@RejectReasonCode = [RejectReasonCode]
			,@RejectReasonNameEn = [RejectReasonNameEn]
			,@RejectReasonNameAr = [RejectReasonNameAr]
			,@IsActive = [IsActive]
			,@IsDeleted = [IsDeleted]
			,@CanEdit = [CanEdit]
			,@CanDelete = [CanDelete]
			,@DisplayOrder = [DisplayOrder]
			,@Color = [Color]
			,@Icon = [Icon]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[RejectReason]
			WHERE 
			[RejectReasonId] = SCOPE_IDENTITY()
			";

		internal static string ctprRejectReason_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[RejectReasonId]
			,[RejectReasonCode]
			,[RejectReasonNameEn]
			,[RejectReasonNameAr]
			,[IsActive]
			,[IsDeleted]
			,[CanEdit]
			,[CanDelete]
			,[DisplayOrder]
			,[Color]
			,[Icon]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[RejectReason]
			";

		internal static string ctprRejectReason_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[RejectReason]
			";

		internal static string ctprRejectReason_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[RejectReason]
			##CRITERIA##
			";

		internal static string ctprRejectReason_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[RejectReasonId]
			,[RejectReasonCode]
			,[RejectReasonNameEn]
			,[RejectReasonNameAr]
			,[IsActive]
			,[IsDeleted]
			,[CanEdit]
			,[CanDelete]
			,[DisplayOrder]
			,[Color]
			,[Icon]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[RejectReason]
			##CRITERIA##
			";

		internal static string ctprRejectReason_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[RejectReason]
			##CRITERIA##
			";

		internal static string ctprRejectReason_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[RejectReason]
			SET
			[RejectReasonCode] = @RejectReasonCode
			,[RejectReasonNameEn] = @RejectReasonNameEn
			,[RejectReasonNameAr] = @RejectReasonNameAr
			,[IsActive] = @IsActive
			,[IsDeleted] = @IsDeleted
			,[CanEdit] = @CanEdit
			,[CanDelete] = @CanDelete
			,[DisplayOrder] = @DisplayOrder
			,[Color] = @Color
			,[Icon] = @Icon
			,[CBy] = @CBy
			,[CDate] = @CDate
			,[EBy] = @EBy
			,[EDate] = @EDate
			WHERE 
			[RejectReasonId] = @RejectReasonId
			SELECT 
			@RejectReasonId = [RejectReasonId]
			,@RejectReasonCode = [RejectReasonCode]
			,@RejectReasonNameEn = [RejectReasonNameEn]
			,@RejectReasonNameAr = [RejectReasonNameAr]
			,@IsActive = [IsActive]
			,@IsDeleted = [IsDeleted]
			,@CanEdit = [CanEdit]
			,@CanDelete = [CanDelete]
			,@DisplayOrder = [DisplayOrder]
			,@Color = [Color]
			,@Icon = [Icon]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[RejectReason]
			WHERE 
			[RejectReasonId] = @RejectReasonId
			";

	}
}
#endregion
