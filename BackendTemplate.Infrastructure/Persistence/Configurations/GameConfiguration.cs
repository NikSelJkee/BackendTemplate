using BackendTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendTemplate.Infrastructure.Persistence.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.Property(p => p.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.OwnsOne(p =>
                p.Info,
                builder =>
                {
                    builder.Property(i => i.Description)
                        .HasMaxLength(250)
                        .IsRequired();
                    builder.Property(i => i.Release)
                        .IsRequired();
                    builder.Property(i => i.Rating)
                        .IsRequired();
                });
        }
    }
}
