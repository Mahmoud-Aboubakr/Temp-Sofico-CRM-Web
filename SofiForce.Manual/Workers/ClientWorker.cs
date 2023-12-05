
using SFFService.Services;
using System.Data;
using System.Data.SqlClient;

namespace SFFService
{
    public class ClientWorker : BackgroundService
    {
        private readonly ILogger<ClientWorker> _logger;
        private readonly IConfiguration _configuration;



        public ClientWorker(ILogger<ClientWorker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration= configuration;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Clients Start at: {time}", DateTimeOffset.Now);
            await base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {

                    ClientMigrator clientMigrator = new ClientMigrator(_configuration);
                    var clientMigratorRes = clientMigrator.Migrate();
                    if (clientMigratorRes.IsCompleted == false)
                    {
                        _logger.LogError("Clients {error}: {time}", clientMigratorRes.Message, DateTimeOffset.Now);
                        continue;

                    }

                }
                catch (Exception ex)
                {

                    _logger.LogError("Clients {error}: {time}", ex.Message, DateTimeOffset.Now);

                }
               

                await Task.Delay(1000, stoppingToken);
            }
        }
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Clients Stoped at: {time}", DateTimeOffset.Now);
            await base.StopAsync(cancellationToken);
        }
    }
}