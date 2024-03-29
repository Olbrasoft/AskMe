﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Web.DotVVM.Presenters;
using DotVVM.Framework.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.AskMe.Business.DependencyInjection.Microsoft;
using Olbrasoft.AskMe.Data.EntityFrameworkCore;
using Olbrasoft.Commanding.DependencyInjection.Microsoft;
using Olbrasoft.Data;
using Olbrasoft.Mapping.AutoMapper.DependencyInjection.Microsoft;
using Olbrasoft.Querying.DependencyInjection.Microsoft;

namespace Altairis.AskMe.Web.DotVVM {
    public class Startup
    {
        private const string ConnectionStringName = "AskMicrosoftSqlServer";

        private readonly IConfigurationRoot _config;


        public Startup(IHostingEnvironment env) {
            // Set CWD to content root (needed when AspNetCoreHostingModel=InProcess)
            Environment.CurrentDirectory = env.ContentRootPath;

            // Load configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("config.json", optional: false)
                .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            _config = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services) {
            // Configure DB context
            services.AddDbContext<AskDbContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString(ConnectionStringName));
                // options.UseSqlite(_config.GetConnectionString(ConnectionStringName));
            });

            //var s = new System.Data.SqlClient.SqlConnection();


           services.AddSingleton<Func<IDbConnection>>(x => () => new SqlConnection(_config.GetConnectionString(ConnectionStringName)));
          

            services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();

            services.AddMapping(typeof(Data.Transfer.Objects.CategoryListItemDto).Assembly);
            
            services.AddCommanding(typeof(Data.Commands.InsertQuestionCommand).Assembly, typeof(AskCommandHandler<>).Assembly);

            services.AddQuerying(
                typeof(Data.Queries.CategoriesListItemsQuery).Assembly, 
                typeof(Olbrasoft.AskMe.Data.Dapper.QueryHandlers.PagedAnsweredQuestionsQueryHandler).Assembly
                );

            services.AddBusiness();

            // Configure identity and authentication
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => {
                options.Password.RequiredLength = 12;
                options.Password.RequiredUniqueChars = 4;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<AskDbContext>()
                .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options => {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.Events.OnRedirectToLogin = context => DotvvmAuthenticationHelper.ApplyRedirectResponse(context.HttpContext, context.RedirectUri);
            });

            // Load configuration
            services.Configure<AppConfiguration>(this._config);

            services.AddDotVVM<DotvvmStartup>();

            services.AddScoped<RssPresenter>();

            // AutoMapper config
            MapperConfig.Configure();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AskDbContext context, UserManager<ApplicationUser> userManager) {
            // Show detailed errors in development environment
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                //app.UseBrowserLink();
            }

            // Migrate database to last version
           // context.Database.Migrate();

            // Seed initial data if in development environment
            if (env.IsDevelopment()) {
                // CreateQuery categories
              //  context.Seed();

                // CreateQuery default user
                if (!userManager.Users.Any()) {
                    var adminUser = new ApplicationUser { UserName = "admin" };
                    var r = userManager.CreateAsync(adminUser, "pass.word123").Result;
                    if (r != IdentityResult.Success) {
                        var errors = string.Join(", ", r.Errors.Select(x => x.Description));
                        throw new Exception("Seeding default user failed: " + errors);
                    }
                }
            }

            // HTTP error handling
            app.UseStatusCodePagesWithReExecute("/Error/{0}");


            // Enable static file caching for one year
            app.UseStaticFiles(new StaticFileOptions {
                OnPrepareResponse = ctx => {
                    ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=31536000");
                }
            });

            // Use other middleware
            app.UseAuthentication();
            app.UseDotVVM<DotvvmStartup>();
        }
    }
}
