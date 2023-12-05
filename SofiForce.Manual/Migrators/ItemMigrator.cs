
using SofiForce.Models;
using System.Data;
using System.Data.SqlClient;

namespace SFFService.Services
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
and I.ItemID in (@ItemCode)
ORDER BY I.ItemID

drop table #ClientPrice
drop table #PublicPrice
                        ";
        public ItemMigrator(IConfiguration configuration)
        {

            _configuration = configuration;
        }

        public MigrationDTO Migrate()
        {
            MigrationDTO Res = new MigrationDTO();

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


                // get param


                _RemoteCommand.CommandType = CommandType.Text;
                _RemoteCommand.CommandText = @"select top 10 DetailId, Payload1 as ItemCode  from SyncSetup_Detail where SetupId=5";

                var reader = _RemoteCommand.ExecuteReader();
                List<string> ItemCodeList = new List<string>();
                List<int> DetailIdList = new List<int>();

                while (reader.Read())
                {
                    if (reader["ItemCode"] != null && !string.IsNullOrEmpty(reader["ItemCode"].ToString()))
                    {
                        var existItemCode = ItemCodeList.Where(a => a.Equals(reader["ItemCode"].ToString())).FirstOrDefault();
                        if (existItemCode == null)
                        {
                            ItemCodeList.Add("'" + reader["ItemCode"].ToString() + "'");
                        }
                    }

                    if (reader["DetailId"] != null && !string.IsNullOrEmpty(reader["DetailId"].ToString()))
                    {
                        DetailIdList.Add(int.Parse(reader["DetailId"].ToString()));
                    }

                }

                // execute AX

                
                _TempCommand.CommandType = CommandType.Text;
                _TempCommand.CommandText = "truncate table Items";
                _TempCommand.ExecuteNonQuery();

                if (ItemCodeList.Count > 0)
                {

                    var ItemCodes = string.Join(',', ItemCodeList);

                    _AXCommand.CommandType = CommandType.Text;
                    _AXCommand.CommandText = SP_Item.Replace("@ItemCode", ItemCodes);
                    DataTable dt = new DataTable();
                    _AXAdapter.SelectCommand = _AXCommand;
                    _AXAdapter.Fill(dt);


                    // Migrate Data
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


                    var DetailId = string.Join(',', DetailIdList);
                    _TempCommand.CommandType = CommandType.StoredProcedure;
                    _TempCommand.CommandText = "Migrate_Items";
                    _TempCommand.Parameters.Add(new SqlParameter("DetailId", DetailId));
                    _TempCommand.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Res.Message = ex.Message;
                Res.IsCompleted = false;
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





            return Res;



        }
    }
}
