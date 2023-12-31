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
	///This is the definition of the class BOAppUserVw.
	///</Summary>
	public partial class BOAppUserVw : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _userId;
		protected Int32? _appRoleId;
		protected Int32? _userGroupId;
		protected string _realName;
		protected string _userName;
		protected bool? _isOnline;
		protected bool? _isLocked;
		protected bool? _mustChangeData;
		protected DateTime? _lastLogin;
		protected bool? _mustChangePassword;
		protected bool? _emailVerified;
		protected string _defaultRoute;
		protected string _phone;
		protected string _whatsApp;
		protected Int32? _expr1;
		protected string _userGroupCode;
		protected string _userGroupNameEn;
		protected string _userGroupNameAr;
		protected string _appRoleCode;
		protected string _appRoleNameEn;
		protected string _appRoleNameAr;
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
		public BOAppUserVw()
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
		///DAOAppUserVw
		///</parameters>
		protected internal BOAppUserVw(DAOAppUserVw daoAppUserVw)
		{
			try
			{
				_userId = daoAppUserVw.UserId;
				_appRoleId = daoAppUserVw.AppRoleId;
				_userGroupId = daoAppUserVw.UserGroupId;
				_realName = daoAppUserVw.RealName;
				_userName = daoAppUserVw.UserName;
				_isOnline = daoAppUserVw.IsOnline;
				_isLocked = daoAppUserVw.IsLocked;
				_mustChangeData = daoAppUserVw.MustChangeData;
				_lastLogin = daoAppUserVw.LastLogin;
				_mustChangePassword = daoAppUserVw.MustChangePassword;
				_emailVerified = daoAppUserVw.EmailVerified;
				_defaultRoute = daoAppUserVw.DefaultRoute;
				_phone = daoAppUserVw.Phone;
				_whatsApp = daoAppUserVw.WhatsApp;
				_expr1 = daoAppUserVw.Expr1;
				_userGroupCode = daoAppUserVw.UserGroupCode;
				_userGroupNameEn = daoAppUserVw.UserGroupNameEn;
				_userGroupNameAr = daoAppUserVw.UserGroupNameAr;
				_appRoleCode = daoAppUserVw.AppRoleCode;
				_appRoleNameEn = daoAppUserVw.AppRoleNameEn;
				_appRoleNameAr = daoAppUserVw.AppRoleNameAr;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///AppUserVwCollection
		///This method returns the collection of BOAppUserVw objects
		///</Summary>
		///<returns>
		///List[BOAppUserVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOAppUserVw> AppUserVwCollection()
		{
			try
			{
				IList<BOAppUserVw> boAppUserVwCollection = new List<BOAppUserVw>();
				IList<DAOAppUserVw> daoAppUserVwCollection = DAOAppUserVw.SelectAll();
			
				foreach(DAOAppUserVw daoAppUserVw in daoAppUserVwCollection)
					boAppUserVwCollection.Add(new BOAppUserVw(daoAppUserVw));
			
				return boAppUserVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AppUserVwCollectionCount
		///This method returns the collection count of BOAppUserVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 AppUserVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOAppUserVw.SelectAllCount();
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
		///List<BOAppUserVw>
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
				IDictionary<string, IList<object>> retObj = DAOAppUserVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AppUserVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOAppUserVw objects, filtered by optional criteria
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
				IList<T> boAppUserVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOAppUserVw> daoAppUserVwCollection = DAOAppUserVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOAppUserVw resdaoAppUserVw in daoAppUserVwCollection)
					boAppUserVwCollection.Add((T)(object)new BOAppUserVw(resdaoAppUserVw));
			
				return boAppUserVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AppUserVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOAppUserVw objects, filtered by optional criteria
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
				Int32 objCount = DAOAppUserVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
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
		
		public virtual Int32? AppRoleId
		{
			get
			{
				 return _appRoleId;
			}
			set
			{
				_appRoleId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? UserGroupId
		{
			get
			{
				 return _userGroupId;
			}
			set
			{
				_userGroupId = value;
				_isDirty = true;
			}
		}
		
		public virtual string RealName
		{
			get
			{
				 return _realName;
			}
			set
			{
				_realName = value;
				_isDirty = true;
			}
		}
		
		public virtual string UserName
		{
			get
			{
				 return _userName;
			}
			set
			{
				_userName = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? IsOnline
		{
			get
			{
				 return _isOnline;
			}
			set
			{
				_isOnline = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? IsLocked
		{
			get
			{
				 return _isLocked;
			}
			set
			{
				_isLocked = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? MustChangeData
		{
			get
			{
				 return _mustChangeData;
			}
			set
			{
				_mustChangeData = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? LastLogin
		{
			get
			{
				 return _lastLogin;
			}
			set
			{
				_lastLogin = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? MustChangePassword
		{
			get
			{
				 return _mustChangePassword;
			}
			set
			{
				_mustChangePassword = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? EmailVerified
		{
			get
			{
				 return _emailVerified;
			}
			set
			{
				_emailVerified = value;
				_isDirty = true;
			}
		}
		
		public virtual string DefaultRoute
		{
			get
			{
				 return _defaultRoute;
			}
			set
			{
				_defaultRoute = value;
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
		
		public virtual Int32? Expr1
		{
			get
			{
				 return _expr1;
			}
			set
			{
				_expr1 = value;
				_isDirty = true;
			}
		}
		
		public virtual string UserGroupCode
		{
			get
			{
				 return _userGroupCode;
			}
			set
			{
				_userGroupCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string UserGroupNameEn
		{
			get
			{
				 return _userGroupNameEn;
			}
			set
			{
				_userGroupNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string UserGroupNameAr
		{
			get
			{
				 return _userGroupNameAr;
			}
			set
			{
				_userGroupNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string AppRoleCode
		{
			get
			{
				 return _appRoleCode;
			}
			set
			{
				_appRoleCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string AppRoleNameEn
		{
			get
			{
				 return _appRoleNameEn;
			}
			set
			{
				_appRoleNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string AppRoleNameAr
		{
			get
			{
				 return _appRoleNameAr;
			}
			set
			{
				_appRoleNameAr = value;
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
