using Streamer.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Streamer.Domain.Repositories
{
    public interface IProjectRepository
    {
        void Create(Project project);
        Project GetById(Guid id);
        void Update(Project project);
        void Delete(Guid id);
    }
}
