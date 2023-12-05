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
	///This is the definition of the class BOCompany.
	///It maintains a collection of BOPromotion objects.
	///</Summary>
	public partial class BOCompany : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _companyId;
		protected string _companyCode;
		protected string _companyNameEn;
		protected string _companyNameAr;
		protected string _companyDesc;
		protected bool? _isActive;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected string _icon;
		protected string _color;
		protected Int32? _displayOrder;
		protected Int32? _prefexClient;
		protected Int32? _prefexItem;
		protected bool? _taxPromotion;
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
		public BOCompany()
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
		///Int32 companyId
		///</parameters>
		public BOCompany(Int32 companyId)
		{
			try
			{
				DAOCompany daoCompany = DAOCompany.SelectOne(companyId);
				_companyId = daoCompany.CompanyId;
				_companyCode = daoCompany.CompanyCode;
				_companyNameEn = daoCompany.CompanyNameEn;
				_companyNameAr = daoCompany.CompanyNameAr;
				_companyDesc = daoCompany.CompanyDesc;
				_isActive = daoCompany.IsActive;
				_canEdit = daoCompany.CanEdit;
				_canDelete = daoCompany.CanDelete;
				_icon = daoCompany.Icon;
				_color = daoCompany.Color;
				_displayOrder = daoCompany.DisplayOrder;
				_prefexClient = daoCompany.PrefexClient;
				_prefexItem = daoCompany.PrefexItem;
				_taxPromotion = daoCompany.TaxPromotion;
				_cBy = daoCompany.CBy;
				_cDate = daoCompany.CDate;
				_eBy = daoCompany.EBy;
				_eDate = daoCompany.EDate;
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
		///DAOCompany
		///</parameters>
		protected internal BOCompany(DAOCompany daoCompany)
		{
			try
			{
				_companyId = daoCompany.CompanyId;
				_companyCode = daoCompany.CompanyCode;
				_companyNameEn = daoCompany.CompanyNameEn;
				_companyNameAr = daoCompany.CompanyNameAr;
				_companyDesc = daoCompany.CompanyDesc;
				_isActive = daoCompany.IsActive;
				_canEdit = daoCompany.CanEdit;
				_canDelete = daoCompany.CanDelete;
				_icon = daoCompany.Icon;
				_color = daoCompany.Color;
				_displayOrder = daoCompany.DisplayOrder;
				_prefexClient = daoCompany.PrefexClient;
				_prefexItem = daoCompany.PrefexItem;
				_taxPromotion = daoCompany.TaxPromotion;
				_cBy = daoCompany.CBy;
				_cDate = daoCompany.CDate;
				_eBy = daoCompany.EBy;
				_eDate = daoCompany.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new Company record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOCompany daoCompany = new DAOCompany();
			RegisterDataObject(daoCompany);
			BeginTransaction("savenewBOCompany");
			try
			{
				daoCompany.CompanyCode = _companyCode;
				daoCompany.CompanyNameEn = _companyNameEn;
				daoCompany.CompanyNameAr = _companyNameAr;
				daoCompany.CompanyDesc = _companyDesc;
				daoCompany.IsActive = _isActive;
				daoCompany.CanEdit = _canEdit;
				daoCompany.CanDelete = _canDelete;
				daoCompany.Icon = _icon;
				daoCompany.Color = _color;
				daoCompany.DisplayOrder = _displayOrder;
				daoCompany.PrefexClient = _prefexClient;
				daoCompany.PrefexItem = _prefexItem;
				daoCompany.TaxPromotion = _taxPromotion;
				daoCompany.CBy = _cBy;
				daoCompany.CDate = _cDate;
				daoCompany.EBy = _eBy;
				daoCompany.EDate = _eDate;
				daoCompany.Insert();
				CommitTransaction();
				
				_companyId = daoCompany.CompanyId;
				_companyCode = daoCompany.CompanyCode;
				_companyNameEn = daoCompany.CompanyNameEn;
				_companyNameAr = daoCompany.CompanyNameAr;
				_companyDesc = daoCompany.CompanyDesc;
				_isActive = daoCompany.IsActive;
				_canEdit = daoCompany.CanEdit;
				_canDelete = daoCompany.CanDelete;
				_icon = daoCompany.Icon;
				_color = daoCompany.Color;
				_displayOrder = daoCompany.DisplayOrder;
				_prefexClient = daoCompany.PrefexClient;
				_prefexItem = daoCompany.PrefexItem;
				_taxPromotion = daoCompany.TaxPromotion;
				_cBy = daoCompany.CBy;
				_cDate = daoCompany.CDate;
				_eBy = daoCompany.EBy;
				_eDate = daoCompany.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOCompany");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one Company record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOCompany
		///</parameters>
		public virtual void Update()
		{
			DAOCompany daoCompany = new DAOCompany();
			RegisterDataObject(daoCompany);
			BeginTransaction("updateBOCompany");
			try
			{
				daoCompany.CompanyId = _companyId;
				daoCompany.CompanyCode = _companyCode;
				daoCompany.CompanyNameEn = _companyNameEn;
				daoCompany.CompanyNameAr = _companyNameAr;
				daoCompany.CompanyDesc = _companyDesc;
				daoCompany.IsActive = _isActive;
				daoCompany.CanEdit = _canEdit;
				daoCompany.CanDelete = _canDelete;
				daoCompany.Icon = _icon;
				daoCompany.Color = _color;
				daoCompany.DisplayOrder = _displayOrder;
				daoCompany.PrefexClient = _prefexClient;
				daoCompany.PrefexItem = _prefexItem;
				daoCompany.TaxPromotion = _taxPromotion;
				daoCompany.CBy = _cBy;
				daoCompany.CDate = _cDate;
				daoCompany.EBy = _eBy;
				daoCompany.EDate = _eDate;
				daoCompany.Update();
				CommitTransaction();
				
				_companyId = daoCompany.CompanyId;
				_companyCode = daoCompany.CompanyCode;
				_companyNameEn = daoCompany.CompanyNameEn;
				_companyNameAr = daoCompany.CompanyNameAr;
				_companyDesc = daoCompany.CompanyDesc;
				_isActive = daoCompany.IsActive;
				_canEdit = daoCompany.CanEdit;
				_canDelete = daoCompany.CanDelete;
				_icon = daoCompany.Icon;
				_color = daoCompany.Color;
				_displayOrder = daoCompany.DisplayOrder;
				_prefexClient = daoCompany.PrefexClient;
				_prefexItem = daoCompany.PrefexItem;
				_taxPromotion = daoCompany.TaxPromotion;
				_cBy = daoCompany.CBy;
				_cDate = daoCompany.CDate;
				_eBy = daoCompany.EBy;
				_eDate = daoCompany.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOCompany");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one Company record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOCompany daoCompany = new DAOCompany();
			RegisterDataObject(daoCompany);
			BeginTransaction("deleteBOCompany");
			try
			{
				daoCompany.CompanyId = _companyId;
				daoCompany.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOCompany");
				throw;
			}
		}
		
		///<Summary>
		///CompanyCollection
		///This method returns the collection of BOCompany objects
		///</Summary>
		///<returns>
		///List[BOCompany]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOCompany> CompanyCollection()
		{
			try
			{
				IList<BOCompany> boCompanyCollection = new List<BOCompany>();
				IList<DAOCompany> daoCompanyCollection = DAOCompany.SelectAll();
			
				foreach(DAOCompany daoCompany in daoCompanyCollection)
					boCompanyCollection.Add(new BOCompany(daoCompany));
			
				return boCompanyCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///CompanyCollectionCount
		///This method returns the collection count of BOCompany objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 CompanyCollectionCount()
		{
			try
			{
				Int32 objCount = DAOCompany.SelectAllCount();
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
		///BOCompany
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
		///List<BOCompany>
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
				IDictionary<string, IList<object>> retObj = DAOCompany.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///CompanyCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOCompany objects, filtered by optional criteria
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
				IList<T> boCompanyCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOCompany> daoCompanyCollection = DAOCompany.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOCompany resdaoCompany in daoCompanyCollection)
					boCompanyCollection.Add((T)(object)new BOCompany(resdaoCompany));
			
				return boCompanyCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///CompanyCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOCompany objects, filtered by optional criteria
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
				Int32 objCount = DAOCompany.SelectAllByCriteriaCount(lstDataCriteria);
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
				IList<DAOPromotion> daoPromotionCollection = DAOPromotion.SelectAllByCompanyId(_companyId.Value);
				
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
				daoPromotion.ValidFrom = boPromotion.ValidFrom;
				daoPromotion.ValidTo = boPromotion.ValidTo;
				daoPromotion.IsActive = boPromotion.IsActive;
				daoPromotion.PromotionTypeId = boPromotion.PromotionTypeId;
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
				daoPromotion.CompanyId = _companyId.Value;
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
				DAOPromotion.DeleteAllByCompanyId(ConnectionProvider, _companyId.Value);
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
		
		public virtual Int32? CompanyId
		{
			get
			{
				 return _companyId;
			}
			set
			{
				_companyId = value;
				_isDirty = true;
			}
		}
		
		public virtual string CompanyCode
		{
			get
			{
				 return _companyCode;
			}
			set
			{
				_companyCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string CompanyNameEn
		{
			get
			{
				 return _companyNameEn;
			}
			set
			{
				_companyNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string CompanyNameAr
		{
			get
			{
				 return _companyNameAr;
			}
			set
			{
				_companyNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string CompanyDesc
		{
			get
			{
				 return _companyDesc;
			}
			set
			{
				_companyDesc = value;
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
		
		public virtual Int32? PrefexClient
		{
			get
			{
				 return _prefexClient;
			}
			set
			{
				_prefexClient = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? PrefexItem
		{
			get
			{
				 return _prefexItem;
			}
			set
			{
				_prefexItem = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? TaxPromotion
		{
			get
			{
				 return _taxPromotion;
			}
			set
			{
				_taxPromotion = value;
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