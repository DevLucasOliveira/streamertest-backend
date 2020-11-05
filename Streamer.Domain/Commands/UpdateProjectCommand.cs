using Streamer.Domain.Commands.Bases;
using System;

namespace Streamer.Domain.Commands
{
    public class UpdateProjectCommand : ProjectBaseCommand
    {
        public Guid ProjectId { get; private set; }

        public void AddProjectId(string id)
        {
            ProjectId = new Guid(id);
        }
    }
}
