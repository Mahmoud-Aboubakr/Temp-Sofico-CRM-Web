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
	///This is the definition of the class BORepresentativeQuota.
	///</Summary>
	public partial class BORepresentativeQuota : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int64? _quotaId;
		protected Int32? _representativeId;
		protected Int32? _itemId;
		protected Int32? _quantity;
		protected Int32? _cBy;
		protected Int32? _eBy;
		protected DateTime? _cDate;
		protected DateTime? _eDate;
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
		public BORepresentativeQuota()
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
		///Int64 quotaId
		///</parameters>
		public BORepresentativeQuota(Int64 quotaId)
		{
			try
			{
				DAORepresentativeQuota daoRepresentativeQuota = DAORepresentativeQuota.SelectOne(quotaId);
				_quotaId = daoRepresentativeQuota.QuotaId;
				_representativeId = daoRepresentativeQuota.RepresentativeId;
				_itemId = daoRepresentativeQuota.ItemId;
				_quantity = daoRepresentativeQuota.Quantity;
				_cBy = daoRepresentativeQuota.CBy;
				_eBy = daoRepresentativeQuota.EBy;
				_cDate = daoRepresentativeQuota.CDate;
				_eDate = daoRepresentativeQuota.EDate;
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
		///DAORepresentativeQuota
		///</parameters>
		protected internal BORepresentativeQuota(DAORepresentativeQuota daoRepresentativeQuota)
		{
			try
			{
				_quotaId = daoRepresentativeQuota.QuotaId;
				_representativeId = daoRepresentativeQuota.RepresentativeId;
				_itemId = daoRepresentativeQuota.ItemId;
				_quantity = daoRepresentativeQuota.Quantity;
				_cBy = daoRepresentativeQuota.CBy;
				_eBy = daoRepresentativeQuota.EBy;
				_cDate = daoRepresentativeQuota.CDate;
				_eDate = daoRepresentativeQuota.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new RepresentativeQuota record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAORepresentativeQuota daoRepresentativeQuota = new DAORepresentativeQuota();
			RegisterDataObject(daoRepresentativeQuota);
			BeginTransaction("savenewBORepresentativeQuota");
			try
			{
				daoRepresentativeQuota.RepresentativeId = _representativeId;
				daoRepresentativeQuota.ItemId = _itemId;
				daoRepresentativeQuota.Quantity = _quantity;
				daoRepresentativeQuota.CBy = _cBy;
				daoRepresentativeQuota.EBy = _eBy;
				daoRepresentativeQuota.CDate = _cDate;
				daoRepresentativeQuota.EDate = _eDate;
				daoRepresentativeQuota.Insert();
				CommitTransaction();
				
				_quotaId = daoRepresentativeQuota.QuotaId;
				_representativeId = daoRepresentativeQuota.RepresentativeId;
				_itemId = daoRepresentativeQuota.ItemId;
				_quantity = daoRepresentativeQuota.Quantity;
				_cBy = daoRepresentativeQuota.CBy;
				_eBy = daoRepresentativeQuota.EBy;
				_cDate = daoRepresentativeQuota.CDate;
				_eDate = daoRepresentativeQuota.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBORepresentativeQuota");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one RepresentativeQuota record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BORepresentativeQuota
		///</parameters>
		public virtual void Update()
		{
			DAORepresentativeQuota daoRepresentativeQuota = new DAORepresentativeQuota();
			RegisterDataObject(daoRepresentativeQuota);
			BeginTransaction("updateBORepresentativeQuota");
			try
			{
				daoRepresentativeQuota.QuotaId = _quotaId;
				daoRepresentativeQuota.RepresentativeId = _representativeId;
				daoRepresentativeQuota.ItemId = _itemId;
				daoRepresentativeQuota.Quantity = _quantity;
				daoRepresentativeQuota.CBy = _cBy;
				daoRepresentativeQuota.EBy = _eBy;
				daoRepresentativeQuota.CDate = _cDate;
				daoRepresentativeQuota.EDate = _eDate;
				daoRepresentativeQuota.Update();
				CommitTransaction();
				
				_quotaId = daoRepresentativeQuota.QuotaId;
				_representativeId = daoRepresentativeQuota.RepresentativeId;
				_itemId = daoRepresentativeQuota.ItemId;
				_quantity = daoRepresentativeQuota.Quantity;
				_cBy = daoRepresentativeQuota.CBy;
				_eBy = daoRepresentativeQuota.EBy;
				_cDate = daoRepresentativeQuota.CDate;
				_eDate = daoRepresentativeQuota.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBORepresentativeQuota");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one RepresentativeQuota record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAORepresentativeQuota daoRepresentativeQuota = new DAORepresentativeQuota();
			RegisterDataObject(daoRepresentativeQuota);
			BeginTransaction("deleteBORepresentativeQuota");
			try
			{
				daoRepresentativeQuota.QuotaId = _quotaId;
				daoRepresentativeQuota.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBORepresentativeQuota");
				throw;
			}
		}
		
		///<Summary>
		///RepresentativeQuotaCollection
		///This method returns the collection of BORepresentativeQuota objects
		///</Summary>
		///<returns>
		///List[BORepresentativeQuota]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BORepresentativeQuota> RepresentativeQuotaCollection()
		{
			try
			{
				IList<BORepresentativeQuota> boRepresentativeQuotaCollection = new List<BORepresentativeQuota>();
				IList<DAORepresentativeQuota> daoRepresentativeQuotaCollection = DAORepresentativeQuota.SelectAll();
			
				foreach(DAORepresentativeQuota daoRepresentativeQuota in daoRepresentativeQuotaCollection)
					boRepresentativeQuotaCollection.Add(new BORepresentativeQuota(daoRepresentativeQuota));
			
				return boRepresentativeQuotaCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RepresentativeQuotaCollectionCount
		///This method returns the collection count of BORepresentativeQuota objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 RepresentativeQuotaCollectionCount()
		{
			try
			{
				Int32 objCount = DAORepresentativeQuota.SelectAllCount();
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
		///List<BORepresentativeQuota>
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
				IDictionary<string, IList<object>> retObj = DAORepresentativeQuota.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RepresentativeQuotaCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BORepresentativeQuota objects, filtered by optional criteria
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
				IList<T> boRepresentativeQuotaCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAORepresentativeQuota> daoRepresentativeQuotaCollection = DAORepresentativeQuota.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAORepresentativeQuota resdaoRepresentativeQuota in daoRepresentativeQuotaCollection)
					boRepresentativeQuotaCollection.Add((T)(object)new BORepresentativeQuota(resdaoRepresentativeQuota));
			
				return boRepresentativeQuotaCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RepresentativeQuotaCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BORepresentativeQuota objects, filtered by optional criteria
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
				Int32 objCount = DAORepresentativeQuota.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int64? QuotaId
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
		
		public virtual Int32? RepresentativeId
		{
			get
			{
				 return _representativeId;
			}
			set
			{
				_representativeId = value;
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
