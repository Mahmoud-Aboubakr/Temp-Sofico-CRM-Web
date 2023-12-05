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
	///This is the definition of the class BOPromtionCriteriaClientAttrVw.
	///</Summary>
	public partial class BOPromtionCriteriaClientAttrVw : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected string _clientCode;
		protected Int32? _clientId;
		protected string _clientNameAr;
		protected string _clientNameEn;
		protected Int32? _clientCustomId;
		protected Int32? _clientAttributeId;
		protected string _clientAttributeCode;
		protected string _clientAttributeNameEn;
		protected string _clientAttributeNameAr;
		protected bool? _isCustom;
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
		public BOPromtionCriteriaClientAttrVw()
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
		///DAOPromtionCriteriaClientAttrVw
		///</parameters>
		protected internal BOPromtionCriteriaClientAttrVw(DAOPromtionCriteriaClientAttrVw daoPromtionCriteriaClientAttrVw)
		{
			try
			{
				_clientCode = daoPromtionCriteriaClientAttrVw.ClientCode;
				_clientId = daoPromtionCriteriaClientAttrVw.ClientId;
				_clientNameAr = daoPromtionCriteriaClientAttrVw.ClientNameAr;
				_clientNameEn = daoPromtionCriteriaClientAttrVw.ClientNameEn;
				_clientCustomId = daoPromtionCriteriaClientAttrVw.ClientCustomId;
				_clientAttributeId = daoPromtionCriteriaClientAttrVw.ClientAttributeId;
				_clientAttributeCode = daoPromtionCriteriaClientAttrVw.ClientAttributeCode;
				_clientAttributeNameEn = daoPromtionCriteriaClientAttrVw.ClientAttributeNameEn;
				_clientAttributeNameAr = daoPromtionCriteriaClientAttrVw.ClientAttributeNameAr;
				_isCustom = daoPromtionCriteriaClientAttrVw.IsCustom;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///PromtionCriteriaClientAttrVwCollection
		///This method returns the collection of BOPromtionCriteriaClientAttrVw objects
		///</Summary>
		///<returns>
		///List[BOPromtionCriteriaClientAttrVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOPromtionCriteriaClientAttrVw> PromtionCriteriaClientAttrVwCollection()
		{
			try
			{
				IList<BOPromtionCriteriaClientAttrVw> boPromtionCriteriaClientAttrVwCollection = new List<BOPromtionCriteriaClientAttrVw>();
				IList<DAOPromtionCriteriaClientAttrVw> daoPromtionCriteriaClientAttrVwCollection = DAOPromtionCriteriaClientAttrVw.SelectAll();
			
				foreach(DAOPromtionCriteriaClientAttrVw daoPromtionCriteriaClientAttrVw in daoPromtionCriteriaClientAttrVwCollection)
					boPromtionCriteriaClientAttrVwCollection.Add(new BOPromtionCriteriaClientAttrVw(daoPromtionCriteriaClientAttrVw));
			
				return boPromtionCriteriaClientAttrVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromtionCriteriaClientAttrVwCollectionCount
		///This method returns the collection count of BOPromtionCriteriaClientAttrVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 PromtionCriteriaClientAttrVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOPromtionCriteriaClientAttrVw.SelectAllCount();
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
		///List<BOPromtionCriteriaClientAttrVw>
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
				IDictionary<string, IList<object>> retObj = DAOPromtionCriteriaClientAttrVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromtionCriteriaClientAttrVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOPromtionCriteriaClientAttrVw objects, filtered by optional criteria
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
				IList<T> boPromtionCriteriaClientAttrVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOPromtionCriteriaClientAttrVw> daoPromtionCriteriaClientAttrVwCollection = DAOPromtionCriteriaClientAttrVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOPromtionCriteriaClientAttrVw resdaoPromtionCriteriaClientAttrVw in daoPromtionCriteriaClientAttrVwCollection)
					boPromtionCriteriaClientAttrVwCollection.Add((T)(object)new BOPromtionCriteriaClientAttrVw(resdaoPromtionCriteriaClientAttrVw));
			
				return boPromtionCriteriaClientAttrVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///PromtionCriteriaClientAttrVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOPromtionCriteriaClientAttrVw objects, filtered by optional criteria
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
				Int32 objCount = DAOPromtionCriteriaClientAttrVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
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
		
		public virtual Int32? ClientCustomId
		{
			get
			{
				 return _clientCustomId;
			}
			set
			{
				_clientCustomId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ClientAttributeId
		{
			get
			{
				 return _clientAttributeId;
			}
			set
			{
				_clientAttributeId = value;
				_isDirty = true;
			}
		}
		
		public virtual string ClientAttributeCode
		{
			get
			{
				 return _clientAttributeCode;
			}
			set
			{
				_clientAttributeCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string ClientAttributeNameEn
		{
			get
			{
				 return _clientAttributeNameEn;
			}
			set
			{
				_clientAttributeNameEn = value;
				_isDirty = true;
			}
		}
		
		public virtual string ClientAttributeNameAr
		{
			get
			{
				 return _clientAttributeNameAr;
			}
			set
			{
				_clientAttributeNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual bool? IsCustom
		{
			get
			{
				 return _isCustom;
			}
			set
			{
				_isCustom = value;
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
