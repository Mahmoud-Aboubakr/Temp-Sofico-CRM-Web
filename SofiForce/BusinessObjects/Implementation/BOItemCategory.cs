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
	///This is the definition of the class BOItemCategory.
	///It maintains a collection of BOItem objects.
	///</Summary>
	public partial class BOItemCategory : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _itemCategoryId;
		protected string _itemCategoryCode;
		protected string _itemCategoryNameEn;
		protected string _itemCategoryNameAr;
		protected bool? _isActive;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected Int32? _displayOrder;
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
		public BOItemCategory()
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
		///Int32 itemCategoryId
		///</parameters>
		public BOItemCategory(Int32 itemCategoryId)
		{
			try
			{
				DAOItemCategory daoItemCategory = DAOItemCategory.SelectOne(itemCategoryId);
				_itemCategoryId = daoItemCategory.ItemCategoryId;
				_itemCategoryCode = daoItemCategory.ItemCategoryCode;
				_itemCategoryNameEn = daoItemCategory.ItemCategoryNameEn;
				_itemCategoryNameAr = daoItemCategory.ItemCategoryNameAr;
				_isActive = daoItemCategory.IsActive;
				_canEdit = daoItemCategory.CanEdit;
				_canDelete = daoItemCategory.CanDelete;
				_displayOrder = daoItemCategory.DisplayOrder;
				_color = daoItemCategory.Color;
				_icon = daoItemCategory.Icon;
				_cBy = daoItemCategory.CBy;
				_cDate = daoItemCategory.CDate;
				_eBy = daoItemCategory.EBy;
				_eDate = daoItemCategory.EDate;
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
		///DAOItemCategory
		///</parameters>
		protected internal BOItemCategory(DAOItemCategory daoItemCategory)
		{
			try
			{
				_itemCategoryId = daoItemCategory.ItemCategoryId;
				_itemCategoryCode = daoItemCategory.ItemCategoryCode;
				_itemCategoryNameEn = daoItemCategory.ItemCategoryNameEn;
				_itemCategoryNameAr = daoItemCategory.ItemCategoryNameAr;
				_isActive = daoItemCategory.IsActive;
				_canEdit = daoItemCategory.CanEdit;
				_canDelete = daoItemCategory.CanDelete;
				_displayOrder = daoItemCategory.DisplayOrder;
				_color = daoItemCategory.Color;
				_icon = daoItemCategory.Icon;
				_cBy = daoItemCategory.CBy;
				_cDate = daoItemCategory.CDate;
				_eBy = daoItemCategory.EBy;
				_eDate = daoItemCategory.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new ItemCategory record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOItemCategory daoItemCategory = new DAOItemCategory();
			RegisterDataObject(daoItemCategory);
			BeginTransaction("savenewBOItemCategory");
			try
			{
				daoItemCategory.ItemCategoryCode = _itemCategoryCode;
				daoItemCategory.ItemCategoryNameEn = _itemCategoryNameEn;
				daoItemCategory.ItemCategoryNameAr = _itemCategoryNameAr;
				daoItemCategory.IsActive = _isActive;
				daoItemCategory.CanEdit = _canEdit;
				daoItemCategory.CanDelete = _canDelete;
				daoItemCategory.DisplayOrder = _displayOrder;
				daoItemCategory.Color = _color;
				daoItemCategory.Icon = _icon;
				daoItemCategory.CBy = _cBy;
				daoItemCategory.CDate = _cDate;
				daoItemCategory.EBy = _eBy;
				daoItemCategory.EDate = _eDate;
				daoItemCategory.Insert();
				CommitTransaction();
				
				_itemCategoryId = daoItemCategory.ItemCategoryId;
				_itemCategoryCode = daoItemCategory.ItemCategoryCode;
				_itemCategoryNameEn = daoItemCategory.ItemCategoryNameEn;
				_itemCategoryNameAr = daoItemCategory.ItemCategoryNameAr;
				_isActive = daoItemCategory.IsActive;
				_canEdit = daoItemCategory.CanEdit;
				_canDelete = daoItemCategory.CanDelete;
				_displayOrder = daoItemCategory.DisplayOrder;
				_color = daoItemCategory.Color;
				_icon = daoItemCategory.Icon;
				_cBy = daoItemCategory.CBy;
				_cDate = daoItemCategory.CDate;
				_eBy = daoItemCategory.EBy;
				_eDate = daoItemCategory.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOItemCategory");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one ItemCategory record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOItemCategory
		///</parameters>
		public virtual void Update()
		{
			DAOItemCategory daoItemCategory = new DAOItemCategory();
			RegisterDataObject(daoItemCategory);
			BeginTransaction("updateBOItemCategory");
			try
			{
				daoItemCategory.ItemCategoryId = _itemCategoryId;
				daoItemCategory.ItemCategoryCode = _itemCategoryCode;
				daoItemCategory.ItemCategoryNameEn = _itemCategoryNameEn;
				daoItemCategory.ItemCategoryNameAr = _itemCategoryNameAr;
				daoItemCategory.IsActive = _isActive;
				daoItemCategory.CanEdit = _canEdit;
				daoItemCategory.CanDelete = _canDelete;
				daoItemCategory.DisplayOrder = _displayOrder;
				daoItemCategory.Color = _color;
				daoItemCategory.Icon = _icon;
				daoItemCategory.CBy = _cBy;
				daoItemCategory.CDate = _cDate;
				daoItemCategory.EBy = _eBy;
				daoItemCategory.EDate = _eDate;
				daoItemCategory.Update();
				CommitTransaction();
				
				_itemCategoryId = daoItemCategory.ItemCategoryId;
				_itemCategoryCode = daoItemCategory.ItemCategoryCode;
				_itemCategoryNameEn = daoItemCategory.ItemCategoryNameEn;
				_itemCategoryNameAr = daoItemCategory.ItemCategoryNameAr;
				_isActive = daoItemCategory.IsActive;
				_canEdit = daoItemCategory.CanEdit;
				_canDelete = daoItemCategory.CanDelete;
				_displayOrder = daoItemCategory.DisplayOrder;
				_color = daoItemCategory.Color;
				_icon = daoItemCategory.Icon;
				_cBy = daoItemCategory.CBy;
				_cDate = daoItemCategory.CDate;
				_eBy = daoItemCategory.EBy;
				_eDate = daoItemCategory.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOItemCategory");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one ItemCategory record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOItemCategory daoItemCategory = new DAOItemCategory();
			RegisterDataObject(daoItemCategory);
			BeginTransaction("deleteBOItemCategory");
			try
			{
				daoItemCategory.ItemCategoryId = _itemCategoryId;
				daoItemCategory.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOItemCategory");
				throw;
			}
		}
		
		///<Summary>
		///ItemCategoryCollection
		///This method returns the collection of BOItemCategory objects
		///</Summary>
		///<returns>
		///List[BOItemCategory]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOItemCategory> ItemCategoryCollection()
		{
			try
			{
				IList<BOItemCategory> boItemCategoryCollection = new List<BOItemCategory>();
				IList<DAOItemCategory> daoItemCategoryCollection = DAOItemCategory.SelectAll();
			
				foreach(DAOItemCategory daoItemCategory in daoItemCategoryCollection)
					boItemCategoryCollection.Add(new BOItemCategory(daoItemCategory));
			
				return boItemCategoryCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemCategoryCollectionCount
		///This method returns the collection count of BOItemCategory objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ItemCategoryCollectionCount()
		{
			try
			{
				Int32 objCount = DAOItemCategory.SelectAllCount();
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
		///BOItemCategory
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
		///List<BOItemCategory>
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
				IDictionary<string, IList<object>> retObj = DAOItemCategory.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemCategoryCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOItemCategory objects, filtered by optional criteria
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
				IList<T> boItemCategoryCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOItemCategory> daoItemCategoryCollection = DAOItemCategory.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOItemCategory resdaoItemCategory in daoItemCategoryCollection)
					boItemCategoryCollection.Add((T)(object)new BOItemCategory(resdaoItemCategory));
			
				return boItemCategoryCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemCategoryCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOItemCategory objects, filtered by optional criteria
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
				Int32 objCount = DAOItemCategory.SelectAllByCriteriaCount(lstDataCriteria);
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
				IList<DAOItem> daoItemCollection = DAOItem.SelectAllByItemCategoryId(_itemCategoryId.Value);
				
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
				daoItem.ItemSourceId = boItem.ItemSourceId;
				daoItem.DescriptionEn = boItem.DescriptionEn;
				daoItem.DescriptionAr = boItem.DescriptionAr;
				daoItem.ItemCategoryId = _itemCategoryId.Value;
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
				DAOItem.DeleteAllByItemCategoryId(ConnectionProvider, _itemCategoryId.Value);
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
		
		public virtual Int32? ItemCategoryId
		{
			get
			{
				 return _itemCategoryId;
			}
			set
			{
				_itemCategoryId = value;
				_isDirty = true;
			}
		}
		
		public virtual string ItemCategoryCode
		{
			get
			{
				 return _itemCategoryCode;
			}
			set
			{
				_itemCategoryCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string ItemCategoryNameEn
		{
			get
			{
				 return _itemCategoryNameEn;
			}
			set
			{
				_itemCategoryNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string ItemCategoryNameAr
		{
			get
			{
				 return _itemCategoryNameAr;
			}
			set
			{
				_itemCategoryNameAr = value;
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
		
		public virtual Int32? DisplayOrder
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
