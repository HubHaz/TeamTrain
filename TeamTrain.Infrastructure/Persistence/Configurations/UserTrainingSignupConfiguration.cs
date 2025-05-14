using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamTrain.Domain.Entities;

namespace TeamTrain.Infrastructure.Persistence.Configurations;

public class UserTrainingSignupConfiguration : IEntityTypeConfiguration<UserTrainingSignup>
{
    public void Configure(EntityTypeBuilder<UserTrainingSignup> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.SignupDateTime).IsRequired();
    }
}