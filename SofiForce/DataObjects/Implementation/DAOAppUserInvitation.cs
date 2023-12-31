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
	public partial class DAOAppUserInvitation : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int64? _invitationId;
		protected Int32? _userId;
		protected string _invitationLink;
		protected Int32? _downloads;
		#endregion

		#region class methods
		public DAOAppUserInvitation()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table AppUser_Invitation based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOAppUserInvitation
		///</returns>
		///<parameters>
		///Int64? invitationId
		///</parameters>
		public static DAOAppUserInvitation SelectOne(Int64? invitationId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_Invitation_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_Invitation");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@InvitationId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)invitationId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOAppUserInvitation retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOAppUserInvitation();
					retObj._invitationId					 = Convert.IsDBNull(dt.Rows[0]["InvitationId"]) ? (Int64?)null : (Int64?)dt.Rows[0]["InvitationId"];
					retObj._userId					 = Convert.IsDBNull(dt.Rows[0]["UserId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["UserId"];
					retObj._invitationLink					 = Convert.IsDBNull(dt.Rows[0]["InvitationLink"]) ? null : (string)dt.Rows[0]["InvitationLink"];
					retObj._downloads					 = Convert.IsDBNull(dt.Rows[0]["Downloads"]) ? (Int32?)null : (Int32?)dt.Rows[0]["Downloads"];
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
		///this method allows the object to delete itself from the table AppUser_Invitation based on its primary key
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
			command.CommandText = InlineProcs.ctprAppUser_Invitation_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@InvitationId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)_invitationId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table AppUser_Invitation based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOAppUserInvitation.
		///</returns>
		///<parameters>
		///Int32? userId
		///</parameters>
		public static IList<DAOAppUserInvitation> SelectAllByUserId(Int32? userId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_Invitation_SelectAllByUserId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_Invitation");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@UserId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)userId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserInvitation> objList = new List<DAOAppUserInvitation>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserInvitation retObj = new DAOAppUserInvitation();
						retObj._invitationId					 = Convert.IsDBNull(row["InvitationId"]) ? (Int64?)null : (Int64?)row["InvitationId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._invitationLink					 = Convert.IsDBNull(row["InvitationLink"]) ? null : (string)row["InvitationLink"];
						retObj._downloads					 = Convert.IsDBNull(row["Downloads"]) ? (Int32?)null : (Int32?)row["Downloads"];
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
		///Int32? userId
		///</parameters>
		public static Int32 SelectAllByUserIdCount(Int32? userId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_Invitation_SelectAllByUserIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@UserId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)userId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table AppUser_Invitation with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? userId
		///</parameters>
		public static void DeleteAllByUserId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? userId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_Invitation_DeleteAllByUserId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@UserId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)userId?? (object)DBNull.Value));

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
		///This method saves a new object to the table AppUser_Invitation
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
			command.CommandText = InlineProcs.ctprAppUser_Invitation_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@InvitationId", SqlDbType.BigInt, 8, ParameterDirection.Output, false, 19, 0, "", DataRowVersion.Proposed, _invitationId));
				command.Parameters.Add(CtSqlParameter.Get("@UserId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_userId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@InvitationLink", SqlDbType.NVarChar, 500, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_invitationLink?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Downloads", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_downloads?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_invitationId					 = Convert.IsDBNull(command.Parameters["@InvitationId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@InvitationId"].Value;
				_userId					 = Convert.IsDBNull(command.Parameters["@UserId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@UserId"].Value;
				_invitationLink					 = Convert.IsDBNull(command.Parameters["@InvitationLink"].Value) ? null : (string)command.Parameters["@InvitationLink"].Value;
				_downloads					 = Convert.IsDBNull(command.Parameters["@Downloads"].Value) ? (Int32?)null : (Int32?)command.Parameters["@Downloads"].Value;

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
		///This method returns all data rows in the table AppUser_Invitation
		///</Summary>
		///<returns>
		///IList-DAOAppUserInvitation.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOAppUserInvitation> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprAppUser_Invitation_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_Invitation");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserInvitation> objList = new List<DAOAppUserInvitation>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserInvitation retObj = new DAOAppUserInvitation();
						retObj._invitationId					 = Convert.IsDBNull(row["InvitationId"]) ? (Int64?)null : (Int64?)row["InvitationId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._invitationLink					 = Convert.IsDBNull(row["InvitationLink"]) ? null : (string)row["InvitationLink"];
						retObj._downloads					 = Convert.IsDBNull(row["Downloads"]) ? (Int32?)null : (Int32?)row["Downloads"];
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
			command.CommandText = InlineProcs.ctprAppUser_Invitation_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiAppUser_Invitation
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUser_Invitation_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_Invitation");
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
						if (string.Compare(projection.Member, "InvitationId", true) == 0) lst.Add(Convert.IsDBNull(row["InvitationId"]) ? (Int64?)null : (Int64?)row["InvitationId"]);
						if (string.Compare(projection.Member, "UserId", true) == 0) lst.Add(Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"]);
						if (string.Compare(projection.Member, "InvitationLink", true) == 0) lst.Add(Convert.IsDBNull(row["InvitationLink"]) ? null : (string)row["InvitationLink"]);
						if (string.Compare(projection.Member, "Downloads", true) == 0) lst.Add(Convert.IsDBNull(row["Downloads"]) ? (Int32?)null : (Int32?)row["Downloads"]);
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
		///This method returns all data rows in the table using criteriaquery api AppUser_Invitation
		///</Summary>
		///<returns>
		///IList-DAOAppUserInvitation.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOAppUserInvitation> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUser_Invitation_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("AppUser_Invitation");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOAppUserInvitation> objList = new List<DAOAppUserInvitation>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOAppUserInvitation retObj = new DAOAppUserInvitation();
						retObj._invitationId					 = Convert.IsDBNull(row["InvitationId"]) ? (Int64?)null : (Int64?)row["InvitationId"];
						retObj._userId					 = Convert.IsDBNull(row["UserId"]) ? (Int32?)null : (Int32?)row["UserId"];
						retObj._invitationLink					 = Convert.IsDBNull(row["InvitationLink"]) ? null : (string)row["InvitationLink"];
						retObj._downloads					 = Convert.IsDBNull(row["Downloads"]) ? (Int32?)null : (Int32?)row["Downloads"];
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
		///This method returns all data rows in the table using criteriaquery api AppUser_Invitation
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprAppUser_Invitation_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table AppUser_Invitation based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprAppUser_Invitation_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@InvitationId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, false, 19, 0, "", DataRowVersion.Proposed, (object)_invitationId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@UserId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_userId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@InvitationLink", SqlDbType.NVarChar, 500, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_invitationLink?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@Downloads", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_downloads?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_invitationId					 = Convert.IsDBNull(command.Parameters["@InvitationId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@InvitationId"].Value;
				_userId					 = Convert.IsDBNull(command.Parameters["@UserId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@UserId"].Value;
				_invitationLink					 = Convert.IsDBNull(command.Parameters["@InvitationLink"].Value) ? null : (string)command.Parameters["@InvitationLink"].Value;
				_downloads					 = Convert.IsDBNull(command.Parameters["@Downloads"].Value) ? (Int32?)null : (Int32?)command.Parameters["@Downloads"].Value;

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

		public Int64? InvitationId
		{
			get
			{
				return _invitationId;
			}
			set
			{
				_invitationId = value;
			}
		}

		public Int32? UserId
		{
			get
			{
				return _userId;
			}
			set
			{
				_userId = value;
			}
		}

		public string InvitationLink
		{
			get
			{
				return _invitationLink;
			}
			set
			{
				_invitationLink = value;
			}
		}

		public Int32? Downloads
		{
			get
			{
				return _downloads;
			}
			set
			{
				_downloads = value;
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
		internal static string ctprAppUser_Invitation_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[InvitationId]
			,[UserId]
			,[InvitationLink]
			,[Downloads]
			FROM [dbo].[AppUser_Invitation]
			WHERE 
			[InvitationId] = @InvitationId
			";

		internal static string ctprAppUser_Invitation_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[AppUser_Invitation]
			WHERE 
			[InvitationId] = @InvitationId
			";

		internal static string ctprAppUser_Invitation_SelectAllByUserId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[InvitationId]
			,[UserId]
			,[InvitationLink]
			,[Downloads]
			FROM [dbo].[AppUser_Invitation]
			WHERE 
			[UserId] = @UserId OR ([UserId] IS NULL AND @UserId IS NULL)
			";

		internal static string ctprAppUser_Invitation_SelectAllByUserIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[AppUser_Invitation]
			WHERE 
			[UserId] = @UserId OR ([UserId] IS NULL AND @UserId IS NULL)
			";

		internal static string ctprAppUser_Invitation_DeleteAllByUserId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[AppUser_Invitation]
			WHERE 
			[UserId] = @UserId OR ([UserId] IS NULL AND @UserId IS NULL)
			";

		internal static string ctprAppUser_Invitation_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[AppUser_Invitation]
			(
			[UserId]
			,[InvitationLink]
			,[Downloads]
			)
			VALUES
			(
			@UserId
			,@InvitationLink
			,@Downloads
			)
			SELECT 
			@InvitationId = [InvitationId]
			,@UserId = [UserId]
			,@InvitationLink = [InvitationLink]
			,@Downloads = [Downloads]
			FROM [dbo].[AppUser_Invitation]
			WHERE 
			[InvitationId] = SCOPE_IDENTITY()
			";

		internal static string ctprAppUser_Invitation_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[InvitationId]
			,[UserId]
			,[InvitationLink]
			,[Downloads]
			FROM [dbo].[AppUser_Invitation]
			";

		internal static string ctprAppUser_Invitation_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[AppUser_Invitation]
			";

		internal static string ctprAppUser_Invitation_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[AppUser_Invitation]
			##CRITERIA##
			";

		internal static string ctprAppUser_Invitation_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[InvitationId]
			,[UserId]
			,[InvitationLink]
			,[Downloads]
			FROM [dbo].[AppUser_Invitation]
			##CRITERIA##
			";

		internal static string ctprAppUser_Invitation_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[AppUser_Invitation]
			##CRITERIA##
			";

		internal static string ctprAppUser_Invitation_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[AppUser_Invitation]
			SET
			[UserId] = @UserId
			,[InvitationLink] = @InvitationLink
			,[Downloads] = @Downloads
			WHERE 
			[InvitationId] = @InvitationId
			SELECT 
			@InvitationId = [InvitationId]
			,@UserId = [UserId]
			,@InvitationLink = [InvitationLink]
			,@Downloads = [Downloads]
			FROM [dbo].[AppUser_Invitation]
			WHERE 
			[InvitationId] = @InvitationId
			";

	}
}
#endregion
