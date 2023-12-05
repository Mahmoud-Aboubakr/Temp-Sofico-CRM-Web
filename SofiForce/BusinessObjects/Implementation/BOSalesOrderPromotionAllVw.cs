/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 6/24/2023 12:51:36 PM
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
	///This is the definition of the class BOSalesOrderPromotionAllVw.
	///</Summary>
	public partial class BOSalesOrderPromotionAllVw : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected string _promotionCode;
		protected DateTime? _validFrom;
		protected DateTime? _validTo;
		protected bool? _isActive;
		protected string _promotionTypeNameAr;
		protected string _promotionTypeNameEn;
		protected Int32? _promotionTypeId;
		protected Int32? _priority;
		protected Int32? _repeats;
		protected string _clientCode;
		protected string _clientNameAr;
		protected string _clientNameEn;
		protected string _salesCode;
		protected decimal? _netTotal;
		protected DateTime? _invoiceDate;
		protected string _invoiceCode;
		protected decimal? _deliveryTotal;
		protected decimal? _customDiscountTotal;
		protected decimal? _customDiscountValue;
		protected Int32? _customDiscountTypeId;
		protected decimal? _cashDiscountTotal;
		protected decimal? _taxTotal;
		protected decimal? _itemDiscountTotal;
		protected decimal? _itemTotal;
		protected Int32? _promotionId;
		protected Int64? _salesId;
		protected Int32? _clientId;
		protected string _clientGroupNameEn;
		protected string _clientGroupNameAr;
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
		public BOSalesOrderPromotionAllVw()
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
		///DAOSalesOrderPromotionAllVw
		///</parameters>
		protected internal BOSalesOrderPromotionAllVw(DAOSalesOrderPromotionAllVw daoSalesOrderPromotionAllVw)
		{
			try
			{
				_promotionCode = daoSalesOrderPromotionAllVw.PromotionCode;
				_validFrom = daoSalesOrderPromotionAllVw.ValidFrom;
				_validTo = daoSalesOrderPromotionAllVw.ValidTo;
				_isActive = daoSalesOrderPromotionAllVw.IsActive;
				_promotionTypeNameAr = daoSalesOrderPromotionAllVw.PromotionTypeNameAr;
				_promotionTypeNameEn = daoSalesOrderPromotionAllVw.PromotionTypeNameEn;
				_promotionTypeId = daoSalesOrderPromotionAllVw.PromotionTypeId;
				_priority = daoSalesOrderPromotionAllVw.Priority;
				_repeats = daoSalesOrderPromotionAllVw.Repeats;
				_clientCode = daoSalesOrderPromotionAllVw.ClientCode;
				_clientNameAr = daoSalesOrderPromotionAllVw.ClientNameAr;
				_clientNameEn = daoSalesOrderPromotionAllVw.ClientNameEn;
				_salesCode = daoSalesOrderPromotionAllVw.SalesCode;
				_netTotal = daoSalesOrderPromotionAllVw.NetTotal;
				_invoiceDate = daoSalesOrderPromotionAllVw.InvoiceDate;
				_invoiceCode = daoSalesOrderPromotionAllVw.InvoiceCode;
				_deliveryTotal = daoSalesOrderPromotionAllVw.DeliveryTotal;
				_customDiscountTotal = daoSalesOrderPromotionAllVw.CustomDiscountTotal;
				_customDiscountValue = daoSalesOrderPromotionAllVw.CustomDiscountValue;
				_customDiscountTypeId = daoSalesOrderPromotionAllVw.CustomDiscountTypeId;
				_cashDiscountTotal = daoSalesOrderPromotionAllVw.CashDiscountTotal;
				_taxTotal = daoSalesOrderPromotionAllVw.TaxTotal;
				_itemDiscountTotal = daoSalesOrderPromotionAllVw.ItemDiscountTotal;
				_itemTotal = daoSalesOrderPromotionAllVw.ItemTotal;
				_promotionId = daoSalesOrderPromotionAllVw.PromotionId;
				_salesId = daoSalesOrderPromotionAllVw.SalesId;
				_clientId = daoSalesOrderPromotionAllVw.ClientId;
				_clientGroupNameEn = daoSalesOrderPromotionAllVw.ClientGroupNameEn;
				_clientGroupNameAr = daoSalesOrderPromotionAllVw.ClientGroupNameAr;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///SalesOrderPromotionAllVwCollection
		///This method returns the collection of BOSalesOrderPromotionAllVw objects
		///</Summary>
		///<returns>
		///List[BOSalesOrderPromotionAllVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOSalesOrderPromotionAllVw> SalesOrderPromotionAllVwCollection()
		{
			try
			{
				IList<BOSalesOrderPromotionAllVw> boSalesOrderPromotionAllVwCollection = new List<BOSalesOrderPromotionAllVw>();
				IList<DAOSalesOrderPromotionAllVw> daoSalesOrderPromotionAllVwCollection = DAOSalesOrderPromotionAllVw.SelectAll();
			
				foreach(DAOSalesOrderPromotionAllVw daoSalesOrderPromotionAllVw in daoSalesOrderPromotionAllVwCollection)
					boSalesOrderPromotionAllVwCollection.Add(new BOSalesOrderPromotionAllVw(daoSalesOrderPromotionAllVw));
			
				return boSalesOrderPromotionAllVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderPromotionAllVwCollectionCount
		///This method returns the collection count of BOSalesOrderPromotionAllVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 SalesOrderPromotionAllVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOSalesOrderPromotionAllVw.SelectAllCount();
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
		///List<BOSalesOrderPromotionAllVw>
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
				IDictionary<string, IList<object>> retObj = DAOSalesOrderPromotionAllVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderPromotionAllVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOSalesOrderPromotionAllVw objects, filtered by optional criteria
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
				IList<T> boSalesOrderPromotionAllVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOSalesOrderPromotionAllVw> daoSalesOrderPromotionAllVwCollection = DAOSalesOrderPromotionAllVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOSalesOrderPromotionAllVw resdaoSalesOrderPromotionAllVw in daoSalesOrderPromotionAllVwCollection)
					boSalesOrderPromotionAllVwCollection.Add((T)(object)new BOSalesOrderPromotionAllVw(resdaoSalesOrderPromotionAllVw));
			
				return boSalesOrderPromotionAllVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderPromotionAllVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOSalesOrderPromotionAllVw objects, filtered by optional criteria
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
				Int32 objCount = DAOSalesOrderPromotionAllVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual string PromotionCode
		{
			get
			{
				 return _promotionCode;
			}
			set
			{
				_promotionCode = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? ValidFrom
		{
			get
			{
				 return _validFrom;
			}
			set
			{
				_validFrom = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? ValidTo
		{
			get
			{
				 return _validTo;
			}
			set
			{
				_validTo = value;
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
		
		public virtual string PromotionTypeNameAr
		{
			get
			{
				 return _promotionTypeNameAr;
			}
			set
			{
				_promotionTypeNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string PromotionTypeNameEn
		{
			get
			{
				 return _promotionTypeNameEn;
			}
			set
			{
				_promotionTypeNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? PromotionTypeId
		{
			get
			{
				 return _promotionTypeId;
			}
			set
			{
				_promotionTypeId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Priority
		{
			get
			{
				 return _priority;
			}
			set
			{
				_priority = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? Repeats
		{
			get
			{
				 return _repeats;
			}
			set
			{
				_repeats = value;
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
		
		public virtual string SalesCode
		{
			get
			{
				 return _salesCode;
			}
			set
			{
				_salesCode = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? NetTotal
		{
			get
			{
				 return _netTotal;
			}
			set
			{
				_netTotal = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? InvoiceDate
		{
			get
			{
				 return _invoiceDate;
			}
			set
			{
				_invoiceDate = value;
				_isDirty = true;
			}
		}
		
		public virtual string InvoiceCode
		{
			get
			{
				 return _invoiceCode;
			}
			set
			{
				_invoiceCode = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? DeliveryTotal
		{
			get
			{
				 return _deliveryTotal;
			}
			set
			{
				_deliveryTotal = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? CustomDiscountTotal
		{
			get
			{
				 return _customDiscountTotal;
			}
			set
			{
				_customDiscountTotal = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? CustomDiscountValue
		{
			get
			{
				 return _customDiscountValue;
			}
			set
			{
				_customDiscountValue = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? CustomDiscountTypeId
		{
			get
			{
				 return _customDiscountTypeId;
			}
			set
			{
				_customDiscountTypeId = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? CashDiscountTotal
		{
			get
			{
				 return _cashDiscountTotal;
			}
			set
			{
				_cashDiscountTotal = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? TaxTotal
		{
			get
			{
				 return _taxTotal;
			}
			set
			{
				_taxTotal = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? ItemDiscountTotal
		{
			get
			{
				 return _itemDiscountTotal;
			}
			set
			{
				_itemDiscountTotal = value;
				_isDirty = true;
			}
		}
		
		public virtual decimal? ItemTotal
		{
			get
			{
				 return _itemTotal;
			}
			set
			{
				_itemTotal = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? PromotionId
		{
			get
			{
				 return _promotionId;
			}
			set
			{
				_promotionId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int64? SalesId
		{
			get
			{
				 return _salesId;
			}
			set
			{
				_salesId = value;
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
		
		public virtual string ClientGroupNameEn
		{
			get
			{
				 return _clientGroupNameEn;
			}
			set
			{
				_clientGroupNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string ClientGroupNameAr
		{
			get
			{
				 return _clientGroupNameAr;
			}
			set
			{
				_clientGroupNameAr = value;
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
