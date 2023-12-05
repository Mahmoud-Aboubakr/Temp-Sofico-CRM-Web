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
	///This is the definition of the class BOCarType.
	///</Summary>
	public partial class BOCarType : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _carTypeId;
		protected string _carTypeCode;
		protected string _carTypeNameEn;
		protected string _carTypeNameAr;
		protected Int32? _displayOrder;
		protected bool? _isActive;
		protected string _color;
		protected string _icon;
		protected bool? _canEdit;
		protected bool? _canDelete;
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
		public BOCarType()
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
		///Int32 carTypeId
		///</parameters>
		public BOCarType(Int32 carTypeId)
		{
			try
			{
				DAOCarType daoCarType = DAOCarType.SelectOne(carTypeId);
				_carTypeId = daoCarType.CarTypeId;
				_carTypeCode = daoCarType.CarTypeCode;
				_carTypeNameEn = daoCarType.CarTypeNameEn;
				_carTypeNameAr = daoCarType.CarTypeNameAr;
				_displayOrder = daoCarType.DisplayOrder;
				_isActive = daoCarType.IsActive;
				_color = daoCarType.Color;
				_icon = daoCarType.Icon;
				_canEdit = daoCarType.CanEdit;
				_canDelete = daoCarType.CanDelete;
				_cBy = daoCarType.CBy;
				_cDate = daoCarType.CDate;
				_eBy = daoCarType.EBy;
				_eDate = daoCarType.EDate;
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
		///DAOCarType
		///</parameters>
		protected internal BOCarType(DAOCarType daoCarType)
		{
			try
			{
				_carTypeId = daoCarType.CarTypeId;
				_carTypeCode = daoCarType.CarTypeCode;
				_carTypeNameEn = daoCarType.CarTypeNameEn;
				_carTypeNameAr = daoCarType.CarTypeNameAr;
				_displayOrder = daoCarType.DisplayOrder;
				_isActive = daoCarType.IsActive;
				_color = daoCarType.Color;
				_icon = daoCarType.Icon;
				_canEdit = daoCarType.CanEdit;
				_canDelete = daoCarType.CanDelete;
				_cBy = daoCarType.CBy;
				_cDate = daoCarType.CDate;
				_eBy = daoCarType.EBy;
				_eDate = daoCarType.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new CarType record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOCarType daoCarType = new DAOCarType();
			RegisterDataObject(daoCarType);
			BeginTransaction("savenewBOCarType");
			try
			{
				daoCarType.CarTypeCode = _carTypeCode;
				daoCarType.CarTypeNameEn = _carTypeNameEn;
				daoCarType.CarTypeNameAr = _carTypeNameAr;
				daoCarType.DisplayOrder = _displayOrder;
				daoCarType.IsActive = _isActive;
				daoCarType.Color = _color;
				daoCarType.Icon = _icon;
				daoCarType.CanEdit = _canEdit;
				daoCarType.CanDelete = _canDelete;
				daoCarType.CBy = _cBy;
				daoCarType.CDate = _cDate;
				daoCarType.EBy = _eBy;
				daoCarType.EDate = _eDate;
				daoCarType.Insert();
				CommitTransaction();
				
				_carTypeId = daoCarType.CarTypeId;
				_carTypeCode = daoCarType.CarTypeCode;
				_carTypeNameEn = daoCarType.CarTypeNameEn;
				_carTypeNameAr = daoCarType.CarTypeNameAr;
				_displayOrder = daoCarType.DisplayOrder;
				_isActive = daoCarType.IsActive;
				_color = daoCarType.Color;
				_icon = daoCarType.Icon;
				_canEdit = daoCarType.CanEdit;
				_canDelete = daoCarType.CanDelete;
				_cBy = daoCarType.CBy;
				_cDate = daoCarType.CDate;
				_eBy = daoCarType.EBy;
				_eDate = daoCarType.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOCarType");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one CarType record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOCarType
		///</parameters>
		public virtual void Update()
		{
			DAOCarType daoCarType = new DAOCarType();
			RegisterDataObject(daoCarType);
			BeginTransaction("updateBOCarType");
			try
			{
				daoCarType.CarTypeId = _carTypeId;
				daoCarType.CarTypeCode = _carTypeCode;
				daoCarType.CarTypeNameEn = _carTypeNameEn;
				daoCarType.CarTypeNameAr = _carTypeNameAr;
				daoCarType.DisplayOrder = _displayOrder;
				daoCarType.IsActive = _isActive;
				daoCarType.Color = _color;
				daoCarType.Icon = _icon;
				daoCarType.CanEdit = _canEdit;
				daoCarType.CanDelete = _canDelete;
				daoCarType.CBy = _cBy;
				daoCarType.CDate = _cDate;
				daoCarType.EBy = _eBy;
				daoCarType.EDate = _eDate;
				daoCarType.Update();
				CommitTransaction();
				
				_carTypeId = daoCarType.CarTypeId;
				_carTypeCode = daoCarType.CarTypeCode;
				_carTypeNameEn = daoCarType.CarTypeNameEn;
				_carTypeNameAr = daoCarType.CarTypeNameAr;
				_displayOrder = daoCarType.DisplayOrder;
				_isActive = daoCarType.IsActive;
				_color = daoCarType.Color;
				_icon = daoCarType.Icon;
				_canEdit = daoCarType.CanEdit;
				_canDelete = daoCarType.CanDelete;
				_cBy = daoCarType.CBy;
				_cDate = daoCarType.CDate;
				_eBy = daoCarType.EBy;
				_eDate = daoCarType.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOCarType");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one CarType record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOCarType daoCarType = new DAOCarType();
			RegisterDataObject(daoCarType);
			BeginTransaction("deleteBOCarType");
			try
			{
				daoCarType.CarTypeId = _carTypeId;
				daoCarType.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOCarType");
				throw;
			}
		}
		
		///<Summary>
		///CarTypeCollection
		///This method returns the collection of BOCarType objects
		///</Summary>
		///<returns>
		///List[BOCarType]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOCarType> CarTypeCollection()
		{
			try
			{
				IList<BOCarType> boCarTypeCollection = new List<BOCarType>();
				IList<DAOCarType> daoCarTypeCollection = DAOCarType.SelectAll();
			
				foreach(DAOCarType daoCarType in daoCarTypeCollection)
					boCarTypeCollection.Add(new BOCarType(daoCarType));
			
				return boCarTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///CarTypeCollectionCount
		///This method returns the collection count of BOCarType objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 CarTypeCollectionCount()
		{
			try
			{
				Int32 objCount = DAOCarType.SelectAllCount();
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
		///List<BOCarType>
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
				IDictionary<string, IList<object>> retObj = DAOCarType.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///CarTypeCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOCarType objects, filtered by optional criteria
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
				IList<T> boCarTypeCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOCarType> daoCarTypeCollection = DAOCarType.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOCarType resdaoCarType in daoCarTypeCollection)
					boCarTypeCollection.Add((T)(object)new BOCarType(resdaoCarType));
			
				return boCarTypeCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///CarTypeCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOCarType objects, filtered by optional criteria
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
				Int32 objCount = DAOCarType.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? CarTypeId
		{
			get
			{
				 return _carTypeId;
			}
			set
			{
				_carTypeId = value;
				_isDirty = true;
			}
		}
		
		public virtual string CarTypeCode
		{
			get
			{
				 return _carTypeCode;
			}
			set
			{
				_carTypeCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string CarTypeNameEn
		{
			get
			{
				 return _carTypeNameEn;
			}
			set
			{
				_carTypeNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string CarTypeNameAr
		{
			get
			{
				 return _carTypeNameAr;
			}
			set
			{
				_carTypeNameAr = value;
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