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
	///This is the definition of the class BOAppUserQuickOrder.
	///It maintains a collection of BOAppUserQuickOrderDetail objects.
	///</Summary>
	public partial class BOAppUserQuickOrder : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int64? _quickOrderId;
		protected Int32? _userId;
		protected Int32? _clientId;
		protected DateTime? _orderDate;
		protected DateTime? _orderTime;
		protected bool? _isApproved;
		protected Int64? _salesOrderId;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOAppUserQuickOrderDetail> _boAppUserQuickOrderDetailCollection;
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
		public BOAppUserQuickOrder()
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
		///Int64 quickOrderId
		///</parameters>
		public BOAppUserQuickOrder(Int64 quickOrderId)
		{
			try
			{
				DAOAppUserQuickOrder daoAppUserQuickOrder = DAOAppUserQuickOrder.SelectOne(quickOrderId);
				_quickOrderId = daoAppUserQuickOrder.QuickOrderId;
				_userId = daoAppUserQuickOrder.UserId;
				_clientId = daoAppUserQuickOrder.ClientId;
				_orderDate = daoAppUserQuickOrder.OrderDate;
				_orderTime = daoAppUserQuickOrder.OrderTime;
				_isApproved = daoAppUserQuickOrder.IsApproved;
				_salesOrderId = daoAppUserQuickOrder.SalesOrderId;
				_cBy = daoAppUserQuickOrder.CBy;
				_cDate = daoAppUserQuickOrder.CDate;
				_eBy = daoAppUserQuickOrder.EBy;
				_eDate = daoAppUserQuickOrder.EDate;
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
		///DAOAppUserQuickOrder
		///</parameters>
		protected internal BOAppUserQuickOrder(DAOAppUserQuickOrder daoAppUserQuickOrder)
		{
			try
			{
				_quickOrderId = daoAppUserQuickOrder.QuickOrderId;
				_userId = daoAppUserQuickOrder.UserId;
				_clientId = daoAppUserQuickOrder.ClientId;
				_orderDate = daoAppUserQuickOrder.OrderDate;
				_orderTime = daoAppUserQuickOrder.OrderTime;
				_isApproved = daoAppUserQuickOrder.IsApproved;
				_salesOrderId = daoAppUserQuickOrder.SalesOrderId;
				_cBy = daoAppUserQuickOrder.CBy;
				_cDate = daoAppUserQuickOrder.CDate;
				_eBy = daoAppUserQuickOrder.EBy;
				_eDate = daoAppUserQuickOrder.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new AppUserQuickOrder record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOAppUserQuickOrder daoAppUserQuickOrder = new DAOAppUserQuickOrder();
			RegisterDataObject(daoAppUserQuickOrder);
			BeginTransaction("savenewBOAppUserQuickOrder");
			try
			{
				daoAppUserQuickOrder.UserId = _userId;
				daoAppUserQuickOrder.ClientId = _clientId;
				daoAppUserQuickOrder.OrderDate = _orderDate;
				daoAppUserQuickOrder.OrderTime = _orderTime;
				daoAppUserQuickOrder.IsApproved = _isApproved;
				daoAppUserQuickOrder.SalesOrderId = _salesOrderId;
				daoAppUserQuickOrder.CBy = _cBy;
				daoAppUserQuickOrder.CDate = _cDate;
				daoAppUserQuickOrder.EBy = _eBy;
				daoAppUserQuickOrder.EDate = _eDate;
				daoAppUserQuickOrder.Insert();
				CommitTransaction();
				
				_quickOrderId = daoAppUserQuickOrder.QuickOrderId;
				_userId = daoAppUserQuickOrder.UserId;
				_clientId = daoAppUserQuickOrder.ClientId;
				_orderDate = daoAppUserQuickOrder.OrderDate;
				_orderTime = daoAppUserQuickOrder.OrderTime;
				_isApproved = daoAppUserQuickOrder.IsApproved;
				_salesOrderId = daoAppUserQuickOrder.SalesOrderId;
				_cBy = daoAppUserQuickOrder.CBy;
				_cDate = daoAppUserQuickOrder.CDate;
				_eBy = daoAppUserQuickOrder.EBy;
				_eDate = daoAppUserQuickOrder.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOAppUserQuickOrder");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one AppUserQuickOrder record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOAppUserQuickOrder
		///</parameters>
		public virtual void Update()
		{
			DAOAppUserQuickOrder daoAppUserQuickOrder = new DAOAppUserQuickOrder();
			RegisterDataObject(daoAppUserQuickOrder);
			BeginTransaction("updateBOAppUserQuickOrder");
			try
			{
				daoAppUserQuickOrder.QuickOrderId = _quickOrderId;
				daoAppUserQuickOrder.UserId = _userId;
				daoAppUserQuickOrder.ClientId = _clientId;
				daoAppUserQuickOrder.OrderDate = _orderDate;
				daoAppUserQuickOrder.OrderTime = _orderTime;
				daoAppUserQuickOrder.IsApproved = _isApproved;
				daoAppUserQuickOrder.SalesOrderId = _salesOrderId;
				daoAppUserQuickOrder.CBy = _cBy;
				daoAppUserQuickOrder.CDate = _cDate;
				daoAppUserQuickOrder.EBy = _eBy;
				daoAppUserQuickOrder.EDate = _eDate;
				daoAppUserQuickOrder.Update();
				CommitTransaction();
				
				_quickOrderId = daoAppUserQuickOrder.QuickOrderId;
				_userId = daoAppUserQuickOrder.UserId;
				_clientId = daoAppUserQuickOrder.ClientId;
				_orderDate = daoAppUserQuickOrder.OrderDate;
				_orderTime = daoAppUserQuickOrder.OrderTime;
				_isApproved = daoAppUserQuickOrder.IsApproved;
				_salesOrderId = daoAppUserQuickOrder.SalesOrderId;
				_cBy = daoAppUserQuickOrder.CBy;
				_cDate = daoAppUserQuickOrder.CDate;
				_eBy = daoAppUserQuickOrder.EBy;
				_eDate = daoAppUserQuickOrder.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOAppUserQuickOrder");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one AppUserQuickOrder record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOAppUserQuickOrder daoAppUserQuickOrder = new DAOAppUserQuickOrder();
			RegisterDataObject(daoAppUserQuickOrder);
			BeginTransaction("deleteBOAppUserQuickOrder");
			try
			{
				daoAppUserQuickOrder.QuickOrderId = _quickOrderId;
				daoAppUserQuickOrder.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOAppUserQuickOrder");
				throw;
			}
		}
		
		///<Summary>
		///AppUserQuickOrderCollection
		///This method returns the collection of BOAppUserQuickOrder objects
		///</Summary>
		///<returns>
		///List[BOAppUserQuickOrder]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOAppUserQuickOrder> AppUserQuickOrderCollection()
		{
			try
			{
				IList<BOAppUserQuickOrder> boAppUserQuickOrderCollection = new List<BOAppUserQuickOrder>();
				IList<DAOAppUserQuickOrder> daoAppUserQuickOrderCollection = DAOAppUserQuickOrder.SelectAll();
			
				foreach(DAOAppUserQuickOrder daoAppUserQuickOrder in daoAppUserQuickOrderCollection)
					boAppUserQuickOrderCollection.Add(new BOAppUserQuickOrder(daoAppUserQuickOrder));
			
				return boAppUserQuickOrderCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AppUserQuickOrderCollectionCount
		///This method returns the collection count of BOAppUserQuickOrder objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 AppUserQuickOrderCollectionCount()
		{
			try
			{
				Int32 objCount = DAOAppUserQuickOrder.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AppUserQuickOrderDetailCollection
		///This method returns its collection of BOAppUserQuickOrderDetail objects
		///</Summary>
		///<returns>
		///IList[BOAppUserQuickOrderDetail]
		///</returns>
		///<parameters>
		///BOAppUserQuickOrder
		///</parameters>
		public virtual IList<BOAppUserQuickOrderDetail> AppUserQuickOrderDetailCollection()
		{
			try
			{
				if(_boAppUserQuickOrderDetailCollection == null)
					LoadAppUserQuickOrderDetailCollection();
				
				return _boAppUserQuickOrderDetailCollection.AsReadOnly();
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
		///List<BOAppUserQuickOrder>
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
				IDictionary<string, IList<object>> retObj = DAOAppUserQuickOrder.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AppUserQuickOrderCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOAppUserQuickOrder objects, filtered by optional criteria
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
				IList<T> boAppUserQuickOrderCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOAppUserQuickOrder> daoAppUserQuickOrderCollection = DAOAppUserQuickOrder.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOAppUserQuickOrder resdaoAppUserQuickOrder in daoAppUserQuickOrderCollection)
					boAppUserQuickOrderCollection.Add((T)(object)new BOAppUserQuickOrder(resdaoAppUserQuickOrder));
			
				return boAppUserQuickOrderCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AppUserQuickOrderCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOAppUserQuickOrder objects, filtered by optional criteria
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
				Int32 objCount = DAOAppUserQuickOrder.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadAppUserQuickOrderDetailCollection
		///This method loads the internal collection of BOAppUserQuickOrderDetail objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadAppUserQuickOrderDetailCollection()
		{
			try
			{
				_boAppUserQuickOrderDetailCollection = new List<BOAppUserQuickOrderDetail>();
				IList<DAOAppUserQuickOrderDetail> daoAppUserQuickOrderDetailCollection = DAOAppUserQuickOrderDetail.SelectAllByQuickOrderId(_quickOrderId.Value);
				
				foreach(DAOAppUserQuickOrderDetail daoAppUserQuickOrderDetail in daoAppUserQuickOrderDetailCollection)
					_boAppUserQuickOrderDetailCollection.Add(new BOAppUserQuickOrderDetail(daoAppUserQuickOrderDetail));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddAppUserQuickOrderDetail
		///This method persists a BOAppUserQuickOrderDetail object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOAppUserQuickOrderDetail
		///</parameters>
		public virtual void AddAppUserQuickOrderDetail(BOAppUserQuickOrderDetail boAppUserQuickOrderDetail)
		{
			DAOAppUserQuickOrderDetail daoAppUserQuickOrderDetail = new DAOAppUserQuickOrderDetail();
			RegisterDataObject(daoAppUserQuickOrderDetail);
			BeginTransaction("addAppUserQuickOrderDetail");
			try
			{
				daoAppUserQuickOrderDetail.DetailId = boAppUserQuickOrderDetail.DetailId;
				daoAppUserQuickOrderDetail.MessageType = boAppUserQuickOrderDetail.MessageType;
				daoAppUserQuickOrderDetail.Message = boAppUserQuickOrderDetail.Message;
				daoAppUserQuickOrderDetail.MessageGroup = boAppUserQuickOrderDetail.MessageGroup;
				daoAppUserQuickOrderDetail.Url = boAppUserQuickOrderDetail.Url;
				daoAppUserQuickOrderDetail.QuickOrderId = _quickOrderId.Value;
				daoAppUserQuickOrderDetail.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boAppUserQuickOrderDetail = new BOAppUserQuickOrderDetail(daoAppUserQuickOrderDetail);
				if(_boAppUserQuickOrderDetailCollection != null)
					_boAppUserQuickOrderDetailCollection.Add(boAppUserQuickOrderDetail);
			}
			catch
			{
				RollbackTransaction("addAppUserQuickOrderDetail");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllAppUserQuickOrderDetail
		///This method deletes all BOAppUserQuickOrderDetail objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllAppUserQuickOrderDetail()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllAppUserQuickOrderDetail");
			try
			{
				DAOAppUserQuickOrderDetail.DeleteAllByQuickOrderId(ConnectionProvider, _quickOrderId.Value);
				CommitTransaction();
				if(_boAppUserQuickOrderDetailCollection != null)
				{
					_boAppUserQuickOrderDetailCollection.Clear();
					_boAppUserQuickOrderDetailCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllAppUserQuickOrderDetail");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int64? QuickOrderId
		{
			get
			{
				 return _quickOrderId;
			}
			set
			{
				_quickOrderId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? UserId
		{
			get
			{
				 return _userId;
			}
			set
			{
				_userId = value;
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
		
		public virtual DateTime? OrderDate
		{
			get
			{
				 return _orderDate;
			}
			set
			{
				_orderDate = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? OrderTime
		{
			get
			{
				 return _orderTime;
			}
			set
			{
				_orderTime = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? IsApproved
		{
			get
			{
				 return _isApproved;
			}
			set
			{
				_isApproved = value;
				_isDirty = true;
			}
		}
		
		public virtual Int64? SalesOrderId
		{
			get
			{
				 return _salesOrderId;
			}
			set
			{
				_salesOrderId = value;
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
