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
	public partial class DAOOperationRequestDetailDocumentVw : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int32? _documentSize;
		protected string _documentExt;
		protected DateTime? _uploadDate;
		protected string _documentPath;
		protected Int32? _documentTypeId;
		protected Int64? _detailId;
		protected Int64? _detailDocumentId;
		protected string _documentTypeNameEn;
		protected string _documentTypeNameAr;
		#endregion

		#region class methods
		public DAOOperationRequestDetailDocumentVw()
		{
		}
		///<Summary>
		///Select all rows
		///This method returns all data rows in the table OperationRequest_Detail_DocumentVw
		///</Summary>
		///<returns>
		///IList-DAOOperationRequestDetailDocumentVw.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOOperationRequestDetailDocumentVw> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprOperationRequest_Detail_DocumentVw_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("OperationRequest_Detail_DocumentVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOOperationRequestDetailDocumentVw> objList = new List<DAOOperationRequestDetailDocumentVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOOperationRequestDetailDocumentVw retObj = new DAOOperationRequestDetailDocumentVw();
						retObj._documentSize					 = Convert.IsDBNull(row["DocumentSize"]) ? (Int32?)null : (Int32?)row["DocumentSize"];
						retObj._documentExt					 = Convert.IsDBNull(row["DocumentExt"]) ? null : (string)row["DocumentExt"];
						retObj._uploadDate					 = Convert.IsDBNull(row["UploadDate"]) ? (DateTime?)null : (DateTime?)row["UploadDate"];
						retObj._documentPath					 = Convert.IsDBNull(row["DocumentPath"]) ? null : (string)row["DocumentPath"];
						retObj._documentTypeId					 = Convert.IsDBNull(row["DocumentTypeId"]) ? (Int32?)null : (Int32?)row["DocumentTypeId"];
						retObj._detailId					 = Convert.IsDBNull(row["DetailId"]) ? (Int64?)null : (Int64?)row["DetailId"];
						retObj._detailDocumentId					 = Convert.IsDBNull(row["DetailDocumentId"]) ? (Int64?)null : (Int64?)row["DetailDocumentId"];
						retObj._documentTypeNameEn					 = Convert.IsDBNull(row["DocumentTypeNameEn"]) ? null : (string)row["DocumentTypeNameEn"];
						retObj._documentTypeNameAr					 = Convert.IsDBNull(row["DocumentTypeNameAr"]) ? null : (string)row["DocumentTypeNameAr"];
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
			command.CommandText = InlineProcs.ctprOperationRequest_Detail_DocumentVw_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiOperationRequest_Detail_DocumentVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprOperationRequest_Detail_DocumentVw_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("OperationRequest_Detail_DocumentVw");
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
						if (string.Compare(projection.Member, "DocumentTypeId", true) == 0) lst.Add(Convert.IsDBNull(row["DocumentTypeId"]) ? (Int32?)null : (Int32?)row["DocumentTypeId"]);
						if (string.Compare(projection.Member, "DetailId", true) == 0) lst.Add(Convert.IsDBNull(row["DetailId"]) ? (Int64?)null : (Int64?)row["DetailId"]);
						if (string.Compare(projection.Member, "DetailDocumentId", true) == 0) lst.Add(Convert.IsDBNull(row["DetailDocumentId"]) ? (Int64?)null : (Int64?)row["DetailDocumentId"]);
						if (string.Compare(projection.Member, "DocumentTypeNameEn", true) == 0) lst.Add(Convert.IsDBNull(row["DocumentTypeNameEn"]) ? null : (string)row["DocumentTypeNameEn"]);
						if (string.Compare(projection.Member, "DocumentTypeNameAr", true) == 0) lst.Add(Convert.IsDBNull(row["DocumentTypeNameAr"]) ? null : (string)row["DocumentTypeNameAr"]);
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
		///This method returns all data rows in the table using criteriaquery api OperationRequest_Detail_DocumentVw
		///</Summary>
		///<returns>
		///IList-DAOOperationRequestDetailDocumentVw.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOOperationRequestDetailDocumentVw> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprOperationRequest_Detail_DocumentVw_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("OperationRequest_Detail_DocumentVw");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOOperationRequestDetailDocumentVw> objList = new List<DAOOperationRequestDetailDocumentVw>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOOperationRequestDetailDocumentVw retObj = new DAOOperationRequestDetailDocumentVw();
						retObj._documentSize					 = Convert.IsDBNull(row["DocumentSize"]) ? (Int32?)null : (Int32?)row["DocumentSize"];
						retObj._documentExt					 = Convert.IsDBNull(row["DocumentExt"]) ? null : (string)row["DocumentExt"];
						retObj._uploadDate					 = Convert.IsDBNull(row["UploadDate"]) ? (DateTime?)null : (DateTime?)row["UploadDate"];
						retObj._documentPath					 = Convert.IsDBNull(row["DocumentPath"]) ? null : (string)row["DocumentPath"];
						retObj._documentTypeId					 = Convert.IsDBNull(row["DocumentTypeId"]) ? (Int32?)null : (Int32?)row["DocumentTypeId"];
						retObj._detailId					 = Convert.IsDBNull(row["DetailId"]) ? (Int64?)null : (Int64?)row["DetailId"];
						retObj._detailDocumentId					 = Convert.IsDBNull(row["DetailDocumentId"]) ? (Int64?)null : (Int64?)row["DetailDocumentId"];
						retObj._documentTypeNameEn					 = Convert.IsDBNull(row["DocumentTypeNameEn"]) ? null : (string)row["DocumentTypeNameEn"];
						retObj._documentTypeNameAr					 = Convert.IsDBNull(row["DocumentTypeNameAr"]) ? null : (string)row["DocumentTypeNameAr"];
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
		///This method returns all data rows in the table using criteriaquery api OperationRequest_Detail_DocumentVw
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprOperationRequest_Detail_DocumentVw_SelectAllByCriteriaCount, null, listCriterion, null);
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

		public Int64? DetailId
		{
			get
			{
				return _detailId;
			}
			set
			{
				_detailId = value;
			}
		}

		public Int64? DetailDocumentId
		{
			get
			{
				return _detailDocumentId;
			}
			set
			{
				_detailDocumentId = value;
			}
		}

		public string DocumentTypeNameEn
		{
			get
			{
				return _documentTypeNameEn;
			}
			set
			{
				_documentTypeNameEn = value;
			}
		}

		public string DocumentTypeNameAr
		{
			get
			{
				return _documentTypeNameAr;
			}
			set
			{
				_documentTypeNameAr = value;
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
		internal static string ctprOperationRequest_Detail_DocumentVw_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[DocumentSize]
			,[DocumentExt]
			,[UploadDate]
			,[DocumentPath]
			,[DocumentTypeId]
			,[DetailId]
			,[DetailDocumentId]
			,[DocumentTypeNameEn]
			,[DocumentTypeNameAr]
			FROM [dbo].[OperationRequest_Detail_DocumentVw]
			";

		internal static string ctprOperationRequest_Detail_DocumentVw_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[OperationRequest_Detail_DocumentVw]
			";

		internal static string ctprOperationRequest_Detail_DocumentVw_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[OperationRequest_Detail_DocumentVw]
			##CRITERIA##
			";

		internal static string ctprOperationRequest_Detail_DocumentVw_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[DocumentSize]
			,[DocumentExt]
			,[UploadDate]
			,[DocumentPath]
			,[DocumentTypeId]
			,[DetailId]
			,[DetailDocumentId]
			,[DocumentTypeNameEn]
			,[DocumentTypeNameAr]
			FROM [dbo].[OperationRequest_Detail_DocumentVw]
			##CRITERIA##
			";

		internal static string ctprOperationRequest_Detail_DocumentVw_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[OperationRequest_Detail_DocumentVw]
			##CRITERIA##
			";

	}
}
#endregion
