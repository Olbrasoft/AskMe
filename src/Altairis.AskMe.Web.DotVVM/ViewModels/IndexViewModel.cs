using System.Linq;
using Altairis.AskMe.Data.Transfer.Objects;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Olbrasoft.AskMe.Data.EntityFrameworkCore;

namespace Altairis.AskMe.Web.DotVVM.ViewModels {
    public class IndexViewModel : PagedViewModel<QuestionDto> {
        private readonly AskDbContext dbContext;

        public IndexViewModel(IHostingEnvironment env, IOptionsSnapshot<AppConfiguration> config, AskDbContext dbContext) : base(env, config) {
            this.dbContext = dbContext;
        }

        public override string PageTitle => "AskMe";

        protected override IQueryable<QuestionDto> DataSource
            => this.dbContext.Questions
                .Where(x => x.DateAnswered.HasValue)
                .OrderByDescending(x => x.DateAnswered)
                .ProjectTo<QuestionDto>();
    }
}

