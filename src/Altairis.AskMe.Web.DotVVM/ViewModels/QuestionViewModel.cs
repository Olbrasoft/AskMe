using System;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Transfer.Objects;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.AskMe.Data.EntityFrameworkCore;

namespace Altairis.AskMe.Web.DotVVM.ViewModels {
    public class QuestionViewModel : MasterPageViewModel {
        private readonly AskDbContext dbContext;

        public QuestionViewModel(IHostingEnvironment env, AskDbContext dbContext) : base(env) {
            this.dbContext = dbContext;
        }

        public override string PageTitle => "Detail otázky";

        public QuestionDto Item { get; set; }

        public async override Task PreRender() {
            var questionId = Convert.ToInt32(this.Context.Parameters["questionId"]);
            var q = await this.dbContext.Questions
                .ProjectTo<QuestionDto>()
                .SingleOrDefaultAsync(x => x.Id == questionId);
            if (q == null) throw new ObjectNotFoundException();
            this.Item = Mapper.Map<QuestionDto>(q);
        }
    }
}

