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
	public partial class DAOPurchaseOrderDetailVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _detailId;
		protected Int32? _purchaseId;
		protected Int32? _itemId;
		protected Int32? _quanity;
		protected decimal? _purchasePrice;
		protected string _currency;
		protected decimal? _exchangeRate;
		protected decimal? _purchasePriceLocal;
		protected Int32? _unitId;
		protected string _unitCode;
		protected decimal? _taxValue;
		protected decimal? _discountValue;
		protected string _batchNo;
		protected DateTime? _expireDate;
		protected Int32? _statusReceipt;
		protected string _vendorCode;
		protected string _vendorNameAr;
		protected string _storeNameAr;
		protected string _storeCode;
		protected string _branchCode;
		protected string _branchNameAr;
		protected string _purchaseCode;
		protected string _invoiceCode;
		protected DateTime? _invoiceDate;
		protected decimal? _invoiceAmount;
		protected string _expr1;
		protected decimal? _expr2;
		protected decimal? _invoiceAmountLocal;
		protected decimal? _sumTax;
		protected decimal? _sumExpense;
		protected decimal? _openValue;
		protected string _itemCode;
		protected string _itemNameAr;
		#endregion

		#region class methods
		public DAOPurchaseOrderDetailVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table PurchaseOrder_DetailVw
		///</Summary>
		///<returns>
		///IList-DAOPurchaseOrderDetailVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOPurchaseOrderDetailVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprPurchaseOrder_DetailVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PurchaseOrder_DetailVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOPurchaseOrderDetailVw> objList = new List<DAOPurchaseOrderDetailVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOPurchaseOrderDetailVw retObj = new DAOPurchaseOrderDetailVw();
						retObj._detailId					 = Convert.IsDBNull(row["DetailId"]) ? (Int32?)null : (Int32?)row["DetailId"];
						retObj._purchaseId					 = Convert.IsDBNull(row["PurchaseId"]) ? (Int32?)null : (Int32?)row["PurchaseId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._quanity					 = Convert.IsDBNull(row["Quanity"]) ? (Int32?)null : (Int32?)row["Quanity"];
						retObj._purchasePrice					 = Convert.IsDBNull(row["PurchasePrice"]) ? (decimal?)null : (decimal?)row["PurchasePrice"];
						retObj._currency					 = Convert.IsDBNull(row["Currency"]) ? null : (string)row["Currency"];
						retObj._exchangeRate					 = Convert.IsDBNull(row["ExchangeRate"]) ? (decimal?)null : (decimal?)row["ExchangeRate"];
						retObj._purchasePriceLocal					 = Convert.IsDBNull(row["PurchasePriceLocal"]) ? (decimal?)null : (decimal?)row["PurchasePriceLocal"];
						retObj._unitId					 = Convert.IsDBNull(row["UnitId"]) ? (Int32?)null : (Int32?)row["UnitId"];
						retObj._unitCode					 = Convert.IsDBNull(row["UnitCode"]) ? null : (string)row["UnitCode"];
						retObj._taxValue					 = Convert.IsDBNull(row["TaxValue"]) ? (decimal?)null : (decimal?)row["TaxValue"];
						retObj._discountValue					 = Convert.IsDBNull(row["DiscountValue"]) ? (decimal?)null : (decimal?)row["DiscountValue"];
						retObj._batchNo					 = Convert.IsDBNull(row["BatchNo"]) ? null : (string)row["BatchNo"];
						retObj._expireDate					 = Convert.IsDBNull(row["ExpireDate"]) ? (DateTime?)null : (DateTime?)row["ExpireDate"];
						retObj._statusReceipt					 = Convert.IsDBNull(row["StatusReceipt"]) ? (Int32?)null : (Int32?)row["StatusReceipt"];
						retObj._vendorCode					 = Convert.IsDBNull(row["VendorCode"]) ? null : (string)row["VendorCode"];
						retObj._vendorNameAr					 = Convert.IsDBNull(row["VendorNameAr"]) ? null : (string)row["VendorNameAr"];
						retObj._storeNameAr					 = Convert.IsDBNull(row["StoreNameAr"]) ? null : (string)row["StoreNameAr"];
						retObj._storeCode					 = Convert.IsDBNull(row["StoreCode"]) ? null : (string)row["StoreCode"];
						retObj._branchCode					 = Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"];
						retObj._branchNameAr					 = Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"];
						retObj._purchaseCode					 = Convert.IsDBNull(row["PurchaseCode"]) ? null : (string)row["PurchaseCode"];
						retObj._invoiceCode					 = Convert.IsDBNull(row["InvoiceCode"]) ? null : (string)row["InvoiceCode"];
						retObj._invoiceDate					 = Convert.IsDBNull(row["InvoiceDate"]) ? (DateTime?)null : (DateTime?)row["InvoiceDate"];
						retObj._invoiceAmount					 = Convert.IsDBNull(row["InvoiceAmount"]) ? (decimal?)null : (decimal?)row["InvoiceAmount"];
						retObj._expr1					 = Convert.IsDBNull(row["Expr1"]) ? null : (string)row["Expr1"];
						retObj._expr2					 = Convert.IsDBNull(row["Expr2"]) ? (decimal?)null : (decimal?)row["Expr2"];
						retObj._invoiceAmountLocal					 = Convert.IsDBNull(row["InvoiceAmountLocal"]) ? (decimal?)null : (decimal?)row["InvoiceAmountLocal"];
						retObj._sumTax					 = Convert.IsDBNull(row["SumTax"]) ? (decimal?)null : (decimal?)row["SumTax"];
						retObj._sumExpense					 = Convert.IsDBNull(row["SumExpense"]) ? (decimal?)null : (decimal?)row["SumExpense"];
						retObj._openValue					 = Convert.IsDBNull(row["OpenValue"]) ? (decimal?)null : (decimal?)row["OpenValue"];
						retObj._itemCode					 = Convert.IsDBNull(row["ItemCode"]) ? null : (string)row["ItemCode"];
						retObj._itemNameAr					 = Convert.IsDBNull(row["ItemNameAr"]) ? null : (string)row["ItemNameAr"];
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
			command.CommandText = InlineProcs.ctprPurchaseOrder_DetailVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiPurchaseOrder_DetailVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPurchaseOrder_DetailVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PurchaseOrder_DetailVw");
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
						if (string.Compare(projection.Member, "DetailId", true) == 0) lst.Add(Convert.IsDBNull(row["DetailId"]) ? (Int32?)null : (Int32?)row["DetailId"]);
						if (string.Compare(projection.Member, "PurchaseId", true) == 0) lst.Add(Convert.IsDBNull(row["PurchaseId"]) ? (Int32?)null : (Int32?)row["PurchaseId"]);
						if (string.Compare(projection.Member, "ItemId", true) == 0) lst.Add(Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"]);
						if (string.Compare(projection.Member, "Quanity", true) == 0) lst.Add(Convert.IsDBNull(row["Quanity"]) ? (Int32?)null : (Int32?)row["Quanity"]);
						if (string.Compare(projection.Member, "PurchasePrice", true) == 0) lst.Add(Convert.IsDBNull(row["PurchasePrice"]) ? (decimal?)null : (decimal?)row["PurchasePrice"]);
						if (string.Compare(projection.Member, "Currency", true) == 0) lst.Add(Convert.IsDBNull(row["Currency"]) ? null : (string)row["Currency"]);
						if (string.Compare(projection.Member, "ExchangeRate", true) == 0) lst.Add(Convert.IsDBNull(row["ExchangeRate"]) ? (decimal?)null : (decimal?)row["ExchangeRate"]);
						if (string.Compare(projection.Member, "PurchasePriceLocal", true) == 0) lst.Add(Convert.IsDBNull(row["PurchasePriceLocal"]) ? (decimal?)null : (decimal?)row["PurchasePriceLocal"]);
						if (string.Compare(projection.Member, "UnitId", true) == 0) lst.Add(Convert.IsDBNull(row["UnitId"]) ? (Int32?)null : (Int32?)row["UnitId"]);
						if (string.Compare(projection.Member, "UnitCode", true) == 0) lst.Add(Convert.IsDBNull(row["UnitCode"]) ? null : (string)row["UnitCode"]);
						if (string.Compare(projection.Member, "TaxValue", true) == 0) lst.Add(Convert.IsDBNull(row["TaxValue"]) ? (decimal?)null : (decimal?)row["TaxValue"]);
						if (string.Compare(projection.Member, "DiscountValue", true) == 0) lst.Add(Convert.IsDBNull(row["DiscountValue"]) ? (decimal?)null : (decimal?)row["DiscountValue"]);
						if (string.Compare(projection.Member, "BatchNo", true) == 0) lst.Add(Convert.IsDBNull(row["BatchNo"]) ? null : (string)row["BatchNo"]);
						if (string.Compare(projection.Member, "ExpireDate", true) == 0) lst.Add(Convert.IsDBNull(row["ExpireDate"]) ? (DateTime?)null : (DateTime?)row["ExpireDate"]);
						if (string.Compare(projection.Member, "StatusReceipt", true) == 0) lst.Add(Convert.IsDBNull(row["StatusReceipt"]) ? (Int32?)null : (Int32?)row["StatusReceipt"]);
						if (string.Compare(projection.Member, "VendorCode", true) == 0) lst.Add(Convert.IsDBNull(row["VendorCode"]) ? null : (string)row["VendorCode"]);
						if (string.Compare(projection.Member, "VendorNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["VendorNameAr"]) ? null : (string)row["VendorNameAr"]);
						if (string.Compare(projection.Member, "StoreNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["StoreNameAr"]) ? null : (string)row["StoreNameAr"]);
						if (string.Compare(projection.Member, "StoreCode", true) == 0) lst.Add(Convert.IsDBNull(row["StoreCode"]) ? null : (string)row["StoreCode"]);
						if (string.Compare(projection.Member, "BranchCode", true) == 0) lst.Add(Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"]);
						if (string.Compare(projection.Member, "BranchNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"]);
						if (string.Compare(projection.Member, "PurchaseCode", true) == 0) lst.Add(Convert.IsDBNull(row["PurchaseCode"]) ? null : (string)row["PurchaseCode"]);
						if (string.Compare(projection.Member, "InvoiceCode", true) == 0) lst.Add(Convert.IsDBNull(row["InvoiceCode"]) ? null : (string)row["InvoiceCode"]);
						if (string.Compare(projection.Member, "InvoiceDate", true) == 0) lst.Add(Convert.IsDBNull(row["InvoiceDate"]) ? (DateTime?)null : (DateTime?)row["InvoiceDate"]);
						if (string.Compare(projection.Member, "InvoiceAmount", true) == 0) lst.Add(Convert.IsDBNull(row["InvoiceAmount"]) ? (decimal?)null : (decimal?)row["InvoiceAmount"]);
						if (string.Compare(projection.Member, "Expr1", true) == 0) lst.Add(Convert.IsDBNull(row["Expr1"]) ? null : (string)row["Expr1"]);
						if (string.Compare(projection.Member, "Expr2", true) == 0) lst.Add(Convert.IsDBNull(row["Expr2"]) ? (decimal?)null : (decimal?)row["Expr2"]);
						if (string.Compare(projection.Member, "InvoiceAmountLocal", true) == 0) lst.Add(Convert.IsDBNull(row["InvoiceAmountLocal"]) ? (decimal?)null : (decimal?)row["InvoiceAmountLocal"]);
						if (string.Compare(projection.Member, "SumTax", true) == 0) lst.Add(Convert.IsDBNull(row["SumTax"]) ? (decimal?)null : (decimal?)row["SumTax"]);
						if (string.Compare(projection.Member, "SumExpense", true) == 0) lst.Add(Convert.IsDBNull(row["SumExpense"]) ? (decimal?)null : (decimal?)row["SumExpense"]);
						if (string.Compare(projection.Member, "OpenValue", true) == 0) lst.Add(Convert.IsDBNull(row["OpenValue"]) ? (decimal?)null : (decimal?)row["OpenValue"]);
						if (string.Compare(projection.Member, "ItemCode", true) == 0) lst.Add(Convert.IsDBNull(row["ItemCode"]) ? null : (string)row["ItemCode"]);
						if (string.Compare(projection.Member, "ItemNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["ItemNameAr"]) ? null : (string)row["ItemNameAr"]);
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
		///This method returns all data rows in the table using criteriaquery api PurchaseOrder_DetailVw
		///</Summary>
		///<returns>
		///IList-DAOPurchaseOrderDetailVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOPurchaseOrderDetailVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPurchaseOrder_DetailVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PurchaseOrder_DetailVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOPurchaseOrderDetailVw> objList = new List<DAOPurchaseOrderDetailVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOPurchaseOrderDetailVw retObj = new DAOPurchaseOrderDetailVw();
						retObj._detailId					 = Convert.IsDBNull(row["DetailId"]) ? (Int32?)null : (Int32?)row["DetailId"];
						retObj._purchaseId					 = Convert.IsDBNull(row["PurchaseId"]) ? (Int32?)null : (Int32?)row["PurchaseId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._quanity					 = Convert.IsDBNull(row["Quanity"]) ? (Int32?)null : (Int32?)row["Quanity"];
						retObj._purchasePrice					 = Convert.IsDBNull(row["PurchasePrice"]) ? (decimal?)null : (decimal?)row["PurchasePrice"];
						retObj._currency					 = Convert.IsDBNull(row["Currency"]) ? null : (string)row["Currency"];
						retObj._exchangeRate					 = Convert.IsDBNull(row["ExchangeRate"]) ? (decimal?)null : (decimal?)row["ExchangeRate"];
						retObj._purchasePriceLocal					 = Convert.IsDBNull(row["PurchasePriceLocal"]) ? (decimal?)null : (decimal?)row["PurchasePriceLocal"];
						retObj._unitId					 = Convert.IsDBNull(row["UnitId"]) ? (Int32?)null : (Int32?)row["UnitId"];
						retObj._unitCode					 = Convert.IsDBNull(row["UnitCode"]) ? null : (string)row["UnitCode"];
						retObj._taxValue					 = Convert.IsDBNull(row["TaxValue"]) ? (decimal?)null : (decimal?)row["TaxValue"];
						retObj._discountValue					 = Convert.IsDBNull(row["DiscountValue"]) ? (decimal?)null : (decimal?)row["DiscountValue"];
						retObj._batchNo					 = Convert.IsDBNull(row["BatchNo"]) ? null : (string)row["BatchNo"];
						retObj._expireDate					 = Convert.IsDBNull(row["ExpireDate"]) ? (DateTime?)null : (DateTime?)row["ExpireDate"];
						retObj._statusReceipt					 = Convert.IsDBNull(row["StatusReceipt"]) ? (Int32?)null : (Int32?)row["StatusReceipt"];
						retObj._vendorCode					 = Convert.IsDBNull(row["VendorCode"]) ? null : (string)row["VendorCode"];
						retObj._vendorNameAr					 = Convert.IsDBNull(row["VendorNameAr"]) ? null : (string)row["VendorNameAr"];
						retObj._storeNameAr					 = Convert.IsDBNull(row["StoreNameAr"]) ? null : (string)row["StoreNameAr"];
						retObj._storeCode					 = Convert.IsDBNull(row["StoreCode"]) ? null : (string)row["StoreCode"];
						retObj._branchCode					 = Convert.IsDBNull(row["BranchCode"]) ? null : (string)row["BranchCode"];
						retObj._branchNameAr					 = Convert.IsDBNull(row["BranchNameAr"]) ? null : (string)row["BranchNameAr"];
						retObj._purchaseCode					 = Convert.IsDBNull(row["PurchaseCode"]) ? null : (string)row["PurchaseCode"];
						retObj._invoiceCode					 = Convert.IsDBNull(row["InvoiceCode"]) ? null : (string)row["InvoiceCode"];
						retObj._invoiceDate					 = Convert.IsDBNull(row["InvoiceDate"]) ? (DateTime?)null : (DateTime?)row["InvoiceDate"];
						retObj._invoiceAmount					 = Convert.IsDBNull(row["InvoiceAmount"]) ? (decimal?)null : (decimal?)row["InvoiceAmount"];
						retObj._expr1					 = Convert.IsDBNull(row["Expr1"]) ? null : (string)row["Expr1"];
						retObj._expr2					 = Convert.IsDBNull(row["Expr2"]) ? (decimal?)null : (decimal?)row["Expr2"];
						retObj._invoiceAmountLocal					 = Convert.IsDBNull(row["InvoiceAmountLocal"]) ? (decimal?)null : (decimal?)row["InvoiceAmountLocal"];
						retObj._sumTax					 = Convert.IsDBNull(row["SumTax"]) ? (decimal?)null : (decimal?)row["SumTax"];
						retObj._sumExpense					 = Convert.IsDBNull(row["SumExpense"]) ? (decimal?)null : (decimal?)row["SumExpense"];
						retObj._openValue					 = Convert.IsDBNull(row["OpenValue"]) ? (decimal?)null : (decimal?)row["OpenValue"];
						retObj._itemCode					 = Convert.IsDBNull(row["ItemCode"]) ? null : (string)row["ItemCode"];
						retObj._itemNameAr					 = Convert.IsDBNull(row["ItemNameAr"]) ? null : (string)row["ItemNameAr"];
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
		///This method returns all data rows in the table using criteriaquery api PurchaseOrder_DetailVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPurchaseOrder_DetailVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public Int32? DetailId
		{
			get
			{
				return _detailId;
			}
			set
			{
				_detailId = value;
			}
		}

		public Int32? PurchaseId
		{
			get
			{
				return _purchaseId;
			}
			set
			{
				_purchaseId = value;
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

		public Int32? Quanity
		{
			get
			{
				return _quanity;
			}
			set
			{
				_quanity = value;
			}
		}

		public decimal? PurchasePrice
		{
			get
			{
				return _purchasePrice;
			}
			set
			{
				_purchasePrice = value;
			}
		}

		public string Currency
		{
			get
			{
				return _currency;
			}
			set
			{
				_currency = value;
			}
		}

		public decimal? ExchangeRate
		{
			get
			{
				return _exchangeRate;
			}
			set
			{
				_exchangeRate = value;
			}
		}

		public decimal? PurchasePriceLocal
		{
			get
			{
				return _purchasePriceLocal;
			}
			set
			{
				_purchasePriceLocal = value;
			}
		}

		public Int32? UnitId
		{
			get
			{
				return _unitId;
			}
			set
			{
				_unitId = value;
			}
		}

		public string UnitCode
		{
			get
			{
				return _unitCode;
			}
			set
			{
				_unitCode = value;
			}
		}

		public decimal? TaxValue
		{
			get
			{
				return _taxValue;
			}
			set
			{
				_taxValue = value;
			}
		}

		public decimal? DiscountValue
		{
			get
			{
				return _discountValue;
			}
			set
			{
				_discountValue = value;
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

		public DateTime? ExpireDate
		{
			get
			{
				return _expireDate;
			}
			set
			{
				_expireDate = value;
			}
		}

		public Int32? StatusReceipt
		{
			get
			{
				return _statusReceipt;
			}
			set
			{
				_statusReceipt = value;
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

		public string StoreNameAr
		{
			get
			{
				return _storeNameAr;
			}
			set
			{
				_storeNameAr = value;
			}
		}

		public string StoreCode
		{
			get
			{
				return _storeCode;
			}
			set
			{
				_storeCode = value;
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

		public string PurchaseCode
		{
			get
			{
				return _purchaseCode;
			}
			set
			{
				_purchaseCode = value;
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

		public decimal? InvoiceAmount
		{
			get
			{
				return _invoiceAmount;
			}
			set
			{
				_invoiceAmount = value;
			}
		}

		public string Expr1
		{
			get
			{
				return _expr1;
			}
			set
			{
				_expr1 = value;
			}
		}

		public decimal? Expr2
		{
			get
			{
				return _expr2;
			}
			set
			{
				_expr2 = value;
			}
		}

		public decimal? InvoiceAmountLocal
		{
			get
			{
				return _invoiceAmountLocal;
			}
			set
			{
				_invoiceAmountLocal = value;
			}
		}

		public decimal? SumTax
		{
			get
			{
				return _sumTax;
			}
			set
			{
				_sumTax = value;
			}
		}

		public decimal? SumExpense
		{
			get
			{
				return _sumExpense;
			}
			set
			{
				_sumExpense = value;
			}
		}

		public decimal? OpenValue
		{
			get
			{
				return _openValue;
			}
			set
			{
				_openValue = value;
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

		#endregion
	}
}

#region inline sql procs
namespace SofiForce.DataObjects
{
	public partial class InlineProcs
	{
		internal static string ctprPurchaseOrder_DetailVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[DetailId]
			,[PurchaseId]
			,[ItemId]
			,[Quanity]
			,[PurchasePrice]
			,[Currency]
			,[ExchangeRate]
			,[PurchasePriceLocal]
			,[UnitId]
			,[UnitCode]
			,[TaxValue]
			,[DiscountValue]
			,[BatchNo]
			,[ExpireDate]
			,[StatusReceipt]
			,[VendorCode]
			,[VendorNameAr]
			,[StoreNameAr]
			,[StoreCode]
			,[BranchCode]
			,[BranchNameAr]
			,[PurchaseCode]
			,[InvoiceCode]
			,[InvoiceDate]
			,[InvoiceAmount]
			,[Expr1]
			,[Expr2]
			,[InvoiceAmountLocal]
			,[SumTax]
			,[SumExpense]
			,[OpenValue]
			,[ItemCode]
			,[ItemNameAr]
			FROM [dbo].[PurchaseOrder_DetailVw]
			";

		internal static string ctprPurchaseOrder_DetailVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[PurchaseOrder_DetailVw]
			";

		internal static string ctprPurchaseOrder_DetailVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[PurchaseOrder_DetailVw]
			##CRITERIA##
			";

		internal static string ctprPurchaseOrder_DetailVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[DetailId]
			,[PurchaseId]
			,[ItemId]
			,[Quanity]
			,[PurchasePrice]
			,[Currency]
			,[ExchangeRate]
			,[PurchasePriceLocal]
			,[UnitId]
			,[UnitCode]
			,[TaxValue]
			,[DiscountValue]
			,[BatchNo]
			,[ExpireDate]
			,[StatusReceipt]
			,[VendorCode]
			,[VendorNameAr]
			,[StoreNameAr]
			,[StoreCode]
			,[BranchCode]
			,[BranchNameAr]
			,[PurchaseCode]
			,[InvoiceCode]
			,[InvoiceDate]
			,[InvoiceAmount]
			,[Expr1]
			,[Expr2]
			,[InvoiceAmountLocal]
			,[SumTax]
			,[SumExpense]
			,[OpenValue]
			,[ItemCode]
			,[ItemNameAr]
			FROM [dbo].[PurchaseOrder_DetailVw]
			##CRITERIA##
			";

		internal static string ctprPurchaseOrder_DetailVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[PurchaseOrder_DetailVw]
			##CRITERIA##
			";

	}
}
#endregion
