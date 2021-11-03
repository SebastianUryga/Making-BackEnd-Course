using System.Threading.Tasks;

namespace Passenger.Infrastructure.Commends
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
