
using System.Data;
using System.Data.SqlClient;

namespace SFFService.Services
{
    public class StoreItemMigrator
    {
        private readonly IConfiguration _configuration;

        private SqlConnection _AXConnection;
        private SqlConnection _RemoteConnection;
        private SqlConnection _TempConnection;

        private SqlCommand _AXCommand;
        private SqlCommand _RemoteCommand;
        private SqlCommand _TempCommand;

        private SqlDataAdapter _RemoteAdapter;
        private SqlDataAdapter _AXAdapter;
        private SqlDataAdapter _TempAdapter;

        private SqlBulkCopy _SqlBulkCopy;


        public static string SP_LocationItem = @"
           SELECT 
            ID.INVENTSITEID AS BRANCHCODE,
            ID.INVENTLOCATIONID AS STORECODE,
            IV.ITEMID AS ItemCode,   
            IV.PRIMARYVENDORID AS VENDORCODE,
            (PostedQty + Received - Deducted + Registered - Picked) - ReservPhysical AS 'SUMQTY',
            IB.EXPDATE AS EXPDATE ,
            ISNULL( IB.INVENTBATCHID ,'') AS Batch,
            0 AS Holded
         -----------------------------------------------------------------------------------------------------------------------------------------
        from 
            [SOF-SRV-DB12].[SofDynAXLive].dbo.INVENTSUM          AS IM  INNER JOIN 
            [SOF-SRV-DB12].[SofDynAXLive].dbo.INVENTTABLEMODULE  AS ITM ON ITM.ITEMID=IM.ITEMID AND ITM.DATAAREAID=IM.DATAAREAID INNER JOIN
            [SOF-SRV-DB12].[SofDynAXLive].dbo.INVENTTABLE        AS IV  ON IV.ITEMID=ITM.ITEMID AND IV.DATAAREAID=ITM.DATAAREAID inner join
            [SOF-SRV-DB12].[SofDynAXLive].dbo.VENDTABLE          AS V   ON V.ACCOUNTNUM=IV.PRIMARYVENDORID AND V.DATAAREAID=IV.DATAAREAID INNER JOIN
            [SOF-SRV-DB12].[SofDynAXLive].dbo.INVENTDIM          AS ID  ON  IM.INVENTDIMID=ID.INVENTDIMID AND IM.DATAAREAID=ID.DATAAREAID INNER JOIN
            [SOF-SRV-DB12].[SofDynAXLive].dbo.INVENTLOCATION     AS IL  ON ID.INVENTLOCATIONID=IL.INVENTLOCATIONID  AND ID.DATAAREAID=IL.DATAAREAID  LEFT OUTER JOIN
            [SOF-SRV-DB12].[SofDynAXLive].dbo.INVENTBATCH        AS IB  ON IB.INVENTBATCHID=ID.INVENTBATCHID and IB.DATAAREAID=ID.DATAAREAID and IB.ITEMID=IM.ITEMID
             WHERE IL.DATAAREAID='SFC'
            --and ID.INVENTLOCATIONID='CAI-V-TS01'
			--and IV.ItemId='18300501'
            --and IM.MODIFIEDDATETIME > DATEADD(day,-1,getdate())
        GROUP BY 
               ID.INVENTSITEID,
               ID.INVENTLOCATIONID, 
               IV.PRIMARYVENDORID,
               IV.ITEMID,
               IB.EXPDATE,
               IB.INVENTBATCHID,
			   IM.PostedQty,
			   IM.Received,
			   IM.Deducted,
			   IM.Registered,
			   IM.Picked,
			   IM.ReservPhysical
        ";



        public StoreItemMigrator( IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Migrate()
        {
            try
            {
                _AXConnection = new SqlConnection(_configuration["AxConnection"]);
                _RemoteConnection = new SqlConnection(_configuration["RemoteConnection"]);
                _TempConnection = new SqlConnection(_configuration["TempConnection"]);

                _SqlBulkCopy = new SqlBulkCopy(_configuration["TempConnection"]);

                _RemoteConnection.Open();
                _AXConnection.Open();
                _TempConnection.Open();

                _AXCommand = new SqlCommand();
                _RemoteCommand = new SqlCommand();
                _TempCommand = new SqlCommand();

                _AXCommand.CommandTimeout = 5000;
                _RemoteCommand.CommandTimeout = 5000;
                _TempCommand.CommandTimeout = 5000;
                _SqlBulkCopy.BulkCopyTimeout = 5000;



                _AXCommand.Connection = _AXConnection;
                _RemoteCommand.Connection = _RemoteConnection;
                _TempCommand.Connection = _TempConnection;

                _AXAdapter = new SqlDataAdapter();
                _RemoteAdapter = new SqlDataAdapter();
                _TempAdapter = new SqlDataAdapter();


              



                _TempCommand.CommandType = CommandType.Text;
                _TempCommand.CommandText = "truncate table LocationItems";
                _TempCommand.ExecuteNonQuery();

                _AXCommand.CommandType = CommandType.Text;
                _AXCommand.CommandText = SP_LocationItem;
                DataTable dt = new DataTable();
                _AXAdapter.SelectCommand = _AXCommand;
                _AXAdapter.Fill(dt);


                // Migrrate Data
                _SqlBulkCopy.DestinationTableName = "LocationItems";

                _SqlBulkCopy.ColumnMappings.Add("BranchCode", "BranchCode");
                _SqlBulkCopy.ColumnMappings.Add("STORECODE", "STORECODE");
                _SqlBulkCopy.ColumnMappings.Add("ItemCode", "ItemCode");
                _SqlBulkCopy.ColumnMappings.Add("VendorCode", "VendorCode");
                _SqlBulkCopy.ColumnMappings.Add("SumQty", "SumQty");
                _SqlBulkCopy.ColumnMappings.Add("EXPDATE", "EXPDATE");
                _SqlBulkCopy.ColumnMappings.Add("Batch", "Batch");
                _SqlBulkCopy.ColumnMappings.Add("Holded", "Holded");



                _SqlBulkCopy.BatchSize = 5000;
                _SqlBulkCopy.WriteToServer(dt);


                _TempCommand.CommandType = CommandType.StoredProcedure;
                _TempCommand.CommandText = "Migrate_LocationItems";
                _TempCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _RemoteConnection.Close();
                _AXConnection.Close();
                _TempConnection.Close();

                _AXCommand.Dispose();
                _RemoteCommand.Dispose();
                _TempCommand.Dispose();

                _AXAdapter.Dispose();
                _RemoteAdapter.Dispose();
                _TempAdapter.Dispose();

                _SqlBulkCopy.Close();
            }

  
        }
    }
}
