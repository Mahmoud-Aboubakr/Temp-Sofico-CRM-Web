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
	public partial class DAORouteSetupVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _routeId;
		protected Int32? _routeTypeId;
		protected Int32? _branchId;
		protected string _routeCode;
		protected string _routeNameEn;
		protected string _routeNameAr;
		protected bool? _isActive;
		protected string _color;
		protected string _icon;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected string _branchCode;
		protected string _branchNameAr;
		protected string _branchNameEn;
		protected string _routeTypeCode;
		protected string _routeTypeNameEn;
		protected string _routeTypeNameAr;
		#endregion

		#region class methods
		public DAORouteSetupVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table RouteSetupVw
		///</Summary>
		///<returns>
		///IList-DAORouteSetupVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAORouteSetupVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprRouteSetupVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("RouteSetupVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAORouteSetupVw> objList = new List<DAORouteSetupVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAORouteSetupVw retObj = new DAORouteSetupVw();
						retObj._routeId					 = Convert.IsDBNull(row["RouteId"]) ? (Int32?)null : (Int32?)row["RouteId"];
						retObj._routeTypeId					 = Convert.IsDBNull(row["RouteTypeId"]) ? (Int32?)null : (Int32?)row["RouteTypeId"];
						retObj._branchId					 = Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"];
						retObj._routeCode					 = Convert.IsDBNull(row["RouteCode"]) ? null : (string)row["RouteCode"];
						retObj._routeNameEn					 = Convert.IsDBNull(row["RouteNameEn"]) ? null : (string)row["RouteNameEn"];
						retObj._routeNameAr					 = Convert.IsDBNull(row["RouteNameAr"]) ? null : (string)row["RouteNameAr"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
						retObj._canEdit					 = Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"];
						retObj._canDelete					 = Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"];
						retObj._branchCode					 = Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"];
						retObj._branchNameAr					 = Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"];
						retObj._branchNameEn					 = Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"];
						retObj._routeTypeCode					 = Convert.IsDBNull(row["RouteTypeCode"]) ? null : (string)row["RouteTypeCode"];
						retObj._routeTypeNameEn					 = Convert.IsDBNull(row["RouteTypeNameEn"]) ? null : (string)row["RouteTypeNameEn"];
						retObj._routeTypeNameAr					 = Convert.IsDBNull(row["RouteTypeNameAr"]) ? null : (string)row["RouteTypeNameAr"];
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
			command.CommandText = InlineProcs.ctprRouteSetupVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiRouteSetupVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprRouteSetupVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("RouteSetupVw");
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
						if (string.Compare(projection.Member, "RouteId", true) == 0) lst.Add(Convert.IsDBNull(row["RouteId"]) ? (Int32?)null : (Int32?)row["RouteId"]);
						if (string.Compare(projection.Member, "RouteTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["RouteTypeId"]) ? (Int32?)null : (Int32?)row["RouteTypeId"]);
						if (string.Compare(projection.Member, "BranchId", true) == 0) lst.Add(Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"]);
						if (string.Compare(projection.Member, "RouteCode", true) == 0) lst.Add(Convert.IsDBNull(row["RouteCode"]) ? null : (string)row["RouteCode"]);
						if (string.Compare(projection.Member, "RouteNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["RouteNameEn"]) ? null : (string)row["RouteNameEn"]);
						if (string.Compare(projection.Member, "RouteNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["RouteNameAr"]) ? null : (string)row["RouteNameAr"]);
						if (string.Compare(projection.Member, "IsActive", true) == 0) lst.Add(Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"]);
						if (string.Compare(projection.Member, "Color", true) == 0) lst.Add(Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"]);
						if (string.Compare(projection.Member, "Icon", true) == 0) lst.Add(Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"]);
						if (string.Compare(projection.Member, "CanEdit", true) == 0) lst.Add(Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"]);
						if (string.Compare(projection.Member, "CanDelete", true) == 0) lst.Add(Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"]);
						if (string.Compare(projection.Member, "BranchCode", true) == 0) lst.Add(Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"]);
						if (string.Compare(projection.Member, "BranchNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"]);
						if (string.Compare(projection.Member, "BranchNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"]);
						if (string.Compare(projection.Member, "RouteTypeCode", true) == 0) lst.Add(Convert.IsDBNull(row["RouteTypeCode"]) ? null : (string)row["RouteTypeCode"]);
						if (string.Compare(projection.Member, "RouteTypeNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["RouteTypeNameEn"]) ? null : (string)row["RouteTypeNameEn"]);
						if (string.Compare(projection.Member, "RouteTypeNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["RouteTypeNameAr"]) ? null : (string)row["RouteTypeNameAr"]);
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
		///This method returns all data rows in the table using criteriaquery api RouteSetupVw
		///</Summary>
		///<returns>
		///IList-DAORouteSetupVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAORouteSetupVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprRouteSetupVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("RouteSetupVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAORouteSetupVw> objList = new List<DAORouteSetupVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAORouteSetupVw retObj = new DAORouteSetupVw();
						retObj._routeId					 = Convert.IsDBNull(row["RouteId"]) ? (Int32?)null : (Int32?)row["RouteId"];
						retObj._routeTypeId					 = Convert.IsDBNull(row["RouteTypeId"]) ? (Int32?)null : (Int32?)row["RouteTypeId"];
						retObj._branchId					 = Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"];
						retObj._routeCode					 = Convert.IsDBNull(row["RouteCode"]) ? null : (string)row["RouteCode"];
						retObj._routeNameEn					 = Convert.IsDBNull(row["RouteNameEn"]) ? null : (string)row["RouteNameEn"];
						retObj._routeNameAr					 = Convert.IsDBNull(row["RouteNameAr"]) ? null : (string)row["RouteNameAr"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
						retObj._canEdit					 = Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"];
						retObj._canDelete					 = Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"];
						retObj._branchCode					 = Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"];
						retObj._branchNameAr					 = Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"];
						retObj._branchNameEn					 = Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"];
						retObj._routeTypeCode					 = Convert.IsDBNull(row["RouteTypeCode"]) ? null : (string)row["RouteTypeCode"];
						retObj._routeTypeNameEn					 = Convert.IsDBNull(row["RouteTypeNameEn"]) ? null : (string)row["RouteTypeNameEn"];
						retObj._routeTypeNameAr					 = Convert.IsDBNull(row["RouteTypeNameAr"]) ? null : (string)row["RouteTypeNameAr"];
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
		///This method returns all data rows in the table using criteriaquery api RouteSetupVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprRouteSetupVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public Int32? RouteTypeId
		{
			get
			{
				return _routeTypeId;
			}
			set
			{
				_routeTypeId = value;
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

		public string RouteCode
		{
			get
			{
				return _routeCode;
			}
			set
			{
				_routeCode = value;
			}
		}

		public string RouteNameEn
		{
			get
			{
				return _routeNameEn;
			}
			set
			{
				_routeNameEn = value;
			}
		}

		public string RouteNameAr
		{
			get
			{
				return _routeNameAr;
			}
			set
			{
				_routeNameAr = value;
			}
		}

		public bool? IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActive = value;
			}
		}

		public string Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
			}
		}

		public string Icon
		{
			get
			{
				return _icon;
			}
			set
			{
				_icon = value;
			}
		}

		public bool? CanEdit
		{
			get
			{
				return _canEdit;
			}
			set
			{
				_canEdit = value;
			}
		}

		public bool? CanDelete
		{
			get
			{
				return _canDelete;
			}
			set
			{
				_canDelete = value;
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

		public string RouteTypeCode
		{
			get
			{
				return _routeTypeCode;
			}
			set
			{
				_routeTypeCode = value;
			}
		}

		public string RouteTypeNameEn
		{
			get
			{
				return _routeTypeNameEn;
			}
			set
			{
				_routeTypeNameEn = value;
			}
		}

		public string RouteTypeNameAr
		{
			get
			{
				return _routeTypeNameAr;
			}
			set
			{
				_routeTypeNameAr = value;
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
		internal static string ctprRouteSetupVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[RouteId]
			,[RouteTypeId]
			,[BranchId]
			,[RouteCode]
			,[RouteNameEn]
			,[RouteNameAr]
			,[IsActive]
			,[Color]
			,[Icon]
			,[CanEdit]
			,[CanDelete]
			,[BranchCode]
			,[BranchNameAr]
			,[BranchNameEn]
			,[RouteTypeCode]
			,[RouteTypeNameEn]
			,[RouteTypeNameAr]
			FROM [dbo].[RouteSetupVw]
			";

		internal static string ctprRouteSetupVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[RouteSetupVw]
			";

		internal static string ctprRouteSetupVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[RouteSetupVw]
			##CRITERIA##
			";

		internal static string ctprRouteSetupVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[RouteId]
			,[RouteTypeId]
			,[BranchId]
			,[RouteCode]
			,[RouteNameEn]
			,[RouteNameAr]
			,[IsActive]
			,[Color]
			,[Icon]
			,[CanEdit]
			,[CanDelete]
			,[BranchCode]
			,[BranchNameAr]
			,[BranchNameEn]
			,[RouteTypeCode]
			,[RouteTypeNameEn]
			,[RouteTypeNameAr]
			FROM [dbo].[RouteSetupVw]
			##CRITERIA##
			";

		internal static string ctprRouteSetupVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[RouteSetupVw]
			##CRITERIA##
			";

	}
}
#endregion