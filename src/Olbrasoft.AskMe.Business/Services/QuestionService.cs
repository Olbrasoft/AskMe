﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Commands;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Olbrasoft.Commanding;
using Olbrasoft.CommandingAndQuerying.Business;
using Olbrasoft.Paging;
using Olbrasoft.Querying;

namespace Olbrasoft.AskMe.Business.Services
{
    public class QuestionService : ServiceWithCommandFactoryAndQueryFactory, IQuestions
    {
        public Task<QuestionDto> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var query = GetQuery<QuestionByIdQuery>();
            query.QuestionId = id;

            return query.ExecuteAsync(cancellationToken);
        }

        public Task<IResultWithTotalCount<QuestionDto>> GetAnsweredAsync(IPageInfo pagingSettings, CancellationToken cancellationToken = default)
        {
            var query = GetQuery<PagedAnsweredQuestionsQuery>();
            query.Paging = pagingSettings;

            return query.ExecuteAsync(cancellationToken);
        }

        public Task<IResultWithTotalCount<UnansweredQuestionDto>> GetUnansweredAsync(IPageInfo pagingSettings, CancellationToken cancellationToken = default)
        {
            var query = GetQuery<PagedUnansweredQuestionsQuery>();
            query.Paging = pagingSettings;

            return query.ExecuteAsync(cancellationToken);
        }

        public  Task AddAsync(InputQuestionDto question, out int questionId, CancellationToken token = default)
        {
            var command = GetCommand<InsertQuestionCommand>();
            command.Data = question;

            var result = command.ExecuteAsync(token);

            questionId = command.QuestionId;

            return result;
        }

        public Task<IEnumerable<SyndicationQuestionDto>> GetSyndicationsAsync(int take, CancellationToken token = default)
        {
            var query = GetQuery<SyndicationQuestionsQuery>();
            query.Take = take;

            return query.ExecuteAsync(token);
        }

        public Task EditAsync(QuestionDto question, out bool notFound, CancellationToken token = default)
        {
            var command = GetCommand<UpdateQuestionCommand>();
            command.Data = question;
            var result = command.ExecuteAsync(token);
            notFound = command.NotFound;

            return result;
        }

        public Task<bool> ExistAsync(int id, CancellationToken token = default)
        {
            var query = GetQuery<ExistQuestionQuery>();
            query.QuestionId = id;

            return query.ExecuteAsync(token);
        }

        public QuestionService(ICommandFactory commandFactory, IQueryFactory queryFactory) : base(commandFactory, queryFactory)
        {
        }
    }
}