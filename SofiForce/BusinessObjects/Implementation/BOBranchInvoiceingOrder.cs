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
	///This is the definition of the class BOBranchInvoiceingOrder.
	///</Summary>
	public partial class BOBranchInvoiceingOrder : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _sortOrderId;
		protected Int32? _branchId;
		protected Int32? _sortOrder;
		protected string _sortProperty;
		protected string _sortDirection;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
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
		public BOBranchInvoiceingOrder()
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
		///Int32 sortOrderId
		///</parameters>
		public BOBranchInvoiceingOrder(Int32 sortOrderId)
		{
			try
			{
				DAOBranchInvoiceingOrder daoBranchInvoiceingOrder = DAOBranchInvoiceingOrder.SelectOne(sortOrderId);
				_sortOrderId = daoBranchInvoiceingOrder.SortOrderId;
				_branchId = daoBranchInvoiceingOrder.BranchId;
				_sortOrder = daoBranchInvoiceingOrder.SortOrder;
				_sortProperty = daoBranchInvoiceingOrder.SortProperty;
				_sortDirection = daoBranchInvoiceingOrder.SortDirection;
				_cBy = daoBranchInvoiceingOrder.CBy;
				_cDate = daoBranchInvoiceingOrder.CDate;
				_eBy = daoBranchInvoiceingOrder.EBy;
				_eDate = daoBranchInvoiceingOrder.EDate;
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
		///DAOBranchInvoiceingOrder
		///</parameters>
		protected internal BOBranchInvoiceingOrder(DAOBranchInvoiceingOrder daoBranchInvoiceingOrder)
		{
			try
			{
				_sortOrderId = daoBranchInvoiceingOrder.SortOrderId;
				_branchId = daoBranchInvoiceingOrder.BranchId;
				_sortOrder = daoBranchInvoiceingOrder.SortOrder;
				_sortProperty = daoBranchInvoiceingOrder.SortProperty;
				_sortDirection = daoBranchInvoiceingOrder.SortDirection;
				_cBy = daoBranchInvoiceingOrder.CBy;
				_cDate = daoBranchInvoiceingOrder.CDate;
				_eBy = daoBranchInvoiceingOrder.EBy;
				_eDate = daoBranchInvoiceingOrder.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new BranchInvoiceingOrder record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOBranchInvoiceingOrder daoBranchInvoiceingOrder = new DAOBranchInvoiceingOrder();
			RegisterDataObject(daoBranchInvoiceingOrder);
			BeginTransaction("savenewBOBranchInvoiceingOrder");
			try
			{
				daoBranchInvoiceingOrder.BranchId = _branchId;
				daoBranchInvoiceingOrder.SortOrder = _sortOrder;
				daoBranchInvoiceingOrder.SortProperty = _sortProperty;
				daoBranchInvoiceingOrder.SortDirection = _sortDirection;
				daoBranchInvoiceingOrder.CBy = _cBy;
				daoBranchInvoiceingOrder.CDate = _cDate;
				daoBranchInvoiceingOrder.EBy = _eBy;
				daoBranchInvoiceingOrder.EDate = _eDate;
				daoBranchInvoiceingOrder.Insert();
				CommitTransaction();
				
				_sortOrderId = daoBranchInvoiceingOrder.SortOrderId;
				_branchId = daoBranchInvoiceingOrder.BranchId;
				_sortOrder = daoBranchInvoiceingOrder.SortOrder;
				_sortProperty = daoBranchInvoiceingOrder.SortProperty;
				_sortDirection = daoBranchInvoiceingOrder.SortDirection;
				_cBy = daoBranchInvoiceingOrder.CBy;
				_cDate = daoBranchInvoiceingOrder.CDate;
				_eBy = daoBranchInvoiceingOrder.EBy;
				_eDate = daoBranchInvoiceingOrder.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOBranchInvoiceingOrder");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one BranchInvoiceingOrder record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOBranchInvoiceingOrder
		///</parameters>
		public virtual void Update()
		{
			DAOBranchInvoiceingOrder daoBranchInvoiceingOrder = new DAOBranchInvoiceingOrder();
			RegisterDataObject(daoBranchInvoiceingOrder);
			BeginTransaction("updateBOBranchInvoiceingOrder");
			try
			{
				daoBranchInvoiceingOrder.SortOrderId = _sortOrderId;
				daoBranchInvoiceingOrder.BranchId = _branchId;
				daoBranchInvoiceingOrder.SortOrder = _sortOrder;
				daoBranchInvoiceingOrder.SortProperty = _sortProperty;
				daoBranchInvoiceingOrder.SortDirection = _sortDirection;
				daoBranchInvoiceingOrder.CBy = _cBy;
				daoBranchInvoiceingOrder.CDate = _cDate;
				daoBranchInvoiceingOrder.EBy = _eBy;
				daoBranchInvoiceingOrder.EDate = _eDate;
				daoBranchInvoiceingOrder.Update();
				CommitTransaction();
				
				_sortOrderId = daoBranchInvoiceingOrder.SortOrderId;
				_branchId = daoBranchInvoiceingOrder.BranchId;
				_sortOrder = daoBranchInvoiceingOrder.SortOrder;
				_sortProperty = daoBranchInvoiceingOrder.SortProperty;
				_sortDirection = daoBranchInvoiceingOrder.SortDirection;
				_cBy = daoBranchInvoiceingOrder.CBy;
				_cDate = daoBranchInvoiceingOrder.CDate;
				_eBy = daoBranchInvoiceingOrder.EBy;
				_eDate = daoBranchInvoiceingOrder.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOBranchInvoiceingOrder");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one BranchInvoiceingOrder record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOBranchInvoiceingOrder daoBranchInvoiceingOrder = new DAOBranchInvoiceingOrder();
			RegisterDataObject(daoBranchInvoiceingOrder);
			BeginTransaction("deleteBOBranchInvoiceingOrder");
			try
			{
				daoBranchInvoiceingOrder.SortOrderId = _sortOrderId;
				daoBranchInvoiceingOrder.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOBranchInvoiceingOrder");
				throw;
			}
		}
		
		///<Summary>
		///BranchInvoiceingOrderCollection
		///This method returns the collection of BOBranchInvoiceingOrder objects
		///</Summary>
		///<returns>
		///List[BOBranchInvoiceingOrder]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOBranchInvoiceingOrder> BranchInvoiceingOrderCollection()
		{
			try
			{
				IList<BOBranchInvoiceingOrder> boBranchInvoiceingOrderCollection = new List<BOBranchInvoiceingOrder>();
				IList<DAOBranchInvoiceingOrder> daoBranchInvoiceingOrderCollection = DAOBranchInvoiceingOrder.SelectAll();
			
				foreach(DAOBranchInvoiceingOrder daoBranchInvoiceingOrder in daoBranchInvoiceingOrderCollection)
					boBranchInvoiceingOrderCollection.Add(new BOBranchInvoiceingOrder(daoBranchInvoiceingOrder));
			
				return boBranchInvoiceingOrderCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///BranchInvoiceingOrderCollectionCount
		///This method returns the collection count of BOBranchInvoiceingOrder objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 BranchInvoiceingOrderCollectionCount()
		{
			try
			{
				Int32 objCount = DAOBranchInvoiceingOrder.SelectAllCount();
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
		///List<BOBranchInvoiceingOrder>
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
				IDictionary<string, IList<object>> retObj = DAOBranchInvoiceingOrder.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///BranchInvoiceingOrderCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOBranchInvoiceingOrder objects, filtered by optional criteria
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
				IList<T> boBranchInvoiceingOrderCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOBranchInvoiceingOrder> daoBranchInvoiceingOrderCollection = DAOBranchInvoiceingOrder.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOBranchInvoiceingOrder resdaoBranchInvoiceingOrder in daoBranchInvoiceingOrderCollection)
					boBranchInvoiceingOrderCollection.Add((T)(object)new BOBranchInvoiceingOrder(resdaoBranchInvoiceingOrder));
			
				return boBranchInvoiceingOrderCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///BranchInvoiceingOrderCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOBranchInvoiceingOrder objects, filtered by optional criteria
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
				Int32 objCount = DAOBranchInvoiceingOrder.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? SortOrderId
		{
			get
			{
				 return _sortOrderId;
			}
			set
			{
				_sortOrderId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? BranchId
		{
			get
			{
				 return _branchId;
			}
			set
			{
				_branchId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? SortOrder
		{
			get
			{
				 return _sortOrder;
			}
			set
			{
				_sortOrder = value;
				_isDirty = true;
			}
		}
		
		public virtual string SortProperty
		{
			get
			{
				 return _sortProperty;
			}
			set
			{
				_sortProperty = value;
				_isDirty = true;
			}
		}
		
		public virtual string SortDirection
		{
			get
			{
				 return _sortDirection;
			}
			set
			{
				_sortDirection = value;
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
