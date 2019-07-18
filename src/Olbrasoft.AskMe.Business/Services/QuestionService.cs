﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Commands;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Data.Commanding;
using Olbrasoft.Data.Querying;
using Olbrasoft.Pagination;

namespace Olbrasoft.AskMe.Business.Services
{
    public class QuestionService : Service, IQuestions
    {
        public QuestionService(ICommandFactory commandFactory, IQueryFactory queryFactory) : base(commandFactory, queryFactory)
        {
        }

        public Task<QuestionDto> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var query = QueryFactory.Get<QuestionByIdQuery>();
            query.QuestionId = id;

            return query.ExecuteAsync(cancellationToken);
        }

        public Task<IResultWithTotalCount<QuestionDto>> GetAnsweredAsync(IPageInfo pagingSettings, CancellationToken cancellationToken = default)
        {
            var query = QueryFactory.Get<PagedAnsweredQuestionsQuery>();
            query.Paging = pagingSettings;

            return query.ExecuteAsync(cancellationToken);
        }

        public Task<IResultWithTotalCount<UnansweredQuestionDto>> GetUnansweredAsync(IPageInfo pagingSettings, CancellationToken cancellationToken = default)
        {
            var query = QueryFactory.Get<PagedUnansweredQuestionsQuery>();
            query.Paging = pagingSettings;

            return query.ExecuteAsync(cancellationToken);
        }

        public Task AddAsync(Question question, CancellationToken token = default)
        {
            var command = CommandFactory.Get<InsertQuestionCommand>();
            command.Data = question;

            return command.ExecuteAsync(token);
        }

        public Task<IEnumerable<SyndicationQuestionDto>> GetSyndicationsAsync(int take, CancellationToken token = default)
        {
            var query = QueryFactory.Get<SyndicationQuestionsQuery>();
            query.Take = take;

            return query.ExecuteAsync(token);
        }

        public Task EditAsync(QuestionDto question, out bool notFound ,CancellationToken token = default)
        {
            var command = CommandFactory.Get<UpdateQuestionCommand>();
            command.Data = question;
            var result = command.ExecuteAsync(token);
            notFound = command.NotFound;

            return result;

        }

        public Task<bool> ExistAsync(int id, CancellationToken token = default)
        {
            var query = QueryFactory.Get<ExistQuestionQuery>();
            query.QuestionId = id;

            return query.ExecuteAsync(token);
        }
    }
}