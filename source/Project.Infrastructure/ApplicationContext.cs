using Microsoft.EntityFrameworkCore;
using Project.Infrastructure.Sprockets;
using System.Reflection;

namespace Project.Infrastructure
{
    /// <inheritdoc />
    public sealed class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
            Sprockets = Set<Sprocket>();
        }

        public DbSet<Sprocket> Sprockets { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
