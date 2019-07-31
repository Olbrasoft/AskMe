namespace Olbrasoft.Commanding.Business
{
    public class ServiceWithCommandFactory
    {
        private readonly ICommandFactory _commandFactory;

        public ServiceWithCommandFactory(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        protected TCommand GetCommand<TCommand>() where TCommand : ICommand
        {
            return _commandFactory.CreateCommand<TCommand>();
        }
    }
}