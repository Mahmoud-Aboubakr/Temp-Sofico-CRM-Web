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
	public partial class DAOUnit : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _unitId;
		protected string _unitCode;
		protected string _unitNameEn;
		protected string _unitNameAr;
		protected string _icon;
		protected string _color;
		protected Int32? _displayOrder;
		protected bool? _isActive;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		#endregion

		#region class methods
		public DAOUnit()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table Unit based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOUnit
		///</returns>
		///<parameters>
		///Int32? unitId
		///</parameters>
		public static DAOUnit SelectOne(Int32? unitId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprUnit_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Unit");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@UnitId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)unitId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOUnit retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOUnit();
					retObj._unitId					 = Convert.IsDBNull(dt.Rows[0]["UnitId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["UnitId"];
					retObj._unitCode					 = Convert.IsDBNull(dt.Rows[0]["UnitCode"]) ? null : (string)dt.Rows[0]["UnitCode"];
					retObj._unitNameEn					 = Convert.IsDBNull(dt.Rows[0]["UnitNameEn"]) ? null : (string)dt.Rows[0]["UnitNameEn"];
					retObj._unitNameAr					 = Convert.IsDBNull(dt.Rows[0]["UnitNameAr"]) ? null : (string)dt.Rows[0]["UnitNameAr"];
					retObj._icon					 = Convert.IsDBNull(dt.Rows[0]["Icon"]) ? null : (string)dt.Rows[0]["Icon"];
					retObj._color					 = Convert.IsDBNull(dt.Rows[0]["Color"]) ? null : (string)dt.Rows[0]["Color"];
					retObj._displayOrder					 = Convert.IsDBNull(dt.Rows[0]["DisplayOrder"]) ? (Int32?)null : (Int32?)dt.Rows[0]["DisplayOrder"];
					retObj._isActive					 = Convert.IsDBNull(dt.Rows[0]["IsActive"]) ? (bool?)null : (bool?)dt.Rows[0]["IsActive"];
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
		///this method allows the object to delete itself from the table Unit based on its primary key
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
			command.CommandText = InlineProcs.ctprUnit_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@UnitId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_unitId?? (object)DBNull.Value));

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
		///This method saves a new object to the table Unit
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
			command.CommandText = InlineProcs.ctprUnit_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@UnitId", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _unitId));
				command.Parameters.Add(CtSqlParameter.Get("@UnitCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_unitCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@UnitNameEn", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_unitNameEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@UnitNameAr", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_unitNameAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_icon?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Color", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_color?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DisplayOrder", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_displayOrder?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_unitId					 = Convert.IsDBNull(command.Parameters["@UnitId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@UnitId"].Value;
				_unitCode					 = Convert.IsDBNull(command.Parameters["@UnitCode"].Value) ? null : (string)command.Parameters["@UnitCode"].Value;
				_unitNameEn					 = Convert.IsDBNull(command.Parameters["@UnitNameEn"].Value) ? null : (string)command.Parameters["@UnitNameEn"].Value;
				_unitNameAr					 = Convert.IsDBNull(command.Parameters["@UnitNameAr"].Value) ? null : (string)command.Parameters["@UnitNameAr"].Value;
				_icon					 = Convert.IsDBNull(command.Parameters["@Icon"].Value) ? null : (string)command.Parameters["@Icon"].Value;
				_color					 = Convert.IsDBNull(command.Parameters["@Color"].Value) ? null : (string)command.Parameters["@Color"].Value;
				_displayOrder					 = Convert.IsDBNull(command.Parameters["@DisplayOrder"].Value) ? (Int32?)null : (Int32?)command.Parameters["@DisplayOrder"].Value;
				_isActive					 = Convert.IsDBNull(command.Parameters["@IsActive"].Value) ? (bool?)null : (bool?)command.Parameters["@IsActive"].Value;
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
		///This method returns all data rows in the table Unit
		///</Summary>
		///<returns>
		///IList-DAOUnit.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOUnit> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprUnit_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Unit");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOUnit> objList = new List<DAOUnit>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOUnit retObj = new DAOUnit();
						retObj._unitId					 = Convert.IsDBNull(row["UnitId"]) ? (Int32?)null : (Int32?)row["UnitId"];
						retObj._unitCode					 = Convert.IsDBNull(row["UnitCode"]) ? null : (string)row["UnitCode"];
						retObj._unitNameEn					 = Convert.IsDBNull(row["UnitNameEn"]) ? null : (string)row["UnitNameEn"];
						retObj._unitNameAr					 = Convert.IsDBNull(row["UnitNameAr"]) ? null : (string)row["UnitNameAr"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
						retObj._displayOrder					 = Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
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
			command.CommandText = InlineProcs.ctprUnit_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiUnit
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprUnit_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Unit");
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
						if (string.Compare(projection.Member, "UnitId", true) == 0) lst.Add(Convert.IsDBNull(row["UnitId"]) ? (Int32?)null : (Int32?)row["UnitId"]);
						if (string.Compare(projection.Member, "UnitCode", true) == 0) lst.Add(Convert.IsDBNull(row["UnitCode"]) ? null : (string)row["UnitCode"]);
						if (string.Compare(projection.Member, "UnitNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["UnitNameEn"]) ? null : (string)row["UnitNameEn"]);
						if (string.Compare(projection.Member, "UnitNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["UnitNameAr"]) ? null : (string)row["UnitNameAr"]);
						if (string.Compare(projection.Member, "Icon", true) == 0) lst.Add(Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"]);
						if (string.Compare(projection.Member, "Color", true) == 0) lst.Add(Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"]);
						if (string.Compare(projection.Member, "DisplayOrder", true) == 0) lst.Add(Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"]);
						if (string.Compare(projection.Member, "IsActive", true) == 0) lst.Add(Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"]);
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
		///This method returns all data rows in the table using criteriaquery api Unit
		///</Summary>
		///<returns>
		///IList-DAOUnit.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOUnit> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprUnit_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Unit");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOUnit> objList = new List<DAOUnit>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOUnit retObj = new DAOUnit();
						retObj._unitId					 = Convert.IsDBNull(row["UnitId"]) ? (Int32?)null : (Int32?)row["UnitId"];
						retObj._unitCode					 = Convert.IsDBNull(row["UnitCode"]) ? null : (string)row["UnitCode"];
						retObj._unitNameEn					 = Convert.IsDBNull(row["UnitNameEn"]) ? null : (string)row["UnitNameEn"];
						retObj._unitNameAr					 = Convert.IsDBNull(row["UnitNameAr"]) ? null : (string)row["UnitNameAr"];
						retObj._icon					 = Convert.IsDBNull(row["Icon"]) ? null : (string)row["Icon"];
						retObj._color					 = Convert.IsDBNull(row["Color"]) ? null : (string)row["Color"];
						retObj._displayOrder					 = Convert.IsDBNull(row["DisplayOrder"]) ? (Int32?)null : (Int32?)row["DisplayOrder"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
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
		///This method returns all data rows in the table using criteriaquery api Unit
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprUnit_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table Unit based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprUnit_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@UnitId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_unitId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@UnitCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_unitCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@UnitNameEn", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_unitNameEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@UnitNameAr", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_unitNameAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Icon", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_icon?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Color", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_color?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DisplayOrder", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_displayOrder?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_unitId					 = Convert.IsDBNull(command.Parameters["@UnitId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@UnitId"].Value;
				_unitCode					 = Convert.IsDBNull(command.Parameters["@UnitCode"].Value) ? null : (string)command.Parameters["@UnitCode"].Value;
				_unitNameEn					 = Convert.IsDBNull(command.Parameters["@UnitNameEn"].Value) ? null : (string)command.Parameters["@UnitNameEn"].Value;
				_unitNameAr					 = Convert.IsDBNull(command.Parameters["@UnitNameAr"].Value) ? null : (string)command.Parameters["@UnitNameAr"].Value;
				_icon					 = Convert.IsDBNull(command.Parameters["@Icon"].Value) ? null : (string)command.Parameters["@Icon"].Value;
				_color					 = Convert.IsDBNull(command.Parameters["@Color"].Value) ? null : (string)command.Parameters["@Color"].Value;
				_displayOrder					 = Convert.IsDBNull(command.Parameters["@DisplayOrder"].Value) ? (Int32?)null : (Int32?)command.Parameters["@DisplayOrder"].Value;
				_isActive					 = Convert.IsDBNull(command.Parameters["@IsActive"].Value) ? (bool?)null : (bool?)command.Parameters["@IsActive"].Value;
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

		public string UnitCode
		{
			get
			{
				return _unitCode;
			}
			set
			{
				_unitCode = value;
			}
		}

		public string UnitNameEn
		{
			get
			{
				return _unitNameEn;
			}
			set
			{
				_unitNameEn = value;
			}
		}

		public string UnitNameAr
		{
			get
			{
				return _unitNameAr;
			}
			set
			{
				_unitNameAr = value;
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
		internal static string ctprUnit_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[UnitId]
			,[UnitCode]
			,[UnitNameEn]
			,[UnitNameAr]
			,[Icon]
			,[Color]
			,[DisplayOrder]
			,[IsActive]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Unit]
			WHERE 
			[UnitId] = @UnitId
			";

		internal static string ctprUnit_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[Unit]
			WHERE 
			[UnitId] = @UnitId
			";

		internal static string ctprUnit_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[Unit]
			(
			[UnitCode]
			,[UnitNameEn]
			,[UnitNameAr]
			,[Icon]
			,[Color]
			,[DisplayOrder]
			,[IsActive]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			)
			VALUES
			(
			@UnitCode
			,@UnitNameEn
			,@UnitNameAr
			,@Icon
			,@Color
			,@DisplayOrder
			,@IsActive
			,@CBy
			,@CDate
			,@EBy
			,@EDate
			)
			SELECT 
			@UnitId = [UnitId]
			,@UnitCode = [UnitCode]
			,@UnitNameEn = [UnitNameEn]
			,@UnitNameAr = [UnitNameAr]
			,@Icon = [Icon]
			,@Color = [Color]
			,@DisplayOrder = [DisplayOrder]
			,@IsActive = [IsActive]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[Unit]
			WHERE 
			[UnitId] = SCOPE_IDENTITY()
			";

		internal static string ctprUnit_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[UnitId]
			,[UnitCode]
			,[UnitNameEn]
			,[UnitNameAr]
			,[Icon]
			,[Color]
			,[DisplayOrder]
			,[IsActive]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Unit]
			";

		internal static string ctprUnit_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Unit]
			";

		internal static string ctprUnit_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Unit]
			##CRITERIA##
			";

		internal static string ctprUnit_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[UnitId]
			,[UnitCode]
			,[UnitNameEn]
			,[UnitNameAr]
			,[Icon]
			,[Color]
			,[DisplayOrder]
			,[IsActive]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Unit]
			##CRITERIA##
			";

		internal static string ctprUnit_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Unit]
			##CRITERIA##
			";

		internal static string ctprUnit_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[Unit]
			SET
			[UnitCode] = @UnitCode
			,[UnitNameEn] = @UnitNameEn
			,[UnitNameAr] = @UnitNameAr
			,[Icon] = @Icon
			,[Color] = @Color
			,[DisplayOrder] = @DisplayOrder
			,[IsActive] = @IsActive
			,[CBy] = @CBy
			,[CDate] = @CDate
			,[EBy] = @EBy
			,[EDate] = @EDate
			WHERE 
			[UnitId] = @UnitId
			SELECT 
			@UnitId = [UnitId]
			,@UnitCode = [UnitCode]
			,@UnitNameEn = [UnitNameEn]
			,@UnitNameAr = [UnitNameAr]
			,@Icon = [Icon]
			,@Color = [Color]
			,@DisplayOrder = [DisplayOrder]
			,@IsActive = [IsActive]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[Unit]
			WHERE 
			[UnitId] = @UnitId
			";

	}
}
#endregion
