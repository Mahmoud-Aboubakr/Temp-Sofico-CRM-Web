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
	public partial class DAOAppRoleFeaturePermission : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _rolePermissionId;
		protected Int32? _appRoleFeatueId;
		protected Int32? _featurePermissionId;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		#endregion

		#region class methods
		public DAOAppRoleFeaturePermission()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table AppRole_Feature_Permission based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOAppRoleFeaturePermission
		///</returns>
		///<parameters>
		///Int32? rolePermissionId
		///</parameters>
		public static DAOAppRoleFeaturePermission SelectOne(Int32? rolePermissionId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppRole_Feature_Permission_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppRole_Feature_Permission");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@RolePermissionId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)rolePermissionId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOAppRoleFeaturePermission retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOAppRoleFeaturePermission();
					retObj._rolePermissionId					 = Convert.IsDBNull(dt.Rows[0]["RolePermissionId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["RolePermissionId"];
					retObj._appRoleFeatueId					 = Convert.IsDBNull(dt.Rows[0]["AppRoleFeatueId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["AppRoleFeatueId"];
					retObj._featurePermissionId					 = Convert.IsDBNull(dt.Rows[0]["FeaturePermissionId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["FeaturePermissionId"];
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
		///this method allows the object to delete itself from the table AppRole_Feature_Permission based on its primary key
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
			command.CommandText = InlineProcs.ctprAppRole_Feature_Permission_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@RolePermissionId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_rolePermissionId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table AppRole_Feature_Permission based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOAppRoleFeaturePermission.
		///</returns>
		///<parameters>
		///Int32? appRoleFeatueId
		///</parameters>
		public static IList<DAOAppRoleFeaturePermission> SelectAllByAppRoleFeatueId(Int32? appRoleFeatueId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppRole_Feature_Permission_SelectAllByAppRoleFeatueId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppRole_Feature_Permission");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@AppRoleFeatueId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)appRoleFeatueId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppRoleFeaturePermission> objList = new List<DAOAppRoleFeaturePermission>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppRoleFeaturePermission retObj = new DAOAppRoleFeaturePermission();
						retObj._rolePermissionId					 = Convert.IsDBNull(row["RolePermissionId"]) ? (Int32?)null : (Int32?)row["RolePermissionId"];
						retObj._appRoleFeatueId					 = Convert.IsDBNull(row["AppRoleFeatueId"]) ? (Int32?)null : (Int32?)row["AppRoleFeatueId"];
						retObj._featurePermissionId					 = Convert.IsDBNull(row["FeaturePermissionId"]) ? (Int32?)null : (Int32?)row["FeaturePermissionId"];
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
		///Int32? appRoleFeatueId
		///</parameters>
		public static Int32 SelectAllByAppRoleFeatueIdCount(Int32? appRoleFeatueId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppRole_Feature_Permission_SelectAllByAppRoleFeatueIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@AppRoleFeatueId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)appRoleFeatueId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table AppRole_Feature_Permission with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? appRoleFeatueId
		///</parameters>
		public static void DeleteAllByAppRoleFeatueId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? appRoleFeatueId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppRole_Feature_Permission_DeleteAllByAppRoleFeatueId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@AppRoleFeatueId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)appRoleFeatueId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table AppRole_Feature_Permission based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOAppRoleFeaturePermission.
		///</returns>
		///<parameters>
		///Int32? featurePermissionId
		///</parameters>
		public static IList<DAOAppRoleFeaturePermission> SelectAllByFeaturePermissionId(Int32? featurePermissionId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppRole_Feature_Permission_SelectAllByFeaturePermissionId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppRole_Feature_Permission");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@FeaturePermissionId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)featurePermissionId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppRoleFeaturePermission> objList = new List<DAOAppRoleFeaturePermission>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppRoleFeaturePermission retObj = new DAOAppRoleFeaturePermission();
						retObj._rolePermissionId					 = Convert.IsDBNull(row["RolePermissionId"]) ? (Int32?)null : (Int32?)row["RolePermissionId"];
						retObj._appRoleFeatueId					 = Convert.IsDBNull(row["AppRoleFeatueId"]) ? (Int32?)null : (Int32?)row["AppRoleFeatueId"];
						retObj._featurePermissionId					 = Convert.IsDBNull(row["FeaturePermissionId"]) ? (Int32?)null : (Int32?)row["FeaturePermissionId"];
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
		///Int32? featurePermissionId
		///</parameters>
		public static Int32 SelectAllByFeaturePermissionIdCount(Int32? featurePermissionId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppRole_Feature_Permission_SelectAllByFeaturePermissionIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@FeaturePermissionId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)featurePermissionId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table AppRole_Feature_Permission with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? featurePermissionId
		///</parameters>
		public static void DeleteAllByFeaturePermissionId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? featurePermissionId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppRole_Feature_Permission_DeleteAllByFeaturePermissionId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@FeaturePermissionId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)featurePermissionId?? (object)DBNull.Value));

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
		///This method saves a new object to the table AppRole_Feature_Permission
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
			command.CommandText = InlineProcs.ctprAppRole_Feature_Permission_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@RolePermissionId", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _rolePermissionId));
				command.Parameters.Add(CtSqlParameter.Get("@AppRoleFeatueId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_appRoleFeatueId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@FeaturePermissionId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_featurePermissionId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_rolePermissionId					 = Convert.IsDBNull(command.Parameters["@RolePermissionId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@RolePermissionId"].Value;
				_appRoleFeatueId					 = Convert.IsDBNull(command.Parameters["@AppRoleFeatueId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@AppRoleFeatueId"].Value;
				_featurePermissionId					 = Convert.IsDBNull(command.Parameters["@FeaturePermissionId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@FeaturePermissionId"].Value;
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
		///This method returns all data rows in the table AppRole_Feature_Permission
		///</Summary>
		///<returns>
		///IList-DAOAppRoleFeaturePermission.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOAppRoleFeaturePermission> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppRole_Feature_Permission_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppRole_Feature_Permission");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppRoleFeaturePermission> objList = new List<DAOAppRoleFeaturePermission>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppRoleFeaturePermission retObj = new DAOAppRoleFeaturePermission();
						retObj._rolePermissionId					 = Convert.IsDBNull(row["RolePermissionId"]) ? (Int32?)null : (Int32?)row["RolePermissionId"];
						retObj._appRoleFeatueId					 = Convert.IsDBNull(row["AppRoleFeatueId"]) ? (Int32?)null : (Int32?)row["AppRoleFeatueId"];
						retObj._featurePermissionId					 = Convert.IsDBNull(row["FeaturePermissionId"]) ? (Int32?)null : (Int32?)row["FeaturePermissionId"];
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
			command.CommandText = InlineProcs.ctprAppRole_Feature_Permission_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiAppRole_Feature_Permission
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppRole_Feature_Permission_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppRole_Feature_Permission");
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
						if (string.Compare(projection.Member, "RolePermissionId", true) == 0) lst.Add(Convert.IsDBNull(row["RolePermissionId"]) ? (Int32?)null : (Int32?)row["RolePermissionId"]);
						if (string.Compare(projection.Member, "AppRoleFeatueId", true) == 0) lst.Add(Convert.IsDBNull(row["AppRoleFeatueId"]) ? (Int32?)null : (Int32?)row["AppRoleFeatueId"]);
						if (string.Compare(projection.Member, "FeaturePermissionId", true) == 0) lst.Add(Convert.IsDBNull(row["FeaturePermissionId"]) ? (Int32?)null : (Int32?)row["FeaturePermissionId"]);
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
		///This method returns all data rows in the table using criteriaquery api AppRole_Feature_Permission
		///</Summary>
		///<returns>
		///IList-DAOAppRoleFeaturePermission.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOAppRoleFeaturePermission> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppRole_Feature_Permission_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppRole_Feature_Permission");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppRoleFeaturePermission> objList = new List<DAOAppRoleFeaturePermission>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppRoleFeaturePermission retObj = new DAOAppRoleFeaturePermission();
						retObj._rolePermissionId					 = Convert.IsDBNull(row["RolePermissionId"]) ? (Int32?)null : (Int32?)row["RolePermissionId"];
						retObj._appRoleFeatueId					 = Convert.IsDBNull(row["AppRoleFeatueId"]) ? (Int32?)null : (Int32?)row["AppRoleFeatueId"];
						retObj._featurePermissionId					 = Convert.IsDBNull(row["FeaturePermissionId"]) ? (Int32?)null : (Int32?)row["FeaturePermissionId"];
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
		///This method returns all data rows in the table using criteriaquery api AppRole_Feature_Permission
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppRole_Feature_Permission_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table AppRole_Feature_Permission based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprAppRole_Feature_Permission_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@RolePermissionId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_rolePermissionId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@AppRoleFeatueId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_appRoleFeatueId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@FeaturePermissionId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_featurePermissionId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_rolePermissionId					 = Convert.IsDBNull(command.Parameters["@RolePermissionId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@RolePermissionId"].Value;
				_appRoleFeatueId					 = Convert.IsDBNull(command.Parameters["@AppRoleFeatueId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@AppRoleFeatueId"].Value;
				_featurePermissionId					 = Convert.IsDBNull(command.Parameters["@FeaturePermissionId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@FeaturePermissionId"].Value;
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

		public Int32? RolePermissionId
		{
			get
			{
				return _rolePermissionId;
			}
			set
			{
				_rolePermissionId = value;
			}
		}

		public Int32? AppRoleFeatueId
		{
			get
			{
				return _appRoleFeatueId;
			}
			set
			{
				_appRoleFeatueId = value;
			}
		}

		public Int32? FeaturePermissionId
		{
			get
			{
				return _featurePermissionId;
			}
			set
			{
				_featurePermissionId = value;
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
		internal static string ctprAppRole_Feature_Permission_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[RolePermissionId]
			,[AppRoleFeatueId]
			,[FeaturePermissionId]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[AppRole_Feature_Permission]
			WHERE 
			[RolePermissionId] = @RolePermissionId
			";

		internal static string ctprAppRole_Feature_Permission_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[AppRole_Feature_Permission]
			WHERE 
			[RolePermissionId] = @RolePermissionId
			";

		internal static string ctprAppRole_Feature_Permission_SelectAllByAppRoleFeatueId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[RolePermissionId]
			,[AppRoleFeatueId]
			,[FeaturePermissionId]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[AppRole_Feature_Permission]
			WHERE 
			[AppRoleFeatueId] = @AppRoleFeatueId OR ([AppRoleFeatueId] IS NULL AND @AppRoleFeatueId IS NULL)
			";

		internal static string ctprAppRole_Feature_Permission_SelectAllByAppRoleFeatueIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[AppRole_Feature_Permission]
			WHERE 
			[AppRoleFeatueId] = @AppRoleFeatueId OR ([AppRoleFeatueId] IS NULL AND @AppRoleFeatueId IS NULL)
			";

		internal static string ctprAppRole_Feature_Permission_DeleteAllByAppRoleFeatueId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[AppRole_Feature_Permission]
			WHERE 
			[AppRoleFeatueId] = @AppRoleFeatueId OR ([AppRoleFeatueId] IS NULL AND @AppRoleFeatueId IS NULL)
			";

		internal static string ctprAppRole_Feature_Permission_SelectAllByFeaturePermissionId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[RolePermissionId]
			,[AppRoleFeatueId]
			,[FeaturePermissionId]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[AppRole_Feature_Permission]
			WHERE 
			[FeaturePermissionId] = @FeaturePermissionId OR ([FeaturePermissionId] IS NULL AND @FeaturePermissionId IS NULL)
			";

		internal static string ctprAppRole_Feature_Permission_SelectAllByFeaturePermissionIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[AppRole_Feature_Permission]
			WHERE 
			[FeaturePermissionId] = @FeaturePermissionId OR ([FeaturePermissionId] IS NULL AND @FeaturePermissionId IS NULL)
			";

		internal static string ctprAppRole_Feature_Permission_DeleteAllByFeaturePermissionId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[AppRole_Feature_Permission]
			WHERE 
			[FeaturePermissionId] = @FeaturePermissionId OR ([FeaturePermissionId] IS NULL AND @FeaturePermissionId IS NULL)
			";

		internal static string ctprAppRole_Feature_Permission_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[AppRole_Feature_Permission]
			(
			[AppRoleFeatueId]
			,[FeaturePermissionId]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			)
			VALUES
			(
			@AppRoleFeatueId
			,@FeaturePermissionId
			,@CBy
			,@CDate
			,@EBy
			,@EDate
			)
			SELECT 
			@RolePermissionId = [RolePermissionId]
			,@AppRoleFeatueId = [AppRoleFeatueId]
			,@FeaturePermissionId = [FeaturePermissionId]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[AppRole_Feature_Permission]
			WHERE 
			[RolePermissionId] = SCOPE_IDENTITY()
			";

		internal static string ctprAppRole_Feature_Permission_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[RolePermissionId]
			,[AppRoleFeatueId]
			,[FeaturePermissionId]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[AppRole_Feature_Permission]
			";

		internal static string ctprAppRole_Feature_Permission_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[AppRole_Feature_Permission]
			";

		internal static string ctprAppRole_Feature_Permission_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[AppRole_Feature_Permission]
			##CRITERIA##
			";

		internal static string ctprAppRole_Feature_Permission_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[RolePermissionId]
			,[AppRoleFeatueId]
			,[FeaturePermissionId]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[AppRole_Feature_Permission]
			##CRITERIA##
			";

		internal static string ctprAppRole_Feature_Permission_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[AppRole_Feature_Permission]
			##CRITERIA##
			";

		internal static string ctprAppRole_Feature_Permission_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[AppRole_Feature_Permission]
			SET
			[AppRoleFeatueId] = @AppRoleFeatueId
			,[FeaturePermissionId] = @FeaturePermissionId
			,[CBy] = @CBy
			,[CDate] = @CDate
			,[EBy] = @EBy
			,[EDate] = @EDate
			WHERE 
			[RolePermissionId] = @RolePermissionId
			SELECT 
			@RolePermissionId = [RolePermissionId]
			,@AppRoleFeatueId = [AppRoleFeatueId]
			,@FeaturePermissionId = [FeaturePermissionId]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[AppRole_Feature_Permission]
			WHERE 
			[RolePermissionId] = @RolePermissionId
			";

	}
}
#endregion
