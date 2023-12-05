using SFFService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<InvoiceWorker>();
        services.AddHostedService<InvoiceCashdiscountWorker>();
    })
    .Build();

await host.RunAsync();
