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
	public partial class DAOPromotionVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _promotionId;
		protected string _promotionCode;
		protected Int32? _companyId;
		protected DateTime? _validFrom;
		protected DateTime? _validTo;
		protected bool? _isActive;
		protected Int32? _promotionTypeId;
		protected Int32? _priority;
		protected Int32? _repeats;
		protected string _icon;
		protected string _color;
		protected string _promotionDesc;
		protected Int32? _promotionGroupId;
		protected Int32? _displayOrder;
		protected bool? _enableNotification;
		protected DateTime? _notificationDate;
		protected bool? _notificationDone;
		protected string _promotionTypeCode;
		protected string _promotionTypeNameAr;
		protected string _promotionTypeNameEn;
		protected Int32? _promotionOutputId;
		protected Int32? _promotionInputId;
		protected string _promotionGroupCode;
		protected string _promotionGroupNameEn;
		protected string _promotionGroupNameAr;
		protected string _repeatTypeNameEn;
		protected string _repeatTypeNameAr;
		protected Int32? _repeatTypeId;
		protected bool? _isApproved;
		protected Int32? _promotionCategoryId;
		protected string _vendorCode;
		#endregion

		#region class methods
		public DAOPromotionVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table PromotionVw
		///</Summary>
		///<returns>
		///IList-DAOPromotionVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOPromotionVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprPromotionVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromotionVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOPromotionVw> objList = new List<DAOPromotionVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOPromotionVw retObj = new DAOPromotionVw();
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._promotionCode					 = Convert.IsDBNull(row["PromotionCode"]) ? null : (string)row["PromotionCode"];
						retObj._companyId					 = Convert.IsDBNull(row["CompanyId"]) ? (Int32?)null : (Int32?)row["CompanyId"];
						retObj._validFrom					 = Convert.IsDBNull(row["ValidFrom"]) ? (DateTime?)null : (DateTime?)row["ValidFrom"];
						retObj._validTo					 = Convert.IsDBNull(row["ValidTo"]) ? (DateTime?)null : (DateTime?)row["ValidTo"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._promotionTypeId					 = Convert.IsDBNull(row["PromotionTypeId"]) ? (Int32?)null : (Int32?)row["PromotionTypeId"];
						retObj._priority					 = Convert.IsDBNull(row["Priority"]) ? (Int32?)null : (Int32?)row["Priority"];
						retObj._repeats					 = Convert.IsDBNull(row["Repeats"]) ? (Int32?)null : (Int32?)row["Repeats"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
						retObj._promotionDesc					 = Convert.IsDBNull(row["PromotionDesc"]) ? null : (string)row["PromotionDesc"];
						retObj._promotionGroupId					 = Convert.IsDBNull(row["PromotionGroupId"]) ? (Int32?)null : (Int32?)row["PromotionGroupId"];
						retObj._displayOrder					 = Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"];
						retObj._enableNotification					 = Convert.IsDBNull(row["EnableNotification"]) ? (bool?)null : (bool?)row["EnableNotification"];
						retObj._notificationDate					 = Convert.IsDBNull(row["NotificationDate"]) ? (DateTime?)null : (DateTime?)row["NotificationDate"];
						retObj._notificationDone					 = Convert.IsDBNull(row["NotificationDone"]) ? (bool?)null : (bool?)row["NotificationDone"];
						retObj._promotionTypeCode					 = Convert.IsDBNull(row["PromotionTypeCode"]) ? null : (string)row["PromotionTypeCode"];
						retObj._promotionTypeNameAr					 = Convert.IsDBNull(row["PromotionTypeNameAr"]) ? null : (string)row["PromotionTypeNameAr"];
						retObj._promotionTypeNameEn					 = Convert.IsDBNull(row["PromotionTypeNameEn"]) ? null : (string)row["PromotionTypeNameEn"];
						retObj._promotionOutputId					 = Convert.IsDBNull(row["PromotionOutputId"]) ? (Int32?)null : (Int32?)row["PromotionOutputId"];
						retObj._promotionInputId					 = Convert.IsDBNull(row["PromotionInputId"]) ? (Int32?)null : (Int32?)row["PromotionInputId"];
						retObj._promotionGroupCode					 = Convert.IsDBNull(row["PromotionGroupCode"]) ? null : (string)row["PromotionGroupCode"];
						retObj._promotionGroupNameEn					 = Convert.IsDBNull(row["PromotionGroupNameEn"]) ? null : (string)row["PromotionGroupNameEn"];
						retObj._promotionGroupNameAr					 = Convert.IsDBNull(row["PromotionGroupNameAr"]) ? null : (string)row["PromotionGroupNameAr"];
						retObj._repeatTypeNameEn					 = Convert.IsDBNull(row["RepeatTypeNameEn"]) ? null : (string)row["RepeatTypeNameEn"];
						retObj._repeatTypeNameAr					 = Convert.IsDBNull(row["RepeatTypeNameAr"]) ? null : (string)row["RepeatTypeNameAr"];
						retObj._repeatTypeId					 = Convert.IsDBNull(row["RepeatTypeId"]) ? (Int32?)null : (Int32?)row["RepeatTypeId"];
						retObj._isApproved					 = Convert.IsDBNull(row["IsApproved"]) ? (bool?)null : (bool?)row["IsApproved"];
						retObj._promotionCategoryId					 = Convert.IsDBNull(row["PromotionCategoryId"]) ? (Int32?)null : (Int32?)row["PromotionCategoryId"];
						retObj._vendorCode					 = Convert.IsDBNull(row["VendorCode"]) ? null : (string)row["VendorCode"];
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
			command.CommandText = InlineProcs.ctprPromotionVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiPromotionVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromotionVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromotionVw");
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
						if (string.Compare(projection.Member, "PromotionCode", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionCode"]) ? null : (string)row["PromotionCode"]);
						if (string.Compare(projection.Member, "CompanyId", true) == 0) lst.Add(Convert.IsDBNull(row["CompanyId"]) ? (Int32?)null : (Int32?)row["CompanyId"]);
						if (string.Compare(projection.Member, "ValidFrom", true) == 0) lst.Add(Convert.IsDBNull(row["ValidFrom"]) ? (DateTime?)null : (DateTime?)row["ValidFrom"]);
						if (string.Compare(projection.Member, "ValidTo", true) == 0) lst.Add(Convert.IsDBNull(row["ValidTo"]) ? (DateTime?)null : (DateTime?)row["ValidTo"]);
						if (string.Compare(projection.Member, "IsActive", true) == 0) lst.Add(Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"]);
						if (string.Compare(projection.Member, "PromotionTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionTypeId"]) ? (Int32?)null : (Int32?)row["PromotionTypeId"]);
						if (string.Compare(projection.Member, "Priority", true) == 0) lst.Add(Convert.IsDBNull(row["Priority"]) ? (Int32?)null : (Int32?)row["Priority"]);
						if (string.Compare(projection.Member, "Repeats", true) == 0) lst.Add(Convert.IsDBNull(row["Repeats"]) ? (Int32?)null : (Int32?)row["Repeats"]);
						if (string.Compare(projection.Member, "Icon", true) == 0) lst.Add(Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"]);
						if (string.Compare(projection.Member, "Color", true) == 0) lst.Add(Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"]);
						if (string.Compare(projection.Member, "PromotionDesc", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionDesc"]) ? null : (string)row["PromotionDesc"]);
						if (string.Compare(projection.Member, "PromotionGroupId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionGroupId"]) ? (Int32?)null : (Int32?)row["PromotionGroupId"]);
						if (string.Compare(projection.Member, "DisplayOrder", true) == 0) lst.Add(Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"]);
						if (string.Compare(projection.Member, "EnableNotification", true) == 0) lst.Add(Convert.IsDBNull(row["EnableNotification"]) ? (bool?)null : (bool?)row["EnableNotification"]);
						if (string.Compare(projection.Member, "NotificationDate", true) == 0) lst.Add(Convert.IsDBNull(row["NotificationDate"]) ? (DateTime?)null : (DateTime?)row["NotificationDate"]);
						if (string.Compare(projection.Member, "NotificationDone", true) == 0) lst.Add(Convert.IsDBNull(row["NotificationDone"]) ? (bool?)null : (bool?)row["NotificationDone"]);
						if (string.Compare(projection.Member, "PromotionTypeCode", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionTypeCode"]) ? null : (string)row["PromotionTypeCode"]);
						if (string.Compare(projection.Member, "PromotionTypeNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionTypeNameAr"]) ? null : (string)row["PromotionTypeNameAr"]);
						if (string.Compare(projection.Member, "PromotionTypeNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionTypeNameEn"]) ? null : (string)row["PromotionTypeNameEn"]);
						if (string.Compare(projection.Member, "PromotionOutputId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionOutputId"]) ? (Int32?)null : (Int32?)row["PromotionOutputId"]);
						if (string.Compare(projection.Member, "PromotionInputId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionInputId"]) ? (Int32?)null : (Int32?)row["PromotionInputId"]);
						if (string.Compare(projection.Member, "PromotionGroupCode", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionGroupCode"]) ? null : (string)row["PromotionGroupCode"]);
						if (string.Compare(projection.Member, "PromotionGroupNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionGroupNameEn"]) ? null : (string)row["PromotionGroupNameEn"]);
						if (string.Compare(projection.Member, "PromotionGroupNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionGroupNameAr"]) ? null : (string)row["PromotionGroupNameAr"]);
						if (string.Compare(projection.Member, "RepeatTypeNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["RepeatTypeNameEn"]) ? null : (string)row["RepeatTypeNameEn"]);
						if (string.Compare(projection.Member, "RepeatTypeNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["RepeatTypeNameAr"]) ? null : (string)row["RepeatTypeNameAr"]);
						if (string.Compare(projection.Member, "RepeatTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["RepeatTypeId"]) ? (Int32?)null : (Int32?)row["RepeatTypeId"]);
						if (string.Compare(projection.Member, "IsApproved", true) == 0) lst.Add(Convert.IsDBNull(row["IsApproved"]) ? (bool?)null : (bool?)row["IsApproved"]);
						if (string.Compare(projection.Member, "PromotionCategoryId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionCategoryId"]) ? (Int32?)null : (Int32?)row["PromotionCategoryId"]);
						if (string.Compare(projection.Member, "VendorCode", true) == 0) lst.Add(Convert.IsDBNull(row["VendorCode"]) ? null : (string)row["VendorCode"]);
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
		///This method returns all data rows in the table using criteriaquery api PromotionVw
		///</Summary>
		///<returns>
		///IList-DAOPromotionVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOPromotionVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromotionVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromotionVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOPromotionVw> objList = new List<DAOPromotionVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOPromotionVw retObj = new DAOPromotionVw();
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._promotionCode					 = Convert.IsDBNull(row["PromotionCode"]) ? null : (string)row["PromotionCode"];
						retObj._companyId					 = Convert.IsDBNull(row["CompanyId"]) ? (Int32?)null : (Int32?)row["CompanyId"];
						retObj._validFrom					 = Convert.IsDBNull(row["ValidFrom"]) ? (DateTime?)null : (DateTime?)row["ValidFrom"];
						retObj._validTo					 = Convert.IsDBNull(row["ValidTo"]) ? (DateTime?)null : (DateTime?)row["ValidTo"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._promotionTypeId					 = Convert.IsDBNull(row["PromotionTypeId"]) ? (Int32?)null : (Int32?)row["PromotionTypeId"];
						retObj._priority					 = Convert.IsDBNull(row["Priority"]) ? (Int32?)null : (Int32?)row["Priority"];
						retObj._repeats					 = Convert.IsDBNull(row["Repeats"]) ? (Int32?)null : (Int32?)row["Repeats"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
						retObj._promotionDesc					 = Convert.IsDBNull(row["PromotionDesc"]) ? null : (string)row["PromotionDesc"];
						retObj._promotionGroupId					 = Convert.IsDBNull(row["PromotionGroupId"]) ? (Int32?)null : (Int32?)row["PromotionGroupId"];
						retObj._displayOrder					 = Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"];
						retObj._enableNotification					 = Convert.IsDBNull(row["EnableNotification"]) ? (bool?)null : (bool?)row["EnableNotification"];
						retObj._notificationDate					 = Convert.IsDBNull(row["NotificationDate"]) ? (DateTime?)null : (DateTime?)row["NotificationDate"];
						retObj._notificationDone					 = Convert.IsDBNull(row["NotificationDone"]) ? (bool?)null : (bool?)row["NotificationDone"];
						retObj._promotionTypeCode					 = Convert.IsDBNull(row["PromotionTypeCode"]) ? null : (string)row["PromotionTypeCode"];
						retObj._promotionTypeNameAr					 = Convert.IsDBNull(row["PromotionTypeNameAr"]) ? null : (string)row["PromotionTypeNameAr"];
						retObj._promotionTypeNameEn					 = Convert.IsDBNull(row["PromotionTypeNameEn"]) ? null : (string)row["PromotionTypeNameEn"];
						retObj._promotionOutputId					 = Convert.IsDBNull(row["PromotionOutputId"]) ? (Int32?)null : (Int32?)row["PromotionOutputId"];
						retObj._promotionInputId					 = Convert.IsDBNull(row["PromotionInputId"]) ? (Int32?)null : (Int32?)row["PromotionInputId"];
						retObj._promotionGroupCode					 = Convert.IsDBNull(row["PromotionGroupCode"]) ? null : (string)row["PromotionGroupCode"];
						retObj._promotionGroupNameEn					 = Convert.IsDBNull(row["PromotionGroupNameEn"]) ? null : (string)row["PromotionGroupNameEn"];
						retObj._promotionGroupNameAr					 = Convert.IsDBNull(row["PromotionGroupNameAr"]) ? null : (string)row["PromotionGroupNameAr"];
						retObj._repeatTypeNameEn					 = Convert.IsDBNull(row["RepeatTypeNameEn"]) ? null : (string)row["RepeatTypeNameEn"];
						retObj._repeatTypeNameAr					 = Convert.IsDBNull(row["RepeatTypeNameAr"]) ? null : (string)row["RepeatTypeNameAr"];
						retObj._repeatTypeId					 = Convert.IsDBNull(row["RepeatTypeId"]) ? (Int32?)null : (Int32?)row["RepeatTypeId"];
						retObj._isApproved					 = Convert.IsDBNull(row["IsApproved"]) ? (bool?)null : (bool?)row["IsApproved"];
						retObj._promotionCategoryId					 = Convert.IsDBNull(row["PromotionCategoryId"]) ? (Int32?)null : (Int32?)row["PromotionCategoryId"];
						retObj._vendorCode					 = Convert.IsDBNull(row["VendorCode"]) ? null : (string)row["VendorCode"];
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
		///This method returns all data rows in the table using criteriaquery api PromotionVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromotionVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public Int32? CompanyId
		{
			get
			{
				return _companyId;
			}
			set
			{
				_companyId = value;
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

		public string PromotionDesc
		{
			get
			{
				return _promotionDesc;
			}
			set
			{
				_promotionDesc = value;
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

		public Int32? DisplayOrder
		{
			get
			{
				return _displayOrder;
			}
			set
			{
				_displayOrder = value;
			}
		}

		public bool? EnableNotification
		{
			get
			{
				return _enableNotification;
			}
			set
			{
				_enableNotification = value;
			}
		}

		public DateTime? NotificationDate
		{
			get
			{
				return _notificationDate;
			}
			set
			{
				_notificationDate = value;
			}
		}

		public bool? NotificationDone
		{
			get
			{
				return _notificationDone;
			}
			set
			{
				_notificationDone = value;
			}
		}

		public string PromotionTypeCode
		{
			get
			{
				return _promotionTypeCode;
			}
			set
			{
				_promotionTypeCode = value;
			}
		}

		public string PromotionTypeNameAr
		{
			get
			{
				return _promotionTypeNameAr;
			}
			set
			{
				_promotionTypeNameAr = value;
			}
		}

		public string PromotionTypeNameEn
		{
			get
			{
				return _promotionTypeNameEn;
			}
			set
			{
				_promotionTypeNameEn = value;
			}
		}

		public Int32? PromotionOutputId
		{
			get
			{
				return _promotionOutputId;
			}
			set
			{
				_promotionOutputId = value;
			}
		}

		public Int32? PromotionInputId
		{
			get
			{
				return _promotionInputId;
			}
			set
			{
				_promotionInputId = value;
			}
		}

		public string PromotionGroupCode
		{
			get
			{
				return _promotionGroupCode;
			}
			set
			{
				_promotionGroupCode = value;
			}
		}

		public string PromotionGroupNameEn
		{
			get
			{
				return _promotionGroupNameEn;
			}
			set
			{
				_promotionGroupNameEn = value;
			}
		}

		public string PromotionGroupNameAr
		{
			get
			{
				return _promotionGroupNameAr;
			}
			set
			{
				_promotionGroupNameAr = value;
			}
		}

		public string RepeatTypeNameEn
		{
			get
			{
				return _repeatTypeNameEn;
			}
			set
			{
				_repeatTypeNameEn = value;
			}
		}

		public string RepeatTypeNameAr
		{
			get
			{
				return _repeatTypeNameAr;
			}
			set
			{
				_repeatTypeNameAr = value;
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

		public string VendorCode
		{
			get
			{
				return _vendorCode;
			}
			set
			{
				_vendorCode = value;
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
		internal static string ctprPromotionVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[PromotionId]
			,[PromotionCode]
			,[CompanyId]
			,[ValidFrom]
			,[ValidTo]
			,[IsActive]
			,[PromotionTypeId]
			,[Priority]
			,[Repeats]
			,[Icon]
			,[Color]
			,[PromotionDesc]
			,[PromotionGroupId]
			,[DisplayOrder]
			,[EnableNotification]
			,[NotificationDate]
			,[NotificationDone]
			,[PromotionTypeCode]
			,[PromotionTypeNameAr]
			,[PromotionTypeNameEn]
			,[PromotionOutputId]
			,[PromotionInputId]
			,[PromotionGroupCode]
			,[PromotionGroupNameEn]
			,[PromotionGroupNameAr]
			,[RepeatTypeNameEn]
			,[RepeatTypeNameAr]
			,[RepeatTypeId]
			,[IsApproved]
			,[PromotionCategoryId]
			,[VendorCode]
			FROM [dbo].[PromotionVw]
			";

		internal static string ctprPromotionVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[PromotionVw]
			";

		internal static string ctprPromotionVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[PromotionVw]
			##CRITERIA##
			";

		internal static string ctprPromotionVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[PromotionId]
			,[PromotionCode]
			,[CompanyId]
			,[ValidFrom]
			,[ValidTo]
			,[IsActive]
			,[PromotionTypeId]
			,[Priority]
			,[Repeats]
			,[Icon]
			,[Color]
			,[PromotionDesc]
			,[PromotionGroupId]
			,[DisplayOrder]
			,[EnableNotification]
			,[NotificationDate]
			,[NotificationDone]
			,[PromotionTypeCode]
			,[PromotionTypeNameAr]
			,[PromotionTypeNameEn]
			,[PromotionOutputId]
			,[PromotionInputId]
			,[PromotionGroupCode]
			,[PromotionGroupNameEn]
			,[PromotionGroupNameAr]
			,[RepeatTypeNameEn]
			,[RepeatTypeNameAr]
			,[RepeatTypeId]
			,[IsApproved]
			,[PromotionCategoryId]
			,[VendorCode]
			FROM [dbo].[PromotionVw]
			##CRITERIA##
			";

		internal static string ctprPromotionVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[PromotionVw]
			##CRITERIA##
			";

	}
}
#endregion