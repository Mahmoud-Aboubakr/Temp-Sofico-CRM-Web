using SFFService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<QuotaWorker>();
    })
    .Build();

await host.RunAsync();
