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
	public partial class DAORepresentativeComissionVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _comissionId;
		protected Int32? _representativeId;
		protected DateTime? _comissionDate;
		protected decimal? _comissionValue;
		protected bool? _isApproved;
		protected Int32? _comissionTypeId;
		protected string _comissionTypeNameEn;
		protected string _comissionTypeNameAr;
		protected string _kindNameAr;
		protected string _kindNameEn;
		protected Int32? _supervisorId;
		protected Int32? _kindId;
		protected Int32? _userId;
		protected Int32? _branchId;
		protected Int32? _businessUnitId;
		protected string _representativeCode;
		protected string _companyCode;
		protected string _representativeNameAr;
		protected string _representativeNameEn;
		protected string _branchCode;
		protected string _branchNameAr;
		protected string _branchNameEn;
		protected string _kindCode;
		protected string _supervisorCode;
		protected string _supervisorNameEn;
		protected string _supervisorNameAr;
		#endregion

		#region class methods
		public DAORepresentativeComissionVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table Representative_ComissionVw
		///</Summary>
		///<returns>
		///IList-DAORepresentativeComissionVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAORepresentativeComissionVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprRepresentative_ComissionVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Representative_ComissionVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAORepresentativeComissionVw> objList = new List<DAORepresentativeComissionVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAORepresentativeComissionVw retObj = new DAORepresentativeComissionVw();
						retObj._comissionId					 = Convert.IsDBNull(row["ComissionId"]) ? (Int32?)null : (Int32?)row["ComissionId"];
						retObj._representativeId					 = Convert.IsDBNull(row["RepresentativeId"]) ? (Int32?)null : (Int32?)row["RepresentativeId"];
						retObj._comissionDate					 = Convert.IsDBNull(row["ComissionDate"]) ? (DateTime?)null : (DateTime?)row["ComissionDate"];
						retObj._comissionValue					 = Convert.IsDBNull(row["ComissionValue"]) ? (decimal?)null : (decimal?)row["ComissionValue"];
						retObj._isApproved					 = Convert.IsDBNull(row["IsApproved"]) ? (bool?)null : (bool?)row["IsApproved"];
						retObj._comissionTypeId					 = Convert.IsDBNull(row["ComissionTypeId"]) ? (Int32?)null : (Int32?)row["ComissionTypeId"];
						retObj._comissionTypeNameEn					 = Convert.IsDBNull(row["ComissionTypeNameEn"]) ? null : (string)row["ComissionTypeNameEn"];
						retObj._comissionTypeNameAr					 = Convert.IsDBNull(row["ComissionTypeNameAr"]) ? null : (string)row["ComissionTypeNameAr"];
						retObj._kindNameAr					 = Convert.IsDBNull(row["KindNameAr"]) ? null : (string)row["KindNameAr"];
						retObj._kindNameEn					 = Convert.IsDBNull(row["KindNameEn"]) ? null : (string)row["KindNameEn"];
						retObj._supervisorId					 = Convert.IsDBNull(row["SupervisorId"]) ? (Int32?)null : (Int32?)row["SupervisorId"];
						retObj._kindId					 = Convert.IsDBNull(row["KindId"]) ? (Int32?)null : (Int32?)row["KindId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._branchId					 = Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"];
						retObj._businessUnitId					 = Convert.IsDBNull(row["BusinessUnitId"]) ? (Int32?)null : (Int32?)row["BusinessUnitId"];
						retObj._representativeCode					 = Convert.IsDBNull(row["RepresentativeCode"]) ? null : (string)row["RepresentativeCode"];
						retObj._companyCode					 = Convert.IsDBNull(row["CompanyCode"]) ? null : (string)row["CompanyCode"];
						retObj._representativeNameAr					 = Convert.IsDBNull(row["RepresentativeNameAr"]) ? null : (string)row["RepresentativeNameAr"];
						retObj._representativeNameEn					 = Convert.IsDBNull(row["RepresentativeNameEn"]) ? null : (string)row["RepresentativeNameEn"];
						retObj._branchCode					 = Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"];
						retObj._branchNameAr					 = Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"];
						retObj._branchNameEn					 = Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"];
						retObj._kindCode					 = Convert.IsDBNull(row["KindCode"]) ? null : (string)row["KindCode"];
						retObj._supervisorCode					 = Convert.IsDBNull(row["SupervisorCode"]) ? null : (string)row["SupervisorCode"];
						retObj._supervisorNameEn					 = Convert.IsDBNull(row["SupervisorNameEn"]) ? null : (string)row["SupervisorNameEn"];
						retObj._supervisorNameAr					 = Convert.IsDBNull(row["SupervisorNameAr"]) ? null : (string)row["SupervisorNameAr"];
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
			command.CommandText = InlineProcs.ctprRepresentative_ComissionVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiRepresentative_ComissionVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprRepresentative_ComissionVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Representative_ComissionVw");
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
						if (string.Compare(projection.Member, "RepresentativeId", true) == 0) lst.Add(Convert.IsDBNull(row["RepresentativeId"]) ? (Int32?)null : (Int32?)row["RepresentativeId"]);
						if (string.Compare(projection.Member, "ComissionDate", true) == 0) lst.Add(Convert.IsDBNull(row["ComissionDate"]) ? (DateTime?)null : (DateTime?)row["ComissionDate"]);
						if (string.Compare(projection.Member, "ComissionValue", true) == 0) lst.Add(Convert.IsDBNull(row["ComissionValue"]) ? (decimal?)null : (decimal?)row["ComissionValue"]);
						if (string.Compare(projection.Member, "IsApproved", true) == 0) lst.Add(Convert.IsDBNull(row["IsApproved"]) ? (bool?)null : (bool?)row["IsApproved"]);
						if (string.Compare(projection.Member, "ComissionTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["ComissionTypeId"]) ? (Int32?)null : (Int32?)row["ComissionTypeId"]);
						if (string.Compare(projection.Member, "ComissionTypeNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["ComissionTypeNameEn"]) ? null : (string)row["ComissionTypeNameEn"]);
						if (string.Compare(projection.Member, "ComissionTypeNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["ComissionTypeNameAr"]) ? null : (string)row["ComissionTypeNameAr"]);
						if (string.Compare(projection.Member, "KindNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["KindNameAr"]) ? null : (string)row["KindNameAr"]);
						if (string.Compare(projection.Member, "KindNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["KindNameEn"]) ? null : (string)row["KindNameEn"]);
						if (string.Compare(projection.Member, "SupervisorId", true) == 0) lst.Add(Convert.IsDBNull(row["SupervisorId"]) ? (Int32?)null : (Int32?)row["SupervisorId"]);
						if (string.Compare(projection.Member, "KindId", true) == 0) lst.Add(Convert.IsDBNull(row["KindId"]) ? (Int32?)null : (Int32?)row["KindId"]);
						if (string.Compare(projection.Member, "UserId", true) == 0) lst.Add(Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"]);
						if (string.Compare(projection.Member, "BranchId", true) == 0) lst.Add(Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"]);
						if (string.Compare(projection.Member, "BusinessUnitId", true) == 0) lst.Add(Convert.IsDBNull(row["BusinessUnitId"]) ? (Int32?)null : (Int32?)row["BusinessUnitId"]);
						if (string.Compare(projection.Member, "RepresentativeCode", true) == 0) lst.Add(Convert.IsDBNull(row["RepresentativeCode"]) ? null : (string)row["RepresentativeCode"]);
						if (string.Compare(projection.Member, "CompanyCode", true) == 0) lst.Add(Convert.IsDBNull(row["CompanyCode"]) ? null : (string)row["CompanyCode"]);
						if (string.Compare(projection.Member, "RepresentativeNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["RepresentativeNameAr"]) ? null : (string)row["RepresentativeNameAr"]);
						if (string.Compare(projection.Member, "RepresentativeNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["RepresentativeNameEn"]) ? null : (string)row["RepresentativeNameEn"]);
						if (string.Compare(projection.Member, "BranchCode", true) == 0) lst.Add(Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"]);
						if (string.Compare(projection.Member, "BranchNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"]);
						if (string.Compare(projection.Member, "BranchNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"]);
						if (string.Compare(projection.Member, "KindCode", true) == 0) lst.Add(Convert.IsDBNull(row["KindCode"]) ? null : (string)row["KindCode"]);
						if (string.Compare(projection.Member, "SupervisorCode", true) == 0) lst.Add(Convert.IsDBNull(row["SupervisorCode"]) ? null : (string)row["SupervisorCode"]);
						if (string.Compare(projection.Member, "SupervisorNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["SupervisorNameEn"]) ? null : (string)row["SupervisorNameEn"]);
						if (string.Compare(projection.Member, "SupervisorNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["SupervisorNameAr"]) ? null : (string)row["SupervisorNameAr"]);
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
		///This method returns all data rows in the table using criteriaquery api Representative_ComissionVw
		///</Summary>
		///<returns>
		///IList-DAORepresentativeComissionVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAORepresentativeComissionVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprRepresentative_ComissionVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Representative_ComissionVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAORepresentativeComissionVw> objList = new List<DAORepresentativeComissionVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAORepresentativeComissionVw retObj = new DAORepresentativeComissionVw();
						retObj._comissionId					 = Convert.IsDBNull(row["ComissionId"]) ? (Int32?)null : (Int32?)row["ComissionId"];
						retObj._representativeId					 = Convert.IsDBNull(row["RepresentativeId"]) ? (Int32?)null : (Int32?)row["RepresentativeId"];
						retObj._comissionDate					 = Convert.IsDBNull(row["ComissionDate"]) ? (DateTime?)null : (DateTime?)row["ComissionDate"];
						retObj._comissionValue					 = Convert.IsDBNull(row["ComissionValue"]) ? (decimal?)null : (decimal?)row["ComissionValue"];
						retObj._isApproved					 = Convert.IsDBNull(row["IsApproved"]) ? (bool?)null : (bool?)row["IsApproved"];
						retObj._comissionTypeId					 = Convert.IsDBNull(row["ComissionTypeId"]) ? (Int32?)null : (Int32?)row["ComissionTypeId"];
						retObj._comissionTypeNameEn					 = Convert.IsDBNull(row["ComissionTypeNameEn"]) ? null : (string)row["ComissionTypeNameEn"];
						retObj._comissionTypeNameAr					 = Convert.IsDBNull(row["ComissionTypeNameAr"]) ? null : (string)row["ComissionTypeNameAr"];
						retObj._kindNameAr					 = Convert.IsDBNull(row["KindNameAr"]) ? null : (string)row["KindNameAr"];
						retObj._kindNameEn					 = Convert.IsDBNull(row["KindNameEn"]) ? null : (string)row["KindNameEn"];
						retObj._supervisorId					 = Convert.IsDBNull(row["SupervisorId"]) ? (Int32?)null : (Int32?)row["SupervisorId"];
						retObj._kindId					 = Convert.IsDBNull(row["KindId"]) ? (Int32?)null : (Int32?)row["KindId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._branchId					 = Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"];
						retObj._businessUnitId					 = Convert.IsDBNull(row["BusinessUnitId"]) ? (Int32?)null : (Int32?)row["BusinessUnitId"];
						retObj._representativeCode					 = Convert.IsDBNull(row["RepresentativeCode"]) ? null : (string)row["RepresentativeCode"];
						retObj._companyCode					 = Convert.IsDBNull(row["CompanyCode"]) ? null : (string)row["CompanyCode"];
						retObj._representativeNameAr					 = Convert.IsDBNull(row["RepresentativeNameAr"]) ? null : (string)row["RepresentativeNameAr"];
						retObj._representativeNameEn					 = Convert.IsDBNull(row["RepresentativeNameEn"]) ? null : (string)row["RepresentativeNameEn"];
						retObj._branchCode					 = Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"];
						retObj._branchNameAr					 = Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"];
						retObj._branchNameEn					 = Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"];
						retObj._kindCode					 = Convert.IsDBNull(row["KindCode"]) ? null : (string)row["KindCode"];
						retObj._supervisorCode					 = Convert.IsDBNull(row["SupervisorCode"]) ? null : (string)row["SupervisorCode"];
						retObj._supervisorNameEn					 = Convert.IsDBNull(row["SupervisorNameEn"]) ? null : (string)row["SupervisorNameEn"];
						retObj._supervisorNameAr					 = Convert.IsDBNull(row["SupervisorNameAr"]) ? null : (string)row["SupervisorNameAr"];
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
		///This method returns all data rows in the table using criteriaquery api Representative_ComissionVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprRepresentative_ComissionVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public string KindNameAr
		{
			get
			{
				return _kindNameAr;
			}
			set
			{
				_kindNameAr = value;
			}
		}

		public string KindNameEn
		{
			get
			{
				return _kindNameEn;
			}
			set
			{
				_kindNameEn = value;
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

		public Int32? KindId
		{
			get
			{
				return _kindId;
			}
			set
			{
				_kindId = value;
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

		public string RepresentativeCode
		{
			get
			{
				return _representativeCode;
			}
			set
			{
				_representativeCode = value;
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

		public string RepresentativeNameAr
		{
			get
			{
				return _representativeNameAr;
			}
			set
			{
				_representativeNameAr = value;
			}
		}

		public string RepresentativeNameEn
		{
			get
			{
				return _representativeNameEn;
			}
			set
			{
				_representativeNameEn = value;
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

		public string KindCode
		{
			get
			{
				return _kindCode;
			}
			set
			{
				_kindCode = value;
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

		#endregion
	}
}

#region inline sql procs
namespace SofiForce.DataObjects
{
	public partial class InlineProcs
	{
		internal static string ctprRepresentative_ComissionVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[ComissionId]
			,[RepresentativeId]
			,[ComissionDate]
			,[ComissionValue]
			,[IsApproved]
			,[ComissionTypeId]
			,[ComissionTypeNameEn]
			,[ComissionTypeNameAr]
			,[KindNameAr]
			,[KindNameEn]
			,[SupervisorId]
			,[KindId]
			,[UserId]
			,[BranchId]
			,[BusinessUnitId]
			,[RepresentativeCode]
			,[CompanyCode]
			,[RepresentativeNameAr]
			,[RepresentativeNameEn]
			,[BranchCode]
			,[BranchNameAr]
			,[BranchNameEn]
			,[KindCode]
			,[SupervisorCode]
			,[SupervisorNameEn]
			,[SupervisorNameAr]
			FROM [dbo].[Representative_ComissionVw]
			";

		internal static string ctprRepresentative_ComissionVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Representative_ComissionVw]
			";

		internal static string ctprRepresentative_ComissionVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Representative_ComissionVw]
			##CRITERIA##
			";

		internal static string ctprRepresentative_ComissionVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[ComissionId]
			,[RepresentativeId]
			,[ComissionDate]
			,[ComissionValue]
			,[IsApproved]
			,[ComissionTypeId]
			,[ComissionTypeNameEn]
			,[ComissionTypeNameAr]
			,[KindNameAr]
			,[KindNameEn]
			,[SupervisorId]
			,[KindId]
			,[UserId]
			,[BranchId]
			,[BusinessUnitId]
			,[RepresentativeCode]
			,[CompanyCode]
			,[RepresentativeNameAr]
			,[RepresentativeNameEn]
			,[BranchCode]
			,[BranchNameAr]
			,[BranchNameEn]
			,[KindCode]
			,[SupervisorCode]
			,[SupervisorNameEn]
			,[SupervisorNameAr]
			FROM [dbo].[Representative_ComissionVw]
			##CRITERIA##
			";

		internal static string ctprRepresentative_ComissionVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Representative_ComissionVw]
			##CRITERIA##
			";

	}
}
#endregion
