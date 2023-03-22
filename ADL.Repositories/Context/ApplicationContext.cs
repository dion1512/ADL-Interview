using ADL.Data.Entities;
using ADL.Data.Maps;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ADL.Repositories.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CalloutMap(modelBuilder.Entity<Callout>());
            new CategoryMap(modelBuilder.Entity<Category>());
            new ScheduleMap(modelBuilder.Entity<Schedule>());

        }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Callout> Callout { get; set; }
    }
}