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
	///This is the definition of the class BOPromotionCriteriaVw.
	///</Summary>
	public partial class BOPromotionCriteriaVw : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _criteriaId;
		protected Int32? _promotionId;
		protected Int32? _groupId;
		protected Int32? _attributeId;
		protected string _valueFrom;
		protected bool? _isActive;
		protected bool? _excluded;
		protected string _attributeCode;
		protected string _attributeNameAr;
		protected string _attributeNameEn;
		protected bool? _isCustom;
		protected Int32? _groupNo;
		protected decimal? _slice;
		protected DateTime? _validTo;
		protected DateTime? _validFrom;
		protected string _promotionCode;
		protected Int32? _promotionTypeId;
		protected Int32? _priority;
		protected Int32? _repeats;
		protected Int32? _promotionGroupId;
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
		public BOPromotionCriteriaVw()
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
		///DAOPromotionCriteriaVw
		///</parameters>
		protected internal BOPromotionCriteriaVw(DAOPromotionCriteriaVw daoPromotionCriteriaVw)
		{
			try
			{
				_criteriaId = daoPromotionCriteriaVw.CriteriaId;
				_promotionId = daoPromotionCriteriaVw.PromotionId;
				_groupId = daoPromotionCriteriaVw.GroupId;
				_attributeId = daoPromotionCriteriaVw.AttributeId;
				_valueFrom = daoPromotionCriteriaVw.ValueFrom;
				_isActive = daoPromotionCriteriaVw.IsActive;
				_excluded = daoPromotionCriteriaVw.Excluded;
				_attributeCode = daoPromotionCriteriaVw.AttributeCode;
				_attributeNameAr = daoPromotionCriteriaVw.AttributeNameAr;
				_attributeNameEn = daoPromotionCriteriaVw.AttributeNameEn;
				_isCustom = daoPromotionCriteriaVw.IsCustom;
				_groupNo = daoPromotionCriteriaVw.GroupNo;
				_slice = daoPromotionCriteriaVw.Slice;
				_validTo = daoPromotionCriteriaVw.ValidTo;
				_validFrom = daoPromotionCriteriaVw.ValidFrom;
				_promotionCode = daoPromotionCriteriaVw.PromotionCode;
				_promotionTypeId = daoPromotionCriteriaVw.PromotionTypeId;
				_priority = daoPromotionCriteriaVw.Priority;
				_repeats = daoPromotionCriteriaVw.Repeats;
				_promotionGroupId = daoPromotionCriteriaVw.PromotionGroupId;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///PromotionCriteriaVwCollection
		///This method returns the collection of BOPromotionCriteriaVw objects
		///</Summary>
		///<returns>
		///List[BOPromotionCriteriaVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOPromotionCriteriaVw> PromotionCriteriaVwCollection()
		{
			try
			{
				IList<BOPromotionCriteriaVw> boPromotionCriteriaVwCollection = new List<BOPromotionCriteriaVw>();
				IList<DAOPromotionCriteriaVw> daoPromotionCriteriaVwCollection = DAOPromotionCriteriaVw.SelectAll();
			
				foreach(DAOPromotionCriteriaVw daoPromotionCriteriaVw in daoPromotionCriteriaVwCollection)
					boPromotionCriteriaVwCollection.Add(new BOPromotionCriteriaVw(daoPromotionCriteriaVw));
			
				return boPromotionCriteriaVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromotionCriteriaVwCollectionCount
		///This method returns the collection count of BOPromotionCriteriaVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 PromotionCriteriaVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOPromotionCriteriaVw.SelectAllCount();
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
		///List<BOPromotionCriteriaVw>
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
				IDictionary<string, IList<object>> retObj = DAOPromotionCriteriaVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromotionCriteriaVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOPromotionCriteriaVw objects, filtered by optional criteria
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
				IList<T> boPromotionCriteriaVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOPromotionCriteriaVw> daoPromotionCriteriaVwCollection = DAOPromotionCriteriaVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOPromotionCriteriaVw resdaoPromotionCriteriaVw in daoPromotionCriteriaVwCollection)
					boPromotionCriteriaVwCollection.Add((T)(object)new BOPromotionCriteriaVw(resdaoPromotionCriteriaVw));
			
				return boPromotionCriteriaVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromotionCriteriaVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOPromotionCriteriaVw objects, filtered by optional criteria
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
				Int32 objCount = DAOPromotionCriteriaVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? CriteriaId
		{
			get
			{
				 return _criteriaId;
			}
			set
			{
				_criteriaId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? PromotionId
		{
			get
			{
				 return _promotionId;
			}
			set
			{
				_promotionId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? GroupId
		{
			get
			{
				 return _groupId;
			}
			set
			{
				_groupId = value;
				_isDirty = true;
			}
		}
		
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
		
		public virtual string ValueFrom
		{
			get
			{
				 return _valueFrom;
			}
			set
			{
				_valueFrom = value;
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
		
		public virtual bool? Excluded
		{
			get
			{
				 return _excluded;
			}
			set
			{
				_excluded = value;
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
		
		public virtual Int32? GroupNo
		{
			get
			{
				 return _groupNo;
			}
			set
			{
				_groupNo = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? Slice
		{
			get
			{
				 return _slice;
			}
			set
			{
				_slice = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? ValidTo
		{
			get
			{
				 return _validTo;
			}
			set
			{
				_validTo = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? ValidFrom
		{
			get
			{
				 return _validFrom;
			}
			set
			{
				_validFrom = value;
				_isDirty = true;
			}
		}
		
		public virtual string PromotionCode
		{
			get
			{
				 return _promotionCode;
			}
			set
			{
				_promotionCode = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? PromotionTypeId
		{
			get
			{
				 return _promotionTypeId;
			}
			set
			{
				_promotionTypeId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Priority
		{
			get
			{
				 return _priority;
			}
			set
			{
				_priority = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Repeats
		{
			get
			{
				 return _repeats;
			}
			set
			{
				_repeats = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? PromotionGroupId
		{
			get
			{
				 return _promotionGroupId;
			}
			set
			{
				_promotionGroupId = value;
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
