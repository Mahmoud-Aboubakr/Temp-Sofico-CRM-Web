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
	public partial class DAOClientPlanVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _clientId;
		protected string _clientCode;
		protected string _clientNameAr;
		protected string _clientNameEn;
		protected Int32? _branchId;
		protected string _branchNameEn;
		protected string _branchNameAr;
		protected string _branchCode;
		protected Int32? _clientTypeId;
		protected decimal? _creditLimit;
		protected decimal? _creditBalance;
		protected Int64? _planId;
		protected decimal? _targetValue;
		protected Int32? _targetVisit;
		protected Int32? _targetCall;
		protected DateTime? _targetDate;
		protected string _clientGroupCode;
		protected string _clientGroupNameEn;
		protected string _clientGroupNameAr;
		protected Int32? _businessUnitId;
		protected Int32? _clientGroupId;
		protected Int32? _clientGroupSubId;
		#endregion

		#region class methods
		public DAOClientPlanVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table Client_planVw
		///</Summary>
		///<returns>
		///IList-DAOClientPlanVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOClientPlanVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_planVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_planVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientPlanVw> objList = new List<DAOClientPlanVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientPlanVw retObj = new DAOClientPlanVw();
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._clientCode					 = Convert.IsDBNull(row["ClientCode"]) ? null : (string)row["ClientCode"];
						retObj._clientNameAr					 = Convert.IsDBNull(row["ClientNameAr"]) ? null : (string)row["ClientNameAr"];
						retObj._clientNameEn					 = Convert.IsDBNull(row["ClientNameEn"]) ? null : (string)row["ClientNameEn"];
						retObj._branchId					 = Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"];
						retObj._branchNameEn					 = Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"];
						retObj._branchNameAr					 = Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"];
						retObj._branchCode					 = Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"];
						retObj._clientTypeId					 = Convert.IsDBNull(row["ClientTypeId"]) ? (Int32?)null : (Int32?)row["ClientTypeId"];
						retObj._creditLimit					 = Convert.IsDBNull(row["CreditLimit"]) ? (decimal?)null : (decimal?)row["CreditLimit"];
						retObj._creditBalance					 = Convert.IsDBNull(row["CreditBalance"]) ? (decimal?)null : (decimal?)row["CreditBalance"];
						retObj._planId					 = Convert.IsDBNull(row["PlanId"]) ? (Int64?)null : (Int64?)row["PlanId"];
						retObj._targetValue					 = Convert.IsDBNull(row["TargetValue"]) ? (decimal?)null : (decimal?)row["TargetValue"];
						retObj._targetVisit					 = Convert.IsDBNull(row["TargetVisit"]) ? (Int32?)null : (Int32?)row["TargetVisit"];
						retObj._targetCall					 = Convert.IsDBNull(row["TargetCall"]) ? (Int32?)null : (Int32?)row["TargetCall"];
						retObj._targetDate					 = Convert.IsDBNull(row["TargetDate"]) ? (DateTime?)null : (DateTime?)row["TargetDate"];
						retObj._clientGroupCode					 = Convert.IsDBNull(row["ClientGroupCode"]) ? null : (string)row["ClientGroupCode"];
						retObj._clientGroupNameEn					 = Convert.IsDBNull(row["ClientGroupNameEn"]) ? null : (string)row["ClientGroupNameEn"];
						retObj._clientGroupNameAr					 = Convert.IsDBNull(row["ClientGroupNameAr"]) ? null : (string)row["ClientGroupNameAr"];
						retObj._businessUnitId					 = Convert.IsDBNull(row["BusinessUnitId"]) ? (Int32?)null : (Int32?)row["BusinessUnitId"];
						retObj._clientGroupId					 = Convert.IsDBNull(row["ClientGroupId"]) ? (Int32?)null : (Int32?)row["ClientGroupId"];
						retObj._clientGroupSubId					 = Convert.IsDBNull(row["ClientGroupSubId"]) ? (Int32?)null : (Int32?)row["ClientGroupSubId"];
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
			command.CommandText = InlineProcs.ctprClient_planVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiClient_planVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_planVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_planVw");
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
						if (string.Compare(projection.Member, "ClientId", true) == 0) lst.Add(Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"]);
						if (string.Compare(projection.Member, "ClientCode", true) == 0) lst.Add(Convert.IsDBNull(row["ClientCode"]) ? null : (string)row["ClientCode"]);
						if (string.Compare(projection.Member, "ClientNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["ClientNameAr"]) ? null : (string)row["ClientNameAr"]);
						if (string.Compare(projection.Member, "ClientNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["ClientNameEn"]) ? null : (string)row["ClientNameEn"]);
						if (string.Compare(projection.Member, "BranchId", true) == 0) lst.Add(Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"]);
						if (string.Compare(projection.Member, "BranchNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"]);
						if (string.Compare(projection.Member, "BranchNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"]);
						if (string.Compare(projection.Member, "BranchCode", true) == 0) lst.Add(Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"]);
						if (string.Compare(projection.Member, "ClientTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["ClientTypeId"]) ? (Int32?)null : (Int32?)row["ClientTypeId"]);
						if (string.Compare(projection.Member, "CreditLimit", true) == 0) lst.Add(Convert.IsDBNull(row["CreditLimit"]) ? (decimal?)null : (decimal?)row["CreditLimit"]);
						if (string.Compare(projection.Member, "CreditBalance", true) == 0) lst.Add(Convert.IsDBNull(row["CreditBalance"]) ? (decimal?)null : (decimal?)row["CreditBalance"]);
						if (string.Compare(projection.Member, "PlanId", true) == 0) lst.Add(Convert.IsDBNull(row["PlanId"]) ? (Int64?)null : (Int64?)row["PlanId"]);
						if (string.Compare(projection.Member, "TargetValue", true) == 0) lst.Add(Convert.IsDBNull(row["TargetValue"]) ? (decimal?)null : (decimal?)row["TargetValue"]);
						if (string.Compare(projection.Member, "TargetVisit", true) == 0) lst.Add(Convert.IsDBNull(row["TargetVisit"]) ? (Int32?)null : (Int32?)row["TargetVisit"]);
						if (string.Compare(projection.Member, "TargetCall", true) == 0) lst.Add(Convert.IsDBNull(row["TargetCall"]) ? (Int32?)null : (Int32?)row["TargetCall"]);
						if (string.Compare(projection.Member, "TargetDate", true) == 0) lst.Add(Convert.IsDBNull(row["TargetDate"]) ? (DateTime?)null : (DateTime?)row["TargetDate"]);
						if (string.Compare(projection.Member, "ClientGroupCode", true) == 0) lst.Add(Convert.IsDBNull(row["ClientGroupCode"]) ? null : (string)row["ClientGroupCode"]);
						if (string.Compare(projection.Member, "ClientGroupNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["ClientGroupNameEn"]) ? null : (string)row["ClientGroupNameEn"]);
						if (string.Compare(projection.Member, "ClientGroupNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["ClientGroupNameAr"]) ? null : (string)row["ClientGroupNameAr"]);
						if (string.Compare(projection.Member, "BusinessUnitId", true) == 0) lst.Add(Convert.IsDBNull(row["BusinessUnitId"]) ? (Int32?)null : (Int32?)row["BusinessUnitId"]);
						if (string.Compare(projection.Member, "ClientGroupId", true) == 0) lst.Add(Convert.IsDBNull(row["ClientGroupId"]) ? (Int32?)null : (Int32?)row["ClientGroupId"]);
						if (string.Compare(projection.Member, "ClientGroupSubId", true) == 0) lst.Add(Convert.IsDBNull(row["ClientGroupSubId"]) ? (Int32?)null : (Int32?)row["ClientGroupSubId"]);
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
		///This method returns all data rows in the table using criteriaquery api Client_planVw
		///</Summary>
		///<returns>
		///IList-DAOClientPlanVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOClientPlanVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_planVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_planVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientPlanVw> objList = new List<DAOClientPlanVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientPlanVw retObj = new DAOClientPlanVw();
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._clientCode					 = Convert.IsDBNull(row["ClientCode"]) ? null : (string)row["ClientCode"];
						retObj._clientNameAr					 = Convert.IsDBNull(row["ClientNameAr"]) ? null : (string)row["ClientNameAr"];
						retObj._clientNameEn					 = Convert.IsDBNull(row["ClientNameEn"]) ? null : (string)row["ClientNameEn"];
						retObj._branchId					 = Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"];
						retObj._branchNameEn					 = Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"];
						retObj._branchNameAr					 = Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"];
						retObj._branchCode					 = Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"];
						retObj._clientTypeId					 = Convert.IsDBNull(row["ClientTypeId"]) ? (Int32?)null : (Int32?)row["ClientTypeId"];
						retObj._creditLimit					 = Convert.IsDBNull(row["CreditLimit"]) ? (decimal?)null : (decimal?)row["CreditLimit"];
						retObj._creditBalance					 = Convert.IsDBNull(row["CreditBalance"]) ? (decimal?)null : (decimal?)row["CreditBalance"];
						retObj._planId					 = Convert.IsDBNull(row["PlanId"]) ? (Int64?)null : (Int64?)row["PlanId"];
						retObj._targetValue					 = Convert.IsDBNull(row["TargetValue"]) ? (decimal?)null : (decimal?)row["TargetValue"];
						retObj._targetVisit					 = Convert.IsDBNull(row["TargetVisit"]) ? (Int32?)null : (Int32?)row["TargetVisit"];
						retObj._targetCall					 = Convert.IsDBNull(row["TargetCall"]) ? (Int32?)null : (Int32?)row["TargetCall"];
						retObj._targetDate					 = Convert.IsDBNull(row["TargetDate"]) ? (DateTime?)null : (DateTime?)row["TargetDate"];
						retObj._clientGroupCode					 = Convert.IsDBNull(row["ClientGroupCode"]) ? null : (string)row["ClientGroupCode"];
						retObj._clientGroupNameEn					 = Convert.IsDBNull(row["ClientGroupNameEn"]) ? null : (string)row["ClientGroupNameEn"];
						retObj._clientGroupNameAr					 = Convert.IsDBNull(row["ClientGroupNameAr"]) ? null : (string)row["ClientGroupNameAr"];
						retObj._businessUnitId					 = Convert.IsDBNull(row["BusinessUnitId"]) ? (Int32?)null : (Int32?)row["BusinessUnitId"];
						retObj._clientGroupId					 = Convert.IsDBNull(row["ClientGroupId"]) ? (Int32?)null : (Int32?)row["ClientGroupId"];
						retObj._clientGroupSubId					 = Convert.IsDBNull(row["ClientGroupSubId"]) ? (Int32?)null : (Int32?)row["ClientGroupSubId"];
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
		///This method returns all data rows in the table using criteriaquery api Client_planVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_planVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public string ClientCode
		{
			get
			{
				return _clientCode;
			}
			set
			{
				_clientCode = value;
			}
		}

		public string ClientNameAr
		{
			get
			{
				return _clientNameAr;
			}
			set
			{
				_clientNameAr = value;
			}
		}

		public string ClientNameEn
		{
			get
			{
				return _clientNameEn;
			}
			set
			{
				_clientNameEn = value;
			}
		}

		public Int32? BranchId
		{
			get
			{
				return _branchId;
			}
			set
			{
				_branchId = value;
			}
		}

		public string BranchNameEn
		{
			get
			{
				return _branchNameEn;
			}
			set
			{
				_branchNameEn = value;
			}
		}

		public string BranchNameAr
		{
			get
			{
				return _branchNameAr;
			}
			set
			{
				_branchNameAr = value;
			}
		}

		public string BranchCode
		{
			get
			{
				return _branchCode;
			}
			set
			{
				_branchCode = value;
			}
		}

		public Int32? ClientTypeId
		{
			get
			{
				return _clientTypeId;
			}
			set
			{
				_clientTypeId = value;
			}
		}

		public decimal? CreditLimit
		{
			get
			{
				return _creditLimit;
			}
			set
			{
				_creditLimit = value;
			}
		}

		public decimal? CreditBalance
		{
			get
			{
				return _creditBalance;
			}
			set
			{
				_creditBalance = value;
			}
		}

		public Int64? PlanId
		{
			get
			{
				return _planId;
			}
			set
			{
				_planId = value;
			}
		}

		public decimal? TargetValue
		{
			get
			{
				return _targetValue;
			}
			set
			{
				_targetValue = value;
			}
		}

		public Int32? TargetVisit
		{
			get
			{
				return _targetVisit;
			}
			set
			{
				_targetVisit = value;
			}
		}

		public Int32? TargetCall
		{
			get
			{
				return _targetCall;
			}
			set
			{
				_targetCall = value;
			}
		}

		public DateTime? TargetDate
		{
			get
			{
				return _targetDate;
			}
			set
			{
				_targetDate = value;
			}
		}

		public string ClientGroupCode
		{
			get
			{
				return _clientGroupCode;
			}
			set
			{
				_clientGroupCode = value;
			}
		}

		public string ClientGroupNameEn
		{
			get
			{
				return _clientGroupNameEn;
			}
			set
			{
				_clientGroupNameEn = value;
			}
		}

		public string ClientGroupNameAr
		{
			get
			{
				return _clientGroupNameAr;
			}
			set
			{
				_clientGroupNameAr = value;
			}
		}

		public Int32? BusinessUnitId
		{
			get
			{
				return _businessUnitId;
			}
			set
			{
				_businessUnitId = value;
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

		public Int32? ClientGroupSubId
		{
			get
			{
				return _clientGroupSubId;
			}
			set
			{
				_clientGroupSubId = value;
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
		internal static string ctprClient_planVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[ClientId]
			,[ClientCode]
			,[ClientNameAr]
			,[ClientNameEn]
			,[BranchId]
			,[BranchNameEn]
			,[BranchNameAr]
			,[BranchCode]
			,[ClientTypeId]
			,[CreditLimit]
			,[CreditBalance]
			,[PlanId]
			,[TargetValue]
			,[TargetVisit]
			,[TargetCall]
			,[TargetDate]
			,[ClientGroupCode]
			,[ClientGroupNameEn]
			,[ClientGroupNameAr]
			,[BusinessUnitId]
			,[ClientGroupId]
			,[ClientGroupSubId]
			FROM [dbo].[Client_planVw]
			";

		internal static string ctprClient_planVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_planVw]
			";

		internal static string ctprClient_planVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Client_planVw]
			##CRITERIA##
			";

		internal static string ctprClient_planVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[ClientId]
			,[ClientCode]
			,[ClientNameAr]
			,[ClientNameEn]
			,[BranchId]
			,[BranchNameEn]
			,[BranchNameAr]
			,[BranchCode]
			,[ClientTypeId]
			,[CreditLimit]
			,[CreditBalance]
			,[PlanId]
			,[TargetValue]
			,[TargetVisit]
			,[TargetCall]
			,[TargetDate]
			,[ClientGroupCode]
			,[ClientGroupNameEn]
			,[ClientGroupNameAr]
			,[BusinessUnitId]
			,[ClientGroupId]
			,[ClientGroupSubId]
			FROM [dbo].[Client_planVw]
			##CRITERIA##
			";

		internal static string ctprClient_planVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Client_planVw]
			##CRITERIA##
			";

	}
}
#endregion
