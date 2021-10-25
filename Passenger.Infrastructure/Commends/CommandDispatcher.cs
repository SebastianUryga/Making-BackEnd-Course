using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Commends
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;
        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }
        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            var handler = _context.Resolve<ICommandHandler<T>>();
            await handler.HandleAsync(command);
        }
    }
}
