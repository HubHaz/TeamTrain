using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamTrain.Domain.Entities.App;

namespace TeamTrain.Infrastructure.Persistence.Configurations;

public class MembershipTypeConfiguration : IEntityTypeConfiguration<MembershipType>
{
    public void Configure(EntityTypeBuilder<MembershipType> builder)
    {
        builder.HasKey(mt => mt.Id);

        builder.Property(mt => mt.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(mt => mt.ValidForDays)
            .IsRequired();

        builder.HasMany(mt => mt.Memberships)
            .WithOne(m => m.MembershipType)
            .HasForeignKey(m => m.MembershipTypeId);
    }
}