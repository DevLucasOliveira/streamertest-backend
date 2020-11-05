using Streamer.Project.Shared.Entities;
using System.Collections.Generic;

namespace Streamer.Project.Domain.Entities
{
    public class Course : Entity
    {
        public Course(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public ICollection<Project> Products { get; private set; }
    }
}
