using System.Collections.Generic;
using System.Linq;

namespace Streamer.Domain.DTOs
{
    public class Course
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Project> Projects { get; set; }

        public static implicit operator Course(Entities.Course entity)
        {
            return new Course
            {
                Id = entity.Id.ToString(),
                Name = entity.Name,
                Projects = entity.Projects.Select(entity => (Project)entity).ToList()
            };
        }
    }
}
