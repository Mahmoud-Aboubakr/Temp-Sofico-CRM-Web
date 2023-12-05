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
	///This is the definition of the class BOCashGroup.
	///It maintains a collection of BOClient objects.
	///</Summary>
	public partial class BOCashGroup : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _cashGroupId;
		protected string _cashGroupCode;
		protected string _cashGroupNameEn;
		protected string _cashGroupNameAr;
		protected bool? _isActive;
		protected string _color;
		protected Int32? _displayOrder;
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
		public BOCashGroup()
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
		///Int32 cashGroupId
		///</parameters>
		public BOCashGroup(Int32 cashGroupId)
		{
			try
			{
				DAOCashGroup daoCashGroup = DAOCashGroup.SelectOne(cashGroupId);
				_cashGroupId = daoCashGroup.CashGroupId;
				_cashGroupCode = daoCashGroup.CashGroupCode;
				_cashGroupNameEn = daoCashGroup.CashGroupNameEn;
				_cashGroupNameAr = daoCashGroup.CashGroupNameAr;
				_isActive = daoCashGroup.IsActive;
				_color = daoCashGroup.Color;
				_displayOrder = daoCashGroup.DisplayOrder;
				_icon = daoCashGroup.Icon;
				_canEdit = daoCashGroup.CanEdit;
				_canDelete = daoCashGroup.CanDelete;
				_cBy = daoCashGroup.CBy;
				_cDate = daoCashGroup.CDate;
				_eBy = daoCashGroup.EBy;
				_eDate = daoCashGroup.EDate;
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
		///DAOCashGroup
		///</parameters>
		protected internal BOCashGroup(DAOCashGroup daoCashGroup)
		{
			try
			{
				_cashGroupId = daoCashGroup.CashGroupId;
				_cashGroupCode = daoCashGroup.CashGroupCode;
				_cashGroupNameEn = daoCashGroup.CashGroupNameEn;
				_cashGroupNameAr = daoCashGroup.CashGroupNameAr;
				_isActive = daoCashGroup.IsActive;
				_color = daoCashGroup.Color;
				_displayOrder = daoCashGroup.DisplayOrder;
				_icon = daoCashGroup.Icon;
				_canEdit = daoCashGroup.CanEdit;
				_canDelete = daoCashGroup.CanDelete;
				_cBy = daoCashGroup.CBy;
				_cDate = daoCashGroup.CDate;
				_eBy = daoCashGroup.EBy;
				_eDate = daoCashGroup.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new CashGroup record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOCashGroup daoCashGroup = new DAOCashGroup();
			RegisterDataObject(daoCashGroup);
			BeginTransaction("savenewBOCashGroup");
			try
			{
				daoCashGroup.CashGroupCode = _cashGroupCode;
				daoCashGroup.CashGroupNameEn = _cashGroupNameEn;
				daoCashGroup.CashGroupNameAr = _cashGroupNameAr;
				daoCashGroup.IsActive = _isActive;
				daoCashGroup.Color = _color;
				daoCashGroup.DisplayOrder = _displayOrder;
				daoCashGroup.Icon = _icon;
				daoCashGroup.CanEdit = _canEdit;
				daoCashGroup.CanDelete = _canDelete;
				daoCashGroup.CBy = _cBy;
				daoCashGroup.CDate = _cDate;
				daoCashGroup.EBy = _eBy;
				daoCashGroup.EDate = _eDate;
				daoCashGroup.Insert();
				CommitTransaction();
				
				_cashGroupId = daoCashGroup.CashGroupId;
				_cashGroupCode = daoCashGroup.CashGroupCode;
				_cashGroupNameEn = daoCashGroup.CashGroupNameEn;
				_cashGroupNameAr = daoCashGroup.CashGroupNameAr;
				_isActive = daoCashGroup.IsActive;
				_color = daoCashGroup.Color;
				_displayOrder = daoCashGroup.DisplayOrder;
				_icon = daoCashGroup.Icon;
				_canEdit = daoCashGroup.CanEdit;
				_canDelete = daoCashGroup.CanDelete;
				_cBy = daoCashGroup.CBy;
				_cDate = daoCashGroup.CDate;
				_eBy = daoCashGroup.EBy;
				_eDate = daoCashGroup.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOCashGroup");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one CashGroup record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOCashGroup
		///</parameters>
		public virtual void Update()
		{
			DAOCashGroup daoCashGroup = new DAOCashGroup();
			RegisterDataObject(daoCashGroup);
			BeginTransaction("updateBOCashGroup");
			try
			{
				daoCashGroup.CashGroupId = _cashGroupId;
				daoCashGroup.CashGroupCode = _cashGroupCode;
				daoCashGroup.CashGroupNameEn = _cashGroupNameEn;
				daoCashGroup.CashGroupNameAr = _cashGroupNameAr;
				daoCashGroup.IsActive = _isActive;
				daoCashGroup.Color = _color;
				daoCashGroup.DisplayOrder = _displayOrder;
				daoCashGroup.Icon = _icon;
				daoCashGroup.CanEdit = _canEdit;
				daoCashGroup.CanDelete = _canDelete;
				daoCashGroup.CBy = _cBy;
				daoCashGroup.CDate = _cDate;
				daoCashGroup.EBy = _eBy;
				daoCashGroup.EDate = _eDate;
				daoCashGroup.Update();
				CommitTransaction();
				
				_cashGroupId = daoCashGroup.CashGroupId;
				_cashGroupCode = daoCashGroup.CashGroupCode;
				_cashGroupNameEn = daoCashGroup.CashGroupNameEn;
				_cashGroupNameAr = daoCashGroup.CashGroupNameAr;
				_isActive = daoCashGroup.IsActive;
				_color = daoCashGroup.Color;
				_displayOrder = daoCashGroup.DisplayOrder;
				_icon = daoCashGroup.Icon;
				_canEdit = daoCashGroup.CanEdit;
				_canDelete = daoCashGroup.CanDelete;
				_cBy = daoCashGroup.CBy;
				_cDate = daoCashGroup.CDate;
				_eBy = daoCashGroup.EBy;
				_eDate = daoCashGroup.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOCashGroup");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one CashGroup record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOCashGroup daoCashGroup = new DAOCashGroup();
			RegisterDataObject(daoCashGroup);
			BeginTransaction("deleteBOCashGroup");
			try
			{
				daoCashGroup.CashGroupId = _cashGroupId;
				daoCashGroup.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOCashGroup");
				throw;
			}
		}
		
		///<Summary>
		///CashGroupCollection
		///This method returns the collection of BOCashGroup objects
		///</Summary>
		///<returns>
		///List[BOCashGroup]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOCashGroup> CashGroupCollection()
		{
			try
			{
				IList<BOCashGroup> boCashGroupCollection = new List<BOCashGroup>();
				IList<DAOCashGroup> daoCashGroupCollection = DAOCashGroup.SelectAll();
			
				foreach(DAOCashGroup daoCashGroup in daoCashGroupCollection)
					boCashGroupCollection.Add(new BOCashGroup(daoCashGroup));
			
				return boCashGroupCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///CashGroupCollectionCount
		///This method returns the collection count of BOCashGroup objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 CashGroupCollectionCount()
		{
			try
			{
				Int32 objCount = DAOCashGroup.SelectAllCount();
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
		///BOCashGroup
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
		///Projections
		///This method returns the collection of projections, ordered and filtered by optional criteria
		///</Summary>
		///<returns>
		///List<BOCashGroup>
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
				IDictionary<string, IList<object>> retObj = DAOCashGroup.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///CashGroupCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOCashGroup objects, filtered by optional criteria
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
				IList<T> boCashGroupCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOCashGroup> daoCashGroupCollection = DAOCashGroup.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOCashGroup resdaoCashGroup in daoCashGroupCollection)
					boCashGroupCollection.Add((T)(object)new BOCashGroup(resdaoCashGroup));
			
				return boCashGroupCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///CashGroupCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOCashGroup objects, filtered by optional criteria
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
				Int32 objCount = DAOCashGroup.SelectAllByCriteriaCount(lstDataCriteria);
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
				IList<DAOClient> daoClientCollection = DAOClient.SelectAllByCashGroupId(_cashGroupId.Value);
				
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
				daoClient.InRoute = boClient.InRoute;
				daoClient.SalesChannelId = boClient.SalesChannelId;
				daoClient.SalesPoolId = boClient.SalesPoolId;
				daoClient.UserId = boClient.UserId;
				daoClient.Points = boClient.Points;
				daoClient.Wallet = boClient.Wallet;
				daoClient.DealId = boClient.DealId;
				daoClient.CashGroupId = _cashGroupId.Value;
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
				DAOClient.DeleteAllByCashGroupId(ConnectionProvider, _cashGroupId.Value);
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
		
		#endregion

		#region member properties
		
		public virtual Int32? CashGroupId
		{
			get
			{
				 return _cashGroupId;
			}
			set
			{
				_cashGroupId = value;
				_isDirty = true;
			}
		}
		
		public virtual string CashGroupCode
		{
			get
			{
				 return _cashGroupCode;
			}
			set
			{
				_cashGroupCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string CashGroupNameEn
		{
			get
			{
				 return _cashGroupNameEn;
			}
			set
			{
				_cashGroupNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string CashGroupNameAr
		{
			get
			{
				 return _cashGroupNameAr;
			}
			set
			{
				_cashGroupNameAr = value;
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
