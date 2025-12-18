using Microsoft.EntityFrameworkCore;

namespace Project.Infrastructure
{
    /// <inheritdoc />
    public sealed class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
