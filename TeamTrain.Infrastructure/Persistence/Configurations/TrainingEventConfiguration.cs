using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamTrain.Domain.Entities;

namespace TeamTrain.Infrastructure.Persistence.Configurations;

public class TrainingEventConfiguration : IEntityTypeConfiguration<TrainingEvent>
{
    public void Configure(EntityTypeBuilder<TrainingEvent> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(t => t.Location)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(t => t.StartTime).IsRequired();
        builder.Property(t => t.Duration).IsRequired();

        builder.HasOne(t => t.Coach)
            .WithMany()
            .HasForeignKey(t => t.CoachId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(t => t.Signups)
            .WithOne(s => s.TrainingEvent)
            .HasForeignKey(s => s.TrainingEventId);
    }
}