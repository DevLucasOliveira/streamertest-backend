using Streamer.Domain.Enums;

namespace Streamer.Domain.DTOs
{
    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Why { get; set; }
        public string What { get; set; }
        public string WhatWillWeDo { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public string CourseId { get; set; }


        public static implicit operator Project(Entities.Project entity)
        {
            return new Project()
            {
                Id = entity.Id.ToString(),
                Name = entity.Name,
                Image = entity.Image,
                Why = entity.Why,
                What = entity.What,
                WhatWillWeDo = entity.WhatWillWeDo,
                ProjectStatus = entity.ProjectStatus,
                CourseId = entity.CourseId.ToString()
            };
        }
    }
}
