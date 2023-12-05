using Dapper;
using SofiForce.Web.Dapper.Interface;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace SofiForce.Web.Dapper.Implementation
{
    public class OperationRequestManager : IOperationRequestManager
    {

        private readonly DapperContext _context;
        public OperationRequestManager(DapperContext context)
        {
            _context = context;
        }


        public void CreateValidationClients(int UserId,int OperationId, List<string> clients)
        {
            using (var connection = _context.CreateConnection())
            {
                var chunks = clients.Chunk<string>(100);
                foreach (var c in chunks)
                {
                    var ClientCodes = string.Join(',',c);

                    var param = new
                    {
                        @ClientCodes = ClientCodes,
                        @UserId = UserId,
                        @OperationId = OperationId,
                    };

                    var Res = connection.Query("Batch_OperationRequest_Clients", param , commandType: CommandType.StoredProcedure);

                }
            }
        }

        public void CreateValidationClient(int UserId, int OperationId, int ClientId)
        {
            using (var connection = _context.CreateConnection())
            {

                var param = new
                {
                    @ClientId = ClientId,
                    @UserId = UserId,
                    @OperationId = OperationId,
                };

                var Res = connection.Query("Batch_OperationRequest_Client", param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
