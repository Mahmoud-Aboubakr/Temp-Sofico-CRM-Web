/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 7/22/2023 2:01:01 PM
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SofiForce.DataObjects.Interfaces;

namespace SofiForce.DataObjects
{
	public partial class DAOPromtionCriteriaClientAttrCustomVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _clientCustomId;
		protected Int32? _clientAttributeId;
		protected string _valueFrom;
		protected bool? _isActive;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected string _clientNameAr;
		protected string _clientNameEn;
		#endregion

		#region class methods
		public DAOPromtionCriteriaClientAttrCustomVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table PromtionCriteriaClientAttrCustomVw
		///</Summary>
		///<returns>
		///IList-DAOPromtionCriteriaClientAttrCustomVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOPromtionCriteriaClientAttrCustomVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprPromtionCriteriaClientAttrCustomVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromtionCriteriaClientAttrCustomVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOPromtionCriteriaClientAttrCustomVw> objList = new List<DAOPromtionCriteriaClientAttrCustomVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOPromtionCriteriaClientAttrCustomVw retObj = new DAOPromtionCriteriaClientAttrCustomVw();
						retObj._clientCustomId					 = Convert.IsDBNull(row["ClientCustomId"]) ? (Int32?)null : (Int32?)row["ClientCustomId"];
						retObj._clientAttributeId					 = Convert.IsDBNull(row["ClientAttributeId"]) ? (Int32?)null : (Int32?)row["ClientAttributeId"];
						retObj._valueFrom					 = Convert.IsDBNull(row["ValueFrom"]) ? null : (string)row["ValueFrom"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._cBy					 = Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"];
						retObj._cDate					 = Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"];
						retObj._eBy					 = Convert.IsDBNull(row["EBy"]) ? (Int32?)null : (Int32?)row["EBy"];
						retObj._eDate					 = Convert.IsDBNull(row["EDate"]) ? (DateTime?)null : (DateTime?)row["EDate"];
						retObj._clientNameAr					 = Convert.IsDBNull(row["ClientNameAr"]) ? null : (string)row["ClientNameAr"];
						retObj._clientNameEn					 = Convert.IsDBNull(row["ClientNameEn"]) ? null : (string)row["ClientNameEn"];
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
			command.CommandText = InlineProcs.ctprPromtionCriteriaClientAttrCustomVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiPromtionCriteriaClientAttrCustomVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromtionCriteriaClientAttrCustomVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromtionCriteriaClientAttrCustomVw");
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
						if (string.Compare(projection.Member, "ClientCustomId", true) == 0) lst.Add(Convert.IsDBNull(row["ClientCustomId"]) ? (Int32?)null : (Int32?)row["ClientCustomId"]);
						if (string.Compare(projection.Member, "ClientAttributeId", true) == 0) lst.Add(Convert.IsDBNull(row["ClientAttributeId"]) ? (Int32?)null : (Int32?)row["ClientAttributeId"]);
						if (string.Compare(projection.Member, "ValueFrom", true) == 0) lst.Add(Convert.IsDBNull(row["ValueFrom"]) ? null : (string)row["ValueFrom"]);
						if (string.Compare(projection.Member, "IsActive", true) == 0) lst.Add(Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"]);
						if (string.Compare(projection.Member, "CBy", true) == 0) lst.Add(Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"]);
						if (string.Compare(projection.Member, "CDate", true) == 0) lst.Add(Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"]);
						if (string.Compare(projection.Member, "EBy", true) == 0) lst.Add(Convert.IsDBNull(row["EBy"]) ? (Int32?)null : (Int32?)row["EBy"]);
						if (string.Compare(projection.Member, "EDate", true) == 0) lst.Add(Convert.IsDBNull(row["EDate"]) ? (DateTime?)null : (DateTime?)row["EDate"]);
						if (string.Compare(projection.Member, "ClientNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["ClientNameAr"]) ? null : (string)row["ClientNameAr"]);
						if (string.Compare(projection.Member, "ClientNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["ClientNameEn"]) ? null : (string)row["ClientNameEn"]);
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
		///This method returns all data rows in the table using criteriaquery api PromtionCriteriaClientAttrCustomVw
		///</Summary>
		///<returns>
		///IList-DAOPromtionCriteriaClientAttrCustomVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOPromtionCriteriaClientAttrCustomVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromtionCriteriaClientAttrCustomVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromtionCriteriaClientAttrCustomVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOPromtionCriteriaClientAttrCustomVw> objList = new List<DAOPromtionCriteriaClientAttrCustomVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOPromtionCriteriaClientAttrCustomVw retObj = new DAOPromtionCriteriaClientAttrCustomVw();
						retObj._clientCustomId					 = Convert.IsDBNull(row["ClientCustomId"]) ? (Int32?)null : (Int32?)row["ClientCustomId"];
						retObj._clientAttributeId					 = Convert.IsDBNull(row["ClientAttributeId"]) ? (Int32?)null : (Int32?)row["ClientAttributeId"];
						retObj._valueFrom					 = Convert.IsDBNull(row["ValueFrom"]) ? null : (string)row["ValueFrom"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._cBy					 = Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"];
						retObj._cDate					 = Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"];
						retObj._eBy					 = Convert.IsDBNull(row["EBy"]) ? (Int32?)null : (Int32?)row["EBy"];
						retObj._eDate					 = Convert.IsDBNull(row["EDate"]) ? (DateTime?)null : (DateTime?)row["EDate"];
						retObj._clientNameAr					 = Convert.IsDBNull(row["ClientNameAr"]) ? null : (string)row["ClientNameAr"];
						retObj._clientNameEn					 = Convert.IsDBNull(row["ClientNameEn"]) ? null : (string)row["ClientNameEn"];
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
		///This method returns all data rows in the table using criteriaquery api PromtionCriteriaClientAttrCustomVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromtionCriteriaClientAttrCustomVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public Int32? ClientCustomId
		{
			get
			{
				return _clientCustomId;
			}
			set
			{
				_clientCustomId = value;
			}
		}

		public Int32? ClientAttributeId
		{
			get
			{
				return _clientAttributeId;
			}
			set
			{
				_clientAttributeId = value;
			}
		}

		public string ValueFrom
		{
			get
			{
				return _valueFrom;
			}
			set
			{
				_valueFrom = value;
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

		public Int32? CBy
		{
			get
			{
				return _cBy;
			}
			set
			{
				_cBy = value;
			}
		}

		public DateTime? CDate
		{
			get
			{
				return _cDate;
			}
			set
			{
				_cDate = value;
			}
		}

		public Int32? EBy
		{
			get
			{
				return _eBy;
			}
			set
			{
				_eBy = value;
			}
		}

		public DateTime? EDate
		{
			get
			{
				return _eDate;
			}
			set
			{
				_eDate = value;
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

		#endregion
	}
}

#region inline sql procs
namespace SofiForce.DataObjects
{
	public partial class InlineProcs
	{
		internal static string ctprPromtionCriteriaClientAttrCustomVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[ClientCustomId]
			,[ClientAttributeId]
			,[ValueFrom]
			,[IsActive]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			,[ClientNameAr]
			,[ClientNameEn]
			FROM [dbo].[PromtionCriteriaClientAttrCustomVw]
			";

		internal static string ctprPromtionCriteriaClientAttrCustomVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[PromtionCriteriaClientAttrCustomVw]
			";

		internal static string ctprPromtionCriteriaClientAttrCustomVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[PromtionCriteriaClientAttrCustomVw]
			##CRITERIA##
			";

		internal static string ctprPromtionCriteriaClientAttrCustomVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[ClientCustomId]
			,[ClientAttributeId]
			,[ValueFrom]
			,[IsActive]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			,[ClientNameAr]
			,[ClientNameEn]
			FROM [dbo].[PromtionCriteriaClientAttrCustomVw]
			##CRITERIA##
			";

		internal static string ctprPromtionCriteriaClientAttrCustomVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[PromtionCriteriaClientAttrCustomVw]
			##CRITERIA##
			";

	}
}
#endregion
