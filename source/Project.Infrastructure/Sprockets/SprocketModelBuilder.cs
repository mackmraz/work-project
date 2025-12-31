using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Infrastructure.Sprockets
{
    public class SprocketModelBuilder : IEntityTypeConfiguration<Sprocket>
    {
        public void Configure(EntityTypeBuilder<Sprocket> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedNever();
        }
    }
}
