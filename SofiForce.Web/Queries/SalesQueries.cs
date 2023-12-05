namespace SofiForce.Web.Queries
{
    public class SalesQueries
    {
        public static string Query_GetInvoiceHeader = @"SELECT        
SELECT        
Branch.BranchCode as BranchCode, 
Store.StoreCode as StoreCode,  
Client.ClientCode as ClientCode, 
Client.ClientNameAr as ClientName, 
SalesOrder.InvoiceDate as InvoiceDate, 
SalesOrder.InvoiceCode as InvoiceCode, 
SalesOrder.SalesCode as SalesCode,
SalesOrder.NetTotal as NetTotal, 
SalesOrder.TaxTotal as TaxTotal, 
SalesOrder.CashDiscountTotal as CashDiscountTotal, 
SalesOrder.ItemDiscountTotal as ItemDiscountTotal, 
SalesOrder.OpenValue as OpenValue

FROM            SalesOrder LEFT OUTER JOIN
                         Client ON SalesOrder.ClientId = Client.ClientId LEFT OUTER JOIN
                         Branch ON SalesOrder.BranchId = Branch.BranchId LEFT OUTER JOIN
                         Store ON SalesOrder.StoreId = Store.StoreId
where cast(SalesOrder.InvoiceDate as date)>=@FromDate and cast(SalesOrder.InvoiceDate as date)<=@ToDate

";

    }
}
