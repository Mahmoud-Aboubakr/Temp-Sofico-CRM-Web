using SFFService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<DispatchWorker>();
    })
    .Build();

await host.RunAsync();
