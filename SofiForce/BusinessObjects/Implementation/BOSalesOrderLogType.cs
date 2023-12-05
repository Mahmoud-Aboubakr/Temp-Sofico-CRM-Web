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
	///This is the definition of the class BOSalesOrderLogType.
	///It maintains a collection of BOSalesOrderLog objects.
	///</Summary>
	public partial class BOSalesOrderLogType : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _salesOrderLogTypeId;
		protected string _salesOrderLogTypeCode;
		protected string _salesOrderLogTypeNameEn;
		protected string _salesOrderLogTypeNameAr;
		protected string _icon;
		protected string _color;
		protected bool? _isActive;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOSalesOrderLog> _boSalesOrderLogCollection;
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
		public BOSalesOrderLogType()
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
		///Int32 salesOrderLogTypeId
		///</parameters>
		public BOSalesOrderLogType(Int32 salesOrderLogTypeId)
		{
			try
			{
				DAOSalesOrderLogType daoSalesOrderLogType = DAOSalesOrderLogType.SelectOne(salesOrderLogTypeId);
				_salesOrderLogTypeId = daoSalesOrderLogType.SalesOrderLogTypeId;
				_salesOrderLogTypeCode = daoSalesOrderLogType.SalesOrderLogTypeCode;
				_salesOrderLogTypeNameEn = daoSalesOrderLogType.SalesOrderLogTypeNameEn;
				_salesOrderLogTypeNameAr = daoSalesOrderLogType.SalesOrderLogTypeNameAr;
				_icon = daoSalesOrderLogType.Icon;
				_color = daoSalesOrderLogType.Color;
				_isActive = daoSalesOrderLogType.IsActive;
				_canEdit = daoSalesOrderLogType.CanEdit;
				_canDelete = daoSalesOrderLogType.CanDelete;
				_cBy = daoSalesOrderLogType.CBy;
				_cDate = daoSalesOrderLogType.CDate;
				_eBy = daoSalesOrderLogType.EBy;
				_eDate = daoSalesOrderLogType.EDate;
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
		///DAOSalesOrderLogType
		///</parameters>
		protected internal BOSalesOrderLogType(DAOSalesOrderLogType daoSalesOrderLogType)
		{
			try
			{
				_salesOrderLogTypeId = daoSalesOrderLogType.SalesOrderLogTypeId;
				_salesOrderLogTypeCode = daoSalesOrderLogType.SalesOrderLogTypeCode;
				_salesOrderLogTypeNameEn = daoSalesOrderLogType.SalesOrderLogTypeNameEn;
				_salesOrderLogTypeNameAr = daoSalesOrderLogType.SalesOrderLogTypeNameAr;
				_icon = daoSalesOrderLogType.Icon;
				_color = daoSalesOrderLogType.Color;
				_isActive = daoSalesOrderLogType.IsActive;
				_canEdit = daoSalesOrderLogType.CanEdit;
				_canDelete = daoSalesOrderLogType.CanDelete;
				_cBy = daoSalesOrderLogType.CBy;
				_cDate = daoSalesOrderLogType.CDate;
				_eBy = daoSalesOrderLogType.EBy;
				_eDate = daoSalesOrderLogType.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new SalesOrderLogType record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOSalesOrderLogType daoSalesOrderLogType = new DAOSalesOrderLogType();
			RegisterDataObject(daoSalesOrderLogType);
			BeginTransaction("savenewBOSalesOrderLogType");
			try
			{
				daoSalesOrderLogType.SalesOrderLogTypeId = _salesOrderLogTypeId;
				daoSalesOrderLogType.SalesOrderLogTypeCode = _salesOrderLogTypeCode;
				daoSalesOrderLogType.SalesOrderLogTypeNameEn = _salesOrderLogTypeNameEn;
				daoSalesOrderLogType.SalesOrderLogTypeNameAr = _salesOrderLogTypeNameAr;
				daoSalesOrderLogType.Icon = _icon;
				daoSalesOrderLogType.Color = _color;
				daoSalesOrderLogType.IsActive = _isActive;
				daoSalesOrderLogType.CanEdit = _canEdit;
				daoSalesOrderLogType.CanDelete = _canDelete;
				daoSalesOrderLogType.CBy = _cBy;
				daoSalesOrderLogType.CDate = _cDate;
				daoSalesOrderLogType.EBy = _eBy;
				daoSalesOrderLogType.EDate = _eDate;
				daoSalesOrderLogType.Insert();
				CommitTransaction();
				
				_salesOrderLogTypeId = daoSalesOrderLogType.SalesOrderLogTypeId;
				_salesOrderLogTypeCode = daoSalesOrderLogType.SalesOrderLogTypeCode;
				_salesOrderLogTypeNameEn = daoSalesOrderLogType.SalesOrderLogTypeNameEn;
				_salesOrderLogTypeNameAr = daoSalesOrderLogType.SalesOrderLogTypeNameAr;
				_icon = daoSalesOrderLogType.Icon;
				_color = daoSalesOrderLogType.Color;
				_isActive = daoSalesOrderLogType.IsActive;
				_canEdit = daoSalesOrderLogType.CanEdit;
				_canDelete = daoSalesOrderLogType.CanDelete;
				_cBy = daoSalesOrderLogType.CBy;
				_cDate = daoSalesOrderLogType.CDate;
				_eBy = daoSalesOrderLogType.EBy;
				_eDate = daoSalesOrderLogType.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOSalesOrderLogType");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one SalesOrderLogType record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOSalesOrderLogType
		///</parameters>
		public virtual void Update()
		{
			DAOSalesOrderLogType daoSalesOrderLogType = new DAOSalesOrderLogType();
			RegisterDataObject(daoSalesOrderLogType);
			BeginTransaction("updateBOSalesOrderLogType");
			try
			{
				daoSalesOrderLogType.SalesOrderLogTypeId = _salesOrderLogTypeId;
				daoSalesOrderLogType.SalesOrderLogTypeCode = _salesOrderLogTypeCode;
				daoSalesOrderLogType.SalesOrderLogTypeNameEn = _salesOrderLogTypeNameEn;
				daoSalesOrderLogType.SalesOrderLogTypeNameAr = _salesOrderLogTypeNameAr;
				daoSalesOrderLogType.Icon = _icon;
				daoSalesOrderLogType.Color = _color;
				daoSalesOrderLogType.IsActive = _isActive;
				daoSalesOrderLogType.CanEdit = _canEdit;
				daoSalesOrderLogType.CanDelete = _canDelete;
				daoSalesOrderLogType.CBy = _cBy;
				daoSalesOrderLogType.CDate = _cDate;
				daoSalesOrderLogType.EBy = _eBy;
				daoSalesOrderLogType.EDate = _eDate;
				daoSalesOrderLogType.Update();
				CommitTransaction();
				
				_salesOrderLogTypeId = daoSalesOrderLogType.SalesOrderLogTypeId;
				_salesOrderLogTypeCode = daoSalesOrderLogType.SalesOrderLogTypeCode;
				_salesOrderLogTypeNameEn = daoSalesOrderLogType.SalesOrderLogTypeNameEn;
				_salesOrderLogTypeNameAr = daoSalesOrderLogType.SalesOrderLogTypeNameAr;
				_icon = daoSalesOrderLogType.Icon;
				_color = daoSalesOrderLogType.Color;
				_isActive = daoSalesOrderLogType.IsActive;
				_canEdit = daoSalesOrderLogType.CanEdit;
				_canDelete = daoSalesOrderLogType.CanDelete;
				_cBy = daoSalesOrderLogType.CBy;
				_cDate = daoSalesOrderLogType.CDate;
				_eBy = daoSalesOrderLogType.EBy;
				_eDate = daoSalesOrderLogType.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOSalesOrderLogType");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one SalesOrderLogType record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOSalesOrderLogType daoSalesOrderLogType = new DAOSalesOrderLogType();
			RegisterDataObject(daoSalesOrderLogType);
			BeginTransaction("deleteBOSalesOrderLogType");
			try
			{
				daoSalesOrderLogType.SalesOrderLogTypeId = _salesOrderLogTypeId;
				daoSalesOrderLogType.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOSalesOrderLogType");
				throw;
			}
		}
		
		///<Summary>
		///SalesOrderLogTypeCollection
		///This method returns the collection of BOSalesOrderLogType objects
		///</Summary>
		///<returns>
		///List[BOSalesOrderLogType]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOSalesOrderLogType> SalesOrderLogTypeCollection()
		{
			try
			{
				IList<BOSalesOrderLogType> boSalesOrderLogTypeCollection = new List<BOSalesOrderLogType>();
				IList<DAOSalesOrderLogType> daoSalesOrderLogTypeCollection = DAOSalesOrderLogType.SelectAll();
			
				foreach(DAOSalesOrderLogType daoSalesOrderLogType in daoSalesOrderLogTypeCollection)
					boSalesOrderLogTypeCollection.Add(new BOSalesOrderLogType(daoSalesOrderLogType));
			
				return boSalesOrderLogTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderLogTypeCollectionCount
		///This method returns the collection count of BOSalesOrderLogType objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 SalesOrderLogTypeCollectionCount()
		{
			try
			{
				Int32 objCount = DAOSalesOrderLogType.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///SalesOrderLogCollection
		///This method returns its collection of BOSalesOrderLog objects
		///</Summary>
		///<returns>
		///IList[BOSalesOrderLog]
		///</returns>
		///<parameters>
		///BOSalesOrderLogType
		///</parameters>
		public virtual IList<BOSalesOrderLog> SalesOrderLogCollection()
		{
			try
			{
				if(_boSalesOrderLogCollection == null)
					LoadSalesOrderLogCollection();
				
				return _boSalesOrderLogCollection.AsReadOnly();
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
		///List<BOSalesOrderLogType>
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
				IDictionary<string, IList<object>> retObj = DAOSalesOrderLogType.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderLogTypeCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOSalesOrderLogType objects, filtered by optional criteria
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
				IList<T> boSalesOrderLogTypeCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOSalesOrderLogType> daoSalesOrderLogTypeCollection = DAOSalesOrderLogType.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOSalesOrderLogType resdaoSalesOrderLogType in daoSalesOrderLogTypeCollection)
					boSalesOrderLogTypeCollection.Add((T)(object)new BOSalesOrderLogType(resdaoSalesOrderLogType));
			
				return boSalesOrderLogTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderLogTypeCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOSalesOrderLogType objects, filtered by optional criteria
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
				Int32 objCount = DAOSalesOrderLogType.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadSalesOrderLogCollection
		///This method loads the internal collection of BOSalesOrderLog objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadSalesOrderLogCollection()
		{
			try
			{
				_boSalesOrderLogCollection = new List<BOSalesOrderLog>();
				IList<DAOSalesOrderLog> daoSalesOrderLogCollection = DAOSalesOrderLog.SelectAllBySalesOrderLogTypeId(_salesOrderLogTypeId.Value);
				
				foreach(DAOSalesOrderLog daoSalesOrderLog in daoSalesOrderLogCollection)
					_boSalesOrderLogCollection.Add(new BOSalesOrderLog(daoSalesOrderLog));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddSalesOrderLog
		///This method persists a BOSalesOrderLog object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOSalesOrderLog
		///</parameters>
		public virtual void AddSalesOrderLog(BOSalesOrderLog boSalesOrderLog)
		{
			DAOSalesOrderLog daoSalesOrderLog = new DAOSalesOrderLog();
			RegisterDataObject(daoSalesOrderLog);
			BeginTransaction("addSalesOrderLog");
			try
			{
				daoSalesOrderLog.LogId = boSalesOrderLog.LogId;
				daoSalesOrderLog.SalesId = boSalesOrderLog.SalesId;
				daoSalesOrderLog.LogDate = boSalesOrderLog.LogDate;
				daoSalesOrderLog.UserId = boSalesOrderLog.UserId;
				daoSalesOrderLog.SalesOrderLogTypeId = _salesOrderLogTypeId.Value;
				daoSalesOrderLog.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boSalesOrderLog = new BOSalesOrderLog(daoSalesOrderLog);
				if(_boSalesOrderLogCollection != null)
					_boSalesOrderLogCollection.Add(boSalesOrderLog);
			}
			catch
			{
				RollbackTransaction("addSalesOrderLog");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllSalesOrderLog
		///This method deletes all BOSalesOrderLog objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllSalesOrderLog()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllSalesOrderLog");
			try
			{
				DAOSalesOrderLog.DeleteAllBySalesOrderLogTypeId(ConnectionProvider, _salesOrderLogTypeId.Value);
				CommitTransaction();
				if(_boSalesOrderLogCollection != null)
				{
					_boSalesOrderLogCollection.Clear();
					_boSalesOrderLogCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllSalesOrderLog");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? SalesOrderLogTypeId
		{
			get
			{
				 return _salesOrderLogTypeId;
			}
			set
			{
				_salesOrderLogTypeId = value;
				_isDirty = true;
			}
		}
		
		public virtual string SalesOrderLogTypeCode
		{
			get
			{
				 return _salesOrderLogTypeCode;
			}
			set
			{
				_salesOrderLogTypeCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string SalesOrderLogTypeNameEn
		{
			get
			{
				 return _salesOrderLogTypeNameEn;
			}
			set
			{
				_salesOrderLogTypeNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string SalesOrderLogTypeNameAr
		{
			get
			{
				 return _salesOrderLogTypeNameAr;
			}
			set
			{
				_salesOrderLogTypeNameAr = value;
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
