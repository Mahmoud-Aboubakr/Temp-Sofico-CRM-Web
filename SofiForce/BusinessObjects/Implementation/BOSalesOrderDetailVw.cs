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
	///This is the definition of the class BOSalesOrderDetailVw.
	///</Summary>
	public partial class BOSalesOrderDetailVw : zSofiForceConn_BaseBusiness, IQueryableCollection
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
		protected decimal? _taxValue;
		protected bool? _isBouns;
		protected string _promotionCode;
		protected string _itemCode;
		protected string _itemNameEn;
		protected string _itemNameAr;
		protected string _vendorNameAr;
		protected string _vendorNameEn;
		protected string _vendorCode;
		protected string _batch;
		protected DateTime? _expiration;
		protected Int32? _itemStoreId;
		protected Int64? _recId;
		protected Int32? _unitId;
		protected decimal? _customDiscount;
		protected bool? _hasPromotion;
		protected Int32? _totalReturn;
		protected Int32? _returnQuantity;
		protected Int32? _returnReasonId;
		protected Int32? _promotionId;
		protected bool? _isTaxable;
		protected Int32? _itemGroupId;
		protected Int32? _vendorId;
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
		public BOSalesOrderDetailVw()
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
		///DAOSalesOrderDetailVw
		///</parameters>
		protected internal BOSalesOrderDetailVw(DAOSalesOrderDetailVw daoSalesOrderDetailVw)
		{
			try
			{
				_detailId = daoSalesOrderDetailVw.DetailId;
				_salesId = daoSalesOrderDetailVw.SalesId;
				_itemId = daoSalesOrderDetailVw.ItemId;
				_publicPrice = daoSalesOrderDetailVw.PublicPrice;
				_clientPrice = daoSalesOrderDetailVw.ClientPrice;
				_quantity = daoSalesOrderDetailVw.Quantity;
				_lineValue = daoSalesOrderDetailVw.LineValue;
				_discount = daoSalesOrderDetailVw.Discount;
				_taxValue = daoSalesOrderDetailVw.TaxValue;
				_isBouns = daoSalesOrderDetailVw.IsBouns;
				_promotionCode = daoSalesOrderDetailVw.PromotionCode;
				_itemCode = daoSalesOrderDetailVw.ItemCode;
				_itemNameEn = daoSalesOrderDetailVw.ItemNameEn;
				_itemNameAr = daoSalesOrderDetailVw.ItemNameAr;
				_vendorNameAr = daoSalesOrderDetailVw.VendorNameAr;
				_vendorNameEn = daoSalesOrderDetailVw.VendorNameEn;
				_vendorCode = daoSalesOrderDetailVw.VendorCode;
				_batch = daoSalesOrderDetailVw.Batch;
				_expiration = daoSalesOrderDetailVw.Expiration;
				_itemStoreId = daoSalesOrderDetailVw.ItemStoreId;
				_recId = daoSalesOrderDetailVw.RecId;
				_unitId = daoSalesOrderDetailVw.UnitId;
				_customDiscount = daoSalesOrderDetailVw.CustomDiscount;
				_hasPromotion = daoSalesOrderDetailVw.HasPromotion;
				_totalReturn = daoSalesOrderDetailVw.TotalReturn;
				_returnQuantity = daoSalesOrderDetailVw.ReturnQuantity;
				_returnReasonId = daoSalesOrderDetailVw.ReturnReasonId;
				_promotionId = daoSalesOrderDetailVw.PromotionId;
				_isTaxable = daoSalesOrderDetailVw.IsTaxable;
				_itemGroupId = daoSalesOrderDetailVw.ItemGroupId;
				_vendorId = daoSalesOrderDetailVw.VendorId;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///SalesOrderDetailVwCollection
		///This method returns the collection of BOSalesOrderDetailVw objects
		///</Summary>
		///<returns>
		///List[BOSalesOrderDetailVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOSalesOrderDetailVw> SalesOrderDetailVwCollection()
		{
			try
			{
				IList<BOSalesOrderDetailVw> boSalesOrderDetailVwCollection = new List<BOSalesOrderDetailVw>();
				IList<DAOSalesOrderDetailVw> daoSalesOrderDetailVwCollection = DAOSalesOrderDetailVw.SelectAll();
			
				foreach(DAOSalesOrderDetailVw daoSalesOrderDetailVw in daoSalesOrderDetailVwCollection)
					boSalesOrderDetailVwCollection.Add(new BOSalesOrderDetailVw(daoSalesOrderDetailVw));
			
				return boSalesOrderDetailVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderDetailVwCollectionCount
		///This method returns the collection count of BOSalesOrderDetailVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 SalesOrderDetailVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOSalesOrderDetailVw.SelectAllCount();
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
		///List<BOSalesOrderDetailVw>
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
				IDictionary<string, IList<object>> retObj = DAOSalesOrderDetailVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderDetailVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOSalesOrderDetailVw objects, filtered by optional criteria
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
				IList<T> boSalesOrderDetailVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOSalesOrderDetailVw> daoSalesOrderDetailVwCollection = DAOSalesOrderDetailVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOSalesOrderDetailVw resdaoSalesOrderDetailVw in daoSalesOrderDetailVwCollection)
					boSalesOrderDetailVwCollection.Add((T)(object)new BOSalesOrderDetailVw(resdaoSalesOrderDetailVw));
			
				return boSalesOrderDetailVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderDetailVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOSalesOrderDetailVw objects, filtered by optional criteria
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
				Int32 objCount = DAOSalesOrderDetailVw.SelectAllByCriteriaCount(lstDataCriteria);
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
		
		public virtual string ItemNameEn
		{
			get
			{
				 return _itemNameEn;
			}
			set
			{
				_itemNameEn = value;
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
		
		public virtual string VendorNameEn
		{
			get
			{
				 return _vendorNameEn;
			}
			set
			{
				_vendorNameEn = value;
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
		
		public virtual bool? HasPromotion
		{
			get
			{
				 return _hasPromotion;
			}
			set
			{
				_hasPromotion = value;
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
		
		public virtual bool? IsTaxable
		{
			get
			{
				 return _isTaxable;
			}
			set
			{
				_isTaxable = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ItemGroupId
		{
			get
			{
				 return _itemGroupId;
			}
			set
			{
				_itemGroupId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? VendorId
		{
			get
			{
				 return _vendorId;
			}
			set
			{
				_vendorId = value;
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
