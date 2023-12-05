
using SFFService.Services;
using System.Data;
using System.Data.SqlClient;

namespace SFFService
{
    public class QuotaWorker : BackgroundService
    {
        private readonly ILogger<QuotaWorker> _logger;
        private readonly IConfiguration _configuration;



        public QuotaWorker(ILogger<QuotaWorker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration= configuration;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Quota Worker Start at: {time}", DateTimeOffset.Now);
          
            await base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {


                    QuotaMigrator quotaMigrator = new QuotaMigrator(_configuration);
                    var quotaMigratorRes = quotaMigrator.Migrate();
                    if (quotaMigratorRes.IsCompleted == false)
                    {
                        _logger.LogError("QuotaMigrator {error}: {time}", quotaMigratorRes.Message, DateTimeOffset.Now);
                        continue;

                    }

                    

                }
                catch (Exception ex)
                {

                    _logger.LogError("{error}: {time}",ex.Message, DateTimeOffset.Now);

                }


                await Task.Delay(1000, stoppingToken);
            }
        }
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Quota Worker Stoped at: {time}", DateTimeOffset.Now);
            await base.StopAsync(cancellationToken);
        }
    }
}