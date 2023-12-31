/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 4/7/2023 11:07:36 PM
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
	///This is the definition of the class BOSalesOrderPromotionVw.
	///</Summary>
	public partial class BOSalesOrderPromotionVw : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _promotionId;
		protected Int64? _salesId;
		protected Int32? _clientId;
		protected DateTime? _salesDate;
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
		public BOSalesOrderPromotionVw()
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
		///DAOSalesOrderPromotionVw
		///</parameters>
		protected internal BOSalesOrderPromotionVw(DAOSalesOrderPromotionVw daoSalesOrderPromotionVw)
		{
			try
			{
				_promotionId = daoSalesOrderPromotionVw.PromotionId;
				_salesId = daoSalesOrderPromotionVw.SalesId;
				_clientId = daoSalesOrderPromotionVw.ClientId;
				_salesDate = daoSalesOrderPromotionVw.SalesDate;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///SalesOrderPromotionVwCollection
		///This method returns the collection of BOSalesOrderPromotionVw objects
		///</Summary>
		///<returns>
		///List[BOSalesOrderPromotionVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOSalesOrderPromotionVw> SalesOrderPromotionVwCollection()
		{
			try
			{
				IList<BOSalesOrderPromotionVw> boSalesOrderPromotionVwCollection = new List<BOSalesOrderPromotionVw>();
				IList<DAOSalesOrderPromotionVw> daoSalesOrderPromotionVwCollection = DAOSalesOrderPromotionVw.SelectAll();
			
				foreach(DAOSalesOrderPromotionVw daoSalesOrderPromotionVw in daoSalesOrderPromotionVwCollection)
					boSalesOrderPromotionVwCollection.Add(new BOSalesOrderPromotionVw(daoSalesOrderPromotionVw));
			
				return boSalesOrderPromotionVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderPromotionVwCollectionCount
		///This method returns the collection count of BOSalesOrderPromotionVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 SalesOrderPromotionVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOSalesOrderPromotionVw.SelectAllCount();
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
		///List<BOSalesOrderPromotionVw>
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
				IDictionary<string, IList<object>> retObj = DAOSalesOrderPromotionVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderPromotionVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOSalesOrderPromotionVw objects, filtered by optional criteria
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
				IList<T> boSalesOrderPromotionVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOSalesOrderPromotionVw> daoSalesOrderPromotionVwCollection = DAOSalesOrderPromotionVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOSalesOrderPromotionVw resdaoSalesOrderPromotionVw in daoSalesOrderPromotionVwCollection)
					boSalesOrderPromotionVwCollection.Add((T)(object)new BOSalesOrderPromotionVw(resdaoSalesOrderPromotionVw));
			
				return boSalesOrderPromotionVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SalesOrderPromotionVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOSalesOrderPromotionVw objects, filtered by optional criteria
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
				Int32 objCount = DAOSalesOrderPromotionVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
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
		
		public virtual DateTime? SalesDate
		{
			get
			{
				 return _salesDate;
			}
			set
			{
				_salesDate = value;
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
