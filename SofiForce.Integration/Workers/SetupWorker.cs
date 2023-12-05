
using SFFService.Services;
using System.Data;
using System.Data.SqlClient;

namespace SFFService
{
    public class SetupWorker : BackgroundService
    {
        private readonly ILogger<WarehouseWorker> _logger;
        private readonly IConfiguration _configuration;



        public SetupWorker(ILogger<WarehouseWorker> logger, IConfiguration configuration)
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


                    BranchMigrator branchMigrator = new BranchMigrator(_configuration);
                    var BranchRES = branchMigrator.Migrate();

                    if (BranchRES.IsCompleted == false)
                    {
                        _logger.LogError("BranchMigrator {error}: {time}", BranchRES.Message, DateTimeOffset.Now);
                        continue;

                    }


                    ClientTypeMigrator clientTypeMigrator = new ClientTypeMigrator(_configuration);
                    var clientTypeRes = clientTypeMigrator.Migrate();
                    if (clientTypeRes.IsCompleted == false)
                    {
                        _logger.LogError("ClientTypeMigrator {error}: {time}", clientTypeRes.Message, DateTimeOffset.Now);
                        continue;

                    }

                    ClientMigrator clientMigrator = new ClientMigrator(_configuration);
                    var clientRes = clientMigrator.Migrate();
                    if (clientRes.IsCompleted == false)
                    {
                        _logger.LogError("ClientMigrator : {error}: {time}", clientRes.Message, DateTimeOffset.Now);
                        continue;

                    }





                    StoreTypeMigrator storeTypeMigrator = new StoreTypeMigrator(_configuration);
                    var StoreTypeRES = storeTypeMigrator.Migrate();
                    if (StoreTypeRES.IsCompleted == false)
                    {
                        _logger.LogError("StoreTypeMigrator {error}: {time}", StoreTypeRES.Message, DateTimeOffset.Now);
                        continue;

                    }


                    StoreMigrator storeMigrator = new StoreMigrator(_configuration);
                    var StoreRES = storeMigrator.Migrate();
                    if (StoreRES.IsCompleted == false)
                    {
                        _logger.LogError("StoreMigrator {error}: {time}", StoreRES.Message, DateTimeOffset.Now);

                    }

                    VendorMigrator vendorMigrator = new VendorMigrator(_configuration);
                    var vendorRES = vendorMigrator.Migrate();
                    if (vendorRES.IsCompleted == false)
                    {
                        _logger.LogError("VendorMigrator {error}: {time}", vendorRES.Message, DateTimeOffset.Now);
                        continue;

                    }


                    ItemMigrator itemMigrator = new ItemMigrator(_configuration);
                    var itemRes = itemMigrator.Migrate();
                    if (itemRes.IsCompleted == false)
                    {
                        _logger.LogError("ItemMigrator {error}: {time}", itemRes.Message, DateTimeOffset.Now);
                        continue;

                    }


                    RepresentativeMigrator representativeMigrator = new RepresentativeMigrator(_configuration);
                    var representativeRes = representativeMigrator.Migrate();
                    if (representativeRes.IsCompleted == false)
                    {
                        _logger.LogError("RepresentativeMigrator {error}: {time}", representativeRes.Message, DateTimeOffset.Now);
                        continue;

                    }

                    PaymentTermMigrator paymentTermMigrator = new PaymentTermMigrator(_configuration);
                    var paymentTermRes = paymentTermMigrator.Migrate();
                    if (paymentTermRes.IsCompleted == false)
                    {
                        _logger.LogError("PaymentTermMigrator {error}: {time}", paymentTermRes.Message, DateTimeOffset.Now);
                        continue;

                    }

                    _logger.LogInformation("Warehouse Worker Done: {time}",  DateTimeOffset.Now);

                }
                catch (Exception ex)
                {

                    _logger.LogError("StoreItemMigrator {error}: {time}", ex.Message, DateTimeOffset.Now);

                }
               

                await Task.Delay(3*60*1000, stoppingToken);
            }
        }
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker Stoped at: {time}", DateTimeOffset.Now);
            await base.StopAsync(cancellationToken);
        }
    }
}