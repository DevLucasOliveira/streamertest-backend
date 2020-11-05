using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Streamer.Domain.Commands;
using Streamer.Domain.DTOs;
using Streamer.Domain.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Streamer.Api.Controllers
{
    [Route("api/courses")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateCourse(
            [FromBody] CreateCourseCommand command,
            [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            return StatusCode(200, result);
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromServices] ICourseRepository repository)
        {
            var entities = repository.GetAll();
            return Ok(entities.Select(entity => (Course)entity));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(
            [FromRoute] string id,
            [FromServices] ICourseRepository repository)
        {
            return Ok((Course)repository.GetById(new Guid(id)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(
            [FromRoute] string id,
            [FromBody] UpdateCourseCommand command,
            [FromServices] IMediator mediator)
        {
            command.AddCourseId(id);
            var result = await mediator.Send(command);
            return StatusCode(200, result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(
            [FromRoute] string id,
            [FromServices] ICourseRepository repository)
        {
            repository.Delete(new Guid(id));
            return Ok();
        }

    }
}
