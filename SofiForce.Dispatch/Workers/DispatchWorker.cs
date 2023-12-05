
using SFFService.Services;
using System.Data;
using System.Data.SqlClient;

namespace SFFService
{
    public class DispatchWorker : BackgroundService
    {
        private readonly ILogger<DispatchWorker> _logger;
        private readonly IConfiguration _configuration;



        public DispatchWorker(ILogger<DispatchWorker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration= configuration;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CRM dispatch Worker Start at: {time}", DateTimeOffset.Now);
          
            await base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {


                    DispatchMigrator itemQuotaMigrator = new DispatchMigrator(_configuration);
                    var ItemQuotaRes = itemQuotaMigrator.Migrate();
                    if (ItemQuotaRes.IsCompleted == false)
                    {
                        _logger.LogError("CRM dispatch Worker {error}: {time}", ItemQuotaRes.Message, DateTimeOffset.Now);
                        continue;

                    }


                    _logger.LogInformation("CRM dispatch Worker Done: {time}",  DateTimeOffset.Now);

                }
                catch (Exception ex)
                {

                    _logger.LogError("{error}: {time}",ex.Message, DateTimeOffset.Now);

                }
               

                await Task.Delay(15*60*1000, stoppingToken);
            }
        }
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CRM dispatch Worker Stoped at: {time}", DateTimeOffset.Now);
            await base.StopAsync(cancellationToken);
        }
    }
}