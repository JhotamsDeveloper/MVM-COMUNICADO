using CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class RolesConfig : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> entity)
        {
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.HasKey(x => x.Id);

            entity.Property(e => e.NameRoles)
                .IsRequired()
                .HasMaxLength(255);
        }
    }

}
