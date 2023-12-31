/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 9/9/2023 5:10:24 PM
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
	///This is the definition of the class BOPurchaseOrderDetail.
	///</Summary>
	public partial class BOPurchaseOrderDetail : zSofiForceConn_BaseBusiness, IQueryableCollection
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
		protected decimal? _taxValue;
		protected decimal? _discountValue;
		protected string _batchNo;
		protected DateTime? _expireDate;
		protected Int32? _statusReceipt;
		protected Int32? _itemStoreId;
		protected Int64? _recId;
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
		public BOPurchaseOrderDetail()
		{
		}

		///<Summary>
		///Constructor
		///Constructor using primary key(s)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///Int32 detailId
		///</parameters>
		public BOPurchaseOrderDetail(Int32 detailId)
		{
			try
			{
				DAOPurchaseOrderDetail daoPurchaseOrderDetail = DAOPurchaseOrderDetail.SelectOne(detailId);
				_detailId = daoPurchaseOrderDetail.DetailId;
				_purchaseId = daoPurchaseOrderDetail.PurchaseId;
				_itemId = daoPurchaseOrderDetail.ItemId;
				_quanity = daoPurchaseOrderDetail.Quanity;
				_purchasePrice = daoPurchaseOrderDetail.PurchasePrice;
				_currency = daoPurchaseOrderDetail.Currency;
				_exchangeRate = daoPurchaseOrderDetail.ExchangeRate;
				_purchasePriceLocal = daoPurchaseOrderDetail.PurchasePriceLocal;
				_unitId = daoPurchaseOrderDetail.UnitId;
				_taxValue = daoPurchaseOrderDetail.TaxValue;
				_discountValue = daoPurchaseOrderDetail.DiscountValue;
				_batchNo = daoPurchaseOrderDetail.BatchNo;
				_expireDate = daoPurchaseOrderDetail.ExpireDate;
				_statusReceipt = daoPurchaseOrderDetail.StatusReceipt;
				_itemStoreId = daoPurchaseOrderDetail.ItemStoreId;
				_recId = daoPurchaseOrderDetail.RecId;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///Constructor
		///This constructor initializes the business object from its respective data object
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///DAOPurchaseOrderDetail
		///</parameters>
		protected internal BOPurchaseOrderDetail(DAOPurchaseOrderDetail daoPurchaseOrderDetail)
		{
			try
			{
				_detailId = daoPurchaseOrderDetail.DetailId;
				_purchaseId = daoPurchaseOrderDetail.PurchaseId;
				_itemId = daoPurchaseOrderDetail.ItemId;
				_quanity = daoPurchaseOrderDetail.Quanity;
				_purchasePrice = daoPurchaseOrderDetail.PurchasePrice;
				_currency = daoPurchaseOrderDetail.Currency;
				_exchangeRate = daoPurchaseOrderDetail.ExchangeRate;
				_purchasePriceLocal = daoPurchaseOrderDetail.PurchasePriceLocal;
				_unitId = daoPurchaseOrderDetail.UnitId;
				_taxValue = daoPurchaseOrderDetail.TaxValue;
				_discountValue = daoPurchaseOrderDetail.DiscountValue;
				_batchNo = daoPurchaseOrderDetail.BatchNo;
				_expireDate = daoPurchaseOrderDetail.ExpireDate;
				_statusReceipt = daoPurchaseOrderDetail.StatusReceipt;
				_itemStoreId = daoPurchaseOrderDetail.ItemStoreId;
				_recId = daoPurchaseOrderDetail.RecId;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new PurchaseOrderDetail record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOPurchaseOrderDetail daoPurchaseOrderDetail = new DAOPurchaseOrderDetail();
			RegisterDataObject(daoPurchaseOrderDetail);
			BeginTransaction("savenewBOPurchaseOrderDetail");
			try
			{
				daoPurchaseOrderDetail.PurchaseId = _purchaseId;
				daoPurchaseOrderDetail.ItemId = _itemId;
				daoPurchaseOrderDetail.Quanity = _quanity;
				daoPurchaseOrderDetail.PurchasePrice = _purchasePrice;
				daoPurchaseOrderDetail.Currency = _currency;
				daoPurchaseOrderDetail.ExchangeRate = _exchangeRate;
				daoPurchaseOrderDetail.PurchasePriceLocal = _purchasePriceLocal;
				daoPurchaseOrderDetail.UnitId = _unitId;
				daoPurchaseOrderDetail.TaxValue = _taxValue;
				daoPurchaseOrderDetail.DiscountValue = _discountValue;
				daoPurchaseOrderDetail.BatchNo = _batchNo;
				daoPurchaseOrderDetail.ExpireDate = _expireDate;
				daoPurchaseOrderDetail.StatusReceipt = _statusReceipt;
				daoPurchaseOrderDetail.ItemStoreId = _itemStoreId;
				daoPurchaseOrderDetail.RecId = _recId;
				daoPurchaseOrderDetail.Insert();
				CommitTransaction();
				
				_detailId = daoPurchaseOrderDetail.DetailId;
				_purchaseId = daoPurchaseOrderDetail.PurchaseId;
				_itemId = daoPurchaseOrderDetail.ItemId;
				_quanity = daoPurchaseOrderDetail.Quanity;
				_purchasePrice = daoPurchaseOrderDetail.PurchasePrice;
				_currency = daoPurchaseOrderDetail.Currency;
				_exchangeRate = daoPurchaseOrderDetail.ExchangeRate;
				_purchasePriceLocal = daoPurchaseOrderDetail.PurchasePriceLocal;
				_unitId = daoPurchaseOrderDetail.UnitId;
				_taxValue = daoPurchaseOrderDetail.TaxValue;
				_discountValue = daoPurchaseOrderDetail.DiscountValue;
				_batchNo = daoPurchaseOrderDetail.BatchNo;
				_expireDate = daoPurchaseOrderDetail.ExpireDate;
				_statusReceipt = daoPurchaseOrderDetail.StatusReceipt;
				_itemStoreId = daoPurchaseOrderDetail.ItemStoreId;
				_recId = daoPurchaseOrderDetail.RecId;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOPurchaseOrderDetail");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one PurchaseOrderDetail record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOPurchaseOrderDetail
		///</parameters>
		public virtual void Update()
		{
			DAOPurchaseOrderDetail daoPurchaseOrderDetail = new DAOPurchaseOrderDetail();
			RegisterDataObject(daoPurchaseOrderDetail);
			BeginTransaction("updateBOPurchaseOrderDetail");
			try
			{
				daoPurchaseOrderDetail.DetailId = _detailId;
				daoPurchaseOrderDetail.PurchaseId = _purchaseId;
				daoPurchaseOrderDetail.ItemId = _itemId;
				daoPurchaseOrderDetail.Quanity = _quanity;
				daoPurchaseOrderDetail.PurchasePrice = _purchasePrice;
				daoPurchaseOrderDetail.Currency = _currency;
				daoPurchaseOrderDetail.ExchangeRate = _exchangeRate;
				daoPurchaseOrderDetail.PurchasePriceLocal = _purchasePriceLocal;
				daoPurchaseOrderDetail.UnitId = _unitId;
				daoPurchaseOrderDetail.TaxValue = _taxValue;
				daoPurchaseOrderDetail.DiscountValue = _discountValue;
				daoPurchaseOrderDetail.BatchNo = _batchNo;
				daoPurchaseOrderDetail.ExpireDate = _expireDate;
				daoPurchaseOrderDetail.StatusReceipt = _statusReceipt;
				daoPurchaseOrderDetail.ItemStoreId = _itemStoreId;
				daoPurchaseOrderDetail.RecId = _recId;
				daoPurchaseOrderDetail.Update();
				CommitTransaction();
				
				_detailId = daoPurchaseOrderDetail.DetailId;
				_purchaseId = daoPurchaseOrderDetail.PurchaseId;
				_itemId = daoPurchaseOrderDetail.ItemId;
				_quanity = daoPurchaseOrderDetail.Quanity;
				_purchasePrice = daoPurchaseOrderDetail.PurchasePrice;
				_currency = daoPurchaseOrderDetail.Currency;
				_exchangeRate = daoPurchaseOrderDetail.ExchangeRate;
				_purchasePriceLocal = daoPurchaseOrderDetail.PurchasePriceLocal;
				_unitId = daoPurchaseOrderDetail.UnitId;
				_taxValue = daoPurchaseOrderDetail.TaxValue;
				_discountValue = daoPurchaseOrderDetail.DiscountValue;
				_batchNo = daoPurchaseOrderDetail.BatchNo;
				_expireDate = daoPurchaseOrderDetail.ExpireDate;
				_statusReceipt = daoPurchaseOrderDetail.StatusReceipt;
				_itemStoreId = daoPurchaseOrderDetail.ItemStoreId;
				_recId = daoPurchaseOrderDetail.RecId;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOPurchaseOrderDetail");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one PurchaseOrderDetail record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOPurchaseOrderDetail daoPurchaseOrderDetail = new DAOPurchaseOrderDetail();
			RegisterDataObject(daoPurchaseOrderDetail);
			BeginTransaction("deleteBOPurchaseOrderDetail");
			try
			{
				daoPurchaseOrderDetail.DetailId = _detailId;
				daoPurchaseOrderDetail.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOPurchaseOrderDetail");
				throw;
			}
		}
		
		///<Summary>
		///PurchaseOrderDetailCollection
		///This method returns the collection of BOPurchaseOrderDetail objects
		///</Summary>
		///<returns>
		///List[BOPurchaseOrderDetail]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOPurchaseOrderDetail> PurchaseOrderDetailCollection()
		{
			try
			{
				IList<BOPurchaseOrderDetail> boPurchaseOrderDetailCollection = new List<BOPurchaseOrderDetail>();
				IList<DAOPurchaseOrderDetail> daoPurchaseOrderDetailCollection = DAOPurchaseOrderDetail.SelectAll();
			
				foreach(DAOPurchaseOrderDetail daoPurchaseOrderDetail in daoPurchaseOrderDetailCollection)
					boPurchaseOrderDetailCollection.Add(new BOPurchaseOrderDetail(daoPurchaseOrderDetail));
			
				return boPurchaseOrderDetailCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PurchaseOrderDetailCollectionCount
		///This method returns the collection count of BOPurchaseOrderDetail objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 PurchaseOrderDetailCollectionCount()
		{
			try
			{
				Int32 objCount = DAOPurchaseOrderDetail.SelectAllCount();
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
		///List<BOPurchaseOrderDetail>
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
				IDictionary<string, IList<object>> retObj = DAOPurchaseOrderDetail.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PurchaseOrderDetailCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOPurchaseOrderDetail objects, filtered by optional criteria
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
				IList<T> boPurchaseOrderDetailCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOPurchaseOrderDetail> daoPurchaseOrderDetailCollection = DAOPurchaseOrderDetail.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOPurchaseOrderDetail resdaoPurchaseOrderDetail in daoPurchaseOrderDetailCollection)
					boPurchaseOrderDetailCollection.Add((T)(object)new BOPurchaseOrderDetail(resdaoPurchaseOrderDetail));
			
				return boPurchaseOrderDetailCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PurchaseOrderDetailCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOPurchaseOrderDetail objects, filtered by optional criteria
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
				Int32 objCount = DAOPurchaseOrderDetail.SelectAllByCriteriaCount(lstDataCriteria);
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
		
		public virtual Int32? ItemStoreId
		{
			get
			{
				 return _itemStoreId;
			}
			set
			{
				_itemStoreId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int64? RecId
		{
			get
			{
				 return _recId;
			}
			set
			{
				_recId = value;
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
