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
	public partial class DAOPromotionCriteriaVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _criteriaId;
		protected Int32? _promotionId;
		protected Int32? _groupId;
		protected Int32? _attributeId;
		protected string _valueFrom;
		protected bool? _isActive;
		protected bool? _excluded;
		protected string _attributeCode;
		protected string _attributeNameAr;
		protected string _attributeNameEn;
		protected bool? _isCustom;
		protected Int32? _groupNo;
		protected decimal? _slice;
		protected DateTime? _validTo;
		protected DateTime? _validFrom;
		protected string _promotionCode;
		protected Int32? _promotionTypeId;
		protected Int32? _priority;
		protected Int32? _repeats;
		protected Int32? _promotionGroupId;
		#endregion

		#region class methods
		public DAOPromotionCriteriaVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table PromotionCriteriaVw
		///</Summary>
		///<returns>
		///IList-DAOPromotionCriteriaVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOPromotionCriteriaVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprPromotionCriteriaVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromotionCriteriaVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOPromotionCriteriaVw> objList = new List<DAOPromotionCriteriaVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOPromotionCriteriaVw retObj = new DAOPromotionCriteriaVw();
						retObj._criteriaId					 = Convert.IsDBNull(row["CriteriaId"]) ? (Int32?)null : (Int32?)row["CriteriaId"];
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._groupId					 = Convert.IsDBNull(row["GroupId"]) ? (Int32?)null : (Int32?)row["GroupId"];
						retObj._attributeId					 = Convert.IsDBNull(row["AttributeId"]) ? (Int32?)null : (Int32?)row["AttributeId"];
						retObj._valueFrom					 = Convert.IsDBNull(row["ValueFrom"]) ? null : (string)row["ValueFrom"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._excluded					 = Convert.IsDBNull(row["Excluded"]) ? (bool?)null : (bool?)row["Excluded"];
						retObj._attributeCode					 = Convert.IsDBNull(row["AttributeCode"]) ? null : (string)row["AttributeCode"];
						retObj._attributeNameAr					 = Convert.IsDBNull(row["AttributeNameAr"]) ? null : (string)row["AttributeNameAr"];
						retObj._attributeNameEn					 = Convert.IsDBNull(row["AttributeNameEn"]) ? null : (string)row["AttributeNameEn"];
						retObj._isCustom					 = Convert.IsDBNull(row["IsCustom"]) ? (bool?)null : (bool?)row["IsCustom"];
						retObj._groupNo					 = Convert.IsDBNull(row["GroupNo"]) ? (Int32?)null : (Int32?)row["GroupNo"];
						retObj._slice					 = Convert.IsDBNull(row["Slice"]) ? (decimal?)null : (decimal?)row["Slice"];
						retObj._validTo					 = Convert.IsDBNull(row["ValidTo"]) ? (DateTime?)null : (DateTime?)row["ValidTo"];
						retObj._validFrom					 = Convert.IsDBNull(row["ValidFrom"]) ? (DateTime?)null : (DateTime?)row["ValidFrom"];
						retObj._promotionCode					 = Convert.IsDBNull(row["PromotionCode"]) ? null : (string)row["PromotionCode"];
						retObj._promotionTypeId					 = Convert.IsDBNull(row["PromotionTypeId"]) ? (Int32?)null : (Int32?)row["PromotionTypeId"];
						retObj._priority					 = Convert.IsDBNull(row["Priority"]) ? (Int32?)null : (Int32?)row["Priority"];
						retObj._repeats					 = Convert.IsDBNull(row["Repeats"]) ? (Int32?)null : (Int32?)row["Repeats"];
						retObj._promotionGroupId					 = Convert.IsDBNull(row["PromotionGroupId"]) ? (Int32?)null : (Int32?)row["PromotionGroupId"];
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
			command.CommandText = InlineProcs.ctprPromotionCriteriaVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiPromotionCriteriaVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromotionCriteriaVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromotionCriteriaVw");
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
						if (string.Compare(projection.Member, "CriteriaId", true) == 0) lst.Add(Convert.IsDBNull(row["CriteriaId"]) ? (Int32?)null : (Int32?)row["CriteriaId"]);
						if (string.Compare(projection.Member, "PromotionId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"]);
						if (string.Compare(projection.Member, "GroupId", true) == 0) lst.Add(Convert.IsDBNull(row["GroupId"]) ? (Int32?)null : (Int32?)row["GroupId"]);
						if (string.Compare(projection.Member, "AttributeId", true) == 0) lst.Add(Convert.IsDBNull(row["AttributeId"]) ? (Int32?)null : (Int32?)row["AttributeId"]);
						if (string.Compare(projection.Member, "ValueFrom", true) == 0) lst.Add(Convert.IsDBNull(row["ValueFrom"]) ? null : (string)row["ValueFrom"]);
						if (string.Compare(projection.Member, "IsActive", true) == 0) lst.Add(Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"]);
						if (string.Compare(projection.Member, "Excluded", true) == 0) lst.Add(Convert.IsDBNull(row["Excluded"]) ? (bool?)null : (bool?)row["Excluded"]);
						if (string.Compare(projection.Member, "AttributeCode", true) == 0) lst.Add(Convert.IsDBNull(row["AttributeCode"]) ? null : (string)row["AttributeCode"]);
						if (string.Compare(projection.Member, "AttributeNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["AttributeNameAr"]) ? null : (string)row["AttributeNameAr"]);
						if (string.Compare(projection.Member, "AttributeNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["AttributeNameEn"]) ? null : (string)row["AttributeNameEn"]);
						if (string.Compare(projection.Member, "IsCustom", true) == 0) lst.Add(Convert.IsDBNull(row["IsCustom"]) ? (bool?)null : (bool?)row["IsCustom"]);
						if (string.Compare(projection.Member, "GroupNo", true) == 0) lst.Add(Convert.IsDBNull(row["GroupNo"]) ? (Int32?)null : (Int32?)row["GroupNo"]);
						if (string.Compare(projection.Member, "Slice", true) == 0) lst.Add(Convert.IsDBNull(row["Slice"]) ? (decimal?)null : (decimal?)row["Slice"]);
						if (string.Compare(projection.Member, "ValidTo", true) == 0) lst.Add(Convert.IsDBNull(row["ValidTo"]) ? (DateTime?)null : (DateTime?)row["ValidTo"]);
						if (string.Compare(projection.Member, "ValidFrom", true) == 0) lst.Add(Convert.IsDBNull(row["ValidFrom"]) ? (DateTime?)null : (DateTime?)row["ValidFrom"]);
						if (string.Compare(projection.Member, "PromotionCode", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionCode"]) ? null : (string)row["PromotionCode"]);
						if (string.Compare(projection.Member, "PromotionTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionTypeId"]) ? (Int32?)null : (Int32?)row["PromotionTypeId"]);
						if (string.Compare(projection.Member, "Priority", true) == 0) lst.Add(Convert.IsDBNull(row["Priority"]) ? (Int32?)null : (Int32?)row["Priority"]);
						if (string.Compare(projection.Member, "Repeats", true) == 0) lst.Add(Convert.IsDBNull(row["Repeats"]) ? (Int32?)null : (Int32?)row["Repeats"]);
						if (string.Compare(projection.Member, "PromotionGroupId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionGroupId"]) ? (Int32?)null : (Int32?)row["PromotionGroupId"]);
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
		///This method returns all data rows in the table using criteriaquery api PromotionCriteriaVw
		///</Summary>
		///<returns>
		///IList-DAOPromotionCriteriaVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOPromotionCriteriaVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromotionCriteriaVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromotionCriteriaVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOPromotionCriteriaVw> objList = new List<DAOPromotionCriteriaVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOPromotionCriteriaVw retObj = new DAOPromotionCriteriaVw();
						retObj._criteriaId					 = Convert.IsDBNull(row["CriteriaId"]) ? (Int32?)null : (Int32?)row["CriteriaId"];
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._groupId					 = Convert.IsDBNull(row["GroupId"]) ? (Int32?)null : (Int32?)row["GroupId"];
						retObj._attributeId					 = Convert.IsDBNull(row["AttributeId"]) ? (Int32?)null : (Int32?)row["AttributeId"];
						retObj._valueFrom					 = Convert.IsDBNull(row["ValueFrom"]) ? null : (string)row["ValueFrom"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._excluded					 = Convert.IsDBNull(row["Excluded"]) ? (bool?)null : (bool?)row["Excluded"];
						retObj._attributeCode					 = Convert.IsDBNull(row["AttributeCode"]) ? null : (string)row["AttributeCode"];
						retObj._attributeNameAr					 = Convert.IsDBNull(row["AttributeNameAr"]) ? null : (string)row["AttributeNameAr"];
						retObj._attributeNameEn					 = Convert.IsDBNull(row["AttributeNameEn"]) ? null : (string)row["AttributeNameEn"];
						retObj._isCustom					 = Convert.IsDBNull(row["IsCustom"]) ? (bool?)null : (bool?)row["IsCustom"];
						retObj._groupNo					 = Convert.IsDBNull(row["GroupNo"]) ? (Int32?)null : (Int32?)row["GroupNo"];
						retObj._slice					 = Convert.IsDBNull(row["Slice"]) ? (decimal?)null : (decimal?)row["Slice"];
						retObj._validTo					 = Convert.IsDBNull(row["ValidTo"]) ? (DateTime?)null : (DateTime?)row["ValidTo"];
						retObj._validFrom					 = Convert.IsDBNull(row["ValidFrom"]) ? (DateTime?)null : (DateTime?)row["ValidFrom"];
						retObj._promotionCode					 = Convert.IsDBNull(row["PromotionCode"]) ? null : (string)row["PromotionCode"];
						retObj._promotionTypeId					 = Convert.IsDBNull(row["PromotionTypeId"]) ? (Int32?)null : (Int32?)row["PromotionTypeId"];
						retObj._priority					 = Convert.IsDBNull(row["Priority"]) ? (Int32?)null : (Int32?)row["Priority"];
						retObj._repeats					 = Convert.IsDBNull(row["Repeats"]) ? (Int32?)null : (Int32?)row["Repeats"];
						retObj._promotionGroupId					 = Convert.IsDBNull(row["PromotionGroupId"]) ? (Int32?)null : (Int32?)row["PromotionGroupId"];
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
		///This method returns all data rows in the table using criteriaquery api PromotionCriteriaVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromotionCriteriaVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public Int32? CriteriaId
		{
			get
			{
				return _criteriaId;
			}
			set
			{
				_criteriaId = value;
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

		public Int32? AttributeId
		{
			get
			{
				return _attributeId;
			}
			set
			{
				_attributeId = value;
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

		public bool? Excluded
		{
			get
			{
				return _excluded;
			}
			set
			{
				_excluded = value;
			}
		}

		public string AttributeCode
		{
			get
			{
				return _attributeCode;
			}
			set
			{
				_attributeCode = value;
			}
		}

		public string AttributeNameAr
		{
			get
			{
				return _attributeNameAr;
			}
			set
			{
				_attributeNameAr = value;
			}
		}

		public string AttributeNameEn
		{
			get
			{
				return _attributeNameEn;
			}
			set
			{
				_attributeNameEn = value;
			}
		}

		public bool? IsCustom
		{
			get
			{
				return _isCustom;
			}
			set
			{
				_isCustom = value;
			}
		}

		public Int32? GroupNo
		{
			get
			{
				return _groupNo;
			}
			set
			{
				_groupNo = value;
			}
		}

		public decimal? Slice
		{
			get
			{
				return _slice;
			}
			set
			{
				_slice = value;
			}
		}

		public DateTime? ValidTo
		{
			get
			{
				return _validTo;
			}
			set
			{
				_validTo = value;
			}
		}

		public DateTime? ValidFrom
		{
			get
			{
				return _validFrom;
			}
			set
			{
				_validFrom = value;
			}
		}

		public string PromotionCode
		{
			get
			{
				return _promotionCode;
			}
			set
			{
				_promotionCode = value;
			}
		}

		public Int32? PromotionTypeId
		{
			get
			{
				return _promotionTypeId;
			}
			set
			{
				_promotionTypeId = value;
			}
		}

		public Int32? Priority
		{
			get
			{
				return _priority;
			}
			set
			{
				_priority = value;
			}
		}

		public Int32? Repeats
		{
			get
			{
				return _repeats;
			}
			set
			{
				_repeats = value;
			}
		}

		public Int32? PromotionGroupId
		{
			get
			{
				return _promotionGroupId;
			}
			set
			{
				_promotionGroupId = value;
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
		internal static string ctprPromotionCriteriaVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[CriteriaId]
			,[PromotionId]
			,[GroupId]
			,[AttributeId]
			,[ValueFrom]
			,[IsActive]
			,[Excluded]
			,[AttributeCode]
			,[AttributeNameAr]
			,[AttributeNameEn]
			,[IsCustom]
			,[GroupNo]
			,[Slice]
			,[ValidTo]
			,[ValidFrom]
			,[PromotionCode]
			,[PromotionTypeId]
			,[Priority]
			,[Repeats]
			,[PromotionGroupId]
			FROM [dbo].[PromotionCriteriaVw]
			";

		internal static string ctprPromotionCriteriaVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[PromotionCriteriaVw]
			";

		internal static string ctprPromotionCriteriaVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[PromotionCriteriaVw]
			##CRITERIA##
			";

		internal static string ctprPromotionCriteriaVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[CriteriaId]
			,[PromotionId]
			,[GroupId]
			,[AttributeId]
			,[ValueFrom]
			,[IsActive]
			,[Excluded]
			,[AttributeCode]
			,[AttributeNameAr]
			,[AttributeNameEn]
			,[IsCustom]
			,[GroupNo]
			,[Slice]
			,[ValidTo]
			,[ValidFrom]
			,[PromotionCode]
			,[PromotionTypeId]
			,[Priority]
			,[Repeats]
			,[PromotionGroupId]
			FROM [dbo].[PromotionCriteriaVw]
			##CRITERIA##
			";

		internal static string ctprPromotionCriteriaVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[PromotionCriteriaVw]
			##CRITERIA##
			";

	}
}
#endregion
