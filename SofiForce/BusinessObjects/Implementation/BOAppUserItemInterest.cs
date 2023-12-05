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
	///This is the definition of the class BOAppUserItemInterest.
	///</Summary>
	public partial class BOAppUserItemInterest : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int64? _id;
		protected Int32? _userId;
		protected Int32? _itemId;
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
		public BOAppUserItemInterest()
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
		///Int64 id
		///</parameters>
		public BOAppUserItemInterest(Int64 id)
		{
			try
			{
				DAOAppUserItemInterest daoAppUserItemInterest = DAOAppUserItemInterest.SelectOne(id);
				_id = daoAppUserItemInterest.Id;
				_userId = daoAppUserItemInterest.UserId;
				_itemId = daoAppUserItemInterest.ItemId;
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
		///DAOAppUserItemInterest
		///</parameters>
		protected internal BOAppUserItemInterest(DAOAppUserItemInterest daoAppUserItemInterest)
		{
			try
			{
				_id = daoAppUserItemInterest.Id;
				_userId = daoAppUserItemInterest.UserId;
				_itemId = daoAppUserItemInterest.ItemId;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new AppUserItemInterest record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOAppUserItemInterest daoAppUserItemInterest = new DAOAppUserItemInterest();
			RegisterDataObject(daoAppUserItemInterest);
			BeginTransaction("savenewBOAppUserItemInterest");
			try
			{
				daoAppUserItemInterest.UserId = _userId;
				daoAppUserItemInterest.ItemId = _itemId;
				daoAppUserItemInterest.Insert();
				CommitTransaction();
				
				_id = daoAppUserItemInterest.Id;
				_userId = daoAppUserItemInterest.UserId;
				_itemId = daoAppUserItemInterest.ItemId;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOAppUserItemInterest");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one AppUserItemInterest record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOAppUserItemInterest
		///</parameters>
		public virtual void Update()
		{
			DAOAppUserItemInterest daoAppUserItemInterest = new DAOAppUserItemInterest();
			RegisterDataObject(daoAppUserItemInterest);
			BeginTransaction("updateBOAppUserItemInterest");
			try
			{
				daoAppUserItemInterest.Id = _id;
				daoAppUserItemInterest.UserId = _userId;
				daoAppUserItemInterest.ItemId = _itemId;
				daoAppUserItemInterest.Update();
				CommitTransaction();
				
				_id = daoAppUserItemInterest.Id;
				_userId = daoAppUserItemInterest.UserId;
				_itemId = daoAppUserItemInterest.ItemId;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOAppUserItemInterest");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one AppUserItemInterest record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOAppUserItemInterest daoAppUserItemInterest = new DAOAppUserItemInterest();
			RegisterDataObject(daoAppUserItemInterest);
			BeginTransaction("deleteBOAppUserItemInterest");
			try
			{
				daoAppUserItemInterest.Id = _id;
				daoAppUserItemInterest.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOAppUserItemInterest");
				throw;
			}
		}
		
		///<Summary>
		///AppUserItemInterestCollection
		///This method returns the collection of BOAppUserItemInterest objects
		///</Summary>
		///<returns>
		///List[BOAppUserItemInterest]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOAppUserItemInterest> AppUserItemInterestCollection()
		{
			try
			{
				IList<BOAppUserItemInterest> boAppUserItemInterestCollection = new List<BOAppUserItemInterest>();
				IList<DAOAppUserItemInterest> daoAppUserItemInterestCollection = DAOAppUserItemInterest.SelectAll();
			
				foreach(DAOAppUserItemInterest daoAppUserItemInterest in daoAppUserItemInterestCollection)
					boAppUserItemInterestCollection.Add(new BOAppUserItemInterest(daoAppUserItemInterest));
			
				return boAppUserItemInterestCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AppUserItemInterestCollectionCount
		///This method returns the collection count of BOAppUserItemInterest objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 AppUserItemInterestCollectionCount()
		{
			try
			{
				Int32 objCount = DAOAppUserItemInterest.SelectAllCount();
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
		///List<BOAppUserItemInterest>
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
				IDictionary<string, IList<object>> retObj = DAOAppUserItemInterest.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AppUserItemInterestCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOAppUserItemInterest objects, filtered by optional criteria
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
				IList<T> boAppUserItemInterestCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOAppUserItemInterest> daoAppUserItemInterestCollection = DAOAppUserItemInterest.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOAppUserItemInterest resdaoAppUserItemInterest in daoAppUserItemInterestCollection)
					boAppUserItemInterestCollection.Add((T)(object)new BOAppUserItemInterest(resdaoAppUserItemInterest));
			
				return boAppUserItemInterestCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AppUserItemInterestCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOAppUserItemInterest objects, filtered by optional criteria
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
				Int32 objCount = DAOAppUserItemInterest.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int64? Id
		{
			get
			{
				 return _id;
			}
			set
			{
				_id = value;
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
