using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Data.Commanding
{
    public interface ICommandDispatcher
    {
        void Dispatch(ICommand command);

        Task DispatchAsync(ICommand command, CancellationToken token);
    }
}