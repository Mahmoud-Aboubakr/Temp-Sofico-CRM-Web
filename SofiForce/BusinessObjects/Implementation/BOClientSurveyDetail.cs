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
	///This is the definition of the class BOClientSurveyDetail.
	///It maintains a collection of BOClientSurveyDetailAnswer objects.
	///</Summary>
	public partial class BOClientSurveyDetail : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int64? _clientDetailId;
		protected Int64? _clientServeyId;
		protected Int32? _surveyDetailId;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOClientSurveyDetailAnswer> _boClientSurveyDetailAnswerCollection;
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
		public BOClientSurveyDetail()
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
		///Int64 clientDetailId
		///</parameters>
		public BOClientSurveyDetail(Int64 clientDetailId)
		{
			try
			{
				DAOClientSurveyDetail daoClientSurveyDetail = DAOClientSurveyDetail.SelectOne(clientDetailId);
				_clientDetailId = daoClientSurveyDetail.ClientDetailId;
				_clientServeyId = daoClientSurveyDetail.ClientServeyId;
				_surveyDetailId = daoClientSurveyDetail.SurveyDetailId;
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
		///DAOClientSurveyDetail
		///</parameters>
		protected internal BOClientSurveyDetail(DAOClientSurveyDetail daoClientSurveyDetail)
		{
			try
			{
				_clientDetailId = daoClientSurveyDetail.ClientDetailId;
				_clientServeyId = daoClientSurveyDetail.ClientServeyId;
				_surveyDetailId = daoClientSurveyDetail.SurveyDetailId;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new ClientSurveyDetail record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOClientSurveyDetail daoClientSurveyDetail = new DAOClientSurveyDetail();
			RegisterDataObject(daoClientSurveyDetail);
			BeginTransaction("savenewBOClientSurveyDetail");
			try
			{
				daoClientSurveyDetail.ClientServeyId = _clientServeyId;
				daoClientSurveyDetail.SurveyDetailId = _surveyDetailId;
				daoClientSurveyDetail.Insert();
				CommitTransaction();
				
				_clientDetailId = daoClientSurveyDetail.ClientDetailId;
				_clientServeyId = daoClientSurveyDetail.ClientServeyId;
				_surveyDetailId = daoClientSurveyDetail.SurveyDetailId;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOClientSurveyDetail");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one ClientSurveyDetail record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOClientSurveyDetail
		///</parameters>
		public virtual void Update()
		{
			DAOClientSurveyDetail daoClientSurveyDetail = new DAOClientSurveyDetail();
			RegisterDataObject(daoClientSurveyDetail);
			BeginTransaction("updateBOClientSurveyDetail");
			try
			{
				daoClientSurveyDetail.ClientDetailId = _clientDetailId;
				daoClientSurveyDetail.ClientServeyId = _clientServeyId;
				daoClientSurveyDetail.SurveyDetailId = _surveyDetailId;
				daoClientSurveyDetail.Update();
				CommitTransaction();
				
				_clientDetailId = daoClientSurveyDetail.ClientDetailId;
				_clientServeyId = daoClientSurveyDetail.ClientServeyId;
				_surveyDetailId = daoClientSurveyDetail.SurveyDetailId;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOClientSurveyDetail");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one ClientSurveyDetail record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOClientSurveyDetail daoClientSurveyDetail = new DAOClientSurveyDetail();
			RegisterDataObject(daoClientSurveyDetail);
			BeginTransaction("deleteBOClientSurveyDetail");
			try
			{
				daoClientSurveyDetail.ClientDetailId = _clientDetailId;
				daoClientSurveyDetail.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOClientSurveyDetail");
				throw;
			}
		}
		
		///<Summary>
		///ClientSurveyDetailCollection
		///This method returns the collection of BOClientSurveyDetail objects
		///</Summary>
		///<returns>
		///List[BOClientSurveyDetail]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOClientSurveyDetail> ClientSurveyDetailCollection()
		{
			try
			{
				IList<BOClientSurveyDetail> boClientSurveyDetailCollection = new List<BOClientSurveyDetail>();
				IList<DAOClientSurveyDetail> daoClientSurveyDetailCollection = DAOClientSurveyDetail.SelectAll();
			
				foreach(DAOClientSurveyDetail daoClientSurveyDetail in daoClientSurveyDetailCollection)
					boClientSurveyDetailCollection.Add(new BOClientSurveyDetail(daoClientSurveyDetail));
			
				return boClientSurveyDetailCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientSurveyDetailCollectionCount
		///This method returns the collection count of BOClientSurveyDetail objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ClientSurveyDetailCollectionCount()
		{
			try
			{
				Int32 objCount = DAOClientSurveyDetail.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///ClientSurveyDetailAnswerCollection
		///This method returns its collection of BOClientSurveyDetailAnswer objects
		///</Summary>
		///<returns>
		///IList[BOClientSurveyDetailAnswer]
		///</returns>
		///<parameters>
		///BOClientSurveyDetail
		///</parameters>
		public virtual IList<BOClientSurveyDetailAnswer> ClientSurveyDetailAnswerCollection()
		{
			try
			{
				if(_boClientSurveyDetailAnswerCollection == null)
					LoadClientSurveyDetailAnswerCollection();
				
				return _boClientSurveyDetailAnswerCollection.AsReadOnly();
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
		///List<BOClientSurveyDetail>
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
				IDictionary<string, IList<object>> retObj = DAOClientSurveyDetail.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientSurveyDetailCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOClientSurveyDetail objects, filtered by optional criteria
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
				IList<T> boClientSurveyDetailCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOClientSurveyDetail> daoClientSurveyDetailCollection = DAOClientSurveyDetail.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOClientSurveyDetail resdaoClientSurveyDetail in daoClientSurveyDetailCollection)
					boClientSurveyDetailCollection.Add((T)(object)new BOClientSurveyDetail(resdaoClientSurveyDetail));
			
				return boClientSurveyDetailCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientSurveyDetailCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOClientSurveyDetail objects, filtered by optional criteria
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
				Int32 objCount = DAOClientSurveyDetail.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadClientSurveyDetailAnswerCollection
		///This method loads the internal collection of BOClientSurveyDetailAnswer objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadClientSurveyDetailAnswerCollection()
		{
			try
			{
				_boClientSurveyDetailAnswerCollection = new List<BOClientSurveyDetailAnswer>();
				IList<DAOClientSurveyDetailAnswer> daoClientSurveyDetailAnswerCollection = DAOClientSurveyDetailAnswer.SelectAllByClientDetailId(_clientDetailId.Value);
				
				foreach(DAOClientSurveyDetailAnswer daoClientSurveyDetailAnswer in daoClientSurveyDetailAnswerCollection)
					_boClientSurveyDetailAnswerCollection.Add(new BOClientSurveyDetailAnswer(daoClientSurveyDetailAnswer));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddClientSurveyDetailAnswer
		///This method persists a BOClientSurveyDetailAnswer object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOClientSurveyDetailAnswer
		///</parameters>
		public virtual void AddClientSurveyDetailAnswer(BOClientSurveyDetailAnswer boClientSurveyDetailAnswer)
		{
			DAOClientSurveyDetailAnswer daoClientSurveyDetailAnswer = new DAOClientSurveyDetailAnswer();
			RegisterDataObject(daoClientSurveyDetailAnswer);
			BeginTransaction("addClientSurveyDetailAnswer");
			try
			{
				daoClientSurveyDetailAnswer.ClientAnswerId = boClientSurveyDetailAnswer.ClientAnswerId;
				daoClientSurveyDetailAnswer.DetailAnswerId = boClientSurveyDetailAnswer.DetailAnswerId;
				daoClientSurveyDetailAnswer.IsSelected = boClientSurveyDetailAnswer.IsSelected;
				daoClientSurveyDetailAnswer.ClientServeyId = boClientSurveyDetailAnswer.ClientServeyId;
				daoClientSurveyDetailAnswer.SurveyDetailId = boClientSurveyDetailAnswer.SurveyDetailId;
				daoClientSurveyDetailAnswer.ClientDetailId = _clientDetailId.Value;
				daoClientSurveyDetailAnswer.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boClientSurveyDetailAnswer = new BOClientSurveyDetailAnswer(daoClientSurveyDetailAnswer);
				if(_boClientSurveyDetailAnswerCollection != null)
					_boClientSurveyDetailAnswerCollection.Add(boClientSurveyDetailAnswer);
			}
			catch
			{
				RollbackTransaction("addClientSurveyDetailAnswer");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllClientSurveyDetailAnswer
		///This method deletes all BOClientSurveyDetailAnswer objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllClientSurveyDetailAnswer()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllClientSurveyDetailA9728");
			try
			{
				DAOClientSurveyDetailAnswer.DeleteAllByClientDetailId(ConnectionProvider, _clientDetailId.Value);
				CommitTransaction();
				if(_boClientSurveyDetailAnswerCollection != null)
				{
					_boClientSurveyDetailAnswerCollection.Clear();
					_boClientSurveyDetailAnswerCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllClientSurveyDetailA9728");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int64? ClientDetailId
		{
			get
			{
				 return _clientDetailId;
			}
			set
			{
				_clientDetailId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int64? ClientServeyId
		{
			get
			{
				 return _clientServeyId;
			}
			set
			{
				_clientServeyId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? SurveyDetailId
		{
			get
			{
				 return _surveyDetailId;
			}
			set
			{
				_surveyDetailId = value;
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
