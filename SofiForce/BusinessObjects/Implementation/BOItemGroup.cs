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
	///This is the definition of the class BOItemGroup.
	///</Summary>
	public partial class BOItemGroup : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _itemGroupId;
		protected string _itemGroupCode;
		protected string _itemGroupNameEn;
		protected string _itemGroupNameAr;
		protected string _icon;
		protected string _color;
		protected Int32? _displayOrder;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected bool? _isActive;
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
		public BOItemGroup()
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
		///Int32 itemGroupId
		///</parameters>
		public BOItemGroup(Int32 itemGroupId)
		{
			try
			{
				DAOItemGroup daoItemGroup = DAOItemGroup.SelectOne(itemGroupId);
				_itemGroupId = daoItemGroup.ItemGroupId;
				_itemGroupCode = daoItemGroup.ItemGroupCode;
				_itemGroupNameEn = daoItemGroup.ItemGroupNameEn;
				_itemGroupNameAr = daoItemGroup.ItemGroupNameAr;
				_icon = daoItemGroup.Icon;
				_color = daoItemGroup.Color;
				_displayOrder = daoItemGroup.DisplayOrder;
				_canEdit = daoItemGroup.CanEdit;
				_canDelete = daoItemGroup.CanDelete;
				_isActive = daoItemGroup.IsActive;
				_cBy = daoItemGroup.CBy;
				_cDate = daoItemGroup.CDate;
				_eBy = daoItemGroup.EBy;
				_eDate = daoItemGroup.EDate;
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
		///DAOItemGroup
		///</parameters>
		protected internal BOItemGroup(DAOItemGroup daoItemGroup)
		{
			try
			{
				_itemGroupId = daoItemGroup.ItemGroupId;
				_itemGroupCode = daoItemGroup.ItemGroupCode;
				_itemGroupNameEn = daoItemGroup.ItemGroupNameEn;
				_itemGroupNameAr = daoItemGroup.ItemGroupNameAr;
				_icon = daoItemGroup.Icon;
				_color = daoItemGroup.Color;
				_displayOrder = daoItemGroup.DisplayOrder;
				_canEdit = daoItemGroup.CanEdit;
				_canDelete = daoItemGroup.CanDelete;
				_isActive = daoItemGroup.IsActive;
				_cBy = daoItemGroup.CBy;
				_cDate = daoItemGroup.CDate;
				_eBy = daoItemGroup.EBy;
				_eDate = daoItemGroup.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new ItemGroup record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOItemGroup daoItemGroup = new DAOItemGroup();
			RegisterDataObject(daoItemGroup);
			BeginTransaction("savenewBOItemGroup");
			try
			{
				daoItemGroup.ItemGroupCode = _itemGroupCode;
				daoItemGroup.ItemGroupNameEn = _itemGroupNameEn;
				daoItemGroup.ItemGroupNameAr = _itemGroupNameAr;
				daoItemGroup.Icon = _icon;
				daoItemGroup.Color = _color;
				daoItemGroup.DisplayOrder = _displayOrder;
				daoItemGroup.CanEdit = _canEdit;
				daoItemGroup.CanDelete = _canDelete;
				daoItemGroup.IsActive = _isActive;
				daoItemGroup.CBy = _cBy;
				daoItemGroup.CDate = _cDate;
				daoItemGroup.EBy = _eBy;
				daoItemGroup.EDate = _eDate;
				daoItemGroup.Insert();
				CommitTransaction();
				
				_itemGroupId = daoItemGroup.ItemGroupId;
				_itemGroupCode = daoItemGroup.ItemGroupCode;
				_itemGroupNameEn = daoItemGroup.ItemGroupNameEn;
				_itemGroupNameAr = daoItemGroup.ItemGroupNameAr;
				_icon = daoItemGroup.Icon;
				_color = daoItemGroup.Color;
				_displayOrder = daoItemGroup.DisplayOrder;
				_canEdit = daoItemGroup.CanEdit;
				_canDelete = daoItemGroup.CanDelete;
				_isActive = daoItemGroup.IsActive;
				_cBy = daoItemGroup.CBy;
				_cDate = daoItemGroup.CDate;
				_eBy = daoItemGroup.EBy;
				_eDate = daoItemGroup.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOItemGroup");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one ItemGroup record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOItemGroup
		///</parameters>
		public virtual void Update()
		{
			DAOItemGroup daoItemGroup = new DAOItemGroup();
			RegisterDataObject(daoItemGroup);
			BeginTransaction("updateBOItemGroup");
			try
			{
				daoItemGroup.ItemGroupId = _itemGroupId;
				daoItemGroup.ItemGroupCode = _itemGroupCode;
				daoItemGroup.ItemGroupNameEn = _itemGroupNameEn;
				daoItemGroup.ItemGroupNameAr = _itemGroupNameAr;
				daoItemGroup.Icon = _icon;
				daoItemGroup.Color = _color;
				daoItemGroup.DisplayOrder = _displayOrder;
				daoItemGroup.CanEdit = _canEdit;
				daoItemGroup.CanDelete = _canDelete;
				daoItemGroup.IsActive = _isActive;
				daoItemGroup.CBy = _cBy;
				daoItemGroup.CDate = _cDate;
				daoItemGroup.EBy = _eBy;
				daoItemGroup.EDate = _eDate;
				daoItemGroup.Update();
				CommitTransaction();
				
				_itemGroupId = daoItemGroup.ItemGroupId;
				_itemGroupCode = daoItemGroup.ItemGroupCode;
				_itemGroupNameEn = daoItemGroup.ItemGroupNameEn;
				_itemGroupNameAr = daoItemGroup.ItemGroupNameAr;
				_icon = daoItemGroup.Icon;
				_color = daoItemGroup.Color;
				_displayOrder = daoItemGroup.DisplayOrder;
				_canEdit = daoItemGroup.CanEdit;
				_canDelete = daoItemGroup.CanDelete;
				_isActive = daoItemGroup.IsActive;
				_cBy = daoItemGroup.CBy;
				_cDate = daoItemGroup.CDate;
				_eBy = daoItemGroup.EBy;
				_eDate = daoItemGroup.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOItemGroup");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one ItemGroup record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOItemGroup daoItemGroup = new DAOItemGroup();
			RegisterDataObject(daoItemGroup);
			BeginTransaction("deleteBOItemGroup");
			try
			{
				daoItemGroup.ItemGroupId = _itemGroupId;
				daoItemGroup.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOItemGroup");
				throw;
			}
		}
		
		///<Summary>
		///ItemGroupCollection
		///This method returns the collection of BOItemGroup objects
		///</Summary>
		///<returns>
		///List[BOItemGroup]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOItemGroup> ItemGroupCollection()
		{
			try
			{
				IList<BOItemGroup> boItemGroupCollection = new List<BOItemGroup>();
				IList<DAOItemGroup> daoItemGroupCollection = DAOItemGroup.SelectAll();
			
				foreach(DAOItemGroup daoItemGroup in daoItemGroupCollection)
					boItemGroupCollection.Add(new BOItemGroup(daoItemGroup));
			
				return boItemGroupCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemGroupCollectionCount
		///This method returns the collection count of BOItemGroup objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ItemGroupCollectionCount()
		{
			try
			{
				Int32 objCount = DAOItemGroup.SelectAllCount();
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
		///List<BOItemGroup>
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
				IDictionary<string, IList<object>> retObj = DAOItemGroup.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemGroupCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOItemGroup objects, filtered by optional criteria
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
				IList<T> boItemGroupCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOItemGroup> daoItemGroupCollection = DAOItemGroup.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOItemGroup resdaoItemGroup in daoItemGroupCollection)
					boItemGroupCollection.Add((T)(object)new BOItemGroup(resdaoItemGroup));
			
				return boItemGroupCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemGroupCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOItemGroup objects, filtered by optional criteria
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
				Int32 objCount = DAOItemGroup.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? ItemGroupId
		{
			get
			{
				 return _itemGroupId;
			}
			set
			{
				_itemGroupId = value;
				_isDirty = true;
			}
		}
		
		public virtual string ItemGroupCode
		{
			get
			{
				 return _itemGroupCode;
			}
			set
			{
				_itemGroupCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string ItemGroupNameEn
		{
			get
			{
				 return _itemGroupNameEn;
			}
			set
			{
				_itemGroupNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string ItemGroupNameAr
		{
			get
			{
				 return _itemGroupNameAr;
			}
			set
			{
				_itemGroupNameAr = value;
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