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
	///This is the definition of the class BOOperationRequestVw.
	///</Summary>
	public partial class BOOperationRequestVw : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _operationId;
		protected string _operationCode;
		protected Int32? _agentId;
		protected Int32? _operationTypeId;
		protected Int32? _representativeId;
		protected DateTime? _startDate;
		protected Int32? _targetDays;
		protected string _mapPoints;
		protected bool? _isClosed;
		protected DateTime? _closeDate;
		protected string _representativeCode;
		protected string _representativeNameAr;
		protected string _representativeNameEn;
		protected string _operationTypeNameEn;
		protected string _operationTypeNameAr;
		protected string _phone;
		protected DateTime? _operationDate;
		protected decimal? _accuracy;
		protected decimal? _clientsPerformance;
		protected decimal? _daysPerformance;
		protected Int32? _actualClients;
		protected Int32? _targetClients;
		protected Int32? _actualDays;
		protected Int32? _governerateId;
		protected string _governerateNameAr;
		protected string _governerateNameEn;
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
		public BOOperationRequestVw()
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
		///DAOOperationRequestVw
		///</parameters>
		protected internal BOOperationRequestVw(DAOOperationRequestVw daoOperationRequestVw)
		{
			try
			{
				_operationId = daoOperationRequestVw.OperationId;
				_operationCode = daoOperationRequestVw.OperationCode;
				_agentId = daoOperationRequestVw.AgentId;
				_operationTypeId = daoOperationRequestVw.OperationTypeId;
				_representativeId = daoOperationRequestVw.RepresentativeId;
				_startDate = daoOperationRequestVw.StartDate;
				_targetDays = daoOperationRequestVw.TargetDays;
				_mapPoints = daoOperationRequestVw.MapPoints;
				_isClosed = daoOperationRequestVw.IsClosed;
				_closeDate = daoOperationRequestVw.CloseDate;
				_representativeCode = daoOperationRequestVw.RepresentativeCode;
				_representativeNameAr = daoOperationRequestVw.RepresentativeNameAr;
				_representativeNameEn = daoOperationRequestVw.RepresentativeNameEn;
				_operationTypeNameEn = daoOperationRequestVw.OperationTypeNameEn;
				_operationTypeNameAr = daoOperationRequestVw.OperationTypeNameAr;
				_phone = daoOperationRequestVw.Phone;
				_operationDate = daoOperationRequestVw.OperationDate;
				_accuracy = daoOperationRequestVw.Accuracy;
				_clientsPerformance = daoOperationRequestVw.ClientsPerformance;
				_daysPerformance = daoOperationRequestVw.DaysPerformance;
				_actualClients = daoOperationRequestVw.ActualClients;
				_targetClients = daoOperationRequestVw.TargetClients;
				_actualDays = daoOperationRequestVw.ActualDays;
				_governerateId = daoOperationRequestVw.GovernerateId;
				_governerateNameAr = daoOperationRequestVw.GovernerateNameAr;
				_governerateNameEn = daoOperationRequestVw.GovernerateNameEn;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///OperationRequestVwCollection
		///This method returns the collection of BOOperationRequestVw objects
		///</Summary>
		///<returns>
		///List[BOOperationRequestVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOOperationRequestVw> OperationRequestVwCollection()
		{
			try
			{
				IList<BOOperationRequestVw> boOperationRequestVwCollection = new List<BOOperationRequestVw>();
				IList<DAOOperationRequestVw> daoOperationRequestVwCollection = DAOOperationRequestVw.SelectAll();
			
				foreach(DAOOperationRequestVw daoOperationRequestVw in daoOperationRequestVwCollection)
					boOperationRequestVwCollection.Add(new BOOperationRequestVw(daoOperationRequestVw));
			
				return boOperationRequestVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///OperationRequestVwCollectionCount
		///This method returns the collection count of BOOperationRequestVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 OperationRequestVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOOperationRequestVw.SelectAllCount();
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
		///List<BOOperationRequestVw>
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
				IDictionary<string, IList<object>> retObj = DAOOperationRequestVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///OperationRequestVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOOperationRequestVw objects, filtered by optional criteria
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
				IList<T> boOperationRequestVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOOperationRequestVw> daoOperationRequestVwCollection = DAOOperationRequestVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOOperationRequestVw resdaoOperationRequestVw in daoOperationRequestVwCollection)
					boOperationRequestVwCollection.Add((T)(object)new BOOperationRequestVw(resdaoOperationRequestVw));
			
				return boOperationRequestVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///OperationRequestVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOOperationRequestVw objects, filtered by optional criteria
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
				Int32 objCount = DAOOperationRequestVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? OperationId
		{
			get
			{
				 return _operationId;
			}
			set
			{
				_operationId = value;
				_isDirty = true;
			}
		}
		
		public virtual string OperationCode
		{
			get
			{
				 return _operationCode;
			}
			set
			{
				_operationCode = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? AgentId
		{
			get
			{
				 return _agentId;
			}
			set
			{
				_agentId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? OperationTypeId
		{
			get
			{
				 return _operationTypeId;
			}
			set
			{
				_operationTypeId = value;
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
		
		public virtual DateTime? StartDate
		{
			get
			{
				 return _startDate;
			}
			set
			{
				_startDate = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? TargetDays
		{
			get
			{
				 return _targetDays;
			}
			set
			{
				_targetDays = value;
				_isDirty = true;
			}
		}
		
		public virtual string MapPoints
		{
			get
			{
				 return _mapPoints;
			}
			set
			{
				_mapPoints = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? IsClosed
		{
			get
			{
				 return _isClosed;
			}
			set
			{
				_isClosed = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? CloseDate
		{
			get
			{
				 return _closeDate;
			}
			set
			{
				_closeDate = value;
				_isDirty = true;
			}
		}
		
		public virtual string RepresentativeCode
		{
			get
			{
				 return _representativeCode;
			}
			set
			{
				_representativeCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string RepresentativeNameAr
		{
			get
			{
				 return _representativeNameAr;
			}
			set
			{
				_representativeNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string RepresentativeNameEn
		{
			get
			{
				 return _representativeNameEn;
			}
			set
			{
				_representativeNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string OperationTypeNameEn
		{
			get
			{
				 return _operationTypeNameEn;
			}
			set
			{
				_operationTypeNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string OperationTypeNameAr
		{
			get
			{
				 return _operationTypeNameAr;
			}
			set
			{
				_operationTypeNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string Phone
		{
			get
			{
				 return _phone;
			}
			set
			{
				_phone = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? OperationDate
		{
			get
			{
				 return _operationDate;
			}
			set
			{
				_operationDate = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? Accuracy
		{
			get
			{
				 return _accuracy;
			}
			set
			{
				_accuracy = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? ClientsPerformance
		{
			get
			{
				 return _clientsPerformance;
			}
			set
			{
				_clientsPerformance = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? DaysPerformance
		{
			get
			{
				 return _daysPerformance;
			}
			set
			{
				_daysPerformance = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ActualClients
		{
			get
			{
				 return _actualClients;
			}
			set
			{
				_actualClients = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? TargetClients
		{
			get
			{
				 return _targetClients;
			}
			set
			{
				_targetClients = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ActualDays
		{
			get
			{
				 return _actualDays;
			}
			set
			{
				_actualDays = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? GovernerateId
		{
			get
			{
				 return _governerateId;
			}
			set
			{
				_governerateId = value;
				_isDirty = true;
			}
		}
		
		public virtual string GovernerateNameAr
		{
			get
			{
				 return _governerateNameAr;
			}
			set
			{
				_governerateNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string GovernerateNameEn
		{
			get
			{
				 return _governerateNameEn;
			}
			set
			{
				_governerateNameEn = value;
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
