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
	///This is the definition of the class BOCustomDiscountType.
	///It maintains a collection of BOSalesOrder objects.
	///</Summary>
	public partial class BOCustomDiscountType : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _customDiscountTypeId;
		protected string _customDiscountTypeCode;
		protected string _customDiscountTypeNameEn;
		protected string _customDiscountTypeNameAr;
		protected string _icon;
		protected string _color;
		protected bool? _isActive;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected Int32? _displayOrder;
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
		public BOCustomDiscountType()
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
		///Int32 customDiscountTypeId
		///</parameters>
		public BOCustomDiscountType(Int32 customDiscountTypeId)
		{
			try
			{
				DAOCustomDiscountType daoCustomDiscountType = DAOCustomDiscountType.SelectOne(customDiscountTypeId);
				_customDiscountTypeId = daoCustomDiscountType.CustomDiscountTypeId;
				_customDiscountTypeCode = daoCustomDiscountType.CustomDiscountTypeCode;
				_customDiscountTypeNameEn = daoCustomDiscountType.CustomDiscountTypeNameEn;
				_customDiscountTypeNameAr = daoCustomDiscountType.CustomDiscountTypeNameAr;
				_icon = daoCustomDiscountType.Icon;
				_color = daoCustomDiscountType.Color;
				_isActive = daoCustomDiscountType.IsActive;
				_canEdit = daoCustomDiscountType.CanEdit;
				_canDelete = daoCustomDiscountType.CanDelete;
				_displayOrder = daoCustomDiscountType.DisplayOrder;
				_cBy = daoCustomDiscountType.CBy;
				_cDate = daoCustomDiscountType.CDate;
				_eBy = daoCustomDiscountType.EBy;
				_eDate = daoCustomDiscountType.EDate;
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
		///DAOCustomDiscountType
		///</parameters>
		protected internal BOCustomDiscountType(DAOCustomDiscountType daoCustomDiscountType)
		{
			try
			{
				_customDiscountTypeId = daoCustomDiscountType.CustomDiscountTypeId;
				_customDiscountTypeCode = daoCustomDiscountType.CustomDiscountTypeCode;
				_customDiscountTypeNameEn = daoCustomDiscountType.CustomDiscountTypeNameEn;
				_customDiscountTypeNameAr = daoCustomDiscountType.CustomDiscountTypeNameAr;
				_icon = daoCustomDiscountType.Icon;
				_color = daoCustomDiscountType.Color;
				_isActive = daoCustomDiscountType.IsActive;
				_canEdit = daoCustomDiscountType.CanEdit;
				_canDelete = daoCustomDiscountType.CanDelete;
				_displayOrder = daoCustomDiscountType.DisplayOrder;
				_cBy = daoCustomDiscountType.CBy;
				_cDate = daoCustomDiscountType.CDate;
				_eBy = daoCustomDiscountType.EBy;
				_eDate = daoCustomDiscountType.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new CustomDiscountType record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOCustomDiscountType daoCustomDiscountType = new DAOCustomDiscountType();
			RegisterDataObject(daoCustomDiscountType);
			BeginTransaction("savenewBOCustomDiscountType");
			try
			{
				daoCustomDiscountType.CustomDiscountTypeId = _customDiscountTypeId;
				daoCustomDiscountType.CustomDiscountTypeCode = _customDiscountTypeCode;
				daoCustomDiscountType.CustomDiscountTypeNameEn = _customDiscountTypeNameEn;
				daoCustomDiscountType.CustomDiscountTypeNameAr = _customDiscountTypeNameAr;
				daoCustomDiscountType.Icon = _icon;
				daoCustomDiscountType.Color = _color;
				daoCustomDiscountType.IsActive = _isActive;
				daoCustomDiscountType.CanEdit = _canEdit;
				daoCustomDiscountType.CanDelete = _canDelete;
				daoCustomDiscountType.DisplayOrder = _displayOrder;
				daoCustomDiscountType.CBy = _cBy;
				daoCustomDiscountType.CDate = _cDate;
				daoCustomDiscountType.EBy = _eBy;
				daoCustomDiscountType.EDate = _eDate;
				daoCustomDiscountType.Insert();
				CommitTransaction();
				
				_customDiscountTypeId = daoCustomDiscountType.CustomDiscountTypeId;
				_customDiscountTypeCode = daoCustomDiscountType.CustomDiscountTypeCode;
				_customDiscountTypeNameEn = daoCustomDiscountType.CustomDiscountTypeNameEn;
				_customDiscountTypeNameAr = daoCustomDiscountType.CustomDiscountTypeNameAr;
				_icon = daoCustomDiscountType.Icon;
				_color = daoCustomDiscountType.Color;
				_isActive = daoCustomDiscountType.IsActive;
				_canEdit = daoCustomDiscountType.CanEdit;
				_canDelete = daoCustomDiscountType.CanDelete;
				_displayOrder = daoCustomDiscountType.DisplayOrder;
				_cBy = daoCustomDiscountType.CBy;
				_cDate = daoCustomDiscountType.CDate;
				_eBy = daoCustomDiscountType.EBy;
				_eDate = daoCustomDiscountType.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOCustomDiscountType");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one CustomDiscountType record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOCustomDiscountType
		///</parameters>
		public virtual void Update()
		{
			DAOCustomDiscountType daoCustomDiscountType = new DAOCustomDiscountType();
			RegisterDataObject(daoCustomDiscountType);
			BeginTransaction("updateBOCustomDiscountType");
			try
			{
				daoCustomDiscountType.CustomDiscountTypeId = _customDiscountTypeId;
				daoCustomDiscountType.CustomDiscountTypeCode = _customDiscountTypeCode;
				daoCustomDiscountType.CustomDiscountTypeNameEn = _customDiscountTypeNameEn;
				daoCustomDiscountType.CustomDiscountTypeNameAr = _customDiscountTypeNameAr;
				daoCustomDiscountType.Icon = _icon;
				daoCustomDiscountType.Color = _color;
				daoCustomDiscountType.IsActive = _isActive;
				daoCustomDiscountType.CanEdit = _canEdit;
				daoCustomDiscountType.CanDelete = _canDelete;
				daoCustomDiscountType.DisplayOrder = _displayOrder;
				daoCustomDiscountType.CBy = _cBy;
				daoCustomDiscountType.CDate = _cDate;
				daoCustomDiscountType.EBy = _eBy;
				daoCustomDiscountType.EDate = _eDate;
				daoCustomDiscountType.Update();
				CommitTransaction();
				
				_customDiscountTypeId = daoCustomDiscountType.CustomDiscountTypeId;
				_customDiscountTypeCode = daoCustomDiscountType.CustomDiscountTypeCode;
				_customDiscountTypeNameEn = daoCustomDiscountType.CustomDiscountTypeNameEn;
				_customDiscountTypeNameAr = daoCustomDiscountType.CustomDiscountTypeNameAr;
				_icon = daoCustomDiscountType.Icon;
				_color = daoCustomDiscountType.Color;
				_isActive = daoCustomDiscountType.IsActive;
				_canEdit = daoCustomDiscountType.CanEdit;
				_canDelete = daoCustomDiscountType.CanDelete;
				_displayOrder = daoCustomDiscountType.DisplayOrder;
				_cBy = daoCustomDiscountType.CBy;
				_cDate = daoCustomDiscountType.CDate;
				_eBy = daoCustomDiscountType.EBy;
				_eDate = daoCustomDiscountType.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOCustomDiscountType");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one CustomDiscountType record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOCustomDiscountType daoCustomDiscountType = new DAOCustomDiscountType();
			RegisterDataObject(daoCustomDiscountType);
			BeginTransaction("deleteBOCustomDiscountType");
			try
			{
				daoCustomDiscountType.CustomDiscountTypeId = _customDiscountTypeId;
				daoCustomDiscountType.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOCustomDiscountType");
				throw;
			}
		}
		
		///<Summary>
		///CustomDiscountTypeCollection
		///This method returns the collection of BOCustomDiscountType objects
		///</Summary>
		///<returns>
		///List[BOCustomDiscountType]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOCustomDiscountType> CustomDiscountTypeCollection()
		{
			try
			{
				IList<BOCustomDiscountType> boCustomDiscountTypeCollection = new List<BOCustomDiscountType>();
				IList<DAOCustomDiscountType> daoCustomDiscountTypeCollection = DAOCustomDiscountType.SelectAll();
			
				foreach(DAOCustomDiscountType daoCustomDiscountType in daoCustomDiscountTypeCollection)
					boCustomDiscountTypeCollection.Add(new BOCustomDiscountType(daoCustomDiscountType));
			
				return boCustomDiscountTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///CustomDiscountTypeCollectionCount
		///This method returns the collection count of BOCustomDiscountType objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 CustomDiscountTypeCollectionCount()
		{
			try
			{
				Int32 objCount = DAOCustomDiscountType.SelectAllCount();
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
		///BOCustomDiscountType
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
		///List<BOCustomDiscountType>
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
				IDictionary<string, IList<object>> retObj = DAOCustomDiscountType.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///CustomDiscountTypeCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOCustomDiscountType objects, filtered by optional criteria
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
				IList<T> boCustomDiscountTypeCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOCustomDiscountType> daoCustomDiscountTypeCollection = DAOCustomDiscountType.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOCustomDiscountType resdaoCustomDiscountType in daoCustomDiscountTypeCollection)
					boCustomDiscountTypeCollection.Add((T)(object)new BOCustomDiscountType(resdaoCustomDiscountType));
			
				return boCustomDiscountTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///CustomDiscountTypeCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOCustomDiscountType objects, filtered by optional criteria
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
				Int32 objCount = DAOCustomDiscountType.SelectAllByCriteriaCount(lstDataCriteria);
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
				IList<DAOSalesOrder> daoSalesOrderCollection = DAOSalesOrder.SelectAllByCustomDiscountTypeId(_customDiscountTypeId.Value);
				
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
				daoSalesOrder.CustomDiscountTypeId = _customDiscountTypeId.Value;
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
				DAOSalesOrder.DeleteAllByCustomDiscountTypeId(ConnectionProvider, _customDiscountTypeId.Value);
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
		
		public virtual Int32? CustomDiscountTypeId
		{
			get
			{
				 return _customDiscountTypeId;
			}
			set
			{
				_customDiscountTypeId = value;
				_isDirty = true;
			}
		}
		
		public virtual string CustomDiscountTypeCode
		{
			get
			{
				 return _customDiscountTypeCode;
			}
			set
			{
				_customDiscountTypeCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string CustomDiscountTypeNameEn
		{
			get
			{
				 return _customDiscountTypeNameEn;
			}
			set
			{
				_customDiscountTypeNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string CustomDiscountTypeNameAr
		{
			get
			{
				 return _customDiscountTypeNameAr;
			}
			set
			{
				_customDiscountTypeNameAr = value;
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
