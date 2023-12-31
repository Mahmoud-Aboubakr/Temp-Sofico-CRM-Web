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
	///This is the definition of the class BOPaymentMethod.
	///It maintains a collection of BOClientPayment objects.
	///</Summary>
	public partial class BOPaymentMethod : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _paymentMethodId;
		protected string _paymentMethodCode;
		protected string _paymentMethodNameEn;
		protected string _paymentMethodNameAr;
		protected string _color;
		protected string _icon;
		protected Int32? _displayOrder;
		protected bool? _isActive;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOClientPayment> _boClientPaymentCollection;
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
		public BOPaymentMethod()
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
		///Int32 paymentMethodId
		///</parameters>
		public BOPaymentMethod(Int32 paymentMethodId)
		{
			try
			{
				DAOPaymentMethod daoPaymentMethod = DAOPaymentMethod.SelectOne(paymentMethodId);
				_paymentMethodId = daoPaymentMethod.PaymentMethodId;
				_paymentMethodCode = daoPaymentMethod.PaymentMethodCode;
				_paymentMethodNameEn = daoPaymentMethod.PaymentMethodNameEn;
				_paymentMethodNameAr = daoPaymentMethod.PaymentMethodNameAr;
				_color = daoPaymentMethod.Color;
				_icon = daoPaymentMethod.Icon;
				_displayOrder = daoPaymentMethod.DisplayOrder;
				_isActive = daoPaymentMethod.IsActive;
				_canEdit = daoPaymentMethod.CanEdit;
				_canDelete = daoPaymentMethod.CanDelete;
				_cBy = daoPaymentMethod.CBy;
				_cDate = daoPaymentMethod.CDate;
				_eBy = daoPaymentMethod.EBy;
				_eDate = daoPaymentMethod.EDate;
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
		///DAOPaymentMethod
		///</parameters>
		protected internal BOPaymentMethod(DAOPaymentMethod daoPaymentMethod)
		{
			try
			{
				_paymentMethodId = daoPaymentMethod.PaymentMethodId;
				_paymentMethodCode = daoPaymentMethod.PaymentMethodCode;
				_paymentMethodNameEn = daoPaymentMethod.PaymentMethodNameEn;
				_paymentMethodNameAr = daoPaymentMethod.PaymentMethodNameAr;
				_color = daoPaymentMethod.Color;
				_icon = daoPaymentMethod.Icon;
				_displayOrder = daoPaymentMethod.DisplayOrder;
				_isActive = daoPaymentMethod.IsActive;
				_canEdit = daoPaymentMethod.CanEdit;
				_canDelete = daoPaymentMethod.CanDelete;
				_cBy = daoPaymentMethod.CBy;
				_cDate = daoPaymentMethod.CDate;
				_eBy = daoPaymentMethod.EBy;
				_eDate = daoPaymentMethod.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new PaymentMethod record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOPaymentMethod daoPaymentMethod = new DAOPaymentMethod();
			RegisterDataObject(daoPaymentMethod);
			BeginTransaction("savenewBOPaymentMethod");
			try
			{
				daoPaymentMethod.PaymentMethodId = _paymentMethodId;
				daoPaymentMethod.PaymentMethodCode = _paymentMethodCode;
				daoPaymentMethod.PaymentMethodNameEn = _paymentMethodNameEn;
				daoPaymentMethod.PaymentMethodNameAr = _paymentMethodNameAr;
				daoPaymentMethod.Color = _color;
				daoPaymentMethod.Icon = _icon;
				daoPaymentMethod.DisplayOrder = _displayOrder;
				daoPaymentMethod.IsActive = _isActive;
				daoPaymentMethod.CanEdit = _canEdit;
				daoPaymentMethod.CanDelete = _canDelete;
				daoPaymentMethod.CBy = _cBy;
				daoPaymentMethod.CDate = _cDate;
				daoPaymentMethod.EBy = _eBy;
				daoPaymentMethod.EDate = _eDate;
				daoPaymentMethod.Insert();
				CommitTransaction();
				
				_paymentMethodId = daoPaymentMethod.PaymentMethodId;
				_paymentMethodCode = daoPaymentMethod.PaymentMethodCode;
				_paymentMethodNameEn = daoPaymentMethod.PaymentMethodNameEn;
				_paymentMethodNameAr = daoPaymentMethod.PaymentMethodNameAr;
				_color = daoPaymentMethod.Color;
				_icon = daoPaymentMethod.Icon;
				_displayOrder = daoPaymentMethod.DisplayOrder;
				_isActive = daoPaymentMethod.IsActive;
				_canEdit = daoPaymentMethod.CanEdit;
				_canDelete = daoPaymentMethod.CanDelete;
				_cBy = daoPaymentMethod.CBy;
				_cDate = daoPaymentMethod.CDate;
				_eBy = daoPaymentMethod.EBy;
				_eDate = daoPaymentMethod.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOPaymentMethod");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one PaymentMethod record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOPaymentMethod
		///</parameters>
		public virtual void Update()
		{
			DAOPaymentMethod daoPaymentMethod = new DAOPaymentMethod();
			RegisterDataObject(daoPaymentMethod);
			BeginTransaction("updateBOPaymentMethod");
			try
			{
				daoPaymentMethod.PaymentMethodId = _paymentMethodId;
				daoPaymentMethod.PaymentMethodCode = _paymentMethodCode;
				daoPaymentMethod.PaymentMethodNameEn = _paymentMethodNameEn;
				daoPaymentMethod.PaymentMethodNameAr = _paymentMethodNameAr;
				daoPaymentMethod.Color = _color;
				daoPaymentMethod.Icon = _icon;
				daoPaymentMethod.DisplayOrder = _displayOrder;
				daoPaymentMethod.IsActive = _isActive;
				daoPaymentMethod.CanEdit = _canEdit;
				daoPaymentMethod.CanDelete = _canDelete;
				daoPaymentMethod.CBy = _cBy;
				daoPaymentMethod.CDate = _cDate;
				daoPaymentMethod.EBy = _eBy;
				daoPaymentMethod.EDate = _eDate;
				daoPaymentMethod.Update();
				CommitTransaction();
				
				_paymentMethodId = daoPaymentMethod.PaymentMethodId;
				_paymentMethodCode = daoPaymentMethod.PaymentMethodCode;
				_paymentMethodNameEn = daoPaymentMethod.PaymentMethodNameEn;
				_paymentMethodNameAr = daoPaymentMethod.PaymentMethodNameAr;
				_color = daoPaymentMethod.Color;
				_icon = daoPaymentMethod.Icon;
				_displayOrder = daoPaymentMethod.DisplayOrder;
				_isActive = daoPaymentMethod.IsActive;
				_canEdit = daoPaymentMethod.CanEdit;
				_canDelete = daoPaymentMethod.CanDelete;
				_cBy = daoPaymentMethod.CBy;
				_cDate = daoPaymentMethod.CDate;
				_eBy = daoPaymentMethod.EBy;
				_eDate = daoPaymentMethod.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOPaymentMethod");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one PaymentMethod record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOPaymentMethod daoPaymentMethod = new DAOPaymentMethod();
			RegisterDataObject(daoPaymentMethod);
			BeginTransaction("deleteBOPaymentMethod");
			try
			{
				daoPaymentMethod.PaymentMethodId = _paymentMethodId;
				daoPaymentMethod.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOPaymentMethod");
				throw;
			}
		}
		
		///<Summary>
		///PaymentMethodCollection
		///This method returns the collection of BOPaymentMethod objects
		///</Summary>
		///<returns>
		///List[BOPaymentMethod]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOPaymentMethod> PaymentMethodCollection()
		{
			try
			{
				IList<BOPaymentMethod> boPaymentMethodCollection = new List<BOPaymentMethod>();
				IList<DAOPaymentMethod> daoPaymentMethodCollection = DAOPaymentMethod.SelectAll();
			
				foreach(DAOPaymentMethod daoPaymentMethod in daoPaymentMethodCollection)
					boPaymentMethodCollection.Add(new BOPaymentMethod(daoPaymentMethod));
			
				return boPaymentMethodCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PaymentMethodCollectionCount
		///This method returns the collection count of BOPaymentMethod objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 PaymentMethodCollectionCount()
		{
			try
			{
				Int32 objCount = DAOPaymentMethod.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///ClientPaymentCollection
		///This method returns its collection of BOClientPayment objects
		///</Summary>
		///<returns>
		///IList[BOClientPayment]
		///</returns>
		///<parameters>
		///BOPaymentMethod
		///</parameters>
		public virtual IList<BOClientPayment> ClientPaymentCollection()
		{
			try
			{
				if(_boClientPaymentCollection == null)
					LoadClientPaymentCollection();
				
				return _boClientPaymentCollection.AsReadOnly();
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
		///List<BOPaymentMethod>
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
				IDictionary<string, IList<object>> retObj = DAOPaymentMethod.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PaymentMethodCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOPaymentMethod objects, filtered by optional criteria
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
				IList<T> boPaymentMethodCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOPaymentMethod> daoPaymentMethodCollection = DAOPaymentMethod.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOPaymentMethod resdaoPaymentMethod in daoPaymentMethodCollection)
					boPaymentMethodCollection.Add((T)(object)new BOPaymentMethod(resdaoPaymentMethod));
			
				return boPaymentMethodCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PaymentMethodCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOPaymentMethod objects, filtered by optional criteria
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
				Int32 objCount = DAOPaymentMethod.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadClientPaymentCollection
		///This method loads the internal collection of BOClientPayment objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadClientPaymentCollection()
		{
			try
			{
				_boClientPaymentCollection = new List<BOClientPayment>();
				IList<DAOClientPayment> daoClientPaymentCollection = DAOClientPayment.SelectAllByPaymentMethodId(_paymentMethodId.Value);
				
				foreach(DAOClientPayment daoClientPayment in daoClientPaymentCollection)
					_boClientPaymentCollection.Add(new BOClientPayment(daoClientPayment));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddClientPayment
		///This method persists a BOClientPayment object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOClientPayment
		///</parameters>
		public virtual void AddClientPayment(BOClientPayment boClientPayment)
		{
			DAOClientPayment daoClientPayment = new DAOClientPayment();
			RegisterDataObject(daoClientPayment);
			BeginTransaction("addClientPayment");
			try
			{
				daoClientPayment.PaymentId = boClientPayment.PaymentId;
				daoClientPayment.ClientId = boClientPayment.ClientId;
				daoClientPayment.PaymentDate = boClientPayment.PaymentDate;
				daoClientPayment.PaymentValue = boClientPayment.PaymentValue;
				daoClientPayment.PaymentCode = boClientPayment.PaymentCode;
				daoClientPayment.RepresentativeId = boClientPayment.RepresentativeId;
				daoClientPayment.BankId = boClientPayment.BankId;
				daoClientPayment.DueDate = boClientPayment.DueDate;
				daoClientPayment.IsRejected = boClientPayment.IsRejected;
				daoClientPayment.CBy = boClientPayment.CBy;
				daoClientPayment.CDate = boClientPayment.CDate;
				daoClientPayment.EBy = boClientPayment.EBy;
				daoClientPayment.EDate = boClientPayment.EDate;
				daoClientPayment.PaymentMethodId = _paymentMethodId.Value;
				daoClientPayment.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boClientPayment = new BOClientPayment(daoClientPayment);
				if(_boClientPaymentCollection != null)
					_boClientPaymentCollection.Add(boClientPayment);
			}
			catch
			{
				RollbackTransaction("addClientPayment");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllClientPayment
		///This method deletes all BOClientPayment objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllClientPayment()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllClientPayment");
			try
			{
				DAOClientPayment.DeleteAllByPaymentMethodId(ConnectionProvider, _paymentMethodId.Value);
				CommitTransaction();
				if(_boClientPaymentCollection != null)
				{
					_boClientPaymentCollection.Clear();
					_boClientPaymentCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllClientPayment");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? PaymentMethodId
		{
			get
			{
				 return _paymentMethodId;
			}
			set
			{
				_paymentMethodId = value;
				_isDirty = true;
			}
		}
		
		public virtual string PaymentMethodCode
		{
			get
			{
				 return _paymentMethodCode;
			}
			set
			{
				_paymentMethodCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string PaymentMethodNameEn
		{
			get
			{
				 return _paymentMethodNameEn;
			}
			set
			{
				_paymentMethodNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string PaymentMethodNameAr
		{
			get
			{
				 return _paymentMethodNameAr;
			}
			set
			{
				_paymentMethodNameAr = value;
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
