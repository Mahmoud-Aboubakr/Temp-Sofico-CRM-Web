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
	///This is the definition of the class BOArticle.
	///It maintains a collection of BOArticleDetail objects.
	///</Summary>
	public partial class BOArticle : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _articleId;
		protected string _articleCode;
		protected DateTime? _articleDate;
		protected DateTime? _articleTime;
		protected Int32? _articleCategoryId;
		protected string _articleTitleAr;
		protected string _articleTitleEn;
		protected bool? _isActive;
		protected string _articleImage;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOArticleDetail> _boArticleDetailCollection;
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
		public BOArticle()
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
		///Int32 articleId
		///</parameters>
		public BOArticle(Int32 articleId)
		{
			try
			{
				DAOArticle daoArticle = DAOArticle.SelectOne(articleId);
				_articleId = daoArticle.ArticleId;
				_articleCode = daoArticle.ArticleCode;
				_articleDate = daoArticle.ArticleDate;
				_articleTime = daoArticle.ArticleTime;
				_articleCategoryId = daoArticle.ArticleCategoryId;
				_articleTitleAr = daoArticle.ArticleTitleAr;
				_articleTitleEn = daoArticle.ArticleTitleEn;
				_isActive = daoArticle.IsActive;
				_articleImage = daoArticle.ArticleImage;
				_cBy = daoArticle.CBy;
				_cDate = daoArticle.CDate;
				_eBy = daoArticle.EBy;
				_eDate = daoArticle.EDate;
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
		///DAOArticle
		///</parameters>
		protected internal BOArticle(DAOArticle daoArticle)
		{
			try
			{
				_articleId = daoArticle.ArticleId;
				_articleCode = daoArticle.ArticleCode;
				_articleDate = daoArticle.ArticleDate;
				_articleTime = daoArticle.ArticleTime;
				_articleCategoryId = daoArticle.ArticleCategoryId;
				_articleTitleAr = daoArticle.ArticleTitleAr;
				_articleTitleEn = daoArticle.ArticleTitleEn;
				_isActive = daoArticle.IsActive;
				_articleImage = daoArticle.ArticleImage;
				_cBy = daoArticle.CBy;
				_cDate = daoArticle.CDate;
				_eBy = daoArticle.EBy;
				_eDate = daoArticle.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new Article record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOArticle daoArticle = new DAOArticle();
			RegisterDataObject(daoArticle);
			BeginTransaction("savenewBOArticle");
			try
			{
				daoArticle.ArticleCode = _articleCode;
				daoArticle.ArticleDate = _articleDate;
				daoArticle.ArticleTime = _articleTime;
				daoArticle.ArticleCategoryId = _articleCategoryId;
				daoArticle.ArticleTitleAr = _articleTitleAr;
				daoArticle.ArticleTitleEn = _articleTitleEn;
				daoArticle.IsActive = _isActive;
				daoArticle.ArticleImage = _articleImage;
				daoArticle.CBy = _cBy;
				daoArticle.CDate = _cDate;
				daoArticle.EBy = _eBy;
				daoArticle.EDate = _eDate;
				daoArticle.Insert();
				CommitTransaction();
				
				_articleId = daoArticle.ArticleId;
				_articleCode = daoArticle.ArticleCode;
				_articleDate = daoArticle.ArticleDate;
				_articleTime = daoArticle.ArticleTime;
				_articleCategoryId = daoArticle.ArticleCategoryId;
				_articleTitleAr = daoArticle.ArticleTitleAr;
				_articleTitleEn = daoArticle.ArticleTitleEn;
				_isActive = daoArticle.IsActive;
				_articleImage = daoArticle.ArticleImage;
				_cBy = daoArticle.CBy;
				_cDate = daoArticle.CDate;
				_eBy = daoArticle.EBy;
				_eDate = daoArticle.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOArticle");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one Article record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOArticle
		///</parameters>
		public virtual void Update()
		{
			DAOArticle daoArticle = new DAOArticle();
			RegisterDataObject(daoArticle);
			BeginTransaction("updateBOArticle");
			try
			{
				daoArticle.ArticleId = _articleId;
				daoArticle.ArticleCode = _articleCode;
				daoArticle.ArticleDate = _articleDate;
				daoArticle.ArticleTime = _articleTime;
				daoArticle.ArticleCategoryId = _articleCategoryId;
				daoArticle.ArticleTitleAr = _articleTitleAr;
				daoArticle.ArticleTitleEn = _articleTitleEn;
				daoArticle.IsActive = _isActive;
				daoArticle.ArticleImage = _articleImage;
				daoArticle.CBy = _cBy;
				daoArticle.CDate = _cDate;
				daoArticle.EBy = _eBy;
				daoArticle.EDate = _eDate;
				daoArticle.Update();
				CommitTransaction();
				
				_articleId = daoArticle.ArticleId;
				_articleCode = daoArticle.ArticleCode;
				_articleDate = daoArticle.ArticleDate;
				_articleTime = daoArticle.ArticleTime;
				_articleCategoryId = daoArticle.ArticleCategoryId;
				_articleTitleAr = daoArticle.ArticleTitleAr;
				_articleTitleEn = daoArticle.ArticleTitleEn;
				_isActive = daoArticle.IsActive;
				_articleImage = daoArticle.ArticleImage;
				_cBy = daoArticle.CBy;
				_cDate = daoArticle.CDate;
				_eBy = daoArticle.EBy;
				_eDate = daoArticle.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOArticle");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one Article record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOArticle daoArticle = new DAOArticle();
			RegisterDataObject(daoArticle);
			BeginTransaction("deleteBOArticle");
			try
			{
				daoArticle.ArticleId = _articleId;
				daoArticle.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOArticle");
				throw;
			}
		}
		
		///<Summary>
		///ArticleCollection
		///This method returns the collection of BOArticle objects
		///</Summary>
		///<returns>
		///List[BOArticle]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOArticle> ArticleCollection()
		{
			try
			{
				IList<BOArticle> boArticleCollection = new List<BOArticle>();
				IList<DAOArticle> daoArticleCollection = DAOArticle.SelectAll();
			
				foreach(DAOArticle daoArticle in daoArticleCollection)
					boArticleCollection.Add(new BOArticle(daoArticle));
			
				return boArticleCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ArticleCollectionCount
		///This method returns the collection count of BOArticle objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ArticleCollectionCount()
		{
			try
			{
				Int32 objCount = DAOArticle.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///ArticleDetailCollection
		///This method returns its collection of BOArticleDetail objects
		///</Summary>
		///<returns>
		///IList[BOArticleDetail]
		///</returns>
		///<parameters>
		///BOArticle
		///</parameters>
		public virtual IList<BOArticleDetail> ArticleDetailCollection()
		{
			try
			{
				if(_boArticleDetailCollection == null)
					LoadArticleDetailCollection();
				
				return _boArticleDetailCollection.AsReadOnly();
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
		///List<BOArticle>
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
				IDictionary<string, IList<object>> retObj = DAOArticle.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ArticleCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOArticle objects, filtered by optional criteria
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
				IList<T> boArticleCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOArticle> daoArticleCollection = DAOArticle.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOArticle resdaoArticle in daoArticleCollection)
					boArticleCollection.Add((T)(object)new BOArticle(resdaoArticle));
			
				return boArticleCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ArticleCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOArticle objects, filtered by optional criteria
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
				Int32 objCount = DAOArticle.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadArticleDetailCollection
		///This method loads the internal collection of BOArticleDetail objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadArticleDetailCollection()
		{
			try
			{
				_boArticleDetailCollection = new List<BOArticleDetail>();
				IList<DAOArticleDetail> daoArticleDetailCollection = DAOArticleDetail.SelectAllByArticleId(_articleId.Value);
				
				foreach(DAOArticleDetail daoArticleDetail in daoArticleDetailCollection)
					_boArticleDetailCollection.Add(new BOArticleDetail(daoArticleDetail));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddArticleDetail
		///This method persists a BOArticleDetail object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOArticleDetail
		///</parameters>
		public virtual void AddArticleDetail(BOArticleDetail boArticleDetail)
		{
			DAOArticleDetail daoArticleDetail = new DAOArticleDetail();
			RegisterDataObject(daoArticleDetail);
			BeginTransaction("addArticleDetail");
			try
			{
				daoArticleDetail.DetailId = boArticleDetail.DetailId;
				daoArticleDetail.ArticleContentAr = boArticleDetail.ArticleContentAr;
				daoArticleDetail.ArticleContentEn = boArticleDetail.ArticleContentEn;
				daoArticleDetail.ArticleId = _articleId.Value;
				daoArticleDetail.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boArticleDetail = new BOArticleDetail(daoArticleDetail);
				if(_boArticleDetailCollection != null)
					_boArticleDetailCollection.Add(boArticleDetail);
			}
			catch
			{
				RollbackTransaction("addArticleDetail");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllArticleDetail
		///This method deletes all BOArticleDetail objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllArticleDetail()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllArticleDetail");
			try
			{
				DAOArticleDetail.DeleteAllByArticleId(ConnectionProvider, _articleId.Value);
				CommitTransaction();
				if(_boArticleDetailCollection != null)
				{
					_boArticleDetailCollection.Clear();
					_boArticleDetailCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllArticleDetail");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? ArticleId
		{
			get
			{
				 return _articleId;
			}
			set
			{
				_articleId = value;
				_isDirty = true;
			}
		}
		
		public virtual string ArticleCode
		{
			get
			{
				 return _articleCode;
			}
			set
			{
				_articleCode = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? ArticleDate
		{
			get
			{
				 return _articleDate;
			}
			set
			{
				_articleDate = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? ArticleTime
		{
			get
			{
				 return _articleTime;
			}
			set
			{
				_articleTime = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ArticleCategoryId
		{
			get
			{
				 return _articleCategoryId;
			}
			set
			{
				_articleCategoryId = value;
				_isDirty = true;
			}
		}
		
		public virtual string ArticleTitleAr
		{
			get
			{
				 return _articleTitleAr;
			}
			set
			{
				_articleTitleAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string ArticleTitleEn
		{
			get
			{
				 return _articleTitleEn;
			}
			set
			{
				_articleTitleEn = value;
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
		
		public virtual string ArticleImage
		{
			get
			{
				 return _articleImage;
			}
			set
			{
				_articleImage = value;
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