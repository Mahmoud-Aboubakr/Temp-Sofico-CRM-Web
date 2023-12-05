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
	///This is the definition of the class BOSalesOrderType.
	///It maintains a collection of BOSalesOrder objects.
	///</Summary>
	public partial class BOSalesOrderType : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _salesOrderTypeId;
		protected string _salesOrderTypeCode;
		protected string _salesOrderTypeNameEn;
		protected string _salesOrderTypeNameAr;
		protected string _icon;
		protected string _color;
		protected bool? _isActive;
		protected Int32? _displayOrder;
		protected bool? _canDelete;
		protected bool? _canEdit;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
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
		public BOSalesOrderType()
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
		///Int32 salesOrderTypeId
		///</parameters>
		public BOSalesOrderType(Int32 salesOrderTypeId)
		{
			try
			{
				DAOSalesOrderType daoSalesOrderType = DAOSalesOrderType.SelectOne(salesOrderTypeId);
				_salesOrderTypeId = daoSalesOrderType.SalesOrderTypeId;
				_salesOrderTypeCode = daoSalesOrderType.SalesOrderTypeCode;
				_salesOrderTypeNameEn = daoSalesOrderType.SalesOrderTypeNameEn;
				_salesOrderTypeNameAr = daoSalesOrderType.SalesOrderTypeNameAr;
				_icon = daoSalesOrderType.Icon;
				_color = daoSalesOrderType.Color;
				_isActive = daoSalesOrderType.IsActive;
				_displayOrder = daoSalesOrderType.DisplayOrder;
				_canDelete = daoSalesOrderType.CanDelete;
				_canEdit = daoSalesOrderType.CanEdit;
				_cBy = daoSalesOrderType.CBy;
				_cDate = daoSalesOrderType.CDate;
				_eBy = daoSalesOrderType.EBy;
				_eDate = daoSalesOrderType.EDate;
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
		///DAOSalesOrderType
		///</parameters>
		protected internal BOSalesOrderType(DAOSalesOrderType daoSalesOrderType)
		{
			try
			{
				_salesOrderTypeId = daoSalesOrderType.SalesOrderTypeId;
				_salesOrderTypeCode = daoSalesOrderType.SalesOrderTypeCode;
				_salesOrderTypeNameEn = daoSalesOrderType.SalesOrderTypeNameEn;
				_salesOrderTypeNameAr = daoSalesOrderType.SalesOrderTypeNameAr;
				_icon = daoSalesOrderType.Icon;
				_color = daoSalesOrderType.Color;
				_isActive = daoSalesOrderType.IsActive;
				_displayOrder = daoSalesOrderType.DisplayOrder;
				_canDelete = daoSalesOrderType.CanDelete;
				_canEdit = daoSalesOrderType.CanEdit;
				_cBy = daoSalesOrderType.CBy;
				_cDate = daoSalesOrderType.CDate;
				_eBy = daoSalesOrderType.EBy;
				_eDate = daoSalesOrderType.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new SalesOrderType record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOSalesOrderType daoSalesOrderType = new DAOSalesOrderType();
			RegisterDataObject(daoSalesOrderType);
			BeginTransaction("savenewBOSalesOrderType");
			try
			{
				daoSalesOrderType.SalesOrderTypeCode = _salesOrderTypeCode;
				daoSalesOrderType.SalesOrderTypeNameEn = _salesOrderTypeNameEn;
				daoSalesOrderType.SalesOrderTypeNameAr = _salesOrderTypeNameAr;
				daoSalesOrderType.Icon = _icon;
				daoSalesOrderType.Color = _color;
				daoSalesOrderType.IsActive = _isActive;
				daoSalesOrderType.DisplayOrder = _displayOrder;
				daoSalesOrderType.CanDelete = _canDelete;
				daoSalesOrderType.CanEdit = _canEdit;
				daoSalesOrderType.CBy = _cBy;
				daoSalesOrderType.CDate = _cDate;
				daoSalesOrderType.EBy = _eBy;
				daoSalesOrderType.EDate = _eDate;
				daoSalesOrderType.Insert();
				CommitTransaction();
				
				_salesOrderTypeId = daoSalesOrderType.SalesOrderTypeId;
				_salesOrderTypeCode = daoSalesOrderType.SalesOrderTypeCode;
				_salesOrderTypeNameEn = daoSalesOrderType.SalesOrderTypeNameEn;
				_salesOrderTypeNameAr = daoSalesOrderType.SalesOrderTypeNameAr;
				_icon = daoSalesOrderType.Icon;
				_color = daoSalesOrderType.Color;
				_isActive = daoSalesOrderType.IsActive;
				_displayOrder = daoSalesOrderType.DisplayOrder;
				_canDelete = daoSalesOrderType.CanDelete;
				_canEdit = daoSalesOrderType.CanEdit;
				_cBy = daoSalesOrderType.CBy;
				_cDate = daoSalesOrderType.CDate;
				_eBy = daoSalesOrderType.EBy;
				_eDate = daoSalesOrderType.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOSalesOrderType");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one SalesOrderType record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOSalesOrderType
		///</parameters>
		public virtual void Update()
		{
			DAOSalesOrderType daoSalesOrderType = new DAOSalesOrderType();
			RegisterDataObject(daoSalesOrderType);
			BeginTransaction("updateBOSalesOrderType");
			try
			{
				daoSalesOrderType.SalesOrderTypeId = _salesOrderTypeId;
				daoSalesOrderType.SalesOrderTypeCode = _salesOrderTypeCode;
				daoSalesOrderType.SalesOrderTypeNameEn = _salesOrderTypeNameEn;
				daoSalesOrderType.SalesOrderTypeNameAr = _salesOrderTypeNameAr;
				daoSalesOrderType.Icon = _icon;
				daoSalesOrderType.Color = _color;
				daoSalesOrderType.IsActive = _isActive;
				daoSalesOrderType.DisplayOrder = _displayOrder;
				daoSalesOrderType.CanDelete = _canDelete;
				daoSalesOrderType.CanEdit = _canEdit;
				daoSalesOrderType.CBy = _cBy;
				daoSalesOrderType.CDate = _cDate;
				daoSalesOrderType.EBy = _eBy;
				daoSalesOrderType.EDate = _eDate;
				daoSalesOrderType.Update();
				CommitTransaction();
				
				_salesOrderTypeId = daoSalesOrderType.SalesOrderTypeId;
				_salesOrderTypeCode = daoSalesOrderType.SalesOrderTypeCode;
				_salesOrderTypeNameEn = daoSalesOrderType.SalesOrderTypeNameEn;
				_salesOrderTypeNameAr = daoSalesOrderType.SalesOrderTypeNameAr;
				_icon = daoSalesOrderType.Icon;
				_color = daoSalesOrderType.Color;
				_isActive = daoSalesOrderType.IsActive;
				_displayOrder = daoSalesOrderType.DisplayOrder;
				_canDelete = daoSalesOrderType.CanDelete;
				_canEdit = daoSalesOrderType.CanEdit;
				_cBy = daoSalesOrderType.CBy;
				_cDate = daoSalesOrderType.CDate;
				_eBy = daoSalesOrderType.EBy;
				_eDate = daoSalesOrderType.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOSalesOrderType");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one SalesOrderType record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOSalesOrderType daoSalesOrderType = new DAOSalesOrderType();
			RegisterDataObject(daoSalesOrderType);
			BeginTransaction("deleteBOSalesOrderType");
			try
			{
				daoSalesOrderType.SalesOrderTypeId = _salesOrderTypeId;
				daoSalesOrderType.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOSalesOrderType");
				throw;
			}
		}
		
		///<Summary>
		///SalesOrderTypeCollection
		///This method returns the collection of BOSalesOrderType objects
		///</Summary>
		///<returns>
		///List[BOSalesOrderType]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOSalesOrderType> SalesOrderTypeCollection()
		{
			try
			{
				IList<BOSalesOrderType> boSalesOrderTypeCollection = new List<BOSalesOrderType>();
				IList<DAOSalesOrderType> daoSalesOrderTypeCollection = DAOSalesOrderType.SelectAll();
			
				foreach(DAOSalesOrderType daoSalesOrderType in daoSalesOrderTypeCollection)
					boSalesOrderTypeCollection.Add(new BOSalesOrderType(daoSalesOrderType));
			
				return boSalesOrderTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderTypeCollectionCount
		///This method returns the collection count of BOSalesOrderType objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 SalesOrderTypeCollectionCount()
		{
			try
			{
				Int32 objCount = DAOSalesOrderType.SelectAllCount();
				return objCount;
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
		///BOSalesOrderType
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
		///List<BOSalesOrderType>
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
				IDictionary<string, IList<object>> retObj = DAOSalesOrderType.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderTypeCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOSalesOrderType objects, filtered by optional criteria
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
				IList<T> boSalesOrderTypeCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOSalesOrderType> daoSalesOrderTypeCollection = DAOSalesOrderType.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOSalesOrderType resdaoSalesOrderType in daoSalesOrderTypeCollection)
					boSalesOrderTypeCollection.Add((T)(object)new BOSalesOrderType(resdaoSalesOrderType));
			
				return boSalesOrderTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderTypeCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOSalesOrderType objects, filtered by optional criteria
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
				Int32 objCount = DAOSalesOrderType.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
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
				IList<DAOSalesOrder> daoSalesOrderCollection = DAOSalesOrder.SelectAllBySalesOrderTypeId(_salesOrderTypeId.Value);
				
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
				daoSalesOrder.SalesOrderTypeId = _salesOrderTypeId.Value;
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
				DAOSalesOrder.DeleteAllBySalesOrderTypeId(ConnectionProvider, _salesOrderTypeId.Value);
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
		
		public virtual Int32? SalesOrderTypeId
		{
			get
			{
				 return _salesOrderTypeId;
			}
			set
			{
				_salesOrderTypeId = value;
				_isDirty = true;
			}
		}
		
		public virtual string SalesOrderTypeCode
		{
			get
			{
				 return _salesOrderTypeCode;
			}
			set
			{
				_salesOrderTypeCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string SalesOrderTypeNameEn
		{
			get
			{
				 return _salesOrderTypeNameEn;
			}
			set
			{
				_salesOrderTypeNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string SalesOrderTypeNameAr
		{
			get
			{
				 return _salesOrderTypeNameAr;
			}
			set
			{
				_salesOrderTypeNameAr = value;
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