using SFFService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<WarehouseWorker>();
    })
    .Build();

await host.RunAsync();
