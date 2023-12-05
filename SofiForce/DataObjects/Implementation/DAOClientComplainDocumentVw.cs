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
	public partial class DAOClientComplainDocumentVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _documentSize;
		protected string _documentExt;
		protected DateTime? _uploadDate;
		protected string _documentPath;
		protected Int64? _complainId;
		protected Int64? _complainDocumentId;
		#endregion

		#region class methods
		public DAOClientComplainDocumentVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table Client_Complain_DocumentVw
		///</Summary>
		///<returns>
		///IList-DAOClientComplainDocumentVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOClientComplainDocumentVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprClient_Complain_DocumentVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Complain_DocumentVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientComplainDocumentVw> objList = new List<DAOClientComplainDocumentVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientComplainDocumentVw retObj = new DAOClientComplainDocumentVw();
						retObj._documentSize					 = Convert.IsDBNull(row["DocumentSize"]) ? (Int32?)null : (Int32?)row["DocumentSize"];
						retObj._documentExt					 = Convert.IsDBNull(row["DocumentExt"]) ? null : (string)row["DocumentExt"];
						retObj._uploadDate					 = Convert.IsDBNull(row["UploadDate"]) ? (DateTime?)null : (DateTime?)row["UploadDate"];
						retObj._documentPath					 = Convert.IsDBNull(row["DocumentPath"]) ? null : (string)row["DocumentPath"];
						retObj._complainId					 = Convert.IsDBNull(row["ComplainId"]) ? (Int64?)null : (Int64?)row["ComplainId"];
						retObj._complainDocumentId					 = Convert.IsDBNull(row["ComplainDocumentId"]) ? (Int64?)null : (Int64?)row["ComplainDocumentId"];
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
			command.CommandText = InlineProcs.ctprClient_Complain_DocumentVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiClient_Complain_DocumentVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Complain_DocumentVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Complain_DocumentVw");
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
						if (string.Compare(projection.Member, "DocumentSize", true) == 0) lst.Add(Convert.IsDBNull(row["DocumentSize"]) ? (Int32?)null : (Int32?)row["DocumentSize"]);
						if (string.Compare(projection.Member, "DocumentExt", true) == 0) lst.Add(Convert.IsDBNull(row["DocumentExt"]) ? null : (string)row["DocumentExt"]);
						if (string.Compare(projection.Member, "UploadDate", true) == 0) lst.Add(Convert.IsDBNull(row["UploadDate"]) ? (DateTime?)null : (DateTime?)row["UploadDate"]);
						if (string.Compare(projection.Member, "DocumentPath", true) == 0) lst.Add(Convert.IsDBNull(row["DocumentPath"]) ? null : (string)row["DocumentPath"]);
						if (string.Compare(projection.Member, "ComplainId", true) == 0) lst.Add(Convert.IsDBNull(row["ComplainId"]) ? (Int64?)null : (Int64?)row["ComplainId"]);
						if (string.Compare(projection.Member, "ComplainDocumentId", true) == 0) lst.Add(Convert.IsDBNull(row["ComplainDocumentId"]) ? (Int64?)null : (Int64?)row["ComplainDocumentId"]);
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
		///This method returns all data rows in the table using criteriaquery api Client_Complain_DocumentVw
		///</Summary>
		///<returns>
		///IList-DAOClientComplainDocumentVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOClientComplainDocumentVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Complain_DocumentVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("Client_Complain_DocumentVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOClientComplainDocumentVw> objList = new List<DAOClientComplainDocumentVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOClientComplainDocumentVw retObj = new DAOClientComplainDocumentVw();
						retObj._documentSize					 = Convert.IsDBNull(row["DocumentSize"]) ? (Int32?)null : (Int32?)row["DocumentSize"];
						retObj._documentExt					 = Convert.IsDBNull(row["DocumentExt"]) ? null : (string)row["DocumentExt"];
						retObj._uploadDate					 = Convert.IsDBNull(row["UploadDate"]) ? (DateTime?)null : (DateTime?)row["UploadDate"];
						retObj._documentPath					 = Convert.IsDBNull(row["DocumentPath"]) ? null : (string)row["DocumentPath"];
						retObj._complainId					 = Convert.IsDBNull(row["ComplainId"]) ? (Int64?)null : (Int64?)row["ComplainId"];
						retObj._complainDocumentId					 = Convert.IsDBNull(row["ComplainDocumentId"]) ? (Int64?)null : (Int64?)row["ComplainDocumentId"];
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
		///This method returns all data rows in the table using criteriaquery api Client_Complain_DocumentVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprClient_Complain_DocumentVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		#endregion
	}
}

#region inline sql procs
namespace SofiForce.DataObjects
{
	public partial class InlineProcs
	{
		internal static string ctprClient_Complain_DocumentVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[DocumentSize]
			,[DocumentExt]
			,[UploadDate]
			,[DocumentPath]
			,[ComplainId]
			,[ComplainDocumentId]
			FROM [dbo].[Client_Complain_DocumentVw]
			";

		internal static string ctprClient_Complain_DocumentVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[Client_Complain_DocumentVw]
			";

		internal static string ctprClient_Complain_DocumentVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[Client_Complain_DocumentVw]
			##CRITERIA##
			";

		internal static string ctprClient_Complain_DocumentVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[DocumentSize]
			,[DocumentExt]
			,[UploadDate]
			,[DocumentPath]
			,[ComplainId]
			,[ComplainDocumentId]
			FROM [dbo].[Client_Complain_DocumentVw]
			##CRITERIA##
			";

		internal static string ctprClient_Complain_DocumentVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[Client_Complain_DocumentVw]
			##CRITERIA##
			";

	}
}
#endregion