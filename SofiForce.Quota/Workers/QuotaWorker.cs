
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


                    ItemQuotaMigrator itemQuotaMigrator = new ItemQuotaMigrator(_configuration);
                    var ItemQuotaRes = itemQuotaMigrator.Migrate();
                    if (ItemQuotaRes.IsCompleted == false)
                    {
                        _logger.LogError("ItemQuotaMigrator {error}: {time}", ItemQuotaRes.Message, DateTimeOffset.Now);
                        continue;

                    }

                  

                    ClientExceptionQuotaMigrator clientExceptionQuotaMigrator = new ClientExceptionQuotaMigrator(_configuration);
                    var ClientExceptionQuotaRes = clientExceptionQuotaMigrator.Migrate();
                    if (ClientExceptionQuotaRes.IsCompleted == false)
                    {
                        _logger.LogError("ClientExceptionQuotaMigrator {error}: {time}", ClientExceptionQuotaRes.Message, DateTimeOffset.Now);
                        continue;

                    }



                    _logger.LogInformation("Quota Worker Done: {time}",  DateTimeOffset.Now);
         
                }
                catch (Exception ex)
                {

                    _logger.LogError("{error}: {time}",ex.Message, DateTimeOffset.Now);
          
                }

         
                await Task.Delay(5*60*1000, stoppingToken);
            }
        }
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Quota Worker Stoped at: {time}", DateTimeOffset.Now);
            await base.StopAsync(cancellationToken);
        }
    }
}
