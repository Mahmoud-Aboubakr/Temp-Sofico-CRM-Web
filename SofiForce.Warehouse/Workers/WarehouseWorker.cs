
using SFFService.Services;
using System.Data;
using System.Data.SqlClient;

namespace SFFService
{
    public class WarehouseWorker : BackgroundService
    {
        private readonly ILogger<WarehouseWorker> _logger;
        private readonly IConfiguration _configuration;



        public WarehouseWorker(ILogger<WarehouseWorker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration= configuration;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Invoice Start at: {time}", DateTimeOffset.Now);
            try
            {
                _logger.LogInformation("{error}: {time}", "Connections Done", DateTimeOffset.Now);
            }
            catch (Exception ex)
            {
                _logger.LogError("{error}: {time}", ex.Message, DateTimeOffset.Now);
            }
            await base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {

                  

                    StoreItemMigrator storeItemMigrator = new StoreItemMigrator(_configuration);
                    var storeItemRes= storeItemMigrator.Migrate();

                    if (storeItemRes.IsCompleted == false)
                    {
                        _logger.LogError("StoreItemMigrator {error}: {time}", storeItemRes.Message, DateTimeOffset.Now);
                        continue;

                    }

                    _logger.LogInformation("Warehouse Worker Done: {time}",  DateTimeOffset.Now);

                }
                catch (Exception ex)
                {

                    _logger.LogError("StoreItemMigrator {error}: {time}", ex.Message, DateTimeOffset.Now);
                 
                }

        
                await Task.Delay(15*60*1000, stoppingToken);
            }
        }
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker Stoped at: {time}", DateTimeOffset.Now);
            await base.StopAsync(cancellationToken);
        }
    }
}
