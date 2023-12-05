/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 6/24/2023 12:17:49 PM
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SofiForce.DataObjects.Interfaces;

namespace SofiForce.DataObjects
{
	public partial class DAOSalesOrderPromotionByItemAllVw : zSofiForceConn_BaseData
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
		protected string _itemCode;
		protected string _itemNameEn;
		protected string _itemNameAr;
		protected Int32? _vendorId;
		protected string _vendorCode;
		protected string _vendorNameEn;
		protected string _vendorNameAr;
		protected Int64? _salesId;
		#endregion

		#region class methods
		public DAOSalesOrderPromotionByItemAllVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table SalesOrder_PromotionByItemAllVw
		///</Summary>
		///<returns>
		///IList-DAOSalesOrderPromotionByItemAllVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOSalesOrderPromotionByItemAllVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSalesOrder_PromotionByItemAllVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_PromotionByItemAllVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSalesOrderPromotionByItemAllVw> objList = new List<DAOSalesOrderPromotionByItemAllVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSalesOrderPromotionByItemAllVw retObj = new DAOSalesOrderPromotionByItemAllVw();
						retObj._promotionCode					 = Convert.IsDBNull(row["PromotionCode"]) ? null : (string)row["PromotionCode"];
						retObj._validFrom					 = Convert.IsDBNull(row["ValidFrom"]) ? (DateTime?)null : (DateTime?)row["ValidFrom"];
						retObj._validTo					 = Convert.IsDBNull(row["ValidTo"]) ? (DateTime?)null : (DateTime?)row["ValidTo"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._promotionTypeNameAr					 = Convert.IsDBNull(row["PromotionTypeNameAr"]) ? null : (string)row["PromotionTypeNameAr"];
						retObj._promotionTypeNameEn					 = Convert.IsDBNull(row["PromotionTypeNameEn"]) ? null : (string)row["PromotionTypeNameEn"];
						retObj._promotionTypeId					 = Convert.IsDBNull(row["PromotionTypeId"]) ? (Int32?)null : (Int32?)row["PromotionTypeId"];
						retObj._priority					 = Convert.IsDBNull(row["Priority"]) ? (Int32?)null : (Int32?)row["Priority"];
						retObj._repeats					 = Convert.IsDBNull(row["Repeats"]) ? (Int32?)null : (Int32?)row["Repeats"];
						retObj._clientCode					 = Convert.IsDBNull(row["ClientCode"]) ? null : (string)row["ClientCode"];
						retObj._clientNameAr					 = Convert.IsDBNull(row["ClientNameAr"]) ? null : (string)row["ClientNameAr"];
						retObj._clientNameEn					 = Convert.IsDBNull(row["ClientNameEn"]) ? null : (string)row["ClientNameEn"];
						retObj._salesCode					 = Convert.IsDBNull(row["SalesCode"]) ? null : (string)row["SalesCode"];
						retObj._netTotal					 = Convert.IsDBNull(row["NetTotal"]) ? (decimal?)null : (decimal?)row["NetTotal"];
						retObj._invoiceDate					 = Convert.IsDBNull(row["InvoiceDate"]) ? (DateTime?)null : (DateTime?)row["InvoiceDate"];
						retObj._invoiceCode					 = Convert.IsDBNull(row["InvoiceCode"]) ? null : (string)row["InvoiceCode"];
						retObj._deliveryTotal					 = Convert.IsDBNull(row["DeliveryTotal"]) ? (decimal?)null : (decimal?)row["DeliveryTotal"];
						retObj._customDiscountTotal					 = Convert.IsDBNull(row["CustomDiscountTotal"]) ? (decimal?)null : (decimal?)row["CustomDiscountTotal"];
						retObj._customDiscountValue					 = Convert.IsDBNull(row["CustomDiscountValue"]) ? (decimal?)null : (decimal?)row["CustomDiscountValue"];
						retObj._customDiscountTypeId					 = Convert.IsDBNull(row["CustomDiscountTypeId"]) ? (Int32?)null : (Int32?)row["CustomDiscountTypeId"];
						retObj._cashDiscountTotal					 = Convert.IsDBNull(row["CashDiscountTotal"]) ? (decimal?)null : (decimal?)row["CashDiscountTotal"];
						retObj._taxTotal					 = Convert.IsDBNull(row["TaxTotal"]) ? (decimal?)null : (decimal?)row["TaxTotal"];
						retObj._itemDiscountTotal					 = Convert.IsDBNull(row["ItemDiscountTotal"]) ? (decimal?)null : (decimal?)row["ItemDiscountTotal"];
						retObj._itemTotal					 = Convert.IsDBNull(row["ItemTotal"]) ? (decimal?)null : (decimal?)row["ItemTotal"];
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._itemCode					 = Convert.IsDBNull(row["ItemCode"]) ? null : (string)row["ItemCode"];
						retObj._itemNameEn					 = Convert.IsDBNull(row["ItemNameEn"]) ? null : (string)row["ItemNameEn"];
						retObj._itemNameAr					 = Convert.IsDBNull(row["ItemNameAr"]) ? null : (string)row["ItemNameAr"];
						retObj._vendorId					 = Convert.IsDBNull(row["VendorId"]) ? (Int32?)null : (Int32?)row["VendorId"];
						retObj._vendorCode					 = Convert.IsDBNull(row["VendorCode"]) ? null : (string)row["VendorCode"];
						retObj._vendorNameEn					 = Convert.IsDBNull(row["VendorNameEn"]) ? null : (string)row["VendorNameEn"];
						retObj._vendorNameAr					 = Convert.IsDBNull(row["VendorNameAr"]) ? null : (string)row["VendorNameAr"];
						retObj._salesId					 = Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"];
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
			command.CommandText = InlineProcs.ctprSalesOrder_PromotionByItemAllVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiSalesOrder_PromotionByItemAllVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesOrder_PromotionByItemAllVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_PromotionByItemAllVw");
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
						if (string.Compare(projection.Member, "PromotionCode", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionCode"]) ? null : (string)row["PromotionCode"]);
						if (string.Compare(projection.Member, "ValidFrom", true) == 0) lst.Add(Convert.IsDBNull(row["ValidFrom"]) ? (DateTime?)null : (DateTime?)row["ValidFrom"]);
						if (string.Compare(projection.Member, "ValidTo", true) == 0) lst.Add(Convert.IsDBNull(row["ValidTo"]) ? (DateTime?)null : (DateTime?)row["ValidTo"]);
						if (string.Compare(projection.Member, "IsActive", true) == 0) lst.Add(Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"]);
						if (string.Compare(projection.Member, "PromotionTypeNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionTypeNameAr"]) ? null : (string)row["PromotionTypeNameAr"]);
						if (string.Compare(projection.Member, "PromotionTypeNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionTypeNameEn"]) ? null : (string)row["PromotionTypeNameEn"]);
						if (string.Compare(projection.Member, "PromotionTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionTypeId"]) ? (Int32?)null : (Int32?)row["PromotionTypeId"]);
						if (string.Compare(projection.Member, "Priority", true) == 0) lst.Add(Convert.IsDBNull(row["Priority"]) ? (Int32?)null : (Int32?)row["Priority"]);
						if (string.Compare(projection.Member, "Repeats", true) == 0) lst.Add(Convert.IsDBNull(row["Repeats"]) ? (Int32?)null : (Int32?)row["Repeats"]);
						if (string.Compare(projection.Member, "ClientCode", true) == 0) lst.Add(Convert.IsDBNull(row["ClientCode"]) ? null : (string)row["ClientCode"]);
						if (string.Compare(projection.Member, "ClientNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["ClientNameAr"]) ? null : (string)row["ClientNameAr"]);
						if (string.Compare(projection.Member, "ClientNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["ClientNameEn"]) ? null : (string)row["ClientNameEn"]);
						if (string.Compare(projection.Member, "SalesCode", true) == 0) lst.Add(Convert.IsDBNull(row["SalesCode"]) ? null : (string)row["SalesCode"]);
						if (string.Compare(projection.Member, "NetTotal", true) == 0) lst.Add(Convert.IsDBNull(row["NetTotal"]) ? (decimal?)null : (decimal?)row["NetTotal"]);
						if (string.Compare(projection.Member, "InvoiceDate", true) == 0) lst.Add(Convert.IsDBNull(row["InvoiceDate"]) ? (DateTime?)null : (DateTime?)row["InvoiceDate"]);
						if (string.Compare(projection.Member, "InvoiceCode", true) == 0) lst.Add(Convert.IsDBNull(row["InvoiceCode"]) ? null : (string)row["InvoiceCode"]);
						if (string.Compare(projection.Member, "DeliveryTotal", true) == 0) lst.Add(Convert.IsDBNull(row["DeliveryTotal"]) ? (decimal?)null : (decimal?)row["DeliveryTotal"]);
						if (string.Compare(projection.Member, "CustomDiscountTotal", true) == 0) lst.Add(Convert.IsDBNull(row["CustomDiscountTotal"]) ? (decimal?)null : (decimal?)row["CustomDiscountTotal"]);
						if (string.Compare(projection.Member, "CustomDiscountValue", true) == 0) lst.Add(Convert.IsDBNull(row["CustomDiscountValue"]) ? (decimal?)null : (decimal?)row["CustomDiscountValue"]);
						if (string.Compare(projection.Member, "CustomDiscountTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["CustomDiscountTypeId"]) ? (Int32?)null : (Int32?)row["CustomDiscountTypeId"]);
						if (string.Compare(projection.Member, "CashDiscountTotal", true) == 0) lst.Add(Convert.IsDBNull(row["CashDiscountTotal"]) ? (decimal?)null : (decimal?)row["CashDiscountTotal"]);
						if (string.Compare(projection.Member, "TaxTotal", true) == 0) lst.Add(Convert.IsDBNull(row["TaxTotal"]) ? (decimal?)null : (decimal?)row["TaxTotal"]);
						if (string.Compare(projection.Member, "ItemDiscountTotal", true) == 0) lst.Add(Convert.IsDBNull(row["ItemDiscountTotal"]) ? (decimal?)null : (decimal?)row["ItemDiscountTotal"]);
						if (string.Compare(projection.Member, "ItemTotal", true) == 0) lst.Add(Convert.IsDBNull(row["ItemTotal"]) ? (decimal?)null : (decimal?)row["ItemTotal"]);
						if (string.Compare(projection.Member, "PromotionId", true) == 0) lst.Add(Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"]);
						if (string.Compare(projection.Member, "ItemCode", true) == 0) lst.Add(Convert.IsDBNull(row["ItemCode"]) ? null : (string)row["ItemCode"]);
						if (string.Compare(projection.Member, "ItemNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["ItemNameEn"]) ? null : (string)row["ItemNameEn"]);
						if (string.Compare(projection.Member, "ItemNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["ItemNameAr"]) ? null : (string)row["ItemNameAr"]);
						if (string.Compare(projection.Member, "VendorId", true) == 0) lst.Add(Convert.IsDBNull(row["VendorId"]) ? (Int32?)null : (Int32?)row["VendorId"]);
						if (string.Compare(projection.Member, "VendorCode", true) == 0) lst.Add(Convert.IsDBNull(row["VendorCode"]) ? null : (string)row["VendorCode"]);
						if (string.Compare(projection.Member, "VendorNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["VendorNameEn"]) ? null : (string)row["VendorNameEn"]);
						if (string.Compare(projection.Member, "VendorNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["VendorNameAr"]) ? null : (string)row["VendorNameAr"]);
						if (string.Compare(projection.Member, "SalesId", true) == 0) lst.Add(Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"]);
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
		///This method returns all data rows in the table using criteriaquery api SalesOrder_PromotionByItemAllVw
		///</Summary>
		///<returns>
		///IList-DAOSalesOrderPromotionByItemAllVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOSalesOrderPromotionByItemAllVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesOrder_PromotionByItemAllVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("SalesOrder_PromotionByItemAllVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSalesOrderPromotionByItemAllVw> objList = new List<DAOSalesOrderPromotionByItemAllVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSalesOrderPromotionByItemAllVw retObj = new DAOSalesOrderPromotionByItemAllVw();
						retObj._promotionCode					 = Convert.IsDBNull(row["PromotionCode"]) ? null : (string)row["PromotionCode"];
						retObj._validFrom					 = Convert.IsDBNull(row["ValidFrom"]) ? (DateTime?)null : (DateTime?)row["ValidFrom"];
						retObj._validTo					 = Convert.IsDBNull(row["ValidTo"]) ? (DateTime?)null : (DateTime?)row["ValidTo"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._promotionTypeNameAr					 = Convert.IsDBNull(row["PromotionTypeNameAr"]) ? null : (string)row["PromotionTypeNameAr"];
						retObj._promotionTypeNameEn					 = Convert.IsDBNull(row["PromotionTypeNameEn"]) ? null : (string)row["PromotionTypeNameEn"];
						retObj._promotionTypeId					 = Convert.IsDBNull(row["PromotionTypeId"]) ? (Int32?)null : (Int32?)row["PromotionTypeId"];
						retObj._priority					 = Convert.IsDBNull(row["Priority"]) ? (Int32?)null : (Int32?)row["Priority"];
						retObj._repeats					 = Convert.IsDBNull(row["Repeats"]) ? (Int32?)null : (Int32?)row["Repeats"];
						retObj._clientCode					 = Convert.IsDBNull(row["ClientCode"]) ? null : (string)row["ClientCode"];
						retObj._clientNameAr					 = Convert.IsDBNull(row["ClientNameAr"]) ? null : (string)row["ClientNameAr"];
						retObj._clientNameEn					 = Convert.IsDBNull(row["ClientNameEn"]) ? null : (string)row["ClientNameEn"];
						retObj._salesCode					 = Convert.IsDBNull(row["SalesCode"]) ? null : (string)row["SalesCode"];
						retObj._netTotal					 = Convert.IsDBNull(row["NetTotal"]) ? (decimal?)null : (decimal?)row["NetTotal"];
						retObj._invoiceDate					 = Convert.IsDBNull(row["InvoiceDate"]) ? (DateTime?)null : (DateTime?)row["InvoiceDate"];
						retObj._invoiceCode					 = Convert.IsDBNull(row["InvoiceCode"]) ? null : (string)row["InvoiceCode"];
						retObj._deliveryTotal					 = Convert.IsDBNull(row["DeliveryTotal"]) ? (decimal?)null : (decimal?)row["DeliveryTotal"];
						retObj._customDiscountTotal					 = Convert.IsDBNull(row["CustomDiscountTotal"]) ? (decimal?)null : (decimal?)row["CustomDiscountTotal"];
						retObj._customDiscountValue					 = Convert.IsDBNull(row["CustomDiscountValue"]) ? (decimal?)null : (decimal?)row["CustomDiscountValue"];
						retObj._customDiscountTypeId					 = Convert.IsDBNull(row["CustomDiscountTypeId"]) ? (Int32?)null : (Int32?)row["CustomDiscountTypeId"];
						retObj._cashDiscountTotal					 = Convert.IsDBNull(row["CashDiscountTotal"]) ? (decimal?)null : (decimal?)row["CashDiscountTotal"];
						retObj._taxTotal					 = Convert.IsDBNull(row["TaxTotal"]) ? (decimal?)null : (decimal?)row["TaxTotal"];
						retObj._itemDiscountTotal					 = Convert.IsDBNull(row["ItemDiscountTotal"]) ? (decimal?)null : (decimal?)row["ItemDiscountTotal"];
						retObj._itemTotal					 = Convert.IsDBNull(row["ItemTotal"]) ? (decimal?)null : (decimal?)row["ItemTotal"];
						retObj._promotionId					 = Convert.IsDBNull(row["PromotionId"]) ? (Int32?)null : (Int32?)row["PromotionId"];
						retObj._itemCode					 = Convert.IsDBNull(row["ItemCode"]) ? null : (string)row["ItemCode"];
						retObj._itemNameEn					 = Convert.IsDBNull(row["ItemNameEn"]) ? null : (string)row["ItemNameEn"];
						retObj._itemNameAr					 = Convert.IsDBNull(row["ItemNameAr"]) ? null : (string)row["ItemNameAr"];
						retObj._vendorId					 = Convert.IsDBNull(row["VendorId"]) ? (Int32?)null : (Int32?)row["VendorId"];
						retObj._vendorCode					 = Convert.IsDBNull(row["VendorCode"]) ? null : (string)row["VendorCode"];
						retObj._vendorNameEn					 = Convert.IsDBNull(row["VendorNameEn"]) ? null : (string)row["VendorNameEn"];
						retObj._vendorNameAr					 = Convert.IsDBNull(row["VendorNameAr"]) ? null : (string)row["VendorNameAr"];
						retObj._salesId					 = Convert.IsDBNull(row["SalesId"]) ? (Int64?)null : (Int64?)row["SalesId"];
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
		///This method returns all data rows in the table using criteriaquery api SalesOrder_PromotionByItemAllVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSalesOrder_PromotionByItemAllVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public DateTime? ValidFrom
		{
			get
			{
				return _validFrom;
			}
			set
			{
				_validFrom = value;
			}
		}

		public DateTime? ValidTo
		{
			get
			{
				return _validTo;
			}
			set
			{
				_validTo = value;
			}
		}

		public bool? IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActive = value;
			}
		}

		public string PromotionTypeNameAr
		{
			get
			{
				return _promotionTypeNameAr;
			}
			set
			{
				_promotionTypeNameAr = value;
			}
		}

		public string PromotionTypeNameEn
		{
			get
			{
				return _promotionTypeNameEn;
			}
			set
			{
				_promotionTypeNameEn = value;
			}
		}

		public Int32? PromotionTypeId
		{
			get
			{
				return _promotionTypeId;
			}
			set
			{
				_promotionTypeId = value;
			}
		}

		public Int32? Priority
		{
			get
			{
				return _priority;
			}
			set
			{
				_priority = value;
			}
		}

		public Int32? Repeats
		{
			get
			{
				return _repeats;
			}
			set
			{
				_repeats = value;
			}
		}

		public string ClientCode
		{
			get
			{
				return _clientCode;
			}
			set
			{
				_clientCode = value;
			}
		}

		public string ClientNameAr
		{
			get
			{
				return _clientNameAr;
			}
			set
			{
				_clientNameAr = value;
			}
		}

		public string ClientNameEn
		{
			get
			{
				return _clientNameEn;
			}
			set
			{
				_clientNameEn = value;
			}
		}

		public string SalesCode
		{
			get
			{
				return _salesCode;
			}
			set
			{
				_salesCode = value;
			}
		}

		public decimal? NetTotal
		{
			get
			{
				return _netTotal;
			}
			set
			{
				_netTotal = value;
			}
		}

		public DateTime? InvoiceDate
		{
			get
			{
				return _invoiceDate;
			}
			set
			{
				_invoiceDate = value;
			}
		}

		public string InvoiceCode
		{
			get
			{
				return _invoiceCode;
			}
			set
			{
				_invoiceCode = value;
			}
		}

		public decimal? DeliveryTotal
		{
			get
			{
				return _deliveryTotal;
			}
			set
			{
				_deliveryTotal = value;
			}
		}

		public decimal? CustomDiscountTotal
		{
			get
			{
				return _customDiscountTotal;
			}
			set
			{
				_customDiscountTotal = value;
			}
		}

		public decimal? CustomDiscountValue
		{
			get
			{
				return _customDiscountValue;
			}
			set
			{
				_customDiscountValue = value;
			}
		}

		public Int32? CustomDiscountTypeId
		{
			get
			{
				return _customDiscountTypeId;
			}
			set
			{
				_customDiscountTypeId = value;
			}
		}

		public decimal? CashDiscountTotal
		{
			get
			{
				return _cashDiscountTotal;
			}
			set
			{
				_cashDiscountTotal = value;
			}
		}

		public decimal? TaxTotal
		{
			get
			{
				return _taxTotal;
			}
			set
			{
				_taxTotal = value;
			}
		}

		public decimal? ItemDiscountTotal
		{
			get
			{
				return _itemDiscountTotal;
			}
			set
			{
				_itemDiscountTotal = value;
			}
		}

		public decimal? ItemTotal
		{
			get
			{
				return _itemTotal;
			}
			set
			{
				_itemTotal = value;
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

		#endregion
	}
}

#region inline sql procs
namespace SofiForce.DataObjects
{
	public partial class InlineProcs
	{
		internal static string ctprSalesOrder_PromotionByItemAllVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[PromotionCode]
			,[ValidFrom]
			,[ValidTo]
			,[IsActive]
			,[PromotionTypeNameAr]
			,[PromotionTypeNameEn]
			,[PromotionTypeId]
			,[Priority]
			,[Repeats]
			,[ClientCode]
			,[ClientNameAr]
			,[ClientNameEn]
			,[SalesCode]
			,[NetTotal]
			,[InvoiceDate]
			,[InvoiceCode]
			,[DeliveryTotal]
			,[CustomDiscountTotal]
			,[CustomDiscountValue]
			,[CustomDiscountTypeId]
			,[CashDiscountTotal]
			,[TaxTotal]
			,[ItemDiscountTotal]
			,[ItemTotal]
			,[PromotionId]
			,[ItemCode]
			,[ItemNameEn]
			,[ItemNameAr]
			,[VendorId]
			,[VendorCode]
			,[VendorNameEn]
			,[VendorNameAr]
			,[SalesId]
			FROM [dbo].[SalesOrder_PromotionByItemAllVw]
			";

		internal static string ctprSalesOrder_PromotionByItemAllVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[SalesOrder_PromotionByItemAllVw]
			";

		internal static string ctprSalesOrder_PromotionByItemAllVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[SalesOrder_PromotionByItemAllVw]
			##CRITERIA##
			";

		internal static string ctprSalesOrder_PromotionByItemAllVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[PromotionCode]
			,[ValidFrom]
			,[ValidTo]
			,[IsActive]
			,[PromotionTypeNameAr]
			,[PromotionTypeNameEn]
			,[PromotionTypeId]
			,[Priority]
			,[Repeats]
			,[ClientCode]
			,[ClientNameAr]
			,[ClientNameEn]
			,[SalesCode]
			,[NetTotal]
			,[InvoiceDate]
			,[InvoiceCode]
			,[DeliveryTotal]
			,[CustomDiscountTotal]
			,[CustomDiscountValue]
			,[CustomDiscountTypeId]
			,[CashDiscountTotal]
			,[TaxTotal]
			,[ItemDiscountTotal]
			,[ItemTotal]
			,[PromotionId]
			,[ItemCode]
			,[ItemNameEn]
			,[ItemNameAr]
			,[VendorId]
			,[VendorCode]
			,[VendorNameEn]
			,[VendorNameAr]
			,[SalesId]
			FROM [dbo].[SalesOrder_PromotionByItemAllVw]
			##CRITERIA##
			";

		internal static string ctprSalesOrder_PromotionByItemAllVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[SalesOrder_PromotionByItemAllVw]
			##CRITERIA##
			";

	}
}
#endregion
