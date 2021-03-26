using CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class AuditSystemConfig : IEntityTypeConfiguration<AuditSystem>
    {
        public void Configure(EntityTypeBuilder<AuditSystem> entity)
        {
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.HasKey(x => x.Id);

            entity.Property(e => e.DateCreate).HasColumnType("datetime");

            entity.Property(e => e.DateUpdate).HasColumnType("datetime");

            entity.HasOne(d => d.UserSystemNavigation)
                .WithMany(p => p.AuditSystem)
                .HasForeignKey(d => d.UserSystem)
                .HasConstraintName("FK__AuditSyst__UserS__3A81B327");
        }
    }
}
