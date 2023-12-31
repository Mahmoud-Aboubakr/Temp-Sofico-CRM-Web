/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 3/23/2023 3:30:39 PM
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SofiForce.DataObjects.Interfaces;

namespace SofiForce.DataObjects
{
	public partial class DAOSalesOrderDetailVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int64? _detailId;
		protected Int64? _salesId;
		protected Int32? _itemId;
		protected decimal? _publicPrice;
		protected decimal? _clientPrice;
		protected Int32? _quantity;
		protected decimal? _lineValue;
		protected decimal? _discount;
		protected decimal? _taxValue;
		protected bool? _isBouns;
		protected string _promotionCode;
		protected string _itemCode;
		protected string _itemNameEn;
		protected string _itemNameAr;
		protected string _vendorNameAr;
		protected string _vendorNameEn;
		protected string _vendorCode;
		protected string _batch;
		protected DateTime? _expiration;
		protected Int32? _itemStoreId;
		protected Int64? _recId;
		protected Int32? _unitId;
		protected decimal? _customDiscount;
		protected bool? _hasPromotion;
		protected Int32? _totalReturn;
		protected Int32? _returnQuantity;
		protected Int32? _returnReasonId;
		protected Int32? _promotionId;
		protected bool? _isTaxable;
		protected Int32? _itemGroupId;
		protected Int32? _vendorId;
		#endregion

		#region class methods
		public DAOSalesOrderDetailVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table SalesOrder_DetailVw
		///</Summary>
		///<returns>
		///IList-DAOSalesOrderDetailVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOSalesOrderDetailVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesOrder_DetailVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_DetailVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSalesOrderDetailVw> objList = new List<DAOSalesOrderDetailVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSalesOrderDetailVw retObj = new DAOSalesOrderDetailVw();
						retObj._detailId					 = Convert.IsDBNull(row["DetailId"]) ? (Int64?)null : (Int64?)row["DetailId"];
						retObj._salesId					 = Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._publicPrice					 = Convert.IsDBNull(row["PublicPrice"]) ? (decimal?)null : (decimal?)row["PublicPrice"];
						retObj._clientPrice					 = Convert.IsDBNull(row["ClientPrice"]) ? (decimal?)null : (decimal?)row["ClientPrice"];
						retObj._quantity					 = Convert.IsDBNull(row["Quantity"]) ? (Int32?)null : (Int32?)row["Quantity"];
						retObj._lineValue					 = Convert.IsDBNull(row["LineValue"]) ? (decimal?)null : (decimal?)row["LineValue"];
						retObj._discount					 = Convert.IsDBNull(row["Discount"]) ? (decimal?)null : (decimal?)row["Discount"];
						retObj._taxValue					 = Convert.IsDBNull(row["TaxValue"]) ? (decimal?)null : (decimal?)row["TaxValue"];
						retObj._isBouns					 = Convert.IsDBNull(row["IsBouns"]) ? (bool?)null : (bool?)row["IsBouns"];
						retObj._promotionCode					 = Convert.IsDBNull(row["PromotionCode"]) ? null : (string)row["PromotionCode"];
						retObj._itemCode					 = Convert.IsDBNull(row["ItemCode"]) ? null : (string)row["ItemCode"];
						retObj._itemNameEn					 = Convert.IsDBNull(row["ItemNameEn"]) ? null : (string)row["ItemNameEn"];
						retObj._itemNameAr					 = Convert.IsDBNull(row["ItemNameAr"]) ? null : (string)row["ItemNameAr"];
						retObj._vendorNameAr					 = Convert.IsDBNull(row["VendorNameAr"]) ? null : (string)row["VendorNameAr"];
						retObj._vendorNameEn					 = Convert.IsDBNull(row["VendorNameEn"]) ? null : (string)row["VendorNameEn"];
						retObj._vendorCode					 = Convert.IsDBNull(row["VendorCode"]) ? null : (string)row["VendorCode"];
						retObj._batch					 = Convert.IsDBNull(row["Batch"]) ? null : (string)row["Batch"];
						retObj._expiration					 = Convert.IsDBNull(row["Expiration"]) ? (DateTime?)null : (DateTime?)row["Expiration"];
						retObj._itemStoreId					 = Convert.IsDBNull(row["ItemStoreId"]) ? (Int32?)null : (Int32?)row["ItemStoreId"];
						retObj._recId					 = Convert.IsDBNull(row["RecId"]) ? (Int64?)null : (Int64?)row["RecId"];
						retObj._unitId					 = Convert.IsDBNull(row["UnitId"]) ? (Int32?)null : (Int32?)row["UnitId"];
						retObj._customDiscount					 = Convert.IsDBNull(row["CustomDiscount"]) ? (decimal?)null : (decimal?)row["CustomDiscount"];
						retObj._hasPromotion					 = Convert.IsDBNull(row["HasPromotion"]) ? (bool?)null : (bool?)row["HasPromotion"];
						retObj._totalReturn					 = Convert.IsDBNull(row["TotalReturn"]) ? (Int32?)null : (Int32?)row["TotalReturn"];
						retObj._returnQuantity					 = Convert.IsDBNull(row["ReturnQuantity"]) ? (Int32?)null : (Int32?)row["ReturnQuantity"];
						retObj._returnReasonId					 = Convert.IsDBNull(row["ReturnReasonId"]) ? (Int32?)null : (Int32?)row["ReturnReasonId"];
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._isTaxable					 = Convert.IsDBNull(row["IsTaxable"]) ? (bool?)null : (bool?)row["IsTaxable"];
						retObj._itemGroupId					 = Convert.IsDBNull(row["ItemGroupId"]) ? (Int32?)null : (Int32?)row["ItemGroupId"];
						retObj._vendorId					 = Convert.IsDBNull(row["VendorId"]) ? (Int32?)null : (Int32?)row["VendorId"];
						objList.Add(retObj);
					}
				}
				return objList;
			}
			catch
			{
				throw;
			}
			finally
			{
				staticConnection.Close();
				command.Dispose();
			}
		}

		///<Summary>
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static Int32 SelectAllCount()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesOrder_DetailVw_SelectAllCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{

				staticConnection.Open();
				Int32 retCount = (Int32)command.ExecuteScalar();

				return retCount;
			}
			catch
			{
				throw;
			}
			finally
			{
				staticConnection.Close();
				command.Dispose();
			}
		}

		///<Summary>
		///Select specific fields of all rows using criteriaquery api
		///This method returns specific fields of all data rows in the table using criteriaquery apiSalesOrder_DetailVw
		///</Summary>
		///<returns>
		///IDictionary-string, IList-object..
		///</returns>
		///<parameters>
		///IList<IDataProjection> listProjection, IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IDictionary<string, IList<object>> SelectAllByCriteriaProjection(IList<IDataProjection> listProjection, IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesOrder_DetailVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_DetailVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				IDictionary<string, IList<object>> dict = new Dictionary<string, IList<object>>();
				foreach (IDataProjection projection in listProjection)
				{
					IList<object> lst = new List<object>();
					dict.Add(projection.Member, lst);
					foreach (DataRow row in dt.Rows)
					{
						if (string.Compare(projection.Member, "DetailId", true) == 0) lst.Add(Convert.IsDBNull(row["DetailId"]) ? (Int64?)null : (Int64?)row["DetailId"]);
						if (string.Compare(projection.Member, "SalesId", true) == 0) lst.Add(Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"]);
						if (string.Compare(projection.Member, "ItemId", true) == 0) lst.Add(Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"]);
						if (string.Compare(projection.Member, "PublicPrice", true) == 0) lst.Add(Convert.IsDBNull(row["PublicPrice"]) ? (decimal?)null : (decimal?)row["PublicPrice"]);
						if (string.Compare(projection.Member, "ClientPrice", true) == 0) lst.Add(Convert.IsDBNull(row["ClientPrice"]) ? (decimal?)null : (decimal?)row["ClientPrice"]);
						if (string.Compare(projection.Member, "Quantity", true) == 0) lst.Add(Convert.IsDBNull(row["Quantity"]) ? (Int32?)null : (Int32?)row["Quantity"]);
						if (string.Compare(projection.Member, "LineValue", true) == 0) lst.Add(Convert.IsDBNull(row["LineValue"]) ? (decimal?)null : (decimal?)row["LineValue"]);
						if (string.Compare(projection.Member, "Discount", true) == 0) lst.Add(Convert.IsDBNull(row["Discount"]) ? (decimal?)null : (decimal?)row["Discount"]);
						if (string.Compare(projection.Member, "TaxValue", true) == 0) lst.Add(Convert.IsDBNull(row["TaxValue"]) ? (decimal?)null : (decimal?)row["TaxValue"]);
						if (string.Compare(projection.Member, "IsBouns", true) == 0) lst.Add(Convert.IsDBNull(row["IsBouns"]) ? (bool?)null : (bool?)row["IsBouns"]);
						if (string.Compare(projection.Member, "PromotionCode", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionCode"]) ? null : (string)row["PromotionCode"]);
						if (string.Compare(projection.Member, "ItemCode", true) == 0) lst.Add(Convert.IsDBNull(row["ItemCode"]) ? null : (string)row["ItemCode"]);
						if (string.Compare(projection.Member, "ItemNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["ItemNameEn"]) ? null : (string)row["ItemNameEn"]);
						if (string.Compare(projection.Member, "ItemNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["ItemNameAr"]) ? null : (string)row["ItemNameAr"]);
						if (string.Compare(projection.Member, "VendorNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["VendorNameAr"]) ? null : (string)row["VendorNameAr"]);
						if (string.Compare(projection.Member, "VendorNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["VendorNameEn"]) ? null : (string)row["VendorNameEn"]);
						if (string.Compare(projection.Member, "VendorCode", true) == 0) lst.Add(Convert.IsDBNull(row["VendorCode"]) ? null : (string)row["VendorCode"]);
						if (string.Compare(projection.Member, "Batch", true) == 0) lst.Add(Convert.IsDBNull(row["Batch"]) ? null : (string)row["Batch"]);
						if (string.Compare(projection.Member, "Expiration", true) == 0) lst.Add(Convert.IsDBNull(row["Expiration"]) ? (DateTime?)null : (DateTime?)row["Expiration"]);
						if (string.Compare(projection.Member, "ItemStoreId", true) == 0) lst.Add(Convert.IsDBNull(row["ItemStoreId"]) ? (Int32?)null : (Int32?)row["ItemStoreId"]);
						if (string.Compare(projection.Member, "RecId", true) == 0) lst.Add(Convert.IsDBNull(row["RecId"]) ? (Int64?)null : (Int64?)row["RecId"]);
						if (string.Compare(projection.Member, "UnitId", true) == 0) lst.Add(Convert.IsDBNull(row["UnitId"]) ? (Int32?)null : (Int32?)row["UnitId"]);
						if (string.Compare(projection.Member, "CustomDiscount", true) == 0) lst.Add(Convert.IsDBNull(row["CustomDiscount"]) ? (decimal?)null : (decimal?)row["CustomDiscount"]);
						if (string.Compare(projection.Member, "HasPromotion", true) == 0) lst.Add(Convert.IsDBNull(row["HasPromotion"]) ? (bool?)null : (bool?)row["HasPromotion"]);
						if (string.Compare(projection.Member, "TotalReturn", true) == 0) lst.Add(Convert.IsDBNull(row["TotalReturn"]) ? (Int32?)null : (Int32?)row["TotalReturn"]);
						if (string.Compare(projection.Member, "ReturnQuantity", true) == 0) lst.Add(Convert.IsDBNull(row["ReturnQuantity"]) ? (Int32?)null : (Int32?)row["ReturnQuantity"]);
						if (string.Compare(projection.Member, "ReturnReasonId", true) == 0) lst.Add(Convert.IsDBNull(row["ReturnReasonId"]) ? (Int32?)null : (Int32?)row["ReturnReasonId"]);
						if (string.Compare(projection.Member, "PromotionId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"]);
						if (string.Compare(projection.Member, "IsTaxable", true) == 0) lst.Add(Convert.IsDBNull(row["IsTaxable"]) ? (bool?)null : (bool?)row["IsTaxable"]);
						if (string.Compare(projection.Member, "ItemGroupId", true) == 0) lst.Add(Convert.IsDBNull(row["ItemGroupId"]) ? (Int32?)null : (Int32?)row["ItemGroupId"]);
						if (string.Compare(projection.Member, "VendorId", true) == 0) lst.Add(Convert.IsDBNull(row["VendorId"]) ? (Int32?)null : (Int32?)row["VendorId"]);
					}
				}
				return dict;
			}
			catch
			{
				throw;
			}
			finally
			{
				staticConnection.Close();
				command.Dispose();
			}
		}

		///<Summary>
		///Select all rows by filter criteria
		///This method returns all data rows in the table using criteriaquery api SalesOrder_DetailVw
		///</Summary>
		///<returns>
		///IList-DAOSalesOrderDetailVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOSalesOrderDetailVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesOrder_DetailVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_DetailVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSalesOrderDetailVw> objList = new List<DAOSalesOrderDetailVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSalesOrderDetailVw retObj = new DAOSalesOrderDetailVw();
						retObj._detailId					 = Convert.IsDBNull(row["DetailId"]) ? (Int64?)null : (Int64?)row["DetailId"];
						retObj._salesId					 = Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"];
						retObj._itemId					 = Convert.IsDBNull(row["ItemId"]) ? (Int32?)null : (Int32?)row["ItemId"];
						retObj._publicPrice					 = Convert.IsDBNull(row["PublicPrice"]) ? (decimal?)null : (decimal?)row["PublicPrice"];
						retObj._clientPrice					 = Convert.IsDBNull(row["ClientPrice"]) ? (decimal?)null : (decimal?)row["ClientPrice"];
						retObj._quantity					 = Convert.IsDBNull(row["Quantity"]) ? (Int32?)null : (Int32?)row["Quantity"];
						retObj._lineValue					 = Convert.IsDBNull(row["LineValue"]) ? (decimal?)null : (decimal?)row["LineValue"];
						retObj._discount					 = Convert.IsDBNull(row["Discount"]) ? (decimal?)null : (decimal?)row["Discount"];
						retObj._taxValue					 = Convert.IsDBNull(row["TaxValue"]) ? (decimal?)null : (decimal?)row["TaxValue"];
						retObj._isBouns					 = Convert.IsDBNull(row["IsBouns"]) ? (bool?)null : (bool?)row["IsBouns"];
						retObj._promotionCode					 = Convert.IsDBNull(row["PromotionCode"]) ? null : (string)row["PromotionCode"];
						retObj._itemCode					 = Convert.IsDBNull(row["ItemCode"]) ? null : (string)row["ItemCode"];
						retObj._itemNameEn					 = Convert.IsDBNull(row["ItemNameEn"]) ? null : (string)row["ItemNameEn"];
						retObj._itemNameAr					 = Convert.IsDBNull(row["ItemNameAr"]) ? null : (string)row["ItemNameAr"];
						retObj._vendorNameAr					 = Convert.IsDBNull(row["VendorNameAr"]) ? null : (string)row["VendorNameAr"];
						retObj._vendorNameEn					 = Convert.IsDBNull(row["VendorNameEn"]) ? null : (string)row["VendorNameEn"];
						retObj._vendorCode					 = Convert.IsDBNull(row["VendorCode"]) ? null : (string)row["VendorCode"];
						retObj._batch					 = Convert.IsDBNull(row["Batch"]) ? null : (string)row["Batch"];
						retObj._expiration					 = Convert.IsDBNull(row["Expiration"]) ? (DateTime?)null : (DateTime?)row["Expiration"];
						retObj._itemStoreId					 = Convert.IsDBNull(row["ItemStoreId"]) ? (Int32?)null : (Int32?)row["ItemStoreId"];
						retObj._recId					 = Convert.IsDBNull(row["RecId"]) ? (Int64?)null : (Int64?)row["RecId"];
						retObj._unitId					 = Convert.IsDBNull(row["UnitId"]) ? (Int32?)null : (Int32?)row["UnitId"];
						retObj._customDiscount					 = Convert.IsDBNull(row["CustomDiscount"]) ? (decimal?)null : (decimal?)row["CustomDiscount"];
						retObj._hasPromotion					 = Convert.IsDBNull(row["HasPromotion"]) ? (bool?)null : (bool?)row["HasPromotion"];
						retObj._totalReturn					 = Convert.IsDBNull(row["TotalReturn"]) ? (Int32?)null : (Int32?)row["TotalReturn"];
						retObj._returnQuantity					 = Convert.IsDBNull(row["ReturnQuantity"]) ? (Int32?)null : (Int32?)row["ReturnQuantity"];
						retObj._returnReasonId					 = Convert.IsDBNull(row["ReturnReasonId"]) ? (Int32?)null : (Int32?)row["ReturnReasonId"];
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._isTaxable					 = Convert.IsDBNull(row["IsTaxable"]) ? (bool?)null : (bool?)row["IsTaxable"];
						retObj._itemGroupId					 = Convert.IsDBNull(row["ItemGroupId"]) ? (Int32?)null : (Int32?)row["ItemGroupId"];
						retObj._vendorId					 = Convert.IsDBNull(row["VendorId"]) ? (Int32?)null : (Int32?)row["VendorId"];
						objList.Add(retObj);
					}
				}
				return objList;
			}
			catch
			{
				throw;
			}
			finally
			{
				staticConnection.Close();
				command.Dispose();
			}
		}

		///<Summary>
		///Select count of all rows using criteriaquery api
		///This method returns all data rows in the table using criteriaquery api SalesOrder_DetailVw
		///</Summary>
		///<returns>
		///Int32
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion
		///</parameters>
		public static Int32 SelectAllByCriteriaCount(IList<IDataCriterion> listCriterion)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesOrder_DetailVw_SelectAllByCriteriaCount, null, listCriterion, null);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{

				staticConnection.Open();
				Int32 retCount = (Int32)command.ExecuteScalar();

				return retCount;
			}
			catch
			{
				throw;
			}
			finally
			{
				staticConnection.Close();
				command.Dispose();
			}
		}

		#endregion

		#region member properties

		public Int64? DetailId
		{
			get
			{
				return _detailId;
			}
			set
			{
				_detailId = value;
			}
		}

		public Int64? SalesId
		{
			get
			{
				return _salesId;
			}
			set
			{
				_salesId = value;
			}
		}

		public Int32? ItemId
		{
			get
			{
				return _itemId;
			}
			set
			{
				_itemId = value;
			}
		}

		public decimal? PublicPrice
		{
			get
			{
				return _publicPrice;
			}
			set
			{
				_publicPrice = value;
			}
		}

		public decimal? ClientPrice
		{
			get
			{
				return _clientPrice;
			}
			set
			{
				_clientPrice = value;
			}
		}

		public Int32? Quantity
		{
			get
			{
				return _quantity;
			}
			set
			{
				_quantity = value;
			}
		}

		public decimal? LineValue
		{
			get
			{
				return _lineValue;
			}
			set
			{
				_lineValue = value;
			}
		}

		public decimal? Discount
		{
			get
			{
				return _discount;
			}
			set
			{
				_discount = value;
			}
		}

		public decimal? TaxValue
		{
			get
			{
				return _taxValue;
			}
			set
			{
				_taxValue = value;
			}
		}

		public bool? IsBouns
		{
			get
			{
				return _isBouns;
			}
			set
			{
				_isBouns = value;
			}
		}

		public string PromotionCode
		{
			get
			{
				return _promotionCode;
			}
			set
			{
				_promotionCode = value;
			}
		}

		public string ItemCode
		{
			get
			{
				return _itemCode;
			}
			set
			{
				_itemCode = value;
			}
		}

		public string ItemNameEn
		{
			get
			{
				return _itemNameEn;
			}
			set
			{
				_itemNameEn = value;
			}
		}

		public string ItemNameAr
		{
			get
			{
				return _itemNameAr;
			}
			set
			{
				_itemNameAr = value;
			}
		}

		public string VendorNameAr
		{
			get
			{
				return _vendorNameAr;
			}
			set
			{
				_vendorNameAr = value;
			}
		}

		public string VendorNameEn
		{
			get
			{
				return _vendorNameEn;
			}
			set
			{
				_vendorNameEn = value;
			}
		}

		public string VendorCode
		{
			get
			{
				return _vendorCode;
			}
			set
			{
				_vendorCode = value;
			}
		}

		public string Batch
		{
			get
			{
				return _batch;
			}
			set
			{
				_batch = value;
			}
		}

		public DateTime? Expiration
		{
			get
			{
				return _expiration;
			}
			set
			{
				_expiration = value;
			}
		}

		public Int32? ItemStoreId
		{
			get
			{
				return _itemStoreId;
			}
			set
			{
				_itemStoreId = value;
			}
		}

		public Int64? RecId
		{
			get
			{
				return _recId;
			}
			set
			{
				_recId = value;
			}
		}

		public Int32? UnitId
		{
			get
			{
				return _unitId;
			}
			set
			{
				_unitId = value;
			}
		}

		public decimal? CustomDiscount
		{
			get
			{
				return _customDiscount;
			}
			set
			{
				_customDiscount = value;
			}
		}

		public bool? HasPromotion
		{
			get
			{
				return _hasPromotion;
			}
			set
			{
				_hasPromotion = value;
			}
		}

		public Int32? TotalReturn
		{
			get
			{
				return _totalReturn;
			}
			set
			{
				_totalReturn = value;
			}
		}

		public Int32? ReturnQuantity
		{
			get
			{
				return _returnQuantity;
			}
			set
			{
				_returnQuantity = value;
			}
		}

		public Int32? ReturnReasonId
		{
			get
			{
				return _returnReasonId;
			}
			set
			{
				_returnReasonId = value;
			}
		}

		public Int32? PromotionId
		{
			get
			{
				return _promotionId;
			}
			set
			{
				_promotionId = value;
			}
		}

		public bool? IsTaxable
		{
			get
			{
				return _isTaxable;
			}
			set
			{
				_isTaxable = value;
			}
		}

		public Int32? ItemGroupId
		{
			get
			{
				return _itemGroupId;
			}
			set
			{
				_itemGroupId = value;
			}
		}

		public Int32? VendorId
		{
			get
			{
				return _vendorId;
			}
			set
			{
				_vendorId = value;
			}
		}

		#endregion
	}
}

#region inline sql procs
namespace SofiForce.DataObjects
{
	public partial class InlineProcs
	{
		internal static string ctprSalesOrder_DetailVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[DetailId]
			,[SalesId]
			,[ItemId]
			,[PublicPrice]
			,[ClientPrice]
			,[Quantity]
			,[LineValue]
			,[Discount]
			,[TaxValue]
			,[IsBouns]
			,[PromotionCode]
			,[ItemCode]
			,[ItemNameEn]
			,[ItemNameAr]
			,[VendorNameAr]
			,[VendorNameEn]
			,[VendorCode]
			,[Batch]
			,[Expiration]
			,[ItemStoreId]
			,[RecId]
			,[UnitId]
			,[CustomDiscount]
			,[HasPromotion]
			,[TotalReturn]
			,[ReturnQuantity]
			,[ReturnReasonId]
			,[PromotionId]
			,[IsTaxable]
			,[ItemGroupId]
			,[VendorId]
			FROM [dbo].[SalesOrder_DetailVw]
			";

		internal static string ctprSalesOrder_DetailVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[SalesOrder_DetailVw]
			";

		internal static string ctprSalesOrder_DetailVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[SalesOrder_DetailVw]
			##CRITERIA##
			";

		internal static string ctprSalesOrder_DetailVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[DetailId]
			,[SalesId]
			,[ItemId]
			,[PublicPrice]
			,[ClientPrice]
			,[Quantity]
			,[LineValue]
			,[Discount]
			,[TaxValue]
			,[IsBouns]
			,[PromotionCode]
			,[ItemCode]
			,[ItemNameEn]
			,[ItemNameAr]
			,[VendorNameAr]
			,[VendorNameEn]
			,[VendorCode]
			,[Batch]
			,[Expiration]
			,[ItemStoreId]
			,[RecId]
			,[UnitId]
			,[CustomDiscount]
			,[HasPromotion]
			,[TotalReturn]
			,[ReturnQuantity]
			,[ReturnReasonId]
			,[PromotionId]
			,[IsTaxable]
			,[ItemGroupId]
			,[VendorId]
			FROM [dbo].[SalesOrder_DetailVw]
			##CRITERIA##
			";

		internal static string ctprSalesOrder_DetailVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[SalesOrder_DetailVw]
			##CRITERIA##
			";

	}
}
#endregion
