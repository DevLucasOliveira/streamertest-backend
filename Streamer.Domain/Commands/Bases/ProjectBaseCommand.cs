using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using Streamer.Domain.Enums;
using Streamer.Shared.Commands;

namespace Streamer.Domain.Commands.Bases
{
    public class ProjectBaseCommand : Notifiable, ICommand, IRequest<GenericCommandResult>
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Why { get; set; }
        public string What { get; set; }
        public string WhatWillWeDo { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public string CourseId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(Name, "Name", "O nome do projeto não pode ser vazio")
                .IsNotNullOrEmpty(CourseId, "CourseId", "O projeto deve conter um curso")
                );
        }
    }
}
