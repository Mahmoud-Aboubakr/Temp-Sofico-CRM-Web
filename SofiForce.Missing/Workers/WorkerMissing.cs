
using SFFService.Services;
using SofiForce.BusinessObjects;
using System.Data;
using System.Data.SqlClient;


namespace SofiForce.Worker
{
    public class WorkerMissing : BackgroundService
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;



        public WorkerMissing(ILogger<WorkerMissing> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration= configuration;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker Missing Start at: {time}", DateTimeOffset.Now);
            await base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    








                    var orders=new Criteria<BOSalesOrder>()
                        .Add(Expression.Eq(nameof(BOSalesOrder.IsDeleted), true))
                        .List<BOSalesOrder>();

                    foreach (var order in orders)
                    {
                        if (order != null)
                        {

                            

                            InvoiceMigrator invoiceMigrator = new InvoiceMigrator(_configuration);
                            var InvoiceRes = invoiceMigrator.Migrate(order.SalesId.Value);
                            if (InvoiceRes.IsCompleted == false)
                            {
                                _logger.LogError("Worker Missing {error}: {time}", InvoiceRes.Message, DateTimeOffset.Now);
                                continue;
                            }
                            
                        };


                    }

                }
                catch (Exception ex)
                {

                    _logger.LogError("Worker Missing {error}: {time}",ex.Message, DateTimeOffset.Now);

                }

                await Task.Delay( 1 * 1000, stoppingToken);
            }
        }
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            /// _logger.LogInformation("Worker No Code Missing Stoped at: {time}", DateTimeOffset.Now);
            _logger.LogInformation("Worker1 Stoped at: {time}", DateTimeOffset.Now);
            await base.StopAsync(cancellationToken);
        }
    }
}