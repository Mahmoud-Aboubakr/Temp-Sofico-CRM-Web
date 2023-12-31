/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 3/23/2023 3:30:40 PM
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
	///This is the definition of the class BOSalesOrderLogVw.
	///</Summary>
	public partial class BOSalesOrderLogVw : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _userId;
		protected DateTime? _logDate;
		protected Int32? _salesOrderLogTypeId;
		protected Int64? _salesId;
		protected Int64? _logId;
		protected string _salesOrderLogTypeNameEn;
		protected string _salesOrderLogTypeNameAr;
		protected string _realName;
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
		public BOSalesOrderLogVw()
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
		///DAOSalesOrderLogVw
		///</parameters>
		protected internal BOSalesOrderLogVw(DAOSalesOrderLogVw daoSalesOrderLogVw)
		{
			try
			{
				_userId = daoSalesOrderLogVw.UserId;
				_logDate = daoSalesOrderLogVw.LogDate;
				_salesOrderLogTypeId = daoSalesOrderLogVw.SalesOrderLogTypeId;
				_salesId = daoSalesOrderLogVw.SalesId;
				_logId = daoSalesOrderLogVw.LogId;
				_salesOrderLogTypeNameEn = daoSalesOrderLogVw.SalesOrderLogTypeNameEn;
				_salesOrderLogTypeNameAr = daoSalesOrderLogVw.SalesOrderLogTypeNameAr;
				_realName = daoSalesOrderLogVw.RealName;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///SalesOrderLogVwCollection
		///This method returns the collection of BOSalesOrderLogVw objects
		///</Summary>
		///<returns>
		///List[BOSalesOrderLogVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOSalesOrderLogVw> SalesOrderLogVwCollection()
		{
			try
			{
				IList<BOSalesOrderLogVw> boSalesOrderLogVwCollection = new List<BOSalesOrderLogVw>();
				IList<DAOSalesOrderLogVw> daoSalesOrderLogVwCollection = DAOSalesOrderLogVw.SelectAll();
			
				foreach(DAOSalesOrderLogVw daoSalesOrderLogVw in daoSalesOrderLogVwCollection)
					boSalesOrderLogVwCollection.Add(new BOSalesOrderLogVw(daoSalesOrderLogVw));
			
				return boSalesOrderLogVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderLogVwCollectionCount
		///This method returns the collection count of BOSalesOrderLogVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 SalesOrderLogVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOSalesOrderLogVw.SelectAllCount();
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
		///List<BOSalesOrderLogVw>
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
				IDictionary<string, IList<object>> retObj = DAOSalesOrderLogVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderLogVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOSalesOrderLogVw objects, filtered by optional criteria
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
				IList<T> boSalesOrderLogVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOSalesOrderLogVw> daoSalesOrderLogVwCollection = DAOSalesOrderLogVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOSalesOrderLogVw resdaoSalesOrderLogVw in daoSalesOrderLogVwCollection)
					boSalesOrderLogVwCollection.Add((T)(object)new BOSalesOrderLogVw(resdaoSalesOrderLogVw));
			
				return boSalesOrderLogVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderLogVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOSalesOrderLogVw objects, filtered by optional criteria
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
				Int32 objCount = DAOSalesOrderLogVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? UserId
		{
			get
			{
				 return _userId;
			}
			set
			{
				_userId = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? LogDate
		{
			get
			{
				 return _logDate;
			}
			set
			{
				_logDate = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? SalesOrderLogTypeId
		{
			get
			{
				 return _salesOrderLogTypeId;
			}
			set
			{
				_salesOrderLogTypeId = value;
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
		
		public virtual Int64? LogId
		{
			get
			{
				 return _logId;
			}
			set
			{
				_logId = value;
				_isDirty = true;
			}
		}
		
		public virtual string SalesOrderLogTypeNameEn
		{
			get
			{
				 return _salesOrderLogTypeNameEn;
			}
			set
			{
				_salesOrderLogTypeNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string SalesOrderLogTypeNameAr
		{
			get
			{
				 return _salesOrderLogTypeNameAr;
			}
			set
			{
				_salesOrderLogTypeNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string RealName
		{
			get
			{
				 return _realName;
			}
			set
			{
				_realName = value;
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
