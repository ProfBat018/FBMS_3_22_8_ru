using ControllerFirst.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControllerFirst.Data.Config;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.HasKey(e => e.UserName).HasName("PK__Users__66DCF95D7E0943AE");

        entity.HasIndex(e => e.Email, "UQ__Users__AB6E61646FB653B8").IsUnique();

        entity.Property(e => e.UserName)
            .HasMaxLength(50)
            .HasColumnName("userName");
        entity.Property(e => e.Email)
            .HasMaxLength(50)
            .HasColumnName("email");
        entity.Property(e => e.IsEmailConfirmed)
            .HasDefaultValue(false)
            .HasColumnName("isEmailConfirmed");
        
        entity.Property(e => e.RefreshToken)
            .HasColumnName("refreshToken");
        entity.Property(e => e.Password).HasColumnName("password");

        entity.Property(e => e.RefreshTokenExpiration)
            .HasColumnName("refreshTokenExpiration")
            .IsRequired(true);

        entity.HasIndex(e => e.RefreshToken)
            .IsUnique()
            .HasDatabaseName("UQ_RefreshToken")
            
            ;
    }
}