﻿using System.Threading;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Commands;
using Olbrasoft.Commanding.Mapping.EntityFrameworkCore;
using Olbrasoft.Mapping;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore.CommandHandlers
{
    public class InputQuestionCommandHandler : CommandHandlerWithMapperAndDbContext<InputQuestionCommand, AskDbContext>
    {
        public InputQuestionCommandHandler(IMapper mapper, AskDbContext context) : base(mapper, context)
        {
        }

        public override async Task HandleAsync(InputQuestionCommand command, CancellationToken token)
        {
            var question = MapTo<Question>(command.Data);

            await Task.WhenAll(
                  Context.Questions.AddAsync(question, token),
                  Context.SaveChangesAsync(token));

            command.QuestionId = question.Id;
        }
    }
}