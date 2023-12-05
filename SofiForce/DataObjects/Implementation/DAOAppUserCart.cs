/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 9/9/2023 5:10:23 PM
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SofiForce.DataObjects.Interfaces;

namespace SofiForce.DataObjects
{
	public partial class DAOAppUserCart : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int64? _cartId;
		protected Int32? _userId;
		protected Int32? _itemId;
		protected Int32? _quantity;
		protected DateTime? _createDate;
		#endregion

		#region class methods
		public DAOAppUserCart()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table AppUser_Cart based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOAppUserCart
		///</returns>
		///<parameters>
		///Int64? cartId
		///</parameters>
		public static DAOAppUserCart SelectOne(Int64? cartId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_Cart_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_Cart");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@CartId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)cartId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOAppUserCart retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOAppUserCart();
					retObj._cartId					 = Convert.IsDBNull(dt.Rows[0]["CartId"]) ? (Int64?)null : (Int64?)dt.Rows[0]["CartId"];
					retObj._userId					 = Convert.IsDBNull(dt.Rows[0]["UserId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["UserId"];
					retObj._itemId					 = Convert.IsDBNull(dt.Rows[0]["ItemId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["ItemId"];
					retObj._quantity					 = Convert.IsDBNull(dt.Rows[0]["Quantity"]) ? (Int32?)null : (Int32?)dt.Rows[0]["Quantity"];
					retObj._createDate					 = Convert.IsDBNull(dt.Rows[0]["CreateDate"]) ? (DateTime?)null : (DateTime?)dt.Rows[0]["CreateDate"];
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
		///this method allows the object to delete itself from the table AppUser_Cart based on its primary key
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
			command.CommandText = InlineProcs.ctprAppUser_Cart_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@CartId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)_cartId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table AppUser_Cart based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOAppUserCart.
		///</returns>
		///<parameters>
		///Int32? userId
		///</parameters>
		public static IList<DAOAppUserCart> SelectAllByUserId(Int32? userId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_Cart_SelectAllByUserId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_Cart");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@UserId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)userId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserCart> objList = new List<DAOAppUserCart>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserCart retObj = new DAOAppUserCart();
						retObj._cartId					 = Convert.IsDBNull(row["CartId"]) ? (Int64?)null : (Int64?)row["CartId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._quantity					 = Convert.IsDBNull(row["Quantity"]) ? (Int32?)null : (Int32?)row["Quantity"];
						retObj._createDate					 = Convert.IsDBNull(row["CreateDate"]) ? (DateTime?)null : (DateTime?)row["CreateDate"];
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
			command.CommandText = InlineProcs.ctprAppUser_Cart_SelectAllByUserIdCount;
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
		///This method deletes all rows in the table AppUser_Cart with a given foreign key
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
			command.CommandText = InlineProcs.ctprAppUser_Cart_DeleteAllByUserId;
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
		///This method returns all data rows in the table AppUser_Cart based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOAppUserCart.
		///</returns>
		///<parameters>
		///Int32? itemId
		///</parameters>
		public static IList<DAOAppUserCart> SelectAllByItemId(Int32? itemId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_Cart_SelectAllByItemId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_Cart");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ItemId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)itemId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserCart> objList = new List<DAOAppUserCart>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserCart retObj = new DAOAppUserCart();
						retObj._cartId					 = Convert.IsDBNull(row["CartId"]) ? (Int64?)null : (Int64?)row["CartId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._quantity					 = Convert.IsDBNull(row["Quantity"]) ? (Int32?)null : (Int32?)row["Quantity"];
						retObj._createDate					 = Convert.IsDBNull(row["CreateDate"]) ? (DateTime?)null : (DateTime?)row["CreateDate"];
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
		///Int32? itemId
		///</parameters>
		public static Int32 SelectAllByItemIdCount(Int32? itemId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_Cart_SelectAllByItemIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ItemId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)itemId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table AppUser_Cart with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? itemId
		///</parameters>
		public static void DeleteAllByItemId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? itemId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_Cart_DeleteAllByItemId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ItemId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)itemId?? (object)DBNull.Value));

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
		///This method saves a new object to the table AppUser_Cart
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
			command.CommandText = InlineProcs.ctprAppUser_Cart_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@CartId", SqlDbType.BigInt, 8, ParameterDirection.Output, false, 19, 0, "", DataRowVersion.Proposed, _cartId));
				command.Parameters.Add(CtSqlParameter.Get("@UserId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_userId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ItemId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_itemId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Quantity", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_quantity?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CreateDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_createDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_cartId					 = Convert.IsDBNull(command.Parameters["@CartId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@CartId"].Value;
				_userId					 = Convert.IsDBNull(command.Parameters["@UserId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@UserId"].Value;
				_itemId					 = Convert.IsDBNull(command.Parameters["@ItemId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ItemId"].Value;
				_quantity					 = Convert.IsDBNull(command.Parameters["@Quantity"].Value) ? (Int32?)null : (Int32?)command.Parameters["@Quantity"].Value;
				_createDate					 = Convert.IsDBNull(command.Parameters["@CreateDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@CreateDate"].Value;

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
		///This method returns all data rows in the table AppUser_Cart
		///</Summary>
		///<returns>
		///IList-DAOAppUserCart.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOAppUserCart> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_Cart_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_Cart");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserCart> objList = new List<DAOAppUserCart>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserCart retObj = new DAOAppUserCart();
						retObj._cartId					 = Convert.IsDBNull(row["CartId"]) ? (Int64?)null : (Int64?)row["CartId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._quantity					 = Convert.IsDBNull(row["Quantity"]) ? (Int32?)null : (Int32?)row["Quantity"];
						retObj._createDate					 = Convert.IsDBNull(row["CreateDate"]) ? (DateTime?)null : (DateTime?)row["CreateDate"];
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
			command.CommandText = InlineProcs.ctprAppUser_Cart_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiAppUser_Cart
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUser_Cart_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_Cart");
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
						if (string.Compare(projection.Member, "CartId", true) == 0) lst.Add(Convert.IsDBNull(row["CartId"]) ? (Int64?)null : (Int64?)row["CartId"]);
						if (string.Compare(projection.Member, "UserId", true) == 0) lst.Add(Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"]);
						if (string.Compare(projection.Member, "ItemId", true) == 0) lst.Add(Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"]);
						if (string.Compare(projection.Member, "Quantity", true) == 0) lst.Add(Convert.IsDBNull(row["Quantity"]) ? (Int32?)null : (Int32?)row["Quantity"]);
						if (string.Compare(projection.Member, "CreateDate", true) == 0) lst.Add(Convert.IsDBNull(row["CreateDate"]) ? (DateTime?)null : (DateTime?)row["CreateDate"]);
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
		///This method returns all data rows in the table using criteriaquery api AppUser_Cart
		///</Summary>
		///<returns>
		///IList-DAOAppUserCart.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOAppUserCart> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUser_Cart_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_Cart");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserCart> objList = new List<DAOAppUserCart>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserCart retObj = new DAOAppUserCart();
						retObj._cartId					 = Convert.IsDBNull(row["CartId"]) ? (Int64?)null : (Int64?)row["CartId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._quantity					 = Convert.IsDBNull(row["Quantity"]) ? (Int32?)null : (Int32?)row["Quantity"];
						retObj._createDate					 = Convert.IsDBNull(row["CreateDate"]) ? (DateTime?)null : (DateTime?)row["CreateDate"];
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
		///This method returns all data rows in the table using criteriaquery api AppUser_Cart
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUser_Cart_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table AppUser_Cart based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprAppUser_Cart_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@CartId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, false, 19, 0, "", DataRowVersion.Proposed, (object)_cartId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@UserId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_userId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ItemId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_itemId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Quantity", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_quantity?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CreateDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_createDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_cartId					 = Convert.IsDBNull(command.Parameters["@CartId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@CartId"].Value;
				_userId					 = Convert.IsDBNull(command.Parameters["@UserId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@UserId"].Value;
				_itemId					 = Convert.IsDBNull(command.Parameters["@ItemId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ItemId"].Value;
				_quantity					 = Convert.IsDBNull(command.Parameters["@Quantity"].Value) ? (Int32?)null : (Int32?)command.Parameters["@Quantity"].Value;
				_createDate					 = Convert.IsDBNull(command.Parameters["@CreateDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@CreateDate"].Value;

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

		public Int64? CartId
		{
			get
			{
				return _cartId;
			}
			set
			{
				_cartId = value;
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

		public Int32? ItemId
		{
			get
			{
				return _itemId;
			}
			set
			{
				_itemId = value;
			}
		}

		public Int32? Quantity
		{
			get
			{
				return _quantity;
			}
			set
			{
				_quantity = value;
			}
		}

		public DateTime? CreateDate
		{
			get
			{
				return _createDate;
			}
			set
			{
				_createDate = value;
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
		internal static string ctprAppUser_Cart_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[CartId]
			,[UserId]
			,[ItemId]
			,[Quantity]
			,[CreateDate]
			FROM [dbo].[AppUser_Cart]
			WHERE 
			[CartId] = @CartId
			";

		internal static string ctprAppUser_Cart_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[AppUser_Cart]
			WHERE 
			[CartId] = @CartId
			";

		internal static string ctprAppUser_Cart_SelectAllByUserId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[CartId]
			,[UserId]
			,[ItemId]
			,[Quantity]
			,[CreateDate]
			FROM [dbo].[AppUser_Cart]
			WHERE 
			[UserId] = @UserId OR ([UserId] IS NULL AND @UserId IS NULL)
			";

		internal static string ctprAppUser_Cart_SelectAllByUserIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[AppUser_Cart]
			WHERE 
			[UserId] = @UserId OR ([UserId] IS NULL AND @UserId IS NULL)
			";

		internal static string ctprAppUser_Cart_DeleteAllByUserId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[AppUser_Cart]
			WHERE 
			[UserId] = @UserId OR ([UserId] IS NULL AND @UserId IS NULL)
			";

		internal static string ctprAppUser_Cart_SelectAllByItemId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[CartId]
			,[UserId]
			,[ItemId]
			,[Quantity]
			,[CreateDate]
			FROM [dbo].[AppUser_Cart]
			WHERE 
			[ItemId] = @ItemId OR ([ItemId] IS NULL AND @ItemId IS NULL)
			";

		internal static string ctprAppUser_Cart_SelectAllByItemIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[AppUser_Cart]
			WHERE 
			[ItemId] = @ItemId OR ([ItemId] IS NULL AND @ItemId IS NULL)
			";

		internal static string ctprAppUser_Cart_DeleteAllByItemId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[AppUser_Cart]
			WHERE 
			[ItemId] = @ItemId OR ([ItemId] IS NULL AND @ItemId IS NULL)
			";

		internal static string ctprAppUser_Cart_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[AppUser_Cart]
			(
			[UserId]
			,[ItemId]
			,[Quantity]
			,[CreateDate]
			)
			VALUES
			(
			@UserId
			,@ItemId
			,@Quantity
			,@CreateDate
			)
			SELECT 
			@CartId = [CartId]
			,@UserId = [UserId]
			,@ItemId = [ItemId]
			,@Quantity = [Quantity]
			,@CreateDate = [CreateDate]
			FROM [dbo].[AppUser_Cart]
			WHERE 
			[CartId] = SCOPE_IDENTITY()
			";

		internal static string ctprAppUser_Cart_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[CartId]
			,[UserId]
			,[ItemId]
			,[Quantity]
			,[CreateDate]
			FROM [dbo].[AppUser_Cart]
			";

		internal static string ctprAppUser_Cart_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[AppUser_Cart]
			";

		internal static string ctprAppUser_Cart_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[AppUser_Cart]
			##CRITERIA##
			";

		internal static string ctprAppUser_Cart_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[CartId]
			,[UserId]
			,[ItemId]
			,[Quantity]
			,[CreateDate]
			FROM [dbo].[AppUser_Cart]
			##CRITERIA##
			";

		internal static string ctprAppUser_Cart_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[AppUser_Cart]
			##CRITERIA##
			";

		internal static string ctprAppUser_Cart_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[AppUser_Cart]
			SET
			[UserId] = @UserId
			,[ItemId] = @ItemId
			,[Quantity] = @Quantity
			,[CreateDate] = @CreateDate
			WHERE 
			[CartId] = @CartId
			SELECT 
			@CartId = [CartId]
			,@UserId = [UserId]
			,@ItemId = [ItemId]
			,@Quantity = [Quantity]
			,@CreateDate = [CreateDate]
			FROM [dbo].[AppUser_Cart]
			WHERE 
			[CartId] = @CartId
			";

	}
}
#endregion
