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
	///This is the definition of the class BORegisterStatus.
	///It maintains a collection of BORegister objects.
	///</Summary>
	public partial class BORegisterStatus : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _registerStatusId;
		protected string _registerStatusCode;
		protected string _registerStatusNameEn;
		protected string _registerStatusNameAr;
		protected string _color;
		protected string _icon;
		protected Int32? _displayOrder;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected bool? _isActive;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BORegister> _boRegisterCollection;
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
		public BORegisterStatus()
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
		///Int32 registerStatusId
		///</parameters>
		public BORegisterStatus(Int32 registerStatusId)
		{
			try
			{
				DAORegisterStatus daoRegisterStatus = DAORegisterStatus.SelectOne(registerStatusId);
				_registerStatusId = daoRegisterStatus.RegisterStatusId;
				_registerStatusCode = daoRegisterStatus.RegisterStatusCode;
				_registerStatusNameEn = daoRegisterStatus.RegisterStatusNameEn;
				_registerStatusNameAr = daoRegisterStatus.RegisterStatusNameAr;
				_color = daoRegisterStatus.Color;
				_icon = daoRegisterStatus.Icon;
				_displayOrder = daoRegisterStatus.DisplayOrder;
				_canEdit = daoRegisterStatus.CanEdit;
				_canDelete = daoRegisterStatus.CanDelete;
				_isActive = daoRegisterStatus.IsActive;
				_cBy = daoRegisterStatus.CBy;
				_cDate = daoRegisterStatus.CDate;
				_eBy = daoRegisterStatus.EBy;
				_eDate = daoRegisterStatus.EDate;
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
		///DAORegisterStatus
		///</parameters>
		protected internal BORegisterStatus(DAORegisterStatus daoRegisterStatus)
		{
			try
			{
				_registerStatusId = daoRegisterStatus.RegisterStatusId;
				_registerStatusCode = daoRegisterStatus.RegisterStatusCode;
				_registerStatusNameEn = daoRegisterStatus.RegisterStatusNameEn;
				_registerStatusNameAr = daoRegisterStatus.RegisterStatusNameAr;
				_color = daoRegisterStatus.Color;
				_icon = daoRegisterStatus.Icon;
				_displayOrder = daoRegisterStatus.DisplayOrder;
				_canEdit = daoRegisterStatus.CanEdit;
				_canDelete = daoRegisterStatus.CanDelete;
				_isActive = daoRegisterStatus.IsActive;
				_cBy = daoRegisterStatus.CBy;
				_cDate = daoRegisterStatus.CDate;
				_eBy = daoRegisterStatus.EBy;
				_eDate = daoRegisterStatus.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new RegisterStatus record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAORegisterStatus daoRegisterStatus = new DAORegisterStatus();
			RegisterDataObject(daoRegisterStatus);
			BeginTransaction("savenewBORegisterStatus");
			try
			{
				daoRegisterStatus.RegisterStatusId = _registerStatusId;
				daoRegisterStatus.RegisterStatusCode = _registerStatusCode;
				daoRegisterStatus.RegisterStatusNameEn = _registerStatusNameEn;
				daoRegisterStatus.RegisterStatusNameAr = _registerStatusNameAr;
				daoRegisterStatus.Color = _color;
				daoRegisterStatus.Icon = _icon;
				daoRegisterStatus.DisplayOrder = _displayOrder;
				daoRegisterStatus.CanEdit = _canEdit;
				daoRegisterStatus.CanDelete = _canDelete;
				daoRegisterStatus.IsActive = _isActive;
				daoRegisterStatus.CBy = _cBy;
				daoRegisterStatus.CDate = _cDate;
				daoRegisterStatus.EBy = _eBy;
				daoRegisterStatus.EDate = _eDate;
				daoRegisterStatus.Insert();
				CommitTransaction();
				
				_registerStatusId = daoRegisterStatus.RegisterStatusId;
				_registerStatusCode = daoRegisterStatus.RegisterStatusCode;
				_registerStatusNameEn = daoRegisterStatus.RegisterStatusNameEn;
				_registerStatusNameAr = daoRegisterStatus.RegisterStatusNameAr;
				_color = daoRegisterStatus.Color;
				_icon = daoRegisterStatus.Icon;
				_displayOrder = daoRegisterStatus.DisplayOrder;
				_canEdit = daoRegisterStatus.CanEdit;
				_canDelete = daoRegisterStatus.CanDelete;
				_isActive = daoRegisterStatus.IsActive;
				_cBy = daoRegisterStatus.CBy;
				_cDate = daoRegisterStatus.CDate;
				_eBy = daoRegisterStatus.EBy;
				_eDate = daoRegisterStatus.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBORegisterStatus");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one RegisterStatus record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BORegisterStatus
		///</parameters>
		public virtual void Update()
		{
			DAORegisterStatus daoRegisterStatus = new DAORegisterStatus();
			RegisterDataObject(daoRegisterStatus);
			BeginTransaction("updateBORegisterStatus");
			try
			{
				daoRegisterStatus.RegisterStatusId = _registerStatusId;
				daoRegisterStatus.RegisterStatusCode = _registerStatusCode;
				daoRegisterStatus.RegisterStatusNameEn = _registerStatusNameEn;
				daoRegisterStatus.RegisterStatusNameAr = _registerStatusNameAr;
				daoRegisterStatus.Color = _color;
				daoRegisterStatus.Icon = _icon;
				daoRegisterStatus.DisplayOrder = _displayOrder;
				daoRegisterStatus.CanEdit = _canEdit;
				daoRegisterStatus.CanDelete = _canDelete;
				daoRegisterStatus.IsActive = _isActive;
				daoRegisterStatus.CBy = _cBy;
				daoRegisterStatus.CDate = _cDate;
				daoRegisterStatus.EBy = _eBy;
				daoRegisterStatus.EDate = _eDate;
				daoRegisterStatus.Update();
				CommitTransaction();
				
				_registerStatusId = daoRegisterStatus.RegisterStatusId;
				_registerStatusCode = daoRegisterStatus.RegisterStatusCode;
				_registerStatusNameEn = daoRegisterStatus.RegisterStatusNameEn;
				_registerStatusNameAr = daoRegisterStatus.RegisterStatusNameAr;
				_color = daoRegisterStatus.Color;
				_icon = daoRegisterStatus.Icon;
				_displayOrder = daoRegisterStatus.DisplayOrder;
				_canEdit = daoRegisterStatus.CanEdit;
				_canDelete = daoRegisterStatus.CanDelete;
				_isActive = daoRegisterStatus.IsActive;
				_cBy = daoRegisterStatus.CBy;
				_cDate = daoRegisterStatus.CDate;
				_eBy = daoRegisterStatus.EBy;
				_eDate = daoRegisterStatus.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBORegisterStatus");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one RegisterStatus record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAORegisterStatus daoRegisterStatus = new DAORegisterStatus();
			RegisterDataObject(daoRegisterStatus);
			BeginTransaction("deleteBORegisterStatus");
			try
			{
				daoRegisterStatus.RegisterStatusId = _registerStatusId;
				daoRegisterStatus.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBORegisterStatus");
				throw;
			}
		}
		
		///<Summary>
		///RegisterStatusCollection
		///This method returns the collection of BORegisterStatus objects
		///</Summary>
		///<returns>
		///List[BORegisterStatus]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BORegisterStatus> RegisterStatusCollection()
		{
			try
			{
				IList<BORegisterStatus> boRegisterStatusCollection = new List<BORegisterStatus>();
				IList<DAORegisterStatus> daoRegisterStatusCollection = DAORegisterStatus.SelectAll();
			
				foreach(DAORegisterStatus daoRegisterStatus in daoRegisterStatusCollection)
					boRegisterStatusCollection.Add(new BORegisterStatus(daoRegisterStatus));
			
				return boRegisterStatusCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RegisterStatusCollectionCount
		///This method returns the collection count of BORegisterStatus objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 RegisterStatusCollectionCount()
		{
			try
			{
				Int32 objCount = DAORegisterStatus.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///RegisterCollection
		///This method returns its collection of BORegister objects
		///</Summary>
		///<returns>
		///IList[BORegister]
		///</returns>
		///<parameters>
		///BORegisterStatus
		///</parameters>
		public virtual IList<BORegister> RegisterCollection()
		{
			try
			{
				if(_boRegisterCollection == null)
					LoadRegisterCollection();
				
				return _boRegisterCollection.AsReadOnly();
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
		///List<BORegisterStatus>
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
				IDictionary<string, IList<object>> retObj = DAORegisterStatus.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RegisterStatusCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BORegisterStatus objects, filtered by optional criteria
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
				IList<T> boRegisterStatusCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAORegisterStatus> daoRegisterStatusCollection = DAORegisterStatus.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAORegisterStatus resdaoRegisterStatus in daoRegisterStatusCollection)
					boRegisterStatusCollection.Add((T)(object)new BORegisterStatus(resdaoRegisterStatus));
			
				return boRegisterStatusCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RegisterStatusCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BORegisterStatus objects, filtered by optional criteria
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
				Int32 objCount = DAORegisterStatus.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadRegisterCollection
		///This method loads the internal collection of BORegister objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadRegisterCollection()
		{
			try
			{
				_boRegisterCollection = new List<BORegister>();
				IList<DAORegister> daoRegisterCollection = DAORegister.SelectAllByRegisterStatusId(_registerStatusId.Value);
				
				foreach(DAORegister daoRegister in daoRegisterCollection)
					_boRegisterCollection.Add(new BORegister(daoRegister));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddRegister
		///This method persists a BORegister object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BORegister
		///</parameters>
		public virtual void AddRegister(BORegister boRegister)
		{
			DAORegister daoRegister = new DAORegister();
			RegisterDataObject(daoRegister);
			BeginTransaction("addRegister");
			try
			{
				daoRegister.RegisterId = boRegister.RegisterId;
				daoRegister.RegisterType = boRegister.RegisterType;
				daoRegister.RegisterName = boRegister.RegisterName;
				daoRegister.Phone = boRegister.Phone;
				daoRegister.GovernerateId = boRegister.GovernerateId;
				daoRegister.CityId = boRegister.CityId;
				daoRegister.Lat = boRegister.Lat;
				daoRegister.Lng = boRegister.Lng;
				daoRegister.Address = boRegister.Address;
				daoRegister.VisitDay = boRegister.VisitDay;
				daoRegister.FromTime = boRegister.FromTime;
				daoRegister.ToTime = boRegister.ToTime;
				daoRegister.EBy = boRegister.EBy;
				daoRegister.EDate = boRegister.EDate;
				daoRegister.RegisterStatusId = _registerStatusId.Value;
				daoRegister.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boRegister = new BORegister(daoRegister);
				if(_boRegisterCollection != null)
					_boRegisterCollection.Add(boRegister);
			}
			catch
			{
				RollbackTransaction("addRegister");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllRegister
		///This method deletes all BORegister objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllRegister()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllRegister");
			try
			{
				DAORegister.DeleteAllByRegisterStatusId(ConnectionProvider, _registerStatusId.Value);
				CommitTransaction();
				if(_boRegisterCollection != null)
				{
					_boRegisterCollection.Clear();
					_boRegisterCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllRegister");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? RegisterStatusId
		{
			get
			{
				 return _registerStatusId;
			}
			set
			{
				_registerStatusId = value;
				_isDirty = true;
			}
		}
		
		public virtual string RegisterStatusCode
		{
			get
			{
				 return _registerStatusCode;
			}
			set
			{
				_registerStatusCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string RegisterStatusNameEn
		{
			get
			{
				 return _registerStatusNameEn;
			}
			set
			{
				_registerStatusNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string RegisterStatusNameAr
		{
			get
			{
				 return _registerStatusNameAr;
			}
			set
			{
				_registerStatusNameAr = value;
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
