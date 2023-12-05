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
	public partial class DAOActivityChannel : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _activityChannelId;
		protected string _activityChannelCode;
		protected string _activityChannelNameEn;
		protected string _activityChannelNameAr;
		protected bool? _isActive;
		protected bool? _canDelete;
		protected bool? _canEdit;
		protected Int32? _displayOrder;
		protected string _color;
		protected string _icon;
		protected Int32? _cBy;
		protected Int32? _eBy;
		protected DateTime? _cDate;
		protected DateTime? _eDate;
		#endregion

		#region class methods
		public DAOActivityChannel()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table ActivityChannel based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOActivityChannel
		///</returns>
		///<parameters>
		///Int32? activityChannelId
		///</parameters>
		public static DAOActivityChannel SelectOne(Int32? activityChannelId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprActivityChannel_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("ActivityChannel");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ActivityChannelId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)activityChannelId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOActivityChannel retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOActivityChannel();
					retObj._activityChannelId					 = Convert.IsDBNull(dt.Rows[0]["ActivityChannelId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["ActivityChannelId"];
					retObj._activityChannelCode					 = Convert.IsDBNull(dt.Rows[0]["ActivityChannelCode"]) ? null : (string)dt.Rows[0]["ActivityChannelCode"];
					retObj._activityChannelNameEn					 = Convert.IsDBNull(dt.Rows[0]["ActivityChannelNameEn"]) ? null : (string)dt.Rows[0]["ActivityChannelNameEn"];
					retObj._activityChannelNameAr					 = Convert.IsDBNull(dt.Rows[0]["ActivityChannelNameAr"]) ? null : (string)dt.Rows[0]["ActivityChannelNameAr"];
					retObj._isActive					 = Convert.IsDBNull(dt.Rows[0]["IsActive"]) ? (bool?)null : (bool?)dt.Rows[0]["IsActive"];
					retObj._canDelete					 = Convert.IsDBNull(dt.Rows[0]["CanDelete"]) ? (bool?)null : (bool?)dt.Rows[0]["CanDelete"];
					retObj._canEdit					 = Convert.IsDBNull(dt.Rows[0]["CanEdit"]) ? (bool?)null : (bool?)dt.Rows[0]["CanEdit"];
					retObj._displayOrder					 = Convert.IsDBNull(dt.Rows[0]["DisplayOrder"]) ? (Int32?)null : (Int32?)dt.Rows[0]["DisplayOrder"];
					retObj._color					 = Convert.IsDBNull(dt.Rows[0]["Color"]) ? null : (string)dt.Rows[0]["Color"];
					retObj._icon					 = Convert.IsDBNull(dt.Rows[0]["Icon"]) ? null : (string)dt.Rows[0]["Icon"];
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
		///this method allows the object to delete itself from the table ActivityChannel based on its primary key
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
			command.CommandText = InlineProcs.ctprActivityChannel_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ActivityChannelId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_activityChannelId?? (object)DBNull.Value));

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
		///This method saves a new object to the table ActivityChannel
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
			command.CommandText = InlineProcs.ctprActivityChannel_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ActivityChannelId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_activityChannelId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ActivityChannelCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_activityChannelCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ActivityChannelNameEn", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_activityChannelNameEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ActivityChannelNameAr", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_activityChannelNameAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanDelete", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canDelete?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanEdit", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canEdit?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DisplayOrder", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_displayOrder?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Color", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_color?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_icon?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_activityChannelId					 = Convert.IsDBNull(command.Parameters["@ActivityChannelId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ActivityChannelId"].Value;
				_activityChannelCode					 = Convert.IsDBNull(command.Parameters["@ActivityChannelCode"].Value) ? null : (string)command.Parameters["@ActivityChannelCode"].Value;
				_activityChannelNameEn					 = Convert.IsDBNull(command.Parameters["@ActivityChannelNameEn"].Value) ? null : (string)command.Parameters["@ActivityChannelNameEn"].Value;
				_activityChannelNameAr					 = Convert.IsDBNull(command.Parameters["@ActivityChannelNameAr"].Value) ? null : (string)command.Parameters["@ActivityChannelNameAr"].Value;
				_isActive					 = Convert.IsDBNull(command.Parameters["@IsActive"].Value) ? (bool?)null : (bool?)command.Parameters["@IsActive"].Value;
				_canDelete					 = Convert.IsDBNull(command.Parameters["@CanDelete"].Value) ? (bool?)null : (bool?)command.Parameters["@CanDelete"].Value;
				_canEdit					 = Convert.IsDBNull(command.Parameters["@CanEdit"].Value) ? (bool?)null : (bool?)command.Parameters["@CanEdit"].Value;
				_displayOrder					 = Convert.IsDBNull(command.Parameters["@DisplayOrder"].Value) ? (Int32?)null : (Int32?)command.Parameters["@DisplayOrder"].Value;
				_color					 = Convert.IsDBNull(command.Parameters["@Color"].Value) ? null : (string)command.Parameters["@Color"].Value;
				_icon					 = Convert.IsDBNull(command.Parameters["@Icon"].Value) ? null : (string)command.Parameters["@Icon"].Value;
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
		///This method returns all data rows in the table ActivityChannel
		///</Summary>
		///<returns>
		///IList-DAOActivityChannel.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOActivityChannel> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprActivityChannel_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("ActivityChannel");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOActivityChannel> objList = new List<DAOActivityChannel>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOActivityChannel retObj = new DAOActivityChannel();
						retObj._activityChannelId					 = Convert.IsDBNull(row["ActivityChannelId"]) ? (Int32?)null : (Int32?)row["ActivityChannelId"];
						retObj._activityChannelCode					 = Convert.IsDBNull(row["ActivityChannelCode"]) ? null : (string)row["ActivityChannelCode"];
						retObj._activityChannelNameEn					 = Convert.IsDBNull(row["ActivityChannelNameEn"]) ? null : (string)row["ActivityChannelNameEn"];
						retObj._activityChannelNameAr					 = Convert.IsDBNull(row["ActivityChannelNameAr"]) ? null : (string)row["ActivityChannelNameAr"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._canDelete					 = Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"];
						retObj._canEdit					 = Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"];
						retObj._displayOrder					 = Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
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
			command.CommandText = InlineProcs.ctprActivityChannel_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiActivityChannel
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprActivityChannel_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("ActivityChannel");
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
						if (string.Compare(projection.Member, "ActivityChannelId", true) == 0) lst.Add(Convert.IsDBNull(row["ActivityChannelId"]) ? (Int32?)null : (Int32?)row["ActivityChannelId"]);
						if (string.Compare(projection.Member, "ActivityChannelCode", true) == 0) lst.Add(Convert.IsDBNull(row["ActivityChannelCode"]) ? null : (string)row["ActivityChannelCode"]);
						if (string.Compare(projection.Member, "ActivityChannelNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["ActivityChannelNameEn"]) ? null : (string)row["ActivityChannelNameEn"]);
						if (string.Compare(projection.Member, "ActivityChannelNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["ActivityChannelNameAr"]) ? null : (string)row["ActivityChannelNameAr"]);
						if (string.Compare(projection.Member, "IsActive", true) == 0) lst.Add(Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"]);
						if (string.Compare(projection.Member, "CanDelete", true) == 0) lst.Add(Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"]);
						if (string.Compare(projection.Member, "CanEdit", true) == 0) lst.Add(Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"]);
						if (string.Compare(projection.Member, "DisplayOrder", true) == 0) lst.Add(Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"]);
						if (string.Compare(projection.Member, "Color", true) == 0) lst.Add(Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"]);
						if (string.Compare(projection.Member, "Icon", true) == 0) lst.Add(Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"]);
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
		///This method returns all data rows in the table using criteriaquery api ActivityChannel
		///</Summary>
		///<returns>
		///IList-DAOActivityChannel.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOActivityChannel> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprActivityChannel_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("ActivityChannel");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOActivityChannel> objList = new List<DAOActivityChannel>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOActivityChannel retObj = new DAOActivityChannel();
						retObj._activityChannelId					 = Convert.IsDBNull(row["ActivityChannelId"]) ? (Int32?)null : (Int32?)row["ActivityChannelId"];
						retObj._activityChannelCode					 = Convert.IsDBNull(row["ActivityChannelCode"]) ? null : (string)row["ActivityChannelCode"];
						retObj._activityChannelNameEn					 = Convert.IsDBNull(row["ActivityChannelNameEn"]) ? null : (string)row["ActivityChannelNameEn"];
						retObj._activityChannelNameAr					 = Convert.IsDBNull(row["ActivityChannelNameAr"]) ? null : (string)row["ActivityChannelNameAr"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._canDelete					 = Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"];
						retObj._canEdit					 = Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"];
						retObj._displayOrder					 = Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
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
		///This method returns all data rows in the table using criteriaquery api ActivityChannel
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprActivityChannel_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table ActivityChannel based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprActivityChannel_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ActivityChannelId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_activityChannelId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ActivityChannelCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_activityChannelCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ActivityChannelNameEn", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_activityChannelNameEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ActivityChannelNameAr", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_activityChannelNameAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanDelete", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canDelete?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanEdit", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canEdit?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DisplayOrder", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_displayOrder?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Color", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_color?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_icon?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_activityChannelId					 = Convert.IsDBNull(command.Parameters["@ActivityChannelId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ActivityChannelId"].Value;
				_activityChannelCode					 = Convert.IsDBNull(command.Parameters["@ActivityChannelCode"].Value) ? null : (string)command.Parameters["@ActivityChannelCode"].Value;
				_activityChannelNameEn					 = Convert.IsDBNull(command.Parameters["@ActivityChannelNameEn"].Value) ? null : (string)command.Parameters["@ActivityChannelNameEn"].Value;
				_activityChannelNameAr					 = Convert.IsDBNull(command.Parameters["@ActivityChannelNameAr"].Value) ? null : (string)command.Parameters["@ActivityChannelNameAr"].Value;
				_isActive					 = Convert.IsDBNull(command.Parameters["@IsActive"].Value) ? (bool?)null : (bool?)command.Parameters["@IsActive"].Value;
				_canDelete					 = Convert.IsDBNull(command.Parameters["@CanDelete"].Value) ? (bool?)null : (bool?)command.Parameters["@CanDelete"].Value;
				_canEdit					 = Convert.IsDBNull(command.Parameters["@CanEdit"].Value) ? (bool?)null : (bool?)command.Parameters["@CanEdit"].Value;
				_displayOrder					 = Convert.IsDBNull(command.Parameters["@DisplayOrder"].Value) ? (Int32?)null : (Int32?)command.Parameters["@DisplayOrder"].Value;
				_color					 = Convert.IsDBNull(command.Parameters["@Color"].Value) ? null : (string)command.Parameters["@Color"].Value;
				_icon					 = Convert.IsDBNull(command.Parameters["@Icon"].Value) ? null : (string)command.Parameters["@Icon"].Value;
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

		public Int32? ActivityChannelId
		{
			get
			{
				return _activityChannelId;
			}
			set
			{
				_activityChannelId = value;
			}
		}

		public string ActivityChannelCode
		{
			get
			{
				return _activityChannelCode;
			}
			set
			{
				_activityChannelCode = value;
			}
		}

		public string ActivityChannelNameEn
		{
			get
			{
				return _activityChannelNameEn;
			}
			set
			{
				_activityChannelNameEn = value;
			}
		}

		public string ActivityChannelNameAr
		{
			get
			{
				return _activityChannelNameAr;
			}
			set
			{
				_activityChannelNameAr = value;
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
		internal static string ctprActivityChannel_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[ActivityChannelId]
			,[ActivityChannelCode]
			,[ActivityChannelNameEn]
			,[ActivityChannelNameAr]
			,[IsActive]
			,[CanDelete]
			,[CanEdit]
			,[DisplayOrder]
			,[Color]
			,[Icon]
			,[CBy]
			,[EBy]
			,[CDate]
			,[EDate]
			FROM [dbo].[ActivityChannel]
			WHERE 
			[ActivityChannelId] = @ActivityChannelId
			";

		internal static string ctprActivityChannel_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[ActivityChannel]
			WHERE 
			[ActivityChannelId] = @ActivityChannelId
			";

		internal static string ctprActivityChannel_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[ActivityChannel]
			(
			[ActivityChannelId]
			,[ActivityChannelCode]
			,[ActivityChannelNameEn]
			,[ActivityChannelNameAr]
			,[IsActive]
			,[CanDelete]
			,[CanEdit]
			,[DisplayOrder]
			,[Color]
			,[Icon]
			,[CBy]
			,[EBy]
			,[CDate]
			,[EDate]
			)
			VALUES
			(
			@ActivityChannelId
			,@ActivityChannelCode
			,@ActivityChannelNameEn
			,@ActivityChannelNameAr
			,@IsActive
			,@CanDelete
			,@CanEdit
			,@DisplayOrder
			,@Color
			,@Icon
			,@CBy
			,@EBy
			,@CDate
			,@EDate
			)
			SELECT 
			@ActivityChannelId = [ActivityChannelId]
			,@ActivityChannelCode = [ActivityChannelCode]
			,@ActivityChannelNameEn = [ActivityChannelNameEn]
			,@ActivityChannelNameAr = [ActivityChannelNameAr]
			,@IsActive = [IsActive]
			,@CanDelete = [CanDelete]
			,@CanEdit = [CanEdit]
			,@DisplayOrder = [DisplayOrder]
			,@Color = [Color]
			,@Icon = [Icon]
			,@CBy = [CBy]
			,@EBy = [EBy]
			,@CDate = [CDate]
			,@EDate = [EDate]
			FROM [dbo].[ActivityChannel]
			WHERE 
			[ActivityChannelId] = @ActivityChannelId
			";

		internal static string ctprActivityChannel_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[ActivityChannelId]
			,[ActivityChannelCode]
			,[ActivityChannelNameEn]
			,[ActivityChannelNameAr]
			,[IsActive]
			,[CanDelete]
			,[CanEdit]
			,[DisplayOrder]
			,[Color]
			,[Icon]
			,[CBy]
			,[EBy]
			,[CDate]
			,[EDate]
			FROM [dbo].[ActivityChannel]
			";

		internal static string ctprActivityChannel_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[ActivityChannel]
			";

		internal static string ctprActivityChannel_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[ActivityChannel]
			##CRITERIA##
			";

		internal static string ctprActivityChannel_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[ActivityChannelId]
			,[ActivityChannelCode]
			,[ActivityChannelNameEn]
			,[ActivityChannelNameAr]
			,[IsActive]
			,[CanDelete]
			,[CanEdit]
			,[DisplayOrder]
			,[Color]
			,[Icon]
			,[CBy]
			,[EBy]
			,[CDate]
			,[EDate]
			FROM [dbo].[ActivityChannel]
			##CRITERIA##
			";

		internal static string ctprActivityChannel_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[ActivityChannel]
			##CRITERIA##
			";

		internal static string ctprActivityChannel_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[ActivityChannel]
			SET
			[ActivityChannelCode] = @ActivityChannelCode
			,[ActivityChannelNameEn] = @ActivityChannelNameEn
			,[ActivityChannelNameAr] = @ActivityChannelNameAr
			,[IsActive] = @IsActive
			,[CanDelete] = @CanDelete
			,[CanEdit] = @CanEdit
			,[DisplayOrder] = @DisplayOrder
			,[Color] = @Color
			,[Icon] = @Icon
			,[CBy] = @CBy
			,[EBy] = @EBy
			,[CDate] = @CDate
			,[EDate] = @EDate
			WHERE 
			[ActivityChannelId] = @ActivityChannelId
			SELECT 
			@ActivityChannelId = [ActivityChannelId]
			,@ActivityChannelCode = [ActivityChannelCode]
			,@ActivityChannelNameEn = [ActivityChannelNameEn]
			,@ActivityChannelNameAr = [ActivityChannelNameAr]
			,@IsActive = [IsActive]
			,@CanDelete = [CanDelete]
			,@CanEdit = [CanEdit]
			,@DisplayOrder = [DisplayOrder]
			,@Color = [Color]
			,@Icon = [Icon]
			,@CBy = [CBy]
			,@EBy = [EBy]
			,@CDate = [CDate]
			,@EDate = [EDate]
			FROM [dbo].[ActivityChannel]
			WHERE 
			[ActivityChannelId] = @ActivityChannelId
			";

	}
}
#endregion
