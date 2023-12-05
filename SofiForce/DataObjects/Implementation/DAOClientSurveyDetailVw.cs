/*************************************************************
** Class generated by CodeTrigger, Version 6.1.0.7
** This class was generated on 4/27/2022 1:23:01 PM
** Changes to this file may cause incorrect behaviour and will be lost if the code is regenerated
**************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using SofiForce.DataObjects.Interfaces;

namespace SofiForce.DataObjects
{
	public partial class DAOClientSurveyDetailVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected bool? _isSelected;
		protected Int32? _detailAnswerId;
		protected Int64? _clientServeyId;
		protected Int64? _clientDetailId;
		protected string _answerEn;
		protected string _answerAr;
		protected string _surveyQuestionEn;
		protected string _surveyQuestionAr;
		protected bool? _isMuliSelect;
		#endregion

		#region class methods
		public DAOClientSurveyDetailVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table Client_Survey_DetailVw
		///</Summary>
		///<returns>
		///IList-DAOClientSurveyDetailVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOClientSurveyDetailVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Survey_DetailVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Survey_DetailVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientSurveyDetailVw> objList = new List<DAOClientSurveyDetailVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientSurveyDetailVw retObj = new DAOClientSurveyDetailVw();
						retObj._isSelected					 = Convert.IsDBNull(row["IsSelected"]) ? (bool?)null : (bool?)row["IsSelected"];
						retObj._detailAnswerId					 = Convert.IsDBNull(row["DetailAnswerId"]) ? (Int32?)null : (Int32?)row["DetailAnswerId"];
						retObj._clientServeyId					 = Convert.IsDBNull(row["ClientServeyId"]) ? (Int64?)null : (Int64?)row["ClientServeyId"];
						retObj._clientDetailId					 = Convert.IsDBNull(row["ClientDetailId"]) ? (Int64?)null : (Int64?)row["ClientDetailId"];
						retObj._answerEn					 = Convert.IsDBNull(row["AnswerEn"]) ? null : (string)row["AnswerEn"];
						retObj._answerAr					 = Convert.IsDBNull(row["AnswerAr"]) ? null : (string)row["AnswerAr"];
						retObj._surveyQuestionEn					 = Convert.IsDBNull(row["SurveyQuestionEn"]) ? null : (string)row["SurveyQuestionEn"];
						retObj._surveyQuestionAr					 = Convert.IsDBNull(row["SurveyQuestionAr"]) ? null : (string)row["SurveyQuestionAr"];
						retObj._isMuliSelect					 = Convert.IsDBNull(row["IsMuliSelect"]) ? (bool?)null : (bool?)row["IsMuliSelect"];
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
			command.CommandText = InlineProcs.ctprClient_Survey_DetailVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiClient_Survey_DetailVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Survey_DetailVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Survey_DetailVw");
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
						if (string.Compare(projection.Member, "IsSelected", true) == 0) lst.Add(Convert.IsDBNull(row["IsSelected"]) ? (bool?)null : (bool?)row["IsSelected"]);
						if (string.Compare(projection.Member, "DetailAnswerId", true) == 0) lst.Add(Convert.IsDBNull(row["DetailAnswerId"]) ? (Int32?)null : (Int32?)row["DetailAnswerId"]);
						if (string.Compare(projection.Member, "ClientServeyId", true) == 0) lst.Add(Convert.IsDBNull(row["ClientServeyId"]) ? (Int64?)null : (Int64?)row["ClientServeyId"]);
						if (string.Compare(projection.Member, "ClientDetailId", true) == 0) lst.Add(Convert.IsDBNull(row["ClientDetailId"]) ? (Int64?)null : (Int64?)row["ClientDetailId"]);
						if (string.Compare(projection.Member, "AnswerEn", true) == 0) lst.Add(Convert.IsDBNull(row["AnswerEn"]) ? null : (string)row["AnswerEn"]);
						if (string.Compare(projection.Member, "AnswerAr", true) == 0) lst.Add(Convert.IsDBNull(row["AnswerAr"]) ? null : (string)row["AnswerAr"]);
						if (string.Compare(projection.Member, "SurveyQuestionEn", true) == 0) lst.Add(Convert.IsDBNull(row["SurveyQuestionEn"]) ? null : (string)row["SurveyQuestionEn"]);
						if (string.Compare(projection.Member, "SurveyQuestionAr", true) == 0) lst.Add(Convert.IsDBNull(row["SurveyQuestionAr"]) ? null : (string)row["SurveyQuestionAr"]);
						if (string.Compare(projection.Member, "IsMuliSelect", true) == 0) lst.Add(Convert.IsDBNull(row["IsMuliSelect"]) ? (bool?)null : (bool?)row["IsMuliSelect"]);
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
		///This method returns all data rows in the table using criteriaquery api Client_Survey_DetailVw
		///</Summary>
		///<returns>
		///IList-DAOClientSurveyDetailVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOClientSurveyDetailVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Survey_DetailVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Survey_DetailVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientSurveyDetailVw> objList = new List<DAOClientSurveyDetailVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientSurveyDetailVw retObj = new DAOClientSurveyDetailVw();
						retObj._isSelected					 = Convert.IsDBNull(row["IsSelected"]) ? (bool?)null : (bool?)row["IsSelected"];
						retObj._detailAnswerId					 = Convert.IsDBNull(row["DetailAnswerId"]) ? (Int32?)null : (Int32?)row["DetailAnswerId"];
						retObj._clientServeyId					 = Convert.IsDBNull(row["ClientServeyId"]) ? (Int64?)null : (Int64?)row["ClientServeyId"];
						retObj._clientDetailId					 = Convert.IsDBNull(row["ClientDetailId"]) ? (Int64?)null : (Int64?)row["ClientDetailId"];
						retObj._answerEn					 = Convert.IsDBNull(row["AnswerEn"]) ? null : (string)row["AnswerEn"];
						retObj._answerAr					 = Convert.IsDBNull(row["AnswerAr"]) ? null : (string)row["AnswerAr"];
						retObj._surveyQuestionEn					 = Convert.IsDBNull(row["SurveyQuestionEn"]) ? null : (string)row["SurveyQuestionEn"];
						retObj._surveyQuestionAr					 = Convert.IsDBNull(row["SurveyQuestionAr"]) ? null : (string)row["SurveyQuestionAr"];
						retObj._isMuliSelect					 = Convert.IsDBNull(row["IsMuliSelect"]) ? (bool?)null : (bool?)row["IsMuliSelect"];
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
		///This method returns all data rows in the table using criteriaquery api Client_Survey_DetailVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Survey_DetailVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public bool? IsSelected
		{
			get
			{
				return _isSelected;
			}
			set
			{
				_isSelected = value;
			}
		}

		public Int32? DetailAnswerId
		{
			get
			{
				return _detailAnswerId;
			}
			set
			{
				_detailAnswerId = value;
			}
		}

		public Int64? ClientServeyId
		{
			get
			{
				return _clientServeyId;
			}
			set
			{
				_clientServeyId = value;
			}
		}

		public Int64? ClientDetailId
		{
			get
			{
				return _clientDetailId;
			}
			set
			{
				_clientDetailId = value;
			}
		}

		public string AnswerEn
		{
			get
			{
				return _answerEn;
			}
			set
			{
				_answerEn = value;
			}
		}

		public string AnswerAr
		{
			get
			{
				return _answerAr;
			}
			set
			{
				_answerAr = value;
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

		#endregion
	}
}

#region inline sql procs
namespace SofiForce.DataObjects
{
	public partial class InlineProcs
	{
		internal static string ctprClient_Survey_DetailVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[IsSelected]
			,[DetailAnswerId]
			,[ClientServeyId]
			,[ClientDetailId]
			,[AnswerEn]
			,[AnswerAr]
			,[SurveyQuestionEn]
			,[SurveyQuestionAr]
			,[IsMuliSelect]
			FROM [dbo].[Client_Survey_DetailVw]
			";

		internal static string ctprClient_Survey_DetailVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_Survey_DetailVw]
			";

		internal static string ctprClient_Survey_DetailVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Client_Survey_DetailVw]
			##CRITERIA##
			";

		internal static string ctprClient_Survey_DetailVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[IsSelected]
			,[DetailAnswerId]
			,[ClientServeyId]
			,[ClientDetailId]
			,[AnswerEn]
			,[AnswerAr]
			,[SurveyQuestionEn]
			,[SurveyQuestionAr]
			,[IsMuliSelect]
			FROM [dbo].[Client_Survey_DetailVw]
			##CRITERIA##
			";

		internal static string ctprClient_Survey_DetailVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Client_Survey_DetailVw]
			##CRITERIA##
			";

	}
}
#endregion