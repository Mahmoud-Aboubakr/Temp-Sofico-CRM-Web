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
	///This is the definition of the class BOClientPlan.
	///</Summary>
	public partial class BOClientPlan : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int64? _planId;
		protected Int32? _clientId;
		protected DateTime? _targetDate;
		protected decimal? _targetValue;
		protected Int32? _targetVisit;
		protected Int32? _targetCall;
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
		public BOClientPlan()
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
		///Int64 planId
		///</parameters>
		public BOClientPlan(Int64 planId)
		{
			try
			{
				DAOClientPlan daoClientPlan = DAOClientPlan.SelectOne(planId);
				_planId = daoClientPlan.PlanId;
				_clientId = daoClientPlan.ClientId;
				_targetDate = daoClientPlan.TargetDate;
				_targetValue = daoClientPlan.TargetValue;
				_targetVisit = daoClientPlan.TargetVisit;
				_targetCall = daoClientPlan.TargetCall;
				_cBy = daoClientPlan.CBy;
				_cDate = daoClientPlan.CDate;
				_eBy = daoClientPlan.EBy;
				_eDate = daoClientPlan.EDate;
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
		///DAOClientPlan
		///</parameters>
		protected internal BOClientPlan(DAOClientPlan daoClientPlan)
		{
			try
			{
				_planId = daoClientPlan.PlanId;
				_clientId = daoClientPlan.ClientId;
				_targetDate = daoClientPlan.TargetDate;
				_targetValue = daoClientPlan.TargetValue;
				_targetVisit = daoClientPlan.TargetVisit;
				_targetCall = daoClientPlan.TargetCall;
				_cBy = daoClientPlan.CBy;
				_cDate = daoClientPlan.CDate;
				_eBy = daoClientPlan.EBy;
				_eDate = daoClientPlan.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new ClientPlan record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOClientPlan daoClientPlan = new DAOClientPlan();
			RegisterDataObject(daoClientPlan);
			BeginTransaction("savenewBOClientPlan");
			try
			{
				daoClientPlan.ClientId = _clientId;
				daoClientPlan.TargetDate = _targetDate;
				daoClientPlan.TargetValue = _targetValue;
				daoClientPlan.TargetVisit = _targetVisit;
				daoClientPlan.TargetCall = _targetCall;
				daoClientPlan.CBy = _cBy;
				daoClientPlan.CDate = _cDate;
				daoClientPlan.EBy = _eBy;
				daoClientPlan.EDate = _eDate;
				daoClientPlan.Insert();
				CommitTransaction();
				
				_planId = daoClientPlan.PlanId;
				_clientId = daoClientPlan.ClientId;
				_targetDate = daoClientPlan.TargetDate;
				_targetValue = daoClientPlan.TargetValue;
				_targetVisit = daoClientPlan.TargetVisit;
				_targetCall = daoClientPlan.TargetCall;
				_cBy = daoClientPlan.CBy;
				_cDate = daoClientPlan.CDate;
				_eBy = daoClientPlan.EBy;
				_eDate = daoClientPlan.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOClientPlan");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one ClientPlan record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOClientPlan
		///</parameters>
		public virtual void Update()
		{
			DAOClientPlan daoClientPlan = new DAOClientPlan();
			RegisterDataObject(daoClientPlan);
			BeginTransaction("updateBOClientPlan");
			try
			{
				daoClientPlan.PlanId = _planId;
				daoClientPlan.ClientId = _clientId;
				daoClientPlan.TargetDate = _targetDate;
				daoClientPlan.TargetValue = _targetValue;
				daoClientPlan.TargetVisit = _targetVisit;
				daoClientPlan.TargetCall = _targetCall;
				daoClientPlan.CBy = _cBy;
				daoClientPlan.CDate = _cDate;
				daoClientPlan.EBy = _eBy;
				daoClientPlan.EDate = _eDate;
				daoClientPlan.Update();
				CommitTransaction();
				
				_planId = daoClientPlan.PlanId;
				_clientId = daoClientPlan.ClientId;
				_targetDate = daoClientPlan.TargetDate;
				_targetValue = daoClientPlan.TargetValue;
				_targetVisit = daoClientPlan.TargetVisit;
				_targetCall = daoClientPlan.TargetCall;
				_cBy = daoClientPlan.CBy;
				_cDate = daoClientPlan.CDate;
				_eBy = daoClientPlan.EBy;
				_eDate = daoClientPlan.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOClientPlan");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one ClientPlan record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOClientPlan daoClientPlan = new DAOClientPlan();
			RegisterDataObject(daoClientPlan);
			BeginTransaction("deleteBOClientPlan");
			try
			{
				daoClientPlan.PlanId = _planId;
				daoClientPlan.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOClientPlan");
				throw;
			}
		}
		
		///<Summary>
		///ClientPlanCollection
		///This method returns the collection of BOClientPlan objects
		///</Summary>
		///<returns>
		///List[BOClientPlan]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOClientPlan> ClientPlanCollection()
		{
			try
			{
				IList<BOClientPlan> boClientPlanCollection = new List<BOClientPlan>();
				IList<DAOClientPlan> daoClientPlanCollection = DAOClientPlan.SelectAll();
			
				foreach(DAOClientPlan daoClientPlan in daoClientPlanCollection)
					boClientPlanCollection.Add(new BOClientPlan(daoClientPlan));
			
				return boClientPlanCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientPlanCollectionCount
		///This method returns the collection count of BOClientPlan objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ClientPlanCollectionCount()
		{
			try
			{
				Int32 objCount = DAOClientPlan.SelectAllCount();
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
		///List<BOClientPlan>
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
				IDictionary<string, IList<object>> retObj = DAOClientPlan.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientPlanCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOClientPlan objects, filtered by optional criteria
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
				IList<T> boClientPlanCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOClientPlan> daoClientPlanCollection = DAOClientPlan.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOClientPlan resdaoClientPlan in daoClientPlanCollection)
					boClientPlanCollection.Add((T)(object)new BOClientPlan(resdaoClientPlan));
			
				return boClientPlanCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientPlanCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOClientPlan objects, filtered by optional criteria
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
				Int32 objCount = DAOClientPlan.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int64? PlanId
		{
			get
			{
				 return _planId;
			}
			set
			{
				_planId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ClientId
		{
			get
			{
				 return _clientId;
			}
			set
			{
				_clientId = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? TargetDate
		{
			get
			{
				 return _targetDate;
			}
			set
			{
				_targetDate = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? TargetValue
		{
			get
			{
				 return _targetValue;
			}
			set
			{
				_targetValue = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? TargetVisit
		{
			get
			{
				 return _targetVisit;
			}
			set
			{
				_targetVisit = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? TargetCall
		{
			get
			{
				 return _targetCall;
			}
			set
			{
				_targetCall = value;
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
