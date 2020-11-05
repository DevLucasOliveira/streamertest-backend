using Streamer.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Streamer.Domain.Queries
{
    public static class ProjectQueries
    {
        public static Expression<Func<Project, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }

    }
}
