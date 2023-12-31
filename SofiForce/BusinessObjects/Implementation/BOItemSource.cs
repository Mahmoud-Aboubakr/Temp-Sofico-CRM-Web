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
	///This is the definition of the class BOItemSource.
	///It maintains a collection of BOItem objects.
	///</Summary>
	public partial class BOItemSource : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _itemSourceId;
		protected string _itemSourceCode;
		protected string _itemSourceNameAr;
		protected string _itemSourceNameEn;
		protected bool? _isActive;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected bool? _displayOrder;
		protected string _color;
		protected string _icon;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOItem> _boItemCollection;
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
		public BOItemSource()
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
		///Int32 itemSourceId
		///</parameters>
		public BOItemSource(Int32 itemSourceId)
		{
			try
			{
				DAOItemSource daoItemSource = DAOItemSource.SelectOne(itemSourceId);
				_itemSourceId = daoItemSource.ItemSourceId;
				_itemSourceCode = daoItemSource.ItemSourceCode;
				_itemSourceNameAr = daoItemSource.ItemSourceNameAr;
				_itemSourceNameEn = daoItemSource.ItemSourceNameEn;
				_isActive = daoItemSource.IsActive;
				_canEdit = daoItemSource.CanEdit;
				_canDelete = daoItemSource.CanDelete;
				_displayOrder = daoItemSource.DisplayOrder;
				_color = daoItemSource.Color;
				_icon = daoItemSource.Icon;
				_cBy = daoItemSource.CBy;
				_cDate = daoItemSource.CDate;
				_eBy = daoItemSource.EBy;
				_eDate = daoItemSource.EDate;
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
		///DAOItemSource
		///</parameters>
		protected internal BOItemSource(DAOItemSource daoItemSource)
		{
			try
			{
				_itemSourceId = daoItemSource.ItemSourceId;
				_itemSourceCode = daoItemSource.ItemSourceCode;
				_itemSourceNameAr = daoItemSource.ItemSourceNameAr;
				_itemSourceNameEn = daoItemSource.ItemSourceNameEn;
				_isActive = daoItemSource.IsActive;
				_canEdit = daoItemSource.CanEdit;
				_canDelete = daoItemSource.CanDelete;
				_displayOrder = daoItemSource.DisplayOrder;
				_color = daoItemSource.Color;
				_icon = daoItemSource.Icon;
				_cBy = daoItemSource.CBy;
				_cDate = daoItemSource.CDate;
				_eBy = daoItemSource.EBy;
				_eDate = daoItemSource.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new ItemSource record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOItemSource daoItemSource = new DAOItemSource();
			RegisterDataObject(daoItemSource);
			BeginTransaction("savenewBOItemSource");
			try
			{
				daoItemSource.ItemSourceCode = _itemSourceCode;
				daoItemSource.ItemSourceNameAr = _itemSourceNameAr;
				daoItemSource.ItemSourceNameEn = _itemSourceNameEn;
				daoItemSource.IsActive = _isActive;
				daoItemSource.CanEdit = _canEdit;
				daoItemSource.CanDelete = _canDelete;
				daoItemSource.DisplayOrder = _displayOrder;
				daoItemSource.Color = _color;
				daoItemSource.Icon = _icon;
				daoItemSource.CBy = _cBy;
				daoItemSource.CDate = _cDate;
				daoItemSource.EBy = _eBy;
				daoItemSource.EDate = _eDate;
				daoItemSource.Insert();
				CommitTransaction();
				
				_itemSourceId = daoItemSource.ItemSourceId;
				_itemSourceCode = daoItemSource.ItemSourceCode;
				_itemSourceNameAr = daoItemSource.ItemSourceNameAr;
				_itemSourceNameEn = daoItemSource.ItemSourceNameEn;
				_isActive = daoItemSource.IsActive;
				_canEdit = daoItemSource.CanEdit;
				_canDelete = daoItemSource.CanDelete;
				_displayOrder = daoItemSource.DisplayOrder;
				_color = daoItemSource.Color;
				_icon = daoItemSource.Icon;
				_cBy = daoItemSource.CBy;
				_cDate = daoItemSource.CDate;
				_eBy = daoItemSource.EBy;
				_eDate = daoItemSource.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOItemSource");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one ItemSource record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOItemSource
		///</parameters>
		public virtual void Update()
		{
			DAOItemSource daoItemSource = new DAOItemSource();
			RegisterDataObject(daoItemSource);
			BeginTransaction("updateBOItemSource");
			try
			{
				daoItemSource.ItemSourceId = _itemSourceId;
				daoItemSource.ItemSourceCode = _itemSourceCode;
				daoItemSource.ItemSourceNameAr = _itemSourceNameAr;
				daoItemSource.ItemSourceNameEn = _itemSourceNameEn;
				daoItemSource.IsActive = _isActive;
				daoItemSource.CanEdit = _canEdit;
				daoItemSource.CanDelete = _canDelete;
				daoItemSource.DisplayOrder = _displayOrder;
				daoItemSource.Color = _color;
				daoItemSource.Icon = _icon;
				daoItemSource.CBy = _cBy;
				daoItemSource.CDate = _cDate;
				daoItemSource.EBy = _eBy;
				daoItemSource.EDate = _eDate;
				daoItemSource.Update();
				CommitTransaction();
				
				_itemSourceId = daoItemSource.ItemSourceId;
				_itemSourceCode = daoItemSource.ItemSourceCode;
				_itemSourceNameAr = daoItemSource.ItemSourceNameAr;
				_itemSourceNameEn = daoItemSource.ItemSourceNameEn;
				_isActive = daoItemSource.IsActive;
				_canEdit = daoItemSource.CanEdit;
				_canDelete = daoItemSource.CanDelete;
				_displayOrder = daoItemSource.DisplayOrder;
				_color = daoItemSource.Color;
				_icon = daoItemSource.Icon;
				_cBy = daoItemSource.CBy;
				_cDate = daoItemSource.CDate;
				_eBy = daoItemSource.EBy;
				_eDate = daoItemSource.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOItemSource");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one ItemSource record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOItemSource daoItemSource = new DAOItemSource();
			RegisterDataObject(daoItemSource);
			BeginTransaction("deleteBOItemSource");
			try
			{
				daoItemSource.ItemSourceId = _itemSourceId;
				daoItemSource.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOItemSource");
				throw;
			}
		}
		
		///<Summary>
		///ItemSourceCollection
		///This method returns the collection of BOItemSource objects
		///</Summary>
		///<returns>
		///List[BOItemSource]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOItemSource> ItemSourceCollection()
		{
			try
			{
				IList<BOItemSource> boItemSourceCollection = new List<BOItemSource>();
				IList<DAOItemSource> daoItemSourceCollection = DAOItemSource.SelectAll();
			
				foreach(DAOItemSource daoItemSource in daoItemSourceCollection)
					boItemSourceCollection.Add(new BOItemSource(daoItemSource));
			
				return boItemSourceCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemSourceCollectionCount
		///This method returns the collection count of BOItemSource objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ItemSourceCollectionCount()
		{
			try
			{
				Int32 objCount = DAOItemSource.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///ItemCollection
		///This method returns its collection of BOItem objects
		///</Summary>
		///<returns>
		///IList[BOItem]
		///</returns>
		///<parameters>
		///BOItemSource
		///</parameters>
		public virtual IList<BOItem> ItemCollection()
		{
			try
			{
				if(_boItemCollection == null)
					LoadItemCollection();
				
				return _boItemCollection.AsReadOnly();
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
		///List<BOItemSource>
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
				IDictionary<string, IList<object>> retObj = DAOItemSource.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemSourceCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOItemSource objects, filtered by optional criteria
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
				IList<T> boItemSourceCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOItemSource> daoItemSourceCollection = DAOItemSource.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOItemSource resdaoItemSource in daoItemSourceCollection)
					boItemSourceCollection.Add((T)(object)new BOItemSource(resdaoItemSource));
			
				return boItemSourceCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemSourceCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOItemSource objects, filtered by optional criteria
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
				Int32 objCount = DAOItemSource.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadItemCollection
		///This method loads the internal collection of BOItem objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadItemCollection()
		{
			try
			{
				_boItemCollection = new List<BOItem>();
				IList<DAOItem> daoItemCollection = DAOItem.SelectAllByItemSourceId(_itemSourceId.Value);
				
				foreach(DAOItem daoItem in daoItemCollection)
					_boItemCollection.Add(new BOItem(daoItem));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddItem
		///This method persists a BOItem object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOItem
		///</parameters>
		public virtual void AddItem(BOItem boItem)
		{
			DAOItem daoItem = new DAOItem();
			RegisterDataObject(daoItem);
			BeginTransaction("addItem");
			try
			{
				daoItem.ItemId = boItem.ItemId;
				daoItem.VendorId = boItem.VendorId;
				daoItem.ItemGroupId = boItem.ItemGroupId;
				daoItem.AcceptDays = boItem.AcceptDays;
				daoItem.UnitId = boItem.UnitId;
				daoItem.IsTaxable = boItem.IsTaxable;
				daoItem.ItemCode = boItem.ItemCode;
				daoItem.ItemNameEn = boItem.ItemNameEn;
				daoItem.ItemNameAr = boItem.ItemNameAr;
				daoItem.PublicPrice = boItem.PublicPrice;
				daoItem.ClientPrice = boItem.ClientPrice;
				daoItem.ReturnPrice = boItem.ReturnPrice;
				daoItem.CostPrice = boItem.CostPrice;
				daoItem.Discount = boItem.Discount;
				daoItem.IsLocal = boItem.IsLocal;
				daoItem.IsActive = boItem.IsActive;
				daoItem.DisplayOrder = boItem.DisplayOrder;
				daoItem.Color = boItem.Color;
				daoItem.Icon = boItem.Icon;
				daoItem.HasPromotion = boItem.HasPromotion;
				daoItem.IsNewAdded = boItem.IsNewAdded;
				daoItem.IsNewStocked = boItem.IsNewStocked;
				daoItem.CanEdit = boItem.CanEdit;
				daoItem.CanDelete = boItem.CanDelete;
				daoItem.CBy = boItem.CBy;
				daoItem.CDate = boItem.CDate;
				daoItem.EBy = boItem.EBy;
				daoItem.EDate = boItem.EDate;
				daoItem.ProductImage = boItem.ProductImage;
				daoItem.ItemCategoryId = boItem.ItemCategoryId;
				daoItem.DescriptionEn = boItem.DescriptionEn;
				daoItem.DescriptionAr = boItem.DescriptionAr;
				daoItem.ItemSourceId = _itemSourceId.Value;
				daoItem.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boItem = new BOItem(daoItem);
				if(_boItemCollection != null)
					_boItemCollection.Add(boItem);
			}
			catch
			{
				RollbackTransaction("addItem");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllItem
		///This method deletes all BOItem objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllItem()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllItem");
			try
			{
				DAOItem.DeleteAllByItemSourceId(ConnectionProvider, _itemSourceId.Value);
				CommitTransaction();
				if(_boItemCollection != null)
				{
					_boItemCollection.Clear();
					_boItemCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllItem");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? ItemSourceId
		{
			get
			{
				 return _itemSourceId;
			}
			set
			{
				_itemSourceId = value;
				_isDirty = true;
			}
		}
		
		public virtual string ItemSourceCode
		{
			get
			{
				 return _itemSourceCode;
			}
			set
			{
				_itemSourceCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string ItemSourceNameAr
		{
			get
			{
				 return _itemSourceNameAr;
			}
			set
			{
				_itemSourceNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string ItemSourceNameEn
		{
			get
			{
				 return _itemSourceNameEn;
			}
			set
			{
				_itemSourceNameEn = value;
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
		
		public virtual bool? CanEdit
		{
			get
			{
				 return _canEdit;
			}
			set
			{
				_canEdit = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? CanDelete
		{
			get
			{
				 return _canDelete;
			}
			set
			{
				_canDelete = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? DisplayOrder
		{
			get
			{
				 return _displayOrder;
			}
			set
			{
				_displayOrder = value;
				_isDirty = true;
			}
		}
		
		public virtual string Color
		{
			get
			{
				 return _color;
			}
			set
			{
				_color = value;
				_isDirty = true;
			}
		}
		
		public virtual string Icon
		{
			get
			{
				 return _icon;
			}
			set
			{
				_icon = value;
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
