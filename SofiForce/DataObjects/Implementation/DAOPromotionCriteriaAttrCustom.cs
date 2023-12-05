/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 3/23/2023 3:30:38 PM
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SofiForce.DataObjects.Interfaces;

namespace SofiForce.DataObjects
{
	public partial class DAOPromotionCriteriaAttrCustom : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _customId;
		protected Int32? _attributeId;
		protected string _valueFrom;
		protected bool? _isActive;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		#endregion

		#region class methods
		public DAOPromotionCriteriaAttrCustom()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table PromotionCriteriaAttrCustom based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOPromotionCriteriaAttrCustom
		///</returns>
		///<parameters>
		///Int32? customId
		///</parameters>
		public static DAOPromotionCriteriaAttrCustom SelectOne(Int32? customId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprPromotionCriteriaAttrCustom_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromotionCriteriaAttrCustom");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@CustomId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)customId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOPromotionCriteriaAttrCustom retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOPromotionCriteriaAttrCustom();
					retObj._customId					 = Convert.IsDBNull(dt.Rows[0]["CustomId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["CustomId"];
					retObj._attributeId					 = Convert.IsDBNull(dt.Rows[0]["AttributeId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["AttributeId"];
					retObj._valueFrom					 = Convert.IsDBNull(dt.Rows[0]["ValueFrom"]) ? null : (string)dt.Rows[0]["ValueFrom"];
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
		///this method allows the object to delete itself from the table PromotionCriteriaAttrCustom based on its primary key
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
			command.CommandText = InlineProcs.ctprPromotionCriteriaAttrCustom_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@CustomId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_customId?? (object)DBNull.Value));

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
		///Select one row by unique constraint
		///This method returns one row from the table PromotionCriteriaAttrCustom based on a unique constraint
		///</Summary>
		///<returns>
		///DAOPromotionCriteriaAttrCustom
		///</returns>
		///<parameters>
		///Int32? attributeId, string valueFrom
		///</parameters>
		public static DAOPromotionCriteriaAttrCustom SelectOneByUniqueFields(Int32? attributeId, string valueFrom)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprPromotionCriteriaAttrCustom_SelectOneByUniqueFields;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromotionCriteriaAttrCustom");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@AttributeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)attributeId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ValueFrom", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)valueFrom?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOPromotionCriteriaAttrCustom retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOPromotionCriteriaAttrCustom();
					retObj._customId					 = Convert.IsDBNull(dt.Rows[0]["CustomId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["CustomId"];
					retObj._attributeId					 = Convert.IsDBNull(dt.Rows[0]["AttributeId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["AttributeId"];
					retObj._valueFrom					 = Convert.IsDBNull(dt.Rows[0]["ValueFrom"]) ? null : (string)dt.Rows[0]["ValueFrom"];
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
		///Delete one row by unique constraint
		///This method deletes one row from the table PromotionCriteriaAttrCustom based on a unique constraint
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///Int32? attributeId, string valueFrom
		///</parameters>
		public virtual void DeleteOneByUniqueFields(Int32? attributeId, string valueFrom)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprPromotionCriteriaAttrCustom_DeleteOneByUniqueFields;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@AttributeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)_attributeId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ValueFrom", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, (object)_valueFrom?? (object)DBNull.Value));

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
		///This method saves a new object to the table PromotionCriteriaAttrCustom
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
			command.CommandText = InlineProcs.ctprPromotionCriteriaAttrCustom_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@CustomId", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _customId));
				command.Parameters.Add(CtSqlParameter.Get("@AttributeId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_attributeId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ValueFrom", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_valueFrom?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_customId					 = Convert.IsDBNull(command.Parameters["@CustomId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@CustomId"].Value;
				_attributeId					 = Convert.IsDBNull(command.Parameters["@AttributeId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@AttributeId"].Value;
				_valueFrom					 = Convert.IsDBNull(command.Parameters["@ValueFrom"].Value) ? null : (string)command.Parameters["@ValueFrom"].Value;
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
		///This method returns all data rows in the table PromotionCriteriaAttrCustom
		///</Summary>
		///<returns>
		///IList-DAOPromotionCriteriaAttrCustom.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOPromotionCriteriaAttrCustom> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprPromotionCriteriaAttrCustom_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromotionCriteriaAttrCustom");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOPromotionCriteriaAttrCustom> objList = new List<DAOPromotionCriteriaAttrCustom>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOPromotionCriteriaAttrCustom retObj = new DAOPromotionCriteriaAttrCustom();
						retObj._customId					 = Convert.IsDBNull(row["CustomId"]) ? (Int32?)null : (Int32?)row["CustomId"];
						retObj._attributeId					 = Convert.IsDBNull(row["AttributeId"]) ? (Int32?)null : (Int32?)row["AttributeId"];
						retObj._valueFrom					 = Convert.IsDBNull(row["ValueFrom"]) ? null : (string)row["ValueFrom"];
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
			command.CommandText = InlineProcs.ctprPromotionCriteriaAttrCustom_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiPromotionCriteriaAttrCustom
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromotionCriteriaAttrCustom_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromotionCriteriaAttrCustom");
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
						if (string.Compare(projection.Member, "CustomId", true) == 0) lst.Add(Convert.IsDBNull(row["CustomId"]) ? (Int32?)null : (Int32?)row["CustomId"]);
						if (string.Compare(projection.Member, "AttributeId", true) == 0) lst.Add(Convert.IsDBNull(row["AttributeId"]) ? (Int32?)null : (Int32?)row["AttributeId"]);
						if (string.Compare(projection.Member, "ValueFrom", true) == 0) lst.Add(Convert.IsDBNull(row["ValueFrom"]) ? null : (string)row["ValueFrom"]);
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
		///This method returns all data rows in the table using criteriaquery api PromotionCriteriaAttrCustom
		///</Summary>
		///<returns>
		///IList-DAOPromotionCriteriaAttrCustom.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOPromotionCriteriaAttrCustom> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromotionCriteriaAttrCustom_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("PromotionCriteriaAttrCustom");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOPromotionCriteriaAttrCustom> objList = new List<DAOPromotionCriteriaAttrCustom>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOPromotionCriteriaAttrCustom retObj = new DAOPromotionCriteriaAttrCustom();
						retObj._customId					 = Convert.IsDBNull(row["CustomId"]) ? (Int32?)null : (Int32?)row["CustomId"];
						retObj._attributeId					 = Convert.IsDBNull(row["AttributeId"]) ? (Int32?)null : (Int32?)row["AttributeId"];
						retObj._valueFrom					 = Convert.IsDBNull(row["ValueFrom"]) ? null : (string)row["ValueFrom"];
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
		///This method returns all data rows in the table using criteriaquery api PromotionCriteriaAttrCustom
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprPromotionCriteriaAttrCustom_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table PromotionCriteriaAttrCustom based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprPromotionCriteriaAttrCustom_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@CustomId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_customId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@AttributeId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_attributeId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ValueFrom", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_valueFrom?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_customId					 = Convert.IsDBNull(command.Parameters["@CustomId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@CustomId"].Value;
				_attributeId					 = Convert.IsDBNull(command.Parameters["@AttributeId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@AttributeId"].Value;
				_valueFrom					 = Convert.IsDBNull(command.Parameters["@ValueFrom"].Value) ? null : (string)command.Parameters["@ValueFrom"].Value;
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

		public Int32? CustomId
		{
			get
			{
				return _customId;
			}
			set
			{
				_customId = value;
			}
		}

		public Int32? AttributeId
		{
			get
			{
				return _attributeId;
			}
			set
			{
				_attributeId = value;
			}
		}

		public string ValueFrom
		{
			get
			{
				return _valueFrom;
			}
			set
			{
				_valueFrom = value;
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
		internal static string ctprPromotionCriteriaAttrCustom_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[CustomId]
			,[AttributeId]
			,[ValueFrom]
			,[IsActive]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[PromotionCriteriaAttrCustom]
			WHERE 
			[CustomId] = @CustomId
			";

		internal static string ctprPromotionCriteriaAttrCustom_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[PromotionCriteriaAttrCustom]
			WHERE 
			[CustomId] = @CustomId
			";

		internal static string ctprPromotionCriteriaAttrCustom_SelectOneByUniqueFields = @"
			-- Select one row by a unique constraint
			-- selects all rows from the table
			SELECT 
			[CustomId]
			,[AttributeId]
			,[ValueFrom]
			,[IsActive]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[PromotionCriteriaAttrCustom]
			WHERE 
			[AttributeId] = @AttributeId
			AND [ValueFrom] = @ValueFrom
			";

		internal static string ctprPromotionCriteriaAttrCustom_DeleteOneByUniqueFields = @"
			
			-- delete all matching from the table
			DELETE [dbo].[PromotionCriteriaAttrCustom]
			WHERE 
			[AttributeId] = @AttributeId
			AND [ValueFrom] = @ValueFrom
			";

		internal static string ctprPromotionCriteriaAttrCustom_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[PromotionCriteriaAttrCustom]
			(
			[AttributeId]
			,[ValueFrom]
			,[IsActive]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			)
			VALUES
			(
			@AttributeId
			,@ValueFrom
			,@IsActive
			,@CBy
			,@CDate
			,@EBy
			,@EDate
			)
			SELECT 
			@CustomId = [CustomId]
			,@AttributeId = [AttributeId]
			,@ValueFrom = [ValueFrom]
			,@IsActive = [IsActive]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[PromotionCriteriaAttrCustom]
			WHERE 
			[CustomId] = SCOPE_IDENTITY()
			";

		internal static string ctprPromotionCriteriaAttrCustom_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[CustomId]
			,[AttributeId]
			,[ValueFrom]
			,[IsActive]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[PromotionCriteriaAttrCustom]
			";

		internal static string ctprPromotionCriteriaAttrCustom_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[PromotionCriteriaAttrCustom]
			";

		internal static string ctprPromotionCriteriaAttrCustom_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[PromotionCriteriaAttrCustom]
			##CRITERIA##
			";

		internal static string ctprPromotionCriteriaAttrCustom_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[CustomId]
			,[AttributeId]
			,[ValueFrom]
			,[IsActive]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[PromotionCriteriaAttrCustom]
			##CRITERIA##
			";

		internal static string ctprPromotionCriteriaAttrCustom_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[PromotionCriteriaAttrCustom]
			##CRITERIA##
			";

		internal static string ctprPromotionCriteriaAttrCustom_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[PromotionCriteriaAttrCustom]
			SET
			[AttributeId] = @AttributeId
			,[ValueFrom] = @ValueFrom
			,[IsActive] = @IsActive
			,[CBy] = @CBy
			,[CDate] = @CDate
			,[EBy] = @EBy
			,[EDate] = @EDate
			WHERE 
			[CustomId] = @CustomId
			SELECT 
			@CustomId = [CustomId]
			,@AttributeId = [AttributeId]
			,@ValueFrom = [ValueFrom]
			,@IsActive = [IsActive]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[PromotionCriteriaAttrCustom]
			WHERE 
			[CustomId] = @CustomId
			";

	}
}
#endregion
