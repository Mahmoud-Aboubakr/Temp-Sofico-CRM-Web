
using SFFService.Services;
using SofiForce.BusinessObjects;
using System.Data;
using System.Data.SqlClient;


namespace SofiForce.Worker
{
    public class WorkerNoCodeMissing : BackgroundService
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;



        public WorkerNoCodeMissing(ILogger<WorkerNoCodeMissing> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration= configuration;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker No Code Missing Start at: {time}", DateTimeOffset.Now);
            await base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    








                    var orders=new Criteria<BOSalesOrder>()
                        .Add(Expression.Eq(nameof(BOSalesOrder.SalesOrderStatusId), 4))
                        .Add(Expression.Null(nameof(BOSalesOrder.InvoiceCode)))
                        .List<BOSalesOrder>();

                    foreach (var order in orders)
                    {
                        if (order != null)
                        {

                            

                            InvoiceWithNoCodeMigrator invoiceMigrator = new InvoiceWithNoCodeMigrator(_configuration);
                            var InvoiceRes = invoiceMigrator.Migrate(order.SalesId.Value);
                            if (InvoiceRes.IsCompleted == false)
                            {
                                _logger.LogError("Worker  No Code Missing {error}: {time}", InvoiceRes.Message, DateTimeOffset.Now);
                                continue;
                            }
                            
                        };


                    }

                }
                catch (Exception ex)
                {

                    _logger.LogError("Worker  No Code Missing {error}: {time}", ex.Message, DateTimeOffset.Now);

                }

                await Task.Delay( 1 * 1000, stoppingToken);
            }
        }
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker  No Code Missing Stoped at: {time}", DateTimeOffset.Now);
            await base.StopAsync(cancellationToken);
        }
    }
}