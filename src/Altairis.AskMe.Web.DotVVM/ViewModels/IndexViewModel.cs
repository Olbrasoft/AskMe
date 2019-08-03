using System;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Transfer.Objects;
using DotVVM.Framework.Controls;
using Microsoft.AspNetCore.Hosting;
using Olbrasoft.AskMe.Business;
using Olbrasoft.AskMe.Data.EntityFrameworkCore;
using Olbrasoft.Paging;

namespace Altairis.AskMe.Web.DotVVM.ViewModels
{
    public class IndexViewModel : MasterPageViewModel
    {
        private readonly IQuestions _questions;

        public override string PageTitle => "AskMe";

        public GridViewDataSet<QuestionDto> Data { get; set; } = new GridViewDataSet<QuestionDto>();

        public override async Task PreRender()
        {
            await base.PreRender();

            var pageNumber = Convert.ToInt32(Context.Parameters["pageNumber"]);

            var pageInfo = new PageInfo(10, pageNumber);
         
            Data.PagingOptions.PageIndex = pageNumber == 0 ? 0 : pageNumber - 1;

            var questions = await _questions.GetAnsweredAsync(pageInfo);
            Data.PagingOptions.TotalItemsCount = questions.TotalCount;
            Data.Items = questions.Result;
        }

        public IndexViewModel(IHostingEnvironment env, AskDbContext dbContext, IQuestions questions) : base(env)
        {
            Data.PagingOptions.PageSize = 10;

            _questions = questions;
        }
    }
}