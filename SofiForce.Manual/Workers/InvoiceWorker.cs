
using SFFService.Services;
using System.Data;
using System.Data.SqlClient;

namespace SFFService
{
    /// <summary>
    /// not exist in published code 
    /// </summary>
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
            try
            {
                _logger.LogInformation("Invoice {error}: {time}", "Connections Done", DateTimeOffset.Now);
            }
            catch (Exception ex)
            {
                _logger.LogError("Invoice {error}: {time}", ex.Message, DateTimeOffset.Now);
            }
            await base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {



                    InvoiceMigrator invoiceMigrator = new InvoiceMigrator(_configuration);
                    var invoiceRes= invoiceMigrator.Migrate();

                    if (invoiceRes.IsCompleted == false)
                    {
                        _logger.LogError("Invoice {error}: {time}", invoiceRes.Message, DateTimeOffset.Now);
                        continue;

                    }

                }
                catch (Exception ex)
                {

                    _logger.LogError("Invoice {error}: {time}", ex.Message, DateTimeOffset.Now);

                }


                await Task.Delay(1000, stoppingToken);
            }
        }
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Invoice Stoped at: {time}", DateTimeOffset.Now);
            await base.StopAsync(cancellationToken);
        }
    }
}