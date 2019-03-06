using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using SuHaFabric.Repository.Dapper;
using SuHaFabric.Repository;
using MedicineSecurityReport.Domain;
using MedicineSecurityReport.Common;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;

namespace MedicineSecurityReport
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var authority = Configuration.GetValue<string>("Authority");
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "oidc";
            })
           .AddCookie(options =>
           {
               options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
               options.Cookie.Name = "mvchybrid";
           })
           .AddOpenIdConnect("oidc", options =>
           {
               options.Authority = authority;
               options.RequireHttpsMetadata = false;

               options.ClientSecret = "secret";
               options.ClientId = "medicinesecurityreport";

               options.ResponseType = "code id_token";

               options.Scope.Clear();
               options.Scope.Add("openid");
               options.Scope.Add("profile");
               options.Scope.Add("api1");

               options.GetClaimsFromUserInfoEndpoint = true;
               options.SaveTokens = true;
               //options.Events.OnRedirectToIdentityProvider = context =>
               //{
               //    context.ProtocolMessage.SetParameter("culture", CultureInfo.CurrentUICulture.Name);

               //    return Task.FromResult(0);
               //};
           });
            services.AddDapperDBContext<ReportDBContext>(options =>
            {
                options.Configuration = Configuration.GetConnectionString("Default");
            });
            services.AddAutoMapper();
            
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<IUnitOfWorkFactory, DapperUnitOfWorkFactory>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();
            app.UseAuthentication();
            Mapper.Initialize(y =>
            {
                y.AddProfile<MyProfile>();
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
