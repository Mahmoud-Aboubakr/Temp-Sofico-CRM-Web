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
	///This is the definition of the class BORepresentativeVw.
	///</Summary>
	public partial class BORepresentativeVw : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _representativeId;
		protected Int32? _branchId;
		protected Int32? _userId;
		protected Int32? _supervisorId;
		protected Int32? _kindId;
		protected string _representativeCode;
		protected string _representativeNameAr;
		protected string _representativeNameEn;
		protected string _kindNameEn;
		protected string _kindNameAr;
		protected bool? _isActive;
		protected Int32? _displayOrder;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected string _icon;
		protected string _color;
		protected string _supervisorNameEn;
		protected string _supervisorNameAr;
		protected string _branchNameEn;
		protected string _branchNameAr;
		protected string _branchCode;
		protected DateTime? _joinDate;
		protected string _notes;
		protected string _phone;
		protected string _phoneAlternative;
		protected bool? _isTerminated;
		protected DateTime? _terminationDate;
		protected Int32? _terminationReasonId;
		protected string _companyCode;
		protected Int32? _businessUnitId;
		protected string _businessUnitCode;
		protected string _businessUnitNameEn;
		protected string _businessUnitNameAr;
		protected Int32? _supervisorUserId;
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
		public BORepresentativeVw()
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
		///DAORepresentativeVw
		///</parameters>
		protected internal BORepresentativeVw(DAORepresentativeVw daoRepresentativeVw)
		{
			try
			{
				_representativeId = daoRepresentativeVw.RepresentativeId;
				_branchId = daoRepresentativeVw.BranchId;
				_userId = daoRepresentativeVw.UserId;
				_supervisorId = daoRepresentativeVw.SupervisorId;
				_kindId = daoRepresentativeVw.KindId;
				_representativeCode = daoRepresentativeVw.RepresentativeCode;
				_representativeNameAr = daoRepresentativeVw.RepresentativeNameAr;
				_representativeNameEn = daoRepresentativeVw.RepresentativeNameEn;
				_kindNameEn = daoRepresentativeVw.KindNameEn;
				_kindNameAr = daoRepresentativeVw.KindNameAr;
				_isActive = daoRepresentativeVw.IsActive;
				_displayOrder = daoRepresentativeVw.DisplayOrder;
				_canEdit = daoRepresentativeVw.CanEdit;
				_canDelete = daoRepresentativeVw.CanDelete;
				_icon = daoRepresentativeVw.Icon;
				_color = daoRepresentativeVw.Color;
				_supervisorNameEn = daoRepresentativeVw.SupervisorNameEn;
				_supervisorNameAr = daoRepresentativeVw.SupervisorNameAr;
				_branchNameEn = daoRepresentativeVw.BranchNameEn;
				_branchNameAr = daoRepresentativeVw.BranchNameAr;
				_branchCode = daoRepresentativeVw.BranchCode;
				_joinDate = daoRepresentativeVw.JoinDate;
				_notes = daoRepresentativeVw.Notes;
				_phone = daoRepresentativeVw.Phone;
				_phoneAlternative = daoRepresentativeVw.PhoneAlternative;
				_isTerminated = daoRepresentativeVw.IsTerminated;
				_terminationDate = daoRepresentativeVw.TerminationDate;
				_terminationReasonId = daoRepresentativeVw.TerminationReasonId;
				_companyCode = daoRepresentativeVw.CompanyCode;
				_businessUnitId = daoRepresentativeVw.BusinessUnitId;
				_businessUnitCode = daoRepresentativeVw.BusinessUnitCode;
				_businessUnitNameEn = daoRepresentativeVw.BusinessUnitNameEn;
				_businessUnitNameAr = daoRepresentativeVw.BusinessUnitNameAr;
				_supervisorUserId = daoRepresentativeVw.SupervisorUserId;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///RepresentativeVwCollection
		///This method returns the collection of BORepresentativeVw objects
		///</Summary>
		///<returns>
		///List[BORepresentativeVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BORepresentativeVw> RepresentativeVwCollection()
		{
			try
			{
				IList<BORepresentativeVw> boRepresentativeVwCollection = new List<BORepresentativeVw>();
				IList<DAORepresentativeVw> daoRepresentativeVwCollection = DAORepresentativeVw.SelectAll();
			
				foreach(DAORepresentativeVw daoRepresentativeVw in daoRepresentativeVwCollection)
					boRepresentativeVwCollection.Add(new BORepresentativeVw(daoRepresentativeVw));
			
				return boRepresentativeVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RepresentativeVwCollectionCount
		///This method returns the collection count of BORepresentativeVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 RepresentativeVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAORepresentativeVw.SelectAllCount();
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
		///List<BORepresentativeVw>
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
				IDictionary<string, IList<object>> retObj = DAORepresentativeVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RepresentativeVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BORepresentativeVw objects, filtered by optional criteria
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
				IList<T> boRepresentativeVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAORepresentativeVw> daoRepresentativeVwCollection = DAORepresentativeVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAORepresentativeVw resdaoRepresentativeVw in daoRepresentativeVwCollection)
					boRepresentativeVwCollection.Add((T)(object)new BORepresentativeVw(resdaoRepresentativeVw));
			
				return boRepresentativeVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///RepresentativeVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BORepresentativeVw objects, filtered by optional criteria
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
				Int32 objCount = DAORepresentativeVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
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
		
		public virtual DateTime? JoinDate
		{
			get
			{
				 return _joinDate;
			}
			set
			{
				_joinDate = value;
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
		
		public virtual string PhoneAlternative
		{
			get
			{
				 return _phoneAlternative;
			}
			set
			{
				_phoneAlternative = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? IsTerminated
		{
			get
			{
				 return _isTerminated;
			}
			set
			{
				_isTerminated = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? TerminationDate
		{
			get
			{
				 return _terminationDate;
			}
			set
			{
				_terminationDate = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? TerminationReasonId
		{
			get
			{
				 return _terminationReasonId;
			}
			set
			{
				_terminationReasonId = value;
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
		
		public virtual string BusinessUnitCode
		{
			get
			{
				 return _businessUnitCode;
			}
			set
			{
				_businessUnitCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string BusinessUnitNameEn
		{
			get
			{
				 return _businessUnitNameEn;
			}
			set
			{
				_businessUnitNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string BusinessUnitNameAr
		{
			get
			{
				 return _businessUnitNameAr;
			}
			set
			{
				_businessUnitNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? SupervisorUserId
		{
			get
			{
				 return _supervisorUserId;
			}
			set
			{
				_supervisorUserId = value;
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