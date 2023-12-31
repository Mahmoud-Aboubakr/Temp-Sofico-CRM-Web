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
	///This is the definition of the class BOAd.
	///</Summary>
	public partial class BOAd : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _adId;
		protected string _adCode;
		protected string _adNameEn;
		protected string _adNameAr;
		protected bool? _isExpire;
		protected DateTime? _expireDate;
		protected string _imagePath;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
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
		public BOAd()
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
		///Int32 adId
		///</parameters>
		public BOAd(Int32 adId)
		{
			try
			{
				DAOAd daoAd = DAOAd.SelectOne(adId);
				_adId = daoAd.AdId;
				_adCode = daoAd.AdCode;
				_adNameEn = daoAd.AdNameEn;
				_adNameAr = daoAd.AdNameAr;
				_isExpire = daoAd.IsExpire;
				_expireDate = daoAd.ExpireDate;
				_imagePath = daoAd.ImagePath;
				_cBy = daoAd.CBy;
				_cDate = daoAd.CDate;
				_eBy = daoAd.EBy;
				_eDate = daoAd.EDate;
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
		///DAOAd
		///</parameters>
		protected internal BOAd(DAOAd daoAd)
		{
			try
			{
				_adId = daoAd.AdId;
				_adCode = daoAd.AdCode;
				_adNameEn = daoAd.AdNameEn;
				_adNameAr = daoAd.AdNameAr;
				_isExpire = daoAd.IsExpire;
				_expireDate = daoAd.ExpireDate;
				_imagePath = daoAd.ImagePath;
				_cBy = daoAd.CBy;
				_cDate = daoAd.CDate;
				_eBy = daoAd.EBy;
				_eDate = daoAd.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new Ad record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOAd daoAd = new DAOAd();
			RegisterDataObject(daoAd);
			BeginTransaction("savenewBOAd");
			try
			{
				daoAd.AdCode = _adCode;
				daoAd.AdNameEn = _adNameEn;
				daoAd.AdNameAr = _adNameAr;
				daoAd.IsExpire = _isExpire;
				daoAd.ExpireDate = _expireDate;
				daoAd.ImagePath = _imagePath;
				daoAd.CBy = _cBy;
				daoAd.CDate = _cDate;
				daoAd.EBy = _eBy;
				daoAd.EDate = _eDate;
				daoAd.Insert();
				CommitTransaction();
				
				_adId = daoAd.AdId;
				_adCode = daoAd.AdCode;
				_adNameEn = daoAd.AdNameEn;
				_adNameAr = daoAd.AdNameAr;
				_isExpire = daoAd.IsExpire;
				_expireDate = daoAd.ExpireDate;
				_imagePath = daoAd.ImagePath;
				_cBy = daoAd.CBy;
				_cDate = daoAd.CDate;
				_eBy = daoAd.EBy;
				_eDate = daoAd.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOAd");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one Ad record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOAd
		///</parameters>
		public virtual void Update()
		{
			DAOAd daoAd = new DAOAd();
			RegisterDataObject(daoAd);
			BeginTransaction("updateBOAd");
			try
			{
				daoAd.AdId = _adId;
				daoAd.AdCode = _adCode;
				daoAd.AdNameEn = _adNameEn;
				daoAd.AdNameAr = _adNameAr;
				daoAd.IsExpire = _isExpire;
				daoAd.ExpireDate = _expireDate;
				daoAd.ImagePath = _imagePath;
				daoAd.CBy = _cBy;
				daoAd.CDate = _cDate;
				daoAd.EBy = _eBy;
				daoAd.EDate = _eDate;
				daoAd.Update();
				CommitTransaction();
				
				_adId = daoAd.AdId;
				_adCode = daoAd.AdCode;
				_adNameEn = daoAd.AdNameEn;
				_adNameAr = daoAd.AdNameAr;
				_isExpire = daoAd.IsExpire;
				_expireDate = daoAd.ExpireDate;
				_imagePath = daoAd.ImagePath;
				_cBy = daoAd.CBy;
				_cDate = daoAd.CDate;
				_eBy = daoAd.EBy;
				_eDate = daoAd.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOAd");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one Ad record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOAd daoAd = new DAOAd();
			RegisterDataObject(daoAd);
			BeginTransaction("deleteBOAd");
			try
			{
				daoAd.AdId = _adId;
				daoAd.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOAd");
				throw;
			}
		}
		
		///<Summary>
		///AdCollection
		///This method returns the collection of BOAd objects
		///</Summary>
		///<returns>
		///List[BOAd]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOAd> AdCollection()
		{
			try
			{
				IList<BOAd> boAdCollection = new List<BOAd>();
				IList<DAOAd> daoAdCollection = DAOAd.SelectAll();
			
				foreach(DAOAd daoAd in daoAdCollection)
					boAdCollection.Add(new BOAd(daoAd));
			
				return boAdCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AdCollectionCount
		///This method returns the collection count of BOAd objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 AdCollectionCount()
		{
			try
			{
				Int32 objCount = DAOAd.SelectAllCount();
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
		///List<BOAd>
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
				IDictionary<string, IList<object>> retObj = DAOAd.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AdCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOAd objects, filtered by optional criteria
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
				IList<T> boAdCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOAd> daoAdCollection = DAOAd.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOAd resdaoAd in daoAdCollection)
					boAdCollection.Add((T)(object)new BOAd(resdaoAd));
			
				return boAdCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AdCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOAd objects, filtered by optional criteria
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
				Int32 objCount = DAOAd.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? AdId
		{
			get
			{
				 return _adId;
			}
			set
			{
				_adId = value;
				_isDirty = true;
			}
		}
		
		public virtual string AdCode
		{
			get
			{
				 return _adCode;
			}
			set
			{
				_adCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string AdNameEn
		{
			get
			{
				 return _adNameEn;
			}
			set
			{
				_adNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string AdNameAr
		{
			get
			{
				 return _adNameAr;
			}
			set
			{
				_adNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? IsExpire
		{
			get
			{
				 return _isExpire;
			}
			set
			{
				_isExpire = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? ExpireDate
		{
			get
			{
				 return _expireDate;
			}
			set
			{
				_expireDate = value;
				_isDirty = true;
			}
		}
		
		public virtual string ImagePath
		{
			get
			{
				 return _imagePath;
			}
			set
			{
				_imagePath = value;
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
