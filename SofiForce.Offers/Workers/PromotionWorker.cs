
using SFFService.Services;
using System.Data;
using System.Data.SqlClient;

namespace SFFService
{
    public class PromotionWorker : BackgroundService
    {
        private readonly ILogger<PromotionWorker> _logger;
        private readonly IConfiguration _configuration;



        public PromotionWorker(ILogger<PromotionWorker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration= configuration;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Promotion Worker Start at: {time}", DateTimeOffset.Now);
            await base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {

                    SupplementryItemMigrator supplementryItemMigrator = new SupplementryItemMigrator(_configuration);
                    var supplementryItemRes = supplementryItemMigrator.Migrate();
                    if (supplementryItemRes.IsCompleted == false)
                    {
                        _logger.LogError("Promotion Worker {error}: {time}", supplementryItemRes.Message, DateTimeOffset.Now);
                        continue;

                    }
                    _logger.LogInformation("Promotion Worker Done: {time}",  DateTimeOffset.Now);

                }
                catch (Exception ex)
                {

                    _logger.LogError("SupplementryItemMigrator {error}: {time}", ex.Message, DateTimeOffset.Now);

                }
               

                await Task.Delay(5*60*1000, stoppingToken);
            }
        }
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Promotion Worker Stoped at: {time}", DateTimeOffset.Now);
            await base.StopAsync(cancellationToken);
        }
    }
}