using Streamer.Project.Shared.Entities;

namespace Streamer.Project.Domain.Entities
{
    public class Project : Entity
    {
        public Project(string name, string image, string why, string what, string whatWillWeDo)
        {
            Name = name;
            Image = image;
            Why = why;
            What = what;
            WhatWillWeDo = whatWillWeDo;
        }

        public string Name { get; private set; }
        public string Image { get; private set; }
        public string Why { get; private set; }
        public string What { get; private set; }
        public string WhatWillWeDo { get; private set; }
    }
}
