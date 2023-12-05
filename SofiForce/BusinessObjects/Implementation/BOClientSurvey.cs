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
	///This is the definition of the class BOClientSurvey.
	///It maintains a collection of BOClientSurveyDetailAnswer,BOClientSurveyDetail objects.
	///</Summary>
	public partial class BOClientSurvey : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int64? _clientServeyId;
		protected Int32? _surveyId;
		protected Int32? _branchId;
		protected Int32? _clientId;
		protected Int32? _representativeId;
		protected Int32? _serveyStatusId;
		protected DateTime? _createDate;
		protected DateTime? _createTime;
		protected DateTime? _startDate;
		protected DateTime? _startTime;
		protected bool? _isClosed;
		protected string _notes;
		protected double? _latitude;
		protected double? _longitude;
		protected bool? _inZone;
		protected double? _distance;
		protected bool? _canDelete;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOClientSurveyDetailAnswer> _boClientSurveyDetailAnswerCollection;
		List<BOClientSurveyDetail> _boClientSurveyDetailCollection;
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
		public BOClientSurvey()
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
		///Int64 clientServeyId
		///</parameters>
		public BOClientSurvey(Int64 clientServeyId)
		{
			try
			{
				DAOClientSurvey daoClientSurvey = DAOClientSurvey.SelectOne(clientServeyId);
				_clientServeyId = daoClientSurvey.ClientServeyId;
				_surveyId = daoClientSurvey.SurveyId;
				_branchId = daoClientSurvey.BranchId;
				_clientId = daoClientSurvey.ClientId;
				_representativeId = daoClientSurvey.RepresentativeId;
				_serveyStatusId = daoClientSurvey.ServeyStatusId;
				_createDate = daoClientSurvey.CreateDate;
				_createTime = daoClientSurvey.CreateTime;
				_startDate = daoClientSurvey.StartDate;
				_startTime = daoClientSurvey.StartTime;
				_isClosed = daoClientSurvey.IsClosed;
				_notes = daoClientSurvey.Notes;
				_latitude = daoClientSurvey.Latitude;
				_longitude = daoClientSurvey.Longitude;
				_inZone = daoClientSurvey.InZone;
				_distance = daoClientSurvey.Distance;
				_canDelete = daoClientSurvey.CanDelete;
				_cBy = daoClientSurvey.CBy;
				_cDate = daoClientSurvey.CDate;
				_eBy = daoClientSurvey.EBy;
				_eDate = daoClientSurvey.EDate;
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
		///DAOClientSurvey
		///</parameters>
		protected internal BOClientSurvey(DAOClientSurvey daoClientSurvey)
		{
			try
			{
				_clientServeyId = daoClientSurvey.ClientServeyId;
				_surveyId = daoClientSurvey.SurveyId;
				_branchId = daoClientSurvey.BranchId;
				_clientId = daoClientSurvey.ClientId;
				_representativeId = daoClientSurvey.RepresentativeId;
				_serveyStatusId = daoClientSurvey.ServeyStatusId;
				_createDate = daoClientSurvey.CreateDate;
				_createTime = daoClientSurvey.CreateTime;
				_startDate = daoClientSurvey.StartDate;
				_startTime = daoClientSurvey.StartTime;
				_isClosed = daoClientSurvey.IsClosed;
				_notes = daoClientSurvey.Notes;
				_latitude = daoClientSurvey.Latitude;
				_longitude = daoClientSurvey.Longitude;
				_inZone = daoClientSurvey.InZone;
				_distance = daoClientSurvey.Distance;
				_canDelete = daoClientSurvey.CanDelete;
				_cBy = daoClientSurvey.CBy;
				_cDate = daoClientSurvey.CDate;
				_eBy = daoClientSurvey.EBy;
				_eDate = daoClientSurvey.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new ClientSurvey record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOClientSurvey daoClientSurvey = new DAOClientSurvey();
			RegisterDataObject(daoClientSurvey);
			BeginTransaction("savenewBOClientSurvey");
			try
			{
				daoClientSurvey.SurveyId = _surveyId;
				daoClientSurvey.BranchId = _branchId;
				daoClientSurvey.ClientId = _clientId;
				daoClientSurvey.RepresentativeId = _representativeId;
				daoClientSurvey.ServeyStatusId = _serveyStatusId;
				daoClientSurvey.CreateDate = _createDate;
				daoClientSurvey.CreateTime = _createTime;
				daoClientSurvey.StartDate = _startDate;
				daoClientSurvey.StartTime = _startTime;
				daoClientSurvey.IsClosed = _isClosed;
				daoClientSurvey.Notes = _notes;
				daoClientSurvey.Latitude = _latitude;
				daoClientSurvey.Longitude = _longitude;
				daoClientSurvey.InZone = _inZone;
				daoClientSurvey.Distance = _distance;
				daoClientSurvey.CanDelete = _canDelete;
				daoClientSurvey.CBy = _cBy;
				daoClientSurvey.CDate = _cDate;
				daoClientSurvey.EBy = _eBy;
				daoClientSurvey.EDate = _eDate;
				daoClientSurvey.Insert();
				CommitTransaction();
				
				_clientServeyId = daoClientSurvey.ClientServeyId;
				_surveyId = daoClientSurvey.SurveyId;
				_branchId = daoClientSurvey.BranchId;
				_clientId = daoClientSurvey.ClientId;
				_representativeId = daoClientSurvey.RepresentativeId;
				_serveyStatusId = daoClientSurvey.ServeyStatusId;
				_createDate = daoClientSurvey.CreateDate;
				_createTime = daoClientSurvey.CreateTime;
				_startDate = daoClientSurvey.StartDate;
				_startTime = daoClientSurvey.StartTime;
				_isClosed = daoClientSurvey.IsClosed;
				_notes = daoClientSurvey.Notes;
				_latitude = daoClientSurvey.Latitude;
				_longitude = daoClientSurvey.Longitude;
				_inZone = daoClientSurvey.InZone;
				_distance = daoClientSurvey.Distance;
				_canDelete = daoClientSurvey.CanDelete;
				_cBy = daoClientSurvey.CBy;
				_cDate = daoClientSurvey.CDate;
				_eBy = daoClientSurvey.EBy;
				_eDate = daoClientSurvey.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOClientSurvey");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one ClientSurvey record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOClientSurvey
		///</parameters>
		public virtual void Update()
		{
			DAOClientSurvey daoClientSurvey = new DAOClientSurvey();
			RegisterDataObject(daoClientSurvey);
			BeginTransaction("updateBOClientSurvey");
			try
			{
				daoClientSurvey.ClientServeyId = _clientServeyId;
				daoClientSurvey.SurveyId = _surveyId;
				daoClientSurvey.BranchId = _branchId;
				daoClientSurvey.ClientId = _clientId;
				daoClientSurvey.RepresentativeId = _representativeId;
				daoClientSurvey.ServeyStatusId = _serveyStatusId;
				daoClientSurvey.CreateDate = _createDate;
				daoClientSurvey.CreateTime = _createTime;
				daoClientSurvey.StartDate = _startDate;
				daoClientSurvey.StartTime = _startTime;
				daoClientSurvey.IsClosed = _isClosed;
				daoClientSurvey.Notes = _notes;
				daoClientSurvey.Latitude = _latitude;
				daoClientSurvey.Longitude = _longitude;
				daoClientSurvey.InZone = _inZone;
				daoClientSurvey.Distance = _distance;
				daoClientSurvey.CanDelete = _canDelete;
				daoClientSurvey.CBy = _cBy;
				daoClientSurvey.CDate = _cDate;
				daoClientSurvey.EBy = _eBy;
				daoClientSurvey.EDate = _eDate;
				daoClientSurvey.Update();
				CommitTransaction();
				
				_clientServeyId = daoClientSurvey.ClientServeyId;
				_surveyId = daoClientSurvey.SurveyId;
				_branchId = daoClientSurvey.BranchId;
				_clientId = daoClientSurvey.ClientId;
				_representativeId = daoClientSurvey.RepresentativeId;
				_serveyStatusId = daoClientSurvey.ServeyStatusId;
				_createDate = daoClientSurvey.CreateDate;
				_createTime = daoClientSurvey.CreateTime;
				_startDate = daoClientSurvey.StartDate;
				_startTime = daoClientSurvey.StartTime;
				_isClosed = daoClientSurvey.IsClosed;
				_notes = daoClientSurvey.Notes;
				_latitude = daoClientSurvey.Latitude;
				_longitude = daoClientSurvey.Longitude;
				_inZone = daoClientSurvey.InZone;
				_distance = daoClientSurvey.Distance;
				_canDelete = daoClientSurvey.CanDelete;
				_cBy = daoClientSurvey.CBy;
				_cDate = daoClientSurvey.CDate;
				_eBy = daoClientSurvey.EBy;
				_eDate = daoClientSurvey.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOClientSurvey");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one ClientSurvey record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOClientSurvey daoClientSurvey = new DAOClientSurvey();
			RegisterDataObject(daoClientSurvey);
			BeginTransaction("deleteBOClientSurvey");
			try
			{
				daoClientSurvey.ClientServeyId = _clientServeyId;
				daoClientSurvey.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOClientSurvey");
				throw;
			}
		}
		
		///<Summary>
		///ClientSurveyCollection
		///This method returns the collection of BOClientSurvey objects
		///</Summary>
		///<returns>
		///List[BOClientSurvey]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOClientSurvey> ClientSurveyCollection()
		{
			try
			{
				IList<BOClientSurvey> boClientSurveyCollection = new List<BOClientSurvey>();
				IList<DAOClientSurvey> daoClientSurveyCollection = DAOClientSurvey.SelectAll();
			
				foreach(DAOClientSurvey daoClientSurvey in daoClientSurveyCollection)
					boClientSurveyCollection.Add(new BOClientSurvey(daoClientSurvey));
			
				return boClientSurveyCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientSurveyCollectionCount
		///This method returns the collection count of BOClientSurvey objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ClientSurveyCollectionCount()
		{
			try
			{
				Int32 objCount = DAOClientSurvey.SelectAllCount();
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
		///BOClientSurvey
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
		///ClientSurveyDetailCollection
		///This method returns its collection of BOClientSurveyDetail objects
		///</Summary>
		///<returns>
		///IList[BOClientSurveyDetail]
		///</returns>
		///<parameters>
		///BOClientSurvey
		///</parameters>
		public virtual IList<BOClientSurveyDetail> ClientSurveyDetailCollection()
		{
			try
			{
				if(_boClientSurveyDetailCollection == null)
					LoadClientSurveyDetailCollection();
				
				return _boClientSurveyDetailCollection.AsReadOnly();
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
		///List<BOClientSurvey>
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
				IDictionary<string, IList<object>> retObj = DAOClientSurvey.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientSurveyCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOClientSurvey objects, filtered by optional criteria
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
				IList<T> boClientSurveyCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOClientSurvey> daoClientSurveyCollection = DAOClientSurvey.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOClientSurvey resdaoClientSurvey in daoClientSurveyCollection)
					boClientSurveyCollection.Add((T)(object)new BOClientSurvey(resdaoClientSurvey));
			
				return boClientSurveyCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientSurveyCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOClientSurvey objects, filtered by optional criteria
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
				Int32 objCount = DAOClientSurvey.SelectAllByCriteriaCount(lstDataCriteria);
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
				IList<DAOClientSurveyDetailAnswer> daoClientSurveyDetailAnswerCollection = DAOClientSurveyDetailAnswer.SelectAllByClientServeyId(_clientServeyId.Value);
				
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
				daoClientSurveyDetailAnswer.ClientDetailId = boClientSurveyDetailAnswer.ClientDetailId;
				daoClientSurveyDetailAnswer.DetailAnswerId = boClientSurveyDetailAnswer.DetailAnswerId;
				daoClientSurveyDetailAnswer.IsSelected = boClientSurveyDetailAnswer.IsSelected;
				daoClientSurveyDetailAnswer.SurveyDetailId = boClientSurveyDetailAnswer.SurveyDetailId;
				daoClientSurveyDetailAnswer.ClientServeyId = _clientServeyId.Value;
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
			BeginTransaction("deleteAllClientSurveyDetailA2528");
			try
			{
				DAOClientSurveyDetailAnswer.DeleteAllByClientServeyId(ConnectionProvider, _clientServeyId.Value);
				CommitTransaction();
				if(_boClientSurveyDetailAnswerCollection != null)
				{
					_boClientSurveyDetailAnswerCollection.Clear();
					_boClientSurveyDetailAnswerCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllClientSurveyDetailA2528");
				throw;
			}
		}
		
		///<Summary>
		///LoadClientSurveyDetailCollection
		///This method loads the internal collection of BOClientSurveyDetail objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadClientSurveyDetailCollection()
		{
			try
			{
				_boClientSurveyDetailCollection = new List<BOClientSurveyDetail>();
				IList<DAOClientSurveyDetail> daoClientSurveyDetailCollection = DAOClientSurveyDetail.SelectAllByClientServeyId(_clientServeyId.Value);
				
				foreach(DAOClientSurveyDetail daoClientSurveyDetail in daoClientSurveyDetailCollection)
					_boClientSurveyDetailCollection.Add(new BOClientSurveyDetail(daoClientSurveyDetail));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddClientSurveyDetail
		///This method persists a BOClientSurveyDetail object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOClientSurveyDetail
		///</parameters>
		public virtual void AddClientSurveyDetail(BOClientSurveyDetail boClientSurveyDetail)
		{
			DAOClientSurveyDetail daoClientSurveyDetail = new DAOClientSurveyDetail();
			RegisterDataObject(daoClientSurveyDetail);
			BeginTransaction("addClientSurveyDetail");
			try
			{
				daoClientSurveyDetail.ClientDetailId = boClientSurveyDetail.ClientDetailId;
				daoClientSurveyDetail.SurveyDetailId = boClientSurveyDetail.SurveyDetailId;
				daoClientSurveyDetail.ClientServeyId = _clientServeyId.Value;
				daoClientSurveyDetail.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boClientSurveyDetail = new BOClientSurveyDetail(daoClientSurveyDetail);
				if(_boClientSurveyDetailCollection != null)
					_boClientSurveyDetailCollection.Add(boClientSurveyDetail);
			}
			catch
			{
				RollbackTransaction("addClientSurveyDetail");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllClientSurveyDetail
		///This method deletes all BOClientSurveyDetail objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllClientSurveyDetail()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllClientSurveyDetail");
			try
			{
				DAOClientSurveyDetail.DeleteAllByClientServeyId(ConnectionProvider, _clientServeyId.Value);
				CommitTransaction();
				if(_boClientSurveyDetailCollection != null)
				{
					_boClientSurveyDetailCollection.Clear();
					_boClientSurveyDetailCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllClientSurveyDetail");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
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
		
		public virtual Int32? SurveyId
		{
			get
			{
				 return _surveyId;
			}
			set
			{
				_surveyId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? BranchId
		{
			get
			{
				 return _branchId;
			}
			set
			{
				_branchId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ClientId
		{
			get
			{
				 return _clientId;
			}
			set
			{
				_clientId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? RepresentativeId
		{
			get
			{
				 return _representativeId;
			}
			set
			{
				_representativeId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ServeyStatusId
		{
			get
			{
				 return _serveyStatusId;
			}
			set
			{
				_serveyStatusId = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? CreateDate
		{
			get
			{
				 return _createDate;
			}
			set
			{
				_createDate = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? CreateTime
		{
			get
			{
				 return _createTime;
			}
			set
			{
				_createTime = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? StartDate
		{
			get
			{
				 return _startDate;
			}
			set
			{
				_startDate = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? StartTime
		{
			get
			{
				 return _startTime;
			}
			set
			{
				_startTime = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? IsClosed
		{
			get
			{
				 return _isClosed;
			}
			set
			{
				_isClosed = value;
				_isDirty = true;
			}
		}
		
		public virtual string Notes
		{
			get
			{
				 return _notes;
			}
			set
			{
				_notes = value;
				_isDirty = true;
			}
		}
		
		public virtual double? Latitude
		{
			get
			{
				 return _latitude;
			}
			set
			{
				_latitude = value;
				_isDirty = true;
			}
		}
		
		public virtual double? Longitude
		{
			get
			{
				 return _longitude;
			}
			set
			{
				_longitude = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? InZone
		{
			get
			{
				 return _inZone;
			}
			set
			{
				_inZone = value;
				_isDirty = true;
			}
		}
		
		public virtual double? Distance
		{
			get
			{
				 return _distance;
			}
			set
			{
				_distance = value;
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
