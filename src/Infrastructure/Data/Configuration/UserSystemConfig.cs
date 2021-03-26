using CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class UserSystemConfig : IEntityTypeConfiguration<UserSystem>
    {
        public void Configure(EntityTypeBuilder<UserSystem> entity)
        {
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.HasKey(x => x.Id);

            entity.Property(e => e.AddressUser).HasMaxLength(255);

            entity.Property(e => e.Document)
                .IsRequired()
                .HasMaxLength(15);

            entity.Property(e => e.Email).HasMaxLength(255);

            entity.Property(e => e.NameUser)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.Phone).HasMaxLength(20);
        }
    }
}
