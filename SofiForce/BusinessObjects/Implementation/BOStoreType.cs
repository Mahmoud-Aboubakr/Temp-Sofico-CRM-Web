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
	///This is the definition of the class BOStoreType.
	///It maintains a collection of BOStore objects.
	///</Summary>
	public partial class BOStoreType : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _storeTypeId;
		protected string _storeTypeNameEn;
		protected string _storeTypeCode;
		protected string _storeTypeNameAr;
		protected bool? _isActive;
		protected Int32? _displayOrder;
		protected bool? _isOrder;
		protected string _icon;
		protected string _color;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOStore> _boStoreCollection;
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
		public BOStoreType()
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
		///Int32 storeTypeId
		///</parameters>
		public BOStoreType(Int32 storeTypeId)
		{
			try
			{
				DAOStoreType daoStoreType = DAOStoreType.SelectOne(storeTypeId);
				_storeTypeId = daoStoreType.StoreTypeId;
				_storeTypeNameEn = daoStoreType.StoreTypeNameEn;
				_storeTypeCode = daoStoreType.StoreTypeCode;
				_storeTypeNameAr = daoStoreType.StoreTypeNameAr;
				_isActive = daoStoreType.IsActive;
				_displayOrder = daoStoreType.DisplayOrder;
				_isOrder = daoStoreType.IsOrder;
				_icon = daoStoreType.Icon;
				_color = daoStoreType.Color;
				_canEdit = daoStoreType.CanEdit;
				_canDelete = daoStoreType.CanDelete;
				_cBy = daoStoreType.CBy;
				_cDate = daoStoreType.CDate;
				_eBy = daoStoreType.EBy;
				_eDate = daoStoreType.EDate;
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
		///DAOStoreType
		///</parameters>
		protected internal BOStoreType(DAOStoreType daoStoreType)
		{
			try
			{
				_storeTypeId = daoStoreType.StoreTypeId;
				_storeTypeNameEn = daoStoreType.StoreTypeNameEn;
				_storeTypeCode = daoStoreType.StoreTypeCode;
				_storeTypeNameAr = daoStoreType.StoreTypeNameAr;
				_isActive = daoStoreType.IsActive;
				_displayOrder = daoStoreType.DisplayOrder;
				_isOrder = daoStoreType.IsOrder;
				_icon = daoStoreType.Icon;
				_color = daoStoreType.Color;
				_canEdit = daoStoreType.CanEdit;
				_canDelete = daoStoreType.CanDelete;
				_cBy = daoStoreType.CBy;
				_cDate = daoStoreType.CDate;
				_eBy = daoStoreType.EBy;
				_eDate = daoStoreType.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new StoreType record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOStoreType daoStoreType = new DAOStoreType();
			RegisterDataObject(daoStoreType);
			BeginTransaction("savenewBOStoreType");
			try
			{
				daoStoreType.StoreTypeNameEn = _storeTypeNameEn;
				daoStoreType.StoreTypeCode = _storeTypeCode;
				daoStoreType.StoreTypeNameAr = _storeTypeNameAr;
				daoStoreType.IsActive = _isActive;
				daoStoreType.DisplayOrder = _displayOrder;
				daoStoreType.IsOrder = _isOrder;
				daoStoreType.Icon = _icon;
				daoStoreType.Color = _color;
				daoStoreType.CanEdit = _canEdit;
				daoStoreType.CanDelete = _canDelete;
				daoStoreType.CBy = _cBy;
				daoStoreType.CDate = _cDate;
				daoStoreType.EBy = _eBy;
				daoStoreType.EDate = _eDate;
				daoStoreType.Insert();
				CommitTransaction();
				
				_storeTypeId = daoStoreType.StoreTypeId;
				_storeTypeNameEn = daoStoreType.StoreTypeNameEn;
				_storeTypeCode = daoStoreType.StoreTypeCode;
				_storeTypeNameAr = daoStoreType.StoreTypeNameAr;
				_isActive = daoStoreType.IsActive;
				_displayOrder = daoStoreType.DisplayOrder;
				_isOrder = daoStoreType.IsOrder;
				_icon = daoStoreType.Icon;
				_color = daoStoreType.Color;
				_canEdit = daoStoreType.CanEdit;
				_canDelete = daoStoreType.CanDelete;
				_cBy = daoStoreType.CBy;
				_cDate = daoStoreType.CDate;
				_eBy = daoStoreType.EBy;
				_eDate = daoStoreType.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOStoreType");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one StoreType record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOStoreType
		///</parameters>
		public virtual void Update()
		{
			DAOStoreType daoStoreType = new DAOStoreType();
			RegisterDataObject(daoStoreType);
			BeginTransaction("updateBOStoreType");
			try
			{
				daoStoreType.StoreTypeId = _storeTypeId;
				daoStoreType.StoreTypeNameEn = _storeTypeNameEn;
				daoStoreType.StoreTypeCode = _storeTypeCode;
				daoStoreType.StoreTypeNameAr = _storeTypeNameAr;
				daoStoreType.IsActive = _isActive;
				daoStoreType.DisplayOrder = _displayOrder;
				daoStoreType.IsOrder = _isOrder;
				daoStoreType.Icon = _icon;
				daoStoreType.Color = _color;
				daoStoreType.CanEdit = _canEdit;
				daoStoreType.CanDelete = _canDelete;
				daoStoreType.CBy = _cBy;
				daoStoreType.CDate = _cDate;
				daoStoreType.EBy = _eBy;
				daoStoreType.EDate = _eDate;
				daoStoreType.Update();
				CommitTransaction();
				
				_storeTypeId = daoStoreType.StoreTypeId;
				_storeTypeNameEn = daoStoreType.StoreTypeNameEn;
				_storeTypeCode = daoStoreType.StoreTypeCode;
				_storeTypeNameAr = daoStoreType.StoreTypeNameAr;
				_isActive = daoStoreType.IsActive;
				_displayOrder = daoStoreType.DisplayOrder;
				_isOrder = daoStoreType.IsOrder;
				_icon = daoStoreType.Icon;
				_color = daoStoreType.Color;
				_canEdit = daoStoreType.CanEdit;
				_canDelete = daoStoreType.CanDelete;
				_cBy = daoStoreType.CBy;
				_cDate = daoStoreType.CDate;
				_eBy = daoStoreType.EBy;
				_eDate = daoStoreType.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOStoreType");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one StoreType record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOStoreType daoStoreType = new DAOStoreType();
			RegisterDataObject(daoStoreType);
			BeginTransaction("deleteBOStoreType");
			try
			{
				daoStoreType.StoreTypeId = _storeTypeId;
				daoStoreType.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOStoreType");
				throw;
			}
		}
		
		///<Summary>
		///StoreTypeCollection
		///This method returns the collection of BOStoreType objects
		///</Summary>
		///<returns>
		///List[BOStoreType]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOStoreType> StoreTypeCollection()
		{
			try
			{
				IList<BOStoreType> boStoreTypeCollection = new List<BOStoreType>();
				IList<DAOStoreType> daoStoreTypeCollection = DAOStoreType.SelectAll();
			
				foreach(DAOStoreType daoStoreType in daoStoreTypeCollection)
					boStoreTypeCollection.Add(new BOStoreType(daoStoreType));
			
				return boStoreTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///StoreTypeCollectionCount
		///This method returns the collection count of BOStoreType objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 StoreTypeCollectionCount()
		{
			try
			{
				Int32 objCount = DAOStoreType.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///StoreCollection
		///This method returns its collection of BOStore objects
		///</Summary>
		///<returns>
		///IList[BOStore]
		///</returns>
		///<parameters>
		///BOStoreType
		///</parameters>
		public virtual IList<BOStore> StoreCollection()
		{
			try
			{
				if(_boStoreCollection == null)
					LoadStoreCollection();
				
				return _boStoreCollection.AsReadOnly();
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
		///List<BOStoreType>
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
				IDictionary<string, IList<object>> retObj = DAOStoreType.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///StoreTypeCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOStoreType objects, filtered by optional criteria
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
				IList<T> boStoreTypeCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOStoreType> daoStoreTypeCollection = DAOStoreType.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOStoreType resdaoStoreType in daoStoreTypeCollection)
					boStoreTypeCollection.Add((T)(object)new BOStoreType(resdaoStoreType));
			
				return boStoreTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///StoreTypeCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOStoreType objects, filtered by optional criteria
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
				Int32 objCount = DAOStoreType.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadStoreCollection
		///This method loads the internal collection of BOStore objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadStoreCollection()
		{
			try
			{
				_boStoreCollection = new List<BOStore>();
				IList<DAOStore> daoStoreCollection = DAOStore.SelectAllByStoreTypeId(_storeTypeId.Value);
				
				foreach(DAOStore daoStore in daoStoreCollection)
					_boStoreCollection.Add(new BOStore(daoStore));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddStore
		///This method persists a BOStore object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOStore
		///</parameters>
		public virtual void AddStore(BOStore boStore)
		{
			DAOStore daoStore = new DAOStore();
			RegisterDataObject(daoStore);
			BeginTransaction("addStore");
			try
			{
				daoStore.StoreId = boStore.StoreId;
				daoStore.BranchId = boStore.BranchId;
				daoStore.StoreNameEn = boStore.StoreNameEn;
				daoStore.StoreNameAr = boStore.StoreNameAr;
				daoStore.StoreCode = boStore.StoreCode;
				daoStore.IsActive = boStore.IsActive;
				daoStore.Icon = boStore.Icon;
				daoStore.Color = boStore.Color;
				daoStore.DisplayOrder = boStore.DisplayOrder;
				daoStore.CanDelete = boStore.CanDelete;
				daoStore.CanEdit = boStore.CanEdit;
				daoStore.CBy = boStore.CBy;
				daoStore.CDate = boStore.CDate;
				daoStore.EBy = boStore.EBy;
				daoStore.EDate = boStore.EDate;
				daoStore.RecId = boStore.RecId;
				daoStore.StoreTypeId = _storeTypeId.Value;
				daoStore.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boStore = new BOStore(daoStore);
				if(_boStoreCollection != null)
					_boStoreCollection.Add(boStore);
			}
			catch
			{
				RollbackTransaction("addStore");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllStore
		///This method deletes all BOStore objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllStore()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllStore");
			try
			{
				DAOStore.DeleteAllByStoreTypeId(ConnectionProvider, _storeTypeId.Value);
				CommitTransaction();
				if(_boStoreCollection != null)
				{
					_boStoreCollection.Clear();
					_boStoreCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllStore");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? StoreTypeId
		{
			get
			{
				 return _storeTypeId;
			}
			set
			{
				_storeTypeId = value;
				_isDirty = true;
			}
		}
		
		public virtual string StoreTypeNameEn
		{
			get
			{
				 return _storeTypeNameEn;
			}
			set
			{
				_storeTypeNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string StoreTypeCode
		{
			get
			{
				 return _storeTypeCode;
			}
			set
			{
				_storeTypeCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string StoreTypeNameAr
		{
			get
			{
				 return _storeTypeNameAr;
			}
			set
			{
				_storeTypeNameAr = value;
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
		
		public virtual bool? IsOrder
		{
			get
			{
				 return _isOrder;
			}
			set
			{
				_isOrder = value;
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
