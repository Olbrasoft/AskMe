﻿using System;
using System.Linq;
using Altairis.AskMe.Data.Base.Objects;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.AskMe.Business;
using Olbrasoft.AskMe.Business.Services;
using Olbrasoft.AskMe.Data.EntityFrameworkCore;
using Olbrasoft.Commanding.DependencyInjection.Microsoft;
using Olbrasoft.Mapping;
using Olbrasoft.Mapping.AutoMapper;
using Olbrasoft.Querying.DependencyInjection.Microsoft;

namespace Altairis.AskMe.Web.Mvc
{
    public class Startup
    {
        private readonly IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AskDbContext>(options =>
            {
                options.UseSqlite(_config.GetConnectionString("AskDB"));
            });

            services.AddAutoMapper(typeof(Data.MapProfile<,>).Assembly);

            services.AddSingleton<IProjection, Projector>();

            services.AddCommandingOnWeb(typeof(Data.Commands.InsertQuestionCommand).Assembly, typeof(AskCommandHandler<>).Assembly);

            services.AddQueryingOnWeb(typeof(Data.Queries.CategoriesListItemsQuery).Assembly, typeof(AskQueryHandler<,,>).Assembly);

            ConfigureBusiness(services);

            // Configure MVC
            services.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            // Configure identity and authentication
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 12;
                options.Password.RequiredUniqueChars = 4;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<AskDbContext>()
                .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
            });

            // Load configuration
            services.Configure<AppConfiguration>(_config);
        }

        private static void ConfigureBusiness(IServiceCollection services)
        {
            services.AddScoped<IQuestions, QuestionService>();

            services.AddScoped<ICategories, CategoryService>();

            services.AddScoped<IAsk, AskFacade>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AskDbContext context, UserManager<ApplicationUser> userManager, IMapper autoMapper)
        {
            autoMapper.ConfigurationProvider.AssertConfigurationIsValid();

            // Show detailed errors in development environment
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }

            // Migrate database to last version
            context.Database.Migrate();

            // Seed initial data if in development environment
            if (env.IsDevelopment())
            {
                // Create categories
                context.Seed();

                // Create default user
                if (!userManager.Users.Any())
                {
                    var adminUser = new ApplicationUser { UserName = "admin" };
                    var r = userManager.CreateAsync(adminUser, "pass.word123").Result;
                    if (r != IdentityResult.Success)
                    {
                        var errors = string.Join(", ", r.Errors.Select(x => x.Description));
                        throw new Exception("Seeding default user failed: " + errors);
                    }
                }
            }

            // HTTP error handling
            app.UseStatusCodePagesWithReExecute("/Error/{0}");

            // Enable static file caching for one year
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=31536000");
                }
            });

            // Use other middleware
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}