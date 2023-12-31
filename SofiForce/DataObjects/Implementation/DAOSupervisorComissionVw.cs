/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 3/23/2023 3:30:39 PM
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SofiForce.DataObjects.Interfaces;

namespace SofiForce.DataObjects
{
	public partial class DAOSupervisorComissionVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _comissionId;
		protected Int32? _supervisorId;
		protected DateTime? _comissionDate;
		protected decimal? _comissionValue;
		protected bool? _isApproved;
		protected Int32? _businessUnitId;
		protected Int32? _supervisorTypeId;
		protected string _supervisorTypeCode;
		protected string _supervisorTypeNameEn;
		protected string _supervisorTypeNameAr;
		protected string _companyCode;
		protected string _supervisorCode;
		protected string _supervisorNameEn;
		protected string _supervisorNameAr;
		protected Int32? _branchId;
		protected string _branchNameEn;
		protected string _branchNameAr;
		protected string _branchCode;
		protected Int32? _comissionTypeId;
		protected string _comissionTypeNameEn;
		protected string _comissionTypeNameAr;
		#endregion

		#region class methods
		public DAOSupervisorComissionVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table Supervisor_ComissionVw
		///</Summary>
		///<returns>
		///IList-DAOSupervisorComissionVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOSupervisorComissionVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSupervisor_ComissionVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Supervisor_ComissionVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSupervisorComissionVw> objList = new List<DAOSupervisorComissionVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSupervisorComissionVw retObj = new DAOSupervisorComissionVw();
						retObj._comissionId					 = Convert.IsDBNull(row["ComissionId"]) ? (Int32?)null : (Int32?)row["ComissionId"];
						retObj._supervisorId					 = Convert.IsDBNull(row["SupervisorId"]) ? (Int32?)null : (Int32?)row["SupervisorId"];
						retObj._comissionDate					 = Convert.IsDBNull(row["ComissionDate"]) ? (DateTime?)null : (DateTime?)row["ComissionDate"];
						retObj._comissionValue					 = Convert.IsDBNull(row["ComissionValue"]) ? (decimal?)null : (decimal?)row["ComissionValue"];
						retObj._isApproved					 = Convert.IsDBNull(row["IsApproved"]) ? (bool?)null : (bool?)row["IsApproved"];
						retObj._businessUnitId					 = Convert.IsDBNull(row["BusinessUnitId"]) ? (Int32?)null : (Int32?)row["BusinessUnitId"];
						retObj._supervisorTypeId					 = Convert.IsDBNull(row["SupervisorTypeId"]) ? (Int32?)null : (Int32?)row["SupervisorTypeId"];
						retObj._supervisorTypeCode					 = Convert.IsDBNull(row["SupervisorTypeCode"]) ? null : (string)row["SupervisorTypeCode"];
						retObj._supervisorTypeNameEn					 = Convert.IsDBNull(row["SupervisorTypeNameEn"]) ? null : (string)row["SupervisorTypeNameEn"];
						retObj._supervisorTypeNameAr					 = Convert.IsDBNull(row["SupervisorTypeNameAr"]) ? null : (string)row["SupervisorTypeNameAr"];
						retObj._companyCode					 = Convert.IsDBNull(row["CompanyCode"]) ? null : (string)row["CompanyCode"];
						retObj._supervisorCode					 = Convert.IsDBNull(row["SupervisorCode"]) ? null : (string)row["SupervisorCode"];
						retObj._supervisorNameEn					 = Convert.IsDBNull(row["SupervisorNameEn"]) ? null : (string)row["SupervisorNameEn"];
						retObj._supervisorNameAr					 = Convert.IsDBNull(row["SupervisorNameAr"]) ? null : (string)row["SupervisorNameAr"];
						retObj._branchId					 = Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"];
						retObj._branchNameEn					 = Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"];
						retObj._branchNameAr					 = Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"];
						retObj._branchCode					 = Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"];
						retObj._comissionTypeId					 = Convert.IsDBNull(row["ComissionTypeId"]) ? (Int32?)null : (Int32?)row["ComissionTypeId"];
						retObj._comissionTypeNameEn					 = Convert.IsDBNull(row["ComissionTypeNameEn"]) ? null : (string)row["ComissionTypeNameEn"];
						retObj._comissionTypeNameAr					 = Convert.IsDBNull(row["ComissionTypeNameAr"]) ? null : (string)row["ComissionTypeNameAr"];
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
			command.CommandText = InlineProcs.ctprSupervisor_ComissionVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiSupervisor_ComissionVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSupervisor_ComissionVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Supervisor_ComissionVw");
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
						if (string.Compare(projection.Member, "ComissionId", true) == 0) lst.Add(Convert.IsDBNull(row["ComissionId"]) ? (Int32?)null : (Int32?)row["ComissionId"]);
						if (string.Compare(projection.Member, "SupervisorId", true) == 0) lst.Add(Convert.IsDBNull(row["SupervisorId"]) ? (Int32?)null : (Int32?)row["SupervisorId"]);
						if (string.Compare(projection.Member, "ComissionDate", true) == 0) lst.Add(Convert.IsDBNull(row["ComissionDate"]) ? (DateTime?)null : (DateTime?)row["ComissionDate"]);
						if (string.Compare(projection.Member, "ComissionValue", true) == 0) lst.Add(Convert.IsDBNull(row["ComissionValue"]) ? (decimal?)null : (decimal?)row["ComissionValue"]);
						if (string.Compare(projection.Member, "IsApproved", true) == 0) lst.Add(Convert.IsDBNull(row["IsApproved"]) ? (bool?)null : (bool?)row["IsApproved"]);
						if (string.Compare(projection.Member, "BusinessUnitId", true) == 0) lst.Add(Convert.IsDBNull(row["BusinessUnitId"]) ? (Int32?)null : (Int32?)row["BusinessUnitId"]);
						if (string.Compare(projection.Member, "SupervisorTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["SupervisorTypeId"]) ? (Int32?)null : (Int32?)row["SupervisorTypeId"]);
						if (string.Compare(projection.Member, "SupervisorTypeCode", true) == 0) lst.Add(Convert.IsDBNull(row["SupervisorTypeCode"]) ? null : (string)row["SupervisorTypeCode"]);
						if (string.Compare(projection.Member, "SupervisorTypeNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["SupervisorTypeNameEn"]) ? null : (string)row["SupervisorTypeNameEn"]);
						if (string.Compare(projection.Member, "SupervisorTypeNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["SupervisorTypeNameAr"]) ? null : (string)row["SupervisorTypeNameAr"]);
						if (string.Compare(projection.Member, "CompanyCode", true) == 0) lst.Add(Convert.IsDBNull(row["CompanyCode"]) ? null : (string)row["CompanyCode"]);
						if (string.Compare(projection.Member, "SupervisorCode", true) == 0) lst.Add(Convert.IsDBNull(row["SupervisorCode"]) ? null : (string)row["SupervisorCode"]);
						if (string.Compare(projection.Member, "SupervisorNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["SupervisorNameEn"]) ? null : (string)row["SupervisorNameEn"]);
						if (string.Compare(projection.Member, "SupervisorNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["SupervisorNameAr"]) ? null : (string)row["SupervisorNameAr"]);
						if (string.Compare(projection.Member, "BranchId", true) == 0) lst.Add(Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"]);
						if (string.Compare(projection.Member, "BranchNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"]);
						if (string.Compare(projection.Member, "BranchNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"]);
						if (string.Compare(projection.Member, "BranchCode", true) == 0) lst.Add(Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"]);
						if (string.Compare(projection.Member, "ComissionTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["ComissionTypeId"]) ? (Int32?)null : (Int32?)row["ComissionTypeId"]);
						if (string.Compare(projection.Member, "ComissionTypeNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["ComissionTypeNameEn"]) ? null : (string)row["ComissionTypeNameEn"]);
						if (string.Compare(projection.Member, "ComissionTypeNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["ComissionTypeNameAr"]) ? null : (string)row["ComissionTypeNameAr"]);
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
		///This method returns all data rows in the table using criteriaquery api Supervisor_ComissionVw
		///</Summary>
		///<returns>
		///IList-DAOSupervisorComissionVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOSupervisorComissionVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSupervisor_ComissionVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Supervisor_ComissionVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSupervisorComissionVw> objList = new List<DAOSupervisorComissionVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSupervisorComissionVw retObj = new DAOSupervisorComissionVw();
						retObj._comissionId					 = Convert.IsDBNull(row["ComissionId"]) ? (Int32?)null : (Int32?)row["ComissionId"];
						retObj._supervisorId					 = Convert.IsDBNull(row["SupervisorId"]) ? (Int32?)null : (Int32?)row["SupervisorId"];
						retObj._comissionDate					 = Convert.IsDBNull(row["ComissionDate"]) ? (DateTime?)null : (DateTime?)row["ComissionDate"];
						retObj._comissionValue					 = Convert.IsDBNull(row["ComissionValue"]) ? (decimal?)null : (decimal?)row["ComissionValue"];
						retObj._isApproved					 = Convert.IsDBNull(row["IsApproved"]) ? (bool?)null : (bool?)row["IsApproved"];
						retObj._businessUnitId					 = Convert.IsDBNull(row["BusinessUnitId"]) ? (Int32?)null : (Int32?)row["BusinessUnitId"];
						retObj._supervisorTypeId					 = Convert.IsDBNull(row["SupervisorTypeId"]) ? (Int32?)null : (Int32?)row["SupervisorTypeId"];
						retObj._supervisorTypeCode					 = Convert.IsDBNull(row["SupervisorTypeCode"]) ? null : (string)row["SupervisorTypeCode"];
						retObj._supervisorTypeNameEn					 = Convert.IsDBNull(row["SupervisorTypeNameEn"]) ? null : (string)row["SupervisorTypeNameEn"];
						retObj._supervisorTypeNameAr					 = Convert.IsDBNull(row["SupervisorTypeNameAr"]) ? null : (string)row["SupervisorTypeNameAr"];
						retObj._companyCode					 = Convert.IsDBNull(row["CompanyCode"]) ? null : (string)row["CompanyCode"];
						retObj._supervisorCode					 = Convert.IsDBNull(row["SupervisorCode"]) ? null : (string)row["SupervisorCode"];
						retObj._supervisorNameEn					 = Convert.IsDBNull(row["SupervisorNameEn"]) ? null : (string)row["SupervisorNameEn"];
						retObj._supervisorNameAr					 = Convert.IsDBNull(row["SupervisorNameAr"]) ? null : (string)row["SupervisorNameAr"];
						retObj._branchId					 = Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"];
						retObj._branchNameEn					 = Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"];
						retObj._branchNameAr					 = Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"];
						retObj._branchCode					 = Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"];
						retObj._comissionTypeId					 = Convert.IsDBNull(row["ComissionTypeId"]) ? (Int32?)null : (Int32?)row["ComissionTypeId"];
						retObj._comissionTypeNameEn					 = Convert.IsDBNull(row["ComissionTypeNameEn"]) ? null : (string)row["ComissionTypeNameEn"];
						retObj._comissionTypeNameAr					 = Convert.IsDBNull(row["ComissionTypeNameAr"]) ? null : (string)row["ComissionTypeNameAr"];
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
		///This method returns all data rows in the table using criteriaquery api Supervisor_ComissionVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSupervisor_ComissionVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public Int32? ComissionId
		{
			get
			{
				return _comissionId;
			}
			set
			{
				_comissionId = value;
			}
		}

		public Int32? SupervisorId
		{
			get
			{
				return _supervisorId;
			}
			set
			{
				_supervisorId = value;
			}
		}

		public DateTime? ComissionDate
		{
			get
			{
				return _comissionDate;
			}
			set
			{
				_comissionDate = value;
			}
		}

		public decimal? ComissionValue
		{
			get
			{
				return _comissionValue;
			}
			set
			{
				_comissionValue = value;
			}
		}

		public bool? IsApproved
		{
			get
			{
				return _isApproved;
			}
			set
			{
				_isApproved = value;
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

		public Int32? SupervisorTypeId
		{
			get
			{
				return _supervisorTypeId;
			}
			set
			{
				_supervisorTypeId = value;
			}
		}

		public string SupervisorTypeCode
		{
			get
			{
				return _supervisorTypeCode;
			}
			set
			{
				_supervisorTypeCode = value;
			}
		}

		public string SupervisorTypeNameEn
		{
			get
			{
				return _supervisorTypeNameEn;
			}
			set
			{
				_supervisorTypeNameEn = value;
			}
		}

		public string SupervisorTypeNameAr
		{
			get
			{
				return _supervisorTypeNameAr;
			}
			set
			{
				_supervisorTypeNameAr = value;
			}
		}

		public string CompanyCode
		{
			get
			{
				return _companyCode;
			}
			set
			{
				_companyCode = value;
			}
		}

		public string SupervisorCode
		{
			get
			{
				return _supervisorCode;
			}
			set
			{
				_supervisorCode = value;
			}
		}

		public string SupervisorNameEn
		{
			get
			{
				return _supervisorNameEn;
			}
			set
			{
				_supervisorNameEn = value;
			}
		}

		public string SupervisorNameAr
		{
			get
			{
				return _supervisorNameAr;
			}
			set
			{
				_supervisorNameAr = value;
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

		public Int32? ComissionTypeId
		{
			get
			{
				return _comissionTypeId;
			}
			set
			{
				_comissionTypeId = value;
			}
		}

		public string ComissionTypeNameEn
		{
			get
			{
				return _comissionTypeNameEn;
			}
			set
			{
				_comissionTypeNameEn = value;
			}
		}

		public string ComissionTypeNameAr
		{
			get
			{
				return _comissionTypeNameAr;
			}
			set
			{
				_comissionTypeNameAr = value;
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
		internal static string ctprSupervisor_ComissionVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[ComissionId]
			,[SupervisorId]
			,[ComissionDate]
			,[ComissionValue]
			,[IsApproved]
			,[BusinessUnitId]
			,[SupervisorTypeId]
			,[SupervisorTypeCode]
			,[SupervisorTypeNameEn]
			,[SupervisorTypeNameAr]
			,[CompanyCode]
			,[SupervisorCode]
			,[SupervisorNameEn]
			,[SupervisorNameAr]
			,[BranchId]
			,[BranchNameEn]
			,[BranchNameAr]
			,[BranchCode]
			,[ComissionTypeId]
			,[ComissionTypeNameEn]
			,[ComissionTypeNameAr]
			FROM [dbo].[Supervisor_ComissionVw]
			";

		internal static string ctprSupervisor_ComissionVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Supervisor_ComissionVw]
			";

		internal static string ctprSupervisor_ComissionVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Supervisor_ComissionVw]
			##CRITERIA##
			";

		internal static string ctprSupervisor_ComissionVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[ComissionId]
			,[SupervisorId]
			,[ComissionDate]
			,[ComissionValue]
			,[IsApproved]
			,[BusinessUnitId]
			,[SupervisorTypeId]
			,[SupervisorTypeCode]
			,[SupervisorTypeNameEn]
			,[SupervisorTypeNameAr]
			,[CompanyCode]
			,[SupervisorCode]
			,[SupervisorNameEn]
			,[SupervisorNameAr]
			,[BranchId]
			,[BranchNameEn]
			,[BranchNameAr]
			,[BranchCode]
			,[ComissionTypeId]
			,[ComissionTypeNameEn]
			,[ComissionTypeNameAr]
			FROM [dbo].[Supervisor_ComissionVw]
			##CRITERIA##
			";

		internal static string ctprSupervisor_ComissionVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Supervisor_ComissionVw]
			##CRITERIA##
			";

	}
}
#endregion
