using System;
using System.Linq;
using Altairis.AskMe.Data.Base.Objects;
using AutoMapper;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
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
using Olbrasoft.Commanding.Castle;
using Olbrasoft.Mapping;
using Olbrasoft.Mapping.AutoMapper;
using Olbrasoft.Querying.Castle;

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

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var container = new WindsorContainer();
            container.AddFacility<TypedFactoryFacility>();

            services.AddDbContext<AskDbContext>(options =>
            {
                options.UseSqlite(_config.GetConnectionString("AskDB"));
            });

            services.AddAutoMapper(typeof(Data.MapProfile<,>).Assembly);

            container.Register(Component.For<IProjection>().ImplementedBy<Projector>());

            container.AddCommanding();

            ConfigureCommands(container);

            ConfigureCommandsHandlers(container);
            
          
            container.AddQuering(typeof(Data.Queries.CategoriesListItemsQuery).Assembly, typeof(AskQueryHandler<,,>).Assembly);

      
            ConfigureBusiness(container);

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

            return WindsorRegistrationHelper.CreateServiceProvider(container, services);
        }

        private static void ConfigureBusiness(IWindsorContainer container)
        {
            container.Register(
                Component.For<IQuestions>().ImplementedBy<QuestionService>()
                    .LifestyleCustom<MsScopedLifestyleManager>()
            );

            container.Register(
                Component.For<ICategories>().ImplementedBy<CategoryService>()
                    .LifestyleCustom<MsScopedLifestyleManager>()
            );

            container.Register(
                Component.For<IAsk>().ImplementedBy<AskFacade>()
                    .LifestyleCustom<MsScopedLifestyleManager>()
            );
        }

       

        private static void ConfigureCommandsHandlers(IWindsorContainer container)
        {
            var classes = Classes.FromAssemblyNamed(typeof(AskCommandHandler<>).Assembly.GetName().Name);

            container.Register(classes
                .Where(ns => ns.Namespace != null && ns.Namespace.Contains(nameof(Olbrasoft.AskMe.Data.EntityFrameworkCore.CommandHandlers)))
                .WithServiceFirstInterface()
                .LifestyleCustom<MsScopedLifestyleManager>());
        }

      

        private static void ConfigureCommands(IWindsorContainer container)
        {
            var classes = Classes.FromAssemblyNamed("Altairis.AskMe.Data");

            container.Register(classes
                .Where(type => type.Namespace != null && type.Namespace.Contains("Commands")));
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