using AlloyDemo.Extensions;
using EPiServer.Cms.Shell;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.ContentApi.Cms;
using EPiServer.Data;
using EPiServer.OpenIDConnect;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Microsoft.OpenApi.Models;
using EPiServer.ContentApi.Core.DependencyInjection;
using EPiServer.ContentDefinitionsApi;
using EPiServer.Core;
using EPiServer.Web;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AlloyDemo.Converter;
using EPiServer.ContentApi.Core.Serialization;

namespace AlloyDemo;

public class Startup
{
    private readonly IWebHostEnvironment _webHostingEnvironment;
    private readonly Uri _frontendUri = new("https://localhost:5000/");
    public Startup(IWebHostEnvironment webHostingEnvironment)
    {
        _webHostingEnvironment = webHostingEnvironment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        if (_webHostingEnvironment.IsDevelopment())
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(_webHostingEnvironment.ContentRootPath, "App_Data"));

            services.Configure<SchedulerOptions>(options => options.Enabled = false);
        }

        //services.AddContentDefinitionsApi();
        services.AddContentDefinitionsApi();
        services.AddContentDeliveryApi(options =>
        {
            options.SiteDefinitionApiEnabled = true;
           
        })
            .WithSiteBasedCors()
            .WithFriendlyUrl();

        services.AddCors(opt =>
        {
            opt.AddPolicy(name: "MyScheme", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v2" });

        });
        services
            .AddCmsAspNetIdentity<ApplicationUser>()
            .AddCms()
            .AddAlloy()
            .AddAdminUserRegistration()
            .AddEmbeddedLocalization<Startup>()
            .Configure<ExternalApplicationOptions>(o => o.OptimizeForDelivery = true);


        //services.TryAddScoped<TestimonialItemListPropertyConvertor>();
        services.TryAddEnumerable(Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Singleton<IPropertyConverterProvider, ListPropertyConvertorProvider>());
        services.TryAddScoped<TestimonialItemListPropertyConvertor>();


        // Required by Wangkanai.Detection
        services.AddDetection();

        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(10);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });


        services.AddOpenIDConnect<ApplicationUser>(
        useDevelopmentCertificate: true,
        signingCertificate: null,
        encryptionCertificate: null,
        createSchema: true,
        options =>
        {
            // Sample interactive JavaScript application 
            options.Applications.Add(new OpenIDConnectApplication
            {
                ClientId = "frontend",
                Scopes =
                {
                    "openid",
                    "offline_access",
                    "profile",
                    "email",
                    "roles"
                },
                PostLogoutRedirectUris = { new Uri("http://localhost:5000") },
                RedirectUris =
                {
                    new Uri("http://localhost:5000/login-callback"),
                    new Uri("http://localhost:5000/login-renewal"),
                },
            });

            // Sample application using Client Credentials to make
            // machine-to-machine API calls
            options.Applications.Add(new OpenIDConnectApplication
            {
                ClientId = "cli",
                ClientSecret = "cli",
                Scopes = { ContentDefinitionsApiOptionsDefaults.Scope }, // Default scope from Content Definitions API
            });
        });

        // If you have installed EPiServer.OpenIDConnect.UI
        services.AddOpenIDConnectUI();


        //services.AddOpenIDConnect<ApplicationUser>(
        //    useDevelopmentCertificate: true,
        //    signingCertificate: null,
        //    encryptionCertificate: null,
        //    createSchema: true,
        //    options =>
        //    {
        //        options.RequireHttps = !_webHostingEnvironment.IsDevelopment();

        //        options.Applications.Add(new OpenIDConnectApplication
        //        {
        //            ClientId = "frontend",
        //            Scopes = { "openid", "offline_access", "profile", "email", "roles", ContentDeliveryApiOptionsDefaults.Scope },
        //            PostLogoutRedirectUris = { _frontendUri },
        //            RedirectUris =
        //            {
        //                new Uri(_frontendUri, "/login-callback"),
        //                new Uri(_frontendUri, "/login-renewal"),
        //            },
        //        });

        //        options.Applications.Add(new OpenIDConnectApplication
        //        {
        //            ClientId = "cli",
        //            ClientSecret = "cli",
        //            Scopes = { ContentDefinitionsApiOptionsDefaults.Scope },
        //        });
        //    });

        //services.AddOpenIDConnectUI();


        //services.AddContentDefinitionsApi(OpenIDConnectOptionsDefaults.AuthenticationScheme);
        //services.AddContentDeliveryApi(OpenIDConnectOptionsDefaults.AuthenticationScheme);
        //services.ConfigureForContentDeliveryClient();

        //services.AddHostedService<ProvisionDatabase>();




    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V2");
            });

        }

        // Required by Wangkanai.Detection
        app.UseDetection();
        app.UseSession();

        app.UseStaticFiles();
        app.UseRouting();

        app.UseCors(builder => builder
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapContent();
        });
    }
}
