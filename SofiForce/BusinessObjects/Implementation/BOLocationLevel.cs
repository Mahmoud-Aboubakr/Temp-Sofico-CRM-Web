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
	///This is the definition of the class BOLocationLevel.
	///It maintains a collection of BOClient,BOOperationRequestDetail objects.
	///</Summary>
	public partial class BOLocationLevel : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _locationLevelId;
		protected string _locationLevelCode;
		protected string _locationLevelNameEn;
		protected string _locationLevelNameAr;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected bool? _isActive;
		protected Int32? _displayOrder;
		protected string _color;
		protected string _icon;
		protected Int32? _cBy;
		protected Int32? _eBy;
		protected DateTime? _cDate;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOClient> _boClientCollection;
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
		public BOLocationLevel()
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
		///Int32 locationLevelId
		///</parameters>
		public BOLocationLevel(Int32 locationLevelId)
		{
			try
			{
				DAOLocationLevel daoLocationLevel = DAOLocationLevel.SelectOne(locationLevelId);
				_locationLevelId = daoLocationLevel.LocationLevelId;
				_locationLevelCode = daoLocationLevel.LocationLevelCode;
				_locationLevelNameEn = daoLocationLevel.LocationLevelNameEn;
				_locationLevelNameAr = daoLocationLevel.LocationLevelNameAr;
				_canEdit = daoLocationLevel.CanEdit;
				_canDelete = daoLocationLevel.CanDelete;
				_isActive = daoLocationLevel.IsActive;
				_displayOrder = daoLocationLevel.DisplayOrder;
				_color = daoLocationLevel.Color;
				_icon = daoLocationLevel.Icon;
				_cBy = daoLocationLevel.CBy;
				_eBy = daoLocationLevel.EBy;
				_cDate = daoLocationLevel.CDate;
				_eDate = daoLocationLevel.EDate;
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
		///DAOLocationLevel
		///</parameters>
		protected internal BOLocationLevel(DAOLocationLevel daoLocationLevel)
		{
			try
			{
				_locationLevelId = daoLocationLevel.LocationLevelId;
				_locationLevelCode = daoLocationLevel.LocationLevelCode;
				_locationLevelNameEn = daoLocationLevel.LocationLevelNameEn;
				_locationLevelNameAr = daoLocationLevel.LocationLevelNameAr;
				_canEdit = daoLocationLevel.CanEdit;
				_canDelete = daoLocationLevel.CanDelete;
				_isActive = daoLocationLevel.IsActive;
				_displayOrder = daoLocationLevel.DisplayOrder;
				_color = daoLocationLevel.Color;
				_icon = daoLocationLevel.Icon;
				_cBy = daoLocationLevel.CBy;
				_eBy = daoLocationLevel.EBy;
				_cDate = daoLocationLevel.CDate;
				_eDate = daoLocationLevel.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new LocationLevel record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOLocationLevel daoLocationLevel = new DAOLocationLevel();
			RegisterDataObject(daoLocationLevel);
			BeginTransaction("savenewBOLocationLevel");
			try
			{
				daoLocationLevel.LocationLevelCode = _locationLevelCode;
				daoLocationLevel.LocationLevelNameEn = _locationLevelNameEn;
				daoLocationLevel.LocationLevelNameAr = _locationLevelNameAr;
				daoLocationLevel.CanEdit = _canEdit;
				daoLocationLevel.CanDelete = _canDelete;
				daoLocationLevel.IsActive = _isActive;
				daoLocationLevel.DisplayOrder = _displayOrder;
				daoLocationLevel.Color = _color;
				daoLocationLevel.Icon = _icon;
				daoLocationLevel.CBy = _cBy;
				daoLocationLevel.EBy = _eBy;
				daoLocationLevel.CDate = _cDate;
				daoLocationLevel.EDate = _eDate;
				daoLocationLevel.Insert();
				CommitTransaction();
				
				_locationLevelId = daoLocationLevel.LocationLevelId;
				_locationLevelCode = daoLocationLevel.LocationLevelCode;
				_locationLevelNameEn = daoLocationLevel.LocationLevelNameEn;
				_locationLevelNameAr = daoLocationLevel.LocationLevelNameAr;
				_canEdit = daoLocationLevel.CanEdit;
				_canDelete = daoLocationLevel.CanDelete;
				_isActive = daoLocationLevel.IsActive;
				_displayOrder = daoLocationLevel.DisplayOrder;
				_color = daoLocationLevel.Color;
				_icon = daoLocationLevel.Icon;
				_cBy = daoLocationLevel.CBy;
				_eBy = daoLocationLevel.EBy;
				_cDate = daoLocationLevel.CDate;
				_eDate = daoLocationLevel.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOLocationLevel");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one LocationLevel record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOLocationLevel
		///</parameters>
		public virtual void Update()
		{
			DAOLocationLevel daoLocationLevel = new DAOLocationLevel();
			RegisterDataObject(daoLocationLevel);
			BeginTransaction("updateBOLocationLevel");
			try
			{
				daoLocationLevel.LocationLevelId = _locationLevelId;
				daoLocationLevel.LocationLevelCode = _locationLevelCode;
				daoLocationLevel.LocationLevelNameEn = _locationLevelNameEn;
				daoLocationLevel.LocationLevelNameAr = _locationLevelNameAr;
				daoLocationLevel.CanEdit = _canEdit;
				daoLocationLevel.CanDelete = _canDelete;
				daoLocationLevel.IsActive = _isActive;
				daoLocationLevel.DisplayOrder = _displayOrder;
				daoLocationLevel.Color = _color;
				daoLocationLevel.Icon = _icon;
				daoLocationLevel.CBy = _cBy;
				daoLocationLevel.EBy = _eBy;
				daoLocationLevel.CDate = _cDate;
				daoLocationLevel.EDate = _eDate;
				daoLocationLevel.Update();
				CommitTransaction();
				
				_locationLevelId = daoLocationLevel.LocationLevelId;
				_locationLevelCode = daoLocationLevel.LocationLevelCode;
				_locationLevelNameEn = daoLocationLevel.LocationLevelNameEn;
				_locationLevelNameAr = daoLocationLevel.LocationLevelNameAr;
				_canEdit = daoLocationLevel.CanEdit;
				_canDelete = daoLocationLevel.CanDelete;
				_isActive = daoLocationLevel.IsActive;
				_displayOrder = daoLocationLevel.DisplayOrder;
				_color = daoLocationLevel.Color;
				_icon = daoLocationLevel.Icon;
				_cBy = daoLocationLevel.CBy;
				_eBy = daoLocationLevel.EBy;
				_cDate = daoLocationLevel.CDate;
				_eDate = daoLocationLevel.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOLocationLevel");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one LocationLevel record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOLocationLevel daoLocationLevel = new DAOLocationLevel();
			RegisterDataObject(daoLocationLevel);
			BeginTransaction("deleteBOLocationLevel");
			try
			{
				daoLocationLevel.LocationLevelId = _locationLevelId;
				daoLocationLevel.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOLocationLevel");
				throw;
			}
		}
		
		///<Summary>
		///LocationLevelCollection
		///This method returns the collection of BOLocationLevel objects
		///</Summary>
		///<returns>
		///List[BOLocationLevel]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOLocationLevel> LocationLevelCollection()
		{
			try
			{
				IList<BOLocationLevel> boLocationLevelCollection = new List<BOLocationLevel>();
				IList<DAOLocationLevel> daoLocationLevelCollection = DAOLocationLevel.SelectAll();
			
				foreach(DAOLocationLevel daoLocationLevel in daoLocationLevelCollection)
					boLocationLevelCollection.Add(new BOLocationLevel(daoLocationLevel));
			
				return boLocationLevelCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///LocationLevelCollectionCount
		///This method returns the collection count of BOLocationLevel objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 LocationLevelCollectionCount()
		{
			try
			{
				Int32 objCount = DAOLocationLevel.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///ClientCollection
		///This method returns its collection of BOClient objects
		///</Summary>
		///<returns>
		///IList[BOClient]
		///</returns>
		///<parameters>
		///BOLocationLevel
		///</parameters>
		public virtual IList<BOClient> ClientCollection()
		{
			try
			{
				if(_boClientCollection == null)
					LoadClientCollection();
				
				return _boClientCollection.AsReadOnly();
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
		///BOLocationLevel
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
		///List<BOLocationLevel>
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
				IDictionary<string, IList<object>> retObj = DAOLocationLevel.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///LocationLevelCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOLocationLevel objects, filtered by optional criteria
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
				IList<T> boLocationLevelCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOLocationLevel> daoLocationLevelCollection = DAOLocationLevel.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOLocationLevel resdaoLocationLevel in daoLocationLevelCollection)
					boLocationLevelCollection.Add((T)(object)new BOLocationLevel(resdaoLocationLevel));
			
				return boLocationLevelCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///LocationLevelCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOLocationLevel objects, filtered by optional criteria
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
				Int32 objCount = DAOLocationLevel.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadClientCollection
		///This method loads the internal collection of BOClient objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadClientCollection()
		{
			try
			{
				_boClientCollection = new List<BOClient>();
				IList<DAOClient> daoClientCollection = DAOClient.SelectAllByLocationLevelId(_locationLevelId.Value);
				
				foreach(DAOClient daoClient in daoClientCollection)
					_boClientCollection.Add(new BOClient(daoClient));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddClient
		///This method persists a BOClient object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOClient
		///</parameters>
		public virtual void AddClient(BOClient boClient)
		{
			DAOClient daoClient = new DAOClient();
			RegisterDataObject(daoClient);
			BeginTransaction("addClient");
			try
			{
				daoClient.ClientId = boClient.ClientId;
				daoClient.ClientAccountId = boClient.ClientAccountId;
				daoClient.ClientTypeId = boClient.ClientTypeId;
				daoClient.ClientCode = boClient.ClientCode;
				daoClient.ClientNameAr = boClient.ClientNameAr;
				daoClient.ClientNameEn = boClient.ClientNameEn;
				daoClient.BusinessUnitId = boClient.BusinessUnitId;
				daoClient.BranchId = boClient.BranchId;
				daoClient.RegionId = boClient.RegionId;
				daoClient.GovernerateId = boClient.GovernerateId;
				daoClient.CityId = boClient.CityId;
				daoClient.ClientGroupId = boClient.ClientGroupId;
				daoClient.ClientGroupSubId = boClient.ClientGroupSubId;
				daoClient.ClientClassificationId = boClient.ClientClassificationId;
				daoClient.CreditLimit = boClient.CreditLimit;
				daoClient.CreditBalance = boClient.CreditBalance;
				daoClient.PaymentTermId = boClient.PaymentTermId;
				daoClient.IsChain = boClient.IsChain;
				daoClient.Building = boClient.Building;
				daoClient.Floor = boClient.Floor;
				daoClient.Property = boClient.Property;
				daoClient.Address = boClient.Address;
				daoClient.Landmark = boClient.Landmark;
				daoClient.Phone = boClient.Phone;
				daoClient.Mobile = boClient.Mobile;
				daoClient.WhatsApp = boClient.WhatsApp;
				daoClient.IsActive = boClient.IsActive;
				daoClient.Latitude = boClient.Latitude;
				daoClient.Longitude = boClient.Longitude;
				daoClient.CBy = boClient.CBy;
				daoClient.CDate = boClient.CDate;
				daoClient.EBy = boClient.EBy;
				daoClient.EDate = boClient.EDate;
				daoClient.IsTaxable = boClient.IsTaxable;
				daoClient.IsCashDiscount = boClient.IsCashDiscount;
				daoClient.ResponsibleNameAr = boClient.ResponsibleNameAr;
				daoClient.ResponsibleNameEn = boClient.ResponsibleNameEn;
				daoClient.TaxCode = boClient.TaxCode;
				daoClient.CommercialCode = boClient.CommercialCode;
				daoClient.IsNew = boClient.IsNew;
				daoClient.NeedValidation = boClient.NeedValidation;
				daoClient.CashGroupId = boClient.CashGroupId;
				daoClient.InRoute = boClient.InRoute;
				daoClient.SalesChannelId = boClient.SalesChannelId;
				daoClient.SalesPoolId = boClient.SalesPoolId;
				daoClient.UserId = boClient.UserId;
				daoClient.Points = boClient.Points;
				daoClient.Wallet = boClient.Wallet;
				daoClient.DealId = boClient.DealId;
				daoClient.LocationLevelId = _locationLevelId.Value;
				daoClient.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boClient = new BOClient(daoClient);
				if(_boClientCollection != null)
					_boClientCollection.Add(boClient);
			}
			catch
			{
				RollbackTransaction("addClient");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllClient
		///This method deletes all BOClient objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllClient()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllClient");
			try
			{
				DAOClient.DeleteAllByLocationLevelId(ConnectionProvider, _locationLevelId.Value);
				CommitTransaction();
				if(_boClientCollection != null)
				{
					_boClientCollection.Clear();
					_boClientCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllClient");
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
				IList<DAOOperationRequestDetail> daoOperationRequestDetailCollection = DAOOperationRequestDetail.SelectAllByLocationLevelId(_locationLevelId.Value);
				
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
				daoOperationRequestDetail.OperationId = boOperationRequestDetail.OperationId;
				daoOperationRequestDetail.OperationDate = boOperationRequestDetail.OperationDate;
				daoOperationRequestDetail.ClientId = boOperationRequestDetail.ClientId;
				daoOperationRequestDetail.ClientTypeId = boOperationRequestDetail.ClientTypeId;
				daoOperationRequestDetail.ClientNameAr = boOperationRequestDetail.ClientNameAr;
				daoOperationRequestDetail.ClientNameEn = boOperationRequestDetail.ClientNameEn;
				daoOperationRequestDetail.RegionId = boOperationRequestDetail.RegionId;
				daoOperationRequestDetail.GovernerateId = boOperationRequestDetail.GovernerateId;
				daoOperationRequestDetail.CityId = boOperationRequestDetail.CityId;
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
				daoOperationRequestDetail.LocationLevelId = _locationLevelId.Value;
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
				DAOOperationRequestDetail.DeleteAllByLocationLevelId(ConnectionProvider, _locationLevelId.Value);
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
		
		public virtual Int32? LocationLevelId
		{
			get
			{
				 return _locationLevelId;
			}
			set
			{
				_locationLevelId = value;
				_isDirty = true;
			}
		}
		
		public virtual string LocationLevelCode
		{
			get
			{
				 return _locationLevelCode;
			}
			set
			{
				_locationLevelCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string LocationLevelNameEn
		{
			get
			{
				 return _locationLevelNameEn;
			}
			set
			{
				_locationLevelNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string LocationLevelNameAr
		{
			get
			{
				 return _locationLevelNameAr;
			}
			set
			{
				_locationLevelNameAr = value;
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
