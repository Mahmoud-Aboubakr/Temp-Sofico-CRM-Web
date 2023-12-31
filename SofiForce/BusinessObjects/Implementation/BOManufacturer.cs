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
	///This is the definition of the class BOManufacturer.
	///It maintains a collection of BOCar objects.
	///</Summary>
	public partial class BOManufacturer : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _manufacturerId;
		protected string _manufacturerCode;
		protected string _manufacturerNameEn;
		protected string _manufacturerNameAr;
		protected string _color;
		protected string _icon;
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
		List<BOCar> _boCarCollection;
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
		public BOManufacturer()
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
		///Int32 manufacturerId
		///</parameters>
		public BOManufacturer(Int32 manufacturerId)
		{
			try
			{
				DAOManufacturer daoManufacturer = DAOManufacturer.SelectOne(manufacturerId);
				_manufacturerId = daoManufacturer.ManufacturerId;
				_manufacturerCode = daoManufacturer.ManufacturerCode;
				_manufacturerNameEn = daoManufacturer.ManufacturerNameEn;
				_manufacturerNameAr = daoManufacturer.ManufacturerNameAr;
				_color = daoManufacturer.Color;
				_icon = daoManufacturer.Icon;
				_displayOrder = daoManufacturer.DisplayOrder;
				_canEdit = daoManufacturer.CanEdit;
				_canDelete = daoManufacturer.CanDelete;
				_isActive = daoManufacturer.IsActive;
				_cBy = daoManufacturer.CBy;
				_cDate = daoManufacturer.CDate;
				_eBy = daoManufacturer.EBy;
				_eDate = daoManufacturer.EDate;
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
		///DAOManufacturer
		///</parameters>
		protected internal BOManufacturer(DAOManufacturer daoManufacturer)
		{
			try
			{
				_manufacturerId = daoManufacturer.ManufacturerId;
				_manufacturerCode = daoManufacturer.ManufacturerCode;
				_manufacturerNameEn = daoManufacturer.ManufacturerNameEn;
				_manufacturerNameAr = daoManufacturer.ManufacturerNameAr;
				_color = daoManufacturer.Color;
				_icon = daoManufacturer.Icon;
				_displayOrder = daoManufacturer.DisplayOrder;
				_canEdit = daoManufacturer.CanEdit;
				_canDelete = daoManufacturer.CanDelete;
				_isActive = daoManufacturer.IsActive;
				_cBy = daoManufacturer.CBy;
				_cDate = daoManufacturer.CDate;
				_eBy = daoManufacturer.EBy;
				_eDate = daoManufacturer.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new Manufacturer record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOManufacturer daoManufacturer = new DAOManufacturer();
			RegisterDataObject(daoManufacturer);
			BeginTransaction("savenewBOManufacturer");
			try
			{
				daoManufacturer.ManufacturerCode = _manufacturerCode;
				daoManufacturer.ManufacturerNameEn = _manufacturerNameEn;
				daoManufacturer.ManufacturerNameAr = _manufacturerNameAr;
				daoManufacturer.Color = _color;
				daoManufacturer.Icon = _icon;
				daoManufacturer.DisplayOrder = _displayOrder;
				daoManufacturer.CanEdit = _canEdit;
				daoManufacturer.CanDelete = _canDelete;
				daoManufacturer.IsActive = _isActive;
				daoManufacturer.CBy = _cBy;
				daoManufacturer.CDate = _cDate;
				daoManufacturer.EBy = _eBy;
				daoManufacturer.EDate = _eDate;
				daoManufacturer.Insert();
				CommitTransaction();
				
				_manufacturerId = daoManufacturer.ManufacturerId;
				_manufacturerCode = daoManufacturer.ManufacturerCode;
				_manufacturerNameEn = daoManufacturer.ManufacturerNameEn;
				_manufacturerNameAr = daoManufacturer.ManufacturerNameAr;
				_color = daoManufacturer.Color;
				_icon = daoManufacturer.Icon;
				_displayOrder = daoManufacturer.DisplayOrder;
				_canEdit = daoManufacturer.CanEdit;
				_canDelete = daoManufacturer.CanDelete;
				_isActive = daoManufacturer.IsActive;
				_cBy = daoManufacturer.CBy;
				_cDate = daoManufacturer.CDate;
				_eBy = daoManufacturer.EBy;
				_eDate = daoManufacturer.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOManufacturer");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one Manufacturer record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOManufacturer
		///</parameters>
		public virtual void Update()
		{
			DAOManufacturer daoManufacturer = new DAOManufacturer();
			RegisterDataObject(daoManufacturer);
			BeginTransaction("updateBOManufacturer");
			try
			{
				daoManufacturer.ManufacturerId = _manufacturerId;
				daoManufacturer.ManufacturerCode = _manufacturerCode;
				daoManufacturer.ManufacturerNameEn = _manufacturerNameEn;
				daoManufacturer.ManufacturerNameAr = _manufacturerNameAr;
				daoManufacturer.Color = _color;
				daoManufacturer.Icon = _icon;
				daoManufacturer.DisplayOrder = _displayOrder;
				daoManufacturer.CanEdit = _canEdit;
				daoManufacturer.CanDelete = _canDelete;
				daoManufacturer.IsActive = _isActive;
				daoManufacturer.CBy = _cBy;
				daoManufacturer.CDate = _cDate;
				daoManufacturer.EBy = _eBy;
				daoManufacturer.EDate = _eDate;
				daoManufacturer.Update();
				CommitTransaction();
				
				_manufacturerId = daoManufacturer.ManufacturerId;
				_manufacturerCode = daoManufacturer.ManufacturerCode;
				_manufacturerNameEn = daoManufacturer.ManufacturerNameEn;
				_manufacturerNameAr = daoManufacturer.ManufacturerNameAr;
				_color = daoManufacturer.Color;
				_icon = daoManufacturer.Icon;
				_displayOrder = daoManufacturer.DisplayOrder;
				_canEdit = daoManufacturer.CanEdit;
				_canDelete = daoManufacturer.CanDelete;
				_isActive = daoManufacturer.IsActive;
				_cBy = daoManufacturer.CBy;
				_cDate = daoManufacturer.CDate;
				_eBy = daoManufacturer.EBy;
				_eDate = daoManufacturer.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOManufacturer");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one Manufacturer record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOManufacturer daoManufacturer = new DAOManufacturer();
			RegisterDataObject(daoManufacturer);
			BeginTransaction("deleteBOManufacturer");
			try
			{
				daoManufacturer.ManufacturerId = _manufacturerId;
				daoManufacturer.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOManufacturer");
				throw;
			}
		}
		
		///<Summary>
		///ManufacturerCollection
		///This method returns the collection of BOManufacturer objects
		///</Summary>
		///<returns>
		///List[BOManufacturer]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOManufacturer> ManufacturerCollection()
		{
			try
			{
				IList<BOManufacturer> boManufacturerCollection = new List<BOManufacturer>();
				IList<DAOManufacturer> daoManufacturerCollection = DAOManufacturer.SelectAll();
			
				foreach(DAOManufacturer daoManufacturer in daoManufacturerCollection)
					boManufacturerCollection.Add(new BOManufacturer(daoManufacturer));
			
				return boManufacturerCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ManufacturerCollectionCount
		///This method returns the collection count of BOManufacturer objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ManufacturerCollectionCount()
		{
			try
			{
				Int32 objCount = DAOManufacturer.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///CarCollection
		///This method returns its collection of BOCar objects
		///</Summary>
		///<returns>
		///IList[BOCar]
		///</returns>
		///<parameters>
		///BOManufacturer
		///</parameters>
		public virtual IList<BOCar> CarCollection()
		{
			try
			{
				if(_boCarCollection == null)
					LoadCarCollection();
				
				return _boCarCollection.AsReadOnly();
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
		///List<BOManufacturer>
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
				IDictionary<string, IList<object>> retObj = DAOManufacturer.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ManufacturerCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOManufacturer objects, filtered by optional criteria
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
				IList<T> boManufacturerCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOManufacturer> daoManufacturerCollection = DAOManufacturer.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOManufacturer resdaoManufacturer in daoManufacturerCollection)
					boManufacturerCollection.Add((T)(object)new BOManufacturer(resdaoManufacturer));
			
				return boManufacturerCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ManufacturerCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOManufacturer objects, filtered by optional criteria
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
				Int32 objCount = DAOManufacturer.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadCarCollection
		///This method loads the internal collection of BOCar objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadCarCollection()
		{
			try
			{
				_boCarCollection = new List<BOCar>();
				IList<DAOCar> daoCarCollection = DAOCar.SelectAllByManufacturerId(_manufacturerId.Value);
				
				foreach(DAOCar daoCar in daoCarCollection)
					_boCarCollection.Add(new BOCar(daoCar));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddCar
		///This method persists a BOCar object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOCar
		///</parameters>
		public virtual void AddCar(BOCar boCar)
		{
			DAOCar daoCar = new DAOCar();
			RegisterDataObject(daoCar);
			BeginTransaction("addCar");
			try
			{
				daoCar.CarId = boCar.CarId;
				daoCar.CarTypeId = boCar.CarTypeId;
				daoCar.BranchId = boCar.BranchId;
				daoCar.CarCode = boCar.CarCode;
				daoCar.CarNo = boCar.CarNo;
				daoCar.Model = boCar.Model;
				daoCar.YearManufactur = boCar.YearManufactur;
				daoCar.IsActive = boCar.IsActive;
				daoCar.Color = boCar.Color;
				daoCar.Icon = boCar.Icon;
				daoCar.DisplayOrder = boCar.DisplayOrder;
				daoCar.CanEdit = boCar.CanEdit;
				daoCar.CanDelete = boCar.CanDelete;
				daoCar.Latitude = boCar.Latitude;
				daoCar.Longitude = boCar.Longitude;
				daoCar.CBy = boCar.CBy;
				daoCar.CDate = boCar.CDate;
				daoCar.EBy = boCar.EBy;
				daoCar.EDate = boCar.EDate;
				daoCar.ManufacturerId = _manufacturerId.Value;
				daoCar.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boCar = new BOCar(daoCar);
				if(_boCarCollection != null)
					_boCarCollection.Add(boCar);
			}
			catch
			{
				RollbackTransaction("addCar");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllCar
		///This method deletes all BOCar objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllCar()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllCar");
			try
			{
				DAOCar.DeleteAllByManufacturerId(ConnectionProvider, _manufacturerId.Value);
				CommitTransaction();
				if(_boCarCollection != null)
				{
					_boCarCollection.Clear();
					_boCarCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllCar");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? ManufacturerId
		{
			get
			{
				 return _manufacturerId;
			}
			set
			{
				_manufacturerId = value;
				_isDirty = true;
			}
		}
		
		public virtual string ManufacturerCode
		{
			get
			{
				 return _manufacturerCode;
			}
			set
			{
				_manufacturerCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string ManufacturerNameEn
		{
			get
			{
				 return _manufacturerNameEn;
			}
			set
			{
				_manufacturerNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string ManufacturerNameAr
		{
			get
			{
				 return _manufacturerNameAr;
			}
			set
			{
				_manufacturerNameAr = value;
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
