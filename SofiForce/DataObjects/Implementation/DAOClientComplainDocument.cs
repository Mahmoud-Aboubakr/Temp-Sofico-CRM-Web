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
	public partial class DAOClientComplainDocument : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int64? _complainDocumentId;
		protected Int64? _complainId;
		protected string _documentPath;
		protected DateTime? _uploadDate;
		protected string _documentExt;
		protected Int32? _documentSize;
		#endregion

		#region class methods
		public DAOClientComplainDocument()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table Client_Complain_Document based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOClientComplainDocument
		///</returns>
		///<parameters>
		///Int64? complainDocumentId
		///</parameters>
		public static DAOClientComplainDocument SelectOne(Int64? complainDocumentId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Complain_Document_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Complain_Document");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ComplainDocumentId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)complainDocumentId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOClientComplainDocument retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOClientComplainDocument();
					retObj._complainDocumentId					 = Convert.IsDBNull(dt.Rows[0]["ComplainDocumentId"]) ? (Int64?)null : (Int64?)dt.Rows[0]["ComplainDocumentId"];
					retObj._complainId					 = Convert.IsDBNull(dt.Rows[0]["ComplainId"]) ? (Int64?)null : (Int64?)dt.Rows[0]["ComplainId"];
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
		///this method allows the object to delete itself from the table Client_Complain_Document based on its primary key
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
			command.CommandText = InlineProcs.ctprClient_Complain_Document_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ComplainDocumentId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)_complainDocumentId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table Client_Complain_Document based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOClientComplainDocument.
		///</returns>
		///<parameters>
		///Int64? complainId
		///</parameters>
		public static IList<DAOClientComplainDocument> SelectAllByComplainId(Int64? complainId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Complain_Document_SelectAllByComplainId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Complain_Document");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ComplainId", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)complainId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientComplainDocument> objList = new List<DAOClientComplainDocument>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientComplainDocument retObj = new DAOClientComplainDocument();
						retObj._complainDocumentId					 = Convert.IsDBNull(row["ComplainDocumentId"]) ? (Int64?)null : (Int64?)row["ComplainDocumentId"];
						retObj._complainId					 = Convert.IsDBNull(row["ComplainId"]) ? (Int64?)null : (Int64?)row["ComplainId"];
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
		///Int64? complainId
		///</parameters>
		public static Int32 SelectAllByComplainIdCount(Int64? complainId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Complain_Document_SelectAllByComplainIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ComplainId", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)complainId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table Client_Complain_Document with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int64? complainId
		///</parameters>
		public static void DeleteAllByComplainId(zSofiForceConn_TxConnectionProvider connectionProvider, Int64? complainId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Complain_Document_DeleteAllByComplainId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ComplainId", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)complainId?? (object)DBNull.Value));

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
		///This method saves a new object to the table Client_Complain_Document
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
			command.CommandText = InlineProcs.ctprClient_Complain_Document_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ComplainDocumentId", SqlDbType.BigInt, 8, ParameterDirection.Output, false, 19, 0, "", DataRowVersion.Proposed, _complainDocumentId));
				command.Parameters.Add(CtSqlParameter.Get("@ComplainId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, true, 19, 0, "", DataRowVersion.Proposed, (object)_complainId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DocumentPath", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_documentPath?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@UploadDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_uploadDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DocumentExt", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_documentExt?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DocumentSize", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_documentSize?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_complainDocumentId					 = Convert.IsDBNull(command.Parameters["@ComplainDocumentId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@ComplainDocumentId"].Value;
				_complainId					 = Convert.IsDBNull(command.Parameters["@ComplainId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@ComplainId"].Value;
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
		///This method returns all data rows in the table Client_Complain_Document
		///</Summary>
		///<returns>
		///IList-DAOClientComplainDocument.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOClientComplainDocument> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Complain_Document_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Complain_Document");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientComplainDocument> objList = new List<DAOClientComplainDocument>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientComplainDocument retObj = new DAOClientComplainDocument();
						retObj._complainDocumentId					 = Convert.IsDBNull(row["ComplainDocumentId"]) ? (Int64?)null : (Int64?)row["ComplainDocumentId"];
						retObj._complainId					 = Convert.IsDBNull(row["ComplainId"]) ? (Int64?)null : (Int64?)row["ComplainId"];
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
			command.CommandText = InlineProcs.ctprClient_Complain_Document_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiClient_Complain_Document
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Complain_Document_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Complain_Document");
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
						if (string.Compare(projection.Member, "ComplainDocumentId", true) == 0) lst.Add(Convert.IsDBNull(row["ComplainDocumentId"]) ? (Int64?)null : (Int64?)row["ComplainDocumentId"]);
						if (string.Compare(projection.Member, "ComplainId", true) == 0) lst.Add(Convert.IsDBNull(row["ComplainId"]) ? (Int64?)null : (Int64?)row["ComplainId"]);
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
		///This method returns all data rows in the table using criteriaquery api Client_Complain_Document
		///</Summary>
		///<returns>
		///IList-DAOClientComplainDocument.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOClientComplainDocument> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Complain_Document_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Complain_Document");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientComplainDocument> objList = new List<DAOClientComplainDocument>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientComplainDocument retObj = new DAOClientComplainDocument();
						retObj._complainDocumentId					 = Convert.IsDBNull(row["ComplainDocumentId"]) ? (Int64?)null : (Int64?)row["ComplainDocumentId"];
						retObj._complainId					 = Convert.IsDBNull(row["ComplainId"]) ? (Int64?)null : (Int64?)row["ComplainId"];
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
		///This method returns all data rows in the table using criteriaquery api Client_Complain_Document
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Complain_Document_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table Client_Complain_Document based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprClient_Complain_Document_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@ComplainDocumentId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, false, 19, 0, "", DataRowVersion.Proposed, (object)_complainDocumentId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ComplainId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, true, 19, 0, "", DataRowVersion.Proposed, (object)_complainId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DocumentPath", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_documentPath?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@UploadDate", SqlDbType.DateTime, 8, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_uploadDate?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DocumentExt", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_documentExt?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DocumentSize", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_documentSize?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_complainDocumentId					 = Convert.IsDBNull(command.Parameters["@ComplainDocumentId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@ComplainDocumentId"].Value;
				_complainId					 = Convert.IsDBNull(command.Parameters["@ComplainId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@ComplainId"].Value;
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

		public Int64? ComplainDocumentId
		{
			get
			{
				return _complainDocumentId;
			}
			set
			{
				_complainDocumentId = value;
			}
		}

		public Int64? ComplainId
		{
			get
			{
				return _complainId;
			}
			set
			{
				_complainId = value;
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
		internal static string ctprClient_Complain_Document_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[ComplainDocumentId]
			,[ComplainId]
			,[DocumentPath]
			,[UploadDate]
			,[DocumentExt]
			,[DocumentSize]
			FROM [dbo].[Client_Complain_Document]
			WHERE 
			[ComplainDocumentId] = @ComplainDocumentId
			";

		internal static string ctprClient_Complain_Document_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[Client_Complain_Document]
			WHERE 
			[ComplainDocumentId] = @ComplainDocumentId
			";

		internal static string ctprClient_Complain_Document_SelectAllByComplainId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[ComplainDocumentId]
			,[ComplainId]
			,[DocumentPath]
			,[UploadDate]
			,[DocumentExt]
			,[DocumentSize]
			FROM [dbo].[Client_Complain_Document]
			WHERE 
			[ComplainId] = @ComplainId OR ([ComplainId] IS NULL AND @ComplainId IS NULL)
			";

		internal static string ctprClient_Complain_Document_SelectAllByComplainIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_Complain_Document]
			WHERE 
			[ComplainId] = @ComplainId OR ([ComplainId] IS NULL AND @ComplainId IS NULL)
			";

		internal static string ctprClient_Complain_Document_DeleteAllByComplainId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[Client_Complain_Document]
			WHERE 
			[ComplainId] = @ComplainId OR ([ComplainId] IS NULL AND @ComplainId IS NULL)
			";

		internal static string ctprClient_Complain_Document_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[Client_Complain_Document]
			(
			[ComplainId]
			,[DocumentPath]
			,[UploadDate]
			,[DocumentExt]
			,[DocumentSize]
			)
			VALUES
			(
			@ComplainId
			,@DocumentPath
			,@UploadDate
			,@DocumentExt
			,@DocumentSize
			)
			SELECT 
			@ComplainDocumentId = [ComplainDocumentId]
			,@ComplainId = [ComplainId]
			,@DocumentPath = [DocumentPath]
			,@UploadDate = [UploadDate]
			,@DocumentExt = [DocumentExt]
			,@DocumentSize = [DocumentSize]
			FROM [dbo].[Client_Complain_Document]
			WHERE 
			[ComplainDocumentId] = SCOPE_IDENTITY()
			";

		internal static string ctprClient_Complain_Document_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[ComplainDocumentId]
			,[ComplainId]
			,[DocumentPath]
			,[UploadDate]
			,[DocumentExt]
			,[DocumentSize]
			FROM [dbo].[Client_Complain_Document]
			";

		internal static string ctprClient_Complain_Document_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_Complain_Document]
			";

		internal static string ctprClient_Complain_Document_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Client_Complain_Document]
			##CRITERIA##
			";

		internal static string ctprClient_Complain_Document_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[ComplainDocumentId]
			,[ComplainId]
			,[DocumentPath]
			,[UploadDate]
			,[DocumentExt]
			,[DocumentSize]
			FROM [dbo].[Client_Complain_Document]
			##CRITERIA##
			";

		internal static string ctprClient_Complain_Document_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Client_Complain_Document]
			##CRITERIA##
			";

		internal static string ctprClient_Complain_Document_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[Client_Complain_Document]
			SET
			[ComplainId] = @ComplainId
			,[DocumentPath] = @DocumentPath
			,[UploadDate] = @UploadDate
			,[DocumentExt] = @DocumentExt
			,[DocumentSize] = @DocumentSize
			WHERE 
			[ComplainDocumentId] = @ComplainDocumentId
			SELECT 
			@ComplainDocumentId = [ComplainDocumentId]
			,@ComplainId = [ComplainId]
			,@DocumentPath = [DocumentPath]
			,@UploadDate = [UploadDate]
			,@DocumentExt = [DocumentExt]
			,@DocumentSize = [DocumentSize]
			FROM [dbo].[Client_Complain_Document]
			WHERE 
			[ComplainDocumentId] = @ComplainDocumentId
			";

	}
}
#endregion
