using Moq;
using Moq.AutoMock;
using Streamer.Domain.Commands;
using Streamer.Domain.Entities;
using Streamer.Domain.Handlers;
using Streamer.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Streamer.Test.Handlers
{
    public class CourseHandlerTest
    {
        private AutoMocker _mocker;

        public CourseHandlerTest()
        {
            _mocker = new AutoMocker();
            
        }

        [Fact]
        public async Task CreateCourse_WhenCommandIsValid_ReturnShouldBeOk()
        {
            // Arrange
            var command = CreateCommand();
            var course = _mocker.CreateInstance<CourseHandler>();

            // Act
            command.Validate();

            var requestResult = await course.Handle(command, CancellationToken.None);


            // Assert
            Assert.NotNull(requestResult);
            Assert.NotEmpty(requestResult.Message);
            Assert.True(requestResult.Success);
        }

        [Fact]
        public async Task CreateCourse_WhenCommandIsInValid_ReturnShouldBeError()
        {
            // Arrange
            var command = CreateCommandInvalid();
            var course = _mocker.CreateInstance<CourseHandler>();
            // Act
            command.Validate();
            var requestResult = await course.Handle(command, CancellationToken.None);


            // Assert
            Assert.NotNull(requestResult);
            Assert.NotEmpty(requestResult.Message);
            Assert.False(requestResult.Success);
        }

        [Fact]
        public async Task UpdateCourse_WhenCommandIsValid_ReturnShouldBeOk()
        {
            // Arrange
            var command = UpdateCommand();
            var course = _mocker.CreateInstance<CourseHandler>();
            _mocker.GetMock<ICourseRepository>().Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns(GetCourse());

            // Act
            command.Validate();

            var requestResult = await course.Handle(command, CancellationToken.None);


            // Assert
            Assert.NotNull(requestResult);
            Assert.NotEmpty(requestResult.Message);
            Assert.True(requestResult.Success);
        }

        [Fact]
        public async Task UpdateCourse_WhenCommandIsInValid_ReturnShouldBeError()
        {
            // Arrange
            var command = UpdateCommandInvalid();
            var course = _mocker.CreateInstance<CourseHandler>();
            // Act
            command.Validate();
            var requestResult = await course.Handle(command, CancellationToken.None);


            // Assert
            Assert.NotNull(requestResult);
            Assert.NotEmpty(requestResult.Message);
            Assert.False(requestResult.Success);
        }

        public Course GetCourse()
        {
            return new Course("Teste");
        }

        public CreateCourseCommand CreateCommand()
        {
            return new CreateCourseCommand()
            {
                Name = "Teste"
            };
        }

        public CreateCourseCommand CreateCommandInvalid()
        {
            return new CreateCourseCommand()
            {
                Name = ""
            };
        }

        public UpdateCourseCommand UpdateCommand()
        {
            return new UpdateCourseCommand()
            {
                Name = "Teste"
            };
        }

        public UpdateCourseCommand UpdateCommandInvalid()
        {
            return new UpdateCourseCommand()
            {
                Name = ""
            };
        }
    }
}
