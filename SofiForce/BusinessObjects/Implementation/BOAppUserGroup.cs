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
	///This is the definition of the class BOAppUserGroup.
	///It maintains a collection of BOAppUser,BONotification objects.
	///</Summary>
	public partial class BOAppUserGroup : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _userGroupId;
		protected string _userGroupCode;
		protected string _userGroupNameEn;
		protected string _userGroupNameAr;
		protected string _icon;
		protected string _color;
		protected bool? _isActive;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected Int32? _displayOrder;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOAppUser> _boAppUserCollection;
		List<BONotification> _boNotificationCollection;
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
		public BOAppUserGroup()
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
		///Int32 userGroupId
		///</parameters>
		public BOAppUserGroup(Int32 userGroupId)
		{
			try
			{
				DAOAppUserGroup daoAppUserGroup = DAOAppUserGroup.SelectOne(userGroupId);
				_userGroupId = daoAppUserGroup.UserGroupId;
				_userGroupCode = daoAppUserGroup.UserGroupCode;
				_userGroupNameEn = daoAppUserGroup.UserGroupNameEn;
				_userGroupNameAr = daoAppUserGroup.UserGroupNameAr;
				_icon = daoAppUserGroup.Icon;
				_color = daoAppUserGroup.Color;
				_isActive = daoAppUserGroup.IsActive;
				_canEdit = daoAppUserGroup.CanEdit;
				_canDelete = daoAppUserGroup.CanDelete;
				_displayOrder = daoAppUserGroup.DisplayOrder;
				_cBy = daoAppUserGroup.CBy;
				_cDate = daoAppUserGroup.CDate;
				_eBy = daoAppUserGroup.EBy;
				_eDate = daoAppUserGroup.EDate;
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
		///DAOAppUserGroup
		///</parameters>
		protected internal BOAppUserGroup(DAOAppUserGroup daoAppUserGroup)
		{
			try
			{
				_userGroupId = daoAppUserGroup.UserGroupId;
				_userGroupCode = daoAppUserGroup.UserGroupCode;
				_userGroupNameEn = daoAppUserGroup.UserGroupNameEn;
				_userGroupNameAr = daoAppUserGroup.UserGroupNameAr;
				_icon = daoAppUserGroup.Icon;
				_color = daoAppUserGroup.Color;
				_isActive = daoAppUserGroup.IsActive;
				_canEdit = daoAppUserGroup.CanEdit;
				_canDelete = daoAppUserGroup.CanDelete;
				_displayOrder = daoAppUserGroup.DisplayOrder;
				_cBy = daoAppUserGroup.CBy;
				_cDate = daoAppUserGroup.CDate;
				_eBy = daoAppUserGroup.EBy;
				_eDate = daoAppUserGroup.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new AppUserGroup record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOAppUserGroup daoAppUserGroup = new DAOAppUserGroup();
			RegisterDataObject(daoAppUserGroup);
			BeginTransaction("savenewBOAppUserGroup");
			try
			{
				daoAppUserGroup.UserGroupId = _userGroupId;
				daoAppUserGroup.UserGroupCode = _userGroupCode;
				daoAppUserGroup.UserGroupNameEn = _userGroupNameEn;
				daoAppUserGroup.UserGroupNameAr = _userGroupNameAr;
				daoAppUserGroup.Icon = _icon;
				daoAppUserGroup.Color = _color;
				daoAppUserGroup.IsActive = _isActive;
				daoAppUserGroup.CanEdit = _canEdit;
				daoAppUserGroup.CanDelete = _canDelete;
				daoAppUserGroup.DisplayOrder = _displayOrder;
				daoAppUserGroup.CBy = _cBy;
				daoAppUserGroup.CDate = _cDate;
				daoAppUserGroup.EBy = _eBy;
				daoAppUserGroup.EDate = _eDate;
				daoAppUserGroup.Insert();
				CommitTransaction();
				
				_userGroupId = daoAppUserGroup.UserGroupId;
				_userGroupCode = daoAppUserGroup.UserGroupCode;
				_userGroupNameEn = daoAppUserGroup.UserGroupNameEn;
				_userGroupNameAr = daoAppUserGroup.UserGroupNameAr;
				_icon = daoAppUserGroup.Icon;
				_color = daoAppUserGroup.Color;
				_isActive = daoAppUserGroup.IsActive;
				_canEdit = daoAppUserGroup.CanEdit;
				_canDelete = daoAppUserGroup.CanDelete;
				_displayOrder = daoAppUserGroup.DisplayOrder;
				_cBy = daoAppUserGroup.CBy;
				_cDate = daoAppUserGroup.CDate;
				_eBy = daoAppUserGroup.EBy;
				_eDate = daoAppUserGroup.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOAppUserGroup");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one AppUserGroup record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOAppUserGroup
		///</parameters>
		public virtual void Update()
		{
			DAOAppUserGroup daoAppUserGroup = new DAOAppUserGroup();
			RegisterDataObject(daoAppUserGroup);
			BeginTransaction("updateBOAppUserGroup");
			try
			{
				daoAppUserGroup.UserGroupId = _userGroupId;
				daoAppUserGroup.UserGroupCode = _userGroupCode;
				daoAppUserGroup.UserGroupNameEn = _userGroupNameEn;
				daoAppUserGroup.UserGroupNameAr = _userGroupNameAr;
				daoAppUserGroup.Icon = _icon;
				daoAppUserGroup.Color = _color;
				daoAppUserGroup.IsActive = _isActive;
				daoAppUserGroup.CanEdit = _canEdit;
				daoAppUserGroup.CanDelete = _canDelete;
				daoAppUserGroup.DisplayOrder = _displayOrder;
				daoAppUserGroup.CBy = _cBy;
				daoAppUserGroup.CDate = _cDate;
				daoAppUserGroup.EBy = _eBy;
				daoAppUserGroup.EDate = _eDate;
				daoAppUserGroup.Update();
				CommitTransaction();
				
				_userGroupId = daoAppUserGroup.UserGroupId;
				_userGroupCode = daoAppUserGroup.UserGroupCode;
				_userGroupNameEn = daoAppUserGroup.UserGroupNameEn;
				_userGroupNameAr = daoAppUserGroup.UserGroupNameAr;
				_icon = daoAppUserGroup.Icon;
				_color = daoAppUserGroup.Color;
				_isActive = daoAppUserGroup.IsActive;
				_canEdit = daoAppUserGroup.CanEdit;
				_canDelete = daoAppUserGroup.CanDelete;
				_displayOrder = daoAppUserGroup.DisplayOrder;
				_cBy = daoAppUserGroup.CBy;
				_cDate = daoAppUserGroup.CDate;
				_eBy = daoAppUserGroup.EBy;
				_eDate = daoAppUserGroup.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOAppUserGroup");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one AppUserGroup record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOAppUserGroup daoAppUserGroup = new DAOAppUserGroup();
			RegisterDataObject(daoAppUserGroup);
			BeginTransaction("deleteBOAppUserGroup");
			try
			{
				daoAppUserGroup.UserGroupId = _userGroupId;
				daoAppUserGroup.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOAppUserGroup");
				throw;
			}
		}
		
		///<Summary>
		///AppUserGroupCollection
		///This method returns the collection of BOAppUserGroup objects
		///</Summary>
		///<returns>
		///List[BOAppUserGroup]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOAppUserGroup> AppUserGroupCollection()
		{
			try
			{
				IList<BOAppUserGroup> boAppUserGroupCollection = new List<BOAppUserGroup>();
				IList<DAOAppUserGroup> daoAppUserGroupCollection = DAOAppUserGroup.SelectAll();
			
				foreach(DAOAppUserGroup daoAppUserGroup in daoAppUserGroupCollection)
					boAppUserGroupCollection.Add(new BOAppUserGroup(daoAppUserGroup));
			
				return boAppUserGroupCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AppUserGroupCollectionCount
		///This method returns the collection count of BOAppUserGroup objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 AppUserGroupCollectionCount()
		{
			try
			{
				Int32 objCount = DAOAppUserGroup.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AppUserCollection
		///This method returns its collection of BOAppUser objects
		///</Summary>
		///<returns>
		///IList[BOAppUser]
		///</returns>
		///<parameters>
		///BOAppUserGroup
		///</parameters>
		public virtual IList<BOAppUser> AppUserCollection()
		{
			try
			{
				if(_boAppUserCollection == null)
					LoadAppUserCollection();
				
				return _boAppUserCollection.AsReadOnly();
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///NotificationCollection
		///This method returns its collection of BONotification objects
		///</Summary>
		///<returns>
		///IList[BONotification]
		///</returns>
		///<parameters>
		///BOAppUserGroup
		///</parameters>
		public virtual IList<BONotification> NotificationCollection()
		{
			try
			{
				if(_boNotificationCollection == null)
					LoadNotificationCollection();
				
				return _boNotificationCollection.AsReadOnly();
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
		///List<BOAppUserGroup>
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
				IDictionary<string, IList<object>> retObj = DAOAppUserGroup.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AppUserGroupCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOAppUserGroup objects, filtered by optional criteria
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
				IList<T> boAppUserGroupCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOAppUserGroup> daoAppUserGroupCollection = DAOAppUserGroup.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOAppUserGroup resdaoAppUserGroup in daoAppUserGroupCollection)
					boAppUserGroupCollection.Add((T)(object)new BOAppUserGroup(resdaoAppUserGroup));
			
				return boAppUserGroupCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AppUserGroupCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOAppUserGroup objects, filtered by optional criteria
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
				Int32 objCount = DAOAppUserGroup.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadAppUserCollection
		///This method loads the internal collection of BOAppUser objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadAppUserCollection()
		{
			try
			{
				_boAppUserCollection = new List<BOAppUser>();
				IList<DAOAppUser> daoAppUserCollection = DAOAppUser.SelectAllByUserGroupId(_userGroupId.Value);
				
				foreach(DAOAppUser daoAppUser in daoAppUserCollection)
					_boAppUserCollection.Add(new BOAppUser(daoAppUser));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddAppUser
		///This method persists a BOAppUser object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOAppUser
		///</parameters>
		public virtual void AddAppUser(BOAppUser boAppUser)
		{
			DAOAppUser daoAppUser = new DAOAppUser();
			RegisterDataObject(daoAppUser);
			BeginTransaction("addAppUser");
			try
			{
				daoAppUser.UserId = boAppUser.UserId;
				daoAppUser.AppRoleId = boAppUser.AppRoleId;
				daoAppUser.RealName = boAppUser.RealName;
				daoAppUser.UserName = boAppUser.UserName;
				daoAppUser.Password = boAppUser.Password;
				daoAppUser.IsOnline = boAppUser.IsOnline;
				daoAppUser.IsLocked = boAppUser.IsLocked;
				daoAppUser.MustChangeData = boAppUser.MustChangeData;
				daoAppUser.LastLogin = boAppUser.LastLogin;
				daoAppUser.MustChangePassword = boAppUser.MustChangePassword;
				daoAppUser.EmailVerified = boAppUser.EmailVerified;
				daoAppUser.FirebaseId = boAppUser.FirebaseId;
				daoAppUser.SignalrId = boAppUser.SignalrId;
				daoAppUser.FailedCount = boAppUser.FailedCount;
				daoAppUser.DefaultRoute = boAppUser.DefaultRoute;
				daoAppUser.Phone = boAppUser.Phone;
				daoAppUser.WhatsApp = boAppUser.WhatsApp;
				daoAppUser.ZoomId = boAppUser.ZoomId;
				daoAppUser.LinkedIn = boAppUser.LinkedIn;
				daoAppUser.UserBio = boAppUser.UserBio;
				daoAppUser.Latitude = boAppUser.Latitude;
				daoAppUser.Longitude = boAppUser.Longitude;
				daoAppUser.Address = boAppUser.Address;
				daoAppUser.Email = boAppUser.Email;
				daoAppUser.Fax = boAppUser.Fax;
				daoAppUser.Internal = boAppUser.Internal;
				daoAppUser.JobTitle = boAppUser.JobTitle;
				daoAppUser.Avatar = boAppUser.Avatar;
				daoAppUser.Mobile = boAppUser.Mobile;
				daoAppUser.CBy = boAppUser.CBy;
				daoAppUser.CDate = boAppUser.CDate;
				daoAppUser.EBy = boAppUser.EBy;
				daoAppUser.EDate = boAppUser.EDate;
				daoAppUser.PrimaryMobile = boAppUser.PrimaryMobile;
				daoAppUser.MobileVerified = boAppUser.MobileVerified;
				daoAppUser.VerificationCode = boAppUser.VerificationCode;
				daoAppUser.UserGroupId = _userGroupId.Value;
				daoAppUser.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boAppUser = new BOAppUser(daoAppUser);
				if(_boAppUserCollection != null)
					_boAppUserCollection.Add(boAppUser);
			}
			catch
			{
				RollbackTransaction("addAppUser");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllAppUser
		///This method deletes all BOAppUser objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllAppUser()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllAppUser");
			try
			{
				DAOAppUser.DeleteAllByUserGroupId(ConnectionProvider, _userGroupId.Value);
				CommitTransaction();
				if(_boAppUserCollection != null)
				{
					_boAppUserCollection.Clear();
					_boAppUserCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllAppUser");
				throw;
			}
		}
		
		///<Summary>
		///LoadNotificationCollection
		///This method loads the internal collection of BONotification objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadNotificationCollection()
		{
			try
			{
				_boNotificationCollection = new List<BONotification>();
				IList<DAONotification> daoNotificationCollection = DAONotification.SelectAllByUserGroupId(_userGroupId.Value);
				
				foreach(DAONotification daoNotification in daoNotificationCollection)
					_boNotificationCollection.Add(new BONotification(daoNotification));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddNotification
		///This method persists a BONotification object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BONotification
		///</parameters>
		public virtual void AddNotification(BONotification boNotification)
		{
			DAONotification daoNotification = new DAONotification();
			RegisterDataObject(daoNotification);
			BeginTransaction("addNotification");
			try
			{
				daoNotification.NotificationId = boNotification.NotificationId;
				daoNotification.NotificationDate = boNotification.NotificationDate;
				daoNotification.ScheduleTime = boNotification.ScheduleTime;
				daoNotification.NotificationDateTime = boNotification.NotificationDateTime;
				daoNotification.PriorityId = boNotification.PriorityId;
				daoNotification.Message = boNotification.Message;
				daoNotification.NotificationTypeId = boNotification.NotificationTypeId;
				daoNotification.UserId = boNotification.UserId;
				daoNotification.CBy = boNotification.CBy;
				daoNotification.CDate = boNotification.CDate;
				daoNotification.EBy = boNotification.EBy;
				daoNotification.EDate = boNotification.EDate;
				daoNotification.UserGroupId = _userGroupId.Value;
				daoNotification.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boNotification = new BONotification(daoNotification);
				if(_boNotificationCollection != null)
					_boNotificationCollection.Add(boNotification);
			}
			catch
			{
				RollbackTransaction("addNotification");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllNotification
		///This method deletes all BONotification objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllNotification()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllNotification");
			try
			{
				DAONotification.DeleteAllByUserGroupId(ConnectionProvider, _userGroupId.Value);
				CommitTransaction();
				if(_boNotificationCollection != null)
				{
					_boNotificationCollection.Clear();
					_boNotificationCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllNotification");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
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