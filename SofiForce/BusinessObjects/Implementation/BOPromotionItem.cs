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
	///This is the definition of the class BOPromotionItem.
	///</Summary>
	public partial class BOPromotionItem : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int64? _promotionItemId;
		protected Int32? _promotionId;
		protected string _itemCode;
		protected Int32? _groupId;
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
		public BOPromotionItem()
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
		///Int64 promotionItemId
		///</parameters>
		public BOPromotionItem(Int64 promotionItemId)
		{
			try
			{
				DAOPromotionItem daoPromotionItem = DAOPromotionItem.SelectOne(promotionItemId);
				_promotionItemId = daoPromotionItem.PromotionItemId;
				_promotionId = daoPromotionItem.PromotionId;
				_itemCode = daoPromotionItem.ItemCode;
				_groupId = daoPromotionItem.GroupId;
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
		///DAOPromotionItem
		///</parameters>
		protected internal BOPromotionItem(DAOPromotionItem daoPromotionItem)
		{
			try
			{
				_promotionItemId = daoPromotionItem.PromotionItemId;
				_promotionId = daoPromotionItem.PromotionId;
				_itemCode = daoPromotionItem.ItemCode;
				_groupId = daoPromotionItem.GroupId;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new PromotionItem record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOPromotionItem daoPromotionItem = new DAOPromotionItem();
			RegisterDataObject(daoPromotionItem);
			BeginTransaction("savenewBOPromotionItem");
			try
			{
				daoPromotionItem.PromotionId = _promotionId;
				daoPromotionItem.ItemCode = _itemCode;
				daoPromotionItem.GroupId = _groupId;
				daoPromotionItem.Insert();
				CommitTransaction();
				
				_promotionItemId = daoPromotionItem.PromotionItemId;
				_promotionId = daoPromotionItem.PromotionId;
				_itemCode = daoPromotionItem.ItemCode;
				_groupId = daoPromotionItem.GroupId;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOPromotionItem");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one PromotionItem record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOPromotionItem
		///</parameters>
		public virtual void Update()
		{
			DAOPromotionItem daoPromotionItem = new DAOPromotionItem();
			RegisterDataObject(daoPromotionItem);
			BeginTransaction("updateBOPromotionItem");
			try
			{
				daoPromotionItem.PromotionItemId = _promotionItemId;
				daoPromotionItem.PromotionId = _promotionId;
				daoPromotionItem.ItemCode = _itemCode;
				daoPromotionItem.GroupId = _groupId;
				daoPromotionItem.Update();
				CommitTransaction();
				
				_promotionItemId = daoPromotionItem.PromotionItemId;
				_promotionId = daoPromotionItem.PromotionId;
				_itemCode = daoPromotionItem.ItemCode;
				_groupId = daoPromotionItem.GroupId;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOPromotionItem");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one PromotionItem record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOPromotionItem daoPromotionItem = new DAOPromotionItem();
			RegisterDataObject(daoPromotionItem);
			BeginTransaction("deleteBOPromotionItem");
			try
			{
				daoPromotionItem.PromotionItemId = _promotionItemId;
				daoPromotionItem.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOPromotionItem");
				throw;
			}
		}
		
		///<Summary>
		///PromotionItemCollection
		///This method returns the collection of BOPromotionItem objects
		///</Summary>
		///<returns>
		///List[BOPromotionItem]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOPromotionItem> PromotionItemCollection()
		{
			try
			{
				IList<BOPromotionItem> boPromotionItemCollection = new List<BOPromotionItem>();
				IList<DAOPromotionItem> daoPromotionItemCollection = DAOPromotionItem.SelectAll();
			
				foreach(DAOPromotionItem daoPromotionItem in daoPromotionItemCollection)
					boPromotionItemCollection.Add(new BOPromotionItem(daoPromotionItem));
			
				return boPromotionItemCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromotionItemCollectionCount
		///This method returns the collection count of BOPromotionItem objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 PromotionItemCollectionCount()
		{
			try
			{
				Int32 objCount = DAOPromotionItem.SelectAllCount();
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
		///List<BOPromotionItem>
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
				IDictionary<string, IList<object>> retObj = DAOPromotionItem.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromotionItemCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOPromotionItem objects, filtered by optional criteria
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
				IList<T> boPromotionItemCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOPromotionItem> daoPromotionItemCollection = DAOPromotionItem.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOPromotionItem resdaoPromotionItem in daoPromotionItemCollection)
					boPromotionItemCollection.Add((T)(object)new BOPromotionItem(resdaoPromotionItem));
			
				return boPromotionItemCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromotionItemCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOPromotionItem objects, filtered by optional criteria
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
				Int32 objCount = DAOPromotionItem.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int64? PromotionItemId
		{
			get
			{
				 return _promotionItemId;
			}
			set
			{
				_promotionItemId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? PromotionId
		{
			get
			{
				 return _promotionId;
			}
			set
			{
				_promotionId = value;
				_isDirty = true;
			}
		}
		
		public virtual string ItemCode
		{
			get
			{
				 return _itemCode;
			}
			set
			{
				_itemCode = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? GroupId
		{
			get
			{
				 return _groupId;
			}
			set
			{
				_groupId = value;
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
