/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 3/23/2023 3:30:40 PM
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
	///This is the definition of the class BOSalesPlanVw.
	///</Summary>
	public partial class BOSalesPlanVw : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _journeyYear;
		protected Int32? _journeyMonth;
		protected Int32? _clientId;
		protected string _clientCode;
		protected string _clientNameAr;
		protected string _clientNameEn;
		protected Int32? _branchId;
		protected string _branchNameEn;
		protected string _branchNameAr;
		protected string _branchCode;
		protected decimal? _creditLimit;
		protected decimal? _creditBalance;
		protected string _phone;
		protected string _mobile;
		protected string _whatsApp;
		protected bool? _isActive;
		protected Int32? _clientTypeId;
		protected string _clientTypeNameEn;
		protected string _clientTypeNameAr;
		protected Int32? _regionId;
		protected Int32? _governerateId;
		protected Int32? _cityId;
		protected Int32? _clientGroupId;
		protected Int32? _clientGroupSubId;
		protected Int32? _clientClassificationId;
		protected Int32? _paymentTermId;
		protected Int32? _clientAccountId;
		protected bool? _isTaxable;
		protected decimal? _targetValue;
		protected Int32? _targetVisit;
		protected Int32? _targetCall;
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
		public BOSalesPlanVw()
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
		///DAOSalesPlanVw
		///</parameters>
		protected internal BOSalesPlanVw(DAOSalesPlanVw daoSalesPlanVw)
		{
			try
			{
				_journeyYear = daoSalesPlanVw.JourneyYear;
				_journeyMonth = daoSalesPlanVw.JourneyMonth;
				_clientId = daoSalesPlanVw.ClientId;
				_clientCode = daoSalesPlanVw.ClientCode;
				_clientNameAr = daoSalesPlanVw.ClientNameAr;
				_clientNameEn = daoSalesPlanVw.ClientNameEn;
				_branchId = daoSalesPlanVw.BranchId;
				_branchNameEn = daoSalesPlanVw.BranchNameEn;
				_branchNameAr = daoSalesPlanVw.BranchNameAr;
				_branchCode = daoSalesPlanVw.BranchCode;
				_creditLimit = daoSalesPlanVw.CreditLimit;
				_creditBalance = daoSalesPlanVw.CreditBalance;
				_phone = daoSalesPlanVw.Phone;
				_mobile = daoSalesPlanVw.Mobile;
				_whatsApp = daoSalesPlanVw.WhatsApp;
				_isActive = daoSalesPlanVw.IsActive;
				_clientTypeId = daoSalesPlanVw.ClientTypeId;
				_clientTypeNameEn = daoSalesPlanVw.ClientTypeNameEn;
				_clientTypeNameAr = daoSalesPlanVw.ClientTypeNameAr;
				_regionId = daoSalesPlanVw.RegionId;
				_governerateId = daoSalesPlanVw.GovernerateId;
				_cityId = daoSalesPlanVw.CityId;
				_clientGroupId = daoSalesPlanVw.ClientGroupId;
				_clientGroupSubId = daoSalesPlanVw.ClientGroupSubId;
				_clientClassificationId = daoSalesPlanVw.ClientClassificationId;
				_paymentTermId = daoSalesPlanVw.PaymentTermId;
				_clientAccountId = daoSalesPlanVw.ClientAccountId;
				_isTaxable = daoSalesPlanVw.IsTaxable;
				_targetValue = daoSalesPlanVw.TargetValue;
				_targetVisit = daoSalesPlanVw.TargetVisit;
				_targetCall = daoSalesPlanVw.TargetCall;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///SalesPlanVwCollection
		///This method returns the collection of BOSalesPlanVw objects
		///</Summary>
		///<returns>
		///List[BOSalesPlanVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOSalesPlanVw> SalesPlanVwCollection()
		{
			try
			{
				IList<BOSalesPlanVw> boSalesPlanVwCollection = new List<BOSalesPlanVw>();
				IList<DAOSalesPlanVw> daoSalesPlanVwCollection = DAOSalesPlanVw.SelectAll();
			
				foreach(DAOSalesPlanVw daoSalesPlanVw in daoSalesPlanVwCollection)
					boSalesPlanVwCollection.Add(new BOSalesPlanVw(daoSalesPlanVw));
			
				return boSalesPlanVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesPlanVwCollectionCount
		///This method returns the collection count of BOSalesPlanVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 SalesPlanVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOSalesPlanVw.SelectAllCount();
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
		///List<BOSalesPlanVw>
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
				IDictionary<string, IList<object>> retObj = DAOSalesPlanVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesPlanVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOSalesPlanVw objects, filtered by optional criteria
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
				IList<T> boSalesPlanVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOSalesPlanVw> daoSalesPlanVwCollection = DAOSalesPlanVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOSalesPlanVw resdaoSalesPlanVw in daoSalesPlanVwCollection)
					boSalesPlanVwCollection.Add((T)(object)new BOSalesPlanVw(resdaoSalesPlanVw));
			
				return boSalesPlanVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesPlanVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOSalesPlanVw objects, filtered by optional criteria
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
				Int32 objCount = DAOSalesPlanVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? JourneyYear
		{
			get
			{
				 return _journeyYear;
			}
			set
			{
				_journeyYear = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? JourneyMonth
		{
			get
			{
				 return _journeyMonth;
			}
			set
			{
				_journeyMonth = value;
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
		
		public virtual string ClientCode
		{
			get
			{
				 return _clientCode;
			}
			set
			{
				_clientCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string ClientNameAr
		{
			get
			{
				 return _clientNameAr;
			}
			set
			{
				_clientNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string ClientNameEn
		{
			get
			{
				 return _clientNameEn;
			}
			set
			{
				_clientNameEn = value;
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
		
		public virtual decimal? CreditLimit
		{
			get
			{
				 return _creditLimit;
			}
			set
			{
				_creditLimit = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? CreditBalance
		{
			get
			{
				 return _creditBalance;
			}
			set
			{
				_creditBalance = value;
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
		
		public virtual string Mobile
		{
			get
			{
				 return _mobile;
			}
			set
			{
				_mobile = value;
				_isDirty = true;
			}
		}
		
		public virtual string WhatsApp
		{
			get
			{
				 return _whatsApp;
			}
			set
			{
				_whatsApp = value;
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
		
		public virtual Int32? ClientTypeId
		{
			get
			{
				 return _clientTypeId;
			}
			set
			{
				_clientTypeId = value;
				_isDirty = true;
			}
		}
		
		public virtual string ClientTypeNameEn
		{
			get
			{
				 return _clientTypeNameEn;
			}
			set
			{
				_clientTypeNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string ClientTypeNameAr
		{
			get
			{
				 return _clientTypeNameAr;
			}
			set
			{
				_clientTypeNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? RegionId
		{
			get
			{
				 return _regionId;
			}
			set
			{
				_regionId = value;
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
		
		public virtual Int32? CityId
		{
			get
			{
				 return _cityId;
			}
			set
			{
				_cityId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ClientGroupId
		{
			get
			{
				 return _clientGroupId;
			}
			set
			{
				_clientGroupId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ClientGroupSubId
		{
			get
			{
				 return _clientGroupSubId;
			}
			set
			{
				_clientGroupSubId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ClientClassificationId
		{
			get
			{
				 return _clientClassificationId;
			}
			set
			{
				_clientClassificationId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? PaymentTermId
		{
			get
			{
				 return _paymentTermId;
			}
			set
			{
				_paymentTermId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ClientAccountId
		{
			get
			{
				 return _clientAccountId;
			}
			set
			{
				_clientAccountId = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? IsTaxable
		{
			get
			{
				 return _isTaxable;
			}
			set
			{
				_isTaxable = value;
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
