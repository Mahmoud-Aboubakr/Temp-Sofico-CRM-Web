
using Models;
using SofiForce.BusinessObjects;
using System.Data;
using System.Data.SqlClient;

namespace SFFService.Services
{
    public class InvoiceMigrator
    {
        private readonly IConfiguration _configuration;

        private SqlConnection _AXConnection;
        private SqlCommand _AXCommand;
        private SqlDataAdapter _AXAdapter;



        public static string SP_InvoiceHeader = @"

SELECT
   CJ.RECID             AS RecId,	
   CJ.INVOICEID         AS InvoiceCode,	
   dateadd(hour,2,CJ.CREATEDDATETIME)   as InvoiceDate,
CJ.INVOICEAMOUNT as NetValue


 FROM 
 [SOF-SRV-DB12].SofDynAXLive.dbo.CUSTINVOICEJOUR AS CJ  left join 
 [SOF-SRV-DB12].SofDynAXLive.dbo.SALESTABLE ST  ON CJ.SALESID=ST.SALESID  and CJ.DATAAREAID=ST.DATAAREAID  


 WHERE 
      CJ.DATAAREAID='SFC'
  AND ST.PurchOrderFormNum=@SalesCode

";
        public InvoiceMigrator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MigrationDTO Migrate(long SalesId)
        {
            MigrationDTO Res = new MigrationDTO();

            try
            {

                var Bo = new BOSalesOrder(SalesId);


                _AXConnection = new SqlConnection(_configuration["AxConnection"]);
                _AXConnection.Open();
                _AXCommand = new SqlCommand();
                _AXCommand.Connection = _AXConnection;
                _AXCommand.CommandTimeout = 5000;
                _AXAdapter = new SqlDataAdapter();


                if(Bo.SalesCode != null)
                {
                    _AXCommand.CommandType = CommandType.Text;
                    _AXCommand.CommandText = SP_InvoiceHeader;
                    DataTable dtHeader = new DataTable();
                    _AXCommand.Parameters.Add(new SqlParameter("@SalesCode", Bo.SalesCode));
                    _AXAdapter.SelectCommand = _AXCommand;
                    _AXAdapter.Fill(dtHeader);


                    if (dtHeader.Rows.Count > 0)
                    {

                        if (Bo.ItemTotal > 0)
                        {
                            var NetValue = decimal.Parse(dtHeader.Rows[0]["NetValue"].ToString());


                            var details = Bo.SalesOrderDetailCollection();
                            Bo.ItemTotal = details.Sum(a => a.Quantity * a.ClientPrice);
                            Bo.ItemDiscountTotal = details.Sum(a => a.Quantity * a.Discount);
                            Bo.CustomDiscountTotal = details.Sum(a => a.Quantity * a.CustomDiscount);
                            Bo.TaxTotal = details.Sum(a => a.Quantity * a.TaxValue);
                            Bo.DeliveryTotal = 0;
                            Bo.NetTotal = Bo.ItemTotal + Bo.TaxTotal - Bo.ItemDiscountTotal - Bo.CustomDiscountTotal - Bo.DeliveryTotal;

                            if (Math.Round(Bo.NetTotal.Value, 2) == Math.Round(NetValue, 2))
                            {
                                Bo.IsDeleted = false;
                                Bo.IsInvoiced = true;
                                Bo.HasError = false;
                                Bo.SalesOrderStatusId = 4;
                                Bo.InvoiceCode = dtHeader.Rows[0]["InvoiceCode"].ToString();
                                Bo.RecId = long.Parse(dtHeader.Rows[0]["RecId"].ToString());
                                Bo.InvoiceDate = DateTime.Parse(dtHeader.Rows[0]["InvoiceDate"].ToString());
                                Bo.CreateDate = DateTime.Parse(dtHeader.Rows[0]["InvoiceDate"].ToString());
                                Bo.Update();
                            }
                            else
                            {
                                Bo.Delete();
                            }

                        }
                        else
                        {
                            Bo.Delete();
                        }



                    }
                    else
                    {
                        Bo.Delete();
                    }

                }
                else
                {
                    Bo.Delete();
                }

            }
            catch (Exception ex)
            {
                Res.Message = ex.Message;
                Res.IsCompleted = false;
            }
            finally
            {

                _AXConnection.Close();
                _AXCommand.Dispose();
                _AXAdapter.Dispose();

            }
            return Res;
        }
    }
}
