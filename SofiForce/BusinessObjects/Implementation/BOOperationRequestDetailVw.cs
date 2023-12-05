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
	///This is the definition of the class BOOperationRequestDetailVw.
	///</Summary>
	public partial class BOOperationRequestDetailVw : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int64? _detailId;
		protected Int32? _operationId;
		protected Int32? _clientId;
		protected Int32? _clientTypeId;
		protected string _clientNameAr;
		protected string _clientNameEn;
		protected Int32? _regionId;
		protected Int32? _governerateId;
		protected Int32? _cityId;
		protected Int32? _locationLevelId;
		protected bool? _isChain;
		protected string _building;
		protected string _floor;
		protected string _property;
		protected string _landmark;
		protected string _address;
		protected string _phone;
		protected string _mobile;
		protected string _whatsApp;
		protected double? _latitude;
		protected double? _longitude;
		protected Int32? _operationStatusId;
		protected string _clientCode;
		protected string _governerateNameEn;
		protected string _governerateNameAr;
		protected string _cityNameAr;
		protected string _cityNameEn;
		protected string _locationLevelNameEn;
		protected string _locationLevelNameAr;
		protected string _operationStatusNameEn;
		protected string _operationStatusNameAr;
		protected DateTime? _operationDate;
		protected decimal? _accuracy;
		protected string _responsibleNameAr;
		protected string _responsibleNameEn;
		protected bool? _inZone;
		protected string _clientTypeNameEn;
		protected string _clientTypeNameAr;
		protected string _taxCode;
		protected string _commercialCode;
		protected Int32? _operationRejectReasonId;
		protected Int32? _representativeId;
		protected Int32? _operationTypeId;
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
		public BOOperationRequestDetailVw()
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
		///DAOOperationRequestDetailVw
		///</parameters>
		protected internal BOOperationRequestDetailVw(DAOOperationRequestDetailVw daoOperationRequestDetailVw)
		{
			try
			{
				_detailId = daoOperationRequestDetailVw.DetailId;
				_operationId = daoOperationRequestDetailVw.OperationId;
				_clientId = daoOperationRequestDetailVw.ClientId;
				_clientTypeId = daoOperationRequestDetailVw.ClientTypeId;
				_clientNameAr = daoOperationRequestDetailVw.ClientNameAr;
				_clientNameEn = daoOperationRequestDetailVw.ClientNameEn;
				_regionId = daoOperationRequestDetailVw.RegionId;
				_governerateId = daoOperationRequestDetailVw.GovernerateId;
				_cityId = daoOperationRequestDetailVw.CityId;
				_locationLevelId = daoOperationRequestDetailVw.LocationLevelId;
				_isChain = daoOperationRequestDetailVw.IsChain;
				_building = daoOperationRequestDetailVw.Building;
				_floor = daoOperationRequestDetailVw.Floor;
				_property = daoOperationRequestDetailVw.Property;
				_landmark = daoOperationRequestDetailVw.Landmark;
				_address = daoOperationRequestDetailVw.Address;
				_phone = daoOperationRequestDetailVw.Phone;
				_mobile = daoOperationRequestDetailVw.Mobile;
				_whatsApp = daoOperationRequestDetailVw.WhatsApp;
				_latitude = daoOperationRequestDetailVw.Latitude;
				_longitude = daoOperationRequestDetailVw.Longitude;
				_operationStatusId = daoOperationRequestDetailVw.OperationStatusId;
				_clientCode = daoOperationRequestDetailVw.ClientCode;
				_governerateNameEn = daoOperationRequestDetailVw.GovernerateNameEn;
				_governerateNameAr = daoOperationRequestDetailVw.GovernerateNameAr;
				_cityNameAr = daoOperationRequestDetailVw.CityNameAr;
				_cityNameEn = daoOperationRequestDetailVw.CityNameEn;
				_locationLevelNameEn = daoOperationRequestDetailVw.LocationLevelNameEn;
				_locationLevelNameAr = daoOperationRequestDetailVw.LocationLevelNameAr;
				_operationStatusNameEn = daoOperationRequestDetailVw.OperationStatusNameEn;
				_operationStatusNameAr = daoOperationRequestDetailVw.OperationStatusNameAr;
				_operationDate = daoOperationRequestDetailVw.OperationDate;
				_accuracy = daoOperationRequestDetailVw.Accuracy;
				_responsibleNameAr = daoOperationRequestDetailVw.ResponsibleNameAr;
				_responsibleNameEn = daoOperationRequestDetailVw.ResponsibleNameEn;
				_inZone = daoOperationRequestDetailVw.InZone;
				_clientTypeNameEn = daoOperationRequestDetailVw.ClientTypeNameEn;
				_clientTypeNameAr = daoOperationRequestDetailVw.ClientTypeNameAr;
				_taxCode = daoOperationRequestDetailVw.TaxCode;
				_commercialCode = daoOperationRequestDetailVw.CommercialCode;
				_operationRejectReasonId = daoOperationRequestDetailVw.OperationRejectReasonId;
				_representativeId = daoOperationRequestDetailVw.RepresentativeId;
				_operationTypeId = daoOperationRequestDetailVw.OperationTypeId;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///OperationRequestDetailVwCollection
		///This method returns the collection of BOOperationRequestDetailVw objects
		///</Summary>
		///<returns>
		///List[BOOperationRequestDetailVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOOperationRequestDetailVw> OperationRequestDetailVwCollection()
		{
			try
			{
				IList<BOOperationRequestDetailVw> boOperationRequestDetailVwCollection = new List<BOOperationRequestDetailVw>();
				IList<DAOOperationRequestDetailVw> daoOperationRequestDetailVwCollection = DAOOperationRequestDetailVw.SelectAll();
			
				foreach(DAOOperationRequestDetailVw daoOperationRequestDetailVw in daoOperationRequestDetailVwCollection)
					boOperationRequestDetailVwCollection.Add(new BOOperationRequestDetailVw(daoOperationRequestDetailVw));
			
				return boOperationRequestDetailVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///OperationRequestDetailVwCollectionCount
		///This method returns the collection count of BOOperationRequestDetailVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 OperationRequestDetailVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOOperationRequestDetailVw.SelectAllCount();
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
		///List<BOOperationRequestDetailVw>
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
				IDictionary<string, IList<object>> retObj = DAOOperationRequestDetailVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///OperationRequestDetailVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOOperationRequestDetailVw objects, filtered by optional criteria
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
				IList<T> boOperationRequestDetailVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOOperationRequestDetailVw> daoOperationRequestDetailVwCollection = DAOOperationRequestDetailVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOOperationRequestDetailVw resdaoOperationRequestDetailVw in daoOperationRequestDetailVwCollection)
					boOperationRequestDetailVwCollection.Add((T)(object)new BOOperationRequestDetailVw(resdaoOperationRequestDetailVw));
			
				return boOperationRequestDetailVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///OperationRequestDetailVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOOperationRequestDetailVw objects, filtered by optional criteria
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
				Int32 objCount = DAOOperationRequestDetailVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int64? DetailId
		{
			get
			{
				 return _detailId;
			}
			set
			{
				_detailId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? OperationId
		{
			get
			{
				 return _operationId;
			}
			set
			{
				_operationId = value;
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
		
		public virtual Int32? LocationLevelId
		{
			get
			{
				 return _locationLevelId;
			}
			set
			{
				_locationLevelId = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? IsChain
		{
			get
			{
				 return _isChain;
			}
			set
			{
				_isChain = value;
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
		
		public virtual Int32? OperationStatusId
		{
			get
			{
				 return _operationStatusId;
			}
			set
			{
				_operationStatusId = value;
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
		
		public virtual string LocationLevelNameEn
		{
			get
			{
				 return _locationLevelNameEn;
			}
			set
			{
				_locationLevelNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string LocationLevelNameAr
		{
			get
			{
				 return _locationLevelNameAr;
			}
			set
			{
				_locationLevelNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string OperationStatusNameEn
		{
			get
			{
				 return _operationStatusNameEn;
			}
			set
			{
				_operationStatusNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string OperationStatusNameAr
		{
			get
			{
				 return _operationStatusNameAr;
			}
			set
			{
				_operationStatusNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? OperationDate
		{
			get
			{
				 return _operationDate;
			}
			set
			{
				_operationDate = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? Accuracy
		{
			get
			{
				 return _accuracy;
			}
			set
			{
				_accuracy = value;
				_isDirty = true;
			}
		}
		
		public virtual string ResponsibleNameAr
		{
			get
			{
				 return _responsibleNameAr;
			}
			set
			{
				_responsibleNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string ResponsibleNameEn
		{
			get
			{
				 return _responsibleNameEn;
			}
			set
			{
				_responsibleNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? InZone
		{
			get
			{
				 return _inZone;
			}
			set
			{
				_inZone = value;
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
		
		public virtual string TaxCode
		{
			get
			{
				 return _taxCode;
			}
			set
			{
				_taxCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string CommercialCode
		{
			get
			{
				 return _commercialCode;
			}
			set
			{
				_commercialCode = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? OperationRejectReasonId
		{
			get
			{
				 return _operationRejectReasonId;
			}
			set
			{
				_operationRejectReasonId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? RepresentativeId
		{
			get
			{
				 return _representativeId;
			}
			set
			{
				_representativeId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? OperationTypeId
		{
			get
			{
				 return _operationTypeId;
			}
			set
			{
				_operationTypeId = value;
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
