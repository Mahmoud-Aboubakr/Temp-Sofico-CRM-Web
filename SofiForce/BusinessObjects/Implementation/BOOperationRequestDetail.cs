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
	///This is the definition of the class BOOperationRequestDetail.
	///It maintains a collection of BOOperationRequestDetailDocument,BOOperationRequestDetailLandmark,BOOperationRequestDetailPreferredTime objects.
	///</Summary>
	public partial class BOOperationRequestDetail : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int64? _detailId;
		protected Int32? _operationId;
		protected DateTime? _operationDate;
		protected Int32? _clientId;
		protected Int32? _clientTypeId;
		protected string _clientNameAr;
		protected string _clientNameEn;
		protected Int32? _regionId;
		protected Int32? _governerateId;
		protected Int32? _cityId;
		protected Int32? _locationLevelId;
		protected bool? _isChain;
		protected string _responsibleNameEn;
		protected string _responsibleNameAr;
		protected string _building;
		protected string _floor;
		protected string _property;
		protected string _address;
		protected string _landmark;
		protected string _phone;
		protected string _mobile;
		protected string _whatsApp;
		protected double? _latitude;
		protected double? _longitude;
		protected decimal? _accuracy;
		protected bool? _inZone;
		protected Int32? _operationStatusId;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		protected string _taxCode;
		protected string _commercialCode;
		protected Int32? _operationRejectReasonId;
		protected bool _isDirty = false;
		/*collection member objects*******************/
		List<BOOperationRequestDetailDocument> _boOperationRequestDetailDocumentCollection;
		List<BOOperationRequestDetailLandmark> _boOperationRequestDetailLandmarkCollection;
		List<BOOperationRequestDetailPreferredTime> _boOperationRequestDetailPreferredTimeCollection;
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
		public BOOperationRequestDetail()
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
		///Int64 detailId
		///</parameters>
		public BOOperationRequestDetail(Int64 detailId)
		{
			try
			{
				DAOOperationRequestDetail daoOperationRequestDetail = DAOOperationRequestDetail.SelectOne(detailId);
				_detailId = daoOperationRequestDetail.DetailId;
				_operationId = daoOperationRequestDetail.OperationId;
				_operationDate = daoOperationRequestDetail.OperationDate;
				_clientId = daoOperationRequestDetail.ClientId;
				_clientTypeId = daoOperationRequestDetail.ClientTypeId;
				_clientNameAr = daoOperationRequestDetail.ClientNameAr;
				_clientNameEn = daoOperationRequestDetail.ClientNameEn;
				_regionId = daoOperationRequestDetail.RegionId;
				_governerateId = daoOperationRequestDetail.GovernerateId;
				_cityId = daoOperationRequestDetail.CityId;
				_locationLevelId = daoOperationRequestDetail.LocationLevelId;
				_isChain = daoOperationRequestDetail.IsChain;
				_responsibleNameEn = daoOperationRequestDetail.ResponsibleNameEn;
				_responsibleNameAr = daoOperationRequestDetail.ResponsibleNameAr;
				_building = daoOperationRequestDetail.Building;
				_floor = daoOperationRequestDetail.Floor;
				_property = daoOperationRequestDetail.Property;
				_address = daoOperationRequestDetail.Address;
				_landmark = daoOperationRequestDetail.Landmark;
				_phone = daoOperationRequestDetail.Phone;
				_mobile = daoOperationRequestDetail.Mobile;
				_whatsApp = daoOperationRequestDetail.WhatsApp;
				_latitude = daoOperationRequestDetail.Latitude;
				_longitude = daoOperationRequestDetail.Longitude;
				_accuracy = daoOperationRequestDetail.Accuracy;
				_inZone = daoOperationRequestDetail.InZone;
				_operationStatusId = daoOperationRequestDetail.OperationStatusId;
				_cBy = daoOperationRequestDetail.CBy;
				_cDate = daoOperationRequestDetail.CDate;
				_eBy = daoOperationRequestDetail.EBy;
				_eDate = daoOperationRequestDetail.EDate;
				_taxCode = daoOperationRequestDetail.TaxCode;
				_commercialCode = daoOperationRequestDetail.CommercialCode;
				_operationRejectReasonId = daoOperationRequestDetail.OperationRejectReasonId;
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
		///DAOOperationRequestDetail
		///</parameters>
		protected internal BOOperationRequestDetail(DAOOperationRequestDetail daoOperationRequestDetail)
		{
			try
			{
				_detailId = daoOperationRequestDetail.DetailId;
				_operationId = daoOperationRequestDetail.OperationId;
				_operationDate = daoOperationRequestDetail.OperationDate;
				_clientId = daoOperationRequestDetail.ClientId;
				_clientTypeId = daoOperationRequestDetail.ClientTypeId;
				_clientNameAr = daoOperationRequestDetail.ClientNameAr;
				_clientNameEn = daoOperationRequestDetail.ClientNameEn;
				_regionId = daoOperationRequestDetail.RegionId;
				_governerateId = daoOperationRequestDetail.GovernerateId;
				_cityId = daoOperationRequestDetail.CityId;
				_locationLevelId = daoOperationRequestDetail.LocationLevelId;
				_isChain = daoOperationRequestDetail.IsChain;
				_responsibleNameEn = daoOperationRequestDetail.ResponsibleNameEn;
				_responsibleNameAr = daoOperationRequestDetail.ResponsibleNameAr;
				_building = daoOperationRequestDetail.Building;
				_floor = daoOperationRequestDetail.Floor;
				_property = daoOperationRequestDetail.Property;
				_address = daoOperationRequestDetail.Address;
				_landmark = daoOperationRequestDetail.Landmark;
				_phone = daoOperationRequestDetail.Phone;
				_mobile = daoOperationRequestDetail.Mobile;
				_whatsApp = daoOperationRequestDetail.WhatsApp;
				_latitude = daoOperationRequestDetail.Latitude;
				_longitude = daoOperationRequestDetail.Longitude;
				_accuracy = daoOperationRequestDetail.Accuracy;
				_inZone = daoOperationRequestDetail.InZone;
				_operationStatusId = daoOperationRequestDetail.OperationStatusId;
				_cBy = daoOperationRequestDetail.CBy;
				_cDate = daoOperationRequestDetail.CDate;
				_eBy = daoOperationRequestDetail.EBy;
				_eDate = daoOperationRequestDetail.EDate;
				_taxCode = daoOperationRequestDetail.TaxCode;
				_commercialCode = daoOperationRequestDetail.CommercialCode;
				_operationRejectReasonId = daoOperationRequestDetail.OperationRejectReasonId;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new OperationRequestDetail record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOOperationRequestDetail daoOperationRequestDetail = new DAOOperationRequestDetail();
			RegisterDataObject(daoOperationRequestDetail);
			BeginTransaction("savenewBOOperationRequestDetail");
			try
			{
				daoOperationRequestDetail.OperationId = _operationId;
				daoOperationRequestDetail.OperationDate = _operationDate;
				daoOperationRequestDetail.ClientId = _clientId;
				daoOperationRequestDetail.ClientTypeId = _clientTypeId;
				daoOperationRequestDetail.ClientNameAr = _clientNameAr;
				daoOperationRequestDetail.ClientNameEn = _clientNameEn;
				daoOperationRequestDetail.RegionId = _regionId;
				daoOperationRequestDetail.GovernerateId = _governerateId;
				daoOperationRequestDetail.CityId = _cityId;
				daoOperationRequestDetail.LocationLevelId = _locationLevelId;
				daoOperationRequestDetail.IsChain = _isChain;
				daoOperationRequestDetail.ResponsibleNameEn = _responsibleNameEn;
				daoOperationRequestDetail.ResponsibleNameAr = _responsibleNameAr;
				daoOperationRequestDetail.Building = _building;
				daoOperationRequestDetail.Floor = _floor;
				daoOperationRequestDetail.Property = _property;
				daoOperationRequestDetail.Address = _address;
				daoOperationRequestDetail.Landmark = _landmark;
				daoOperationRequestDetail.Phone = _phone;
				daoOperationRequestDetail.Mobile = _mobile;
				daoOperationRequestDetail.WhatsApp = _whatsApp;
				daoOperationRequestDetail.Latitude = _latitude;
				daoOperationRequestDetail.Longitude = _longitude;
				daoOperationRequestDetail.Accuracy = _accuracy;
				daoOperationRequestDetail.InZone = _inZone;
				daoOperationRequestDetail.OperationStatusId = _operationStatusId;
				daoOperationRequestDetail.CBy = _cBy;
				daoOperationRequestDetail.CDate = _cDate;
				daoOperationRequestDetail.EBy = _eBy;
				daoOperationRequestDetail.EDate = _eDate;
				daoOperationRequestDetail.TaxCode = _taxCode;
				daoOperationRequestDetail.CommercialCode = _commercialCode;
				daoOperationRequestDetail.OperationRejectReasonId = _operationRejectReasonId;
				daoOperationRequestDetail.Insert();
				CommitTransaction();
				
				_detailId = daoOperationRequestDetail.DetailId;
				_operationId = daoOperationRequestDetail.OperationId;
				_operationDate = daoOperationRequestDetail.OperationDate;
				_clientId = daoOperationRequestDetail.ClientId;
				_clientTypeId = daoOperationRequestDetail.ClientTypeId;
				_clientNameAr = daoOperationRequestDetail.ClientNameAr;
				_clientNameEn = daoOperationRequestDetail.ClientNameEn;
				_regionId = daoOperationRequestDetail.RegionId;
				_governerateId = daoOperationRequestDetail.GovernerateId;
				_cityId = daoOperationRequestDetail.CityId;
				_locationLevelId = daoOperationRequestDetail.LocationLevelId;
				_isChain = daoOperationRequestDetail.IsChain;
				_responsibleNameEn = daoOperationRequestDetail.ResponsibleNameEn;
				_responsibleNameAr = daoOperationRequestDetail.ResponsibleNameAr;
				_building = daoOperationRequestDetail.Building;
				_floor = daoOperationRequestDetail.Floor;
				_property = daoOperationRequestDetail.Property;
				_address = daoOperationRequestDetail.Address;
				_landmark = daoOperationRequestDetail.Landmark;
				_phone = daoOperationRequestDetail.Phone;
				_mobile = daoOperationRequestDetail.Mobile;
				_whatsApp = daoOperationRequestDetail.WhatsApp;
				_latitude = daoOperationRequestDetail.Latitude;
				_longitude = daoOperationRequestDetail.Longitude;
				_accuracy = daoOperationRequestDetail.Accuracy;
				_inZone = daoOperationRequestDetail.InZone;
				_operationStatusId = daoOperationRequestDetail.OperationStatusId;
				_cBy = daoOperationRequestDetail.CBy;
				_cDate = daoOperationRequestDetail.CDate;
				_eBy = daoOperationRequestDetail.EBy;
				_eDate = daoOperationRequestDetail.EDate;
				_taxCode = daoOperationRequestDetail.TaxCode;
				_commercialCode = daoOperationRequestDetail.CommercialCode;
				_operationRejectReasonId = daoOperationRequestDetail.OperationRejectReasonId;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOOperationRequestDetail");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one OperationRequestDetail record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOOperationRequestDetail
		///</parameters>
		public virtual void Update()
		{
			DAOOperationRequestDetail daoOperationRequestDetail = new DAOOperationRequestDetail();
			RegisterDataObject(daoOperationRequestDetail);
			BeginTransaction("updateBOOperationRequestDetail");
			try
			{
				daoOperationRequestDetail.DetailId = _detailId;
				daoOperationRequestDetail.OperationId = _operationId;
				daoOperationRequestDetail.OperationDate = _operationDate;
				daoOperationRequestDetail.ClientId = _clientId;
				daoOperationRequestDetail.ClientTypeId = _clientTypeId;
				daoOperationRequestDetail.ClientNameAr = _clientNameAr;
				daoOperationRequestDetail.ClientNameEn = _clientNameEn;
				daoOperationRequestDetail.RegionId = _regionId;
				daoOperationRequestDetail.GovernerateId = _governerateId;
				daoOperationRequestDetail.CityId = _cityId;
				daoOperationRequestDetail.LocationLevelId = _locationLevelId;
				daoOperationRequestDetail.IsChain = _isChain;
				daoOperationRequestDetail.ResponsibleNameEn = _responsibleNameEn;
				daoOperationRequestDetail.ResponsibleNameAr = _responsibleNameAr;
				daoOperationRequestDetail.Building = _building;
				daoOperationRequestDetail.Floor = _floor;
				daoOperationRequestDetail.Property = _property;
				daoOperationRequestDetail.Address = _address;
				daoOperationRequestDetail.Landmark = _landmark;
				daoOperationRequestDetail.Phone = _phone;
				daoOperationRequestDetail.Mobile = _mobile;
				daoOperationRequestDetail.WhatsApp = _whatsApp;
				daoOperationRequestDetail.Latitude = _latitude;
				daoOperationRequestDetail.Longitude = _longitude;
				daoOperationRequestDetail.Accuracy = _accuracy;
				daoOperationRequestDetail.InZone = _inZone;
				daoOperationRequestDetail.OperationStatusId = _operationStatusId;
				daoOperationRequestDetail.CBy = _cBy;
				daoOperationRequestDetail.CDate = _cDate;
				daoOperationRequestDetail.EBy = _eBy;
				daoOperationRequestDetail.EDate = _eDate;
				daoOperationRequestDetail.TaxCode = _taxCode;
				daoOperationRequestDetail.CommercialCode = _commercialCode;
				daoOperationRequestDetail.OperationRejectReasonId = _operationRejectReasonId;
				daoOperationRequestDetail.Update();
				CommitTransaction();
				
				_detailId = daoOperationRequestDetail.DetailId;
				_operationId = daoOperationRequestDetail.OperationId;
				_operationDate = daoOperationRequestDetail.OperationDate;
				_clientId = daoOperationRequestDetail.ClientId;
				_clientTypeId = daoOperationRequestDetail.ClientTypeId;
				_clientNameAr = daoOperationRequestDetail.ClientNameAr;
				_clientNameEn = daoOperationRequestDetail.ClientNameEn;
				_regionId = daoOperationRequestDetail.RegionId;
				_governerateId = daoOperationRequestDetail.GovernerateId;
				_cityId = daoOperationRequestDetail.CityId;
				_locationLevelId = daoOperationRequestDetail.LocationLevelId;
				_isChain = daoOperationRequestDetail.IsChain;
				_responsibleNameEn = daoOperationRequestDetail.ResponsibleNameEn;
				_responsibleNameAr = daoOperationRequestDetail.ResponsibleNameAr;
				_building = daoOperationRequestDetail.Building;
				_floor = daoOperationRequestDetail.Floor;
				_property = daoOperationRequestDetail.Property;
				_address = daoOperationRequestDetail.Address;
				_landmark = daoOperationRequestDetail.Landmark;
				_phone = daoOperationRequestDetail.Phone;
				_mobile = daoOperationRequestDetail.Mobile;
				_whatsApp = daoOperationRequestDetail.WhatsApp;
				_latitude = daoOperationRequestDetail.Latitude;
				_longitude = daoOperationRequestDetail.Longitude;
				_accuracy = daoOperationRequestDetail.Accuracy;
				_inZone = daoOperationRequestDetail.InZone;
				_operationStatusId = daoOperationRequestDetail.OperationStatusId;
				_cBy = daoOperationRequestDetail.CBy;
				_cDate = daoOperationRequestDetail.CDate;
				_eBy = daoOperationRequestDetail.EBy;
				_eDate = daoOperationRequestDetail.EDate;
				_taxCode = daoOperationRequestDetail.TaxCode;
				_commercialCode = daoOperationRequestDetail.CommercialCode;
				_operationRejectReasonId = daoOperationRequestDetail.OperationRejectReasonId;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOOperationRequestDetail");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one OperationRequestDetail record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOOperationRequestDetail daoOperationRequestDetail = new DAOOperationRequestDetail();
			RegisterDataObject(daoOperationRequestDetail);
			BeginTransaction("deleteBOOperationRequestDetail");
			try
			{
				daoOperationRequestDetail.DetailId = _detailId;
				daoOperationRequestDetail.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOOperationRequestDetail");
				throw;
			}
		}
		
		///<Summary>
		///OperationRequestDetailCollection
		///This method returns the collection of BOOperationRequestDetail objects
		///</Summary>
		///<returns>
		///List[BOOperationRequestDetail]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOOperationRequestDetail> OperationRequestDetailCollection()
		{
			try
			{
				IList<BOOperationRequestDetail> boOperationRequestDetailCollection = new List<BOOperationRequestDetail>();
				IList<DAOOperationRequestDetail> daoOperationRequestDetailCollection = DAOOperationRequestDetail.SelectAll();
			
				foreach(DAOOperationRequestDetail daoOperationRequestDetail in daoOperationRequestDetailCollection)
					boOperationRequestDetailCollection.Add(new BOOperationRequestDetail(daoOperationRequestDetail));
			
				return boOperationRequestDetailCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///OperationRequestDetailCollectionCount
		///This method returns the collection count of BOOperationRequestDetail objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 OperationRequestDetailCollectionCount()
		{
			try
			{
				Int32 objCount = DAOOperationRequestDetail.SelectAllCount();
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///OperationRequestDetailDocumentCollection
		///This method returns its collection of BOOperationRequestDetailDocument objects
		///</Summary>
		///<returns>
		///IList[BOOperationRequestDetailDocument]
		///</returns>
		///<parameters>
		///BOOperationRequestDetail
		///</parameters>
		public virtual IList<BOOperationRequestDetailDocument> OperationRequestDetailDocumentCollection()
		{
			try
			{
				if(_boOperationRequestDetailDocumentCollection == null)
					LoadOperationRequestDetailDocumentCollection();
				
				return _boOperationRequestDetailDocumentCollection.AsReadOnly();
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///OperationRequestDetailLandmarkCollection
		///This method returns its collection of BOOperationRequestDetailLandmark objects
		///</Summary>
		///<returns>
		///IList[BOOperationRequestDetailLandmark]
		///</returns>
		///<parameters>
		///BOOperationRequestDetail
		///</parameters>
		public virtual IList<BOOperationRequestDetailLandmark> OperationRequestDetailLandmarkCollection()
		{
			try
			{
				if(_boOperationRequestDetailLandmarkCollection == null)
					LoadOperationRequestDetailLandmarkCollection();
				
				return _boOperationRequestDetailLandmarkCollection.AsReadOnly();
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///OperationRequestDetailPreferredTimeCollection
		///This method returns its collection of BOOperationRequestDetailPreferredTime objects
		///</Summary>
		///<returns>
		///IList[BOOperationRequestDetailPreferredTime]
		///</returns>
		///<parameters>
		///BOOperationRequestDetail
		///</parameters>
		public virtual IList<BOOperationRequestDetailPreferredTime> OperationRequestDetailPreferredTimeCollection()
		{
			try
			{
				if(_boOperationRequestDetailPreferredTimeCollection == null)
					LoadOperationRequestDetailPreferredTimeCollection();
				
				return _boOperationRequestDetailPreferredTimeCollection.AsReadOnly();
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
		///List<BOOperationRequestDetail>
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
				IDictionary<string, IList<object>> retObj = DAOOperationRequestDetail.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///OperationRequestDetailCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOOperationRequestDetail objects, filtered by optional criteria
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
				IList<T> boOperationRequestDetailCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOOperationRequestDetail> daoOperationRequestDetailCollection = DAOOperationRequestDetail.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOOperationRequestDetail resdaoOperationRequestDetail in daoOperationRequestDetailCollection)
					boOperationRequestDetailCollection.Add((T)(object)new BOOperationRequestDetail(resdaoOperationRequestDetail));
			
				return boOperationRequestDetailCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///OperationRequestDetailCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOOperationRequestDetail objects, filtered by optional criteria
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
				Int32 objCount = DAOOperationRequestDetail.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///LoadOperationRequestDetailDocumentCollection
		///This method loads the internal collection of BOOperationRequestDetailDocument objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadOperationRequestDetailDocumentCollection()
		{
			try
			{
				_boOperationRequestDetailDocumentCollection = new List<BOOperationRequestDetailDocument>();
				IList<DAOOperationRequestDetailDocument> daoOperationRequestDetailDocumentCollection = DAOOperationRequestDetailDocument.SelectAllByDetailId(_detailId.Value);
				
				foreach(DAOOperationRequestDetailDocument daoOperationRequestDetailDocument in daoOperationRequestDetailDocumentCollection)
					_boOperationRequestDetailDocumentCollection.Add(new BOOperationRequestDetailDocument(daoOperationRequestDetailDocument));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddOperationRequestDetailDocument
		///This method persists a BOOperationRequestDetailDocument object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOOperationRequestDetailDocument
		///</parameters>
		public virtual void AddOperationRequestDetailDocument(BOOperationRequestDetailDocument boOperationRequestDetailDocument)
		{
			DAOOperationRequestDetailDocument daoOperationRequestDetailDocument = new DAOOperationRequestDetailDocument();
			RegisterDataObject(daoOperationRequestDetailDocument);
			BeginTransaction("addOperationRequestDetailDoc5401");
			try
			{
				daoOperationRequestDetailDocument.DetailDocumentId = boOperationRequestDetailDocument.DetailDocumentId;
				daoOperationRequestDetailDocument.DocumentTypeId = boOperationRequestDetailDocument.DocumentTypeId;
				daoOperationRequestDetailDocument.DocumentPath = boOperationRequestDetailDocument.DocumentPath;
				daoOperationRequestDetailDocument.UploadDate = boOperationRequestDetailDocument.UploadDate;
				daoOperationRequestDetailDocument.DocumentExt = boOperationRequestDetailDocument.DocumentExt;
				daoOperationRequestDetailDocument.DocumentSize = boOperationRequestDetailDocument.DocumentSize;
				daoOperationRequestDetailDocument.DetailId = _detailId.Value;
				daoOperationRequestDetailDocument.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boOperationRequestDetailDocument = new BOOperationRequestDetailDocument(daoOperationRequestDetailDocument);
				if(_boOperationRequestDetailDocumentCollection != null)
					_boOperationRequestDetailDocumentCollection.Add(boOperationRequestDetailDocument);
			}
			catch
			{
				RollbackTransaction("addOperationRequestDetailDoc5401");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllOperationRequestDetailDocument
		///This method deletes all BOOperationRequestDetailDocument objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllOperationRequestDetailDocument()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllOperationRequestDet5401");
			try
			{
				DAOOperationRequestDetailDocument.DeleteAllByDetailId(ConnectionProvider, _detailId.Value);
				CommitTransaction();
				if(_boOperationRequestDetailDocumentCollection != null)
				{
					_boOperationRequestDetailDocumentCollection.Clear();
					_boOperationRequestDetailDocumentCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllOperationRequestDet5401");
				throw;
			}
		}
		
		///<Summary>
		///LoadOperationRequestDetailLandmarkCollection
		///This method loads the internal collection of BOOperationRequestDetailLandmark objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadOperationRequestDetailLandmarkCollection()
		{
			try
			{
				_boOperationRequestDetailLandmarkCollection = new List<BOOperationRequestDetailLandmark>();
				IList<DAOOperationRequestDetailLandmark> daoOperationRequestDetailLandmarkCollection = DAOOperationRequestDetailLandmark.SelectAllByDetailId(_detailId.Value);
				
				foreach(DAOOperationRequestDetailLandmark daoOperationRequestDetailLandmark in daoOperationRequestDetailLandmarkCollection)
					_boOperationRequestDetailLandmarkCollection.Add(new BOOperationRequestDetailLandmark(daoOperationRequestDetailLandmark));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddOperationRequestDetailLandmark
		///This method persists a BOOperationRequestDetailLandmark object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOOperationRequestDetailLandmark
		///</parameters>
		public virtual void AddOperationRequestDetailLandmark(BOOperationRequestDetailLandmark boOperationRequestDetailLandmark)
		{
			DAOOperationRequestDetailLandmark daoOperationRequestDetailLandmark = new DAOOperationRequestDetailLandmark();
			RegisterDataObject(daoOperationRequestDetailLandmark);
			BeginTransaction("addOperationRequestDetailLan5401");
			try
			{
				daoOperationRequestDetailLandmark.LandmarkId = boOperationRequestDetailLandmark.LandmarkId;
				daoOperationRequestDetailLandmark.DetaillandId = boOperationRequestDetailLandmark.DetaillandId;
				daoOperationRequestDetailLandmark.DetailId = _detailId.Value;
				daoOperationRequestDetailLandmark.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boOperationRequestDetailLandmark = new BOOperationRequestDetailLandmark(daoOperationRequestDetailLandmark);
				if(_boOperationRequestDetailLandmarkCollection != null)
					_boOperationRequestDetailLandmarkCollection.Add(boOperationRequestDetailLandmark);
			}
			catch
			{
				RollbackTransaction("addOperationRequestDetailLan5401");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllOperationRequestDetailLandmark
		///This method deletes all BOOperationRequestDetailLandmark objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllOperationRequestDetailLandmark()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllOperationRequestDet5401");
			try
			{
				DAOOperationRequestDetailLandmark.DeleteAllByDetailId(ConnectionProvider, _detailId.Value);
				CommitTransaction();
				if(_boOperationRequestDetailLandmarkCollection != null)
				{
					_boOperationRequestDetailLandmarkCollection.Clear();
					_boOperationRequestDetailLandmarkCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllOperationRequestDet5401");
				throw;
			}
		}
		
		///<Summary>
		///LoadOperationRequestDetailPreferredTimeCollection
		///This method loads the internal collection of BOOperationRequestDetailPreferredTime objects from storage. 
		///Call this if you need to ensure the collection is up-to-date (concurrency)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void LoadOperationRequestDetailPreferredTimeCollection()
		{
			try
			{
				_boOperationRequestDetailPreferredTimeCollection = new List<BOOperationRequestDetailPreferredTime>();
				IList<DAOOperationRequestDetailPreferredTime> daoOperationRequestDetailPreferredTimeCollection = DAOOperationRequestDetailPreferredTime.SelectAllByDetailId(_detailId.Value);
				
				foreach(DAOOperationRequestDetailPreferredTime daoOperationRequestDetailPreferredTime in daoOperationRequestDetailPreferredTimeCollection)
					_boOperationRequestDetailPreferredTimeCollection.Add(new BOOperationRequestDetailPreferredTime(daoOperationRequestDetailPreferredTime));
			}
			catch
			{
				throw;
			}
		}
		
		///<Summary>
		///AddOperationRequestDetailPreferredTime
		///This method persists a BOOperationRequestDetailPreferredTime object to the database collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOOperationRequestDetailPreferredTime
		///</parameters>
		public virtual void AddOperationRequestDetailPreferredTime(BOOperationRequestDetailPreferredTime boOperationRequestDetailPreferredTime)
		{
			DAOOperationRequestDetailPreferredTime daoOperationRequestDetailPreferredTime = new DAOOperationRequestDetailPreferredTime();
			RegisterDataObject(daoOperationRequestDetailPreferredTime);
			BeginTransaction("addOperationRequestDetailPre5401");
			try
			{
				daoOperationRequestDetailPreferredTime.PreferredId = boOperationRequestDetailPreferredTime.PreferredId;
				daoOperationRequestDetailPreferredTime.PreferredOperationId = boOperationRequestDetailPreferredTime.PreferredOperationId;
				daoOperationRequestDetailPreferredTime.WeekDayId = boOperationRequestDetailPreferredTime.WeekDayId;
				daoOperationRequestDetailPreferredTime.FromTime = boOperationRequestDetailPreferredTime.FromTime;
				daoOperationRequestDetailPreferredTime.ToTime = boOperationRequestDetailPreferredTime.ToTime;
				daoOperationRequestDetailPreferredTime.DetailId = _detailId.Value;
				daoOperationRequestDetailPreferredTime.Insert();
				CommitTransaction();
				
				/*pick up any primary keys, computed values etc*/
				boOperationRequestDetailPreferredTime = new BOOperationRequestDetailPreferredTime(daoOperationRequestDetailPreferredTime);
				if(_boOperationRequestDetailPreferredTimeCollection != null)
					_boOperationRequestDetailPreferredTimeCollection.Add(boOperationRequestDetailPreferredTime);
			}
			catch
			{
				RollbackTransaction("addOperationRequestDetailPre5401");
				throw;
			}
		}
		
		///<Summary>
		///DeleteAllOperationRequestDetailPreferredTime
		///This method deletes all BOOperationRequestDetailPreferredTime objects from its collection
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void DeleteAllOperationRequestDetailPreferredTime()
		{
			RegisterDataObject(null);
			BeginTransaction("deleteAllOperationRequestDet626");
			try
			{
				DAOOperationRequestDetailPreferredTime.DeleteAllByDetailId(ConnectionProvider, _detailId.Value);
				CommitTransaction();
				if(_boOperationRequestDetailPreferredTimeCollection != null)
				{
					_boOperationRequestDetailPreferredTimeCollection.Clear();
					_boOperationRequestDetailPreferredTimeCollection = null;
				}
			}
			catch
			{
				RollbackTransaction("deleteAllOperationRequestDet626");
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
