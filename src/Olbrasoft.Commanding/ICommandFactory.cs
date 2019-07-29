namespace Olbrasoft.Commanding
{
    public interface ICommandFactory
    {
        /// <summary>
        /// CreateCommand query
        /// </summary>
        /// <typeparam name="T">Type of concrete command</typeparam>
        /// <returns>Command</returns>
        T CreateCommand<T>() where T : ICommand;
    }
}