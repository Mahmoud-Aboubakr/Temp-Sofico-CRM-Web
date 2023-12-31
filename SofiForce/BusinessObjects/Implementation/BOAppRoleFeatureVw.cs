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
	///This is the definition of the class BOAppRoleFeatureVw.
	///</Summary>
	public partial class BOAppRoleFeatureVw : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _appRoleId;
		protected Int32? _featueId;
		protected Int32? _appRoleFeatueId;
		protected string _featueCode;
		protected string _featueNameEn;
		protected string _featueNameAr;
		protected string _featuePath;
		protected Int32? _applicationId;
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
		public BOAppRoleFeatureVw()
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
		///DAOAppRoleFeatureVw
		///</parameters>
		protected internal BOAppRoleFeatureVw(DAOAppRoleFeatureVw daoAppRoleFeatureVw)
		{
			try
			{
				_appRoleId = daoAppRoleFeatureVw.AppRoleId;
				_featueId = daoAppRoleFeatureVw.FeatueId;
				_appRoleFeatueId = daoAppRoleFeatureVw.AppRoleFeatueId;
				_featueCode = daoAppRoleFeatureVw.FeatueCode;
				_featueNameEn = daoAppRoleFeatureVw.FeatueNameEn;
				_featueNameAr = daoAppRoleFeatureVw.FeatueNameAr;
				_featuePath = daoAppRoleFeatureVw.FeatuePath;
				_applicationId = daoAppRoleFeatureVw.ApplicationId;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///AppRoleFeatureVwCollection
		///This method returns the collection of BOAppRoleFeatureVw objects
		///</Summary>
		///<returns>
		///List[BOAppRoleFeatureVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOAppRoleFeatureVw> AppRoleFeatureVwCollection()
		{
			try
			{
				IList<BOAppRoleFeatureVw> boAppRoleFeatureVwCollection = new List<BOAppRoleFeatureVw>();
				IList<DAOAppRoleFeatureVw> daoAppRoleFeatureVwCollection = DAOAppRoleFeatureVw.SelectAll();
			
				foreach(DAOAppRoleFeatureVw daoAppRoleFeatureVw in daoAppRoleFeatureVwCollection)
					boAppRoleFeatureVwCollection.Add(new BOAppRoleFeatureVw(daoAppRoleFeatureVw));
			
				return boAppRoleFeatureVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AppRoleFeatureVwCollectionCount
		///This method returns the collection count of BOAppRoleFeatureVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 AppRoleFeatureVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOAppRoleFeatureVw.SelectAllCount();
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
		///List<BOAppRoleFeatureVw>
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
				IDictionary<string, IList<object>> retObj = DAOAppRoleFeatureVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AppRoleFeatureVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOAppRoleFeatureVw objects, filtered by optional criteria
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
				IList<T> boAppRoleFeatureVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOAppRoleFeatureVw> daoAppRoleFeatureVwCollection = DAOAppRoleFeatureVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOAppRoleFeatureVw resdaoAppRoleFeatureVw in daoAppRoleFeatureVwCollection)
					boAppRoleFeatureVwCollection.Add((T)(object)new BOAppRoleFeatureVw(resdaoAppRoleFeatureVw));
			
				return boAppRoleFeatureVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AppRoleFeatureVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOAppRoleFeatureVw objects, filtered by optional criteria
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
				Int32 objCount = DAOAppRoleFeatureVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? AppRoleId
		{
			get
			{
				 return _appRoleId;
			}
			set
			{
				_appRoleId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? FeatueId
		{
			get
			{
				 return _featueId;
			}
			set
			{
				_featueId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? AppRoleFeatueId
		{
			get
			{
				 return _appRoleFeatueId;
			}
			set
			{
				_appRoleFeatueId = value;
				_isDirty = true;
			}
		}
		
		public virtual string FeatueCode
		{
			get
			{
				 return _featueCode;
			}
			set
			{
				_featueCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string FeatueNameEn
		{
			get
			{
				 return _featueNameEn;
			}
			set
			{
				_featueNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string FeatueNameAr
		{
			get
			{
				 return _featueNameAr;
			}
			set
			{
				_featueNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string FeatuePath
		{
			get
			{
				 return _featuePath;
			}
			set
			{
				_featuePath = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ApplicationId
		{
			get
			{
				 return _applicationId;
			}
			set
			{
				_applicationId = value;
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
