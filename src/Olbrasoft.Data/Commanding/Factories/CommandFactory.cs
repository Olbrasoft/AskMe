using Olbrasoft.Dependence;

namespace Olbrasoft.Data.Commanding.Factories
{
    public class CommandFactory : ICommandFactory
    {
        public CommandFactory(IResolver objectResolver)
        {
            ObjectResolver = objectResolver;
        }

        protected IResolver ObjectResolver { get; }

        public T Get<T>() where T : ICommand
        {
            return (T)ObjectResolver.Resolve(typeof(T));
        }
    }
}