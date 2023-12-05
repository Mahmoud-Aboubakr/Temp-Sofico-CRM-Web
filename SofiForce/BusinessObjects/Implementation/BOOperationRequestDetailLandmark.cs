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
	///This is the definition of the class BOOperationRequestDetailLandmark.
	///</Summary>
	public partial class BOOperationRequestDetailLandmark : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int64? _detailId;
		protected Int32? _landmarkId;
		protected Int64? _detaillandId;
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
		public BOOperationRequestDetailLandmark()
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
		///Int64 detaillandId
		///</parameters>
		public BOOperationRequestDetailLandmark(Int64 detaillandId)
		{
			try
			{
				DAOOperationRequestDetailLandmark daoOperationRequestDetailLandmark = DAOOperationRequestDetailLandmark.SelectOne(detaillandId);
				_detailId = daoOperationRequestDetailLandmark.DetailId;
				_landmarkId = daoOperationRequestDetailLandmark.LandmarkId;
				_detaillandId = daoOperationRequestDetailLandmark.DetaillandId;
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
		///DAOOperationRequestDetailLandmark
		///</parameters>
		protected internal BOOperationRequestDetailLandmark(DAOOperationRequestDetailLandmark daoOperationRequestDetailLandmark)
		{
			try
			{
				_detailId = daoOperationRequestDetailLandmark.DetailId;
				_landmarkId = daoOperationRequestDetailLandmark.LandmarkId;
				_detaillandId = daoOperationRequestDetailLandmark.DetaillandId;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new OperationRequestDetailLandmark record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOOperationRequestDetailLandmark daoOperationRequestDetailLandmark = new DAOOperationRequestDetailLandmark();
			RegisterDataObject(daoOperationRequestDetailLandmark);
			BeginTransaction("savenewBOOperationRequestDet8250");
			try
			{
				daoOperationRequestDetailLandmark.DetailId = _detailId;
				daoOperationRequestDetailLandmark.LandmarkId = _landmarkId;
				daoOperationRequestDetailLandmark.Insert();
				CommitTransaction();
				
				_detailId = daoOperationRequestDetailLandmark.DetailId;
				_landmarkId = daoOperationRequestDetailLandmark.LandmarkId;
				_detaillandId = daoOperationRequestDetailLandmark.DetaillandId;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOOperationRequestDet8250");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one OperationRequestDetailLandmark record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOOperationRequestDetailLandmark
		///</parameters>
		public virtual void Update()
		{
			DAOOperationRequestDetailLandmark daoOperationRequestDetailLandmark = new DAOOperationRequestDetailLandmark();
			RegisterDataObject(daoOperationRequestDetailLandmark);
			BeginTransaction("updateBOOperationRequestDeta8250");
			try
			{
				daoOperationRequestDetailLandmark.DetailId = _detailId;
				daoOperationRequestDetailLandmark.LandmarkId = _landmarkId;
				daoOperationRequestDetailLandmark.DetaillandId = _detaillandId;
				daoOperationRequestDetailLandmark.Update();
				CommitTransaction();
				
				_detailId = daoOperationRequestDetailLandmark.DetailId;
				_landmarkId = daoOperationRequestDetailLandmark.LandmarkId;
				_detaillandId = daoOperationRequestDetailLandmark.DetaillandId;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOOperationRequestDeta8250");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one OperationRequestDetailLandmark record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOOperationRequestDetailLandmark daoOperationRequestDetailLandmark = new DAOOperationRequestDetailLandmark();
			RegisterDataObject(daoOperationRequestDetailLandmark);
			BeginTransaction("deleteBOOperationRequestDeta3475");
			try
			{
				daoOperationRequestDetailLandmark.DetaillandId = _detaillandId;
				daoOperationRequestDetailLandmark.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOOperationRequestDeta3475");
				throw;
			}
		}
		
		///<Summary>
		///OperationRequestDetailLandmarkCollection
		///This method returns the collection of BOOperationRequestDetailLandmark objects
		///</Summary>
		///<returns>
		///List[BOOperationRequestDetailLandmark]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOOperationRequestDetailLandmark> OperationRequestDetailLandmarkCollection()
		{
			try
			{
				IList<BOOperationRequestDetailLandmark> boOperationRequestDetailLandmarkCollection = new List<BOOperationRequestDetailLandmark>();
				IList<DAOOperationRequestDetailLandmark> daoOperationRequestDetailLandmarkCollection = DAOOperationRequestDetailLandmark.SelectAll();
			
				foreach(DAOOperationRequestDetailLandmark daoOperationRequestDetailLandmark in daoOperationRequestDetailLandmarkCollection)
					boOperationRequestDetailLandmarkCollection.Add(new BOOperationRequestDetailLandmark(daoOperationRequestDetailLandmark));
			
				return boOperationRequestDetailLandmarkCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///OperationRequestDetailLandmarkCollectionCount
		///This method returns the collection count of BOOperationRequestDetailLandmark objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 OperationRequestDetailLandmarkCollectionCount()
		{
			try
			{
				Int32 objCount = DAOOperationRequestDetailLandmark.SelectAllCount();
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
		///List<BOOperationRequestDetailLandmark>
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
				IDictionary<string, IList<object>> retObj = DAOOperationRequestDetailLandmark.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///OperationRequestDetailLandmarkCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOOperationRequestDetailLandmark objects, filtered by optional criteria
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
				IList<T> boOperationRequestDetailLandmarkCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOOperationRequestDetailLandmark> daoOperationRequestDetailLandmarkCollection = DAOOperationRequestDetailLandmark.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOOperationRequestDetailLandmark resdaoOperationRequestDetailLandmark in daoOperationRequestDetailLandmarkCollection)
					boOperationRequestDetailLandmarkCollection.Add((T)(object)new BOOperationRequestDetailLandmark(resdaoOperationRequestDetailLandmark));
			
				return boOperationRequestDetailLandmarkCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///OperationRequestDetailLandmarkCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOOperationRequestDetailLandmark objects, filtered by optional criteria
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
				Int32 objCount = DAOOperationRequestDetailLandmark.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int64? DetailId
		{
			get
			{
				 return _detailId;
			}
			set
			{
				_detailId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? LandmarkId
		{
			get
			{
				 return _landmarkId;
			}
			set
			{
				_landmarkId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int64? DetaillandId
		{
			get
			{
				 return _detaillandId;
			}
			set
			{
				_detaillandId = value;
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