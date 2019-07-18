namespace Olbrasoft.Data.Commanding
{
    public interface ICommandFactory
    {
        /// <summary>
        /// Get query
        /// </summary>
        /// <typeparam name="T">Type of concrete command</typeparam>
        /// <returns>Command</returns>
        T Get<T>() where T : ICommand;
    }
}