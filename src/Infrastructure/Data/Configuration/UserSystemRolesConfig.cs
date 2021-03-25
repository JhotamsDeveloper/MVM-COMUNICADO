using CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class UserSystemRolesConfig : IEntityTypeConfiguration<UserSystemRoles>
    {
        public void Configure(EntityTypeBuilder<UserSystemRoles> entity)
        {
            entity.HasOne(d => d.RolesNavigation)
                .WithMany(p => p.UserSystemRoles)
                .HasForeignKey(d => d.Roles)
                .HasConstraintName("FK__UserSyste__Roles__33D4B598");

            entity.HasOne(d => d.UserSystemNavigation)
                .WithMany(p => p.UserSystemRoles)
                .HasForeignKey(d => d.UserSystem)
                .HasConstraintName("FK__UserSyste__UserS__32E0915F");
        }
    }
}
