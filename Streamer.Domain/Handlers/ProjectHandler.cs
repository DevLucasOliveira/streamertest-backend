using Flunt.Notifications;
using MediatR;
using Streamer.Domain.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Streamer.Domain.Handlers
{
    public class ProjectHandler : Notifiable, IRequestHandler<CreateProjectCommand, GenericCommandResult>
    {
        public Task<GenericCommandResult> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
