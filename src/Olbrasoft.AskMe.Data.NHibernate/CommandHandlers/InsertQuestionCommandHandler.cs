using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Commands;
using NHibernate;
using Olbrasoft.Commanding.Mapping.NHibernate;
using Olbrasoft.Mapping;

namespace Olbrasoft.AskMe.Data.NHibernate.CommandHandlers
{
    public class InsertQuestionCommandHandler : CommandHandlerWithMapperAndSessionFactory<InsertQuestionCommand>
    {
        public InsertQuestionCommandHandler(IMapper mapper, ISessionFactory factory) : base(mapper, factory)
        {
        }

        public override async Task HandleAsync(InsertQuestionCommand command, CancellationToken token)
        {
            var question = MapTo<Question>(command.Data);

            question.Category = new Category { Id = question.CategoryId };
            
            using (var transaction = Session.BeginTransaction())
            {
                command.QuestionId = (int) Session.Save(question);
                await transaction.CommitAsync(token);
            }
            

        }
    }
}