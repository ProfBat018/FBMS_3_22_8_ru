using ControllerFirst.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControllerFirst.Data.Config;

public class RoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> entity)
    {
      
            entity.HasKey(e => e.RoleName).HasName("PK__Roles__B19478603A776CCC");

            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("roleName");
    }
}