using SFFService;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<SetupWorker>();
        services.AddHostedService<PromotionWorker>();
        services.AddHostedService<QuotaWorker>();
    })
    .Build();

await host.RunAsync();
