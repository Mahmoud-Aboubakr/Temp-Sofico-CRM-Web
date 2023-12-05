
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
            _logger.LogInformation("Promotion Start at: {time}", DateTimeOffset.Now);
            try
            {
                _logger.LogInformation("Promotion {error}: {time}", "Connections Done", DateTimeOffset.Now);
            }
            catch (Exception ex)
            {
                _logger.LogError("Promotion {error}: {time}", ex.Message, DateTimeOffset.Now);
            }
            await base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {



                    PromotionMigrator promotionMigrator = new PromotionMigrator(_configuration);
                    var promotionMigratorRes = promotionMigrator.Migrate();

                    if (promotionMigratorRes.IsCompleted == false)
                    {
                        _logger.LogError("Promotion {error}: {time}", promotionMigratorRes.Message, DateTimeOffset.Now);
                        continue;

                    }

                }
                catch (Exception ex)
                {

                    _logger.LogError("Promotion {error}: {time}", ex.Message, DateTimeOffset.Now);

                }
                await Task.Delay(1000, stoppingToken);

            }
        }
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Promotion Stoped at: {time}", DateTimeOffset.Now);
            await base.StopAsync(cancellationToken);
        }
    }
}