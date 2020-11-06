using Flunt.Notifications;
using MediatR;
using Streamer.Domain.Commands;
using Streamer.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Streamer.Domain.Handlers
{
    public class ProjectHandler : Notifiable, 
        IRequestHandler<CreateProjectCommand, GenericCommandResult>,
        IRequestHandler<UpdateProjectCommand, GenericCommandResult>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IProjectRepository _projectRepository;

        public ProjectHandler(ICourseRepository courseRepository, IProjectRepository projectRepository)
        {
            _courseRepository = courseRepository;
            _projectRepository = projectRepository;
        }

        public async Task<GenericCommandResult> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro", command.Notifications);

            var course = _courseRepository.GetById(new Guid(command.CourseId));
            if (course == null)
                return new GenericCommandResult(false, "Curso não cadastrado", command.CourseId);

            var project = new Entities.Project(command.Name, command.Image, command.Why, command.What, command.WhatWillWeDo, command.ProjectStatus);

            course.AddProject(project);

            _projectRepository.Create(project);
            _courseRepository.Update(course);

            return new GenericCommandResult(true, "Projeto cadastrado com sucesso", (DTOs.Project)project);
        }

        public async Task<GenericCommandResult> Handle(UpdateProjectCommand command, CancellationToken cancellationToken)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro", command.Notifications);

            var project = _projectRepository.GetById(command.ProjectId);
            if (project == null)
                return new GenericCommandResult(false, "Projeto não cadastrado", command.CourseId);

            project.Update(command.Name, command.Image, command.Why, command.What, command.WhatWillWeDo, command.ProjectStatus);

            _projectRepository.Update(project);

            return new GenericCommandResult(true, "Projeto atualizado com sucesso", (DTOs.Project)project);
        }
    }
}
