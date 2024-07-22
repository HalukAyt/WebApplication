using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using AspNetCore.Identity.MongoDbCore.Models;
using WebApp.Business.Abstract;
using WebApp.Core.Repository.Abstract;
using WebApp.DataAccess.Abstract;
using WebApp.DataAccess.Concrete;
using WebApp.DataAccess.Repository;
using WebApp.User.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using WebApp.Entities.Concrete;
using WebApp.Business.Concrete;
using WebApp.Core.Settings;

namespace WebApp.User
{
    public class Startup(IConfiguration configuration)
    {
        public IConfiguration Configuration { get; } = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddAuthentication(option =>
            {
                option.DefaultScheme = IdentityConstants.ApplicationScheme;
                option.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            }).AddIdentityCookies(o =>
            {

            });

            services.AddIdentityCore<Personel>(option =>
            {

            })
                .AddRoles<MongoIdentityRole>()
                .AddMongoDbStores<Personel, MongoIdentityRole, Guid>(Configuration.GetSection("MongoConnection:ConnectionString").Value, Configuration.GetSection("MongoConnection:Database").Value)
                .AddSignInManager()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(option =>
            {
                option.Cookie.HttpOnly = true;
                option.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                option.LoginPath = "/Account/Login";
                option.SlidingExpiration = true;
            });


            services.AddScoped(typeof(IRepository<>), typeof(MongoRepositoryBase<>));
            services.AddScoped<IPersonelDataAccess, PersonelDataAccess>();
            services.AddScoped<IPersonelService, PersonelManager>();

            services.AddScoped<IPropertyDataAccess, PropertyDataAccess>();
            services.AddScoped<IPropertyService, PropertyManager>();

            services.AddScoped<IBookingDataAccess, BookingDataAccess>();
            services.AddScoped<IBookingService, BookingService>();


            services.AddScoped<ICityDataAccess, CityDataAccess>();
            services.AddScoped<ICityService, CityManager>();

            services.AddControllersWithViews();

            services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });

            services.AddMvc()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization(
                options => options.DataAnnotationLocalizerProvider = (type, factory) =>
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    var assemblyName = new AssemblyName(typeof(SharedModelResource).GetTypeInfo().Assembly.FullName);
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning disable CS8604 // Possible null reference argument.
                    return factory.Create(nameof(SharedModelResource), assemblyName.Name);
#pragma warning restore CS8604 // Possible null reference argument.
                }
                );
            services.Configure<MongoSettings>(options =>
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning disable CS8601 // Possible null reference assignment.
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
#pragma warning restore CS8601 // Possible null reference assignment.
            });
            services.Configure<RequestLocalizationOptions>(opt =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new("en-US"),
                    new ("tr-TR"),
                    new ("ar-SA")
                };

                opt.DefaultRequestCulture = new RequestCulture("tr-TR");
                opt.SupportedCultures = supportedCultures;
                opt.SupportedUICultures = supportedCultures;

#pragma warning disable IDE0028 // Simplify collection initialization
                opt.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider(),
                    new AcceptLanguageHeaderRequestCultureProvider()
                };
#pragma warning restore IDE0028 // Simplify collection initialization
                //opt.RequestCultureProviders = new[] { new RouteDataRequestCultureProvider() {

                //Options=opt
                //} };
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            app.UseRequestLocalization(options.Value);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
