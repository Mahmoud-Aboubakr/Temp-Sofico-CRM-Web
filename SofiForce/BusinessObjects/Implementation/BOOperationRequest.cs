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
	///This is the definition of the class BOOperationRequest.
	///It maintains a collection of BOOperationRequestDetail objects.
	///</Summary>
	public partial class BOOperationRequest : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _operationId;
		protected string _operationCode;
		protected Int32? _agentId;
		protected Int32? _operationTypeId;
		protected Int32? _governerateId;
		protected Int32? _representativeId;
		protected DateTime? _operationDate;
		protected DateTime? _startDate;
		protected Int32? _targetDays;
		protected Int32? _actualDays;
		protected Int32? _targetClients;
		protected Int32? _actualClients;
		protected decimal? _daysPerformance;
		protected decimal? _clientsPerformance;
		protected decimal? _accuracy;
		protected string _mapPoints;
		protected bool? _isClosed;
		protected DateTime? _closeDate;
		protected string _notes;
		protected Int32? _cBy;
		protected Int32? _eBy;
		protected DateTime? _cDate;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOOperationRequestDetail> _boOperationRequestDetailCollection;
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
		public BOOperationRequest()
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
		///Int32 operationId
		///</parameters>
		public BOOperationRequest(Int32 operationId)
		{
			try
			{
				DAOOperationRequest daoOperationRequest = DAOOperationRequest.SelectOne(operationId);
				_operationId = daoOperationRequest.OperationId;
				_operationCode = daoOperationRequest.OperationCode;
				_agentId = daoOperationRequest.AgentId;
				_operationTypeId = daoOperationRequest.OperationTypeId;
				_governerateId = daoOperationRequest.GovernerateId;
				_representativeId = daoOperationRequest.RepresentativeId;
				_operationDate = daoOperationRequest.OperationDate;
				_startDate = daoOperationRequest.StartDate;
				_targetDays = daoOperationRequest.TargetDays;
				_actualDays = daoOperationRequest.ActualDays;
				_targetClients = daoOperationRequest.TargetClients;
				_actualClients = daoOperationRequest.ActualClients;
				_daysPerformance = daoOperationRequest.DaysPerformance;
				_clientsPerformance = daoOperationRequest.ClientsPerformance;
				_accuracy = daoOperationRequest.Accuracy;
				_mapPoints = daoOperationRequest.MapPoints;
				_isClosed = daoOperationRequest.IsClosed;
				_closeDate = daoOperationRequest.CloseDate;
				_notes = daoOperationRequest.Notes;
				_cBy = daoOperationRequest.CBy;
				_eBy = daoOperationRequest.EBy;
				_cDate = daoOperationRequest.CDate;
				_eDate = daoOperationRequest.EDate;
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
		///DAOOperationRequest
		///</parameters>
		protected internal BOOperationRequest(DAOOperationRequest daoOperationRequest)
		{
			try
			{
				_operationId = daoOperationRequest.OperationId;
				_operationCode = daoOperationRequest.OperationCode;
				_agentId = daoOperationRequest.AgentId;
				_operationTypeId = daoOperationRequest.OperationTypeId;
				_governerateId = daoOperationRequest.GovernerateId;
				_representativeId = daoOperationRequest.RepresentativeId;
				_operationDate = daoOperationRequest.OperationDate;
				_startDate = daoOperationRequest.StartDate;
				_targetDays = daoOperationRequest.TargetDays;
				_actualDays = daoOperationRequest.ActualDays;
				_targetClients = daoOperationRequest.TargetClients;
				_actualClients = daoOperationRequest.ActualClients;
				_daysPerformance = daoOperationRequest.DaysPerformance;
				_clientsPerformance = daoOperationRequest.ClientsPerformance;
				_accuracy = daoOperationRequest.Accuracy;
				_mapPoints = daoOperationRequest.MapPoints;
				_isClosed = daoOperationRequest.IsClosed;
				_closeDate = daoOperationRequest.CloseDate;
				_notes = daoOperationRequest.Notes;
				_cBy = daoOperationRequest.CBy;
				_eBy = daoOperationRequest.EBy;
				_cDate = daoOperationRequest.CDate;
				_eDate = daoOperationRequest.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new OperationRequest record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOOperationRequest daoOperationRequest = new DAOOperationRequest();
			RegisterDataObject(daoOperationRequest);
			BeginTransaction("savenewBOOperationRequest");
			try
			{
				daoOperationRequest.OperationCode = _operationCode;
				daoOperationRequest.AgentId = _agentId;
				daoOperationRequest.OperationTypeId = _operationTypeId;
				daoOperationRequest.GovernerateId = _governerateId;
				daoOperationRequest.RepresentativeId = _representativeId;
				daoOperationRequest.OperationDate = _operationDate;
				daoOperationRequest.StartDate = _startDate;
				daoOperationRequest.TargetDays = _targetDays;
				daoOperationRequest.ActualDays = _actualDays;
				daoOperationRequest.TargetClients = _targetClients;
				daoOperationRequest.ActualClients = _actualClients;
				daoOperationRequest.DaysPerformance = _daysPerformance;
				daoOperationRequest.ClientsPerformance = _clientsPerformance;
				daoOperationRequest.Accuracy = _accuracy;
				daoOperationRequest.MapPoints = _mapPoints;
				daoOperationRequest.IsClosed = _isClosed;
				daoOperationRequest.CloseDate = _closeDate;
				daoOperationRequest.Notes = _notes;
				daoOperationRequest.CBy = _cBy;
				daoOperationRequest.EBy = _eBy;
				daoOperationRequest.CDate = _cDate;
				daoOperationRequest.EDate = _eDate;
				daoOperationRequest.Insert();
				CommitTransaction();
				
				_operationId = daoOperationRequest.OperationId;
				_operationCode = daoOperationRequest.OperationCode;
				_agentId = daoOperationRequest.AgentId;
				_operationTypeId = daoOperationRequest.OperationTypeId;
				_governerateId = daoOperationRequest.GovernerateId;
				_representativeId = daoOperationRequest.RepresentativeId;
				_operationDate = daoOperationRequest.OperationDate;
				_startDate = daoOperationRequest.StartDate;
				_targetDays = daoOperationRequest.TargetDays;
				_actualDays = daoOperationRequest.ActualDays;
				_targetClients = daoOperationRequest.TargetClients;
				_actualClients = daoOperationRequest.ActualClients;
				_daysPerformance = daoOperationRequest.DaysPerformance;
				_clientsPerformance = daoOperationRequest.ClientsPerformance;
				_accuracy = daoOperationRequest.Accuracy;
				_mapPoints = daoOperationRequest.MapPoints;
				_isClosed = daoOperationRequest.IsClosed;
				_closeDate = daoOperationRequest.CloseDate;
				_notes = daoOperationRequest.Notes;
				_cBy = daoOperationRequest.CBy;
				_eBy = daoOperationRequest.EBy;
				_cDate = daoOperationRequest.CDate;
				_eDate = daoOperationRequest.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOOperationRequest");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one OperationRequest record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOOperationRequest
		///</parameters>
		public virtual void Update()
		{
			DAOOperationRequest daoOperationRequest = new DAOOperationRequest();
			RegisterDataObject(daoOperationRequest);
			BeginTransaction("updateBOOperationRequest");
			try
			{
				daoOperationRequest.OperationId = _operationId;
				daoOperationRequest.OperationCode = _operationCode;
				daoOperationRequest.AgentId = _agentId;
				daoOperationRequest.OperationTypeId = _operationTypeId;
				daoOperationRequest.GovernerateId = _governerateId;
				daoOperationRequest.RepresentativeId = _representativeId;
				daoOperationRequest.OperationDate = _operationDate;
				daoOperationRequest.StartDate = _startDate;
				daoOperationRequest.TargetDays = _targetDays;
				daoOperationRequest.ActualDays = _actualDays;
				daoOperationRequest.TargetClients = _targetClients;
				daoOperationRequest.ActualClients = _actualClients;
				daoOperationRequest.DaysPerformance = _daysPerformance;
				daoOperationRequest.ClientsPerformance = _clientsPerformance;
				daoOperationRequest.Accuracy = _accuracy;
				daoOperationRequest.MapPoints = _mapPoints;
				daoOperationRequest.IsClosed = _isClosed;
				daoOperationRequest.CloseDate = _closeDate;
				daoOperationRequest.Notes = _notes;
				daoOperationRequest.CBy = _cBy;
				daoOperationRequest.EBy = _eBy;
				daoOperationRequest.CDate = _cDate;
				daoOperationRequest.EDate = _eDate;
				daoOperationRequest.Update();
				CommitTransaction();
				
				_operationId = daoOperationRequest.OperationId;
				_operationCode = daoOperationRequest.OperationCode;
				_agentId = daoOperationRequest.AgentId;
				_operationTypeId = daoOperationRequest.OperationTypeId;
				_governerateId = daoOperationRequest.GovernerateId;
				_representativeId = daoOperationRequest.RepresentativeId;
				_operationDate = daoOperationRequest.OperationDate;
				_startDate = daoOperationRequest.StartDate;
				_targetDays = daoOperationRequest.TargetDays;
				_actualDays = daoOperationRequest.ActualDays;
				_targetClients = daoOperationRequest.TargetClients;
				_actualClients = daoOperationRequest.ActualClients;
				_daysPerformance = daoOperationRequest.DaysPerformance;
				_clientsPerformance = daoOperationRequest.ClientsPerformance;
				_accuracy = daoOperationRequest.Accuracy;
				_mapPoints = daoOperationRequest.MapPoints;
				_isClosed = daoOperationRequest.IsClosed;
				_closeDate = daoOperationRequest.CloseDate;
				_notes = daoOperationRequest.Notes;
				_cBy = daoOperationRequest.CBy;
				_eBy = daoOperationRequest.EBy;
				_cDate = daoOperationRequest.CDate;
				_eDate = daoOperationRequest.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOOperationRequest");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one OperationRequest record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOOperationRequest daoOperationRequest = new DAOOperationRequest();
			RegisterDataObject(daoOperationRequest);
			BeginTransaction("deleteBOOperationRequest");
			try
			{
				daoOperationRequest.OperationId = _operationId;
				daoOperationRequest.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOOperationRequest");
				throw;
			}
		}
		
		///<Summary>
		///OperationRequestCollection
		///This method returns the collection of BOOperationRequest objects
		///</Summary>
		///<returns>
		///List[BOOperationRequest]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOOperationRequest> OperationRequestCollection()
		{
			try
			{
				IList<BOOperationRequest> boOperationRequestCollection = new List<BOOperationRequest>();
				IList<DAOOperationRequest> daoOperationRequestCollection = DAOOperationRequest.SelectAll();
			
				foreach(DAOOperationRequest daoOperationRequest in daoOperationRequestCollection)
					boOperationRequestCollection.Add(new BOOperationRequest(daoOperationRequest));
			
				return boOperationRequestCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///OperationRequestCollectionCount
		///This method returns the collection count of BOOperationRequest objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 OperationRequestCollectionCount()
		{
			try
			{
				Int32 objCount = DAOOperationRequest.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///OperationRequestDetailCollection
		///This method returns its collection of BOOperationRequestDetail objects
		///</Summary>
		///<returns>
		///IList[BOOperationRequestDetail]
		///</returns>
		///<parameters>
		///BOOperationRequest
		///</parameters>
		public virtual IList<BOOperationRequestDetail> OperationRequestDetailCollection()
		{
			try
			{
				if(_boOperationRequestDetailCollection == null)
					LoadOperationRequestDetailCollection();
				
				return _boOperationRequestDetailCollection.AsReadOnly();
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
		///List<BOOperationRequest>
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
				IDictionary<string, IList<object>> retObj = DAOOperationRequest.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///OperationRequestCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOOperationRequest objects, filtered by optional criteria
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
				IList<T> boOperationRequestCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOOperationRequest> daoOperationRequestCollection = DAOOperationRequest.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOOperationRequest resdaoOperationRequest in daoOperationRequestCollection)
					boOperationRequestCollection.Add((T)(object)new BOOperationRequest(resdaoOperationRequest));
			
				return boOperationRequestCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///OperationRequestCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOOperationRequest objects, filtered by optional criteria
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
				Int32 objCount = DAOOperationRequest.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadOperationRequestDetailCollection
		///This method loads the internal collection of BOOperationRequestDetail objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadOperationRequestDetailCollection()
		{
			try
			{
				_boOperationRequestDetailCollection = new List<BOOperationRequestDetail>();
				IList<DAOOperationRequestDetail> daoOperationRequestDetailCollection = DAOOperationRequestDetail.SelectAllByOperationId(_operationId.Value);
				
				foreach(DAOOperationRequestDetail daoOperationRequestDetail in daoOperationRequestDetailCollection)
					_boOperationRequestDetailCollection.Add(new BOOperationRequestDetail(daoOperationRequestDetail));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddOperationRequestDetail
		///This method persists a BOOperationRequestDetail object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOOperationRequestDetail
		///</parameters>
		public virtual void AddOperationRequestDetail(BOOperationRequestDetail boOperationRequestDetail)
		{
			DAOOperationRequestDetail daoOperationRequestDetail = new DAOOperationRequestDetail();
			RegisterDataObject(daoOperationRequestDetail);
			BeginTransaction("addOperationRequestDetail");
			try
			{
				daoOperationRequestDetail.DetailId = boOperationRequestDetail.DetailId;
				daoOperationRequestDetail.OperationDate = boOperationRequestDetail.OperationDate;
				daoOperationRequestDetail.ClientId = boOperationRequestDetail.ClientId;
				daoOperationRequestDetail.ClientTypeId = boOperationRequestDetail.ClientTypeId;
				daoOperationRequestDetail.ClientNameAr = boOperationRequestDetail.ClientNameAr;
				daoOperationRequestDetail.ClientNameEn = boOperationRequestDetail.ClientNameEn;
				daoOperationRequestDetail.RegionId = boOperationRequestDetail.RegionId;
				daoOperationRequestDetail.GovernerateId = boOperationRequestDetail.GovernerateId;
				daoOperationRequestDetail.CityId = boOperationRequestDetail.CityId;
				daoOperationRequestDetail.LocationLevelId = boOperationRequestDetail.LocationLevelId;
				daoOperationRequestDetail.IsChain = boOperationRequestDetail.IsChain;
				daoOperationRequestDetail.ResponsibleNameEn = boOperationRequestDetail.ResponsibleNameEn;
				daoOperationRequestDetail.ResponsibleNameAr = boOperationRequestDetail.ResponsibleNameAr;
				daoOperationRequestDetail.Building = boOperationRequestDetail.Building;
				daoOperationRequestDetail.Floor = boOperationRequestDetail.Floor;
				daoOperationRequestDetail.Property = boOperationRequestDetail.Property;
				daoOperationRequestDetail.Address = boOperationRequestDetail.Address;
				daoOperationRequestDetail.Landmark = boOperationRequestDetail.Landmark;
				daoOperationRequestDetail.Phone = boOperationRequestDetail.Phone;
				daoOperationRequestDetail.Mobile = boOperationRequestDetail.Mobile;
				daoOperationRequestDetail.WhatsApp = boOperationRequestDetail.WhatsApp;
				daoOperationRequestDetail.Latitude = boOperationRequestDetail.Latitude;
				daoOperationRequestDetail.Longitude = boOperationRequestDetail.Longitude;
				daoOperationRequestDetail.Accuracy = boOperationRequestDetail.Accuracy;
				daoOperationRequestDetail.InZone = boOperationRequestDetail.InZone;
				daoOperationRequestDetail.OperationStatusId = boOperationRequestDetail.OperationStatusId;
				daoOperationRequestDetail.CBy = boOperationRequestDetail.CBy;
				daoOperationRequestDetail.CDate = boOperationRequestDetail.CDate;
				daoOperationRequestDetail.EBy = boOperationRequestDetail.EBy;
				daoOperationRequestDetail.EDate = boOperationRequestDetail.EDate;
				daoOperationRequestDetail.TaxCode = boOperationRequestDetail.TaxCode;
				daoOperationRequestDetail.CommercialCode = boOperationRequestDetail.CommercialCode;
				daoOperationRequestDetail.OperationRejectReasonId = boOperationRequestDetail.OperationRejectReasonId;
				daoOperationRequestDetail.OperationId = _operationId.Value;
				daoOperationRequestDetail.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boOperationRequestDetail = new BOOperationRequestDetail(daoOperationRequestDetail);
				if(_boOperationRequestDetailCollection != null)
					_boOperationRequestDetailCollection.Add(boOperationRequestDetail);
			}
			catch
			{
				RollbackTransaction("addOperationRequestDetail");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllOperationRequestDetail
		///This method deletes all BOOperationRequestDetail objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllOperationRequestDetail()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllOperationRequestDetail");
			try
			{
				DAOOperationRequestDetail.DeleteAllByOperationId(ConnectionProvider, _operationId.Value);
				CommitTransaction();
				if(_boOperationRequestDetailCollection != null)
				{
					_boOperationRequestDetailCollection.Clear();
					_boOperationRequestDetailCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllOperationRequestDetail");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? OperationId
		{
			get
			{
				 return _operationId;
			}
			set
			{
				_operationId = value;
				_isDirty = true;
			}
		}
		
		public virtual string OperationCode
		{
			get
			{
				 return _operationCode;
			}
			set
			{
				_operationCode = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? AgentId
		{
			get
			{
				 return _agentId;
			}
			set
			{
				_agentId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? OperationTypeId
		{
			get
			{
				 return _operationTypeId;
			}
			set
			{
				_operationTypeId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? GovernerateId
		{
			get
			{
				 return _governerateId;
			}
			set
			{
				_governerateId = value;
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
		
		public virtual DateTime? OperationDate
		{
			get
			{
				 return _operationDate;
			}
			set
			{
				_operationDate = value;
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
		
		public virtual Int32? TargetDays
		{
			get
			{
				 return _targetDays;
			}
			set
			{
				_targetDays = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ActualDays
		{
			get
			{
				 return _actualDays;
			}
			set
			{
				_actualDays = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? TargetClients
		{
			get
			{
				 return _targetClients;
			}
			set
			{
				_targetClients = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ActualClients
		{
			get
			{
				 return _actualClients;
			}
			set
			{
				_actualClients = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? DaysPerformance
		{
			get
			{
				 return _daysPerformance;
			}
			set
			{
				_daysPerformance = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? ClientsPerformance
		{
			get
			{
				 return _clientsPerformance;
			}
			set
			{
				_clientsPerformance = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? Accuracy
		{
			get
			{
				 return _accuracy;
			}
			set
			{
				_accuracy = value;
				_isDirty = true;
			}
		}
		
		public virtual string MapPoints
		{
			get
			{
				 return _mapPoints;
			}
			set
			{
				_mapPoints = value;
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
		
		public virtual DateTime? CloseDate
		{
			get
			{
				 return _closeDate;
			}
			set
			{
				_closeDate = value;
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
