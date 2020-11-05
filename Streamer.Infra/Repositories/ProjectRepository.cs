using Microsoft.EntityFrameworkCore;
using Streamer.Domain.Entities;
using Streamer.Domain.Queries;
using Streamer.Domain.Repositories;
using Streamer.Infra.Contexts;
using System;
using System.Linq;

namespace Streamer.Infra.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;

        public ProjectRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Project project)
        {
            _context.Project.Add(project);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public Project GetById(Guid id)
        {
            return _context.Project.AsNoTracking().FirstOrDefault(ProjectQueries.GetById(id));
        }

        public void Update(Project project)
        {
            _context.Entry(project).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
