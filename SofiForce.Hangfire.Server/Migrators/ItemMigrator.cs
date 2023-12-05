
using System.Data;
using System.Data.SqlClient;

namespace SofiForce.Hangfire.Server
{
    public class ItemMigrator
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

        public static string SP_Item = @"



IF OBJECT_ID('tempdb..#ClientPrice', 'U') IS NOT NULL DROP TABLE #ClientPrice;
IF OBJECT_ID('tempdb..#PublicPrice', 'U') IS NOT NULL DROP TABLE #PublicPrice;


Create Table #ClientPrice
(
	ItemCode nvarchar(500) COLLATE DATABASE_DEFAULT,
	Price decimal(18,5)
)


;WITH cte AS (
  SELECT Amount as Price,P.ItemRelation as ItemCode, fromdate,
     row_number() OVER(PARTITION BY P.ItemRelation ORDER BY fromdate desc) AS [rn]
 
   FROM         [SOF-SRV-DB12].[SofDynAXLive].dbo.PriceDiscTable AS p
                           WHERE     (dataareaid = 'sfc') 
						   AND (accountrelation = '1') 



)
insert into #ClientPrice
select ItemCode,Price from cte 
where rn=1




Create Table #PublicPrice
(
	ItemCode nvarchar(500) COLLATE DATABASE_DEFAULT,
	Price decimal(18,5)
)


;WITH cteP AS (
  SELECT Amount as Price,P.ItemRelation as ItemCode, fromdate,
     row_number() OVER(PARTITION BY P.ItemRelation ORDER BY fromdate desc) AS [rn]
 
   FROM         [SOF-SRV-DB12].[SofDynAXLive].dbo.PriceDiscTable AS p
                           WHERE     (dataareaid = 'sfc') 
						   AND (accountrelation = 'PUB') 



)
insert into #PublicPrice
select ItemCode,Price from cteP 
where rn=1




SELECT    
                          
                           I.PRIMARYVENDORID as VendorId,
                           I.ItemID as ItemCode,
                           ltrim(rtrim((replace(EcoTransl.Name,',',' ')))) as ItemName,
                           isnull(#ClientPrice.Price,0) AS ClientPrice,

                          isnull(#PublicPrice.Price,0) AS PublicPrice,
                         
                          case when #PublicPrice.Price>0 then 100 - #ClientPrice.Price/#PublicPrice.Price else 0 end * 100 AS Discount 
                      ----------------------------------------------------------------------------------------------------------------------------
                          
                           , se.STOPPED
						   ,I.ItemBuyerGroupId as ItemGroupId
						   ,(select top 1 unitid from  [SOF-SRV-DB12].[SofDynAXLive].dbo.INVENTTABLEMODULE  as IM where IM.ModuleType =2 and IM.Itemid = I.itemId) as UnitId
						   ,(case when M.TaxItemGroupID = 'All' then 1 else 0 end) as TaxGroupId

                           
                                                       
FROM                        [SOF-SRV-DB12].[SofDynAXLive].dbo.InventTable AS I LEFT OUTER JOIN
                            (SELECT     ItemID, TaxItemGroupID
                             FROM         [SOF-SRV-DB12].[SofDynAXLive].dbo.InventTableModule
                             WHERE     (moduleType = 2) AND (DataAreaID = 'SFC'))        AS M ON I.ItemID = M.ItemID LEFT OUTER JOIN
							 [SOF-SRV-DB12].[SofDynAXLive].dbo.EcoResProductTranslation   as EcoTransl on I.PRODUCT = EcoTransl.PRODUCT LEFT OUTER JOIN
                             [SOF-SRV-DB12].[SofDynAXLive].dbo.VendTable                  AS V ON I.PrimaryVendorID = V.AccountNum AND I.DataAreaID = V.DataAreaID LEFT OUTER JOIN
                             [SOF-SRV-DB12].[SofDynAXLive].dbo.InventItemSalesSetup        as se on  se.ITEMID=I.ITEMID and se.DATAAREAID=I.DATAAREAID  left join 
							 #ClientPrice on #ClientPrice.ItemCode COLLATE DATABASE_DEFAULT=I.ItemID COLLATE DATABASE_DEFAULT left join 
							 #PublicPrice on #PublicPrice.ItemCode COLLATE DATABASE_DEFAULT=I.ItemID COLLATE DATABASE_DEFAULT
WHERE     I.DataAreaID = 'SFC'


ORDER BY I.ItemID



drop table #ClientPrice
drop table #PublicPrice
                        ";
        public ItemMigrator(IConfiguration configuration)
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


                // execute AX

                _TempCommand.CommandType = CommandType.Text;
                _TempCommand.CommandText = "truncate table Items";
                _TempCommand.ExecuteNonQuery();

                _AXCommand.CommandType = CommandType.Text;
                _AXCommand.CommandText = SP_Item;
                DataTable dt = new DataTable();
                _AXAdapter.SelectCommand = _AXCommand;
                _AXAdapter.Fill(dt);


                // Migrrate Data
                _SqlBulkCopy.DestinationTableName = "Items";

                _SqlBulkCopy.ColumnMappings.Add("VendorId", "VendorId");
                _SqlBulkCopy.ColumnMappings.Add("ItemCode", "ItemCode");
                _SqlBulkCopy.ColumnMappings.Add("ItemName", "ItemName");
                _SqlBulkCopy.ColumnMappings.Add("PublicPrice", "PublicPrice");
                _SqlBulkCopy.ColumnMappings.Add("ClientPrice", "ClientPrice");
                _SqlBulkCopy.ColumnMappings.Add("Discount", "Discount");
                _SqlBulkCopy.ColumnMappings.Add("STOPPED", "STOPPED");
                _SqlBulkCopy.ColumnMappings.Add("ItemGroupId", "ItemGroupId");
                _SqlBulkCopy.ColumnMappings.Add("UnitId", "UnitId");
                _SqlBulkCopy.ColumnMappings.Add("TaxGroupId", "TaxGroupId");


                _SqlBulkCopy.BatchSize = 5000;
                _SqlBulkCopy.WriteToServer(dt);


                _TempCommand.CommandType = CommandType.StoredProcedure;
                _TempCommand.CommandText = "Migrate_Items";
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
