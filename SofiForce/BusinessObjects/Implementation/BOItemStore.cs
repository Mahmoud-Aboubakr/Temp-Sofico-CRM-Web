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
	///This is the definition of the class BOItemStore.
	///It maintains a collection of BOPurchaseOrderDetail objects.
	///</Summary>
	public partial class BOItemStore : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _itemStoreId;
		protected Int32? _itemId;
		protected Int32? _branchId;
		protected Int32? _storeId;
		protected Int32? _quantity;
		protected Int32? _onHand;
		protected DateTime? _expireDate;
		protected string _batchNo;
		protected bool? _isActive;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOPurchaseOrderDetail> _boPurchaseOrderDetailCollection;
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
		public BOItemStore()
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
		///Int32 itemStoreId
		///</parameters>
		public BOItemStore(Int32 itemStoreId)
		{
			try
			{
				DAOItemStore daoItemStore = DAOItemStore.SelectOne(itemStoreId);
				_itemStoreId = daoItemStore.ItemStoreId;
				_itemId = daoItemStore.ItemId;
				_branchId = daoItemStore.BranchId;
				_storeId = daoItemStore.StoreId;
				_quantity = daoItemStore.Quantity;
				_onHand = daoItemStore.OnHand;
				_expireDate = daoItemStore.ExpireDate;
				_batchNo = daoItemStore.BatchNo;
				_isActive = daoItemStore.IsActive;
				_cBy = daoItemStore.CBy;
				_cDate = daoItemStore.CDate;
				_eBy = daoItemStore.EBy;
				_eDate = daoItemStore.EDate;
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
		///DAOItemStore
		///</parameters>
		protected internal BOItemStore(DAOItemStore daoItemStore)
		{
			try
			{
				_itemStoreId = daoItemStore.ItemStoreId;
				_itemId = daoItemStore.ItemId;
				_branchId = daoItemStore.BranchId;
				_storeId = daoItemStore.StoreId;
				_quantity = daoItemStore.Quantity;
				_onHand = daoItemStore.OnHand;
				_expireDate = daoItemStore.ExpireDate;
				_batchNo = daoItemStore.BatchNo;
				_isActive = daoItemStore.IsActive;
				_cBy = daoItemStore.CBy;
				_cDate = daoItemStore.CDate;
				_eBy = daoItemStore.EBy;
				_eDate = daoItemStore.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new ItemStore record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOItemStore daoItemStore = new DAOItemStore();
			RegisterDataObject(daoItemStore);
			BeginTransaction("savenewBOItemStore");
			try
			{
				daoItemStore.ItemId = _itemId;
				daoItemStore.BranchId = _branchId;
				daoItemStore.StoreId = _storeId;
				daoItemStore.Quantity = _quantity;
				daoItemStore.OnHand = _onHand;
				daoItemStore.ExpireDate = _expireDate;
				daoItemStore.BatchNo = _batchNo;
				daoItemStore.IsActive = _isActive;
				daoItemStore.CBy = _cBy;
				daoItemStore.CDate = _cDate;
				daoItemStore.EBy = _eBy;
				daoItemStore.EDate = _eDate;
				daoItemStore.Insert();
				CommitTransaction();
				
				_itemStoreId = daoItemStore.ItemStoreId;
				_itemId = daoItemStore.ItemId;
				_branchId = daoItemStore.BranchId;
				_storeId = daoItemStore.StoreId;
				_quantity = daoItemStore.Quantity;
				_onHand = daoItemStore.OnHand;
				_expireDate = daoItemStore.ExpireDate;
				_batchNo = daoItemStore.BatchNo;
				_isActive = daoItemStore.IsActive;
				_cBy = daoItemStore.CBy;
				_cDate = daoItemStore.CDate;
				_eBy = daoItemStore.EBy;
				_eDate = daoItemStore.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOItemStore");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one ItemStore record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOItemStore
		///</parameters>
		public virtual void Update()
		{
			DAOItemStore daoItemStore = new DAOItemStore();
			RegisterDataObject(daoItemStore);
			BeginTransaction("updateBOItemStore");
			try
			{
				daoItemStore.ItemStoreId = _itemStoreId;
				daoItemStore.ItemId = _itemId;
				daoItemStore.BranchId = _branchId;
				daoItemStore.StoreId = _storeId;
				daoItemStore.Quantity = _quantity;
				daoItemStore.OnHand = _onHand;
				daoItemStore.ExpireDate = _expireDate;
				daoItemStore.BatchNo = _batchNo;
				daoItemStore.IsActive = _isActive;
				daoItemStore.CBy = _cBy;
				daoItemStore.CDate = _cDate;
				daoItemStore.EBy = _eBy;
				daoItemStore.EDate = _eDate;
				daoItemStore.Update();
				CommitTransaction();
				
				_itemStoreId = daoItemStore.ItemStoreId;
				_itemId = daoItemStore.ItemId;
				_branchId = daoItemStore.BranchId;
				_storeId = daoItemStore.StoreId;
				_quantity = daoItemStore.Quantity;
				_onHand = daoItemStore.OnHand;
				_expireDate = daoItemStore.ExpireDate;
				_batchNo = daoItemStore.BatchNo;
				_isActive = daoItemStore.IsActive;
				_cBy = daoItemStore.CBy;
				_cDate = daoItemStore.CDate;
				_eBy = daoItemStore.EBy;
				_eDate = daoItemStore.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOItemStore");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one ItemStore record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOItemStore daoItemStore = new DAOItemStore();
			RegisterDataObject(daoItemStore);
			BeginTransaction("deleteBOItemStore");
			try
			{
				daoItemStore.ItemStoreId = _itemStoreId;
				daoItemStore.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOItemStore");
				throw;
			}
		}
		
		///<Summary>
		///ItemStoreCollection
		///This method returns the collection of BOItemStore objects
		///</Summary>
		///<returns>
		///List[BOItemStore]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOItemStore> ItemStoreCollection()
		{
			try
			{
				IList<BOItemStore> boItemStoreCollection = new List<BOItemStore>();
				IList<DAOItemStore> daoItemStoreCollection = DAOItemStore.SelectAll();
			
				foreach(DAOItemStore daoItemStore in daoItemStoreCollection)
					boItemStoreCollection.Add(new BOItemStore(daoItemStore));
			
				return boItemStoreCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemStoreCollectionCount
		///This method returns the collection count of BOItemStore objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ItemStoreCollectionCount()
		{
			try
			{
				Int32 objCount = DAOItemStore.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///PurchaseOrderDetailCollection
		///This method returns its collection of BOPurchaseOrderDetail objects
		///</Summary>
		///<returns>
		///IList[BOPurchaseOrderDetail]
		///</returns>
		///<parameters>
		///BOItemStore
		///</parameters>
		public virtual IList<BOPurchaseOrderDetail> PurchaseOrderDetailCollection()
		{
			try
			{
				if(_boPurchaseOrderDetailCollection == null)
					LoadPurchaseOrderDetailCollection();
				
				return _boPurchaseOrderDetailCollection.AsReadOnly();
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
		///List<BOItemStore>
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
				IDictionary<string, IList<object>> retObj = DAOItemStore.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemStoreCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOItemStore objects, filtered by optional criteria
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
				IList<T> boItemStoreCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOItemStore> daoItemStoreCollection = DAOItemStore.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOItemStore resdaoItemStore in daoItemStoreCollection)
					boItemStoreCollection.Add((T)(object)new BOItemStore(resdaoItemStore));
			
				return boItemStoreCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemStoreCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOItemStore objects, filtered by optional criteria
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
				Int32 objCount = DAOItemStore.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadPurchaseOrderDetailCollection
		///This method loads the internal collection of BOPurchaseOrderDetail objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadPurchaseOrderDetailCollection()
		{
			try
			{
				_boPurchaseOrderDetailCollection = new List<BOPurchaseOrderDetail>();
				IList<DAOPurchaseOrderDetail> daoPurchaseOrderDetailCollection = DAOPurchaseOrderDetail.SelectAllByItemStoreId(_itemStoreId.Value);
				
				foreach(DAOPurchaseOrderDetail daoPurchaseOrderDetail in daoPurchaseOrderDetailCollection)
					_boPurchaseOrderDetailCollection.Add(new BOPurchaseOrderDetail(daoPurchaseOrderDetail));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddPurchaseOrderDetail
		///This method persists a BOPurchaseOrderDetail object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOPurchaseOrderDetail
		///</parameters>
		public virtual void AddPurchaseOrderDetail(BOPurchaseOrderDetail boPurchaseOrderDetail)
		{
			DAOPurchaseOrderDetail daoPurchaseOrderDetail = new DAOPurchaseOrderDetail();
			RegisterDataObject(daoPurchaseOrderDetail);
			BeginTransaction("addPurchaseOrderDetail");
			try
			{
				daoPurchaseOrderDetail.DetailId = boPurchaseOrderDetail.DetailId;
				daoPurchaseOrderDetail.PurchaseId = boPurchaseOrderDetail.PurchaseId;
				daoPurchaseOrderDetail.ItemId = boPurchaseOrderDetail.ItemId;
				daoPurchaseOrderDetail.Quanity = boPurchaseOrderDetail.Quanity;
				daoPurchaseOrderDetail.PurchasePrice = boPurchaseOrderDetail.PurchasePrice;
				daoPurchaseOrderDetail.Currency = boPurchaseOrderDetail.Currency;
				daoPurchaseOrderDetail.ExchangeRate = boPurchaseOrderDetail.ExchangeRate;
				daoPurchaseOrderDetail.PurchasePriceLocal = boPurchaseOrderDetail.PurchasePriceLocal;
				daoPurchaseOrderDetail.UnitId = boPurchaseOrderDetail.UnitId;
				daoPurchaseOrderDetail.TaxValue = boPurchaseOrderDetail.TaxValue;
				daoPurchaseOrderDetail.DiscountValue = boPurchaseOrderDetail.DiscountValue;
				daoPurchaseOrderDetail.BatchNo = boPurchaseOrderDetail.BatchNo;
				daoPurchaseOrderDetail.ExpireDate = boPurchaseOrderDetail.ExpireDate;
				daoPurchaseOrderDetail.StatusReceipt = boPurchaseOrderDetail.StatusReceipt;
				daoPurchaseOrderDetail.RecId = boPurchaseOrderDetail.RecId;
				daoPurchaseOrderDetail.ItemStoreId = _itemStoreId.Value;
				daoPurchaseOrderDetail.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boPurchaseOrderDetail = new BOPurchaseOrderDetail(daoPurchaseOrderDetail);
				if(_boPurchaseOrderDetailCollection != null)
					_boPurchaseOrderDetailCollection.Add(boPurchaseOrderDetail);
			}
			catch
			{
				RollbackTransaction("addPurchaseOrderDetail");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllPurchaseOrderDetail
		///This method deletes all BOPurchaseOrderDetail objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllPurchaseOrderDetail()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllPurchaseOrderDetail");
			try
			{
				DAOPurchaseOrderDetail.DeleteAllByItemStoreId(ConnectionProvider, _itemStoreId.Value);
				CommitTransaction();
				if(_boPurchaseOrderDetailCollection != null)
				{
					_boPurchaseOrderDetailCollection.Clear();
					_boPurchaseOrderDetailCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllPurchaseOrderDetail");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
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
		
		public virtual Int32? BranchId
		{
			get
			{
				 return _branchId;
			}
			set
			{
				_branchId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? StoreId
		{
			get
			{
				 return _storeId;
			}
			set
			{
				_storeId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Quantity
		{
			get
			{
				 return _quantity;
			}
			set
			{
				_quantity = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? OnHand
		{
			get
			{
				 return _onHand;
			}
			set
			{
				_onHand = value;
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
		
		public virtual bool? IsActive
		{
			get
			{
				 return _isActive;
			}
			set
			{
				_isActive = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? CBy
		{
			get
			{
				 return _cBy;
			}
			set
			{
				_cBy = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? CDate
		{
			get
			{
				 return _cDate;
			}
			set
			{
				_cDate = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? EBy
		{
			get
			{
				 return _eBy;
			}
			set
			{
				_eBy = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? EDate
		{
			get
			{
				 return _eDate;
			}
			set
			{
				_eDate = value;
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
