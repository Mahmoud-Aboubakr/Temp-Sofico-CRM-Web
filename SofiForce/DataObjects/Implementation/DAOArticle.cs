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
	public partial class DAOArticle : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _articleId;
		protected string _articleCode;
		protected DateTime? _articleDate;
		protected DateTime? _articleTime;
		protected Int32? _articleCategoryId;
		protected string _articleTitleAr;
		protected string _articleTitleEn;
		protected bool? _isActive;
		protected string _articleImage;
		protected Int32? _cBy;
		protected DateTime? _cDate;
		protected Int32? _eBy;
		protected DateTime? _eDate;
		#endregion

		#region class methods
		public DAOArticle()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table Article based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOArticle
		///</returns>
		///<parameters>
		///Int32? articleId
		///</parameters>
		public static DAOArticle SelectOne(Int32? articleId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprArticle_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Article");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ArticleId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)articleId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOArticle retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOArticle();
					retObj._articleId					 = Convert.IsDBNull(dt.Rows[0]["ArticleId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["ArticleId"];
					retObj._articleCode					 = Convert.IsDBNull(dt.Rows[0]["ArticleCode"]) ? null : (string)dt.Rows[0]["ArticleCode"];
					retObj._articleDate					 = Convert.IsDBNull(dt.Rows[0]["ArticleDate"]) ? (DateTime?)null : (DateTime?)dt.Rows[0]["ArticleDate"];
					retObj._articleTime					 = Convert.IsDBNull(dt.Rows[0]["ArticleTime"]) ? (DateTime?)null : (DateTime?)dt.Rows[0]["ArticleTime"];
					retObj._articleCategoryId					 = Convert.IsDBNull(dt.Rows[0]["ArticleCategoryId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["ArticleCategoryId"];
					retObj._articleTitleAr					 = Convert.IsDBNull(dt.Rows[0]["ArticleTitleAr"]) ? null : (string)dt.Rows[0]["ArticleTitleAr"];
					retObj._articleTitleEn					 = Convert.IsDBNull(dt.Rows[0]["ArticleTitleEn"]) ? null : (string)dt.Rows[0]["ArticleTitleEn"];
					retObj._isActive					 = Convert.IsDBNull(dt.Rows[0]["IsActive"]) ? (bool?)null : (bool?)dt.Rows[0]["IsActive"];
					retObj._articleImage					 = Convert.IsDBNull(dt.Rows[0]["ArticleImage"]) ? null : (string)dt.Rows[0]["ArticleImage"];
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
		///this method allows the object to delete itself from the table Article based on its primary key
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
			command.CommandText = InlineProcs.ctprArticle_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ArticleId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_articleId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table Article based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOArticle.
		///</returns>
		///<parameters>
		///Int32? articleCategoryId
		///</parameters>
		public static IList<DAOArticle> SelectAllByArticleCategoryId(Int32? articleCategoryId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprArticle_SelectAllByArticleCategoryId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Article");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ArticleCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)articleCategoryId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOArticle> objList = new List<DAOArticle>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOArticle retObj = new DAOArticle();
						retObj._articleId					 = Convert.IsDBNull(row["ArticleId"]) ? (Int32?)null : (Int32?)row["ArticleId"];
						retObj._articleCode					 = Convert.IsDBNull(row["ArticleCode"]) ? null : (string)row["ArticleCode"];
						retObj._articleDate					 = Convert.IsDBNull(row["ArticleDate"]) ? (DateTime?)null : (DateTime?)row["ArticleDate"];
						retObj._articleTime					 = Convert.IsDBNull(row["ArticleTime"]) ? (DateTime?)null : (DateTime?)row["ArticleTime"];
						retObj._articleCategoryId					 = Convert.IsDBNull(row["ArticleCategoryId"]) ? (Int32?)null : (Int32?)row["ArticleCategoryId"];
						retObj._articleTitleAr					 = Convert.IsDBNull(row["ArticleTitleAr"]) ? null : (string)row["ArticleTitleAr"];
						retObj._articleTitleEn					 = Convert.IsDBNull(row["ArticleTitleEn"]) ? null : (string)row["ArticleTitleEn"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._articleImage					 = Convert.IsDBNull(row["ArticleImage"]) ? null : (string)row["ArticleImage"];
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
		///Int32? articleCategoryId
		///</parameters>
		public static Int32 SelectAllByArticleCategoryIdCount(Int32? articleCategoryId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprArticle_SelectAllByArticleCategoryIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ArticleCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)articleCategoryId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table Article with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? articleCategoryId
		///</parameters>
		public static void DeleteAllByArticleCategoryId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? articleCategoryId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprArticle_DeleteAllByArticleCategoryId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ArticleCategoryId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)articleCategoryId?? (object)DBNull.Value));

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
		///This method saves a new object to the table Article
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
			command.CommandText = InlineProcs.ctprArticle_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ArticleId", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _articleId));
				command.Parameters.Add(CtSqlParameter.Get("@ArticleCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_articleCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ArticleDate", SqlDbType.Date, 3, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_articleDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ArticleTime", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_articleTime?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ArticleCategoryId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_articleCategoryId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ArticleTitleAr", SqlDbType.NVarChar, 500, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_articleTitleAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ArticleTitleEn", SqlDbType.NVarChar, 500, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_articleTitleEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ArticleImage", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_articleImage?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_articleId					 = Convert.IsDBNull(command.Parameters["@ArticleId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ArticleId"].Value;
				_articleCode					 = Convert.IsDBNull(command.Parameters["@ArticleCode"].Value) ? null : (string)command.Parameters["@ArticleCode"].Value;
				_articleDate					 = Convert.IsDBNull(command.Parameters["@ArticleDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@ArticleDate"].Value;
				_articleTime					 = Convert.IsDBNull(command.Parameters["@ArticleTime"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@ArticleTime"].Value;
				_articleCategoryId					 = Convert.IsDBNull(command.Parameters["@ArticleCategoryId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ArticleCategoryId"].Value;
				_articleTitleAr					 = Convert.IsDBNull(command.Parameters["@ArticleTitleAr"].Value) ? null : (string)command.Parameters["@ArticleTitleAr"].Value;
				_articleTitleEn					 = Convert.IsDBNull(command.Parameters["@ArticleTitleEn"].Value) ? null : (string)command.Parameters["@ArticleTitleEn"].Value;
				_isActive					 = Convert.IsDBNull(command.Parameters["@IsActive"].Value) ? (bool?)null : (bool?)command.Parameters["@IsActive"].Value;
				_articleImage					 = Convert.IsDBNull(command.Parameters["@ArticleImage"].Value) ? null : (string)command.Parameters["@ArticleImage"].Value;
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
		///This method returns all data rows in the table Article
		///</Summary>
		///<returns>
		///IList-DAOArticle.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOArticle> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprArticle_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Article");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOArticle> objList = new List<DAOArticle>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOArticle retObj = new DAOArticle();
						retObj._articleId					 = Convert.IsDBNull(row["ArticleId"]) ? (Int32?)null : (Int32?)row["ArticleId"];
						retObj._articleCode					 = Convert.IsDBNull(row["ArticleCode"]) ? null : (string)row["ArticleCode"];
						retObj._articleDate					 = Convert.IsDBNull(row["ArticleDate"]) ? (DateTime?)null : (DateTime?)row["ArticleDate"];
						retObj._articleTime					 = Convert.IsDBNull(row["ArticleTime"]) ? (DateTime?)null : (DateTime?)row["ArticleTime"];
						retObj._articleCategoryId					 = Convert.IsDBNull(row["ArticleCategoryId"]) ? (Int32?)null : (Int32?)row["ArticleCategoryId"];
						retObj._articleTitleAr					 = Convert.IsDBNull(row["ArticleTitleAr"]) ? null : (string)row["ArticleTitleAr"];
						retObj._articleTitleEn					 = Convert.IsDBNull(row["ArticleTitleEn"]) ? null : (string)row["ArticleTitleEn"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._articleImage					 = Convert.IsDBNull(row["ArticleImage"]) ? null : (string)row["ArticleImage"];
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
			command.CommandText = InlineProcs.ctprArticle_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiArticle
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprArticle_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Article");
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
						if (string.Compare(projection.Member, "ArticleId", true) == 0) lst.Add(Convert.IsDBNull(row["ArticleId"]) ? (Int32?)null : (Int32?)row["ArticleId"]);
						if (string.Compare(projection.Member, "ArticleCode", true) == 0) lst.Add(Convert.IsDBNull(row["ArticleCode"]) ? null : (string)row["ArticleCode"]);
						if (string.Compare(projection.Member, "ArticleDate", true) == 0) lst.Add(Convert.IsDBNull(row["ArticleDate"]) ? (DateTime?)null : (DateTime?)row["ArticleDate"]);
						if (string.Compare(projection.Member, "ArticleTime", true) == 0) lst.Add(Convert.IsDBNull(row["ArticleTime"]) ? (DateTime?)null : (DateTime?)row["ArticleTime"]);
						if (string.Compare(projection.Member, "ArticleCategoryId", true) == 0) lst.Add(Convert.IsDBNull(row["ArticleCategoryId"]) ? (Int32?)null : (Int32?)row["ArticleCategoryId"]);
						if (string.Compare(projection.Member, "ArticleTitleAr", true) == 0) lst.Add(Convert.IsDBNull(row["ArticleTitleAr"]) ? null : (string)row["ArticleTitleAr"]);
						if (string.Compare(projection.Member, "ArticleTitleEn", true) == 0) lst.Add(Convert.IsDBNull(row["ArticleTitleEn"]) ? null : (string)row["ArticleTitleEn"]);
						if (string.Compare(projection.Member, "IsActive", true) == 0) lst.Add(Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"]);
						if (string.Compare(projection.Member, "ArticleImage", true) == 0) lst.Add(Convert.IsDBNull(row["ArticleImage"]) ? null : (string)row["ArticleImage"]);
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
		///This method returns all data rows in the table using criteriaquery api Article
		///</Summary>
		///<returns>
		///IList-DAOArticle.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOArticle> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprArticle_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Article");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOArticle> objList = new List<DAOArticle>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOArticle retObj = new DAOArticle();
						retObj._articleId					 = Convert.IsDBNull(row["ArticleId"]) ? (Int32?)null : (Int32?)row["ArticleId"];
						retObj._articleCode					 = Convert.IsDBNull(row["ArticleCode"]) ? null : (string)row["ArticleCode"];
						retObj._articleDate					 = Convert.IsDBNull(row["ArticleDate"]) ? (DateTime?)null : (DateTime?)row["ArticleDate"];
						retObj._articleTime					 = Convert.IsDBNull(row["ArticleTime"]) ? (DateTime?)null : (DateTime?)row["ArticleTime"];
						retObj._articleCategoryId					 = Convert.IsDBNull(row["ArticleCategoryId"]) ? (Int32?)null : (Int32?)row["ArticleCategoryId"];
						retObj._articleTitleAr					 = Convert.IsDBNull(row["ArticleTitleAr"]) ? null : (string)row["ArticleTitleAr"];
						retObj._articleTitleEn					 = Convert.IsDBNull(row["ArticleTitleEn"]) ? null : (string)row["ArticleTitleEn"];
						retObj._isActive					 = Convert.IsDBNull(row["IsActive"]) ? (bool?)null : (bool?)row["IsActive"];
						retObj._articleImage					 = Convert.IsDBNull(row["ArticleImage"]) ? null : (string)row["ArticleImage"];
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
		///This method returns all data rows in the table using criteriaquery api Article
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprArticle_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table Article based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprArticle_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ArticleId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_articleId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ArticleCode", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_articleCode?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ArticleDate", SqlDbType.Date, 3, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_articleDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ArticleTime", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_articleTime?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ArticleCategoryId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_articleCategoryId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ArticleTitleAr", SqlDbType.NVarChar, 500, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_articleTitleAr?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ArticleTitleEn", SqlDbType.NVarChar, 500, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_articleTitleEn?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@IsActive", SqlDbType.Bit, 1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_isActive?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ArticleImage", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_articleImage?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_cBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@CDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_cDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EBy", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_eBy?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@EDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_eDate?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_articleId					 = Convert.IsDBNull(command.Parameters["@ArticleId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ArticleId"].Value;
				_articleCode					 = Convert.IsDBNull(command.Parameters["@ArticleCode"].Value) ? null : (string)command.Parameters["@ArticleCode"].Value;
				_articleDate					 = Convert.IsDBNull(command.Parameters["@ArticleDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@ArticleDate"].Value;
				_articleTime					 = Convert.IsDBNull(command.Parameters["@ArticleTime"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@ArticleTime"].Value;
				_articleCategoryId					 = Convert.IsDBNull(command.Parameters["@ArticleCategoryId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ArticleCategoryId"].Value;
				_articleTitleAr					 = Convert.IsDBNull(command.Parameters["@ArticleTitleAr"].Value) ? null : (string)command.Parameters["@ArticleTitleAr"].Value;
				_articleTitleEn					 = Convert.IsDBNull(command.Parameters["@ArticleTitleEn"].Value) ? null : (string)command.Parameters["@ArticleTitleEn"].Value;
				_isActive					 = Convert.IsDBNull(command.Parameters["@IsActive"].Value) ? (bool?)null : (bool?)command.Parameters["@IsActive"].Value;
				_articleImage					 = Convert.IsDBNull(command.Parameters["@ArticleImage"].Value) ? null : (string)command.Parameters["@ArticleImage"].Value;
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

		public Int32? ArticleId
		{
			get
			{
				return _articleId;
			}
			set
			{
				_articleId = value;
			}
		}

		public string ArticleCode
		{
			get
			{
				return _articleCode;
			}
			set
			{
				_articleCode = value;
			}
		}

		public DateTime? ArticleDate
		{
			get
			{
				return _articleDate;
			}
			set
			{
				_articleDate = value;
			}
		}

		public DateTime? ArticleTime
		{
			get
			{
				return _articleTime;
			}
			set
			{
				_articleTime = value;
			}
		}

		public Int32? ArticleCategoryId
		{
			get
			{
				return _articleCategoryId;
			}
			set
			{
				_articleCategoryId = value;
			}
		}

		public string ArticleTitleAr
		{
			get
			{
				return _articleTitleAr;
			}
			set
			{
				_articleTitleAr = value;
			}
		}

		public string ArticleTitleEn
		{
			get
			{
				return _articleTitleEn;
			}
			set
			{
				_articleTitleEn = value;
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

		public string ArticleImage
		{
			get
			{
				return _articleImage;
			}
			set
			{
				_articleImage = value;
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
		internal static string ctprArticle_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[ArticleId]
			,[ArticleCode]
			,[ArticleDate]
			,[ArticleTime]
			,[ArticleCategoryId]
			,[ArticleTitleAr]
			,[ArticleTitleEn]
			,[IsActive]
			,[ArticleImage]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Article]
			WHERE 
			[ArticleId] = @ArticleId
			";

		internal static string ctprArticle_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[Article]
			WHERE 
			[ArticleId] = @ArticleId
			";

		internal static string ctprArticle_SelectAllByArticleCategoryId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[ArticleId]
			,[ArticleCode]
			,[ArticleDate]
			,[ArticleTime]
			,[ArticleCategoryId]
			,[ArticleTitleAr]
			,[ArticleTitleEn]
			,[IsActive]
			,[ArticleImage]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Article]
			WHERE 
			[ArticleCategoryId] = @ArticleCategoryId OR ([ArticleCategoryId] IS NULL AND @ArticleCategoryId IS NULL)
			";

		internal static string ctprArticle_SelectAllByArticleCategoryIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Article]
			WHERE 
			[ArticleCategoryId] = @ArticleCategoryId OR ([ArticleCategoryId] IS NULL AND @ArticleCategoryId IS NULL)
			";

		internal static string ctprArticle_DeleteAllByArticleCategoryId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[Article]
			WHERE 
			[ArticleCategoryId] = @ArticleCategoryId OR ([ArticleCategoryId] IS NULL AND @ArticleCategoryId IS NULL)
			";

		internal static string ctprArticle_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[Article]
			(
			[ArticleCode]
			,[ArticleDate]
			,[ArticleTime]
			,[ArticleCategoryId]
			,[ArticleTitleAr]
			,[ArticleTitleEn]
			,[IsActive]
			,[ArticleImage]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			)
			VALUES
			(
			@ArticleCode
			,@ArticleDate
			,@ArticleTime
			,@ArticleCategoryId
			,@ArticleTitleAr
			,@ArticleTitleEn
			,@IsActive
			,@ArticleImage
			,@CBy
			,@CDate
			,@EBy
			,@EDate
			)
			SELECT 
			@ArticleId = [ArticleId]
			,@ArticleCode = [ArticleCode]
			,@ArticleDate = [ArticleDate]
			,@ArticleTime = [ArticleTime]
			,@ArticleCategoryId = [ArticleCategoryId]
			,@ArticleTitleAr = [ArticleTitleAr]
			,@ArticleTitleEn = [ArticleTitleEn]
			,@IsActive = [IsActive]
			,@ArticleImage = [ArticleImage]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[Article]
			WHERE 
			[ArticleId] = SCOPE_IDENTITY()
			";

		internal static string ctprArticle_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[ArticleId]
			,[ArticleCode]
			,[ArticleDate]
			,[ArticleTime]
			,[ArticleCategoryId]
			,[ArticleTitleAr]
			,[ArticleTitleEn]
			,[IsActive]
			,[ArticleImage]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Article]
			";

		internal static string ctprArticle_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Article]
			";

		internal static string ctprArticle_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Article]
			##CRITERIA##
			";

		internal static string ctprArticle_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[ArticleId]
			,[ArticleCode]
			,[ArticleDate]
			,[ArticleTime]
			,[ArticleCategoryId]
			,[ArticleTitleAr]
			,[ArticleTitleEn]
			,[IsActive]
			,[ArticleImage]
			,[CBy]
			,[CDate]
			,[EBy]
			,[EDate]
			FROM [dbo].[Article]
			##CRITERIA##
			";

		internal static string ctprArticle_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Article]
			##CRITERIA##
			";

		internal static string ctprArticle_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[Article]
			SET
			[ArticleCode] = @ArticleCode
			,[ArticleDate] = @ArticleDate
			,[ArticleTime] = @ArticleTime
			,[ArticleCategoryId] = @ArticleCategoryId
			,[ArticleTitleAr] = @ArticleTitleAr
			,[ArticleTitleEn] = @ArticleTitleEn
			,[IsActive] = @IsActive
			,[ArticleImage] = @ArticleImage
			,[CBy] = @CBy
			,[CDate] = @CDate
			,[EBy] = @EBy
			,[EDate] = @EDate
			WHERE 
			[ArticleId] = @ArticleId
			SELECT 
			@ArticleId = [ArticleId]
			,@ArticleCode = [ArticleCode]
			,@ArticleDate = [ArticleDate]
			,@ArticleTime = [ArticleTime]
			,@ArticleCategoryId = [ArticleCategoryId]
			,@ArticleTitleAr = [ArticleTitleAr]
			,@ArticleTitleEn = [ArticleTitleEn]
			,@IsActive = [IsActive]
			,@ArticleImage = [ArticleImage]
			,@CBy = [CBy]
			,@CDate = [CDate]
			,@EBy = [EBy]
			,@EDate = [EDate]
			FROM [dbo].[Article]
			WHERE 
			[ArticleId] = @ArticleId
			";

	}
}
#endregion
