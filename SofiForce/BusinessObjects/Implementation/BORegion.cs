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
	///This is the definition of the class BORegion.
	///It maintains a collection of BOClient,BOGovernerate,BOOperationRequestDetail,BOSalesOrderAddress objects.
	///</Summary>
	public partial class BORegion : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _regionId;
		protected string _regionNameAr;
		protected string _regionNameEn;
		protected string _regionCode;
		protected bool? _isActive;
		protected Int32? _displayOrder;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected string _color;
		protected string _icon;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOClient> _boClientCollection;
		List<BOGovernerate> _boGovernerateCollection;
		List<BOOperationRequestDetail> _boOperationRequestDetailCollection;
		List<BOSalesOrderAddress> _boSalesOrderAddressCollection;
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
		public BORegion()
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
		///Int32 regionId
		///</parameters>
		public BORegion(Int32 regionId)
		{
			try
			{
				DAORegion daoRegion = DAORegion.SelectOne(regionId);
				_regionId = daoRegion.RegionId;
				_regionNameAr = daoRegion.RegionNameAr;
				_regionNameEn = daoRegion.RegionNameEn;
				_regionCode = daoRegion.RegionCode;
				_isActive = daoRegion.IsActive;
				_displayOrder = daoRegion.DisplayOrder;
				_canEdit = daoRegion.CanEdit;
				_canDelete = daoRegion.CanDelete;
				_color = daoRegion.Color;
				_icon = daoRegion.Icon;
				_cBy = daoRegion.CBy;
				_cDate = daoRegion.CDate;
				_eBy = daoRegion.EBy;
				_eDate = daoRegion.EDate;
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
		///DAORegion
		///</parameters>
		protected internal BORegion(DAORegion daoRegion)
		{
			try
			{
				_regionId = daoRegion.RegionId;
				_regionNameAr = daoRegion.RegionNameAr;
				_regionNameEn = daoRegion.RegionNameEn;
				_regionCode = daoRegion.RegionCode;
				_isActive = daoRegion.IsActive;
				_displayOrder = daoRegion.DisplayOrder;
				_canEdit = daoRegion.CanEdit;
				_canDelete = daoRegion.CanDelete;
				_color = daoRegion.Color;
				_icon = daoRegion.Icon;
				_cBy = daoRegion.CBy;
				_cDate = daoRegion.CDate;
				_eBy = daoRegion.EBy;
				_eDate = daoRegion.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new Region record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAORegion daoRegion = new DAORegion();
			RegisterDataObject(daoRegion);
			BeginTransaction("savenewBORegion");
			try
			{
				daoRegion.RegionNameAr = _regionNameAr;
				daoRegion.RegionNameEn = _regionNameEn;
				daoRegion.RegionCode = _regionCode;
				daoRegion.IsActive = _isActive;
				daoRegion.DisplayOrder = _displayOrder;
				daoRegion.CanEdit = _canEdit;
				daoRegion.CanDelete = _canDelete;
				daoRegion.Color = _color;
				daoRegion.Icon = _icon;
				daoRegion.CBy = _cBy;
				daoRegion.CDate = _cDate;
				daoRegion.EBy = _eBy;
				daoRegion.EDate = _eDate;
				daoRegion.Insert();
				CommitTransaction();
				
				_regionId = daoRegion.RegionId;
				_regionNameAr = daoRegion.RegionNameAr;
				_regionNameEn = daoRegion.RegionNameEn;
				_regionCode = daoRegion.RegionCode;
				_isActive = daoRegion.IsActive;
				_displayOrder = daoRegion.DisplayOrder;
				_canEdit = daoRegion.CanEdit;
				_canDelete = daoRegion.CanDelete;
				_color = daoRegion.Color;
				_icon = daoRegion.Icon;
				_cBy = daoRegion.CBy;
				_cDate = daoRegion.CDate;
				_eBy = daoRegion.EBy;
				_eDate = daoRegion.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBORegion");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one Region record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BORegion
		///</parameters>
		public virtual void Update()
		{
			DAORegion daoRegion = new DAORegion();
			RegisterDataObject(daoRegion);
			BeginTransaction("updateBORegion");
			try
			{
				daoRegion.RegionId = _regionId;
				daoRegion.RegionNameAr = _regionNameAr;
				daoRegion.RegionNameEn = _regionNameEn;
				daoRegion.RegionCode = _regionCode;
				daoRegion.IsActive = _isActive;
				daoRegion.DisplayOrder = _displayOrder;
				daoRegion.CanEdit = _canEdit;
				daoRegion.CanDelete = _canDelete;
				daoRegion.Color = _color;
				daoRegion.Icon = _icon;
				daoRegion.CBy = _cBy;
				daoRegion.CDate = _cDate;
				daoRegion.EBy = _eBy;
				daoRegion.EDate = _eDate;
				daoRegion.Update();
				CommitTransaction();
				
				_regionId = daoRegion.RegionId;
				_regionNameAr = daoRegion.RegionNameAr;
				_regionNameEn = daoRegion.RegionNameEn;
				_regionCode = daoRegion.RegionCode;
				_isActive = daoRegion.IsActive;
				_displayOrder = daoRegion.DisplayOrder;
				_canEdit = daoRegion.CanEdit;
				_canDelete = daoRegion.CanDelete;
				_color = daoRegion.Color;
				_icon = daoRegion.Icon;
				_cBy = daoRegion.CBy;
				_cDate = daoRegion.CDate;
				_eBy = daoRegion.EBy;
				_eDate = daoRegion.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBORegion");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one Region record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAORegion daoRegion = new DAORegion();
			RegisterDataObject(daoRegion);
			BeginTransaction("deleteBORegion");
			try
			{
				daoRegion.RegionId = _regionId;
				daoRegion.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBORegion");
				throw;
			}
		}
		
		///<Summary>
		///RegionCollection
		///This method returns the collection of BORegion objects
		///</Summary>
		///<returns>
		///List[BORegion]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BORegion> RegionCollection()
		{
			try
			{
				IList<BORegion> boRegionCollection = new List<BORegion>();
				IList<DAORegion> daoRegionCollection = DAORegion.SelectAll();
			
				foreach(DAORegion daoRegion in daoRegionCollection)
					boRegionCollection.Add(new BORegion(daoRegion));
			
				return boRegionCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RegionCollectionCount
		///This method returns the collection count of BORegion objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 RegionCollectionCount()
		{
			try
			{
				Int32 objCount = DAORegion.SelectAllCount();
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
		///BORegion
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
		///GovernerateCollection
		///This method returns its collection of BOGovernerate objects
		///</Summary>
		///<returns>
		///IList[BOGovernerate]
		///</returns>
		///<parameters>
		///BORegion
		///</parameters>
		public virtual IList<BOGovernerate> GovernerateCollection()
		{
			try
			{
				if(_boGovernerateCollection == null)
					LoadGovernerateCollection();
				
				return _boGovernerateCollection.AsReadOnly();
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
		///BORegion
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
		///SalesOrderAddressCollection
		///This method returns its collection of BOSalesOrderAddress objects
		///</Summary>
		///<returns>
		///IList[BOSalesOrderAddress]
		///</returns>
		///<parameters>
		///BORegion
		///</parameters>
		public virtual IList<BOSalesOrderAddress> SalesOrderAddressCollection()
		{
			try
			{
				if(_boSalesOrderAddressCollection == null)
					LoadSalesOrderAddressCollection();
				
				return _boSalesOrderAddressCollection.AsReadOnly();
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
		///List<BORegion>
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
				IDictionary<string, IList<object>> retObj = DAORegion.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RegionCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BORegion objects, filtered by optional criteria
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
				IList<T> boRegionCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAORegion> daoRegionCollection = DAORegion.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAORegion resdaoRegion in daoRegionCollection)
					boRegionCollection.Add((T)(object)new BORegion(resdaoRegion));
			
				return boRegionCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RegionCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BORegion objects, filtered by optional criteria
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
				Int32 objCount = DAORegion.SelectAllByCriteriaCount(lstDataCriteria);
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
				IList<DAOClient> daoClientCollection = DAOClient.SelectAllByRegionId(_regionId.Value);
				
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
				daoClient.GovernerateId = boClient.GovernerateId;
				daoClient.CityId = boClient.CityId;
				daoClient.LocationLevelId = boClient.LocationLevelId;
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
				daoClient.RegionId = _regionId.Value;
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
				DAOClient.DeleteAllByRegionId(ConnectionProvider, _regionId.Value);
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
		///LoadGovernerateCollection
		///This method loads the internal collection of BOGovernerate objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadGovernerateCollection()
		{
			try
			{
				_boGovernerateCollection = new List<BOGovernerate>();
				IList<DAOGovernerate> daoGovernerateCollection = DAOGovernerate.SelectAllByRegionId(_regionId.Value);
				
				foreach(DAOGovernerate daoGovernerate in daoGovernerateCollection)
					_boGovernerateCollection.Add(new BOGovernerate(daoGovernerate));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddGovernerate
		///This method persists a BOGovernerate object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOGovernerate
		///</parameters>
		public virtual void AddGovernerate(BOGovernerate boGovernerate)
		{
			DAOGovernerate daoGovernerate = new DAOGovernerate();
			RegisterDataObject(daoGovernerate);
			BeginTransaction("addGovernerate");
			try
			{
				daoGovernerate.GovernerateId = boGovernerate.GovernerateId;
				daoGovernerate.GovernerateCode = boGovernerate.GovernerateCode;
				daoGovernerate.GovernerateNameAr = boGovernerate.GovernerateNameAr;
				daoGovernerate.GovernerateNameEn = boGovernerate.GovernerateNameEn;
				daoGovernerate.IsActive = boGovernerate.IsActive;
				daoGovernerate.DisplayOrder = boGovernerate.DisplayOrder;
				daoGovernerate.CanEdit = boGovernerate.CanEdit;
				daoGovernerate.CanDelete = boGovernerate.CanDelete;
				daoGovernerate.Color = boGovernerate.Color;
				daoGovernerate.Icon = boGovernerate.Icon;
				daoGovernerate.CBy = boGovernerate.CBy;
				daoGovernerate.CDate = boGovernerate.CDate;
				daoGovernerate.EBy = boGovernerate.EBy;
				daoGovernerate.EDate = boGovernerate.EDate;
				daoGovernerate.RegionId = _regionId.Value;
				daoGovernerate.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boGovernerate = new BOGovernerate(daoGovernerate);
				if(_boGovernerateCollection != null)
					_boGovernerateCollection.Add(boGovernerate);
			}
			catch
			{
				RollbackTransaction("addGovernerate");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllGovernerate
		///This method deletes all BOGovernerate objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllGovernerate()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllGovernerate");
			try
			{
				DAOGovernerate.DeleteAllByRegionId(ConnectionProvider, _regionId.Value);
				CommitTransaction();
				if(_boGovernerateCollection != null)
				{
					_boGovernerateCollection.Clear();
					_boGovernerateCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllGovernerate");
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
				IList<DAOOperationRequestDetail> daoOperationRequestDetailCollection = DAOOperationRequestDetail.SelectAllByRegionId(_regionId.Value);
				
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
				daoOperationRequestDetail.RegionId = _regionId.Value;
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
				DAOOperationRequestDetail.DeleteAllByRegionId(ConnectionProvider, _regionId.Value);
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
		
		///<Summary>
		///LoadSalesOrderAddressCollection
		///This method loads the internal collection of BOSalesOrderAddress objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadSalesOrderAddressCollection()
		{
			try
			{
				_boSalesOrderAddressCollection = new List<BOSalesOrderAddress>();
				IList<DAOSalesOrderAddress> daoSalesOrderAddressCollection = DAOSalesOrderAddress.SelectAllByRegionId(_regionId.Value);
				
				foreach(DAOSalesOrderAddress daoSalesOrderAddress in daoSalesOrderAddressCollection)
					_boSalesOrderAddressCollection.Add(new BOSalesOrderAddress(daoSalesOrderAddress));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddSalesOrderAddress
		///This method persists a BOSalesOrderAddress object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOSalesOrderAddress
		///</parameters>
		public virtual void AddSalesOrderAddress(BOSalesOrderAddress boSalesOrderAddress)
		{
			DAOSalesOrderAddress daoSalesOrderAddress = new DAOSalesOrderAddress();
			RegisterDataObject(daoSalesOrderAddress);
			BeginTransaction("addSalesOrderAddress");
			try
			{
				daoSalesOrderAddress.SalesAddressId = boSalesOrderAddress.SalesAddressId;
				daoSalesOrderAddress.SalesId = boSalesOrderAddress.SalesId;
				daoSalesOrderAddress.GovernerateId = boSalesOrderAddress.GovernerateId;
				daoSalesOrderAddress.CityId = boSalesOrderAddress.CityId;
				daoSalesOrderAddress.Address = boSalesOrderAddress.Address;
				daoSalesOrderAddress.Landmark = boSalesOrderAddress.Landmark;
				daoSalesOrderAddress.Latitude = boSalesOrderAddress.Latitude;
				daoSalesOrderAddress.Longitude = boSalesOrderAddress.Longitude;
				daoSalesOrderAddress.Building = boSalesOrderAddress.Building;
				daoSalesOrderAddress.Floor = boSalesOrderAddress.Floor;
				daoSalesOrderAddress.Property = boSalesOrderAddress.Property;
				daoSalesOrderAddress.Mobile = boSalesOrderAddress.Mobile;
				daoSalesOrderAddress.WhatsApp = boSalesOrderAddress.WhatsApp;
				daoSalesOrderAddress.Phone = boSalesOrderAddress.Phone;
				daoSalesOrderAddress.EBy = boSalesOrderAddress.EBy;
				daoSalesOrderAddress.EDate = boSalesOrderAddress.EDate;
				daoSalesOrderAddress.RegionId = _regionId.Value;
				daoSalesOrderAddress.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boSalesOrderAddress = new BOSalesOrderAddress(daoSalesOrderAddress);
				if(_boSalesOrderAddressCollection != null)
					_boSalesOrderAddressCollection.Add(boSalesOrderAddress);
			}
			catch
			{
				RollbackTransaction("addSalesOrderAddress");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllSalesOrderAddress
		///This method deletes all BOSalesOrderAddress objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllSalesOrderAddress()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllSalesOrderAddress");
			try
			{
				DAOSalesOrderAddress.DeleteAllByRegionId(ConnectionProvider, _regionId.Value);
				CommitTransaction();
				if(_boSalesOrderAddressCollection != null)
				{
					_boSalesOrderAddressCollection.Clear();
					_boSalesOrderAddressCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllSalesOrderAddress");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? RegionId
		{
			get
			{
				 return _regionId;
			}
			set
			{
				_regionId = value;
				_isDirty = true;
			}
		}
		
		public virtual string RegionNameAr
		{
			get
			{
				 return _regionNameAr;
			}
			set
			{
				_regionNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string RegionNameEn
		{
			get
			{
				 return _regionNameEn;
			}
			set
			{
				_regionNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string RegionCode
		{
			get
			{
				 return _regionCode;
			}
			set
			{
				_regionCode = value;
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
