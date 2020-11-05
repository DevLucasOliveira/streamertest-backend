using Streamer.Shared.Entities;
using System.Collections.Generic;

namespace Streamer.Domain.Entities
{
    public class Course : Entity
    {
        public Course(string name)
        {
            Name = name;
            Projects = new List<Project>();
        }

        public string Name { get; private set; }
        public ICollection<Project> Projects { get; private set; }

        public void UpdateName(string name)
        {
            Name = name;
        }

    }
}
