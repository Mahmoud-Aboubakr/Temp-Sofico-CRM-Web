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
	///This is the definition of the class BORepresentativeJourney.
	///</Summary>
	public partial class BORepresentativeJourney : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int64? _journeyId;
		protected Int32? _representativeId;
		protected Int32? _routeId;
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
		public BORepresentativeJourney()
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
		///Int64 journeyId
		///</parameters>
		public BORepresentativeJourney(Int64 journeyId)
		{
			try
			{
				DAORepresentativeJourney daoRepresentativeJourney = DAORepresentativeJourney.SelectOne(journeyId);
				_journeyId = daoRepresentativeJourney.JourneyId;
				_representativeId = daoRepresentativeJourney.RepresentativeId;
				_routeId = daoRepresentativeJourney.RouteId;
				_cBy = daoRepresentativeJourney.CBy;
				_cDate = daoRepresentativeJourney.CDate;
				_eBy = daoRepresentativeJourney.EBy;
				_eDate = daoRepresentativeJourney.EDate;
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
		///DAORepresentativeJourney
		///</parameters>
		protected internal BORepresentativeJourney(DAORepresentativeJourney daoRepresentativeJourney)
		{
			try
			{
				_journeyId = daoRepresentativeJourney.JourneyId;
				_representativeId = daoRepresentativeJourney.RepresentativeId;
				_routeId = daoRepresentativeJourney.RouteId;
				_cBy = daoRepresentativeJourney.CBy;
				_cDate = daoRepresentativeJourney.CDate;
				_eBy = daoRepresentativeJourney.EBy;
				_eDate = daoRepresentativeJourney.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new RepresentativeJourney record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAORepresentativeJourney daoRepresentativeJourney = new DAORepresentativeJourney();
			RegisterDataObject(daoRepresentativeJourney);
			BeginTransaction("savenewBORepresentativeJourney");
			try
			{
				daoRepresentativeJourney.RepresentativeId = _representativeId;
				daoRepresentativeJourney.RouteId = _routeId;
				daoRepresentativeJourney.CBy = _cBy;
				daoRepresentativeJourney.CDate = _cDate;
				daoRepresentativeJourney.EBy = _eBy;
				daoRepresentativeJourney.EDate = _eDate;
				daoRepresentativeJourney.Insert();
				CommitTransaction();
				
				_journeyId = daoRepresentativeJourney.JourneyId;
				_representativeId = daoRepresentativeJourney.RepresentativeId;
				_routeId = daoRepresentativeJourney.RouteId;
				_cBy = daoRepresentativeJourney.CBy;
				_cDate = daoRepresentativeJourney.CDate;
				_eBy = daoRepresentativeJourney.EBy;
				_eDate = daoRepresentativeJourney.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBORepresentativeJourney");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one RepresentativeJourney record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BORepresentativeJourney
		///</parameters>
		public virtual void Update()
		{
			DAORepresentativeJourney daoRepresentativeJourney = new DAORepresentativeJourney();
			RegisterDataObject(daoRepresentativeJourney);
			BeginTransaction("updateBORepresentativeJourney");
			try
			{
				daoRepresentativeJourney.JourneyId = _journeyId;
				daoRepresentativeJourney.RepresentativeId = _representativeId;
				daoRepresentativeJourney.RouteId = _routeId;
				daoRepresentativeJourney.CBy = _cBy;
				daoRepresentativeJourney.CDate = _cDate;
				daoRepresentativeJourney.EBy = _eBy;
				daoRepresentativeJourney.EDate = _eDate;
				daoRepresentativeJourney.Update();
				CommitTransaction();
				
				_journeyId = daoRepresentativeJourney.JourneyId;
				_representativeId = daoRepresentativeJourney.RepresentativeId;
				_routeId = daoRepresentativeJourney.RouteId;
				_cBy = daoRepresentativeJourney.CBy;
				_cDate = daoRepresentativeJourney.CDate;
				_eBy = daoRepresentativeJourney.EBy;
				_eDate = daoRepresentativeJourney.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBORepresentativeJourney");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one RepresentativeJourney record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAORepresentativeJourney daoRepresentativeJourney = new DAORepresentativeJourney();
			RegisterDataObject(daoRepresentativeJourney);
			BeginTransaction("deleteBORepresentativeJourney");
			try
			{
				daoRepresentativeJourney.JourneyId = _journeyId;
				daoRepresentativeJourney.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBORepresentativeJourney");
				throw;
			}
		}
		
		///<Summary>
		///RepresentativeJourneyCollection
		///This method returns the collection of BORepresentativeJourney objects
		///</Summary>
		///<returns>
		///List[BORepresentativeJourney]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BORepresentativeJourney> RepresentativeJourneyCollection()
		{
			try
			{
				IList<BORepresentativeJourney> boRepresentativeJourneyCollection = new List<BORepresentativeJourney>();
				IList<DAORepresentativeJourney> daoRepresentativeJourneyCollection = DAORepresentativeJourney.SelectAll();
			
				foreach(DAORepresentativeJourney daoRepresentativeJourney in daoRepresentativeJourneyCollection)
					boRepresentativeJourneyCollection.Add(new BORepresentativeJourney(daoRepresentativeJourney));
			
				return boRepresentativeJourneyCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RepresentativeJourneyCollectionCount
		///This method returns the collection count of BORepresentativeJourney objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 RepresentativeJourneyCollectionCount()
		{
			try
			{
				Int32 objCount = DAORepresentativeJourney.SelectAllCount();
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
		///List<BORepresentativeJourney>
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
				IDictionary<string, IList<object>> retObj = DAORepresentativeJourney.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RepresentativeJourneyCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BORepresentativeJourney objects, filtered by optional criteria
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
				IList<T> boRepresentativeJourneyCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAORepresentativeJourney> daoRepresentativeJourneyCollection = DAORepresentativeJourney.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAORepresentativeJourney resdaoRepresentativeJourney in daoRepresentativeJourneyCollection)
					boRepresentativeJourneyCollection.Add((T)(object)new BORepresentativeJourney(resdaoRepresentativeJourney));
			
				return boRepresentativeJourneyCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RepresentativeJourneyCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BORepresentativeJourney objects, filtered by optional criteria
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
				Int32 objCount = DAORepresentativeJourney.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int64? JourneyId
		{
			get
			{
				 return _journeyId;
			}
			set
			{
				_journeyId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? RepresentativeId
		{
			get
			{
				 return _representativeId;
			}
			set
			{
				_representativeId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? RouteId
		{
			get
			{
				 return _routeId;
			}
			set
			{
				_routeId = value;
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
