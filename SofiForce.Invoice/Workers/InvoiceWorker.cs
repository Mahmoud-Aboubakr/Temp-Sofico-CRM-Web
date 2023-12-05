
using SFFService.Services;
using System.Data;
using System.Data.SqlClient;

namespace SFFService
{
    public class InvoiceWorker : BackgroundService
    {
        private readonly ILogger<InvoiceWorker> _logger;
        private readonly IConfiguration _configuration;



        public InvoiceWorker(ILogger<InvoiceWorker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration= configuration;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Invoice Start at: {time}", DateTimeOffset.Now);
            await base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    InvoiceMigrator invoiceMigrator = new InvoiceMigrator(_configuration);
                    var InvoiceRes = invoiceMigrator.Migrate();
                    if (InvoiceRes.IsCompleted == false)
                    {
                        _logger.LogError("InvoiceMigrator {error}: {time}", InvoiceRes.Message, DateTimeOffset.Now);
                        continue;
                    }
                    _logger.LogInformation("Invoice Worker Done: {time}",  DateTimeOffset.Now);

                }
                catch (Exception ex)
                {

                    _logger.LogError("{error}: {time}",ex.Message, DateTimeOffset.Now);

                }
               

                await Task.Delay(10*60*1000, stoppingToken);
            }
        }
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker Stoped at: {time}", DateTimeOffset.Now);
            await base.StopAsync(cancellationToken);
        }
    }
}