using Moq;
using Moq.AutoMock;
using Streamer.Domain.Commands;
using Streamer.Domain.Entities;
using Streamer.Domain.Enums;
using Streamer.Domain.Handlers;
using Streamer.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Streamer.Test.Handlers
{
    public class ProjectHandlerTest
    {
        private AutoMocker _mocker;

        public ProjectHandlerTest()
        {
            _mocker = new AutoMocker();

        }

        [Fact]
        public async Task CreateProject_WhenCommandIsValid_ReturnShouldBeOk()
        {
            // Arrange
            var command = CreateCommand();
            var project = _mocker.CreateInstance<ProjectHandler>();
            _mocker.GetMock<ICourseRepository>().Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns(GetCourse());

            // Act
            command.Validate();

            var requestResult = await project.Handle(command, CancellationToken.None);


            // Assert
            Assert.NotNull(requestResult);
            Assert.NotEmpty(requestResult.Message);
            Assert.True(requestResult.Success);
        }

        [Fact]
        public async Task CreateProject_WhenCommandIsInValid_ReturnShouldBeError()
        {
            // Arrange
            var command = CreateCommandInvalid();
            var project = _mocker.CreateInstance<ProjectHandler>();
            // Act
            command.Validate();
            var requestResult = await project.Handle(command, CancellationToken.None);


            // Assert
            Assert.NotNull(requestResult);
            Assert.NotEmpty(requestResult.Message);
            Assert.False(requestResult.Success);
        }

        [Fact]
        public async Task CreateProject_WhenCourseNotExists_ReturnShouldBeError()
        {
            // Arrange
            var command = CreateCommand();
            var project = _mocker.CreateInstance<ProjectHandler>();
            _mocker.GetMock<ICourseRepository>().Setup(x => x.GetById(It.IsAny<Guid>()));

            // Act
            command.Validate();

            var requestResult = await project.Handle(command, CancellationToken.None);


            // Assert
            Assert.NotNull(requestResult);
            Assert.NotEmpty(requestResult.Message);
            Assert.False(requestResult.Success);
        }

        [Fact]
        public async Task UpdateProject_WhenCommandIsValid_ReturnShouldBeOk()
        {
            // Arrange
            var command = UpdateCommand();
            var project = _mocker.CreateInstance<ProjectHandler>();
            _mocker.GetMock<IProjectRepository>().Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns(GetProject());

            // Act
            command.Validate();

            var requestResult = await project.Handle(command, CancellationToken.None);


            // Assert
            Assert.NotNull(requestResult);
            Assert.NotEmpty(requestResult.Message);
            Assert.True(requestResult.Success);
        }

        [Fact]
        public async Task UpdateProject_WhenCommandIsInValid_ReturnShouldBeError()
        {
            // Arrange
            var command = UpdateCommandInvalid();
            var project = _mocker.CreateInstance<ProjectHandler>();
            // Act
            command.Validate();
            var requestResult = await project.Handle(command, CancellationToken.None);


            // Assert
            Assert.NotNull(requestResult);
            Assert.NotEmpty(requestResult.Message);
            Assert.False(requestResult.Success);
        }

        [Fact]
        public async Task UpdateProject_WhenProjectNotExists_ReturnShouldBeError()
        {
            // Arrange
            var command = UpdateCommandInvalid();
            var project = _mocker.CreateInstance<ProjectHandler>();
            _mocker.GetMock<IProjectRepository>().Setup(x => x.GetById(It.IsAny<Guid>()));

            // Act
            command.Validate();
            var requestResult = await project.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(requestResult);
            Assert.NotEmpty(requestResult.Message);
            Assert.False(requestResult.Success);
        }

        public Course GetCourse()
        {
            return new Course("Teste");
        }

        public Project GetProject()
        {
            return new Project("Teste", "Teste", "Teste", "Teste", "Teste", ProjectStatus.Desenvolvimento);
        }

        public CreateProjectCommand CreateCommand()
        {
            return new CreateProjectCommand()
            {
                Name = "Teste",
                Image = "Teste",
                Why = "Teste",
                What = "Teste",
                WhatWillWeDo = "Teste",
                ProjectStatus = ProjectStatus.Desenvolvimento,
                CourseId = Guid.NewGuid().ToString()
            };
        }

        public CreateProjectCommand CreateCommandInvalid()
        {
            return new CreateProjectCommand()
            {
                Name = "",
                Image = "Teste",
                Why = "Teste",
                What = "Teste",
                WhatWillWeDo = "Teste",
                ProjectStatus = ProjectStatus.Desenvolvimento,
                CourseId = ""
            };
        }

        public UpdateProjectCommand UpdateCommand()
        {
            return new UpdateProjectCommand()
            {
                Name = "Teste",
                Image = "Teste",
                Why = "Teste",
                What = "Teste",
                WhatWillWeDo = "Teste",
                ProjectStatus = ProjectStatus.Desenvolvimento,
                CourseId = Guid.NewGuid().ToString()
            };
        }

        public UpdateProjectCommand UpdateCommandInvalid()
        {
            return new UpdateProjectCommand()
            {
                Name = "",
                Image = "Teste",
                Why = "Teste",
                What = "Teste",
                WhatWillWeDo = "Teste",
                ProjectStatus = ProjectStatus.Desenvolvimento,
                CourseId = ""
            };
        }
    }
}
