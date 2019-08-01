using System;
using System.Linq;
using Altairis.AskMe.Data.Base.Objects;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.AskMe.Business.DependencyInjection.Microsoft;
using Olbrasoft.AskMe.Data.EntityFrameworkCore;
using Olbrasoft.AskMe.Data.NHibernate;
using Olbrasoft.AskMe.Data.NHibernate.CommandHandlers;
using Olbrasoft.AskMe.Data.NHibernate.QueryHandlers;
using Olbrasoft.Commanding.DependencyInjection.Microsoft;
using Olbrasoft.Mapping.AutoMapper.DependencyInjection.Microsoft;
using Olbrasoft.Querying.DependencyInjection.Microsoft;
using Environment = System.Environment;

namespace Altairis.AskMe.Web.RazorPages
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
            // Configure DB context
            services.AddDbContext<AskDbContext>(options =>
            {
                options.UseSqlServer(this._config.GetConnectionString("AskDB"));
            });
            
            services.AddMapping(typeof(Data.Transfer.Objects.CategoryListItemDto).Assembly);

            services.AddCommanding(typeof(Data.Commands.InputQuestionCommand).Assembly, typeof(InputQuestionCommandHandler).Assembly);

            services.AddQuerying(typeof(Data.Queries.CategoriesListItemsQuery).Assembly, typeof(PagedAnsweredQuestionsQueryHandler).Assembly);

            services.AddBusiness();

            // Configure Razor Pages
            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/Admin");
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

            var cfg = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(_config.GetConnectionString("AskDB")))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<PagedAnsweredQuestionsQueryHandler>()
                    .Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Never()));
            
            services.AddSingleton(provider => cfg.BuildSessionFactory());

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AskDbContext context, UserManager<ApplicationUser> userManager)
        {
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