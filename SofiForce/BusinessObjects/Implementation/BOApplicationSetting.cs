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
	///This is the definition of the class BOApplicationSetting.
	///</Summary>
	public partial class BOApplicationSetting : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _appSettingId;
		protected Int32? _applicationId;
		protected string _appSettingCode;
		protected string _appSettingName;
		protected string _appSettingValue;
		protected DateTime? _appSettingLastDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
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
		public BOApplicationSetting()
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
		///Int32 appSettingId
		///</parameters>
		public BOApplicationSetting(Int32 appSettingId)
		{
			try
			{
				DAOApplicationSetting daoApplicationSetting = DAOApplicationSetting.SelectOne(appSettingId);
				_appSettingId = daoApplicationSetting.AppSettingId;
				_applicationId = daoApplicationSetting.ApplicationId;
				_appSettingCode = daoApplicationSetting.AppSettingCode;
				_appSettingName = daoApplicationSetting.AppSettingName;
				_appSettingValue = daoApplicationSetting.AppSettingValue;
				_appSettingLastDate = daoApplicationSetting.AppSettingLastDate;
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
		///DAOApplicationSetting
		///</parameters>
		protected internal BOApplicationSetting(DAOApplicationSetting daoApplicationSetting)
		{
			try
			{
				_appSettingId = daoApplicationSetting.AppSettingId;
				_applicationId = daoApplicationSetting.ApplicationId;
				_appSettingCode = daoApplicationSetting.AppSettingCode;
				_appSettingName = daoApplicationSetting.AppSettingName;
				_appSettingValue = daoApplicationSetting.AppSettingValue;
				_appSettingLastDate = daoApplicationSetting.AppSettingLastDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new ApplicationSetting record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOApplicationSetting daoApplicationSetting = new DAOApplicationSetting();
			RegisterDataObject(daoApplicationSetting);
			BeginTransaction("savenewBOApplicationSetting");
			try
			{
				daoApplicationSetting.ApplicationId = _applicationId;
				daoApplicationSetting.AppSettingCode = _appSettingCode;
				daoApplicationSetting.AppSettingName = _appSettingName;
				daoApplicationSetting.AppSettingValue = _appSettingValue;
				daoApplicationSetting.AppSettingLastDate = _appSettingLastDate;
				daoApplicationSetting.Insert();
				CommitTransaction();
				
				_appSettingId = daoApplicationSetting.AppSettingId;
				_applicationId = daoApplicationSetting.ApplicationId;
				_appSettingCode = daoApplicationSetting.AppSettingCode;
				_appSettingName = daoApplicationSetting.AppSettingName;
				_appSettingValue = daoApplicationSetting.AppSettingValue;
				_appSettingLastDate = daoApplicationSetting.AppSettingLastDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOApplicationSetting");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one ApplicationSetting record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOApplicationSetting
		///</parameters>
		public virtual void Update()
		{
			DAOApplicationSetting daoApplicationSetting = new DAOApplicationSetting();
			RegisterDataObject(daoApplicationSetting);
			BeginTransaction("updateBOApplicationSetting");
			try
			{
				daoApplicationSetting.AppSettingId = _appSettingId;
				daoApplicationSetting.ApplicationId = _applicationId;
				daoApplicationSetting.AppSettingCode = _appSettingCode;
				daoApplicationSetting.AppSettingName = _appSettingName;
				daoApplicationSetting.AppSettingValue = _appSettingValue;
				daoApplicationSetting.AppSettingLastDate = _appSettingLastDate;
				daoApplicationSetting.Update();
				CommitTransaction();
				
				_appSettingId = daoApplicationSetting.AppSettingId;
				_applicationId = daoApplicationSetting.ApplicationId;
				_appSettingCode = daoApplicationSetting.AppSettingCode;
				_appSettingName = daoApplicationSetting.AppSettingName;
				_appSettingValue = daoApplicationSetting.AppSettingValue;
				_appSettingLastDate = daoApplicationSetting.AppSettingLastDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOApplicationSetting");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one ApplicationSetting record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOApplicationSetting daoApplicationSetting = new DAOApplicationSetting();
			RegisterDataObject(daoApplicationSetting);
			BeginTransaction("deleteBOApplicationSetting");
			try
			{
				daoApplicationSetting.AppSettingId = _appSettingId;
				daoApplicationSetting.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOApplicationSetting");
				throw;
			}
		}
		
		///<Summary>
		///ApplicationSettingCollection
		///This method returns the collection of BOApplicationSetting objects
		///</Summary>
		///<returns>
		///List[BOApplicationSetting]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOApplicationSetting> ApplicationSettingCollection()
		{
			try
			{
				IList<BOApplicationSetting> boApplicationSettingCollection = new List<BOApplicationSetting>();
				IList<DAOApplicationSetting> daoApplicationSettingCollection = DAOApplicationSetting.SelectAll();
			
				foreach(DAOApplicationSetting daoApplicationSetting in daoApplicationSettingCollection)
					boApplicationSettingCollection.Add(new BOApplicationSetting(daoApplicationSetting));
			
				return boApplicationSettingCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ApplicationSettingCollectionCount
		///This method returns the collection count of BOApplicationSetting objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ApplicationSettingCollectionCount()
		{
			try
			{
				Int32 objCount = DAOApplicationSetting.SelectAllCount();
				return objCount;
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
		///List<BOApplicationSetting>
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
				IDictionary<string, IList<object>> retObj = DAOApplicationSetting.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ApplicationSettingCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOApplicationSetting objects, filtered by optional criteria
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
				IList<T> boApplicationSettingCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOApplicationSetting> daoApplicationSettingCollection = DAOApplicationSetting.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOApplicationSetting resdaoApplicationSetting in daoApplicationSettingCollection)
					boApplicationSettingCollection.Add((T)(object)new BOApplicationSetting(resdaoApplicationSetting));
			
				return boApplicationSettingCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ApplicationSettingCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOApplicationSetting objects, filtered by optional criteria
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
				Int32 objCount = DAOApplicationSetting.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? AppSettingId
		{
			get
			{
				 return _appSettingId;
			}
			set
			{
				_appSettingId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ApplicationId
		{
			get
			{
				 return _applicationId;
			}
			set
			{
				_applicationId = value;
				_isDirty = true;
			}
		}
		
		public virtual string AppSettingCode
		{
			get
			{
				 return _appSettingCode;
			}
			set
			{
				_appSettingCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string AppSettingName
		{
			get
			{
				 return _appSettingName;
			}
			set
			{
				_appSettingName = value;
				_isDirty = true;
			}
		}
		
		public virtual string AppSettingValue
		{
			get
			{
				 return _appSettingValue;
			}
			set
			{
				_appSettingValue = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? AppSettingLastDate
		{
			get
			{
				 return _appSettingLastDate;
			}
			set
			{
				_appSettingLastDate = value;
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
