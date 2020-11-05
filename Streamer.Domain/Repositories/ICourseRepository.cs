using Streamer.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Streamer.Domain.Repositories
{
    public interface ICourseRepository
    {
        void Create(Course course);
        IEnumerable<Course> GetAll();
        Course GetById(Guid id);
        void Update(Course course);
        void Delete(Guid id);
    }
}
