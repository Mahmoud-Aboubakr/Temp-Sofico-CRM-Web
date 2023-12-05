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
	///This is the definition of the class BOReasonType.
	///</Summary>
	public partial class BOReasonType : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _reasonTypeId;
		protected string _reasonTypeCode;
		protected string _reasonTypeName;
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
		public BOReasonType()
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
		///Int32 reasonTypeId
		///</parameters>
		public BOReasonType(Int32 reasonTypeId)
		{
			try
			{
				DAOReasonType daoReasonType = DAOReasonType.SelectOne(reasonTypeId);
				_reasonTypeId = daoReasonType.ReasonTypeId;
				_reasonTypeCode = daoReasonType.ReasonTypeCode;
				_reasonTypeName = daoReasonType.ReasonTypeName;
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
		///DAOReasonType
		///</parameters>
		protected internal BOReasonType(DAOReasonType daoReasonType)
		{
			try
			{
				_reasonTypeId = daoReasonType.ReasonTypeId;
				_reasonTypeCode = daoReasonType.ReasonTypeCode;
				_reasonTypeName = daoReasonType.ReasonTypeName;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new ReasonType record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOReasonType daoReasonType = new DAOReasonType();
			RegisterDataObject(daoReasonType);
			BeginTransaction("savenewBOReasonType");
			try
			{
				daoReasonType.ReasonTypeId = _reasonTypeId;
				daoReasonType.ReasonTypeCode = _reasonTypeCode;
				daoReasonType.ReasonTypeName = _reasonTypeName;
				daoReasonType.Insert();
				CommitTransaction();
				
				_reasonTypeId = daoReasonType.ReasonTypeId;
				_reasonTypeCode = daoReasonType.ReasonTypeCode;
				_reasonTypeName = daoReasonType.ReasonTypeName;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOReasonType");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one ReasonType record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOReasonType
		///</parameters>
		public virtual void Update()
		{
			DAOReasonType daoReasonType = new DAOReasonType();
			RegisterDataObject(daoReasonType);
			BeginTransaction("updateBOReasonType");
			try
			{
				daoReasonType.ReasonTypeId = _reasonTypeId;
				daoReasonType.ReasonTypeCode = _reasonTypeCode;
				daoReasonType.ReasonTypeName = _reasonTypeName;
				daoReasonType.Update();
				CommitTransaction();
				
				_reasonTypeId = daoReasonType.ReasonTypeId;
				_reasonTypeCode = daoReasonType.ReasonTypeCode;
				_reasonTypeName = daoReasonType.ReasonTypeName;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOReasonType");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one ReasonType record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOReasonType daoReasonType = new DAOReasonType();
			RegisterDataObject(daoReasonType);
			BeginTransaction("deleteBOReasonType");
			try
			{
				daoReasonType.ReasonTypeId = _reasonTypeId;
				daoReasonType.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOReasonType");
				throw;
			}
		}
		
		///<Summary>
		///ReasonTypeCollection
		///This method returns the collection of BOReasonType objects
		///</Summary>
		///<returns>
		///List[BOReasonType]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOReasonType> ReasonTypeCollection()
		{
			try
			{
				IList<BOReasonType> boReasonTypeCollection = new List<BOReasonType>();
				IList<DAOReasonType> daoReasonTypeCollection = DAOReasonType.SelectAll();
			
				foreach(DAOReasonType daoReasonType in daoReasonTypeCollection)
					boReasonTypeCollection.Add(new BOReasonType(daoReasonType));
			
				return boReasonTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ReasonTypeCollectionCount
		///This method returns the collection count of BOReasonType objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ReasonTypeCollectionCount()
		{
			try
			{
				Int32 objCount = DAOReasonType.SelectAllCount();
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
		///List<BOReasonType>
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
				IDictionary<string, IList<object>> retObj = DAOReasonType.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ReasonTypeCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOReasonType objects, filtered by optional criteria
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
				IList<T> boReasonTypeCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOReasonType> daoReasonTypeCollection = DAOReasonType.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOReasonType resdaoReasonType in daoReasonTypeCollection)
					boReasonTypeCollection.Add((T)(object)new BOReasonType(resdaoReasonType));
			
				return boReasonTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ReasonTypeCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOReasonType objects, filtered by optional criteria
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
				Int32 objCount = DAOReasonType.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? ReasonTypeId
		{
			get
			{
				 return _reasonTypeId;
			}
			set
			{
				_reasonTypeId = value;
				_isDirty = true;
			}
		}
		
		public virtual string ReasonTypeCode
		{
			get
			{
				 return _reasonTypeCode;
			}
			set
			{
				_reasonTypeCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string ReasonTypeName
		{
			get
			{
				 return _reasonTypeName;
			}
			set
			{
				_reasonTypeName = value;
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
