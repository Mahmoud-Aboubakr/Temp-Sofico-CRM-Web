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
	///This is the definition of the class BOServiceWorker.
	///It maintains a collection of BOBranchInvoiceingSetup objects.
	///</Summary>
	public partial class BOServiceWorker : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _serviceWorkerId;
		protected string _serviceWorkerCode;
		protected string _serviceWorkerNameEn;
		protected string _serviceWorkerNameAr;
		protected bool? _isActive;
		protected Int32? _displayOrder;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOBranchInvoiceingSetup> _boBranchInvoiceingSetupCollection;
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
		public BOServiceWorker()
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
		///Int32 serviceWorkerId
		///</parameters>
		public BOServiceWorker(Int32 serviceWorkerId)
		{
			try
			{
				DAOServiceWorker daoServiceWorker = DAOServiceWorker.SelectOne(serviceWorkerId);
				_serviceWorkerId = daoServiceWorker.ServiceWorkerId;
				_serviceWorkerCode = daoServiceWorker.ServiceWorkerCode;
				_serviceWorkerNameEn = daoServiceWorker.ServiceWorkerNameEn;
				_serviceWorkerNameAr = daoServiceWorker.ServiceWorkerNameAr;
				_isActive = daoServiceWorker.IsActive;
				_displayOrder = daoServiceWorker.DisplayOrder;
				_canEdit = daoServiceWorker.CanEdit;
				_canDelete = daoServiceWorker.CanDelete;
				_cBy = daoServiceWorker.CBy;
				_cDate = daoServiceWorker.CDate;
				_eBy = daoServiceWorker.EBy;
				_eDate = daoServiceWorker.EDate;
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
		///DAOServiceWorker
		///</parameters>
		protected internal BOServiceWorker(DAOServiceWorker daoServiceWorker)
		{
			try
			{
				_serviceWorkerId = daoServiceWorker.ServiceWorkerId;
				_serviceWorkerCode = daoServiceWorker.ServiceWorkerCode;
				_serviceWorkerNameEn = daoServiceWorker.ServiceWorkerNameEn;
				_serviceWorkerNameAr = daoServiceWorker.ServiceWorkerNameAr;
				_isActive = daoServiceWorker.IsActive;
				_displayOrder = daoServiceWorker.DisplayOrder;
				_canEdit = daoServiceWorker.CanEdit;
				_canDelete = daoServiceWorker.CanDelete;
				_cBy = daoServiceWorker.CBy;
				_cDate = daoServiceWorker.CDate;
				_eBy = daoServiceWorker.EBy;
				_eDate = daoServiceWorker.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new ServiceWorker record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOServiceWorker daoServiceWorker = new DAOServiceWorker();
			RegisterDataObject(daoServiceWorker);
			BeginTransaction("savenewBOServiceWorker");
			try
			{
				daoServiceWorker.ServiceWorkerCode = _serviceWorkerCode;
				daoServiceWorker.ServiceWorkerNameEn = _serviceWorkerNameEn;
				daoServiceWorker.ServiceWorkerNameAr = _serviceWorkerNameAr;
				daoServiceWorker.IsActive = _isActive;
				daoServiceWorker.DisplayOrder = _displayOrder;
				daoServiceWorker.CanEdit = _canEdit;
				daoServiceWorker.CanDelete = _canDelete;
				daoServiceWorker.CBy = _cBy;
				daoServiceWorker.CDate = _cDate;
				daoServiceWorker.EBy = _eBy;
				daoServiceWorker.EDate = _eDate;
				daoServiceWorker.Insert();
				CommitTransaction();
				
				_serviceWorkerId = daoServiceWorker.ServiceWorkerId;
				_serviceWorkerCode = daoServiceWorker.ServiceWorkerCode;
				_serviceWorkerNameEn = daoServiceWorker.ServiceWorkerNameEn;
				_serviceWorkerNameAr = daoServiceWorker.ServiceWorkerNameAr;
				_isActive = daoServiceWorker.IsActive;
				_displayOrder = daoServiceWorker.DisplayOrder;
				_canEdit = daoServiceWorker.CanEdit;
				_canDelete = daoServiceWorker.CanDelete;
				_cBy = daoServiceWorker.CBy;
				_cDate = daoServiceWorker.CDate;
				_eBy = daoServiceWorker.EBy;
				_eDate = daoServiceWorker.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOServiceWorker");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one ServiceWorker record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOServiceWorker
		///</parameters>
		public virtual void Update()
		{
			DAOServiceWorker daoServiceWorker = new DAOServiceWorker();
			RegisterDataObject(daoServiceWorker);
			BeginTransaction("updateBOServiceWorker");
			try
			{
				daoServiceWorker.ServiceWorkerId = _serviceWorkerId;
				daoServiceWorker.ServiceWorkerCode = _serviceWorkerCode;
				daoServiceWorker.ServiceWorkerNameEn = _serviceWorkerNameEn;
				daoServiceWorker.ServiceWorkerNameAr = _serviceWorkerNameAr;
				daoServiceWorker.IsActive = _isActive;
				daoServiceWorker.DisplayOrder = _displayOrder;
				daoServiceWorker.CanEdit = _canEdit;
				daoServiceWorker.CanDelete = _canDelete;
				daoServiceWorker.CBy = _cBy;
				daoServiceWorker.CDate = _cDate;
				daoServiceWorker.EBy = _eBy;
				daoServiceWorker.EDate = _eDate;
				daoServiceWorker.Update();
				CommitTransaction();
				
				_serviceWorkerId = daoServiceWorker.ServiceWorkerId;
				_serviceWorkerCode = daoServiceWorker.ServiceWorkerCode;
				_serviceWorkerNameEn = daoServiceWorker.ServiceWorkerNameEn;
				_serviceWorkerNameAr = daoServiceWorker.ServiceWorkerNameAr;
				_isActive = daoServiceWorker.IsActive;
				_displayOrder = daoServiceWorker.DisplayOrder;
				_canEdit = daoServiceWorker.CanEdit;
				_canDelete = daoServiceWorker.CanDelete;
				_cBy = daoServiceWorker.CBy;
				_cDate = daoServiceWorker.CDate;
				_eBy = daoServiceWorker.EBy;
				_eDate = daoServiceWorker.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOServiceWorker");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one ServiceWorker record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOServiceWorker daoServiceWorker = new DAOServiceWorker();
			RegisterDataObject(daoServiceWorker);
			BeginTransaction("deleteBOServiceWorker");
			try
			{
				daoServiceWorker.ServiceWorkerId = _serviceWorkerId;
				daoServiceWorker.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOServiceWorker");
				throw;
			}
		}
		
		///<Summary>
		///ServiceWorkerCollection
		///This method returns the collection of BOServiceWorker objects
		///</Summary>
		///<returns>
		///List[BOServiceWorker]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOServiceWorker> ServiceWorkerCollection()
		{
			try
			{
				IList<BOServiceWorker> boServiceWorkerCollection = new List<BOServiceWorker>();
				IList<DAOServiceWorker> daoServiceWorkerCollection = DAOServiceWorker.SelectAll();
			
				foreach(DAOServiceWorker daoServiceWorker in daoServiceWorkerCollection)
					boServiceWorkerCollection.Add(new BOServiceWorker(daoServiceWorker));
			
				return boServiceWorkerCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ServiceWorkerCollectionCount
		///This method returns the collection count of BOServiceWorker objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ServiceWorkerCollectionCount()
		{
			try
			{
				Int32 objCount = DAOServiceWorker.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///BranchInvoiceingSetupCollection
		///This method returns its collection of BOBranchInvoiceingSetup objects
		///</Summary>
		///<returns>
		///IList[BOBranchInvoiceingSetup]
		///</returns>
		///<parameters>
		///BOServiceWorker
		///</parameters>
		public virtual IList<BOBranchInvoiceingSetup> BranchInvoiceingSetupCollection()
		{
			try
			{
				if(_boBranchInvoiceingSetupCollection == null)
					LoadBranchInvoiceingSetupCollection();
				
				return _boBranchInvoiceingSetupCollection.AsReadOnly();
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
		///List<BOServiceWorker>
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
				IDictionary<string, IList<object>> retObj = DAOServiceWorker.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ServiceWorkerCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOServiceWorker objects, filtered by optional criteria
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
				IList<T> boServiceWorkerCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOServiceWorker> daoServiceWorkerCollection = DAOServiceWorker.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOServiceWorker resdaoServiceWorker in daoServiceWorkerCollection)
					boServiceWorkerCollection.Add((T)(object)new BOServiceWorker(resdaoServiceWorker));
			
				return boServiceWorkerCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ServiceWorkerCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOServiceWorker objects, filtered by optional criteria
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
				Int32 objCount = DAOServiceWorker.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadBranchInvoiceingSetupCollection
		///This method loads the internal collection of BOBranchInvoiceingSetup objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadBranchInvoiceingSetupCollection()
		{
			try
			{
				_boBranchInvoiceingSetupCollection = new List<BOBranchInvoiceingSetup>();
				IList<DAOBranchInvoiceingSetup> daoBranchInvoiceingSetupCollection = DAOBranchInvoiceingSetup.SelectAllByServiceWorkerId(_serviceWorkerId.Value);
				
				foreach(DAOBranchInvoiceingSetup daoBranchInvoiceingSetup in daoBranchInvoiceingSetupCollection)
					_boBranchInvoiceingSetupCollection.Add(new BOBranchInvoiceingSetup(daoBranchInvoiceingSetup));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddBranchInvoiceingSetup
		///This method persists a BOBranchInvoiceingSetup object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOBranchInvoiceingSetup
		///</parameters>
		public virtual void AddBranchInvoiceingSetup(BOBranchInvoiceingSetup boBranchInvoiceingSetup)
		{
			DAOBranchInvoiceingSetup daoBranchInvoiceingSetup = new DAOBranchInvoiceingSetup();
			RegisterDataObject(daoBranchInvoiceingSetup);
			BeginTransaction("addBranchInvoiceingSetup");
			try
			{
				daoBranchInvoiceingSetup.SetupId = boBranchInvoiceingSetup.SetupId;
				daoBranchInvoiceingSetup.BranchId = boBranchInvoiceingSetup.BranchId;
				daoBranchInvoiceingSetup.IsEnabled = boBranchInvoiceingSetup.IsEnabled;
				daoBranchInvoiceingSetup.CBy = boBranchInvoiceingSetup.CBy;
				daoBranchInvoiceingSetup.CDate = boBranchInvoiceingSetup.CDate;
				daoBranchInvoiceingSetup.EBy = boBranchInvoiceingSetup.EBy;
				daoBranchInvoiceingSetup.EDate = boBranchInvoiceingSetup.EDate;
				daoBranchInvoiceingSetup.ServiceWorkerId = _serviceWorkerId.Value;
				daoBranchInvoiceingSetup.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boBranchInvoiceingSetup = new BOBranchInvoiceingSetup(daoBranchInvoiceingSetup);
				if(_boBranchInvoiceingSetupCollection != null)
					_boBranchInvoiceingSetupCollection.Add(boBranchInvoiceingSetup);
			}
			catch
			{
				RollbackTransaction("addBranchInvoiceingSetup");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllBranchInvoiceingSetup
		///This method deletes all BOBranchInvoiceingSetup objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllBranchInvoiceingSetup()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllBranchInvoiceingSetup");
			try
			{
				DAOBranchInvoiceingSetup.DeleteAllByServiceWorkerId(ConnectionProvider, _serviceWorkerId.Value);
				CommitTransaction();
				if(_boBranchInvoiceingSetupCollection != null)
				{
					_boBranchInvoiceingSetupCollection.Clear();
					_boBranchInvoiceingSetupCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllBranchInvoiceingSetup");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? ServiceWorkerId
		{
			get
			{
				 return _serviceWorkerId;
			}
			set
			{
				_serviceWorkerId = value;
				_isDirty = true;
			}
		}
		
		public virtual string ServiceWorkerCode
		{
			get
			{
				 return _serviceWorkerCode;
			}
			set
			{
				_serviceWorkerCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string ServiceWorkerNameEn
		{
			get
			{
				 return _serviceWorkerNameEn;
			}
			set
			{
				_serviceWorkerNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string ServiceWorkerNameAr
		{
			get
			{
				 return _serviceWorkerNameAr;
			}
			set
			{
				_serviceWorkerNameAr = value;
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