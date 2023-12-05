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
	///This is the definition of the class BORequestType.
	///It maintains a collection of BOClientServiceRequest,BORequestTypeDetail objects.
	///</Summary>
	public partial class BORequestType : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _requestTypeId;
		protected string _requestTypeCode;
		protected string _requestTypeNameEn;
		protected string _requestTypeNameAr;
		protected string _icon;
		protected string _color;
		protected Int32? _displayOrder;
		protected bool? _isActive;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOClientServiceRequest> _boClientServiceRequestCollection;
		List<BORequestTypeDetail> _boRequestTypeDetailCollection;
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
		public BORequestType()
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
		///Int32 requestTypeId
		///</parameters>
		public BORequestType(Int32 requestTypeId)
		{
			try
			{
				DAORequestType daoRequestType = DAORequestType.SelectOne(requestTypeId);
				_requestTypeId = daoRequestType.RequestTypeId;
				_requestTypeCode = daoRequestType.RequestTypeCode;
				_requestTypeNameEn = daoRequestType.RequestTypeNameEn;
				_requestTypeNameAr = daoRequestType.RequestTypeNameAr;
				_icon = daoRequestType.Icon;
				_color = daoRequestType.Color;
				_displayOrder = daoRequestType.DisplayOrder;
				_isActive = daoRequestType.IsActive;
				_canEdit = daoRequestType.CanEdit;
				_canDelete = daoRequestType.CanDelete;
				_cBy = daoRequestType.CBy;
				_cDate = daoRequestType.CDate;
				_eBy = daoRequestType.EBy;
				_eDate = daoRequestType.EDate;
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
		///DAORequestType
		///</parameters>
		protected internal BORequestType(DAORequestType daoRequestType)
		{
			try
			{
				_requestTypeId = daoRequestType.RequestTypeId;
				_requestTypeCode = daoRequestType.RequestTypeCode;
				_requestTypeNameEn = daoRequestType.RequestTypeNameEn;
				_requestTypeNameAr = daoRequestType.RequestTypeNameAr;
				_icon = daoRequestType.Icon;
				_color = daoRequestType.Color;
				_displayOrder = daoRequestType.DisplayOrder;
				_isActive = daoRequestType.IsActive;
				_canEdit = daoRequestType.CanEdit;
				_canDelete = daoRequestType.CanDelete;
				_cBy = daoRequestType.CBy;
				_cDate = daoRequestType.CDate;
				_eBy = daoRequestType.EBy;
				_eDate = daoRequestType.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new RequestType record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAORequestType daoRequestType = new DAORequestType();
			RegisterDataObject(daoRequestType);
			BeginTransaction("savenewBORequestType");
			try
			{
				daoRequestType.RequestTypeCode = _requestTypeCode;
				daoRequestType.RequestTypeNameEn = _requestTypeNameEn;
				daoRequestType.RequestTypeNameAr = _requestTypeNameAr;
				daoRequestType.Icon = _icon;
				daoRequestType.Color = _color;
				daoRequestType.DisplayOrder = _displayOrder;
				daoRequestType.IsActive = _isActive;
				daoRequestType.CanEdit = _canEdit;
				daoRequestType.CanDelete = _canDelete;
				daoRequestType.CBy = _cBy;
				daoRequestType.CDate = _cDate;
				daoRequestType.EBy = _eBy;
				daoRequestType.EDate = _eDate;
				daoRequestType.Insert();
				CommitTransaction();
				
				_requestTypeId = daoRequestType.RequestTypeId;
				_requestTypeCode = daoRequestType.RequestTypeCode;
				_requestTypeNameEn = daoRequestType.RequestTypeNameEn;
				_requestTypeNameAr = daoRequestType.RequestTypeNameAr;
				_icon = daoRequestType.Icon;
				_color = daoRequestType.Color;
				_displayOrder = daoRequestType.DisplayOrder;
				_isActive = daoRequestType.IsActive;
				_canEdit = daoRequestType.CanEdit;
				_canDelete = daoRequestType.CanDelete;
				_cBy = daoRequestType.CBy;
				_cDate = daoRequestType.CDate;
				_eBy = daoRequestType.EBy;
				_eDate = daoRequestType.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBORequestType");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one RequestType record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BORequestType
		///</parameters>
		public virtual void Update()
		{
			DAORequestType daoRequestType = new DAORequestType();
			RegisterDataObject(daoRequestType);
			BeginTransaction("updateBORequestType");
			try
			{
				daoRequestType.RequestTypeId = _requestTypeId;
				daoRequestType.RequestTypeCode = _requestTypeCode;
				daoRequestType.RequestTypeNameEn = _requestTypeNameEn;
				daoRequestType.RequestTypeNameAr = _requestTypeNameAr;
				daoRequestType.Icon = _icon;
				daoRequestType.Color = _color;
				daoRequestType.DisplayOrder = _displayOrder;
				daoRequestType.IsActive = _isActive;
				daoRequestType.CanEdit = _canEdit;
				daoRequestType.CanDelete = _canDelete;
				daoRequestType.CBy = _cBy;
				daoRequestType.CDate = _cDate;
				daoRequestType.EBy = _eBy;
				daoRequestType.EDate = _eDate;
				daoRequestType.Update();
				CommitTransaction();
				
				_requestTypeId = daoRequestType.RequestTypeId;
				_requestTypeCode = daoRequestType.RequestTypeCode;
				_requestTypeNameEn = daoRequestType.RequestTypeNameEn;
				_requestTypeNameAr = daoRequestType.RequestTypeNameAr;
				_icon = daoRequestType.Icon;
				_color = daoRequestType.Color;
				_displayOrder = daoRequestType.DisplayOrder;
				_isActive = daoRequestType.IsActive;
				_canEdit = daoRequestType.CanEdit;
				_canDelete = daoRequestType.CanDelete;
				_cBy = daoRequestType.CBy;
				_cDate = daoRequestType.CDate;
				_eBy = daoRequestType.EBy;
				_eDate = daoRequestType.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBORequestType");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one RequestType record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAORequestType daoRequestType = new DAORequestType();
			RegisterDataObject(daoRequestType);
			BeginTransaction("deleteBORequestType");
			try
			{
				daoRequestType.RequestTypeId = _requestTypeId;
				daoRequestType.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBORequestType");
				throw;
			}
		}
		
		///<Summary>
		///RequestTypeCollection
		///This method returns the collection of BORequestType objects
		///</Summary>
		///<returns>
		///List[BORequestType]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BORequestType> RequestTypeCollection()
		{
			try
			{
				IList<BORequestType> boRequestTypeCollection = new List<BORequestType>();
				IList<DAORequestType> daoRequestTypeCollection = DAORequestType.SelectAll();
			
				foreach(DAORequestType daoRequestType in daoRequestTypeCollection)
					boRequestTypeCollection.Add(new BORequestType(daoRequestType));
			
				return boRequestTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RequestTypeCollectionCount
		///This method returns the collection count of BORequestType objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 RequestTypeCollectionCount()
		{
			try
			{
				Int32 objCount = DAORequestType.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///ClientServiceRequestCollection
		///This method returns its collection of BOClientServiceRequest objects
		///</Summary>
		///<returns>
		///IList[BOClientServiceRequest]
		///</returns>
		///<parameters>
		///BORequestType
		///</parameters>
		public virtual IList<BOClientServiceRequest> ClientServiceRequestCollection()
		{
			try
			{
				if(_boClientServiceRequestCollection == null)
					LoadClientServiceRequestCollection();
				
				return _boClientServiceRequestCollection.AsReadOnly();
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///RequestTypeDetailCollection
		///This method returns its collection of BORequestTypeDetail objects
		///</Summary>
		///<returns>
		///IList[BORequestTypeDetail]
		///</returns>
		///<parameters>
		///BORequestType
		///</parameters>
		public virtual IList<BORequestTypeDetail> RequestTypeDetailCollection()
		{
			try
			{
				if(_boRequestTypeDetailCollection == null)
					LoadRequestTypeDetailCollection();
				
				return _boRequestTypeDetailCollection.AsReadOnly();
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
		///List<BORequestType>
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
				IDictionary<string, IList<object>> retObj = DAORequestType.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RequestTypeCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BORequestType objects, filtered by optional criteria
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
				IList<T> boRequestTypeCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAORequestType> daoRequestTypeCollection = DAORequestType.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAORequestType resdaoRequestType in daoRequestTypeCollection)
					boRequestTypeCollection.Add((T)(object)new BORequestType(resdaoRequestType));
			
				return boRequestTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RequestTypeCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BORequestType objects, filtered by optional criteria
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
				Int32 objCount = DAORequestType.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadClientServiceRequestCollection
		///This method loads the internal collection of BOClientServiceRequest objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadClientServiceRequestCollection()
		{
			try
			{
				_boClientServiceRequestCollection = new List<BOClientServiceRequest>();
				IList<DAOClientServiceRequest> daoClientServiceRequestCollection = DAOClientServiceRequest.SelectAllByRequestTypeId(_requestTypeId.Value);
				
				foreach(DAOClientServiceRequest daoClientServiceRequest in daoClientServiceRequestCollection)
					_boClientServiceRequestCollection.Add(new BOClientServiceRequest(daoClientServiceRequest));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddClientServiceRequest
		///This method persists a BOClientServiceRequest object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOClientServiceRequest
		///</parameters>
		public virtual void AddClientServiceRequest(BOClientServiceRequest boClientServiceRequest)
		{
			DAOClientServiceRequest daoClientServiceRequest = new DAOClientServiceRequest();
			RegisterDataObject(daoClientServiceRequest);
			BeginTransaction("addClientServiceRequest");
			try
			{
				daoClientServiceRequest.RequestId = boClientServiceRequest.RequestId;
				daoClientServiceRequest.RequestCode = boClientServiceRequest.RequestCode;
				daoClientServiceRequest.BranchId = boClientServiceRequest.BranchId;
				daoClientServiceRequest.RepresentativeId = boClientServiceRequest.RepresentativeId;
				daoClientServiceRequest.ClientId = boClientServiceRequest.ClientId;
				daoClientServiceRequest.RequestDate = boClientServiceRequest.RequestDate;
				daoClientServiceRequest.RequestTime = boClientServiceRequest.RequestTime;
				daoClientServiceRequest.RequestTypeDetailId = boClientServiceRequest.RequestTypeDetailId;
				daoClientServiceRequest.Phone = boClientServiceRequest.Phone;
				daoClientServiceRequest.PhoneAlternative = boClientServiceRequest.PhoneAlternative;
				daoClientServiceRequest.PriorityId = boClientServiceRequest.PriorityId;
				daoClientServiceRequest.RequestStatusId = boClientServiceRequest.RequestStatusId;
				daoClientServiceRequest.IsClosed = boClientServiceRequest.IsClosed;
				daoClientServiceRequest.CloseDate = boClientServiceRequest.CloseDate;
				daoClientServiceRequest.Duration = boClientServiceRequest.Duration;
				daoClientServiceRequest.Latitude = boClientServiceRequest.Latitude;
				daoClientServiceRequest.Longitude = boClientServiceRequest.Longitude;
				daoClientServiceRequest.InZone = boClientServiceRequest.InZone;
				daoClientServiceRequest.Distance = boClientServiceRequest.Distance;
				daoClientServiceRequest.Notes = boClientServiceRequest.Notes;
				daoClientServiceRequest.DepartmentId = boClientServiceRequest.DepartmentId;
				daoClientServiceRequest.CBy = boClientServiceRequest.CBy;
				daoClientServiceRequest.CDate = boClientServiceRequest.CDate;
				daoClientServiceRequest.EBy = boClientServiceRequest.EBy;
				daoClientServiceRequest.EDate = boClientServiceRequest.EDate;
				daoClientServiceRequest.Replay = boClientServiceRequest.Replay;
				daoClientServiceRequest.RequestTitle = boClientServiceRequest.RequestTitle;
				daoClientServiceRequest.RequestTypeId = _requestTypeId.Value;
				daoClientServiceRequest.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boClientServiceRequest = new BOClientServiceRequest(daoClientServiceRequest);
				if(_boClientServiceRequestCollection != null)
					_boClientServiceRequestCollection.Add(boClientServiceRequest);
			}
			catch
			{
				RollbackTransaction("addClientServiceRequest");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllClientServiceRequest
		///This method deletes all BOClientServiceRequest objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllClientServiceRequest()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllClientServiceRequest");
			try
			{
				DAOClientServiceRequest.DeleteAllByRequestTypeId(ConnectionProvider, _requestTypeId.Value);
				CommitTransaction();
				if(_boClientServiceRequestCollection != null)
				{
					_boClientServiceRequestCollection.Clear();
					_boClientServiceRequestCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllClientServiceRequest");
				throw;
			}
		}
		
		///<Summary>
		///LoadRequestTypeDetailCollection
		///This method loads the internal collection of BORequestTypeDetail objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadRequestTypeDetailCollection()
		{
			try
			{
				_boRequestTypeDetailCollection = new List<BORequestTypeDetail>();
				IList<DAORequestTypeDetail> daoRequestTypeDetailCollection = DAORequestTypeDetail.SelectAllByRequestTypeId(_requestTypeId.Value);
				
				foreach(DAORequestTypeDetail daoRequestTypeDetail in daoRequestTypeDetailCollection)
					_boRequestTypeDetailCollection.Add(new BORequestTypeDetail(daoRequestTypeDetail));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddRequestTypeDetail
		///This method persists a BORequestTypeDetail object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BORequestTypeDetail
		///</parameters>
		public virtual void AddRequestTypeDetail(BORequestTypeDetail boRequestTypeDetail)
		{
			DAORequestTypeDetail daoRequestTypeDetail = new DAORequestTypeDetail();
			RegisterDataObject(daoRequestTypeDetail);
			BeginTransaction("addRequestTypeDetail");
			try
			{
				daoRequestTypeDetail.RequestTypeDetailId = boRequestTypeDetail.RequestTypeDetailId;
				daoRequestTypeDetail.RequestTypeDetailCode = boRequestTypeDetail.RequestTypeDetailCode;
				daoRequestTypeDetail.RequestTypeDetailNameEn = boRequestTypeDetail.RequestTypeDetailNameEn;
				daoRequestTypeDetail.RequestTypeDetailNameAr = boRequestTypeDetail.RequestTypeDetailNameAr;
				daoRequestTypeDetail.Icon = boRequestTypeDetail.Icon;
				daoRequestTypeDetail.Color = boRequestTypeDetail.Color;
				daoRequestTypeDetail.DisplayOrder = boRequestTypeDetail.DisplayOrder;
				daoRequestTypeDetail.IsActive = boRequestTypeDetail.IsActive;
				daoRequestTypeDetail.CanEdit = boRequestTypeDetail.CanEdit;
				daoRequestTypeDetail.CanDelete = boRequestTypeDetail.CanDelete;
				daoRequestTypeDetail.CBy = boRequestTypeDetail.CBy;
				daoRequestTypeDetail.CDate = boRequestTypeDetail.CDate;
				daoRequestTypeDetail.EBy = boRequestTypeDetail.EBy;
				daoRequestTypeDetail.EDate = boRequestTypeDetail.EDate;
				daoRequestTypeDetail.RequestTypeId = _requestTypeId.Value;
				daoRequestTypeDetail.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boRequestTypeDetail = new BORequestTypeDetail(daoRequestTypeDetail);
				if(_boRequestTypeDetailCollection != null)
					_boRequestTypeDetailCollection.Add(boRequestTypeDetail);
			}
			catch
			{
				RollbackTransaction("addRequestTypeDetail");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllRequestTypeDetail
		///This method deletes all BORequestTypeDetail objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllRequestTypeDetail()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllRequestTypeDetail");
			try
			{
				DAORequestTypeDetail.DeleteAllByRequestTypeId(ConnectionProvider, _requestTypeId.Value);
				CommitTransaction();
				if(_boRequestTypeDetailCollection != null)
				{
					_boRequestTypeDetailCollection.Clear();
					_boRequestTypeDetailCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllRequestTypeDetail");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? RequestTypeId
		{
			get
			{
				 return _requestTypeId;
			}
			set
			{
				_requestTypeId = value;
				_isDirty = true;
			}
		}
		
		public virtual string RequestTypeCode
		{
			get
			{
				 return _requestTypeCode;
			}
			set
			{
				_requestTypeCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string RequestTypeNameEn
		{
			get
			{
				 return _requestTypeNameEn;
			}
			set
			{
				_requestTypeNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string RequestTypeNameAr
		{
			get
			{
				 return _requestTypeNameAr;
			}
			set
			{
				_requestTypeNameAr = value;
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