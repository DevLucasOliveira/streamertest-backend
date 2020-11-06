using Streamer.Domain.Enums;
using Streamer.Shared.Entities;
using System;

namespace Streamer.Domain.Entities
{
    public class Project : Entity
    {
        public Project(string name, string image, string why, string what, string whatWillWeDo, ProjectStatus projectStatus)
        {
            Name = name;
            Image = image;
            Why = why;
            What = what;
            WhatWillWeDo = whatWillWeDo;
            ProjectStatus = projectStatus;
        }

        public string Name { get; private set; }
        public string Image { get; private set; }
        public string Why { get; private set; }
        public string What { get; private set; }
        public string WhatWillWeDo { get; private set; }
        public ProjectStatus ProjectStatus { get; private set; }
        public Guid CourseId { get; private set; }
        public Course Course { get; private set; }

        public void Update(string name, string image, string why, string what, string whatWillWeDo, ProjectStatus projectStatus)
        {
            Name = name;
            Image = image;
            Why = why;
            What = what;
            WhatWillWeDo = whatWillWeDo;
            ProjectStatus = projectStatus;
        }
    }
}
