

using SFFService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<PromotionWorker>();
    })
    .Build();

await host.RunAsync();
