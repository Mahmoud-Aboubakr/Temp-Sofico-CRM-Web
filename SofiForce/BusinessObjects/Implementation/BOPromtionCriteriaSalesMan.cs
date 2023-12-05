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
	///This is the definition of the class BOPromtionCriteriaSalesMan.
	///</Summary>
	public partial class BOPromtionCriteriaSalesMan : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _salesManCriteriaId;
		protected Int32? _promotionId;
		protected Int32? _salesManAttributeId;
		protected string _valueFrom;
		protected bool? _excluded;
		protected bool? _isActive;
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
		public BOPromtionCriteriaSalesMan()
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
		///Int32 salesManCriteriaId
		///</parameters>
		public BOPromtionCriteriaSalesMan(Int32 salesManCriteriaId)
		{
			try
			{
				DAOPromtionCriteriaSalesMan daoPromtionCriteriaSalesMan = DAOPromtionCriteriaSalesMan.SelectOne(salesManCriteriaId);
				_salesManCriteriaId = daoPromtionCriteriaSalesMan.SalesManCriteriaId;
				_promotionId = daoPromtionCriteriaSalesMan.PromotionId;
				_salesManAttributeId = daoPromtionCriteriaSalesMan.SalesManAttributeId;
				_valueFrom = daoPromtionCriteriaSalesMan.ValueFrom;
				_excluded = daoPromtionCriteriaSalesMan.Excluded;
				_isActive = daoPromtionCriteriaSalesMan.IsActive;
				_cBy = daoPromtionCriteriaSalesMan.CBy;
				_cDate = daoPromtionCriteriaSalesMan.CDate;
				_eBy = daoPromtionCriteriaSalesMan.EBy;
				_eDate = daoPromtionCriteriaSalesMan.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///Constructor
		///Constructor using unique field(s)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///ValueFrom
		///</parameters>
		public BOPromtionCriteriaSalesMan(Int32 promotionId, Int32 salesManAttributeId, string valueFrom)
		{
			try
			{
				DAOPromtionCriteriaSalesMan daoPromtionCriteriaSalesMan = DAOPromtionCriteriaSalesMan.SelectOneByUniqueFields(promotionId, salesManAttributeId, valueFrom);
				_salesManCriteriaId = daoPromtionCriteriaSalesMan.SalesManCriteriaId;
				_promotionId = daoPromtionCriteriaSalesMan.PromotionId;
				_salesManAttributeId = daoPromtionCriteriaSalesMan.SalesManAttributeId;
				_valueFrom = daoPromtionCriteriaSalesMan.ValueFrom;
				_excluded = daoPromtionCriteriaSalesMan.Excluded;
				_isActive = daoPromtionCriteriaSalesMan.IsActive;
				_cBy = daoPromtionCriteriaSalesMan.CBy;
				_cDate = daoPromtionCriteriaSalesMan.CDate;
				_eBy = daoPromtionCriteriaSalesMan.EBy;
				_eDate = daoPromtionCriteriaSalesMan.EDate;
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
		///DAOPromtionCriteriaSalesMan
		///</parameters>
		protected internal BOPromtionCriteriaSalesMan(DAOPromtionCriteriaSalesMan daoPromtionCriteriaSalesMan)
		{
			try
			{
				_salesManCriteriaId = daoPromtionCriteriaSalesMan.SalesManCriteriaId;
				_promotionId = daoPromtionCriteriaSalesMan.PromotionId;
				_salesManAttributeId = daoPromtionCriteriaSalesMan.SalesManAttributeId;
				_valueFrom = daoPromtionCriteriaSalesMan.ValueFrom;
				_excluded = daoPromtionCriteriaSalesMan.Excluded;
				_isActive = daoPromtionCriteriaSalesMan.IsActive;
				_cBy = daoPromtionCriteriaSalesMan.CBy;
				_cDate = daoPromtionCriteriaSalesMan.CDate;
				_eBy = daoPromtionCriteriaSalesMan.EBy;
				_eDate = daoPromtionCriteriaSalesMan.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new PromtionCriteriaSalesMan record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOPromtionCriteriaSalesMan daoPromtionCriteriaSalesMan = new DAOPromtionCriteriaSalesMan();
			RegisterDataObject(daoPromtionCriteriaSalesMan);
			BeginTransaction("savenewBOPromtionCriteriaSal8042");
			try
			{
				daoPromtionCriteriaSalesMan.PromotionId = _promotionId;
				daoPromtionCriteriaSalesMan.SalesManAttributeId = _salesManAttributeId;
				daoPromtionCriteriaSalesMan.ValueFrom = _valueFrom;
				daoPromtionCriteriaSalesMan.Excluded = _excluded;
				daoPromtionCriteriaSalesMan.IsActive = _isActive;
				daoPromtionCriteriaSalesMan.CBy = _cBy;
				daoPromtionCriteriaSalesMan.CDate = _cDate;
				daoPromtionCriteriaSalesMan.EBy = _eBy;
				daoPromtionCriteriaSalesMan.EDate = _eDate;
				daoPromtionCriteriaSalesMan.Insert();
				CommitTransaction();
				
				_salesManCriteriaId = daoPromtionCriteriaSalesMan.SalesManCriteriaId;
				_promotionId = daoPromtionCriteriaSalesMan.PromotionId;
				_salesManAttributeId = daoPromtionCriteriaSalesMan.SalesManAttributeId;
				_valueFrom = daoPromtionCriteriaSalesMan.ValueFrom;
				_excluded = daoPromtionCriteriaSalesMan.Excluded;
				_isActive = daoPromtionCriteriaSalesMan.IsActive;
				_cBy = daoPromtionCriteriaSalesMan.CBy;
				_cDate = daoPromtionCriteriaSalesMan.CDate;
				_eBy = daoPromtionCriteriaSalesMan.EBy;
				_eDate = daoPromtionCriteriaSalesMan.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOPromtionCriteriaSal8042");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one PromtionCriteriaSalesMan record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOPromtionCriteriaSalesMan
		///</parameters>
		public virtual void Update()
		{
			DAOPromtionCriteriaSalesMan daoPromtionCriteriaSalesMan = new DAOPromtionCriteriaSalesMan();
			RegisterDataObject(daoPromtionCriteriaSalesMan);
			BeginTransaction("updateBOPromtionCriteriaSalesMan");
			try
			{
				daoPromtionCriteriaSalesMan.SalesManCriteriaId = _salesManCriteriaId;
				daoPromtionCriteriaSalesMan.PromotionId = _promotionId;
				daoPromtionCriteriaSalesMan.SalesManAttributeId = _salesManAttributeId;
				daoPromtionCriteriaSalesMan.ValueFrom = _valueFrom;
				daoPromtionCriteriaSalesMan.Excluded = _excluded;
				daoPromtionCriteriaSalesMan.IsActive = _isActive;
				daoPromtionCriteriaSalesMan.CBy = _cBy;
				daoPromtionCriteriaSalesMan.CDate = _cDate;
				daoPromtionCriteriaSalesMan.EBy = _eBy;
				daoPromtionCriteriaSalesMan.EDate = _eDate;
				daoPromtionCriteriaSalesMan.Update();
				CommitTransaction();
				
				_salesManCriteriaId = daoPromtionCriteriaSalesMan.SalesManCriteriaId;
				_promotionId = daoPromtionCriteriaSalesMan.PromotionId;
				_salesManAttributeId = daoPromtionCriteriaSalesMan.SalesManAttributeId;
				_valueFrom = daoPromtionCriteriaSalesMan.ValueFrom;
				_excluded = daoPromtionCriteriaSalesMan.Excluded;
				_isActive = daoPromtionCriteriaSalesMan.IsActive;
				_cBy = daoPromtionCriteriaSalesMan.CBy;
				_cDate = daoPromtionCriteriaSalesMan.CDate;
				_eBy = daoPromtionCriteriaSalesMan.EBy;
				_eDate = daoPromtionCriteriaSalesMan.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOPromtionCriteriaSalesMan");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one PromtionCriteriaSalesMan record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOPromtionCriteriaSalesMan daoPromtionCriteriaSalesMan = new DAOPromtionCriteriaSalesMan();
			RegisterDataObject(daoPromtionCriteriaSalesMan);
			BeginTransaction("deleteBOPromtionCriteriaSalesMan");
			try
			{
				daoPromtionCriteriaSalesMan.SalesManCriteriaId = _salesManCriteriaId;
				daoPromtionCriteriaSalesMan.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOPromtionCriteriaSalesMan");
				throw;
			}
		}
		
		///<Summary>
		///PromtionCriteriaSalesManCollection
		///This method returns the collection of BOPromtionCriteriaSalesMan objects
		///</Summary>
		///<returns>
		///List[BOPromtionCriteriaSalesMan]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOPromtionCriteriaSalesMan> PromtionCriteriaSalesManCollection()
		{
			try
			{
				IList<BOPromtionCriteriaSalesMan> boPromtionCriteriaSalesManCollection = new List<BOPromtionCriteriaSalesMan>();
				IList<DAOPromtionCriteriaSalesMan> daoPromtionCriteriaSalesManCollection = DAOPromtionCriteriaSalesMan.SelectAll();
			
				foreach(DAOPromtionCriteriaSalesMan daoPromtionCriteriaSalesMan in daoPromtionCriteriaSalesManCollection)
					boPromtionCriteriaSalesManCollection.Add(new BOPromtionCriteriaSalesMan(daoPromtionCriteriaSalesMan));
			
				return boPromtionCriteriaSalesManCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromtionCriteriaSalesManCollectionCount
		///This method returns the collection count of BOPromtionCriteriaSalesMan objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 PromtionCriteriaSalesManCollectionCount()
		{
			try
			{
				Int32 objCount = DAOPromtionCriteriaSalesMan.SelectAllCount();
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
		///List<BOPromtionCriteriaSalesMan>
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
				IDictionary<string, IList<object>> retObj = DAOPromtionCriteriaSalesMan.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromtionCriteriaSalesManCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOPromtionCriteriaSalesMan objects, filtered by optional criteria
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
				IList<T> boPromtionCriteriaSalesManCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOPromtionCriteriaSalesMan> daoPromtionCriteriaSalesManCollection = DAOPromtionCriteriaSalesMan.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOPromtionCriteriaSalesMan resdaoPromtionCriteriaSalesMan in daoPromtionCriteriaSalesManCollection)
					boPromtionCriteriaSalesManCollection.Add((T)(object)new BOPromtionCriteriaSalesMan(resdaoPromtionCriteriaSalesMan));
			
				return boPromtionCriteriaSalesManCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromtionCriteriaSalesManCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOPromtionCriteriaSalesMan objects, filtered by optional criteria
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
				Int32 objCount = DAOPromtionCriteriaSalesMan.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? SalesManCriteriaId
		{
			get
			{
				 return _salesManCriteriaId;
			}
			set
			{
				_salesManCriteriaId = value;
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
		
		public virtual Int32? SalesManAttributeId
		{
			get
			{
				 return _salesManAttributeId;
			}
			set
			{
				_salesManAttributeId = value;
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
