using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DataAccess
{
    public class TaskTrackerDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public TaskTrackerDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            // Database.EnsureDeleted();
            // Database.EnsureCreated();
        }

        private DbSet<TodoItem> TodoItems { get; set; }
        private DbSet<TodoList> TodoLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration["ConnectionStrings:Pgsql"]);
            optionsBuilder.UseLoggerFactory(GetLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedTimestamp = DateTime.Now;
                        entry.Entity.UpdatedTimestamp = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedTimestamp = DateTime.Now;
                        break;
                }
            }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedTimestamp = DateTime.Now;
                        entry.Entity.UpdatedTimestamp = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedTimestamp = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        private static readonly ILoggerFactory GetLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddProvider(new ConsoleLoggerProvider());
        });
    }
}