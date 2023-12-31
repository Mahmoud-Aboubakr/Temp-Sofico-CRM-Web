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
	public partial class DAOSurveyDetail : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _surveyDetailId;
		protected Int32? _surveyId;
		protected string _surveyQuestionEn;
		protected string _surveyQuestionAr;
		protected bool? _isMuliSelect;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		#endregion

		#region class methods
		public DAOSurveyDetail()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table Survey_Detail based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOSurveyDetail
		///</returns>
		///<parameters>
		///Int32? surveyDetailId
		///</parameters>
		public static DAOSurveyDetail SelectOne(Int32? surveyDetailId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSurvey_Detail_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Survey_Detail");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SurveyDetailId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)surveyDetailId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOSurveyDetail retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOSurveyDetail();
					retObj._surveyDetailId					 = Convert.IsDBNull(dt.Rows[0]["SurveyDetailId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["SurveyDetailId"];
					retObj._surveyId					 = Convert.IsDBNull(dt.Rows[0]["SurveyId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["SurveyId"];
					retObj._surveyQuestionEn					 = Convert.IsDBNull(dt.Rows[0]["SurveyQuestionEn"]) ? null : (string)dt.Rows[0]["SurveyQuestionEn"];
					retObj._surveyQuestionAr					 = Convert.IsDBNull(dt.Rows[0]["SurveyQuestionAr"]) ? null : (string)dt.Rows[0]["SurveyQuestionAr"];
					retObj._isMuliSelect					 = Convert.IsDBNull(dt.Rows[0]["IsMuliSelect"]) ? (bool?)null : (bool?)dt.Rows[0]["IsMuliSelect"];
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
		///this method allows the object to delete itself from the table Survey_Detail based on its primary key
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
			command.CommandText = InlineProcs.ctprSurvey_Detail_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SurveyDetailId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_surveyDetailId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table Survey_Detail based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOSurveyDetail.
		///</returns>
		///<parameters>
		///Int32? surveyId
		///</parameters>
		public static IList<DAOSurveyDetail> SelectAllBySurveyId(Int32? surveyId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSurvey_Detail_SelectAllBySurveyId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Survey_Detail");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SurveyId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)surveyId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSurveyDetail> objList = new List<DAOSurveyDetail>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSurveyDetail retObj = new DAOSurveyDetail();
						retObj._surveyDetailId					 = Convert.IsDBNull(row["SurveyDetailId"]) ? (Int32?)null : (Int32?)row["SurveyDetailId"];
						retObj._surveyId					 = Convert.IsDBNull(row["SurveyId"]) ? (Int32?)null : (Int32?)row["SurveyId"];
						retObj._surveyQuestionEn					 = Convert.IsDBNull(row["SurveyQuestionEn"]) ? null : (string)row["SurveyQuestionEn"];
						retObj._surveyQuestionAr					 = Convert.IsDBNull(row["SurveyQuestionAr"]) ? null : (string)row["SurveyQuestionAr"];
						retObj._isMuliSelect					 = Convert.IsDBNull(row["IsMuliSelect"]) ? (bool?)null : (bool?)row["IsMuliSelect"];
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
		///Int32? surveyId
		///</parameters>
		public static Int32 SelectAllBySurveyIdCount(Int32? surveyId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSurvey_Detail_SelectAllBySurveyIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SurveyId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)surveyId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table Survey_Detail with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? surveyId
		///</parameters>
		public static void DeleteAllBySurveyId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? surveyId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSurvey_Detail_DeleteAllBySurveyId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SurveyId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)surveyId?? (object)DBNull.Value));

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
		///This method saves a new object to the table Survey_Detail
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
			command.CommandText = InlineProcs.ctprSurvey_Detail_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SurveyDetailId", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _surveyDetailId));
				command.Parameters.Add(CtSqlParameter.Get("@SurveyId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_surveyId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SurveyQuestionEn", SqlDbType.NVarChar, -1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_surveyQuestionEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SurveyQuestionAr", SqlDbType.NVarChar, -1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_surveyQuestionAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsMuliSelect", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isMuliSelect?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_surveyDetailId					 = Convert.IsDBNull(command.Parameters["@SurveyDetailId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@SurveyDetailId"].Value;
				_surveyId					 = Convert.IsDBNull(command.Parameters["@SurveyId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@SurveyId"].Value;
				_surveyQuestionEn					 = Convert.IsDBNull(command.Parameters["@SurveyQuestionEn"].Value) ? null : (string)command.Parameters["@SurveyQuestionEn"].Value;
				_surveyQuestionAr					 = Convert.IsDBNull(command.Parameters["@SurveyQuestionAr"].Value) ? null : (string)command.Parameters["@SurveyQuestionAr"].Value;
				_isMuliSelect					 = Convert.IsDBNull(command.Parameters["@IsMuliSelect"].Value) ? (bool?)null : (bool?)command.Parameters["@IsMuliSelect"].Value;
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
		///This method returns all data rows in the table Survey_Detail
		///</Summary>
		///<returns>
		///IList-DAOSurveyDetail.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOSurveyDetail> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprSurvey_Detail_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Survey_Detail");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSurveyDetail> objList = new List<DAOSurveyDetail>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSurveyDetail retObj = new DAOSurveyDetail();
						retObj._surveyDetailId					 = Convert.IsDBNull(row["SurveyDetailId"]) ? (Int32?)null : (Int32?)row["SurveyDetailId"];
						retObj._surveyId					 = Convert.IsDBNull(row["SurveyId"]) ? (Int32?)null : (Int32?)row["SurveyId"];
						retObj._surveyQuestionEn					 = Convert.IsDBNull(row["SurveyQuestionEn"]) ? null : (string)row["SurveyQuestionEn"];
						retObj._surveyQuestionAr					 = Convert.IsDBNull(row["SurveyQuestionAr"]) ? null : (string)row["SurveyQuestionAr"];
						retObj._isMuliSelect					 = Convert.IsDBNull(row["IsMuliSelect"]) ? (bool?)null : (bool?)row["IsMuliSelect"];
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
			command.CommandText = InlineProcs.ctprSurvey_Detail_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiSurvey_Detail
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSurvey_Detail_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Survey_Detail");
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
						if (string.Compare(projection.Member, "SurveyDetailId", true) == 0) lst.Add(Convert.IsDBNull(row["SurveyDetailId"]) ? (Int32?)null : (Int32?)row["SurveyDetailId"]);
						if (string.Compare(projection.Member, "SurveyId", true) == 0) lst.Add(Convert.IsDBNull(row["SurveyId"]) ? (Int32?)null : (Int32?)row["SurveyId"]);
						if (string.Compare(projection.Member, "SurveyQuestionEn", true) == 0) lst.Add(Convert.IsDBNull(row["SurveyQuestionEn"]) ? null : (string)row["SurveyQuestionEn"]);
						if (string.Compare(projection.Member, "SurveyQuestionAr", true) == 0) lst.Add(Convert.IsDBNull(row["SurveyQuestionAr"]) ? null : (string)row["SurveyQuestionAr"]);
						if (string.Compare(projection.Member, "IsMuliSelect", true) == 0) lst.Add(Convert.IsDBNull(row["IsMuliSelect"]) ? (bool?)null : (bool?)row["IsMuliSelect"]);
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
		///This method returns all data rows in the table using criteriaquery api Survey_Detail
		///</Summary>
		///<returns>
		///IList-DAOSurveyDetail.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOSurveyDetail> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSurvey_Detail_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Survey_Detail");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOSurveyDetail> objList = new List<DAOSurveyDetail>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOSurveyDetail retObj = new DAOSurveyDetail();
						retObj._surveyDetailId					 = Convert.IsDBNull(row["SurveyDetailId"]) ? (Int32?)null : (Int32?)row["SurveyDetailId"];
						retObj._surveyId					 = Convert.IsDBNull(row["SurveyId"]) ? (Int32?)null : (Int32?)row["SurveyId"];
						retObj._surveyQuestionEn					 = Convert.IsDBNull(row["SurveyQuestionEn"]) ? null : (string)row["SurveyQuestionEn"];
						retObj._surveyQuestionAr					 = Convert.IsDBNull(row["SurveyQuestionAr"]) ? null : (string)row["SurveyQuestionAr"];
						retObj._isMuliSelect					 = Convert.IsDBNull(row["IsMuliSelect"]) ? (bool?)null : (bool?)row["IsMuliSelect"];
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
		///This method returns all data rows in the table using criteriaquery api Survey_Detail
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprSurvey_Detail_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table Survey_Detail based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprSurvey_Detail_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@SurveyDetailId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_surveyDetailId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SurveyId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_surveyId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SurveyQuestionEn", SqlDbType.NVarChar, -1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_surveyQuestionEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@SurveyQuestionAr", SqlDbType.NVarChar, -1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_surveyQuestionAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsMuliSelect", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isMuliSelect?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_surveyDetailId					 = Convert.IsDBNull(command.Parameters["@SurveyDetailId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@SurveyDetailId"].Value;
				_surveyId					 = Convert.IsDBNull(command.Parameters["@SurveyId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@SurveyId"].Value;
				_surveyQuestionEn					 = Convert.IsDBNull(command.Parameters["@SurveyQuestionEn"].Value) ? null : (string)command.Parameters["@SurveyQuestionEn"].Value;
				_surveyQuestionAr					 = Convert.IsDBNull(command.Parameters["@SurveyQuestionAr"].Value) ? null : (string)command.Parameters["@SurveyQuestionAr"].Value;
				_isMuliSelect					 = Convert.IsDBNull(command.Parameters["@IsMuliSelect"].Value) ? (bool?)null : (bool?)command.Parameters["@IsMuliSelect"].Value;
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

		public Int32? SurveyDetailId
		{
			get
			{
				return _surveyDetailId;
			}
			set
			{
				_surveyDetailId = value;
			}
		}

		public Int32? SurveyId
		{
			get
			{
				return _surveyId;
			}
			set
			{
				_surveyId = value;
			}
		}

		public string SurveyQuestionEn
		{
			get
			{
				return _surveyQuestionEn;
			}
			set
			{
				_surveyQuestionEn = value;
			}
		}

		public string SurveyQuestionAr
		{
			get
			{
				return _surveyQuestionAr;
			}
			set
			{
				_surveyQuestionAr = value;
			}
		}

		public bool? IsMuliSelect
		{
			get
			{
				return _isMuliSelect;
			}
			set
			{
				_isMuliSelect = value;
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
		internal static string ctprSurvey_Detail_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[SurveyDetailId]
			,[SurveyId]
			,[SurveyQuestionEn]
			,[SurveyQuestionAr]
			,[IsMuliSelect]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Survey_Detail]
			WHERE 
			[SurveyDetailId] = @SurveyDetailId
			";

		internal static string ctprSurvey_Detail_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[Survey_Detail]
			WHERE 
			[SurveyDetailId] = @SurveyDetailId
			";

		internal static string ctprSurvey_Detail_SelectAllBySurveyId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[SurveyDetailId]
			,[SurveyId]
			,[SurveyQuestionEn]
			,[SurveyQuestionAr]
			,[IsMuliSelect]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Survey_Detail]
			WHERE 
			[SurveyId] = @SurveyId OR ([SurveyId] IS NULL AND @SurveyId IS NULL)
			";

		internal static string ctprSurvey_Detail_SelectAllBySurveyIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Survey_Detail]
			WHERE 
			[SurveyId] = @SurveyId OR ([SurveyId] IS NULL AND @SurveyId IS NULL)
			";

		internal static string ctprSurvey_Detail_DeleteAllBySurveyId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[Survey_Detail]
			WHERE 
			[SurveyId] = @SurveyId OR ([SurveyId] IS NULL AND @SurveyId IS NULL)
			";

		internal static string ctprSurvey_Detail_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[Survey_Detail]
			(
			[SurveyId]
			,[SurveyQuestionEn]
			,[SurveyQuestionAr]
			,[IsMuliSelect]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			)
			VALUES
			(
			@SurveyId
			,@SurveyQuestionEn
			,@SurveyQuestionAr
			,@IsMuliSelect
			,@CBy
			,@CDate
			,@EBy
			,@EDate
			)
			SELECT 
			@SurveyDetailId = [SurveyDetailId]
			,@SurveyId = [SurveyId]
			,@SurveyQuestionEn = [SurveyQuestionEn]
			,@SurveyQuestionAr = [SurveyQuestionAr]
			,@IsMuliSelect = [IsMuliSelect]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[Survey_Detail]
			WHERE 
			[SurveyDetailId] = SCOPE_IDENTITY()
			";

		internal static string ctprSurvey_Detail_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[SurveyDetailId]
			,[SurveyId]
			,[SurveyQuestionEn]
			,[SurveyQuestionAr]
			,[IsMuliSelect]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Survey_Detail]
			";

		internal static string ctprSurvey_Detail_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Survey_Detail]
			";

		internal static string ctprSurvey_Detail_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Survey_Detail]
			##CRITERIA##
			";

		internal static string ctprSurvey_Detail_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[SurveyDetailId]
			,[SurveyId]
			,[SurveyQuestionEn]
			,[SurveyQuestionAr]
			,[IsMuliSelect]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Survey_Detail]
			##CRITERIA##
			";

		internal static string ctprSurvey_Detail_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Survey_Detail]
			##CRITERIA##
			";

		internal static string ctprSurvey_Detail_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[Survey_Detail]
			SET
			[SurveyId] = @SurveyId
			,[SurveyQuestionEn] = @SurveyQuestionEn
			,[SurveyQuestionAr] = @SurveyQuestionAr
			,[IsMuliSelect] = @IsMuliSelect
			,[CBy] = @CBy
			,[CDate] = @CDate
			,[EBy] = @EBy
			,[EDate] = @EDate
			WHERE 
			[SurveyDetailId] = @SurveyDetailId
			SELECT 
			@SurveyDetailId = [SurveyDetailId]
			,@SurveyId = [SurveyId]
			,@SurveyQuestionEn = [SurveyQuestionEn]
			,@SurveyQuestionAr = [SurveyQuestionAr]
			,@IsMuliSelect = [IsMuliSelect]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[Survey_Detail]
			WHERE 
			[SurveyDetailId] = @SurveyDetailId
			";

	}
}
#endregion
