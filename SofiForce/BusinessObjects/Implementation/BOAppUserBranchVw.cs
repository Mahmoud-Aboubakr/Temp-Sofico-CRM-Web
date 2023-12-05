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
	///This is the definition of the class BOAppUserBranchVw.
	///</Summary>
	public partial class BOAppUserBranchVw : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _userBranchId;
		protected Int32? _branchId;
		protected Int32? _userId;
		protected string _branchCode;
		protected string _branchNameAr;
		protected string _branchNameEn;
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
		public BOAppUserBranchVw()
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
		///DAOAppUserBranchVw
		///</parameters>
		protected internal BOAppUserBranchVw(DAOAppUserBranchVw daoAppUserBranchVw)
		{
			try
			{
				_userBranchId = daoAppUserBranchVw.UserBranchId;
				_branchId = daoAppUserBranchVw.BranchId;
				_userId = daoAppUserBranchVw.UserId;
				_branchCode = daoAppUserBranchVw.BranchCode;
				_branchNameAr = daoAppUserBranchVw.BranchNameAr;
				_branchNameEn = daoAppUserBranchVw.BranchNameEn;
			}
			catch
			{
				throw;
			}
		}

		
		///<Summary>
		///AppUserBranchVwCollection
		///This method returns the collection of BOAppUserBranchVw objects
		///</Summary>
		///<returns>
		///List[BOAppUserBranchVw]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOAppUserBranchVw> AppUserBranchVwCollection()
		{
			try
			{
				IList<BOAppUserBranchVw> boAppUserBranchVwCollection = new List<BOAppUserBranchVw>();
				IList<DAOAppUserBranchVw> daoAppUserBranchVwCollection = DAOAppUserBranchVw.SelectAll();
			
				foreach(DAOAppUserBranchVw daoAppUserBranchVw in daoAppUserBranchVwCollection)
					boAppUserBranchVwCollection.Add(new BOAppUserBranchVw(daoAppUserBranchVw));
			
				return boAppUserBranchVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AppUserBranchVwCollectionCount
		///This method returns the collection count of BOAppUserBranchVw objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 AppUserBranchVwCollectionCount()
		{
			try
			{
				Int32 objCount = DAOAppUserBranchVw.SelectAllCount();
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
		///List<BOAppUserBranchVw>
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
				IDictionary<string, IList<object>> retObj = DAOAppUserBranchVw.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AppUserBranchVwCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOAppUserBranchVw objects, filtered by optional criteria
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
				IList<T> boAppUserBranchVwCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOAppUserBranchVw> daoAppUserBranchVwCollection = DAOAppUserBranchVw.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOAppUserBranchVw resdaoAppUserBranchVw in daoAppUserBranchVwCollection)
					boAppUserBranchVwCollection.Add((T)(object)new BOAppUserBranchVw(resdaoAppUserBranchVw));
			
				return boAppUserBranchVwCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///AppUserBranchVwCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOAppUserBranchVw objects, filtered by optional criteria
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
				Int32 objCount = DAOAppUserBranchVw.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? UserBranchId
		{
			get
			{
				 return _userBranchId;
			}
			set
			{
				_userBranchId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? BranchId
		{
			get
			{
				 return _branchId;
			}
			set
			{
				_branchId = value;
				_isDirty = true;
			}
		}
		
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
		
		public virtual string BranchCode
		{
			get
			{
				 return _branchCode;
			}
			set
			{
				_branchCode = value;
				_isDirty = true;
			}
		}
		
		public virtual string BranchNameAr
		{
			get
			{
				 return _branchNameAr;
			}
			set
			{
				_branchNameAr = value;
				_isDirty = true;
			}
		}
		
		public virtual string BranchNameEn
		{
			get
			{
				 return _branchNameEn;
			}
			set
			{
				_branchNameEn = value;
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