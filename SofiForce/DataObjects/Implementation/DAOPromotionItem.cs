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
	public partial class DAOPromotionItem : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int64? _promotionItemId;
		protected Int32? _promotionId;
		protected string _itemCode;
		protected Int32? _groupId;
		#endregion

		#region class methods
		public DAOPromotionItem()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table PromotionItem based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOPromotionItem
		///</returns>
		///<parameters>
		///Int64? promotionItemId
		///</parameters>
		public static DAOPromotionItem SelectOne(Int64? promotionItemId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprPromotionItem_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromotionItem");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PromotionItemId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)promotionItemId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOPromotionItem retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOPromotionItem();
					retObj._promotionItemId					 = Convert.IsDBNull(dt.Rows[0]["PromotionItemId"]) ? (Int64?)null : (Int64?)dt.Rows[0]["PromotionItemId"];
					retObj._promotionId					 = Convert.IsDBNull(dt.Rows[0]["PromotionId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["PromotionId"];
					retObj._itemCode					 = Convert.IsDBNull(dt.Rows[0]["ItemCode"]) ? null : (string)dt.Rows[0]["ItemCode"];
					retObj._groupId					 = Convert.IsDBNull(dt.Rows[0]["GroupId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["GroupId"];
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
		///this method allows the object to delete itself from the table PromotionItem based on its primary key
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
			command.CommandText = InlineProcs.ctprPromotionItem_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PromotionItemId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)_promotionItemId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table PromotionItem based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOPromotionItem.
		///</returns>
		///<parameters>
		///Int32? promotionId
		///</parameters>
		public static IList<DAOPromotionItem> SelectAllByPromotionId(Int32? promotionId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprPromotionItem_SelectAllByPromotionId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromotionItem");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PromotionId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)promotionId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOPromotionItem> objList = new List<DAOPromotionItem>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOPromotionItem retObj = new DAOPromotionItem();
						retObj._promotionItemId					 = Convert.IsDBNull(row["PromotionItemId"]) ? (Int64?)null : (Int64?)row["PromotionItemId"];
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._itemCode					 = Convert.IsDBNull(row["ItemCode"]) ? null : (string)row["ItemCode"];
						retObj._groupId					 = Convert.IsDBNull(row["GroupId"]) ? (Int32?)null : (Int32?)row["GroupId"];
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
		///Int32? promotionId
		///</parameters>
		public static Int32 SelectAllByPromotionIdCount(Int32? promotionId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprPromotionItem_SelectAllByPromotionIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PromotionId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)promotionId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table PromotionItem with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? promotionId
		///</parameters>
		public static void DeleteAllByPromotionId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? promotionId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprPromotionItem_DeleteAllByPromotionId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PromotionId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)promotionId?? (object)DBNull.Value));

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
		///This method saves a new object to the table PromotionItem
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
			command.CommandText = InlineProcs.ctprPromotionItem_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PromotionItemId", SqlDbType.BigInt, 8, ParameterDirection.Output, false, 19, 0, "", DataRowVersion.Proposed, _promotionItemId));
				command.Parameters.Add(CtSqlParameter.Get("@PromotionId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_promotionId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ItemCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_itemCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@GroupId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_groupId?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_promotionItemId					 = Convert.IsDBNull(command.Parameters["@PromotionItemId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@PromotionItemId"].Value;
				_promotionId					 = Convert.IsDBNull(command.Parameters["@PromotionId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@PromotionId"].Value;
				_itemCode					 = Convert.IsDBNull(command.Parameters["@ItemCode"].Value) ? null : (string)command.Parameters["@ItemCode"].Value;
				_groupId					 = Convert.IsDBNull(command.Parameters["@GroupId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@GroupId"].Value;

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
		///This method returns all data rows in the table PromotionItem
		///</Summary>
		///<returns>
		///IList-DAOPromotionItem.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOPromotionItem> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprPromotionItem_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromotionItem");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOPromotionItem> objList = new List<DAOPromotionItem>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOPromotionItem retObj = new DAOPromotionItem();
						retObj._promotionItemId					 = Convert.IsDBNull(row["PromotionItemId"]) ? (Int64?)null : (Int64?)row["PromotionItemId"];
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._itemCode					 = Convert.IsDBNull(row["ItemCode"]) ? null : (string)row["ItemCode"];
						retObj._groupId					 = Convert.IsDBNull(row["GroupId"]) ? (Int32?)null : (Int32?)row["GroupId"];
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
			command.CommandText = InlineProcs.ctprPromotionItem_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiPromotionItem
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromotionItem_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromotionItem");
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
						if (string.Compare(projection.Member, "PromotionItemId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionItemId"]) ? (Int64?)null : (Int64?)row["PromotionItemId"]);
						if (string.Compare(projection.Member, "PromotionId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"]);
						if (string.Compare(projection.Member, "ItemCode", true) == 0) lst.Add(Convert.IsDBNull(row["ItemCode"]) ? null : (string)row["ItemCode"]);
						if (string.Compare(projection.Member, "GroupId", true) == 0) lst.Add(Convert.IsDBNull(row["GroupId"]) ? (Int32?)null : (Int32?)row["GroupId"]);
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
		///This method returns all data rows in the table using criteriaquery api PromotionItem
		///</Summary>
		///<returns>
		///IList-DAOPromotionItem.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOPromotionItem> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromotionItem_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromotionItem");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOPromotionItem> objList = new List<DAOPromotionItem>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOPromotionItem retObj = new DAOPromotionItem();
						retObj._promotionItemId					 = Convert.IsDBNull(row["PromotionItemId"]) ? (Int64?)null : (Int64?)row["PromotionItemId"];
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._itemCode					 = Convert.IsDBNull(row["ItemCode"]) ? null : (string)row["ItemCode"];
						retObj._groupId					 = Convert.IsDBNull(row["GroupId"]) ? (Int32?)null : (Int32?)row["GroupId"];
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
		///This method returns all data rows in the table using criteriaquery api PromotionItem
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromotionItem_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table PromotionItem based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprPromotionItem_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PromotionItemId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, false, 19, 0, "", DataRowVersion.Proposed, (object)_promotionItemId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@PromotionId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_promotionId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ItemCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_itemCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@GroupId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_groupId?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_promotionItemId					 = Convert.IsDBNull(command.Parameters["@PromotionItemId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@PromotionItemId"].Value;
				_promotionId					 = Convert.IsDBNull(command.Parameters["@PromotionId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@PromotionId"].Value;
				_itemCode					 = Convert.IsDBNull(command.Parameters["@ItemCode"].Value) ? null : (string)command.Parameters["@ItemCode"].Value;
				_groupId					 = Convert.IsDBNull(command.Parameters["@GroupId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@GroupId"].Value;

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

		public Int64? PromotionItemId
		{
			get
			{
				return _promotionItemId;
			}
			set
			{
				_promotionItemId = value;
			}
		}

		public Int32? PromotionId
		{
			get
			{
				return _promotionId;
			}
			set
			{
				_promotionId = value;
			}
		}

		public string ItemCode
		{
			get
			{
				return _itemCode;
			}
			set
			{
				_itemCode = value;
			}
		}

		public Int32? GroupId
		{
			get
			{
				return _groupId;
			}
			set
			{
				_groupId = value;
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
		internal static string ctprPromotionItem_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[PromotionItemId]
			,[PromotionId]
			,[ItemCode]
			,[GroupId]
			FROM [dbo].[PromotionItem]
			WHERE 
			[PromotionItemId] = @PromotionItemId
			";

		internal static string ctprPromotionItem_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[PromotionItem]
			WHERE 
			[PromotionItemId] = @PromotionItemId
			";

		internal static string ctprPromotionItem_SelectAllByPromotionId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[PromotionItemId]
			,[PromotionId]
			,[ItemCode]
			,[GroupId]
			FROM [dbo].[PromotionItem]
			WHERE 
			[PromotionId] = @PromotionId OR ([PromotionId] IS NULL AND @PromotionId IS NULL)
			";

		internal static string ctprPromotionItem_SelectAllByPromotionIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[PromotionItem]
			WHERE 
			[PromotionId] = @PromotionId OR ([PromotionId] IS NULL AND @PromotionId IS NULL)
			";

		internal static string ctprPromotionItem_DeleteAllByPromotionId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[PromotionItem]
			WHERE 
			[PromotionId] = @PromotionId OR ([PromotionId] IS NULL AND @PromotionId IS NULL)
			";

		internal static string ctprPromotionItem_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[PromotionItem]
			(
			[PromotionId]
			,[ItemCode]
			,[GroupId]
			)
			VALUES
			(
			@PromotionId
			,@ItemCode
			,@GroupId
			)
			SELECT 
			@PromotionItemId = [PromotionItemId]
			,@PromotionId = [PromotionId]
			,@ItemCode = [ItemCode]
			,@GroupId = [GroupId]
			FROM [dbo].[PromotionItem]
			WHERE 
			[PromotionItemId] = SCOPE_IDENTITY()
			";

		internal static string ctprPromotionItem_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[PromotionItemId]
			,[PromotionId]
			,[ItemCode]
			,[GroupId]
			FROM [dbo].[PromotionItem]
			";

		internal static string ctprPromotionItem_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[PromotionItem]
			";

		internal static string ctprPromotionItem_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[PromotionItem]
			##CRITERIA##
			";

		internal static string ctprPromotionItem_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[PromotionItemId]
			,[PromotionId]
			,[ItemCode]
			,[GroupId]
			FROM [dbo].[PromotionItem]
			##CRITERIA##
			";

		internal static string ctprPromotionItem_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[PromotionItem]
			##CRITERIA##
			";

		internal static string ctprPromotionItem_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[PromotionItem]
			SET
			[PromotionId] = @PromotionId
			,[ItemCode] = @ItemCode
			,[GroupId] = @GroupId
			WHERE 
			[PromotionItemId] = @PromotionItemId
			SELECT 
			@PromotionItemId = [PromotionItemId]
			,@PromotionId = [PromotionId]
			,@ItemCode = [ItemCode]
			,@GroupId = [GroupId]
			FROM [dbo].[PromotionItem]
			WHERE 
			[PromotionItemId] = @PromotionItemId
			";

	}
}
#endregion
