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
	public partial class DAOClientTransactionVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int64? _transactionId;
		protected Int32? _clientId;
		protected Int32? _transactionTypeId;
		protected string _transactionCode;
		protected DateTime? _transactionDate;
		protected decimal? _transactionValue;
		protected string _transactionTypeNameAr;
		protected string _transactionTypeNameEn;
		#endregion

		#region class methods
		public DAOClientTransactionVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table Client_TransactionVw
		///</Summary>
		///<returns>
		///IList-DAOClientTransactionVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOClientTransactionVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_TransactionVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_TransactionVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientTransactionVw> objList = new List<DAOClientTransactionVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientTransactionVw retObj = new DAOClientTransactionVw();
						retObj._transactionId					 = Convert.IsDBNull(row["TransactionId"]) ? (Int64?)null : (Int64?)row["TransactionId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._transactionTypeId					 = Convert.IsDBNull(row["TransactionTypeId"]) ? (Int32?)null : (Int32?)row["TransactionTypeId"];
						retObj._transactionCode					 = Convert.IsDBNull(row["TransactionCode"]) ? null : (string)row["TransactionCode"];
						retObj._transactionDate					 = Convert.IsDBNull(row["TransactionDate"]) ? (DateTime?)null : (DateTime?)row["TransactionDate"];
						retObj._transactionValue					 = Convert.IsDBNull(row["TransactionValue"]) ? (decimal?)null : (decimal?)row["TransactionValue"];
						retObj._transactionTypeNameAr					 = Convert.IsDBNull(row["TransactionTypeNameAr"]) ? null : (string)row["TransactionTypeNameAr"];
						retObj._transactionTypeNameEn					 = Convert.IsDBNull(row["TransactionTypeNameEn"]) ? null : (string)row["TransactionTypeNameEn"];
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
			command.CommandText = InlineProcs.ctprClient_TransactionVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiClient_TransactionVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_TransactionVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_TransactionVw");
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
						if (string.Compare(projection.Member, "TransactionId", true) == 0) lst.Add(Convert.IsDBNull(row["TransactionId"]) ? (Int64?)null : (Int64?)row["TransactionId"]);
						if (string.Compare(projection.Member, "ClientId", true) == 0) lst.Add(Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"]);
						if (string.Compare(projection.Member, "TransactionTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["TransactionTypeId"]) ? (Int32?)null : (Int32?)row["TransactionTypeId"]);
						if (string.Compare(projection.Member, "TransactionCode", true) == 0) lst.Add(Convert.IsDBNull(row["TransactionCode"]) ? null : (string)row["TransactionCode"]);
						if (string.Compare(projection.Member, "TransactionDate", true) == 0) lst.Add(Convert.IsDBNull(row["TransactionDate"]) ? (DateTime?)null : (DateTime?)row["TransactionDate"]);
						if (string.Compare(projection.Member, "TransactionValue", true) == 0) lst.Add(Convert.IsDBNull(row["TransactionValue"]) ? (decimal?)null : (decimal?)row["TransactionValue"]);
						if (string.Compare(projection.Member, "TransactionTypeNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["TransactionTypeNameAr"]) ? null : (string)row["TransactionTypeNameAr"]);
						if (string.Compare(projection.Member, "TransactionTypeNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["TransactionTypeNameEn"]) ? null : (string)row["TransactionTypeNameEn"]);
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
		///This method returns all data rows in the table using criteriaquery api Client_TransactionVw
		///</Summary>
		///<returns>
		///IList-DAOClientTransactionVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOClientTransactionVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_TransactionVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_TransactionVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientTransactionVw> objList = new List<DAOClientTransactionVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientTransactionVw retObj = new DAOClientTransactionVw();
						retObj._transactionId					 = Convert.IsDBNull(row["TransactionId"]) ? (Int64?)null : (Int64?)row["TransactionId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._transactionTypeId					 = Convert.IsDBNull(row["TransactionTypeId"]) ? (Int32?)null : (Int32?)row["TransactionTypeId"];
						retObj._transactionCode					 = Convert.IsDBNull(row["TransactionCode"]) ? null : (string)row["TransactionCode"];
						retObj._transactionDate					 = Convert.IsDBNull(row["TransactionDate"]) ? (DateTime?)null : (DateTime?)row["TransactionDate"];
						retObj._transactionValue					 = Convert.IsDBNull(row["TransactionValue"]) ? (decimal?)null : (decimal?)row["TransactionValue"];
						retObj._transactionTypeNameAr					 = Convert.IsDBNull(row["TransactionTypeNameAr"]) ? null : (string)row["TransactionTypeNameAr"];
						retObj._transactionTypeNameEn					 = Convert.IsDBNull(row["TransactionTypeNameEn"]) ? null : (string)row["TransactionTypeNameEn"];
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
		///This method returns all data rows in the table using criteriaquery api Client_TransactionVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_TransactionVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public Int64? TransactionId
		{
			get
			{
				return _transactionId;
			}
			set
			{
				_transactionId = value;
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

		public Int32? TransactionTypeId
		{
			get
			{
				return _transactionTypeId;
			}
			set
			{
				_transactionTypeId = value;
			}
		}

		public string TransactionCode
		{
			get
			{
				return _transactionCode;
			}
			set
			{
				_transactionCode = value;
			}
		}

		public DateTime? TransactionDate
		{
			get
			{
				return _transactionDate;
			}
			set
			{
				_transactionDate = value;
			}
		}

		public decimal? TransactionValue
		{
			get
			{
				return _transactionValue;
			}
			set
			{
				_transactionValue = value;
			}
		}

		public string TransactionTypeNameAr
		{
			get
			{
				return _transactionTypeNameAr;
			}
			set
			{
				_transactionTypeNameAr = value;
			}
		}

		public string TransactionTypeNameEn
		{
			get
			{
				return _transactionTypeNameEn;
			}
			set
			{
				_transactionTypeNameEn = value;
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
		internal static string ctprClient_TransactionVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[TransactionId]
			,[ClientId]
			,[TransactionTypeId]
			,[TransactionCode]
			,[TransactionDate]
			,[TransactionValue]
			,[TransactionTypeNameAr]
			,[TransactionTypeNameEn]
			FROM [dbo].[Client_TransactionVw]
			";

		internal static string ctprClient_TransactionVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_TransactionVw]
			";

		internal static string ctprClient_TransactionVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Client_TransactionVw]
			##CRITERIA##
			";

		internal static string ctprClient_TransactionVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[TransactionId]
			,[ClientId]
			,[TransactionTypeId]
			,[TransactionCode]
			,[TransactionDate]
			,[TransactionValue]
			,[TransactionTypeNameAr]
			,[TransactionTypeNameEn]
			FROM [dbo].[Client_TransactionVw]
			##CRITERIA##
			";

		internal static string ctprClient_TransactionVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Client_TransactionVw]
			##CRITERIA##
			";

	}
}
#endregion
