namespace Olbrasoft.Commanding
{
    public interface ICommandFactory
    {
        /// <summary>
        /// Create query
        /// </summary>
        /// <typeparam name="T">Type of concrete command</typeparam>
        /// <returns>Command</returns>
        T Create<T>() where T : ICommand;
    }
}