using CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class CompanyStatementConfig : IEntityTypeConfiguration<CompanyStatement>
    {
        public void Configure(EntityTypeBuilder<CompanyStatement> entity)
        {
            entity.Property(e => e.ID).HasColumnName("ID");
            entity.HasKey(x => x.ID);

            entity.HasOne(d => d.DestinataryNavigation)
                .WithMany(p => p.CompanyStatementDestinataryNavigation)
                .HasForeignKey(d => d.Destinatary)
                .HasConstraintName("FK__CompanySt__Desti__37A5467C");

            entity.HasOne(d => d.RemitentNavigation)
                .WithMany(p => p.CompanyStatementRemitentNavigation)
                .HasForeignKey(d => d.Remitent)
                .HasConstraintName("FK__CompanySt__Remit__36B12243");
        }
    }
}
