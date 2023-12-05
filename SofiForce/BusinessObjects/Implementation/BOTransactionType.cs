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
	///This is the definition of the class BOTransactionType.
	///It maintains a collection of BOClientTransaction objects.
	///</Summary>
	public partial class BOTransactionType : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _transactionTypeId;
		protected string _transactionTypeCode;
		protected string _transactionTypeNameEn;
		protected string _transactionTypeNameAr;
		protected bool? _isActive;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected string _color;
		protected string _icon;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOClientTransaction> _boClientTransactionCollection;
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
		public BOTransactionType()
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
		///Int32 transactionTypeId
		///</parameters>
		public BOTransactionType(Int32 transactionTypeId)
		{
			try
			{
				DAOTransactionType daoTransactionType = DAOTransactionType.SelectOne(transactionTypeId);
				_transactionTypeId = daoTransactionType.TransactionTypeId;
				_transactionTypeCode = daoTransactionType.TransactionTypeCode;
				_transactionTypeNameEn = daoTransactionType.TransactionTypeNameEn;
				_transactionTypeNameAr = daoTransactionType.TransactionTypeNameAr;
				_isActive = daoTransactionType.IsActive;
				_canEdit = daoTransactionType.CanEdit;
				_canDelete = daoTransactionType.CanDelete;
				_color = daoTransactionType.Color;
				_icon = daoTransactionType.Icon;
				_cBy = daoTransactionType.CBy;
				_cDate = daoTransactionType.CDate;
				_eBy = daoTransactionType.EBy;
				_eDate = daoTransactionType.EDate;
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
		///DAOTransactionType
		///</parameters>
		protected internal BOTransactionType(DAOTransactionType daoTransactionType)
		{
			try
			{
				_transactionTypeId = daoTransactionType.TransactionTypeId;
				_transactionTypeCode = daoTransactionType.TransactionTypeCode;
				_transactionTypeNameEn = daoTransactionType.TransactionTypeNameEn;
				_transactionTypeNameAr = daoTransactionType.TransactionTypeNameAr;
				_isActive = daoTransactionType.IsActive;
				_canEdit = daoTransactionType.CanEdit;
				_canDelete = daoTransactionType.CanDelete;
				_color = daoTransactionType.Color;
				_icon = daoTransactionType.Icon;
				_cBy = daoTransactionType.CBy;
				_cDate = daoTransactionType.CDate;
				_eBy = daoTransactionType.EBy;
				_eDate = daoTransactionType.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new TransactionType record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOTransactionType daoTransactionType = new DAOTransactionType();
			RegisterDataObject(daoTransactionType);
			BeginTransaction("savenewBOTransactionType");
			try
			{
				daoTransactionType.TransactionTypeId = _transactionTypeId;
				daoTransactionType.TransactionTypeCode = _transactionTypeCode;
				daoTransactionType.TransactionTypeNameEn = _transactionTypeNameEn;
				daoTransactionType.TransactionTypeNameAr = _transactionTypeNameAr;
				daoTransactionType.IsActive = _isActive;
				daoTransactionType.CanEdit = _canEdit;
				daoTransactionType.CanDelete = _canDelete;
				daoTransactionType.Color = _color;
				daoTransactionType.Icon = _icon;
				daoTransactionType.CBy = _cBy;
				daoTransactionType.CDate = _cDate;
				daoTransactionType.EBy = _eBy;
				daoTransactionType.EDate = _eDate;
				daoTransactionType.Insert();
				CommitTransaction();
				
				_transactionTypeId = daoTransactionType.TransactionTypeId;
				_transactionTypeCode = daoTransactionType.TransactionTypeCode;
				_transactionTypeNameEn = daoTransactionType.TransactionTypeNameEn;
				_transactionTypeNameAr = daoTransactionType.TransactionTypeNameAr;
				_isActive = daoTransactionType.IsActive;
				_canEdit = daoTransactionType.CanEdit;
				_canDelete = daoTransactionType.CanDelete;
				_color = daoTransactionType.Color;
				_icon = daoTransactionType.Icon;
				_cBy = daoTransactionType.CBy;
				_cDate = daoTransactionType.CDate;
				_eBy = daoTransactionType.EBy;
				_eDate = daoTransactionType.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOTransactionType");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one TransactionType record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOTransactionType
		///</parameters>
		public virtual void Update()
		{
			DAOTransactionType daoTransactionType = new DAOTransactionType();
			RegisterDataObject(daoTransactionType);
			BeginTransaction("updateBOTransactionType");
			try
			{
				daoTransactionType.TransactionTypeId = _transactionTypeId;
				daoTransactionType.TransactionTypeCode = _transactionTypeCode;
				daoTransactionType.TransactionTypeNameEn = _transactionTypeNameEn;
				daoTransactionType.TransactionTypeNameAr = _transactionTypeNameAr;
				daoTransactionType.IsActive = _isActive;
				daoTransactionType.CanEdit = _canEdit;
				daoTransactionType.CanDelete = _canDelete;
				daoTransactionType.Color = _color;
				daoTransactionType.Icon = _icon;
				daoTransactionType.CBy = _cBy;
				daoTransactionType.CDate = _cDate;
				daoTransactionType.EBy = _eBy;
				daoTransactionType.EDate = _eDate;
				daoTransactionType.Update();
				CommitTransaction();
				
				_transactionTypeId = daoTransactionType.TransactionTypeId;
				_transactionTypeCode = daoTransactionType.TransactionTypeCode;
				_transactionTypeNameEn = daoTransactionType.TransactionTypeNameEn;
				_transactionTypeNameAr = daoTransactionType.TransactionTypeNameAr;
				_isActive = daoTransactionType.IsActive;
				_canEdit = daoTransactionType.CanEdit;
				_canDelete = daoTransactionType.CanDelete;
				_color = daoTransactionType.Color;
				_icon = daoTransactionType.Icon;
				_cBy = daoTransactionType.CBy;
				_cDate = daoTransactionType.CDate;
				_eBy = daoTransactionType.EBy;
				_eDate = daoTransactionType.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOTransactionType");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one TransactionType record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOTransactionType daoTransactionType = new DAOTransactionType();
			RegisterDataObject(daoTransactionType);
			BeginTransaction("deleteBOTransactionType");
			try
			{
				daoTransactionType.TransactionTypeId = _transactionTypeId;
				daoTransactionType.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOTransactionType");
				throw;
			}
		}
		
		///<Summary>
		///TransactionTypeCollection
		///This method returns the collection of BOTransactionType objects
		///</Summary>
		///<returns>
		///List[BOTransactionType]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOTransactionType> TransactionTypeCollection()
		{
			try
			{
				IList<BOTransactionType> boTransactionTypeCollection = new List<BOTransactionType>();
				IList<DAOTransactionType> daoTransactionTypeCollection = DAOTransactionType.SelectAll();
			
				foreach(DAOTransactionType daoTransactionType in daoTransactionTypeCollection)
					boTransactionTypeCollection.Add(new BOTransactionType(daoTransactionType));
			
				return boTransactionTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///TransactionTypeCollectionCount
		///This method returns the collection count of BOTransactionType objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 TransactionTypeCollectionCount()
		{
			try
			{
				Int32 objCount = DAOTransactionType.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///ClientTransactionCollection
		///This method returns its collection of BOClientTransaction objects
		///</Summary>
		///<returns>
		///IList[BOClientTransaction]
		///</returns>
		///<parameters>
		///BOTransactionType
		///</parameters>
		public virtual IList<BOClientTransaction> ClientTransactionCollection()
		{
			try
			{
				if(_boClientTransactionCollection == null)
					LoadClientTransactionCollection();
				
				return _boClientTransactionCollection.AsReadOnly();
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
		///List<BOTransactionType>
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
				IDictionary<string, IList<object>> retObj = DAOTransactionType.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///TransactionTypeCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOTransactionType objects, filtered by optional criteria
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
				IList<T> boTransactionTypeCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOTransactionType> daoTransactionTypeCollection = DAOTransactionType.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOTransactionType resdaoTransactionType in daoTransactionTypeCollection)
					boTransactionTypeCollection.Add((T)(object)new BOTransactionType(resdaoTransactionType));
			
				return boTransactionTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///TransactionTypeCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOTransactionType objects, filtered by optional criteria
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
				Int32 objCount = DAOTransactionType.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadClientTransactionCollection
		///This method loads the internal collection of BOClientTransaction objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadClientTransactionCollection()
		{
			try
			{
				_boClientTransactionCollection = new List<BOClientTransaction>();
				IList<DAOClientTransaction> daoClientTransactionCollection = DAOClientTransaction.SelectAllByTransactionTypeId(_transactionTypeId.Value);
				
				foreach(DAOClientTransaction daoClientTransaction in daoClientTransactionCollection)
					_boClientTransactionCollection.Add(new BOClientTransaction(daoClientTransaction));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddClientTransaction
		///This method persists a BOClientTransaction object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOClientTransaction
		///</parameters>
		public virtual void AddClientTransaction(BOClientTransaction boClientTransaction)
		{
			DAOClientTransaction daoClientTransaction = new DAOClientTransaction();
			RegisterDataObject(daoClientTransaction);
			BeginTransaction("addClientTransaction");
			try
			{
				daoClientTransaction.TransactionId = boClientTransaction.TransactionId;
				daoClientTransaction.ClientId = boClientTransaction.ClientId;
				daoClientTransaction.TransactionCode = boClientTransaction.TransactionCode;
				daoClientTransaction.TransactionDate = boClientTransaction.TransactionDate;
				daoClientTransaction.TransactionValue = boClientTransaction.TransactionValue;
				daoClientTransaction.CBy = boClientTransaction.CBy;
				daoClientTransaction.CDate = boClientTransaction.CDate;
				daoClientTransaction.EBy = boClientTransaction.EBy;
				daoClientTransaction.EDate = boClientTransaction.EDate;
				daoClientTransaction.TransactionTypeId = _transactionTypeId.Value;
				daoClientTransaction.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boClientTransaction = new BOClientTransaction(daoClientTransaction);
				if(_boClientTransactionCollection != null)
					_boClientTransactionCollection.Add(boClientTransaction);
			}
			catch
			{
				RollbackTransaction("addClientTransaction");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllClientTransaction
		///This method deletes all BOClientTransaction objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllClientTransaction()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllClientTransaction");
			try
			{
				DAOClientTransaction.DeleteAllByTransactionTypeId(ConnectionProvider, _transactionTypeId.Value);
				CommitTransaction();
				if(_boClientTransactionCollection != null)
				{
					_boClientTransactionCollection.Clear();
					_boClientTransactionCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllClientTransaction");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? TransactionTypeId
		{
			get
			{
				 return _transactionTypeId;
			}
			set
			{
				_transactionTypeId = value;
				_isDirty = true;
			}
		}
		
		public virtual string TransactionTypeCode
		{
			get
			{
				 return _transactionTypeCode;
			}
			set
			{
				_transactionTypeCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string TransactionTypeNameEn
		{
			get
			{
				 return _transactionTypeNameEn;
			}
			set
			{
				_transactionTypeNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string TransactionTypeNameAr
		{
			get
			{
				 return _transactionTypeNameAr;
			}
			set
			{
				_transactionTypeNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? IsActive
		{
			get
			{
				 return _isActive;
			}
			set
			{
				_isActive = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? CanEdit
		{
			get
			{
				 return _canEdit;
			}
			set
			{
				_canEdit = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? CanDelete
		{
			get
			{
				 return _canDelete;
			}
			set
			{
				_canDelete = value;
				_isDirty = true;
			}
		}
		
		public virtual string Color
		{
			get
			{
				 return _color;
			}
			set
			{
				_color = value;
				_isDirty = true;
			}
		}
		
		public virtual string Icon
		{
			get
			{
				 return _icon;
			}
			set
			{
				_icon = value;
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
