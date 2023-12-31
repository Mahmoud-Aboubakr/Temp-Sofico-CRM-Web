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
	///This is the definition of the class BOClientServiceRequestDocumentVw.
	///</Summary>
	public partial class BOClientServiceRequestDocumentVw : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _documentSize;
		protected string _documentExt;
		protected DateTime? _uploadDate;
		protected string _documentPath;
		protected Int64? _requestId;
		protected Int64? _requestDocumentId;
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
		public BOClientServiceRequestDocumentVw()
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
		///DAOClientServiceRequestDocumentVw
		///</parameters>
		protected internal BOClientServiceRequestDocumentVw(DAOClientServiceRequestDocumentVw daoClientServiceRequestDocumentVw)
		{
			try
			{
				_documentSize = daoClientServiceRequestDocumentVw.DocumentSize;
				_documentExt = daoClientServiceRequestDocumentVw.DocumentExt;
				_uploadDate = daoClientServiceRequestDocumentVw.UploadDate;
				_documentPath = daoClientServiceRequestDocumentVw.DocumentPath;
				_requestId = daoClientServiceRequestDocumentVw.RequestId;
				_requestDocumentId = daoClientServiceRequestDocumentVw.RequestDocumentId;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///ClientServiceRequestDocumentVwCollection
		///This method returns the collection of BOClientServiceRequestDocumentVw objects
		///</Summary>
		///<returns>
		///List[BOClientServiceRequestDocumentVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOClientServiceRequestDocumentVw> ClientServiceRequestDocumentVwCollection()
		{
			try
			{
				IList<BOClientServiceRequestDocumentVw> boClientServiceRequestDocumentVwCollection = new List<BOClientServiceRequestDocumentVw>();
				IList<DAOClientServiceRequestDocumentVw> daoClientServiceRequestDocumentVwCollection = DAOClientServiceRequestDocumentVw.SelectAll();
			
				foreach(DAOClientServiceRequestDocumentVw daoClientServiceRequestDocumentVw in daoClientServiceRequestDocumentVwCollection)
					boClientServiceRequestDocumentVwCollection.Add(new BOClientServiceRequestDocumentVw(daoClientServiceRequestDocumentVw));
			
				return boClientServiceRequestDocumentVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientServiceRequestDocumentVwCollectionCount
		///This method returns the collection count of BOClientServiceRequestDocumentVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ClientServiceRequestDocumentVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOClientServiceRequestDocumentVw.SelectAllCount();
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
		///List<BOClientServiceRequestDocumentVw>
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
				IDictionary<string, IList<object>> retObj = DAOClientServiceRequestDocumentVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientServiceRequestDocumentVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOClientServiceRequestDocumentVw objects, filtered by optional criteria
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
				IList<T> boClientServiceRequestDocumentVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOClientServiceRequestDocumentVw> daoClientServiceRequestDocumentVwCollection = DAOClientServiceRequestDocumentVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOClientServiceRequestDocumentVw resdaoClientServiceRequestDocumentVw in daoClientServiceRequestDocumentVwCollection)
					boClientServiceRequestDocumentVwCollection.Add((T)(object)new BOClientServiceRequestDocumentVw(resdaoClientServiceRequestDocumentVw));
			
				return boClientServiceRequestDocumentVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientServiceRequestDocumentVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOClientServiceRequestDocumentVw objects, filtered by optional criteria
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
				Int32 objCount = DAOClientServiceRequestDocumentVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? DocumentSize
		{
			get
			{
				 return _documentSize;
			}
			set
			{
				_documentSize = value;
				_isDirty = true;
			}
		}
		
		public virtual string DocumentExt
		{
			get
			{
				 return _documentExt;
			}
			set
			{
				_documentExt = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? UploadDate
		{
			get
			{
				 return _uploadDate;
			}
			set
			{
				_uploadDate = value;
				_isDirty = true;
			}
		}
		
		public virtual string DocumentPath
		{
			get
			{
				 return _documentPath;
			}
			set
			{
				_documentPath = value;
				_isDirty = true;
			}
		}
		
		public virtual Int64? RequestId
		{
			get
			{
				 return _requestId;
			}
			set
			{
				_requestId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int64? RequestDocumentId
		{
			get
			{
				 return _requestDocumentId;
			}
			set
			{
				_requestDocumentId = value;
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
