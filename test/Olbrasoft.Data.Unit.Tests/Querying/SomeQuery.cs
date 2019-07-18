using System;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.Data.Unit.Tests.Querying
{
    public class SomeQuery : Query<AwesomeObject>
    {
       
        public SomeQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}