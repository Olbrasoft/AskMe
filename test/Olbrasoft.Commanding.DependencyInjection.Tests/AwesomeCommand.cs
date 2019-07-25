using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Commanding.DependencyInjection
{
    public class AwesomeCommand : ICommand
    {
        public void Execute() => throw new NotImplementedException();

        public Task ExecuteAsync(CancellationToken token) => throw new NotImplementedException();
    }
}
