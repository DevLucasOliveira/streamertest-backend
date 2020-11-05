using Streamer.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Streamer.Domain.Queries
{
    public class CourseQueries
    {
        public static Expression<Func<Course, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
