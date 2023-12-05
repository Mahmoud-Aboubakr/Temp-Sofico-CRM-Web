
using SofiForce.Worker;
using System.Reflection;

IHost host = Host.CreateDefaultBuilder(args)
     .ConfigureAppConfiguration((hostingContext, configuration) =>
     {
         configuration.Sources.Clear();
         configuration.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
         configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
         IConfigurationRoot configurationRoot = configuration.Build();
     })
    .ConfigureServices(services =>
    {
        services.AddHostedService<WorkerMissing>();
        services.AddHostedService<WorkerNoCodeMissing>();
        //services.AddHostedService<WorkerInValidValue>();


    })
    .Build();

await host.RunAsync();
