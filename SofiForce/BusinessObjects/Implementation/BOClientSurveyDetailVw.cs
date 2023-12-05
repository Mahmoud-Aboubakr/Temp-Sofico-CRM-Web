/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 4/27/2022 1:23:01 PM
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
	///This is the definition of the class BOClientSurveyDetailVw.
	///</Summary>
	public partial class BOClientSurveyDetailVw : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected bool? _isSelected;
		protected Int32? _detailAnswerId;
		protected Int64? _clientServeyId;
		protected Int64? _clientDetailId;
		protected string _answerEn;
		protected string _answerAr;
		protected string _surveyQuestionEn;
		protected string _surveyQuestionAr;
		protected bool? _isMuliSelect;
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
		public BOClientSurveyDetailVw()
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
		///DAOClientSurveyDetailVw
		///</parameters>
		protected internal BOClientSurveyDetailVw(DAOClientSurveyDetailVw daoClientSurveyDetailVw)
		{
			try
			{
				_isSelected = daoClientSurveyDetailVw.IsSelected;
				_detailAnswerId = daoClientSurveyDetailVw.DetailAnswerId;
				_clientServeyId = daoClientSurveyDetailVw.ClientServeyId;
				_clientDetailId = daoClientSurveyDetailVw.ClientDetailId;
				_answerEn = daoClientSurveyDetailVw.AnswerEn;
				_answerAr = daoClientSurveyDetailVw.AnswerAr;
				_surveyQuestionEn = daoClientSurveyDetailVw.SurveyQuestionEn;
				_surveyQuestionAr = daoClientSurveyDetailVw.SurveyQuestionAr;
				_isMuliSelect = daoClientSurveyDetailVw.IsMuliSelect;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///ClientSurveyDetailVwCollection
		///This method returns the collection of BOClientSurveyDetailVw objects
		///</Summary>
		///<returns>
		///List[BOClientSurveyDetailVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOClientSurveyDetailVw> ClientSurveyDetailVwCollection()
		{
			try
			{
				IList<BOClientSurveyDetailVw> boClientSurveyDetailVwCollection = new List<BOClientSurveyDetailVw>();
				IList<DAOClientSurveyDetailVw> daoClientSurveyDetailVwCollection = DAOClientSurveyDetailVw.SelectAll();
			
				foreach(DAOClientSurveyDetailVw daoClientSurveyDetailVw in daoClientSurveyDetailVwCollection)
					boClientSurveyDetailVwCollection.Add(new BOClientSurveyDetailVw(daoClientSurveyDetailVw));
			
				return boClientSurveyDetailVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientSurveyDetailVwCollectionCount
		///This method returns the collection count of BOClientSurveyDetailVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ClientSurveyDetailVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOClientSurveyDetailVw.SelectAllCount();
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
		///List<BOClientSurveyDetailVw>
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
				IDictionary<string, IList<object>> retObj = DAOClientSurveyDetailVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientSurveyDetailVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOClientSurveyDetailVw objects, filtered by optional criteria
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
				IList<T> boClientSurveyDetailVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOClientSurveyDetailVw> daoClientSurveyDetailVwCollection = DAOClientSurveyDetailVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOClientSurveyDetailVw resdaoClientSurveyDetailVw in daoClientSurveyDetailVwCollection)
					boClientSurveyDetailVwCollection.Add((T)(object)new BOClientSurveyDetailVw(resdaoClientSurveyDetailVw));
			
				return boClientSurveyDetailVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ClientSurveyDetailVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOClientSurveyDetailVw objects, filtered by optional criteria
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
				Int32 objCount = DAOClientSurveyDetailVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual bool? IsSelected
		{
			get
			{
				 return _isSelected;
			}
			set
			{
				_isSelected = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? DetailAnswerId
		{
			get
			{
				 return _detailAnswerId;
			}
			set
			{
				_detailAnswerId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int64? ClientServeyId
		{
			get
			{
				 return _clientServeyId;
			}
			set
			{
				_clientServeyId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int64? ClientDetailId
		{
			get
			{
				 return _clientDetailId;
			}
			set
			{
				_clientDetailId = value;
				_isDirty = true;
			}
		}
		
		public virtual string AnswerEn
		{
			get
			{
				 return _answerEn;
			}
			set
			{
				_answerEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string AnswerAr
		{
			get
			{
				 return _answerAr;
			}
			set
			{
				_answerAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string SurveyQuestionEn
		{
			get
			{
				 return _surveyQuestionEn;
			}
			set
			{
				_surveyQuestionEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string SurveyQuestionAr
		{
			get
			{
				 return _surveyQuestionAr;
			}
			set
			{
				_surveyQuestionAr = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? IsMuliSelect
		{
			get
			{
				 return _isMuliSelect;
			}
			set
			{
				_isMuliSelect = value;
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