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
	///This is the definition of the class BOClientComplainDocument.
	///</Summary>
	public partial class BOClientComplainDocument : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int64? _complainDocumentId;
		protected Int64? _complainId;
		protected string _documentPath;
		protected DateTime? _uploadDate;
		protected string _documentExt;
		protected Int32? _documentSize;
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
		public BOClientComplainDocument()
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
		///Int64 complainDocumentId
		///</parameters>
		public BOClientComplainDocument(Int64 complainDocumentId)
		{
			try
			{
				DAOClientComplainDocument daoClientComplainDocument = DAOClientComplainDocument.SelectOne(complainDocumentId);
				_complainDocumentId = daoClientComplainDocument.ComplainDocumentId;
				_complainId = daoClientComplainDocument.ComplainId;
				_documentPath = daoClientComplainDocument.DocumentPath;
				_uploadDate = daoClientComplainDocument.UploadDate;
				_documentExt = daoClientComplainDocument.DocumentExt;
				_documentSize = daoClientComplainDocument.DocumentSize;
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
		///DAOClientComplainDocument
		///</parameters>
		protected internal BOClientComplainDocument(DAOClientComplainDocument daoClientComplainDocument)
		{
			try
			{
				_complainDocumentId = daoClientComplainDocument.ComplainDocumentId;
				_complainId = daoClientComplainDocument.ComplainId;
				_documentPath = daoClientComplainDocument.DocumentPath;
				_uploadDate = daoClientComplainDocument.UploadDate;
				_documentExt = daoClientComplainDocument.DocumentExt;
				_documentSize = daoClientComplainDocument.DocumentSize;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new ClientComplainDocument record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOClientComplainDocument daoClientComplainDocument = new DAOClientComplainDocument();
			RegisterDataObject(daoClientComplainDocument);
			BeginTransaction("savenewBOClientComplainDocument");
			try
			{
				daoClientComplainDocument.ComplainId = _complainId;
				daoClientComplainDocument.DocumentPath = _documentPath;
				daoClientComplainDocument.UploadDate = _uploadDate;
				daoClientComplainDocument.DocumentExt = _documentExt;
				daoClientComplainDocument.DocumentSize = _documentSize;
				daoClientComplainDocument.Insert();
				CommitTransaction();
				
				_complainDocumentId = daoClientComplainDocument.ComplainDocumentId;
				_complainId = daoClientComplainDocument.ComplainId;
				_documentPath = daoClientComplainDocument.DocumentPath;
				_uploadDate = daoClientComplainDocument.UploadDate;
				_documentExt = daoClientComplainDocument.DocumentExt;
				_documentSize = daoClientComplainDocument.DocumentSize;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOClientComplainDocument");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one ClientComplainDocument record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOClientComplainDocument
		///</parameters>
		public virtual void Update()
		{
			DAOClientComplainDocument daoClientComplainDocument = new DAOClientComplainDocument();
			RegisterDataObject(daoClientComplainDocument);
			BeginTransaction("updateBOClientComplainDocument");
			try
			{
				daoClientComplainDocument.ComplainDocumentId = _complainDocumentId;
				daoClientComplainDocument.ComplainId = _complainId;
				daoClientComplainDocument.DocumentPath = _documentPath;
				daoClientComplainDocument.UploadDate = _uploadDate;
				daoClientComplainDocument.DocumentExt = _documentExt;
				daoClientComplainDocument.DocumentSize = _documentSize;
				daoClientComplainDocument.Update();
				CommitTransaction();
				
				_complainDocumentId = daoClientComplainDocument.ComplainDocumentId;
				_complainId = daoClientComplainDocument.ComplainId;
				_documentPath = daoClientComplainDocument.DocumentPath;
				_uploadDate = daoClientComplainDocument.UploadDate;
				_documentExt = daoClientComplainDocument.DocumentExt;
				_documentSize = daoClientComplainDocument.DocumentSize;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOClientComplainDocument");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one ClientComplainDocument record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOClientComplainDocument daoClientComplainDocument = new DAOClientComplainDocument();
			RegisterDataObject(daoClientComplainDocument);
			BeginTransaction("deleteBOClientComplainDocument");
			try
			{
				daoClientComplainDocument.ComplainDocumentId = _complainDocumentId;
				daoClientComplainDocument.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOClientComplainDocument");
				throw;
			}
		}
		
		///<Summary>
		///ClientComplainDocumentCollection
		///This method returns the collection of BOClientComplainDocument objects
		///</Summary>
		///<returns>
		///List[BOClientComplainDocument]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOClientComplainDocument> ClientComplainDocumentCollection()
		{
			try
			{
				IList<BOClientComplainDocument> boClientComplainDocumentCollection = new List<BOClientComplainDocument>();
				IList<DAOClientComplainDocument> daoClientComplainDocumentCollection = DAOClientComplainDocument.SelectAll();
			
				foreach(DAOClientComplainDocument daoClientComplainDocument in daoClientComplainDocumentCollection)
					boClientComplainDocumentCollection.Add(new BOClientComplainDocument(daoClientComplainDocument));
			
				return boClientComplainDocumentCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientComplainDocumentCollectionCount
		///This method returns the collection count of BOClientComplainDocument objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ClientComplainDocumentCollectionCount()
		{
			try
			{
				Int32 objCount = DAOClientComplainDocument.SelectAllCount();
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
		///List<BOClientComplainDocument>
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
				IDictionary<string, IList<object>> retObj = DAOClientComplainDocument.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientComplainDocumentCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOClientComplainDocument objects, filtered by optional criteria
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
				IList<T> boClientComplainDocumentCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOClientComplainDocument> daoClientComplainDocumentCollection = DAOClientComplainDocument.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOClientComplainDocument resdaoClientComplainDocument in daoClientComplainDocumentCollection)
					boClientComplainDocumentCollection.Add((T)(object)new BOClientComplainDocument(resdaoClientComplainDocument));
			
				return boClientComplainDocumentCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientComplainDocumentCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOClientComplainDocument objects, filtered by optional criteria
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
				Int32 objCount = DAOClientComplainDocument.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int64? ComplainDocumentId
		{
			get
			{
				 return _complainDocumentId;
			}
			set
			{
				_complainDocumentId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int64? ComplainId
		{
			get
			{
				 return _complainId;
			}
			set
			{
				_complainId = value;
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