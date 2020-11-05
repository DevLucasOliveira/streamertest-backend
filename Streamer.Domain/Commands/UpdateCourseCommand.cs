using Streamer.Domain.Commands.Bases;
using System;

namespace Streamer.Domain.Commands
{
    public class UpdateCourseCommand : CourseBaseCommand
    {
        public Guid CourseId { get; private set; }

        public void AddCourseId(string id)
        {
            CourseId = new Guid(id);
        }
    }
}
