using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Dapper;
using Olbrasoft.Data;
using Olbrasoft.Paging;
using Olbrasoft.Querying.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.AskMe.Data.Dapper.QueryHandlers
{
    public class PagedAnsweredQuestionsQueryHandler : QueryHandlerWithDbConnectionFactory<PagedAnsweredQuestionsQuery, IResultWithTotalCount<QuestionDto>>
    {
        public PagedAnsweredQuestionsQueryHandler(IDbConnectionFactory factory) : base(factory)
        {
        }

        public override async Task<IResultWithTotalCount<QuestionDto>> HandleAsync(PagedAnsweredQuestionsQuery query, CancellationToken token)
        {
            //const string sql = @"SELECT Questions.Id, Questions.DateCreated, Questions.DateAnswered, Questions.QuestionText, Questions.DisplayName, Questions.EmailAddress, Questions.AnswerText, Categories.Name AS CategoryName
            //FROM Questions INNER JOIN
            //Categories ON Questions.CategoryId = Categories.Id
            //WHERE(NOT(Questions.DateAnswered IS NULL))
            //ORDER BY Questions.DateAnswered DESC LIMIT @Take OFFSET @Skip;

            //SELECT count(id) FROM Questions WHERE (NOT (Questions.DateAnswered IS NULL))";


            const string sql = @"SELECT Questions.Id, Questions.DateCreated, Questions.DateAnswered, Questions.QuestionText, Questions.DisplayName, Questions.EmailAddress, Questions.AnswerText, Categories.Name AS CategoryName
            FROM Questions INNER JOIN
            Categories ON Questions.CategoryId = Categories.Id
            WHERE(NOT(Questions.DateAnswered IS NULL))
            ORDER BY Questions.DateAnswered DESC OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY;

            SELECT count(id) FROM Questions WHERE (NOT (Questions.DateAnswered IS NULL))";


            IResultWithTotalCount<QuestionDto> result;

            using (var connection = GetConnection())
            {
                using (var multi = connection.QueryMultipleAsync(sql, new { Take = query.Paging.PageSize, Skip = query.Paging.CalculateSkip() }).Result)
                {
                    result = new ResultWithTotalCount<QuestionDto>
                    {
                        Result = (await multi.ReadAsync<QuestionDto>()).ToArray(),


                        // SQLite TotalCount = (int) await multi.ReadFirstAsync<long>()

                        TotalCount = await multi.ReadFirstAsync<int>()
                    };
                }
            }
            
            return result;
        }
    }
}