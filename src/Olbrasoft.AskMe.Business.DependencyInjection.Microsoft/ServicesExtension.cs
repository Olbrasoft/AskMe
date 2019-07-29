using System;
using Microsoft.Extensions.DependencyInjection;
using Olbrasoft.AskMe.Business.Services;

namespace Olbrasoft.AskMe.Business.DependencyInjection.Microsoft
{
    public static class ServicesExtension
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<IQuestions, QuestionService>();

            services.AddScoped<ICategories, CategoryService>();

            services.AddScoped<IAsk,AskFacade>();
        }
    }
}
