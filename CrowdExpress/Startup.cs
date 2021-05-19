using AuthWebApi.Asset;
using AuthWebApi.Asset.Contract;
using AuthWebApi.Contract;
using AuthWebApi.Email.Services;
using AuthWebApi.MiddleWare;
using AuthWebApi.Model;
using AuthWebApi.Repository;
using AuthWebApi.Service;
using AutoMapper;
using CrowdExpress.Data;
using CrowdExpress.Models;
using CrowdExpress.Models.Configuration;
using CrowdExpress.Repository;
using CrowdExpress.Repository.Contract;
using CrowdExpress.Repository.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace CrowdExpress
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<CrowdExpressDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddJwt<JwtOption>(Configuration.GetSection(JwtOption.Section));
            //Add cors
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder
                        .WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            services.AddHttpContextAccessor();
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CrowdExpress API", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<IUserContractManager, UserImplementationManager>();
            services.AddTransient<IIntManager<ExternalLogin<User>>, IntModelManager<ExternalLogin<User>>>();
            services.AddTransient<INewsletterRepository, NewsletterRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IStringManager<Transaction>, StringModelManager<Transaction>>();
            services.AddTransient<IStringManager<WalletTransaction>, StringModelManager<WalletTransaction>>();
            services.AddTransient<IIntManager<Product>, IntModelManager<Product>>();
            services.AddTransient<IIntManager<Receipient>, IntModelManager<Receipient>>();
            services.AddTransient<IIntManager<Itinerary>, IntModelManager<Itinerary>>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<AuthRepository>();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            //regster custom app handling middleware
            app.UseAppExceptionHandler(env);
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
            });
        }
    }
}
