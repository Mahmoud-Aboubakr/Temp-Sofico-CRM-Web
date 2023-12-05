using AutoMapper;
using CorePush.Apple;
using CorePush.Google;
using Helpers;
using Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Models;
using SofiForce.Promotion;
using SofiForce.Sync.Common;
using SofiForce.Sync.Dapper;
using SofiForce.Sync.Dapper.Implementation;
using SofiForce.Sync.Dapper.Interface;
using SofiForce.Sync.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofiForce.Sync
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
            services.AddControllersWithViews();
            services.Configure<Microsoft.AspNetCore.Mvc.ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
                
            });

            services.AddCors(options =>
            {
                options.AddPolicy("sofico",
                    builder =>
                    {
                        builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(_ => true)
                        .AllowCredentials()
                        ;
                    });
            });


            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
               
            });


            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.AddSignalR();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<DapperContext>();
            services.AddSingleton<DapperTempContext>();



            services.AddSingleton<IOrderLoggerService, OrderLoggerService>();
            services.AddScoped<ISalesControlManager, SalesControlManager>();


            services.AddSingleton<IPromotionCalculator,PromotionCalculator>();

            services.AddScoped<AppHub>();
            services.AddHttpClient<FcmSender>();
            services.AddHttpClient<ApnSender>();


            // Configure strongly typed settings objects
            var FcmNotification = Configuration.GetSection("FcmNotification");
            services.Configure<FcmNotificationSetting>(FcmNotification);


            // Register the swagger generator
 
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc(name: "V1", new OpenApiInfo { Title = "Fieldforce API", Version = "V1" });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("sofico");
            app.UseAuthentication();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }


            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();
            // Enable the SwaggerUI
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint(url: "/swagger/V1/swagger.json", name: "My API V1");
                c.RoutePrefix = string.Empty;
            });


            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {

            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");

               endpoints.MapHub<AppHub>("/AppHub");
            });

        }
    }
}
