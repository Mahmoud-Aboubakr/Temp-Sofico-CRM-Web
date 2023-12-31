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
	///This is the definition of the class BOSurveyVw.
	///</Summary>
	public partial class BOSurveyVw : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _surveyId;
		protected string _surveyCode;
		protected DateTime? _createDate;
		protected Int32? _serveyGroupId;
		protected string _surveyNameEn;
		protected string _surveyNameAr;
		protected bool? _isActive;
		protected string _serveyGroupNameEn;
		protected string _serveyGroupNameAr;
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
		public BOSurveyVw()
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
		///DAOSurveyVw
		///</parameters>
		protected internal BOSurveyVw(DAOSurveyVw daoSurveyVw)
		{
			try
			{
				_surveyId = daoSurveyVw.SurveyId;
				_surveyCode = daoSurveyVw.SurveyCode;
				_createDate = daoSurveyVw.CreateDate;
				_serveyGroupId = daoSurveyVw.ServeyGroupId;
				_surveyNameEn = daoSurveyVw.SurveyNameEn;
				_surveyNameAr = daoSurveyVw.SurveyNameAr;
				_isActive = daoSurveyVw.IsActive;
				_serveyGroupNameEn = daoSurveyVw.ServeyGroupNameEn;
				_serveyGroupNameAr = daoSurveyVw.ServeyGroupNameAr;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///SurveyVwCollection
		///This method returns the collection of BOSurveyVw objects
		///</Summary>
		///<returns>
		///List[BOSurveyVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOSurveyVw> SurveyVwCollection()
		{
			try
			{
				IList<BOSurveyVw> boSurveyVwCollection = new List<BOSurveyVw>();
				IList<DAOSurveyVw> daoSurveyVwCollection = DAOSurveyVw.SelectAll();
			
				foreach(DAOSurveyVw daoSurveyVw in daoSurveyVwCollection)
					boSurveyVwCollection.Add(new BOSurveyVw(daoSurveyVw));
			
				return boSurveyVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SurveyVwCollectionCount
		///This method returns the collection count of BOSurveyVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 SurveyVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOSurveyVw.SelectAllCount();
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
		///List<BOSurveyVw>
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
				IDictionary<string, IList<object>> retObj = DAOSurveyVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SurveyVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOSurveyVw objects, filtered by optional criteria
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
				IList<T> boSurveyVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOSurveyVw> daoSurveyVwCollection = DAOSurveyVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOSurveyVw resdaoSurveyVw in daoSurveyVwCollection)
					boSurveyVwCollection.Add((T)(object)new BOSurveyVw(resdaoSurveyVw));
			
				return boSurveyVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///SurveyVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOSurveyVw objects, filtered by optional criteria
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
				Int32 objCount = DAOSurveyVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? SurveyId
		{
			get
			{
				 return _surveyId;
			}
			set
			{
				_surveyId = value;
				_isDirty = true;
			}
		}
		
		public virtual string SurveyCode
		{
			get
			{
				 return _surveyCode;
			}
			set
			{
				_surveyCode = value;
				_isDirty = true;
			}
		}
		
		public virtual DateTime? CreateDate
		{
			get
			{
				 return _createDate;
			}
			set
			{
				_createDate = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ServeyGroupId
		{
			get
			{
				 return _serveyGroupId;
			}
			set
			{
				_serveyGroupId = value;
				_isDirty = true;
			}
		}
		
		public virtual string SurveyNameEn
		{
			get
			{
				 return _surveyNameEn;
			}
			set
			{
				_surveyNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string SurveyNameAr
		{
			get
			{
				 return _surveyNameAr;
			}
			set
			{
				_surveyNameAr = value;
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
		
		public virtual string ServeyGroupNameEn
		{
			get
			{
				 return _serveyGroupNameEn;
			}
			set
			{
				_serveyGroupNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string ServeyGroupNameAr
		{
			get
			{
				 return _serveyGroupNameAr;
			}
			set
			{
				_serveyGroupNameAr = value;
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
