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
	///This is the definition of the class BOCar.
	///It maintains a collection of BOSalesOrderDispatch objects.
	///</Summary>
	public partial class BOCar : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _carId;
		protected Int32? _carTypeId;
		protected Int32? _branchId;
		protected string _carCode;
		protected string _carNo;
		protected string _model;
		protected Int32? _manufacturerId;
		protected Int32? _yearManufactur;
		protected bool? _isActive;
		protected string _color;
		protected string _icon;
		protected Int32? _displayOrder;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected double? _latitude;
		protected double? _longitude;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOSalesOrderDispatch> _boSalesOrderDispatchCollection;
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
		public BOCar()
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
		///Int32 carId
		///</parameters>
		public BOCar(Int32 carId)
		{
			try
			{
				DAOCar daoCar = DAOCar.SelectOne(carId);
				_carId = daoCar.CarId;
				_carTypeId = daoCar.CarTypeId;
				_branchId = daoCar.BranchId;
				_carCode = daoCar.CarCode;
				_carNo = daoCar.CarNo;
				_model = daoCar.Model;
				_manufacturerId = daoCar.ManufacturerId;
				_yearManufactur = daoCar.YearManufactur;
				_isActive = daoCar.IsActive;
				_color = daoCar.Color;
				_icon = daoCar.Icon;
				_displayOrder = daoCar.DisplayOrder;
				_canEdit = daoCar.CanEdit;
				_canDelete = daoCar.CanDelete;
				_latitude = daoCar.Latitude;
				_longitude = daoCar.Longitude;
				_cBy = daoCar.CBy;
				_cDate = daoCar.CDate;
				_eBy = daoCar.EBy;
				_eDate = daoCar.EDate;
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
		///DAOCar
		///</parameters>
		protected internal BOCar(DAOCar daoCar)
		{
			try
			{
				_carId = daoCar.CarId;
				_carTypeId = daoCar.CarTypeId;
				_branchId = daoCar.BranchId;
				_carCode = daoCar.CarCode;
				_carNo = daoCar.CarNo;
				_model = daoCar.Model;
				_manufacturerId = daoCar.ManufacturerId;
				_yearManufactur = daoCar.YearManufactur;
				_isActive = daoCar.IsActive;
				_color = daoCar.Color;
				_icon = daoCar.Icon;
				_displayOrder = daoCar.DisplayOrder;
				_canEdit = daoCar.CanEdit;
				_canDelete = daoCar.CanDelete;
				_latitude = daoCar.Latitude;
				_longitude = daoCar.Longitude;
				_cBy = daoCar.CBy;
				_cDate = daoCar.CDate;
				_eBy = daoCar.EBy;
				_eDate = daoCar.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new Car record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOCar daoCar = new DAOCar();
			RegisterDataObject(daoCar);
			BeginTransaction("savenewBOCar");
			try
			{
				daoCar.CarTypeId = _carTypeId;
				daoCar.BranchId = _branchId;
				daoCar.CarCode = _carCode;
				daoCar.CarNo = _carNo;
				daoCar.Model = _model;
				daoCar.ManufacturerId = _manufacturerId;
				daoCar.YearManufactur = _yearManufactur;
				daoCar.IsActive = _isActive;
				daoCar.Color = _color;
				daoCar.Icon = _icon;
				daoCar.DisplayOrder = _displayOrder;
				daoCar.CanEdit = _canEdit;
				daoCar.CanDelete = _canDelete;
				daoCar.Latitude = _latitude;
				daoCar.Longitude = _longitude;
				daoCar.CBy = _cBy;
				daoCar.CDate = _cDate;
				daoCar.EBy = _eBy;
				daoCar.EDate = _eDate;
				daoCar.Insert();
				CommitTransaction();
				
				_carId = daoCar.CarId;
				_carTypeId = daoCar.CarTypeId;
				_branchId = daoCar.BranchId;
				_carCode = daoCar.CarCode;
				_carNo = daoCar.CarNo;
				_model = daoCar.Model;
				_manufacturerId = daoCar.ManufacturerId;
				_yearManufactur = daoCar.YearManufactur;
				_isActive = daoCar.IsActive;
				_color = daoCar.Color;
				_icon = daoCar.Icon;
				_displayOrder = daoCar.DisplayOrder;
				_canEdit = daoCar.CanEdit;
				_canDelete = daoCar.CanDelete;
				_latitude = daoCar.Latitude;
				_longitude = daoCar.Longitude;
				_cBy = daoCar.CBy;
				_cDate = daoCar.CDate;
				_eBy = daoCar.EBy;
				_eDate = daoCar.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOCar");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one Car record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOCar
		///</parameters>
		public virtual void Update()
		{
			DAOCar daoCar = new DAOCar();
			RegisterDataObject(daoCar);
			BeginTransaction("updateBOCar");
			try
			{
				daoCar.CarId = _carId;
				daoCar.CarTypeId = _carTypeId;
				daoCar.BranchId = _branchId;
				daoCar.CarCode = _carCode;
				daoCar.CarNo = _carNo;
				daoCar.Model = _model;
				daoCar.ManufacturerId = _manufacturerId;
				daoCar.YearManufactur = _yearManufactur;
				daoCar.IsActive = _isActive;
				daoCar.Color = _color;
				daoCar.Icon = _icon;
				daoCar.DisplayOrder = _displayOrder;
				daoCar.CanEdit = _canEdit;
				daoCar.CanDelete = _canDelete;
				daoCar.Latitude = _latitude;
				daoCar.Longitude = _longitude;
				daoCar.CBy = _cBy;
				daoCar.CDate = _cDate;
				daoCar.EBy = _eBy;
				daoCar.EDate = _eDate;
				daoCar.Update();
				CommitTransaction();
				
				_carId = daoCar.CarId;
				_carTypeId = daoCar.CarTypeId;
				_branchId = daoCar.BranchId;
				_carCode = daoCar.CarCode;
				_carNo = daoCar.CarNo;
				_model = daoCar.Model;
				_manufacturerId = daoCar.ManufacturerId;
				_yearManufactur = daoCar.YearManufactur;
				_isActive = daoCar.IsActive;
				_color = daoCar.Color;
				_icon = daoCar.Icon;
				_displayOrder = daoCar.DisplayOrder;
				_canEdit = daoCar.CanEdit;
				_canDelete = daoCar.CanDelete;
				_latitude = daoCar.Latitude;
				_longitude = daoCar.Longitude;
				_cBy = daoCar.CBy;
				_cDate = daoCar.CDate;
				_eBy = daoCar.EBy;
				_eDate = daoCar.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOCar");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one Car record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOCar daoCar = new DAOCar();
			RegisterDataObject(daoCar);
			BeginTransaction("deleteBOCar");
			try
			{
				daoCar.CarId = _carId;
				daoCar.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOCar");
				throw;
			}
		}
		
		///<Summary>
		///CarCollection
		///This method returns the collection of BOCar objects
		///</Summary>
		///<returns>
		///List[BOCar]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOCar> CarCollection()
		{
			try
			{
				IList<BOCar> boCarCollection = new List<BOCar>();
				IList<DAOCar> daoCarCollection = DAOCar.SelectAll();
			
				foreach(DAOCar daoCar in daoCarCollection)
					boCarCollection.Add(new BOCar(daoCar));
			
				return boCarCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///CarCollectionCount
		///This method returns the collection count of BOCar objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 CarCollectionCount()
		{
			try
			{
				Int32 objCount = DAOCar.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///SalesOrderDispatchCollection
		///This method returns its collection of BOSalesOrderDispatch objects
		///</Summary>
		///<returns>
		///IList[BOSalesOrderDispatch]
		///</returns>
		///<parameters>
		///BOCar
		///</parameters>
		public virtual IList<BOSalesOrderDispatch> SalesOrderDispatchCollection()
		{
			try
			{
				if(_boSalesOrderDispatchCollection == null)
					LoadSalesOrderDispatchCollection();
				
				return _boSalesOrderDispatchCollection.AsReadOnly();
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
		///List<BOCar>
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
				IDictionary<string, IList<object>> retObj = DAOCar.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///CarCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOCar objects, filtered by optional criteria
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
				IList<T> boCarCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOCar> daoCarCollection = DAOCar.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOCar resdaoCar in daoCarCollection)
					boCarCollection.Add((T)(object)new BOCar(resdaoCar));
			
				return boCarCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///CarCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOCar objects, filtered by optional criteria
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
				Int32 objCount = DAOCar.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadSalesOrderDispatchCollection
		///This method loads the internal collection of BOSalesOrderDispatch objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadSalesOrderDispatchCollection()
		{
			try
			{
				_boSalesOrderDispatchCollection = new List<BOSalesOrderDispatch>();
				IList<DAOSalesOrderDispatch> daoSalesOrderDispatchCollection = DAOSalesOrderDispatch.SelectAllByCarId(_carId.Value);
				
				foreach(DAOSalesOrderDispatch daoSalesOrderDispatch in daoSalesOrderDispatchCollection)
					_boSalesOrderDispatchCollection.Add(new BOSalesOrderDispatch(daoSalesOrderDispatch));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddSalesOrderDispatch
		///This method persists a BOSalesOrderDispatch object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOSalesOrderDispatch
		///</parameters>
		public virtual void AddSalesOrderDispatch(BOSalesOrderDispatch boSalesOrderDispatch)
		{
			DAOSalesOrderDispatch daoSalesOrderDispatch = new DAOSalesOrderDispatch();
			RegisterDataObject(daoSalesOrderDispatch);
			BeginTransaction("addSalesOrderDispatch");
			try
			{
				daoSalesOrderDispatch.DispatchId = boSalesOrderDispatch.DispatchId;
				daoSalesOrderDispatch.SalesId = boSalesOrderDispatch.SalesId;
				daoSalesOrderDispatch.DispatchCode = boSalesOrderDispatch.DispatchCode;
				daoSalesOrderDispatch.DispatchDate = boSalesOrderDispatch.DispatchDate;
				daoSalesOrderDispatch.DispatchTime = boSalesOrderDispatch.DispatchTime;
				daoSalesOrderDispatch.ShiftDate = boSalesOrderDispatch.ShiftDate;
				daoSalesOrderDispatch.DistributorId = boSalesOrderDispatch.DistributorId;
				daoSalesOrderDispatch.DriverId = boSalesOrderDispatch.DriverId;
				daoSalesOrderDispatch.InZone = boSalesOrderDispatch.InZone;
				daoSalesOrderDispatch.Distance = boSalesOrderDispatch.Distance;
				daoSalesOrderDispatch.Latitude = boSalesOrderDispatch.Latitude;
				daoSalesOrderDispatch.Longitude = boSalesOrderDispatch.Longitude;
				daoSalesOrderDispatch.FeedbackId = boSalesOrderDispatch.FeedbackId;
				daoSalesOrderDispatch.Notes = boSalesOrderDispatch.Notes;
				daoSalesOrderDispatch.EBy = boSalesOrderDispatch.EBy;
				daoSalesOrderDispatch.EDate = boSalesOrderDispatch.EDate;
				daoSalesOrderDispatch.RejectReasonId = boSalesOrderDispatch.RejectReasonId;
				daoSalesOrderDispatch.RejectReasonNotes = boSalesOrderDispatch.RejectReasonNotes;
				daoSalesOrderDispatch.CarId = _carId.Value;
				daoSalesOrderDispatch.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boSalesOrderDispatch = new BOSalesOrderDispatch(daoSalesOrderDispatch);
				if(_boSalesOrderDispatchCollection != null)
					_boSalesOrderDispatchCollection.Add(boSalesOrderDispatch);
			}
			catch
			{
				RollbackTransaction("addSalesOrderDispatch");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllSalesOrderDispatch
		///This method deletes all BOSalesOrderDispatch objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllSalesOrderDispatch()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllSalesOrderDispatch");
			try
			{
				DAOSalesOrderDispatch.DeleteAllByCarId(ConnectionProvider, _carId.Value);
				CommitTransaction();
				if(_boSalesOrderDispatchCollection != null)
				{
					_boSalesOrderDispatchCollection.Clear();
					_boSalesOrderDispatchCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllSalesOrderDispatch");
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? CarId
		{
			get
			{
				 return _carId;
			}
			set
			{
				_carId = value;
				_isDirty = true;
			}
		}
		
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
		
		public virtual string CarCode
		{
			get
			{
				 return _carCode;
			}
			set
			{
				_carCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string CarNo
		{
			get
			{
				 return _carNo;
			}
			set
			{
				_carNo = value;
				_isDirty = true;
			}
		}
		
		public virtual string Model
		{
			get
			{
				 return _model;
			}
			set
			{
				_model = value;
				_isDirty = true;
			}
		}
		
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
		
		public virtual Int32? YearManufactur
		{
			get
			{
				 return _yearManufactur;
			}
			set
			{
				_yearManufactur = value;
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
		
		public virtual double? Latitude
		{
			get
			{
				 return _latitude;
			}
			set
			{
				_latitude = value;
				_isDirty = true;
			}
		}
		
		public virtual double? Longitude
		{
			get
			{
				 return _longitude;
			}
			set
			{
				_longitude = value;
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
