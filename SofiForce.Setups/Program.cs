
using SFFService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<SetupWorker>();
    })
    .Build();

await host.RunAsync();
