﻿using Olbrasoft.Data.Commanding;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.AskMe.Business.Services
{
    public abstract class Service
    {
        protected IQueryFactory QueryFactory { get; }

        protected ICommandFactory CommandFactory { get; }

        protected Service( ICommandFactory commandFactory, IQueryFactory queryFactory)
        {
            CommandFactory = commandFactory;
            QueryFactory = queryFactory;
        }
    }
}