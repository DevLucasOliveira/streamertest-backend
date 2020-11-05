using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Streamer.Domain.Commands;
using Streamer.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Streamer.Api.Controllers
{
    [Route("api/projects")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateProject(
            [FromBody] CreateProjectCommand command,
            [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return StatusCode(200, result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(
            [FromRoute] string id,
            [FromServices] IProjectRepository repository)
        {
            return Ok(repository.GetById(new Guid(id)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(
            [FromRoute] string id,
            [FromBody] UpdateProjectCommand command,
            [FromServices] IMediator mediator)
        {
            command.AddProjectId(id);
            var result = await mediator.Send(command);
            return StatusCode(200, result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(
            [FromRoute] string id,
            [FromServices] IProjectRepository repository)
        {
            repository.Delete(new Guid(id));
            return Ok();
        }

    }
}
