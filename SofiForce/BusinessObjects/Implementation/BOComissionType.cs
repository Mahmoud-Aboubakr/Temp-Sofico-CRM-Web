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
	///This is the definition of the class BOComissionType.
	///It maintains a collection of BORepresentativeComission,BOSupervisorComission objects.
	///</Summary>
	public partial class BOComissionType : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _comissionTypeId;
		protected string _comissionTypeCode;
		protected string _comissionTypeNameEn;
		protected string _comissionTypeNameAr;
		protected string _icon;
		protected string _color;
		protected string _displayOrder;
		protected bool? _isActive;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BORepresentativeComission> _boRepresentativeComissionCollection;
		List<BOSupervisorComission> _boSupervisorComissionCollection;
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
		public BOComissionType()
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
		///Int32 comissionTypeId
		///</parameters>
		public BOComissionType(Int32 comissionTypeId)
		{
			try
			{
				DAOComissionType daoComissionType = DAOComissionType.SelectOne(comissionTypeId);
				_comissionTypeId = daoComissionType.ComissionTypeId;
				_comissionTypeCode = daoComissionType.ComissionTypeCode;
				_comissionTypeNameEn = daoComissionType.ComissionTypeNameEn;
				_comissionTypeNameAr = daoComissionType.ComissionTypeNameAr;
				_icon = daoComissionType.Icon;
				_color = daoComissionType.Color;
				_displayOrder = daoComissionType.DisplayOrder;
				_isActive = daoComissionType.IsActive;
				_canEdit = daoComissionType.CanEdit;
				_canDelete = daoComissionType.CanDelete;
				_cBy = daoComissionType.CBy;
				_cDate = daoComissionType.CDate;
				_eBy = daoComissionType.EBy;
				_eDate = daoComissionType.EDate;
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
		///DAOComissionType
		///</parameters>
		protected internal BOComissionType(DAOComissionType daoComissionType)
		{
			try
			{
				_comissionTypeId = daoComissionType.ComissionTypeId;
				_comissionTypeCode = daoComissionType.ComissionTypeCode;
				_comissionTypeNameEn = daoComissionType.ComissionTypeNameEn;
				_comissionTypeNameAr = daoComissionType.ComissionTypeNameAr;
				_icon = daoComissionType.Icon;
				_color = daoComissionType.Color;
				_displayOrder = daoComissionType.DisplayOrder;
				_isActive = daoComissionType.IsActive;
				_canEdit = daoComissionType.CanEdit;
				_canDelete = daoComissionType.CanDelete;
				_cBy = daoComissionType.CBy;
				_cDate = daoComissionType.CDate;
				_eBy = daoComissionType.EBy;
				_eDate = daoComissionType.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new ComissionType record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOComissionType daoComissionType = new DAOComissionType();
			RegisterDataObject(daoComissionType);
			BeginTransaction("savenewBOComissionType");
			try
			{
				daoComissionType.ComissionTypeCode = _comissionTypeCode;
				daoComissionType.ComissionTypeNameEn = _comissionTypeNameEn;
				daoComissionType.ComissionTypeNameAr = _comissionTypeNameAr;
				daoComissionType.Icon = _icon;
				daoComissionType.Color = _color;
				daoComissionType.DisplayOrder = _displayOrder;
				daoComissionType.IsActive = _isActive;
				daoComissionType.CanEdit = _canEdit;
				daoComissionType.CanDelete = _canDelete;
				daoComissionType.CBy = _cBy;
				daoComissionType.CDate = _cDate;
				daoComissionType.EBy = _eBy;
				daoComissionType.EDate = _eDate;
				daoComissionType.Insert();
				CommitTransaction();
				
				_comissionTypeId = daoComissionType.ComissionTypeId;
				_comissionTypeCode = daoComissionType.ComissionTypeCode;
				_comissionTypeNameEn = daoComissionType.ComissionTypeNameEn;
				_comissionTypeNameAr = daoComissionType.ComissionTypeNameAr;
				_icon = daoComissionType.Icon;
				_color = daoComissionType.Color;
				_displayOrder = daoComissionType.DisplayOrder;
				_isActive = daoComissionType.IsActive;
				_canEdit = daoComissionType.CanEdit;
				_canDelete = daoComissionType.CanDelete;
				_cBy = daoComissionType.CBy;
				_cDate = daoComissionType.CDate;
				_eBy = daoComissionType.EBy;
				_eDate = daoComissionType.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOComissionType");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one ComissionType record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOComissionType
		///</parameters>
		public virtual void Update()
		{
			DAOComissionType daoComissionType = new DAOComissionType();
			RegisterDataObject(daoComissionType);
			BeginTransaction("updateBOComissionType");
			try
			{
				daoComissionType.ComissionTypeId = _comissionTypeId;
				daoComissionType.ComissionTypeCode = _comissionTypeCode;
				daoComissionType.ComissionTypeNameEn = _comissionTypeNameEn;
				daoComissionType.ComissionTypeNameAr = _comissionTypeNameAr;
				daoComissionType.Icon = _icon;
				daoComissionType.Color = _color;
				daoComissionType.DisplayOrder = _displayOrder;
				daoComissionType.IsActive = _isActive;
				daoComissionType.CanEdit = _canEdit;
				daoComissionType.CanDelete = _canDelete;
				daoComissionType.CBy = _cBy;
				daoComissionType.CDate = _cDate;
				daoComissionType.EBy = _eBy;
				daoComissionType.EDate = _eDate;
				daoComissionType.Update();
				CommitTransaction();
				
				_comissionTypeId = daoComissionType.ComissionTypeId;
				_comissionTypeCode = daoComissionType.ComissionTypeCode;
				_comissionTypeNameEn = daoComissionType.ComissionTypeNameEn;
				_comissionTypeNameAr = daoComissionType.ComissionTypeNameAr;
				_icon = daoComissionType.Icon;
				_color = daoComissionType.Color;
				_displayOrder = daoComissionType.DisplayOrder;
				_isActive = daoComissionType.IsActive;
				_canEdit = daoComissionType.CanEdit;
				_canDelete = daoComissionType.CanDelete;
				_cBy = daoComissionType.CBy;
				_cDate = daoComissionType.CDate;
				_eBy = daoComissionType.EBy;
				_eDate = daoComissionType.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOComissionType");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one ComissionType record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOComissionType daoComissionType = new DAOComissionType();
			RegisterDataObject(daoComissionType);
			BeginTransaction("deleteBOComissionType");
			try
			{
				daoComissionType.ComissionTypeId = _comissionTypeId;
				daoComissionType.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOComissionType");
				throw;
			}
		}
		
		///<Summary>
		///ComissionTypeCollection
		///This method returns the collection of BOComissionType objects
		///</Summary>
		///<returns>
		///List[BOComissionType]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOComissionType> ComissionTypeCollection()
		{
			try
			{
				IList<BOComissionType> boComissionTypeCollection = new List<BOComissionType>();
				IList<DAOComissionType> daoComissionTypeCollection = DAOComissionType.SelectAll();
			
				foreach(DAOComissionType daoComissionType in daoComissionTypeCollection)
					boComissionTypeCollection.Add(new BOComissionType(daoComissionType));
			
				return boComissionTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ComissionTypeCollectionCount
		///This method returns the collection count of BOComissionType objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ComissionTypeCollectionCount()
		{
			try
			{
				Int32 objCount = DAOComissionType.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///RepresentativeComissionCollection
		///This method returns its collection of BORepresentativeComission objects
		///</Summary>
		///<returns>
		///IList[BORepresentativeComission]
		///</returns>
		///<parameters>
		///BOComissionType
		///</parameters>
		public virtual IList<BORepresentativeComission> RepresentativeComissionCollection()
		{
			try
			{
				if(_boRepresentativeComissionCollection == null)
					LoadRepresentativeComissionCollection();
				
				return _boRepresentativeComissionCollection.AsReadOnly();
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///SupervisorComissionCollection
		///This method returns its collection of BOSupervisorComission objects
		///</Summary>
		///<returns>
		///IList[BOSupervisorComission]
		///</returns>
		///<parameters>
		///BOComissionType
		///</parameters>
		public virtual IList<BOSupervisorComission> SupervisorComissionCollection()
		{
			try
			{
				if(_boSupervisorComissionCollection == null)
					LoadSupervisorComissionCollection();
				
				return _boSupervisorComissionCollection.AsReadOnly();
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
		///List<BOComissionType>
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
				IDictionary<string, IList<object>> retObj = DAOComissionType.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ComissionTypeCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOComissionType objects, filtered by optional criteria
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
				IList<T> boComissionTypeCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOComissionType> daoComissionTypeCollection = DAOComissionType.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOComissionType resdaoComissionType in daoComissionTypeCollection)
					boComissionTypeCollection.Add((T)(object)new BOComissionType(resdaoComissionType));
			
				return boComissionTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ComissionTypeCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOComissionType objects, filtered by optional criteria
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
				Int32 objCount = DAOComissionType.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadRepresentativeComissionCollection
		///This method loads the internal collection of BORepresentativeComission objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadRepresentativeComissionCollection()
		{
			try
			{
				_boRepresentativeComissionCollection = new List<BORepresentativeComission>();
				IList<DAORepresentativeComission> daoRepresentativeComissionCollection = DAORepresentativeComission.SelectAllByComissionTypeId(_comissionTypeId.Value);
				
				foreach(DAORepresentativeComission daoRepresentativeComission in daoRepresentativeComissionCollection)
					_boRepresentativeComissionCollection.Add(new BORepresentativeComission(daoRepresentativeComission));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddRepresentativeComission
		///This method persists a BORepresentativeComission object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BORepresentativeComission
		///</parameters>
		public virtual void AddRepresentativeComission(BORepresentativeComission boRepresentativeComission)
		{
			DAORepresentativeComission daoRepresentativeComission = new DAORepresentativeComission();
			RegisterDataObject(daoRepresentativeComission);
			BeginTransaction("addRepresentativeComission");
			try
			{
				daoRepresentativeComission.ComissionId = boRepresentativeComission.ComissionId;
				daoRepresentativeComission.RepresentativeId = boRepresentativeComission.RepresentativeId;
				daoRepresentativeComission.ComissionDate = boRepresentativeComission.ComissionDate;
				daoRepresentativeComission.ComissionValue = boRepresentativeComission.ComissionValue;
				daoRepresentativeComission.IsApproved = boRepresentativeComission.IsApproved;
				daoRepresentativeComission.Notes = boRepresentativeComission.Notes;
				daoRepresentativeComission.CBy = boRepresentativeComission.CBy;
				daoRepresentativeComission.CDate = boRepresentativeComission.CDate;
				daoRepresentativeComission.EBy = boRepresentativeComission.EBy;
				daoRepresentativeComission.EDate = boRepresentativeComission.EDate;
				daoRepresentativeComission.ComissionTypeId = _comissionTypeId.Value;
				daoRepresentativeComission.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boRepresentativeComission = new BORepresentativeComission(daoRepresentativeComission);
				if(_boRepresentativeComissionCollection != null)
					_boRepresentativeComissionCollection.Add(boRepresentativeComission);
			}
			catch
			{
				RollbackTransaction("addRepresentativeComission");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllRepresentativeComission
		///This method deletes all BORepresentativeComission objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllRepresentativeComission()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllRepresentativeComission");
			try
			{
				DAORepresentativeComission.DeleteAllByComissionTypeId(ConnectionProvider, _comissionTypeId.Value);
				CommitTransaction();
				if(_boRepresentativeComissionCollection != null)
				{
					_boRepresentativeComissionCollection.Clear();
					_boRepresentativeComissionCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllRepresentativeComission");
				throw;
			}
		}
		
		///<Summary>
		///LoadSupervisorComissionCollection
		///This method loads the internal collection of BOSupervisorComission objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadSupervisorComissionCollection()
		{
			try
			{
				_boSupervisorComissionCollection = new List<BOSupervisorComission>();
				IList<DAOSupervisorComission> daoSupervisorComissionCollection = DAOSupervisorComission.SelectAllByComissionTypeId(_comissionTypeId.Value);
				
				foreach(DAOSupervisorComission daoSupervisorComission in daoSupervisorComissionCollection)
					_boSupervisorComissionCollection.Add(new BOSupervisorComission(daoSupervisorComission));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddSupervisorComission
		///This method persists a BOSupervisorComission object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOSupervisorComission
		///</parameters>
		public virtual void AddSupervisorComission(BOSupervisorComission boSupervisorComission)
		{
			DAOSupervisorComission daoSupervisorComission = new DAOSupervisorComission();
			RegisterDataObject(daoSupervisorComission);
			BeginTransaction("addSupervisorComission");
			try
			{
				daoSupervisorComission.ComissionId = boSupervisorComission.ComissionId;
				daoSupervisorComission.SupervisorId = boSupervisorComission.SupervisorId;
				daoSupervisorComission.ComissionDate = boSupervisorComission.ComissionDate;
				daoSupervisorComission.ComissionValue = boSupervisorComission.ComissionValue;
				daoSupervisorComission.IsApproved = boSupervisorComission.IsApproved;
				daoSupervisorComission.Notes = boSupervisorComission.Notes;
				daoSupervisorComission.CBy = boSupervisorComission.CBy;
				daoSupervisorComission.CDate = boSupervisorComission.CDate;
				daoSupervisorComission.EBy = boSupervisorComission.EBy;
				daoSupervisorComission.EDate = boSupervisorComission.EDate;
				daoSupervisorComission.ComissionTypeId = _comissionTypeId.Value;
				daoSupervisorComission.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boSupervisorComission = new BOSupervisorComission(daoSupervisorComission);
				if(_boSupervisorComissionCollection != null)
					_boSupervisorComissionCollection.Add(boSupervisorComission);
			}
			catch
			{
				RollbackTransaction("addSupervisorComission");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllSupervisorComission
		///This method deletes all BOSupervisorComission objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllSupervisorComission()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllSupervisorComission");
			try
			{
				DAOSupervisorComission.DeleteAllByComissionTypeId(ConnectionProvider, _comissionTypeId.Value);
				CommitTransaction();
				if(_boSupervisorComissionCollection != null)
				{
					_boSupervisorComissionCollection.Clear();
					_boSupervisorComissionCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllSupervisorComission");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? ComissionTypeId
		{
			get
			{
				 return _comissionTypeId;
			}
			set
			{
				_comissionTypeId = value;
				_isDirty = true;
			}
		}
		
		public virtual string ComissionTypeCode
		{
			get
			{
				 return _comissionTypeCode;
			}
			set
			{
				_comissionTypeCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string ComissionTypeNameEn
		{
			get
			{
				 return _comissionTypeNameEn;
			}
			set
			{
				_comissionTypeNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string ComissionTypeNameAr
		{
			get
			{
				 return _comissionTypeNameAr;
			}
			set
			{
				_comissionTypeNameAr = value;
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
		
		public virtual string DisplayOrder
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
