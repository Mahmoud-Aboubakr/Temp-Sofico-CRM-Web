using SFFService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<ClientWorker>();
        services.AddHostedService<WarehouseWorker>();
        services.AddHostedService<ItemWorker>();
        services.AddHostedService<PromotionWorker>();
        services.AddHostedService<InvoiceWorker>();

    })
    .Build();

await host.RunAsync();
