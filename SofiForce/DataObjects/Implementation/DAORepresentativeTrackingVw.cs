/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 3/26/2023 2:26:30 PM
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SofiForce.DataObjects.Interfaces;

namespace SofiForce.DataObjects
{
	public partial class DAORepresentativeTrackingVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _representativeId;
		protected Int32? _branchId;
		protected Int32? _userId;
		protected Int32? _supervisorId;
		protected Int32? _kindId;
		protected Int32? _businessUnitId;
		protected string _companyCode;
		protected string _representativeCode;
		protected string _representativeNameAr;
		protected string _representativeNameEn;
		protected string _phone;
		protected double? _latitude;
		protected double? _longitude;
		protected DateTime? _lastSyncDate;
		protected bool? _isOnline;
		protected string _branchNameEn;
		protected string _branchNameAr;
		protected string _branchCode;
		#endregion

		#region class methods
		public DAORepresentativeTrackingVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table Representative_Tracking_Vw
		///</Summary>
		///<returns>
		///IList-DAORepresentativeTrackingVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAORepresentativeTrackingVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprRepresentative_Tracking_Vw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Representative_Tracking_Vw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAORepresentativeTrackingVw> objList = new List<DAORepresentativeTrackingVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAORepresentativeTrackingVw retObj = new DAORepresentativeTrackingVw();
						retObj._representativeId					 = Convert.IsDBNull(row["RepresentativeId"]) ? (Int32?)null : (Int32?)row["RepresentativeId"];
						retObj._branchId					 = Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._supervisorId					 = Convert.IsDBNull(row["SupervisorId"]) ? (Int32?)null : (Int32?)row["SupervisorId"];
						retObj._kindId					 = Convert.IsDBNull(row["KindId"]) ? (Int32?)null : (Int32?)row["KindId"];
						retObj._businessUnitId					 = Convert.IsDBNull(row["BusinessUnitId"]) ? (Int32?)null : (Int32?)row["BusinessUnitId"];
						retObj._companyCode					 = Convert.IsDBNull(row["CompanyCode"]) ? null : (string)row["CompanyCode"];
						retObj._representativeCode					 = Convert.IsDBNull(row["RepresentativeCode"]) ? null : (string)row["RepresentativeCode"];
						retObj._representativeNameAr					 = Convert.IsDBNull(row["RepresentativeNameAr"]) ? null : (string)row["RepresentativeNameAr"];
						retObj._representativeNameEn					 = Convert.IsDBNull(row["RepresentativeNameEn"]) ? null : (string)row["RepresentativeNameEn"];
						retObj._phone					 = Convert.IsDBNull(row["Phone"]) ? null : (string)row["Phone"];
						retObj._latitude					 = Convert.IsDBNull(row["Latitude"]) ? (double?)null : (double?)row["Latitude"];
						retObj._longitude					 = Convert.IsDBNull(row["Longitude"]) ? (double?)null : (double?)row["Longitude"];
						retObj._lastSyncDate					 = Convert.IsDBNull(row["LastSyncDate"]) ? (DateTime?)null : (DateTime?)row["LastSyncDate"];
						retObj._isOnline					 = Convert.IsDBNull(row["isOnline"]) ? (bool?)null : (bool?)row["isOnline"];
						retObj._branchNameEn					 = Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"];
						retObj._branchNameAr					 = Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"];
						retObj._branchCode					 = Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"];
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
			command.CommandText = InlineProcs.ctprRepresentative_Tracking_Vw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiRepresentative_Tracking_Vw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprRepresentative_Tracking_Vw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Representative_Tracking_Vw");
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
						if (string.Compare(projection.Member, "RepresentativeId", true) == 0) lst.Add(Convert.IsDBNull(row["RepresentativeId"]) ? (Int32?)null : (Int32?)row["RepresentativeId"]);
						if (string.Compare(projection.Member, "BranchId", true) == 0) lst.Add(Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"]);
						if (string.Compare(projection.Member, "UserId", true) == 0) lst.Add(Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"]);
						if (string.Compare(projection.Member, "SupervisorId", true) == 0) lst.Add(Convert.IsDBNull(row["SupervisorId"]) ? (Int32?)null : (Int32?)row["SupervisorId"]);
						if (string.Compare(projection.Member, "KindId", true) == 0) lst.Add(Convert.IsDBNull(row["KindId"]) ? (Int32?)null : (Int32?)row["KindId"]);
						if (string.Compare(projection.Member, "BusinessUnitId", true) == 0) lst.Add(Convert.IsDBNull(row["BusinessUnitId"]) ? (Int32?)null : (Int32?)row["BusinessUnitId"]);
						if (string.Compare(projection.Member, "CompanyCode", true) == 0) lst.Add(Convert.IsDBNull(row["CompanyCode"]) ? null : (string)row["CompanyCode"]);
						if (string.Compare(projection.Member, "RepresentativeCode", true) == 0) lst.Add(Convert.IsDBNull(row["RepresentativeCode"]) ? null : (string)row["RepresentativeCode"]);
						if (string.Compare(projection.Member, "RepresentativeNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["RepresentativeNameAr"]) ? null : (string)row["RepresentativeNameAr"]);
						if (string.Compare(projection.Member, "RepresentativeNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["RepresentativeNameEn"]) ? null : (string)row["RepresentativeNameEn"]);
						if (string.Compare(projection.Member, "Phone", true) == 0) lst.Add(Convert.IsDBNull(row["Phone"]) ? null : (string)row["Phone"]);
						if (string.Compare(projection.Member, "Latitude", true) == 0) lst.Add(Convert.IsDBNull(row["Latitude"]) ? (double?)null : (double?)row["Latitude"]);
						if (string.Compare(projection.Member, "Longitude", true) == 0) lst.Add(Convert.IsDBNull(row["Longitude"]) ? (double?)null : (double?)row["Longitude"]);
						if (string.Compare(projection.Member, "LastSyncDate", true) == 0) lst.Add(Convert.IsDBNull(row["LastSyncDate"]) ? (DateTime?)null : (DateTime?)row["LastSyncDate"]);
						if (string.Compare(projection.Member, "isOnline", true) == 0) lst.Add(Convert.IsDBNull(row["isOnline"]) ? (bool?)null : (bool?)row["isOnline"]);
						if (string.Compare(projection.Member, "BranchNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"]);
						if (string.Compare(projection.Member, "BranchNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"]);
						if (string.Compare(projection.Member, "BranchCode", true) == 0) lst.Add(Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"]);
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
		///This method returns all data rows in the table using criteriaquery api Representative_Tracking_Vw
		///</Summary>
		///<returns>
		///IList-DAORepresentativeTrackingVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAORepresentativeTrackingVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprRepresentative_Tracking_Vw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Representative_Tracking_Vw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAORepresentativeTrackingVw> objList = new List<DAORepresentativeTrackingVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAORepresentativeTrackingVw retObj = new DAORepresentativeTrackingVw();
						retObj._representativeId					 = Convert.IsDBNull(row["RepresentativeId"]) ? (Int32?)null : (Int32?)row["RepresentativeId"];
						retObj._branchId					 = Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._supervisorId					 = Convert.IsDBNull(row["SupervisorId"]) ? (Int32?)null : (Int32?)row["SupervisorId"];
						retObj._kindId					 = Convert.IsDBNull(row["KindId"]) ? (Int32?)null : (Int32?)row["KindId"];
						retObj._businessUnitId					 = Convert.IsDBNull(row["BusinessUnitId"]) ? (Int32?)null : (Int32?)row["BusinessUnitId"];
						retObj._companyCode					 = Convert.IsDBNull(row["CompanyCode"]) ? null : (string)row["CompanyCode"];
						retObj._representativeCode					 = Convert.IsDBNull(row["RepresentativeCode"]) ? null : (string)row["RepresentativeCode"];
						retObj._representativeNameAr					 = Convert.IsDBNull(row["RepresentativeNameAr"]) ? null : (string)row["RepresentativeNameAr"];
						retObj._representativeNameEn					 = Convert.IsDBNull(row["RepresentativeNameEn"]) ? null : (string)row["RepresentativeNameEn"];
						retObj._phone					 = Convert.IsDBNull(row["Phone"]) ? null : (string)row["Phone"];
						retObj._latitude					 = Convert.IsDBNull(row["Latitude"]) ? (double?)null : (double?)row["Latitude"];
						retObj._longitude					 = Convert.IsDBNull(row["Longitude"]) ? (double?)null : (double?)row["Longitude"];
						retObj._lastSyncDate					 = Convert.IsDBNull(row["LastSyncDate"]) ? (DateTime?)null : (DateTime?)row["LastSyncDate"];
						retObj._isOnline					 = Convert.IsDBNull(row["isOnline"]) ? (bool?)null : (bool?)row["isOnline"];
						retObj._branchNameEn					 = Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"];
						retObj._branchNameAr					 = Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"];
						retObj._branchCode					 = Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"];
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
		///This method returns all data rows in the table using criteriaquery api Representative_Tracking_Vw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprRepresentative_Tracking_Vw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public string Phone
		{
			get
			{
				return _phone;
			}
			set
			{
				_phone = value;
			}
		}

		public double? Latitude
		{
			get
			{
				return _latitude;
			}
			set
			{
				_latitude = value;
			}
		}

		public double? Longitude
		{
			get
			{
				return _longitude;
			}
			set
			{
				_longitude = value;
			}
		}

		public DateTime? LastSyncDate
		{
			get
			{
				return _lastSyncDate;
			}
			set
			{
				_lastSyncDate = value;
			}
		}

		public bool? IsOnline
		{
			get
			{
				return _isOnline;
			}
			set
			{
				_isOnline = value;
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

		#endregion
	}
}

#region inline sql procs
namespace SofiForce.DataObjects
{
	public partial class InlineProcs
	{
		internal static string ctprRepresentative_Tracking_Vw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[RepresentativeId]
			,[BranchId]
			,[UserId]
			,[SupervisorId]
			,[KindId]
			,[BusinessUnitId]
			,[CompanyCode]
			,[RepresentativeCode]
			,[RepresentativeNameAr]
			,[RepresentativeNameEn]
			,[Phone]
			,[Latitude]
			,[Longitude]
			,[LastSyncDate]
			,[isOnline]
			,[BranchNameEn]
			,[BranchNameAr]
			,[BranchCode]
			FROM [dbo].[Representative_Tracking_Vw]
			";

		internal static string ctprRepresentative_Tracking_Vw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Representative_Tracking_Vw]
			";

		internal static string ctprRepresentative_Tracking_Vw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Representative_Tracking_Vw]
			##CRITERIA##
			";

		internal static string ctprRepresentative_Tracking_Vw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[RepresentativeId]
			,[BranchId]
			,[UserId]
			,[SupervisorId]
			,[KindId]
			,[BusinessUnitId]
			,[CompanyCode]
			,[RepresentativeCode]
			,[RepresentativeNameAr]
			,[RepresentativeNameEn]
			,[Phone]
			,[Latitude]
			,[Longitude]
			,[LastSyncDate]
			,[isOnline]
			,[BranchNameEn]
			,[BranchNameAr]
			,[BranchCode]
			FROM [dbo].[Representative_Tracking_Vw]
			##CRITERIA##
			";

		internal static string ctprRepresentative_Tracking_Vw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Representative_Tracking_Vw]
			##CRITERIA##
			";

	}
}
#endregion
