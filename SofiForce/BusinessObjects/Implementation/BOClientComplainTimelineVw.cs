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
	///This is the definition of the class BOClientComplainTimelineVw.
	///</Summary>
	public partial class BOClientComplainTimelineVw : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int64? _timelineId;
		protected Int64? _complainId;
		protected Int32? _complainStatusId;
		protected Int32? _userId;
		protected DateTime? _timelineDate;
		protected string _notes;
		protected string _complainStatusNameEn;
		protected string _complainStatusNameAr;
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
		public BOClientComplainTimelineVw()
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
		///DAOClientComplainTimelineVw
		///</parameters>
		protected internal BOClientComplainTimelineVw(DAOClientComplainTimelineVw daoClientComplainTimelineVw)
		{
			try
			{
				_timelineId = daoClientComplainTimelineVw.TimelineId;
				_complainId = daoClientComplainTimelineVw.ComplainId;
				_complainStatusId = daoClientComplainTimelineVw.ComplainStatusId;
				_userId = daoClientComplainTimelineVw.UserId;
				_timelineDate = daoClientComplainTimelineVw.TimelineDate;
				_notes = daoClientComplainTimelineVw.Notes;
				_complainStatusNameEn = daoClientComplainTimelineVw.ComplainStatusNameEn;
				_complainStatusNameAr = daoClientComplainTimelineVw.ComplainStatusNameAr;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///ClientComplainTimelineVwCollection
		///This method returns the collection of BOClientComplainTimelineVw objects
		///</Summary>
		///<returns>
		///List[BOClientComplainTimelineVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOClientComplainTimelineVw> ClientComplainTimelineVwCollection()
		{
			try
			{
				IList<BOClientComplainTimelineVw> boClientComplainTimelineVwCollection = new List<BOClientComplainTimelineVw>();
				IList<DAOClientComplainTimelineVw> daoClientComplainTimelineVwCollection = DAOClientComplainTimelineVw.SelectAll();
			
				foreach(DAOClientComplainTimelineVw daoClientComplainTimelineVw in daoClientComplainTimelineVwCollection)
					boClientComplainTimelineVwCollection.Add(new BOClientComplainTimelineVw(daoClientComplainTimelineVw));
			
				return boClientComplainTimelineVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientComplainTimelineVwCollectionCount
		///This method returns the collection count of BOClientComplainTimelineVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ClientComplainTimelineVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOClientComplainTimelineVw.SelectAllCount();
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
		///List<BOClientComplainTimelineVw>
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
				IDictionary<string, IList<object>> retObj = DAOClientComplainTimelineVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientComplainTimelineVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOClientComplainTimelineVw objects, filtered by optional criteria
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
				IList<T> boClientComplainTimelineVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOClientComplainTimelineVw> daoClientComplainTimelineVwCollection = DAOClientComplainTimelineVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOClientComplainTimelineVw resdaoClientComplainTimelineVw in daoClientComplainTimelineVwCollection)
					boClientComplainTimelineVwCollection.Add((T)(object)new BOClientComplainTimelineVw(resdaoClientComplainTimelineVw));
			
				return boClientComplainTimelineVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientComplainTimelineVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOClientComplainTimelineVw objects, filtered by optional criteria
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
				Int32 objCount = DAOClientComplainTimelineVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int64? TimelineId
		{
			get
			{
				 return _timelineId;
			}
			set
			{
				_timelineId = value;
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
		
		public virtual Int32? ComplainStatusId
		{
			get
			{
				 return _complainStatusId;
			}
			set
			{
				_complainStatusId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? UserId
		{
			get
			{
				 return _userId;
			}
			set
			{
				_userId = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? TimelineDate
		{
			get
			{
				 return _timelineDate;
			}
			set
			{
				_timelineDate = value;
				_isDirty = true;
			}
		}
		
		public virtual string Notes
		{
			get
			{
				 return _notes;
			}
			set
			{
				_notes = value;
				_isDirty = true;
			}
		}
		
		public virtual string ComplainStatusNameEn
		{
			get
			{
				 return _complainStatusNameEn;
			}
			set
			{
				_complainStatusNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string ComplainStatusNameAr
		{
			get
			{
				 return _complainStatusNameAr;
			}
			set
			{
				_complainStatusNameAr = value;
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