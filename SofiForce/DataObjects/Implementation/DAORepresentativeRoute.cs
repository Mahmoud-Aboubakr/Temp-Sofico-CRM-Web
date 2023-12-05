/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 9/21/2022 4:49:17 PM
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SofiForce.DataObjects.Interfaces;

namespace SofiForce.DataObjects
{
	public partial class DAORepresentativeRoute : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _id;
		protected Int32? _routeId;
		protected Int32? _representativeId;
		#endregion

		#region class methods
		public DAORepresentativeRoute()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table Representative_Route based on the primary key(s)
		///</Summary>
		///<returns>
		///DAORepresentativeRoute
		///</returns>
		///<parameters>
		///Int32? id
		///</parameters>
		public static DAORepresentativeRoute SelectOne(Int32? id)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprRepresentative_Route_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Representative_Route");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)id?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAORepresentativeRoute retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAORepresentativeRoute();
					retObj._id					 = Convert.IsDBNull(dt.Rows[0]["Id"]) ? (Int32?)null : (Int32?)dt.Rows[0]["Id"];
					retObj._routeId					 = Convert.IsDBNull(dt.Rows[0]["RouteId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["RouteId"];
					retObj._representativeId					 = Convert.IsDBNull(dt.Rows[0]["RepresentativeId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["RepresentativeId"];
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
		///this method allows the object to delete itself from the table Representative_Route based on its primary key
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
			command.CommandText = InlineProcs.ctprRepresentative_Route_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@Id", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_id?? (object)DBNull.Value));

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
		///This method returns all data rows in the table Representative_Route based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAORepresentativeRoute.
		///</returns>
		///<parameters>
		///Int32? routeId
		///</parameters>
		public static IList<DAORepresentativeRoute> SelectAllByRouteId(Int32? routeId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprRepresentative_Route_SelectAllByRouteId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Representative_Route");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@RouteId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)routeId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAORepresentativeRoute> objList = new List<DAORepresentativeRoute>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAORepresentativeRoute retObj = new DAORepresentativeRoute();
						retObj._id					 = Convert.IsDBNull(row["Id"]) ? (Int32?)null : (Int32?)row["Id"];
						retObj._routeId					 = Convert.IsDBNull(row["RouteId"]) ? (Int32?)null : (Int32?)row["RouteId"];
						retObj._representativeId					 = Convert.IsDBNull(row["RepresentativeId"]) ? (Int32?)null : (Int32?)row["RepresentativeId"];
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
		///Int32? routeId
		///</parameters>
		public static Int32 SelectAllByRouteIdCount(Int32? routeId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprRepresentative_Route_SelectAllByRouteIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@RouteId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)routeId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table Representative_Route with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? routeId
		///</parameters>
		public static void DeleteAllByRouteId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? routeId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprRepresentative_Route_DeleteAllByRouteId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@RouteId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)routeId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table Representative_Route based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAORepresentativeRoute.
		///</returns>
		///<parameters>
		///Int32? representativeId
		///</parameters>
		public static IList<DAORepresentativeRoute> SelectAllByRepresentativeId(Int32? representativeId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprRepresentative_Route_SelectAllByRepresentativeId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Representative_Route");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@RepresentativeId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)representativeId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAORepresentativeRoute> objList = new List<DAORepresentativeRoute>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAORepresentativeRoute retObj = new DAORepresentativeRoute();
						retObj._id					 = Convert.IsDBNull(row["Id"]) ? (Int32?)null : (Int32?)row["Id"];
						retObj._routeId					 = Convert.IsDBNull(row["RouteId"]) ? (Int32?)null : (Int32?)row["RouteId"];
						retObj._representativeId					 = Convert.IsDBNull(row["RepresentativeId"]) ? (Int32?)null : (Int32?)row["RepresentativeId"];
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
		///Int32? representativeId
		///</parameters>
		public static Int32 SelectAllByRepresentativeIdCount(Int32? representativeId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprRepresentative_Route_SelectAllByRepresentativeIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@RepresentativeId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)representativeId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table Representative_Route with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? representativeId
		///</parameters>
		public static void DeleteAllByRepresentativeId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? representativeId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprRepresentative_Route_DeleteAllByRepresentativeId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@RepresentativeId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)representativeId?? (object)DBNull.Value));

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
		///This method saves a new object to the table Representative_Route
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
			command.CommandText = InlineProcs.ctprRepresentative_Route_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@Id", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_id?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@RouteId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_routeId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@RepresentativeId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_representativeId?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_id					 = Convert.IsDBNull(command.Parameters["@Id"].Value) ? (Int32?)null : (Int32?)command.Parameters["@Id"].Value;
				_routeId					 = Convert.IsDBNull(command.Parameters["@RouteId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@RouteId"].Value;
				_representativeId					 = Convert.IsDBNull(command.Parameters["@RepresentativeId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@RepresentativeId"].Value;

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
		///This method returns all data rows in the table Representative_Route
		///</Summary>
		///<returns>
		///IList-DAORepresentativeRoute.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAORepresentativeRoute> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprRepresentative_Route_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Representative_Route");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAORepresentativeRoute> objList = new List<DAORepresentativeRoute>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAORepresentativeRoute retObj = new DAORepresentativeRoute();
						retObj._id					 = Convert.IsDBNull(row["Id"]) ? (Int32?)null : (Int32?)row["Id"];
						retObj._routeId					 = Convert.IsDBNull(row["RouteId"]) ? (Int32?)null : (Int32?)row["RouteId"];
						retObj._representativeId					 = Convert.IsDBNull(row["RepresentativeId"]) ? (Int32?)null : (Int32?)row["RepresentativeId"];
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
			command.CommandText = InlineProcs.ctprRepresentative_Route_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiRepresentative_Route
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprRepresentative_Route_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Representative_Route");
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
						if (string.Compare(projection.Member, "Id", true) == 0) lst.Add(Convert.IsDBNull(row["Id"]) ? (Int32?)null : (Int32?)row["Id"]);
						if (string.Compare(projection.Member, "RouteId", true) == 0) lst.Add(Convert.IsDBNull(row["RouteId"]) ? (Int32?)null : (Int32?)row["RouteId"]);
						if (string.Compare(projection.Member, "RepresentativeId", true) == 0) lst.Add(Convert.IsDBNull(row["RepresentativeId"]) ? (Int32?)null : (Int32?)row["RepresentativeId"]);
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
		///This method returns all data rows in the table using criteriaquery api Representative_Route
		///</Summary>
		///<returns>
		///IList-DAORepresentativeRoute.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAORepresentativeRoute> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprRepresentative_Route_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Representative_Route");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAORepresentativeRoute> objList = new List<DAORepresentativeRoute>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAORepresentativeRoute retObj = new DAORepresentativeRoute();
						retObj._id					 = Convert.IsDBNull(row["Id"]) ? (Int32?)null : (Int32?)row["Id"];
						retObj._routeId					 = Convert.IsDBNull(row["RouteId"]) ? (Int32?)null : (Int32?)row["RouteId"];
						retObj._representativeId					 = Convert.IsDBNull(row["RepresentativeId"]) ? (Int32?)null : (Int32?)row["RepresentativeId"];
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
		///This method returns all data rows in the table using criteriaquery api Representative_Route
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprRepresentative_Route_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table Representative_Route based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprRepresentative_Route_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@Id", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_id?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@RouteId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_routeId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@RepresentativeId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_representativeId?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_id					 = Convert.IsDBNull(command.Parameters["@Id"].Value) ? (Int32?)null : (Int32?)command.Parameters["@Id"].Value;
				_routeId					 = Convert.IsDBNull(command.Parameters["@RouteId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@RouteId"].Value;
				_representativeId					 = Convert.IsDBNull(command.Parameters["@RepresentativeId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@RepresentativeId"].Value;

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

		public Int32? Id
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
			}
		}

		public Int32? RouteId
		{
			get
			{
				return _routeId;
			}
			set
			{
				_routeId = value;
			}
		}

		public Int32? RepresentativeId
		{
			get
			{
				return _representativeId;
			}
			set
			{
				_representativeId = value;
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
		internal static string ctprRepresentative_Route_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[Id]
			,[RouteId]
			,[RepresentativeId]
			FROM [dbo].[Representative_Route]
			WHERE 
			[Id] = @Id
			";

		internal static string ctprRepresentative_Route_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[Representative_Route]
			WHERE 
			[Id] = @Id
			";

		internal static string ctprRepresentative_Route_SelectAllByRouteId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[Id]
			,[RouteId]
			,[RepresentativeId]
			FROM [dbo].[Representative_Route]
			WHERE 
			[RouteId] = @RouteId OR ([RouteId] IS NULL AND @RouteId IS NULL)
			";

		internal static string ctprRepresentative_Route_SelectAllByRouteIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Representative_Route]
			WHERE 
			[RouteId] = @RouteId OR ([RouteId] IS NULL AND @RouteId IS NULL)
			";

		internal static string ctprRepresentative_Route_DeleteAllByRouteId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[Representative_Route]
			WHERE 
			[RouteId] = @RouteId OR ([RouteId] IS NULL AND @RouteId IS NULL)
			";

		internal static string ctprRepresentative_Route_SelectAllByRepresentativeId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[Id]
			,[RouteId]
			,[RepresentativeId]
			FROM [dbo].[Representative_Route]
			WHERE 
			[RepresentativeId] = @RepresentativeId OR ([RepresentativeId] IS NULL AND @RepresentativeId IS NULL)
			";

		internal static string ctprRepresentative_Route_SelectAllByRepresentativeIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Representative_Route]
			WHERE 
			[RepresentativeId] = @RepresentativeId OR ([RepresentativeId] IS NULL AND @RepresentativeId IS NULL)
			";

		internal static string ctprRepresentative_Route_DeleteAllByRepresentativeId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[Representative_Route]
			WHERE 
			[RepresentativeId] = @RepresentativeId OR ([RepresentativeId] IS NULL AND @RepresentativeId IS NULL)
			";

		internal static string ctprRepresentative_Route_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[Representative_Route]
			(
			[Id]
			,[RouteId]
			,[RepresentativeId]
			)
			VALUES
			(
			@Id
			,@RouteId
			,@RepresentativeId
			)
			SELECT 
			@Id = [Id]
			,@RouteId = [RouteId]
			,@RepresentativeId = [RepresentativeId]
			FROM [dbo].[Representative_Route]
			WHERE 
			[Id] = @Id
			";

		internal static string ctprRepresentative_Route_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[Id]
			,[RouteId]
			,[RepresentativeId]
			FROM [dbo].[Representative_Route]
			";

		internal static string ctprRepresentative_Route_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Representative_Route]
			";

		internal static string ctprRepresentative_Route_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Representative_Route]
			##CRITERIA##
			";

		internal static string ctprRepresentative_Route_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[Id]
			,[RouteId]
			,[RepresentativeId]
			FROM [dbo].[Representative_Route]
			##CRITERIA##
			";

		internal static string ctprRepresentative_Route_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Representative_Route]
			##CRITERIA##
			";

		internal static string ctprRepresentative_Route_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[Representative_Route]
			SET
			[RouteId] = @RouteId
			,[RepresentativeId] = @RepresentativeId
			WHERE 
			[Id] = @Id
			SELECT 
			@Id = [Id]
			,@RouteId = [RouteId]
			,@RepresentativeId = [RepresentativeId]
			FROM [dbo].[Representative_Route]
			WHERE 
			[Id] = @Id
			";

	}
}
#endregion
