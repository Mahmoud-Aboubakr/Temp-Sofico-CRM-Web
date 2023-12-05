using Dapper;
using System.Data;



namespace SofiForce.Worker
{
    public class SalesOrderManager : ISalesOrderManager
    {

        private readonly DapperContext _context;
        public SalesOrderManager(DapperContext context)
        {
            _context = context;
        }

        public int UpdateOnhand(double SalesId)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {

                    var param = new
                    {
                        @SalesId = SalesId
                    };

                    return connection.Execute("Batch_Warehouse_updateAvaliabe", param, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
