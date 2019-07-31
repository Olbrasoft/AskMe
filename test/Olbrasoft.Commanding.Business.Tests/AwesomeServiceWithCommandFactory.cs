namespace Olbrasoft.Commanding.Business
{
    public class AwesomeServiceWithCommandFactory :ServiceWithCommandFactory
    {
        public AwesomeServiceWithCommandFactory(ICommandFactory commandFactory) : base(commandFactory)
        {
        }

        public void CallGetCommand()
        {
            GetCommand<Command>();
        }
    }
}