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
	///This is the definition of the class BOClientAddressVw.
	///</Summary>
	public partial class BOClientAddressVw : zSofiForceConn_BaseBusiness, IQueryableCollection
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
		protected double? _lng;
		protected double? _lat;
		protected bool? _needValidation;
		protected string _clientNameAr;
		protected string _clientNameEn;
		protected string _clientCode;
		protected string _governerateNameAr;
		protected string _governerateNameEn;
		protected string _cityNameAr;
		protected string _cityNameEn;
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
		public BOClientAddressVw()
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
		///DAOClientAddressVw
		///</parameters>
		protected internal BOClientAddressVw(DAOClientAddressVw daoClientAddressVw)
		{
			try
			{
				_addressId = daoClientAddressVw.AddressId;
				_clientId = daoClientAddressVw.ClientId;
				_isDefault = daoClientAddressVw.IsDefault;
				_governerateId = daoClientAddressVw.GovernerateId;
				_cityId = daoClientAddressVw.CityId;
				_address = daoClientAddressVw.Address;
				_landmark = daoClientAddressVw.Landmark;
				_building = daoClientAddressVw.Building;
				_floor = daoClientAddressVw.Floor;
				_property = daoClientAddressVw.Property;
				_email = daoClientAddressVw.Email;
				_phone = daoClientAddressVw.Phone;
				_lng = daoClientAddressVw.Lng;
				_lat = daoClientAddressVw.Lat;
				_needValidation = daoClientAddressVw.NeedValidation;
				_clientNameAr = daoClientAddressVw.ClientNameAr;
				_clientNameEn = daoClientAddressVw.ClientNameEn;
				_clientCode = daoClientAddressVw.ClientCode;
				_governerateNameAr = daoClientAddressVw.GovernerateNameAr;
				_governerateNameEn = daoClientAddressVw.GovernerateNameEn;
				_cityNameAr = daoClientAddressVw.CityNameAr;
				_cityNameEn = daoClientAddressVw.CityNameEn;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///ClientAddressVwCollection
		///This method returns the collection of BOClientAddressVw objects
		///</Summary>
		///<returns>
		///List[BOClientAddressVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOClientAddressVw> ClientAddressVwCollection()
		{
			try
			{
				IList<BOClientAddressVw> boClientAddressVwCollection = new List<BOClientAddressVw>();
				IList<DAOClientAddressVw> daoClientAddressVwCollection = DAOClientAddressVw.SelectAll();
			
				foreach(DAOClientAddressVw daoClientAddressVw in daoClientAddressVwCollection)
					boClientAddressVwCollection.Add(new BOClientAddressVw(daoClientAddressVw));
			
				return boClientAddressVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientAddressVwCollectionCount
		///This method returns the collection count of BOClientAddressVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ClientAddressVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOClientAddressVw.SelectAllCount();
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
		///List<BOClientAddressVw>
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
				IDictionary<string, IList<object>> retObj = DAOClientAddressVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientAddressVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOClientAddressVw objects, filtered by optional criteria
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
				IList<T> boClientAddressVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOClientAddressVw> daoClientAddressVwCollection = DAOClientAddressVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOClientAddressVw resdaoClientAddressVw in daoClientAddressVwCollection)
					boClientAddressVwCollection.Add((T)(object)new BOClientAddressVw(resdaoClientAddressVw));
			
				return boClientAddressVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientAddressVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOClientAddressVw objects, filtered by optional criteria
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
				Int32 objCount = DAOClientAddressVw.SelectAllByCriteriaCount(lstDataCriteria);
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
		
		public virtual string GovernerateNameAr
		{
			get
			{
				 return _governerateNameAr;
			}
			set
			{
				_governerateNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string GovernerateNameEn
		{
			get
			{
				 return _governerateNameEn;
			}
			set
			{
				_governerateNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string CityNameAr
		{
			get
			{
				 return _cityNameAr;
			}
			set
			{
				_cityNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string CityNameEn
		{
			get
			{
				 return _cityNameEn;
			}
			set
			{
				_cityNameEn = value;
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
