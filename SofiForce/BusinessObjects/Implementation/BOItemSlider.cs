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
	///This is the definition of the class BOItemSlider.
	///</Summary>
	public partial class BOItemSlider : zSofiForceConn_BaseBusiness, IQueryableCollection
	{
		#region member variables
		protected Int32? _sliderId;
		protected Int32? _itemId;
		protected string _slideImage;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
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
		public BOItemSlider()
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
		///Int32 sliderId
		///</parameters>
		public BOItemSlider(Int32 sliderId)
		{
			try
			{
				DAOItemSlider daoItemSlider = DAOItemSlider.SelectOne(sliderId);
				_sliderId = daoItemSlider.SliderId;
				_itemId = daoItemSlider.ItemId;
				_slideImage = daoItemSlider.SlideImage;
				_cBy = daoItemSlider.CBy;
				_cDate = daoItemSlider.CDate;
				_eBy = daoItemSlider.EBy;
				_eDate = daoItemSlider.EDate;
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
		///DAOItemSlider
		///</parameters>
		protected internal BOItemSlider(DAOItemSlider daoItemSlider)
		{
			try
			{
				_sliderId = daoItemSlider.SliderId;
				_itemId = daoItemSlider.ItemId;
				_slideImage = daoItemSlider.SlideImage;
				_cBy = daoItemSlider.CBy;
				_cDate = daoItemSlider.CDate;
				_eBy = daoItemSlider.EBy;
				_eDate = daoItemSlider.EDate;
			}
			catch
			{
				throw;
			}
		}

		///<Summary>
		///SaveNew
		///This method persists a new ItemSlider record to the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void SaveNew()
		{
			DAOItemSlider daoItemSlider = new DAOItemSlider();
			RegisterDataObject(daoItemSlider);
			BeginTransaction("savenewBOItemSlider");
			try
			{
				daoItemSlider.ItemId = _itemId;
				daoItemSlider.SlideImage = _slideImage;
				daoItemSlider.CBy = _cBy;
				daoItemSlider.CDate = _cDate;
				daoItemSlider.EBy = _eBy;
				daoItemSlider.EDate = _eDate;
				daoItemSlider.Insert();
				CommitTransaction();
				
				_sliderId = daoItemSlider.SliderId;
				_itemId = daoItemSlider.ItemId;
				_slideImage = daoItemSlider.SlideImage;
				_cBy = daoItemSlider.CBy;
				_cDate = daoItemSlider.CDate;
				_eBy = daoItemSlider.EBy;
				_eDate = daoItemSlider.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("savenewBOItemSlider");
				throw;
			}
		}
		
		///<Summary>
		///Update
		///This method updates one ItemSlider record in the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///BOItemSlider
		///</parameters>
		public virtual void Update()
		{
			DAOItemSlider daoItemSlider = new DAOItemSlider();
			RegisterDataObject(daoItemSlider);
			BeginTransaction("updateBOItemSlider");
			try
			{
				daoItemSlider.SliderId = _sliderId;
				daoItemSlider.ItemId = _itemId;
				daoItemSlider.SlideImage = _slideImage;
				daoItemSlider.CBy = _cBy;
				daoItemSlider.CDate = _cDate;
				daoItemSlider.EBy = _eBy;
				daoItemSlider.EDate = _eDate;
				daoItemSlider.Update();
				CommitTransaction();
				
				_sliderId = daoItemSlider.SliderId;
				_itemId = daoItemSlider.ItemId;
				_slideImage = daoItemSlider.SlideImage;
				_cBy = daoItemSlider.CBy;
				_cDate = daoItemSlider.CDate;
				_eBy = daoItemSlider.EBy;
				_eDate = daoItemSlider.EDate;
				_isDirty = false;
			}
			catch
			{
				RollbackTransaction("updateBOItemSlider");
				throw;
			}
		}
		///<Summary>
		///Delete
		///This method deletes one ItemSlider record from the store
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			DAOItemSlider daoItemSlider = new DAOItemSlider();
			RegisterDataObject(daoItemSlider);
			BeginTransaction("deleteBOItemSlider");
			try
			{
				daoItemSlider.SliderId = _sliderId;
				daoItemSlider.Delete();
				CommitTransaction();
			}
			catch
			{
				RollbackTransaction("deleteBOItemSlider");
				throw;
			}
		}
		
		///<Summary>
		///ItemSliderCollection
		///This method returns the collection of BOItemSlider objects
		///</Summary>
		///<returns>
		///List[BOItemSlider]
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<BOItemSlider> ItemSliderCollection()
		{
			try
			{
				IList<BOItemSlider> boItemSliderCollection = new List<BOItemSlider>();
				IList<DAOItemSlider> daoItemSliderCollection = DAOItemSlider.SelectAll();
			
				foreach(DAOItemSlider daoItemSlider in daoItemSliderCollection)
					boItemSliderCollection.Add(new BOItemSlider(daoItemSlider));
			
				return boItemSliderCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemSliderCollectionCount
		///This method returns the collection count of BOItemSlider objects
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 ItemSliderCollectionCount()
		{
			try
			{
				Int32 objCount = DAOItemSlider.SelectAllCount();
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
		///List<BOItemSlider>
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
				IDictionary<string, IList<object>> retObj = DAOItemSlider.SelectAllByCriteriaProjection(lstDataProjection, lstDataCriteria, lstDataOrder, dataSkip, dataTake);
				return retObj;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemSliderCollection<T>
		///This method implements the IQueryable Collection<T> method, returning a collection of BOItemSlider objects, filtered by optional criteria
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
				IList<T> boItemSliderCollection = new List<T>();
				IList<IDataCriterion> lstDataCriteria = (icriteria == null) ? null : icriteria.ListDataCriteria();
				IList<IDataOrderBy> lstDataOrder = (icriteria == null) ? null : icriteria.ListDataOrder();
				IDataTake dataTake = (icriteria == null) ? null : icriteria.DataTake();
				IDataSkip dataSkip = (icriteria == null) ? null : icriteria.DataSkip();
				IList<DAOItemSlider> daoItemSliderCollection = DAOItemSlider.SelectAllByCriteria(lstDataCriteria, lstDataOrder, dataSkip, dataTake);
			
				foreach(DAOItemSlider resdaoItemSlider in daoItemSliderCollection)
					boItemSliderCollection.Add((T)(object)new BOItemSlider(resdaoItemSlider));
			
				return boItemSliderCollection;
			}
			catch
			{
				throw;
			}
		}
		
		
		///<Summary>
		///ItemSliderCollectionCount
		///This method implements the IQueryable CollectionCount method, returning a collection count of BOItemSlider objects, filtered by optional criteria
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
				Int32 objCount = DAOItemSlider.SelectAllByCriteriaCount(lstDataCriteria);
				return objCount;
			}
			catch
			{
				throw;
			}
		}
		
		#endregion

		#region member properties
		
		public virtual Int32? SliderId
		{
			get
			{
				 return _sliderId;
			}
			set
			{
				_sliderId = value;
				_isDirty = true;
			}
		}
		
		public virtual Int32? ItemId
		{
			get
			{
				 return _itemId;
			}
			set
			{
				_itemId = value;
				_isDirty = true;
			}
		}
		
		public virtual string SlideImage
		{
			get
			{
				 return _slideImage;
			}
			set
			{
				_slideImage = value;
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
