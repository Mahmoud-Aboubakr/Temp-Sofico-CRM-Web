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
	///This is the definition of the class BORouteType.
	///It maintains a collection of BOClientRoute,BORouteSetup objects.
	///</Summary>
	public partial class BORouteType : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _routeTypeId;
		protected string _routeTypeCode;
		protected string _routeTypeNameEn;
		protected string _routeTypeNameAr;
		protected bool? _isPhysical;
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
		List<BOClientRoute> _boClientRouteCollection;
		List<BORouteSetup> _boRouteSetupCollection;
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
		public BORouteType()
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
		///Int32 routeTypeId
		///</parameters>
		public BORouteType(Int32 routeTypeId)
		{
			try
			{
				DAORouteType daoRouteType = DAORouteType.SelectOne(routeTypeId);
				_routeTypeId = daoRouteType.RouteTypeId;
				_routeTypeCode = daoRouteType.RouteTypeCode;
				_routeTypeNameEn = daoRouteType.RouteTypeNameEn;
				_routeTypeNameAr = daoRouteType.RouteTypeNameAr;
				_isPhysical = daoRouteType.IsPhysical;
				_isActive = daoRouteType.IsActive;
				_canEdit = daoRouteType.CanEdit;
				_canDelete = daoRouteType.CanDelete;
				_displayOrder = daoRouteType.DisplayOrder;
				_cBy = daoRouteType.CBy;
				_cDate = daoRouteType.CDate;
				_eBy = daoRouteType.EBy;
				_eDate = daoRouteType.EDate;
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
		///DAORouteType
		///</parameters>
		protected internal BORouteType(DAORouteType daoRouteType)
		{
			try
			{
				_routeTypeId = daoRouteType.RouteTypeId;
				_routeTypeCode = daoRouteType.RouteTypeCode;
				_routeTypeNameEn = daoRouteType.RouteTypeNameEn;
				_routeTypeNameAr = daoRouteType.RouteTypeNameAr;
				_isPhysical = daoRouteType.IsPhysical;
				_isActive = daoRouteType.IsActive;
				_canEdit = daoRouteType.CanEdit;
				_canDelete = daoRouteType.CanDelete;
				_displayOrder = daoRouteType.DisplayOrder;
				_cBy = daoRouteType.CBy;
				_cDate = daoRouteType.CDate;
				_eBy = daoRouteType.EBy;
				_eDate = daoRouteType.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new RouteType record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAORouteType daoRouteType = new DAORouteType();
			RegisterDataObject(daoRouteType);
			BeginTransaction("savenewBORouteType");
			try
			{
				daoRouteType.RouteTypeId = _routeTypeId;
				daoRouteType.RouteTypeCode = _routeTypeCode;
				daoRouteType.RouteTypeNameEn = _routeTypeNameEn;
				daoRouteType.RouteTypeNameAr = _routeTypeNameAr;
				daoRouteType.IsPhysical = _isPhysical;
				daoRouteType.IsActive = _isActive;
				daoRouteType.CanEdit = _canEdit;
				daoRouteType.CanDelete = _canDelete;
				daoRouteType.DisplayOrder = _displayOrder;
				daoRouteType.CBy = _cBy;
				daoRouteType.CDate = _cDate;
				daoRouteType.EBy = _eBy;
				daoRouteType.EDate = _eDate;
				daoRouteType.Insert();
				CommitTransaction();
				
				_routeTypeId = daoRouteType.RouteTypeId;
				_routeTypeCode = daoRouteType.RouteTypeCode;
				_routeTypeNameEn = daoRouteType.RouteTypeNameEn;
				_routeTypeNameAr = daoRouteType.RouteTypeNameAr;
				_isPhysical = daoRouteType.IsPhysical;
				_isActive = daoRouteType.IsActive;
				_canEdit = daoRouteType.CanEdit;
				_canDelete = daoRouteType.CanDelete;
				_displayOrder = daoRouteType.DisplayOrder;
				_cBy = daoRouteType.CBy;
				_cDate = daoRouteType.CDate;
				_eBy = daoRouteType.EBy;
				_eDate = daoRouteType.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBORouteType");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one RouteType record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BORouteType
		///</parameters>
		public virtual void Update()
		{
			DAORouteType daoRouteType = new DAORouteType();
			RegisterDataObject(daoRouteType);
			BeginTransaction("updateBORouteType");
			try
			{
				daoRouteType.RouteTypeId = _routeTypeId;
				daoRouteType.RouteTypeCode = _routeTypeCode;
				daoRouteType.RouteTypeNameEn = _routeTypeNameEn;
				daoRouteType.RouteTypeNameAr = _routeTypeNameAr;
				daoRouteType.IsPhysical = _isPhysical;
				daoRouteType.IsActive = _isActive;
				daoRouteType.CanEdit = _canEdit;
				daoRouteType.CanDelete = _canDelete;
				daoRouteType.DisplayOrder = _displayOrder;
				daoRouteType.CBy = _cBy;
				daoRouteType.CDate = _cDate;
				daoRouteType.EBy = _eBy;
				daoRouteType.EDate = _eDate;
				daoRouteType.Update();
				CommitTransaction();
				
				_routeTypeId = daoRouteType.RouteTypeId;
				_routeTypeCode = daoRouteType.RouteTypeCode;
				_routeTypeNameEn = daoRouteType.RouteTypeNameEn;
				_routeTypeNameAr = daoRouteType.RouteTypeNameAr;
				_isPhysical = daoRouteType.IsPhysical;
				_isActive = daoRouteType.IsActive;
				_canEdit = daoRouteType.CanEdit;
				_canDelete = daoRouteType.CanDelete;
				_displayOrder = daoRouteType.DisplayOrder;
				_cBy = daoRouteType.CBy;
				_cDate = daoRouteType.CDate;
				_eBy = daoRouteType.EBy;
				_eDate = daoRouteType.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBORouteType");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one RouteType record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAORouteType daoRouteType = new DAORouteType();
			RegisterDataObject(daoRouteType);
			BeginTransaction("deleteBORouteType");
			try
			{
				daoRouteType.RouteTypeId = _routeTypeId;
				daoRouteType.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBORouteType");
				throw;
			}
		}
		
		///<Summary>
		///RouteTypeCollection
		///This method returns the collection of BORouteType objects
		///</Summary>
		///<returns>
		///List[BORouteType]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BORouteType> RouteTypeCollection()
		{
			try
			{
				IList<BORouteType> boRouteTypeCollection = new List<BORouteType>();
				IList<DAORouteType> daoRouteTypeCollection = DAORouteType.SelectAll();
			
				foreach(DAORouteType daoRouteType in daoRouteTypeCollection)
					boRouteTypeCollection.Add(new BORouteType(daoRouteType));
			
				return boRouteTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RouteTypeCollectionCount
		///This method returns the collection count of BORouteType objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 RouteTypeCollectionCount()
		{
			try
			{
				Int32 objCount = DAORouteType.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///ClientRouteCollection
		///This method returns its collection of BOClientRoute objects
		///</Summary>
		///<returns>
		///IList[BOClientRoute]
		///</returns>
		///<parameters>
		///BORouteType
		///</parameters>
		public virtual IList<BOClientRoute> ClientRouteCollection()
		{
			try
			{
				if(_boClientRouteCollection == null)
					LoadClientRouteCollection();
				
				return _boClientRouteCollection.AsReadOnly();
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///RouteSetupCollection
		///This method returns its collection of BORouteSetup objects
		///</Summary>
		///<returns>
		///IList[BORouteSetup]
		///</returns>
		///<parameters>
		///BORouteType
		///</parameters>
		public virtual IList<BORouteSetup> RouteSetupCollection()
		{
			try
			{
				if(_boRouteSetupCollection == null)
					LoadRouteSetupCollection();
				
				return _boRouteSetupCollection.AsReadOnly();
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
		///List<BORouteType>
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
				IDictionary<string, IList<object>> retObj = DAORouteType.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RouteTypeCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BORouteType objects, filtered by optional criteria
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
				IList<T> boRouteTypeCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAORouteType> daoRouteTypeCollection = DAORouteType.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAORouteType resdaoRouteType in daoRouteTypeCollection)
					boRouteTypeCollection.Add((T)(object)new BORouteType(resdaoRouteType));
			
				return boRouteTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RouteTypeCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BORouteType objects, filtered by optional criteria
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
				Int32 objCount = DAORouteType.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadClientRouteCollection
		///This method loads the internal collection of BOClientRoute objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadClientRouteCollection()
		{
			try
			{
				_boClientRouteCollection = new List<BOClientRoute>();
				IList<DAOClientRoute> daoClientRouteCollection = DAOClientRoute.SelectAllByRouteTypeId(_routeTypeId.Value);
				
				foreach(DAOClientRoute daoClientRoute in daoClientRouteCollection)
					_boClientRouteCollection.Add(new BOClientRoute(daoClientRoute));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddClientRoute
		///This method persists a BOClientRoute object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOClientRoute
		///</parameters>
		public virtual void AddClientRoute(BOClientRoute boClientRoute)
		{
			DAOClientRoute daoClientRoute = new DAOClientRoute();
			RegisterDataObject(daoClientRoute);
			BeginTransaction("addClientRoute");
			try
			{
				daoClientRoute.ClientRouteId = boClientRoute.ClientRouteId;
				daoClientRoute.RouteId = boClientRoute.RouteId;
				daoClientRoute.ClientId = boClientRoute.ClientId;
				daoClientRoute.Day1 = boClientRoute.Day1;
				daoClientRoute.Day2 = boClientRoute.Day2;
				daoClientRoute.Day3 = boClientRoute.Day3;
				daoClientRoute.Day4 = boClientRoute.Day4;
				daoClientRoute.Day5 = boClientRoute.Day5;
				daoClientRoute.Day6 = boClientRoute.Day6;
				daoClientRoute.Day7 = boClientRoute.Day7;
				daoClientRoute.CBy = boClientRoute.CBy;
				daoClientRoute.CDate = boClientRoute.CDate;
				daoClientRoute.EBy = boClientRoute.EBy;
				daoClientRoute.EDate = boClientRoute.EDate;
				daoClientRoute.RouteTypeId = _routeTypeId.Value;
				daoClientRoute.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boClientRoute = new BOClientRoute(daoClientRoute);
				if(_boClientRouteCollection != null)
					_boClientRouteCollection.Add(boClientRoute);
			}
			catch
			{
				RollbackTransaction("addClientRoute");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllClientRoute
		///This method deletes all BOClientRoute objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllClientRoute()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllClientRoute");
			try
			{
				DAOClientRoute.DeleteAllByRouteTypeId(ConnectionProvider, _routeTypeId.Value);
				CommitTransaction();
				if(_boClientRouteCollection != null)
				{
					_boClientRouteCollection.Clear();
					_boClientRouteCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllClientRoute");
				throw;
			}
		}
		
		///<Summary>
		///LoadRouteSetupCollection
		///This method loads the internal collection of BORouteSetup objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadRouteSetupCollection()
		{
			try
			{
				_boRouteSetupCollection = new List<BORouteSetup>();
				IList<DAORouteSetup> daoRouteSetupCollection = DAORouteSetup.SelectAllByRouteTypeId(_routeTypeId.Value);
				
				foreach(DAORouteSetup daoRouteSetup in daoRouteSetupCollection)
					_boRouteSetupCollection.Add(new BORouteSetup(daoRouteSetup));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddRouteSetup
		///This method persists a BORouteSetup object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BORouteSetup
		///</parameters>
		public virtual void AddRouteSetup(BORouteSetup boRouteSetup)
		{
			DAORouteSetup daoRouteSetup = new DAORouteSetup();
			RegisterDataObject(daoRouteSetup);
			BeginTransaction("addRouteSetup");
			try
			{
				daoRouteSetup.RouteId = boRouteSetup.RouteId;
				daoRouteSetup.BranchId = boRouteSetup.BranchId;
				daoRouteSetup.RouteCode = boRouteSetup.RouteCode;
				daoRouteSetup.RouteNameEn = boRouteSetup.RouteNameEn;
				daoRouteSetup.RouteNameAr = boRouteSetup.RouteNameAr;
				daoRouteSetup.IsActive = boRouteSetup.IsActive;
				daoRouteSetup.Color = boRouteSetup.Color;
				daoRouteSetup.Icon = boRouteSetup.Icon;
				daoRouteSetup.CanEdit = boRouteSetup.CanEdit;
				daoRouteSetup.CanDelete = boRouteSetup.CanDelete;
				daoRouteSetup.Notes = boRouteSetup.Notes;
				daoRouteSetup.CBy = boRouteSetup.CBy;
				daoRouteSetup.CDate = boRouteSetup.CDate;
				daoRouteSetup.EBy = boRouteSetup.EBy;
				daoRouteSetup.EDate = boRouteSetup.EDate;
				daoRouteSetup.RouteTypeId = _routeTypeId.Value;
				daoRouteSetup.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boRouteSetup = new BORouteSetup(daoRouteSetup);
				if(_boRouteSetupCollection != null)
					_boRouteSetupCollection.Add(boRouteSetup);
			}
			catch
			{
				RollbackTransaction("addRouteSetup");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllRouteSetup
		///This method deletes all BORouteSetup objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllRouteSetup()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllRouteSetup");
			try
			{
				DAORouteSetup.DeleteAllByRouteTypeId(ConnectionProvider, _routeTypeId.Value);
				CommitTransaction();
				if(_boRouteSetupCollection != null)
				{
					_boRouteSetupCollection.Clear();
					_boRouteSetupCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllRouteSetup");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? RouteTypeId
		{
			get
			{
				 return _routeTypeId;
			}
			set
			{
				_routeTypeId = value;
				_isDirty = true;
			}
		}
		
		public virtual string RouteTypeCode
		{
			get
			{
				 return _routeTypeCode;
			}
			set
			{
				_routeTypeCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string RouteTypeNameEn
		{
			get
			{
				 return _routeTypeNameEn;
			}
			set
			{
				_routeTypeNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string RouteTypeNameAr
		{
			get
			{
				 return _routeTypeNameAr;
			}
			set
			{
				_routeTypeNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? IsPhysical
		{
			get
			{
				 return _isPhysical;
			}
			set
			{
				_isPhysical = value;
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