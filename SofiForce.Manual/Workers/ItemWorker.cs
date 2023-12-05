
using SFFService.Services;
using System.Data;
using System.Data.SqlClient;

namespace SFFService
{
    public class ItemWorker : BackgroundService
    {
        private readonly ILogger<ItemWorker> _logger;
        private readonly IConfiguration _configuration;



        public ItemWorker(ILogger<ItemWorker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration= configuration;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Item Start at: {time}", DateTimeOffset.Now);
            try
            {
                _logger.LogInformation("Item {error}: {time}", "Connections Done", DateTimeOffset.Now);
            }
            catch (Exception ex)
            {
                _logger.LogError("Item {error}: {time}", ex.Message, DateTimeOffset.Now);
            }
            await base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {

                  

                    ItemMigrator itemMigrator = new ItemMigrator(_configuration);
                    var itemMigratorRes= itemMigrator.Migrate();

                    if (itemMigratorRes.IsCompleted == false)
                    {
                        _logger.LogError("Item {error}: {time}", itemMigratorRes.Message, DateTimeOffset.Now);
                        continue;

                    }

                }
                catch (Exception ex)
                {

                    _logger.LogError("Item {error}: {time}", ex.Message, DateTimeOffset.Now);

                }

                await Task.Delay(1000, stoppingToken);

            }
        }
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Item Stoped at: {time}", DateTimeOffset.Now);
            await base.StopAsync(cancellationToken);
        }
    }
}