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
	public partial class DAOPromotionMixGroupVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _groupId;
		protected Int32? _groupNo;
		protected Int32? _promotionId;
		protected decimal? _slice;
		protected bool? _isActive;
		protected DateTime? _validTo;
		protected DateTime? _validFrom;
		protected Int32? _repeatTypeId;
		protected Int32? _promotionCategoryId;
		protected bool? _isApproved;
		protected Int32? _promotionGroupId;
		protected Int32? _promotionTypeId;
		protected Int32? _priority;
		#endregion

		#region class methods
		public DAOPromotionMixGroupVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table PromotionMixGroupVw
		///</Summary>
		///<returns>
		///IList-DAOPromotionMixGroupVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOPromotionMixGroupVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprPromotionMixGroupVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromotionMixGroupVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOPromotionMixGroupVw> objList = new List<DAOPromotionMixGroupVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOPromotionMixGroupVw retObj = new DAOPromotionMixGroupVw();
						retObj._groupId					 = Convert.IsDBNull(row["GroupId"]) ? (Int32?)null : (Int32?)row["GroupId"];
						retObj._groupNo					 = Convert.IsDBNull(row["GroupNo"]) ? (Int32?)null : (Int32?)row["GroupNo"];
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._slice					 = Convert.IsDBNull(row["Slice"]) ? (decimal?)null : (decimal?)row["Slice"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._validTo					 = Convert.IsDBNull(row["ValidTo"]) ? (DateTime?)null : (DateTime?)row["ValidTo"];
						retObj._validFrom					 = Convert.IsDBNull(row["ValidFrom"]) ? (DateTime?)null : (DateTime?)row["ValidFrom"];
						retObj._repeatTypeId					 = Convert.IsDBNull(row["RepeatTypeId"]) ? (Int32?)null : (Int32?)row["RepeatTypeId"];
						retObj._promotionCategoryId					 = Convert.IsDBNull(row["PromotionCategoryId"]) ? (Int32?)null : (Int32?)row["PromotionCategoryId"];
						retObj._isApproved					 = Convert.IsDBNull(row["IsApproved"]) ? (bool?)null : (bool?)row["IsApproved"];
						retObj._promotionGroupId					 = Convert.IsDBNull(row["PromotionGroupId"]) ? (Int32?)null : (Int32?)row["PromotionGroupId"];
						retObj._promotionTypeId					 = Convert.IsDBNull(row["PromotionTypeId"]) ? (Int32?)null : (Int32?)row["PromotionTypeId"];
						retObj._priority					 = Convert.IsDBNull(row["Priority"]) ? (Int32?)null : (Int32?)row["Priority"];
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
			command.CommandText = InlineProcs.ctprPromotionMixGroupVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiPromotionMixGroupVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromotionMixGroupVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromotionMixGroupVw");
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
						if (string.Compare(projection.Member, "GroupId", true) == 0) lst.Add(Convert.IsDBNull(row["GroupId"]) ? (Int32?)null : (Int32?)row["GroupId"]);
						if (string.Compare(projection.Member, "GroupNo", true) == 0) lst.Add(Convert.IsDBNull(row["GroupNo"]) ? (Int32?)null : (Int32?)row["GroupNo"]);
						if (string.Compare(projection.Member, "PromotionId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"]);
						if (string.Compare(projection.Member, "Slice", true) == 0) lst.Add(Convert.IsDBNull(row["Slice"]) ? (decimal?)null : (decimal?)row["Slice"]);
						if (string.Compare(projection.Member, "IsActive", true) == 0) lst.Add(Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"]);
						if (string.Compare(projection.Member, "ValidTo", true) == 0) lst.Add(Convert.IsDBNull(row["ValidTo"]) ? (DateTime?)null : (DateTime?)row["ValidTo"]);
						if (string.Compare(projection.Member, "ValidFrom", true) == 0) lst.Add(Convert.IsDBNull(row["ValidFrom"]) ? (DateTime?)null : (DateTime?)row["ValidFrom"]);
						if (string.Compare(projection.Member, "RepeatTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["RepeatTypeId"]) ? (Int32?)null : (Int32?)row["RepeatTypeId"]);
						if (string.Compare(projection.Member, "PromotionCategoryId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionCategoryId"]) ? (Int32?)null : (Int32?)row["PromotionCategoryId"]);
						if (string.Compare(projection.Member, "IsApproved", true) == 0) lst.Add(Convert.IsDBNull(row["IsApproved"]) ? (bool?)null : (bool?)row["IsApproved"]);
						if (string.Compare(projection.Member, "PromotionGroupId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionGroupId"]) ? (Int32?)null : (Int32?)row["PromotionGroupId"]);
						if (string.Compare(projection.Member, "PromotionTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionTypeId"]) ? (Int32?)null : (Int32?)row["PromotionTypeId"]);
						if (string.Compare(projection.Member, "Priority", true) == 0) lst.Add(Convert.IsDBNull(row["Priority"]) ? (Int32?)null : (Int32?)row["Priority"]);
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
		///This method returns all data rows in the table using criteriaquery api PromotionMixGroupVw
		///</Summary>
		///<returns>
		///IList-DAOPromotionMixGroupVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOPromotionMixGroupVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromotionMixGroupVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromotionMixGroupVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOPromotionMixGroupVw> objList = new List<DAOPromotionMixGroupVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOPromotionMixGroupVw retObj = new DAOPromotionMixGroupVw();
						retObj._groupId					 = Convert.IsDBNull(row["GroupId"]) ? (Int32?)null : (Int32?)row["GroupId"];
						retObj._groupNo					 = Convert.IsDBNull(row["GroupNo"]) ? (Int32?)null : (Int32?)row["GroupNo"];
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._slice					 = Convert.IsDBNull(row["Slice"]) ? (decimal?)null : (decimal?)row["Slice"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._validTo					 = Convert.IsDBNull(row["ValidTo"]) ? (DateTime?)null : (DateTime?)row["ValidTo"];
						retObj._validFrom					 = Convert.IsDBNull(row["ValidFrom"]) ? (DateTime?)null : (DateTime?)row["ValidFrom"];
						retObj._repeatTypeId					 = Convert.IsDBNull(row["RepeatTypeId"]) ? (Int32?)null : (Int32?)row["RepeatTypeId"];
						retObj._promotionCategoryId					 = Convert.IsDBNull(row["PromotionCategoryId"]) ? (Int32?)null : (Int32?)row["PromotionCategoryId"];
						retObj._isApproved					 = Convert.IsDBNull(row["IsApproved"]) ? (bool?)null : (bool?)row["IsApproved"];
						retObj._promotionGroupId					 = Convert.IsDBNull(row["PromotionGroupId"]) ? (Int32?)null : (Int32?)row["PromotionGroupId"];
						retObj._promotionTypeId					 = Convert.IsDBNull(row["PromotionTypeId"]) ? (Int32?)null : (Int32?)row["PromotionTypeId"];
						retObj._priority					 = Convert.IsDBNull(row["Priority"]) ? (Int32?)null : (Int32?)row["Priority"];
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
		///This method returns all data rows in the table using criteriaquery api PromotionMixGroupVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromotionMixGroupVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public Int32? RepeatTypeId
		{
			get
			{
				return _repeatTypeId;
			}
			set
			{
				_repeatTypeId = value;
			}
		}

		public Int32? PromotionCategoryId
		{
			get
			{
				return _promotionCategoryId;
			}
			set
			{
				_promotionCategoryId = value;
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

		#endregion
	}
}

#region inline sql procs
namespace SofiForce.DataObjects
{
	public partial class InlineProcs
	{
		internal static string ctprPromotionMixGroupVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[GroupId]
			,[GroupNo]
			,[PromotionId]
			,[Slice]
			,[IsActive]
			,[ValidTo]
			,[ValidFrom]
			,[RepeatTypeId]
			,[PromotionCategoryId]
			,[IsApproved]
			,[PromotionGroupId]
			,[PromotionTypeId]
			,[Priority]
			FROM [dbo].[PromotionMixGroupVw]
			";

		internal static string ctprPromotionMixGroupVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[PromotionMixGroupVw]
			";

		internal static string ctprPromotionMixGroupVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[PromotionMixGroupVw]
			##CRITERIA##
			";

		internal static string ctprPromotionMixGroupVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[GroupId]
			,[GroupNo]
			,[PromotionId]
			,[Slice]
			,[IsActive]
			,[ValidTo]
			,[ValidFrom]
			,[RepeatTypeId]
			,[PromotionCategoryId]
			,[IsApproved]
			,[PromotionGroupId]
			,[PromotionTypeId]
			,[Priority]
			FROM [dbo].[PromotionMixGroupVw]
			##CRITERIA##
			";

		internal static string ctprPromotionMixGroupVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[PromotionMixGroupVw]
			##CRITERIA##
			";

	}
}
#endregion
