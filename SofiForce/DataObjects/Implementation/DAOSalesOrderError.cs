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
	public partial class DAOSalesOrderError : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int64? _errorId;
		protected Int64? _salesId;
		protected string _errorDetail;
		protected DateTime? _errorDate;
		#endregion

		#region class methods
		public DAOSalesOrderError()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table SalesOrder_Error based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOSalesOrderError
		///</returns>
		///<parameters>
		///Int64? errorId
		///</parameters>
		public static DAOSalesOrderError SelectOne(Int64? errorId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesOrder_Error_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_Error");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ErrorId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)errorId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOSalesOrderError retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOSalesOrderError();
					retObj._errorId					 = Convert.IsDBNull(dt.Rows[0]["ErrorId"]) ? (Int64?)null : (Int64?)dt.Rows[0]["ErrorId"];
					retObj._salesId					 = Convert.IsDBNull(dt.Rows[0]["SalesId"]) ? (Int64?)null : (Int64?)dt.Rows[0]["SalesId"];
					retObj._errorDetail					 = Convert.IsDBNull(dt.Rows[0]["ErrorDetail"]) ? null : (string)dt.Rows[0]["ErrorDetail"];
					retObj._errorDate					 = Convert.IsDBNull(dt.Rows[0]["ErrorDate"]) ? (DateTime?)null : (DateTime?)dt.Rows[0]["ErrorDate"];
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
		///this method allows the object to delete itself from the table SalesOrder_Error based on its primary key
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
			command.CommandText = InlineProcs.ctprSalesOrder_Error_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ErrorId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)_errorId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table SalesOrder_Error based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOSalesOrderError.
		///</returns>
		///<parameters>
		///Int64? salesId
		///</parameters>
		public static IList<DAOSalesOrderError> SelectAllBySalesId(Int64? salesId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesOrder_Error_SelectAllBySalesId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_Error");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SalesId", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)salesId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSalesOrderError> objList = new List<DAOSalesOrderError>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSalesOrderError retObj = new DAOSalesOrderError();
						retObj._errorId					 = Convert.IsDBNull(row["ErrorId"]) ? (Int64?)null : (Int64?)row["ErrorId"];
						retObj._salesId					 = Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"];
						retObj._errorDetail					 = Convert.IsDBNull(row["ErrorDetail"]) ? null : (string)row["ErrorDetail"];
						retObj._errorDate					 = Convert.IsDBNull(row["ErrorDate"]) ? (DateTime?)null : (DateTime?)row["ErrorDate"];
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
		///Int64? salesId
		///</parameters>
		public static Int32 SelectAllBySalesIdCount(Int64? salesId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesOrder_Error_SelectAllBySalesIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SalesId", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)salesId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table SalesOrder_Error with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int64? salesId
		///</parameters>
		public static void DeleteAllBySalesId(zSofiForceConn_TxConnectionProvider connectionProvider, Int64? salesId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesOrder_Error_DeleteAllBySalesId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SalesId", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)salesId?? (object)DBNull.Value));

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
		///This method saves a new object to the table SalesOrder_Error
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
			command.CommandText = InlineProcs.ctprSalesOrder_Error_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ErrorId", SqlDbType.BigInt, 8, ParameterDirection.Output, false, 19, 0, "", DataRowVersion.Proposed, _errorId));
				command.Parameters.Add(CtSqlParameter.Get("@SalesId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, true, 19, 0, "", DataRowVersion.Proposed, (object)_salesId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ErrorDetail", SqlDbType.NVarChar, -1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_errorDetail?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ErrorDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_errorDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_errorId					 = Convert.IsDBNull(command.Parameters["@ErrorId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@ErrorId"].Value;
				_salesId					 = Convert.IsDBNull(command.Parameters["@SalesId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@SalesId"].Value;
				_errorDetail					 = Convert.IsDBNull(command.Parameters["@ErrorDetail"].Value) ? null : (string)command.Parameters["@ErrorDetail"].Value;
				_errorDate					 = Convert.IsDBNull(command.Parameters["@ErrorDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@ErrorDate"].Value;

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
		///This method returns all data rows in the table SalesOrder_Error
		///</Summary>
		///<returns>
		///IList-DAOSalesOrderError.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOSalesOrderError> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesOrder_Error_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_Error");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSalesOrderError> objList = new List<DAOSalesOrderError>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSalesOrderError retObj = new DAOSalesOrderError();
						retObj._errorId					 = Convert.IsDBNull(row["ErrorId"]) ? (Int64?)null : (Int64?)row["ErrorId"];
						retObj._salesId					 = Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"];
						retObj._errorDetail					 = Convert.IsDBNull(row["ErrorDetail"]) ? null : (string)row["ErrorDetail"];
						retObj._errorDate					 = Convert.IsDBNull(row["ErrorDate"]) ? (DateTime?)null : (DateTime?)row["ErrorDate"];
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
			command.CommandText = InlineProcs.ctprSalesOrder_Error_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiSalesOrder_Error
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesOrder_Error_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_Error");
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
						if (string.Compare(projection.Member, "ErrorId", true) == 0) lst.Add(Convert.IsDBNull(row["ErrorId"]) ? (Int64?)null : (Int64?)row["ErrorId"]);
						if (string.Compare(projection.Member, "SalesId", true) == 0) lst.Add(Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"]);
						if (string.Compare(projection.Member, "ErrorDetail", true) == 0) lst.Add(Convert.IsDBNull(row["ErrorDetail"]) ? null : (string)row["ErrorDetail"]);
						if (string.Compare(projection.Member, "ErrorDate", true) == 0) lst.Add(Convert.IsDBNull(row["ErrorDate"]) ? (DateTime?)null : (DateTime?)row["ErrorDate"]);
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
		///This method returns all data rows in the table using criteriaquery api SalesOrder_Error
		///</Summary>
		///<returns>
		///IList-DAOSalesOrderError.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOSalesOrderError> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesOrder_Error_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_Error");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSalesOrderError> objList = new List<DAOSalesOrderError>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSalesOrderError retObj = new DAOSalesOrderError();
						retObj._errorId					 = Convert.IsDBNull(row["ErrorId"]) ? (Int64?)null : (Int64?)row["ErrorId"];
						retObj._salesId					 = Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"];
						retObj._errorDetail					 = Convert.IsDBNull(row["ErrorDetail"]) ? null : (string)row["ErrorDetail"];
						retObj._errorDate					 = Convert.IsDBNull(row["ErrorDate"]) ? (DateTime?)null : (DateTime?)row["ErrorDate"];
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
		///This method returns all data rows in the table using criteriaquery api SalesOrder_Error
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesOrder_Error_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table SalesOrder_Error based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprSalesOrder_Error_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ErrorId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, false, 19, 0, "", DataRowVersion.Proposed, (object)_errorId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SalesId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, true, 19, 0, "", DataRowVersion.Proposed, (object)_salesId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ErrorDetail", SqlDbType.NVarChar, -1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_errorDetail?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ErrorDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_errorDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_errorId					 = Convert.IsDBNull(command.Parameters["@ErrorId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@ErrorId"].Value;
				_salesId					 = Convert.IsDBNull(command.Parameters["@SalesId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@SalesId"].Value;
				_errorDetail					 = Convert.IsDBNull(command.Parameters["@ErrorDetail"].Value) ? null : (string)command.Parameters["@ErrorDetail"].Value;
				_errorDate					 = Convert.IsDBNull(command.Parameters["@ErrorDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@ErrorDate"].Value;

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

		public Int64? ErrorId
		{
			get
			{
				return _errorId;
			}
			set
			{
				_errorId = value;
			}
		}

		public Int64? SalesId
		{
			get
			{
				return _salesId;
			}
			set
			{
				_salesId = value;
			}
		}

		public string ErrorDetail
		{
			get
			{
				return _errorDetail;
			}
			set
			{
				_errorDetail = value;
			}
		}

		public DateTime? ErrorDate
		{
			get
			{
				return _errorDate;
			}
			set
			{
				_errorDate = value;
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
		internal static string ctprSalesOrder_Error_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[ErrorId]
			,[SalesId]
			,[ErrorDetail]
			,[ErrorDate]
			FROM [dbo].[SalesOrder_Error]
			WHERE 
			[ErrorId] = @ErrorId
			";

		internal static string ctprSalesOrder_Error_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[SalesOrder_Error]
			WHERE 
			[ErrorId] = @ErrorId
			";

		internal static string ctprSalesOrder_Error_SelectAllBySalesId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[ErrorId]
			,[SalesId]
			,[ErrorDetail]
			,[ErrorDate]
			FROM [dbo].[SalesOrder_Error]
			WHERE 
			[SalesId] = @SalesId OR ([SalesId] IS NULL AND @SalesId IS NULL)
			";

		internal static string ctprSalesOrder_Error_SelectAllBySalesIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[SalesOrder_Error]
			WHERE 
			[SalesId] = @SalesId OR ([SalesId] IS NULL AND @SalesId IS NULL)
			";

		internal static string ctprSalesOrder_Error_DeleteAllBySalesId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[SalesOrder_Error]
			WHERE 
			[SalesId] = @SalesId OR ([SalesId] IS NULL AND @SalesId IS NULL)
			";

		internal static string ctprSalesOrder_Error_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[SalesOrder_Error]
			(
			[SalesId]
			,[ErrorDetail]
			,[ErrorDate]
			)
			VALUES
			(
			@SalesId
			,@ErrorDetail
			,@ErrorDate
			)
			SELECT 
			@ErrorId = [ErrorId]
			,@SalesId = [SalesId]
			,@ErrorDetail = [ErrorDetail]
			,@ErrorDate = [ErrorDate]
			FROM [dbo].[SalesOrder_Error]
			WHERE 
			[ErrorId] = SCOPE_IDENTITY()
			";

		internal static string ctprSalesOrder_Error_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[ErrorId]
			,[SalesId]
			,[ErrorDetail]
			,[ErrorDate]
			FROM [dbo].[SalesOrder_Error]
			";

		internal static string ctprSalesOrder_Error_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[SalesOrder_Error]
			";

		internal static string ctprSalesOrder_Error_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[SalesOrder_Error]
			##CRITERIA##
			";

		internal static string ctprSalesOrder_Error_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[ErrorId]
			,[SalesId]
			,[ErrorDetail]
			,[ErrorDate]
			FROM [dbo].[SalesOrder_Error]
			##CRITERIA##
			";

		internal static string ctprSalesOrder_Error_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[SalesOrder_Error]
			##CRITERIA##
			";

		internal static string ctprSalesOrder_Error_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[SalesOrder_Error]
			SET
			[SalesId] = @SalesId
			,[ErrorDetail] = @ErrorDetail
			,[ErrorDate] = @ErrorDate
			WHERE 
			[ErrorId] = @ErrorId
			SELECT 
			@ErrorId = [ErrorId]
			,@SalesId = [SalesId]
			,@ErrorDetail = [ErrorDetail]
			,@ErrorDate = [ErrorDate]
			FROM [dbo].[SalesOrder_Error]
			WHERE 
			[ErrorId] = @ErrorId
			";

	}
}
#endregion