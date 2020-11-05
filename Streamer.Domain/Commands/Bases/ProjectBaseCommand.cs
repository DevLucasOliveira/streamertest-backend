using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using Streamer.Shared.Commands;

namespace Streamer.Domain.Commands.Bases
{
    public class ProjectBaseCommand : Notifiable, ICommand, IRequest<GenericCommandResult>
    {
        public string Name { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(Name, "Name", "O nome do projeto não pode ser vazio"));
        }
    }
}
