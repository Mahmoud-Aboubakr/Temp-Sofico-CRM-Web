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
	public partial class DAOVacation : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _vacationId;
		protected Int32? _vacationTypeId;
		protected DateTime? _vacationDate;
		protected string _notes;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eby;
		protected DateTime? _eDate;
		#endregion

		#region class methods
		public DAOVacation()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table Vacation based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOVacation
		///</returns>
		///<parameters>
		///Int32? vacationId
		///</parameters>
		public static DAOVacation SelectOne(Int32? vacationId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprVacation_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Vacation");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@VacationId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)vacationId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOVacation retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOVacation();
					retObj._vacationId					 = Convert.IsDBNull(dt.Rows[0]["VacationId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["VacationId"];
					retObj._vacationTypeId					 = Convert.IsDBNull(dt.Rows[0]["VacationTypeId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["VacationTypeId"];
					retObj._vacationDate					 = Convert.IsDBNull(dt.Rows[0]["VacationDate"]) ? (DateTime?)null : (DateTime?)dt.Rows[0]["VacationDate"];
					retObj._notes					 = Convert.IsDBNull(dt.Rows[0]["Notes"]) ? null : (string)dt.Rows[0]["Notes"];
					retObj._cBy					 = Convert.IsDBNull(dt.Rows[0]["CBy"]) ? (Int32?)null : (Int32?)dt.Rows[0]["CBy"];
					retObj._cDate					 = Convert.IsDBNull(dt.Rows[0]["CDate"]) ? (DateTime?)null : (DateTime?)dt.Rows[0]["CDate"];
					retObj._eby					 = Convert.IsDBNull(dt.Rows[0]["Eby"]) ? (Int32?)null : (Int32?)dt.Rows[0]["Eby"];
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
		///this method allows the object to delete itself from the table Vacation based on its primary key
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
			command.CommandText = InlineProcs.ctprVacation_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@VacationId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_vacationId?? (object)DBNull.Value));

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
		///Select all rows by foreign key
		///This method returns all data rows in the table Vacation based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOVacation.
		///</returns>
		///<parameters>
		///Int32? vacationTypeId
		///</parameters>
		public static IList<DAOVacation> SelectAllByVacationTypeId(Int32? vacationTypeId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprVacation_SelectAllByVacationTypeId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Vacation");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@VacationTypeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)vacationTypeId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOVacation> objList = new List<DAOVacation>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOVacation retObj = new DAOVacation();
						retObj._vacationId					 = Convert.IsDBNull(row["VacationId"]) ? (Int32?)null : (Int32?)row["VacationId"];
						retObj._vacationTypeId					 = Convert.IsDBNull(row["VacationTypeId"]) ? (Int32?)null : (Int32?)row["VacationTypeId"];
						retObj._vacationDate					 = Convert.IsDBNull(row["VacationDate"]) ? (DateTime?)null : (DateTime?)row["VacationDate"];
						retObj._notes					 = Convert.IsDBNull(row["Notes"]) ? null : (string)row["Notes"];
						retObj._cBy					 = Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"];
						retObj._cDate					 = Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"];
						retObj._eby					 = Convert.IsDBNull(row["Eby"]) ? (Int32?)null : (Int32?)row["Eby"];
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
		///Int32? vacationTypeId
		///</parameters>
		public static Int32 SelectAllByVacationTypeIdCount(Int32? vacationTypeId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprVacation_SelectAllByVacationTypeIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@VacationTypeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)vacationTypeId?? (object)DBNull.Value));

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
		///Delete all by foreign key
		///This method deletes all rows in the table Vacation with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? vacationTypeId
		///</parameters>
		public static void DeleteAllByVacationTypeId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? vacationTypeId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprVacation_DeleteAllByVacationTypeId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@VacationTypeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)vacationTypeId?? (object)DBNull.Value));

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
		///This method saves a new object to the table Vacation
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
			command.CommandText = InlineProcs.ctprVacation_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@VacationId", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _vacationId));
				command.Parameters.Add(CtSqlParameter.Get("@VacationTypeId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_vacationTypeId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@VacationDate", SqlDbType.Date, 3, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_vacationDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Notes", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_notes?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Eby", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eby?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_vacationId					 = Convert.IsDBNull(command.Parameters["@VacationId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@VacationId"].Value;
				_vacationTypeId					 = Convert.IsDBNull(command.Parameters["@VacationTypeId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@VacationTypeId"].Value;
				_vacationDate					 = Convert.IsDBNull(command.Parameters["@VacationDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@VacationDate"].Value;
				_notes					 = Convert.IsDBNull(command.Parameters["@Notes"].Value) ? null : (string)command.Parameters["@Notes"].Value;
				_cBy					 = Convert.IsDBNull(command.Parameters["@CBy"].Value) ? (Int32?)null : (Int32?)command.Parameters["@CBy"].Value;
				_cDate					 = Convert.IsDBNull(command.Parameters["@CDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@CDate"].Value;
				_eby					 = Convert.IsDBNull(command.Parameters["@Eby"].Value) ? (Int32?)null : (Int32?)command.Parameters["@Eby"].Value;
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
		///This method returns all data rows in the table Vacation
		///</Summary>
		///<returns>
		///IList-DAOVacation.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOVacation> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprVacation_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Vacation");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOVacation> objList = new List<DAOVacation>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOVacation retObj = new DAOVacation();
						retObj._vacationId					 = Convert.IsDBNull(row["VacationId"]) ? (Int32?)null : (Int32?)row["VacationId"];
						retObj._vacationTypeId					 = Convert.IsDBNull(row["VacationTypeId"]) ? (Int32?)null : (Int32?)row["VacationTypeId"];
						retObj._vacationDate					 = Convert.IsDBNull(row["VacationDate"]) ? (DateTime?)null : (DateTime?)row["VacationDate"];
						retObj._notes					 = Convert.IsDBNull(row["Notes"]) ? null : (string)row["Notes"];
						retObj._cBy					 = Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"];
						retObj._cDate					 = Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"];
						retObj._eby					 = Convert.IsDBNull(row["Eby"]) ? (Int32?)null : (Int32?)row["Eby"];
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
			command.CommandText = InlineProcs.ctprVacation_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiVacation
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprVacation_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Vacation");
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
						if (string.Compare(projection.Member, "VacationId", true) == 0) lst.Add(Convert.IsDBNull(row["VacationId"]) ? (Int32?)null : (Int32?)row["VacationId"]);
						if (string.Compare(projection.Member, "VacationTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["VacationTypeId"]) ? (Int32?)null : (Int32?)row["VacationTypeId"]);
						if (string.Compare(projection.Member, "VacationDate", true) == 0) lst.Add(Convert.IsDBNull(row["VacationDate"]) ? (DateTime?)null : (DateTime?)row["VacationDate"]);
						if (string.Compare(projection.Member, "Notes", true) == 0) lst.Add(Convert.IsDBNull(row["Notes"]) ? null : (string)row["Notes"]);
						if (string.Compare(projection.Member, "CBy", true) == 0) lst.Add(Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"]);
						if (string.Compare(projection.Member, "CDate", true) == 0) lst.Add(Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"]);
						if (string.Compare(projection.Member, "Eby", true) == 0) lst.Add(Convert.IsDBNull(row["Eby"]) ? (Int32?)null : (Int32?)row["Eby"]);
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
		///This method returns all data rows in the table using criteriaquery api Vacation
		///</Summary>
		///<returns>
		///IList-DAOVacation.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOVacation> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprVacation_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Vacation");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOVacation> objList = new List<DAOVacation>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOVacation retObj = new DAOVacation();
						retObj._vacationId					 = Convert.IsDBNull(row["VacationId"]) ? (Int32?)null : (Int32?)row["VacationId"];
						retObj._vacationTypeId					 = Convert.IsDBNull(row["VacationTypeId"]) ? (Int32?)null : (Int32?)row["VacationTypeId"];
						retObj._vacationDate					 = Convert.IsDBNull(row["VacationDate"]) ? (DateTime?)null : (DateTime?)row["VacationDate"];
						retObj._notes					 = Convert.IsDBNull(row["Notes"]) ? null : (string)row["Notes"];
						retObj._cBy					 = Convert.IsDBNull(row["CBy"]) ? (Int32?)null : (Int32?)row["CBy"];
						retObj._cDate					 = Convert.IsDBNull(row["CDate"]) ? (DateTime?)null : (DateTime?)row["CDate"];
						retObj._eby					 = Convert.IsDBNull(row["Eby"]) ? (Int32?)null : (Int32?)row["Eby"];
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
		///This method returns all data rows in the table using criteriaquery api Vacation
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprVacation_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table Vacation based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprVacation_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@VacationId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_vacationId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@VacationTypeId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_vacationTypeId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@VacationDate", SqlDbType.Date, 3, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_vacationDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Notes", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_notes?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Eby", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eby?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_vacationId					 = Convert.IsDBNull(command.Parameters["@VacationId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@VacationId"].Value;
				_vacationTypeId					 = Convert.IsDBNull(command.Parameters["@VacationTypeId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@VacationTypeId"].Value;
				_vacationDate					 = Convert.IsDBNull(command.Parameters["@VacationDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@VacationDate"].Value;
				_notes					 = Convert.IsDBNull(command.Parameters["@Notes"].Value) ? null : (string)command.Parameters["@Notes"].Value;
				_cBy					 = Convert.IsDBNull(command.Parameters["@CBy"].Value) ? (Int32?)null : (Int32?)command.Parameters["@CBy"].Value;
				_cDate					 = Convert.IsDBNull(command.Parameters["@CDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@CDate"].Value;
				_eby					 = Convert.IsDBNull(command.Parameters["@Eby"].Value) ? (Int32?)null : (Int32?)command.Parameters["@Eby"].Value;
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

		public Int32? VacationId
		{
			get
			{
				return _vacationId;
			}
			set
			{
				_vacationId = value;
			}
		}

		public Int32? VacationTypeId
		{
			get
			{
				return _vacationTypeId;
			}
			set
			{
				_vacationTypeId = value;
			}
		}

		public DateTime? VacationDate
		{
			get
			{
				return _vacationDate;
			}
			set
			{
				_vacationDate = value;
			}
		}

		public string Notes
		{
			get
			{
				return _notes;
			}
			set
			{
				_notes = value;
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

		public Int32? Eby
		{
			get
			{
				return _eby;
			}
			set
			{
				_eby = value;
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
		internal static string ctprVacation_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[VacationId]
			,[VacationTypeId]
			,[VacationDate]
			,[Notes]
			,[CBy]
			,[CDate]
			,[Eby]
			,[EDate]
			FROM [dbo].[Vacation]
			WHERE 
			[VacationId] = @VacationId
			";

		internal static string ctprVacation_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[Vacation]
			WHERE 
			[VacationId] = @VacationId
			";

		internal static string ctprVacation_SelectAllByVacationTypeId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[VacationId]
			,[VacationTypeId]
			,[VacationDate]
			,[Notes]
			,[CBy]
			,[CDate]
			,[Eby]
			,[EDate]
			FROM [dbo].[Vacation]
			WHERE 
			[VacationTypeId] = @VacationTypeId OR ([VacationTypeId] IS NULL AND @VacationTypeId IS NULL)
			";

		internal static string ctprVacation_SelectAllByVacationTypeIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Vacation]
			WHERE 
			[VacationTypeId] = @VacationTypeId OR ([VacationTypeId] IS NULL AND @VacationTypeId IS NULL)
			";

		internal static string ctprVacation_DeleteAllByVacationTypeId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[Vacation]
			WHERE 
			[VacationTypeId] = @VacationTypeId OR ([VacationTypeId] IS NULL AND @VacationTypeId IS NULL)
			";

		internal static string ctprVacation_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[Vacation]
			(
			[VacationTypeId]
			,[VacationDate]
			,[Notes]
			,[CBy]
			,[CDate]
			,[Eby]
			,[EDate]
			)
			VALUES
			(
			@VacationTypeId
			,@VacationDate
			,@Notes
			,@CBy
			,@CDate
			,@Eby
			,@EDate
			)
			SELECT 
			@VacationId = [VacationId]
			,@VacationTypeId = [VacationTypeId]
			,@VacationDate = [VacationDate]
			,@Notes = [Notes]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@Eby = [Eby]
			,@EDate = [EDate]
			FROM [dbo].[Vacation]
			WHERE 
			[VacationId] = SCOPE_IDENTITY()
			";

		internal static string ctprVacation_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[VacationId]
			,[VacationTypeId]
			,[VacationDate]
			,[Notes]
			,[CBy]
			,[CDate]
			,[Eby]
			,[EDate]
			FROM [dbo].[Vacation]
			";

		internal static string ctprVacation_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Vacation]
			";

		internal static string ctprVacation_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Vacation]
			##CRITERIA##
			";

		internal static string ctprVacation_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[VacationId]
			,[VacationTypeId]
			,[VacationDate]
			,[Notes]
			,[CBy]
			,[CDate]
			,[Eby]
			,[EDate]
			FROM [dbo].[Vacation]
			##CRITERIA##
			";

		internal static string ctprVacation_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Vacation]
			##CRITERIA##
			";

		internal static string ctprVacation_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[Vacation]
			SET
			[VacationTypeId] = @VacationTypeId
			,[VacationDate] = @VacationDate
			,[Notes] = @Notes
			,[CBy] = @CBy
			,[CDate] = @CDate
			,[Eby] = @Eby
			,[EDate] = @EDate
			WHERE 
			[VacationId] = @VacationId
			SELECT 
			@VacationId = [VacationId]
			,@VacationTypeId = [VacationTypeId]
			,@VacationDate = [VacationDate]
			,@Notes = [Notes]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@Eby = [Eby]
			,@EDate = [EDate]
			FROM [dbo].[Vacation]
			WHERE 
			[VacationId] = @VacationId
			";

	}
}
#endregion
