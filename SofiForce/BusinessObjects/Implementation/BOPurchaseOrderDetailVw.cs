/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 3/23/2023 3:30:39 PM
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Collections.Generic;
using SofiForce.DataObjects;
using SofiForce.DataObjects.Interfaces;
using SofiForce.BusinessObjects.Interfaces;

namespace SofiForce.BusinessObjects
{
	///<Summary>
	///Class definition
	///This is the definition of the class BOPurchaseOrderDetailVw.
	///</Summary>
	public partial class BOPurchaseOrderDetailVw : zSofiForceConn_BaseBusiness, IQueryableCollection
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
		protected bool _isDirty = false;
		/*collection member objects*******************/
		/*********************************************/
		#endregion

		#region class methods
		///<Summary>
		///Constructor
		///This is the default constructor
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public BOPurchaseOrderDetailVw()
		{
		}

		///<Summary>
		///Constructor
		///This constructor initializes the business object from its respective data object
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///DAOPurchaseOrderDetailVw
		///</parameters>
		protected internal BOPurchaseOrderDetailVw(DAOPurchaseOrderDetailVw daoPurchaseOrderDetailVw)
		{
			try
			{
				_detailId = daoPurchaseOrderDetailVw.DetailId;
				_purchaseId = daoPurchaseOrderDetailVw.PurchaseId;
				_itemId = daoPurchaseOrderDetailVw.ItemId;
				_quanity = daoPurchaseOrderDetailVw.Quanity;
				_purchasePrice = daoPurchaseOrderDetailVw.PurchasePrice;
				_currency = daoPurchaseOrderDetailVw.Currency;
				_exchangeRate = daoPurchaseOrderDetailVw.ExchangeRate;
				_purchasePriceLocal = daoPurchaseOrderDetailVw.PurchasePriceLocal;
				_unitId = daoPurchaseOrderDetailVw.UnitId;
				_unitCode = daoPurchaseOrderDetailVw.UnitCode;
				_taxValue = daoPurchaseOrderDetailVw.TaxValue;
				_discountValue = daoPurchaseOrderDetailVw.DiscountValue;
				_batchNo = daoPurchaseOrderDetailVw.BatchNo;
				_expireDate = daoPurchaseOrderDetailVw.ExpireDate;
				_statusReceipt = daoPurchaseOrderDetailVw.StatusReceipt;
				_vendorCode = daoPurchaseOrderDetailVw.VendorCode;
				_vendorNameAr = daoPurchaseOrderDetailVw.VendorNameAr;
				_storeNameAr = daoPurchaseOrderDetailVw.StoreNameAr;
				_storeCode = daoPurchaseOrderDetailVw.StoreCode;
				_branchCode = daoPurchaseOrderDetailVw.BranchCode;
				_branchNameAr = daoPurchaseOrderDetailVw.BranchNameAr;
				_purchaseCode = daoPurchaseOrderDetailVw.PurchaseCode;
				_invoiceCode = daoPurchaseOrderDetailVw.InvoiceCode;
				_invoiceDate = daoPurchaseOrderDetailVw.InvoiceDate;
				_invoiceAmount = daoPurchaseOrderDetailVw.InvoiceAmount;
				_expr1 = daoPurchaseOrderDetailVw.Expr1;
				_expr2 = daoPurchaseOrderDetailVw.Expr2;
				_invoiceAmountLocal = daoPurchaseOrderDetailVw.InvoiceAmountLocal;
				_sumTax = daoPurchaseOrderDetailVw.SumTax;
				_sumExpense = daoPurchaseOrderDetailVw.SumExpense;
				_openValue = daoPurchaseOrderDetailVw.OpenValue;
				_itemCode = daoPurchaseOrderDetailVw.ItemCode;
				_itemNameAr = daoPurchaseOrderDetailVw.ItemNameAr;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///PurchaseOrderDetailVwCollection
		///This method returns the collection of BOPurchaseOrderDetailVw objects
		///</Summary>
		///<returns>
		///List[BOPurchaseOrderDetailVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOPurchaseOrderDetailVw> PurchaseOrderDetailVwCollection()
		{
			try
			{
				IList<BOPurchaseOrderDetailVw> boPurchaseOrderDetailVwCollection = new List<BOPurchaseOrderDetailVw>();
				IList<DAOPurchaseOrderDetailVw> daoPurchaseOrderDetailVwCollection = DAOPurchaseOrderDetailVw.SelectAll();
			
				foreach(DAOPurchaseOrderDetailVw daoPurchaseOrderDetailVw in daoPurchaseOrderDetailVwCollection)
					boPurchaseOrderDetailVwCollection.Add(new BOPurchaseOrderDetailVw(daoPurchaseOrderDetailVw));
			
				return boPurchaseOrderDetailVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PurchaseOrderDetailVwCollectionCount
		///This method returns the collection count of BOPurchaseOrderDetailVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 PurchaseOrderDetailVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOPurchaseOrderDetailVw.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///Projections
		///This method returns the collection of projections, ordered and filtered by optional criteria
		///</Summary>
		///<returns>
		///List<BOPurchaseOrderDetailVw>
		///</returns>
		///<parameters>
		///ICriteria icriteria
		///</parameters>
		public virtual IDictionary<string, IList<object>> Projections(object o)
		{
			try
			{
				ICriteria icriteria = (ICriteria)o;
				IList<IDataProjection> lstDataProjection = (icriteria == null) ? null : icriteria.ListDataProjection();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IDictionary<string, IList<object>> retObj = DAOPurchaseOrderDetailVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PurchaseOrderDetailVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOPurchaseOrderDetailVw objects, filtered by optional criteria
		///</Summary>
		///<returns>
		///IList<T>
		///</returns>
		///<parameters>
		///object o
		///</parameters>
		public virtual IList<T> Collection<T>(object o)
		{
			try
			{
				ICriteria icriteria = (ICriteria)o;
				IList<T> boPurchaseOrderDetailVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOPurchaseOrderDetailVw> daoPurchaseOrderDetailVwCollection = DAOPurchaseOrderDetailVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOPurchaseOrderDetailVw resdaoPurchaseOrderDetailVw in daoPurchaseOrderDetailVwCollection)
					boPurchaseOrderDetailVwCollection.Add((T)(object)new BOPurchaseOrderDetailVw(resdaoPurchaseOrderDetailVw));
			
				return boPurchaseOrderDetailVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PurchaseOrderDetailVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOPurchaseOrderDetailVw objects, filtered by optional criteria
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///object o
		///</parameters>
		public virtual Int32 CollectionCount(object o)
		{
			try
			{
				ICriteria icriteria = (ICriteria)o;
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				Int32 objCount = DAOPurchaseOrderDetailVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? DetailId
		{
			get
			{
				 return _detailId;
			}
			set
			{
				_detailId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? PurchaseId
		{
			get
			{
				 return _purchaseId;
			}
			set
			{
				_purchaseId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ItemId
		{
			get
			{
				 return _itemId;
			}
			set
			{
				_itemId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Quanity
		{
			get
			{
				 return _quanity;
			}
			set
			{
				_quanity = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? PurchasePrice
		{
			get
			{
				 return _purchasePrice;
			}
			set
			{
				_purchasePrice = value;
				_isDirty = true;
			}
		}
		
		public virtual string Currency
		{
			get
			{
				 return _currency;
			}
			set
			{
				_currency = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? ExchangeRate
		{
			get
			{
				 return _exchangeRate;
			}
			set
			{
				_exchangeRate = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? PurchasePriceLocal
		{
			get
			{
				 return _purchasePriceLocal;
			}
			set
			{
				_purchasePriceLocal = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? UnitId
		{
			get
			{
				 return _unitId;
			}
			set
			{
				_unitId = value;
				_isDirty = true;
			}
		}
		
		public virtual string UnitCode
		{
			get
			{
				 return _unitCode;
			}
			set
			{
				_unitCode = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? TaxValue
		{
			get
			{
				 return _taxValue;
			}
			set
			{
				_taxValue = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? DiscountValue
		{
			get
			{
				 return _discountValue;
			}
			set
			{
				_discountValue = value;
				_isDirty = true;
			}
		}
		
		public virtual string BatchNo
		{
			get
			{
				 return _batchNo;
			}
			set
			{
				_batchNo = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? ExpireDate
		{
			get
			{
				 return _expireDate;
			}
			set
			{
				_expireDate = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? StatusReceipt
		{
			get
			{
				 return _statusReceipt;
			}
			set
			{
				_statusReceipt = value;
				_isDirty = true;
			}
		}
		
		public virtual string VendorCode
		{
			get
			{
				 return _vendorCode;
			}
			set
			{
				_vendorCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string VendorNameAr
		{
			get
			{
				 return _vendorNameAr;
			}
			set
			{
				_vendorNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string StoreNameAr
		{
			get
			{
				 return _storeNameAr;
			}
			set
			{
				_storeNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string StoreCode
		{
			get
			{
				 return _storeCode;
			}
			set
			{
				_storeCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string BranchCode
		{
			get
			{
				 return _branchCode;
			}
			set
			{
				_branchCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string BranchNameAr
		{
			get
			{
				 return _branchNameAr;
			}
			set
			{
				_branchNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string PurchaseCode
		{
			get
			{
				 return _purchaseCode;
			}
			set
			{
				_purchaseCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string InvoiceCode
		{
			get
			{
				 return _invoiceCode;
			}
			set
			{
				_invoiceCode = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? InvoiceDate
		{
			get
			{
				 return _invoiceDate;
			}
			set
			{
				_invoiceDate = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? InvoiceAmount
		{
			get
			{
				 return _invoiceAmount;
			}
			set
			{
				_invoiceAmount = value;
				_isDirty = true;
			}
		}
		
		public virtual string Expr1
		{
			get
			{
				 return _expr1;
			}
			set
			{
				_expr1 = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? Expr2
		{
			get
			{
				 return _expr2;
			}
			set
			{
				_expr2 = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? InvoiceAmountLocal
		{
			get
			{
				 return _invoiceAmountLocal;
			}
			set
			{
				_invoiceAmountLocal = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? SumTax
		{
			get
			{
				 return _sumTax;
			}
			set
			{
				_sumTax = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? SumExpense
		{
			get
			{
				 return _sumExpense;
			}
			set
			{
				_sumExpense = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? OpenValue
		{
			get
			{
				 return _openValue;
			}
			set
			{
				_openValue = value;
				_isDirty = true;
			}
		}
		
		public virtual string ItemCode
		{
			get
			{
				 return _itemCode;
			}
			set
			{
				_itemCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string ItemNameAr
		{
			get
			{
				 return _itemNameAr;
			}
			set
			{
				_itemNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual object Repository
		{
			get {	return null;	}
			set	{	}
		}
		
		public virtual bool IsDirty
		{
			get
			{
				 return _isDirty;
			}
			set
			{
				_isDirty = value;
			}
		}
		#endregion
	}
}
