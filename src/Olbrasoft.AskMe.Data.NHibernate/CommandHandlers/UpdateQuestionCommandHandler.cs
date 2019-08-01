using System;
using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Commands;
using NHibernate;
using Olbrasoft.Commanding.Mapping.NHibernate;
using Olbrasoft.Mapping;

namespace Olbrasoft.AskMe.Data.NHibernate.CommandHandlers
{
    public class UpdateQuestionCommandHandler : CommandHandlerWithMapperAndSessionFactory<UpdateQuestionCommand>
    {
        public UpdateQuestionCommandHandler(IMapper mapper, ISessionFactory factory) : base(mapper, factory)
        {
        }

        public override async Task HandleAsync(UpdateQuestionCommand command, CancellationToken token)
        {
            var q = await Session.QueryOver<Question>().Where(p => p.Id == command.Data.Id).SingleOrDefaultAsync(token);

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

            using (var transaction = Session.BeginTransaction())
            {
                Session.Update(q);
                await transaction.CommitAsync(token);
            }
        }
    }
}