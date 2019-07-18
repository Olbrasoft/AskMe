using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Commanding
{
    public interface ICommand
    {
        void Execute();

        Task ExecuteAsync(CancellationToken cancellationToken);
    }

    public interface ICommand<TData> : ICommand
    {
        TData Data { get; set; }
    }
}