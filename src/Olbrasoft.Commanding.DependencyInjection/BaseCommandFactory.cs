namespace Olbrasoft.Commanding.DependencyInjection
{
    public abstract class BaseCommandFactory : ICommandFactory
    {
        public abstract T CreateCommand<T>() where T : ICommand;
    }
}