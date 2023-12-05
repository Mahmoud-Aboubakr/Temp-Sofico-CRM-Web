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
	///This is the definition of the class BOClientAddress.
	///</Summary>
	public partial class BOClientAddress : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _addressId;
		protected Int32? _clientId;
		protected bool? _isDefault;
		protected Int32? _governerateId;
		protected Int32? _cityId;
		protected string _address;
		protected string _landmark;
		protected string _building;
		protected string _floor;
		protected string _property;
		protected string _email;
		protected string _phone;
		protected double? _lat;
		protected double? _lng;
		protected bool? _needValidation;
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
		public BOClientAddress()
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
		///Int32 addressId
		///</parameters>
		public BOClientAddress(Int32 addressId)
		{
			try
			{
				DAOClientAddress daoClientAddress = DAOClientAddress.SelectOne(addressId);
				_addressId = daoClientAddress.AddressId;
				_clientId = daoClientAddress.ClientId;
				_isDefault = daoClientAddress.IsDefault;
				_governerateId = daoClientAddress.GovernerateId;
				_cityId = daoClientAddress.CityId;
				_address = daoClientAddress.Address;
				_landmark = daoClientAddress.Landmark;
				_building = daoClientAddress.Building;
				_floor = daoClientAddress.Floor;
				_property = daoClientAddress.Property;
				_email = daoClientAddress.Email;
				_phone = daoClientAddress.Phone;
				_lat = daoClientAddress.Lat;
				_lng = daoClientAddress.Lng;
				_needValidation = daoClientAddress.NeedValidation;
				_cBy = daoClientAddress.CBy;
				_cDate = daoClientAddress.CDate;
				_eBy = daoClientAddress.EBy;
				_eDate = daoClientAddress.EDate;
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
		///DAOClientAddress
		///</parameters>
		protected internal BOClientAddress(DAOClientAddress daoClientAddress)
		{
			try
			{
				_addressId = daoClientAddress.AddressId;
				_clientId = daoClientAddress.ClientId;
				_isDefault = daoClientAddress.IsDefault;
				_governerateId = daoClientAddress.GovernerateId;
				_cityId = daoClientAddress.CityId;
				_address = daoClientAddress.Address;
				_landmark = daoClientAddress.Landmark;
				_building = daoClientAddress.Building;
				_floor = daoClientAddress.Floor;
				_property = daoClientAddress.Property;
				_email = daoClientAddress.Email;
				_phone = daoClientAddress.Phone;
				_lat = daoClientAddress.Lat;
				_lng = daoClientAddress.Lng;
				_needValidation = daoClientAddress.NeedValidation;
				_cBy = daoClientAddress.CBy;
				_cDate = daoClientAddress.CDate;
				_eBy = daoClientAddress.EBy;
				_eDate = daoClientAddress.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new ClientAddress record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOClientAddress daoClientAddress = new DAOClientAddress();
			RegisterDataObject(daoClientAddress);
			BeginTransaction("savenewBOClientAddress");
			try
			{
				daoClientAddress.ClientId = _clientId;
				daoClientAddress.IsDefault = _isDefault;
				daoClientAddress.GovernerateId = _governerateId;
				daoClientAddress.CityId = _cityId;
				daoClientAddress.Address = _address;
				daoClientAddress.Landmark = _landmark;
				daoClientAddress.Building = _building;
				daoClientAddress.Floor = _floor;
				daoClientAddress.Property = _property;
				daoClientAddress.Email = _email;
				daoClientAddress.Phone = _phone;
				daoClientAddress.Lat = _lat;
				daoClientAddress.Lng = _lng;
				daoClientAddress.NeedValidation = _needValidation;
				daoClientAddress.CBy = _cBy;
				daoClientAddress.CDate = _cDate;
				daoClientAddress.EBy = _eBy;
				daoClientAddress.EDate = _eDate;
				daoClientAddress.Insert();
				CommitTransaction();
				
				_addressId = daoClientAddress.AddressId;
				_clientId = daoClientAddress.ClientId;
				_isDefault = daoClientAddress.IsDefault;
				_governerateId = daoClientAddress.GovernerateId;
				_cityId = daoClientAddress.CityId;
				_address = daoClientAddress.Address;
				_landmark = daoClientAddress.Landmark;
				_building = daoClientAddress.Building;
				_floor = daoClientAddress.Floor;
				_property = daoClientAddress.Property;
				_email = daoClientAddress.Email;
				_phone = daoClientAddress.Phone;
				_lat = daoClientAddress.Lat;
				_lng = daoClientAddress.Lng;
				_needValidation = daoClientAddress.NeedValidation;
				_cBy = daoClientAddress.CBy;
				_cDate = daoClientAddress.CDate;
				_eBy = daoClientAddress.EBy;
				_eDate = daoClientAddress.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOClientAddress");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one ClientAddress record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOClientAddress
		///</parameters>
		public virtual void Update()
		{
			DAOClientAddress daoClientAddress = new DAOClientAddress();
			RegisterDataObject(daoClientAddress);
			BeginTransaction("updateBOClientAddress");
			try
			{
				daoClientAddress.AddressId = _addressId;
				daoClientAddress.ClientId = _clientId;
				daoClientAddress.IsDefault = _isDefault;
				daoClientAddress.GovernerateId = _governerateId;
				daoClientAddress.CityId = _cityId;
				daoClientAddress.Address = _address;
				daoClientAddress.Landmark = _landmark;
				daoClientAddress.Building = _building;
				daoClientAddress.Floor = _floor;
				daoClientAddress.Property = _property;
				daoClientAddress.Email = _email;
				daoClientAddress.Phone = _phone;
				daoClientAddress.Lat = _lat;
				daoClientAddress.Lng = _lng;
				daoClientAddress.NeedValidation = _needValidation;
				daoClientAddress.CBy = _cBy;
				daoClientAddress.CDate = _cDate;
				daoClientAddress.EBy = _eBy;
				daoClientAddress.EDate = _eDate;
				daoClientAddress.Update();
				CommitTransaction();
				
				_addressId = daoClientAddress.AddressId;
				_clientId = daoClientAddress.ClientId;
				_isDefault = daoClientAddress.IsDefault;
				_governerateId = daoClientAddress.GovernerateId;
				_cityId = daoClientAddress.CityId;
				_address = daoClientAddress.Address;
				_landmark = daoClientAddress.Landmark;
				_building = daoClientAddress.Building;
				_floor = daoClientAddress.Floor;
				_property = daoClientAddress.Property;
				_email = daoClientAddress.Email;
				_phone = daoClientAddress.Phone;
				_lat = daoClientAddress.Lat;
				_lng = daoClientAddress.Lng;
				_needValidation = daoClientAddress.NeedValidation;
				_cBy = daoClientAddress.CBy;
				_cDate = daoClientAddress.CDate;
				_eBy = daoClientAddress.EBy;
				_eDate = daoClientAddress.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOClientAddress");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one ClientAddress record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOClientAddress daoClientAddress = new DAOClientAddress();
			RegisterDataObject(daoClientAddress);
			BeginTransaction("deleteBOClientAddress");
			try
			{
				daoClientAddress.AddressId = _addressId;
				daoClientAddress.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOClientAddress");
				throw;
			}
		}
		
		///<Summary>
		///ClientAddressCollection
		///This method returns the collection of BOClientAddress objects
		///</Summary>
		///<returns>
		///List[BOClientAddress]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOClientAddress> ClientAddressCollection()
		{
			try
			{
				IList<BOClientAddress> boClientAddressCollection = new List<BOClientAddress>();
				IList<DAOClientAddress> daoClientAddressCollection = DAOClientAddress.SelectAll();
			
				foreach(DAOClientAddress daoClientAddress in daoClientAddressCollection)
					boClientAddressCollection.Add(new BOClientAddress(daoClientAddress));
			
				return boClientAddressCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientAddressCollectionCount
		///This method returns the collection count of BOClientAddress objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ClientAddressCollectionCount()
		{
			try
			{
				Int32 objCount = DAOClientAddress.SelectAllCount();
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
		///List<BOClientAddress>
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
				IDictionary<string, IList<object>> retObj = DAOClientAddress.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientAddressCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOClientAddress objects, filtered by optional criteria
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
				IList<T> boClientAddressCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOClientAddress> daoClientAddressCollection = DAOClientAddress.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOClientAddress resdaoClientAddress in daoClientAddressCollection)
					boClientAddressCollection.Add((T)(object)new BOClientAddress(resdaoClientAddress));
			
				return boClientAddressCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientAddressCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOClientAddress objects, filtered by optional criteria
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
				Int32 objCount = DAOClientAddress.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? AddressId
		{
			get
			{
				 return _addressId;
			}
			set
			{
				_addressId = value;
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
		
		public virtual bool? IsDefault
		{
			get
			{
				 return _isDefault;
			}
			set
			{
				_isDefault = value;
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
		
		public virtual string Address
		{
			get
			{
				 return _address;
			}
			set
			{
				_address = value;
				_isDirty = true;
			}
		}
		
		public virtual string Landmark
		{
			get
			{
				 return _landmark;
			}
			set
			{
				_landmark = value;
				_isDirty = true;
			}
		}
		
		public virtual string Building
		{
			get
			{
				 return _building;
			}
			set
			{
				_building = value;
				_isDirty = true;
			}
		}
		
		public virtual string Floor
		{
			get
			{
				 return _floor;
			}
			set
			{
				_floor = value;
				_isDirty = true;
			}
		}
		
		public virtual string Property
		{
			get
			{
				 return _property;
			}
			set
			{
				_property = value;
				_isDirty = true;
			}
		}
		
		public virtual string Email
		{
			get
			{
				 return _email;
			}
			set
			{
				_email = value;
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
		
		public virtual double? Lat
		{
			get
			{
				 return _lat;
			}
			set
			{
				_lat = value;
				_isDirty = true;
			}
		}
		
		public virtual double? Lng
		{
			get
			{
				 return _lng;
			}
			set
			{
				_lng = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? NeedValidation
		{
			get
			{
				 return _needValidation;
			}
			set
			{
				_needValidation = value;
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
