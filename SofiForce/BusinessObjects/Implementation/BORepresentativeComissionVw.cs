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
	///This is the definition of the class BORepresentativeComissionVw.
	///</Summary>
	public partial class BORepresentativeComissionVw : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _comissionId;
		protected Int32? _representativeId;
		protected DateTime? _comissionDate;
		protected decimal? _comissionValue;
		protected bool? _isApproved;
		protected Int32? _comissionTypeId;
		protected string _comissionTypeNameEn;
		protected string _comissionTypeNameAr;
		protected string _kindNameAr;
		protected string _kindNameEn;
		protected Int32? _supervisorId;
		protected Int32? _kindId;
		protected Int32? _userId;
		protected Int32? _branchId;
		protected Int32? _businessUnitId;
		protected string _representativeCode;
		protected string _companyCode;
		protected string _representativeNameAr;
		protected string _representativeNameEn;
		protected string _branchCode;
		protected string _branchNameAr;
		protected string _branchNameEn;
		protected string _kindCode;
		protected string _supervisorCode;
		protected string _supervisorNameEn;
		protected string _supervisorNameAr;
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
		public BORepresentativeComissionVw()
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
		///DAORepresentativeComissionVw
		///</parameters>
		protected internal BORepresentativeComissionVw(DAORepresentativeComissionVw daoRepresentativeComissionVw)
		{
			try
			{
				_comissionId = daoRepresentativeComissionVw.ComissionId;
				_representativeId = daoRepresentativeComissionVw.RepresentativeId;
				_comissionDate = daoRepresentativeComissionVw.ComissionDate;
				_comissionValue = daoRepresentativeComissionVw.ComissionValue;
				_isApproved = daoRepresentativeComissionVw.IsApproved;
				_comissionTypeId = daoRepresentativeComissionVw.ComissionTypeId;
				_comissionTypeNameEn = daoRepresentativeComissionVw.ComissionTypeNameEn;
				_comissionTypeNameAr = daoRepresentativeComissionVw.ComissionTypeNameAr;
				_kindNameAr = daoRepresentativeComissionVw.KindNameAr;
				_kindNameEn = daoRepresentativeComissionVw.KindNameEn;
				_supervisorId = daoRepresentativeComissionVw.SupervisorId;
				_kindId = daoRepresentativeComissionVw.KindId;
				_userId = daoRepresentativeComissionVw.UserId;
				_branchId = daoRepresentativeComissionVw.BranchId;
				_businessUnitId = daoRepresentativeComissionVw.BusinessUnitId;
				_representativeCode = daoRepresentativeComissionVw.RepresentativeCode;
				_companyCode = daoRepresentativeComissionVw.CompanyCode;
				_representativeNameAr = daoRepresentativeComissionVw.RepresentativeNameAr;
				_representativeNameEn = daoRepresentativeComissionVw.RepresentativeNameEn;
				_branchCode = daoRepresentativeComissionVw.BranchCode;
				_branchNameAr = daoRepresentativeComissionVw.BranchNameAr;
				_branchNameEn = daoRepresentativeComissionVw.BranchNameEn;
				_kindCode = daoRepresentativeComissionVw.KindCode;
				_supervisorCode = daoRepresentativeComissionVw.SupervisorCode;
				_supervisorNameEn = daoRepresentativeComissionVw.SupervisorNameEn;
				_supervisorNameAr = daoRepresentativeComissionVw.SupervisorNameAr;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///RepresentativeComissionVwCollection
		///This method returns the collection of BORepresentativeComissionVw objects
		///</Summary>
		///<returns>
		///List[BORepresentativeComissionVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BORepresentativeComissionVw> RepresentativeComissionVwCollection()
		{
			try
			{
				IList<BORepresentativeComissionVw> boRepresentativeComissionVwCollection = new List<BORepresentativeComissionVw>();
				IList<DAORepresentativeComissionVw> daoRepresentativeComissionVwCollection = DAORepresentativeComissionVw.SelectAll();
			
				foreach(DAORepresentativeComissionVw daoRepresentativeComissionVw in daoRepresentativeComissionVwCollection)
					boRepresentativeComissionVwCollection.Add(new BORepresentativeComissionVw(daoRepresentativeComissionVw));
			
				return boRepresentativeComissionVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RepresentativeComissionVwCollectionCount
		///This method returns the collection count of BORepresentativeComissionVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 RepresentativeComissionVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAORepresentativeComissionVw.SelectAllCount();
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
		///List<BORepresentativeComissionVw>
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
				IDictionary<string, IList<object>> retObj = DAORepresentativeComissionVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RepresentativeComissionVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BORepresentativeComissionVw objects, filtered by optional criteria
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
				IList<T> boRepresentativeComissionVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAORepresentativeComissionVw> daoRepresentativeComissionVwCollection = DAORepresentativeComissionVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAORepresentativeComissionVw resdaoRepresentativeComissionVw in daoRepresentativeComissionVwCollection)
					boRepresentativeComissionVwCollection.Add((T)(object)new BORepresentativeComissionVw(resdaoRepresentativeComissionVw));
			
				return boRepresentativeComissionVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RepresentativeComissionVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BORepresentativeComissionVw objects, filtered by optional criteria
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
				Int32 objCount = DAORepresentativeComissionVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? ComissionId
		{
			get
			{
				 return _comissionId;
			}
			set
			{
				_comissionId = value;
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
		
		public virtual DateTime? ComissionDate
		{
			get
			{
				 return _comissionDate;
			}
			set
			{
				_comissionDate = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? ComissionValue
		{
			get
			{
				 return _comissionValue;
			}
			set
			{
				_comissionValue = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? IsApproved
		{
			get
			{
				 return _isApproved;
			}
			set
			{
				_isApproved = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ComissionTypeId
		{
			get
			{
				 return _comissionTypeId;
			}
			set
			{
				_comissionTypeId = value;
				_isDirty = true;
			}
		}
		
		public virtual string ComissionTypeNameEn
		{
			get
			{
				 return _comissionTypeNameEn;
			}
			set
			{
				_comissionTypeNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string ComissionTypeNameAr
		{
			get
			{
				 return _comissionTypeNameAr;
			}
			set
			{
				_comissionTypeNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string KindNameAr
		{
			get
			{
				 return _kindNameAr;
			}
			set
			{
				_kindNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string KindNameEn
		{
			get
			{
				 return _kindNameEn;
			}
			set
			{
				_kindNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? SupervisorId
		{
			get
			{
				 return _supervisorId;
			}
			set
			{
				_supervisorId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? KindId
		{
			get
			{
				 return _kindId;
			}
			set
			{
				_kindId = value;
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
		
		public virtual Int32? BranchId
		{
			get
			{
				 return _branchId;
			}
			set
			{
				_branchId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? BusinessUnitId
		{
			get
			{
				 return _businessUnitId;
			}
			set
			{
				_businessUnitId = value;
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
		
		public virtual string CompanyCode
		{
			get
			{
				 return _companyCode;
			}
			set
			{
				_companyCode = value;
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
		
		public virtual string BranchCode
		{
			get
			{
				 return _branchCode;
			}
			set
			{
				_branchCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string BranchNameAr
		{
			get
			{
				 return _branchNameAr;
			}
			set
			{
				_branchNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string BranchNameEn
		{
			get
			{
				 return _branchNameEn;
			}
			set
			{
				_branchNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string KindCode
		{
			get
			{
				 return _kindCode;
			}
			set
			{
				_kindCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string SupervisorCode
		{
			get
			{
				 return _supervisorCode;
			}
			set
			{
				_supervisorCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string SupervisorNameEn
		{
			get
			{
				 return _supervisorNameEn;
			}
			set
			{
				_supervisorNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string SupervisorNameAr
		{
			get
			{
				 return _supervisorNameAr;
			}
			set
			{
				_supervisorNameAr = value;
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
