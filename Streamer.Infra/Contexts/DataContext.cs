using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Streamer.Domain.Entities;

namespace Streamer.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext() : base() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Course> Course { get; set; }
        public DbSet<Project> Project { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.Entity<Course>().ToTable("Courses");
            modelBuilder.Entity<Course>().HasKey(x => x.Id);
            modelBuilder.Entity<Course>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Course>().HasMany(x => x.Projects).WithOne(x => x.Course).HasForeignKey(x => x.CourseId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<Project>().HasKey(x => x.Id);
            modelBuilder.Entity<Project>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Project>().Property(x => x.Image);
            modelBuilder.Entity<Project>().Property(x => x.Why);
            modelBuilder.Entity<Project>().Property(x => x.What);
            modelBuilder.Entity<Project>().Property(x => x.WhatWillWeDo);
            modelBuilder.Entity<Project>().Property(x => x.ProjectStatus);
            modelBuilder.Entity<Project>().Property(x => x.ProjectStatus);
            modelBuilder.Entity<Project>().HasOne(x => x.Course);

        }
    }
}