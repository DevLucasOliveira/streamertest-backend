using Streamer.Project.Shared.Commands;

namespace Streamer.Project.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
