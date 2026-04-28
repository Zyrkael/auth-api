using auth_api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace auth_api.Configurations;

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {

        base.Configure(builder);

        builder.ToTable("users");

        builder.Property(x => x.UserName)
            .HasColumnName("user_name")
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Password)
            .HasColumnName("password")
            .IsRequired()
            .HasMaxLength(255);
    }
}
