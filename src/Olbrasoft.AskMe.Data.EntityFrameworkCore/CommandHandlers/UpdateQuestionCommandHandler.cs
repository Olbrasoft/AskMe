using System;
using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Commands;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.CommandHandlers
{
    public class UpdateQuestionCommandHandler : AskCommandHandler<UpdateQuestionCommand>
    {
        public UpdateQuestionCommandHandler(AskDbContext context) : base(context)
        {
        }

        public override async Task HandleAsync(UpdateQuestionCommand command, CancellationToken token)
        {
            var q = await Context.Questions.FindAsync(command.Data.Id);
            if (q == null)
            {
                command.NotFound = true;
                return;
            }

            var data = command.Data;
            q.CategoryId = data.CategoryId;
            q.DisplayName = data.DisplayName;
            q.EmailAddress = data.EmailAddress;
            q.QuestionText = data.QuestionText;

            if (string.IsNullOrWhiteSpace(data.AnswerText))
            {
                q.AnswerText = null;
                q.DateAnswered = null;
            }
            else
            {
                q.AnswerText = data.AnswerText;
                if (!q.DateAnswered.HasValue) q.DateAnswered = DateTime.Now;
            }

            await Context.SaveChangesAsync(token);
        }
    }
}