using CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class CompanyStatementConfig : IEntityTypeConfiguration<CompanyStatement>
    {
        public void Configure(EntityTypeBuilder<CompanyStatement> entity)
        {
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.HasKey(x => x.Id);

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
