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
	///This is the definition of the class BOPromotionInput.
	///It maintains a collection of BOPromotionType objects.
	///</Summary>
	public partial class BOPromotionInput : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _promotionInputId;
		protected string _promotionInputCode;
		protected string _promotionInputNameEn;
		protected string _promotionInputNameAr;
		protected string _icon;
		protected string _color;
		protected Int32? _displayOrder;
		protected bool? _isActive;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOPromotionType> _boPromotionTypeCollection;
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
		public BOPromotionInput()
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
		///Int32 promotionInputId
		///</parameters>
		public BOPromotionInput(Int32 promotionInputId)
		{
			try
			{
				DAOPromotionInput daoPromotionInput = DAOPromotionInput.SelectOne(promotionInputId);
				_promotionInputId = daoPromotionInput.PromotionInputId;
				_promotionInputCode = daoPromotionInput.PromotionInputCode;
				_promotionInputNameEn = daoPromotionInput.PromotionInputNameEn;
				_promotionInputNameAr = daoPromotionInput.PromotionInputNameAr;
				_icon = daoPromotionInput.Icon;
				_color = daoPromotionInput.Color;
				_displayOrder = daoPromotionInput.DisplayOrder;
				_isActive = daoPromotionInput.IsActive;
				_canEdit = daoPromotionInput.CanEdit;
				_canDelete = daoPromotionInput.CanDelete;
				_cBy = daoPromotionInput.CBy;
				_cDate = daoPromotionInput.CDate;
				_eBy = daoPromotionInput.EBy;
				_eDate = daoPromotionInput.EDate;
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
		///DAOPromotionInput
		///</parameters>
		protected internal BOPromotionInput(DAOPromotionInput daoPromotionInput)
		{
			try
			{
				_promotionInputId = daoPromotionInput.PromotionInputId;
				_promotionInputCode = daoPromotionInput.PromotionInputCode;
				_promotionInputNameEn = daoPromotionInput.PromotionInputNameEn;
				_promotionInputNameAr = daoPromotionInput.PromotionInputNameAr;
				_icon = daoPromotionInput.Icon;
				_color = daoPromotionInput.Color;
				_displayOrder = daoPromotionInput.DisplayOrder;
				_isActive = daoPromotionInput.IsActive;
				_canEdit = daoPromotionInput.CanEdit;
				_canDelete = daoPromotionInput.CanDelete;
				_cBy = daoPromotionInput.CBy;
				_cDate = daoPromotionInput.CDate;
				_eBy = daoPromotionInput.EBy;
				_eDate = daoPromotionInput.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new PromotionInput record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOPromotionInput daoPromotionInput = new DAOPromotionInput();
			RegisterDataObject(daoPromotionInput);
			BeginTransaction("savenewBOPromotionInput");
			try
			{
				daoPromotionInput.PromotionInputId = _promotionInputId;
				daoPromotionInput.PromotionInputCode = _promotionInputCode;
				daoPromotionInput.PromotionInputNameEn = _promotionInputNameEn;
				daoPromotionInput.PromotionInputNameAr = _promotionInputNameAr;
				daoPromotionInput.Icon = _icon;
				daoPromotionInput.Color = _color;
				daoPromotionInput.DisplayOrder = _displayOrder;
				daoPromotionInput.IsActive = _isActive;
				daoPromotionInput.CanEdit = _canEdit;
				daoPromotionInput.CanDelete = _canDelete;
				daoPromotionInput.CBy = _cBy;
				daoPromotionInput.CDate = _cDate;
				daoPromotionInput.EBy = _eBy;
				daoPromotionInput.EDate = _eDate;
				daoPromotionInput.Insert();
				CommitTransaction();
				
				_promotionInputId = daoPromotionInput.PromotionInputId;
				_promotionInputCode = daoPromotionInput.PromotionInputCode;
				_promotionInputNameEn = daoPromotionInput.PromotionInputNameEn;
				_promotionInputNameAr = daoPromotionInput.PromotionInputNameAr;
				_icon = daoPromotionInput.Icon;
				_color = daoPromotionInput.Color;
				_displayOrder = daoPromotionInput.DisplayOrder;
				_isActive = daoPromotionInput.IsActive;
				_canEdit = daoPromotionInput.CanEdit;
				_canDelete = daoPromotionInput.CanDelete;
				_cBy = daoPromotionInput.CBy;
				_cDate = daoPromotionInput.CDate;
				_eBy = daoPromotionInput.EBy;
				_eDate = daoPromotionInput.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOPromotionInput");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one PromotionInput record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOPromotionInput
		///</parameters>
		public virtual void Update()
		{
			DAOPromotionInput daoPromotionInput = new DAOPromotionInput();
			RegisterDataObject(daoPromotionInput);
			BeginTransaction("updateBOPromotionInput");
			try
			{
				daoPromotionInput.PromotionInputId = _promotionInputId;
				daoPromotionInput.PromotionInputCode = _promotionInputCode;
				daoPromotionInput.PromotionInputNameEn = _promotionInputNameEn;
				daoPromotionInput.PromotionInputNameAr = _promotionInputNameAr;
				daoPromotionInput.Icon = _icon;
				daoPromotionInput.Color = _color;
				daoPromotionInput.DisplayOrder = _displayOrder;
				daoPromotionInput.IsActive = _isActive;
				daoPromotionInput.CanEdit = _canEdit;
				daoPromotionInput.CanDelete = _canDelete;
				daoPromotionInput.CBy = _cBy;
				daoPromotionInput.CDate = _cDate;
				daoPromotionInput.EBy = _eBy;
				daoPromotionInput.EDate = _eDate;
				daoPromotionInput.Update();
				CommitTransaction();
				
				_promotionInputId = daoPromotionInput.PromotionInputId;
				_promotionInputCode = daoPromotionInput.PromotionInputCode;
				_promotionInputNameEn = daoPromotionInput.PromotionInputNameEn;
				_promotionInputNameAr = daoPromotionInput.PromotionInputNameAr;
				_icon = daoPromotionInput.Icon;
				_color = daoPromotionInput.Color;
				_displayOrder = daoPromotionInput.DisplayOrder;
				_isActive = daoPromotionInput.IsActive;
				_canEdit = daoPromotionInput.CanEdit;
				_canDelete = daoPromotionInput.CanDelete;
				_cBy = daoPromotionInput.CBy;
				_cDate = daoPromotionInput.CDate;
				_eBy = daoPromotionInput.EBy;
				_eDate = daoPromotionInput.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOPromotionInput");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one PromotionInput record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOPromotionInput daoPromotionInput = new DAOPromotionInput();
			RegisterDataObject(daoPromotionInput);
			BeginTransaction("deleteBOPromotionInput");
			try
			{
				daoPromotionInput.PromotionInputId = _promotionInputId;
				daoPromotionInput.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOPromotionInput");
				throw;
			}
		}
		
		///<Summary>
		///PromotionInputCollection
		///This method returns the collection of BOPromotionInput objects
		///</Summary>
		///<returns>
		///List[BOPromotionInput]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOPromotionInput> PromotionInputCollection()
		{
			try
			{
				IList<BOPromotionInput> boPromotionInputCollection = new List<BOPromotionInput>();
				IList<DAOPromotionInput> daoPromotionInputCollection = DAOPromotionInput.SelectAll();
			
				foreach(DAOPromotionInput daoPromotionInput in daoPromotionInputCollection)
					boPromotionInputCollection.Add(new BOPromotionInput(daoPromotionInput));
			
				return boPromotionInputCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromotionInputCollectionCount
		///This method returns the collection count of BOPromotionInput objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 PromotionInputCollectionCount()
		{
			try
			{
				Int32 objCount = DAOPromotionInput.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///PromotionTypeCollection
		///This method returns its collection of BOPromotionType objects
		///</Summary>
		///<returns>
		///IList[BOPromotionType]
		///</returns>
		///<parameters>
		///BOPromotionInput
		///</parameters>
		public virtual IList<BOPromotionType> PromotionTypeCollection()
		{
			try
			{
				if(_boPromotionTypeCollection == null)
					LoadPromotionTypeCollection();
				
				return _boPromotionTypeCollection.AsReadOnly();
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
		///List<BOPromotionInput>
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
				IDictionary<string, IList<object>> retObj = DAOPromotionInput.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromotionInputCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOPromotionInput objects, filtered by optional criteria
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
				IList<T> boPromotionInputCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOPromotionInput> daoPromotionInputCollection = DAOPromotionInput.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOPromotionInput resdaoPromotionInput in daoPromotionInputCollection)
					boPromotionInputCollection.Add((T)(object)new BOPromotionInput(resdaoPromotionInput));
			
				return boPromotionInputCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromotionInputCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOPromotionInput objects, filtered by optional criteria
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
				Int32 objCount = DAOPromotionInput.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadPromotionTypeCollection
		///This method loads the internal collection of BOPromotionType objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadPromotionTypeCollection()
		{
			try
			{
				_boPromotionTypeCollection = new List<BOPromotionType>();
				IList<DAOPromotionType> daoPromotionTypeCollection = DAOPromotionType.SelectAllByPromotionInputId(_promotionInputId.Value);
				
				foreach(DAOPromotionType daoPromotionType in daoPromotionTypeCollection)
					_boPromotionTypeCollection.Add(new BOPromotionType(daoPromotionType));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddPromotionType
		///This method persists a BOPromotionType object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOPromotionType
		///</parameters>
		public virtual void AddPromotionType(BOPromotionType boPromotionType)
		{
			DAOPromotionType daoPromotionType = new DAOPromotionType();
			RegisterDataObject(daoPromotionType);
			BeginTransaction("addPromotionType");
			try
			{
				daoPromotionType.PromotionTypeId = boPromotionType.PromotionTypeId;
				daoPromotionType.PromotionTypeCode = boPromotionType.PromotionTypeCode;
				daoPromotionType.PromotionTypeNameAr = boPromotionType.PromotionTypeNameAr;
				daoPromotionType.PromotionTypeNameEn = boPromotionType.PromotionTypeNameEn;
				daoPromotionType.PromotionTypeDesc = boPromotionType.PromotionTypeDesc;
				daoPromotionType.PromotionOutputId = boPromotionType.PromotionOutputId;
				daoPromotionType.IsActive = boPromotionType.IsActive;
				daoPromotionType.CanEdit = boPromotionType.CanEdit;
				daoPromotionType.CanDelete = boPromotionType.CanDelete;
				daoPromotionType.DisplayOrder = boPromotionType.DisplayOrder;
				daoPromotionType.CBy = boPromotionType.CBy;
				daoPromotionType.CDate = boPromotionType.CDate;
				daoPromotionType.EBy = boPromotionType.EBy;
				daoPromotionType.EDate = boPromotionType.EDate;
				daoPromotionType.PromotionInputId = _promotionInputId.Value;
				daoPromotionType.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boPromotionType = new BOPromotionType(daoPromotionType);
				if(_boPromotionTypeCollection != null)
					_boPromotionTypeCollection.Add(boPromotionType);
			}
			catch
			{
				RollbackTransaction("addPromotionType");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllPromotionType
		///This method deletes all BOPromotionType objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllPromotionType()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllPromotionType");
			try
			{
				DAOPromotionType.DeleteAllByPromotionInputId(ConnectionProvider, _promotionInputId.Value);
				CommitTransaction();
				if(_boPromotionTypeCollection != null)
				{
					_boPromotionTypeCollection.Clear();
					_boPromotionTypeCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllPromotionType");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? PromotionInputId
		{
			get
			{
				 return _promotionInputId;
			}
			set
			{
				_promotionInputId = value;
				_isDirty = true;
			}
		}
		
		public virtual string PromotionInputCode
		{
			get
			{
				 return _promotionInputCode;
			}
			set
			{
				_promotionInputCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string PromotionInputNameEn
		{
			get
			{
				 return _promotionInputNameEn;
			}
			set
			{
				_promotionInputNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string PromotionInputNameAr
		{
			get
			{
				 return _promotionInputNameAr;
			}
			set
			{
				_promotionInputNameAr = value;
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
