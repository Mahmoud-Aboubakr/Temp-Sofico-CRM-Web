

using SofiForce.Worker;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker2>();
        services.AddSingleton<IOrderService, OrderService>();
        services.AddSingleton<ISalesOrderManager, SalesOrderManager>();
        services.AddSingleton<DapperContext>();

    })
    .Build();

await host.RunAsync();
