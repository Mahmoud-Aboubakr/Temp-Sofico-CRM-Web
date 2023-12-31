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
	///This is the definition of the class BOItemQuotaVw.
	///</Summary>
	public partial class BOItemQuotaVw : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _quantity;
		protected Int32? _itemId;
		protected string _itemCode;
		protected string _itemNameEn;
		protected string _itemNameAr;
		protected decimal? _publicPrice;
		protected decimal? _clientPrice;
		protected decimal? _discount;
		protected bool? _isActive;
		protected DateTime? _toDate;
		protected DateTime? _fromDate;
		protected string _vendorCode;
		protected string _vendorNameEn;
		protected Int32? _vendorId;
		protected string _vendorNameAr;
		protected bool? _hasPromotion;
		protected bool? _isNewAdded;
		protected bool? _isNewStocked;
		protected bool? _isTaxable;
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
		public BOItemQuotaVw()
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
		///DAOItemQuotaVw
		///</parameters>
		protected internal BOItemQuotaVw(DAOItemQuotaVw daoItemQuotaVw)
		{
			try
			{
				_quantity = daoItemQuotaVw.Quantity;
				_itemId = daoItemQuotaVw.ItemId;
				_itemCode = daoItemQuotaVw.ItemCode;
				_itemNameEn = daoItemQuotaVw.ItemNameEn;
				_itemNameAr = daoItemQuotaVw.ItemNameAr;
				_publicPrice = daoItemQuotaVw.PublicPrice;
				_clientPrice = daoItemQuotaVw.ClientPrice;
				_discount = daoItemQuotaVw.Discount;
				_isActive = daoItemQuotaVw.IsActive;
				_toDate = daoItemQuotaVw.ToDate;
				_fromDate = daoItemQuotaVw.FromDate;
				_vendorCode = daoItemQuotaVw.VendorCode;
				_vendorNameEn = daoItemQuotaVw.VendorNameEn;
				_vendorId = daoItemQuotaVw.VendorId;
				_vendorNameAr = daoItemQuotaVw.VendorNameAr;
				_hasPromotion = daoItemQuotaVw.HasPromotion;
				_isNewAdded = daoItemQuotaVw.IsNewAdded;
				_isNewStocked = daoItemQuotaVw.IsNewStocked;
				_isTaxable = daoItemQuotaVw.IsTaxable;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///ItemQuotaVwCollection
		///This method returns the collection of BOItemQuotaVw objects
		///</Summary>
		///<returns>
		///List[BOItemQuotaVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOItemQuotaVw> ItemQuotaVwCollection()
		{
			try
			{
				IList<BOItemQuotaVw> boItemQuotaVwCollection = new List<BOItemQuotaVw>();
				IList<DAOItemQuotaVw> daoItemQuotaVwCollection = DAOItemQuotaVw.SelectAll();
			
				foreach(DAOItemQuotaVw daoItemQuotaVw in daoItemQuotaVwCollection)
					boItemQuotaVwCollection.Add(new BOItemQuotaVw(daoItemQuotaVw));
			
				return boItemQuotaVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemQuotaVwCollectionCount
		///This method returns the collection count of BOItemQuotaVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ItemQuotaVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOItemQuotaVw.SelectAllCount();
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
		///List<BOItemQuotaVw>
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
				IDictionary<string, IList<object>> retObj = DAOItemQuotaVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemQuotaVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOItemQuotaVw objects, filtered by optional criteria
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
				IList<T> boItemQuotaVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOItemQuotaVw> daoItemQuotaVwCollection = DAOItemQuotaVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOItemQuotaVw resdaoItemQuotaVw in daoItemQuotaVwCollection)
					boItemQuotaVwCollection.Add((T)(object)new BOItemQuotaVw(resdaoItemQuotaVw));
			
				return boItemQuotaVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemQuotaVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOItemQuotaVw objects, filtered by optional criteria
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
				Int32 objCount = DAOItemQuotaVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
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
		
		public virtual DateTime? ToDate
		{
			get
			{
				 return _toDate;
			}
			set
			{
				_toDate = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? FromDate
		{
			get
			{
				 return _fromDate;
			}
			set
			{
				_fromDate = value;
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
		
		public virtual bool? IsNewAdded
		{
			get
			{
				 return _isNewAdded;
			}
			set
			{
				_isNewAdded = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? IsNewStocked
		{
			get
			{
				 return _isNewStocked;
			}
			set
			{
				_isNewStocked = value;
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
