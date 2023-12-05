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
	///This is the definition of the class BOPaymentTerm.
	///It maintains a collection of BOClient,BOSalesOrder objects.
	///</Summary>
	public partial class BOPaymentTerm : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _paymentTermId;
		protected string _paymentTermCode;
		protected string _paymentTermNameAr;
		protected string _paymentTermNameEn;
		protected string _icon;
		protected string _color;
		protected bool? _isActive;
		protected Int32? _displayOrder;
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
		public BOPaymentTerm()
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
		///Int32 paymentTermId
		///</parameters>
		public BOPaymentTerm(Int32 paymentTermId)
		{
			try
			{
				DAOPaymentTerm daoPaymentTerm = DAOPaymentTerm.SelectOne(paymentTermId);
				_paymentTermId = daoPaymentTerm.PaymentTermId;
				_paymentTermCode = daoPaymentTerm.PaymentTermCode;
				_paymentTermNameAr = daoPaymentTerm.PaymentTermNameAr;
				_paymentTermNameEn = daoPaymentTerm.PaymentTermNameEn;
				_icon = daoPaymentTerm.Icon;
				_color = daoPaymentTerm.Color;
				_isActive = daoPaymentTerm.IsActive;
				_displayOrder = daoPaymentTerm.DisplayOrder;
				_canEdit = daoPaymentTerm.CanEdit;
				_canDelete = daoPaymentTerm.CanDelete;
				_cBy = daoPaymentTerm.CBy;
				_cDate = daoPaymentTerm.CDate;
				_eBy = daoPaymentTerm.EBy;
				_eDate = daoPaymentTerm.EDate;
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
		///DAOPaymentTerm
		///</parameters>
		protected internal BOPaymentTerm(DAOPaymentTerm daoPaymentTerm)
		{
			try
			{
				_paymentTermId = daoPaymentTerm.PaymentTermId;
				_paymentTermCode = daoPaymentTerm.PaymentTermCode;
				_paymentTermNameAr = daoPaymentTerm.PaymentTermNameAr;
				_paymentTermNameEn = daoPaymentTerm.PaymentTermNameEn;
				_icon = daoPaymentTerm.Icon;
				_color = daoPaymentTerm.Color;
				_isActive = daoPaymentTerm.IsActive;
				_displayOrder = daoPaymentTerm.DisplayOrder;
				_canEdit = daoPaymentTerm.CanEdit;
				_canDelete = daoPaymentTerm.CanDelete;
				_cBy = daoPaymentTerm.CBy;
				_cDate = daoPaymentTerm.CDate;
				_eBy = daoPaymentTerm.EBy;
				_eDate = daoPaymentTerm.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new PaymentTerm record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOPaymentTerm daoPaymentTerm = new DAOPaymentTerm();
			RegisterDataObject(daoPaymentTerm);
			BeginTransaction("savenewBOPaymentTerm");
			try
			{
				daoPaymentTerm.PaymentTermCode = _paymentTermCode;
				daoPaymentTerm.PaymentTermNameAr = _paymentTermNameAr;
				daoPaymentTerm.PaymentTermNameEn = _paymentTermNameEn;
				daoPaymentTerm.Icon = _icon;
				daoPaymentTerm.Color = _color;
				daoPaymentTerm.IsActive = _isActive;
				daoPaymentTerm.DisplayOrder = _displayOrder;
				daoPaymentTerm.CanEdit = _canEdit;
				daoPaymentTerm.CanDelete = _canDelete;
				daoPaymentTerm.CBy = _cBy;
				daoPaymentTerm.CDate = _cDate;
				daoPaymentTerm.EBy = _eBy;
				daoPaymentTerm.EDate = _eDate;
				daoPaymentTerm.Insert();
				CommitTransaction();
				
				_paymentTermId = daoPaymentTerm.PaymentTermId;
				_paymentTermCode = daoPaymentTerm.PaymentTermCode;
				_paymentTermNameAr = daoPaymentTerm.PaymentTermNameAr;
				_paymentTermNameEn = daoPaymentTerm.PaymentTermNameEn;
				_icon = daoPaymentTerm.Icon;
				_color = daoPaymentTerm.Color;
				_isActive = daoPaymentTerm.IsActive;
				_displayOrder = daoPaymentTerm.DisplayOrder;
				_canEdit = daoPaymentTerm.CanEdit;
				_canDelete = daoPaymentTerm.CanDelete;
				_cBy = daoPaymentTerm.CBy;
				_cDate = daoPaymentTerm.CDate;
				_eBy = daoPaymentTerm.EBy;
				_eDate = daoPaymentTerm.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOPaymentTerm");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one PaymentTerm record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOPaymentTerm
		///</parameters>
		public virtual void Update()
		{
			DAOPaymentTerm daoPaymentTerm = new DAOPaymentTerm();
			RegisterDataObject(daoPaymentTerm);
			BeginTransaction("updateBOPaymentTerm");
			try
			{
				daoPaymentTerm.PaymentTermId = _paymentTermId;
				daoPaymentTerm.PaymentTermCode = _paymentTermCode;
				daoPaymentTerm.PaymentTermNameAr = _paymentTermNameAr;
				daoPaymentTerm.PaymentTermNameEn = _paymentTermNameEn;
				daoPaymentTerm.Icon = _icon;
				daoPaymentTerm.Color = _color;
				daoPaymentTerm.IsActive = _isActive;
				daoPaymentTerm.DisplayOrder = _displayOrder;
				daoPaymentTerm.CanEdit = _canEdit;
				daoPaymentTerm.CanDelete = _canDelete;
				daoPaymentTerm.CBy = _cBy;
				daoPaymentTerm.CDate = _cDate;
				daoPaymentTerm.EBy = _eBy;
				daoPaymentTerm.EDate = _eDate;
				daoPaymentTerm.Update();
				CommitTransaction();
				
				_paymentTermId = daoPaymentTerm.PaymentTermId;
				_paymentTermCode = daoPaymentTerm.PaymentTermCode;
				_paymentTermNameAr = daoPaymentTerm.PaymentTermNameAr;
				_paymentTermNameEn = daoPaymentTerm.PaymentTermNameEn;
				_icon = daoPaymentTerm.Icon;
				_color = daoPaymentTerm.Color;
				_isActive = daoPaymentTerm.IsActive;
				_displayOrder = daoPaymentTerm.DisplayOrder;
				_canEdit = daoPaymentTerm.CanEdit;
				_canDelete = daoPaymentTerm.CanDelete;
				_cBy = daoPaymentTerm.CBy;
				_cDate = daoPaymentTerm.CDate;
				_eBy = daoPaymentTerm.EBy;
				_eDate = daoPaymentTerm.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOPaymentTerm");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one PaymentTerm record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOPaymentTerm daoPaymentTerm = new DAOPaymentTerm();
			RegisterDataObject(daoPaymentTerm);
			BeginTransaction("deleteBOPaymentTerm");
			try
			{
				daoPaymentTerm.PaymentTermId = _paymentTermId;
				daoPaymentTerm.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOPaymentTerm");
				throw;
			}
		}
		
		///<Summary>
		///PaymentTermCollection
		///This method returns the collection of BOPaymentTerm objects
		///</Summary>
		///<returns>
		///List[BOPaymentTerm]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOPaymentTerm> PaymentTermCollection()
		{
			try
			{
				IList<BOPaymentTerm> boPaymentTermCollection = new List<BOPaymentTerm>();
				IList<DAOPaymentTerm> daoPaymentTermCollection = DAOPaymentTerm.SelectAll();
			
				foreach(DAOPaymentTerm daoPaymentTerm in daoPaymentTermCollection)
					boPaymentTermCollection.Add(new BOPaymentTerm(daoPaymentTerm));
			
				return boPaymentTermCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PaymentTermCollectionCount
		///This method returns the collection count of BOPaymentTerm objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 PaymentTermCollectionCount()
		{
			try
			{
				Int32 objCount = DAOPaymentTerm.SelectAllCount();
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
		///BOPaymentTerm
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
		///BOPaymentTerm
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
		///List<BOPaymentTerm>
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
				IDictionary<string, IList<object>> retObj = DAOPaymentTerm.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PaymentTermCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOPaymentTerm objects, filtered by optional criteria
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
				IList<T> boPaymentTermCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOPaymentTerm> daoPaymentTermCollection = DAOPaymentTerm.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOPaymentTerm resdaoPaymentTerm in daoPaymentTermCollection)
					boPaymentTermCollection.Add((T)(object)new BOPaymentTerm(resdaoPaymentTerm));
			
				return boPaymentTermCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PaymentTermCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOPaymentTerm objects, filtered by optional criteria
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
				Int32 objCount = DAOPaymentTerm.SelectAllByCriteriaCount(lstDataCriteria);
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
				IList<DAOClient> daoClientCollection = DAOClient.SelectAllByPaymentTermId(_paymentTermId.Value);
				
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
				daoClient.PaymentTermId = _paymentTermId.Value;
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
				DAOClient.DeleteAllByPaymentTermId(ConnectionProvider, _paymentTermId.Value);
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
				IList<DAOSalesOrder> daoSalesOrderCollection = DAOSalesOrder.SelectAllByPaymentTermId(_paymentTermId.Value);
				
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
				daoSalesOrder.SalesDate = boSalesOrder.SalesDate;
				daoSalesOrder.SalesTime = boSalesOrder.SalesTime;
				daoSalesOrder.SalesOrderStatusId = boSalesOrder.SalesOrderStatusId;
				daoSalesOrder.SalesOrderSourceId = boSalesOrder.SalesOrderSourceId;
				daoSalesOrder.SalesChannelId = boSalesOrder.SalesChannelId;
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
				daoSalesOrder.PaymentTermId = _paymentTermId.Value;
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
				DAOSalesOrder.DeleteAllByPaymentTermId(ConnectionProvider, _paymentTermId.Value);
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
		
		public virtual Int32? PaymentTermId
		{
			get
			{
				 return _paymentTermId;
			}
			set
			{
				_paymentTermId = value;
				_isDirty = true;
			}
		}
		
		public virtual string PaymentTermCode
		{
			get
			{
				 return _paymentTermCode;
			}
			set
			{
				_paymentTermCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string PaymentTermNameAr
		{
			get
			{
				 return _paymentTermNameAr;
			}
			set
			{
				_paymentTermNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string PaymentTermNameEn
		{
			get
			{
				 return _paymentTermNameEn;
			}
			set
			{
				_paymentTermNameEn = value;
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
