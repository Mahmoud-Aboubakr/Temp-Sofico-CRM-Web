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
	///This is the definition of the class BOItemQuota.
	///</Summary>
	public partial class BOItemQuota : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _quotaId;
		protected Int32? _itemId;
		protected Int32? _quantity;
		protected DateTime? _fromDate;
		protected DateTime? _toDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
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
		public BOItemQuota()
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
		///Int32 quotaId
		///</parameters>
		public BOItemQuota(Int32 quotaId)
		{
			try
			{
				DAOItemQuota daoItemQuota = DAOItemQuota.SelectOne(quotaId);
				_quotaId = daoItemQuota.QuotaId;
				_itemId = daoItemQuota.ItemId;
				_quantity = daoItemQuota.Quantity;
				_fromDate = daoItemQuota.FromDate;
				_toDate = daoItemQuota.ToDate;
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
		///DAOItemQuota
		///</parameters>
		protected internal BOItemQuota(DAOItemQuota daoItemQuota)
		{
			try
			{
				_quotaId = daoItemQuota.QuotaId;
				_itemId = daoItemQuota.ItemId;
				_quantity = daoItemQuota.Quantity;
				_fromDate = daoItemQuota.FromDate;
				_toDate = daoItemQuota.ToDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new ItemQuota record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOItemQuota daoItemQuota = new DAOItemQuota();
			RegisterDataObject(daoItemQuota);
			BeginTransaction("savenewBOItemQuota");
			try
			{
				daoItemQuota.ItemId = _itemId;
				daoItemQuota.Quantity = _quantity;
				daoItemQuota.FromDate = _fromDate;
				daoItemQuota.ToDate = _toDate;
				daoItemQuota.Insert();
				CommitTransaction();
				
				_quotaId = daoItemQuota.QuotaId;
				_itemId = daoItemQuota.ItemId;
				_quantity = daoItemQuota.Quantity;
				_fromDate = daoItemQuota.FromDate;
				_toDate = daoItemQuota.ToDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOItemQuota");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one ItemQuota record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOItemQuota
		///</parameters>
		public virtual void Update()
		{
			DAOItemQuota daoItemQuota = new DAOItemQuota();
			RegisterDataObject(daoItemQuota);
			BeginTransaction("updateBOItemQuota");
			try
			{
				daoItemQuota.QuotaId = _quotaId;
				daoItemQuota.ItemId = _itemId;
				daoItemQuota.Quantity = _quantity;
				daoItemQuota.FromDate = _fromDate;
				daoItemQuota.ToDate = _toDate;
				daoItemQuota.Update();
				CommitTransaction();
				
				_quotaId = daoItemQuota.QuotaId;
				_itemId = daoItemQuota.ItemId;
				_quantity = daoItemQuota.Quantity;
				_fromDate = daoItemQuota.FromDate;
				_toDate = daoItemQuota.ToDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOItemQuota");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one ItemQuota record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOItemQuota daoItemQuota = new DAOItemQuota();
			RegisterDataObject(daoItemQuota);
			BeginTransaction("deleteBOItemQuota");
			try
			{
				daoItemQuota.QuotaId = _quotaId;
				daoItemQuota.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOItemQuota");
				throw;
			}
		}
		
		///<Summary>
		///ItemQuotaCollection
		///This method returns the collection of BOItemQuota objects
		///</Summary>
		///<returns>
		///List[BOItemQuota]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOItemQuota> ItemQuotaCollection()
		{
			try
			{
				IList<BOItemQuota> boItemQuotaCollection = new List<BOItemQuota>();
				IList<DAOItemQuota> daoItemQuotaCollection = DAOItemQuota.SelectAll();
			
				foreach(DAOItemQuota daoItemQuota in daoItemQuotaCollection)
					boItemQuotaCollection.Add(new BOItemQuota(daoItemQuota));
			
				return boItemQuotaCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemQuotaCollectionCount
		///This method returns the collection count of BOItemQuota objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ItemQuotaCollectionCount()
		{
			try
			{
				Int32 objCount = DAOItemQuota.SelectAllCount();
				return objCount;
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
		///List<BOItemQuota>
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
				IDictionary<string, IList<object>> retObj = DAOItemQuota.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemQuotaCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOItemQuota objects, filtered by optional criteria
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
				IList<T> boItemQuotaCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOItemQuota> daoItemQuotaCollection = DAOItemQuota.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOItemQuota resdaoItemQuota in daoItemQuotaCollection)
					boItemQuotaCollection.Add((T)(object)new BOItemQuota(resdaoItemQuota));
			
				return boItemQuotaCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemQuotaCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOItemQuota objects, filtered by optional criteria
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
				Int32 objCount = DAOItemQuota.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? QuotaId
		{
			get
			{
				 return _quotaId;
			}
			set
			{
				_quotaId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ItemId
		{
			get
			{
				 return _itemId;
			}
			set
			{
				_itemId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Quantity
		{
			get
			{
				 return _quantity;
			}
			set
			{
				_quantity = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? FromDate
		{
			get
			{
				 return _fromDate;
			}
			set
			{
				_fromDate = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? ToDate
		{
			get
			{
				 return _toDate;
			}
			set
			{
				_toDate = value;
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
