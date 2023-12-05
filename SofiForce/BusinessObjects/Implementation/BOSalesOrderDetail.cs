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
	///This is the definition of the class BOSalesOrderDetail.
	///</Summary>
	public partial class BOSalesOrderDetail : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int64? _detailId;
		protected Int64? _salesId;
		protected Int32? _itemId;
		protected decimal? _publicPrice;
		protected decimal? _clientPrice;
		protected Int32? _quantity;
		protected decimal? _lineValue;
		protected decimal? _discount;
		protected decimal? _customDiscount;
		protected decimal? _taxValue;
		protected bool? _isBouns;
		protected string _promotionCode;
		protected Int32? _itemStoreId;
		protected string _batch;
		protected DateTime? _expiration;
		protected Int64? _recId;
		protected Int32? _unitId;
		protected Int32? _promotionId;
		protected Int32? _returnReasonId;
		protected Int32? _returnQuantity;
		protected Int32? _totalReturn;
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
		public BOSalesOrderDetail()
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
		///Int64 detailId
		///</parameters>
		public BOSalesOrderDetail(Int64 detailId)
		{
			try
			{
				DAOSalesOrderDetail daoSalesOrderDetail = DAOSalesOrderDetail.SelectOne(detailId);
				_detailId = daoSalesOrderDetail.DetailId;
				_salesId = daoSalesOrderDetail.SalesId;
				_itemId = daoSalesOrderDetail.ItemId;
				_publicPrice = daoSalesOrderDetail.PublicPrice;
				_clientPrice = daoSalesOrderDetail.ClientPrice;
				_quantity = daoSalesOrderDetail.Quantity;
				_lineValue = daoSalesOrderDetail.LineValue;
				_discount = daoSalesOrderDetail.Discount;
				_customDiscount = daoSalesOrderDetail.CustomDiscount;
				_taxValue = daoSalesOrderDetail.TaxValue;
				_isBouns = daoSalesOrderDetail.IsBouns;
				_promotionCode = daoSalesOrderDetail.PromotionCode;
				_itemStoreId = daoSalesOrderDetail.ItemStoreId;
				_batch = daoSalesOrderDetail.Batch;
				_expiration = daoSalesOrderDetail.Expiration;
				_recId = daoSalesOrderDetail.RecId;
				_unitId = daoSalesOrderDetail.UnitId;
				_promotionId = daoSalesOrderDetail.PromotionId;
				_returnReasonId = daoSalesOrderDetail.ReturnReasonId;
				_returnQuantity = daoSalesOrderDetail.ReturnQuantity;
				_totalReturn = daoSalesOrderDetail.TotalReturn;
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
		///DAOSalesOrderDetail
		///</parameters>
		protected internal BOSalesOrderDetail(DAOSalesOrderDetail daoSalesOrderDetail)
		{
			try
			{
				_detailId = daoSalesOrderDetail.DetailId;
				_salesId = daoSalesOrderDetail.SalesId;
				_itemId = daoSalesOrderDetail.ItemId;
				_publicPrice = daoSalesOrderDetail.PublicPrice;
				_clientPrice = daoSalesOrderDetail.ClientPrice;
				_quantity = daoSalesOrderDetail.Quantity;
				_lineValue = daoSalesOrderDetail.LineValue;
				_discount = daoSalesOrderDetail.Discount;
				_customDiscount = daoSalesOrderDetail.CustomDiscount;
				_taxValue = daoSalesOrderDetail.TaxValue;
				_isBouns = daoSalesOrderDetail.IsBouns;
				_promotionCode = daoSalesOrderDetail.PromotionCode;
				_itemStoreId = daoSalesOrderDetail.ItemStoreId;
				_batch = daoSalesOrderDetail.Batch;
				_expiration = daoSalesOrderDetail.Expiration;
				_recId = daoSalesOrderDetail.RecId;
				_unitId = daoSalesOrderDetail.UnitId;
				_promotionId = daoSalesOrderDetail.PromotionId;
				_returnReasonId = daoSalesOrderDetail.ReturnReasonId;
				_returnQuantity = daoSalesOrderDetail.ReturnQuantity;
				_totalReturn = daoSalesOrderDetail.TotalReturn;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new SalesOrderDetail record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOSalesOrderDetail daoSalesOrderDetail = new DAOSalesOrderDetail();
			RegisterDataObject(daoSalesOrderDetail);
			BeginTransaction("savenewBOSalesOrderDetail");
			try
			{
				daoSalesOrderDetail.SalesId = _salesId;
				daoSalesOrderDetail.ItemId = _itemId;
				daoSalesOrderDetail.PublicPrice = _publicPrice;
				daoSalesOrderDetail.ClientPrice = _clientPrice;
				daoSalesOrderDetail.Quantity = _quantity;
				daoSalesOrderDetail.LineValue = _lineValue;
				daoSalesOrderDetail.Discount = _discount;
				daoSalesOrderDetail.CustomDiscount = _customDiscount;
				daoSalesOrderDetail.TaxValue = _taxValue;
				daoSalesOrderDetail.IsBouns = _isBouns;
				daoSalesOrderDetail.PromotionCode = _promotionCode;
				daoSalesOrderDetail.ItemStoreId = _itemStoreId;
				daoSalesOrderDetail.Batch = _batch;
				daoSalesOrderDetail.Expiration = _expiration;
				daoSalesOrderDetail.RecId = _recId;
				daoSalesOrderDetail.UnitId = _unitId;
				daoSalesOrderDetail.PromotionId = _promotionId;
				daoSalesOrderDetail.ReturnReasonId = _returnReasonId;
				daoSalesOrderDetail.ReturnQuantity = _returnQuantity;
				daoSalesOrderDetail.TotalReturn = _totalReturn;
				daoSalesOrderDetail.Insert();
				CommitTransaction();
				
				_detailId = daoSalesOrderDetail.DetailId;
				_salesId = daoSalesOrderDetail.SalesId;
				_itemId = daoSalesOrderDetail.ItemId;
				_publicPrice = daoSalesOrderDetail.PublicPrice;
				_clientPrice = daoSalesOrderDetail.ClientPrice;
				_quantity = daoSalesOrderDetail.Quantity;
				_lineValue = daoSalesOrderDetail.LineValue;
				_discount = daoSalesOrderDetail.Discount;
				_customDiscount = daoSalesOrderDetail.CustomDiscount;
				_taxValue = daoSalesOrderDetail.TaxValue;
				_isBouns = daoSalesOrderDetail.IsBouns;
				_promotionCode = daoSalesOrderDetail.PromotionCode;
				_itemStoreId = daoSalesOrderDetail.ItemStoreId;
				_batch = daoSalesOrderDetail.Batch;
				_expiration = daoSalesOrderDetail.Expiration;
				_recId = daoSalesOrderDetail.RecId;
				_unitId = daoSalesOrderDetail.UnitId;
				_promotionId = daoSalesOrderDetail.PromotionId;
				_returnReasonId = daoSalesOrderDetail.ReturnReasonId;
				_returnQuantity = daoSalesOrderDetail.ReturnQuantity;
				_totalReturn = daoSalesOrderDetail.TotalReturn;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOSalesOrderDetail");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one SalesOrderDetail record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOSalesOrderDetail
		///</parameters>
		public virtual void Update()
		{
			DAOSalesOrderDetail daoSalesOrderDetail = new DAOSalesOrderDetail();
			RegisterDataObject(daoSalesOrderDetail);
			BeginTransaction("updateBOSalesOrderDetail");
			try
			{
				daoSalesOrderDetail.DetailId = _detailId;
				daoSalesOrderDetail.SalesId = _salesId;
				daoSalesOrderDetail.ItemId = _itemId;
				daoSalesOrderDetail.PublicPrice = _publicPrice;
				daoSalesOrderDetail.ClientPrice = _clientPrice;
				daoSalesOrderDetail.Quantity = _quantity;
				daoSalesOrderDetail.LineValue = _lineValue;
				daoSalesOrderDetail.Discount = _discount;
				daoSalesOrderDetail.CustomDiscount = _customDiscount;
				daoSalesOrderDetail.TaxValue = _taxValue;
				daoSalesOrderDetail.IsBouns = _isBouns;
				daoSalesOrderDetail.PromotionCode = _promotionCode;
				daoSalesOrderDetail.ItemStoreId = _itemStoreId;
				daoSalesOrderDetail.Batch = _batch;
				daoSalesOrderDetail.Expiration = _expiration;
				daoSalesOrderDetail.RecId = _recId;
				daoSalesOrderDetail.UnitId = _unitId;
				daoSalesOrderDetail.PromotionId = _promotionId;
				daoSalesOrderDetail.ReturnReasonId = _returnReasonId;
				daoSalesOrderDetail.ReturnQuantity = _returnQuantity;
				daoSalesOrderDetail.TotalReturn = _totalReturn;
				daoSalesOrderDetail.Update();
				CommitTransaction();
				
				_detailId = daoSalesOrderDetail.DetailId;
				_salesId = daoSalesOrderDetail.SalesId;
				_itemId = daoSalesOrderDetail.ItemId;
				_publicPrice = daoSalesOrderDetail.PublicPrice;
				_clientPrice = daoSalesOrderDetail.ClientPrice;
				_quantity = daoSalesOrderDetail.Quantity;
				_lineValue = daoSalesOrderDetail.LineValue;
				_discount = daoSalesOrderDetail.Discount;
				_customDiscount = daoSalesOrderDetail.CustomDiscount;
				_taxValue = daoSalesOrderDetail.TaxValue;
				_isBouns = daoSalesOrderDetail.IsBouns;
				_promotionCode = daoSalesOrderDetail.PromotionCode;
				_itemStoreId = daoSalesOrderDetail.ItemStoreId;
				_batch = daoSalesOrderDetail.Batch;
				_expiration = daoSalesOrderDetail.Expiration;
				_recId = daoSalesOrderDetail.RecId;
				_unitId = daoSalesOrderDetail.UnitId;
				_promotionId = daoSalesOrderDetail.PromotionId;
				_returnReasonId = daoSalesOrderDetail.ReturnReasonId;
				_returnQuantity = daoSalesOrderDetail.ReturnQuantity;
				_totalReturn = daoSalesOrderDetail.TotalReturn;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOSalesOrderDetail");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one SalesOrderDetail record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOSalesOrderDetail daoSalesOrderDetail = new DAOSalesOrderDetail();
			RegisterDataObject(daoSalesOrderDetail);
			BeginTransaction("deleteBOSalesOrderDetail");
			try
			{
				daoSalesOrderDetail.DetailId = _detailId;
				daoSalesOrderDetail.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOSalesOrderDetail");
				throw;
			}
		}
		
		///<Summary>
		///SalesOrderDetailCollection
		///This method returns the collection of BOSalesOrderDetail objects
		///</Summary>
		///<returns>
		///List[BOSalesOrderDetail]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOSalesOrderDetail> SalesOrderDetailCollection()
		{
			try
			{
				IList<BOSalesOrderDetail> boSalesOrderDetailCollection = new List<BOSalesOrderDetail>();
				IList<DAOSalesOrderDetail> daoSalesOrderDetailCollection = DAOSalesOrderDetail.SelectAll();
			
				foreach(DAOSalesOrderDetail daoSalesOrderDetail in daoSalesOrderDetailCollection)
					boSalesOrderDetailCollection.Add(new BOSalesOrderDetail(daoSalesOrderDetail));
			
				return boSalesOrderDetailCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderDetailCollectionCount
		///This method returns the collection count of BOSalesOrderDetail objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 SalesOrderDetailCollectionCount()
		{
			try
			{
				Int32 objCount = DAOSalesOrderDetail.SelectAllCount();
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
		///List<BOSalesOrderDetail>
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
				IDictionary<string, IList<object>> retObj = DAOSalesOrderDetail.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderDetailCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOSalesOrderDetail objects, filtered by optional criteria
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
				IList<T> boSalesOrderDetailCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOSalesOrderDetail> daoSalesOrderDetailCollection = DAOSalesOrderDetail.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOSalesOrderDetail resdaoSalesOrderDetail in daoSalesOrderDetailCollection)
					boSalesOrderDetailCollection.Add((T)(object)new BOSalesOrderDetail(resdaoSalesOrderDetail));
			
				return boSalesOrderDetailCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderDetailCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOSalesOrderDetail objects, filtered by optional criteria
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
				Int32 objCount = DAOSalesOrderDetail.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int64? DetailId
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
		
		public virtual Int64? SalesId
		{
			get
			{
				 return _salesId;
			}
			set
			{
				_salesId = value;
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
		
		public virtual decimal? PublicPrice
		{
			get
			{
				 return _publicPrice;
			}
			set
			{
				_publicPrice = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? ClientPrice
		{
			get
			{
				 return _clientPrice;
			}
			set
			{
				_clientPrice = value;
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
		
		public virtual decimal? LineValue
		{
			get
			{
				 return _lineValue;
			}
			set
			{
				_lineValue = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? Discount
		{
			get
			{
				 return _discount;
			}
			set
			{
				_discount = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? CustomDiscount
		{
			get
			{
				 return _customDiscount;
			}
			set
			{
				_customDiscount = value;
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
		
		public virtual bool? IsBouns
		{
			get
			{
				 return _isBouns;
			}
			set
			{
				_isBouns = value;
				_isDirty = true;
			}
		}
		
		public virtual string PromotionCode
		{
			get
			{
				 return _promotionCode;
			}
			set
			{
				_promotionCode = value;
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
		
		public virtual string Batch
		{
			get
			{
				 return _batch;
			}
			set
			{
				_batch = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? Expiration
		{
			get
			{
				 return _expiration;
			}
			set
			{
				_expiration = value;
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
		
		public virtual Int32? PromotionId
		{
			get
			{
				 return _promotionId;
			}
			set
			{
				_promotionId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ReturnReasonId
		{
			get
			{
				 return _returnReasonId;
			}
			set
			{
				_returnReasonId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ReturnQuantity
		{
			get
			{
				 return _returnQuantity;
			}
			set
			{
				_returnQuantity = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? TotalReturn
		{
			get
			{
				 return _totalReturn;
			}
			set
			{
				_totalReturn = value;
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
