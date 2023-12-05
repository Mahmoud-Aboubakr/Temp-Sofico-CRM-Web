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
	///This is the definition of the class BOPromotionCriteriaAttr.
	///</Summary>
	public partial class BOPromotionCriteriaAttr : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _attributeId;
		protected string _attributeCode;
		protected string _attributeNameAr;
		protected string _attributeNameEn;
		protected string _attributeNameDesc;
		protected bool? _isCustom;
		protected bool? _isActive;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected Int32? _displayOrder;
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
		public BOPromotionCriteriaAttr()
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
		///Int32 attributeId
		///</parameters>
		public BOPromotionCriteriaAttr(Int32 attributeId)
		{
			try
			{
				DAOPromotionCriteriaAttr daoPromotionCriteriaAttr = DAOPromotionCriteriaAttr.SelectOne(attributeId);
				_attributeId = daoPromotionCriteriaAttr.AttributeId;
				_attributeCode = daoPromotionCriteriaAttr.AttributeCode;
				_attributeNameAr = daoPromotionCriteriaAttr.AttributeNameAr;
				_attributeNameEn = daoPromotionCriteriaAttr.AttributeNameEn;
				_attributeNameDesc = daoPromotionCriteriaAttr.AttributeNameDesc;
				_isCustom = daoPromotionCriteriaAttr.IsCustom;
				_isActive = daoPromotionCriteriaAttr.IsActive;
				_canEdit = daoPromotionCriteriaAttr.CanEdit;
				_canDelete = daoPromotionCriteriaAttr.CanDelete;
				_displayOrder = daoPromotionCriteriaAttr.DisplayOrder;
				_cBy = daoPromotionCriteriaAttr.CBy;
				_cDate = daoPromotionCriteriaAttr.CDate;
				_eBy = daoPromotionCriteriaAttr.EBy;
				_eDate = daoPromotionCriteriaAttr.EDate;
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
		///DAOPromotionCriteriaAttr
		///</parameters>
		protected internal BOPromotionCriteriaAttr(DAOPromotionCriteriaAttr daoPromotionCriteriaAttr)
		{
			try
			{
				_attributeId = daoPromotionCriteriaAttr.AttributeId;
				_attributeCode = daoPromotionCriteriaAttr.AttributeCode;
				_attributeNameAr = daoPromotionCriteriaAttr.AttributeNameAr;
				_attributeNameEn = daoPromotionCriteriaAttr.AttributeNameEn;
				_attributeNameDesc = daoPromotionCriteriaAttr.AttributeNameDesc;
				_isCustom = daoPromotionCriteriaAttr.IsCustom;
				_isActive = daoPromotionCriteriaAttr.IsActive;
				_canEdit = daoPromotionCriteriaAttr.CanEdit;
				_canDelete = daoPromotionCriteriaAttr.CanDelete;
				_displayOrder = daoPromotionCriteriaAttr.DisplayOrder;
				_cBy = daoPromotionCriteriaAttr.CBy;
				_cDate = daoPromotionCriteriaAttr.CDate;
				_eBy = daoPromotionCriteriaAttr.EBy;
				_eDate = daoPromotionCriteriaAttr.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new PromotionCriteriaAttr record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOPromotionCriteriaAttr daoPromotionCriteriaAttr = new DAOPromotionCriteriaAttr();
			RegisterDataObject(daoPromotionCriteriaAttr);
			BeginTransaction("savenewBOPromotionCriteriaAttr");
			try
			{
				daoPromotionCriteriaAttr.AttributeCode = _attributeCode;
				daoPromotionCriteriaAttr.AttributeNameAr = _attributeNameAr;
				daoPromotionCriteriaAttr.AttributeNameEn = _attributeNameEn;
				daoPromotionCriteriaAttr.AttributeNameDesc = _attributeNameDesc;
				daoPromotionCriteriaAttr.IsCustom = _isCustom;
				daoPromotionCriteriaAttr.IsActive = _isActive;
				daoPromotionCriteriaAttr.CanEdit = _canEdit;
				daoPromotionCriteriaAttr.CanDelete = _canDelete;
				daoPromotionCriteriaAttr.DisplayOrder = _displayOrder;
				daoPromotionCriteriaAttr.CBy = _cBy;
				daoPromotionCriteriaAttr.CDate = _cDate;
				daoPromotionCriteriaAttr.EBy = _eBy;
				daoPromotionCriteriaAttr.EDate = _eDate;
				daoPromotionCriteriaAttr.Insert();
				CommitTransaction();
				
				_attributeId = daoPromotionCriteriaAttr.AttributeId;
				_attributeCode = daoPromotionCriteriaAttr.AttributeCode;
				_attributeNameAr = daoPromotionCriteriaAttr.AttributeNameAr;
				_attributeNameEn = daoPromotionCriteriaAttr.AttributeNameEn;
				_attributeNameDesc = daoPromotionCriteriaAttr.AttributeNameDesc;
				_isCustom = daoPromotionCriteriaAttr.IsCustom;
				_isActive = daoPromotionCriteriaAttr.IsActive;
				_canEdit = daoPromotionCriteriaAttr.CanEdit;
				_canDelete = daoPromotionCriteriaAttr.CanDelete;
				_displayOrder = daoPromotionCriteriaAttr.DisplayOrder;
				_cBy = daoPromotionCriteriaAttr.CBy;
				_cDate = daoPromotionCriteriaAttr.CDate;
				_eBy = daoPromotionCriteriaAttr.EBy;
				_eDate = daoPromotionCriteriaAttr.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOPromotionCriteriaAttr");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one PromotionCriteriaAttr record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOPromotionCriteriaAttr
		///</parameters>
		public virtual void Update()
		{
			DAOPromotionCriteriaAttr daoPromotionCriteriaAttr = new DAOPromotionCriteriaAttr();
			RegisterDataObject(daoPromotionCriteriaAttr);
			BeginTransaction("updateBOPromotionCriteriaAttr");
			try
			{
				daoPromotionCriteriaAttr.AttributeId = _attributeId;
				daoPromotionCriteriaAttr.AttributeCode = _attributeCode;
				daoPromotionCriteriaAttr.AttributeNameAr = _attributeNameAr;
				daoPromotionCriteriaAttr.AttributeNameEn = _attributeNameEn;
				daoPromotionCriteriaAttr.AttributeNameDesc = _attributeNameDesc;
				daoPromotionCriteriaAttr.IsCustom = _isCustom;
				daoPromotionCriteriaAttr.IsActive = _isActive;
				daoPromotionCriteriaAttr.CanEdit = _canEdit;
				daoPromotionCriteriaAttr.CanDelete = _canDelete;
				daoPromotionCriteriaAttr.DisplayOrder = _displayOrder;
				daoPromotionCriteriaAttr.CBy = _cBy;
				daoPromotionCriteriaAttr.CDate = _cDate;
				daoPromotionCriteriaAttr.EBy = _eBy;
				daoPromotionCriteriaAttr.EDate = _eDate;
				daoPromotionCriteriaAttr.Update();
				CommitTransaction();
				
				_attributeId = daoPromotionCriteriaAttr.AttributeId;
				_attributeCode = daoPromotionCriteriaAttr.AttributeCode;
				_attributeNameAr = daoPromotionCriteriaAttr.AttributeNameAr;
				_attributeNameEn = daoPromotionCriteriaAttr.AttributeNameEn;
				_attributeNameDesc = daoPromotionCriteriaAttr.AttributeNameDesc;
				_isCustom = daoPromotionCriteriaAttr.IsCustom;
				_isActive = daoPromotionCriteriaAttr.IsActive;
				_canEdit = daoPromotionCriteriaAttr.CanEdit;
				_canDelete = daoPromotionCriteriaAttr.CanDelete;
				_displayOrder = daoPromotionCriteriaAttr.DisplayOrder;
				_cBy = daoPromotionCriteriaAttr.CBy;
				_cDate = daoPromotionCriteriaAttr.CDate;
				_eBy = daoPromotionCriteriaAttr.EBy;
				_eDate = daoPromotionCriteriaAttr.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOPromotionCriteriaAttr");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one PromotionCriteriaAttr record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOPromotionCriteriaAttr daoPromotionCriteriaAttr = new DAOPromotionCriteriaAttr();
			RegisterDataObject(daoPromotionCriteriaAttr);
			BeginTransaction("deleteBOPromotionCriteriaAttr");
			try
			{
				daoPromotionCriteriaAttr.AttributeId = _attributeId;
				daoPromotionCriteriaAttr.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOPromotionCriteriaAttr");
				throw;
			}
		}
		
		///<Summary>
		///PromotionCriteriaAttrCollection
		///This method returns the collection of BOPromotionCriteriaAttr objects
		///</Summary>
		///<returns>
		///List[BOPromotionCriteriaAttr]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOPromotionCriteriaAttr> PromotionCriteriaAttrCollection()
		{
			try
			{
				IList<BOPromotionCriteriaAttr> boPromotionCriteriaAttrCollection = new List<BOPromotionCriteriaAttr>();
				IList<DAOPromotionCriteriaAttr> daoPromotionCriteriaAttrCollection = DAOPromotionCriteriaAttr.SelectAll();
			
				foreach(DAOPromotionCriteriaAttr daoPromotionCriteriaAttr in daoPromotionCriteriaAttrCollection)
					boPromotionCriteriaAttrCollection.Add(new BOPromotionCriteriaAttr(daoPromotionCriteriaAttr));
			
				return boPromotionCriteriaAttrCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromotionCriteriaAttrCollectionCount
		///This method returns the collection count of BOPromotionCriteriaAttr objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 PromotionCriteriaAttrCollectionCount()
		{
			try
			{
				Int32 objCount = DAOPromotionCriteriaAttr.SelectAllCount();
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
		///List<BOPromotionCriteriaAttr>
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
				IDictionary<string, IList<object>> retObj = DAOPromotionCriteriaAttr.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromotionCriteriaAttrCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOPromotionCriteriaAttr objects, filtered by optional criteria
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
				IList<T> boPromotionCriteriaAttrCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOPromotionCriteriaAttr> daoPromotionCriteriaAttrCollection = DAOPromotionCriteriaAttr.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOPromotionCriteriaAttr resdaoPromotionCriteriaAttr in daoPromotionCriteriaAttrCollection)
					boPromotionCriteriaAttrCollection.Add((T)(object)new BOPromotionCriteriaAttr(resdaoPromotionCriteriaAttr));
			
				return boPromotionCriteriaAttrCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromotionCriteriaAttrCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOPromotionCriteriaAttr objects, filtered by optional criteria
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
				Int32 objCount = DAOPromotionCriteriaAttr.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? AttributeId
		{
			get
			{
				 return _attributeId;
			}
			set
			{
				_attributeId = value;
				_isDirty = true;
			}
		}
		
		public virtual string AttributeCode
		{
			get
			{
				 return _attributeCode;
			}
			set
			{
				_attributeCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string AttributeNameAr
		{
			get
			{
				 return _attributeNameAr;
			}
			set
			{
				_attributeNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string AttributeNameEn
		{
			get
			{
				 return _attributeNameEn;
			}
			set
			{
				_attributeNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string AttributeNameDesc
		{
			get
			{
				 return _attributeNameDesc;
			}
			set
			{
				_attributeNameDesc = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? IsCustom
		{
			get
			{
				 return _isCustom;
			}
			set
			{
				_isCustom = value;
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
