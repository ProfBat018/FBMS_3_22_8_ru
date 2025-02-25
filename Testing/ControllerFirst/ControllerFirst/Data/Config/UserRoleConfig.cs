using ControllerFirst.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControllerFirst.Data.Config;

public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> entity)
    {
        entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__CD3149CCDE4D7241");

        entity.Property(e => e.UserRoleId).HasColumnName("userRoleId");
        entity.Property(e => e.RoleNameRef)
            .HasMaxLength(50)
            .HasColumnName("roleNameRef");
        entity.Property(e => e.UserNameRef)
            .HasMaxLength(50)
            .HasColumnName("userNameRef");

        entity.HasOne(d => d.RoleNameRefNavigation).WithMany(p => p.UserRoles)
            .HasForeignKey(d => d.RoleNameRef)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__UserRoles__roleN__2B3F6F97");

        entity.HasOne(d => d.UserNameRefNavigation).WithMany(p => p.UserRoles)
            .HasForeignKey(d => d.UserNameRef)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK__UserRoles__userN__2A4B4B5E");
    }
}