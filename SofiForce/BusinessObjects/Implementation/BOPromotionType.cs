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
	///This is the definition of the class BOPromotionType.
	///It maintains a collection of BOPromotion objects.
	///</Summary>
	public partial class BOPromotionType : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _promotionTypeId;
		protected string _promotionTypeCode;
		protected string _promotionTypeNameAr;
		protected string _promotionTypeNameEn;
		protected string _promotionTypeDesc;
		protected Int32? _promotionInputId;
		protected Int32? _promotionOutputId;
		protected bool? _isActive;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected Int32? _displayOrder;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOPromotion> _boPromotionCollection;
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
		public BOPromotionType()
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
		///Int32 promotionTypeId
		///</parameters>
		public BOPromotionType(Int32 promotionTypeId)
		{
			try
			{
				DAOPromotionType daoPromotionType = DAOPromotionType.SelectOne(promotionTypeId);
				_promotionTypeId = daoPromotionType.PromotionTypeId;
				_promotionTypeCode = daoPromotionType.PromotionTypeCode;
				_promotionTypeNameAr = daoPromotionType.PromotionTypeNameAr;
				_promotionTypeNameEn = daoPromotionType.PromotionTypeNameEn;
				_promotionTypeDesc = daoPromotionType.PromotionTypeDesc;
				_promotionInputId = daoPromotionType.PromotionInputId;
				_promotionOutputId = daoPromotionType.PromotionOutputId;
				_isActive = daoPromotionType.IsActive;
				_canEdit = daoPromotionType.CanEdit;
				_canDelete = daoPromotionType.CanDelete;
				_displayOrder = daoPromotionType.DisplayOrder;
				_cBy = daoPromotionType.CBy;
				_cDate = daoPromotionType.CDate;
				_eBy = daoPromotionType.EBy;
				_eDate = daoPromotionType.EDate;
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
		///DAOPromotionType
		///</parameters>
		protected internal BOPromotionType(DAOPromotionType daoPromotionType)
		{
			try
			{
				_promotionTypeId = daoPromotionType.PromotionTypeId;
				_promotionTypeCode = daoPromotionType.PromotionTypeCode;
				_promotionTypeNameAr = daoPromotionType.PromotionTypeNameAr;
				_promotionTypeNameEn = daoPromotionType.PromotionTypeNameEn;
				_promotionTypeDesc = daoPromotionType.PromotionTypeDesc;
				_promotionInputId = daoPromotionType.PromotionInputId;
				_promotionOutputId = daoPromotionType.PromotionOutputId;
				_isActive = daoPromotionType.IsActive;
				_canEdit = daoPromotionType.CanEdit;
				_canDelete = daoPromotionType.CanDelete;
				_displayOrder = daoPromotionType.DisplayOrder;
				_cBy = daoPromotionType.CBy;
				_cDate = daoPromotionType.CDate;
				_eBy = daoPromotionType.EBy;
				_eDate = daoPromotionType.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new PromotionType record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOPromotionType daoPromotionType = new DAOPromotionType();
			RegisterDataObject(daoPromotionType);
			BeginTransaction("savenewBOPromotionType");
			try
			{
				daoPromotionType.PromotionTypeCode = _promotionTypeCode;
				daoPromotionType.PromotionTypeNameAr = _promotionTypeNameAr;
				daoPromotionType.PromotionTypeNameEn = _promotionTypeNameEn;
				daoPromotionType.PromotionTypeDesc = _promotionTypeDesc;
				daoPromotionType.PromotionInputId = _promotionInputId;
				daoPromotionType.PromotionOutputId = _promotionOutputId;
				daoPromotionType.IsActive = _isActive;
				daoPromotionType.CanEdit = _canEdit;
				daoPromotionType.CanDelete = _canDelete;
				daoPromotionType.DisplayOrder = _displayOrder;
				daoPromotionType.CBy = _cBy;
				daoPromotionType.CDate = _cDate;
				daoPromotionType.EBy = _eBy;
				daoPromotionType.EDate = _eDate;
				daoPromotionType.Insert();
				CommitTransaction();
				
				_promotionTypeId = daoPromotionType.PromotionTypeId;
				_promotionTypeCode = daoPromotionType.PromotionTypeCode;
				_promotionTypeNameAr = daoPromotionType.PromotionTypeNameAr;
				_promotionTypeNameEn = daoPromotionType.PromotionTypeNameEn;
				_promotionTypeDesc = daoPromotionType.PromotionTypeDesc;
				_promotionInputId = daoPromotionType.PromotionInputId;
				_promotionOutputId = daoPromotionType.PromotionOutputId;
				_isActive = daoPromotionType.IsActive;
				_canEdit = daoPromotionType.CanEdit;
				_canDelete = daoPromotionType.CanDelete;
				_displayOrder = daoPromotionType.DisplayOrder;
				_cBy = daoPromotionType.CBy;
				_cDate = daoPromotionType.CDate;
				_eBy = daoPromotionType.EBy;
				_eDate = daoPromotionType.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOPromotionType");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one PromotionType record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOPromotionType
		///</parameters>
		public virtual void Update()
		{
			DAOPromotionType daoPromotionType = new DAOPromotionType();
			RegisterDataObject(daoPromotionType);
			BeginTransaction("updateBOPromotionType");
			try
			{
				daoPromotionType.PromotionTypeId = _promotionTypeId;
				daoPromotionType.PromotionTypeCode = _promotionTypeCode;
				daoPromotionType.PromotionTypeNameAr = _promotionTypeNameAr;
				daoPromotionType.PromotionTypeNameEn = _promotionTypeNameEn;
				daoPromotionType.PromotionTypeDesc = _promotionTypeDesc;
				daoPromotionType.PromotionInputId = _promotionInputId;
				daoPromotionType.PromotionOutputId = _promotionOutputId;
				daoPromotionType.IsActive = _isActive;
				daoPromotionType.CanEdit = _canEdit;
				daoPromotionType.CanDelete = _canDelete;
				daoPromotionType.DisplayOrder = _displayOrder;
				daoPromotionType.CBy = _cBy;
				daoPromotionType.CDate = _cDate;
				daoPromotionType.EBy = _eBy;
				daoPromotionType.EDate = _eDate;
				daoPromotionType.Update();
				CommitTransaction();
				
				_promotionTypeId = daoPromotionType.PromotionTypeId;
				_promotionTypeCode = daoPromotionType.PromotionTypeCode;
				_promotionTypeNameAr = daoPromotionType.PromotionTypeNameAr;
				_promotionTypeNameEn = daoPromotionType.PromotionTypeNameEn;
				_promotionTypeDesc = daoPromotionType.PromotionTypeDesc;
				_promotionInputId = daoPromotionType.PromotionInputId;
				_promotionOutputId = daoPromotionType.PromotionOutputId;
				_isActive = daoPromotionType.IsActive;
				_canEdit = daoPromotionType.CanEdit;
				_canDelete = daoPromotionType.CanDelete;
				_displayOrder = daoPromotionType.DisplayOrder;
				_cBy = daoPromotionType.CBy;
				_cDate = daoPromotionType.CDate;
				_eBy = daoPromotionType.EBy;
				_eDate = daoPromotionType.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOPromotionType");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one PromotionType record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOPromotionType daoPromotionType = new DAOPromotionType();
			RegisterDataObject(daoPromotionType);
			BeginTransaction("deleteBOPromotionType");
			try
			{
				daoPromotionType.PromotionTypeId = _promotionTypeId;
				daoPromotionType.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOPromotionType");
				throw;
			}
		}
		
		///<Summary>
		///PromotionTypeCollection
		///This method returns the collection of BOPromotionType objects
		///</Summary>
		///<returns>
		///List[BOPromotionType]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOPromotionType> PromotionTypeCollection()
		{
			try
			{
				IList<BOPromotionType> boPromotionTypeCollection = new List<BOPromotionType>();
				IList<DAOPromotionType> daoPromotionTypeCollection = DAOPromotionType.SelectAll();
			
				foreach(DAOPromotionType daoPromotionType in daoPromotionTypeCollection)
					boPromotionTypeCollection.Add(new BOPromotionType(daoPromotionType));
			
				return boPromotionTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromotionTypeCollectionCount
		///This method returns the collection count of BOPromotionType objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 PromotionTypeCollectionCount()
		{
			try
			{
				Int32 objCount = DAOPromotionType.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///PromotionCollection
		///This method returns its collection of BOPromotion objects
		///</Summary>
		///<returns>
		///IList[BOPromotion]
		///</returns>
		///<parameters>
		///BOPromotionType
		///</parameters>
		public virtual IList<BOPromotion> PromotionCollection()
		{
			try
			{
				if(_boPromotionCollection == null)
					LoadPromotionCollection();
				
				return _boPromotionCollection.AsReadOnly();
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
		///List<BOPromotionType>
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
				IDictionary<string, IList<object>> retObj = DAOPromotionType.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromotionTypeCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOPromotionType objects, filtered by optional criteria
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
				IList<T> boPromotionTypeCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOPromotionType> daoPromotionTypeCollection = DAOPromotionType.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOPromotionType resdaoPromotionType in daoPromotionTypeCollection)
					boPromotionTypeCollection.Add((T)(object)new BOPromotionType(resdaoPromotionType));
			
				return boPromotionTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromotionTypeCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOPromotionType objects, filtered by optional criteria
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
				Int32 objCount = DAOPromotionType.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadPromotionCollection
		///This method loads the internal collection of BOPromotion objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadPromotionCollection()
		{
			try
			{
				_boPromotionCollection = new List<BOPromotion>();
				IList<DAOPromotion> daoPromotionCollection = DAOPromotion.SelectAllByPromotionTypeId(_promotionTypeId.Value);
				
				foreach(DAOPromotion daoPromotion in daoPromotionCollection)
					_boPromotionCollection.Add(new BOPromotion(daoPromotion));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddPromotion
		///This method persists a BOPromotion object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOPromotion
		///</parameters>
		public virtual void AddPromotion(BOPromotion boPromotion)
		{
			DAOPromotion daoPromotion = new DAOPromotion();
			RegisterDataObject(daoPromotion);
			BeginTransaction("addPromotion");
			try
			{
				daoPromotion.PromotionId = boPromotion.PromotionId;
				daoPromotion.PromotionCode = boPromotion.PromotionCode;
				daoPromotion.VendorCode = boPromotion.VendorCode;
				daoPromotion.CompanyId = boPromotion.CompanyId;
				daoPromotion.ValidFrom = boPromotion.ValidFrom;
				daoPromotion.ValidTo = boPromotion.ValidTo;
				daoPromotion.IsActive = boPromotion.IsActive;
				daoPromotion.Priority = boPromotion.Priority;
				daoPromotion.Repeats = boPromotion.Repeats;
				daoPromotion.Icon = boPromotion.Icon;
				daoPromotion.Color = boPromotion.Color;
				daoPromotion.PromotionDesc = boPromotion.PromotionDesc;
				daoPromotion.PromotionGroupId = boPromotion.PromotionGroupId;
				daoPromotion.DisplayOrder = boPromotion.DisplayOrder;
				daoPromotion.EnableNotification = boPromotion.EnableNotification;
				daoPromotion.NotificationDate = boPromotion.NotificationDate;
				daoPromotion.NotificationDone = boPromotion.NotificationDone;
				daoPromotion.CBy = boPromotion.CBy;
				daoPromotion.CDate = boPromotion.CDate;
				daoPromotion.EBy = boPromotion.EBy;
				daoPromotion.EDate = boPromotion.EDate;
				daoPromotion.IsApproved = boPromotion.IsApproved;
				daoPromotion.PromotionCategoryId = boPromotion.PromotionCategoryId;
				daoPromotion.RepeatTypeId = boPromotion.RepeatTypeId;
				daoPromotion.PromotionTypeId = _promotionTypeId.Value;
				daoPromotion.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boPromotion = new BOPromotion(daoPromotion);
				if(_boPromotionCollection != null)
					_boPromotionCollection.Add(boPromotion);
			}
			catch
			{
				RollbackTransaction("addPromotion");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllPromotion
		///This method deletes all BOPromotion objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllPromotion()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllPromotion");
			try
			{
				DAOPromotion.DeleteAllByPromotionTypeId(ConnectionProvider, _promotionTypeId.Value);
				CommitTransaction();
				if(_boPromotionCollection != null)
				{
					_boPromotionCollection.Clear();
					_boPromotionCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllPromotion");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? PromotionTypeId
		{
			get
			{
				 return _promotionTypeId;
			}
			set
			{
				_promotionTypeId = value;
				_isDirty = true;
			}
		}
		
		public virtual string PromotionTypeCode
		{
			get
			{
				 return _promotionTypeCode;
			}
			set
			{
				_promotionTypeCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string PromotionTypeNameAr
		{
			get
			{
				 return _promotionTypeNameAr;
			}
			set
			{
				_promotionTypeNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string PromotionTypeNameEn
		{
			get
			{
				 return _promotionTypeNameEn;
			}
			set
			{
				_promotionTypeNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string PromotionTypeDesc
		{
			get
			{
				 return _promotionTypeDesc;
			}
			set
			{
				_promotionTypeDesc = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? PromotionInputId
		{
			get
			{
				 return _promotionInputId;
			}
			set
			{
				_promotionInputId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? PromotionOutputId
		{
			get
			{
				 return _promotionOutputId;
			}
			set
			{
				_promotionOutputId = value;
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
