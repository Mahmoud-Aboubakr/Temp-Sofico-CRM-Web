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
	public partial class DAOClientDocument : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _clientDocumentId;
		protected Int32? _clientId;
		protected Int32? _documentTypeId;
		protected string _documentPath;
		protected DateTime? _uploadDate;
		protected string _documentExt;
		protected Int32? _documentSize;
		#endregion

		#region class methods
		public DAOClientDocument()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table Client_Document based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOClientDocument
		///</returns>
		///<parameters>
		///Int32? clientDocumentId
		///</parameters>
		public static DAOClientDocument SelectOne(Int32? clientDocumentId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Document_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Document");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ClientDocumentId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)clientDocumentId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOClientDocument retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOClientDocument();
					retObj._clientDocumentId					 = Convert.IsDBNull(dt.Rows[0]["ClientDocumentId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["ClientDocumentId"];
					retObj._clientId					 = Convert.IsDBNull(dt.Rows[0]["ClientId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["ClientId"];
					retObj._documentTypeId					 = Convert.IsDBNull(dt.Rows[0]["DocumentTypeId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["DocumentTypeId"];
					retObj._documentPath					 = Convert.IsDBNull(dt.Rows[0]["DocumentPath"]) ? null : (string)dt.Rows[0]["DocumentPath"];
					retObj._uploadDate					 = Convert.IsDBNull(dt.Rows[0]["UploadDate"]) ? (DateTime?)null : (DateTime?)dt.Rows[0]["UploadDate"];
					retObj._documentExt					 = Convert.IsDBNull(dt.Rows[0]["DocumentExt"]) ? null : (string)dt.Rows[0]["DocumentExt"];
					retObj._documentSize					 = Convert.IsDBNull(dt.Rows[0]["DocumentSize"]) ? (Int32?)null : (Int32?)dt.Rows[0]["DocumentSize"];
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
		///this method allows the object to delete itself from the table Client_Document based on its primary key
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
			command.CommandText = InlineProcs.ctprClient_Document_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ClientDocumentId", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, (object)_clientDocumentId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table Client_Document based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOClientDocument.
		///</returns>
		///<parameters>
		///Int32? clientId
		///</parameters>
		public static IList<DAOClientDocument> SelectAllByClientId(Int32? clientId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Document_SelectAllByClientId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Document");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ClientId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)clientId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientDocument> objList = new List<DAOClientDocument>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientDocument retObj = new DAOClientDocument();
						retObj._clientDocumentId					 = Convert.IsDBNull(row["ClientDocumentId"]) ? (Int32?)null : (Int32?)row["ClientDocumentId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._documentTypeId					 = Convert.IsDBNull(row["DocumentTypeId"]) ? (Int32?)null : (Int32?)row["DocumentTypeId"];
						retObj._documentPath					 = Convert.IsDBNull(row["DocumentPath"]) ? null : (string)row["DocumentPath"];
						retObj._uploadDate					 = Convert.IsDBNull(row["UploadDate"]) ? (DateTime?)null : (DateTime?)row["UploadDate"];
						retObj._documentExt					 = Convert.IsDBNull(row["DocumentExt"]) ? null : (string)row["DocumentExt"];
						retObj._documentSize					 = Convert.IsDBNull(row["DocumentSize"]) ? (Int32?)null : (Int32?)row["DocumentSize"];
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
		///Int32? clientId
		///</parameters>
		public static Int32 SelectAllByClientIdCount(Int32? clientId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Document_SelectAllByClientIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ClientId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)clientId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table Client_Document with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? clientId
		///</parameters>
		public static void DeleteAllByClientId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? clientId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Document_DeleteAllByClientId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ClientId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)clientId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table Client_Document based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOClientDocument.
		///</returns>
		///<parameters>
		///Int32? documentTypeId
		///</parameters>
		public static IList<DAOClientDocument> SelectAllByDocumentTypeId(Int32? documentTypeId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Document_SelectAllByDocumentTypeId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Document");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@DocumentTypeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)documentTypeId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientDocument> objList = new List<DAOClientDocument>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientDocument retObj = new DAOClientDocument();
						retObj._clientDocumentId					 = Convert.IsDBNull(row["ClientDocumentId"]) ? (Int32?)null : (Int32?)row["ClientDocumentId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._documentTypeId					 = Convert.IsDBNull(row["DocumentTypeId"]) ? (Int32?)null : (Int32?)row["DocumentTypeId"];
						retObj._documentPath					 = Convert.IsDBNull(row["DocumentPath"]) ? null : (string)row["DocumentPath"];
						retObj._uploadDate					 = Convert.IsDBNull(row["UploadDate"]) ? (DateTime?)null : (DateTime?)row["UploadDate"];
						retObj._documentExt					 = Convert.IsDBNull(row["DocumentExt"]) ? null : (string)row["DocumentExt"];
						retObj._documentSize					 = Convert.IsDBNull(row["DocumentSize"]) ? (Int32?)null : (Int32?)row["DocumentSize"];
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
		///Int32? documentTypeId
		///</parameters>
		public static Int32 SelectAllByDocumentTypeIdCount(Int32? documentTypeId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Document_SelectAllByDocumentTypeIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@DocumentTypeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)documentTypeId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table Client_Document with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? documentTypeId
		///</parameters>
		public static void DeleteAllByDocumentTypeId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? documentTypeId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Document_DeleteAllByDocumentTypeId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@DocumentTypeId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)documentTypeId?? (object)DBNull.Value));

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
		///This method saves a new object to the table Client_Document
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
			command.CommandText = InlineProcs.ctprClient_Document_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ClientDocumentId", SqlDbType.Int, 4, ParameterDirection.Output, false, 10, 0, "", DataRowVersion.Proposed, _clientDocumentId));
				command.Parameters.Add(CtSqlParameter.Get("@ClientId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_clientId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DocumentTypeId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_documentTypeId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DocumentPath", SqlDbType.NVarChar, -1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_documentPath?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@UploadDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_uploadDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DocumentExt", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_documentExt?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DocumentSize", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_documentSize?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_clientDocumentId					 = Convert.IsDBNull(command.Parameters["@ClientDocumentId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ClientDocumentId"].Value;
				_clientId					 = Convert.IsDBNull(command.Parameters["@ClientId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ClientId"].Value;
				_documentTypeId					 = Convert.IsDBNull(command.Parameters["@DocumentTypeId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@DocumentTypeId"].Value;
				_documentPath					 = Convert.IsDBNull(command.Parameters["@DocumentPath"].Value) ? null : (string)command.Parameters["@DocumentPath"].Value;
				_uploadDate					 = Convert.IsDBNull(command.Parameters["@UploadDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@UploadDate"].Value;
				_documentExt					 = Convert.IsDBNull(command.Parameters["@DocumentExt"].Value) ? null : (string)command.Parameters["@DocumentExt"].Value;
				_documentSize					 = Convert.IsDBNull(command.Parameters["@DocumentSize"].Value) ? (Int32?)null : (Int32?)command.Parameters["@DocumentSize"].Value;

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
		///This method returns all data rows in the table Client_Document
		///</Summary>
		///<returns>
		///IList-DAOClientDocument.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOClientDocument> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Document_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Document");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientDocument> objList = new List<DAOClientDocument>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientDocument retObj = new DAOClientDocument();
						retObj._clientDocumentId					 = Convert.IsDBNull(row["ClientDocumentId"]) ? (Int32?)null : (Int32?)row["ClientDocumentId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._documentTypeId					 = Convert.IsDBNull(row["DocumentTypeId"]) ? (Int32?)null : (Int32?)row["DocumentTypeId"];
						retObj._documentPath					 = Convert.IsDBNull(row["DocumentPath"]) ? null : (string)row["DocumentPath"];
						retObj._uploadDate					 = Convert.IsDBNull(row["UploadDate"]) ? (DateTime?)null : (DateTime?)row["UploadDate"];
						retObj._documentExt					 = Convert.IsDBNull(row["DocumentExt"]) ? null : (string)row["DocumentExt"];
						retObj._documentSize					 = Convert.IsDBNull(row["DocumentSize"]) ? (Int32?)null : (Int32?)row["DocumentSize"];
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
			command.CommandText = InlineProcs.ctprClient_Document_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiClient_Document
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Document_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Document");
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
						if (string.Compare(projection.Member, "ClientDocumentId", true) == 0) lst.Add(Convert.IsDBNull(row["ClientDocumentId"]) ? (Int32?)null : (Int32?)row["ClientDocumentId"]);
						if (string.Compare(projection.Member, "ClientId", true) == 0) lst.Add(Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"]);
						if (string.Compare(projection.Member, "DocumentTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["DocumentTypeId"]) ? (Int32?)null : (Int32?)row["DocumentTypeId"]);
						if (string.Compare(projection.Member, "DocumentPath", true) == 0) lst.Add(Convert.IsDBNull(row["DocumentPath"]) ? null : (string)row["DocumentPath"]);
						if (string.Compare(projection.Member, "UploadDate", true) == 0) lst.Add(Convert.IsDBNull(row["UploadDate"]) ? (DateTime?)null : (DateTime?)row["UploadDate"]);
						if (string.Compare(projection.Member, "DocumentExt", true) == 0) lst.Add(Convert.IsDBNull(row["DocumentExt"]) ? null : (string)row["DocumentExt"]);
						if (string.Compare(projection.Member, "DocumentSize", true) == 0) lst.Add(Convert.IsDBNull(row["DocumentSize"]) ? (Int32?)null : (Int32?)row["DocumentSize"]);
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
		///This method returns all data rows in the table using criteriaquery api Client_Document
		///</Summary>
		///<returns>
		///IList-DAOClientDocument.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOClientDocument> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Document_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Document");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientDocument> objList = new List<DAOClientDocument>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientDocument retObj = new DAOClientDocument();
						retObj._clientDocumentId					 = Convert.IsDBNull(row["ClientDocumentId"]) ? (Int32?)null : (Int32?)row["ClientDocumentId"];
						retObj._clientId					 = Convert.IsDBNull(row["ClientId"]) ? (Int32?)null : (Int32?)row["ClientId"];
						retObj._documentTypeId					 = Convert.IsDBNull(row["DocumentTypeId"]) ? (Int32?)null : (Int32?)row["DocumentTypeId"];
						retObj._documentPath					 = Convert.IsDBNull(row["DocumentPath"]) ? null : (string)row["DocumentPath"];
						retObj._uploadDate					 = Convert.IsDBNull(row["UploadDate"]) ? (DateTime?)null : (DateTime?)row["UploadDate"];
						retObj._documentExt					 = Convert.IsDBNull(row["DocumentExt"]) ? null : (string)row["DocumentExt"];
						retObj._documentSize					 = Convert.IsDBNull(row["DocumentSize"]) ? (Int32?)null : (Int32?)row["DocumentSize"];
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
		///This method returns all data rows in the table using criteriaquery api Client_Document
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Document_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table Client_Document based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprClient_Document_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ClientDocumentId", SqlDbType.Int, 4, ParameterDirection.InputOutput, false, 10, 0, "", DataRowVersion.Proposed, (object)_clientDocumentId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ClientId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_clientId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DocumentTypeId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_documentTypeId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DocumentPath", SqlDbType.NVarChar, -1, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_documentPath?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@UploadDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_uploadDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DocumentExt", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_documentExt?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DocumentSize", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_documentSize?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_clientDocumentId					 = Convert.IsDBNull(command.Parameters["@ClientDocumentId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ClientDocumentId"].Value;
				_clientId					 = Convert.IsDBNull(command.Parameters["@ClientId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@ClientId"].Value;
				_documentTypeId					 = Convert.IsDBNull(command.Parameters["@DocumentTypeId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@DocumentTypeId"].Value;
				_documentPath					 = Convert.IsDBNull(command.Parameters["@DocumentPath"].Value) ? null : (string)command.Parameters["@DocumentPath"].Value;
				_uploadDate					 = Convert.IsDBNull(command.Parameters["@UploadDate"].Value) ? (DateTime?)null : (DateTime?)command.Parameters["@UploadDate"].Value;
				_documentExt					 = Convert.IsDBNull(command.Parameters["@DocumentExt"].Value) ? null : (string)command.Parameters["@DocumentExt"].Value;
				_documentSize					 = Convert.IsDBNull(command.Parameters["@DocumentSize"].Value) ? (Int32?)null : (Int32?)command.Parameters["@DocumentSize"].Value;

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

		public Int32? ClientDocumentId
		{
			get
			{
				return _clientDocumentId;
			}
			set
			{
				_clientDocumentId = value;
			}
		}

		public Int32? ClientId
		{
			get
			{
				return _clientId;
			}
			set
			{
				_clientId = value;
			}
		}

		public Int32? DocumentTypeId
		{
			get
			{
				return _documentTypeId;
			}
			set
			{
				_documentTypeId = value;
			}
		}

		public string DocumentPath
		{
			get
			{
				return _documentPath;
			}
			set
			{
				_documentPath = value;
			}
		}

		public DateTime? UploadDate
		{
			get
			{
				return _uploadDate;
			}
			set
			{
				_uploadDate = value;
			}
		}

		public string DocumentExt
		{
			get
			{
				return _documentExt;
			}
			set
			{
				_documentExt = value;
			}
		}

		public Int32? DocumentSize
		{
			get
			{
				return _documentSize;
			}
			set
			{
				_documentSize = value;
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
		internal static string ctprClient_Document_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[ClientDocumentId]
			,[ClientId]
			,[DocumentTypeId]
			,[DocumentPath]
			,[UploadDate]
			,[DocumentExt]
			,[DocumentSize]
			FROM [dbo].[Client_Document]
			WHERE 
			[ClientDocumentId] = @ClientDocumentId
			";

		internal static string ctprClient_Document_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[Client_Document]
			WHERE 
			[ClientDocumentId] = @ClientDocumentId
			";

		internal static string ctprClient_Document_SelectAllByClientId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[ClientDocumentId]
			,[ClientId]
			,[DocumentTypeId]
			,[DocumentPath]
			,[UploadDate]
			,[DocumentExt]
			,[DocumentSize]
			FROM [dbo].[Client_Document]
			WHERE 
			[ClientId] = @ClientId OR ([ClientId] IS NULL AND @ClientId IS NULL)
			";

		internal static string ctprClient_Document_SelectAllByClientIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_Document]
			WHERE 
			[ClientId] = @ClientId OR ([ClientId] IS NULL AND @ClientId IS NULL)
			";

		internal static string ctprClient_Document_DeleteAllByClientId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[Client_Document]
			WHERE 
			[ClientId] = @ClientId OR ([ClientId] IS NULL AND @ClientId IS NULL)
			";

		internal static string ctprClient_Document_SelectAllByDocumentTypeId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[ClientDocumentId]
			,[ClientId]
			,[DocumentTypeId]
			,[DocumentPath]
			,[UploadDate]
			,[DocumentExt]
			,[DocumentSize]
			FROM [dbo].[Client_Document]
			WHERE 
			[DocumentTypeId] = @DocumentTypeId OR ([DocumentTypeId] IS NULL AND @DocumentTypeId IS NULL)
			";

		internal static string ctprClient_Document_SelectAllByDocumentTypeIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_Document]
			WHERE 
			[DocumentTypeId] = @DocumentTypeId OR ([DocumentTypeId] IS NULL AND @DocumentTypeId IS NULL)
			";

		internal static string ctprClient_Document_DeleteAllByDocumentTypeId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[Client_Document]
			WHERE 
			[DocumentTypeId] = @DocumentTypeId OR ([DocumentTypeId] IS NULL AND @DocumentTypeId IS NULL)
			";

		internal static string ctprClient_Document_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[Client_Document]
			(
			[ClientId]
			,[DocumentTypeId]
			,[DocumentPath]
			,[UploadDate]
			,[DocumentExt]
			,[DocumentSize]
			)
			VALUES
			(
			@ClientId
			,@DocumentTypeId
			,@DocumentPath
			,@UploadDate
			,@DocumentExt
			,@DocumentSize
			)
			SELECT 
			@ClientDocumentId = [ClientDocumentId]
			,@ClientId = [ClientId]
			,@DocumentTypeId = [DocumentTypeId]
			,@DocumentPath = [DocumentPath]
			,@UploadDate = [UploadDate]
			,@DocumentExt = [DocumentExt]
			,@DocumentSize = [DocumentSize]
			FROM [dbo].[Client_Document]
			WHERE 
			[ClientDocumentId] = SCOPE_IDENTITY()
			";

		internal static string ctprClient_Document_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[ClientDocumentId]
			,[ClientId]
			,[DocumentTypeId]
			,[DocumentPath]
			,[UploadDate]
			,[DocumentExt]
			,[DocumentSize]
			FROM [dbo].[Client_Document]
			";

		internal static string ctprClient_Document_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_Document]
			";

		internal static string ctprClient_Document_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Client_Document]
			##CRITERIA##
			";

		internal static string ctprClient_Document_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[ClientDocumentId]
			,[ClientId]
			,[DocumentTypeId]
			,[DocumentPath]
			,[UploadDate]
			,[DocumentExt]
			,[DocumentSize]
			FROM [dbo].[Client_Document]
			##CRITERIA##
			";

		internal static string ctprClient_Document_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Client_Document]
			##CRITERIA##
			";

		internal static string ctprClient_Document_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[Client_Document]
			SET
			[ClientId] = @ClientId
			,[DocumentTypeId] = @DocumentTypeId
			,[DocumentPath] = @DocumentPath
			,[UploadDate] = @UploadDate
			,[DocumentExt] = @DocumentExt
			,[DocumentSize] = @DocumentSize
			WHERE 
			[ClientDocumentId] = @ClientDocumentId
			SELECT 
			@ClientDocumentId = [ClientDocumentId]
			,@ClientId = [ClientId]
			,@DocumentTypeId = [DocumentTypeId]
			,@DocumentPath = [DocumentPath]
			,@UploadDate = [UploadDate]
			,@DocumentExt = [DocumentExt]
			,@DocumentSize = [DocumentSize]
			FROM [dbo].[Client_Document]
			WHERE 
			[ClientDocumentId] = @ClientDocumentId
			";

	}
}
#endregion
