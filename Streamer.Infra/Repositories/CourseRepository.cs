using Microsoft.EntityFrameworkCore;
using Streamer.Domain.Entities;
using Streamer.Domain.Queries;
using Streamer.Domain.Repositories;
using Streamer.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Streamer.Infra.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DataContext _context;

        public CourseRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Course course)
        {
            _context.Course.Add(course);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Course.AsNoTracking().ToList();
        }

        public Course GetById(Guid id)
        {
            return _context.Course.AsNoTracking().Where(CourseQueries.GetById(id)).Include(x => x.Projects).First();
        }

        public void Update(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
