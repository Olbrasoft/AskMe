namespace Olbrasoft.Commanding.DependencyInjection
{
    public abstract class BaseCommandFactory : ICommandFactory
    {
        public abstract T Create<T>() where T : ICommand;
    }
}