using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Commanding
{
    public interface ICommand
    {
        void Execute();

        Task ExecuteAsync(CancellationToken token);
    }

    public interface ICommand<TData> : ICommand
    {
        TData Data { get; set; }
    }
}