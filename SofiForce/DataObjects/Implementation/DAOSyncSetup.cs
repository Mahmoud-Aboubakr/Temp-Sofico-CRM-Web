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
	public partial class DAOSyncSetup : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _setupId;
		protected string _syncCode;
		protected string _syncNameAr;
		protected string _syncNameEn;
		protected string _icon;
		protected string _color;
		protected bool? _isActive;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		#endregion

		#region class methods
		public DAOSyncSetup()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table SyncSetup based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOSyncSetup
		///</returns>
		///<parameters>
		///Int32? setupId
		///</parameters>
		public static DAOSyncSetup SelectOne(Int32? setupId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSyncSetup_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SyncSetup");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SetupId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)setupId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOSyncSetup retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOSyncSetup();
					retObj._setupId					 = Convert.IsDBNull(dt.Rows[0]["SetupId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["SetupId"];
					retObj._syncCode					 = Convert.IsDBNull(dt.Rows[0]["SyncCode"]) ? null : (string)dt.Rows[0]["SyncCode"];
					retObj._syncNameAr					 = Convert.IsDBNull(dt.Rows[0]["SyncNameAr"]) ? null : (string)dt.Rows[0]["SyncNameAr"];
					retObj._syncNameEn					 = Convert.IsDBNull(dt.Rows[0]["SyncNameEn"]) ? null : (string)dt.Rows[0]["SyncNameEn"];
					retObj._icon					 = Convert.IsDBNull(dt.Rows[0]["Icon"]) ? null : (string)dt.Rows[0]["Icon"];
					retObj._color					 = Convert.IsDBNull(dt.Rows[0]["Color"]) ? null : (string)dt.Rows[0]["Color"];
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
		///this method allows the object to delete itself from the table SyncSetup based on its primary key
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
			command.CommandText = InlineProcs.ctprSyncSetup_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SetupId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_setupId?? (object)DBNull.Value));

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
		///This method saves a new object to the table SyncSetup
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
			command.CommandText = InlineProcs.ctprSyncSetup_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SetupId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_setupId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SyncCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_syncCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SyncNameAr", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_syncNameAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SyncNameEn", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_syncNameEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_icon?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Color", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_color?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_setupId					 = Convert.IsDBNull(command.Parameters["@SetupId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@SetupId"].Value;
				_syncCode					 = Convert.IsDBNull(command.Parameters["@SyncCode"].Value) ? null : (string)command.Parameters["@SyncCode"].Value;
				_syncNameAr					 = Convert.IsDBNull(command.Parameters["@SyncNameAr"].Value) ? null : (string)command.Parameters["@SyncNameAr"].Value;
				_syncNameEn					 = Convert.IsDBNull(command.Parameters["@SyncNameEn"].Value) ? null : (string)command.Parameters["@SyncNameEn"].Value;
				_icon					 = Convert.IsDBNull(command.Parameters["@Icon"].Value) ? null : (string)command.Parameters["@Icon"].Value;
				_color					 = Convert.IsDBNull(command.Parameters["@Color"].Value) ? null : (string)command.Parameters["@Color"].Value;
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
		///This method returns all data rows in the table SyncSetup
		///</Summary>
		///<returns>
		///IList-DAOSyncSetup.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOSyncSetup> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSyncSetup_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SyncSetup");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSyncSetup> objList = new List<DAOSyncSetup>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSyncSetup retObj = new DAOSyncSetup();
						retObj._setupId					 = Convert.IsDBNull(row["SetupId"]) ? (Int32?)null : (Int32?)row["SetupId"];
						retObj._syncCode					 = Convert.IsDBNull(row["SyncCode"]) ? null : (string)row["SyncCode"];
						retObj._syncNameAr					 = Convert.IsDBNull(row["SyncNameAr"]) ? null : (string)row["SyncNameAr"];
						retObj._syncNameEn					 = Convert.IsDBNull(row["SyncNameEn"]) ? null : (string)row["SyncNameEn"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
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
			command.CommandText = InlineProcs.ctprSyncSetup_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiSyncSetup
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSyncSetup_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SyncSetup");
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
						if (string.Compare(projection.Member, "SetupId", true) == 0) lst.Add(Convert.IsDBNull(row["SetupId"]) ? (Int32?)null : (Int32?)row["SetupId"]);
						if (string.Compare(projection.Member, "SyncCode", true) == 0) lst.Add(Convert.IsDBNull(row["SyncCode"]) ? null : (string)row["SyncCode"]);
						if (string.Compare(projection.Member, "SyncNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["SyncNameAr"]) ? null : (string)row["SyncNameAr"]);
						if (string.Compare(projection.Member, "SyncNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["SyncNameEn"]) ? null : (string)row["SyncNameEn"]);
						if (string.Compare(projection.Member, "Icon", true) == 0) lst.Add(Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"]);
						if (string.Compare(projection.Member, "Color", true) == 0) lst.Add(Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"]);
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
		///This method returns all data rows in the table using criteriaquery api SyncSetup
		///</Summary>
		///<returns>
		///IList-DAOSyncSetup.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOSyncSetup> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSyncSetup_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SyncSetup");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSyncSetup> objList = new List<DAOSyncSetup>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSyncSetup retObj = new DAOSyncSetup();
						retObj._setupId					 = Convert.IsDBNull(row["SetupId"]) ? (Int32?)null : (Int32?)row["SetupId"];
						retObj._syncCode					 = Convert.IsDBNull(row["SyncCode"]) ? null : (string)row["SyncCode"];
						retObj._syncNameAr					 = Convert.IsDBNull(row["SyncNameAr"]) ? null : (string)row["SyncNameAr"];
						retObj._syncNameEn					 = Convert.IsDBNull(row["SyncNameEn"]) ? null : (string)row["SyncNameEn"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
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
		///This method returns all data rows in the table using criteriaquery api SyncSetup
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSyncSetup_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table SyncSetup based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprSyncSetup_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SetupId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_setupId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SyncCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_syncCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SyncNameAr", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_syncNameAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SyncNameEn", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_syncNameEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_icon?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Color", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_color?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_setupId					 = Convert.IsDBNull(command.Parameters["@SetupId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@SetupId"].Value;
				_syncCode					 = Convert.IsDBNull(command.Parameters["@SyncCode"].Value) ? null : (string)command.Parameters["@SyncCode"].Value;
				_syncNameAr					 = Convert.IsDBNull(command.Parameters["@SyncNameAr"].Value) ? null : (string)command.Parameters["@SyncNameAr"].Value;
				_syncNameEn					 = Convert.IsDBNull(command.Parameters["@SyncNameEn"].Value) ? null : (string)command.Parameters["@SyncNameEn"].Value;
				_icon					 = Convert.IsDBNull(command.Parameters["@Icon"].Value) ? null : (string)command.Parameters["@Icon"].Value;
				_color					 = Convert.IsDBNull(command.Parameters["@Color"].Value) ? null : (string)command.Parameters["@Color"].Value;
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

		public Int32? SetupId
		{
			get
			{
				return _setupId;
			}
			set
			{
				_setupId = value;
			}
		}

		public string SyncCode
		{
			get
			{
				return _syncCode;
			}
			set
			{
				_syncCode = value;
			}
		}

		public string SyncNameAr
		{
			get
			{
				return _syncNameAr;
			}
			set
			{
				_syncNameAr = value;
			}
		}

		public string SyncNameEn
		{
			get
			{
				return _syncNameEn;
			}
			set
			{
				_syncNameEn = value;
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
		internal static string ctprSyncSetup_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[SetupId]
			,[SyncCode]
			,[SyncNameAr]
			,[SyncNameEn]
			,[Icon]
			,[Color]
			,[IsActive]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[SyncSetup]
			WHERE 
			[SetupId] = @SetupId
			";

		internal static string ctprSyncSetup_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[SyncSetup]
			WHERE 
			[SetupId] = @SetupId
			";

		internal static string ctprSyncSetup_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[SyncSetup]
			(
			[SetupId]
			,[SyncCode]
			,[SyncNameAr]
			,[SyncNameEn]
			,[Icon]
			,[Color]
			,[IsActive]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			)
			VALUES
			(
			@SetupId
			,@SyncCode
			,@SyncNameAr
			,@SyncNameEn
			,@Icon
			,@Color
			,@IsActive
			,@CBy
			,@CDate
			,@EBy
			,@EDate
			)
			SELECT 
			@SetupId = [SetupId]
			,@SyncCode = [SyncCode]
			,@SyncNameAr = [SyncNameAr]
			,@SyncNameEn = [SyncNameEn]
			,@Icon = [Icon]
			,@Color = [Color]
			,@IsActive = [IsActive]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[SyncSetup]
			WHERE 
			[SetupId] = @SetupId
			";

		internal static string ctprSyncSetup_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[SetupId]
			,[SyncCode]
			,[SyncNameAr]
			,[SyncNameEn]
			,[Icon]
			,[Color]
			,[IsActive]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[SyncSetup]
			";

		internal static string ctprSyncSetup_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[SyncSetup]
			";

		internal static string ctprSyncSetup_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[SyncSetup]
			##CRITERIA##
			";

		internal static string ctprSyncSetup_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[SetupId]
			,[SyncCode]
			,[SyncNameAr]
			,[SyncNameEn]
			,[Icon]
			,[Color]
			,[IsActive]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[SyncSetup]
			##CRITERIA##
			";

		internal static string ctprSyncSetup_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[SyncSetup]
			##CRITERIA##
			";

		internal static string ctprSyncSetup_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[SyncSetup]
			SET
			[SyncCode] = @SyncCode
			,[SyncNameAr] = @SyncNameAr
			,[SyncNameEn] = @SyncNameEn
			,[Icon] = @Icon
			,[Color] = @Color
			,[IsActive] = @IsActive
			,[CBy] = @CBy
			,[CDate] = @CDate
			,[EBy] = @EBy
			,[EDate] = @EDate
			WHERE 
			[SetupId] = @SetupId
			SELECT 
			@SetupId = [SetupId]
			,@SyncCode = [SyncCode]
			,@SyncNameAr = [SyncNameAr]
			,@SyncNameEn = [SyncNameEn]
			,@Icon = [Icon]
			,@Color = [Color]
			,@IsActive = [IsActive]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[SyncSetup]
			WHERE 
			[SetupId] = @SetupId
			";

	}
}
#endregion