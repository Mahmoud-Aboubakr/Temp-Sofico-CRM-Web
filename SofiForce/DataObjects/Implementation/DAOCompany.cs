/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 9/9/2023 5:10:24 PM
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SofiForce.DataObjects.Interfaces;

namespace SofiForce.DataObjects
{
	public partial class DAOCompany : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _companyId;
		protected string _companyCode;
		protected string _companyNameEn;
		protected string _companyNameAr;
		protected string _companyDesc;
		protected bool? _isActive;
		protected bool? _canEdit;
		protected bool? _canDelete;
		protected string _icon;
		protected string _color;
		protected Int32? _displayOrder;
		protected Int32? _prefexClient;
		protected Int32? _prefexItem;
		protected bool? _taxPromotion;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		#endregion

		#region class methods
		public DAOCompany()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table Company based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOCompany
		///</returns>
		///<parameters>
		///Int32? companyId
		///</parameters>
		public static DAOCompany SelectOne(Int32? companyId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprCompany_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Company");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@CompanyId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)companyId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOCompany retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOCompany();
					retObj._companyId					 = Convert.IsDBNull(dt.Rows[0]["CompanyId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["CompanyId"];
					retObj._companyCode					 = Convert.IsDBNull(dt.Rows[0]["CompanyCode"]) ? null : (string)dt.Rows[0]["CompanyCode"];
					retObj._companyNameEn					 = Convert.IsDBNull(dt.Rows[0]["CompanyNameEn"]) ? null : (string)dt.Rows[0]["CompanyNameEn"];
					retObj._companyNameAr					 = Convert.IsDBNull(dt.Rows[0]["CompanyNameAr"]) ? null : (string)dt.Rows[0]["CompanyNameAr"];
					retObj._companyDesc					 = Convert.IsDBNull(dt.Rows[0]["CompanyDesc"]) ? null : (string)dt.Rows[0]["CompanyDesc"];
					retObj._isActive					 = Convert.IsDBNull(dt.Rows[0]["IsActive"]) ? (bool?)null : (bool?)dt.Rows[0]["IsActive"];
					retObj._canEdit					 = Convert.IsDBNull(dt.Rows[0]["CanEdit"]) ? (bool?)null : (bool?)dt.Rows[0]["CanEdit"];
					retObj._canDelete					 = Convert.IsDBNull(dt.Rows[0]["CanDelete"]) ? (bool?)null : (bool?)dt.Rows[0]["CanDelete"];
					retObj._icon					 = Convert.IsDBNull(dt.Rows[0]["Icon"]) ? null : (string)dt.Rows[0]["Icon"];
					retObj._color					 = Convert.IsDBNull(dt.Rows[0]["Color"]) ? null : (string)dt.Rows[0]["Color"];
					retObj._displayOrder					 = Convert.IsDBNull(dt.Rows[0]["DisplayOrder"]) ? (Int32?)null : (Int32?)dt.Rows[0]["DisplayOrder"];
					retObj._prefexClient					 = Convert.IsDBNull(dt.Rows[0]["PrefexClient"]) ? (Int32?)null : (Int32?)dt.Rows[0]["PrefexClient"];
					retObj._prefexItem					 = Convert.IsDBNull(dt.Rows[0]["PrefexItem"]) ? (Int32?)null : (Int32?)dt.Rows[0]["PrefexItem"];
					retObj._taxPromotion					 = Convert.IsDBNull(dt.Rows[0]["TaxPromotion"]) ? (bool?)null : (bool?)dt.Rows[0]["TaxPromotion"];
					retObj._cBy					 = Convert.IsDBNull(dt.Rows[0]["CBy"]) ? (Int32?)null : (Int32?)dt.Rows[0]["CBy"];
					retObj._cDate					 = Convert.IsDBNull(dt.Rows[0]["CDate"]) ? (DateTime?)null : (DateTime?)dt.Rows[0]["CDate"];
					retObj._eBy					 = Convert.IsDBNull(dt.Rows[0]["EBy"]) ? (Int32?)null : (Int32?)dt.Rows[0]["EBy"];
					retObj._eDate					 = Convert.IsDBNull(dt.Rows[0]["EDate"]) ? (DateTime?)null : (DateTime?)dt.Rows[0]["EDate"];
				}
				return retObj;
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
		///Delete one row by primary key(s)
		///this method allows the object to delete itself from the table Company based on its primary key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Delete()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprCompany_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@CompanyId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_companyId?? (object)DBNull.Value));

				command.ExecuteNonQuery();

			}
			catch
			{
				throw;
			}
			finally
			{
				command.Dispose();
			}
		}

		///<Summary>
		///Insert a new row
		///This method saves a new object to the table Company
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Insert()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprCompany_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@CompanyId", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _companyId));
				command.Parameters.Add(CtSqlParameter.Get("@CompanyCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_companyCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CompanyNameEn", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_companyNameEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CompanyNameAr", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_companyNameAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CompanyDesc", SqlDbType.NVarChar, -1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_companyDesc?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanEdit", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canEdit?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanDelete", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canDelete?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_icon?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Color", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_color?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DisplayOrder", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_displayOrder?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@PrefexClient", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_prefexClient?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@PrefexItem", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_prefexItem?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@TaxPromotion", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_taxPromotion?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_companyId					 = Convert.IsDBNull(command.Parameters["@CompanyId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@CompanyId"].Value;
				_companyCode					 = Convert.IsDBNull(command.Parameters["@CompanyCode"].Value) ? null : (string)command.Parameters["@CompanyCode"].Value;
				_companyNameEn					 = Convert.IsDBNull(command.Parameters["@CompanyNameEn"].Value) ? null : (string)command.Parameters["@CompanyNameEn"].Value;
				_companyNameAr					 = Convert.IsDBNull(command.Parameters["@CompanyNameAr"].Value) ? null : (string)command.Parameters["@CompanyNameAr"].Value;
				_companyDesc					 = Convert.IsDBNull(command.Parameters["@CompanyDesc"].Value) ? null : (string)command.Parameters["@CompanyDesc"].Value;
				_isActive					 = Convert.IsDBNull(command.Parameters["@IsActive"].Value) ? (bool?)null : (bool?)command.Parameters["@IsActive"].Value;
				_canEdit					 = Convert.IsDBNull(command.Parameters["@CanEdit"].Value) ? (bool?)null : (bool?)command.Parameters["@CanEdit"].Value;
				_canDelete					 = Convert.IsDBNull(command.Parameters["@CanDelete"].Value) ? (bool?)null : (bool?)command.Parameters["@CanDelete"].Value;
				_icon					 = Convert.IsDBNull(command.Parameters["@Icon"].Value) ? null : (string)command.Parameters["@Icon"].Value;
				_color					 = Convert.IsDBNull(command.Parameters["@Color"].Value) ? null : (string)command.Parameters["@Color"].Value;
				_displayOrder					 = Convert.IsDBNull(command.Parameters["@DisplayOrder"].Value) ? (Int32?)null : (Int32?)command.Parameters["@DisplayOrder"].Value;
				_prefexClient					 = Convert.IsDBNull(command.Parameters["@PrefexClient"].Value) ? (Int32?)null : (Int32?)command.Parameters["@PrefexClient"].Value;
				_prefexItem					 = Convert.IsDBNull(command.Parameters["@PrefexItem"].Value) ? (Int32?)null : (Int32?)command.Parameters["@PrefexItem"].Value;
				_taxPromotion					 = Convert.IsDBNull(command.Parameters["@TaxPromotion"].Value) ? (bool?)null : (bool?)command.Parameters["@TaxPromotion"].Value;
				_cBy					 = Convert.IsDBNull(command.Parameters["@CBy"].Value) ? (Int32?)null : (Int32?)command.Parameters["@CBy"].Value;
				_cDate					 = Convert.IsDBNull(command.Parameters["@CDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@CDate"].Value;
				_eBy					 = Convert.IsDBNull(command.Parameters["@EBy"].Value) ? (Int32?)null : (Int32?)command.Parameters["@EBy"].Value;
				_eDate					 = Convert.IsDBNull(command.Parameters["@EDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@EDate"].Value;

			}
			catch
			{
				throw;
			}
			finally
			{
				command.Dispose();
			}
		}

		///<Summary>
		///Select all rows
		///This method returns all data rows in the table Company
		///</Summary>
		///<returns>
		///IList-DAOCompany.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOCompany> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprCompany_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Company");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOCompany> objList = new List<DAOCompany>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOCompany retObj = new DAOCompany();
						retObj._companyId					 = Convert.IsDBNull(row["CompanyId"]) ? (Int32?)null : (Int32?)row["CompanyId"];
						retObj._companyCode					 = Convert.IsDBNull(row["CompanyCode"]) ? null : (string)row["CompanyCode"];
						retObj._companyNameEn					 = Convert.IsDBNull(row["CompanyNameEn"]) ? null : (string)row["CompanyNameEn"];
						retObj._companyNameAr					 = Convert.IsDBNull(row["CompanyNameAr"]) ? null : (string)row["CompanyNameAr"];
						retObj._companyDesc					 = Convert.IsDBNull(row["CompanyDesc"]) ? null : (string)row["CompanyDesc"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._canEdit					 = Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"];
						retObj._canDelete					 = Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
						retObj._displayOrder					 = Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"];
						retObj._prefexClient					 = Convert.IsDBNull(row["PrefexClient"]) ? (Int32?)null : (Int32?)row["PrefexClient"];
						retObj._prefexItem					 = Convert.IsDBNull(row["PrefexItem"]) ? (Int32?)null : (Int32?)row["PrefexItem"];
						retObj._taxPromotion					 = Convert.IsDBNull(row["TaxPromotion"]) ? (bool?)null : (bool?)row["TaxPromotion"];
						retObj._cBy					 = Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"];
						retObj._cDate					 = Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"];
						retObj._eBy					 = Convert.IsDBNull(row["EBy"]) ? (Int32?)null : (Int32?)row["EBy"];
						retObj._eDate					 = Convert.IsDBNull(row["EDate"]) ? (DateTime?)null : (DateTime?)row["EDate"];
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
			command.CommandText = InlineProcs.ctprCompany_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiCompany
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprCompany_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Company");
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
						if (string.Compare(projection.Member, "CompanyId", true) == 0) lst.Add(Convert.IsDBNull(row["CompanyId"]) ? (Int32?)null : (Int32?)row["CompanyId"]);
						if (string.Compare(projection.Member, "CompanyCode", true) == 0) lst.Add(Convert.IsDBNull(row["CompanyCode"]) ? null : (string)row["CompanyCode"]);
						if (string.Compare(projection.Member, "CompanyNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["CompanyNameEn"]) ? null : (string)row["CompanyNameEn"]);
						if (string.Compare(projection.Member, "CompanyNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["CompanyNameAr"]) ? null : (string)row["CompanyNameAr"]);
						if (string.Compare(projection.Member, "CompanyDesc", true) == 0) lst.Add(Convert.IsDBNull(row["CompanyDesc"]) ? null : (string)row["CompanyDesc"]);
						if (string.Compare(projection.Member, "IsActive", true) == 0) lst.Add(Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"]);
						if (string.Compare(projection.Member, "CanEdit", true) == 0) lst.Add(Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"]);
						if (string.Compare(projection.Member, "CanDelete", true) == 0) lst.Add(Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"]);
						if (string.Compare(projection.Member, "Icon", true) == 0) lst.Add(Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"]);
						if (string.Compare(projection.Member, "Color", true) == 0) lst.Add(Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"]);
						if (string.Compare(projection.Member, "DisplayOrder", true) == 0) lst.Add(Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"]);
						if (string.Compare(projection.Member, "PrefexClient", true) == 0) lst.Add(Convert.IsDBNull(row["PrefexClient"]) ? (Int32?)null : (Int32?)row["PrefexClient"]);
						if (string.Compare(projection.Member, "PrefexItem", true) == 0) lst.Add(Convert.IsDBNull(row["PrefexItem"]) ? (Int32?)null : (Int32?)row["PrefexItem"]);
						if (string.Compare(projection.Member, "TaxPromotion", true) == 0) lst.Add(Convert.IsDBNull(row["TaxPromotion"]) ? (bool?)null : (bool?)row["TaxPromotion"]);
						if (string.Compare(projection.Member, "CBy", true) == 0) lst.Add(Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"]);
						if (string.Compare(projection.Member, "CDate", true) == 0) lst.Add(Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"]);
						if (string.Compare(projection.Member, "EBy", true) == 0) lst.Add(Convert.IsDBNull(row["EBy"]) ? (Int32?)null : (Int32?)row["EBy"]);
						if (string.Compare(projection.Member, "EDate", true) == 0) lst.Add(Convert.IsDBNull(row["EDate"]) ? (DateTime?)null : (DateTime?)row["EDate"]);
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
		///This method returns all data rows in the table using criteriaquery api Company
		///</Summary>
		///<returns>
		///IList-DAOCompany.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOCompany> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprCompany_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Company");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOCompany> objList = new List<DAOCompany>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOCompany retObj = new DAOCompany();
						retObj._companyId					 = Convert.IsDBNull(row["CompanyId"]) ? (Int32?)null : (Int32?)row["CompanyId"];
						retObj._companyCode					 = Convert.IsDBNull(row["CompanyCode"]) ? null : (string)row["CompanyCode"];
						retObj._companyNameEn					 = Convert.IsDBNull(row["CompanyNameEn"]) ? null : (string)row["CompanyNameEn"];
						retObj._companyNameAr					 = Convert.IsDBNull(row["CompanyNameAr"]) ? null : (string)row["CompanyNameAr"];
						retObj._companyDesc					 = Convert.IsDBNull(row["CompanyDesc"]) ? null : (string)row["CompanyDesc"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._canEdit					 = Convert.IsDBNull(row["CanEdit"]) ? (bool?)null : (bool?)row["CanEdit"];
						retObj._canDelete					 = Convert.IsDBNull(row["CanDelete"]) ? (bool?)null : (bool?)row["CanDelete"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
						retObj._displayOrder					 = Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"];
						retObj._prefexClient					 = Convert.IsDBNull(row["PrefexClient"]) ? (Int32?)null : (Int32?)row["PrefexClient"];
						retObj._prefexItem					 = Convert.IsDBNull(row["PrefexItem"]) ? (Int32?)null : (Int32?)row["PrefexItem"];
						retObj._taxPromotion					 = Convert.IsDBNull(row["TaxPromotion"]) ? (bool?)null : (bool?)row["TaxPromotion"];
						retObj._cBy					 = Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"];
						retObj._cDate					 = Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"];
						retObj._eBy					 = Convert.IsDBNull(row["EBy"]) ? (Int32?)null : (Int32?)row["EBy"];
						retObj._eDate					 = Convert.IsDBNull(row["EDate"]) ? (DateTime?)null : (DateTime?)row["EDate"];
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
		///This method returns all data rows in the table using criteriaquery api Company
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprCompany_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///Update one row by primary key(s)
		///This method allows the object to update itself in the table Company based on its primary key(s)
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///
		///</parameters>
		public virtual void Update()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprCompany_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@CompanyId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_companyId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CompanyCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_companyCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CompanyNameEn", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_companyNameEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CompanyNameAr", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_companyNameAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CompanyDesc", SqlDbType.NVarChar, -1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_companyDesc?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanEdit", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canEdit?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CanDelete", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_canDelete?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_icon?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Color", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_color?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DisplayOrder", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_displayOrder?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@PrefexClient", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_prefexClient?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@PrefexItem", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_prefexItem?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@TaxPromotion", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_taxPromotion?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_companyId					 = Convert.IsDBNull(command.Parameters["@CompanyId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@CompanyId"].Value;
				_companyCode					 = Convert.IsDBNull(command.Parameters["@CompanyCode"].Value) ? null : (string)command.Parameters["@CompanyCode"].Value;
				_companyNameEn					 = Convert.IsDBNull(command.Parameters["@CompanyNameEn"].Value) ? null : (string)command.Parameters["@CompanyNameEn"].Value;
				_companyNameAr					 = Convert.IsDBNull(command.Parameters["@CompanyNameAr"].Value) ? null : (string)command.Parameters["@CompanyNameAr"].Value;
				_companyDesc					 = Convert.IsDBNull(command.Parameters["@CompanyDesc"].Value) ? null : (string)command.Parameters["@CompanyDesc"].Value;
				_isActive					 = Convert.IsDBNull(command.Parameters["@IsActive"].Value) ? (bool?)null : (bool?)command.Parameters["@IsActive"].Value;
				_canEdit					 = Convert.IsDBNull(command.Parameters["@CanEdit"].Value) ? (bool?)null : (bool?)command.Parameters["@CanEdit"].Value;
				_canDelete					 = Convert.IsDBNull(command.Parameters["@CanDelete"].Value) ? (bool?)null : (bool?)command.Parameters["@CanDelete"].Value;
				_icon					 = Convert.IsDBNull(command.Parameters["@Icon"].Value) ? null : (string)command.Parameters["@Icon"].Value;
				_color					 = Convert.IsDBNull(command.Parameters["@Color"].Value) ? null : (string)command.Parameters["@Color"].Value;
				_displayOrder					 = Convert.IsDBNull(command.Parameters["@DisplayOrder"].Value) ? (Int32?)null : (Int32?)command.Parameters["@DisplayOrder"].Value;
				_prefexClient					 = Convert.IsDBNull(command.Parameters["@PrefexClient"].Value) ? (Int32?)null : (Int32?)command.Parameters["@PrefexClient"].Value;
				_prefexItem					 = Convert.IsDBNull(command.Parameters["@PrefexItem"].Value) ? (Int32?)null : (Int32?)command.Parameters["@PrefexItem"].Value;
				_taxPromotion					 = Convert.IsDBNull(command.Parameters["@TaxPromotion"].Value) ? (bool?)null : (bool?)command.Parameters["@TaxPromotion"].Value;
				_cBy					 = Convert.IsDBNull(command.Parameters["@CBy"].Value) ? (Int32?)null : (Int32?)command.Parameters["@CBy"].Value;
				_cDate					 = Convert.IsDBNull(command.Parameters["@CDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@CDate"].Value;
				_eBy					 = Convert.IsDBNull(command.Parameters["@EBy"].Value) ? (Int32?)null : (Int32?)command.Parameters["@EBy"].Value;
				_eDate					 = Convert.IsDBNull(command.Parameters["@EDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@EDate"].Value;

			}
			catch
			{
				throw;
			}
			finally
			{
				command.Dispose();
			}
		}

		#endregion

		#region member properties

		public Int32? CompanyId
		{
			get
			{
				return _companyId;
			}
			set
			{
				_companyId = value;
			}
		}

		public string CompanyCode
		{
			get
			{
				return _companyCode;
			}
			set
			{
				_companyCode = value;
			}
		}

		public string CompanyNameEn
		{
			get
			{
				return _companyNameEn;
			}
			set
			{
				_companyNameEn = value;
			}
		}

		public string CompanyNameAr
		{
			get
			{
				return _companyNameAr;
			}
			set
			{
				_companyNameAr = value;
			}
		}

		public string CompanyDesc
		{
			get
			{
				return _companyDesc;
			}
			set
			{
				_companyDesc = value;
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

		public bool? CanEdit
		{
			get
			{
				return _canEdit;
			}
			set
			{
				_canEdit = value;
			}
		}

		public bool? CanDelete
		{
			get
			{
				return _canDelete;
			}
			set
			{
				_canDelete = value;
			}
		}

		public string Icon
		{
			get
			{
				return _icon;
			}
			set
			{
				_icon = value;
			}
		}

		public string Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
			}
		}

		public Int32? DisplayOrder
		{
			get
			{
				return _displayOrder;
			}
			set
			{
				_displayOrder = value;
			}
		}

		public Int32? PrefexClient
		{
			get
			{
				return _prefexClient;
			}
			set
			{
				_prefexClient = value;
			}
		}

		public Int32? PrefexItem
		{
			get
			{
				return _prefexItem;
			}
			set
			{
				_prefexItem = value;
			}
		}

		public bool? TaxPromotion
		{
			get
			{
				return _taxPromotion;
			}
			set
			{
				_taxPromotion = value;
			}
		}

		public Int32? CBy
		{
			get
			{
				return _cBy;
			}
			set
			{
				_cBy = value;
			}
		}

		public DateTime? CDate
		{
			get
			{
				return _cDate;
			}
			set
			{
				_cDate = value;
			}
		}

		public Int32? EBy
		{
			get
			{
				return _eBy;
			}
			set
			{
				_eBy = value;
			}
		}

		public DateTime? EDate
		{
			get
			{
				return _eDate;
			}
			set
			{
				_eDate = value;
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
		internal static string ctprCompany_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[CompanyId]
			,[CompanyCode]
			,[CompanyNameEn]
			,[CompanyNameAr]
			,[CompanyDesc]
			,[IsActive]
			,[CanEdit]
			,[CanDelete]
			,[Icon]
			,[Color]
			,[DisplayOrder]
			,[PrefexClient]
			,[PrefexItem]
			,[TaxPromotion]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Company]
			WHERE 
			[CompanyId] = @CompanyId
			";

		internal static string ctprCompany_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[Company]
			WHERE 
			[CompanyId] = @CompanyId
			";

		internal static string ctprCompany_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[Company]
			(
			[CompanyCode]
			,[CompanyNameEn]
			,[CompanyNameAr]
			,[CompanyDesc]
			,[IsActive]
			,[CanEdit]
			,[CanDelete]
			,[Icon]
			,[Color]
			,[DisplayOrder]
			,[PrefexClient]
			,[PrefexItem]
			,[TaxPromotion]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			)
			VALUES
			(
			@CompanyCode
			,@CompanyNameEn
			,@CompanyNameAr
			,@CompanyDesc
			,@IsActive
			,@CanEdit
			,@CanDelete
			,@Icon
			,@Color
			,@DisplayOrder
			,@PrefexClient
			,@PrefexItem
			,@TaxPromotion
			,@CBy
			,@CDate
			,@EBy
			,@EDate
			)
			SELECT 
			@CompanyId = [CompanyId]
			,@CompanyCode = [CompanyCode]
			,@CompanyNameEn = [CompanyNameEn]
			,@CompanyNameAr = [CompanyNameAr]
			,@CompanyDesc = [CompanyDesc]
			,@IsActive = [IsActive]
			,@CanEdit = [CanEdit]
			,@CanDelete = [CanDelete]
			,@Icon = [Icon]
			,@Color = [Color]
			,@DisplayOrder = [DisplayOrder]
			,@PrefexClient = [PrefexClient]
			,@PrefexItem = [PrefexItem]
			,@TaxPromotion = [TaxPromotion]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[Company]
			WHERE 
			[CompanyId] = SCOPE_IDENTITY()
			";

		internal static string ctprCompany_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[CompanyId]
			,[CompanyCode]
			,[CompanyNameEn]
			,[CompanyNameAr]
			,[CompanyDesc]
			,[IsActive]
			,[CanEdit]
			,[CanDelete]
			,[Icon]
			,[Color]
			,[DisplayOrder]
			,[PrefexClient]
			,[PrefexItem]
			,[TaxPromotion]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Company]
			";

		internal static string ctprCompany_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Company]
			";

		internal static string ctprCompany_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Company]
			##CRITERIA##
			";

		internal static string ctprCompany_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[CompanyId]
			,[CompanyCode]
			,[CompanyNameEn]
			,[CompanyNameAr]
			,[CompanyDesc]
			,[IsActive]
			,[CanEdit]
			,[CanDelete]
			,[Icon]
			,[Color]
			,[DisplayOrder]
			,[PrefexClient]
			,[PrefexItem]
			,[TaxPromotion]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Company]
			##CRITERIA##
			";

		internal static string ctprCompany_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Company]
			##CRITERIA##
			";

		internal static string ctprCompany_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[Company]
			SET
			[CompanyCode] = @CompanyCode
			,[CompanyNameEn] = @CompanyNameEn
			,[CompanyNameAr] = @CompanyNameAr
			,[CompanyDesc] = @CompanyDesc
			,[IsActive] = @IsActive
			,[CanEdit] = @CanEdit
			,[CanDelete] = @CanDelete
			,[Icon] = @Icon
			,[Color] = @Color
			,[DisplayOrder] = @DisplayOrder
			,[PrefexClient] = @PrefexClient
			,[PrefexItem] = @PrefexItem
			,[TaxPromotion] = @TaxPromotion
			,[CBy] = @CBy
			,[CDate] = @CDate
			,[EBy] = @EBy
			,[EDate] = @EDate
			WHERE 
			[CompanyId] = @CompanyId
			SELECT 
			@CompanyId = [CompanyId]
			,@CompanyCode = [CompanyCode]
			,@CompanyNameEn = [CompanyNameEn]
			,@CompanyNameAr = [CompanyNameAr]
			,@CompanyDesc = [CompanyDesc]
			,@IsActive = [IsActive]
			,@CanEdit = [CanEdit]
			,@CanDelete = [CanDelete]
			,@Icon = [Icon]
			,@Color = [Color]
			,@DisplayOrder = [DisplayOrder]
			,@PrefexClient = [PrefexClient]
			,@PrefexItem = [PrefexItem]
			,@TaxPromotion = [TaxPromotion]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[Company]
			WHERE 
			[CompanyId] = @CompanyId
			";

	}
}
#endregion