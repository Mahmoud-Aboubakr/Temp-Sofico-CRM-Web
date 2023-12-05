
using Hangfire;
using SofiForce.DataObjects;


namespace SofiForce.Hangfire.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Hangfire services.
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection")));

            // Add the processing server as IHostedService
            services.AddHangfireServer();

            // Add framework services.
            services.AddMvc();

            // intalize Jobs

            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHangfireDashboard();
                endpoints.MapGet("/", context =>
                {
                    return Task.Run(() => context.Response.Redirect("/hangfire"));
                });
            });

            RecurringJob.AddOrUpdate("Branch_Migrator", () => new BranchMigrator(Configuration).Migrate(), Cron.MinuteInterval(1));
            RecurringJob.AddOrUpdate("Client_Balance_Migrator", () => new ClientBalanceMigrator(Configuration).Migrate(), Cron.MinuteInterval(1));
            RecurringJob.AddOrUpdate("Client_Migrator", () => new ClientMigrator(Configuration).Migrate(), Cron.MinuteInterval(1));
            RecurringJob.AddOrUpdate("Client_Type_Migrator", () => new ClientTypeMigrator(Configuration).Migrate(), Cron.MinuteInterval(1));
            RecurringJob.AddOrUpdate("Item_Migrator", () => new ItemMigrator(Configuration).Migrate(), Cron.MinuteInterval(1));
            RecurringJob.AddOrUpdate("PaymentTerm_Migrator", () => new PaymentTermMigrator(Configuration).Migrate(), Cron.MinuteInterval(1));
            RecurringJob.AddOrUpdate("Representative_Migrator", () => new RepresentativeMigrator(Configuration).Migrate(), Cron.MinuteInterval(1));
            RecurringJob.AddOrUpdate("Store_Migrator", () => new StoreMigrator(Configuration).Migrate(), Cron.MinuteInterval(1));
            RecurringJob.AddOrUpdate("Store_Type_Migrator", () => new StoreTypeMigrator(Configuration).Migrate(), Cron.MinuteInterval(1));
            RecurringJob.AddOrUpdate("Vendor_Migrator", () => new VendorMigrator(Configuration).Migrate(), Cron.MinuteInterval(1));

        }
    }
}
