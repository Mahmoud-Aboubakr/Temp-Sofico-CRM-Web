/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 3/23/2023 3:30:39 PM
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
	///This is the definition of the class BOBranchInvoiceingSetupVw.
	///</Summary>
	public partial class BOBranchInvoiceingSetupVw : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _serviceWorkerId;
		protected bool? _isEnabled;
		protected Int32? _branchId;
		protected Int32? _setupId;
		protected string _branchNameAr;
		protected string _branchCode;
		protected string _branchNameEn;
		protected string _serviceWorkerCode;
		protected string _serviceWorkerNameEn;
		protected string _serviceWorkerNameAr;
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
		public BOBranchInvoiceingSetupVw()
		{
		}

		///<Summary>
		///Constructor
		///This constructor initializes the business object from its respective data object
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///DAOBranchInvoiceingSetupVw
		///</parameters>
		protected internal BOBranchInvoiceingSetupVw(DAOBranchInvoiceingSetupVw daoBranchInvoiceingSetupVw)
		{
			try
			{
				_serviceWorkerId = daoBranchInvoiceingSetupVw.ServiceWorkerId;
				_isEnabled = daoBranchInvoiceingSetupVw.IsEnabled;
				_branchId = daoBranchInvoiceingSetupVw.BranchId;
				_setupId = daoBranchInvoiceingSetupVw.SetupId;
				_branchNameAr = daoBranchInvoiceingSetupVw.BranchNameAr;
				_branchCode = daoBranchInvoiceingSetupVw.BranchCode;
				_branchNameEn = daoBranchInvoiceingSetupVw.BranchNameEn;
				_serviceWorkerCode = daoBranchInvoiceingSetupVw.ServiceWorkerCode;
				_serviceWorkerNameEn = daoBranchInvoiceingSetupVw.ServiceWorkerNameEn;
				_serviceWorkerNameAr = daoBranchInvoiceingSetupVw.ServiceWorkerNameAr;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///BranchInvoiceingSetupVwCollection
		///This method returns the collection of BOBranchInvoiceingSetupVw objects
		///</Summary>
		///<returns>
		///List[BOBranchInvoiceingSetupVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOBranchInvoiceingSetupVw> BranchInvoiceingSetupVwCollection()
		{
			try
			{
				IList<BOBranchInvoiceingSetupVw> boBranchInvoiceingSetupVwCollection = new List<BOBranchInvoiceingSetupVw>();
				IList<DAOBranchInvoiceingSetupVw> daoBranchInvoiceingSetupVwCollection = DAOBranchInvoiceingSetupVw.SelectAll();
			
				foreach(DAOBranchInvoiceingSetupVw daoBranchInvoiceingSetupVw in daoBranchInvoiceingSetupVwCollection)
					boBranchInvoiceingSetupVwCollection.Add(new BOBranchInvoiceingSetupVw(daoBranchInvoiceingSetupVw));
			
				return boBranchInvoiceingSetupVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///BranchInvoiceingSetupVwCollectionCount
		///This method returns the collection count of BOBranchInvoiceingSetupVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 BranchInvoiceingSetupVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOBranchInvoiceingSetupVw.SelectAllCount();
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
		///List<BOBranchInvoiceingSetupVw>
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
				IDictionary<string, IList<object>> retObj = DAOBranchInvoiceingSetupVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///BranchInvoiceingSetupVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOBranchInvoiceingSetupVw objects, filtered by optional criteria
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
				IList<T> boBranchInvoiceingSetupVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOBranchInvoiceingSetupVw> daoBranchInvoiceingSetupVwCollection = DAOBranchInvoiceingSetupVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOBranchInvoiceingSetupVw resdaoBranchInvoiceingSetupVw in daoBranchInvoiceingSetupVwCollection)
					boBranchInvoiceingSetupVwCollection.Add((T)(object)new BOBranchInvoiceingSetupVw(resdaoBranchInvoiceingSetupVw));
			
				return boBranchInvoiceingSetupVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///BranchInvoiceingSetupVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOBranchInvoiceingSetupVw objects, filtered by optional criteria
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
				Int32 objCount = DAOBranchInvoiceingSetupVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? ServiceWorkerId
		{
			get
			{
				 return _serviceWorkerId;
			}
			set
			{
				_serviceWorkerId = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? IsEnabled
		{
			get
			{
				 return _isEnabled;
			}
			set
			{
				_isEnabled = value;
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
		
		public virtual Int32? SetupId
		{
			get
			{
				 return _setupId;
			}
			set
			{
				_setupId = value;
				_isDirty = true;
			}
		}
		
		public virtual string BranchNameAr
		{
			get
			{
				 return _branchNameAr;
			}
			set
			{
				_branchNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string BranchCode
		{
			get
			{
				 return _branchCode;
			}
			set
			{
				_branchCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string BranchNameEn
		{
			get
			{
				 return _branchNameEn;
			}
			set
			{
				_branchNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string ServiceWorkerCode
		{
			get
			{
				 return _serviceWorkerCode;
			}
			set
			{
				_serviceWorkerCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string ServiceWorkerNameEn
		{
			get
			{
				 return _serviceWorkerNameEn;
			}
			set
			{
				_serviceWorkerNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string ServiceWorkerNameAr
		{
			get
			{
				 return _serviceWorkerNameAr;
			}
			set
			{
				_serviceWorkerNameAr = value;
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