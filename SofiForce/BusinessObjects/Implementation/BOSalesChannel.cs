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
	///This is the definition of the class BOSalesChannel.
	///It maintains a collection of BOClient,BOSalesOrder objects.
	///</Summary>
	public partial class BOSalesChannel : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _salesChannelId;
		protected string _salesChannelCode;
		protected string _salesChannelNameEn;
		protected string _salesChannelNameAr;
		protected Int32? _displayOrder;
		protected string _color;
		protected string _icon;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOClient> _boClientCollection;
		List<BOSalesOrder> _boSalesOrderCollection;
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
		public BOSalesChannel()
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
		///Int32 salesChannelId
		///</parameters>
		public BOSalesChannel(Int32 salesChannelId)
		{
			try
			{
				DAOSalesChannel daoSalesChannel = DAOSalesChannel.SelectOne(salesChannelId);
				_salesChannelId = daoSalesChannel.SalesChannelId;
				_salesChannelCode = daoSalesChannel.SalesChannelCode;
				_salesChannelNameEn = daoSalesChannel.SalesChannelNameEn;
				_salesChannelNameAr = daoSalesChannel.SalesChannelNameAr;
				_displayOrder = daoSalesChannel.DisplayOrder;
				_color = daoSalesChannel.Color;
				_icon = daoSalesChannel.Icon;
				_canEdit = daoSalesChannel.CanEdit;
				_canDelete = daoSalesChannel.CanDelete;
				_cBy = daoSalesChannel.CBy;
				_cDate = daoSalesChannel.CDate;
				_eBy = daoSalesChannel.EBy;
				_eDate = daoSalesChannel.EDate;
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
		///DAOSalesChannel
		///</parameters>
		protected internal BOSalesChannel(DAOSalesChannel daoSalesChannel)
		{
			try
			{
				_salesChannelId = daoSalesChannel.SalesChannelId;
				_salesChannelCode = daoSalesChannel.SalesChannelCode;
				_salesChannelNameEn = daoSalesChannel.SalesChannelNameEn;
				_salesChannelNameAr = daoSalesChannel.SalesChannelNameAr;
				_displayOrder = daoSalesChannel.DisplayOrder;
				_color = daoSalesChannel.Color;
				_icon = daoSalesChannel.Icon;
				_canEdit = daoSalesChannel.CanEdit;
				_canDelete = daoSalesChannel.CanDelete;
				_cBy = daoSalesChannel.CBy;
				_cDate = daoSalesChannel.CDate;
				_eBy = daoSalesChannel.EBy;
				_eDate = daoSalesChannel.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new SalesChannel record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOSalesChannel daoSalesChannel = new DAOSalesChannel();
			RegisterDataObject(daoSalesChannel);
			BeginTransaction("savenewBOSalesChannel");
			try
			{
				daoSalesChannel.SalesChannelCode = _salesChannelCode;
				daoSalesChannel.SalesChannelNameEn = _salesChannelNameEn;
				daoSalesChannel.SalesChannelNameAr = _salesChannelNameAr;
				daoSalesChannel.DisplayOrder = _displayOrder;
				daoSalesChannel.Color = _color;
				daoSalesChannel.Icon = _icon;
				daoSalesChannel.CanEdit = _canEdit;
				daoSalesChannel.CanDelete = _canDelete;
				daoSalesChannel.CBy = _cBy;
				daoSalesChannel.CDate = _cDate;
				daoSalesChannel.EBy = _eBy;
				daoSalesChannel.EDate = _eDate;
				daoSalesChannel.Insert();
				CommitTransaction();
				
				_salesChannelId = daoSalesChannel.SalesChannelId;
				_salesChannelCode = daoSalesChannel.SalesChannelCode;
				_salesChannelNameEn = daoSalesChannel.SalesChannelNameEn;
				_salesChannelNameAr = daoSalesChannel.SalesChannelNameAr;
				_displayOrder = daoSalesChannel.DisplayOrder;
				_color = daoSalesChannel.Color;
				_icon = daoSalesChannel.Icon;
				_canEdit = daoSalesChannel.CanEdit;
				_canDelete = daoSalesChannel.CanDelete;
				_cBy = daoSalesChannel.CBy;
				_cDate = daoSalesChannel.CDate;
				_eBy = daoSalesChannel.EBy;
				_eDate = daoSalesChannel.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOSalesChannel");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one SalesChannel record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOSalesChannel
		///</parameters>
		public virtual void Update()
		{
			DAOSalesChannel daoSalesChannel = new DAOSalesChannel();
			RegisterDataObject(daoSalesChannel);
			BeginTransaction("updateBOSalesChannel");
			try
			{
				daoSalesChannel.SalesChannelId = _salesChannelId;
				daoSalesChannel.SalesChannelCode = _salesChannelCode;
				daoSalesChannel.SalesChannelNameEn = _salesChannelNameEn;
				daoSalesChannel.SalesChannelNameAr = _salesChannelNameAr;
				daoSalesChannel.DisplayOrder = _displayOrder;
				daoSalesChannel.Color = _color;
				daoSalesChannel.Icon = _icon;
				daoSalesChannel.CanEdit = _canEdit;
				daoSalesChannel.CanDelete = _canDelete;
				daoSalesChannel.CBy = _cBy;
				daoSalesChannel.CDate = _cDate;
				daoSalesChannel.EBy = _eBy;
				daoSalesChannel.EDate = _eDate;
				daoSalesChannel.Update();
				CommitTransaction();
				
				_salesChannelId = daoSalesChannel.SalesChannelId;
				_salesChannelCode = daoSalesChannel.SalesChannelCode;
				_salesChannelNameEn = daoSalesChannel.SalesChannelNameEn;
				_salesChannelNameAr = daoSalesChannel.SalesChannelNameAr;
				_displayOrder = daoSalesChannel.DisplayOrder;
				_color = daoSalesChannel.Color;
				_icon = daoSalesChannel.Icon;
				_canEdit = daoSalesChannel.CanEdit;
				_canDelete = daoSalesChannel.CanDelete;
				_cBy = daoSalesChannel.CBy;
				_cDate = daoSalesChannel.CDate;
				_eBy = daoSalesChannel.EBy;
				_eDate = daoSalesChannel.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOSalesChannel");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one SalesChannel record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOSalesChannel daoSalesChannel = new DAOSalesChannel();
			RegisterDataObject(daoSalesChannel);
			BeginTransaction("deleteBOSalesChannel");
			try
			{
				daoSalesChannel.SalesChannelId = _salesChannelId;
				daoSalesChannel.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOSalesChannel");
				throw;
			}
		}
		
		///<Summary>
		///SalesChannelCollection
		///This method returns the collection of BOSalesChannel objects
		///</Summary>
		///<returns>
		///List[BOSalesChannel]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOSalesChannel> SalesChannelCollection()
		{
			try
			{
				IList<BOSalesChannel> boSalesChannelCollection = new List<BOSalesChannel>();
				IList<DAOSalesChannel> daoSalesChannelCollection = DAOSalesChannel.SelectAll();
			
				foreach(DAOSalesChannel daoSalesChannel in daoSalesChannelCollection)
					boSalesChannelCollection.Add(new BOSalesChannel(daoSalesChannel));
			
				return boSalesChannelCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesChannelCollectionCount
		///This method returns the collection count of BOSalesChannel objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 SalesChannelCollectionCount()
		{
			try
			{
				Int32 objCount = DAOSalesChannel.SelectAllCount();
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
		///BOSalesChannel
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
		///SalesOrderCollection
		///This method returns its collection of BOSalesOrder objects
		///</Summary>
		///<returns>
		///IList[BOSalesOrder]
		///</returns>
		///<parameters>
		///BOSalesChannel
		///</parameters>
		public virtual IList<BOSalesOrder> SalesOrderCollection()
		{
			try
			{
				if(_boSalesOrderCollection == null)
					LoadSalesOrderCollection();
				
				return _boSalesOrderCollection.AsReadOnly();
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
		///List<BOSalesChannel>
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
				IDictionary<string, IList<object>> retObj = DAOSalesChannel.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesChannelCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOSalesChannel objects, filtered by optional criteria
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
				IList<T> boSalesChannelCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOSalesChannel> daoSalesChannelCollection = DAOSalesChannel.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOSalesChannel resdaoSalesChannel in daoSalesChannelCollection)
					boSalesChannelCollection.Add((T)(object)new BOSalesChannel(resdaoSalesChannel));
			
				return boSalesChannelCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesChannelCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOSalesChannel objects, filtered by optional criteria
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
				Int32 objCount = DAOSalesChannel.SelectAllByCriteriaCount(lstDataCriteria);
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
				IList<DAOClient> daoClientCollection = DAOClient.SelectAllBySalesChannelId(_salesChannelId.Value);
				
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
				daoClient.SalesPoolId = boClient.SalesPoolId;
				daoClient.UserId = boClient.UserId;
				daoClient.Points = boClient.Points;
				daoClient.Wallet = boClient.Wallet;
				daoClient.DealId = boClient.DealId;
				daoClient.SalesChannelId = _salesChannelId.Value;
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
				DAOClient.DeleteAllBySalesChannelId(ConnectionProvider, _salesChannelId.Value);
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
		///LoadSalesOrderCollection
		///This method loads the internal collection of BOSalesOrder objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadSalesOrderCollection()
		{
			try
			{
				_boSalesOrderCollection = new List<BOSalesOrder>();
				IList<DAOSalesOrder> daoSalesOrderCollection = DAOSalesOrder.SelectAllBySalesChannelId(_salesChannelId.Value);
				
				foreach(DAOSalesOrder daoSalesOrder in daoSalesOrderCollection)
					_boSalesOrderCollection.Add(new BOSalesOrder(daoSalesOrder));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddSalesOrder
		///This method persists a BOSalesOrder object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOSalesOrder
		///</parameters>
		public virtual void AddSalesOrder(BOSalesOrder boSalesOrder)
		{
			DAOSalesOrder daoSalesOrder = new DAOSalesOrder();
			RegisterDataObject(daoSalesOrder);
			BeginTransaction("addSalesOrder");
			try
			{
				daoSalesOrder.SalesId = boSalesOrder.SalesId;
				daoSalesOrder.SalesCode = boSalesOrder.SalesCode;
				daoSalesOrder.SalesOrderTypeId = boSalesOrder.SalesOrderTypeId;
				daoSalesOrder.ClientId = boSalesOrder.ClientId;
				daoSalesOrder.BranchId = boSalesOrder.BranchId;
				daoSalesOrder.AgentId = boSalesOrder.AgentId;
				daoSalesOrder.RepresentativeId = boSalesOrder.RepresentativeId;
				daoSalesOrder.StoreId = boSalesOrder.StoreId;
				daoSalesOrder.PriorityTypeId = boSalesOrder.PriorityTypeId;
				daoSalesOrder.PaymentTermId = boSalesOrder.PaymentTermId;
				daoSalesOrder.SalesDate = boSalesOrder.SalesDate;
				daoSalesOrder.SalesTime = boSalesOrder.SalesTime;
				daoSalesOrder.SalesOrderStatusId = boSalesOrder.SalesOrderStatusId;
				daoSalesOrder.SalesOrderSourceId = boSalesOrder.SalesOrderSourceId;
				daoSalesOrder.SalesPoolId = boSalesOrder.SalesPoolId;
				daoSalesOrder.IsOpened = boSalesOrder.IsOpened;
				daoSalesOrder.OpenValue = boSalesOrder.OpenValue;
				daoSalesOrder.Latitude = boSalesOrder.Latitude;
				daoSalesOrder.Longitude = boSalesOrder.Longitude;
				daoSalesOrder.ItemTotal = boSalesOrder.ItemTotal;
				daoSalesOrder.ItemDiscountTotal = boSalesOrder.ItemDiscountTotal;
				daoSalesOrder.TaxTotal = boSalesOrder.TaxTotal;
				daoSalesOrder.CashDiscountTotal = boSalesOrder.CashDiscountTotal;
				daoSalesOrder.CustomDiscountTypeId = boSalesOrder.CustomDiscountTypeId;
				daoSalesOrder.CustomDiscountValue = boSalesOrder.CustomDiscountValue;
				daoSalesOrder.CustomDiscountTotal = boSalesOrder.CustomDiscountTotal;
				daoSalesOrder.DeliveryTotal = boSalesOrder.DeliveryTotal;
				daoSalesOrder.NetTotal = boSalesOrder.NetTotal;
				daoSalesOrder.Notes = boSalesOrder.Notes;
				daoSalesOrder.InvoiceRetry = boSalesOrder.InvoiceRetry;
				daoSalesOrder.HasError = boSalesOrder.HasError;
				daoSalesOrder.IsInvoiced = boSalesOrder.IsInvoiced;
				daoSalesOrder.InvoiceCode = boSalesOrder.InvoiceCode;
				daoSalesOrder.InvoiceDate = boSalesOrder.InvoiceDate;
				daoSalesOrder.CreateDate = boSalesOrder.CreateDate;
				daoSalesOrder.RecId = boSalesOrder.RecId;
				daoSalesOrder.CBy = boSalesOrder.CBy;
				daoSalesOrder.CDate = boSalesOrder.CDate;
				daoSalesOrder.EBy = boSalesOrder.EBy;
				daoSalesOrder.EDate = boSalesOrder.EDate;
				daoSalesOrder.SalesPerenId = boSalesOrder.SalesPerenId;
				daoSalesOrder.Inprogress = boSalesOrder.Inprogress;
				daoSalesOrder.IsBackoffice = boSalesOrder.IsBackoffice;
				daoSalesOrder.IsDeleted = boSalesOrder.IsDeleted;
				daoSalesOrder.SalesChannelId = _salesChannelId.Value;
				daoSalesOrder.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boSalesOrder = new BOSalesOrder(daoSalesOrder);
				if(_boSalesOrderCollection != null)
					_boSalesOrderCollection.Add(boSalesOrder);
			}
			catch
			{
				RollbackTransaction("addSalesOrder");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllSalesOrder
		///This method deletes all BOSalesOrder objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllSalesOrder()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllSalesOrder");
			try
			{
				DAOSalesOrder.DeleteAllBySalesChannelId(ConnectionProvider, _salesChannelId.Value);
				CommitTransaction();
				if(_boSalesOrderCollection != null)
				{
					_boSalesOrderCollection.Clear();
					_boSalesOrderCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllSalesOrder");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? SalesChannelId
		{
			get
			{
				 return _salesChannelId;
			}
			set
			{
				_salesChannelId = value;
				_isDirty = true;
			}
		}
		
		public virtual string SalesChannelCode
		{
			get
			{
				 return _salesChannelCode;
			}
			set
			{
				_salesChannelCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string SalesChannelNameEn
		{
			get
			{
				 return _salesChannelNameEn;
			}
			set
			{
				_salesChannelNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string SalesChannelNameAr
		{
			get
			{
				 return _salesChannelNameAr;
			}
			set
			{
				_salesChannelNameAr = value;
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
