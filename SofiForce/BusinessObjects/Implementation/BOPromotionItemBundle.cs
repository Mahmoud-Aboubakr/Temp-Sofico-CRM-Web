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
	///This is the definition of the class BOPromotionItemBundle.
	///</Summary>
	public partial class BOPromotionItemBundle : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _bundleId;
		protected Int32? _promotionId;
		protected Int32? _itemId;
		protected Int32? _quantity;
		protected bool? _isMandatory;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
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
		public BOPromotionItemBundle()
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
		///Int32 bundleId
		///</parameters>
		public BOPromotionItemBundle(Int32 bundleId)
		{
			try
			{
				DAOPromotionItemBundle daoPromotionItemBundle = DAOPromotionItemBundle.SelectOne(bundleId);
				_bundleId = daoPromotionItemBundle.BundleId;
				_promotionId = daoPromotionItemBundle.PromotionId;
				_itemId = daoPromotionItemBundle.ItemId;
				_quantity = daoPromotionItemBundle.Quantity;
				_isMandatory = daoPromotionItemBundle.IsMandatory;
				_cBy = daoPromotionItemBundle.CBy;
				_cDate = daoPromotionItemBundle.CDate;
				_eBy = daoPromotionItemBundle.EBy;
				_eDate = daoPromotionItemBundle.EDate;
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
		///DAOPromotionItemBundle
		///</parameters>
		protected internal BOPromotionItemBundle(DAOPromotionItemBundle daoPromotionItemBundle)
		{
			try
			{
				_bundleId = daoPromotionItemBundle.BundleId;
				_promotionId = daoPromotionItemBundle.PromotionId;
				_itemId = daoPromotionItemBundle.ItemId;
				_quantity = daoPromotionItemBundle.Quantity;
				_isMandatory = daoPromotionItemBundle.IsMandatory;
				_cBy = daoPromotionItemBundle.CBy;
				_cDate = daoPromotionItemBundle.CDate;
				_eBy = daoPromotionItemBundle.EBy;
				_eDate = daoPromotionItemBundle.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new PromotionItemBundle record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOPromotionItemBundle daoPromotionItemBundle = new DAOPromotionItemBundle();
			RegisterDataObject(daoPromotionItemBundle);
			BeginTransaction("savenewBOPromotionItemBundle");
			try
			{
				daoPromotionItemBundle.PromotionId = _promotionId;
				daoPromotionItemBundle.ItemId = _itemId;
				daoPromotionItemBundle.Quantity = _quantity;
				daoPromotionItemBundle.IsMandatory = _isMandatory;
				daoPromotionItemBundle.CBy = _cBy;
				daoPromotionItemBundle.CDate = _cDate;
				daoPromotionItemBundle.EBy = _eBy;
				daoPromotionItemBundle.EDate = _eDate;
				daoPromotionItemBundle.Insert();
				CommitTransaction();
				
				_bundleId = daoPromotionItemBundle.BundleId;
				_promotionId = daoPromotionItemBundle.PromotionId;
				_itemId = daoPromotionItemBundle.ItemId;
				_quantity = daoPromotionItemBundle.Quantity;
				_isMandatory = daoPromotionItemBundle.IsMandatory;
				_cBy = daoPromotionItemBundle.CBy;
				_cDate = daoPromotionItemBundle.CDate;
				_eBy = daoPromotionItemBundle.EBy;
				_eDate = daoPromotionItemBundle.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOPromotionItemBundle");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one PromotionItemBundle record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOPromotionItemBundle
		///</parameters>
		public virtual void Update()
		{
			DAOPromotionItemBundle daoPromotionItemBundle = new DAOPromotionItemBundle();
			RegisterDataObject(daoPromotionItemBundle);
			BeginTransaction("updateBOPromotionItemBundle");
			try
			{
				daoPromotionItemBundle.BundleId = _bundleId;
				daoPromotionItemBundle.PromotionId = _promotionId;
				daoPromotionItemBundle.ItemId = _itemId;
				daoPromotionItemBundle.Quantity = _quantity;
				daoPromotionItemBundle.IsMandatory = _isMandatory;
				daoPromotionItemBundle.CBy = _cBy;
				daoPromotionItemBundle.CDate = _cDate;
				daoPromotionItemBundle.EBy = _eBy;
				daoPromotionItemBundle.EDate = _eDate;
				daoPromotionItemBundle.Update();
				CommitTransaction();
				
				_bundleId = daoPromotionItemBundle.BundleId;
				_promotionId = daoPromotionItemBundle.PromotionId;
				_itemId = daoPromotionItemBundle.ItemId;
				_quantity = daoPromotionItemBundle.Quantity;
				_isMandatory = daoPromotionItemBundle.IsMandatory;
				_cBy = daoPromotionItemBundle.CBy;
				_cDate = daoPromotionItemBundle.CDate;
				_eBy = daoPromotionItemBundle.EBy;
				_eDate = daoPromotionItemBundle.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOPromotionItemBundle");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one PromotionItemBundle record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOPromotionItemBundle daoPromotionItemBundle = new DAOPromotionItemBundle();
			RegisterDataObject(daoPromotionItemBundle);
			BeginTransaction("deleteBOPromotionItemBundle");
			try
			{
				daoPromotionItemBundle.BundleId = _bundleId;
				daoPromotionItemBundle.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOPromotionItemBundle");
				throw;
			}
		}
		
		///<Summary>
		///PromotionItemBundleCollection
		///This method returns the collection of BOPromotionItemBundle objects
		///</Summary>
		///<returns>
		///List[BOPromotionItemBundle]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOPromotionItemBundle> PromotionItemBundleCollection()
		{
			try
			{
				IList<BOPromotionItemBundle> boPromotionItemBundleCollection = new List<BOPromotionItemBundle>();
				IList<DAOPromotionItemBundle> daoPromotionItemBundleCollection = DAOPromotionItemBundle.SelectAll();
			
				foreach(DAOPromotionItemBundle daoPromotionItemBundle in daoPromotionItemBundleCollection)
					boPromotionItemBundleCollection.Add(new BOPromotionItemBundle(daoPromotionItemBundle));
			
				return boPromotionItemBundleCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromotionItemBundleCollectionCount
		///This method returns the collection count of BOPromotionItemBundle objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 PromotionItemBundleCollectionCount()
		{
			try
			{
				Int32 objCount = DAOPromotionItemBundle.SelectAllCount();
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
		///List<BOPromotionItemBundle>
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
				IDictionary<string, IList<object>> retObj = DAOPromotionItemBundle.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromotionItemBundleCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOPromotionItemBundle objects, filtered by optional criteria
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
				IList<T> boPromotionItemBundleCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOPromotionItemBundle> daoPromotionItemBundleCollection = DAOPromotionItemBundle.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOPromotionItemBundle resdaoPromotionItemBundle in daoPromotionItemBundleCollection)
					boPromotionItemBundleCollection.Add((T)(object)new BOPromotionItemBundle(resdaoPromotionItemBundle));
			
				return boPromotionItemBundleCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromotionItemBundleCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOPromotionItemBundle objects, filtered by optional criteria
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
				Int32 objCount = DAOPromotionItemBundle.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? BundleId
		{
			get
			{
				 return _bundleId;
			}
			set
			{
				_bundleId = value;
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
		
		public virtual bool? IsMandatory
		{
			get
			{
				 return _isMandatory;
			}
			set
			{
				_isMandatory = value;
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