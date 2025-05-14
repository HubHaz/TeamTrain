using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamTrain.Domain.Entities;

namespace TeamTrain.Infrastructure.Persistence.Configurations;

public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
{
    public void Configure(EntityTypeBuilder<Membership> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.StartDate).IsRequired();
        builder.Property(m => m.EndDate).IsRequired();
    }
}