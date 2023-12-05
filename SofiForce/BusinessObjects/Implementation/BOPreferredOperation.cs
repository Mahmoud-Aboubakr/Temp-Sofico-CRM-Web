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
	///This is the definition of the class BOPreferredOperation.
	///It maintains a collection of BOClientPreferredTime,BOOperationRequestDetailPreferredTime objects.
	///</Summary>
	public partial class BOPreferredOperation : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _preferredOperationId;
		protected string _preferredOperationCode;
		protected string _preferredOperationNameEn;
		protected string _preferredOperationNameAr;
		protected bool? _isActive;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected string _color;
		protected string _icon;
		protected Int32? _displayOrder;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOClientPreferredTime> _boClientPreferredTimeCollection;
		List<BOOperationRequestDetailPreferredTime> _boOperationRequestDetailPreferredTimeCollection;
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
		public BOPreferredOperation()
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
		///Int32 preferredOperationId
		///</parameters>
		public BOPreferredOperation(Int32 preferredOperationId)
		{
			try
			{
				DAOPreferredOperation daoPreferredOperation = DAOPreferredOperation.SelectOne(preferredOperationId);
				_preferredOperationId = daoPreferredOperation.PreferredOperationId;
				_preferredOperationCode = daoPreferredOperation.PreferredOperationCode;
				_preferredOperationNameEn = daoPreferredOperation.PreferredOperationNameEn;
				_preferredOperationNameAr = daoPreferredOperation.PreferredOperationNameAr;
				_isActive = daoPreferredOperation.IsActive;
				_canEdit = daoPreferredOperation.CanEdit;
				_canDelete = daoPreferredOperation.CanDelete;
				_color = daoPreferredOperation.Color;
				_icon = daoPreferredOperation.Icon;
				_displayOrder = daoPreferredOperation.DisplayOrder;
				_cBy = daoPreferredOperation.CBy;
				_cDate = daoPreferredOperation.CDate;
				_eBy = daoPreferredOperation.EBy;
				_eDate = daoPreferredOperation.EDate;
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
		///DAOPreferredOperation
		///</parameters>
		protected internal BOPreferredOperation(DAOPreferredOperation daoPreferredOperation)
		{
			try
			{
				_preferredOperationId = daoPreferredOperation.PreferredOperationId;
				_preferredOperationCode = daoPreferredOperation.PreferredOperationCode;
				_preferredOperationNameEn = daoPreferredOperation.PreferredOperationNameEn;
				_preferredOperationNameAr = daoPreferredOperation.PreferredOperationNameAr;
				_isActive = daoPreferredOperation.IsActive;
				_canEdit = daoPreferredOperation.CanEdit;
				_canDelete = daoPreferredOperation.CanDelete;
				_color = daoPreferredOperation.Color;
				_icon = daoPreferredOperation.Icon;
				_displayOrder = daoPreferredOperation.DisplayOrder;
				_cBy = daoPreferredOperation.CBy;
				_cDate = daoPreferredOperation.CDate;
				_eBy = daoPreferredOperation.EBy;
				_eDate = daoPreferredOperation.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new PreferredOperation record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOPreferredOperation daoPreferredOperation = new DAOPreferredOperation();
			RegisterDataObject(daoPreferredOperation);
			BeginTransaction("savenewBOPreferredOperation");
			try
			{
				daoPreferredOperation.PreferredOperationId = _preferredOperationId;
				daoPreferredOperation.PreferredOperationCode = _preferredOperationCode;
				daoPreferredOperation.PreferredOperationNameEn = _preferredOperationNameEn;
				daoPreferredOperation.PreferredOperationNameAr = _preferredOperationNameAr;
				daoPreferredOperation.IsActive = _isActive;
				daoPreferredOperation.CanEdit = _canEdit;
				daoPreferredOperation.CanDelete = _canDelete;
				daoPreferredOperation.Color = _color;
				daoPreferredOperation.Icon = _icon;
				daoPreferredOperation.DisplayOrder = _displayOrder;
				daoPreferredOperation.CBy = _cBy;
				daoPreferredOperation.CDate = _cDate;
				daoPreferredOperation.EBy = _eBy;
				daoPreferredOperation.EDate = _eDate;
				daoPreferredOperation.Insert();
				CommitTransaction();
				
				_preferredOperationId = daoPreferredOperation.PreferredOperationId;
				_preferredOperationCode = daoPreferredOperation.PreferredOperationCode;
				_preferredOperationNameEn = daoPreferredOperation.PreferredOperationNameEn;
				_preferredOperationNameAr = daoPreferredOperation.PreferredOperationNameAr;
				_isActive = daoPreferredOperation.IsActive;
				_canEdit = daoPreferredOperation.CanEdit;
				_canDelete = daoPreferredOperation.CanDelete;
				_color = daoPreferredOperation.Color;
				_icon = daoPreferredOperation.Icon;
				_displayOrder = daoPreferredOperation.DisplayOrder;
				_cBy = daoPreferredOperation.CBy;
				_cDate = daoPreferredOperation.CDate;
				_eBy = daoPreferredOperation.EBy;
				_eDate = daoPreferredOperation.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOPreferredOperation");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one PreferredOperation record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOPreferredOperation
		///</parameters>
		public virtual void Update()
		{
			DAOPreferredOperation daoPreferredOperation = new DAOPreferredOperation();
			RegisterDataObject(daoPreferredOperation);
			BeginTransaction("updateBOPreferredOperation");
			try
			{
				daoPreferredOperation.PreferredOperationId = _preferredOperationId;
				daoPreferredOperation.PreferredOperationCode = _preferredOperationCode;
				daoPreferredOperation.PreferredOperationNameEn = _preferredOperationNameEn;
				daoPreferredOperation.PreferredOperationNameAr = _preferredOperationNameAr;
				daoPreferredOperation.IsActive = _isActive;
				daoPreferredOperation.CanEdit = _canEdit;
				daoPreferredOperation.CanDelete = _canDelete;
				daoPreferredOperation.Color = _color;
				daoPreferredOperation.Icon = _icon;
				daoPreferredOperation.DisplayOrder = _displayOrder;
				daoPreferredOperation.CBy = _cBy;
				daoPreferredOperation.CDate = _cDate;
				daoPreferredOperation.EBy = _eBy;
				daoPreferredOperation.EDate = _eDate;
				daoPreferredOperation.Update();
				CommitTransaction();
				
				_preferredOperationId = daoPreferredOperation.PreferredOperationId;
				_preferredOperationCode = daoPreferredOperation.PreferredOperationCode;
				_preferredOperationNameEn = daoPreferredOperation.PreferredOperationNameEn;
				_preferredOperationNameAr = daoPreferredOperation.PreferredOperationNameAr;
				_isActive = daoPreferredOperation.IsActive;
				_canEdit = daoPreferredOperation.CanEdit;
				_canDelete = daoPreferredOperation.CanDelete;
				_color = daoPreferredOperation.Color;
				_icon = daoPreferredOperation.Icon;
				_displayOrder = daoPreferredOperation.DisplayOrder;
				_cBy = daoPreferredOperation.CBy;
				_cDate = daoPreferredOperation.CDate;
				_eBy = daoPreferredOperation.EBy;
				_eDate = daoPreferredOperation.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOPreferredOperation");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one PreferredOperation record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOPreferredOperation daoPreferredOperation = new DAOPreferredOperation();
			RegisterDataObject(daoPreferredOperation);
			BeginTransaction("deleteBOPreferredOperation");
			try
			{
				daoPreferredOperation.PreferredOperationId = _preferredOperationId;
				daoPreferredOperation.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOPreferredOperation");
				throw;
			}
		}
		
		///<Summary>
		///PreferredOperationCollection
		///This method returns the collection of BOPreferredOperation objects
		///</Summary>
		///<returns>
		///List[BOPreferredOperation]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOPreferredOperation> PreferredOperationCollection()
		{
			try
			{
				IList<BOPreferredOperation> boPreferredOperationCollection = new List<BOPreferredOperation>();
				IList<DAOPreferredOperation> daoPreferredOperationCollection = DAOPreferredOperation.SelectAll();
			
				foreach(DAOPreferredOperation daoPreferredOperation in daoPreferredOperationCollection)
					boPreferredOperationCollection.Add(new BOPreferredOperation(daoPreferredOperation));
			
				return boPreferredOperationCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PreferredOperationCollectionCount
		///This method returns the collection count of BOPreferredOperation objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 PreferredOperationCollectionCount()
		{
			try
			{
				Int32 objCount = DAOPreferredOperation.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///ClientPreferredTimeCollection
		///This method returns its collection of BOClientPreferredTime objects
		///</Summary>
		///<returns>
		///IList[BOClientPreferredTime]
		///</returns>
		///<parameters>
		///BOPreferredOperation
		///</parameters>
		public virtual IList<BOClientPreferredTime> ClientPreferredTimeCollection()
		{
			try
			{
				if(_boClientPreferredTimeCollection == null)
					LoadClientPreferredTimeCollection();
				
				return _boClientPreferredTimeCollection.AsReadOnly();
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///OperationRequestDetailPreferredTimeCollection
		///This method returns its collection of BOOperationRequestDetailPreferredTime objects
		///</Summary>
		///<returns>
		///IList[BOOperationRequestDetailPreferredTime]
		///</returns>
		///<parameters>
		///BOPreferredOperation
		///</parameters>
		public virtual IList<BOOperationRequestDetailPreferredTime> OperationRequestDetailPreferredTimeCollection()
		{
			try
			{
				if(_boOperationRequestDetailPreferredTimeCollection == null)
					LoadOperationRequestDetailPreferredTimeCollection();
				
				return _boOperationRequestDetailPreferredTimeCollection.AsReadOnly();
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
		///List<BOPreferredOperation>
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
				IDictionary<string, IList<object>> retObj = DAOPreferredOperation.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PreferredOperationCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOPreferredOperation objects, filtered by optional criteria
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
				IList<T> boPreferredOperationCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOPreferredOperation> daoPreferredOperationCollection = DAOPreferredOperation.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOPreferredOperation resdaoPreferredOperation in daoPreferredOperationCollection)
					boPreferredOperationCollection.Add((T)(object)new BOPreferredOperation(resdaoPreferredOperation));
			
				return boPreferredOperationCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PreferredOperationCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOPreferredOperation objects, filtered by optional criteria
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
				Int32 objCount = DAOPreferredOperation.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadClientPreferredTimeCollection
		///This method loads the internal collection of BOClientPreferredTime objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadClientPreferredTimeCollection()
		{
			try
			{
				_boClientPreferredTimeCollection = new List<BOClientPreferredTime>();
				IList<DAOClientPreferredTime> daoClientPreferredTimeCollection = DAOClientPreferredTime.SelectAllByPreferredOperationId(_preferredOperationId.Value);
				
				foreach(DAOClientPreferredTime daoClientPreferredTime in daoClientPreferredTimeCollection)
					_boClientPreferredTimeCollection.Add(new BOClientPreferredTime(daoClientPreferredTime));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddClientPreferredTime
		///This method persists a BOClientPreferredTime object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOClientPreferredTime
		///</parameters>
		public virtual void AddClientPreferredTime(BOClientPreferredTime boClientPreferredTime)
		{
			DAOClientPreferredTime daoClientPreferredTime = new DAOClientPreferredTime();
			RegisterDataObject(daoClientPreferredTime);
			BeginTransaction("addClientPreferredTime");
			try
			{
				daoClientPreferredTime.PreferredId = boClientPreferredTime.PreferredId;
				daoClientPreferredTime.ClientId = boClientPreferredTime.ClientId;
				daoClientPreferredTime.WeekDayId = boClientPreferredTime.WeekDayId;
				daoClientPreferredTime.FromTime = boClientPreferredTime.FromTime;
				daoClientPreferredTime.ToTime = boClientPreferredTime.ToTime;
				daoClientPreferredTime.PreferredOperationId = _preferredOperationId.Value;
				daoClientPreferredTime.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boClientPreferredTime = new BOClientPreferredTime(daoClientPreferredTime);
				if(_boClientPreferredTimeCollection != null)
					_boClientPreferredTimeCollection.Add(boClientPreferredTime);
			}
			catch
			{
				RollbackTransaction("addClientPreferredTime");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllClientPreferredTime
		///This method deletes all BOClientPreferredTime objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllClientPreferredTime()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllClientPreferredTime");
			try
			{
				DAOClientPreferredTime.DeleteAllByPreferredOperationId(ConnectionProvider, _preferredOperationId.Value);
				CommitTransaction();
				if(_boClientPreferredTimeCollection != null)
				{
					_boClientPreferredTimeCollection.Clear();
					_boClientPreferredTimeCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllClientPreferredTime");
				throw;
			}
		}
		
		///<Summary>
		///LoadOperationRequestDetailPreferredTimeCollection
		///This method loads the internal collection of BOOperationRequestDetailPreferredTime objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadOperationRequestDetailPreferredTimeCollection()
		{
			try
			{
				_boOperationRequestDetailPreferredTimeCollection = new List<BOOperationRequestDetailPreferredTime>();
				IList<DAOOperationRequestDetailPreferredTime> daoOperationRequestDetailPreferredTimeCollection = DAOOperationRequestDetailPreferredTime.SelectAllByPreferredOperationId(_preferredOperationId.Value);
				
				foreach(DAOOperationRequestDetailPreferredTime daoOperationRequestDetailPreferredTime in daoOperationRequestDetailPreferredTimeCollection)
					_boOperationRequestDetailPreferredTimeCollection.Add(new BOOperationRequestDetailPreferredTime(daoOperationRequestDetailPreferredTime));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddOperationRequestDetailPreferredTime
		///This method persists a BOOperationRequestDetailPreferredTime object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOOperationRequestDetailPreferredTime
		///</parameters>
		public virtual void AddOperationRequestDetailPreferredTime(BOOperationRequestDetailPreferredTime boOperationRequestDetailPreferredTime)
		{
			DAOOperationRequestDetailPreferredTime daoOperationRequestDetailPreferredTime = new DAOOperationRequestDetailPreferredTime();
			RegisterDataObject(daoOperationRequestDetailPreferredTime);
			BeginTransaction("addOperationRequestDetailPre6240");
			try
			{
				daoOperationRequestDetailPreferredTime.PreferredId = boOperationRequestDetailPreferredTime.PreferredId;
				daoOperationRequestDetailPreferredTime.DetailId = boOperationRequestDetailPreferredTime.DetailId;
				daoOperationRequestDetailPreferredTime.WeekDayId = boOperationRequestDetailPreferredTime.WeekDayId;
				daoOperationRequestDetailPreferredTime.FromTime = boOperationRequestDetailPreferredTime.FromTime;
				daoOperationRequestDetailPreferredTime.ToTime = boOperationRequestDetailPreferredTime.ToTime;
				daoOperationRequestDetailPreferredTime.PreferredOperationId = _preferredOperationId.Value;
				daoOperationRequestDetailPreferredTime.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boOperationRequestDetailPreferredTime = new BOOperationRequestDetailPreferredTime(daoOperationRequestDetailPreferredTime);
				if(_boOperationRequestDetailPreferredTimeCollection != null)
					_boOperationRequestDetailPreferredTimeCollection.Add(boOperationRequestDetailPreferredTime);
			}
			catch
			{
				RollbackTransaction("addOperationRequestDetailPre6240");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllOperationRequestDetailPreferredTime
		///This method deletes all BOOperationRequestDetailPreferredTime objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllOperationRequestDetailPreferredTime()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllOperationRequestDet6240");
			try
			{
				DAOOperationRequestDetailPreferredTime.DeleteAllByPreferredOperationId(ConnectionProvider, _preferredOperationId.Value);
				CommitTransaction();
				if(_boOperationRequestDetailPreferredTimeCollection != null)
				{
					_boOperationRequestDetailPreferredTimeCollection.Clear();
					_boOperationRequestDetailPreferredTimeCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllOperationRequestDet6240");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? PreferredOperationId
		{
			get
			{
				 return _preferredOperationId;
			}
			set
			{
				_preferredOperationId = value;
				_isDirty = true;
			}
		}
		
		public virtual string PreferredOperationCode
		{
			get
			{
				 return _preferredOperationCode;
			}
			set
			{
				_preferredOperationCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string PreferredOperationNameEn
		{
			get
			{
				 return _preferredOperationNameEn;
			}
			set
			{
				_preferredOperationNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string PreferredOperationNameAr
		{
			get
			{
				 return _preferredOperationNameAr;
			}
			set
			{
				_preferredOperationNameAr = value;
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
		
		public virtual Int32? DisplayOrder
		{
			get
			{
				 return _displayOrder;
			}
			set
			{
				_displayOrder = value;
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
