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
	public partial class DAOOperationRequestDetailPreferredTime : zSofiForceConn_BaseData
	{
		#region member variables
		protected Int64? _preferredId;
		protected Int64? _detailId;
		protected Int32? _preferredOperationId;
		protected Int32? _weekDayId;
		protected TimeSpan? _fromTime;
		protected TimeSpan? _toTime;
		#endregion

		#region class methods
		public DAOOperationRequestDetailPreferredTime()
		{
		}
		///<Summary>
		///Select one row by primary key(s)
		///This method returns one row from the table OperationRequest_Detail_PreferredTime based on the primary key(s)
		///</Summary>
		///<returns>
		///DAOOperationRequestDetailPreferredTime
		///</returns>
		///<parameters>
		///Int64? preferredId
		///</parameters>
		public static DAOOperationRequestDetailPreferredTime SelectOne(Int64? preferredId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprOperationRequest_Detail_PreferredTime_SelectOne;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("OperationRequest_Detail_PreferredTime");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PreferredId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)preferredId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				DAOOperationRequestDetailPreferredTime retObj = null;
				if(dt.Rows.Count > 0)
				{
					retObj = new DAOOperationRequestDetailPreferredTime();
					retObj._preferredId					 = Convert.IsDBNull(dt.Rows[0]["PreferredId"]) ? (Int64?)null : (Int64?)dt.Rows[0]["PreferredId"];
					retObj._detailId					 = Convert.IsDBNull(dt.Rows[0]["DetailId"]) ? (Int64?)null : (Int64?)dt.Rows[0]["DetailId"];
					retObj._preferredOperationId					 = Convert.IsDBNull(dt.Rows[0]["PreferredOperationId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["PreferredOperationId"];
					retObj._weekDayId					 = Convert.IsDBNull(dt.Rows[0]["WeekDayId"]) ? (Int32?)null : (Int32?)dt.Rows[0]["WeekDayId"];
					retObj._fromTime					 = Convert.IsDBNull(dt.Rows[0]["FromTime"]) ? (TimeSpan?)null : (TimeSpan?)dt.Rows[0]["FromTime"];
					retObj._toTime					 = Convert.IsDBNull(dt.Rows[0]["ToTime"]) ? (TimeSpan?)null : (TimeSpan?)dt.Rows[0]["ToTime"];
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
		///this method allows the object to delete itself from the table OperationRequest_Detail_PreferredTime based on its primary key
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
			command.CommandText = InlineProcs.ctprOperationRequest_Detail_PreferredTime_DeleteOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PreferredId", SqlDbType.BigInt, 8, ParameterDirection.Input, false, 19, 0, "", DataRowVersion.Proposed, (object)_preferredId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table OperationRequest_Detail_PreferredTime based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOOperationRequestDetailPreferredTime.
		///</returns>
		///<parameters>
		///Int64? detailId
		///</parameters>
		public static IList<DAOOperationRequestDetailPreferredTime> SelectAllByDetailId(Int64? detailId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprOperationRequest_Detail_PreferredTime_SelectAllByDetailId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("OperationRequest_Detail_PreferredTime");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@DetailId", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)detailId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOOperationRequestDetailPreferredTime> objList = new List<DAOOperationRequestDetailPreferredTime>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOOperationRequestDetailPreferredTime retObj = new DAOOperationRequestDetailPreferredTime();
						retObj._preferredId					 = Convert.IsDBNull(row["PreferredId"]) ? (Int64?)null : (Int64?)row["PreferredId"];
						retObj._detailId					 = Convert.IsDBNull(row["DetailId"]) ? (Int64?)null : (Int64?)row["DetailId"];
						retObj._preferredOperationId					 = Convert.IsDBNull(row["PreferredOperationId"]) ? (Int32?)null : (Int32?)row["PreferredOperationId"];
						retObj._weekDayId					 = Convert.IsDBNull(row["WeekDayId"]) ? (Int32?)null : (Int32?)row["WeekDayId"];
						retObj._fromTime					 = Convert.IsDBNull(row["FromTime"]) ? (TimeSpan?)null : (TimeSpan?)row["FromTime"];
						retObj._toTime					 = Convert.IsDBNull(row["ToTime"]) ? (TimeSpan?)null : (TimeSpan?)row["ToTime"];
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
		///Int64? detailId
		///</parameters>
		public static Int32 SelectAllByDetailIdCount(Int64? detailId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprOperationRequest_Detail_PreferredTime_SelectAllByDetailIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@DetailId", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)detailId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table OperationRequest_Detail_PreferredTime with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int64? detailId
		///</parameters>
		public static void DeleteAllByDetailId(zSofiForceConn_TxConnectionProvider connectionProvider, Int64? detailId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprOperationRequest_Detail_PreferredTime_DeleteAllByDetailId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@DetailId", SqlDbType.BigInt, 8, ParameterDirection.Input, true, 19, 0, "", DataRowVersion.Proposed, (object)detailId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table OperationRequest_Detail_PreferredTime based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOOperationRequestDetailPreferredTime.
		///</returns>
		///<parameters>
		///Int32? preferredOperationId
		///</parameters>
		public static IList<DAOOperationRequestDetailPreferredTime> SelectAllByPreferredOperationId(Int32? preferredOperationId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprOperationRequest_Detail_PreferredTime_SelectAllByPreferredOperationId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("OperationRequest_Detail_PreferredTime");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PreferredOperationId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)preferredOperationId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOOperationRequestDetailPreferredTime> objList = new List<DAOOperationRequestDetailPreferredTime>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOOperationRequestDetailPreferredTime retObj = new DAOOperationRequestDetailPreferredTime();
						retObj._preferredId					 = Convert.IsDBNull(row["PreferredId"]) ? (Int64?)null : (Int64?)row["PreferredId"];
						retObj._detailId					 = Convert.IsDBNull(row["DetailId"]) ? (Int64?)null : (Int64?)row["DetailId"];
						retObj._preferredOperationId					 = Convert.IsDBNull(row["PreferredOperationId"]) ? (Int32?)null : (Int32?)row["PreferredOperationId"];
						retObj._weekDayId					 = Convert.IsDBNull(row["WeekDayId"]) ? (Int32?)null : (Int32?)row["WeekDayId"];
						retObj._fromTime					 = Convert.IsDBNull(row["FromTime"]) ? (TimeSpan?)null : (TimeSpan?)row["FromTime"];
						retObj._toTime					 = Convert.IsDBNull(row["ToTime"]) ? (TimeSpan?)null : (TimeSpan?)row["ToTime"];
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
		///Int32? preferredOperationId
		///</parameters>
		public static Int32 SelectAllByPreferredOperationIdCount(Int32? preferredOperationId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprOperationRequest_Detail_PreferredTime_SelectAllByPreferredOperationIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PreferredOperationId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)preferredOperationId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table OperationRequest_Detail_PreferredTime with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? preferredOperationId
		///</parameters>
		public static void DeleteAllByPreferredOperationId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? preferredOperationId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprOperationRequest_Detail_PreferredTime_DeleteAllByPreferredOperationId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PreferredOperationId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)preferredOperationId?? (object)DBNull.Value));

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
		///This method returns all data rows in the table OperationRequest_Detail_PreferredTime based on a foreign key
		///</Summary>
		///<returns>
		///IList-DAOOperationRequestDetailPreferredTime.
		///</returns>
		///<parameters>
		///Int32? weekDayId
		///</parameters>
		public static IList<DAOOperationRequestDetailPreferredTime> SelectAllByWeekDayId(Int32? weekDayId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprOperationRequest_Detail_PreferredTime_SelectAllByWeekDayId;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("OperationRequest_Detail_PreferredTime");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@WeekDayId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)weekDayId?? (object)DBNull.Value));

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOOperationRequestDetailPreferredTime> objList = new List<DAOOperationRequestDetailPreferredTime>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOOperationRequestDetailPreferredTime retObj = new DAOOperationRequestDetailPreferredTime();
						retObj._preferredId					 = Convert.IsDBNull(row["PreferredId"]) ? (Int64?)null : (Int64?)row["PreferredId"];
						retObj._detailId					 = Convert.IsDBNull(row["DetailId"]) ? (Int64?)null : (Int64?)row["DetailId"];
						retObj._preferredOperationId					 = Convert.IsDBNull(row["PreferredOperationId"]) ? (Int32?)null : (Int32?)row["PreferredOperationId"];
						retObj._weekDayId					 = Convert.IsDBNull(row["WeekDayId"]) ? (Int32?)null : (Int32?)row["WeekDayId"];
						retObj._fromTime					 = Convert.IsDBNull(row["FromTime"]) ? (TimeSpan?)null : (TimeSpan?)row["FromTime"];
						retObj._toTime					 = Convert.IsDBNull(row["ToTime"]) ? (TimeSpan?)null : (TimeSpan?)row["ToTime"];
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
		///Int32? weekDayId
		///</parameters>
		public static Int32 SelectAllByWeekDayIdCount(Int32? weekDayId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprOperationRequest_Detail_PreferredTime_SelectAllByWeekDayIdCount;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@WeekDayId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)weekDayId?? (object)DBNull.Value));

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
		///This method deletes all rows in the table OperationRequest_Detail_PreferredTime with a given foreign key
		///</Summary>
		///<returns>
		///void
		///</returns>
		///<parameters>
		///zSofiForceConn_TxConnectionProvider connectionProvider, Int32? weekDayId
		///</parameters>
		public static void DeleteAllByWeekDayId(zSofiForceConn_TxConnectionProvider connectionProvider, Int32? weekDayId)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprOperationRequest_Detail_PreferredTime_DeleteAllByWeekDayId;
			command.CommandType = CommandType.Text;
			command.Connection = connectionProvider.Connection;
			command.Transaction = connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@WeekDayId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, (object)weekDayId?? (object)DBNull.Value));

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
		///This method saves a new object to the table OperationRequest_Detail_PreferredTime
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
			command.CommandText = InlineProcs.ctprOperationRequest_Detail_PreferredTime_InsertOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PreferredId", SqlDbType.BigInt, 8, ParameterDirection.Output, false, 19, 0, "", DataRowVersion.Proposed, _preferredId));
				command.Parameters.Add(CtSqlParameter.Get("@DetailId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, true, 19, 0, "", DataRowVersion.Proposed, (object)_detailId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@PreferredOperationId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_preferredOperationId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@WeekDayId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_weekDayId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@FromTime", SqlDbType.Time, 5, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_fromTime?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ToTime", SqlDbType.Time, 5, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_toTime?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_preferredId					 = Convert.IsDBNull(command.Parameters["@PreferredId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@PreferredId"].Value;
				_detailId					 = Convert.IsDBNull(command.Parameters["@DetailId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@DetailId"].Value;
				_preferredOperationId					 = Convert.IsDBNull(command.Parameters["@PreferredOperationId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@PreferredOperationId"].Value;
				_weekDayId					 = Convert.IsDBNull(command.Parameters["@WeekDayId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@WeekDayId"].Value;
				_fromTime					 = Convert.IsDBNull(command.Parameters["@FromTime"].Value) ? (TimeSpan?)null : (TimeSpan?)command.Parameters["@FromTime"].Value;
				_toTime					 = Convert.IsDBNull(command.Parameters["@ToTime"].Value) ? (TimeSpan?)null : (TimeSpan?)command.Parameters["@ToTime"].Value;

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
		///This method returns all data rows in the table OperationRequest_Detail_PreferredTime
		///</Summary>
		///<returns>
		///IList-DAOOperationRequestDetailPreferredTime.
		///</returns>
		///<parameters>
		///
		///</parameters>
		public static IList<DAOOperationRequestDetailPreferredTime> SelectAll()
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = InlineProcs.ctprOperationRequest_Detail_PreferredTime_SelectAll;
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("OperationRequest_Detail_PreferredTime");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOOperationRequestDetailPreferredTime> objList = new List<DAOOperationRequestDetailPreferredTime>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOOperationRequestDetailPreferredTime retObj = new DAOOperationRequestDetailPreferredTime();
						retObj._preferredId					 = Convert.IsDBNull(row["PreferredId"]) ? (Int64?)null : (Int64?)row["PreferredId"];
						retObj._detailId					 = Convert.IsDBNull(row["DetailId"]) ? (Int64?)null : (Int64?)row["DetailId"];
						retObj._preferredOperationId					 = Convert.IsDBNull(row["PreferredOperationId"]) ? (Int32?)null : (Int32?)row["PreferredOperationId"];
						retObj._weekDayId					 = Convert.IsDBNull(row["WeekDayId"]) ? (Int32?)null : (Int32?)row["WeekDayId"];
						retObj._fromTime					 = Convert.IsDBNull(row["FromTime"]) ? (TimeSpan?)null : (TimeSpan?)row["FromTime"];
						retObj._toTime					 = Convert.IsDBNull(row["ToTime"]) ? (TimeSpan?)null : (TimeSpan?)row["ToTime"];
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
			command.CommandText = InlineProcs.ctprOperationRequest_Detail_PreferredTime_SelectAllCount;
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
		///This method returns specific fields of all data rows in the table using criteriaquery apiOperationRequest_Detail_PreferredTime
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprOperationRequest_Detail_PreferredTime_SelectAllByCriteriaProjection, listProjection, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("OperationRequest_Detail_PreferredTime");
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
						if (string.Compare(projection.Member, "PreferredId", true) == 0) lst.Add(Convert.IsDBNull(row["PreferredId"]) ? (Int64?)null : (Int64?)row["PreferredId"]);
						if (string.Compare(projection.Member, "DetailId", true) == 0) lst.Add(Convert.IsDBNull(row["DetailId"]) ? (Int64?)null : (Int64?)row["DetailId"]);
						if (string.Compare(projection.Member, "PreferredOperationId", true) == 0) lst.Add(Convert.IsDBNull(row["PreferredOperationId"]) ? (Int32?)null : (Int32?)row["PreferredOperationId"]);
						if (string.Compare(projection.Member, "WeekDayId", true) == 0) lst.Add(Convert.IsDBNull(row["WeekDayId"]) ? (Int32?)null : (Int32?)row["WeekDayId"]);
						if (string.Compare(projection.Member, "FromTime", true) == 0) lst.Add(Convert.IsDBNull(row["FromTime"]) ? (TimeSpan?)null : (TimeSpan?)row["FromTime"]);
						if (string.Compare(projection.Member, "ToTime", true) == 0) lst.Add(Convert.IsDBNull(row["ToTime"]) ? (TimeSpan?)null : (TimeSpan?)row["ToTime"]);
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
		///This method returns all data rows in the table using criteriaquery api OperationRequest_Detail_PreferredTime
		///</Summary>
		///<returns>
		///IList-DAOOperationRequestDetailPreferredTime.
		///</returns>
		///<parameters>
		///IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake
		///</parameters>
		public static IList<DAOOperationRequestDetailPreferredTime> SelectAllByCriteria(IList<IDataCriterion> listCriterion, IList<IDataOrderBy> listOrder, IDataSkip dataSkip, IDataTake dataTake)
		{
			SqlCommand	command = new SqlCommand();
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprOperationRequest_Detail_PreferredTime_SelectAllByCriteria, null, listCriterion, listOrder, dataSkip, dataTake);
			command.CommandType = CommandType.Text;
			SqlConnection staticConnection = StaticSqlConnection;
			command.Connection = staticConnection;

			DataTable dt = new DataTable("OperationRequest_Detail_PreferredTime");
			SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);
			try
			{

				staticConnection.Open();
				sqlAdapter.Fill(dt);

				List<DAOOperationRequestDetailPreferredTime> objList = new List<DAOOperationRequestDetailPreferredTime>();
				if(dt.Rows.Count > 0)
				{
					foreach(DataRow row in dt.Rows)
					{
						DAOOperationRequestDetailPreferredTime retObj = new DAOOperationRequestDetailPreferredTime();
						retObj._preferredId					 = Convert.IsDBNull(row["PreferredId"]) ? (Int64?)null : (Int64?)row["PreferredId"];
						retObj._detailId					 = Convert.IsDBNull(row["DetailId"]) ? (Int64?)null : (Int64?)row["DetailId"];
						retObj._preferredOperationId					 = Convert.IsDBNull(row["PreferredOperationId"]) ? (Int32?)null : (Int32?)row["PreferredOperationId"];
						retObj._weekDayId					 = Convert.IsDBNull(row["WeekDayId"]) ? (Int32?)null : (Int32?)row["WeekDayId"];
						retObj._fromTime					 = Convert.IsDBNull(row["FromTime"]) ? (TimeSpan?)null : (TimeSpan?)row["FromTime"];
						retObj._toTime					 = Convert.IsDBNull(row["ToTime"]) ? (TimeSpan?)null : (TimeSpan?)row["ToTime"];
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
		///This method returns all data rows in the table using criteriaquery api OperationRequest_Detail_PreferredTime
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
			command.CommandText = GetSelectionCriteria(InlineProcs.ctprOperationRequest_Detail_PreferredTime_SelectAllByCriteriaCount, null, listCriterion, null);
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
		///This method allows the object to update itself in the table OperationRequest_Detail_PreferredTime based on its primary key(s)
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
			command.CommandText = InlineProcs.ctprOperationRequest_Detail_PreferredTime_UpdateOne;
			command.CommandType = CommandType.Text;
			command.Connection = _connectionProvider.Connection;
			command.Transaction = _connectionProvider.CurrentTransaction;

			try
			{
				command.Parameters.Add(CtSqlParameter.Get("@PreferredId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, false, 19, 0, "", DataRowVersion.Proposed, (object)_preferredId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@DetailId", SqlDbType.BigInt, 8, ParameterDirection.InputOutput, true, 19, 0, "", DataRowVersion.Proposed, (object)_detailId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@PreferredOperationId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_preferredOperationId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@WeekDayId", SqlDbType.Int, 4, ParameterDirection.InputOutput, true, 10, 0, "", DataRowVersion.Proposed, (object)_weekDayId?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@FromTime", SqlDbType.Time, 5, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_fromTime?? (object)DBNull.Value));
				command.Parameters.Add(CtSqlParameter.Get("@ToTime", SqlDbType.Time, 5, ParameterDirection.InputOutput, true, 0, 0, "", DataRowVersion.Proposed, (object)_toTime?? (object)DBNull.Value));

				command.ExecuteNonQuery();

				_preferredId					 = Convert.IsDBNull(command.Parameters["@PreferredId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@PreferredId"].Value;
				_detailId					 = Convert.IsDBNull(command.Parameters["@DetailId"].Value) ? (Int64?)null : (Int64?)command.Parameters["@DetailId"].Value;
				_preferredOperationId					 = Convert.IsDBNull(command.Parameters["@PreferredOperationId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@PreferredOperationId"].Value;
				_weekDayId					 = Convert.IsDBNull(command.Parameters["@WeekDayId"].Value) ? (Int32?)null : (Int32?)command.Parameters["@WeekDayId"].Value;
				_fromTime					 = Convert.IsDBNull(command.Parameters["@FromTime"].Value) ? (TimeSpan?)null : (TimeSpan?)command.Parameters["@FromTime"].Value;
				_toTime					 = Convert.IsDBNull(command.Parameters["@ToTime"].Value) ? (TimeSpan?)null : (TimeSpan?)command.Parameters["@ToTime"].Value;

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

		public Int64? PreferredId
		{
			get
			{
				return _preferredId;
			}
			set
			{
				_preferredId = value;
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

		public Int32? PreferredOperationId
		{
			get
			{
				return _preferredOperationId;
			}
			set
			{
				_preferredOperationId = value;
			}
		}

		public Int32? WeekDayId
		{
			get
			{
				return _weekDayId;
			}
			set
			{
				_weekDayId = value;
			}
		}

		public TimeSpan? FromTime
		{
			get
			{
				return _fromTime;
			}
			set
			{
				_fromTime = value;
			}
		}

		public TimeSpan? ToTime
		{
			get
			{
				return _toTime;
			}
			set
			{
				_toTime = value;
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
		internal static string ctprOperationRequest_Detail_PreferredTime_SelectOne = @"
			-- Select one row based on the primary key(s)
			-- selects all rows from the table
			SELECT 
			[PreferredId]
			,[DetailId]
			,[PreferredOperationId]
			,[WeekDayId]
			,[FromTime]
			,[ToTime]
			FROM [dbo].[OperationRequest_Detail_PreferredTime]
			WHERE 
			[PreferredId] = @PreferredId
			";

		internal static string ctprOperationRequest_Detail_PreferredTime_DeleteOne = @"
			-- Delete a row based on the primary key(s)
			-- delete all matching from the table
			DELETE [dbo].[OperationRequest_Detail_PreferredTime]
			WHERE 
			[PreferredId] = @PreferredId
			";

		internal static string ctprOperationRequest_Detail_PreferredTime_SelectAllByDetailId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[PreferredId]
			,[DetailId]
			,[PreferredOperationId]
			,[WeekDayId]
			,[FromTime]
			,[ToTime]
			FROM [dbo].[OperationRequest_Detail_PreferredTime]
			WHERE 
			[DetailId] = @DetailId OR ([DetailId] IS NULL AND @DetailId IS NULL)
			";

		internal static string ctprOperationRequest_Detail_PreferredTime_SelectAllByDetailIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[OperationRequest_Detail_PreferredTime]
			WHERE 
			[DetailId] = @DetailId OR ([DetailId] IS NULL AND @DetailId IS NULL)
			";

		internal static string ctprOperationRequest_Detail_PreferredTime_DeleteAllByDetailId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[OperationRequest_Detail_PreferredTime]
			WHERE 
			[DetailId] = @DetailId OR ([DetailId] IS NULL AND @DetailId IS NULL)
			";

		internal static string ctprOperationRequest_Detail_PreferredTime_SelectAllByPreferredOperationId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[PreferredId]
			,[DetailId]
			,[PreferredOperationId]
			,[WeekDayId]
			,[FromTime]
			,[ToTime]
			FROM [dbo].[OperationRequest_Detail_PreferredTime]
			WHERE 
			[PreferredOperationId] = @PreferredOperationId OR ([PreferredOperationId] IS NULL AND @PreferredOperationId IS NULL)
			";

		internal static string ctprOperationRequest_Detail_PreferredTime_SelectAllByPreferredOperationIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[OperationRequest_Detail_PreferredTime]
			WHERE 
			[PreferredOperationId] = @PreferredOperationId OR ([PreferredOperationId] IS NULL AND @PreferredOperationId IS NULL)
			";

		internal static string ctprOperationRequest_Detail_PreferredTime_DeleteAllByPreferredOperationId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[OperationRequest_Detail_PreferredTime]
			WHERE 
			[PreferredOperationId] = @PreferredOperationId OR ([PreferredOperationId] IS NULL AND @PreferredOperationId IS NULL)
			";

		internal static string ctprOperationRequest_Detail_PreferredTime_SelectAllByWeekDayId = @"
			-- Select all rows based on a foreign key
			-- selects all rows from the table
			SELECT 
			[PreferredId]
			,[DetailId]
			,[PreferredOperationId]
			,[WeekDayId]
			,[FromTime]
			,[ToTime]
			FROM [dbo].[OperationRequest_Detail_PreferredTime]
			WHERE 
			[WeekDayId] = @WeekDayId OR ([WeekDayId] IS NULL AND @WeekDayId IS NULL)
			";

		internal static string ctprOperationRequest_Detail_PreferredTime_SelectAllByWeekDayIdCount = @"
			-- Get count of rows returnable by this query
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[OperationRequest_Detail_PreferredTime]
			WHERE 
			[WeekDayId] = @WeekDayId OR ([WeekDayId] IS NULL AND @WeekDayId IS NULL)
			";

		internal static string ctprOperationRequest_Detail_PreferredTime_DeleteAllByWeekDayId = @"
			
			-- delete all matching from the table
			DELETE [dbo].[OperationRequest_Detail_PreferredTime]
			WHERE 
			[WeekDayId] = @WeekDayId OR ([WeekDayId] IS NULL AND @WeekDayId IS NULL)
			";

		internal static string ctprOperationRequest_Detail_PreferredTime_InsertOne = @"
			-- Insert a new row
			-- inserts a new row into the table
			INSERT [dbo].[OperationRequest_Detail_PreferredTime]
			(
			[DetailId]
			,[PreferredOperationId]
			,[WeekDayId]
			,[FromTime]
			,[ToTime]
			)
			VALUES
			(
			@DetailId
			,@PreferredOperationId
			,@WeekDayId
			,@FromTime
			,@ToTime
			)
			SELECT 
			@PreferredId = [PreferredId]
			,@DetailId = [DetailId]
			,@PreferredOperationId = [PreferredOperationId]
			,@WeekDayId = [WeekDayId]
			,@FromTime = [FromTime]
			,@ToTime = [ToTime]
			FROM [dbo].[OperationRequest_Detail_PreferredTime]
			WHERE 
			[PreferredId] = SCOPE_IDENTITY()
			";

		internal static string ctprOperationRequest_Detail_PreferredTime_SelectAll = @"
			-- Select All rows
			-- selects all rows from the table
			SELECT 
			[PreferredId]
			,[DetailId]
			,[PreferredOperationId]
			,[WeekDayId]
			,[FromTime]
			,[ToTime]
			FROM [dbo].[OperationRequest_Detail_PreferredTime]
			";

		internal static string ctprOperationRequest_Detail_PreferredTime_SelectAllCount = @"
			
			-- selects count of all rows from the table
			SELECT COUNT(*)
			FROM [dbo].[OperationRequest_Detail_PreferredTime]
			";

		internal static string ctprOperationRequest_Detail_PreferredTime_SelectAllByCriteriaProjection = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			##STARTFIELDS##
			##ENDFIELDS##
			FROM [dbo].[OperationRequest_Detail_PreferredTime]
			##CRITERIA##
			";

		internal static string ctprOperationRequest_Detail_PreferredTime_SelectAllByCriteria = @"
			
			-- selects all rows from the table by criteria
			SELECT 
			[PreferredId]
			,[DetailId]
			,[PreferredOperationId]
			,[WeekDayId]
			,[FromTime]
			,[ToTime]
			FROM [dbo].[OperationRequest_Detail_PreferredTime]
			##CRITERIA##
			";

		internal static string ctprOperationRequest_Detail_PreferredTime_SelectAllByCriteriaCount = @"
			
			-- selects count of all rows from the table according to criteria
			SELECT COUNT(*)
			FROM [dbo].[OperationRequest_Detail_PreferredTime]
			##CRITERIA##
			";

		internal static string ctprOperationRequest_Detail_PreferredTime_UpdateOne = @"
			-- Update one row based on the primary key(s)
			-- updates a row in the table based on the primary key
			
			UPDATE [dbo].[OperationRequest_Detail_PreferredTime]
			SET
			[DetailId] = @DetailId
			,[PreferredOperationId] = @PreferredOperationId
			,[WeekDayId] = @WeekDayId
			,[FromTime] = @FromTime
			,[ToTime] = @ToTime
			WHERE 
			[PreferredId] = @PreferredId
			SELECT 
			@PreferredId = [PreferredId]
			,@DetailId = [DetailId]
			,@PreferredOperationId = [PreferredOperationId]
			,@WeekDayId = [WeekDayId]
			,@FromTime = [FromTime]
			,@ToTime = [ToTime]
			FROM [dbo].[OperationRequest_Detail_PreferredTime]
			WHERE 
			[PreferredId] = @PreferredId
			";

	}
}
#endregion
