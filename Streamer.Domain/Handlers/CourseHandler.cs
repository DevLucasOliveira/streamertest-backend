using Flunt.Notifications;
using MediatR;
using Streamer.Domain.Commands;
using Streamer.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Streamer.Domain.Handlers
{
    public class CourseHandler : Notifiable, 
        IRequestHandler<CreateCourseCommand, GenericCommandResult>,
        IRequestHandler<UpdateCourseCommand, GenericCommandResult>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IProjectRepository _projectRepository;

        public CourseHandler(ICourseRepository courseRepository, IProjectRepository projectRepository)
        {
            _courseRepository = courseRepository;
            _projectRepository = projectRepository;
        }

        public async Task<GenericCommandResult> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro", command.Notifications);

            var course = new Entities.Course(command.Name);

            _courseRepository.Create(course);

            return new GenericCommandResult(true, "Curso cadastrado com sucesso", (DTOs.Course)course);
        }

        public async Task<GenericCommandResult> Handle(UpdateCourseCommand command, CancellationToken cancellationToken)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ocorreu um erro", command.Notifications);

            var course = _courseRepository.GetById(command.CourseId);

            course.UpdateName(command.Name);

            _courseRepository.Update(course);

            return new GenericCommandResult(true, "Curso atualizado com sucesso", (DTOs.Course)course);
        }
    }
}
