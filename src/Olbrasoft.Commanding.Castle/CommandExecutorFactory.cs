using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;

namespace Olbrasoft.Commanding.Castle
{
    public class CommandExecutorFactory :ICommandExecutorFactory
    {
        private readonly IWindsorContainer _container;

        public CommandExecutorFactory(IWindsorContainer container)
        {
            _container = container;
        }


        public ICommandExecutor Get(Type executorType)
        {
            return (ICommandExecutor)_container.Resolve(executorType);

        }
    }
}
