using CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Infrastructure.Data
{
    public partial class dbMVMComunicadoContext : DbContext
    {
        public dbMVMComunicadoContext()
        {
        }

        public dbMVMComunicadoContext(DbContextOptions<dbMVMComunicadoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditSystem> AuditSystem { get; set; }
        public virtual DbSet<CompanyStatement> CompanyStatement { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<UserSystem> UserSystem { get; set; }
        public virtual DbSet<UserSystemRoles> UserSystemRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ProccessAudiit();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ProccessAudiit()
        {
            var _dateCreate = DateTimeOffset.UtcNow;
            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added && e.Entity is BaseEntity))
            {

            }
        }
    }
}
