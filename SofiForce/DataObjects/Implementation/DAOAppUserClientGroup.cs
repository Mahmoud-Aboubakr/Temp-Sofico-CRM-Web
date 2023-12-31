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
	public partial class DAOAppUserClientGroup : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _appUserGroupId;
		protected Int32? _userId;
		protected Int32? _clientGroupId;
		#endregion

		#region class methods
		public DAOAppUserClientGroup()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table AppUser_ClientGroup based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOAppUserClientGroup
		///</returns>
		///<parameters>
		///Int32? appUserGroupId
		///</parameters>
		public static DAOAppUserClientGroup SelectOne(Int32? appUserGroupId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_ClientGroup_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_ClientGroup");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@AppUserGroupId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)appUserGroupId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOAppUserClientGroup retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOAppUserClientGroup();
					retObj._appUserGroupId					 = Convert.IsDBNull(dt.Rows[0]["AppUserGroupId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["AppUserGroupId"];
					retObj._userId					 = Convert.IsDBNull(dt.Rows[0]["UserId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["UserId"];
					retObj._clientGroupId					 = Convert.IsDBNull(dt.Rows[0]["ClientGroupId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["ClientGroupId"];
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
		///this method allows the object to delete itself from the table AppUser_ClientGroup based on its primary key
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
			command.CommandText = InlineProcs.ctprAppUser_ClientGroup_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@AppUserGroupId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_appUserGroupId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table AppUser_ClientGroup based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOAppUserClientGroup.
		///</returns>
		///<parameters>
		///Int32? userId
		///</parameters>
		public static IList<DAOAppUserClientGroup> SelectAllByUserId(Int32? userId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_ClientGroup_SelectAllByUserId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_ClientGroup");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@UserId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)userId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserClientGroup> objList = new List<DAOAppUserClientGroup>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserClientGroup retObj = new DAOAppUserClientGroup();
						retObj._appUserGroupId					 = Convert.IsDBNull(row["AppUserGroupId"]) ? (Int32?)null : (Int32?)row["AppUserGroupId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._clientGroupId					 = Convert.IsDBNull(row["ClientGroupId"]) ? (Int32?)null : (Int32?)row["ClientGroupId"];
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
		///Int32? userId
		///</parameters>
		public static Int32 SelectAllByUserIdCount(Int32? userId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_ClientGroup_SelectAllByUserIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@UserId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)userId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table AppUser_ClientGroup with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? userId
		///</parameters>
		public static void DeleteAllByUserId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? userId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_ClientGroup_DeleteAllByUserId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@UserId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)userId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table AppUser_ClientGroup based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOAppUserClientGroup.
		///</returns>
		///<parameters>
		///Int32? clientGroupId
		///</parameters>
		public static IList<DAOAppUserClientGroup> SelectAllByClientGroupId(Int32? clientGroupId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_ClientGroup_SelectAllByClientGroupId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_ClientGroup");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ClientGroupId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)clientGroupId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserClientGroup> objList = new List<DAOAppUserClientGroup>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserClientGroup retObj = new DAOAppUserClientGroup();
						retObj._appUserGroupId					 = Convert.IsDBNull(row["AppUserGroupId"]) ? (Int32?)null : (Int32?)row["AppUserGroupId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._clientGroupId					 = Convert.IsDBNull(row["ClientGroupId"]) ? (Int32?)null : (Int32?)row["ClientGroupId"];
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
		///Int32? clientGroupId
		///</parameters>
		public static Int32 SelectAllByClientGroupIdCount(Int32? clientGroupId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_ClientGroup_SelectAllByClientGroupIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ClientGroupId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)clientGroupId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table AppUser_ClientGroup with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? clientGroupId
		///</parameters>
		public static void DeleteAllByClientGroupId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? clientGroupId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_ClientGroup_DeleteAllByClientGroupId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ClientGroupId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)clientGroupId?? (object)DBNull.Value));

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
		///This method saves a new object to the table AppUser_ClientGroup
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
			command.CommandText = InlineProcs.ctprAppUser_ClientGroup_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@AppUserGroupId", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _appUserGroupId));
				command.Parameters.Add(CtSqlParameter.Get("@UserId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_userId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ClientGroupId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_clientGroupId?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_appUserGroupId					 = Convert.IsDBNull(command.Parameters["@AppUserGroupId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@AppUserGroupId"].Value;
				_userId					 = Convert.IsDBNull(command.Parameters["@UserId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@UserId"].Value;
				_clientGroupId					 = Convert.IsDBNull(command.Parameters["@ClientGroupId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ClientGroupId"].Value;

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
		///This method returns all data rows in the table AppUser_ClientGroup
		///</Summary>
		///<returns>
		///IList-DAOAppUserClientGroup.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOAppUserClientGroup> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_ClientGroup_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_ClientGroup");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserClientGroup> objList = new List<DAOAppUserClientGroup>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserClientGroup retObj = new DAOAppUserClientGroup();
						retObj._appUserGroupId					 = Convert.IsDBNull(row["AppUserGroupId"]) ? (Int32?)null : (Int32?)row["AppUserGroupId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._clientGroupId					 = Convert.IsDBNull(row["ClientGroupId"]) ? (Int32?)null : (Int32?)row["ClientGroupId"];
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
			command.CommandText = InlineProcs.ctprAppUser_ClientGroup_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiAppUser_ClientGroup
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUser_ClientGroup_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_ClientGroup");
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
						if (string.Compare(projection.Member, "AppUserGroupId", true) == 0) lst.Add(Convert.IsDBNull(row["AppUserGroupId"]) ? (Int32?)null : (Int32?)row["AppUserGroupId"]);
						if (string.Compare(projection.Member, "UserId", true) == 0) lst.Add(Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"]);
						if (string.Compare(projection.Member, "ClientGroupId", true) == 0) lst.Add(Convert.IsDBNull(row["ClientGroupId"]) ? (Int32?)null : (Int32?)row["ClientGroupId"]);
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
		///This method returns all data rows in the table using criteriaquery api AppUser_ClientGroup
		///</Summary>
		///<returns>
		///IList-DAOAppUserClientGroup.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOAppUserClientGroup> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUser_ClientGroup_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_ClientGroup");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserClientGroup> objList = new List<DAOAppUserClientGroup>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserClientGroup retObj = new DAOAppUserClientGroup();
						retObj._appUserGroupId					 = Convert.IsDBNull(row["AppUserGroupId"]) ? (Int32?)null : (Int32?)row["AppUserGroupId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._clientGroupId					 = Convert.IsDBNull(row["ClientGroupId"]) ? (Int32?)null : (Int32?)row["ClientGroupId"];
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
		///This method returns all data rows in the table using criteriaquery api AppUser_ClientGroup
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUser_ClientGroup_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table AppUser_ClientGroup based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprAppUser_ClientGroup_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@AppUserGroupId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_appUserGroupId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@UserId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_userId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ClientGroupId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_clientGroupId?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_appUserGroupId					 = Convert.IsDBNull(command.Parameters["@AppUserGroupId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@AppUserGroupId"].Value;
				_userId					 = Convert.IsDBNull(command.Parameters["@UserId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@UserId"].Value;
				_clientGroupId					 = Convert.IsDBNull(command.Parameters["@ClientGroupId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ClientGroupId"].Value;

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

		public Int32? AppUserGroupId
		{
			get
			{
				return _appUserGroupId;
			}
			set
			{
				_appUserGroupId = value;
			}
		}

		public Int32? UserId
		{
			get
			{
				return _userId;
			}
			set
			{
				_userId = value;
			}
		}

		public Int32? ClientGroupId
		{
			get
			{
				return _clientGroupId;
			}
			set
			{
				_clientGroupId = value;
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
		internal static string ctprAppUser_ClientGroup_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[AppUserGroupId]
			,[UserId]
			,[ClientGroupId]
			FROM [dbo].[AppUser_ClientGroup]
			WHERE 
			[AppUserGroupId] = @AppUserGroupId
			";

		internal static string ctprAppUser_ClientGroup_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[AppUser_ClientGroup]
			WHERE 
			[AppUserGroupId] = @AppUserGroupId
			";

		internal static string ctprAppUser_ClientGroup_SelectAllByUserId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[AppUserGroupId]
			,[UserId]
			,[ClientGroupId]
			FROM [dbo].[AppUser_ClientGroup]
			WHERE 
			[UserId] = @UserId OR ([UserId] IS NULL AND @UserId IS NULL)
			";

		internal static string ctprAppUser_ClientGroup_SelectAllByUserIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[AppUser_ClientGroup]
			WHERE 
			[UserId] = @UserId OR ([UserId] IS NULL AND @UserId IS NULL)
			";

		internal static string ctprAppUser_ClientGroup_DeleteAllByUserId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[AppUser_ClientGroup]
			WHERE 
			[UserId] = @UserId OR ([UserId] IS NULL AND @UserId IS NULL)
			";

		internal static string ctprAppUser_ClientGroup_SelectAllByClientGroupId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[AppUserGroupId]
			,[UserId]
			,[ClientGroupId]
			FROM [dbo].[AppUser_ClientGroup]
			WHERE 
			[ClientGroupId] = @ClientGroupId OR ([ClientGroupId] IS NULL AND @ClientGroupId IS NULL)
			";

		internal static string ctprAppUser_ClientGroup_SelectAllByClientGroupIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[AppUser_ClientGroup]
			WHERE 
			[ClientGroupId] = @ClientGroupId OR ([ClientGroupId] IS NULL AND @ClientGroupId IS NULL)
			";

		internal static string ctprAppUser_ClientGroup_DeleteAllByClientGroupId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[AppUser_ClientGroup]
			WHERE 
			[ClientGroupId] = @ClientGroupId OR ([ClientGroupId] IS NULL AND @ClientGroupId IS NULL)
			";

		internal static string ctprAppUser_ClientGroup_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[AppUser_ClientGroup]
			(
			[UserId]
			,[ClientGroupId]
			)
			VALUES
			(
			@UserId
			,@ClientGroupId
			)
			SELECT 
			@AppUserGroupId = [AppUserGroupId]
			,@UserId = [UserId]
			,@ClientGroupId = [ClientGroupId]
			FROM [dbo].[AppUser_ClientGroup]
			WHERE 
			[AppUserGroupId] = SCOPE_IDENTITY()
			";

		internal static string ctprAppUser_ClientGroup_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[AppUserGroupId]
			,[UserId]
			,[ClientGroupId]
			FROM [dbo].[AppUser_ClientGroup]
			";

		internal static string ctprAppUser_ClientGroup_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[AppUser_ClientGroup]
			";

		internal static string ctprAppUser_ClientGroup_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[AppUser_ClientGroup]
			##CRITERIA##
			";

		internal static string ctprAppUser_ClientGroup_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[AppUserGroupId]
			,[UserId]
			,[ClientGroupId]
			FROM [dbo].[AppUser_ClientGroup]
			##CRITERIA##
			";

		internal static string ctprAppUser_ClientGroup_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[AppUser_ClientGroup]
			##CRITERIA##
			";

		internal static string ctprAppUser_ClientGroup_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[AppUser_ClientGroup]
			SET
			[UserId] = @UserId
			,[ClientGroupId] = @ClientGroupId
			WHERE 
			[AppUserGroupId] = @AppUserGroupId
			SELECT 
			@AppUserGroupId = [AppUserGroupId]
			,@UserId = [UserId]
			,@ClientGroupId = [ClientGroupId]
			FROM [dbo].[AppUser_ClientGroup]
			WHERE 
			[AppUserGroupId] = @AppUserGroupId
			";

	}
}
#endregion
