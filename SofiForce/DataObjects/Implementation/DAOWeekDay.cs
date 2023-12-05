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
	public partial class DAOWeekDay : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _weekDayId;
		protected string _weekDayCode;
		protected string _weekDayNameEn;
		protected string _weekDayNameAr;
		protected string _icon;
		protected string _color;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected bool? _isActive;
		protected Int32? _displayOrder;
		protected Int32? _cBy;
		protected Int32? _cDate;
		#endregion

		#region class methods
		public DAOWeekDay()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table WeekDay based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOWeekDay
		///</returns>
		///<parameters>
		///Int32? weekDayId
		///</parameters>
		public static DAOWeekDay SelectOne(Int32? weekDayId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprWeekDay_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("WeekDay");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@WeekDayId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)weekDayId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOWeekDay retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOWeekDay();
					retObj._weekDayId					 = Convert.IsDBNull(dt.Rows[0]["WeekDayId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["WeekDayId"];
					retObj._weekDayCode					 = Convert.IsDBNull(dt.Rows[0]["WeekDayCode"]) ? null : (string)dt.Rows[0]["WeekDayCode"];
					retObj._weekDayNameEn					 = Convert.IsDBNull(dt.Rows[0]["WeekDayNameEn"]) ? null : (string)dt.Rows[0]["WeekDayNameEn"];
					retObj._weekDayNameAr					 = Convert.IsDBNull(dt.Rows[0]["WeekDayNameAr"]) ? null : (string)dt.Rows[0]["WeekDayNameAr"];
					retObj._icon					 = Convert.IsDBNull(dt.Rows[0]["Icon"]) ? null : (string)dt.Rows[0]["Icon"];
					retObj._color					 = Convert.IsDBNull(dt.Rows[0]["Color"]) ? null : (string)dt.Rows[0]["Color"];
					retObj._canEdit					 = Convert.IsDBNull(dt.Rows[0]["CanEdit"]) ? (bool?)null : (bool?)dt.Rows[0]["CanEdit"];
					retObj._canDelete					 = Convert.IsDBNull(dt.Rows[0]["CanDelete"]) ? (bool?)null : (bool?)dt.Rows[0]["CanDelete"];
					retObj._isActive					 = Convert.IsDBNull(dt.Rows[0]["IsActive"]) ? (bool?)null : (bool?)dt.Rows[0]["IsActive"];
					retObj._displayOrder					 = Convert.IsDBNull(dt.Rows[0]["DisplayOrder"]) ? (Int32?)null : (Int32?)dt.Rows[0]["DisplayOrder"];
					retObj._cBy					 = Convert.IsDBNull(dt.Rows[0]["CBy"]) ? (Int32?)null : (Int32?)dt.Rows[0]["CBy"];
					retObj._cDate					 = Convert.IsDBNull(dt.Rows[0]["CDate"]) ? (Int32?)null : (Int32?)dt.Rows[0]["CDate"];
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
		///this method allows the object to delete itself from the table WeekDay based on its primary key
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
			command.CommandText = InlineProcs.ctprWeekDay_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@WeekDayId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_weekDayId?? (object)DBNull.Value));

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
		///This method saves a new object to the table WeekDay
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
			command.CommandText = InlineProcs.ctprWeekDay_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@WeekDayId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_weekDayId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@WeekDayCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_weekDayCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@WeekDayNameEn", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_weekDayNameEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@WeekDayNameAr", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_weekDayNameAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_icon?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Color", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_color?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanEdit", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canEdit?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanDelete", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canDelete?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DisplayOrder", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_displayOrder?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_weekDayId					 = Convert.IsDBNull(command.Parameters["@WeekDayId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@WeekDayId"].Value;
				_weekDayCode					 = Convert.IsDBNull(command.Parameters["@WeekDayCode"].Value) ? null : (string)command.Parameters["@WeekDayCode"].Value;
				_weekDayNameEn					 = Convert.IsDBNull(command.Parameters["@WeekDayNameEn"].Value) ? null : (string)command.Parameters["@WeekDayNameEn"].Value;
				_weekDayNameAr					 = Convert.IsDBNull(command.Parameters["@WeekDayNameAr"].Value) ? null : (string)command.Parameters["@WeekDayNameAr"].Value;
				_icon					 = Convert.IsDBNull(command.Parameters["@Icon"].Value) ? null : (string)command.Parameters["@Icon"].Value;
				_color					 = Convert.IsDBNull(command.Parameters["@Color"].Value) ? null : (string)command.Parameters["@Color"].Value;
				_canEdit					 = Convert.IsDBNull(command.Parameters["@CanEdit"].Value) ? (bool?)null : (bool?)command.Parameters["@CanEdit"].Value;
				_canDelete					 = Convert.IsDBNull(command.Parameters["@CanDelete"].Value) ? (bool?)null : (bool?)command.Parameters["@CanDelete"].Value;
				_isActive					 = Convert.IsDBNull(command.Parameters["@IsActive"].Value) ? (bool?)null : (bool?)command.Parameters["@IsActive"].Value;
				_displayOrder					 = Convert.IsDBNull(command.Parameters["@DisplayOrder"].Value) ? (Int32?)null : (Int32?)command.Parameters["@DisplayOrder"].Value;
				_cBy					 = Convert.IsDBNull(command.Parameters["@CBy"].Value) ? (Int32?)null : (Int32?)command.Parameters["@CBy"].Value;
				_cDate					 = Convert.IsDBNull(command.Parameters["@CDate"].Value) ? (Int32?)null : (Int32?)command.Parameters["@CDate"].Value;

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
		///This method returns all data rows in the table WeekDay
		///</Summary>
		///<returns>
		///IList-DAOWeekDay.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOWeekDay> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprWeekDay_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("WeekDay");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOWeekDay> objList = new List<DAOWeekDay>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOWeekDay retObj = new DAOWeekDay();
						retObj._weekDayId					 = Convert.IsDBNull(row["WeekDayId"]) ? (Int32?)null : (Int32?)row["WeekDayId"];
						retObj._weekDayCode					 = Convert.IsDBNull(row["WeekDayCode"]) ? null : (string)row["WeekDayCode"];
						retObj._weekDayNameEn					 = Convert.IsDBNull(row["WeekDayNameEn"]) ? null : (string)row["WeekDayNameEn"];
						retObj._weekDayNameAr					 = Convert.IsDBNull(row["WeekDayNameAr"]) ? null : (string)row["WeekDayNameAr"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
						retObj._canEdit					 = Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"];
						retObj._canDelete					 = Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._displayOrder					 = Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"];
						retObj._cBy					 = Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"];
						retObj._cDate					 = Convert.IsDBNull(row["CDate"]) ? (Int32?)null : (Int32?)row["CDate"];
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
			command.CommandText = InlineProcs.ctprWeekDay_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiWeekDay
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprWeekDay_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("WeekDay");
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
						if (string.Compare(projection.Member, "WeekDayId", true) == 0) lst.Add(Convert.IsDBNull(row["WeekDayId"]) ? (Int32?)null : (Int32?)row["WeekDayId"]);
						if (string.Compare(projection.Member, "WeekDayCode", true) == 0) lst.Add(Convert.IsDBNull(row["WeekDayCode"]) ? null : (string)row["WeekDayCode"]);
						if (string.Compare(projection.Member, "WeekDayNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["WeekDayNameEn"]) ? null : (string)row["WeekDayNameEn"]);
						if (string.Compare(projection.Member, "WeekDayNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["WeekDayNameAr"]) ? null : (string)row["WeekDayNameAr"]);
						if (string.Compare(projection.Member, "Icon", true) == 0) lst.Add(Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"]);
						if (string.Compare(projection.Member, "Color", true) == 0) lst.Add(Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"]);
						if (string.Compare(projection.Member, "CanEdit", true) == 0) lst.Add(Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"]);
						if (string.Compare(projection.Member, "CanDelete", true) == 0) lst.Add(Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"]);
						if (string.Compare(projection.Member, "IsActive", true) == 0) lst.Add(Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"]);
						if (string.Compare(projection.Member, "DisplayOrder", true) == 0) lst.Add(Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"]);
						if (string.Compare(projection.Member, "CBy", true) == 0) lst.Add(Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"]);
						if (string.Compare(projection.Member, "CDate", true) == 0) lst.Add(Convert.IsDBNull(row["CDate"]) ? (Int32?)null : (Int32?)row["CDate"]);
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
		///This method returns all data rows in the table using criteriaquery api WeekDay
		///</Summary>
		///<returns>
		///IList-DAOWeekDay.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOWeekDay> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprWeekDay_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("WeekDay");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOWeekDay> objList = new List<DAOWeekDay>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOWeekDay retObj = new DAOWeekDay();
						retObj._weekDayId					 = Convert.IsDBNull(row["WeekDayId"]) ? (Int32?)null : (Int32?)row["WeekDayId"];
						retObj._weekDayCode					 = Convert.IsDBNull(row["WeekDayCode"]) ? null : (string)row["WeekDayCode"];
						retObj._weekDayNameEn					 = Convert.IsDBNull(row["WeekDayNameEn"]) ? null : (string)row["WeekDayNameEn"];
						retObj._weekDayNameAr					 = Convert.IsDBNull(row["WeekDayNameAr"]) ? null : (string)row["WeekDayNameAr"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
						retObj._canEdit					 = Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"];
						retObj._canDelete					 = Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._displayOrder					 = Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"];
						retObj._cBy					 = Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"];
						retObj._cDate					 = Convert.IsDBNull(row["CDate"]) ? (Int32?)null : (Int32?)row["CDate"];
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
		///This method returns all data rows in the table using criteriaquery api WeekDay
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprWeekDay_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table WeekDay based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprWeekDay_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@WeekDayId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_weekDayId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@WeekDayCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_weekDayCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@WeekDayNameEn", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_weekDayNameEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@WeekDayNameAr", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_weekDayNameAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_icon?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Color", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_color?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanEdit", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canEdit?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanDelete", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canDelete?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DisplayOrder", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_displayOrder?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_weekDayId					 = Convert.IsDBNull(command.Parameters["@WeekDayId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@WeekDayId"].Value;
				_weekDayCode					 = Convert.IsDBNull(command.Parameters["@WeekDayCode"].Value) ? null : (string)command.Parameters["@WeekDayCode"].Value;
				_weekDayNameEn					 = Convert.IsDBNull(command.Parameters["@WeekDayNameEn"].Value) ? null : (string)command.Parameters["@WeekDayNameEn"].Value;
				_weekDayNameAr					 = Convert.IsDBNull(command.Parameters["@WeekDayNameAr"].Value) ? null : (string)command.Parameters["@WeekDayNameAr"].Value;
				_icon					 = Convert.IsDBNull(command.Parameters["@Icon"].Value) ? null : (string)command.Parameters["@Icon"].Value;
				_color					 = Convert.IsDBNull(command.Parameters["@Color"].Value) ? null : (string)command.Parameters["@Color"].Value;
				_canEdit					 = Convert.IsDBNull(command.Parameters["@CanEdit"].Value) ? (bool?)null : (bool?)command.Parameters["@CanEdit"].Value;
				_canDelete					 = Convert.IsDBNull(command.Parameters["@CanDelete"].Value) ? (bool?)null : (bool?)command.Parameters["@CanDelete"].Value;
				_isActive					 = Convert.IsDBNull(command.Parameters["@IsActive"].Value) ? (bool?)null : (bool?)command.Parameters["@IsActive"].Value;
				_displayOrder					 = Convert.IsDBNull(command.Parameters["@DisplayOrder"].Value) ? (Int32?)null : (Int32?)command.Parameters["@DisplayOrder"].Value;
				_cBy					 = Convert.IsDBNull(command.Parameters["@CBy"].Value) ? (Int32?)null : (Int32?)command.Parameters["@CBy"].Value;
				_cDate					 = Convert.IsDBNull(command.Parameters["@CDate"].Value) ? (Int32?)null : (Int32?)command.Parameters["@CDate"].Value;

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

		public Int32? WeekDayId
		{
			get
			{
				return _weekDayId;
			}
			set
			{
				_weekDayId = value;
			}
		}

		public string WeekDayCode
		{
			get
			{
				return _weekDayCode;
			}
			set
			{
				_weekDayCode = value;
			}
		}

		public string WeekDayNameEn
		{
			get
			{
				return _weekDayNameEn;
			}
			set
			{
				_weekDayNameEn = value;
			}
		}

		public string WeekDayNameAr
		{
			get
			{
				return _weekDayNameAr;
			}
			set
			{
				_weekDayNameAr = value;
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

		public Int32? CDate
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

		#endregion
	}
}

#region inline sql procs
namespace SofiForce.DataObjects
{
	public partial class InlineProcs
	{
		internal static string ctprWeekDay_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[WeekDayId]
			,[WeekDayCode]
			,[WeekDayNameEn]
			,[WeekDayNameAr]
			,[Icon]
			,[Color]
			,[CanEdit]
			,[CanDelete]
			,[IsActive]
			,[DisplayOrder]
			,[CBy]
			,[CDate]
			FROM [dbo].[WeekDay]
			WHERE 
			[WeekDayId] = @WeekDayId
			";

		internal static string ctprWeekDay_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[WeekDay]
			WHERE 
			[WeekDayId] = @WeekDayId
			";

		internal static string ctprWeekDay_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[WeekDay]
			(
			[WeekDayId]
			,[WeekDayCode]
			,[WeekDayNameEn]
			,[WeekDayNameAr]
			,[Icon]
			,[Color]
			,[CanEdit]
			,[CanDelete]
			,[IsActive]
			,[DisplayOrder]
			,[CBy]
			,[CDate]
			)
			VALUES
			(
			@WeekDayId
			,@WeekDayCode
			,@WeekDayNameEn
			,@WeekDayNameAr
			,@Icon
			,@Color
			,@CanEdit
			,@CanDelete
			,@IsActive
			,@DisplayOrder
			,@CBy
			,@CDate
			)
			SELECT 
			@WeekDayId = [WeekDayId]
			,@WeekDayCode = [WeekDayCode]
			,@WeekDayNameEn = [WeekDayNameEn]
			,@WeekDayNameAr = [WeekDayNameAr]
			,@Icon = [Icon]
			,@Color = [Color]
			,@CanEdit = [CanEdit]
			,@CanDelete = [CanDelete]
			,@IsActive = [IsActive]
			,@DisplayOrder = [DisplayOrder]
			,@CBy = [CBy]
			,@CDate = [CDate]
			FROM [dbo].[WeekDay]
			WHERE 
			[WeekDayId] = @WeekDayId
			";

		internal static string ctprWeekDay_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[WeekDayId]
			,[WeekDayCode]
			,[WeekDayNameEn]
			,[WeekDayNameAr]
			,[Icon]
			,[Color]
			,[CanEdit]
			,[CanDelete]
			,[IsActive]
			,[DisplayOrder]
			,[CBy]
			,[CDate]
			FROM [dbo].[WeekDay]
			";

		internal static string ctprWeekDay_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[WeekDay]
			";

		internal static string ctprWeekDay_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[WeekDay]
			##CRITERIA##
			";

		internal static string ctprWeekDay_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[WeekDayId]
			,[WeekDayCode]
			,[WeekDayNameEn]
			,[WeekDayNameAr]
			,[Icon]
			,[Color]
			,[CanEdit]
			,[CanDelete]
			,[IsActive]
			,[DisplayOrder]
			,[CBy]
			,[CDate]
			FROM [dbo].[WeekDay]
			##CRITERIA##
			";

		internal static string ctprWeekDay_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[WeekDay]
			##CRITERIA##
			";

		internal static string ctprWeekDay_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[WeekDay]
			SET
			[WeekDayCode] = @WeekDayCode
			,[WeekDayNameEn] = @WeekDayNameEn
			,[WeekDayNameAr] = @WeekDayNameAr
			,[Icon] = @Icon
			,[Color] = @Color
			,[CanEdit] = @CanEdit
			,[CanDelete] = @CanDelete
			,[IsActive] = @IsActive
			,[DisplayOrder] = @DisplayOrder
			,[CBy] = @CBy
			,[CDate] = @CDate
			WHERE 
			[WeekDayId] = @WeekDayId
			SELECT 
			@WeekDayId = [WeekDayId]
			,@WeekDayCode = [WeekDayCode]
			,@WeekDayNameEn = [WeekDayNameEn]
			,@WeekDayNameAr = [WeekDayNameAr]
			,@Icon = [Icon]
			,@Color = [Color]
			,@CanEdit = [CanEdit]
			,@CanDelete = [CanDelete]
			,@IsActive = [IsActive]
			,@DisplayOrder = [DisplayOrder]
			,@CBy = [CBy]
			,@CDate = [CDate]
			FROM [dbo].[WeekDay]
			WHERE 
			[WeekDayId] = @WeekDayId
			";

	}
}
#endregion
