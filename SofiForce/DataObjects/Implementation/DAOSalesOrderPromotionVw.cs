/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 4/7/2023 11:07:36 PM
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SofiForce.DataObjects.Interfaces;

namespace SofiForce.DataObjects
{
	public partial class DAOSalesOrderPromotionVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _promotionId;
		protected Int64? _salesId;
		protected Int32? _clientId;
		protected DateTime? _salesDate;
		#endregion

		#region class methods
		public DAOSalesOrderPromotionVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table SalesOrder_PromotionVw
		///</Summary>
		///<returns>
		///IList-DAOSalesOrderPromotionVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOSalesOrderPromotionVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesOrder_PromotionVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_PromotionVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSalesOrderPromotionVw> objList = new List<DAOSalesOrderPromotionVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSalesOrderPromotionVw retObj = new DAOSalesOrderPromotionVw();
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._salesId					 = Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._salesDate					 = Convert.IsDBNull(row["SalesDate"]) ? (DateTime?)null : (DateTime?)row["SalesDate"];
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
			command.CommandText = InlineProcs.ctprSalesOrder_PromotionVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiSalesOrder_PromotionVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesOrder_PromotionVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_PromotionVw");
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
						if (string.Compare(projection.Member, "PromotionId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"]);
						if (string.Compare(projection.Member, "SalesId", true) == 0) lst.Add(Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"]);
						if (string.Compare(projection.Member, "ClientId", true) == 0) lst.Add(Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"]);
						if (string.Compare(projection.Member, "SalesDate", true) == 0) lst.Add(Convert.IsDBNull(row["SalesDate"]) ? (DateTime?)null : (DateTime?)row["SalesDate"]);
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
		///This method returns all data rows in the table using criteriaquery api SalesOrder_PromotionVw
		///</Summary>
		///<returns>
		///IList-DAOSalesOrderPromotionVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOSalesOrderPromotionVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesOrder_PromotionVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_PromotionVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSalesOrderPromotionVw> objList = new List<DAOSalesOrderPromotionVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSalesOrderPromotionVw retObj = new DAOSalesOrderPromotionVw();
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._salesId					 = Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._salesDate					 = Convert.IsDBNull(row["SalesDate"]) ? (DateTime?)null : (DateTime?)row["SalesDate"];
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
		///This method returns all data rows in the table using criteriaquery api SalesOrder_PromotionVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesOrder_PromotionVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		#endregion

		#region member properties

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

		public Int32? ClientId
		{
			get
			{
				return _clientId;
			}
			set
			{
				_clientId = value;
			}
		}

		public DateTime? SalesDate
		{
			get
			{
				return _salesDate;
			}
			set
			{
				_salesDate = value;
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
		internal static string ctprSalesOrder_PromotionVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[PromotionId]
			,[SalesId]
			,[ClientId]
			,[SalesDate]
			FROM [dbo].[SalesOrder_PromotionVw]
			";

		internal static string ctprSalesOrder_PromotionVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[SalesOrder_PromotionVw]
			";

		internal static string ctprSalesOrder_PromotionVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[SalesOrder_PromotionVw]
			##CRITERIA##
			";

		internal static string ctprSalesOrder_PromotionVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[PromotionId]
			,[SalesId]
			,[ClientId]
			,[SalesDate]
			FROM [dbo].[SalesOrder_PromotionVw]
			##CRITERIA##
			";

		internal static string ctprSalesOrder_PromotionVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[SalesOrder_PromotionVw]
			##CRITERIA##
			";

	}
}
#endregion
