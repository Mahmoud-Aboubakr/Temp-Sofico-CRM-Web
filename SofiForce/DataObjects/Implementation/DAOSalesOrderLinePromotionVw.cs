/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 8/12/2023 3:03:10 PM
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SofiForce.DataObjects.Interfaces;

namespace SofiForce.DataObjects
{
	public partial class DAOSalesOrderLinePromotionVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int64? _lineId;
		protected Int64? _salesId;
		protected Int32? _itemId;
		protected Int32? _promotionId;
		protected decimal? _outcome;
		protected Int32? _salesOrderStatusId;
		protected string _invoiceCode;
		protected string _clientCode;
		protected string _clientNameAr;
		protected string _clientNameEn;
		protected string _branchCode;
		protected string _branchNameAr;
		protected string _branchNameEn;
		protected Int32? _branchId;
		protected Int32? _clientId;
		protected DateTime? _invoiceDate;
		protected string _promotionCode;
		protected bool? _isActive;
		protected DateTime? _validFrom;
		protected DateTime? _validTo;
		protected Int32? _itemStoreId;
		protected string _batchNo;
		protected bool? _isInvoiced;
		protected bool? _isDeleted;
		protected Int32? _outcomeType;
		protected string _itemCode;
		protected string _itemNameEn;
		protected string _itemNameAr;
		protected string _vendorCode;
		protected Int32? _vendorId;
		protected string _vendorNameEn;
		protected string _vendorNameAr;
		protected Int32? _itemGroupId;
		#endregion

		#region class methods
		public DAOSalesOrderLinePromotionVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table SalesOrder_Line_PromotionVw
		///</Summary>
		///<returns>
		///IList-DAOSalesOrderLinePromotionVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOSalesOrderLinePromotionVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesOrder_Line_PromotionVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_Line_PromotionVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSalesOrderLinePromotionVw> objList = new List<DAOSalesOrderLinePromotionVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSalesOrderLinePromotionVw retObj = new DAOSalesOrderLinePromotionVw();
						retObj._lineId					 = Convert.IsDBNull(row["LineId"]) ? (Int64?)null : (Int64?)row["LineId"];
						retObj._salesId					 = Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._outcome					 = Convert.IsDBNull(row["Outcome"]) ? (decimal?)null : (decimal?)row["Outcome"];
						retObj._salesOrderStatusId					 = Convert.IsDBNull(row["SalesOrderStatusId"]) ? (Int32?)null : (Int32?)row["SalesOrderStatusId"];
						retObj._invoiceCode					 = Convert.IsDBNull(row["InvoiceCode"]) ? null : (string)row["InvoiceCode"];
						retObj._clientCode					 = Convert.IsDBNull(row["ClientCode"]) ? null : (string)row["ClientCode"];
						retObj._clientNameAr					 = Convert.IsDBNull(row["ClientNameAr"]) ? null : (string)row["ClientNameAr"];
						retObj._clientNameEn					 = Convert.IsDBNull(row["ClientNameEn"]) ? null : (string)row["ClientNameEn"];
						retObj._branchCode					 = Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"];
						retObj._branchNameAr					 = Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"];
						retObj._branchNameEn					 = Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"];
						retObj._branchId					 = Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._invoiceDate					 = Convert.IsDBNull(row["InvoiceDate"]) ? (DateTime?)null : (DateTime?)row["InvoiceDate"];
						retObj._promotionCode					 = Convert.IsDBNull(row["PromotionCode"]) ? null : (string)row["PromotionCode"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._validFrom					 = Convert.IsDBNull(row["ValidFrom"]) ? (DateTime?)null : (DateTime?)row["ValidFrom"];
						retObj._validTo					 = Convert.IsDBNull(row["ValidTo"]) ? (DateTime?)null : (DateTime?)row["ValidTo"];
						retObj._itemStoreId					 = Convert.IsDBNull(row["ItemStoreId"]) ? (Int32?)null : (Int32?)row["ItemStoreId"];
						retObj._batchNo					 = Convert.IsDBNull(row["BatchNo"]) ? null : (string)row["BatchNo"];
						retObj._isInvoiced					 = Convert.IsDBNull(row["IsInvoiced"]) ? (bool?)null : (bool?)row["IsInvoiced"];
						retObj._isDeleted					 = Convert.IsDBNull(row["IsDeleted"]) ? (bool?)null : (bool?)row["IsDeleted"];
						retObj._outcomeType					 = Convert.IsDBNull(row["OutcomeType"]) ? (Int32?)null : (Int32?)row["OutcomeType"];
						retObj._itemCode					 = Convert.IsDBNull(row["ItemCode"]) ? null : (string)row["ItemCode"];
						retObj._itemNameEn					 = Convert.IsDBNull(row["ItemNameEn"]) ? null : (string)row["ItemNameEn"];
						retObj._itemNameAr					 = Convert.IsDBNull(row["ItemNameAr"]) ? null : (string)row["ItemNameAr"];
						retObj._vendorCode					 = Convert.IsDBNull(row["VendorCode"]) ? null : (string)row["VendorCode"];
						retObj._vendorId					 = Convert.IsDBNull(row["VendorId"]) ? (Int32?)null : (Int32?)row["VendorId"];
						retObj._vendorNameEn					 = Convert.IsDBNull(row["VendorNameEn"]) ? null : (string)row["VendorNameEn"];
						retObj._vendorNameAr					 = Convert.IsDBNull(row["VendorNameAr"]) ? null : (string)row["VendorNameAr"];
						retObj._itemGroupId					 = Convert.IsDBNull(row["ItemGroupId"]) ? (Int32?)null : (Int32?)row["ItemGroupId"];
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
			command.CommandText = InlineProcs.ctprSalesOrder_Line_PromotionVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiSalesOrder_Line_PromotionVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesOrder_Line_PromotionVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_Line_PromotionVw");
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
						if (string.Compare(projection.Member, "LineId", true) == 0) lst.Add(Convert.IsDBNull(row["LineId"]) ? (Int64?)null : (Int64?)row["LineId"]);
						if (string.Compare(projection.Member, "SalesId", true) == 0) lst.Add(Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"]);
						if (string.Compare(projection.Member, "ItemId", true) == 0) lst.Add(Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"]);
						if (string.Compare(projection.Member, "PromotionId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"]);
						if (string.Compare(projection.Member, "Outcome", true) == 0) lst.Add(Convert.IsDBNull(row["Outcome"]) ? (decimal?)null : (decimal?)row["Outcome"]);
						if (string.Compare(projection.Member, "SalesOrderStatusId", true) == 0) lst.Add(Convert.IsDBNull(row["SalesOrderStatusId"]) ? (Int32?)null : (Int32?)row["SalesOrderStatusId"]);
						if (string.Compare(projection.Member, "InvoiceCode", true) == 0) lst.Add(Convert.IsDBNull(row["InvoiceCode"]) ? null : (string)row["InvoiceCode"]);
						if (string.Compare(projection.Member, "ClientCode", true) == 0) lst.Add(Convert.IsDBNull(row["ClientCode"]) ? null : (string)row["ClientCode"]);
						if (string.Compare(projection.Member, "ClientNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["ClientNameAr"]) ? null : (string)row["ClientNameAr"]);
						if (string.Compare(projection.Member, "ClientNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["ClientNameEn"]) ? null : (string)row["ClientNameEn"]);
						if (string.Compare(projection.Member, "BranchCode", true) == 0) lst.Add(Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"]);
						if (string.Compare(projection.Member, "BranchNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"]);
						if (string.Compare(projection.Member, "BranchNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"]);
						if (string.Compare(projection.Member, "BranchId", true) == 0) lst.Add(Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"]);
						if (string.Compare(projection.Member, "ClientId", true) == 0) lst.Add(Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"]);
						if (string.Compare(projection.Member, "InvoiceDate", true) == 0) lst.Add(Convert.IsDBNull(row["InvoiceDate"]) ? (DateTime?)null : (DateTime?)row["InvoiceDate"]);
						if (string.Compare(projection.Member, "PromotionCode", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionCode"]) ? null : (string)row["PromotionCode"]);
						if (string.Compare(projection.Member, "IsActive", true) == 0) lst.Add(Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"]);
						if (string.Compare(projection.Member, "ValidFrom", true) == 0) lst.Add(Convert.IsDBNull(row["ValidFrom"]) ? (DateTime?)null : (DateTime?)row["ValidFrom"]);
						if (string.Compare(projection.Member, "ValidTo", true) == 0) lst.Add(Convert.IsDBNull(row["ValidTo"]) ? (DateTime?)null : (DateTime?)row["ValidTo"]);
						if (string.Compare(projection.Member, "ItemStoreId", true) == 0) lst.Add(Convert.IsDBNull(row["ItemStoreId"]) ? (Int32?)null : (Int32?)row["ItemStoreId"]);
						if (string.Compare(projection.Member, "BatchNo", true) == 0) lst.Add(Convert.IsDBNull(row["BatchNo"]) ? null : (string)row["BatchNo"]);
						if (string.Compare(projection.Member, "IsInvoiced", true) == 0) lst.Add(Convert.IsDBNull(row["IsInvoiced"]) ? (bool?)null : (bool?)row["IsInvoiced"]);
						if (string.Compare(projection.Member, "IsDeleted", true) == 0) lst.Add(Convert.IsDBNull(row["IsDeleted"]) ? (bool?)null : (bool?)row["IsDeleted"]);
						if (string.Compare(projection.Member, "OutcomeType", true) == 0) lst.Add(Convert.IsDBNull(row["OutcomeType"]) ? (Int32?)null : (Int32?)row["OutcomeType"]);
						if (string.Compare(projection.Member, "ItemCode", true) == 0) lst.Add(Convert.IsDBNull(row["ItemCode"]) ? null : (string)row["ItemCode"]);
						if (string.Compare(projection.Member, "ItemNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["ItemNameEn"]) ? null : (string)row["ItemNameEn"]);
						if (string.Compare(projection.Member, "ItemNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["ItemNameAr"]) ? null : (string)row["ItemNameAr"]);
						if (string.Compare(projection.Member, "VendorCode", true) == 0) lst.Add(Convert.IsDBNull(row["VendorCode"]) ? null : (string)row["VendorCode"]);
						if (string.Compare(projection.Member, "VendorId", true) == 0) lst.Add(Convert.IsDBNull(row["VendorId"]) ? (Int32?)null : (Int32?)row["VendorId"]);
						if (string.Compare(projection.Member, "VendorNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["VendorNameEn"]) ? null : (string)row["VendorNameEn"]);
						if (string.Compare(projection.Member, "VendorNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["VendorNameAr"]) ? null : (string)row["VendorNameAr"]);
						if (string.Compare(projection.Member, "ItemGroupId", true) == 0) lst.Add(Convert.IsDBNull(row["ItemGroupId"]) ? (Int32?)null : (Int32?)row["ItemGroupId"]);
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
		///This method returns all data rows in the table using criteriaquery api SalesOrder_Line_PromotionVw
		///</Summary>
		///<returns>
		///IList-DAOSalesOrderLinePromotionVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOSalesOrderLinePromotionVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesOrder_Line_PromotionVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_Line_PromotionVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSalesOrderLinePromotionVw> objList = new List<DAOSalesOrderLinePromotionVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSalesOrderLinePromotionVw retObj = new DAOSalesOrderLinePromotionVw();
						retObj._lineId					 = Convert.IsDBNull(row["LineId"]) ? (Int64?)null : (Int64?)row["LineId"];
						retObj._salesId					 = Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._outcome					 = Convert.IsDBNull(row["Outcome"]) ? (decimal?)null : (decimal?)row["Outcome"];
						retObj._salesOrderStatusId					 = Convert.IsDBNull(row["SalesOrderStatusId"]) ? (Int32?)null : (Int32?)row["SalesOrderStatusId"];
						retObj._invoiceCode					 = Convert.IsDBNull(row["InvoiceCode"]) ? null : (string)row["InvoiceCode"];
						retObj._clientCode					 = Convert.IsDBNull(row["ClientCode"]) ? null : (string)row["ClientCode"];
						retObj._clientNameAr					 = Convert.IsDBNull(row["ClientNameAr"]) ? null : (string)row["ClientNameAr"];
						retObj._clientNameEn					 = Convert.IsDBNull(row["ClientNameEn"]) ? null : (string)row["ClientNameEn"];
						retObj._branchCode					 = Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"];
						retObj._branchNameAr					 = Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"];
						retObj._branchNameEn					 = Convert.IsDBNull(row["BranchNameEn"]) ? null : (string)row["BranchNameEn"];
						retObj._branchId					 = Convert.IsDBNull(row["BranchId"]) ? (Int32?)null : (Int32?)row["BranchId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._invoiceDate					 = Convert.IsDBNull(row["InvoiceDate"]) ? (DateTime?)null : (DateTime?)row["InvoiceDate"];
						retObj._promotionCode					 = Convert.IsDBNull(row["PromotionCode"]) ? null : (string)row["PromotionCode"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._validFrom					 = Convert.IsDBNull(row["ValidFrom"]) ? (DateTime?)null : (DateTime?)row["ValidFrom"];
						retObj._validTo					 = Convert.IsDBNull(row["ValidTo"]) ? (DateTime?)null : (DateTime?)row["ValidTo"];
						retObj._itemStoreId					 = Convert.IsDBNull(row["ItemStoreId"]) ? (Int32?)null : (Int32?)row["ItemStoreId"];
						retObj._batchNo					 = Convert.IsDBNull(row["BatchNo"]) ? null : (string)row["BatchNo"];
						retObj._isInvoiced					 = Convert.IsDBNull(row["IsInvoiced"]) ? (bool?)null : (bool?)row["IsInvoiced"];
						retObj._isDeleted					 = Convert.IsDBNull(row["IsDeleted"]) ? (bool?)null : (bool?)row["IsDeleted"];
						retObj._outcomeType					 = Convert.IsDBNull(row["OutcomeType"]) ? (Int32?)null : (Int32?)row["OutcomeType"];
						retObj._itemCode					 = Convert.IsDBNull(row["ItemCode"]) ? null : (string)row["ItemCode"];
						retObj._itemNameEn					 = Convert.IsDBNull(row["ItemNameEn"]) ? null : (string)row["ItemNameEn"];
						retObj._itemNameAr					 = Convert.IsDBNull(row["ItemNameAr"]) ? null : (string)row["ItemNameAr"];
						retObj._vendorCode					 = Convert.IsDBNull(row["VendorCode"]) ? null : (string)row["VendorCode"];
						retObj._vendorId					 = Convert.IsDBNull(row["VendorId"]) ? (Int32?)null : (Int32?)row["VendorId"];
						retObj._vendorNameEn					 = Convert.IsDBNull(row["VendorNameEn"]) ? null : (string)row["VendorNameEn"];
						retObj._vendorNameAr					 = Convert.IsDBNull(row["VendorNameAr"]) ? null : (string)row["VendorNameAr"];
						retObj._itemGroupId					 = Convert.IsDBNull(row["ItemGroupId"]) ? (Int32?)null : (Int32?)row["ItemGroupId"];
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
		///This method returns all data rows in the table using criteriaquery api SalesOrder_Line_PromotionVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesOrder_Line_PromotionVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public Int64? LineId
		{
			get
			{
				return _lineId;
			}
			set
			{
				_lineId = value;
			}
		}

		public Int64? SalesId
		{
			get
			{
				return _salesId;
			}
			set
			{
				_salesId = value;
			}
		}

		public Int32? ItemId
		{
			get
			{
				return _itemId;
			}
			set
			{
				_itemId = value;
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

		public decimal? Outcome
		{
			get
			{
				return _outcome;
			}
			set
			{
				_outcome = value;
			}
		}

		public Int32? SalesOrderStatusId
		{
			get
			{
				return _salesOrderStatusId;
			}
			set
			{
				_salesOrderStatusId = value;
			}
		}

		public string InvoiceCode
		{
			get
			{
				return _invoiceCode;
			}
			set
			{
				_invoiceCode = value;
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

		public DateTime? InvoiceDate
		{
			get
			{
				return _invoiceDate;
			}
			set
			{
				_invoiceDate = value;
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

		public Int32? ItemStoreId
		{
			get
			{
				return _itemStoreId;
			}
			set
			{
				_itemStoreId = value;
			}
		}

		public string BatchNo
		{
			get
			{
				return _batchNo;
			}
			set
			{
				_batchNo = value;
			}
		}

		public bool? IsInvoiced
		{
			get
			{
				return _isInvoiced;
			}
			set
			{
				_isInvoiced = value;
			}
		}

		public bool? IsDeleted
		{
			get
			{
				return _isDeleted;
			}
			set
			{
				_isDeleted = value;
			}
		}

		public Int32? OutcomeType
		{
			get
			{
				return _outcomeType;
			}
			set
			{
				_outcomeType = value;
			}
		}

		public string ItemCode
		{
			get
			{
				return _itemCode;
			}
			set
			{
				_itemCode = value;
			}
		}

		public string ItemNameEn
		{
			get
			{
				return _itemNameEn;
			}
			set
			{
				_itemNameEn = value;
			}
		}

		public string ItemNameAr
		{
			get
			{
				return _itemNameAr;
			}
			set
			{
				_itemNameAr = value;
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

		public Int32? VendorId
		{
			get
			{
				return _vendorId;
			}
			set
			{
				_vendorId = value;
			}
		}

		public string VendorNameEn
		{
			get
			{
				return _vendorNameEn;
			}
			set
			{
				_vendorNameEn = value;
			}
		}

		public string VendorNameAr
		{
			get
			{
				return _vendorNameAr;
			}
			set
			{
				_vendorNameAr = value;
			}
		}

		public Int32? ItemGroupId
		{
			get
			{
				return _itemGroupId;
			}
			set
			{
				_itemGroupId = value;
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
		internal static string ctprSalesOrder_Line_PromotionVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[LineId]
			,[SalesId]
			,[ItemId]
			,[PromotionId]
			,[Outcome]
			,[SalesOrderStatusId]
			,[InvoiceCode]
			,[ClientCode]
			,[ClientNameAr]
			,[ClientNameEn]
			,[BranchCode]
			,[BranchNameAr]
			,[BranchNameEn]
			,[BranchId]
			,[ClientId]
			,[InvoiceDate]
			,[PromotionCode]
			,[IsActive]
			,[ValidFrom]
			,[ValidTo]
			,[ItemStoreId]
			,[BatchNo]
			,[IsInvoiced]
			,[IsDeleted]
			,[OutcomeType]
			,[ItemCode]
			,[ItemNameEn]
			,[ItemNameAr]
			,[VendorCode]
			,[VendorId]
			,[VendorNameEn]
			,[VendorNameAr]
			,[ItemGroupId]
			FROM [dbo].[SalesOrder_Line_PromotionVw]
			";

		internal static string ctprSalesOrder_Line_PromotionVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[SalesOrder_Line_PromotionVw]
			";

		internal static string ctprSalesOrder_Line_PromotionVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[SalesOrder_Line_PromotionVw]
			##CRITERIA##
			";

		internal static string ctprSalesOrder_Line_PromotionVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[LineId]
			,[SalesId]
			,[ItemId]
			,[PromotionId]
			,[Outcome]
			,[SalesOrderStatusId]
			,[InvoiceCode]
			,[ClientCode]
			,[ClientNameAr]
			,[ClientNameEn]
			,[BranchCode]
			,[BranchNameAr]
			,[BranchNameEn]
			,[BranchId]
			,[ClientId]
			,[InvoiceDate]
			,[PromotionCode]
			,[IsActive]
			,[ValidFrom]
			,[ValidTo]
			,[ItemStoreId]
			,[BatchNo]
			,[IsInvoiced]
			,[IsDeleted]
			,[OutcomeType]
			,[ItemCode]
			,[ItemNameEn]
			,[ItemNameAr]
			,[VendorCode]
			,[VendorId]
			,[VendorNameEn]
			,[VendorNameAr]
			,[ItemGroupId]
			FROM [dbo].[SalesOrder_Line_PromotionVw]
			##CRITERIA##
			";

		internal static string ctprSalesOrder_Line_PromotionVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[SalesOrder_Line_PromotionVw]
			##CRITERIA##
			";

	}
}
#endregion
