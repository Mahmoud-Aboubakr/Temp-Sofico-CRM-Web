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
	///This is the definition of the class BOClientPreferredTimeVw.
	///</Summary>
	public partial class BOClientPreferredTimeVw : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _preferredId;
		protected Int32? _clientId;
		protected Int32? _preferredOperationId;
		protected Int32? _weekDayId;
		protected TimeSpan? _fromTime;
		protected TimeSpan? _toTime;
		protected string _weekDayNameEn;
		protected string _weekDayNameAr;
		protected string _preferredOperationNameEn;
		protected string _preferredOperationNameAr;
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
		public BOClientPreferredTimeVw()
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
		///DAOClientPreferredTimeVw
		///</parameters>
		protected internal BOClientPreferredTimeVw(DAOClientPreferredTimeVw daoClientPreferredTimeVw)
		{
			try
			{
				_preferredId = daoClientPreferredTimeVw.PreferredId;
				_clientId = daoClientPreferredTimeVw.ClientId;
				_preferredOperationId = daoClientPreferredTimeVw.PreferredOperationId;
				_weekDayId = daoClientPreferredTimeVw.WeekDayId;
				_fromTime = daoClientPreferredTimeVw.FromTime;
				_toTime = daoClientPreferredTimeVw.ToTime;
				_weekDayNameEn = daoClientPreferredTimeVw.WeekDayNameEn;
				_weekDayNameAr = daoClientPreferredTimeVw.WeekDayNameAr;
				_preferredOperationNameEn = daoClientPreferredTimeVw.PreferredOperationNameEn;
				_preferredOperationNameAr = daoClientPreferredTimeVw.PreferredOperationNameAr;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///ClientPreferredTimeVwCollection
		///This method returns the collection of BOClientPreferredTimeVw objects
		///</Summary>
		///<returns>
		///List[BOClientPreferredTimeVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOClientPreferredTimeVw> ClientPreferredTimeVwCollection()
		{
			try
			{
				IList<BOClientPreferredTimeVw> boClientPreferredTimeVwCollection = new List<BOClientPreferredTimeVw>();
				IList<DAOClientPreferredTimeVw> daoClientPreferredTimeVwCollection = DAOClientPreferredTimeVw.SelectAll();
			
				foreach(DAOClientPreferredTimeVw daoClientPreferredTimeVw in daoClientPreferredTimeVwCollection)
					boClientPreferredTimeVwCollection.Add(new BOClientPreferredTimeVw(daoClientPreferredTimeVw));
			
				return boClientPreferredTimeVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientPreferredTimeVwCollectionCount
		///This method returns the collection count of BOClientPreferredTimeVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ClientPreferredTimeVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOClientPreferredTimeVw.SelectAllCount();
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
		///List<BOClientPreferredTimeVw>
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
				IDictionary<string, IList<object>> retObj = DAOClientPreferredTimeVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientPreferredTimeVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOClientPreferredTimeVw objects, filtered by optional criteria
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
				IList<T> boClientPreferredTimeVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOClientPreferredTimeVw> daoClientPreferredTimeVwCollection = DAOClientPreferredTimeVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOClientPreferredTimeVw resdaoClientPreferredTimeVw in daoClientPreferredTimeVwCollection)
					boClientPreferredTimeVwCollection.Add((T)(object)new BOClientPreferredTimeVw(resdaoClientPreferredTimeVw));
			
				return boClientPreferredTimeVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientPreferredTimeVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOClientPreferredTimeVw objects, filtered by optional criteria
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
				Int32 objCount = DAOClientPreferredTimeVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? PreferredId
		{
			get
			{
				 return _preferredId;
			}
			set
			{
				_preferredId = value;
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
		
		public virtual Int32? WeekDayId
		{
			get
			{
				 return _weekDayId;
			}
			set
			{
				_weekDayId = value;
				_isDirty = true;
			}
		}
		
		public virtual TimeSpan? FromTime
		{
			get
			{
				 return _fromTime;
			}
			set
			{
				_fromTime = value;
				_isDirty = true;
			}
		}
		
		public virtual TimeSpan? ToTime
		{
			get
			{
				 return _toTime;
			}
			set
			{
				_toTime = value;
				_isDirty = true;
			}
		}
		
		public virtual string WeekDayNameEn
		{
			get
			{
				 return _weekDayNameEn;
			}
			set
			{
				_weekDayNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string WeekDayNameAr
		{
			get
			{
				 return _weekDayNameAr;
			}
			set
			{
				_weekDayNameAr = value;
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
